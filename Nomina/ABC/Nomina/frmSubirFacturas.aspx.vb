Imports System.IO
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports System.IO.Compression
Imports Ionic.Zip
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV


Partial Class frmSubirFacturas
    Inherits System.Web.UI.Page

    Protected Sub AjaxFileUpload1_UploadComplete(sender As Object, e As AjaxControlToolkit.AjaxFileUploadEventArgs) Handles AjaxFileUpload1.UploadComplete
        Dim TargetPath As String = String.Empty
        Dim extensionFile As String = String.Empty

        TargetPath = ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP")
        Try
            My.Computer.FileSystem.DeleteFile(TargetPath + "SubirFacturas.zip")
        Catch
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(TargetPath + "ActualizarFolios.csv")
        Catch
        End Try


        extensionFile = e.FileName.Split(".")(1)
        If extensionFile.ToUpper = "ZIP" Then
            AjaxFileUpload1.SaveAs(TargetPath + "SubirFacturas.zip")
        ElseIf extensionFile.ToUpper = "CSV" Or extensionFile.ToUpper = "TXT" Then
            AjaxFileUpload1.SaveAs(TargetPath + "ActualizarFolios.csv")
        End If
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



    Sub UnZip(Src As String, Target As String)
        Dim ZipToUnpack As String = Src
        Dim TargetDir As String = Target
        Dim destino As Array
        Dim oTimbrado As HistorialTimbrado
        Dim respuesta As String = ""


        Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
            Dim e As ZipEntry
            For Each e In zip1
                destino = e.FileName.Split("_")
                TargetDir = Target _
                    + "/20" + destino(4).ToString.Substring(0, 2) _
                    + "/" + destino(4).ToString.Substring(2, 2) _
                    + "/" + destino(4).ToString.Substring(4, 2)
                e.Extract(TargetDir, ExtractExistingFileAction.OverwriteSilently)

                'Actualizar BD
                If e.FileName.Split(".")(1).ToUpper = "XML" Then
                    oTimbrado = New HistorialTimbrado
                    respuesta = oTimbrado.ActualizarUUID(destino(4).Split(".")(0), Nothing, e.FileName)
                    If respuesta <> "" Then
                        lblMsjError.Text = respuesta
                        lblMsjError.Visible = True
                        Exit For
                    Else
                        lblMsjError.Visible = False
                    End If
                End If
            Next
        End Using


    End Sub

    Sub ReadUUID(Src As String)
        Dim oTimbrado As HistorialTimbrado
        Dim sr As System.IO.StreamReader = Nothing
        Dim respuesta As String
        Try
            sr = New System.IO.StreamReader(Src, System.Text.Encoding.Default, True)

            While sr.Peek() <> -1
                Dim s As String = sr.ReadLine()
                If String.IsNullOrEmpty(s) Then
                    Continue While
                Else
                    Dim data() As String 'an array that will hold each value
                    data = Split(s, ",") 'split 'rawData' with a comma as delimiter
                    If IsNumeric(data(0).Substring(0, 1)) Then
                        oTimbrado = New HistorialTimbrado
                        respuesta = oTimbrado.ActualizarUUID(data(0), data(1), Nothing)
                        If respuesta <> "" Then
                            lblMsjError.Text = respuesta
                            lblMsjError.Visible = True
                            Exit While
                        Else
                            lblMsjError.Visible = False
                        End If
                    End If
                End If
            End While
            sr.Close()

        Catch ex As Exception
            Me.MultiView1.Visible = False
        Finally
            sr.Close()
        End Try
    End Sub

    Protected Sub btnEjecutarArchivo_Click(sender As Object, e As EventArgs) Handles btnEjecutarArchivo.Click
        Dim TargetPath As String = String.Empty
        Dim extensionFile As String = String.Empty
        Dim fileReader As System.IO.StreamReader

        TargetPath = ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP")
        lblError.Text = ""
        Try
            'test para saber si existe el archivo
            fileReader = My.Computer.FileSystem.OpenTextFileReader(TargetPath + "SubirFacturas.zip")
            fileReader.Close()
            UnZip(TargetPath + "SubirFacturas.zip", ConfigurationManager.AppSettings("RutaFacturas"))
            lblExito.Visible = True
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
            Try
                'test para saber si existe el archivo
                fileReader = My.Computer.FileSystem.OpenTextFileReader(TargetPath + "ActualizarFolios.csv")
                fileReader.Close()
                ReadUUID(TargetPath + "ActualizarFolios.csv")
                lblExito.Visible = True
                lblError.Visible = False
            Catch ex2 As Exception
                lblError.Text = lblError.Text + vbCrLf + ex2.Message
                lblError.Visible = True
            End Try
        End Try

    End Sub
End Class
