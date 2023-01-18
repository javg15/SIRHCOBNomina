Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class RolesDeducciones
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
    Private Sub BindgvDeducsPermisos(Optional ByVal pEdit As Boolean = False)
        Dim itemEdit As Integer = Me.gvDeducsPermisos.EditIndex
        If Not pEdit Then
            Me.gvDeducsPermisos.EditIndex = -1
        End If

        Dim oAplic As New Aplicacion
        Me.gvDeducsPermisos.DataSource = oAplic.ObtenerPermisosRolDeducciones(CShort(Me.ddlRoles.SelectedValue), ddlRoles.SelectedItem.Text.Trim)
        Me.gvDeducsPermisos.DataBind()

        If pEdit Then
            Me.gvDeducsPermisos.Columns(0).Visible = True 'Select
        End If
        If Not pEdit Then
            Me.gvDeducsPermisos.SelectedIndex = itemEdit
        End If

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "RolesPermisosSobreDeducs")
        gvDeducsPermisos.Columns(8).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlRoles()
            If Me.ddlRoles.SelectedValue <> -1 Then BindgvDeducsPermisos()
        End If
    End Sub

    Protected Sub btnConsultarPermisos_Click(sender As Object, e As System.EventArgs) Handles btnConsultarPermisos.Click
        BindgvDeducsPermisos()
        Me.gvDeducsPermisos.Columns(0).Visible = True 'Select
    End Sub

    Protected Sub gvDeducsPermisos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDeducsPermisos.RowDataBound
        If Me.gvDeducsPermisos.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        End If
    End Sub

    Protected Sub gvDeducsPermisos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvDeducsPermisos.SelectedIndexChanged

    End Sub

    Protected Sub gvDeducsPermisos_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvDeducsPermisos.RowCancelingEdit
        Dim vlSelectedIndex As Integer = e.RowIndex
        Me.gvDeducsPermisos.Columns(0).Visible = True 'Select
        Me.gvDeducsPermisos.SelectedIndex = e.RowIndex
        Me.gvDeducsPermisos.EditIndex = -1
        BindgvDeducsPermisos()
        Me.gvDeducsPermisos.SelectedIndex = vlSelectedIndex
    End Sub

    Protected Sub gvPercsPermisos_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvDeducsPermisos.RowEditing
        Me.gvDeducsPermisos.SelectedIndex = -1
        Me.gvDeducsPermisos.EditIndex = e.NewEditIndex
        BindgvDeducsPermisos(True)
        Me.gvDeducsPermisos.Columns(0).Visible = False 'Select
    End Sub

    Protected Sub gvDeducsPermisos_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvDeducsPermisos.RowUpdating
        Dim lblIdRolE As Label = CType(Me.gvDeducsPermisos.Rows(e.RowIndex).FindControl("lblIdRolE"), Label)
        Dim lblIdDeduccionE As Label = CType(Me.gvDeducsPermisos.Rows(e.RowIndex).FindControl("lblIdDeduccionE"), Label)
        Dim chkbxPermisoCapturaNominaE As CheckBox = CType(Me.gvDeducsPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoCapturaNominaE"), CheckBox)
        Dim chkbxPermisoCapturaReciboE As CheckBox = CType(Me.gvDeducsPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoCapturaReciboE"), CheckBox)
        Dim chkbxPermisoConsultaE As CheckBox = CType(Me.gvDeducsPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoConsultaE"), CheckBox)
        Dim chkbxPermisoTblRolesDeduccionesParaRecibosE As CheckBox = CType(Me.gvDeducsPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoTblRolesDeduccionesParaRecibosE"), CheckBox)
        Dim chkbxPermisoTblRolesDeduccionesE As CheckBox = CType(Me.gvDeducsPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoTblRolesDeduccionesE"), CheckBox)

        Dim oAplic As New Aplicacion

        oAplic.InsUpdRolesDeducciones(CByte(lblIdRolE.Text), CShort(lblIdDeduccionE.Text), chkbxPermisoCapturaNominaE.Checked, chkbxPermisoCapturaReciboE.Checked, _
                                  chkbxPermisoConsultaE.Checked, chkbxPermisoTblRolesDeduccionesParaRecibosE.Checked, _
                                  chkbxPermisoTblRolesDeduccionesE.Checked, CType(Session("ArregloAuditoria"), String()))

        Me.gvDeducsPermisos.Columns(0).Visible = True 'Select     
        Me.gvDeducsPermisos.SelectedIndex = e.RowIndex
        Me.gvDeducsPermisos.EditIndex = -1
        BindgvDeducsPermisos()
    End Sub
End Class
