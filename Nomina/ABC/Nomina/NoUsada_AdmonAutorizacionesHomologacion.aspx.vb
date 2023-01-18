Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Partial Class ABC_Empleados_AdmonAutorizacionesHomologacion
    Inherits System.Web.UI.Page
    Private Sub BindQnas()
        Dim oQna As New Quincenas
        Dim crItem As ListItem
        With Me.ddlQnas
            .DataSource = oQna.ObtenAbiertasParaCaptura
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas abiertas para captura")
                .Items(0).Value = -1
                Me.btnGuardar.Enabled = False
            Else
                If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3" Then
                    crItem = .Items.FindByValue(Request.Params("IdQuincena"))
                    If crItem Is Nothing Then
                        btnGuardar.Enabled = False
                    Else
                        .SelectedValue = Request.Params("IdQuincena")
                    End If
                End If
            End If
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Me.MultiView1.SetActiveView(Me.viewAutorizacion)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3" Then
                txtbxRFC.Text = Request.Params("RFC")
                hfRFC.Value = Request.Params("RFC")
                txtbxNomEmp.Text = Request.Params("Nombre")
                hfNomEmp.Value = Request.Params("Nombre")
                Session.Add("NoLimpiar", "Ok")
                ibBuscarEmp.Visible = False
                If Request.Params("TipoOperacion") = "0" Then Me.btnGuardar.Text = "Actualizar"
                If Request.Params("TipoOperacion") = "3" Then
                    Me.ddlQnas.Enabled = False
                    Me.btnGuardar.Text = "Eliminar"
                End If
            ElseIf Request.Params("TipoOperacion") = "1" Then
                Session.Add("NoLlenar", "Ok")
                ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false")
                Me.btnGuardar.Text = "Crear"
            End If
            BindQnas()
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
                .IdQuincena = CShort(Me.ddlQnas.SelectedValue)
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
            If Request.Params("TipoOperacion") = "0" Then
                oEmp.ActualizarAutorizacionHomologacion(Request.Params("TipoOperacion"), CShort(Me.ddlQnas.SelectedValue), CType(Session("ArregloAuditoria"), String()), CShort(Request.Params("IdQuincena")))
                Me.lblExito.Text = "Actualización realizada correctamente."
            ElseIf Request.Params("TipoOperacion") = "1" Then
                oEmp.InsertarAutorizacionHomologacion(CShort(Me.ddlQnas.SelectedValue), CType(Session("ArregloAuditoria"), String()))
                Me.lblExito.Text = "Nueva autorización guardada correctamente."
            ElseIf Request.Params("TipoOperacion") = "3" Then
                oEmp.EliminaAutorizacionHomologacion(CShort(Me.ddlQnas.SelectedValue), CType(Session("ArregloAuditoria"), String()))
                Me.lblExito.Text = "Autorización eliminada correctamente."
            End If
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
            Me.lbContinuar.Visible = False
        End Try
    End Sub

    Protected Sub lbContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbContinuar.Click
        Me.MultiView1.SetActiveView(Me.viewAutorizacion)
    End Sub
End Class
