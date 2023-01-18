Imports System.IO
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Nominas

Partial Class frmSubirArchivosDeducs
    Inherits System.Web.UI.Page
    Private Sub BindQnas()
        Dim oQna As New Quincenas

        If Not AjaxFileUpload1.IsInFileUploadPostBack Then
            Session.Remove("strQnaParaUploadDeducs")
        End If

        With Me.ddlQnasAbiertasParaCaptura
            .DataSource = oQna.ObtenAbiertasParaCaptura()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()

            If Not AjaxFileUpload1.IsInFileUploadPostBack Then
                Session.Add("strQnaParaUploadDeducs", ddlQnasAbiertasParaCaptura.SelectedItem.Text)
            Else
                ddlQnasAbiertasParaCaptura.SelectedItem.Text = Session("strQnaParaUploadDeducs")
            End If

            If .Items.Count > 0 Then
                'Me.btnImportar.Enabled = True
                'Me.btnEliminar.Enabled = True
            Else
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas abiertas para captura.")
                .Items(0).Value = -1
                AjaxFileUpload1.Visible = False
                'Me.btnImportar.Enabled = False
                'Me.btnEliminar.Enabled = False
            End If
        End With
    End Sub
    Protected Sub AjaxFileUpload1_UploadComplete(sender As Object, e As AjaxControlToolkit.AjaxFileUploadEventArgs)
        Dim TargetPath As String = String.Empty
        Dim strAnio As String = Left(ddlQnasAbiertasParaCaptura.SelectedItem.Text, 4)
        Dim strQna As String = ddlQnasAbiertasParaCaptura.SelectedItem.Text

        If Not Directory.Exists(ConfigurationManager.AppSettings("RutaImportarDeducciones") + "\" + strAnio) Then
            Directory.CreateDirectory(ConfigurationManager.AppSettings("RutaImportarDeducciones") + "\" + strAnio)
        End If

        If Not Directory.Exists(ConfigurationManager.AppSettings("RutaImportarDeducciones") + "\" + strAnio + "\" + strQna.Replace("-", "_")) Then
            Directory.CreateDirectory(ConfigurationManager.AppSettings("RutaImportarDeducciones") + "\" + strAnio + "\" + strQna.Replace("-", "_"))
        End If

        TargetPath = ConfigurationManager.AppSettings("RutaImportarDeducciones") '+ "\" + strAnio.ToString + "\" + strQna.Replace("-", "_").ToString + "\" + e.FileName.ToString
        TargetPath = TargetPath + "\" + strAnio.ToString
        TargetPath = TargetPath + "\" + strQna.Replace("-", "_").ToString
        TargetPath = TargetPath + "\" + e.FileName.ToString

        AjaxFileUpload1.SaveAs(TargetPath)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim oUsr As New Usuario

        If Not IsPostBack Then
            Me.Response.Expires = 0

            BindQnas()

            Me.MultiView1.SetActiveView(Me.viewUpLoad)

        Else
            Session.Remove("strQnaParaUploadDeducs")
            Session.Add("strQnaParaUploadDeducs", ddlQnasAbiertasParaCaptura.SelectedItem.Text)
        End If
    End Sub

    Protected Sub AjaxFileUpload1_UploadCompleteAll(sender As Object, e As AjaxControlToolkit.AjaxFileUploadCompleteAllEventArgs)
        Me.MultiView1.SetActiveView(Me.viewRelacionaArchivos)
    End Sub

    Protected Sub ddlQnasAbiertasParaCaptura_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlQnasAbiertasParaCaptura.SelectedIndexChanged
        Session.Remove("strQnaParaUploadDeducs")
        Session.Add("strQnaParaUploadDeducs", ddlQnasAbiertasParaCaptura.SelectedItem.Text)
    End Sub
End Class
