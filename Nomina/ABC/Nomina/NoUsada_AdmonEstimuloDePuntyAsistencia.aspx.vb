Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Partial Class ABC_Nomina_AdmonEstimuloDePuntyAsistencia
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Me.MultiView1.SetActiveView(Me.viewOperacion)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            If Request.Params("TipoOperacion") = "3" Then
                txtbxRFC.Text = Request.Params("RFC")
                hfRFC.Value = Request.Params("RFC")
                txtbxNomEmp.Text = Request.Params("Nombre")
                hfNomEmp.Value = Request.Params("Nombre")
                Session.Add("NoLimpiar", "Ok")
                ibBuscarEmp.Visible = False
                Me.btnGuardar.Text = "Eliminar"
            ElseIf Request.Params("TipoOperacion") = "1" Then
                Session.Add("NoLlenar", "Ok")
                ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false")
                Me.btnGuardar.Text = "Guardar"
            End If
            'BindQnas()
            Me.lbCerrar.OnClientClick = "javascript:window.close();"
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)

            If hfRFC.Value = String.Empty Then
                Me.lblError.Text = "Información de empleado requerida."
                Me.MultiView1.SetActiveView(Me.viewError)
                Me.lbContinuar.Visible = True
                Exit Sub
            End If

            Dim oValidacion As New Validaciones
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsValida As DataSet
            dsValida = _DataCOBAEV.setDataSetErrores()

            With oValidacion
                .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                .RFC = hfRFC.Value
                .IdSemestre = CShort(Request.Params("IdSemestre"))
                .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
                If Not .ValidaPaginasOperacion(dsValida) Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            End With

            Dim oEmp As New Empleado
            oEmp.RFC = hfRFC.Value
            If Request.Params("TipoOperacion") = "1" Then
                oEmp.InsEstDePuntYAsist(CShort(Request.Params("IdSemestre")), CType(Session("ArregloAuditoria"), String()))
            ElseIf Request.Params("TipoOperacion") = "3" Then
                oEmp.EliminaDeEstDePuntYAsist(CShort(Request.Params("IdSemestre")), CType(Session("ArregloAuditoria"), String()))
            End If
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
            Me.lbContinuar.Visible = False
        End Try
    End Sub

    Protected Sub lbContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbContinuar.Click
        Me.MultiView1.SetActiveView(Me.viewOperacion)
    End Sub
End Class
