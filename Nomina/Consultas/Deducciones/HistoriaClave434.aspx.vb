Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Partial Class ConsultasDeduccionesHistoriaClave434
    Inherits System.Web.UI.Page
    Private Sub BindddlQnaAplic()
        Dim oQna As New Quincenas
        With Me.ddlQnaAplic
            .DataSource = oQna.ObtenAbiertasParaCaptura()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If Me.ddlQnaAplic.Items.Count = 0 Then
                .Items.Insert(0, "(No existen quincenas abiertas para captura)")
                .Items(0).Value = "-1"
                Me.btnGuardar.Enabled = False
            End If
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Response.Expires = 0
            If Request.Params("TipoOperacion") = "4" Then 'Consultar
            ElseIf Request.Params("TipoOperacion") = "0" Then 'Modificar porcentaje de descuento
                Page.Title = "COBAEV - Nómina - Nuevo porcentaje Préstamo Hipotecario FOVISSSTE"
                Me.MultiView1.SetActiveView(Me.viewNuevoPorcDesc)
                BindddlQnaAplic()
            End If
        End If
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            'Código para validaciones
            'Dim oValidacion As New Validaciones
            'Dim _DataCOBAEV As New DataCOBAEV
            'Dim dsValida As DataSet
            'dsValida = _DataCOBAEV.setDataSetErrores()

            'With oValidacion
            '    .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            '    .RFC = Session("RFCParaCons")
            '    .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
            '    If Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Insert Then
            '        .Cantidad = CByte(CType(Me.dvCargaHoraria.FindControl("txtbxCantidadIns"), TextBox).Text)
            '    ElseIf Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Edit Then
            '        .Cantidad = CByte(CType(Me.dvCargaHoraria.FindControl("txtbxCantidad"), TextBox).Text)
            '        .IdHora = CType(Request.Params("IdHora"), Integer)
            '    End If
            '    If Not .ValidaPaginasOperacion(dsValida) Then
            '        Session.Add("dsValida", dsValida)
            '        Response.Redirect("~/ErroresPagina2.aspx")
            '    Else
            '        Session.Remove("dsValida")
            '    End If
            'End With
            'Código para validaciones

            Dim oDeduc As New Deduccion
            oDeduc.InsNuevoPorcParaPrestHipFOVISSSTE(CInt(Request.Params("IdEmp")), CDec(Me.txtbxNuevoPorcDesc.Text), _
                                            CShort(Me.ddlQnaAplic.SelectedValue), CType(Session("ArregloAuditoria"), String()))
            Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
        Catch ex As Exception
            Me.MultiView1.SetActiveView(Me.viewErrores)
            Me.lblErrores.Text = ex.Message
        End Try
    End Sub

    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
        Me.MultiView1.SetActiveView(Me.viewNuevoPorcDesc)
    End Sub
End Class
