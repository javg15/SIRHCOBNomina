
Partial Class WebControls_wucMuestraFoto
    Inherits System.Web.UI.UserControl

    'Protected Sub lbVerFoto_Click(sender As Object, e As System.EventArgs) Handles lbVerFoto.Click
    '    Me.lbVerFoto_MPE.Show()
    'End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.imgZoom_MPE.Hide()
    End Sub

    Protected Sub imgZoom_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgZoom.Click
        Me.imgZoom_MPE.Show()
    End Sub
End Class
