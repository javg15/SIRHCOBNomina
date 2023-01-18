Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports System.Data
Partial Class MovsDePersonal_Puestos
    Inherits System.Web.UI.Page
    Private Sub BindDatos(ByVal pIdQuincena As Short)
        Dim oPuesto As New Puestos
        Dim dt As DataTable

        dt = oPuesto.GetVigentesPorQna(pIdQuincena)

        gvPuestos.DataSource = dt
        gvPuestos.DataBind()

        'tblHeader.Rows(0).Cells(0).Width = gvPuestos.Columns(0).ItemStyle.Width
    End Sub

    Protected Sub gvPuestos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPuestos.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lbNivSalarial As LinkButton = CType(e.Row.FindControl("lbNivSalarial"), LinkButton)
                Dim lblNivelSalarial As Label = CType(e.Row.FindControl("lblNivelSalarial"), Label)

                lbNivSalarial.Visible = lblNivelSalarial.Text <> "N/D"
                lblNivelSalarial.Visible = lblNivelSalarial.Text = "N/D"

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click
        Dim ddlQnasPagadas As DropDownList = CType(wucAnioQnas1.FindControl("ddlQnasPagadas"), DropDownList)
        Label1.Text = "Información obtenida con base en la quincena: " + ddlQnasPagadas.SelectedItem.Text
        Label1.Visible = True
        btnConsultar.Enabled = True
        BindDatos(CShort(ddlQnasPagadas.SelectedValue))
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then

            Dim ddlAños As DropDownList = CType(wucAnioQnas1.FindControl("ddlAños"), DropDownList)
            Dim ddlQnasPagadas As DropDownList = CType(wucAnioQnas1.FindControl("ddlQnasPagadas"), DropDownList)
            If ddlAños.SelectedValue = "-1" Or ddlQnasPagadas.SelectedValue = "-1" Then
                Label1.Visible = False
                btnConsultar.Enabled = False
                gvPuestos.DataBind()
            Else
                If ddlQnasPagadas.SelectedValue = "-1" Then
                    Label1.Visible = False
                    btnConsultar.Enabled = False
                    gvPuestos.DataBind()
                Else
                    Label1.Text = "Información obtenida con base en la quincena: " + ddlQnasPagadas.SelectedItem.Text
                    Label1.Visible = True
                    btnConsultar.Enabled = True
                    BindDatos(CShort(ddlQnasPagadas.SelectedValue))
                End If
            End If
        End If
    End Sub

    Protected Sub gvPuestos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPuestos.SelectedIndexChanged
        'Dim ddlQnasPagadas As DropDownList = CType(wucAnioQnas1.FindControl("ddlQnasPagadas"), DropDownList)
        'BindDatos(CShort(ddlQnasPagadas.SelectedValue))
    End Sub

    Protected Sub lbCantidadAut_Click(sender As Object, e As System.EventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, LinkButton).NamingContainer, GridViewRow)
        Dim vlCvePuestoCompuesta As String
        Dim vlCveZonaEco As String
        Dim ddlQnasPagadas As DropDownList = CType(wucAnioQnas1.FindControl("ddlQnasPagadas"), DropDownList)

        vlCvePuestoCompuesta = gvr.Cells(1).Text
        vlCveZonaEco = gvr.Cells(5).Text

        Response.Redirect("../Plazas/PlazasAutPorPuestoZonaEco.aspx?pCvePuestoCompuesta=" + vlCvePuestoCompuesta + "&pCveZonaEco=" + vlCveZonaEco + "&pIdQuincena=" + ddlQnasPagadas.SelectedValue + "&pQuincena=" + ddlQnasPagadas.SelectedItem.Text, True)
    End Sub

    Protected Sub lbNivSalarial_Click(sender As Object, e As System.EventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, LinkButton).NamingContainer, GridViewRow)
        Dim vlNivelSalarial As String
        Dim ddlQnasPagadas As DropDownList = CType(wucAnioQnas1.FindControl("ddlQnasPagadas"), DropDownList)

        vlNivelSalarial = CType(gvr.FindControl("lbNivSalarial"), LinkButton).Text
        Response.Redirect("../NivelesSalariales/NivelesSalarialesHistoria.aspx?pNivelSalarial=" + vlNivelSalarial + "&pIdQuincena=" + ddlQnasPagadas.SelectedValue + "&pQuincena=" + ddlQnasPagadas.SelectedItem.Text, True)
    End Sub
End Class
