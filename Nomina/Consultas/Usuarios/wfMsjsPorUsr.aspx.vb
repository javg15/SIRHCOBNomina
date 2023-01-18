Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class wfMsjsPorUsr
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindgvNotificaciones()
        Try
            Dim oAplic As New Aplicacion

            If Session("Login") Is Nothing = False Then

                gvNotificaciones.DataSource = oAplic.GetMsjsParaUsuario(Session("Login"))
                gvNotificaciones.DataBind()

                If gvNotificaciones.Rows.Count = 0 Then
                    gvNotificaciones.EmptyDataText = "No existen actualmente mensajes para usted."
                    gvNotificaciones.DataBind()
                End If
            Else
                Session.RemoveAll()
                Response.Redirect("~/Login.aspx")
            End If
        Catch ex As  Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindgvNotificaciones()
        End If
    End Sub
    Protected Sub gvNotificaciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvNotificaciones.SelectedIndexChanged
    End Sub

    Protected Sub gvNotificaciones_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvNotificaciones.RowEditing
        gvNotificaciones.Columns(0).Visible = False
        gvNotificaciones.SelectedIndex = -1
        gvNotificaciones.EditIndex = e.NewEditIndex
        BindgvNotificaciones()
    End Sub
    Protected Sub gvNotificaciones_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvNotificaciones.RowCancelingEdit
        gvNotificaciones.Columns(0).Visible = True
        gvNotificaciones.SelectedIndex = e.RowIndex
        gvNotificaciones.EditIndex = -1
        BindgvNotificaciones()
    End Sub

    Protected Sub gvNotificaciones_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvNotificaciones.RowDeleting

    End Sub

    Protected Sub gvNotificaciones_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvNotificaciones.RowUpdating
        If gvNotificaciones.EditIndex <> -1 Then
            Dim lblIdMsj_E As Label = CType(gvNotificaciones.Rows(e.RowIndex).FindControl("lblIdMsj_E"), Label)
            Dim ChkBxAtendido_E As CheckBox = CType(gvNotificaciones.Rows(e.RowIndex).FindControl("ChkBxAtendido_E"), CheckBox)
            Dim oAplic As New Aplicacion
            Dim dtNotif As DataTable
            If Session("Login") Is Nothing = False Then
                oAplic.UpdMsjsParaUsuario(CInt(lblIdMsj_E.Text), ChkBxAtendido_E.Checked, CType(Session("ArregloAuditoria"), String()))

                dtNotif = oAplic.GetMsjsParaUsuario(Session("Login"))
                CType(Master.FindControl("lnkbtnNotific"), LinkButton).Text = "Notificaciones pendientes (" + dtNotif.Rows.Count.ToString + ")"

                gvNotificaciones.Columns(0).Visible = True
                gvNotificaciones.SelectedIndex = e.RowIndex
                gvNotificaciones.EditIndex = -1
                BindgvNotificaciones()
            Else
                Session.RemoveAll()
                Response.Redirect("~/Login.aspx")
            End If
        End If
    End Sub

    Protected Sub gvNotificaciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvNotificaciones.RowDataBound
        If gvNotificaciones.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        End If
    End Sub
End Class
