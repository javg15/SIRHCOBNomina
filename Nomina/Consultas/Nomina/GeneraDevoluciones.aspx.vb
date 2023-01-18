Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class Consultas_Nomina_GeneraDevoluciones
    Inherits System.Web.UI.Page
    Private Sub SetEnabledbtnGeneraDevolucion()
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim dt As DataTable
        Dim oNomina As New Devolucion
        Dim oQna As New Quincenas

        Me.btnGeneraDevolucion.Enabled = Not Me.ddlQnasPDev.SelectedValue = "-1"
        If Me.ddlQnas.SelectedValue = "-1" Then
            Me.btnGeneraDevolucion.Enabled = False
        Else
            dt = oNomina.ObtenSiExisteDevolucion(hfRFC.Value, CShort(Me.ddlQnas.SelectedValue))
            If dt.Rows.Count > 0 Then
                With Me.ddlQnasPDev
                    .Items.Clear()
                    .DataSource = dt
                    .DataTextField = "Quincena"
                    .DataValueField = "IdQuincena"
                    .DataBind()
                End With
                Me.btnGeneraDevolucion.Text = "Quincena devuelta"
                Me.btnGeneraDevolucion.Enabled = False
            Else
                With Me.ddlQnasPDev
                    .Items.Clear()
                    .DataSource = oQna.ObtenAbiertasParaCaptura()
                    .DataTextField = "Quincena"
                    .DataValueField = "IdQuincena"
                    .DataBind()
                End With
                Me.btnGeneraDevolucion.Text = "Genera devolución"
                Me.btnGeneraDevolucion.Enabled = True
            End If
        End If
    End Sub
    Private Sub BindDatos()

        Dim oQna As New Quincenas
        Dim RFCEmp As String
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim oNomina As New Devolucion
        Dim oUsr As New Usuario
        Dim dr As DataRow

        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        RFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        Me.ddlQnas.DataSource = oQna.ObtenQnasPagadasPorEmp(RFCEmp)
        Me.ddlQnasPDev.DataSource = oQna.ObtenAbiertasParaCaptura()
        Me.ddlQnas.DataTextField = "Quincena"
        Me.ddlQnas.DataValueField = "IdQuincena"
        Me.ddlQnasPDev.DataTextField = "Quincena"
        Me.ddlQnasPDev.DataValueField = "IdQuincena"
        If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
            lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            lblEmpInf.Visible = True
        Else
            lblEmpInf.Text = String.Empty
            lblEmpInf.Visible = False
        End If
        Me.ddlQnas.DataBind()
        Me.ddlQnasPDev.DataBind()
        pnl1.Visible = True
        pnl2.Visible = True
        If Me.ddlQnas.Items.Count = 0 Or Me.ddlQnas.SelectedValue = "-1" Then
            Me.ddlQnas.Items.Clear()
            Me.ddlQnas.Items.Insert(0, "No existen pagos registrados.")
            Me.ddlQnas.Items(0).Value = -1
            Me.btnConsultarPago.Enabled = False
            Me.btnGeneraDevolucion.Enabled = False
            If Me.ddlQnasPDev.Items.Count = 0 Then
                Me.ddlQnasPDev.Items.Insert(0, "No existen quincenas abiertas para captura.")
                Me.ddlQnasPDev.Items(0).Value = -1
            End If
        Else
            Me.btnConsultarPago.Enabled = True
            If Me.ddlQnasPDev.Items.Count = 0 Then
                Me.ddlQnasPDev.Items.Insert(0, "No existen quincenas abiertas para captura.")
                Me.ddlQnasPDev.Items(0).Value = -1
                Me.btnGeneraDevolucion.Enabled = False
            Else
                Me.btnGeneraDevolucion.Enabled = True
            End If
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
                Me.gvQuincenasAdeudo.DataSource = dsEmpPago.Tables(3)
                Me.gvQuincenasDevoluciones.DataSource = dsEmpPago.Tables(4)

                Me.btnGeneraDevolucion.Enabled = dsEmpPago.Tables(1).Rows.Count <> 0 And Me.ddlQnasPDev.SelectedValue <> "-1"
                Me.btnConsultarPago.Enabled = dsEmpPago.Tables(1).Rows.Count <> 0
            End If

            Me.gvPlazas.DataBind()
            Me.gvPercepciones.DataBind()
            Me.gvDeducciones.DataBind()
            Me.dvTotalPerc.DataBind()
            Me.dvTotalDeduc.DataBind()
            Me.dvNetoPagar.DataBind()
            Me.gvQuincenasAdeudo.DataBind()
            Me.gvQuincenasDevoluciones.DataBind()

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
            BindDatos()
            BindPago()
        End If
    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
        BindPago()
        SetEnabledbtnGeneraDevolucion()
    End Sub

    Protected Sub btnConsultarPago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarPago.Click
        BindPago()
        SetEnabledbtnGeneraDevolucion()
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
    Protected Sub btnGeneraDevolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraDevolucion.Click
        Try
            If btnGeneraDevolucion.Enabled Then
                Dim oNomina As New Devolucion
                Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
                oNomina.GeneraDevolucion(hfRFC.Value, CType(Me.ddlQnas.SelectedValue, Short), CType(Me.ddlQnasPDev.SelectedValue, Short), CType(Session("ArregloAuditoria"), String()))
                BindPago()
                SetEnabledbtnGeneraDevolucion()
            End If
        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            SetEnabledbtnGeneraDevolucion()
        End If
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Then
            If hfRFC.Value <> String.Empty Then
                BindDatos()
                BindPago()
                SetEnabledbtnGeneraDevolucion()
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
                SetEnabledbtnGeneraDevolucion()
                pnl1.Visible = True
                pnl2.Visible = True
            End If
        End If
    End Sub
End Class
