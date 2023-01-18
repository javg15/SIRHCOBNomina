Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.Threading
Imports log4net
Imports iTextSharp.text.pdf.parser
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports Microsoft.Reporting.WebForms
Imports System.Net.Mail
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Mime
Imports System.ComponentModel

Partial Class EnvioComprobantesDePago
    Inherits System.Web.UI.Page
    Private Shared _vgCarpeta As String
    Private Shared ReadOnly logger As ILog = LogManager.GetLogger("EmailUtils")

    Private Const InvalidEmailAddress As String = "User unknown"

    Private Shared Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        ' Get the unique identifier for this asynchronous operation.
        Dim _Message As New MailMessage()
        Dim _FileNameAttach As FileStream
        'Dim vlError As Boolean

        If e.Cancelled Then
            'Console.WriteLine("[{0}] Send canceled.", token)
            'vlError = True
        ElseIf e.Error IsNot Nothing Then
            'Console.WriteLine("[{0}] {1}", token, e.Error.ToString())
            'vlError = True
        Else
            Try
                _Message = CType(e.UserState, MailMessage)
                _FileNameAttach = CType(_Message.Attachments(0).ContentStream, FileStream)
                _Message.Dispose()
                File.Delete(_FileNameAttach.Name)
            Catch
                'vlError = True
            End Try
        End If
    End Sub

    Private Shared Function ValidarCertificado(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        'bypass de la validación del certificado (aplicar aquí validación personalizada si fuera el caso)
        Return True
    End Function

    Private Sub EnviaEmail(dr As DataRow, pCarpeta As String)
        Dim _Message As New MailMessage()
        Dim _SMTP As New SmtpClient
        Dim oNomina As New Nomina
        Dim drInfoCorreo As DataRow
        Dim strBody As String = String.Empty
        Dim strHTML As String = String.Empty
        Dim plainView As AlternateView
        Dim htmlView As AlternateView
        Dim imgHeader As LinkedResource
        Dim imgFooter As LinkedResource
        Dim userState As New MailMessage()
        Dim vlFile As String
        Dim mailStatus As String
        Dim message_ As String
        Dim intZonaGeografica As Int32
        Dim strZonaGeografica As String
        Dim strCorreoOficial As String
        Dim strToken As String

        'Dim vlError As Boolean

        _vgCarpeta = pCarpeta

        '_Message = New MailMessage()

        strToken = "EnvioRecibosPago99"
        If Me.ddlTiposDeImpresion.SelectedValue = "2" Then
            intZonaGeografica = ddlPlanteles_ZonasGeo.SelectedValue
            If intZonaGeografica < 9 Then
                strZonaGeografica = "0" & intZonaGeografica.ToString()
                strToken = strToken.Replace("99", strZonaGeografica)
            End If
        End If


        drInfoCorreo = oNomina.ObtenCorreosVarios(strToken)

        Dim _Attach As New Attachment(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + dr("NumEmp").ToString + "_" + dr("Quincena").ToString.Replace("-", "Adic") + ".pdf")
        '_Attach = New Attachment(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + dr("NumEmp").ToString + "_" + dr("Quincena").ToString.Replace("-", "Adic") + ".pdf")

        'strZonaGeografica = ""
        'strCorreoOficial = drInfoCorreo("EMAIL").ToString
        'If Me.ddlTiposDeImpresion.SelectedValue = "2" Then
        '    intZonaGeografica = ddlPlanteles_ZonasGeo.SelectedValue
        '    If intZonaGeografica < 9 Then
        '        strZonaGeografica = "0" & intZonaGeografica.ToString()
        '        strCorreoOficial = strCorreoOficial.Replace("99", strZonaGeografica)
        '    End If
        'End If

        'CONFIGURACIÓN DEL SMTP
        _SMTP.UseDefaultCredentials = False
        _SMTP.Credentials = New System.Net.NetworkCredential(drInfoCorreo("EMAIL").ToString, drInfoCorreo("CONTRASENIA").ToString)
        '_SMTP.Credentials = New System.Net.NetworkCredential(strCorreoOficial, drInfoCorreo("CONTRASENIA").ToString)
        '_SMTP.Host = "smtp.office365.com"
        '_SMTP.Port = 587
        _SMTP.Host = drInfoCorreo("SERVIDOR").ToString
        _SMTP.Port = drInfoCorreo("PUERTO").ToString
        _SMTP.EnableSsl = True


        ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidarCertificado)



        ' CONFIGURACION DEL MENSAJE
        _Message.[To].Add(dr("Email").ToString) 'Cuenta de Correo al que se le quiere enviar el e-mail
        '_Message.[To].Add("jcbarrales@cobaev.edu.mx") 'Cuenta de Correo al que se le quiere enviar el e-mail
        '_Message.Bcc.Add(drInfoCorreo("EMAIL").ToString)

        '_Message.Bcc.Add("rolofajr@gmail.com")
        _Message.From = New System.Net.Mail.MailAddress(drInfoCorreo("EMAIL").ToString, "Recursos Humanos (Nóminas)", System.Text.Encoding.UTF8) 'Quien lo envía
        '_Message.From = New System.Net.Mail.MailAddress("rolofajr@gmail.com", "Recursos Humanos (Nóminas)", System.Text.Encoding.UTF8) 'Quien lo envía
        _Message.Subject = "COBAEV: Comprobante de pago, quincena " + dr("Quincena").ToString + "..." 'Sujeto del e-mail
        _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion

        strBody =
            ConfigurationManager.AppSettings("NombreLargoEmpresa") + vbCrLf + vbCrLf +
            "Comprobate de pago de la quincena: " + dr("Quincena").ToString + vbCrLf + vbCrLf +
            dr("TipoPago") + vbCrLf + vbCrLf +
            "¡Importante! Su comprobante de pago está protegido con contraseña, " + vbCrLf +
            "así que para poder visualizarlo tendrá que teclearla al momento de " + vbCrLf +
            "intentar abrir el archivo PDF que lo contiene." + vbCrLf + vbCrLf +
            "Su contraseña siempre será su R.F.C. escrito en letras mayúsculas. (" + dr("RFCEmp").ToString + ")" + vbCrLf + vbCrLf +
            "El presente correo proviene de una dirección no supervisada, " + vbCrLf +
            "favor de no enviar correos a la misma porque no obtendrá respuesta alguna. Gracias."

        plainView = AlternateView.CreateAlternateViewFromString(strBody, Encoding.UTF8, MediaTypeNames.Text.Plain)

        '"            <asp:Image ID='Image8' runat='server' Height='125px' " + _
        '"                ImageUrl='~/Imagenes/HeaderDocsOficiales.jpg' Width='110px'/> " + _

        strHTML =
                "<table width='100%' cellpadding='0' cellspacing='0'> " +
                "    <tr> " +
                "        <td style='padding: 5px; border: thin solid #008000; text-align:center; width:110px;'> " +
                "        <img src='cid:imagenheader' style='height:125px; width:110px;  text-align:center;' /> " +
                "        </td> " +
                "        <td style='border-width: thin; border-color: #008000; padding: 5px; text-align:center; border-top-style: solid; border-right-style: solid; border-bottom-style: solid;'> " +
                "            <h1 style='text-align:center; color: #000000; font-size: 1.7em;'>COLEGIO DE BACHILLERES<br/>DEL ESTADO DE VERACRUZ</h1> " +
                "        </td> " +
                "    </tr> " +
                "    <tr> " +
                "        <td style='padding: 5px; border-width: thin; border-color: #008000; text-align: justify; color: #000000; font-size: 16px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid;' " +
                "            colspan='2'> " +
                "            Estimado(a) <span style='color: #0066FF'><strong>" + dr("NomEmp").ToString + "</strong></span>:<br/> " +
                "            <br/> " +
                "            Por medio del presente correo le hacemos llegar su comprobante de pago de la quincena " +
                "            <span style='color: #0066FF'><strong>" + dr("Quincena").ToString + ", " + dr("TipoPago").ToString +
                "            </strong></span><br/> " +
                "            <br/> " +
                "            <span style='color: #FF0000'><strong>¡Importante!</strong></span> Su  " +
                "            comprobante de pago está protegido con contraseña, así que para poder  " +
                "            visualizarlo tendrá que teclearla al momento de intentar abrir el archivo PDF  " +
                "            que lo contiene.<br/> " +
                "            <br/> " +
                "            <span style='color: #008000; text-decoration: underline'>Su contraseña siempre será su <strong>R.F.C.</strong> " +
                "            escrito en letras mayúsculas." + dr("RFCEmp").ToString + "</span><br/> " +
                "            <br/> " +
                "            <span style='color: #FF0000;  font-size: 14px;'>El presente correo proviene de una dirección no supervisada, favor de no enviar  " +
                "            correos a la misma porque no obtendrá respuesta alguna. Gracias.</span><br/> " +
                "        </td> " +
                "    </tr> " +
                "    <tr> " +
                "        <td colspan='2' " +
                "            style='padding: 5px; border-width: thin; border-color: #008000; text-align: left; border-right-style: solid; border-bottom-style: solid; border-left-style: solid;'> " +
                "        <img src='cid:imagenfooter' style='height:50px; width:450px;' /> " +
                "        </td> " +
                "    </tr> " +
                "</table> "

        htmlView = AlternateView.CreateAlternateViewFromString(strHTML, Encoding.UTF8, MediaTypeNames.Text.Html)

        imgHeader = New LinkedResource(ConfigurationManager.AppSettings("RutaImagenes") + "HeaderDocsOficiales.jpg", MediaTypeNames.Image.Jpeg)
        imgHeader.ContentId = "imagenHeader"

        htmlView.LinkedResources.Add(imgHeader)

        imgFooter = New LinkedResource(ConfigurationManager.AppSettings("RutaImagenes") + "FooterDocsOficiales1.jpg", MediaTypeNames.Image.Jpeg)
        imgFooter.ContentId = "imagenfooter"

        htmlView.LinkedResources.Add(imgFooter)

        _Message.AlternateViews.Add(plainView)
        _Message.AlternateViews.Add(htmlView)

        '_Message.Body = strBody
        _Message.BodyEncoding = System.Text.Encoding.UTF8
        _Message.Priority = System.Net.Mail.MailPriority.High
        _Message.Attachments.Add(_Attach)
        _Message.IsBodyHtml = False

        'ENVIO
        Try
            AddHandler _SMTP.SendCompleted, AddressOf SendCompletedCallback

            userState = _Message

            _SMTP.SendAsync(_Message, userState) ' pCarpeta + "," + dr("NumEmp").ToString + "," + dr("Quincena").ToString)

            '_SMTP.Send(_Message)

        Catch ex As Exception
            'vlError = True
            'Response.Write(ex.ToString)
        Finally
            '_Message.Dispose()
        End Try
    End Sub

    Private Shared Function HandleSmtpException(ByRef ex As SmtpException) As String
        logger.Error("SmptException occurred : " + ex.Message + " status code = " + ex.StatusCode.ToString)
        Return "PENDIENTE"
    End Function

    Private Shared Function HandleSmtpFailedRecipientsException(ByRef mail As MailMessage,
                ByRef client As SmtpClient,
                ByVal ex As SmtpFailedRecipientsException) As String
        logger.Error("SmtpFailedRecipientsException : " + ex.Message)
        Dim mailStatus As String = "ENVIADO" ' EmailNotificationStatus.SENT.ToString
        Try
            ' multiple fail
            mail.[To].Clear()
            Dim err As New StringBuilder("")
            For Each sfrEx As SmtpFailedRecipientException In ex.InnerExceptions
                CheckStatusAndReaddress(mail, sfrEx)
                err.Append(sfrEx.Message).Append(" ")
            Next
            If mail.[To].Count > 0 Then
                ' wait 5 seconds, try a second time
                Thread.Sleep(5000)
                client.Send(mail)
            End If
        Catch e As SmtpException
            logger.Error("SmtpException after retry " _
                    + e.Message + " statusCode = " + e.StatusCode.ToString)
            If Err.ToString.Contains(InvalidEmailAddress) Then
                mailStatus = "PARTIAL"
            Else
                mailStatus = "PENDIENTE"
            End If
        End Try
        Return mailStatus
    End Function
    ''' <summary>
    ''' Check for email exceptions and retry to send email to failed address only
    ''' </summary>
    ''' <param name="mail"></param>
    ''' <param name="exception"></param>
    ''' <remarks></remarks>
    Private Shared Sub CheckStatusAndReaddress(ByVal mail As MailMessage, ByVal exception As SmtpFailedRecipientException)
        Dim statusCode As SmtpStatusCode = exception.StatusCode
        If statusCode = SmtpStatusCode.MailboxBusy _
               OrElse statusCode = SmtpStatusCode.MailboxUnavailable _
               OrElse statusCode = SmtpStatusCode.TransactionFailed Then
            logger.Error("This user caused a FailedRecipient exception = " + exception.FailedRecipient + " statusCode = " + statusCode.ToString + " SmtpFailedRecipientException : " + exception.Message)
            mail.[To].Add(exception.FailedRecipient)
        End If
    End Sub

    Private Shared Function HandleSmtpFailedRecipientException(ByRef mail As MailMessage,
               ByRef client As SmtpClient,
               ByVal ex As SmtpFailedRecipientException) As String
        logger.Error("SmtpFailedRecipientException : " + ex.Message)
        Dim mailStatus As String = "ENVIADO" '= EmailNotificationStatus.SENT.ToString
        Try
            ' single fail
            mail.[To].Clear()
            CheckStatusAndReaddress(mail, ex)
            If mail.[To].Count > 0 Then
                ' wait 5 seconds, try a second time
                Thread.Sleep(5000)
                client.Send(mail)
            End If
        Catch e As SmtpException
            logger.Error("SmtpException after retry " _
                             + e.Message + " statusCode = " + e.StatusCode.ToString)
            If ex.Message.Contains(InvalidEmailAddress) Then
                mailStatus = "PARCIAL"
            Else
                mailStatus = "PENDIENTE"
            End If
        End Try
        Return mailStatus
    End Function

    Private Sub GeneraPDF(pIdQuincena As Short, pRFC As String, pNumEmp As String, pQuincena As String)
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
        'Dim dt As DataTable
        'Dim oReporte As New Reportes

        'If Request.Params("SubTipoReporte") Is Nothing Then
        '    dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")))
        'Else
        '    dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")), CByte(Request.Params("SubTipoReporte")))
        'End If

        deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>"

        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdFondoPresup", "0"))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdQuincena", pIdQuincena))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pRFCEmp", pRFC))

        rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ServerReportes"))
        rview.ServerReport.ReportPath = "/Reportes/ReciboNominaConImg"

        rview.ServerReport.SetParameters(paramList)
        bytes = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamids, warnings)

        If File.Exists(ConfigurationManager.AppSettings("RutaQuincenas") + pNumEmp + "_Qna" + pQuincena + ".pdf") Then
            File.Delete(ConfigurationManager.AppSettings("RutaQuincenas") + pNumEmp + "_Qna" + pQuincena + ".pdf")
        End If

        Dim fs As FileStream = New FileStream(ConfigurationManager.AppSettings("RutaQuincenas") + pNumEmp + "_Qna" + pQuincena + ".pdf", FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()
    End Sub

    Private Sub EliminaPDF(ByVal pCarpeta As String)
        'Eliminamos todos los archivos PDF
        'Dim arrayFiles() As String
        Dim File As String
        Dim FileInfo As FileInfo

        'arrayFiles = Directory.GetFiles(ConfigurationManager.AppSettings("RutaComprobantes"))

        For Each File In Directory.GetFiles(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta)
            FileInfo = New FileInfo(File)
            FileInfo.Delete()
        Next
    End Sub

    Private Sub validaEnvioTotalDeComprobantesPorQna(ByVal pCrear As Boolean)
        Timer1.Enabled = False

        Dim lblIdQuincena As Label = CType(gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Dim vlCarpeta As String = Nothing

        Select Case Me.ddlTiposDeImpresion.SelectedValue
            Case "0" 'Impresión general por fondo presupuestal
                vlCarpeta = "Recibos_Qna" + lblQuincena.Text.Replace("-", "Adic") + "_FP" + ddlTipoDeNomina.SelectedValue
            Case "1" 'Impresión de un plantel y fondo presupuestal
                vlCarpeta = "Recibos_Qna" + lblQuincena.Text.Replace("-", "Adic") + "_PL" + ddlPlanteles_ZonasGeo.SelectedValue + "_FP" + ddlTipoDeNomina.SelectedValue
            Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                vlCarpeta = "Recibos_Qna" + lblQuincena.Text.Replace("-", "Adic") + "_ZG" + ddlPlanteles_ZonasGeo.SelectedValue + "_FP" + ddlTipoDeNomina.SelectedValue
        End Select

        If Directory.Exists(ConfigurationManager.AppSettings("RutaComprobantes") + vlCarpeta) Then
            If Directory.GetFiles(ConfigurationManager.AppSettings("RutaComprobantes") + vlCarpeta).Length > 0 Then
                If pCrear Then
                    EliminaPDF(vlCarpeta)
                End If
            End If
        Else
            If pCrear Then
                Directory.CreateDirectory(ConfigurationManager.AppSettings("RutaComprobantes") + vlCarpeta)
            End If
        End If

        If pCrear Then
            GeneraArchivosPDF(vlCarpeta)
        End If

        If Directory.Exists(ConfigurationManager.AppSettings("RutaComprobantes") + vlCarpeta) Then
            If Directory.GetFiles(ConfigurationManager.AppSettings("RutaComprobantes") + vlCarpeta).Length > 0 Then

                Dim oNomina As New Nomina
                Dim drInfoCorreo As DataRow
                Dim strZonaGeografica As String
                Dim intZonaGeografica As Int32
                Dim strCorreoOficial As String
                Dim strToken As String


                'strZonaGeografica = ""
                'strCorreoOficial = drInfoCorreo("EMAIL").ToString
                'If Me.ddlTiposDeImpresion.SelectedValue = "2" Then
                '    intZonaGeografica = ddlPlanteles_ZonasGeo.SelectedValue
                '    If intZonaGeografica < 9 Then
                '        strZonaGeografica = "0" & intZonaGeografica.ToString()
                '        strCorreoOficial = strCorreoOficial.Replace("99", strZonaGeografica)
                '    End If
                'End If

                'drInfoCorreo = oNomina.ObtenCorreosVarios("EnvioRecibosPago")


                strToken = "EnvioRecibosPago99"
                If Me.ddlTiposDeImpresion.SelectedValue = "2" Then
                    intZonaGeografica = ddlPlanteles_ZonasGeo.SelectedValue
                    If intZonaGeografica < 9 Then
                        strZonaGeografica = "0" & intZonaGeografica.ToString()
                        strToken = strToken.Replace("99", strZonaGeografica)
                    End If
                End If


                drInfoCorreo = oNomina.ObtenCorreosVarios(strToken)


                ibEnviarEmail.ToolTip = "Enviar (" + Directory.GetFiles(ConfigurationManager.AppSettings("RutaComprobantes") + vlCarpeta).Length.ToString + ") comprobantes de pago por correo electrónico. " + drInfoCorreo("EMAIL").ToString
                ibEnviarEmail.Visible = True
            Else
                ibEnviarEmail.Visible = False
            End If
        Else
            ibEnviarEmail.Visible = False
        End If

    End Sub

    Private Sub GeneraArchivosPDF(ByVal pCarpeta As String) '(pIdQuincena As Short, pRFC As String, pNumEmp As String, pQuincena As String)
        Dim lblIdQuincena As Label = CType(gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvReportes.SelectedRow.FindControl("lblIdReporte"), Label)
        Dim vlSubTipoReporte As String = Nothing
        Dim vlFilePDF As String = Nothing

        Dim dtEmps As DataTable = Nothing
        Dim oNomina As New Nomina
        'Dim arrayHojasNomina() As String

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

        Select Case Me.ddlTiposDeImpresion.SelectedValue
            Case "0" 'Impresión general por fondo presupuestal
                vlSubTipoReporte = "0"
                vlFilePDF = "Recibos_Qna" + lblQuincena.Text.Replace("-", "Adic") + "_FP" + ddlTipoDeNomina.SelectedValue
                dtEmps = oNomina.ObtenEmpsParaEnvioDeComprobantesDePago(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), 0, 0, "", "")
            Case "1" 'Impresión de un plantel y fondo presupuestal
                vlSubTipoReporte = "1"
                vlFilePDF = "Recibos_Qna" + lblQuincena.Text.Replace("-", "Adic") + "_PL" + ddlPlanteles_ZonasGeo.SelectedValue + "_FP" + ddlTipoDeNomina.SelectedValue
                dtEmps = oNomina.ObtenEmpsParaEnvioDeComprobantesDePago(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), CShort(Me.ddlPlanteles_ZonasGeo.SelectedValue), 0, "", "")
            Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                vlSubTipoReporte = "2"
                vlFilePDF = "Recibos_Qna" + lblQuincena.Text.Replace("-", "Adic") + "_ZG" + ddlPlanteles_ZonasGeo.SelectedValue + "_FP" + ddlTipoDeNomina.SelectedValue
                dtEmps = oNomina.ObtenEmpsParaEnvioDeComprobantesDePago(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), 0, CShort(Me.ddlPlanteles_ZonasGeo.SelectedValue), "", "")
        End Select

        'If Request.Params("SubTipoReporte") Is Nothing Then
        If vlSubTipoReporte Is Nothing Then
            'dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")))
            dt = oReporte.ObtenInfParaImpresion(CShort(lblIdReporte.Text))
        Else
            dt = oReporte.ObtenInfParaImpresion(CShort(lblIdReporte.Text), CByte(vlSubTipoReporte))
        End If

        deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>"

        Select Case vlSubTipoReporte
            Case "0"
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdQuincena", CShort(lblIdQuincena.Text)))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdFondoPresup", ddlTipoDeNomina.SelectedValue))
            Case "1"
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdQuincena", CShort(lblIdQuincena.Text)))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdPlantel", CShort(ddlPlanteles_ZonasGeo.SelectedValue)))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdFondoPresup", ddlTipoDeNomina.SelectedValue))
            Case "2"
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdQuincena", CShort(lblIdQuincena.Text)))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdZonaGeografica", CShort(ddlPlanteles_ZonasGeo.SelectedValue)))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdFondoPresup", ddlTipoDeNomina.SelectedValue))
        End Select

        rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ServerReportes"))
        rview.ServerReport.ReportPath = ConfigurationManager.AppSettings("PathReportes") + dt.Rows(0).Item("NombreReporte").ToString
        'rview.ServerReport.ReportPath = "/Reportes/RecibosNomina"

        rview.ServerReport.SetParameters(paramList)
        bytes = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamids, warnings)

        'Dim vlDirs() As String
        'Dim vlFile As String

        Dim fs As New FileStream(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + vlFilePDF + ".pdf", FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()

        SeparaPDFEnHojas(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + vlFilePDF + ".pdf", dtEmps, lblQuincena.Text, pCarpeta)

        'Eliminamos el archivo pdf del cual generamos los recibos de pago

        If File.Exists(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + vlFilePDF + ".pdf") Then
            File.Delete(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + vlFilePDF + ".pdf")
        End If

        'vlDirs = Directory.GetFiles(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta, "*.pdf")
        'For Each vlFile In vlDirs
        '    If vlFile.Contains(vlFilePDF) Then File.Delete(vlFile)
        'Next
    End Sub

    Private Sub GeneraPDF(ByVal pIdReporte As Short, ByVal pIdQuincena As Short, ByVal pIdFondoPresup As Byte, ByVal pIdPlantel As Short)
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
            dt = oReporte.ObtenInfParaImpresion(pIdReporte)
        Else
            dt = oReporte.ObtenInfParaImpresion(pIdReporte, CByte(Request.Params("SubTipoReporte")))
        End If

        deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>"

        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdQuincena", pIdQuincena.ToString))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdFondoPresup", pIdFondoPresup.ToString))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pstrPlanteles", pIdPlantel.ToString))

        If Session("pFchImpRpt") Is Nothing = False Then
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pFchImpRpt", CDate(Session("pFchImpRpt"))))
        End If

        rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ServerReportes"))
        rview.ServerReport.ReportPath = "/Reportes/" + dt.Rows(0).Item("NombreReporte").ToString

        rview.ServerReport.SetParameters(paramList)
        bytes = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamids, warnings)

        Dim vlDirs() As String
        Dim vlFile As String

        vlDirs = Directory.GetFiles(ConfigurationManager.AppSettings("RutaPagomatico"), "*.pdf")
        For Each vlFile In vlDirs
            If vlFile.Contains("NomIndice_" + pIdPlantel.ToString) Then File.Delete(vlFile)
        Next

        Dim fs As New FileStream(ConfigurationManager.AppSettings("RutaPagomatico") + "NomIndice_" + _
                             pIdPlantel.ToString + "_" + pIdFondoPresup.ToString() + "_" + pIdQuincena.ToString + ".pdf", FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()
    End Sub

    Public Sub SeparaPDFEnHojas(ByVal pNombreArchivo As String, ByVal dtEmps As DataTable, ByVal pQuincena As String, ByVal pCarpeta As String)

        Dim vlPagina As Integer
        Dim vlPDFReader As PdfReader = Nothing
        Dim vlImportedPage As PdfImportedPage = Nothing
        Dim vlPDFCopyProvider As PdfCopy = Nothing
        Dim vlSourceDocument As Document = Nothing

        If (File.Exists(pNombreArchivo)) Then
            vlPDFReader = New PdfReader(pNombreArchivo)

            For vlPagina = 1 To vlPDFReader.NumberOfPages Step 1
                vlSourceDocument = New Document(vlPDFReader.GetPageSizeWithRotation(1))
                vlPDFCopyProvider = New PdfCopy(vlSourceDocument, New System.IO.FileStream(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + dtEmps.Rows(vlPagina - 1).Item("NumEmp").ToString + "_" + pQuincena.Replace("-", "Adic") + ".pdf", System.IO.FileMode.Create))
                vlImportedPage = vlPDFCopyProvider.GetImportedPage(vlPDFReader, vlPagina)
                vlSourceDocument.Open()
                vlPDFCopyProvider.AddPage(vlImportedPage)
                vlSourceDocument.Close()

                'Agregar password
                Dim USER As Byte() = Encoding.ASCII.GetBytes(dtEmps.Rows(vlPagina - 1).Item("RFCEmp").ToString)
                Dim OWNER As Byte() = Encoding.ASCII.GetBytes(dtEmps.Rows(vlPagina - 1).Item("RFCEmp").ToString)
                Dim reader As PdfReader = New PdfReader(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + dtEmps.Rows(vlPagina - 1).Item("NumEmp").ToString + "_" + pQuincena.Replace("-", "Adic") + ".pdf")
                Dim stamper As PdfStamper = New PdfStamper(reader, New FileStream(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + dtEmps.Rows(vlPagina - 1).Item("NumEmp").ToString + "_" + pQuincena.Replace("-", "Adic") + "_2.pdf", FileMode.Create))
                stamper.SetEncryption(USER, OWNER, PdfWriter.AllowPrinting, PdfWriter.ENCRYPTION_AES_128)
                stamper.Close()
                reader.Close()

                File.Delete(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + dtEmps.Rows(vlPagina - 1).Item("NumEmp").ToString + "_" + pQuincena.Replace("-", "Adic") + ".pdf")
                File.Move(ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + dtEmps.Rows(vlPagina - 1).Item("NumEmp").ToString + "_" + pQuincena.Replace("-", "Adic") + "_2.pdf",
                        ConfigurationManager.AppSettings("RutaComprobantes") + pCarpeta + "\" + dtEmps.Rows(vlPagina - 1).Item("NumEmp").ToString + "_" + pQuincena.Replace("-", "Adic") + ".pdf")

            Next vlPagina

            vlPDFReader.Close()
        End If
    End Sub

    Private Sub BindgvReportes()
        Dim oAplic As New Aplicacion
        Dim drPagina As DataRow
        Dim oReporte As New Reportes

        Dim oUsr As New Usuario
        Dim dr As DataRow

        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        drPagina = oAplic.ObtenInfSobrePagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString)
        Me.gvReportes.DataSource = oReporte.ObtenPorPagina(CShort(drPagina("IdPagina")), CByte(dr("IdRol")))
        Me.gvReportes.DataBind()

        If gvReportes.Rows.Count > 0 Then
            gvReportes.SelectedIndex = 0
        Else
            gvReportes.EmptyDataText = "Usuario sin permisos para utilizar los reportes disponibles en esta página."
            Me.gvReportes.DataBind()
        End If

    End Sub

    Private Sub BindddlAños()
        Dim oQna As New Quincenas
        With Me.ddlAños
            .DataSource = oQna.ObtenAños(True)
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
                Me.btnConsultarQuincenas.Enabled = False
            Else
                Me.btnConsultarQuincenas.Enabled = True
            End If
        End With
    End Sub

    Private Sub BindddlMeses()
        Dim oQna As New Quincenas
        With Me.ddlMeses
            .DataSource = oQna.ObtenMesesCalculadosPorAnio(CShort(Me.ddlAños.SelectedValue))
            .DataTextField = "NombreMes"
            .DataValueField = "IdMes"
            .DataBind()
        End With
    End Sub

    Private Sub BindQuincenas()
        Dim oQna As New Quincenas
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue), True, True)
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0
        End If
    End Sub

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub

    Private Sub BindddlPlanteles_ZonasGeo(Optional ByVal pCargando As Boolean = False)
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Me.ddlPlanteles_ZonasGeo.Enabled = True
        Select Case Me.ddlTiposDeImpresion.SelectedValue
            Case "1"  'Planteles
                Me.pnlPlanteles_ZonasGeo.GroupingText = "Seleccione plantel"
                Me.pnlPlanteles_ZonasGeo.Visible = True
                Dim oPlantel As New Plantel
                If pCargando = True Then
                    LlenaDDL(Me.ddlPlanteles_ZonasGeo, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorUsr(Session("Login")))
                    LlenaDDL(Me.ddlPlantelesPensionAlimenticia, "DescPlantel", "IdPlantel", oPlantel.ObtenParaImpDePensionAlimPorUsr(Session("Login"), CShort(lblIdQuincena.Text)))
                    If Me.ddlPlantelesPensionAlimenticia.Items.Count = 0 Then
                        Me.ddlPlantelesPensionAlimenticia.Items.Add(New WebControls.ListItem("No hay planteles con pensión alimenticia en la quincena seleccionada", "-1"))
                    End If
                End If
            Case "2" 'Zonas geográficas
                Me.pnlPlanteles_ZonasGeo.GroupingText = "Seleccione zona geográfica"
                Me.pnlPlanteles_ZonasGeo.Visible = True
                Dim oZonaGeo As New Zonageografica
                If pCargando = True Then
                    LlenaDDL(Me.ddlPlanteles_ZonasGeo, "NombreZonaGeografica", "IdZonaGeografica", oZonaGeo.ObtenPorUsuario(Session("Login")))
                    If Me.ddlPlanteles_ZonasGeo.Items.Count = 0 Then
                        Me.ddlPlanteles_ZonasGeo.Items.Add(New WebControls.ListItem("No hay zonas geográficas disponibles para el usuario.", "0"))
                    End If
                End If
            Case Else
                Me.pnlPlanteles_ZonasGeo.Visible = False
        End Select
    End Sub

    Private Sub BindddlTipoDeNomina()
        Dim oQna As New Nomina
        LlenaDDL(Me.ddlTipoDeNomina, "DescFondoPresup", "IdFondoPresup", oQna.GetFondosPresupuestales())
    End Sub

    Private Sub CreaLinkParaImpresion2(ByVal gvr As GridViewRow)
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        'Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)
        'Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)

        Select Case lblIdReporte.Text
            Case "1" 'Institucional de percepciones y deducciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaInstitucional_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "3" 'Nómina
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0"
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Nomina_Gral_" + lblIdQuincena.Text + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Planteles
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&strPlanteles=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Nomina_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Zonas geográficas
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','" + "Nomina_ZG_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "9" 'Nómina pensión alimenticia
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPAGral_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Planteles
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPA_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlantelesPensionAlimenticia.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPAG_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "10" 'Recibos de nómina
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaGral_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Impresión de un plantel y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPlantel_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaZG_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "11" 'Recibos de nómina de pensión alimenticia
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "1" 'Planteles
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue(
                                    +"&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPA_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlantelesPensionAlimenticia.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;")
                End Select
            Case "12" 'Institucional, todos los planteles
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalTP_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "14" 'Institucional, todos los planteles de una zona geográfica
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalZG_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "13" 'Institucional, un solo plantel
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalPlantel_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "19" 'Conciliaciones
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'General
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_Gral_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                    Case "1" 'Plantel
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_Pl_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"

                    Case "2" 'Zona geográfica
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_ZG_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"

                End Select
            Case "21" 'Concentrado de Conciliaciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','ConcentradoConciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "22" 'Resúmen de Conciliaciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','ResumenConciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "24"
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                                + "&IdMes=" + Me.ddlMeses.SelectedValue _
                                + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNomina_" + Me.ddlAños.SelectedItem.Text + "_" + Me.ddlMeses.SelectedValue + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "25"
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdMes=" + Me.ddlMeses.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNomina_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "29" 'Institucional, Recibos
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalRecibos_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "30" 'Institucional, devoluciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalDevoluciones_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "94" 'Provisión del 2% a la nómina, anual
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNominaAnual_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "95" 'Recibos de nómina con formato
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaGralFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Impresión de un plantel y fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPlantelFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaZGFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "121" 'Recibos de nómina con formato para envío de comprobantes de nómina
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaGralFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Impresión de un plantel y fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPlantelFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaZGFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "99" 'Nómina, para generar índice
                'Dim dtEmps As DataTable
                'Dim oNomina As New Nomina
                'Dim arrayHojasNomina() As String
                'dtEmps = oNomina.ObtenEmpsParaGenerarIndice(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), CShort(Me.ddlPlanteles_ZonasGeo.SelectedValue))
                'GeneraPDF(3, CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), CShort(Me.ddlPlanteles_ZonasGeo.SelectedValue))
                ''arrayHojasNomina = SeparaPDFEnHojas(ConfigurationManager.AppSettings("RutaPagomatico") + "NomIndice_" + _
                ''                         Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "_" + _
                ''                         lblIdQuincena.Text + ".pdf")

                'For Each drEmp As DataRow In dtEmps.Rows
                '    For Hoja As Short = 0 To arrayHojasNomina.Length - 1
                '        If arrayHojasNomina(Hoja).Contains(drEmp("RFCEmp")) Then
                '            oNomina.InsertaEnNominaIndice(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), Hoja + 1, CInt(drEmp("IdEmp")))
                '            Exit For
                '        End If
                '    Next
                'Next

                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaIndice_Pl_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "Qna_" + lblIdQuincena.Text.Replace("-", "_") + "_FP_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"

            Case "101" 'Nómina quincenal desglosada en Estatal y Federal (Cheques)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','NomQnalDesgEnEstyFed_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "104"
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                                + "&IdMes=" + Me.ddlMeses.SelectedValue _
                                + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNomina_" + Me.ddlAños.SelectedItem.Text + "_" + Me.ddlMeses.SelectedValue + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "105"
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdMes=" + Me.ddlMeses.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNomina_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "106" 'Provisión del 3% a la nómina, anual
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNominaAnual_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
        End Select
    End Sub

    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow, Optional ByVal pFchImpRpt As String = "")

        If gvr Is Nothing Then Exit Sub

        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblExportarAPDF As Label = CType(gvr.FindControl("lblExportarAPDF"), Label)
        Dim lblImplicaQuincenas As Label = CType(gvr.FindControl("lblImplicaQuincenas"), Label)
        Dim lblImplicaFondoPresup As Label = CType(gvr.FindControl("lblImplicaFondoPresup"), Label)
        Dim lblImplicaPlantel As Label = CType(gvr.FindControl("lblImplicaPlantel"), Label)
        'Dim strOnClientClick As String = String.Empty

        Me.pnlMeses.Enabled = CType(lblImplicaMeses.Text, Boolean)
        Me.ibImprimir.Visible = CType(lblExportarAPDF.Text, Boolean)
        Me.ibExportarExcel.Visible = CType(lblExportarAExcel.Text, Boolean)
        If CType(lblExportarAExcel.Text, Boolean) Then
            CreaLinkParaImpresion2(gvr)
        End If
        Me.lblMsj.Enabled = CType(lblImplicaQuincenas.Text, Boolean)
        Me.gvQuincenas.Enabled = CType(lblImplicaQuincenas.Text, Boolean)
        Me.pnlTipoDeNomina.Enabled = CType(lblImplicaFondoPresup.Text, Boolean)
        Me.pnlOpcDeImpresion.Enabled = CType(lblImplicaPlantel.Text, Boolean)
        Me.pnlPlanteles_ZonasGeo.Enabled = CType(lblImplicaPlantel.Text, Boolean)

        'Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx"
        'Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx"

        'If CType(lblImplicaQuincenas.Text, Boolean) Then
        '    strOnClientClick = "?IdQuincena=" + lblIdQuincena.Text
        'End If

        Me.ddlPlanteles_ZonasGeo.Visible = True
        Me.ddlPlantelesPensionAlimenticia.Visible = False
        Select Case lblIdReporte.Text
            Case "1" 'Institucional de percepciones y deducciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaInstitucional_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "3" 'Nómina
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0"
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Nomina_Gral_" + lblIdQuincena.Text + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Planteles
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&strPlanteles=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Nomina_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Zonas geográficas
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','" + "Nomina_ZG_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "9" 'Nómina pensión alimenticia
                Me.ibImprimir.Visible = Me.ddlPlantelesPensionAlimenticia.SelectedValue <> "-1" And CType(lblExportarAPDF.Text, Boolean)
                Me.ibExportarExcel.Visible = Me.ddlPlantelesPensionAlimenticia.SelectedValue <> "-1" And CType(lblExportarAExcel.Text, Boolean)
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por quincena
                        Me.ddlPlanteles_ZonasGeo.Visible = False
                        Me.ddlPlantelesPensionAlimenticia.Visible = False
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPAGral_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Planteles
                        Me.ddlPlanteles_ZonasGeo.Visible = False
                        Me.ddlPlantelesPensionAlimenticia.Visible = True
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPA_" + lblIdQuincena.Text.Replace("-", "_") + "_Pl_" + Me.ddlPlantelesPensionAlimenticia.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica
                        Me.ddlPlanteles_ZonasGeo.Visible = True
                        Me.ddlPlantelesPensionAlimenticia.Visible = False
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPA_" + lblIdQuincena.Text.Replace("-", "_") + "_ZG_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "10" 'Recibos de nómina
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaGral_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Impresión de un plantel y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPlantel_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaZG_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "11" 'Recibos de nómina de pensión alimenticia
                Me.ddlPlanteles_ZonasGeo.Visible = False
                Me.ddlPlantelesPensionAlimenticia.Visible = True
                Me.ibImprimir.Visible = Me.ddlPlantelesPensionAlimenticia.SelectedValue <> "-1" And CType(lblExportarAPDF.Text, Boolean)
                Me.ibExportarExcel.Visible = Me.ddlPlantelesPensionAlimenticia.SelectedValue <> "-1" And CType(lblExportarAExcel.Text, Boolean)
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "1" 'Planteles
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPA_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlantelesPensionAlimenticia.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "12" 'Institucional, todos los planteles
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalTP_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "14" 'Institucional, todos los planteles de una zona geográfica
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalZG_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "13" 'Institucional, un solo plantel
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalPlantel_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "19" 'Conciliaciones
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'General
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_Gral_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                    Case "1" 'Plantel
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_Pl_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"

                    Case "2" 'Zona geográfica
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_ZG_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"

                End Select
                'Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                '            + "?IdQuincena=" + lblIdQuincena.Text _
                '            + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                '            + "&IdReporte=" + lblIdReporte.Text + "','Conciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
            Case "21" 'Concentrado de Conciliaciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','ConcentradoConciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "22" 'Resúmen de Conciliaciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','ResumenConciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "24" 'Provisión del 2% a la nómina, quincenal
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                                + "&IdMes=" + Me.ddlMeses.SelectedValue _
                                + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNomina_" + Me.ddlAños.SelectedItem.Text + "_" + Me.ddlMeses.SelectedValue + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "25" 'Provisión del 2% a la nómina, quincenal
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdMes=" + Me.ddlMeses.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNomina_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "29" 'Institucional, Recibos
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalRecibos_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "30" 'Institucional, devoluciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalDevoluciones_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "94" 'Provisión del 2% a la nómina, anual
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNominaAnual_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "95" 'Recibos de nómina con formato
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaGralFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Impresión de un plantel y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPlantelFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaZGFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "121" 'Recibos de nómina con formato para envío de comprobantes de nómina
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaGralFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Impresión de un plantel y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPlantelFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaZGFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "99" 'Nómina, para generar índice
                'Dim dtEmps As DataTable
                'Dim oNomina As New Nomina
                'Dim arrayHojasNomina() As String
                'dtEmps = oNomina.ObtenEmpsParaGenerarIndice(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), CShort(Me.ddlPlanteles_ZonasGeo.SelectedValue))
                'GeneraPDF(3, CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), CShort(Me.ddlPlanteles_ZonasGeo.SelectedValue))
                'arrayHojasNomina = SeparaPDFEnHojas(ConfigurationManager.AppSettings("RutaPagomatico") + "NomIndice_" + _
                '                         Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "_" + _
                '                         lblIdQuincena.Text + ".pdf")

                'For Each drEmp As DataRow In dtEmps.Rows
                '    For Hoja As Short = 0 To arrayHojasNomina.Length - 1
                '        If arrayHojasNomina(Hoja).Contains(drEmp("RFCEmp")) Then
                '            oNomina.InsertaEnNominaIndice(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), Hoja + 1, CInt(drEmp("IdEmp")))
                '            Exit For
                '        End If
                '    Next
                'Next

                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaIndice_Pl_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "Qna_" + lblIdQuincena.Text.Replace("-", "_") + "_FP_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "101" 'Nómina quincenal desglosada en Estatal y Federal (Cheques)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','NomQnalDesgEnEstyFed_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "104" 'Provisión del 3% a la nómina, quincenal
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                                + "&IdMes=" + Me.ddlMeses.SelectedValue _
                                + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNomina_" + Me.ddlAños.SelectedItem.Text + "_" + Me.ddlMeses.SelectedValue + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "105" 'Provisión del 3% a la nómina, quincenal
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdMes=" + Me.ddlMeses.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNomina_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "106" 'Provisión del 3% a la nómina, anual
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNominaAnual_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
        End Select
    End Sub

    Protected Sub gvQuincenas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvQuincenas.RowCommand

    End Sub

    Protected Sub gvQuincenas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuincenas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvQuincenas, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindddlMeses()
                BindQuincenas()
                BindddlPlanteles_ZonasGeo(True)
                BindddlTipoDeNomina()
                BindgvReportes()
                validaEnvioTotalDeComprobantesPorQna(False)
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        BindddlMeses()
        BindQuincenas()

    End Sub

    Protected Sub ddlTiposDeImpresion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTiposDeImpresion.SelectedIndexChanged
        BindddlPlanteles_ZonasGeo(True)

        validaEnvioTotalDeComprobantesPorQna(False)

    End Sub

    Protected Sub ddlTipoDeNomina_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoDeNomina.SelectedIndexChanged
        validaEnvioTotalDeComprobantesPorQna(False)
    End Sub

    Protected Sub ddlPlanteles_ZonasGeo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPlanteles_ZonasGeo.SelectedIndexChanged, ddlPlantelesPensionAlimenticia.SelectedIndexChanged
        validaEnvioTotalDeComprobantesPorQna(False)
    End Sub

    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvQuincenas.SelectedIndexChanged
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim oPlantel As New Plantel
        LlenaDDL(Me.ddlPlantelesPensionAlimenticia, "DescPlantel", "IdPlantel", oPlantel.ObtenParaImpDePensionAlimPorUsr(Session("Login"), CShort(lblIdQuincena.Text)))
        If Me.ddlPlantelesPensionAlimenticia.Items.Count = 0 Then
            Me.ddlPlantelesPensionAlimenticia.Items.Add(New WebControls.ListItem("No hay planteles con pensión alimenticia en la quincena seleccionada", "-1"))
        End If

        validaEnvioTotalDeComprobantesPorQna(False)
    End Sub

    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReportes.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        Dim oUsr As New Usuario
        Dim oReporte As New Reportes
        Dim drReporte As DataRow
        Dim itemSel As String

        Dim vlIdReporte As Short = CShort(CType(gvr.FindControl("lblIdReporte"), Label).Text)

        If oUsr.EsAdministrador(Session("Login")) Or oUsr.EsVIP(Session("Login")) Then
            drReporte = oReporte.ObtenOpcionesVarias(vlIdReporte)
            pnlFchImpRpt.Visible = CBool(drReporte("PedirFechaDeImp"))

            Session.Remove("pFchImpRpt")
            txtbxFchImpRpt.Text = String.Empty
        End If

        itemSel = Me.ddlTiposDeImpresion.SelectedValue

        If CType(gvr.FindControl("lblIdReporte"), Label).Text = "3" Or CType(gvr.FindControl("lblIdReporte"), Label).Text = "9" _
                Or CType(gvr.FindControl("lblIdReporte"), Label).Text = "10" _
                Or CType(gvr.FindControl("lblIdReporte"), Label).Text = "95" _
                Or CType(gvr.FindControl("lblIdReporte"), Label).Text = "19" Then
            Me.ddlTiposDeImpresion.Items(0).Enabled = oUsr.EsAdministrador(Session("Login"))
            Me.ddlTiposDeImpresion.Items(2).Enabled = True
            If itemSel <> Me.ddlTiposDeImpresion.SelectedValue Then
                BindddlPlanteles_ZonasGeo(True)
            Else
                BindddlPlanteles_ZonasGeo()
            End If
        Else
            Me.ddlTiposDeImpresion.Items(0).Enabled = False
            Me.ddlTiposDeImpresion.Items(2).Enabled = False
            Me.ddlTiposDeImpresion.Items(0).Selected = False
            Me.ddlTiposDeImpresion.Items(2).Selected = False
            Me.ddlTiposDeImpresion.Items(1).Selected = True
            If itemSel <> Me.ddlTiposDeImpresion.SelectedValue Then
                BindddlPlanteles_ZonasGeo(True)
            Else
                BindddlPlanteles_ZonasGeo()
            End If
        End If

        'CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlMeses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged
        'Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        'CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub chbxPrioridadQna_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        'CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub txtbxFchImpRpt_TextChanged(sender As Object, e As System.EventArgs) Handles txtbxFchImpRpt.TextChanged
        If IsDate(txtbxFchImpRpt.Text.Trim) Then
            Session.Add("pFchImpRpt", txtbxFchImpRpt.Text)
        Else
            Session.Remove("pFchImpRpt")
        End If
    End Sub

    Protected Sub ibImprimir_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibImprimir.Click
        validaEnvioTotalDeComprobantesPorQna(True)
    End Sub

    Protected Sub ibEnviarEmail_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibEnviarEmail.Click
        Dim lblIdQuincena As Label = CType(gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvReportes.SelectedRow.FindControl("lblIdReporte"), Label)
        Dim vlFilePDF As String = Nothing
        Dim vlCarpeta As String = Nothing
        Dim File As String
        Dim FileInfo As FileInfo
        Dim vlNumEmp As String = Nothing
        Dim dt As DataTable
        Dim dr As DataRow

        Dim dtEmps As DataTable = Nothing
        Dim oNomina As New Nomina
        Select Case Me.ddlTiposDeImpresion.SelectedValue
            Case "0" 'Impresión general por fondo presupuestal
                vlFilePDF = "Recibos_Qna" + lblQuincena.Text.Replace("-", "Adic") + "_FP" + ddlTipoDeNomina.SelectedValue
            Case "1" 'Impresión de un plantel y fondo presupuestal
                vlFilePDF = "Recibos_Qna" + lblQuincena.Text.Replace("-", "Adic") + "_PL" + ddlPlanteles_ZonasGeo.SelectedValue + "_FP" + ddlTipoDeNomina.SelectedValue
            Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                vlFilePDF = "Recibos_Qna" + lblQuincena.Text.Replace("-", "Adic") + "_ZG" + ddlPlanteles_ZonasGeo.SelectedValue + "_FP" + ddlTipoDeNomina.SelectedValue
        End Select

        vlCarpeta = vlFilePDF
        _vgCarpeta = vlCarpeta

        Timer1.Enabled = True

        For Each File In Directory.GetFiles(ConfigurationManager.AppSettings("RutaComprobantes") + vlCarpeta)
            FileInfo = New FileInfo(File)
            vlNumEmp = Left(FileInfo.Name, 5)

            If IsNumeric(vlNumEmp) Then
                dt = oNomina.ObtenEmpsParaEnvioDeComprobantesDePago(lblIdQuincena.Text, 0, 0, 0, "", vlNumEmp)
                dr = dt.Rows(0)
                If dr("Email").ToString.Trim <> String.Empty Then
                    EnviaEmail(dr, vlCarpeta)
                End If
            End If

        Next

        'validaEnvioTotalDeComprobantesPorQna(False)

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        Dim oNomina As New Nomina
        Dim drInfoCorreo As DataRow
        Dim intZonaGeografica As Int32
        Dim strZonaGeografica As String
        Dim strToken As String

        strToken = "EnvioRecibosPago99"
        If Me.ddlTiposDeImpresion.SelectedValue = "2" Then
            intZonaGeografica = ddlPlanteles_ZonasGeo.SelectedValue
            If intZonaGeografica < 9 Then
                strZonaGeografica = "0" & intZonaGeografica.ToString()
                strToken = strToken.Replace("99", strZonaGeografica)
            End If
        End If


        drInfoCorreo = oNomina.ObtenCorreosVarios(strToken)
        'drInfoCorreo = oNomina.ObtenCorreosVarios("EnvioRecibosPago")

        If Directory.Exists(ConfigurationManager.AppSettings("RutaComprobantes") + _vgCarpeta) Then
            If Directory.GetFiles(ConfigurationManager.AppSettings("RutaComprobantes") + _vgCarpeta).Length > 0 Then
                ibEnviarEmail.ToolTip = "Enviar (" + Directory.GetFiles(ConfigurationManager.AppSettings("RutaComprobantes") + _vgCarpeta).Length.ToString + ") comprobantes de pago por correo electrónico, desde " + drInfoCorreo("EMAIL").ToString
                ibEnviarEmail.Visible = True
            Else
                Directory.Delete(ConfigurationManager.AppSettings("RutaComprobantes") + _vgCarpeta)
                ibEnviarEmail.Visible = False
                Timer1.Enabled = False
            End If
        Else
            ibEnviarEmail.Visible = False
            Timer1.Enabled = False
        End If
    End Sub
End Class