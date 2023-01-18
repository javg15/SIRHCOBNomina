Imports DataAccessLayer.COBAEV.Empleados
Partial Class Consultas_Catalogos_DocsParaExpedientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oDoc As New Expediente
            With Me.gvDocs
                .DataSource = oDoc.ObtenDifTiposDeDocs()
                .DataBind()
            End With
            Me.ibVigSinDocExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx?IdReporte=65','EmpsVigSinExpExcel'); return false;"
            Me.ibVigSinDocPDF.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx?IdReporte=65','EmpsVigSinExpPDF'); return false;"
            Me.ibNoVigSinDocExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx?IdReporte=66','EmpsNoVigSinExpExcel'); return false;"
            Me.ibNoVigSinDocPDF.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx?IdReporte=66','EmpsNoVigSinExpPDF'); return false;"
        End If
    End Sub

    Protected Sub gvDocs_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDocs.RowDataBound
        Dim lblIdDocumento As Label = CType(e.Row.FindControl("lblIdDocumento"), Label)
        Dim ibVigSinDocExcel As ImageButton = CType(e.Row.FindControl("ibVigSinDocExcel"), ImageButton)
        Dim ibVigSinDocPDF As ImageButton = CType(e.Row.FindControl("ibVigSinDocPDF"), ImageButton)
        Dim ibNoVigSinDocExcel As ImageButton = CType(e.Row.FindControl("ibNoVigSinDocExcel"), ImageButton)
        Dim ibNoVigSinDocPDF As ImageButton = CType(e.Row.FindControl("ibNoVigSinDocPDF"), ImageButton)

        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                ibVigSinDocExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx?IdReporte=63&IdDocumento=" + lblIdDocumento.Text + "'," _
                        + "'EmpsVigSinDocExcel_" + lblIdDocumento.Text + "'); return false;"
                ibVigSinDocPDF.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx?IdReporte=63&IdDocumento=" + lblIdDocumento.Text + "'," _
                        + "'EmpsVigSinDocPDF_" + lblIdDocumento.Text + "'); return false;"
                ibNoVigSinDocExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx?IdReporte=64&IdDocumento=" + lblIdDocumento.Text + "'," _
                        + "'EmpsNoVigSinDocExcel_" + lblIdDocumento.Text + "'); return false;"
                ibNoVigSinDocPDF.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx?IdReporte=64&IdDocumento=" + lblIdDocumento.Text + "'," _
                        + "'EmpsNoVigSinDocPDF_" + lblIdDocumento.Text + "'); return false;"
        End Select
    End Sub
End Class
