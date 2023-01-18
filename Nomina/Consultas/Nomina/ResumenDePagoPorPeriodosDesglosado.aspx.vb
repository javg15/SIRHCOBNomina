﻿Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Partial Class Consultas_Nomina_ResumenDePagoPorPeriodosDesglosado
    Inherits System.Web.UI.Page
    Private Sub BindAnios()
        Dim oAnio As New Quincenas
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        With Me.ddlAnios
            .DataSource = oAnio.ObtenAñosParaConsultaDePagos(True)
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay años disponibles para consulta")
                .Items(0).Value = -1
                With Me.ddlQnaIni
                    .Items.Clear()
                    .Items.Insert(0, "(Vacío)")
                    .Items(0).Value = -1
                End With
                With Me.ddlQnaFin
                    .Items.Clear()
                    .Items.Insert(0, "(Vacío)")
                    .Items(0).Value = -1
                End With
                Me.btnConsultar.Enabled = False
            Else
                If hfRFC.Value.Trim = String.Empty Then
                    .Items.Clear()
                    .Items.Insert(0, "(Vacío)")
                    .Items(0).Value = -1
                    With Me.ddlQnaIni
                        .Items.Clear()
                        .Items.Insert(0, "(Vacío)")
                        .Items(0).Value = -1
                    End With
                    With Me.ddlQnaFin
                        .Items.Clear()
                        .Items.Insert(0, "(Vacío)")
                        .Items(0).Value = -1
                    End With
                    Me.btnConsultar.Enabled = False
                Else
                    BindddlQnaIni()
                    BindddlQnaFin()
                    BindPago()
                    Me.btnConsultar.Enabled = True
                End If
            End If
        End With
    End Sub
    Private Sub BindddlQnaIni()
        Dim oQna As New Quincenas
        With Me.ddlQnaIni
            .DataSource = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAnios.SelectedValue), False)
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            .SelectedIndex = ddlQnaIni.Items.Count - 1
        End With
    End Sub
    Private Sub BindddlQnaFin()
        Dim oQna As New Quincenas
        With Me.ddlQnaFin
            .DataSource = oQna.ObtenQnasFinParaPeriodoDeConsultaDePago(CShort(Me.ddlQnaIni.SelectedItem.Value))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
        End With
    End Sub
    Private Sub BindPago()
        Try
            Dim oEmp As New Empleado
            Dim dsEmpPago As DataSet
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            'Dim dt As DataTable
            Dim oNomina As New Devolucion
            Dim oNomina2 As New Recibos
            Dim RFCEmp As String = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

            Me.LblInfDeQna.Text = "Empleado: " + hfNomEmp.Value + "<br />" + "Periodo: " + Me.ddlQnaIni.SelectedItem.Text + " - " + Me.ddlQnaFin.SelectedItem.Text
            Me.LblInfDeQna.Visible = True
            Me.lbVistaNormal.Visible = True

            dsEmpPago = oEmp.ConsultaPagoAcumuladoPorPeriodoDesglosado(RFCEmp, CShort(Me.ddlQnaIni.SelectedValue), CShort(Me.ddlQnaFin.SelectedValue))

            Me.gvPercsNomina.DataSource = dsEmpPago.Tables(0)
            Me.gvDeducsNomina.DataSource = dsEmpPago.Tables(1)
            Me.dvTotalPercsNomina.DataSource = dsEmpPago.Tables(2)
            Me.dvTotalDeducsNomina.DataSource = dsEmpPago.Tables(3)
            Me.dvImporteNetoNomina.DataSource = dsEmpPago.Tables(4)

            Me.gvPercsRecibos.DataSource = dsEmpPago.Tables(5)
            Me.gvDeducsRecibos.DataSource = dsEmpPago.Tables(6)
            Me.dvTotalPercsRecibos.DataSource = dsEmpPago.Tables(7)
            Me.dvTotalDeducsRecibos.DataSource = dsEmpPago.Tables(8)
            Me.dvImporteNetoRecibos.DataSource = dsEmpPago.Tables(9)

            Me.gvPercsDevols.DataSource = dsEmpPago.Tables(10)
            Me.gvDeducsDevols.DataSource = dsEmpPago.Tables(11)
            Me.dvTotalPercsDevols.DataSource = dsEmpPago.Tables(12)
            Me.dvTotalDeducsDevols.DataSource = dsEmpPago.Tables(13)
            Me.dvImporteNetoDevols.DataSource = dsEmpPago.Tables(14)

            Me.gvPercs.DataSource = dsEmpPago.Tables(15)
            Me.gvDeducs.DataSource = dsEmpPago.Tables(16)
            Me.dvTotalesPercs.DataSource = dsEmpPago.Tables(17)
            Me.dvTotalesDeducs.DataSource = dsEmpPago.Tables(18)
            Me.dvTotales.DataSource = dsEmpPago.Tables(19)

            Me.gvPercsNomina.DataBind()
            Me.gvDeducsNomina.DataBind()
            Me.dvTotalPercsNomina.DataBind()
            Me.dvTotalDeducsNomina.DataBind()
            Me.dvImporteNetoNomina.DataBind()

            Me.gvPercsRecibos.DataBind()
            Me.gvDeducsRecibos.DataBind()
            Me.dvTotalPercsRecibos.DataBind()
            Me.dvTotalDeducsRecibos.DataBind()
            Me.dvImporteNetoRecibos.DataBind()

            Me.gvPercsDevols.DataBind()
            Me.gvDeducsDevols.DataBind()
            Me.dvTotalPercsDevols.DataBind()
            Me.dvTotalDeducsDevols.DataBind()
            Me.dvImporteNetoDevols.DataBind()

            Me.gvPercs.DataBind()
            Me.gvDeducs.DataBind()
            Me.dvTotalesPercs.DataBind()
            Me.dvTotalesDeducs.DataBind()
            Me.dvTotales.DataBind()

        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
    '        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
    '        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
    '        Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
    '        ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false")
    '    End If
    'End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindAnios()
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        System.Threading.Thread.Sleep(1000)
        BindPago()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindAnios()
        End If
    End Sub

    Protected Sub ddlAnios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindddlQnaIni()
        BindddlQnaFin()
    End Sub

    Protected Sub ddlQnaIni_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindddlQnaFin()
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Then
            If hfRFC.Value <> String.Empty Then
                BindAnios()
                pnl1.Visible = True
                pnl2.Visible = True
            End If
        ElseIf Request.Params(0).Contains("BtnNewSearch") Then
            Me.pnl1.Visible = False
            Me.pnl2.Visible = False
        ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
            Me.pnl1.Visible = True
            Me.pnl2.Visible = True
        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                BindAnios()
                pnl1.Visible = True
                pnl2.Visible = True
            End If
        End If
    End Sub
End Class
