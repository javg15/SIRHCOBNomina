Imports DataAccessLayer.COBAEV
Imports Microsoft.Reporting.WebForms
Imports System.Collections.Generic
Imports System.IO
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports iTextSharp.text.pdf.parser
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports log4net
Imports log4net.Config


Partial Class VisorDeReportes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Response.Expires = 0
            Dim rview As New ReportViewer
            Dim mimeType As String = String.Empty
            Dim encoding As String = String.Empty
            Dim extension As String = String.Empty
            Dim deviceInfo As String = String.Empty
            Dim streamids As String() = Nothing
            Dim warnings As Microsoft.Reporting.WebForms.Warning() = Nothing
            Dim format As String = "PDF"
            'Dim format As String = "EXCEL"
            Dim paramList As New System.Collections.Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            Dim bytes As Byte()
            Dim dt As DataTable
            Dim oReporte As New Reportes

            Dim drError As DataRow
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsErrores As DataSet
            dsErrores = _DataCOBAEV.setDataSetErrsCalculoNomina()
            'Dim vlThread As Thread

            If Request.Params("SubTipoReporte") Is Nothing Then
                dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")))
            Else
                dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")), CByte(Request.Params("SubTipoReporte")))
            End If

            deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>"

            For Each dr As DataRow In dt.Rows
                If Request.Params(dr("VariableAsociada")) Is Nothing = False And dr("VariableAsociada") <> String.Empty Then
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter(dr("NombreParametro").ToString, Request.Params(dr("VariableAsociada").ToString)))
                    'ElseIf dr("ValorDefault") <> String.Empty Then
                    '    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter(dr("NombreParametro").ToString, dr("ValorDefault").ToString))
                End If
            Next

            If Session("pFchImpRpt") Is Nothing = False Then
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pFchImpRpt", CDate(Session("pFchImpRpt"))))
            End If

            'rview.ServerReport.ReportServerUrl = New Uri(dt.Rows(0).Item("URL").ToString)
            rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ServerReportes"))
            rview.ServerReport.ReportPath = ConfigurationManager.AppSettings("PathReportes") + dt.Rows(0).Item("NombreReporte").ToString

            Try

                rview.ServerReport.SetParameters(paramList)
                'rview.ServerReport.Timeout = 3600
                'System.Threading.Thread.


                bytes = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamids, warnings)
            Catch ex As Exception
                drError = dsErrores.Tables(0).NewRow()
                drError(0) = "error"
                drError(1) = ex.Message
                dsErrores.Tables(0).Rows.Add(drError)
                Session("miTabla") = dsErrores.Tables(0)

            End Try
            'Mostramos el reporte en formato PDF
            Response.Clear()
            Response.ContentType = "application/pdf"
            'Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("Content-disposition", "filename=output.pdf")
            'Response.AddHeader("Content-disposition", "filename=output.xls")
            Response.OutputStream.Write(bytes, 0, bytes.Length)
            Response.OutputStream.Flush()
            Response.OutputStream.Close()
            Response.Flush()
            Response.Close()
        End If
    End Sub
End Class