Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class wfInfParaEnvioRecibosPago
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.MultiView1.SetActiveView(Me.viewCambioPassw)
        End If
    End Sub
    Protected Sub ChangePassword1_ChangingPassword(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles ChangePassword1.ChangingPassword
        Try
            Dim oUsr As New Usuario

            oUsr.Login = Session("Login")
            oUsr.Password = ChangePassword1.CurrentPassword
            If oUsr.EsValido(CType(Session("ArregloAuditoria"), String())) Then
                oUsr.Password = ChangePassword1.NewPassword
                oUsr.ActualizarPassword()

                Me.MultiView1.SetActiveView(viewCapturaExitosa)
            Else
                Me.lblErrores.Text = "La contraseña actual es incorrecta."
                Me.MultiView1.SetActiveView(Me.viewErrores)
            End If
        Catch ex As Exception
            Me.lblErrores.Text = ex.Message
            Me.MultiView1.SetActiveView(Me.viewErrores)
        End Try
        e.Cancel = True
    End Sub


    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
        Me.MultiView1.SetActiveView(Me.viewCambioPassw)
    End Sub
End Class
