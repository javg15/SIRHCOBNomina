Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Partial Class Consultas_Nomina_EliminaPagos
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oQna As New Quincenas
        Dim RFCEmp As String
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        RFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        Me.ddlQnas.DataSource = oQna.ObtenAbiertasParaCaptura()
        Me.ddlQnas.DataTextField = "Quincena"
        Me.ddlQnas.DataValueField = "IdQuincena"
        If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
            lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            lblEmpInf.Visible = True
        Else
            lblEmpInf.Text = String.Empty
            lblEmpInf.Visible = False
        End If
        Me.ddlQnas.DataBind()
        If Me.ddlQnas.Items.Count = 0 Then
            Me.ddlQnas.Items.Insert(0, "No existen quincenas abiertas para captura.")
            Me.ddlQnas.Items(0).Value = -1
            Me.btnConsultarPago.Enabled = False
            Me.btnEliminar.Enabled = False
            Me.btnEliminarQnaCompleta.Enabled = False
        Else
            Me.btnConsultarPago.Enabled = True
            Me.btnEliminar.Enabled = True
            Me.btnEliminarQnaCompleta.Enabled = True
        End If
        Me.pnlQuincenas.Visible = True
    End Sub
    Private Sub BindPago()
        Try
            Dim oEmp As New Empleado
            Dim dsEmpPago As DataSet
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

            If Me.ddlQnas.SelectedValue <> -1 Then
                oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
                dsEmpPago = oEmp.ConsultaPagoQnal(CType(Me.ddlQnas.SelectedValue, Short))

                Me.gvPlazas.DataSource = dsEmpPago.Tables(0)
                Me.gvPercepciones.DataSource = dsEmpPago.Tables(1)
                Me.gvDeducciones.DataSource = dsEmpPago.Tables(2)
                Me.dvTotalPerc.DataSource = dsEmpPago.Tables(0)
                Me.dvTotalDeduc.DataSource = dsEmpPago.Tables(0)
                Me.dvNetoPagar.DataSource = dsEmpPago.Tables(0)
                'Me.gvDetallePago.DataSource = dsEmpPago.Tables(3)
                Me.gvQuincenasAdeudo.DataSource = dsEmpPago.Tables(3)
                Me.gvQuincenasDevoluciones.DataSource = dsEmpPago.Tables(4)

                Me.btnEliminar.Enabled = dsEmpPago.Tables(1).Rows.Count <> 0
                Me.btnConsultarPago.Enabled = dsEmpPago.Tables(1).Rows.Count <> 0
            End If

            Me.gvPlazas.DataBind()
            Me.gvPercepciones.DataBind()
            Me.gvDeducciones.DataBind()
            Me.dvTotalPerc.DataBind()
            Me.dvTotalDeduc.DataBind()
            Me.dvNetoPagar.DataBind()
            'Me.gvDetallePago.DataBind()
            Me.gvQuincenasAdeudo.DataBind()
            Me.gvQuincenasDevoluciones.DataBind()
            pnl1.Visible = True
            pnl2.Visible = True

            Me.lbDetallePago.Visible = Me.ddlQnas.SelectedValue <> -1
            lbDetallePago.OnClientClick = "javascript:abreVentMedAncha('DetallePago.aspx?TipoOperacion=4" + _
                            "&Adeudo=NO&IdQuincena=" + ddlQnas.SelectedValue + _
                            "&RFCEmp=" + oEmp.RFC + "'); return false;"

        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            'Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            'Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
            BindDatos()
            BindPago()
        End If
    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
        BindPago()
    End Sub

    Protected Sub btnConsultarPago_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindPago()
    End Sub

    Protected Sub gvQuincenasAdeudo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
                Dim lblIdQuincena As Label = CType(e.Row.FindControl("lblIdQuincena"), Label)
                Dim lbDetallePagoAdeudo As LinkButton = CType(e.Row.FindControl("lbDetallePagoAdeudo"), LinkButton)

                lbDetallePagoAdeudo.OnClientClick = "javascript:abreVentMedAncha('DetallePago.aspx?IdQuincenaAplicacion=" + Me.ddlQnas.SelectedValue + _
                                            "&TipoOperacion=4" + _
                                            "&Adeudo=SI&IdQuincena=" + lblIdQuincena.Text + _
                                            "&RFCEmp=" + IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons")) + "'); return false;"
        End Select
    End Sub

    Protected Sub gvQuincenasDevoluciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
                Dim lblIdQuincena As Label = CType(e.Row.FindControl("lblIdQuincena"), Label)
                Dim lbDetallePagoDevolucion As LinkButton = CType(e.Row.FindControl("lbDetallePagoDevolucion"), LinkButton)

                lbDetallePagoDevolucion.OnClientClick = "javascript:abreVentMedAncha('DetallePago.aspx?TipoOperacion=4" + _
                                            "&Devolucion=SI&IdQuincena=" + lblIdQuincena.Text + _
                                            "&RFCEmp=" + IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons")) + "'); return false;"
        End Select
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim oNom As New Nomina
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            oNom.EliminaPagoQuincenal(CType(Me.ddlQnas.SelectedValue, Short), hfRFC.Value, CType(Session("ArregloAuditoria"), String()))
            BindPago()
        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub

    'Protected Sub WucBuscaEmpleados1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.Load
    '    Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '    If hfRFC.Value.Trim <> String.Empty Then
    '        BindDatos()
    '        BindPago()
    '    Else
    '        Me.btnEliminarQnaCompleta.Enabled = False
    '        Me.btnEliminar.Enabled = False
    '        If Me.ddlQnas.Items.Count = 0 Or Me.ddlQnas.SelectedValue = "-1" Then
    '            Me.btnEliminarQnaCompleta.Enabled = False
    '        Else
    '            Me.btnEliminarQnaCompleta.Enabled = True
    '        End If
    '    End If
    'End Sub

    Protected Sub btnEliminarQnaCompleta_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim oNom As New Nomina
            oNom.EliminaPagoQuincenal(CType(Me.ddlQnas.SelectedValue, Short), CType(Session("ArregloAuditoria"), String()))
            BindPago()
        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Then
            If hfRFC.Value <> String.Empty Then
                BindDatos()
                BindPago()
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
                BindDatos()
                BindPago()
                pnl1.Visible = True
                pnl2.Visible = True
            End If
        End If
    End Sub
End Class
