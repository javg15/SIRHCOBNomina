Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Net.Mail
Imports System.IO
'Imports System.IO.Stream
'Imports System.IO.StreamWriter
Imports Microsoft.Reporting.WebForms
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Partial Class Consultas_Nomina_wfPagos
    Inherits System.Web.UI.Page
    Private Shared Function ValidarCertificado(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        'bypass de la validación del certificado (aplicar aquí validación personalizada si fuera el caso)
        Return True
    End Function
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
    Private Sub EnviaEmail(dr As DataRow)
        Dim _Message As New MailMessage()
        Dim _SMTP As New SmtpClient
        Dim oNomina As New Nomina
        Dim drInfoCorreo As DataRow

        drInfoCorreo = oNomina.ObtenCorreosVarios("EnvioRecibosPago")

        Dim _Attach As New Attachment(ConfigurationManager.AppSettings("RutaQuincenas") + dr("NumEmp") + "_Qna" + dr("Quincena").ToString.Replace("-", "_") + ".pdf")

        'CONFIGURACIÓN DEL STMP
        _SMTP.Credentials = New System.Net.NetworkCredential(drInfoCorreo("EMAIL").ToString, drInfoCorreo("CONTRASENIA").ToString)
        '_SMTP.Credentials = New System.Net.NetworkCredential("nominasrh@cobaev.edu.mx", "Americas24")
        '_SMTP.Credentials = New System.Net.NetworkCredential("rolofajr@gmail.com", "JoMaLiz??")
        '_SMTP.Host = "smtp.gmail.com"
        _SMTP.Host = "outlook.office365.com"
        _SMTP.Port = 587
        _SMTP.EnableSsl = True
        '_SMTP.DeliveryMethod = SmtpDeliveryMethod.Network

        'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidarCertificado)

        ' CONFIGURACION DEL MENSAJE
        _Message.[To].Add(dr("Email").ToString) 'Cuenta de Correo al que se le quiere enviar el e-mail
        _Message.Bcc.Add(drInfoCorreo("EMAIL").ToString)
        '_Message.Bcc.Add("rolofajr@gmail.com")
        _Message.From = New System.Net.Mail.MailAddress(drInfoCorreo("EMAIL").ToString, "Recursos Humanos (Nóminas)", System.Text.Encoding.UTF8) 'Quien lo envía
        '_Message.From = New System.Net.Mail.MailAddress("rolofajr@gmail.com", "Recursos Humanos (Nóminas)", System.Text.Encoding.UTF8) 'Quien lo envía
        _Message.Subject = "COBAEV: Notificación de pago de la quincena " + dr("Quincena").ToString + "..." 'Sujeto del e-mail
        _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
        _Message.Body = ConfigurationManager.AppSettings("NombreLargoEmpresa") + vbCrLf + vbCrLf + _
            "Notificación de pago de la quincena: " + dr("Quincena").ToString + vbCrLf + vbCrLf + _
            dr("TipoPago") + vbCrLf + vbCrLf + _
            "FAVOR DE CONFIRMAR LA RECEPCIÓN DE SU RECIBO DE PAGO. GRACIAS."
        _Message.BodyEncoding = System.Text.Encoding.UTF8
        _Message.Priority = System.Net.Mail.MailPriority.High
        _Message.Attachments.Add(_Attach)
        _Message.IsBodyHtml = False

        'ENVIO
        Try
            ' _SMTP.TargetName = "outlook.office365.com"
            _SMTP.Send(_Message)
        Catch ex As Exception
            Response.Write(ex.ToString)
        Finally
            _Attach.Dispose()
        End Try
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

    Private Sub BindDatos(Optional ByVal CargaAños As Boolean = True)
        Dim oUsr As New Usuario
        Dim dr As DataRow
        Dim oEmp As New Empleado
        Dim oQna As New Quincenas
        Dim RFCEmp As String
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        RFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        If CargaAños Then
            If RFCEmp = String.Empty Then
                Me.ddlAños.Items.Clear()
                Me.ddlAños.Items.Add(New ListItem("No existe información de pago", "-1"))
            Else
                With Me.ddlAños
                    .DataSource = oQna.ObtenAñosConPago(RFCEmp)
                    .DataTextField = "Anio"
                    .DataValueField = "Anio"
                    .DataBind()
                    If .Items.Count = 0 Then
                        Me.ddlAños.Items.Clear()
                        Me.ddlAños.Items.Add(New ListItem("No existe información de pago", "-1"))
                    End If
                End With
            End If
        End If
        If RFCEmp = String.Empty Or Me.ddlAños.SelectedValue = "-1" Then
            Me.ddlQnasPagadas.Items.Clear()
            Me.ddlQnasPagadas.Items.Add(New ListItem("No existe información de pago", "-1"))
        Else
            oUsr.Login = Session("Login")
            dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
            With Me.ddlQnasPagadas
                .DataSource = oQna.ObtenQnasPagadasPorEmp(RFCEmp, CShort(Me.ddlAños.SelectedValue), CBool(dr("VisibilidadDeQnasAdic")))
                .DataTextField = "Quincena"
                .DataValueField = "IdQuincena"
                .DataBind()
            End With
            If Me.ddlQnasPagadas.Items.Count = 0 Then
                Me.ddlQnasPagadas.Items.Clear()
                Me.ddlQnasPagadas.Items.Add(New ListItem("Información no disponible", "-1"))
            End If
        End If
        If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
            Me.lblRFCEmp.Text = Session("RFCParaCons")
            lblEmpInf.Text = "Información relacionada con el empleado: " + Me.lblRFCEmp.Text + ", " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            lblEmpInf.Visible = True
            Me.lblRFCEmp.Visible = True
        Else
            lblEmpInf.Text = String.Empty
            Me.lblRFCEmp.Text = String.Empty
            lblEmpInf.Visible = False
            Me.lblRFCEmp.Visible = False
        End If

        If Me.ddlQnasPagadas.Items.Count = 0 Or ddlQnasPagadas.SelectedValue = "-1" Then
            Me.btnConsultarPago.Enabled = False
            Me.LblInfDeQna.Visible = False
            Me.btnImprimirReciboPago.Enabled = False
            Me.btnPrintReciboPagoConImg.Enabled = False
            Me.btnSendEmail.Visible = False
        Else
            Me.btnConsultarPago.Enabled = ddlQnasPagadas.SelectedValue <> "-1"
            Me.LblInfDeQna.Text = "Detalles de pago de la quincena: " + Me.ddlQnasPagadas.SelectedItem.Text
            Me.LblInfDeQna.Visible = True
            Me.btnImprimirReciboPago.Enabled = ddlQnasPagadas.SelectedValue <> "-1"
            Me.btnPrintReciboPagoConImg.Enabled = ddlQnasPagadas.SelectedValue <> "-1"

            btnSendEmail.Visible = oUsr.EsAdministrador(Session("Login")) And oEmp.TieneEmail(hfRFC.Value) And hfRFC.Value <> String.Empty _
                            And ddlQnasPagadas.SelectedValue <> "-1"

            Me.btnImprimirReciboPago.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                        + "?SubTipoReporte=3" _
                        + "&IdQuincena=" + Me.ddlQnasPagadas.SelectedValue _
                        + "&RFCEmp=" + RFCEmp _
                        + "&IdFondoPresup=0" _
                        + "&IdReporte=10" + "','ReciboNominaEmp_" + Me.ddlQnasPagadas.SelectedValue + "_" + RFCEmp + "'); return false;"
            Me.btnPrintReciboPagoConImg.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                        + "?SubTipoReporte=3" _
                        + "&IdQuincena=" + Me.ddlQnasPagadas.SelectedValue _
                        + "&RFCEmp=" + RFCEmp _
                        + "&IdFondoPresup=0" _
                        + "&IdReporte=95" + "','ReciboNominaConImgEmp_" + Me.ddlQnasPagadas.SelectedValue + "_" + RFCEmp + "'); return false;"

        End If
        Me.pnlQuincenas.Visible = True

    End Sub
    Private Sub BindPago()
        Try
            Dim oEmp As New Empleado
            Dim dsEmpPago As DataSet
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim dt As DataTable
            Dim oNomina As New Devolucion
            Dim oNomina2 As New Recibos
            Dim oQnaPagadaComoAdeudo As New Adeudo
            Dim RFCEmp As String = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

            If Me.ddlQnasPagadas.SelectedValue <> "-1" And Me.ddlQnasPagadas.SelectedValue <> String.Empty Then
                Me.LblInfDeQna.Text = "Detalles de pago de la quincena: " + Me.ddlQnasPagadas.SelectedItem.Text
                Me.LblInfDeQna.Visible = True
                Me.btnImprimirReciboPago.Visible = True
                Me.btnPrintReciboPagoConImg.Visible = True

                'Si la quincena fue pagada como adeudo en nómina normal
                If ddlQnasPagadas.SelectedItem.Text.Contains("(A)") Then
                    'Determinamos en que quincena fue pagada realmente
                    dt = oQnaPagadaComoAdeudo.ObtenQnaRealDePago(RFCEmp, CShort(Me.ddlQnasPagadas.SelectedValue))
                    Me.LblMsjSobreQna3.Text = "<br />QUINCENA PAGADA COMO ADEUDO EN LA QUINCENA: " + dt.Rows(0).Item("Quincena").ToString
                    Me.LblMsjSobreQna3.Visible = True
                    Me.btnImprimirReciboPago.Visible = False
                    Me.btnPrintReciboPagoConImg.Visible = False
                Else
                    Me.LblMsjSobreQna3.Visible = False
                    'Me.btnImprimirReciboPago.Visible = True
                End If

                dt = oNomina.ObtenSiExisteDevolucion(RFCEmp, CShort(Me.ddlQnasPagadas.SelectedValue))
                If dt.Rows.Count > 0 Then
                    Me.LblMsjSobreQna.Text = "<br />QUINCENA DEVUELTA EN LA QUINCENA: " + dt.Rows(0).Item("Quincena").ToString
                    Me.LblMsjSobreQna.Visible = True
                    'Me.btnImprimirReciboPago.Visible = True
                Else
                    Me.LblMsjSobreQna.Visible = False
                    'Me.btnImprimirReciboPago.Visible = True
                End If

                dt = oNomina2.ObtenSiExisteRecibo(RFCEmp, CShort(Me.ddlQnasPagadas.SelectedValue))
                If dt.Rows.Count > 0 Then
                    Me.LblMsjSobreQna2.Text = "<br />QUINCENA PAGADA CON EL RECIBO: " + dt.Rows(0).Item("NumRecibo").ToString + "/" + dt.Rows(0).Item("Anio").ToString
                    Me.LblMsjSobreQna2.Visible = True
                    Me.lbVerRecibo.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx?IdRecibo=" + dt.Rows(0).Item("IdRecibo").ToString + "&IdReporte=2','Recibo_" + dt.Rows(0).Item("IdRecibo").ToString + "'); return false;"
                    Me.lbVerRecibo.Visible = True
                    Me.btnImprimirReciboPago.Visible = False
                    Me.btnPrintReciboPagoConImg.Visible = False
                Else
                    Me.LblMsjSobreQna2.Visible = False
                    Me.lbVerRecibo.Visible = False
                    'Me.btnImprimirReciboPago.Visible = True
                End If

                oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
                dsEmpPago = oEmp.ConsultaPagoQnal(CType(Me.ddlQnasPagadas.SelectedValue, Short))

                Me.gvPlazas.DataSource = dsEmpPago.Tables(5)
                Me.gvPercepciones.DataSource = dsEmpPago.Tables(1)
                Me.gvDeducciones.DataSource = dsEmpPago.Tables(2)
                Me.dvTotalPerc.DataSource = dsEmpPago.Tables(0)
                Me.dvTotalDeduc.DataSource = dsEmpPago.Tables(0)
                Me.dvNetoPagar.DataSource = dsEmpPago.Tables(0)
                'Me.gvDetallePago.DataSource = dsEmpPago.Tables(3)
                Me.gvQuincenasAdeudo.DataSource = dsEmpPago.Tables(3)
                Me.gvQuincenasDevoluciones.DataSource = dsEmpPago.Tables(4)
                Me.btnImprimirReciboPago.Enabled = (dsEmpPago.Tables(0).Rows.Count > 0)
                Me.btnPrintReciboPagoConImg.Enabled = (dsEmpPago.Tables(0).Rows.Count > 0)
                Me.btnImprimirReciboPago.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                                        + "?SubTipoReporte=3" _
                                                        + "&IdQuincena=" + Me.ddlQnasPagadas.SelectedValue _
                                                        + "&RFCEmp=" + RFCEmp _
                                                        + "&IdFondoPresup=0" _
                                                        + "&IdReporte=10" + "','ReciboNominaEmp_" + Me.ddlQnasPagadas.SelectedValue + "_" + RFCEmp + "'); return false;"
                Me.btnPrintReciboPagoConImg.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                                        + "?SubTipoReporte=3" _
                                                        + "&IdQuincena=" + Me.ddlQnasPagadas.SelectedValue _
                                                        + "&RFCEmp=" + RFCEmp _
                                                        + "&IdFondoPresup=0" _
                                                        + "&IdReporte=95" + "','ReciboNominaImgEmp_" + Me.ddlQnasPagadas.SelectedValue + "_" + RFCEmp + "'); return false;"

            End If

            Me.gvPlazas.DataBind()
            Me.gvPercepciones.DataBind()
            Me.gvDeducciones.DataBind()
            Me.dvTotalPerc.DataBind()
            Me.dvTotalDeduc.DataBind()
            Me.dvNetoPagar.DataBind()

            gvPlazas.SelectedIndex = -1

            'Me.gvDetallePago.DataBind()
            Me.gvQuincenasAdeudo.DataBind()
            Me.gvQuincenasDevoluciones.DataBind()

            Me.pnl1.Visible = True
            Me.pnl2.Visible = True

            Me.lbDetallePago.Visible = Me.ddlQnasPagadas.SelectedValue <> "-1" And Me.ddlQnasPagadas.SelectedValue <> String.Empty
            lbDetallePago.OnClientClick = "javascript:abreVentanaImpresion('DetallePago.aspx?TipoOperacion=4" + _
                            "&Adeudo=NO&IdQuincena=" + ddlQnasPagadas.SelectedValue + _
                            "&RFCEmp=" + oEmp.RFC + "','" + oEmp.RFC + "_" + Me.ddlQnasPagadas.SelectedValue + "'); return false;"

        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Remove("pFchImpRpt")
            BindDatos()
            BindPago()
            btnSendEmail.Visible = True
        End If
    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
        BindPago()
    End Sub

    Protected Sub btnConsultarPago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarPago.Click, btnImprimirReciboPago.Click
        If lblEmpInf.Text.Contains(Session("RFCParaCons")) Then
            BindPago()
        Else
            BindDatos()
            BindPago()
        End If
    End Sub

    Protected Sub gvQuincenasAdeudo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
                Dim lblIdQuincena As Label = CType(e.Row.FindControl("lblIdQuincena"), Label)
                Dim lbDetallePagoAdeudo As LinkButton = CType(e.Row.FindControl("lbDetallePagoAdeudo"), LinkButton)

                lbDetallePagoAdeudo.OnClientClick = "javascript:abreVentanaChica('DetallePago.aspx?IdQuincenaAplicacion=" + Me.ddlQnasPagadas.SelectedValue + _
                                            "&TipoOperacion=4" + _
                                            "&Adeudo=SI&IdQuincena=" + lblIdQuincena.Text + _
                                            "&RFCEmp=" + IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons")) + "'); return false;"
        End Select
    End Sub

    Protected Sub gvQuincenasDevoluciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
                Dim lblIdQuincena As Label = CType(e.Row.FindControl("lblIdQuincena"), Label)
                Dim lbDetallePagoDevolucion As LinkButton = CType(e.Row.FindControl("lbDetallePagoDevolucion"), LinkButton)

                lbDetallePagoDevolucion.OnClientClick = "javascript:abreVentanaChica('DetallePago.aspx?TipoOperacion=4" + _
                                            "&Devolucion=SI&IdQuincena=" + lblIdQuincena.Text + _
                                            "&RFCEmp=" + IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons")) + "&IdQuincenaAplicacion=" + Me.ddlQnasPagadas.SelectedValue + "'); return false;"
        End Select
    End Sub

    Protected Sub gvPlazas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim oPlaza As New EmpleadoPlazas
                Dim dtWarnings As DataTable

                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibWarning As ImageButton = CType(e.Row.FindControl("ibWarning"), ImageButton)

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Plazas/wfAdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text
                ibWarning.OnClientClick = "javascript:abreVentMedAncha('../Plazas/ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                dtWarnings = oPlaza.ObtenObservaciones(CInt(lblIdPlaza.Text))
                ibWarning.Visible = dtWarnings.Rows.Count > 0
        End Select

    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        Dim oQna As New Quincenas
        Dim RFCEmp As String
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oUsr As New Usuario
        Dim dr As DataRow

        RFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        With Me.ddlQnasPagadas
            .DataSource = oQna.ObtenQnasPagadasPorEmp(RFCEmp, CShort(Me.ddlAños.SelectedValue), CBool(dr("VisibilidadDeQnasAdic")))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Add(New ListItem("Información no disponible", "-1"))
                Me.btnConsultarPago.Enabled = False
                Me.LblInfDeQna.Visible = False
                Me.btnImprimirReciboPago.Enabled = False
                Me.btnPrintReciboPagoConImg.Enabled = False
            Else
                btnConsultarPago.Enabled = True
            End If
        End With
        BindPago()
    End Sub
    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            If Session("RFCParaCons") Is Nothing = False Then
                If Me.lblRFCEmp.Text <> Session("RFCParaCons") Then
                    BindDatos()
                    BindPago()
                End If
            End If
        End If
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Then
            If hfRFC.Value <> String.Empty Then
                BindDatos()
                BindPago()
            End If
        ElseIf Request.Params(0).Contains("BtnNewSearch") Then
            Me.pnl1.Visible = False
            Me.pnl2.Visible = False
        ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
            Me.pnl1.Visible = True
            Me.pnl2.Visible = True
        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                BindDatos()
                BindPago()
            End If
        End If
    End Sub

    Protected Sub btnSendEmail_Click(sender As Object, e As System.EventArgs) Handles btnSendEmail.Click
        Dim oQna As New Quincenas
        Dim dt As DataTable
        Dim dr As DataRow
        Dim vlIdQuincena As Short = CShort(ddlQnasPagadas.SelectedValue)
        Dim vlNumEmp As String = CType(WucBuscaEmpleados1.FindControl("hfNumEmp"), HiddenField).Value

        dt = oQna.ObtenEmpsParaNotificacionDePagoViaEmail(vlIdQuincena, vlNumEmp)
        dr = dt.Rows(0)
        EliminaPDF() 'Elimino todos los pdf's que estén generados para no saturar el servidor con archivos
        GeneraPDF(vlIdQuincena, dr("RFCEmp"), dr("NumEmp"), dr("Quincena").ToString.Replace("-", "_"))
        EnviaEmail(dr)
    End Sub

    Protected Sub ibVerPercepciones_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblIdPlaza As Label

        lblIdPlaza = CType(gvr.FindControl("lblIdPlaza"), Label)

        Dim oEmp As New Empleado
        Dim dsEmpPago As DataSet
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        dsEmpPago = oEmp.ConsultaPagoQnal(oEmp.RFC, CInt(lblIdPlaza.Text), CShort(ddlQnasPagadas.SelectedValue))

        gvPercepciones.DataSource = dsEmpPago.Tables(1)
        gvDeducciones.DataSource = Nothing
        dvTotalPerc.DataSource = dsEmpPago.Tables(0)
        dvTotalDeduc.DataSource = Nothing
        dvNetoPagar.DataSource = Nothing

        gvPercepciones.DataBind()
        gvDeducciones.DataBind()
        dvTotalPerc.DataBind()
        dvTotalDeduc.DataBind()
        dvNetoPagar.DataBind()

        gvPlazas.SelectedIndex = gvr.RowIndex
    End Sub
End Class
