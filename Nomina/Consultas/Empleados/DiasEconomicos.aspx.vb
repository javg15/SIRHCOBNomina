Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Partial Class Consultas_Empleados_DiasEconomicos
    Inherits System.Web.UI.Page
    Private Sub SubCancelingEditgvDiasEco()
        Me.gvDiasEco.Columns(0).Visible = True 'Select

        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "DiasEconomicos")
        Me.gvDiasEco.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))

        Me.gvDiasEco.SelectedIndex = -1
        Me.gvDiasEco.EditIndex = -1
        BindgvDiasEco(-1)
    End Sub

    Private Sub SubActualizar()
        Me.gvDiasEco.EditIndex = -1
        BindddlAños()
        BindDatos()
        Me.gvDiasEco.Columns(0).Visible = True 'Select

        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "DiasEconomicos")
        Me.gvDiasEco.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
    End Sub
    Private Sub BindddlAños()
        Dim oQna As New Quincenas
        With Me.ddlAños
            .DataSource = oQna.ObtenAños(True)
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
                Me.btnConsultar.Enabled = False
            Else
                Me.btnConsultar.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "DiasEconomicos")

        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        If oEmp.RFC <> String.Empty Then
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
                Me.lblMsj1.Text = "Año: " + Me.ddlAños.SelectedItem.Text
                Me.lblNuevoDiaEco.Enabled = CBool(dt.Rows(0).Item("Insercion"))
                Me.txtbxFechaNuevoDiaEco.Enabled = CBool(dt.Rows(0).Item("Insercion"))
                Me.ibFechaNuevoDiaEco.Enabled = CBool(dt.Rows(0).Item("Insercion"))
                Me.btnGuardarNuevoDiaEco.Enabled = CBool(dt.Rows(0).Item("Insercion"))
                If Me.hfFechaNuevoDiaEco.Value = "" Then
                    Me.ibFechaNuevoDiaEco.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + Me.txtbxFechaNuevoDiaEco.ClientID + "','" + Me.hfFechaNuevoDiaEco.ClientID + "');")
                Else
                    Me.ibFechaNuevoDiaEco.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx?Fecha=" + Me.hfFechaNuevoDiaEco.Value + "','" + Me.hfFechaNuevoDiaEco.ClientID + "','" + Me.hfFechaNuevoDiaEco.ClientID + "');")
                End If
                pnl1.Visible = True
            Else
                Me.lblEmpInf.Text = String.Empty
                Me.lblMsj1.Text = "Año: Sin especificar"
                Me.lblNuevoDiaEco.Enabled = False
                Me.txtbxFechaNuevoDiaEco.Enabled = False
                Me.ibFechaNuevoDiaEco.Enabled = False
                Me.btnGuardarNuevoDiaEco.Enabled = False
                pnl1.Visible = False
            End If
        End If
        BindgvDiasEco()
    End Sub
    Private Sub BindgvDiasEco(Optional ByVal Fila As SByte = -1)
        Dim oEmp As New Empleado
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        With Me.gvDiasEco
            If Fila = -1 Then
                If hfRFC.Value <> String.Empty Then .DataSource = oEmp.ObtenDiasEconomicosPorAño(hfRFC.Value, CShort(Me.ddlAños.SelectedValue))
            Else
                If hfRFC.Value <> String.Empty Then .DataSource = oEmp.ObtenDiasEconomicosPorAño(hfRFC.Value, CShort(Right(Me.lblMsj1.Text, 4)))
            End If
            .DataBind()
            Me.gvDiasEco.Enabled = True
        End With
        Me.ddlAños.Enabled = hfRFC.Value <> String.Empty 'Or Session("RFCParaCons") Is Nothing
        Me.btnConsultar.Enabled = hfRFC.Value <> String.Empty 'Or Session("RFCParaCons") Is Nothing
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Response.Expires = 0
            Dim oUsr As New Usuario
            Dim dt As DataTable

            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "DiasEconomicos")
            Me.gvDiasEco.Columns(5).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            Me.gvDiasEco.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))

            'Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            'Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            'Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
            BindddlAños()
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub
    Protected Sub gvDiasEco_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDiasEco.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim oUsr As New Usuario
                Dim dr As DataRow
                Dim lblIdUsuario As Label = CType(e.Row.FindControl("lblIdUsuario"), Label)
                Dim lblLogin As Label = CType(e.Row.FindControl("lblLogin"), Label)
                oUsr.IdUsuario = CShort(lblIdUsuario.Text)
                dr = oUsr.ObtenerPorId()
                lblLogin.Text = dr("Login")
                lblLogin.ToolTip = dr("ApellidoPaterno").ToString.Trim + " " + dr("ApellidoMaterno").ToString.Trim + " " + dr("Nombre").ToString.Trim

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub
    Protected Sub gvDiasEco_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvDiasEco.RowCancelingEdit
        SubCancelingEditgvDiasEco()
        SubActualizar()
        'Me.gvDiasEco.Columns(0).Visible = True 'Select

        'Dim oUsr As New Usuario
        'Dim dt As DataTable

        'dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "DiasEconomicos")
        'Me.gvDiasEco.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))

        'Me.gvDiasEco.SelectedIndex = e.RowIndex
        'Me.gvDiasEco.EditIndex = -1
        'BindgvDiasEco(e.RowIndex)
    End Sub

    Protected Sub gvDiasEco_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvDiasEco.RowEditing
        Me.gvDiasEco.Columns(0).Visible = False 'Select
        Me.gvDiasEco.Columns(6).Visible = False 'Delete
        Me.gvDiasEco.SelectedIndex = -1
        Me.gvDiasEco.EditIndex = e.NewEditIndex
        BindgvDiasEco(e.NewEditIndex)

        Dim fila As Integer = Me.gvDiasEco.EditIndex
        Dim lblFecha As Label = CType(Me.gvDiasEco.Rows(fila).FindControl("lblFecha"), Label)
        Dim txtbxFecha As TextBox = CType(Me.gvDiasEco.Rows(fila).FindControl("txtbxFecha"), TextBox)
        Dim hfFecNac As HiddenField = CType(Me.gvDiasEco.Rows(fila).FindControl("hfFecNac"), HiddenField)
        Dim ibFecNac As ImageButton = CType(Me.gvDiasEco.Rows(fila).FindControl("ibFecNac"), ImageButton)

        txtbxFecha.Text = lblFecha.Text
        hfFecNac.Value = lblFecha.Text

        ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx?Fecha=" + lblFecha.Text + "','" + txtbxFecha.ClientID + "','" + hfFecNac.ClientID + "');")

        ddlAños.Enabled = False
        btnConsultar.Enabled = False
        txtbxFechaNuevoDiaEco.Enabled = False
        ibFechaNuevoDiaEco.Enabled = False
        btnGuardarNuevoDiaEco.Enabled = False

    End Sub

    Protected Sub gvDiasEco_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvDiasEco.RowUpdating
        Dim lblIdEmp As Label = CType(Me.gvDiasEco.Rows(e.RowIndex).FindControl("lblIdEmp"), Label)
        Dim lblFecha As Label = CType(Me.gvDiasEco.Rows(e.RowIndex).FindControl("lblFecha"), Label)
        Dim hfFecha As HiddenField = CType(Me.gvDiasEco.Rows(e.RowIndex).FindControl("hfFecNac"), HiddenField)

        Dim oEmp As New Empleado
        Dim oUsuario As New Usuario
        Dim drUsuario As DataRow

        oUsuario.Login = Session("Login")
        drUsuario = oUsuario.ObtenerPorLogin()

        oEmp.Ins_O_UpdDiasEconomicos(CInt(lblIdEmp.Text), CDate(lblFecha.Text), CDate(hfFecha.Value), CShort(drUsuario("IdUsuario")), 0, CType(Session("ArregloAuditoria"), String()))

        Me.gvDiasEco.Columns(0).Visible = True 'Select

        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "DiasEconomicos")
        Me.gvDiasEco.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))

        Me.gvDiasEco.SelectedIndex = e.RowIndex
        Me.gvDiasEco.EditIndex = -1
        BindgvDiasEco(e.RowIndex)

        SubActualizar()
    End Sub
    Protected Sub gvDiasEco_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDiasEco.SelectedIndexChanged

    End Sub

    Protected Sub gvDiasEco_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvDiasEco.RowDeleting
        Dim lblIdEmp As Label = CType(Me.gvDiasEco.Rows(e.RowIndex).FindControl("lblIdEmp"), Label)
        Dim lblFecha As Label = CType(Me.gvDiasEco.Rows(e.RowIndex).FindControl("lblFecha"), Label)

        Dim oEmp As New Empleado
        oEmp.EliminaDiaEconomicos(CInt(lblIdEmp.Text), CDate(lblFecha.Text), CType(Session("ArregloAuditoria"), String()))

        If e.RowIndex = Me.gvDiasEco.SelectedIndex Then Me.gvDiasEco.SelectedIndex = -1

        BindgvDiasEco(e.RowIndex)
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        'If Request.Params(1).Contains("BtnSearch") Then
        '    BindDatos()
        'ElseIf Request.Params(1).Contains("BtnNewSearch") Then
        '    SubCancelingEditgvDiasEco()
        '    ddlAños.Enabled = False
        '    btnConsultar.Enabled = False
        '    txtbxFechaNuevoDiaEco.Enabled = False
        '    ibFechaNuevoDiaEco.Enabled = False
        '    btnGuardarNuevoDiaEco.Enabled = False
        '    gvDiasEco.Enabled = False
        'ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
        '    gvDiasEco.Enabled = True
        '    SubActualizar()
        'End If
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(1).Contains("BtnSearch") Then
                'If hfRFC.Value <> String.Empty Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    SubActualizar()
                    pnl1.Visible = True
                Else
                    pnl1.Visible = False
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                SubActualizar()
                Me.pnl1.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                Me.pnl1.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    SubActualizar()
                    pnl1.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Me.gvDiasEco.EditIndex = -1
        BindDatos()
        Me.gvDiasEco.Columns(0).Visible = True 'Select

        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "DiasEconomicos")
        Me.gvDiasEco.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        SubActualizar()
    End Sub

    Protected Sub ibFecNac_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ibFecNac As ImageButton = CType(Me.gvDiasEco.Rows(Me.gvDiasEco.EditIndex).FindControl("ibFecNac"), ImageButton)
        Dim txtbxFecha As TextBox = CType(Me.gvDiasEco.Rows(Me.gvDiasEco.EditIndex).FindControl("txtbxFecha"), TextBox)
        Dim hfFecNac As HiddenField = CType(Me.gvDiasEco.Rows(Me.gvDiasEco.EditIndex).FindControl("hfFecNac"), HiddenField)
        Dim lblFecha As Label = CType(Me.gvDiasEco.Rows(Me.gvDiasEco.EditIndex).FindControl("lblFecha"), Label)

        If hfFecNac.Value = "" Then
            ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + txtbxFecha.ClientID + "','" + hfFecNac.ClientID + "');")
        Else
            ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx?Fecha=" + hfFecNac.Value + "','" + txtbxFecha.ClientID + "','" + hfFecNac.ClientID + "');")
        End If
    End Sub

    Protected Sub ibFechaNuevoDiaEco_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        If Me.hfFechaNuevoDiaEco.Value = "" Then
            Me.ibFechaNuevoDiaEco.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + Me.txtbxFechaNuevoDiaEco.ClientID + "','" + Me.hfFechaNuevoDiaEco.ClientID + "');")
        Else
            Me.ibFechaNuevoDiaEco.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx?Fecha=" + Me.hfFechaNuevoDiaEco.Value + "','" + Me.hfFechaNuevoDiaEco.ClientID + "','" + Me.hfFechaNuevoDiaEco.ClientID + "');")
        End If
    End Sub

    Protected Sub btnGuardarNuevoDiaEco_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oEmp As New Empleado
        Dim oUsuario As New Usuario
        Dim drUsuario As DataRow
        Dim drEmp As DataRow
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        oUsuario.Login = Session("Login")
        drUsuario = oUsuario.ObtenerPorLogin()

        oEmp.RFC = hfRFC.Value
        drEmp = oEmp.ObtenDatosPersonales().Rows(0)

        oEmp.Ins_O_UpdDiasEconomicos(CInt(drEmp("IdEmp")), CDate(Me.hfFechaNuevoDiaEco.Value), CDate(Me.hfFechaNuevoDiaEco.Value), CShort(drUsuario("IdUsuario")), 1, CType(Session("ArregloAuditoria"), String()))

        If Me.gvDiasEco.EditIndex = -1 Then BindgvDiasEco()

        Me.txtbxFechaNuevoDiaEco.Text = String.Empty
        Me.hfFechaNuevoDiaEco.Value = String.Empty
        Me.ibFechaNuevoDiaEco.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + Me.txtbxFechaNuevoDiaEco.ClientID + "','" + Me.hfFechaNuevoDiaEco.ClientID + "');")
    End Sub

    Protected Sub txtbxFechaNuevoDiaEco_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.hfFechaNuevoDiaEco.Value = Me.txtbxFechaNuevoDiaEco.Text
    End Sub

    Protected Sub txtbxFecha_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim hfFecha As HiddenField = CType(Me.gvDiasEco.Rows(Me.gvDiasEco.EditIndex).FindControl("hfFecNac"), HiddenField)
        Dim txtbxFecha As TextBox = CType(Me.gvDiasEco.Rows(Me.gvDiasEco.EditIndex).FindControl("txtbxFecha"), TextBox)
        hfFecha.Value = txtbxFecha.Text
    End Sub
End Class
