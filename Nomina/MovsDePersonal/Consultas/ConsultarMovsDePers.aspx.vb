Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.MovsDePersonal
Partial Class ConsultarMovsDePers
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    'Private Sub BindgvPlazasHistoria()
    '    Dim oEmp As New Empleado
    '    Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
    '    Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
    '    Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '    Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
    '    oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
    '    oEmp.IdEmp = 0
    '    If oEmp.RFC <> String.Empty Then
    '        Me.gvMovsDePers.DataSource = oEmp.ObtenHistoria()
    '        If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
    '            Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
    '        Else
    '            Me.lblEmpInf.Text = String.Empty
    '        End If
    '        Me.gvMovsDePers.DataBind()
    '    End If
    'End Sub
    Private Sub BindgvMovsDePers()
        Dim oMovsDePers As New MovsDePersonal
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        If hfRFC.Value <> String.Empty Then
            Me.gvMovsDePers.DataSource = oMovsDePers.ObtenPorEmpleado(hfRFC.Value)
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            Else
                Me.lblEmpInf.Text = String.Empty
            End If
            Me.gvMovsDePers.DataBind()
            If gvMovsDePers.Rows.Count = 0 Then
                'gvMovsDePers.DataSource = Nothing
                gvMovsDePers.EmptyDataText = "El empleado no tiene movimientos de personal registrados."
                Me.gvMovsDePers.DataBind()
                'Me.gvMovsDePers.Visible = True
            End If
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindgvMovsDePers()
        End If
    End Sub

    Protected Sub gvMovsDePers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMovsDePers.RowDataBound
        'Dim oCadena As New Cadenas
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                'Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                'Dim lblMotGralBaja As Label = CType(e.Row.FindControl("lblMotGralBaja"), Label)
                'Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                'Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
                'Dim oEmpleadoPlaza As New EmpleadoPlazas
                'Dim drMotivoGeneralDeBajaPorPlaza As DataRow
                'Dim lblIdCadena As Label = CType(e.Row.FindControl("lblIdCadena"), Label)
                'Dim lbNumCadena As LinkButton = CType(e.Row.FindControl("lbNumCadena"), LinkButton)
                'Dim ddlCadenas As DropDownList = CType(e.Row.FindControl("ddlCadenas"), DropDownList)
                'Dim drCadena As DataRow
                'Dim lblTipoMov As Label = CType(e.Row.FindControl("lblTipoMov"), Label)
                'Dim ddlTipoMov As DropDownList = CType(e.Row.FindControl("ddlTipoMov"), DropDownList)
                'Dim lblNombramiento As Label = CType(e.Row.FindControl("lblOcupacion"), Label)
                'Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)

                'Dim drInfTitular As DataRow
                'Dim vlNomTitular As String


                'imgInfTitular.Visible = False
                'If lblNombramiento.Text = "I" Then
                '    imgInfTitular.Visible = True
                '    oEmpleadoPlaza.IdPlaza = CInt(lblIdPlaza.Text)
                '    drInfTitular = oEmpleadoPlaza.ObtenTitular()
                '    vlNomTitular = (drInfTitular("ApePatEmp") + " " + drInfTitular("ApeMatEmp") + " " + drInfTitular("NomEmp")).ToString.Trim
                '    If vlNomTitular = String.Empty Then
                '        vlNomTitular = "Información del titular no capturada."
                '    End If
                '    imgInfTitular.ToolTip = vlNomTitular
                'End If

                'drMotivoGeneralDeBajaPorPlaza = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(lblIdPlaza.Text))

                'lblMotGralBaja.Text = drMotivoGeneralDeBajaPorPlaza("DescMotGralBaja").ToString

                'drCadena = oCadena.ObtenSiPlazaEstaEnCadena(CInt(lblIdPlaza.Text))
                'lblIdCadena.Text = drCadena("IdCadena").ToString
                'lblTipoMov.Text = drCadena("TipoMov").ToString
                'If lbNumCadena Is Nothing = False Then
                '    lbNumCadena.Text = drCadena("NumCadena").ToString
                '    lbNumCadena.Visible = lblIdCadena.Text <> "-1"
                '    lbNumCadena.OnClientClick = "javascript:abreVentMediaScreen('CadenaMovsAsociados.aspx?TipoOperacion=4&IdCadena=" + lblIdCadena.Text + "','" + lblIdCadena.Text + "'); return false;"
                '    If CBool(oCadena.EstaAbiertaParaCaptura(CInt(lblIdCadena.Text)).Item("AbiertaParaCaptura")) = False And lblIdCadena.Text <> "-1" Then
                '        ibEditar.OnClientClick = "alert('Registro no se puede modificar, la cadena debe estar en el estatus de ABIERTA PARA CAPTURA.'); return false;"
                '    End If
                'Else
                '    LlenaDDL(ddlCadenas, "NumCadena", "IdCadena", oCadena.ObtenAbiertasPorUsr(Session("Login")))
                '    If CType(ddlCadenas.Items.FindByValue(drCadena("IdCadena").ToString), ListItem) Is Nothing Then
                '        ddlCadenas.Items.Add(New ListItem(drCadena("NumCadena").ToString, drCadena("IdCadena").ToString))
                '    End If
                '    ddlCadenas.SelectedValue = drCadena("IdCadena").ToString
                '    If CType(ddlTipoMov.Items.FindByValue(drCadena("TipoMov").ToString), ListItem) Is Nothing = False Then
                '        ddlTipoMov.SelectedValue = lblTipoMov.Text
                '    End If
                'End If

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    'Protected Sub ibEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim ibEditar As ImageButton = CType(sender, ImageButton)
    '    Dim Fila As GridViewRow = CType(ibEditar.NamingContainer, GridViewRow)

    '    Me.gvMovsDePers.EditIndex = Fila.RowIndex
    '    BindgvPlazasVigentes()
    'End Sub

    'Protected Sub ibGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim oCadena As New Cadenas
    '    Dim ibGuardar As ImageButton = CType(sender, ImageButton)
    '    Dim Fila As GridViewRow = CType(ibGuardar.NamingContainer, GridViewRow)
    '    Dim lblIdCadena As Label = CType(Fila.FindControl("lblIdCadena"), Label)
    '    Dim lblIdPlaza As Label = CType(Fila.FindControl("lblIdPlaza"), Label)
    '    Dim ddlCadenas As DropDownList = CType(Fila.FindControl("ddlCadenas"), DropDownList)
    '    Dim ddlTipoMov As DropDownList = CType(Fila.FindControl("ddlTipoMov"), DropDownList)

    '    oCadena.ActualizaMov(CInt(lblIdCadena.Text), CInt(ddlCadenas.SelectedValue), CInt(lblIdPlaza.Text), Session("Login"), ddlTipoMov.SelectedValue, CType(Session("ArregloAuditoria"), String()))

    '    Me.gvMovsDePers.EditIndex = -1
    '    BindgvPlazasVigentes()

    '    Me.gvPlazasHistoria.EditIndex = -1
    '    BindgvPlazasHistoria()
    'End Sub

    'Protected Sub ibCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim ibCancelar As ImageButton = CType(sender, ImageButton)
    '    Dim Fila As GridViewRow = CType(ibCancelar.NamingContainer, GridViewRow)

    '    Me.gvMovsDePers.EditIndex = -1
    '    BindgvPlazasVigentes()
    'End Sub

    'Protected Sub ibEditar_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim ibEditar As ImageButton = CType(sender, ImageButton)
    '    Dim Fila As GridViewRow = CType(ibEditar.NamingContainer, GridViewRow)

    '    Me.gvPlazasHistoria.EditIndex = Fila.RowIndex
    '    BindgvPlazasHistoria()
    'End Sub

    'Protected Sub ibGuardar_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim oCadena As New Cadenas
    '    Dim ibGuardar As ImageButton = CType(sender, ImageButton)
    '    Dim Fila As GridViewRow = CType(ibGuardar.NamingContainer, GridViewRow)
    '    Dim lblIdCadena As Label = CType(Fila.FindControl("lblIdCadena"), Label)
    '    Dim lblIdPlaza As Label = CType(Fila.FindControl("lblIdPlaza"), Label)
    '    Dim ddlCadenas As DropDownList = CType(Fila.FindControl("ddlCadenas"), DropDownList)
    '    Dim ddlTipoMov As DropDownList = CType(Fila.FindControl("ddlTipoMov"), DropDownList)

    '    oCadena.ActualizaMov(CInt(lblIdCadena.Text), CInt(ddlCadenas.SelectedValue), CInt(lblIdPlaza.Text), Session("Login"), ddlTipoMov.SelectedValue, CType(Session("ArregloAuditoria"), String()))

    '    Me.gvMovsDePers.EditIndex = -1
    '    BindgvPlazasVigentes()

    '    Me.gvPlazasHistoria.EditIndex = -1
    '    BindgvPlazasHistoria()
    'End Sub

    'Protected Sub ibCancelar_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim ibCancelar As ImageButton = CType(sender, ImageButton)
    '    Dim Fila As GridViewRow = CType(ibCancelar.NamingContainer, GridViewRow)

    '    Me.gvPlazasHistoria.EditIndex = -1
    '    BindgvPlazasHistoria()
    'End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    BindgvMovsDePers()
                    pnl1.Visible = True
                    'gvMovsDePers.Visible = True
                Else
                    pnl1.Visible = False
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                pnl1.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                pnl1.Visible = True
                'gvMovsDePers.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindgvMovsDePers()
                    pnl1.Visible = True
                    'gvMovsDePers.Visible = True
                End If
            End If
        End If
    End Sub
End Class
