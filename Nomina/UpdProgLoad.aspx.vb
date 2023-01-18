Imports System.Net.Mail
Imports System.Net
Imports System.Data
Imports Microsoft.Reporting.WebForms
Imports System.Collections.Generic
Imports System.IO
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Web.Services.Protocols
Imports RS2010

Partial Class UpdProgLoad
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles btnEnviarEmail.Click

        Dim oQna As New Quincenas
        Dim dt As DataTable
        Dim vlIdQuincena As Short = 1953

        dt = oQna.ObtenEmpsParaNotificacionDePagoViaEmail(vlIdQuincena)

        For Each dr In dt.Rows
            GeneraPDF(vlIdQuincena, dr("RFCEmp"))
            EnviaEmail(dr)
            EliminaPDF()
        Next
    End Sub
    Private Sub GeneraPDF(pIdQuincena As Short, pRFC As String)
        Response.Expires = 0
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
        'SubTipoReporte=3&IdQuincena=1962&RFCEmp=ROLF711025G92&IdFondoPresup=0&IdReporte=10

        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdFondoPresup", "0"))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdQuincena", pIdQuincena))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pRFCEmp", pRFC))

        'For Each dr As DataRow In dt.Rows
        '    If Request.Params(dr("VariableAsociada")) Is Nothing = False And dr("VariableAsociada") <> String.Empty Then
        '        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter(dr("NombreParametro").ToString, Request.Params(dr("VariableAsociada").ToString)))
        '    End If
        'Next
        rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ServerReportes"))
        rview.ServerReport.ReportPath = "/Reportes/RecibosNomina"

        rview.ServerReport.SetParameters(paramList)
        bytes = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamids, warnings)

        If File.Exists(ConfigurationManager.AppSettings("RutaQuincenas") + "Quincena.pdf") Then
            File.Delete(ConfigurationManager.AppSettings("RutaQuincenas") + "Quincena.pdf")
        End If

        Dim fs As FileStream = New FileStream(ConfigurationManager.AppSettings("RutaQuincenas") + "Quincena.pdf", FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()
    End Sub

    Private Sub EnviaEmail(dr As DataRow)
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim _Attach As New Attachment(ConfigurationManager.AppSettings("RutaQuincenas") + "Quincena.pdf")

        'CONFIGURACIÓN DEL STMP
        _SMTP.Credentials = New System.Net.NetworkCredential("rolofajr@gmail.com", "JoMaLiz??")
        _SMTP.Host = "smtp.gmail.com"
        _SMTP.Port = 587
        _SMTP.EnableSsl = True

        ' CONFIGURACION DEL MENSAJE
        _Message.[To].Add(dr("Email")) 'Cuenta de Correo al que se le quiere enviar el e-mail
        _Message.From = New System.Net.Mail.MailAddress("rolofajr@gmail.com", "COBAEV", System.Text.Encoding.UTF8) 'Quien lo envía
        _Message.Subject = "COBAEV: Notificación de pago de la quincena " + dr("Quincena") + "..." 'Sujeto del e-mail
        _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
        _Message.Body = ConfigurationManager.AppSettings("NombreLargoEmpresa") + vbCrLf + vbCrLf + _
            "Notificación de pago de la quincena: " + dr("Quincena") + vbCrLf + vbCrLf + _
            dr("TipoPago") 'contenido del mail
        _Message.BodyEncoding = System.Text.Encoding.UTF8
        _Message.Priority = System.Net.Mail.MailPriority.High
        _Message.Attachments.Add(_Attach)
        _Message.IsBodyHtml = False

        'ENVIO
        Try
            _SMTP.Send(_Message)
            _Attach.Dispose()
        Catch ex As System.Net.Mail.SmtpException
            Response.Write(ex.ToString)
            _Attach.Dispose()
        Finally
            _Attach.Dispose()
        End Try
    End Sub
    Private Sub EliminaPDF()
        If File.Exists(ConfigurationManager.AppSettings("RutaQuincenas") + "Quincena.pdf") Then
            File.Delete(ConfigurationManager.AppSettings("RutaQuincenas") + "Quincena.pdf")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            Dim rs As New ReportingService2010()
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials

            Dim report As String = "/Reportes/ReciboNominaConImg"
            Dim description As String = "Mi nueva data driven subscription"

            ' Set the extension setting as report server email.
            Dim settings As New ExtensionSettings()
            settings.Extension = "Report Server Email"

            ' Set the extension parameter values.
            Dim extensionParams(7) As ParameterValueOrFieldReference

            Dim [to] As New ParameterFieldReference() ' Data-driven.
            [to].ParameterName = "TO"
            [to].FieldAlias = "rolofa_jr@hotmail.com"
            extensionParams(0) = [to]

            Dim replyTo As New ParameterValue()
            replyTo.Name = "ReplyTo"
            replyTo.Value = ""
            extensionParams(1) = replyTo

            Dim includeReport As New ParameterValue()
            includeReport.Name = "IncludeReport"
            includeReport.Value = "False"
            extensionParams(2) = includeReport

            Dim renderFormat As New ParameterValue()
            renderFormat.Name = "RenderFormat"
            renderFormat.Value = "PDF"
            extensionParams(3) = renderFormat

            Dim priority As New ParameterValue()
            priority.Name = "Priority"
            priority.Value = "NORMAL"
            extensionParams(4) = priority

            Dim subject As New ParameterValue()
            subject.Name = "Subject"
            subject.Value = ConfigurationManager.AppSettings("NombreLargoEmpresa") + ", NOTIFICACIÓN DE PAGO DE NÓMINA..."
            extensionParams(5) = subject

            Dim comment As New ParameterValue()
            comment.Name = "Comment"
            comment.Value = ""
            extensionParams(6) = comment

            Dim includeLink As New ParameterValue()
            includeLink.Name = "IncludeLink"
            includeLink.Value = "False"
            extensionParams(7) = includeLink

            settings.ParameterValues = extensionParams

            ' Create the data source for the delivery query.
            Dim delivery As New DataSource()
            delivery.Name = ""
            Dim dataSourceDefinition As New DataSourceDefinition()
            dataSourceDefinition.ConnectString = ConfigurationManager.AppSettings("CadCnnBDNomina")
            dataSourceDefinition.CredentialRetrieval = CredentialRetrievalEnum.Store
            dataSourceDefinition.Enabled = True
            dataSourceDefinition.EnabledSpecified = True
            dataSourceDefinition.Extension = "SQL"
            dataSourceDefinition.ImpersonateUserSpecified = False
            'dataSourceDefinition.UserName = "username"
            'dataSourceDefinition.Password = "runUnAtt1"
            delivery.Item = dataSourceDefinition

            ' Create the fields list.
            Dim fieldsList(7) As Field
            fieldsList(0) = New Field()
            fieldsList(0).Name = "pIdPlantel"
            fieldsList(0).Alias = "pIdPlantel"
            fieldsList(1) = New Field()
            fieldsList(1).Name = "pIdQuincena"
            fieldsList(1).Alias = "pIdQuincena"
            fieldsList(2) = New Field()
            fieldsList(2).Name = "pIdFondoPresup"
            fieldsList(2).Alias = "pIdFondoPresup"
            fieldsList(3) = New Field()
            fieldsList(3).Name = "pIdZonaGeografica"
            fieldsList(3).Alias = "pIdZonaGeografica"
            fieldsList(4) = New Field()
            fieldsList(4).Name = "pRFCEmp"
            fieldsList(4).Alias = "pRFCEmp"
            fieldsList(5) = New Field()
            fieldsList(5).Name = "Email"
            fieldsList(5).Alias = "Email"
            fieldsList(6) = New Field()
            fieldsList(6).Name = "DescripcionRecibo"
            fieldsList(6).Alias = "DescripcionRecibo"
            fieldsList(7) = New Field()
            fieldsList(7).Name = "QuincenaPago"
            fieldsList(7).Alias = "QuincenaPago"

            ' Create the data set for the delivery query.
            Dim dataSetDefinition As New DataSetDefinition()

            dataSetDefinition.AccentSensitivitySpecified = False
            dataSetDefinition.CaseSensitivitySpecified = False
            dataSetDefinition.KanatypeSensitivitySpecified = False
            dataSetDefinition.WidthSensitivitySpecified = False
            dataSetDefinition.Fields = fieldsList
            Dim queryDefinition As New QueryDefinition()
            queryDefinition.CommandText = "Exec SP_SEmpsParaNotificacionDePagoViaEmail 1980"
            queryDefinition.CommandType = CommandType.StoredProcedure
            queryDefinition.Timeout = 45
            queryDefinition.TimeoutSpecified = True

            dataSetDefinition.Query = queryDefinition
            Dim results As New DataSetDefinition()
            'Dim changed As Boolean
            Dim paramNames As String() = Nothing

            'Try
            '    results = rs.PrepareQuery(delivery, dataSetDefinition, changed, paramNames)
            'Catch e As SoapException
            '    Console.WriteLine(e.Detail.InnerText.ToString())
            'End Try

            Dim dataRetrieval As New DataRetrievalPlan()
            dataRetrieval.DataSet = results
            dataRetrieval.Item = dataSourceDefinition

            ' Set the event type and match data for the delivery.
            Dim eventType As String = "TimedSubscription"
            Dim matchData As String = "<ScheduleDefinition><StartDateTime>2003-04-14T19:15:00-07:00</StartDateTime><WeeklyRecurrence><WeeksInterval>1</WeeksInterval><DaysOfWeek><Monday>True</Monday><Tuesday>True</Tuesday><Wednesday>True</Wednesday><Thursday>True</Thursday><Friday>True</Friday></DaysOfWeek></WeeklyRecurrence></ScheduleDefinition>"

            ' Set the report parameter values.
            Dim parameters(2) As ParameterValueOrFieldReference

            Dim empID As New ParameterFieldReference() ' Data-driven.
            empID.ParameterName = "EmpID"
            empID.FieldAlias = "EmpID"
            parameters(0) = empID

            Dim reportYear As New ParameterValue()
            reportYear.Name = "ReportYear"
            reportYear.Value = "2004"
            parameters(1) = reportYear

            Dim reportMonth As New ParameterValue()
            reportMonth.Name = "ReportMonth"
            reportMonth.Value = "6" ' June
            parameters(2) = reportMonth

            'Try
            '    Dim subscriptionID As String = rs.CreateDataDrivenSubscription(report, settings, dataRetrieval, description, eventType, matchData, parameters)
            'Catch e As SoapException
            '    Console.WriteLine(e.Detail.InnerText.ToString())
            'End Try
        End If
    End Sub
End Class


