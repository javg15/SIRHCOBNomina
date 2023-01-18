Imports System.IO
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion

Partial Class frmSubirArchivosExpDigital
    Inherits System.Web.UI.Page
    Protected Sub AjaxFileUpload1_UploadComplete(sender As Object, e As AjaxControlToolkit.AjaxFileUploadEventArgs)
        Dim TargetPath As String = String.Empty

        TargetPath = ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP") + e.FileName
        AjaxFileUpload1.SaveAs(TargetPath)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim oUsr As New Usuario
        Dim dt As DataTable

        If Not IsPostBack Then
            Me.Response.Expires = 0
            Me.MultiView1.SetActiveView(Me.viewUpLoad)

            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsDocs")

            If CBool(dt.Rows(0).Item("Consulta")) = False Then Response.Redirect("~/SinPermiso.aspx?Home=SI")
        End If
    End Sub

    Protected Sub AjaxFileUpload1_UploadCompleteAll(sender As Object, e As AjaxControlToolkit.AjaxFileUploadCompleteAllEventArgs)
        Me.MultiView1.SetActiveView(Me.viewRelacionaArchivos)
    End Sub
End Class
