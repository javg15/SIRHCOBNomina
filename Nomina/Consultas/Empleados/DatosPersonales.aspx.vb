Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Partial Class Consultas_Empleados_DatosPersonales
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim drDatosValidados As DataRow
        Dim dtPermisos As DataTable
        Dim oUsr As New Usuario
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If oEmp.RFC <> String.Empty Then
            Me.dvDatosPers.DataSource = oEmp.ObtenDatosPersonales()
            Me.dvDatosDom.DataSource = oEmp.ObtenDomicilio()
            Me.dvDatosDomFis.DataSource = oEmp.ObtenDomicilioFiscal()
            drDatosValidados = oEmp.ObtenEmpsValidadosPorSeguridadSocial()
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            Else
                Me.lblEmpInf.Text = String.Empty
            End If
            Me.dvDatosPers.DataBind()
            Me.dvDatosDom.DataBind()
            Me.dvDatosDomFis.DataBind()
            'Me.lbVerFoto.OnClientClick = "javascript:abreVentanaMediana('VisualzadorDeFotos.aspx?RFCEmp=" + oEmp.RFC + "'); return false"
            'Me.lbVerFoto.Enabled = True

            dtPermisos = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsValidadosPorSeguridadSocial")

            Me.ChkBxDatosValidados.Enabled = False
            Me.ChkBxDatosValidados.Checked = CBool(drDatosValidados("SuspenderPagoQnal"))
            Me.ChkBxDatosValidados.Visible = True
            Me.btnModificarSuspenderPagoQnal.Text = "Modificar"
            Me.btnModificarSuspenderPagoQnal.Visible = CBool(dtPermisos.Rows(0).Item("Actualizacion"))
            Me.btnGuardarSuspenderPagoQnal.Visible = False
            pnlGral.Visible = True
        Else
            'Me.lbVerFoto.Enabled = False
            Me.ChkBxDatosValidados.Visible = False
            Me.btnModificarSuspenderPagoQnal.Visible = False
            Me.btnGuardarSuspenderPagoQnal.Visible = False
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            'Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            'Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
            BindDatos()
        End If
    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
    End Sub

    Protected Sub dvDatosPers_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvDatosPers.DataBound
        Dim lbModifDatosPers As LinkButton = CType(Me.dvDatosPers.Rows(0).FindControl("lbModifDatosPers"), LinkButton)
        Dim lblRFCEmp As Label = CType(Me.dvDatosPers.Rows(0).FindControl("lblRFCEmp"), Label)
        If lblRFCEmp Is Nothing = False Then
            lbModifDatosPers.PostBackUrl = "~/ABC/Empleados/AdministracionEmpleados.aspx?TipoOperacion=0&RFCEmp=" + lblRFCEmp.Text
        End If
    End Sub

    Protected Sub dvDatosDom_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvDatosDom.DataBound
        Dim lbModificar As LinkButton = CType(Me.dvDatosDom.Rows(0).FindControl("lbModificar"), LinkButton)
        Dim lblRFCEmp As Label = CType(Me.dvDatosPers.Rows(0).FindControl("lblRFCEmp"), Label)
        If lblRFCEmp Is Nothing = False Then
            lbModificar.PostBackUrl = "~/ABC/Empleados/AdministracionDomicilios.aspx?TipoOperacion=0&RFCEmp=" + lblRFCEmp.Text
        End If
    End Sub
    Protected Sub dvDatosDomFis_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvDatosDomFis.DataBound
        Dim lbModificar As LinkButton = CType(Me.dvDatosDomFis.Rows(0).FindControl("lbModificarFis"), LinkButton)
        Dim lblRFCEmp As Label = CType(Me.dvDatosPers.Rows(0).FindControl("lblRFCEmp"), Label)
        If lblRFCEmp Is Nothing = False Then
            lbModificar.PostBackUrl = "~/ABC/Empleados/AdministracionDomicilioFiscalSAT.aspx?TipoOperacion=0&RFCEmp=" + lblRFCEmp.Text
        End If
    End Sub

    'Protected Sub WucBuscaEmpleados1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.Load
    '    If Request.Params(0).Contains("ibBuscarEmp") Then BindDatos()
    'End Sub
    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        'If Request.Params(0).Contains("BtnSearch") Then
        '    BindDatos()
        'ElseIf Request.Params(0).Contains("BtnNewSearch") Then
        '    'gvDocumentos.Visible = False
        'ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
        '    'gvDocumentos.Visible = True
        'ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
        '    If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
        '        BindDatos()
        '    End If
        'End If

        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Then
            If hfRFC.Value <> String.Empty Then
                BindDatos()
            End If
        ElseIf Request.Params(0).Contains("BtnNewSearch") Then
            pnlGral.Visible = False
        ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
            pnlGral.Visible = True
        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                BindDatos()
            End If
        End If
    End Sub

    Protected Sub btnGuardarSuspenderPagoQnal_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim oEmp As New Empleado

            oEmp.ActualizaEmpsValidadosPorSegSoc(hfRFC.Value, Me.ChkBxDatosValidados.Checked, CType(Session("ArregloAuditoria"), String()))
            BindDatos()
        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub

    Protected Sub btnModificarSuspenderPagoQnal_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.btnModificarSuspenderPagoQnal.Text = "Modificar" Then
            Me.ChkBxDatosValidados.Enabled = True
            Me.btnModificarSuspenderPagoQnal.Text = "Cancelar"
            Me.btnGuardarSuspenderPagoQnal.Visible = True
        Else
            BindDatos()
            'Me.ChkBxDatosValidados.Enabled = False
            'Me.btnModificarSuspenderPagoQnal.Text = "Modificar"
            'Me.btnGuardarSuspenderPagoQnal.Visible = False
        End If
    End Sub
End Class
