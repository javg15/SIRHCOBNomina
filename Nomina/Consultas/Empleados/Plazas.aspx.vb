Imports DataAccessLayer.COBAEV.Empleados
Partial Class Consultas_Empleados_Plazas
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        If oEmp.RFC <> String.Empty Then
            Me.gvDatosPlazas.DataSource = oEmp.ObtenPlazasVigentes()
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            Else
                Me.lblEmpInf.Text = String.Empty
            End If
            Me.gvDatosPlazas.DataBind()
            pnl1.Visible = True
        End If
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
        BindDatos()
    End Sub

    Protected Sub gvDatosPlazas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatosPlazas.RowDataBound
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim ibBaja As ImageButton = CType(e.Row.FindControl("ibBaja"), ImageButton)
                'ibBaja.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=2&IdPlaza=" + lblIdPlaza.Text + "');"
                ibBaja.PostBackUrl = "../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=2&IdPlaza=" + lblIdPlaza.Text
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub

    'Protected Sub WucBuscaEmpleados1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.Load
    '    BindDatos()
    'End Sub

    Protected Sub ibBaja_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindDatos()
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            If Request.Params(1).Contains("BtnSearch") Then
                If hfRFC.Value <> String.Empty Then
                    BindDatos()
                    pnl1.Visible = True
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                Me.pnl1.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                Me.pnl1.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindDatos()
                    pnl1.Visible = True
                End If
            End If
        End If
    End Sub
End Class
