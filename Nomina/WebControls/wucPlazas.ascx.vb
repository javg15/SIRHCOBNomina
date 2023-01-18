Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports System.Data
Imports DataAccessLayer.COBAEV.Plazas

Partial Class wucPlazas
    Inherits System.Web.UI.UserControl
    Private _ContinuarConMovDePers As Boolean
    Private _proplblInfEmp, _proplblNumCadena, _proplblTramite, _proplblMotivo As String
    Private _proptxtbxCod_Pago, _proplblDescCod_Pago, _proplblClavePlaza As String
    Private _propddlCvePlazaTipo, _proplblDescPlazaTipo As String
    Private _propddlZonasEco, _proplblDescZonaEco, _propddlCveCategoCOBACH, _propddlCveCategoCOBACH2 As String
    Private _proplblDescCatego, _proptxtbxHorasPlaza, _proptxtbxConsPlaza As String
    Private _dtInfTraMot As DataTable

    Public Property propdtInfTraMot() As DataTable
        Get
            '_dtInfTraMot = lblInfEmp.Text
            Return _dtInfTraMot
        End Get
        Set(ByVal Value As DataTable)
            _dtInfTraMot = Value
        End Set
    End Property

    'Public Property proplblInfEmp() As String
    '    Get
    '        _proplblInfEmp = lblInfEmp.Text
    '        Return _proplblInfEmp
    '    End Get
    '    Set(ByVal Value As String)
    '        _proplblInfEmp = Value
    '    End Set
    'End Property

    'Public Property proplblNumCadena() As String
    '    Get
    '        _proplblNumCadena = lblNumCadena.Text
    '        Return _proplblNumCadena
    '    End Get
    '    Set(ByVal Value As String)
    '        _proplblNumCadena = Value
    '    End Set
    'End Property

    'Public Property proplblTramite() As String
    '    Get
    '        _proplblTramite = lblTramite.Text
    '        Return _proplblTramite
    '    End Get
    '    Set(ByVal Value As String)
    '        _proplblTramite = Value
    '    End Set
    'End Property

    'Public Property proplblMotivo() As String
    '    Get
    '        _proplblMotivo = lblMotivo.Text
    '        Return _proplblMotivo
    '    End Get
    '    Set(ByVal Value As String)
    '        _proplblMotivo = Value
    '    End Set
    'End Property

    Public Property proptxtbxCod_Pago() As String
        Get
            _proptxtbxCod_Pago = txtbxCod_Pago.Text
            Return _proptxtbxCod_Pago
        End Get
        Set(ByVal Value As String)
            _proptxtbxCod_Pago = Value
        End Set
    End Property

    Public Property proplblDescCod_Pago() As String
        Get
            _proplblDescCod_Pago = lblDescCod_Pago.Text
            Return _proplblDescCod_Pago
        End Get
        Set(ByVal Value As String)
            _proplblDescCod_Pago = Value
        End Set
    End Property

    Public Property propddlCveCategoCOBACH() As String
        Get
            _propddlCveCategoCOBACH = Left(ddlCveCategoCOBACH.SelectedItem.Text, 3)
            Return _propddlCveCategoCOBACH
        End Get
        Set(ByVal Value As String)
            _propddlCveCategoCOBACH = Value
        End Set
    End Property

    Public Property propddlCveCategoCOBACH2() As String
        Get
            _propddlCveCategoCOBACH2 = ddlCveCategoCOBACH.SelectedItem.Text.Substring(4, (ddlCveCategoCOBACH.SelectedItem.Text.Length - 4))
            Return _propddlCveCategoCOBACH2
        End Get
        Set(ByVal Value As String)
            _propddlCveCategoCOBACH2 = Value
        End Set
    End Property

    Public Property proplblDescCatego() As String
        Get
            _proplblDescCatego = lblDescCatego.Text
            Return _proplblDescCatego
        End Get
        Set(ByVal Value As String)
            _proplblDescCatego = Value
        End Set
    End Property

    Public Property proptxtbxConsPlaza() As String
        Get
            _proptxtbxConsPlaza = txtbxConsPlaza.Text
            Return _proptxtbxConsPlaza
        End Get
        Set(ByVal Value As String)
            _proptxtbxConsPlaza = Value
        End Set
    End Property

    Public Property proptxtbxHorasPlaza() As String
        Get
            _proptxtbxHorasPlaza = txtbxHorasPlaza.Text
            Return _proptxtbxHorasPlaza
        End Get
        Set(ByVal Value As String)
            _proptxtbxHorasPlaza = Value
        End Set
    End Property

    Public Property ContinuarConMovDePers() As Boolean
        Get
            Return _ContinuarConMovDePers
        End Get
        Set(ByVal Value As Boolean)
            _ContinuarConMovDePers = Value
        End Set
    End Property

    Public Property proplblClavePlaza() As String
        Get
            _proplblClavePlaza = txtbxClavePlaza.Text
            Return _proplblClavePlaza
        End Get
        Set(ByVal Value As String)
            _proplblClavePlaza = Value
        End Set
    End Property

    Public Property propddlCvePlazaTipo() As String
        Get
            _propddlCvePlazaTipo = ddlCvePlazaTipo.SelectedValue
            Return _propddlCvePlazaTipo
        End Get
        Set(ByVal Value As String)
            _propddlCvePlazaTipo = Value
        End Set
    End Property
    Public Property proplblDescPlazaTipo() As String
        Get
            _proplblDescPlazaTipo = lblDescPlazaTipo.Text
            Return _proplblDescPlazaTipo
        End Get
        Set(ByVal Value As String)
            _proplblDescPlazaTipo = Value
        End Set
    End Property

    Public Property propddlZonasEco() As String
        Get
            _propddlZonasEco = ddlZonasEco.SelectedItem.Text
            Return _propddlZonasEco
        End Get
        Set(ByVal Value As String)
            _propddlZonasEco = Value
        End Set
    End Property
    Public Property proplblDescZonaEco() As String
        Get
            _proplblDescZonaEco = lblDescZonaEco.Text
            Return _proplblDescZonaEco
        End Get
        Set(ByVal Value As String)
            _proplblDescZonaEco = Value
        End Set
    End Property

    'Public Sub ActualizalblNumCadena(ByVal pText As String)
    '    lblNumCadena.Text = pText
    'End Sub

    'Public Sub ActualizalblTramiteYlblMotivo(ByVal pTextTramite As String, ByVal pTextMotivo As String)
    '    lblTramite.Text = pTextTramite
    '    lblMotivo.Text = pTextMotivo
    'End Sub

    Public Sub ActualizatxtbxCod_Pago(ByVal pText As String)
        txtbxCod_Pago.Text = pText
    End Sub

    Public Sub ActualizalblDescCod_Pago(ByVal pText As String)
        lblDescCod_Pago.Text = pText
    End Sub

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False And SelectedValue <> String.Empty Then
            If ddl.Items.FindByValue(SelectedValue) Is Nothing = False Then
                ddl.SelectedValue = SelectedValue
            End If
        End If
    End Sub

    Public Sub UpdateClavePlaza()
        txtbxClavePlaza.Text = ddlCvePlazaTipo.SelectedItem.Text + "-" + ddlZonasEco.SelectedItem.Text + "-" +
                            txtbxCod_Pago.Text +
                            IIf(txtbxUnidad.Text.Trim <> String.Empty, "-" + txtbxUnidad.Text.Trim, "") +
                            IIf(txtbxSubUnidad.Text.Trim <> String.Empty, "-" + txtbxSubUnidad.Text.Trim, "") +
                            "-" + ddlCveCategoCOBACH.SelectedValue +
                            "-" + txtbxHorasPlaza.Text + "-" + txtbxConsPlaza.Text.Trim
    End Sub

    Public Sub UpdateHorasPlaza()
        Dim oPlaza As New SMP_Plazas
        Dim dtPlazaDetalles As DataRow = Nothing

        txtbxConsPlaza.Text = txtbxConsPlaza.Text.PadLeft(5, "0")
        If ddlCveCategoCOBACH.Text <> "-1" Then
            dtPlazaDetalles = oPlaza.ObtenPlazaDetalles(ddlZonasEco.SelectedItem.Text, ddlCveCategoCOBACH.Text, txtbxConsPlaza.Text)
        End If

        If dtPlazaDetalles Is Nothing = False Then
            txtbxHorasPlaza.Text = dtPlazaDetalles("strHrsJornada").ToString
            imgPlazaCorrecta.Visible = True
            imgPlazaIncorrecta.Visible = False
            _ContinuarConMovDePers = True
        Else
            imgPlazaCorrecta.Visible = False
            imgPlazaIncorrecta.Visible = True
            _ContinuarConMovDePers = False
        End If
    End Sub

    Private Sub UpdateDescPlazaTipo()
        Dim dtTipoPlaza As DataTable
        Dim oPlaza As New SMP_Plazas

        dtTipoPlaza = oPlaza.ObtenInfDeCvePlazaTipo(ddlCvePlazaTipo.SelectedValue)
        lblDescPlazaTipo.Text = "PLAZA DE " + dtTipoPlaza.Rows(0).Item("DescPlazaTipo").ToString
    End Sub

    Private Sub UpdateDescZonaEco()
        Dim dtInfZonaEco As DataTable
        Dim oZonaEco As New ZonaEconomica

        dtInfZonaEco = oZonaEco.ObtenPorId(CByte(ddlZonasEco.SelectedValue))
        lblDescZonaEco.Text = "PLAZA DE " + dtInfZonaEco.Rows(0).Item("DescZonaEcoConPorc").ToString
    End Sub

    Private Sub Bind_ddlCveCategoCOBACH(ByVal pstrIdEmpFuncion As String)
        Dim oPlaza As New SMP_Plazas

        LlenaDDL(ddlCveCategoCOBACH, "DescCatego2", "CveCategoCOBACH", oPlaza.ObtenCategosXCvePlazaTipoYZonaEcoParaMovDePers(ddlCvePlazaTipo.SelectedValue, ddlZonasEco.SelectedItem.Text, pstrIdEmpFuncion), Nothing)

        If ddlCveCategoCOBACH.Items.Count = 0 Then
            ddlCveCategoCOBACH.Items.Add(New ListItem("(CATEGORÍAS NO DISPONIBLES)", "-1"))
        End If
    End Sub

    Private Sub UpdateDescPlazaDiferenciador()
        Dim drDescPlazaDiferenciador As DataRow
        Dim oPlaza As New SMP_Plazas

        drDescPlazaDiferenciador = oPlaza.ObtenDetallesPlazaPorZEyPlazaTipoyCveCatego(ddlZonasEco.SelectedItem.Text, ddlCvePlazaTipo.SelectedValue, ddlCveCategoCOBACH.SelectedValue)
        If drDescPlazaDiferenciador Is Nothing = False Then
            lblDescCatego.Text = drDescPlazaDiferenciador("DescPlazaDiferenciador").ToString
            txtbxHorasPlaza.Text = drDescPlazaDiferenciador("strHrsJornada").ToString
        End If
    End Sub

    Public Sub UpdateIsPostBack()
        Dim oPlaza As New SMP_Plazas
        Dim oZonaEco As New ZonaEconomica

        'lblInfEmp.Text = _proplblInfEmp
        'lblNumCadena.Text = _proplblNumCadena
        'lblTramite.Text = _proplblTramite
        'lblMotivo.Text = _proplblMotivo
        LlenaDDL(ddlCvePlazaTipo, "CvePlazaTipo", "CvePlazaTipo", oPlaza.ObtenTipos(), Nothing)
        UpdateDescPlazaTipo()
        LlenaDDL(ddlZonasEco, "ClaveZonaEco", "IdZonaEco", oZonaEco.ObtenTodasSinComodin(), Nothing)
        UpdateDescZonaEco()
        txtbxCod_Pago.Text = _proptxtbxCod_Pago
        lblDescCod_Pago.Text = _proplblDescCod_Pago
        Bind_ddlCveCategoCOBACH(_dtInfTraMot.Rows(0).Item("strIdEmpFuncion").ToString)
        UpdateDescPlazaDiferenciador()
        txtbxConsPlaza.Text = "00000"
        UpdateClavePlaza()
        imgPlazaCorrecta.Visible = False
        imgPlazaIncorrecta.Visible = True
        txtbxFechaIni.Text = String.Empty
        txtbxFechaFin.Text = String.Empty
        If CBool(_dtInfTraMot.Rows(0).Item("PedirVigFin")) = False Then
            txtbxFechaFin.Text = "31/12/2099"
            txtbxFechaFin.Enabled = False
            ibFechaFin.Visible = False
        Else
            txtbxFechaFin.Text = String.Empty
            txtbxFechaFin.Enabled = True
            ibFechaFin.Visible = True
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'UpdateIsPostBack()
        End If
    End Sub

    Protected Sub ddlCvePlazaTipo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCvePlazaTipo.SelectedIndexChanged
        Dim oPlaza As New SMP_Plazas

        UpdateDescPlazaTipo()
        Bind_ddlCveCategoCOBACH(_dtInfTraMot.Rows(0).Item("strIdEmpFuncion").ToString)
        UpdateDescPlazaDiferenciador()
        UpdateHorasPlaza()
        UpdateClavePlaza()
    End Sub

    Protected Sub ddlZonasEco_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlZonasEco.SelectedIndexChanged
        Dim oPlaza As New SMP_Plazas

        UpdateDescZonaEco()
        Bind_ddlCveCategoCOBACH(_dtInfTraMot.Rows(0).Item("strIdEmpFuncion").ToString)
        UpdateDescPlazaDiferenciador()
        UpdateHorasPlaza()
        UpdateClavePlaza()
    End Sub

    Protected Sub txtbxConsPlaza_TextChanged(sender As Object, e As System.EventArgs) Handles txtbxConsPlaza.TextChanged
        UpdateHorasPlaza()
        UpdateClavePlaza()
    End Sub

    Protected Sub ddlCveCategoCOBACH_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCveCategoCOBACH.SelectedIndexChanged
        UpdateDescPlazaDiferenciador()
        txtbxConsPlaza.Text = txtbxConsPlaza.Text.PadLeft(5, "0")
        UpdateHorasPlaza()
        UpdateClavePlaza()
    End Sub

    Protected Sub ibFechaIni_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibFechaIni.Click
        Dim vlCalendario As Calendar = CType(wucCalendarFechIni.FindControl("Calendar1"), Calendar)

        If txtbxFechaIni.Text.Trim <> String.Empty And IsDate(txtbxFechaIni.Text.Trim) Then
            vlCalendario.SelectedDate = CDate(txtbxFechaIni.Text).ToString("dd/MM/yyyy")
            vlCalendario.VisibleDate = CDate(txtbxFechaIni.Text).ToString("dd/MM/yyyy")

            wucCalendarFechIni.Calendar1VisibleMonthChanged()
        Else
            vlCalendario.VisibleDate = Today
            vlCalendario.SelectedDate = Nothing

            wucCalendarFechIni.Calendar1VisibleMonthChanged()
        End If

        pnlFechIni.Visible = Not pnlFechIni.Visible
        pnlFechFin.Visible = False
    End Sub

    Protected Sub ibFechaFin_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibFechaFin.Click
        Dim vlCalendario As Calendar = CType(wucCalendarFechFin.FindControl("Calendar1"), Calendar)

        If txtbxFechaFin.Text.Trim <> String.Empty And IsDate(txtbxFechaFin.Text.Trim) Then
            vlCalendario.SelectedDate = CDate(txtbxFechaFin.Text).ToString("dd/MM/yyyy")
            vlCalendario.VisibleDate = CDate(txtbxFechaFin.Text).ToString("dd/MM/yyyy")

            wucCalendarFechFin.Calendar1VisibleMonthChanged()
        Else
            vlCalendario.VisibleDate = Today
            vlCalendario.SelectedDate = Nothing

            wucCalendarFechFin.Calendar1VisibleMonthChanged()
        End If

        pnlFechFin.Visible = Not pnlFechFin.Visible
        pnlFechIni.Visible = False
    End Sub

    Protected Sub wucCalendarFechIni_PreRender(sender As Object, e As System.EventArgs) Handles wucCalendarFechIni.PreRender
        Dim vlCalendario As Calendar = CType(wucCalendarFechIni.FindControl("Calendar1"), Calendar)

        If IsPostBack Then
            'If Request.Params(0).Contains("Calendar1") Or Request.Params(1).Contains("Calendar1") Then
            If vlCalendario.ID = "Calendar1" Then
                If txtbxFechaIni.Text <> vlCalendario.SelectedDate().ToString("dd/MM/yyyy") Then
                    txtbxFechaIni.Text = vlCalendario.SelectedDate().ToString("dd/MM/yyyy")
                    If txtbxFechaIni.Text = "01/01/0001" Then txtbxFechaIni.Text = String.Empty
                    If txtbxFechaFin.Enabled Then txtbxFechaFin.Text = txtbxFechaIni.Text
                    If txtbxFechaIni.Text <> "01/01/0001" And txtbxFechaIni.Text <> String.Empty Then pnlFechIni.Visible = Not pnlFechIni.Visible
                End If
            End If
        End If
    End Sub

    Protected Sub wucCalendarFechFin_PreRender(sender As Object, e As System.EventArgs) Handles wucCalendarFechFin.PreRender
        Dim vlCalendario As Calendar = CType(wucCalendarFechFin.FindControl("Calendar1"), Calendar)

        If IsPostBack Then
            'If Request.Params(0).Contains("Calendar1") Or Request.Params(1).Contains("Calendar1") Then
            If vlCalendario.ID = "Calendar1" Then
                If txtbxFechaFin.Text <> vlCalendario.SelectedDate().ToString("dd/MM/yyyy") Then
                    txtbxFechaFin.Text = vlCalendario.SelectedDate().ToString("dd/MM/yyyy")
                    If txtbxFechaFin.Text = "01/01/0001" Then txtbxFechaFin.Text = String.Empty
                    'If txtbxFechaFin.Enabled = False Then txtbxFechaFin.Text = txtbxFechaIni.Text
                    If txtbxFechaFin.Text <> "01/01/0001" And txtbxFechaFin.Text <> String.Empty Then pnlFechFin.Visible = Not pnlFechFin.Visible
                End If
            End If
        End If
    End Sub
End Class
