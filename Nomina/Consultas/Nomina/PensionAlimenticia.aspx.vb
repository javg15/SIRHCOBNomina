Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Partial Class ConsultasPensionAlimenticia
    Inherits System.Web.UI.Page
    Private Sub BindgvPensionados()
        Dim oEmp As New BeneficiariosPensionAlimenticia
        Dim RFCEmp As String
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim dt, dt2 As DataTable
        RFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
            oEmp.RFCEmp = RFCEmp
            dt = oEmp.ObtenBeneficiariosDePensionAlimenticia
            dt2 = oEmp.ObtenBeneficiariosDePensionAlimenticia(True)
            Me.gvPensionados.DataSource = dt
            Me.gvPensionados.DataBind()
            Me.gvPensionados2.DataSource = dt2
            Me.gvPensionados2.DataBind()
            lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            lblEmpInf.Visible = True
            lbAgregarNuevo.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPensionAlimenticia.aspx?TipoOperacion=1&RFCEmp=" + RFCEmp + "&ValidacionAlCargarPagina=SI');"
            lbAgregarNuevo.Visible = True
            gvPensionados.Enabled = True
            gvPensionados2.Enabled = True
            pnl1.Visible = True
            pnl2.Visible = True
            pnl3.Visible = True
        Else
            lblEmpInf.Text = String.Empty
            lblEmpInf.Visible = False
            lbAgregarNuevo.Visible = False
            pnl1.Visible = False
            pnl2.Visible = False
            pnl3.Visible = False
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            'Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            'Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
            BindgvPensionados()
        End If
    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindgvPensionados()
    End Sub

    Protected Sub gvPensionados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPensionados.RowDataBound
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdBeneficiario As Label = CType(e.Row.FindControl("lblIdBeneficiario"), Label)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibBaja As ImageButton = CType(e.Row.FindControl("ibBaja"), ImageButton)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPensionAlimenticia.aspx?TipoOperacion=0&IdBeneficiario=" + lblIdBeneficiario.Text + "&ValidacionAlCargarPagina=SI');"
                ibBaja.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPensionAlimenticia.aspx?TipoOperacion=6&IdBeneficiario=" + lblIdBeneficiario.Text + "&ValidacionAlCargarPagina=SI');"
                ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPensionAlimenticia.aspx?TipoOperacion=3&IdBeneficiario=" + lblIdBeneficiario.Text + "&ValidacionAlCargarPagina=SI');"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPensionados, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvPensionados2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPensionados2, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(0).Contains("BtnSearch") Then
                'If hfRFC.Value <> String.Empty Then
                If txtbxRFC.Text <> String.Empty Then
                    BindgvPensionados()
                    pnl1.Visible = True
                    pnl2.Visible = True
                    pnl3.Visible = True
                Else
                    pnl1.Visible = False
                    pnl2.Visible = False
                    pnl3.Visible = False
                End If
            ElseIf Request.Params(0).Contains("BtnNewSearch") Then
                'lbAgregarNuevo.Visible = False
                'gvPensionados.Enabled = False
                'gvPensionados2.Enabled = False
                pnl1.Visible = False
                pnl2.Visible = False
                pnl3.Visible = False
            ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
                pnl1.Visible = True
                pnl2.Visible = True
                pnl3.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindgvPensionados()
                    pnl1.Visible = True
                    pnl2.Visible = True
                    pnl3.Visible = True
                End If
            End If
            End If
    End Sub

    Protected Sub lbAgregarNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindgvPensionados()
    End Sub

    Protected Sub ibModificar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindgvPensionados()
    End Sub

    Protected Sub ibBaja_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindgvPensionados()
    End Sub

    Protected Sub ibEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindgvPensionados()
    End Sub
End Class
