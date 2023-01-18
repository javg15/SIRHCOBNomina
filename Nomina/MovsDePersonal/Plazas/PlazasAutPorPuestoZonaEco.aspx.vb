Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports System.Data
Imports System.Drawing
Partial Class MovsDePersonal_PlazasAutPorPuestoZonaEco
    Inherits System.Web.UI.Page
    Private Sub AgregaEncabezado()
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()

        cell.Text = ""
        cell.ColumnSpan = 1
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 4
        cell.Text = "Información sobre la Plaza"
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.Text = ""
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 5
        cell.Text = "Información del Empleado que ocupa(ó) la plaza en el periodo"
        row.Controls.Add(cell)

        row.BackColor = ColorTranslator.FromHtml("Maroon")
        gvPlazasPorPuesto.HeaderRow.Parent.Controls.AddAt(0, row)
    End Sub
    Private Sub BindDatos(ByVal pCvePuestoCompuesta As String, ByVal pCveZonaEco As String, ByVal pIdQuincena As Short)
        Dim oPuesto As New Puestos
        Dim dt As DataTable

        dt = oPuesto.GetPlazas(Request.Params("pCvePuestoCompuesta"), Request.Params("pCveZonaEco"), Request.Params("pIdQuincena"))

        Me.gvPlazasPorPuesto.DataSource = dt
        Me.gvPlazasPorPuesto.DataBind()

        If dt.Rows.Count > 0 Then AgregaEncabezado()

    End Sub

    Protected Sub gvPlazasPorPuesto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazasPorPuesto.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim ddlAños As DropDownList = CType(wucAnioQnas1.FindControl("ddlAños"), DropDownList)
            Dim ddlQnasPagadas As DropDownList = CType(wucAnioQnas1.FindControl("ddlQnasPagadas"), DropDownList)

            Label1.Text = "Información obtenida con base en la quincena: " + Request.Params("pQuincena")
            Label1.Visible = True
            ddlAños.SelectedValue = Left(Request.Params("pQuincena").ToString, 4)
            ddlQnasPagadas.SelectedItem.Text = Request.Params("pQuincena").ToString
            BindDatos(Request.Params("pCvePuestoCompuesta"), Request.Params("pCveZonaEco"), Request.Params("pIdQuincena"))
        End If
    End Sub

    Protected Sub gvPlazasPorPuesto_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPlazasPorPuesto.SelectedIndexChanged
        Dim ddlQnasPagadas As DropDownList = CType(wucAnioQnas1.FindControl("ddlQnasPagadas"), DropDownList)
        BindDatos(Request.Params("pCvePuestoCompuesta"), Request.Params("pCveZonaEco"), CShort(ddlQnasPagadas.SelectedValue))
    End Sub
End Class
