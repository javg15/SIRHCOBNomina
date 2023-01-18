Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Imports System.IO.Stream
Imports System.IO.StreamWriter
Imports Microsoft.Reporting.WebForms
Imports System.Net.Mail
 
Partial Class ABC_Nomina_RecibosNomina
    Inherits System.Web.UI.Page

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
    Private Sub BindQuincenas()
        Dim oQna As New Quincenas
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue))
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0
        Else
            Me.gvQuincenas.EmptyDataText = "No existen quincenas calculadas en el año " + ddlAños.SelectedValue
            Me.gvQuincenas.DataBind()
        End If
    End Sub
    Protected Sub gvQuincenas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuincenas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            mv_EnvioComprobantes.SetActiveView(view_Qnas)

            'Dim oPlantel As New Plantel
            BindddlAños()
            If ddlAños.SelectedValue <> -1 Then
                BindQuincenas()

                'Si ya existen archivos PDF de la quincena seleccionada en el gvQuincenas, habilitamos el control ibEnviarEmail
                Dim arrayFiles() As String
                Dim vlQuincena As String = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label).Text

                arrayFiles = Directory.GetFiles(ConfigurationManager.AppSettings("RutaQuincenas"), "*" + vlQuincena.Replace("-", "_") + ".pdf")

                ibEnviarEmail.Visible = arrayFiles.Length > 0
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        BindQuincenas()
        'Si ya existen archvivos PDF de la quincena seleccionada en el gvQuincenas, habilitamos el control ibEnviarEmail
        Dim arrayFiles() As String
        Dim vlQuincena As String = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label).Text

        arrayFiles = Directory.GetFiles(ConfigurationManager.AppSettings("RutaQuincenas"), "*" + vlQuincena.Replace("-", "_") + ".pdf")

        ibEnviarEmail.Visible = arrayFiles.Length > 0
    End Sub
    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvQuincenas.SelectedIndexChanged
        'Si ya existen archvivos PDF de la quincena seleccionada en el gvQuincenas, habilitamos el control ibEnviarEmail
        Dim arrayFiles() As String
        Dim vlQuincena As String = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label).Text

        arrayFiles = Directory.GetFiles(ConfigurationManager.AppSettings("RutaQuincenas"), "*" + vlQuincena.Replace("-", "_") + ".pdf")

        ibEnviarEmail.Visible = arrayFiles.Length > 0
    End Sub


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
        Dim dt As DataTable
        Dim oReporte As New Reportes

        If Request.Params("SubTipoReporte") Is Nothing Then
            dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")))
        Else
            dt = oReporte.ObtenInfParaImpresion(CShort(Request.Params("IdReporte")), CByte(Request.Params("SubTipoReporte")))
        End If

        deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>"

        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdFondoPresup", "0"))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdQuincena", pIdQuincena))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pRFCEmp", pRFC))

        rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ServerReportes"))
        rview.ServerReport.ReportPath = "/Reportes/RecibosNomina"

        rview.ServerReport.SetParameters(paramList)
        bytes = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamids, warnings)

        If File.Exists(ConfigurationManager.AppSettings("RutaQuincenas") + pNumEmp + "_Qna" + pQuincena + ".pdf") Then
            File.Delete(ConfigurationManager.AppSettings("RutaQuincenas") + pNumEmp + "_Qna" + pQuincena + ".pdf")
        End If

        Dim fs As FileStream = New FileStream(ConfigurationManager.AppSettings("RutaQuincenas") + pNumEmp + "_Qna" + pQuincena + ".pdf", FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()
    End Sub

    Protected Sub ibGeneraPDF_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibGeneraPDF.Click
        'Response.Redirect("RecibosNomina.aspx?pOperacion=Eliminando&pAnio=" + ddlAños.SelectedValue + "&pQnaSeleccionada=" + gvQuincenas.SelectedIndex.ToString)

        'Cuando vamos a generar los archivos PDF para enviar posteriormente por Email
        'primero eliminamos el contenido de la carpeta donde los guardaremos

        System.Threading.Thread.Sleep(5000)

        EliminaPDF()

        'Generamos los archivos PDf
        Dim oQna As New Quincenas
        Dim dt As DataTable
        Dim vlIdQuincena As Short = CShort(CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label).Text)

        dt = oQna.ObtenEmpsParaNotificacionDePagoViaEmail(vlIdQuincena)

        Threading.Thread.Sleep(5000)

        For Each dr In dt.Rows
            'GeneraPDF(vlIdQuincena, dr("RFCEmp"), dr("NumEmp"), dr("Quincena").ToString.Replace("-", "_"))
        Next

        ibEnviarEmail.Visible = True
    End Sub

    Private Sub EnviaEmail(dr As DataRow)
        Dim _Message As New MailMessage()
        Dim _SMTP As New SmtpClient
        Dim _Attach As New Attachment(ConfigurationManager.AppSettings("RutaQuincenas") + dr("NumEmp") + "_Qna" + dr("Quincena").ToString.Replace("-", "_") + ".pdf")

        'CONFIGURACIÓN DEL STMP
        _SMTP.Credentials = New System.Net.NetworkCredential("NominaCOBAEV@gmail.com", "NominaCOBAEV??")
        _SMTP.Host = "smtp.gmail.com"
        _SMTP.Port = 587
        _SMTP.EnableSsl = True

        ' CONFIGURACION DEL MENSAJE
        _Message.[To].Add(dr("Email").ToString) 'Cuenta de Correo al que se le quiere enviar el e-mail
        _Message.From = New System.Net.Mail.MailAddress("NominaCOBAEV@gmail.com", "COBAEV", System.Text.Encoding.UTF8) 'Quien lo envía
        _Message.Subject = "COBAEV: Notificación de pago de la quincena " + dr("Quincena").ToString + "..." 'Sujeto del e-mail
        _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
        _Message.Body = ConfigurationManager.AppSettings("NombreLargoEmpresa") + vbCrLf + vbCrLf + _
            "Notificación de pago de la quincena: " + dr("Quincena").ToString + vbCrLf + vbCrLf + _
            dr("TipoPago") 'contenido del mail
        _Message.BodyEncoding = System.Text.Encoding.UTF8
        _Message.Priority = System.Net.Mail.MailPriority.High
        _Message.Attachments.Add(_Attach)
        _Message.IsBodyHtml = False

        'ENVIO
        Try
            _SMTP.Send(_Message)
        Catch ex As System.Net.Mail.SmtpException
            Response.Write(ex.ToString)
        Finally
            _Attach.Dispose()
        End Try
    End Sub

    Protected Sub ibEnviarEmail_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibEnviarEmail.Click
        'Enviamos los PDF vía correo electrónico
        Dim oQna As New Quincenas
        Dim dt As DataTable
        Dim vlIdQuincena As Short = CShort(CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label).Text)

        dt = oQna.ObtenEmpsParaNotificacionDePagoViaEmail(vlIdQuincena)

        Threading.Thread.Sleep(5000)

        For Each dr In dt.Rows
            'EnviaEmail(dr)
        Next
    End Sub

    Private Sub EliminaPDF()
        'Eliminamos todos los archivos PDF
        Dim arrayFiles() As String
        Dim File As String
        Dim FileInfo As FileInfo

        arrayFiles = Directory.GetFiles(ConfigurationManager.AppSettings("RutaQuincenas"))

        For Each File In Directory.GetFiles(ConfigurationManager.AppSettings("RutaQuincenas"))
            FileInfo = New FileInfo(File)
            FileInfo.Delete()
        Next
    End Sub
End Class