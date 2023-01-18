Imports System.Net.Mail
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Partial Class SolicitudEstPuntyAsist
    Inherits System.Web.UI.Page
    Private Shared Function ValidarCertificado(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        'bypass de la validación del certificado (aplicar aquí validación personalizada si fuera el caso)
        Return True
    End Function
    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click

        Dim oEmp As New Empleado
        Dim dt As DataTable = Nothing
        Dim strBody As String = ""

        dt = oEmp.ValidaDatos(txtbxNumEmp.Text.Trim, txtbxRFC.Text.Trim.ToUpper, txtbxEmail.Text.Trim.ToUpper)

        If dt.Rows.Count = 0 Then
            If chkbxEstPunt.Checked Then
                dt = oEmp.ValidaInfDeSolicitudDeEstDePuntyAsist(txtbxNumEmp.Text.Trim, txtbxRFC.Text.Trim.ToUpper, 1, 2015)
            End If

            If chkbxDiasEco.Checked Then
                If dt.Rows.Count = 0 Then
                    dt = oEmp.ValidaInfDeSolicitudDeDiasEcoNoDisf(txtbxNumEmp.Text.Trim, txtbxRFC.Text.Trim.ToUpper, 2015)
                Else
                    dt.Merge(oEmp.ValidaInfDeSolicitudDeDiasEcoNoDisf(txtbxNumEmp.Text.Trim, txtbxRFC.Text.Trim.ToUpper, 2015))
                End If
            End If
        End If


        If dt.Rows.Count = 0 Then

            Dim _Message As New MailMessage()
            Dim _SMTP As New SmtpClient
            Dim drEmp As DataRow
            Dim dtEmp As DataTable

            oEmp.RFC = txtbxRFC.Text.Trim.ToUpper
            dtEmp = oEmp.ObtenDatosPersonales
            If dtEmp.Rows.Count > 0 Then
                drEmp = dtEmp.Rows(0)
            Else
                drEmp = Nothing
            End If

            If drEmp Is Nothing = False And drEmp("Email").ToString <> String.Empty Then

                'Dim Random As New Random()
                'Dim vlClaveRegistroEmail As String = Random.Next(100000, 999999).ToString.PadLeft(10, "0")


                'CONFIGURACIÓN DEL STMP
                _SMTP.Credentials = New System.Net.NetworkCredential("nominasrh@cobaev.edu.mx", "Nominas??")
                _SMTP.Host = "smtp.office365.com"
                _SMTP.Port = 587
                _SMTP.EnableSsl = True
                ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidarCertificado)

                ' CONFIGURACION DEL MENSAJE
                _Message.[To].Add(drEmp("Email").ToString) 'Cuenta de Correo al que se le quiere enviar el e-mail
                _Message.From = New System.Net.Mail.MailAddress("nominasrh@cobaev.edu.mx", "Recursos Humanos (Control de Asistencia)", System.Text.Encoding.UTF8) 'Quien lo envía
                _Message.Subject = "COBAEV: Solicitud de pago de prestaciones..."  'Sujeto del e-mail
                _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion

                If chkbxEstPunt.Checked = True And chkbxDiasEco.Checked = False Then
                    strBody = "COLEGIO DE BACHILLERES DEL ESTADO DE VERACRUZ, " + vbCrLf +
                                "Su solicitud de pago de la 1ª Parte del Estímulo por Puntualidad y Asistencia 2015 " +
                                "ha sido registrada. " + vbCrLf +
                                "Ahora procederemos a evaluar su historial de incidencias con el fin de determinar si usted tiene " + vbCrLf +
                                "derecho o no al pago de la prestación solicitada." + vbCrLf +
                                "Gracias."
                End If
                If chkbxEstPunt.Checked = False And chkbxDiasEco.Checked = True Then
                    strBody = "COLEGIO DE BACHILLERES DEL ESTADO DE VERACRUZ, " + vbCrLf +
                                "Su solicitud de pago de Días Económicos No Disfrutados en el 2015 " +
                                "ha sido registrada. " + vbCrLf +
                                "Ahora procederemos a evaluar su historial de incidencias con el fin de determinar si usted tiene " + vbCrLf +
                                "derecho o no al pago de la prestación solicitada." + vbCrLf +
                                "Gracias."
                End If
                If chkbxEstPunt.Checked = True And chkbxDiasEco.Checked = True Then
                    strBody = "COLEGIO DE BACHILLERES DEL ESTADO DE VERACRUZ, " + vbCrLf +
                                "Su solicitud de pago tanto de la 1ª Parte del Estímulo por Puntualidad y Asistencia 2015 como de " + vbCrLf +
                                "Días Económicos No Disfrutados en el 2015  " +
                                "ha sido registrada. " + vbCrLf +
                                "Ahora procederemos a evaluar su historial de incidencias con el fin de determinar si usted tiene " + vbCrLf +
                                "derecho o no al pago de las prestaciones solicitadas." + vbCrLf +
                                "Gracias."
                End If
                _Message.Body = strBody
                _Message.BodyEncoding = System.Text.Encoding.UTF8
                _Message.Priority = System.Net.Mail.MailPriority.High
                _Message.IsBodyHtml = False
                '_Message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            End If
            'ENVIO

            Try
                If chkbxEstPunt.Checked Then oEmp.UpdInfDeSolicitudDeEstDePuntyAsist(txtbxRFC.Text.ToUpper, 1, 2015)
                If chkbxDiasEco.Checked Then oEmp.UpdInfDeSolicitudDeDiasEcoNoDisf(txtbxRFC.Text.ToUpper, 2015)

                If drEmp Is Nothing = False And drEmp("Email").ToString <> String.Empty Then
                    _SMTP.Send(_Message)
                    Label6.Text = "Su solicitud ha sido registrada con éxito, le hemos enviado un correo electrónico confirmando la misma."
                End If
                MultiView1.SetActiveView(View_Results)
            Catch ex As Exception ' System.Net.Mail.SmtpException
                lblErrores.Text = ex.ToString
                MultiView1.SetActiveView(View_Errores)
            End Try
        Else
            gvErrores.DataSource = dt
            gvErrores.DataBind()
            MultiView1.SetActiveView(View_Errores)
        End If
    End Sub
    Protected Sub btnReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles btnReintentarCaptura.Click
        MultiView1.SetActiveView(View_Captura)
    End Sub

    Protected Sub chkbxEstPunt_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxEstPunt.CheckedChanged
        btnGuardar.Enabled = chkbxEstPunt.Checked Or chkbxDiasEco.Checked
    End Sub

    Protected Sub chkbxDiasEco_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxDiasEco.CheckedChanged
        btnGuardar.Enabled = chkbxEstPunt.Checked Or chkbxDiasEco.Checked
    End Sub
End Class
