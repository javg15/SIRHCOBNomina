
Partial Class Calendario
    Inherits System.Web.UI.Page
    Private Sub ConfiguraControles(ByVal Fecha As String)
        Me.hfFecha.Value = Fecha

        Me.lbCerrar.Attributes.Remove("onclick")
        Me.lbCerrar.Attributes.Add("onclick", "seleccionaFecha();")
    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        ConfiguraControles(Calendar1.SelectedDate.ToShortDateString)
        Me.lblAnio.Text = Me.Calendar1.SelectedDate.Year.ToString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            ConfiguraControles("0")
            If Request.Params("Fecha") Is Nothing = False Then
                Me.Calendar1.SelectedDate = CDate(Request.Params("Fecha"))
                ConfiguraControles(Calendar1.SelectedDate.ToShortDateString)
                Me.lblAnio.Text = Me.Calendar1.SelectedDate.Year.ToString
                Me.Calendar1.VisibleDate = Me.Calendar1.SelectedDate
            Else
                Me.lblAnio.Text = Date.Today.Year
            End If
        End If
    End Sub

    Protected Sub lbAnioAnt_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lblAnio.Text = (CShort(lblAnio.Text) - 1).ToString
        Me.Calendar1.SelectedDate = CDate(Me.Calendar1.SelectedDate.Day.ToString + "/" + Me.Calendar1.SelectedDate.Month.ToString + "/" + Me.lblAnio.Text)
        Me.Calendar1.VisibleDate = Me.Calendar1.SelectedDate
        ConfiguraControles(Calendar1.SelectedDate.ToShortDateString)
    End Sub

    Protected Sub Calendar1_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged
        Me.Calendar1.SelectedDate = CDate(Calendar1.SelectedDate.Day.ToString + "/" + e.NewDate.Month.ToString + "/" + e.NewDate.Year.ToString)
        Me.Calendar1.VisibleDate = Me.Calendar1.SelectedDate
        Me.lblAnio.Text = Me.Calendar1.SelectedDate.Year.ToString
        ConfiguraControles(Calendar1.SelectedDate.ToShortDateString)
    End Sub

    Protected Sub lbAnioSig_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lblAnio.Text = (CShort(lblAnio.Text) + 1).ToString
        Me.Calendar1.SelectedDate = CDate(Me.Calendar1.SelectedDate.Day.ToString + "/" + Me.Calendar1.SelectedDate.Month.ToString + "/" + Me.lblAnio.Text)
        Me.Calendar1.VisibleDate = Me.Calendar1.SelectedDate
        ConfiguraControles(Calendar1.SelectedDate.ToShortDateString)
    End Sub
End Class
