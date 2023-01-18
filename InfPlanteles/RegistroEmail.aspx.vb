Imports System.Net.Mail
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Partial Class RegistroEmail
    Inherits System.Web.UI.Page

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim oEmp As New Empleado
        Dim dt As DataTable

        dt = oEmp.ValidaInfParaRegistroDeEmail(txtbxNumEmp.Text.Trim, txtbxRFC.Text.Trim.ToUpper, txtbxEmail.Text.Trim.ToUpper)

        If dt.Rows.Count = 0 Then

            Dim _Message As New MailMessage()
            Dim _SMTP As New SmtpClient
            Dim Random As New Random()
            Dim vlClaveRegistroEmail As String = Random.Next(100000, 999999).ToString.PadLeft(10, "0")

            'CONFIGURACIÓN DEL STMP
            _SMTP.Credentials = New System.Net.NetworkCredential("nominasrh@cobaev.edu.mx", "Nominas??")
            _SMTP.Host = "smtp.office365.com"
            _SMTP.Port = 587
            _SMTP.EnableSsl = True

            ' CONFIGURACION DEL MENSAJE
            _Message.[To].Add(txtbxEmail.Text.Trim.ToUpper) 'Cuenta de Correo al que se le quiere enviar el e-mail
            _Message.From = New System.Net.Mail.MailAddress("nominasrh@cobaev.edu.mx", "Recursos Humanos (Nóminas)", System.Text.Encoding.UTF8) 'Quien lo envía
            _Message.Subject = "COBAEV: Clave de registro de correo electrónico..."  'Sujeto del e-mail
            _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
            _Message.Body = ConfigurationManager.AppSettings("NombreLargoEmpresa") + ", " + vbCrLf +
                            "Clave de registro de correo electrónico: " + vlClaveRegistroEmail
            _Message.BodyEncoding = System.Text.Encoding.UTF8
            _Message.Priority = System.Net.Mail.MailPriority.High
            _Message.IsBodyHtml = False
            '_Message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure

            'ENVIO
            Try
                _SMTP.Send(_Message)
                oEmp.AddInfParaRegistroDeEmail(txtbxNumEmp.Text, txtbxRFC.Text.ToUpper, txtbxEmail.Text.ToUpper, vlClaveRegistroEmail)
                MultiView1.SetActiveView(View_Results)
            Catch ex As System.Net.Mail.SmtpException
                lblErrores.Text = ex.ToString
                MultiView1.SetActiveView(View_Errores)
            End Try
        Else
            gvErrores.DataSource = dt
            gvErrores.DataBind()
            MultiView1.SetActiveView(View_Errores)
        End If
    End Sub

    Protected Sub btnGuardar2_Click(sender As Object, e As System.EventArgs) Handles btnGuardar2.Click
        Dim oEmp As New Empleado

        Try
            If oEmp.ValidaCodigoRegistroEmail(txtbxRFC.Text.Trim.ToUpper, txtbxClaveViaEmail.Text.Trim) = True Then
                lblErrorClaveConfEmail.Visible = False
                oEmp.UpdInfParaRegistroDeEmail(txtbxNumEmp.Text, txtbxRFC.Text.ToUpper, txtbxEmail.Text.ToUpper, txtbxClaveViaEmail.Text, True)
                MultiView1.SetActiveView(View_FinProceso)
            Else
                lblErrorClaveConfEmail.Visible = True
            End If
        Catch ex As Exception
            lblErrores.Text = ex.ToString
            MultiView1.SetActiveView(View_Errores)
        End Try
    End Sub

    Protected Sub btnReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles btnReintentarCaptura.Click
        MultiView1.SetActiveView(View_Captura)
    End Sub
End Class
