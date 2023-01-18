Imports DataAccessLayer.COBAEV.Nominas
'Imports System.Threading.Thread
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Partial Class CapturaPercDeduc
    Inherits System.Web.UI.Page
    Private Sub SetPermisosRolPerc()
        Dim gvr As GridViewRow
        Dim lblIdPercepcion As Label
        Dim ibEliminar As ImageButton
        Dim ibModificar As ImageButton
        Dim oAplic As New Aplicacion
        Dim oUsr As New Usuario
        Dim dt As DataTable
        Dim dr As DataRow

        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        For Each gvr In gvPercepciones.Rows
            lblIdPercepcion = Nothing
            lblIdPercepcion = CType(gvr.FindControl("lblIdPercepcion"), Label)
            If lblIdPercepcion Is Nothing = False Then
                ibEliminar = CType(gvr.FindControl("ibEliminar"), ImageButton)
                ibModificar = CType(gvr.FindControl("ibModificar"), ImageButton)

                dt = oAplic.ObtenerPermisosRolesPercepciones(CShort(dr("IdRol")), CShort(lblIdPercepcion.Text))

                If dt.Rows.Count > 0 Then
                    ibEliminar.Visible = CBool(dt.Rows(0).Item("PermisoBorrar"))
                    ibModificar.Visible = CBool(dt.Rows(0).Item("PermisoModificar"))
                End If

                ddlPercepciones.Items.Remove(ddlPercepciones.Items.FindByValue(lblIdPercepcion.Text))
            End If
        Next
    End Sub
    Private Sub SetPermisosRolPerc2()
        Dim lblIdPercepcion As New Label
        Dim oAplic As New Aplicacion
        Dim oUsr As New Usuario
        Dim dr As DataRow
        Dim dr2 As DataRow
        Dim dt As DataTable

        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        dt = oAplic.ObtenerPermisosRolesPercepciones(CShort(dr("IdRol")))

        For Each dr2 In dt.Rows
            lblIdPercepcion.Text = dr2("IdDeduccion").ToString
            If CBool(dr2("PermisoCaptura")) = False Then
                ddlPercepciones.Items.Remove(ddlPercepciones.Items.FindByValue(lblIdPercepcion.Text))
            End If
        Next
    End Sub
    Private Sub SetPermisosRolDeduc()
        Dim gvr As GridViewRow
        Dim lblIdDeduccion As Label
        Dim ibEliminar As ImageButton
        Dim ibModificar As ImageButton
        Dim oAplic As New Aplicacion
        Dim oUsr As New Usuario
        Dim dt As DataTable
        Dim dr As DataRow

        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        For Each gvr In gvDeducciones.Rows
            lblIdDeduccion = Nothing
            lblIdDeduccion = CType(gvr.FindControl("lblIdDeduccion"), Label)
            If lblIdDeduccion Is Nothing = False Then
                ibEliminar = CType(gvr.FindControl("ibEliminar"), ImageButton)
                ibModificar = CType(gvr.FindControl("ibModificar"), ImageButton)

                dt = oAplic.ObtenerPermisosRolesDeducciones(CShort(dr("IdRol")), CShort(lblIdDeduccion.Text))

                If dt.Rows.Count > 0 Then
                    ibEliminar.Visible = CBool(dt.Rows(0).Item("PermisoBorrar"))
                    ibModificar.Visible = CBool(dt.Rows(0).Item("PermisoModificar"))
                End If

                ddlDeducciones.Items.Remove(ddlDeducciones.Items.FindByValue(lblIdDeduccion.Text))
            End If
        Next
    End Sub
    Private Sub SetPermisosRolDeduc2()
        Dim lblIdDeduccion As New Label
        Dim oAplic As New Aplicacion
        Dim oUsr As New Usuario
        Dim dr As DataRow
        Dim dr2 As DataRow
        Dim dt As DataTable

        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        dt = oAplic.ObtenerPermisosRolesDeducciones(CShort(dr("IdRol")))

        For Each dr2 In dt.Rows
            lblIdDeduccion.Text = dr2("IdDeduccion").ToString
            If CBool(dr2("PermisoCaptura")) = False Then
                ddlDeducciones.Items.Remove(ddlDeducciones.Items.FindByValue(lblIdDeduccion.Text))
            End If
        Next
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, _
                        ByVal dt As DataTable, Optional ByVal SelectedValue As String = "", _
                        Optional ByVal Habilitado As Boolean = True)
        If dt.Rows.Count > 0 Then
            ddl.Items.Clear()
            ddl.DataSource = dt
            ddl.DataTextField = TextField
            ddl.DataValueField = ValueField
            Try
                ddl.DataBind()
            Catch
            End Try
            If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
            ddl.Enabled = Habilitado
        End If
    End Sub

    Private Sub SetPermisos()
        Dim oUsr As New Usuario
        Dim dtPermPerc As DataTable
        Dim dtPermDeduc As DataTable

        dtPermPerc = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Percepciones")
        dtPermDeduc = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Deducciones")

        gvPercepciones.Columns(10).Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1 And CBool(dtPermPerc.Rows(0).Item("Eliminacion"))
        gvPercepciones.Columns(11).Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1 And CBool(dtPermPerc.Rows(0).Item("Actualizacion"))
        lblPosiblesPerc.Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1 And CBool(dtPermPerc.Rows(0).Item("Insercion"))
        ddlPercepciones.Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1 And CBool(dtPermPerc.Rows(0).Item("Insercion"))
        btnAddPerc.Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1 And CBool(dtPermPerc.Rows(0).Item("Insercion"))
        'lbAgregarPercepcion.Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1
        gvDeducciones.Columns(10).Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1 And CBool(dtPermDeduc.Rows(0).Item("Eliminacion"))
        gvDeducciones.Columns(11).Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1 And CBool(dtPermDeduc.Rows(0).Item("Actualizacion"))
        lblPosiblesDeduc.Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1 And CBool(dtPermDeduc.Rows(0).Item("Insercion"))
        ddlDeducciones.Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1 And CBool(dtPermDeduc.Rows(0).Item("Insercion"))
        btnAddDeduc.Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1 And CBool(dtPermDeduc.Rows(0).Item("Insercion"))
        'lbAgregarDeduccion.Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1
        'lbAddPrestamoISSSTE.Visible = ddlQnasAbiertasParaCaptura.SelectedValue <> -1
    End Sub
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
                Else
                    lblEmpInf.Text = String.Empty
                    lblEmpInf.Visible = False
                    .Items.Clear()
                    .Items.Insert(0, "No hay quincenas abiertas para captura")
                    .Items(0).Value = -1
                    ddlQnasAbiertasParaCaptura.Enabled = False
                    btnConsultarQna.Enabled = False
                End If
                MultiView1.SetActiveView(viewInf)
            Else
                MultiView1.SetActiveView(viewVacio)
                lblEmpInf.Text = String.Empty
                lblEmpInf.Visible = False
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas abiertas para captura")
                .Items(0).Value = -1
                ddlQnasAbiertasParaCaptura.Enabled = False
                btnConsultarQna.Enabled = False
            End If
        End With
    End Sub
    Private Sub BindDeducciones(ByVal RFCEmp As String)
        Dim oDeduccion As New Deduccion
        Dim oUsr As New Usuario
        Dim dr2 As DataRow
        oUsr.Login = Session("Login")
        dr2 = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        'lbAddPrestamoISSSTE.Visible = True

        With oDeduccion
            Me.gvDeducciones.DataSource = .ObtenCapturadasPorEmpleado(RFCEmp, CType(Me.ddlQnasAbiertasParaCaptura.SelectedValue, Short))
            Me.gvDeducciones.DataBind()
        End With
        'Me.lbAgregarDeduccion.Visible = True
        Me.lbAgregarDeduccion.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonDeducCapturadas.aspx?TipoOperacion=1&RFCEmp=" + RFCEmp + _
                                "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "');"
        Me.lbAddPrestamoISSSTE.OnClientClick = "javascript:abreVentanaMediana('../../ABC/ISSSTE/AdmonPrestamosISSSTE.aspx?TipoOperacion=1&RFCEmp=" + RFCEmp + _
                                "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "');"

        LlenaDDL(Me.ddlDeducciones, "Deduccion", "IdDeduccion", oDeduccion.ObtenPorRol(CByte(dr2("IdRol"))), String.Empty)

        SetPermisos()
        SetPermisosRolDeduc()
        SetPermisosRolDeduc2()
    End Sub
    Private Sub BidnPercepciones(ByVal RFCEmp As String)
        Dim oPercepcion As New Percepcion

        Dim oUsr As New Usuario
        Dim dr2 As DataRow
        oUsr.Login = Session("Login")
        dr2 = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        With oPercepcion
            Me.gvPercepciones.DataSource = .ObtenCapturadasPorEmpleado(RFCEmp, CType(Me.ddlQnasAbiertasParaCaptura.SelectedValue, Short))
            Me.gvPercepciones.DataBind()
        End With
        'lbAgregarPercepcion.Visible = True
        '        Me.lbAgregarPercepcion.Attributes.Add("onclick", "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=1&RFCEmp=" + RFCEmp + "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "&ValidacionAlCargarPagina=SI');")
        lbAgregarPercepcion.Attributes.Add("onclick", "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=1&RFCEmp=" + RFCEmp + "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "');")

        LlenaDDL(Me.ddlPercepciones, "Percepcion", "IdPercepcion", oPercepcion.ObtenPorRol(CByte(dr2("IdRol"))), String.Empty)

        SetPermisos()
        SetPermisosRolPerc()
        SetPermisosRolPerc2()
    End Sub

    'Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
    '    BindQnas()
    '    If Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "-1" Then
    '        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '        BindDeducciones(hfRFC.Value)
    '        BidnPercepciones(hfRFC.Value)
    '    End If
    '    'Sleep(500)
    'End Sub

    Protected Sub gvDeducciones_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDeducciones.RowCommand
        'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        'BindDeducciones(hfRFC.Value)
        'Sleep(500)
    End Sub

    Protected Sub gvDeducciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDeducciones.RowDataBound
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oDeduc As New Deduccion
        Dim drDeduc As DataRow

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
                Dim drDeducCaptPermiteABC As DataRow
                Dim vlDeducCaptPermiteABC As Boolean

                ibEliminar.CommandArgument = e.Row.RowIndex

                drDeduc = oDeduc.ObtenPorId(CShort(lblIdDeduccion.Text))
                drDeducCaptPermiteABC = oDeduc.DeducCaptPermiteABC(hfRFC.Value, CInt(lblIdDeducCapturada.Text), CShort(lblIdDeduccion.Text))
                vlDeducCaptPermiteABC = CBool(drDeducCaptPermiteABC("Result"))

                ibEliminar.Enabled = vlDeducCaptPermiteABC
                'ibModificar.Enabled = vlDeducCaptPermiteABC
                If vlDeducCaptPermiteABC Then
                    ibEliminar.ToolTip = "Eliminar deducción."
                    ibModificar.ToolTip = "Modificar deducción."
                Else
                    ibEliminar.ToolTip = "Opción no permitida, la deducción ya está asociada a pagos quincenales del trabajador."
                    ibModificar.ToolTip = "Opción permitida, pero solo para modificar vigencia final, dado que la deducción ya está asociada a pagos quincenales del trabajador."
                End If

                If drDeduc("URL").ToString.Trim <> "" And drDeduc("URL").ToString.Trim.Contains(".aspx") Then
                    ibEliminar.PostBackUrl = drDeduc("URL").ToString.Trim + "?TipoOperacion=3" + _
                                                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                                                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text + "&RFCEmp=" + hfRFC.Value
                    ibModificar.PostBackUrl = drDeduc("URL").ToString.Trim + "?TipoOperacion=0&RFCEmp=" + hfRFC.Value + _
                                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                                "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + _
                                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text
                Else
                    ibEliminar.PostBackUrl = "../../ABC/Nomina/AdmonDeducCapturadas.aspx?TipoOperacion=3" + _
                                                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                                                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text + "&RFCEmp=" + hfRFC.Value
                    ibModificar.PostBackUrl = "../../ABC/Nomina/AdmonDeducCapturadas.aspx?TipoOperacion=0&RFCEmp=" + hfRFC.Value + _
                                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                                "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + _
                                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text
                End If
                'ibEliminar.Enabled = CShort(ddlQnasAbiertasParaCaptura.SelectedValue) = CShort(lblVigIniDeduc.Text)

                'If lblIdDeduccion.Text <> "31" Then 'Préstamo ISSSTE (Clave 431)
                '    ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonDeducCapturadas.aspx?TipoOperacion=3" + _
                '                                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                '                                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text + "&RFCEmp=" + hfRFC.Value + "'); return false;"
                '    ibEliminar.Enabled = (CType(Me.ddlQnasAbiertasParaCaptura.SelectedValue, Short) = CType(lblVigIniDeduc.Text, Short))
                '    ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonDeducCapturadas.aspx?TipoOperacion=0&RFCEmp=" + hfRFC.Value + _
                '                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                '                "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + _
                '                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text + "'); return false;"
                'Else
                '    'lbAddPrestamoISSSTE.Visible = False
                '    ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/ISSSTE/AdmonPrestamosISSSTE.aspx?TipoOperacion=3" + _
                '                                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                '                                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text + "&RFCEmp=" + hfRFC.Value + "'); return false;"
                '    ibEliminar.Enabled = (CType(Me.ddlQnasAbiertasParaCaptura.SelectedValue, Short) = CType(lblVigIniDeduc.Text, Short))
                '    ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/ISSSTE/AdmonPrestamosISSSTE.aspx?TipoOperacion=0&RFCEmp=" + hfRFC.Value + _
                '                "&IdDeducCapturada=" + lblIdDeducCapturada.Text + _
                '                "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + _
                '                "&IdPlaza=" + lblIdPlaza.Text + "&IdDeduccion=" + lblIdDeduccion.Text + "'); return false;"
                'End If
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
                'ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=3" + _
                '                            "&IdPercCapturada=" + lblIdPercCapturada.Text + _
                '                            "&IdPlaza=" + lblIdPlaza.Text + "&IdPercepcion=" + lblIdPercepcion.Text + "'); return false;"
                ibEliminar.PostBackUrl = "../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=3" + _
                                            "&IdPercCapturada=" + lblIdPercCapturada.Text + _
                                            "&IdPlaza=" + lblIdPlaza.Text + "&IdPercepcion=" + lblIdPercepcion.Text
                ibEliminar.Enabled = CShort(ddlQnasAbiertasParaCaptura.SelectedValue) = CShort(lblVigIniPerc.Text)
                'ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=0&RFCEmp=" + hfRFC.Value + _
                '            "&IdPercCapturada=" + lblIdPercCapturada.Text + _
                '            "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + _
                '            "&IdPlaza=" + lblIdPlaza.Text + "&IdPercepcion=" + lblIdPercepcion.Text + "'); return false;"
                ibModificar.PostBackUrl = "../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=0&RFCEmp=" + hfRFC.Value + _
                            "&IdPercCapturada=" + lblIdPercCapturada.Text + _
                            "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + _
                            "&IdPlaza=" + lblIdPlaza.Text + "&IdPercepcion=" + lblIdPercepcion.Text
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPercepciones, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindQnas()
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            BindDeducciones(hfRFC.Value)
            BidnPercepciones(hfRFC.Value)
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
        'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        'BidnPercepciones(hfRFC.Value)
    End Sub

    Protected Sub lbAgregarPercepcion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAgregarPercepcion.Click
        'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        'BidnPercepciones(hfRFC.Value)
    End Sub

    Protected Sub lbAgregarDeduccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAgregarDeduccion.Click
        'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        'BindDeducciones(hfRFC.Value)
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Then
            BindQnas()
            If hfRFC.Value <> String.Empty Then
                If Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "-1" And Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "" Then
                    BindDeducciones(hfRFC.Value)
                    BidnPercepciones(hfRFC.Value)
                    MultiView1.Visible = True
                End If
            End If
        ElseIf Request.Params(0).Contains("BtnNewSearch") Then
            MultiView1.Visible = False
        ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
            MultiView1.Visible = True
        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                BindQnas()
                If Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "-1" And Me.ddlQnasAbiertasParaCaptura.SelectedValue <> "" Then
                    BindDeducciones(hfRFC.Value)
                    BidnPercepciones(hfRFC.Value)
                    MultiView1.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub btnAddPerc_Click(sender As Object, e As System.EventArgs) Handles btnAddPerc.Click
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        Response.Redirect("../../ABC/Nomina/AdmonPercCapturadas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + _
                          "&IdQnaCaptura=" + ddlQnasAbiertasParaCaptura.SelectedValue + "&ValidacionAlCargarPagina=SI&IdPercepcion=" + _
                          ddlPercepciones.SelectedValue)
    End Sub

    Protected Sub btnAddDeduc_Click(sender As Object, e As System.EventArgs) Handles btnAddDeduc.Click
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oDeduc As New Deduccion
        Dim drDeduc As DataRow

        drDeduc = oDeduc.ObtenPorId(CShort(ddlDeducciones.SelectedValue))

        If drDeduc("URL").ToString.Trim <> "" And drDeduc("URL").ToString.Trim.Contains(".aspx") Then
            Response.Redirect(drDeduc("URL").ToString.Trim + "?TipoOperacion=1&RFCEmp=" + hfRFC.Value + _
                                    "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "&ValidacionAlCargarPagina=SI&IdDeduccion=" + _
                                    ddlDeducciones.SelectedValue)
        Else
            Response.Redirect("../../ABC/Nomina/AdmonDeducCapturadas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + _
                                    "&IdQnaCaptura=" + Me.ddlQnasAbiertasParaCaptura.SelectedValue + "&ValidacionAlCargarPagina=SI&IdDeduccion=" + _
                                    ddlDeducciones.SelectedValue)
        End If
    End Sub
End Class
