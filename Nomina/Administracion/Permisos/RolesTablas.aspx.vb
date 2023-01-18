Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class RolesTablas
    Inherits System.Web.UI.Page
    Private Sub BindddlRoles()
        Dim oAplic As New Aplicacion
        Me.ddlRoles.DataSource = oAplic.ObtenerRoles()
        Me.ddlRoles.DataTextField = "NombreRol"
        Me.ddlRoles.DataValueField = "IdRol"
        Me.ddlRoles.DataBind()
        If Me.ddlRoles.Items.Count = 0 Then
            Me.ddlRoles.Items.Insert(0, "No existen Roles creados")
            Me.ddlRoles.Items(0).Value = -1
            Me.btnConsultarPermisos.Enabled = False
        Else
            Me.btnConsultarPermisos.Enabled = True
        End If
    End Sub
    Private Sub BindgvTablasPermisos()
        Dim oAplic As New Aplicacion
        Me.gvTablasPermisos.DataSource = oAplic.ObtenerPermisosRolTablas(CShort(Me.ddlRoles.SelectedValue))
        Me.gvTablasPermisos.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Dim oUsr As New Usuario
            Dim dt As DataTable
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "RolesTablas")
            gvTablasPermisos.Columns(10).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlRoles()
            If Me.ddlRoles.SelectedValue <> -1 Then BindgvTablasPermisos()
        End If
    End Sub

    Protected Sub btnConsultarPermisos_Click(sender As Object, e As System.EventArgs) Handles btnConsultarPermisos.Click
        BindgvTablasPermisos()
    End Sub

    Protected Sub gvTablasPermisos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTablasPermisos.RowDataBound
        If Me.gvTablasPermisos.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        End If
    End Sub

    Protected Sub gvTablasPermisos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvTablasPermisos.SelectedIndexChanged

    End Sub

    Protected Sub gvTablasPermisos_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvTablasPermisos.RowCancelingEdit
        Me.gvTablasPermisos.Columns(0).Visible = True 'Select
        Me.gvTablasPermisos.SelectedIndex = e.RowIndex
        Me.gvTablasPermisos.EditIndex = -1
        BindgvTablasPermisos()
    End Sub

    Protected Sub gvTablasPermisos_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvTablasPermisos.RowEditing
        Me.gvTablasPermisos.Columns(0).Visible = False 'Select
        Me.gvTablasPermisos.SelectedIndex = -1
        Me.gvTablasPermisos.EditIndex = e.NewEditIndex
        BindgvTablasPermisos()
    End Sub

    Protected Sub gvTablasPermisos_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvTablasPermisos.RowUpdating
        Dim lblIdRolE As Label = CType(Me.gvTablasPermisos.Rows(e.RowIndex).FindControl("lblIdRolE"), Label)
        Dim lblIdTablaE As Label = CType(Me.gvTablasPermisos.Rows(e.RowIndex).FindControl("lblIdTablaE"), Label)
        Dim txtbxNombreTablaE As TextBox = CType(Me.gvTablasPermisos.Rows(e.RowIndex).FindControl("txtbxNombreTablaE"), TextBox)
        Dim chkbxActualizacionE As CheckBox = CType(Me.gvTablasPermisos.Rows(e.RowIndex).FindControl("chkbxActualizacionE"), CheckBox)
        Dim chkbxInsercionE As CheckBox = CType(Me.gvTablasPermisos.Rows(e.RowIndex).FindControl("chkbxInsercionE"), CheckBox)
        Dim chkbxEliminacionE As CheckBox = CType(Me.gvTablasPermisos.Rows(e.RowIndex).FindControl("chkbxEliminacionE"), CheckBox)
        Dim chkbxConsultaE As CheckBox = CType(Me.gvTablasPermisos.Rows(e.RowIndex).FindControl("chkbxConsultaE"), CheckBox)
        Dim chkbxSoloConsultaE As CheckBox = CType(Me.gvTablasPermisos.Rows(e.RowIndex).FindControl("chkbxSoloConsultaE"), CheckBox)
        Dim oAplic As New Aplicacion

        oAplic.InsUpdRolesTablas(CByte(lblIdRolE.Text), CShort(lblIdTablaE.Text), chkbxActualizacionE.Checked, chkbxInsercionE.Checked, _
                                  chkbxEliminacionE.Checked, chkbxConsultaE.Checked, chkbxSoloConsultaE.Checked, txtbxNombreTablaE.Text.Trim, _
                                  CType(Session("ArregloAuditoria"), String()))

        Me.gvTablasPermisos.Columns(0).Visible = True 'Select     
        Me.gvTablasPermisos.SelectedIndex = e.RowIndex
        Me.gvTablasPermisos.EditIndex = -1
        BindgvTablasPermisos()

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "RolesTablas")
        gvTablasPermisos.Columns(10).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
    End Sub

    Protected Sub btnAddTabla_Click(sender As Object, e As System.EventArgs) Handles btnAddTabla.Click
        Dim oAplic As New Aplicacion
        Dim oUsr As New Usuario
        Dim dt As DataTable

        oAplic.AgregaTabla(txtbxNomTabla.Text.Trim, ConfigurationManager.AppSettings("NombreAplicacion").ToString, CType(Session("ArregloAuditoria"), String()))
        txtbxNomTabla.Text = String.Empty
        BindgvTablasPermisos()

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "RolesTablas")
        gvTablasPermisos.Columns(10).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
    End Sub
End Class
