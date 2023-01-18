Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Empleados

Partial Class Herramientas_CalculadoraDeImpuestos
    Inherits System.Web.UI.Page
    Private Sub BindImpuesto()
        Dim oEmp As New Empleado
        Dim hfRFC As HiddenField = CType(Me.wucSearchEmps1.FindControl("hfRFC"), HiddenField)
        Dim dtImpuesto As DataTable

        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        'oEmp.IdEmp = 0

        txtbxBaseGravable.Text = "0"
        If oEmp.RFC <> String.Empty Then
            dtImpuesto = oEmp.ObtenUltimoSueldoMensualOrddinario(oEmp.RFC)
            If dtImpuesto.Rows.Count > 0 Then
                txtbxBaseGravable.Text = dtImpuesto.Rows(0).Item("UltSdoMenOrd").ToString
            End If
        End If
    End Sub

    Private Sub BindddlTipoImpuesto()
        Dim oNomina As New Nomina
        With ddlTipoImpuesto
            .DataSource = oNomina.GetTiposDeImpuesto()
            .DataTextField = "NombreImpuesto"
            .DataValueField = "IdTipoImpuesto"
            .DataBind()
        End With
    End Sub

    Private Sub BindddlTipoImpuesto2()
        Select Case Me.ddlTipoImpuesto.SelectedValue
            Case "1" 'Ley
                Me.txtbxBaseGravable.Enabled = False
                'Me.txtbxBaseGravable.Text = "0"
                Me.ddlImpMensualQnal.Enabled = True
                Me.txtbxDias.Enabled = False
                Me.txtbxDias.Text = "0"
            Case "2" 'Reglamento
                Me.txtbxBaseGravable.Enabled = True
                'Me.txtbxBaseGravable.Text = String.Empty
                Me.ddlImpMensualQnal.Enabled = False
                Me.txtbxDias.Enabled = True
                Me.txtbxDias.Text = String.Empty
        End Select
        Me.txtbxImpuestoCalculado.Text = "0"
        Me.txtbxImpuestoCalculado.ForeColor = Drawing.Color.Black
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            BindddlTipoImpuesto()
            BindImpuesto()
        End If
    End Sub
    Protected Sub ddlTipoImpuesto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoImpuesto.SelectedIndexChanged
        BindddlTipoImpuesto2()
    End Sub

    Protected Sub btnCalcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        Dim oNomina As New Nomina
        Dim dr As DataRow
        If Me.ddlTipoImpuesto.SelectedValue = "2" Then
            Me.txtbxImpuestoCalculado.ForeColor = Drawing.Color.Red
            Me.lblImpuesto_Subsidio.Text = "Impuesto"
            Me.txtbxImpuestoCalculado.Text = oNomina.CalculaImpuestoPorReglamento(CDec(Me.txtPercAGrav.Text), CDec(Me.txtbxBaseGravable.Text), CShort(Me.txtbxDias.Text))
        Else
            dr = oNomina.CalculaImpuestoPorLey(CDec(Me.txtPercAGrav.Text), Me.ddlImpMensualQnal.SelectedValue)
            Me.lblImpuesto_Subsidio.Text = dr("Impuesto_O_Subsidio").ToString
            Me.txtbxImpuestoCalculado.Text = dr("Importe").ToString
            If dr("Impuesto_O_Subsidio").ToString.Contains("Impuesto") Then
                Me.txtbxImpuestoCalculado.ForeColor = Drawing.Color.Red
            Else
                Me.txtbxImpuestoCalculado.ForeColor = Drawing.Color.Navy
            End If
        End If
    End Sub

    Protected Sub wucSearchEmps1_PreRender(sender As Object, e As System.EventArgs) Handles wucSearchEmps1.PreRender
        Dim hfRFC As HiddenField = CType(wucSearchEmps1.FindControl("hfRFC"), HiddenField)
        Dim oMetodoComun As New MetodosComunes
        Dim c As Control = oMetodoComun.GetPostBackControl(Page)

        If c Is Nothing Then Exit Sub
        If c.ID = "BtnSearch" Then
            If hfRFC.Value <> String.Empty Then
                BindImpuesto()
                BindddlTipoImpuesto2()
                pnlDatosParaImpuesto.Visible = True
            End If
        ElseIf c.ID = "BtnNewSearch" Then
            pnlDatosParaImpuesto.Visible = False
        ElseIf c.ID = "BtnCancelSearch" Then
            pnlDatosParaImpuesto.Visible = True
        ElseIf c.ID = "lnkbtnrfc" Then
            BindImpuesto()
            BindddlTipoImpuesto2()
            pnlDatosParaImpuesto.Visible = True
        End If
    End Sub
End Class
