Imports Microsoft.Reporting.WebForms
Imports System.Collections.Generic
Imports System.IO
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class VisorDeReportesWord
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim rview, rview2 As New ReportViewer
            Dim mimeType As String = String.Empty
            Dim encoding As String = String.Empty
            Dim extension As String = String.Empty
            Dim deviceInfo As String = String.Empty
            Dim streamids As String() = Nothing
            Dim warnings As Microsoft.Reporting.WebForms.Warning() = Nothing
            Dim format As String = "WORD"
            Dim paramList As New System.Collections.Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            Dim bytes As Byte()
            Dim dt As DataTable
            Dim oReporte As New Reportes

            dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")))

            deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>False</SimplePageHeaders>" + "</DeviceInfo>"

            For Each dr As DataRow In dt.Rows
                If Request.Params(dr("VariableAsociada")) Is Nothing = False Then
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter(dr("NombreParametro").ToString, Request.Params(dr("VariableAsociada").ToString)))
                End If
            Next
            'rview.ServerReport.ReportServerUrl = New Uri(dt.Rows(0).Item("URL").ToString)
            rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ServerReportes"))
            rview.ServerReport.ReportPath = ConfigurationManager.AppSettings("PathReportes") + dt.Rows(0).Item("NombreReporte").ToString

            rview.ServerReport.SetParameters(paramList)
            bytes = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamids, warnings)

            'Mostramos el reporte en formato WORD
            Response.Clear()
            Response.ContentType = "application/vnd.ms-word"
            Response.AddHeader("Content-disposition", "filename=output.doc")
            Response.OutputStream.Write(bytes, 0, bytes.Length)
            Response.OutputStream.Flush()
            Response.OutputStream.Close()
            Response.Flush()
            Response.Close()
        End If
    End Sub
End Class