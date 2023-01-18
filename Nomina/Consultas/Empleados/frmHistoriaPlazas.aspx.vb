Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Plazas
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.MovsDePersonal
Partial Class frmHistoriaPlazas
    Inherits System.Web.UI.Page
    Private Sub SetPermisosgvPlazasVigentes()

        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpleadosPlazas")

        gvPlazasVigentes.Columns(19).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim oPlaza As New SMP_Plazas
        'Dim dtPlazasBase As DataTable
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        If oEmp.RFC <> String.Empty Then
            'dtPlazasBase = oPlaza.ObtenPlazaBasePorEmp(txtbxRFC.Text)
            gvPlazasBase.DataSource = oPlaza.ObtenPlazaBasePorEmp(txtbxRFC.Text)
            gvPlazasVigentes.DataSource = oEmp.ObtenPlazasVigentesHistoria2()
            gvPlazasHistoria.DataSource = oEmp.ObtenHistoria(oEmp.RFC, False)
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            Else
                lblEmpInf.Text = String.Empty
            End If

            gvPlazasBase.DataBind()
            gvPlazasVigentes.DataBind()
            gvPlazasHistoria.DataBind()
            pnl1.Visible = True
            pnl2.Visible = True

            SetPermisosgvPlazasVigentes()

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

    'Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
    '    BindDatos()
    'End Sub

    Protected Sub gvPlazasVigentes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPlazasVigentes.RowCommand

    End Sub

    'Protected Sub gvDatosPlazas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazasVigentes.RowDataBound
    '    'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '    'Select Case e.Row.RowType
    '    '    Case DataControlRowType.DataRow
    '    '        Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
    '    '        Dim lbHistoriaPlaza As LinkButton = CType(e.Row.FindControl("lbHistoriaPlaza"), LinkButton)
    '    '        lbHistoriaPlaza.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=2&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
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
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim lblOcupacion As Label = CType(e.Row.FindControl("lblOcupacion"), Label)
                Dim drFuncionPriSecPorPlaza As DataRow
                Dim drMotivoGeneralDeBajaPorPlaza As DataRow
                Dim oPlaza As New EmpleadoPlazas
                Dim dtWarnings As DataTable
                Dim drInfTitular As DataRow
                Dim vlNomTitular As String
                Dim vlPlazaTienePagosRelacionados As Boolean

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

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Plazas/wfAdmonPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text

                vlPlazaTienePagosRelacionados = oPlaza.TienePagosRelacionados(CInt(lblIdPlaza.Text))

                'If oPlaza.TienePagosRelacionados(CInt(lblIdPlaza.Text)) Then
                If vlPlazaTienePagosRelacionados Then
                    ibModificar.Enabled = False
                    ibModificar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    ibModificar.ToolTip = "(Opción deshabilitada) La plaza tiene pagos relacionados, no se permiten modificaciones."
                End If

                'ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=0&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibModificar.PostBackUrl = "../../ABC/Plazas/wfAdmonPlazas.aspx?TipoOperacion=0&IdPlaza=" + lblIdPlaza.Text
                'ibBaja.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=2&IdPlaza=" + lblIdPlaza.Text + "');"
                ibBaja.PostBackUrl = "../../ABC/Plazas/wfAdmonPlazas.aspx?TipoOperacion=2&IdPlaza=" + lblIdPlaza.Text
                ibWarning.OnClientClick = "javascript:abreVentMedAncha('../Plazas/ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                dtWarnings = oPlaza.ObtenObservaciones(CInt(lblIdPlaza.Text))
                ibWarning.Visible = dtWarnings.Rows.Count > 0

                ibEliminar.Enabled = IIf(vlPlazaTienePagosRelacionados, False, True)
                ibEliminar.ImageUrl = IIf(vlPlazaTienePagosRelacionados, "~/Imagenes/TrashDisabled.png", "~/Imagenes/TrashEnabled.png")
                ibEliminar.ToolTip = IIf(vlPlazaTienePagosRelacionados, "(Opción deshabilitada) La plaza tiene pagos relacionados, no se puede eliminar este registro.", "Eliminar registro.")                

            Case DataControlRowType.EmptyDataRow, DataControlRowType.Footer
                Dim lbAsignarPlaza As LinkButton = CType(e.Row.FindControl("lbAsignarPlaza"), LinkButton)
                Dim lbAsignarPlazaCopia As LinkButton = CType(e.Row.FindControl("lbAsignarPlazaCopia"), LinkButton)
                Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

                lbAsignarPlaza.Visible = oEmpleadoPlaza.SeLePudenAgregarMasPlazas(hfRFC.Value)

                'lbAsignarPlaza.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "');"
                lbAsignarPlaza.PostBackUrl = "../../ABC/Plazas/wfAdmonPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value
                'lbAsignarPlazaCopia.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "&CopiarUltVig=SI');"
                lbAsignarPlazaCopia.PostBackUrl = "../../ABC/Plazas/wfAdmonPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "&CopiarUltVig=SI"
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

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Plazas/wfAdmonPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text
                ibWarning.OnClientClick = "javascript:abreVentMedAncha('../Plazas/ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                dtWarnings = oPlaza.ObtenObservaciones(CInt(lblIdPlaza.Text))
                ibWarning.Visible = dtWarnings.Rows.Count > 0
        End Select
    End Sub
    Protected Sub lbAsignarPlaza_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindDatos()
    End Sub

    Protected Sub lbAsignarPlazaCopia_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindDatos()
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Or Request.Params(1).Contains("BtnSearch") Then
            If hfRFC.Value <> String.Empty Then
                BindDatos()
            End If
        ElseIf Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnNewSearch") Then
            Me.pnl1.Visible = False
            Me.pnl2.Visible = False
        ElseIf Request.Params(0).Contains("BtnCancelSearch") Or Request.Params(1).Contains("BtnCancelSearch") Then
            Me.pnl1.Visible = True
            Me.pnl2.Visible = True
        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                BindDatos()
            End If
        End If
    End Sub

    Protected Sub gvPlazasBase_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPlazasBase.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(gvPlazasBase.Rows(e.CommandArgument).FindControl("LnkBtnRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(gvPlazasBase.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(gvPlazasBase.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(gvPlazasBase.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(gvPlazasBase.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(gvPlazasBase.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)

                Response.Redirect(Request.Url.ToString)
        End Select
    End Sub

    Protected Sub gvPlazasBase_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazasBase.RowDataBound
        Dim LnkBtn As LinkButton
        Dim dt As DataTable
        Dim oEmp As New Empleado
        Dim oUsr As New Usuario
        Dim dr As DataRow

        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                oUsr.Login = Session("Login")
                dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)


                LnkBtn = CType(e.Row.FindControl("LnkBtnRFC"), LinkButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString

                oEmp.RFC = LnkBtn.Text.Trim.ToUpper
                dt = oEmp.Buscar(Empleado.TipoBusqueda.RFC, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))

                LnkBtn.Enabled = dt.Rows.Count > 0
                If LnkBtn.Enabled Then
                    LnkBtn.ToolTip = "Click en el RFC para seleccionar al empleado para aplicarle operaciones."
                Else
                    LnkBtn.ToolTip = "Sin permisos para visualizar al empleado, no pertenece a su zona geográfica."

                End If

        End Select
    End Sub

    Protected Sub ibEliminar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim gvr As GridViewRow
            Dim lblIdPlaza As Label
            Dim oMovPers As New MovsDePersonal
            Dim oEmp As New Empleado
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim vlRFCEmp As String

            gvr = CType(sender.dataitemcontainer, GridViewRow)
            lblIdPlaza = CType(gvr.FindControl("lblIdPlaza"), Label)

            oMovPers.ElminaPorIdPlaza(CInt(lblIdPlaza.Text), CType(Session("ArregloAuditoria"), String()))

            vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

            gvPlazasVigentes.DataSource = oEmp.ObtenPlazasVigentesHistoria2(vlRFCEmp)
            gvPlazasVigentes.DataBind()

        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
End Class
