
Partial Class PruebaUpdateProgress
    Inherits System.Web.UI.Page
    Protected Sub BtnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        System.Threading.Thread.Sleep(3000)
        'Me.Label1.Text = Date.Today
    End Sub
End Class
