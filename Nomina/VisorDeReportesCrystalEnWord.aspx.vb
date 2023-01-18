Imports Microsoft.Reporting.WebForms
Imports System.Collections.Generic
Imports System.IO
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Partial Class VisorDeReportesCrystalEnWord
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Response.Expires = 0

            'Dim rview As New ReportViewer
            'Dim mimeType As String = String.Empty
            'Dim encoding As String = String.Empty
            'Dim extension As String = String.Empty
            'Dim deviceInfo As String = String.Empty
            'Dim streamids As String() = Nothing
            'Dim warnings As Microsoft.Reporting.WebForms.Warning() = Nothing
            'Dim format As String = "PDF"
            ''Dim format As String = "EXCEL"
            'Dim paramList As New System.Collections.Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            'Dim bytes As Byte()
            'Dim dt As DataTable
            'Dim oReporte As New Reportes

            'If Request.Params("SubTipoReporte") Is Nothing Then
            '    dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")))
            'Else
            '    dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")), CByte(Request.Params("SubTipoReporte")))
            'End If

            'deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>"

            'For Each dr As DataRow In dt.Rows
            '    If Request.Params(dr("VariableAsociada")) Is Nothing = False And dr("VariableAsociada") <> String.Empty Then
            '        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter(dr("NombreParametro").ToString, Request.Params(dr("VariableAsociada").ToString)))
            '    End If
            'Next
            ''rview.ServerReport.ReportServerUrl = New Uri(dt.Rows(0).Item("URL").ToString)
            'rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ServerReportes"))
            'rview.ServerReport.ReportPath = "/Reportes/" + dt.Rows(0).Item("NombreReporte").ToString

            'rview.ServerReport.SetParameters(paramList)
            'bytes = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamids, warnings)

            ''Dim fs As FileStream = New FileStream("C:\MyXML.xml", FileMode.Create)
            ''fs.Write(bytes, 0, bytes.Length)
            ''fs.Close()

            ''Mostramos el reporte en formato PDF
            'Response.Clear()
            'Response.ContentType = "application/pdf"
            ''Response.ContentType = "application/vnd.ms-excel"
            'Response.AddHeader("Content-disposition", "filename=output.pdf")
            ''Response.AddHeader("Content-disposition", "filename=output.xls")
            'Response.OutputStream.Write(bytes, 0, bytes.Length)
            'Response.OutputStream.Flush()
            'Response.OutputStream.Close()
            'Response.Flush()
            'Response.Close()
            Dim oCR As New ReportDocument
            Dim RpDatos As New ParameterValues()
            Dim RpDatos2 As New ParameterValues()
            Dim pIdPlantel As New ParameterDiscreteValue()
            Dim pAnio As New ParameterDiscreteValue()
            Dim pFolio As New ParameterDiscreteValue()

            Select Case Request.Params("IdReporte")
                Case "CR01" 'CONSTANCIA LABORAL EN CRYSTAL REPORTS
                    oCR.Load(Server.MapPath("~/ReportesCrystal/ConstanciaLaboral.rpt"))

                    oCR.DataSourceConnections(0).SetConnection(ConfigurationManager.AppSettings("Server"), _
                                                               ConfigurationManager.AppSettings("BaseDeDatos"), _
                                                               ConfigurationManager.AppSettings("Usuario"), _
                                                               ConfigurationManager.AppSettings("Password"))

                    pIdPlantel.Value = Request.Params("IdPlantel")

                    RpDatos.Add(pIdPlantel)
                    oCR.DataDefinition.ParameterFields("@IdPlantel").ApplyCurrentValues(RpDatos)
                Case "CR02" 'CONSTANCIA LABORAL CON INGRESOS EN CRYSTAL REPORTS
                    oCR.Load(Server.MapPath("~/ReportesCrystal/ConstanciaLaboralConIngresos.rpt"))

                    oCR.DataSourceConnections(0).SetConnection(ConfigurationManager.AppSettings("Server"), _
                                                               ConfigurationManager.AppSettings("BaseDeDatos"), _
                                                               ConfigurationManager.AppSettings("Usuario"), _
                                                               ConfigurationManager.AppSettings("Password"))

                    pAnio.Value = Request.Params("Anio")
                    'RpDatos.Insert(0, pAnio)
                    RpDatos.Add(pAnio)
                    oCR.DataDefinition.ParameterFields("@Anio").ApplyCurrentValues(RpDatos)

                    pFolio.Value = Request.Params("Folio")
                    'RpDatos.Insert(1, pFolio)
                    RpDatos2.Add(pFolio)
                    oCR.DataDefinition.ParameterFields("@FolioConstancia").ApplyCurrentValues(RpDatos2)
            End Select
            oCR.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, True, "ConstanciaLaboral")
            'Word(oCR)
        End If
    End Sub

    'Private Sub Word(pCR As ReportDocument)
    '    Try
    '        Dim l_stream As New System.IO.MemoryStream
    '        l_stream = pCR.ExportToStream(ExportFormatType.WordForWindows)
    '        Response.ContentType = "application/vnd.ms-word"
    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.BinaryWrite(l_stream.ToArray())
    '        Response.End()

    '        'Dim b(l_stream.Length()) As Byte
    '        'l_stream.Read(b, 0, l_stream.Length())
    '        'Response.ClearContent()
    '        'Response.ClearHeaders()
    '        'Response.ContentType = "application/vnd.ms-word"
    '        'Response.BinaryWrite(b)
    '        'Response.Flush()
    '        'Response.Close()
    '    Catch ex As Exception
    '        Response.Write(ex.Message.ToString)
    '    End Try
    'End Sub
End Class