Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports System.Data
Imports DataAccessLayer.COBAEV.Plazas

Partial Class wucPlazas2
    Inherits System.Web.UI.UserControl
    Private _proplblInfEmp, _proplblNumCadena, _proplblTramite, _proplblMotivo As String
    Private _proplblClavePlaza, _proplblDescPlazaTipo, _proplblZonaEco As String
    Private _proplblCod_Pago, _proplblCveCategoCOBACH, _proplblHorasPlaza As String
    Private _proplblConsPlaza As String

    Public Property proplblInfEmp() As String
        Get
            Return _proplblInfEmp
        End Get
        Set(ByVal Value As String)
            _proplblInfEmp = Value
        End Set
    End Property

    Public Property proplblNumCadena() As String
        Get
            Return _proplblNumCadena
        End Get
        Set(ByVal Value As String)
            _proplblNumCadena = Value
        End Set
    End Property

    Public Property proplblTramite() As String
        Get
            Return _proplblTramite
        End Get
        Set(ByVal Value As String)
            _proplblTramite = Value
        End Set
    End Property

    Public Property proplblMotivo() As String
        Get
            Return _proplblMotivo
        End Get
        Set(ByVal Value As String)
            _proplblMotivo = Value
        End Set
    End Property

    Public Property proplblClavePlaza() As String
        Get
            Return _proplblClavePlaza
        End Get
        Set(ByVal Value As String)
            _proplblClavePlaza = Value
        End Set
    End Property

    Public Property proplblDescPlazaTipo() As String
        Get
            Return _proplblDescPlazaTipo
        End Get
        Set(ByVal Value As String)
            _proplblDescPlazaTipo = Value
        End Set
    End Property

    Public Property proplblZonaEco() As String
        Get
            Return _proplblZonaEco
        End Get
        Set(ByVal Value As String)
            _proplblZonaEco = Value
        End Set
    End Property

    Public Property proplblCod_Pago() As String
        Get
            Return _proplblCod_Pago
        End Get
        Set(ByVal Value As String)
            _proplblCod_Pago = Value
        End Set
    End Property

    Public Property proplblCveCategoCOBACH() As String
        Get
            Return _proplblCveCategoCOBACH
        End Get
        Set(ByVal Value As String)
            _proplblCveCategoCOBACH = Value
        End Set
    End Property

    Public Property proplblHorasPlaza() As String
        Get
            Return _proplblHorasPlaza
        End Get
        Set(ByVal Value As String)
            _proplblHorasPlaza = Value
        End Set
    End Property

    Public Property proplblConsPlaza() As String
        Get
            Return _proplblConsPlaza
        End Get
        Set(ByVal Value As String)
            _proplblConsPlaza = Value
        End Set
    End Property


    Public Sub UpdateIsPostBack()
        Dim oPlaza As New SMP_Plazas
        Dim oZonaEco As New ZonaEconomica

        lblInfEmp.Text = _proplblInfEmp
        lblNumCadena.Text = _proplblNumCadena
        lblTramite.Text = _proplblTramite
        lblMotivo.Text = _proplblMotivo
        lblClavePlaza.Text = _proplblClavePlaza
        lblCvePlazaTipo.Text = _proplblDescPlazaTipo
        lblZonaEco.Text = _proplblZonaEco
        lblCod_Pago.Text = _proplblCod_Pago
        lblCveCategoCOBACH.Text = _proplblCveCategoCOBACH
        lblHorasPlaza.Text = _proplblHorasPlaza
        lblConsPlaza.Text = _proplblConsPlaza
        txtbxFechaIni.Text = String.Empty
        txtbxFechaFin.Text = String.Empty
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
                    txtbxFechaFin.Text = txtbxFechaIni.Text
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
