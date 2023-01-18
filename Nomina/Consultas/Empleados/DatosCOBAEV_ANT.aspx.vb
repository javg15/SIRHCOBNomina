Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Plazas
Partial Class Consultas_Empleados_DatosCOBAEV_ANT
    Inherits System.Web.UI.Page
    Private Sub BindPlazas()
        Try
            Dim oEmp As New Empleado
            Dim hfRFC As HiddenField = CType(Me.wucSearchEmps1.FindControl("hfRFC"), HiddenField)
            oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
            Me.gvDatosPlazas.DataSource = oEmp.ObtenPlazasVigentes()
            Me.gvDatosPlazas.DataBind()
        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.wucSearchEmps1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.wucSearchEmps1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.wucSearchEmps1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.wucSearchEmps1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        If oEmp.RFC <> String.Empty Then
            Dim dtDatosLab As DataTable
            dtDatosLab = oEmp.ObtenDatosLaborales()
            Me.dvDatosLab.DataSource = dtDatosLab
            Me.dvSegSoc.DataSource = dtDatosLab
            Me.dvPagomatico.DataSource = dtDatosLab
            Me.gvDatosPlazas.DataSource = oEmp.ObtenPlazasVigentes()
            Me.dvAntiguedad.DataSource = oEmp.ObtenAntiguedad()
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            Else
                Me.lblEmpInf.Text = String.Empty
            End If
            Me.dvDatosLab.DataBind()
            Me.gvDatosPlazas.DataBind()

            Me.lbAdmonPlazasBase.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/PlazasBase.aspx?TipoOperacion=4&RFCEmp=" + hfRFC.Value + "');"
            Me.lbAdmonPlazasBase.Visible = True

            Me.dvAntiguedad.DataBind()
            Me.dvSegSoc.DataBind()
            Me.dvPagomatico.DataBind()

            pnlGral.Visible = True
            'En caso de que el empleado tenga plazas vigentes, deshabilitamos la opción de agregar más plazas
            'If Me.gvDatosPlazas.Rows.Count >= 1 Then
            '    Dim PnlCrearPlazas As Panel = CType(gvDatosPlazas.FooterRow.FindControl("PnlCrearPlazas"), Panel)
            '    PnlCrearPlazas.Visible = Me.gvDatosPlazas.Rows.Count = 0
            'End If
        End If
    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        Dim txtbxRFC As TextBox = CType(Me.wucSearchEmps1.FindControl("txtbxRFC"), TextBox)
    '        Dim txtbxNomEmp As TextBox = CType(Me.wucSearchEmps1.FindControl("txtbxNomEmp"), TextBox)
    '        Dim hfRFC As HiddenField = CType(Me.wucSearchEmps1.FindControl("hfRFC"), HiddenField)
    '        Dim hfNomEmp As HiddenField = CType(Me.wucSearchEmps1.FindControl("hfNomEmp"), HiddenField)
    '        Dim ibBuscarEmp As ImageButton = CType(Me.wucSearchEmps1.FindControl("ibBuscarEmp"), ImageButton)
    '        ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
    '    End If
    'End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
    End Sub

    Protected Sub gvDatosPlazas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatosPlazas.RowDataBound
        Dim hfRFC As HiddenField = CType(Me.wucSearchEmps1.FindControl("hfRFC"), HiddenField)
        Dim oPlaza As New EmpleadoPlazas
        Dim dtWarnings As DataTable

        Select Case e.Row.RowType
            'Case DataControlRowType.EmptyDataRow, DataControlRowType.Footer
            '    Dim lbAsignarPlaza As LinkButton = CType(e.Row.FindControl("lbAsignarPlaza"), LinkButton)
            '    Dim lbAsignarPlazaCopia As LinkButton = CType(e.Row.FindControl("lbAsignarPlazaCopia"), LinkButton)

            '    lbAsignarPlaza.Visible = False 'oPlaza.SeLePudenAgregarMasPlazas(hfRFC.Value)

            '    lbAsignarPlaza.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "');"
            '    lbAsignarPlazaCopia.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "&CopiarUltVig=SI');"
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibModificarPlaza As ImageButton = CType(e.Row.FindControl("ibModificarPlaza"), ImageButton)
                Dim ibWarning As ImageButton = CType(e.Row.FindControl("ibWarning"), ImageButton)
                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text

                If oPlaza.TienePagosRelacionados(CInt(lblIdPlaza.Text)) Then
                    ibModificarPlaza.Enabled = False
                    ibModificarPlaza.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    ibModificarPlaza.ToolTip = "(Opción deshabilitada) La plaza tiene pagos relacionados, no se permiten modificaciones."
                End If

                'ibModificarPlaza.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=0&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibModificarPlaza.PostBackUrl = "../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=0&IdPlaza=" + lblIdPlaza.Text
                ibWarning.OnClientClick = "javascript:abreVentMedAncha('../Plazas/ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                dtWarnings = oPlaza.ObtenObservaciones(CInt(lblIdPlaza.Text))
                ibWarning.Visible = dtWarnings.Rows.Count > 0

        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub
    Protected Sub dvAntiguedad_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvAntiguedad.DataBound
        Dim lbModifAnt As LinkButton = CType(Me.dvAntiguedad.Rows(0).FindControl("lbModifAnt"), LinkButton)
        Dim lblIdEmp As Label = CType(Me.dvAntiguedad.Rows(0).FindControl("lblIdEmp"), Label)
        If lblIdEmp Is Nothing = False Then
            lbModifAnt.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionAntiguedad.aspx?TipoOperacion=0&IdEmp=" + lblIdEmp.Text + "'); return false;"
        End If
    End Sub

    Protected Sub dvDatosLab_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvDatosLab.DataBound
        Dim lbModifDatosLab As LinkButton = CType(Me.dvDatosLab.Rows(0).FindControl("lbModifDatosLab"), LinkButton)
        Dim lblIdEmp As Label = CType(Me.dvDatosLab.Rows(0).FindControl("lblIdEmp"), Label)
        If lblIdEmp Is Nothing = False Then
            lbModifDatosLab.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionDatosLaborales.aspx?TipoOperacion=0&IdEmp=" + lblIdEmp.Text + "'); return false;"
        End If
    End Sub

    Protected Sub dvSegSoc_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvSegSoc.DataBound
        Dim lbModifSegSoc As LinkButton = CType(Me.dvSegSoc.Rows(0).FindControl("lbModifSegSoc"), LinkButton)
        Dim lblIdEmp As Label = CType(Me.dvSegSoc.Rows(0).FindControl("lblIdEmp"), Label)
        If lblIdEmp Is Nothing = False Then
            lbModifSegSoc.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdmonDatosSegSoc.aspx?TipoOperacion=0&IdEmp=" + lblIdEmp.Text + "'); return false;"
        End If
    End Sub

    Protected Sub dvPagomatico_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvPagomatico.DataBound
        Dim txtbxNomEmp As TextBox = CType(Me.wucSearchEmps1.FindControl("txtbxNomEmp"), TextBox)
        Dim lbModifPagomatico As LinkButton = CType(Me.dvPagomatico.Rows(0).FindControl("lbModifPagomatico"), LinkButton)
        Dim lblIdEmp As Label = CType(Me.dvPagomatico.Rows(0).FindControl("lblIdEmp"), Label)
        If lblIdEmp Is Nothing = False Then
            lbModifPagomatico.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/wfAdmonDatosPagomatico.aspx?TipoOperacion=0&IdEmp=" + lblIdEmp.Text + "&NomEmp=" + txtbxNomEmp.Text.Trim + "&ValidacionAlCargarPagina=SI'); return false;"
            'lbModifPagomatico.CommandArgument = lblIdEmp.Text
        End If
    End Sub
    Protected Sub lbAsignarPlaza_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindPlazas()
    End Sub

    Protected Sub lbAsignarPlazaCopia_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindPlazas()
    End Sub

    Protected Sub wucSearchEmps1_PreRender(sender As Object, e As System.EventArgs) Handles wucSearchEmps1.PreRender
        'BindDatos()
        Dim hfRFC As HiddenField = CType(Me.wucSearchEmps1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Then
            If hfRFC.Value <> String.Empty Then
                BindDatos()
            End If
        ElseIf Request.Params(0).Contains("BtnNewSearch") Then
            pnlGral.Visible = False
        ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
            pnlGral.Visible = True
        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                BindDatos()
            End If
        End If
    End Sub
End Class
