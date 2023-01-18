Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports DataAccessLayer.COBAEV.Plazas
Partial Class OrdenesDePresPorPlaza
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindgvPlazasHistoria()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        If oEmp.RFC <> String.Empty Then
            Me.gvPlazasHistoria.DataSource = oEmp.ObtenHistoria()
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            Else
                Me.lblEmpInf.Text = String.Empty
            End If
            Me.gvPlazasHistoria.DataBind()
        End If
    End Sub
    Private Sub BindgvPlazasVigentes()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        If oEmp.RFC <> String.Empty Then
            Me.gvPlazasVigentes.DataSource = oEmp.ObtenPlazasVigentes()
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            Else
                Me.lblEmpInf.Text = String.Empty
            End If
            Me.gvPlazasVigentes.DataBind()
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
        Me.gvPlazasVigentes.EditIndex = -1
        BindgvPlazasVigentes()
        Me.gvPlazasHistoria.EditIndex = -1
        BindgvPlazasHistoria()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindgvPlazasVigentes()
            BindgvPlazasHistoria()
        End If
    End Sub

    Protected Sub gvPlazasVigentes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim oCadena As New Cadenas
        Dim oOrdPres As New OrdenesDePresentacion
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim lblMotGralBaja As Label = CType(e.Row.FindControl("lblMotGralBaja"), Label)
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
                Dim oEmpleadoPlaza As New EmpleadoPlazas
                Dim drMotivoGeneralDeBajaPorPlaza As DataRow
                Dim lblIdOrdenDePres As Label = CType(e.Row.FindControl("lblIdOrdenDePres"), Label)
                Dim lbNumOrdPres As LinkButton = CType(e.Row.FindControl("lbNumOrdPres"), LinkButton)
                Dim ddlOPs As DropDownList = CType(e.Row.FindControl("ddlOPs"), DropDownList)
                Dim drCadPlaza As DataRow
                Dim drOrdPres As DataRow
                Dim lblTipoMov As Label = CType(e.Row.FindControl("lblTipoMov"), Label)
                Dim ddlTipoMov As DropDownList = CType(e.Row.FindControl("ddlTipoMov"), DropDownList)
                Dim lblIdCadena As Label = CType(e.Row.FindControl("lblIdCadena"), Label)
                Dim lbNumCadena As LinkButton = CType(e.Row.FindControl("lbNumCadena"), LinkButton)
                Dim lblNombramiento As Label = CType(e.Row.FindControl("lblOcupacion"), Label)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim vlCategoEsDocHomooAdmva As Boolean
                Dim oPlaza As New TipoOcupacion
                Dim drInfTitular As DataRow
                Dim vlNomTitular As String

                imgInfTitular.Visible = False
                If lblNombramiento.Text = "I" Then
                    imgInfTitular.Visible = True
                    oEmpleadoPlaza.IdPlaza = CInt(lblIdPlaza.Text)
                    drInfTitular = oEmpleadoPlaza.ObtenTitular()
                    vlNomTitular = (drInfTitular("ApePatEmp") + " " + drInfTitular("ApeMatEmp") + " " + drInfTitular("NomEmp")).ToString.Trim
                    If vlNomTitular = String.Empty Then
                        vlNomTitular = "Información del titular no capturada."
                    End If
                    imgInfTitular.ToolTip = vlNomTitular
                End If

                drMotivoGeneralDeBajaPorPlaza = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(lblIdPlaza.Text))

                lblMotGralBaja.Text = drMotivoGeneralDeBajaPorPlaza("DescMotGralBaja").ToString

                drOrdPres = oCadena.ObtenInfOrdDePresDePlaza(CInt(lblIdPlaza.Text))
                drCadPlaza = oCadena.ObtenSiPlazaEstaEnCadena2(CInt(drOrdPres("IdOrdenDePres").ToString))

                vlCategoEsDocHomooAdmva = CBool(oPlaza.ObtenSiCategoAsocEsDocHomooAdmva(CInt(lblIdPlaza.Text)).Item("CategoEsDocHomooAdmva"))

                lblIdCadena.Text = drCadPlaza("IdCadena").ToString
                lbNumCadena.Text = drCadPlaza("NumCadena").ToString
                lbNumCadena.Visible = drCadPlaza("IdCadena") <> "-1"
                lbNumCadena.OnClientClick = "javascript:abreVentMediaScreen('../Cadenas/CadenaMovsAsociados.aspx?TipoOperacion=4&IdCadena=" + lblIdCadena.Text + "','" + lblIdCadena.Text + "'); return false;"
                'lblIdOrdenDePres.Text = drCadPlaza("IdOrdenDePres").ToString
                lblIdOrdenDePres.Text = drOrdPres("IdOrdenDePres").ToString
                lblTipoMov.Text = drCadPlaza("TipoMov").ToString
                If lbNumOrdPres Is Nothing = False Then
                    'lbNumOrdPres.Text = drCadPlaza("NumOrdPres").ToString
                    lbNumOrdPres.Text = drOrdPres("NumOrdPres").ToString
                    lbNumOrdPres.Visible = lblIdOrdenDePres.Text <> "0"
                    If lblIdOrdenDePres.Text <> "0" And lblNombramiento.Text = "I" Then
                        lbNumOrdPres.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?IdOrdenDePres=" + lblIdOrdenDePres.Text + "&IdReporte=75','OP_" + lblIdOrdenDePres.Text + "'); return false;"
                    ElseIf lblIdOrdenDePres.Text <> "0" And (lblNombramiento.Text = "P") Then
                        lbNumOrdPres.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?IdOrdenDePres=" + lblIdOrdenDePres.Text + "&IdReporte=76','OP_" + lblIdOrdenDePres.Text + "'); return false;"
                    End If
                    'If lblTipoMov.Text <> "A" Then
                    '    ibEditar.OnClientClick = "alert('Registro no se puede modificar, solo se puede asignar orden de presentación a movimientos de alta.'); return false;"
                    If lblIdOrdenDePres.Text <> "0" Then
                        ibEditar.OnClientClick = "alert('Registro no se puede modificar, ya tiene una órden de presentación asociada.'); return false;"
                    ElseIf vlCategoEsDocHomooAdmva = False Then
                        ibEditar.OnClientClick = "alert('Registro no se puede modificar, solo se pueden asignar órdenes de presentación por plaza a categorías Docentes Homologadas o Administrativas.'); return false;"
                    ElseIf lblNombramiento.Text = "B" Or lblNombramiento.Text = "C" Then
                        ibEditar.OnClientClick = "alert('Registro no se puede modificar, NO se pueden asignar órdenes de presentación por plaza a nombramientos de BASE/CONFIANZA.'); return false;"
                    End If
                    'Else 'Cuando se entraba en modo edición
                    'LlenaDDL(ddlOPs, "NumOrdPres", "IdOrdenDePres", oOrdPres.ObtenAbiertasPorUsr(Session("Login")))
                    'If CType(ddlOPs.Items.FindByValue(drCadPlaza("IdOrdenDePres").ToString), ListItem) Is Nothing Then
                    '    ddlOPs.Items.Add(New ListItem(drCadPlaza("NumOrdPres").ToString, drCadPlaza("IdOrdenDePres").ToString))
                    'End If
                    'ddlOPs.SelectedValue = drCadPlaza("IdOrdenDePres").ToString
                    'If CType(ddlTipoMov.Items.FindByValue(drCadPlaza("TipoMov").ToString), ListItem) Is Nothing = False Then
                    '    ddlTipoMov.SelectedValue = lblTipoMov.Text
                    'End If
                End If

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvPlazasHistoria_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazasHistoria.RowDataBound
        Dim oCadena As New Cadenas
        Dim oOrdPres As New OrdenesDePresentacion
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim lblMotGralBaja As Label = CType(e.Row.FindControl("lblMotGralBaja"), Label)
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
                Dim lblIdOrdenDePres As Label = CType(e.Row.FindControl("lblIdOrdenDePres"), Label)
                Dim lbNumOrdPres As LinkButton = CType(e.Row.FindControl("lbNumOrdPres"), LinkButton)
                Dim ddlOPs As DropDownList = CType(e.Row.FindControl("ddlOPs"), DropDownList)
                Dim drCadPlaza As DataRow
                Dim drOrdPres As DataRow
                Dim lblTipoMov As Label = CType(e.Row.FindControl("lblTipoMov"), Label)
                Dim ddlTipoMov As DropDownList = CType(e.Row.FindControl("ddlTipoMov"), DropDownList)
                Dim lblIdCadena As Label = CType(e.Row.FindControl("lblIdCadena"), Label)
                Dim lbNumCadena As LinkButton = CType(e.Row.FindControl("lbNumCadena"), LinkButton)
                Dim lblNombramiento As Label = CType(e.Row.FindControl("lblOcupacion"), Label)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim vlCategoEsDocHomooAdmva As Boolean
                Dim oPlaza As New TipoOcupacion

                Dim oEmpleadoPlaza As New EmpleadoPlazas
                Dim drMotivoGeneralDeBajaPorPlaza As DataRow
                Dim drInfTitular As DataRow
                Dim vlNomTitular As String

                imgInfTitular.Visible = False
                If lblNombramiento.Text = "I" Then
                    imgInfTitular.Visible = True
                    oEmpleadoPlaza.IdPlaza = CInt(lblIdPlaza.Text)
                    drInfTitular = oEmpleadoPlaza.ObtenTitular()
                    vlNomTitular = (drInfTitular("ApePatEmp") + " " + drInfTitular("ApeMatEmp") + " " + drInfTitular("NomEmp")).ToString.Trim
                    If vlNomTitular = String.Empty Then
                        vlNomTitular = "Información del titular no capturada."
                    End If
                    imgInfTitular.ToolTip = vlNomTitular
                End If

                drMotivoGeneralDeBajaPorPlaza = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(lblIdPlaza.Text))

                lblMotGralBaja.Text = drMotivoGeneralDeBajaPorPlaza("DescMotGralBaja").ToString

                drOrdPres = oCadena.ObtenInfOrdDePresDePlaza(CInt(lblIdPlaza.Text))
                drCadPlaza = oCadena.ObtenSiPlazaEstaEnCadena2(CInt(drOrdPres("IdOrdenDePres").ToString))

                vlCategoEsDocHomooAdmva = CBool(oPlaza.ObtenSiCategoAsocEsDocHomooAdmva(CInt(lblIdPlaza.Text)).Item("CategoEsDocHomooAdmva"))

                lblIdCadena.Text = drCadPlaza("IdCadena").ToString
                lbNumCadena.Text = drCadPlaza("NumCadena").ToString
                lbNumCadena.Visible = drCadPlaza("IdCadena") <> "-1"
                lbNumCadena.OnClientClick = "javascript:abreVentMediaScreen('../Cadenas/CadenaMovsAsociados.aspx?TipoOperacion=4&IdCadena=" + lblIdCadena.Text + "','" + lblIdCadena.Text + "'); return false;"
                'lblIdOrdenDePres.Text = drCadPlaza("IdOrdenDePres").ToString
                lblIdOrdenDePres.Text = drOrdPres("IdOrdenDePres").ToString
                lblTipoMov.Text = drCadPlaza("TipoMov").ToString
                If lbNumOrdPres Is Nothing = False Then
                    'lbNumOrdPres.Text = drCadPlaza("NumOrdPres").ToString
                    lbNumOrdPres.Text = drOrdPres("NumOrdPres").ToString
                    lbNumOrdPres.Visible = lblIdOrdenDePres.Text <> "0"
                    If lblIdOrdenDePres.Text <> "0" And lblNombramiento.Text = "I" Then
                        lbNumOrdPres.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?IdOrdenDePres=" + lblIdOrdenDePres.Text + "&IdReporte=75','OP_" + lblIdOrdenDePres.Text + "'); return false;"
                    ElseIf lblIdOrdenDePres.Text <> "0" And (lblNombramiento.Text = "P") Then
                        lbNumOrdPres.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?IdOrdenDePres=" + lblIdOrdenDePres.Text + "&IdReporte=76','OP_" + lblIdOrdenDePres.Text + "'); return false;"
                    End If
                    'If lblTipoMov.Text <> "A" Then
                    '    ibEditar.OnClientClick = "alert('Registro no se puede modificar, solo se puede asignar orden de presentación a movimientos de alta.'); return false;"
                    'Else
                    If lblIdOrdenDePres.Text <> "0" Then
                        ibEditar.OnClientClick = "alert('Registro no se puede modificar, ya tiene una órden de presentación asociada.'); return false;"
                    ElseIf vlCategoEsDocHomooAdmva = False Then
                        ibEditar.OnClientClick = "alert('Registro no se puede modificar, solo se pueden asignar órdenes de presentación por plaza a categorías Docentes Homologadas o Administrativas.'); return false;"
                    ElseIf lblNombramiento.Text = "B" Or lblNombramiento.Text = "C" Then
                        ibEditar.OnClientClick = "alert('Registro no se puede modificar, NO se pueden asignar órdenes de presentación por plaza a nombramientos de BASE/CONFIANZA.'); return false;"
                    End If
                    'Else 'Cuando se entraba en modo edición
                    '    LlenaDDL(ddlOPs, "NumOrdPres", "IdOrdenDePres", oOrdPres.ObtenAbiertasPorUsr(Session("Login")))
                    '    If CType(ddlOPs.Items.FindByValue(drCadPlaza("IdOrdenDePres").ToString), ListItem) Is Nothing Then
                    '        ddlOPs.Items.Add(New ListItem(drCadPlaza("NumOrdPres").ToString, drCadPlaza("IdOrdenDePres").ToString))
                    '    End If
                    '    ddlOPs.SelectedValue = drCadPlaza("IdOrdenDePres").ToString
                    '    If CType(ddlTipoMov.Items.FindByValue(drCadPlaza("TipoMov").ToString), ListItem) Is Nothing = False Then
                    '        ddlTipoMov.SelectedValue = lblTipoMov.Text
                    '    End If
                End If

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub ibEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim vlIdOrdDePres As Integer
        Dim oOrdPres As New OrdenesDePresentacion
        Dim ibEditar As ImageButton = CType(sender, ImageButton)
        Dim Fila As GridViewRow = CType(ibEditar.NamingContainer, GridViewRow)
        Dim lblIdCadena As Label = CType(Fila.FindControl("lblIdCadena"), Label)
        Dim lblIdPlaza As Label = CType(Fila.FindControl("lblIdPlaza"), Label)
        Dim lblIdOrdenDePres As Label = CType(Fila.FindControl("lblIdOrdenDePres"), Label)

        If lblIdOrdenDePres.Text = "0" Then
            vlIdOrdDePres = oOrdPres.GeneraNueva(Session("Login"), CType(Session("ArregloAuditoria"), String()))

            oOrdPres.AsociaAPlaza(CInt(lblIdPlaza.Text), vlIdOrdDePres, CType(Session("ArregloAuditoria"), String()))

            BindgvPlazasVigentes()
            BindgvPlazasHistoria()
        End If
    End Sub

    Protected Sub ibGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oCadena As New Cadenas
        Dim ibGuardar As ImageButton = CType(sender, ImageButton)
        Dim Fila As GridViewRow = CType(ibGuardar.NamingContainer, GridViewRow)
        Dim lblIdCadena As Label = CType(Fila.FindControl("lblIdCadena"), Label)
        Dim lblIdPlaza As Label = CType(Fila.FindControl("lblIdPlaza"), Label)
        Dim ddlCadenas As DropDownList = CType(Fila.FindControl("ddlCadenas"), DropDownList)
        Dim ddlTipoMov As DropDownList = CType(Fila.FindControl("ddlTipoMov"), DropDownList)

        oCadena.ActualizaMov(CInt(lblIdCadena.Text), CInt(ddlCadenas.SelectedValue), CInt(lblIdPlaza.Text), Session("Login"), ddlTipoMov.SelectedValue, CType(Session("ArregloAuditoria"), String()))

        Me.gvPlazasVigentes.EditIndex = -1
        BindgvPlazasVigentes()

        Me.gvPlazasHistoria.EditIndex = -1
        BindgvPlazasHistoria()
    End Sub

    Protected Sub ibCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ibCancelar As ImageButton = CType(sender, ImageButton)
        Dim Fila As GridViewRow = CType(ibCancelar.NamingContainer, GridViewRow)

        Me.gvPlazasVigentes.EditIndex = -1
        BindgvPlazasVigentes()
    End Sub

    Protected Sub ibEditar_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim vlIdOrdDePres As Integer
        Dim oOrdPres As New OrdenesDePresentacion
        Dim ibEditar As ImageButton = CType(sender, ImageButton)
        Dim Fila As GridViewRow = CType(ibEditar.NamingContainer, GridViewRow)
        Dim lblIdCadena As Label = CType(Fila.FindControl("lblIdCadena"), Label)
        Dim lblIdPlaza As Label = CType(Fila.FindControl("lblIdPlaza"), Label)
        Dim lblIdOrdenDePres As Label = CType(Fila.FindControl("lblIdOrdenDePres"), Label)

        If lblIdOrdenDePres.Text = "0" Then
            vlIdOrdDePres = oOrdPres.GeneraNueva(Session("Login"), CType(Session("ArregloAuditoria"), String()))

            oOrdPres.AsociaAPlaza(CInt(lblIdPlaza.Text), vlIdOrdDePres, CType(Session("ArregloAuditoria"), String()))

            BindgvPlazasVigentes()
            BindgvPlazasHistoria()
        End If
    End Sub

    Protected Sub ibGuardar_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oCadena As New Cadenas
        Dim ibGuardar As ImageButton = CType(sender, ImageButton)
        Dim Fila As GridViewRow = CType(ibGuardar.NamingContainer, GridViewRow)
        Dim lblIdCadena As Label = CType(Fila.FindControl("lblIdCadena"), Label)
        Dim lblIdPlaza As Label = CType(Fila.FindControl("lblIdPlaza"), Label)
        Dim ddlCadenas As DropDownList = CType(Fila.FindControl("ddlCadenas"), DropDownList)
        Dim ddlTipoMov As DropDownList = CType(Fila.FindControl("ddlTipoMov"), DropDownList)

        oCadena.ActualizaMov(CInt(lblIdCadena.Text), CInt(ddlCadenas.SelectedValue), CInt(lblIdPlaza.Text), Session("Login"), ddlTipoMov.SelectedValue, CType(Session("ArregloAuditoria"), String()))

        Me.gvPlazasVigentes.EditIndex = -1
        BindgvPlazasVigentes()

        Me.gvPlazasHistoria.EditIndex = -1
        BindgvPlazasHistoria()
    End Sub

    Protected Sub ibCancelar_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim ibCancelar As ImageButton = CType(sender, ImageButton)
        Dim Fila As GridViewRow = CType(ibCancelar.NamingContainer, GridViewRow)

        Me.gvPlazasHistoria.EditIndex = -1
        BindgvPlazasHistoria()
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    BindgvPlazasVigentes()
                    BindgvPlazasHistoria()
                    pnl1.Visible = True
                    TitlePanelHistoriaPlazas.Visible = True
                    TitlePanelPlazasVigentes.Visible = True
                    ContentPanelHistoriaPlazas.Visible = True
                    ContentPanelPlazasVigentes.Visible = True
                Else
                    pnl1.Visible = False
                    TitlePanelHistoriaPlazas.Visible = False
                    TitlePanelPlazasVigentes.Visible = False
                    ContentPanelHistoriaPlazas.Visible = False
                    ContentPanelPlazasVigentes.Visible = False
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                pnl1.Visible = False
                TitlePanelHistoriaPlazas.Visible = False
                TitlePanelPlazasVigentes.Visible = False
                ContentPanelHistoriaPlazas.Visible = False
                ContentPanelPlazasVigentes.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                pnl1.Visible = True
                TitlePanelHistoriaPlazas.Visible = True
                TitlePanelPlazasVigentes.Visible = True
                ContentPanelHistoriaPlazas.Visible = True
                ContentPanelPlazasVigentes.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindgvPlazasVigentes()
                    BindgvPlazasHistoria()
                    pnl1.Visible = True
                    TitlePanelHistoriaPlazas.Visible = True
                    TitlePanelPlazasVigentes.Visible = True
                    ContentPanelHistoriaPlazas.Visible = True
                    ContentPanelPlazasVigentes.Visible = True
                End If
            End If
        End If
    End Sub
End Class
