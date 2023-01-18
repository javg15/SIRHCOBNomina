Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Partial Class EjerciciosFiscalesAcumuladoPorEjercicioQna
    Inherits System.Web.UI.Page
    Private Sub BindddlAños()
        Dim oEjercicioFiscal As New EjercicioFiscal
        Dim dr, dr2 As DataRow
        Dim oUsr As New Usuario
        Dim drRolUsr As DataRow

        With Me.ddlAnios
            .DataSource = oEjercicioFiscal.ObtenAños()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, New ListItem("Sin ejercicios", "-1"))
                Me.btnConsultar.Enabled = False
                Me.btnGeneraAcumulado.Enabled = False
                Me.btnGeneraAcumulado.Text = "Generar acumulado"
                Me.btnGenerarDecAnual.Enabled = False
                Me.btnGenerarDecAnual.Text = "Generar declaración anual"
            Else
                oUsr.Login = Session("Login")
                drRolUsr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
                Me.btnConsultar.Enabled = True
                dr = oEjercicioFiscal.ObtenDetalles(CShort(Me.ddlAnios.SelectedValue))
                dr2 = oEjercicioFiscal.TieneAcumuladoAnual(CShort(Me.ddlAnios.SelectedValue))
                Me.btnGeneraAcumulado.Enabled = Not CType(dr("Concluido"), Boolean)
                Me.btnGeneraAcumulado.Text = "Generar acumulado " + Me.ddlAnios.SelectedItem.Text
                Me.btnGenerarDecAnual.Enabled = Not CType(dr("Concluido"), Boolean) And CInt(dr2("TotalRegistros")) > 0 And CBool(drRolUsr("CalculaDecAnual"))
                Me.btnGenerarDecAnual.Text = "Generar declaración anual " + Me.ddlAnios.SelectedItem.Text
            End If
        End With
    End Sub
    Private Sub BindgvQnas()
        Dim oEjercicioFiscal As New EjercicioFiscal
        With Me.gvQnas
            .DataSource = oEjercicioFiscal.ObtenQnas(CShort(Me.ddlAnios.SelectedValue))
            .DataBind()
        End With
        Me.lblEjercicio.Text = " " + Me.ddlAnios.SelectedValue
    End Sub
    Private Sub BindgvDetalle(Optional ByVal IdQuincena As Short = 0, Optional ByVal Quincena As String = "")
        Dim oEjercicioFiscal As New EjercicioFiscal
        Dim ds As DataSet
        Dim lblNominaNormal2, lblNominaRP2, lblCompe2, lblDevolPR2, lblDevolRP2, lblRecibosPR2, lblRecibosRP2 As Label
        Dim lblRecibosDevolPR2, lblRecibosDevolRP2, lblConceptosExtraParaDecAnual2, lblConceptosExtraParaDecAnualRP2, lblTotalPorClave2 As Label
        With Me.gvDetalle
            If IdQuincena = 0 Then
                Me.lblEjercicio2.Text = " " + Me.ddlAnios.SelectedValue
                ds = oEjercicioFiscal.ObtenAcumuladoPorAnio(CShort(Me.ddlAnios.SelectedValue))
                .DataSource = ds.Tables(0)
            Else
                Me.lblEjercicio2.Text = " " + Me.ddlAnios.SelectedValue + " (Quincena " + Quincena + ")"
                ds = oEjercicioFiscal.ObtenAcumuladoPorAnioQna(CShort(Me.ddlAnios.SelectedValue), IdQuincena)
                .DataSource = ds.Tables(0)
            End If
            .DataBind()
            If Me.gvDetalle.Rows.Count > 0 Then
                lblNominaNormal2 = CType(Me.gvDetalle.FooterRow.FindControl("lblNominaNormal2"), Label)
                lblNominaNormal2.Text = Format(ds.Tables(1).Compute("Sum(ImporteNominaNormal)", ""), "$ ###,###,##0.00")
                lblNominaRP2 = CType(Me.gvDetalle.FooterRow.FindControl("lblNominaRP2"), Label)
                lblNominaRP2.Text = Format(ds.Tables(1).Compute("Sum(ImporteNominaRP)", ""), "$ ###,###,##0.00")
                lblCompe2 = CType(Me.gvDetalle.FooterRow.FindControl("lblCompe2"), Label)
                lblCompe2.Text = Format(ds.Tables(1).Compute("Sum(ImporteCompe)", ""), "$ ###,###,##0.00")
                lblDevolPR2 = CType(Me.gvDetalle.FooterRow.FindControl("lblDevolPR2"), Label)
                lblDevolPR2.Text = Format(ds.Tables(1).Compute("Sum(ImporteDevolPR)", ""), "$ ###,###,##0.00")
                lblDevolRP2 = CType(Me.gvDetalle.FooterRow.FindControl("lblDevolRP2"), Label)
                lblDevolRP2.Text = Format(ds.Tables(1).Compute("Sum(ImporteDevolRP)", ""), "$ ###,###,##0.00")
                lblRecibosPR2 = CType(Me.gvDetalle.FooterRow.FindControl("lblRecibosPR2"), Label)
                lblRecibosPR2.Text = Format(ds.Tables(1).Compute("Sum(ImporteRecibosPR)", ""), "$ ###,###,##0.00")
                lblRecibosRP2 = CType(Me.gvDetalle.FooterRow.FindControl("lblRecibosRP2"), Label)
                lblRecibosRP2.Text = Format(ds.Tables(1).Compute("Sum(ImporteRecibosRP)", ""), "$ ###,###,##0.00")
                lblRecibosDevolPR2 = CType(Me.gvDetalle.FooterRow.FindControl("lblRecibosDevolPR2"), Label)
                lblRecibosDevolPR2.Text = Format(ds.Tables(1).Compute("Sum(ImporteRecibosDevolPR)", ""), "$ ###,###,##0.00")
                lblRecibosDevolRP2 = CType(Me.gvDetalle.FooterRow.FindControl("lblRecibosDevolRP2"), Label)
                lblRecibosDevolRP2.Text = Format(ds.Tables(1).Compute("Sum(ImporteRecibosDevolRP)", ""), "$ ###,###,##0.00")
                lblConceptosExtraParaDecAnual2 = CType(Me.gvDetalle.FooterRow.FindControl("lblConceptosExtraParaDecAnual2"), Label)
                lblConceptosExtraParaDecAnual2.Text = Format(ds.Tables(1).Compute("Sum(ImporteConceptosExtraParaDecAnual)", ""), "$ ###,###,##0.00")
                lblConceptosExtraParaDecAnualRP2 = CType(Me.gvDetalle.FooterRow.FindControl("lblConceptosExtraParaDecAnualRP2"), Label)
                lblConceptosExtraParaDecAnualRP2.Text = Format(ds.Tables(1).Compute("Sum(ImporteConceptosExtraParaDecAnualRP)", ""), "$ ###,###,##0.00")
                lblTotalPorClave2 = CType(Me.gvDetalle.FooterRow.FindControl("lblTotalPorClave2"), Label)
                lblTotalPorClave2.Text = Format(ds.Tables(1).Compute("Sum(TotalPorClave)", ""), "$ ###,###,##0.00")
            End If
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindddlAños()
            BindgvQnas()
            If Me.gvQnas.SelectedIndex = -1 Then
                Response.Expires = 0
                BindgvDetalle()
            End If
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If Me.ddlAnios.SelectedValue <> "-1" Then
            BindgvQnas()
            BindgvDetalle()
        End If
    End Sub

    Protected Sub gvQnas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQnas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvQnas, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvQnas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvQnas.SelectedIndexChanged
        Dim lblIdQuincena As Label = CType(gvQnas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(gvQnas.SelectedRow.FindControl("lblQuincena"), Label)
        BindgvDetalle(CShort(lblIdQuincena.Text), lblQuincena.Text)
    End Sub

    Protected Sub gvDetalle_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvDetalle, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub btnGeneraAcumulado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraAcumulado.Click
        Dim oEjercicioFiscal As New EjercicioFiscal
        oEjercicioFiscal.GeneraAcumulado(CShort(Me.ddlAnios.SelectedItem.Text), CType(Session("ArregloAuditoria"), String()))
        BindgvQnas()
        BindgvDetalle()
    End Sub

    Protected Sub ddlAnios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAnios.SelectedIndexChanged
        Dim oEjercicioFiscal As New EjercicioFiscal
        Dim dr, dr2 As DataRow
        Dim oUsr As New Usuario
        Dim drRolUsr As DataRow

        oUsr.Login = Session("Login")
        drRolUsr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        dr = oEjercicioFiscal.ObtenDetalles(CShort(Me.ddlAnios.SelectedValue))
        dr2 = oEjercicioFiscal.TieneAcumuladoAnual(CShort(Me.ddlAnios.SelectedValue))
        Me.btnGeneraAcumulado.Enabled = Not CType(dr("Concluido"), Boolean)
        Me.btnGeneraAcumulado.Text = "Generar acumulado " + Me.ddlAnios.SelectedItem.Text
        Me.btnGenerarDecAnual.Enabled = Not CBool(dr("Concluido")) And CInt(dr2("TotalRegistros")) > 0 And CBool(drRolUsr("CalculaDecAnual"))
        Me.btnGenerarDecAnual.Text = "Generar declaración anual " + Me.ddlAnios.SelectedItem.Text
    End Sub

    Protected Sub btnGenerarDecAnual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarDecAnual.Click
        Dim oEjercicioFiscal As New EjercicioFiscal
        oEjercicioFiscal.GeneraDeclaracionAnual(CShort(Me.ddlAnios.SelectedItem.Text), CType(Session("ArregloAuditoria"), String()))
    End Sub
End Class
