Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Partial Class DifPorcDescClave434
    Inherits System.Web.UI.Page
    Private Sub BindgvHistoriaClave434()
        Dim oDeduc As New Deduccion
        gvHistoriaPorcDescClave434.DataSource = oDeduc.ObtenDiferentesPorcDescClave434()
        gvHistoriaPorcDescClave434.DataBind()
    End Sub
    Protected Sub gvHistoriaPorcDescClave434_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvHistoriaPorcDescClave434.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblPorcDesc As Label = CType(e.Row.FindControl("lblPorcDesc"), Label)
                Dim ibHistPorcDescPDF As ImageButton = CType(e.Row.FindControl("ibHistPorcDescPDF"), ImageButton)
                Dim ibHistPorcDescExcel As ImageButton = CType(e.Row.FindControl("ibHistPorcDescExcel"), ImageButton)

                lblPorcDesc.Text = lblPorcDesc.Text.Replace("%", "")

                Select Case e.Row.RowType
                    Case DataControlRowType.DataRow
                        ibHistPorcDescExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx?IdReporte=81&PorcDesc=" + lblPorcDesc.Text + "'," _
                                + "'EmpsExcelPorcDescClave434'); return false;"
                        ibHistPorcDescPDF.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx?IdReporte=81&PorcDesc=" + lblPorcDesc.Text + "'," _
                                + "'EmpsPDFPorcDescClave434'); return false;"
                End Select

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvHistoriaPorcDescClave434, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            BindgvHistoriaClave434()
        End If
    End Sub
End Class
