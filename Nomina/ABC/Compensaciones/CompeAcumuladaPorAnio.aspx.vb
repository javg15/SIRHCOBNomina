Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class ABC_Compensaciones_CompeAcumuladaPorAnio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Dim oCompensacion As New Compensacion
            Dim oEmpleado As New Empleado
            Dim dt As DataTable
            Dim dr As DataRow = Nothing
            Dim lblImporteTotal As Label
            Dim dsEmpleados As DataTable
            Dim drEmpleado As DataRow
            Dim vlIdEmp As Integer

            If Request.Params("IdEmp") Is Nothing Then
                dsEmpleados = oCompensacion.BuscarEmpleadosPorNumEmp(Empleado.TipoBusqueda.NumeroDeEmpleado, Request.Params("NumEmp"), Request.Params("Origen"))
                drEmpleado = dsEmpleados.Rows(0)
                vlIdEmp = CInt(drEmpleado("IdEmp"))
            Else
                vlIdEmp = CInt(Request.Params("IdEmp"))
            End If

            Me.lblAño.Text = String.Empty
            If Request.Params("Origen") <> "EXTRAORDINARIO" Then
                dr = oEmpleado.BuscarPorId(vlIdEmp)
                Me.lblAño.Text = (dr("Nombre") + " " + dr("ApellidoPaterno") + " " + dr("ApellidoMaterno")).ToString.Trim + "<br />"
            Else
                dr = oEmpleado.BuscarPorId(vlIdEmp, Request.Params("Origen"))
                Me.lblAño.Text = (dr("Nombre") + " " + dr("ApellidoPaterno") + " " + dr("ApellidoMaterno")).ToString.Trim + "<br />"
            End If

            Me.lblAño.Text = Me.lblAño.Text + "Acumulado de compensaciones durante el año: " + Request.Params("Anio")
            With Me.gvHistoriaCompe
                dt = oCompensacion.ObtenAcumuladoPorEmp(vlIdEmp, CShort(Request.Params("Anio")), Request.Params("Origen"))
                .DataSource = dt
                .DataBind()
            End With

            If Me.gvHistoriaCompe.Rows.Count > 0 Then
                lblImporteTotal = CType(Me.gvHistoriaCompe.FooterRow.FindControl("lblImporteTotal"), Label)
                lblImporteTotal.Text = Format(dt.Compute("Sum(Importe)", ""), "$ ###,###,##0.00")
            End If

            CreaLinkParaImpresion(vlIdEmp)

            Me.lbCerrar.OnClientClick = "javascript:window.close();"
        End If
    End Sub
    Private Sub CreaLinkParaImpresion(pIdEmp As Integer)
        Me.ibImprimirEnPDF.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                        + "?Anio=" + Request.Params("Anio") _
                                        + "&IdEmp=" + pIdEmp.ToString _
                                        + "&Origen=" + Request.Params("Origen") _
                                        + "&IdReporte=93','CompeRecibosPorEmpAnio_" + Request.Params("Anio") + "_" + Request.Params("IdEmp") + "_" + Request.Params("Origen") + "'); return false;"

    End Sub
End Class
