Imports DataAccessLayer.COBAEV.Nominas
Imports System.Threading.Thread
Partial Class Consultas_Nomina_CapturaPercDeducAnt
    Inherits System.Web.UI.Page
    Private Sub BindQnas()
        Dim oQna As New Quincenas
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        With Me.ddlQnasAbiertasParaCaptura
            lblEmpInf.Text = String.Empty
            If hfRFC.Value.Trim <> String.Empty Or Not Session("RFCParaCons") Is Nothing Then
                lblEmpInf.Text = "Información relacionada con el empleado: " + _
                                IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value) + "<br />" + _
                                "Número de empleado: " + Session("NumEmpParaCons")
                lblEmpInf.Visible = True
                .DataSource = oQna.ObtenAbiertasParaCaptura()
                .DataTextField = "Quincena"
                .DataValueField = "IdQuincena"
                .DataBind()
                If .Items.Count > 0 Then
                    lblEmpInf.Text += ", quincena " + Me.ddlQnasAbiertasParaCaptura.SelectedItem.Text
                    ddlQnasAbiertasParaCaptura.Enabled = True
                    btnConsultarQna.Enabled = True
                    'BindDeducciones(hfRFC.Value)
                    'BidnPercepciones(hfRFC.Value)
                Else
                    lblEmpInf.Text = String.Empty
                    lblEmpInf.Visible = False
                    .Items.Clear()
                    .Items.Insert(0, "No hay quincenas abiertas")
                    .Items(0).Value = -1
                    ddlQnasAbiertasParaCaptura.Enabled = False
                    btnConsultarQna.Enabled = False
                End If
            Else
                lblEmpInf.Text = String.Empty
                lblEmpInf.Visible = False
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas abiertas")
                .Items(0).Value = -1
                ddlQnasAbiertasParaCaptura.Enabled = False
                btnConsultarQna.Enabled = False
            End If
        End With
    End Sub
    Private Sub BindDeducciones(ByVal RFCEmp As String)
        Dim oDeduccion As New Deduccion

        Me.lbAddPrestamoISSSTE.Visible = True

        With oDeduccion
            Me.gvDeducciones.DataSource = .ObtenCapturadasPorEmpleado(RFCEmp, CType(Me.ddlQnasAbiertasParaCaptura.SelectedValue, Short))
            Me.gvDeducciones.DataBind()
        End With
        Me.lbAgregarDeduccion.Visible = True
        Me.lbAgregarDeduccion.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonDeducCapturadas.aspx?TipoOperacion=1&RFCEmp=" + RFCEmp + _
                                "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "');"
        Me.lbAddPrestamoISSSTE.OnClientClick = "javascript:abreVentanaMediana('../../ABC/ISSSTE/AdmonPrestamosISSSTE.aspx?TipoOperacion=1&RFCEmp=" + RFCEmp + _
                                "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "');"

    End Sub
    Private Sub BidnPercepciones(ByVal RFCEmp As String)
        Dim oPercepcion As New Percepcion
        With oPercepcion
            Me.gvPercepciones.DataSource = .ObtenCapturadasPorEmpleado(RFCEmp, CType(Me.ddlQnasAbiertasParaCaptura.SelectedValue, Short))
            Me.gvPercepciones.DataBind()
        End With
        Me.lbAgregarPercepcion.Visible = True
        '        Me.lbAgregarPercepcion.Attributes.Add("onclick", "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=1&RFCEmp=" + RFCEmp + "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "&ValidacionAlCargarPagina=SI');")
        Me.lbAgregarPercepcion.Attributes.Add("onclick", "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=1&RFCEmp=" + RFCEmp + "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "');")
    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
    '        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
    '        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
    '        Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
    '        ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
    '    End If
    'End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindQnas()
        If Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "-1" Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            BindDeducciones(hfRFC.Value)
            BidnPercepciones(hfRFC.Value)
        End If
        'Sleep(500)
    End Sub

    Protected Sub gvDeducciones_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDeducciones.RowCommand
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        BindDeducciones(hfRFC.Value)
        'Sleep(500)
    End Sub

    Protected Sub gvDeducciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDeducciones.RowDataBound
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Select Case e.Row.RowType
            'Case DataControlRowType.EmptyDataRow, DataControlRowType.Footer
            '    Dim lbAgregarDeduccion As LinkButton = CType(e.Row.FindControl("lbAgregarDeduccion"), LinkButton)
            '    lbAgregarDeduccion.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonDeducCapturadas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + _
            '                                    "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "'); return false;"
            Case DataControlRowType.DataRow
                Dim lblIdDeduccion As Label = CType(e.Row.FindControl("lblIdDeduccion"), Label)
                Dim lblIdDeducCapturada As Label = CType(e.Row.FindControl("lblIdDeducCapturada"), Label)
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim lblVigIniDeduc As Label = CType(e.Row.FindControl("lblVigIniDeduc"), Label)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                ibEliminar.CommandArgument = e.Row.RowIndex
                If lblIdDeduccion.Text <> "31" Then 'Préstamo ISSSTE (Clave 431)
                    ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonDeducCapturadas.aspx?TipoOperacion=3" + _
                                                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                                                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text + "&RFCEmp=" + hfRFC.Value + "'); return false;"
                    ibEliminar.Enabled = (CType(Me.ddlQnasAbiertasParaCaptura.SelectedValue, Short) = CType(lblVigIniDeduc.Text, Short))
                    ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonDeducCapturadas.aspx?TipoOperacion=0&RFCEmp=" + hfRFC.Value + _
                                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                                "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + _
                                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text + "'); return false;"
                Else
                    Me.lbAddPrestamoISSSTE.Visible = False
                    ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/ISSSTE/AdmonPrestamosISSSTE.aspx?TipoOperacion=3" + _
                                                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                                                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text + "&RFCEmp=" + hfRFC.Value + "'); return false;"
                    ibEliminar.Enabled = (CType(Me.ddlQnasAbiertasParaCaptura.SelectedValue, Short) = CType(lblVigIniDeduc.Text, Short))
                    ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/ISSSTE/AdmonPrestamosISSSTE.aspx?TipoOperacion=0&RFCEmp=" + hfRFC.Value + _
                                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                                "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + _
                                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text + "'); return false;"
                End If
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvDeducciones, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvPercepciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercepciones.RowDataBound
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPercepcion As Label = CType(e.Row.FindControl("lblIdPercepcion"), Label)
                Dim lblIdPercCapturada As Label = CType(e.Row.FindControl("lblIdPercCapturada"), Label)
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim lblVigIniPerc As Label = CType(e.Row.FindControl("lblVigIniPerc"), Label)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                ibEliminar.CommandArgument = e.Row.RowIndex
                ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=3" + _
                                            "&IdPercCapturada=" + lblIdPercCapturada.Text + _
                                            "&IdPlaza=" + lblIdPlaza.Text + "&IdPercepcion=" + lblIdPercepcion.Text + "'); return false;"
                ibEliminar.Enabled = (CType(Me.ddlQnasAbiertasParaCaptura.SelectedValue, Short) = CType(lblVigIniPerc.Text, Short))
                ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=0&RFCEmp=" + hfRFC.Value + _
                            "&IdPercCapturada=" + lblIdPercCapturada.Text + _
                            "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + _
                            "&IdPlaza=" + lblIdPlaza.Text + "&IdPercepcion=" + lblIdPercepcion.Text + "'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPercepciones, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindQnas()
            If Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "-1" Then
                Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
                BindDeducciones(hfRFC.Value)
                BidnPercepciones(hfRFC.Value)
            End If
        End If
    End Sub

    Protected Sub btnConsultarQna_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        lblEmpInf.Text = "Información relacionada con el empleado: " + _
            IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + _
            Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value) + _
            ", quincena " + Me.ddlQnasAbiertasParaCaptura.SelectedItem.Text
        BindDeducciones(hfRFC.Value)
        BidnPercepciones(hfRFC.Value)
    End Sub

    Protected Sub gvPercepciones_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPercepciones.RowCommand
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        BidnPercepciones(hfRFC.Value)
        'Sleep(500)
    End Sub

    Protected Sub lbAgregarPercepcion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAgregarPercepcion.Click
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        BidnPercepciones(hfRFC.Value)
        'Sleep(500)
    End Sub

    Protected Sub lbAgregarDeduccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAgregarDeduccion.Click
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        BindDeducciones(hfRFC.Value)
        'Sleep(500)
    End Sub

    'Protected Sub WucBuscaEmpleados1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.Load
    '    If Request.Params(0).Contains("ibBuscarEmp") Or Request.Params(0).Contains("ibActualizar") Then
    '        BindQnas()
    '        If Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "-1" And Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "" Then
    '            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '            BindDeducciones(hfRFC.Value)
    '            BidnPercepciones(hfRFC.Value)
    '        End If
    '        'Sleep(500)
    '    Else
    '        If Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "-1" And Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "" Then
    '            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '            BindDeducciones(hfRFC.Value)
    '            BidnPercepciones(hfRFC.Value)
    '        End If
    '        'Sleep(500)
    '    End If
    'End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Then
            BindQnas()
            If hfRFC.Value <> String.Empty Then
                If Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "-1" And Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "" Then
                    BindDeducciones(hfRFC.Value)
                    BidnPercepciones(hfRFC.Value)
                    pnl1.Visible = True
                    pnl2.Visible = True
                End If
            End If
        ElseIf Request.Params(0).Contains("BtnNewSearch") Then
            Me.pnl1.Visible = False
            Me.pnl2.Visible = False
        ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
            Me.pnl1.Visible = True
            Me.pnl2.Visible = True
        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                BindQnas()
                If Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "-1" And Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "" Then
                    BindDeducciones(hfRFC.Value)
                    BidnPercepciones(hfRFC.Value)
                    pnl1.Visible = True
                    pnl2.Visible = True
                End If
            End If
        End If
    End Sub
End Class
