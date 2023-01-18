Imports DataAccessLayer.COBAEV
Imports System.Data

Partial Class WebControls_wfCalendario
    Inherits System.Web.UI.Page
    Private dtPeriodos As DataTable

    Private Sub CargaAnios()
        Dim vlAnio As Integer

        For vlAnio = Today.Year + 1 To Today.Year - 1 Step -1
            ddlAnios.Items.Add(New ListItem(vlAnio.ToString, vlAnio.ToString))
        Next
    End Sub
    Private Sub CargaMeses()
        Dim vlMeses As Integer

        ddlMeses.Items.Clear()

        If ddlAnios.SelectedValue = Today.Year.ToString Then
            For vlMeses = 12 To 1 Step -1 'Today.Month To 1 Step -1
                ddlMeses.Items.Add(New ListItem(MonthName(vlMeses).ToString.ToUpper(), vlMeses.ToString))
            Next
        Else
            For vlMeses = 12 To 1 Step -1
                ddlMeses.Items.Add(New ListItem(MonthName(vlMeses).ToString.ToUpper(), vlMeses.ToString))
            Next
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim oCalendario As New CalendarioLaboral

        dtPeriodos = oCalendario.ObtenPeriodosNoLaborables()

        If Not IsPostBack Then
            CargaAnios()
            CargaMeses()
        End If
    End Sub

    Protected Sub ddlAnios_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAnios.SelectedIndexChanged
        CargaMeses()
        Calendar1.VisibleDate = New Date(CInt(ddlAnios.SelectedValue), CInt(ddlMeses.SelectedValue), 1)
    End Sub

    Protected Sub ddlMeses_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged
        Calendar1.VisibleDate = New Date(CInt(ddlAnios.SelectedValue), CInt(ddlMeses.SelectedValue), 1)
    End Sub

    Protected Sub Calendar1_DayRender(sender As Object, e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
        Dim vlDiaNoLab As Boolean = False
        Dim vlDiaNoLabPorVacaciones As Boolean = False

        Dim dr As DataRow

        For Each dr In dtPeriodos.Rows
            If e.Day.Date >= CDate(dr("FechaIniPeriodo")) And e.Day.Date <= CDate(dr("FechaFinPeriodo")) And CBool(dr("PeriodoVacacional")) = False Then
                vlDiaNoLab = True
                Exit For
            ElseIf e.Day.Date >= CDate(dr("FechaIniPeriodo")) And e.Day.Date <= CDate(dr("FechaFinPeriodo")) And CBool(dr("PeriodoVacacional")) = True Then
                vlDiaNoLabPorVacaciones = True
                Exit For
            End If
        Next

        If e.Day.Date > Today And Not e.Day.IsWeekend And Not vlDiaNoLab And Not vlDiaNoLabPorVacaciones Then
            e.Day.IsSelectable = True
            'e.Cell.CssClass = "diaNoSeleccionable"
            'e.Cell.ToolTip = e.Day.Date.ToShortDateString + ", es mayor que la fecha actual. (Deshabilitado)"
        ElseIf e.Day.IsWeekend Then
            e.Day.IsSelectable = False
            e.Cell.CssClass = "diaNoSeleccionable"
            e.Cell.ToolTip = e.Day.Date.ToShortDateString + " fue o es fin de semana. (Deshabilitado)"
        ElseIf vlDiaNoLab Then
            e.Day.IsSelectable = False
            e.Cell.CssClass = "diaNoLaborable"
            e.Cell.ToolTip = e.Day.Date.ToShortDateString + " fue o es día no laborable. (Deshabilitado)"
        ElseIf vlDiaNoLabPorVacaciones Then
            e.Day.IsSelectable = False
            e.Cell.CssClass = "diaNoLabPorVacaciones"
            e.Cell.ToolTip = e.Day.Date.ToShortDateString + " fue o es día vacacional. (Deshabilitado)"
        End If
    End Sub

    Protected Sub Calendar1_VisibleMonthChanged(sender As Object, e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged
        Dim liAnio As ListItem
        Dim liMes As ListItem

        liAnio = ddlAnios.Items.FindByValue(Calendar1.VisibleDate.Year.ToString)
        liMes = ddlMeses.Items.FindByValue(Calendar1.VisibleDate.Month.ToString)

        If liAnio Is Nothing = False And liMes Is Nothing = False Then
            ddlAnios.SelectedValue = Calendar1.VisibleDate.Year.ToString
            CargaMeses()
            ddlMeses.SelectedValue = Calendar1.VisibleDate.Month.ToString
        Else
            If Calendar1.VisibleDate.Month = 12 Then
                'liAnio = ddlAnios.Items.FindByValue((Calendar1.VisibleDate.Year - 1).ToString)
                If liAnio Is Nothing = False Then
                    ddlAnios.SelectedValue = Calendar1.VisibleDate.Year.ToString
                    CargaMeses()
                    ddlMeses.SelectedValue = Calendar1.VisibleDate.Month.ToString
                Else
                    Calendar1.VisibleDate = New Date(CInt(ddlAnios.SelectedValue), CInt(ddlMeses.SelectedValue), 1)
                End If
            Else
                Calendar1.VisibleDate = New Date(CInt(ddlAnios.SelectedValue), CInt(ddlMeses.SelectedValue), 1)
            End If
        End If
    End Sub
End Class
