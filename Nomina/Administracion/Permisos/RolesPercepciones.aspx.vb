Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class RolesPercepciones
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
    Private Sub BindgvPercsPermisos()
        Dim oAplic As New Aplicacion
        Me.gvPercsPermisos.DataSource = oAplic.ObtenerPermisosRolPercepciones(CShort(Me.ddlRoles.SelectedValue), ddlRoles.SelectedItem.Text.Trim)
        Me.gvPercsPermisos.DataBind()

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "RolesPermisosSobrePercs")
        gvPercsPermisos.Columns(8).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            'Dim oUsr As New Usuario
            'Dim dt As DataTable
            'dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "RolesPermisosSobrePercs")
            'gvPercsPermisos.Columns(7).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlRoles()
            If Me.ddlRoles.SelectedValue <> -1 Then BindgvPercsPermisos()
        End If
    End Sub

    Protected Sub btnConsultarPermisos_Click(sender As Object, e As System.EventArgs) Handles btnConsultarPermisos.Click
        BindgvPercsPermisos()
    End Sub

    Protected Sub gvPaginasPermisos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercsPermisos.RowDataBound
        If Me.gvPercsPermisos.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        End If
    End Sub

    Protected Sub gvPercsPermisos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPercsPermisos.SelectedIndexChanged

    End Sub

    Protected Sub gvPercsPermisos_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvPercsPermisos.RowCancelingEdit
        Me.gvPercsPermisos.Columns(0).Visible = True 'Select
        Me.gvPercsPermisos.SelectedIndex = e.RowIndex
        Me.gvPercsPermisos.EditIndex = -1
        BindgvPercsPermisos()
    End Sub

    Protected Sub gvPercsPermisos_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvPercsPermisos.RowEditing
        Me.gvPercsPermisos.Columns(0).Visible = False 'Select
        Me.gvPercsPermisos.SelectedIndex = -1
        Me.gvPercsPermisos.EditIndex = e.NewEditIndex
        BindgvPercsPermisos()
    End Sub

    Protected Sub gvPercsPermisos_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvPercsPermisos.RowUpdating
        Dim lblIdRolE As Label = CType(Me.gvPercsPermisos.Rows(e.RowIndex).FindControl("lblIdRolE"), Label)
        Dim lblIdPercepcionE As Label = CType(Me.gvPercsPermisos.Rows(e.RowIndex).FindControl("lblIdPercepcionE"), Label)
        Dim chkbxPermisoCapturaNominaE As CheckBox = CType(Me.gvPercsPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoCapturaNominaE"), CheckBox)
        Dim chkbxPermisoCapturaReciboE As CheckBox = CType(Me.gvPercsPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoCapturaReciboE"), CheckBox)
        Dim chkbxPermisoConsultaE As CheckBox = CType(Me.gvPercsPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoConsultaE"), CheckBox)
        Dim chkbxPermisoTblRolesPercepcionesParaRecibosE As CheckBox = CType(Me.gvPercsPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoTblRolesPercepcionesParaRecibosE"), CheckBox)
        Dim chkbxPermisoTblRolesPercepcionesE As CheckBox = CType(Me.gvPercsPermisos.Rows(e.RowIndex).FindControl("chkbxPermisoTblRolesPercepcionesE"), CheckBox)

        Dim oAplic As New Aplicacion

        oAplic.InsUpdRolesPercepciones(CByte(lblIdRolE.Text), CShort(lblIdPercepcionE.Text), chkbxPermisoCapturaNominaE.Checked, chkbxPermisoCapturaReciboE.Checked, _
                                  chkbxPermisoConsultaE.Checked, chkbxPermisoTblRolesPercepcionesParaRecibosE.Checked, _
                                  chkbxPermisoTblRolesPercepcionesE.Checked, CType(Session("ArregloAuditoria"), String()))

        Me.gvPercsPermisos.Columns(0).Visible = True 'Select     
        Me.gvPercsPermisos.SelectedIndex = e.RowIndex
        Me.gvPercsPermisos.EditIndex = -1
        BindgvPercsPermisos()
    End Sub
End Class
