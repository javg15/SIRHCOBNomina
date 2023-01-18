Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class Consultas_Nomina_Detallepago
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Dim oEmp As New Empleado
            Dim oQna As New Quincenas
            Dim QuincenaEsAdicional As Boolean = oQna.EsAdicional(CShort(Request.Params("IdQuincena"))).Item("QuincenaEsAdicional")
            Dim msj As String = "Información no disponible."
            Dim dt As DataTable = oEmp.ObtenSiCobroComoAdmvo_o_DocEnQna(Request.Params("RFCEmp").ToString, CShort(Request.Params("IdQuincena")))
            Dim vlIdEmpFuncion As Byte
            Dim ds As DataSet

            gvInfEmp.DataSource = oEmp.BuscarPorRFC(Request.Params("RFCEmp").ToString).Table
            gvInfEmp.DataBind()

            If QuincenaEsAdicional Then
                msj = "Información solo disponible para quincenas ordinarias."
            Else
                If dt.Rows.Count = 1 Then
                    vlIdEmpFuncion = dt.Rows(0).Item("IdEmpFuncion") 'Cobro como administrativo o docente
                Else
                    vlIdEmpFuncion = 3 'Cobro como administrativo y docente
                End If
                If vlIdEmpFuncion = 1 Then
                    msj = "Información disponible solo para empleados docentes."
                End If
            End If

            oEmp.RFC = Request.Params("RFCEmp").ToString
            If Request.Params("Adeudo") = "NO" Then
                Me.gvDetallePago.DataSource = oEmp.DetalleDePagoQnal(CShort(Request.Params("IdQuincena")))
                Me.gvDiasPagados.DataSource = oEmp.ObtenDiasPagadosPorQna(Request.Params("RFCEmp").ToString, CShort(Request.Params("IdQuincena")))
                ds = oEmp.ObtenHistoriaDetallePagoHoras(Request.Params("RFCEmp").ToString, CShort(Request.Params("IdQuincena")))
                Me.gvHistoriaDetallePagoHoras.DataSource = ds.Tables(0)
                Me.gvHistDetePagoHorasResumenPlazas.DataSource = ds.Tables(1)
            ElseIf Request.Params("Adeudo") = "SI" Then
                Me.gvDetallePago.DataSource = oEmp.DetalleDePagoQnalAdeudo(CShort(Request.Params("IdQuincena")), CShort(Request.Params("IdQuincenaAplicacion")))
                Me.gvDiasPagados.DataSource = oEmp.ObtenDiasPagadosPorQna(Request.Params("RFCEmp").ToString, CShort(Request.Params("IdQuincena")), CShort(Request.Params("IdQuincenaAplicacion")), True, False)
                ds = oEmp.ObtenHistoriaDetallePagoHoras(Request.Params("RFCEmp").ToString, CShort(Request.Params("IdQuincenaAplicacion")))
                Me.gvHistoriaDetallePagoHoras.DataSource = ds.Tables(0)
                Me.gvHistDetePagoHorasResumenPlazas.DataSource = ds.Tables(1)
            ElseIf Request.Params("Devolucion") = "SI" Then
                Me.gvDetallePago.DataSource = oEmp.DetalleDePagoQnalDevolucion(CShort(Request.Params("IdQuincena")))
                Me.gvDiasPagados.DataSource = oEmp.ObtenDiasPagadosPorQna(Request.Params("RFCEmp").ToString, CShort(Request.Params("IdQuincena")), CShort(Request.Params("IdQuincenaAplicacion")), False, True)
            End If
            Me.gvDetallePago.DataBind()
            If Me.gvDetallePago.Rows.Count = 0 Then
                Me.gvDetallePago.EmptyDataText = msj
                Me.gvDetallePago.DataBind()
            End If
            Me.gvDiasPagados.DataBind()
            If Me.gvDiasPagados.Rows.Count = 0 Then
                If vlIdEmpFuncion = 1 And QuincenaEsAdicional = True Then
                    msj = "Información no disponible."
                End If
                Me.gvDiasPagados.EmptyDataText = msj
                Me.gvDiasPagados.DataBind()
            End If
            Me.gvHistoriaDetallePagoHoras.DataBind()
            Me.gvHistDetePagoHorasResumenPlazas.DataBind()
            If Me.gvHistoriaDetallePagoHoras.Rows.Count = 0 Then
                Me.gvHistoriaDetallePagoHoras.EmptyDataText = msj
                Me.gvHistoriaDetallePagoHoras.DataBind()
                Me.gvHistDetePagoHorasResumenPlazas.EmptyDataText = msj
                Me.gvHistDetePagoHorasResumenPlazas.DataBind()
            End If
            Me.lbCerrar.OnClientClick = "javascript:window.close();"
        End If
    End Sub
End Class
