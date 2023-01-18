Partial Class WebControls_wucUpdateProgress
    Inherits System.Web.UI.UserControl
    Public Sub ActualizaMensaje(ByVal pMensaje As String)
        Dim lblMsjEspera As Label = CType(UpdateProgress1.FindControl("lblMsjEspera"), Label)
        lblMsjEspera.Text = pMensaje

        ' onclientclick="ChangeUpdateProgress('Eliminando archivos PDF anteriores, por favor espere...')"

        'Dim Script As String = "ChangeUpdateProgress('" + pMensaje + "');"
        'ScriptManager.RegisterStartupScript(Me, GetType(Page), "ChangeUpdateProgress", Script, True)
        'up_Progress.RenderControl()
    End Sub

End Class
