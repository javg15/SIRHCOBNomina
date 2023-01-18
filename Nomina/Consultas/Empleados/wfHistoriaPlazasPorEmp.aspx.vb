Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV

Partial Class wfHistoriaPlazasPorEmp
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        If oEmp.RFC <> String.Empty Then
            Me.gvPlazasVigentes.DataSource = oEmp.ObtenPlazasVigentes()
            Me.gvPlazasHistoria.DataSource = oEmp.ObtenHistoria()
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            Else
                Me.lblEmpInf.Text = String.Empty
            End If
            Me.gvPlazasVigentes.DataBind()

            'En caso de que el empleado tenga plazas vigentes, deshabilitamos la opción de agregar más plazas
            'If Me.gvDatosPlazas.Rows.Count >= 1 Then
            '    Dim PnlCrearPlazas As Panel = CType(gvDatosPlazas.FooterRow.FindControl("PnlCrearPlazas"), Panel)
            '    PnlCrearPlazas.Visible = Me.gvDatosPlazas.Rows.Count = 0
            'End If

            Me.gvPlazasHistoria.DataBind()
            pnl1.Visible = True
            pnl2.Visible = True
        Else
            pnl1.Visible = False
            pnl2.Visible = False
        End If
    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
    '        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
    '        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
    '        Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
    '        ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false")
    '    End If
    'End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
    End Sub

    Protected Sub gvPlazasVigentes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPlazasVigentes.RowCommand

    End Sub

    'Protected Sub gvDatosPlazas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazasVigentes.RowDataBound
    '    'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '    'Select Case e.Row.RowType
    '    '    Case DataControlRowType.DataRow
    '    '        Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
    '    '        Dim lbHistoriaPlaza As LinkButton = CType(e.Row.FindControl("lbHistoriaPlaza"), LinkButton)
    '    '        lbHistoriaPlaza.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=2&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
    '    'End Select
    'End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub

    Protected Sub gvPlazasVigentes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazasVigentes.RowDataBound
        Dim oEmpleadoPlaza As New EmpleadoPlazas
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim lblNombreFuncionPri As Label = CType(e.Row.FindControl("lblNombreFuncionPri"), Label)
                Dim lblNombreFuncionSec As Label = CType(e.Row.FindControl("lblNombreFuncionSec"), Label)
                Dim lblMotGralBaja As Label = CType(e.Row.FindControl("lblMotGralBaja"), Label)
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibBaja As ImageButton = CType(e.Row.FindControl("ibBaja"), ImageButton)
                Dim ibWarning As ImageButton = CType(e.Row.FindControl("ibWarning"), ImageButton)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim lblOcupacion As Label = CType(e.Row.FindControl("lblOcupacion"), Label)
                Dim drFuncionPriSecPorPlaza As DataRow
                Dim drMotivoGeneralDeBajaPorPlaza As DataRow
                Dim oPlaza As New EmpleadoPlazas
                Dim dtWarnings As DataTable
                Dim drInfTitular As DataRow
                Dim vlNomTitular As String

                imgInfTitular.Visible = False
                If lblOcupacion.Text = "I" Then
                    imgInfTitular.Visible = True
                    oEmpleadoPlaza.IdPlaza = CInt(lblIdPlaza.Text)
                    drInfTitular = oEmpleadoPlaza.ObtenTitular()
                    vlNomTitular = (drInfTitular("ApePatEmp") + " " + drInfTitular("ApeMatEmp") + " " + drInfTitular("NomEmp")).ToString.Trim
                    If vlNomTitular = String.Empty Then
                        vlNomTitular = "Información del titular no capturada."
                    End If
                    imgInfTitular.ToolTip = vlNomTitular
                End If

                drFuncionPriSecPorPlaza = oEmpleadoPlaza.ObtenFuncionesPri_Y_Sec(CInt(lblIdPlaza.Text))
                drMotivoGeneralDeBajaPorPlaza = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(lblIdPlaza.Text))

                lblNombreFuncionPri.Text = drFuncionPriSecPorPlaza("NombreFuncionPri").ToString
                lblNombreFuncionSec.Text = drFuncionPriSecPorPlaza("NombreFuncionSec").ToString
                lblMotGralBaja.Text = drMotivoGeneralDeBajaPorPlaza("DescMotGralBaja").ToString

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text

                If oPlaza.TienePagosRelacionados(CInt(lblIdPlaza.Text)) Then
                    ibModificar.Enabled = False
                    ibModificar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    ibModificar.ToolTip = "(Opción deshabilitada) La plaza tiene pagos relacionados, no se permiten modificaciones."
                End If

                'ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=0&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibModificar.PostBackUrl = "../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=0&IdPlaza=" + lblIdPlaza.Text
                'ibBaja.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=2&IdPlaza=" + lblIdPlaza.Text + "');"
                ibBaja.PostBackUrl = "../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=2&IdPlaza=" + lblIdPlaza.Text
                ibWarning.OnClientClick = "javascript:abreVentMedAncha('../Plazas/ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                dtWarnings = oPlaza.ObtenObservaciones(CInt(lblIdPlaza.Text))
                ibWarning.Visible = dtWarnings.Rows.Count > 0
            Case DataControlRowType.EmptyDataRow, DataControlRowType.Footer
                Dim lbAsignarPlaza As LinkButton = CType(e.Row.FindControl("lbAsignarPlaza"), LinkButton)
                Dim lbAsignarPlazaCopia As LinkButton = CType(e.Row.FindControl("lbAsignarPlazaCopia"), LinkButton)
                Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

                lbAsignarPlaza.Visible = oEmpleadoPlaza.SeLePudenAgregarMasPlazas(hfRFC.Value)

                lbAsignarPlaza.PostBackUrl = "../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value

                'lbAsignarPlaza.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "');"
                'lbAsignarPlazaCopia.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "&CopiarUltVig=SI');"
                lbAsignarPlazaCopia.PostBackUrl = "../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "&CopiarUltVig=SI"
        End Select
    End Sub

    Protected Sub gvPlazasHistoria_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim lblNombreFuncionPri As Label = CType(e.Row.FindControl("lblNombreFuncionPri"), Label)
                Dim lblNombreFuncionSec As Label = CType(e.Row.FindControl("lblNombreFuncionSec"), Label)
                Dim lblMotGralBaja As Label = CType(e.Row.FindControl("lblMotGralBaja"), Label)
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibWarning As ImageButton = CType(e.Row.FindControl("ibWarning"), ImageButton)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim lblOcupacion As Label = CType(e.Row.FindControl("lblOcupacion"), Label)

                Dim oEmpleadoPlaza As New EmpleadoPlazas
                Dim drFuncionPriSecPorPlaza As DataRow
                Dim drMotivoGeneralDeBajaPorPlaza As DataRow
                Dim oPlaza As New EmpleadoPlazas
                Dim dtWarnings As DataTable
                Dim drInfTitular As DataRow
                Dim vlNomTitular As String

                imgInfTitular.Visible = False
                If lblOcupacion.Text = "I" Then
                    imgInfTitular.Visible = True
                    oEmpleadoPlaza.IdPlaza = CInt(lblIdPlaza.Text)
                    drInfTitular = oEmpleadoPlaza.ObtenTitular()
                    vlNomTitular = (drInfTitular("ApePatEmp") + " " + drInfTitular("ApeMatEmp") + " " + drInfTitular("NomEmp")).ToString.Trim
                    If vlNomTitular = String.Empty Then
                        vlNomTitular = "Información del titular no capturada."
                    End If
                    imgInfTitular.ToolTip = vlNomTitular
                End If

                drFuncionPriSecPorPlaza = oEmpleadoPlaza.ObtenFuncionesPri_Y_Sec(CInt(lblIdPlaza.Text))
                drMotivoGeneralDeBajaPorPlaza = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(lblIdPlaza.Text))

                lblNombreFuncionPri.Text = drFuncionPriSecPorPlaza("NombreFuncionPri").ToString
                lblNombreFuncionSec.Text = drFuncionPriSecPorPlaza("NombreFuncionSec").ToString
                lblMotGralBaja.Text = drMotivoGeneralDeBajaPorPlaza("DescMotGralBaja").ToString

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text
                ibWarning.OnClientClick = "javascript:abreVentMedAncha('../Plazas/ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                dtWarnings = oPlaza.ObtenObservaciones(CInt(lblIdPlaza.Text))
                ibWarning.Visible = dtWarnings.Rows.Count > 0
        End Select
    End Sub
    Protected Sub lbAsignarPlaza_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'lbAsignarPlaza()
        'lbAsignarPlaza.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "');"
        'BindDatos()
    End Sub

    Protected Sub lbAsignarPlazaCopia_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindDatos()
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oMetodoComun As New MetodosComunes
        Dim c As Control = oMetodoComun.GetPostBackControl(Page)

        If c Is Nothing Then Exit Sub
        If c.ID = "BtnSearch" Then
            If hfRFC.Value <> String.Empty Then
                BindDatos()
            End If
        ElseIf c.ID = "BtnNewSearch" Then
            Me.pnl1.Visible = False
            Me.pnl2.Visible = False
        ElseIf c.ID = "BtnCancelSearch" Then
            Me.pnl1.Visible = True
            Me.pnl2.Visible = True
        ElseIf c.ID = "lnkbtnrfc" Then
            BindDatos()
        End If
    End Sub
End Class
