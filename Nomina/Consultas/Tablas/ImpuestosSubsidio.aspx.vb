Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class Consultas_Tablas_ImpuestosSubsidio
    Inherits System.Web.UI.Page
    Private Sub SetPropertyVisibleGridView(pgvTablaImpuesto As Boolean, pgvTablaSubsidio As Boolean, pgvTablaImpuestoAnual As Boolean)
        gvTablaImpuesto.Visible = pgvTablaImpuesto
        gvTablaSubsidio.Visible = pgvTablaSubsidio
        gvTablaImpuestoAnual.Visible = pgvTablaImpuestoAnual
    End Sub
    Private Sub BindddlAños()
        Dim oEjercicioFiscal As New EjercicioFiscal

        With Me.ddlAnios
            .DataSource = oEjercicioFiscal.ObtenAños()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, New ListItem("Información no disponible", "-1"))
                btnConsultarTabla.Enabled = False
            End If
        End With
    End Sub

    Private Sub BindgvTabla()
        Dim oEjercFiscal As New EjercicioFiscal
        Dim dt As DataTable

        dt = oEjercFiscal.ObtenTablasImpuestosSubsidio(CShort(ddlAnios.SelectedValue), ddlTabla.SelectedValue)

        If dt.Rows.Count = 0 Then
            Select Case ddlTabla.SelectedValue
                Case "TQI"
                    lblInfTipoTabla.Text = "Tabla quincenal de impuestos, año: " + ddlAnios.SelectedItem.Text
                    gvTablaImpuesto.EmptyDataText = "No existen registros disponibles"
                    gvTablaImpuesto.DataBind()
                    SetPropertyVisibleGridView(True, False, False)
                Case "TMI"
                    lblInfTipoTabla.Text = "Tabla mensual de impuestos, año: " + ddlAnios.SelectedItem.Text
                    gvTablaImpuesto.EmptyDataText = "No existen registros disponibles"
                    gvTablaImpuesto.DataBind()
                    SetPropertyVisibleGridView(True, False, False)
                Case "TQS"
                    lblInfTipoTabla.Text = "Tabla quincenal subsidio para el empleo, año: " + ddlAnios.SelectedItem.Text
                    gvTablaSubsidio.EmptyDataText = "No existen registros disponibles"
                    gvTablaSubsidio.DataBind()
                    SetPropertyVisibleGridView(False, True, False)
                Case "TMS"
                    lblInfTipoTabla.Text = "Tabla mensual subsidio para el empleo, año: " + ddlAnios.SelectedItem.Text
                    gvTablaSubsidio.EmptyDataText = "No existen registros disponibles"
                    gvTablaSubsidio.DataBind()
                    SetPropertyVisibleGridView(False, True, False)
                Case "TAI"
                    lblInfTipoTabla.Text = "Tabla anual de impuestos, año: " + ddlAnios.SelectedItem.Text
                    gvTablaImpuestoAnual.EmptyDataText = "No existen registros disponibles"
                    gvTablaImpuestoAnual.DataBind()
                    SetPropertyVisibleGridView(False, False, True)
            End Select
        Else
            Select Case ddlTabla.SelectedValue
                Case "TQI"
                    lblInfTipoTabla.Text = "Tabla quincenal de impuestos, año: " + ddlAnios.SelectedItem.Text
                    gvTablaImpuesto.DataSource = dt
                    gvTablaImpuesto.DataBind()
                    SetPropertyVisibleGridView(True, False, False)
                Case "TMI"
                    lblInfTipoTabla.Text = "Tabla mensual de impuestos, año: " + ddlAnios.SelectedItem.Text
                    gvTablaImpuesto.DataSource = dt
                    gvTablaImpuesto.DataBind()
                    SetPropertyVisibleGridView(True, False, False)
                Case "TQS"
                    lblInfTipoTabla.Text = "Tabla quincenal subsidio para el empleo, año: " + ddlAnios.SelectedItem.Text
                    gvTablaSubsidio.DataSource = dt
                    gvTablaSubsidio.DataBind()
                    SetPropertyVisibleGridView(False, True, False)
                Case "TMS"
                    lblInfTipoTabla.Text = "Tabla mensual subsidio para el empleo, año: " + ddlAnios.SelectedItem.Text
                    gvTablaSubsidio.DataSource = dt
                    gvTablaSubsidio.DataBind()
                    SetPropertyVisibleGridView(False, True, False)
                Case "TAI"
                    lblInfTipoTabla.Text = "Tabla anual de impuestos, año: " + ddlAnios.SelectedItem.Text
                    gvTablaImpuestoAnual.DataSource = dt
                    gvTablaImpuestoAnual.DataBind()
                    SetPropertyVisibleGridView(False, False, True)
            End Select
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindddlAños()
            BindgvTabla()
        End If
    End Sub
    Protected Sub btnConsultarTabla_Click(sender As Object, e As System.EventArgs) Handles btnConsultarTabla.Click
        BindgvTabla()
    End Sub

    Protected Sub gvTablaImpuesto_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTablaImpuesto.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvTablaImpuesto, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvTablaSubsidio_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTablaSubsidio.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvTablaSubsidio, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvTablaImpuestoAnual_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTablaImpuestoAnual.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvTablaImpuestoAnual, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
End Class
