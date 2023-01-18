Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class RolesPaginas
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
    Private Sub BindgvPaginasPermisos()
        Dim oAplic As New Aplicacion
        Me.gvPaginasPermisos.DataSource = oAplic.ObtenerPermisosRolPaginas(CShort(Me.ddlRoles.SelectedValue))
        Me.gvPaginasPermisos.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Dim oUsr As New Usuario
            Dim dt As DataTable
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "RolesPaginas")
            gvPaginasPermisos.Columns(9).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlRoles()
            If Me.ddlRoles.SelectedValue <> -1 Then BindgvPaginasPermisos()
        End If
    End Sub

    Protected Sub btnConsultarPermisos_Click(sender As Object, e As System.EventArgs) Handles btnConsultarPermisos.Click
        BindgvPaginasPermisos()
    End Sub

    Protected Sub gvPaginasPermisos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPaginasPermisos.RowDataBound
        If Me.gvPaginasPermisos.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        End If
    End Sub

    Protected Sub gvPaginasPermisos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPaginasPermisos.SelectedIndexChanged

    End Sub

    Protected Sub gvPaginasPermisos_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvPaginasPermisos.RowCancelingEdit
        Me.gvPaginasPermisos.Columns(0).Visible = True 'Select
        Me.gvPaginasPermisos.SelectedIndex = e.RowIndex
        Me.gvPaginasPermisos.EditIndex = -1
        BindgvPaginasPermisos()
    End Sub

    Protected Sub gvPaginasPermisos_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvPaginasPermisos.RowEditing
        Me.gvPaginasPermisos.Columns(0).Visible = False 'Select
        Me.gvPaginasPermisos.SelectedIndex = -1
        Me.gvPaginasPermisos.EditIndex = e.NewEditIndex
        BindgvPaginasPermisos()
    End Sub

    Protected Sub gvPaginasPermisos_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvPaginasPermisos.RowUpdating
        Dim lblIdRolE As Label = CType(Me.gvPaginasPermisos.Rows(e.RowIndex).FindControl("lblIdRolE"), Label)
        Dim lblIdPaginaE As Label = CType(Me.gvPaginasPermisos.Rows(e.RowIndex).FindControl("lblIdPaginaE"), Label)
        Dim chkbxActualizacionE As CheckBox = CType(Me.gvPaginasPermisos.Rows(e.RowIndex).FindControl("chkbxActualizacionE"), CheckBox)
        Dim chkbxInsercionE As CheckBox = CType(Me.gvPaginasPermisos.Rows(e.RowIndex).FindControl("chkbxInsercionE"), CheckBox)
        Dim chkbxEliminacionE As CheckBox = CType(Me.gvPaginasPermisos.Rows(e.RowIndex).FindControl("chkbxEliminacionE"), CheckBox)
        Dim chkbxConsultaE As CheckBox = CType(Me.gvPaginasPermisos.Rows(e.RowIndex).FindControl("chkbxConsultaE"), CheckBox)
        Dim oAplic As New Aplicacion

        oAplic.InsUpdRolesPaginas(CByte(lblIdRolE.Text), CShort(lblIdPaginaE.Text), chkbxActualizacionE.Checked, chkbxInsercionE.Checked, _
                                  chkbxEliminacionE.Checked, chkbxConsultaE.Checked, CType(Session("ArregloAuditoria"), String()))

        Me.gvPaginasPermisos.Columns(0).Visible = True 'Select     
        Me.gvPaginasPermisos.SelectedIndex = e.RowIndex
        Me.gvPaginasPermisos.EditIndex = -1
        BindgvPaginasPermisos()

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "RolesPaginas")
        gvPaginasPermisos.Columns(9).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
    End Sub
End Class
