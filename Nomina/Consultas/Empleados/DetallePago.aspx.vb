Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Empleados
Partial Class Consultas_Empleados_DetallePago
    Inherits System.Web.UI.Page
    Private Sub BindSemestres()
        Dim oSem As New Semestre
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
            lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            lblEmpInf.Visible = True
            Me.pnlSemestres.Visible = True
        Else
            lblEmpInf.Text = String.Empty
            lblEmpInf.Visible = False
            Me.pnlSemestres.Visible = False
        End If
        Me.ddlSemestres.DataSource = oSem.ObtenSemestres
        Me.ddlSemestres.DataTextField = "Semestre"
        Me.ddlSemestres.DataValueField = "IdSemestre"
        Me.ddlSemestres.DataBind()
        If Me.ddlSemestres.Items.Count = 0 Then
            Me.ddlSemestres.Items.Insert(0, "No existe información de semestres")
            Me.ddlSemestres.Items(0).Value = -1
            Me.btnDetallePago.Enabled = False
        Else
            Me.btnDetallePago.Enabled = True
        End If
    End Sub
    Private Sub BindDetalleDePago()
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oEmp As New Empleado
        oEmp.RFC = hfRFC.Value
        Me.gvDetallePago.DataSource = oEmp.DetalleDePagoSemestral(CShort(Me.ddlSemestres.SelectedValue))
        Me.gvDetallePago.DataBind()
        pnl1.Visible = True
        pnl2.Visible = True
    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindSemestres()
        If Me.ddlSemestres.SelectedValue <> -1 Then BindDetalleDePago()
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
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindSemestres()
            If Me.ddlSemestres.SelectedValue <> -1 Then BindDetalleDePago()
        End If
    End Sub

    Protected Sub btnDetallePago_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindDetalleDePago()
    End Sub

    Protected Sub gvDetallePago_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDetallePago.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvDetallePago, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            If Request.Params(1).Contains("BtnSearch") Then
                If hfRFC.Value <> String.Empty Then
                    BindSemestres()
                    If Me.ddlSemestres.SelectedValue <> -1 Then BindDetalleDePago()
                    pnl1.Visible = True
                    pnl2.Visible = True
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                Me.pnl1.Visible = False
                Me.pnl2.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                Me.pnl1.Visible = True
                Me.pnl2.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindSemestres()
                    If Me.ddlSemestres.SelectedValue <> -1 Then BindDetalleDePago()
                    pnl1.Visible = True
                    pnl2.Visible = True
                End If
            End If
        End If
    End Sub
End Class
