Imports iTextSharp.text.pdf.parser
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports Microsoft.Reporting.WebForms
Partial Class pruebas
    Inherits System.Web.UI.Page

    Public Function SeparaPDFEnHojas(ByVal pNombreArchivo As String) As String()

        Dim vlPagina As Integer
        Dim vlPDFReader As PdfReader
        Dim vlTxtHoja As String
        Dim arrayHojas(1) As String

        If (File.Exists(pNombreArchivo)) Then
            vlPDFReader = New PdfReader(pNombreArchivo)
            ReDim arrayHojas(vlPDFReader.NumberOfPages - 1)

            For vlPagina = 1 To vlPDFReader.NumberOfPages Step 1
                Dim strategy As New SimpleTextExtractionStrategy()
                vlTxtHoja = PdfTextExtractor.GetTextFromPage(vlPDFReader, vlPagina, strategy)

                vlTxtHoja = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(vlTxtHoja)))
                arrayHojas(vlPagina - 1) = vlTxtHoja
            Next
            vlPDFReader.Close()
        Else
            arrayHojas(0) = ""
        End If
        Return arrayHojas
    End Function
    Private Sub GeneraPDF()
        Dim rview As New ReportViewer
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty
        Dim deviceInfo As String = String.Empty
        Dim streamids As String() = Nothing
        Dim warnings As Microsoft.Reporting.WebForms.Warning() = Nothing
        Dim format As String = "PDF"
        Dim paramList As New System.Collections.Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
        Dim bytes As Byte()
        Dim dt As DataTable
        Dim oReporte As New Reportes

        If Request.Params("SubTipoReporte") Is Nothing Then
            dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")))
        Else
            dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")), CByte(Request.Params("SubTipoReporte")))
        End If

        deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>"

        For Each dr As DataRow In dt.Rows
            If Request.Params(dr("VariableAsociada")) Is Nothing = False And dr("VariableAsociada") <> String.Empty Then
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter(dr("NombreParametro").ToString, Request.Params(dr("VariableAsociada").ToString)))
            End If
        Next

        If Session("pFchImpRpt") Is Nothing = False Then
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pFchImpRpt", CDate(Session("pFchImpRpt"))))
        End If

        rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ServerReportes"))
        rview.ServerReport.ReportPath = "/Reportes/" + dt.Rows(0).Item("NombreReporte").ToString

        rview.ServerReport.SetParameters(paramList)
        bytes = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamids, warnings)

        If (File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + "Nomina.pdf")) Then
            File.Delete(ConfigurationManager.AppSettings("RutaPagomatico") + "Nomina.pdf")
        End If

        Dim fs As New FileStream(ConfigurationManager.AppSettings("RutaPagomatico") + "Nomina.pdf", FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim arrayHojasNomina() As String
        Dim dtEmps As DataTable
        Dim oNomina As New Nomina
        If IsPostBack = False Then
            GeneraPDF()
            dtEmps = oNomina.ObtenEmpsParaGenerarIndice(1995, 2, 55)
            arrayHojasNomina = SeparaPDFEnHojas(ConfigurationManager.AppSettings("RutaPagomatico") + "Nomina.pdf")
            If arrayHojasNomina.Length = 1 And arrayHojasNomina(0) = String.Empty Then
                'No hacemos nada
            Else
                'Generamos el índice

            End If
        End If
    End Sub
End Class
