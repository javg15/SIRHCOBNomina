Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Empleados.Sexos
Imports DataAccessLayer.COBAEV.Empleados.EstadosCiviles
Imports DataAccessLayer.COBAEV.Empleados.Nacionalidades
Imports DataAccessLayer.COBAEV.Mexico.Estados
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Mexico.Estados.Municipios
Imports System.Data
Imports DataAccessLayer.COBAEV.Mexico.Estados.Municipios.Localidades
Imports DataAccessLayer.COBAEV.Mexico.Estados.Municipios.Localidades.Colonias
Partial Class ABC_Empleados_AdministracionDomicilioFiscalSATCaptura
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Public dr As DataRow
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindDatos()
        Dim btnGuardar As Button = CType(Me.dvDatosDom.FindControl("btnGuardar"), Button)
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If oEmp.RFC <> String.Empty Then
            btnGuardar.Visible = False
            Dim txtbxNombre As TextBox = CType(Me.dvDatosDom.FindControl("txtbxNombre"), TextBox)
            Dim tbCalle As TextBox = CType(Me.dvDatosDom.FindControl("tbCalle"), TextBox)
            Dim tbNumExt As TextBox = CType(Me.dvDatosDom.FindControl("tbNumExt"), TextBox)
            Dim tbNumInt As TextBox = CType(Me.dvDatosDom.FindControl("tbNumInt"), TextBox)
            Dim tbCodPos As TextBox = CType(Me.dvDatosDom.FindControl("tbCodPos"), TextBox)
            Dim hdIdEmp As HiddenField = CType(Me.dvDatosDom.FindControl("hdIdEmp"), HiddenField)
            Me.MultiView1.SetActiveView(Me.viewCaptura)
            pnlGral.Visible = True
            Dim dr2 As DataRow
            dr2 = oEmp.ObtenDomicilioFiscal().Rows(0)
            hdIdEmp.Value = dr2("IdEmp")
            tbCalle.Text = dr2("CalleDomFis")
            tbNumExt.Text = dr2("NumExtDomFis")
            tbNumInt.Text = dr2("NumIntDomFis")
            BindEstados(dr2("IdEdo"))
            BindMunicipios(dr2("IdMun"))
            BindLocalidades(dr2("IdLoc"))
            BindColonias(dr2("IdCol"))
            tbCodPos.Text = dr2("CodPosDomFis")
            BloquearCambios(True)
        End If
    End Sub
    Private Sub FilltbCodPos()
        Dim oCol As New Colonia
        Dim ddlColonias As DropDownList = CType(Me.dvDatosDom.FindControl("ddlColonias"), DropDownList)
        Dim tbCodPos As TextBox = CType(Me.dvDatosDom.FindControl("tbCodPos"), TextBox)
        Dim CP As String
        CP = oCol.ObtenCodigoPostal(CInt(ddlColonias.SelectedValue))
        If CP <> String.Empty Then
            tbCodPos.Text = CP
        Else
            tbCodPos.Text = String.Empty
        End If
    End Sub
    Private Sub BindColonias(Optional ByVal SelectedValue As String = "99999")
        Dim oLocalidad As New Localidad
        Dim ddlLocalidades As DropDownList = CType(Me.dvDatosDom.FindControl("ddlLocalidades"), DropDownList)
        Dim ddlColonias As DropDownList = CType(Me.dvDatosDom.FindControl("ddlColonias"), DropDownList)
        LlenaDDL(ddlColonias, "NomCol", "IdCol", oLocalidad.ObtenColonias(CInt(ddlLocalidades.SelectedValue)), SelectedValue)
    End Sub
    Private Sub BindLocalidades(Optional ByVal SelectedValue As String = "999999")
        Dim oMunicipio As New Municipio
        Dim ddlMunicipios As DropDownList = CType(Me.dvDatosDom.FindControl("ddlMunicipios"), DropDownList)
        Dim ddlLocalidades As DropDownList = CType(Me.dvDatosDom.FindControl("ddlLocalidades"), DropDownList)
        LlenaDDL(ddlLocalidades, "NomLoc", "IdLoc", oMunicipio.ObtenLocalidades(CShort(ddlMunicipios.SelectedValue)), SelectedValue)
    End Sub
    Private Sub BindMunicipios(Optional ByVal SelectedValue As String = "9999")
        Dim oEstado As New Estado
        Dim ddlEstados As DropDownList = CType(Me.dvDatosDom.FindControl("ddlEstados"), DropDownList)
        Dim ddlMunicipios As DropDownList = CType(Me.dvDatosDom.FindControl("ddlMunicipios"), DropDownList)
        LlenaDDL(ddlMunicipios, "NomMun", "IdMun", oEstado.ObtenMunicipios(CByte(ddlEstados.SelectedValue)), SelectedValue)
    End Sub
    Private Sub BindEstados(Optional ByVal SelectedValue As String = "99")
        Dim oEstado As New Estado
        Dim ddlEstados As DropDownList = CType(Me.dvDatosDom.FindControl("ddlEstados"), DropDownList)
        LlenaDDL(ddlEstados, "NomEdo", "IdEdo", oEstado.ObtenParaDomicilio(False), SelectedValue)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub
    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
    End Sub
    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender

        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Then
            If hfRFC.Value <> String.Empty Then
                BindDatos()
            End If
        ElseIf Request.Params(0).Contains("BtnNewSearch") Then
            pnlGral.Visible = False
        ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
            pnlGral.Visible = True
        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                BindDatos()
            End If
        End If
    End Sub
    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(Me.dvDatosDom.FindControl("btnEditar"), Button)
        If btnEditar.Text = "Editar" Then
            BloquearCambios(False)
            btnEditar.Text = "Cancelar"
        Else
            BloquearCambios(True)
            btnEditar.Text = "Editar"
        End If
    End Sub
    Private Sub BloquearCambios(ByVal bloqueo As Boolean)
        Dim tbCalle As TextBox = CType(Me.dvDatosDom.FindControl("tbCalle"), TextBox)
        Dim tbNumExt As TextBox = CType(Me.dvDatosDom.FindControl("tbNumExt"), TextBox)
        Dim tbNumInt As TextBox = CType(Me.dvDatosDom.FindControl("tbNumInt"), TextBox)
        Dim ddlEstados As DropDownList = CType(Me.dvDatosDom.FindControl("ddlEstados"), DropDownList)
        Dim ddlMunicipios As DropDownList = CType(Me.dvDatosDom.FindControl("ddlMunicipios"), DropDownList)
        Dim ddlLocalidades As DropDownList = CType(Me.dvDatosDom.FindControl("ddlLocalidades"), DropDownList)
        Dim ddlColonias As DropDownList = CType(Me.dvDatosDom.FindControl("ddlColonias"), DropDownList)
        Dim chbCapturarColonia As CheckBox = CType(Me.dvDatosDom.FindControl("chbCapturarColonia"), CheckBox)
        Dim tbColonia As TextBox = CType(Me.dvDatosDom.FindControl("tbColonia"), TextBox)
        Dim tbCodPos As TextBox = CType(Me.dvDatosDom.FindControl("tbCodPos"), TextBox)
        Dim btnGuardar As Button = CType(Me.dvDatosDom.FindControl("btnGuardar"), Button)
        If bloqueo = False Then
            tbCalle.Enabled = True
            tbNumExt.Enabled = True
            tbNumInt.Enabled = True
            ddlEstados.Enabled = True
            ddlMunicipios.Enabled = True
            ddlLocalidades.Enabled = True
            ddlColonias.Enabled = True
            tbColonia.Enabled = True
            tbCodPos.Enabled = True
            btnGuardar.Visible = True
        Else
            tbCalle.Enabled = False
            tbNumExt.Enabled = False
            tbNumInt.Enabled = False
            ddlEstados.Enabled = False
            ddlMunicipios.Enabled = False
            ddlLocalidades.Enabled = False
            ddlColonias.Enabled = False
            tbColonia.Enabled = False
            tbCodPos.Enabled = False
            btnGuardar.Visible = False
        End If
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim hdIdEmp As HiddenField = CType(Me.dvDatosDom.FindControl("hdIdEmp"), HiddenField)
            Dim tbCalle As TextBox = CType(Me.dvDatosDom.FindControl("tbCalle"), TextBox)
            Dim tbNumExt As TextBox = CType(Me.dvDatosDom.FindControl("tbNumExt"), TextBox)
            Dim tbNumInt As TextBox = CType(Me.dvDatosDom.FindControl("tbNumInt"), TextBox)
            Dim ddlEstados As DropDownList = CType(Me.dvDatosDom.FindControl("ddlEstados"), DropDownList)
            Dim ddlMunicipios As DropDownList = CType(Me.dvDatosDom.FindControl("ddlMunicipios"), DropDownList)
            Dim ddlLocalidades As DropDownList = CType(Me.dvDatosDom.FindControl("ddlLocalidades"), DropDownList)
            Dim ddlColonias As DropDownList = CType(Me.dvDatosDom.FindControl("ddlColonias"), DropDownList)
            Dim chbCapturarColonia As CheckBox = CType(Me.dvDatosDom.FindControl("chbCapturarColonia"), CheckBox)
            Dim tbColonia As TextBox = CType(Me.dvDatosDom.FindControl("tbColonia"), TextBox)
            Dim tbCodPos As TextBox = CType(Me.dvDatosDom.FindControl("tbCodPos"), TextBox)
            Dim btnEditar As Button = CType(Me.dvDatosDom.FindControl("btnEditar"), Button)
            Dim oEmpDom As New EmpleadosDomicilios
            With oEmpDom
                .IdEmp = CInt(hdIdEmp.Value)
                .CalleDom = tbCalle.Text.Trim.ToUpper
                .NumExtDom = tbNumExt.Text.Trim.ToUpper
                .NumIntDom = tbNumInt.Text.Trim.ToUpper
                .IdEdo = CByte(ddlEstados.SelectedValue)
                .IdMun = CShort(ddlMunicipios.SelectedValue)
                .IdLoc = CInt(ddlLocalidades.SelectedValue)
                .IdCol = CInt(Me.ddlColonias.SelectedValue)
                .ColoniaCapturada = chbCapturarColonia.Checked
                .NomColDom = tbColonia.Text.Trim.ToUpper
                .CodPosDom = tbCodPos.Text.Trim.ToUpper
                .ActualizarDomicilioFiscal(0, CType(Session("ArregloAuditoria"), String()))
            End With
            BloquearCambios(True)
            btnEditar.Text = "Editar"
            Me.MultiView1.SetActiveView(viewCapturaExitosa)
        Catch Ex As Exception
            Me.lblErrores.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewErrores)
        End Try
    End Sub
    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub
    Protected Sub lbVerDatosPersonales_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbVerDatosPersonales.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub

    Protected Sub ddlEstados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindMunicipios()
        BindLocalidades()
        BindColonias()
        FilltbCodPos()
    End Sub

    Protected Sub ddlMunicipios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindLocalidades()
        BindColonias()
        FilltbCodPos()
    End Sub

    Protected Sub ddlLocalidades_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindColonias()
        FilltbCodPos()
    End Sub

    Protected Sub chbSN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tbNumExt As TextBox = CType(Me.dvDatosDom.FindControl("tbNumExt"), TextBox)
        Dim chbSN As CheckBox = CType(Me.dvDatosDom.FindControl("chbSN"), CheckBox)
        Dim tbNumInt As TextBox = CType(Me.dvDatosDom.FindControl("tbNumInt"), TextBox)
        If chbSN.Checked Then
            tbNumExt.Text = "S/N"
            tbNumExt.Enabled = False
            tbNumInt.Text = String.Empty
            tbNumInt.Enabled = False
        Else
            tbNumExt.Text = ""
            tbNumExt.Enabled = True
            tbNumInt.Text = String.Empty
            tbNumInt.Enabled = True
        End If
    End Sub
    Protected Sub chbCapturarColonia_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If chbCapturarColonia.Checked Then
            Me.ddlColonias.Enabled = False
            Me.tbColonia.Visible = True
        Else
            Me.ddlColonias.Enabled = True
            Me.tbColonia.Visible = False
        End If
    End Sub

    Protected Sub ddlColonias_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        FilltbCodPos()
    End Sub
End Class
