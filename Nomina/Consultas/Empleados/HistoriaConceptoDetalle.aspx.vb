Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class Consultas_Emps_HistoriaConceptoDetalle
    Inherits System.Web.UI.Page
    Private Sub BindddlAños()
        Dim oEjercicioFiscal As New EjercicioFiscal
        With Me.ddlAños
            .DataSource = oEjercicioFiscal.ObtenAños()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, New ListItem("No existe información de ejercicios", "-1"))
            Else
                .SelectedValue = Request.Params("Ejercicio").ToString
            End If
        End With
    End Sub
    Private Sub BindgvDetalleConcepto()
        Dim oEmp As New Empleado
        Dim oPerc As New Percepcion
        Dim oDeduc As New Deduccion
        Dim drPerc, drDeduc As DataRow

        Me.gvDetalleConcepto.DataSource = oEmp.ObtenHistConceptoDetallePorEjerc(Request.Params("RFCEmp").ToString, Request.Params("IdConcepto").ToString, Request.Params("TipoConcepto").ToString, CShort(Me.ddlAños.SelectedValue))
        Me.gvDetalleConcepto.DataBind()
        Me.lblEmpInf.Text = "Información relacionada con el empleado: " + Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons") + _
                            "<br /> Ejercicio: " + Me.ddlAños.SelectedItem.Text
        If Request.Params("TipoConcepto").ToString = "P" Then
            oPerc.IdPercepcion = CShort(Request.Params("IdConcepto").ToString)
            drPerc = oPerc.ObtenPorId()
            Me.lblInfConcepto.Text = "Clave " + drPerc("ClavePercepcion") + ", " + drPerc("NombrePercepcion")
        Else
            oDeduc.IdDeduccion = CShort(Request.Params("IdConcepto").ToString)
            drDeduc = oDeduc.ObtenPorId()
            Me.lblInfConcepto.Text = "Clave " + drDeduc("ClaveDeduccion") + ", " + drDeduc("NombreDeduccion")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            BindddlAños()
            BindgvDetalleConcepto()
            Me.lbCerrar.OnClientClick = "javascript:window.close();"
        End If
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindgvDetalleConcepto()
    End Sub

    Protected Sub gvDetalleConcepto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvDetalleConcepto, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
End Class
