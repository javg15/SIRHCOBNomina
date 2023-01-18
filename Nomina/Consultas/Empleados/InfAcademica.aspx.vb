Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Partial Class Consultas_Empleados_InfAcademica
    Inherits System.Web.UI.Page
    Private Sub SetVisibilidadDeColumnas()
        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EstudiosPorEmpleado")
        Me.gvHistoriaAcademica.Columns(11).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        Me.gvHistoriaAcademica.Columns(12).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
        Me.lbAddRegAcad.Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim vlRFCEmp As String = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If vlRFCEmp <> String.Empty Then
            Me.gvHistoriaAcademica.DataSource = oEmp.ObtenHistoriaAcademica(vlRFCEmp)
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                lblEmpInf.Text = "Información académica relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
                lblRFCEmp.Text = vlRFCEmp
                lbAddRegAcad.Enabled = True
                lbAddRegAcad.PostBackUrl = "../../ABC/Empleados/AdmonInfAcademica.aspx?TipoOperacion=1&RFCEmp=" + vlRFCEmp
                'lbAddRegAcad.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Empleados/AdmonInfAcademica.aspx?TipoOperacion=1&RFCEmp=" + vlRFCEmp + "');"
            Else
                Me.lblEmpInf.Text = String.Empty
                Me.lblRFCEmp.Text = String.Empty
                Me.lbAddRegAcad.Enabled = False
                Me.lbAddRegAcad.OnClientClick = String.Empty
            End If
            Me.gvHistoriaAcademica.DataBind()
            Me.lbAddRegAcad.Visible = True
            Me.gvHistoriaAcademica.Visible = True
        Else
            Me.lbAddRegAcad.Enabled = False
            Me.lbAddRegAcad.OnClientClick = String.Empty
        End If
    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If IsPostBack = False Then
    '        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
    '        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
    '        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
    '        Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
    '        ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
    '    End If
    'End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
        SetVisibilidadDeColumnas()
    End Sub

    Protected Sub gvHistoriaAcademica_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvHistoriaAcademica.RowCommand

    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
            SetVisibilidadDeColumnas()
        End If
    End Sub

    Protected Sub gvHistoriaAcademica_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvHistoriaAcademica.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim lblIdEstudio As Label = CType(e.Row.FindControl("lblIdEstudio"), Label)

                ibEditar.PostBackUrl = "../../ABC/Empleados/AdmonInfAcademica.aspx?TipoOperacion=0&IdEstudio=" + lblIdEstudio.Text
                ibEliminar.PostBackUrl = "../../ABC/Empleados/AdmonInfAcademica.aspx?TipoOperacion=3&IdEstudio=" + lblIdEstudio.Text

                'ibEditar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Empleados/AdmonInfAcademica.aspx?TipoOperacion=0&IdEstudio=" + lblIdEstudio.Text + "');"
                'ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Empleados/AdmonInfAcademica.aspx?TipoOperacion=3&IdEstudio=" + lblIdEstudio.Text + "');"

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub
    Protected Sub gvHistoriaAcademica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvHistoriaAcademica.SelectedIndexChanged
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Session("RFCParaCons") Is Nothing = False Then
                If Me.lblRFCEmp.Text <> Session("RFCParaCons") Then
                    BindDatos()
                    SetVisibilidadDeColumnas()
                End If
            End If
            If Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    BindDatos()
                    SetVisibilidadDeColumnas()
                    pnl1.Visible = True
                Else
                    pnl1.Visible = False
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                'Me.lbAddRegAcad.Visible = False
                'Me.gvHistoriaAcademica.Visible = False
                pnl1.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                'Me.lbAddRegAcad.Visible = True
                'Me.gvHistoriaAcademica.Visible = True
                pnl1.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindDatos()
                    SetVisibilidadDeColumnas()
                    pnl1.Visible = True
                End If
            End If
            End If
    End Sub

    Protected Sub ibEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindDatos()
        SetVisibilidadDeColumnas()
    End Sub

    Protected Sub lbAddRegAcad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAddRegAcad.Click
        BindDatos()
        SetVisibilidadDeColumnas()
    End Sub

    Protected Sub ibEliminar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        BindDatos()
        SetVisibilidadDeColumnas()
    End Sub
End Class
