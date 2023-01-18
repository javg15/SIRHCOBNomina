Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV.MovsDePersonal
Partial Class MovsDePersonal_Cadenas
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindddlAños()
        Dim oEjercicioFiscal As New EjercicioFiscal
        With Me.ddlAños
            .DataSource = oEjercicioFiscal.ObtenAños()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, New ListItem("No existe información de ejercicios", "-1"))
                Me.btnConsultar.Enabled = False
            Else
                Me.btnConsultar.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindgvCadenas()
        Dim oUsr As New Usuario
        Dim drUsr As DataRow

        drUsr = oUsr.ObtenerPorLogin(Session("Login"))

        Dim oCadena As New Cadenas
        Me.gvCadenas.DataSource = oCadena.ObtenPorEjercUsr(Session("Login"), CShort(Me.ddlAños.SelectedValue))
        Me.gvCadenas.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oUsr As New Usuario
            Dim dt As DataTable
            Dim oQna As New Quincenas

            BindddlAños()
            BindgvCadenas()
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Cadenas")
            lbCrearNuevaCadena.Visible = CBool(dt.Rows(0).Item("Insercion"))
            lbCrearNuevaCadena.Visible = oQna.HayAbiertasParaCaptura()
            gvCadenas.Columns(12).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            gvCadenas.Columns(13).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
            gvCadenas.Columns(14).Visible = CBool(dt.Rows(0).Item("Consulta"))
        End If
    End Sub
    Protected Sub gvCadenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCadenas.SelectedIndexChanged
    End Sub

    Protected Sub gvCadenas_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvCadenas.RowEditing
        Me.gvCadenas.Columns(0).Visible = False 'Select
        Me.gvCadenas.Columns(13).Visible = False 'Delete
        Me.gvCadenas.Columns(14).Visible = False 'VerMovs
        Me.gvCadenas.SelectedIndex = -1
        Me.gvCadenas.EditIndex = e.NewEditIndex
        BindgvCadenas()

        Dim fila As Integer = Me.gvCadenas.EditIndex
        Dim lblIdEstatusCadena_E As Label = CType(Me.gvCadenas.Rows(fila).FindControl("lblIdEstatusCadena_E"), Label)
        Dim lblIdOrigenPropuesta_E As Label = CType(Me.gvCadenas.Rows(fila).FindControl("lblIdOrigenPropuesta_E"), Label)
        Dim ddlEstatusActualCadena_E As DropDownList = CType(Me.gvCadenas.Rows(fila).FindControl("ddlEstatusActualCadena_E"), DropDownList)
        Dim ddlOrigenPropuesta_E As DropDownList = CType(Me.gvCadenas.Rows(fila).FindControl("ddlOrigenPropuesta_E"), DropDownList)

        Dim oCadena As New Cadenas
        Dim oOrigProp As New OrigenPropuestas

        LlenaDDL(ddlEstatusActualCadena_E, "EstatusCadena", "IdEstatusCadena", oCadena.ObtenPosiblesEstatus(), lblIdEstatusCadena_E.Text)
        LlenaDDL(ddlOrigenPropuesta_E, "OrigenPropuesta", "IdOrigenPropuesta", oOrigProp.ObtenOrigenPropuestas(), lblIdOrigenPropuesta_E.Text)
    End Sub
    Protected Sub gvCadenas_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvCadenas.RowCancelingEdit
        Me.gvCadenas.Columns(0).Visible = True 'Select
        Me.gvCadenas.SelectedIndex = e.RowIndex
        Me.gvCadenas.EditIndex = -1
        BindgvCadenas()

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Cadenas")
        Me.lbCrearNuevaCadena.Visible = CBool(dt.Rows(0).Item("Insercion"))
        Me.gvCadenas.Columns(12).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        Me.gvCadenas.Columns(13).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
        Me.gvCadenas.Columns(14).Visible = CBool(dt.Rows(0).Item("Consulta"))
    End Sub

    Protected Sub gvCadenas_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCadenas.RowDeleting

    End Sub

    Protected Sub gvCadenas_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvCadenas.RowUpdating
        If Me.gvCadenas.EditIndex <> -1 Then
            Dim lblIdCadena_E As Label = CType(Me.gvCadenas.Rows(e.RowIndex).FindControl("lblIdCadena_E"), Label)
            Dim tbOficioDePropuesta_E As TextBox = CType(Me.gvCadenas.Rows(e.RowIndex).FindControl("tbOficioDePropuesta_E"), TextBox)
            Dim tbFchParaOrdDePres_E As TextBox = CType(Me.gvCadenas.Rows(e.RowIndex).FindControl("tbFchParaOrdDePres_E"), TextBox)
            Dim ddlEstatusActualCadena_E As DropDownList = CType(Me.gvCadenas.Rows(e.RowIndex).FindControl("ddlEstatusActualCadena_E"), DropDownList)
            Dim ddlOrigenPropuesta_E As DropDownList = CType(Me.gvCadenas.Rows(e.RowIndex).FindControl("ddlOrigenPropuesta_E"), DropDownList)

            Dim oCadena As New Cadenas

            oCadena.ActualizaInf(CInt(lblIdCadena_E.Text), tbFchParaOrdDePres_E.Text.Trim, tbOficioDePropuesta_E.Text, _
                                Session("Login"), CByte(ddlEstatusActualCadena_E.SelectedValue), _
                                CByte(ddlOrigenPropuesta_E.SelectedValue), CType(Session("ArregloAuditoria"), String()))

            Me.gvCadenas.Columns(0).Visible = True 'Select
            Me.gvCadenas.SelectedIndex = e.RowIndex
            Me.gvCadenas.EditIndex = -1
            BindgvCadenas()

            Dim oUsr As New Usuario
            Dim dt As DataTable
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Cadenas")
            Me.lbCrearNuevaCadena.Visible = CBool(dt.Rows(0).Item("Insercion"))
            Me.gvCadenas.Columns(12).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            Me.gvCadenas.Columns(13).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
            Me.gvCadenas.Columns(14).Visible = CBool(dt.Rows(0).Item("Consulta"))
        End If
    End Sub

    Protected Sub lbCrearNuevaCadena_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbCrearNuevaCadena.Click
        Dim oCadena As New Cadenas
        Dim oUsr As New Usuario
        Dim drUsr As DataRow

        oUsr.Login = Session("Login")
        drUsr = oUsr.ObtenerPorLogin()

        oCadena.CreaNueva(CShort(drUsr("IdUsuario")), CType(Session("ArregloAuditoria"), String()))
        BindgvCadenas()
    End Sub

    Protected Sub gvCadenas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCadenas.RowDataBound
        Dim oUsr As New Usuario
        Dim drUsr As DataRow
        If Me.gvCadenas.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblIdUsuarioCreador As Label = CType(e.Row.FindControl("lblIdUsuarioCreador"), Label)
                    Dim lblIdUsuarioModifico As Label = CType(e.Row.FindControl("lblIdUsuarioModifico"), Label)
                    Dim lblLoginCreador As Label = CType(e.Row.FindControl("lblLoginCreador"), Label)
                    Dim lblLoginModifico As Label = CType(e.Row.FindControl("lblLoginModifico"), Label)
                    Dim ibVerMovs As ImageButton = CType(e.Row.FindControl("ibVerMovs"), ImageButton)
                    Dim lblIdCadena As Label = CType(e.Row.FindControl("lblIdCadena"), Label)
                    Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                    Dim oCadena As New Cadenas
                    Dim dr As DataRow

                    dr = oCadena.TieneMovsDePersAsociados(CInt(lblIdCadena.Text))

                    ibEliminar.Enabled = CBool(dr("CadenaSePuedeEliminar"))
                    ibEliminar.ToolTip = "Eliminar cadena"
                    If ibEliminar.Enabled = False Then
                        ibEliminar.ToolTip = "La cadena tiene movimientos de personal asociados por lo cual no se puede eliminar"
                    End If

                    ibVerMovs.OnClientClick = "javascript:abreVentMediaScreen('CadenaMovsAsociados.aspx?IdCadena=" + lblIdCadena.Text + "','" + lblIdCadena.Text + "'); return false;"

                    oUsr.IdUsuario = CShort(lblIdUsuarioCreador.Text)
                    drUsr = oUsr.ObtenerPorId()
                    lblLoginCreador.Text = drUsr("Login")
                    lblLoginCreador.ToolTip = drUsr("NomComUsr")

                    If lblIdUsuarioModifico.Text <> String.Empty Then
                        oUsr.IdUsuario = CShort(lblIdUsuarioModifico.Text)
                        drUsr = oUsr.ObtenerPorId()
                        lblLoginModifico.Text = drUsr("Login")
                        lblLoginModifico.ToolTip = drUsr("NomComUsr")
                    End If

                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        Else
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblIdUsuarioCreador_E As Label = CType(e.Row.FindControl("lblIdUsuarioCreador_E"), Label)
                    Dim lblIdUsuarioModifico_E As Label = CType(e.Row.FindControl("lblIdUsuarioModifico_E"), Label)
                    Dim lblLoginCreador_E As Label = CType(e.Row.FindControl("lblLoginCreador_E"), Label)
                    Dim lblLoginModifico_E As Label = CType(e.Row.FindControl("lblLoginModifico_E"), Label)

                    If lblIdUsuarioCreador_E Is Nothing Then
                        lblIdUsuarioCreador_E = CType(e.Row.FindControl("lblIdUsuarioCreador"), Label)
                        lblIdUsuarioModifico_E = CType(e.Row.FindControl("lblIdUsuarioModifico"), Label)
                        lblLoginCreador_E = CType(e.Row.FindControl("lblLoginCreador"), Label)
                        lblLoginModifico_E = CType(e.Row.FindControl("lblLoginModifico"), Label)
                    End If

                    oUsr.IdUsuario = CShort(lblIdUsuarioCreador_E.Text)
                    drUsr = oUsr.ObtenerPorId()
                    lblLoginCreador_E.Text = drUsr("Login")
                    lblLoginCreador_E.ToolTip = drUsr("NomComUsr")

                    If lblIdUsuarioModifico_E.Text <> String.Empty Then
                        oUsr.IdUsuario = CShort(lblIdUsuarioModifico_E.Text)
                        drUsr = oUsr.ObtenerPorId()
                        lblLoginModifico_E.Text = drUsr("Login")
                        lblLoginModifico_E.ToolTip = drUsr("NomComUsr")
                    End If
            End Select

        End If
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindgvCadenas()
    End Sub

    Protected Sub ibEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ibEliminar As ImageButton = CType(sender, ImageButton)
        Dim Fila As GridViewRow = CType(ibEliminar.NamingContainer, GridViewRow)

        Dim lblIdCadena As Label = CType(Me.gvCadenas.Rows(Fila.RowIndex).FindControl("lblIdCadena"), Label)

        Dim oCadena As New Cadenas

        oCadena.Elimina(CInt(lblIdCadena.Text), CType(Session("ArregloAuditoria"), String()))

        BindgvCadenas()
    End Sub
End Class
