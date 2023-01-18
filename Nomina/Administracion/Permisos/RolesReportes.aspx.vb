Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class RolesReportes
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
    Private Sub BindgvReportesPermisos()
        Dim oAplic As New Aplicacion
        Me.lblPermisosRolX.Text = "Permisos del Rol " + Me.ddlRoles.SelectedItem.Text.Trim.ToUpper
        Me.gvReportesPermisos.DataSource = oAplic.ObtenerPermisosRolReportes(CShort(Me.ddlRoles.SelectedValue))
        Me.gvReportesPermisos.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Dim oUsr As New Usuario
            Dim dt As DataTable
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "RolesReportes")
            gvReportesPermisos.Columns(6).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlRoles()
            If Me.ddlRoles.SelectedValue <> -1 Then BindgvReportesPermisos()
        End If
    End Sub

    Protected Sub btnConsultarPermisos_Click(sender As Object, e As System.EventArgs) Handles btnConsultarPermisos.Click
        BindgvReportesPermisos()
    End Sub

    Protected Sub gvReportesPermisos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvReportesPermisos.RowDataBound
        If Me.gvReportesPermisos.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        End If
    End Sub

    Protected Sub gvReportesPermisos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvReportesPermisos.SelectedIndexChanged

    End Sub

    Protected Sub gvReportesPermisos_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvReportesPermisos.RowCancelingEdit
        Me.gvReportesPermisos.Columns(0).Visible = True 'Select
        Me.gvReportesPermisos.SelectedIndex = e.RowIndex
        Me.gvReportesPermisos.EditIndex = -1
        BindgvReportesPermisos()
    End Sub

    Protected Sub gvReportesPermisos_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvReportesPermisos.RowEditing
        Me.gvReportesPermisos.Columns(0).Visible = False 'Select
        Me.gvReportesPermisos.SelectedIndex = -1
        Me.gvReportesPermisos.EditIndex = e.NewEditIndex
        BindgvReportesPermisos()
    End Sub

    Protected Sub gvReportesPermisos_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvReportesPermisos.RowUpdating
        Dim lblIdReporteE As Label = CType(Me.gvReportesPermisos.Rows(e.RowIndex).FindControl("lblIdReporteE"), Label)
        Dim chkbxPermisoE As CheckBox = CType(Me.gvReportesPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoE"), CheckBox)
        Dim oAplic As New Aplicacion

        oAplic.InsUpdRolesReportes(CByte(ddlRoles.SelectedValue), CShort(lblIdReporteE.Text), chkbxPermisoE.Checked, _
                                   CType(Session("ArregloAuditoria"), String()))

        Me.gvReportesPermisos.Columns(0).Visible = True 'Select     
        Me.gvReportesPermisos.SelectedIndex = e.RowIndex
        Me.gvReportesPermisos.EditIndex = -1
        BindgvReportesPermisos()

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "RolesReportes")
        gvReportesPermisos.Columns(6).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
    End Sub

    Protected Sub ddlRoles_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlRoles.SelectedIndexChanged
        BindgvReportesPermisos()
    End Sub
End Class
