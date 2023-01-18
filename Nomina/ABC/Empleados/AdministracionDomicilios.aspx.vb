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
Partial Class ABC_Empleados_AdministracionDomicilios
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
            Dim lblIdEmp As Label = CType(Me.dvDatosDom.FindControl("lblIdEmp"), Label)
            Dim txtbxRFC As TextBox = CType(Me.dvDatosDom.FindControl("txtbxRFC"), TextBox)
            Dim txtbxNombre As TextBox = CType(Me.dvDatosDom.FindControl("txtbxNombre"), TextBox)
            Dim tbCalle As TextBox = CType(Me.dvDatosDom.FindControl("tbCalle"), TextBox)
            Dim tbNumExt As TextBox = CType(Me.dvDatosDom.FindControl("tbNumExt"), TextBox)
            Dim tbNumInt As TextBox = CType(Me.dvDatosDom.FindControl("tbNumInt"), TextBox)
            Dim tbCodPos As TextBox = CType(Me.dvDatosDom.FindControl("tbCodPos"), TextBox)
            If Request.Params("TipoOperacion") = "0" Then 'Actualizar
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Dim oEmp As New Empleado
                Dim dr, dr2 As DataRow
                oEmp.RFC = Request.Params("RFCEmp")
                dr = oEmp.ObtenDatosPersonales().Rows(0)
                lblIdEmp.Text = dr("IdEmp")
                txtbxRFC.Text = dr("RFCEmp")
                txtbxNombre.Text = dr("ApePatEmp").ToString.Trim + " " + dr("ApeMatEmp").ToString.Trim + " " + dr("NomEmp").ToString.Trim
                dr2 = oEmp.ObtenDomicilio().Rows(0)
                tbCalle.Text = dr2("CalleDom")
                tbNumExt.Text = dr2("NumExtDom")
                tbNumInt.Text = dr2("NumIntDom")
                BindEstados(dr2("IdEdo"))
                BindMunicipios(dr2("IdMun"))
                BindLocalidades(dr2("IdLoc"))
                BindColonias(dr2("IdCol"))
                tbCodPos.Text = dr2("CodPosDom")
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lblIdEmp As Label = CType(Me.dvDatosDom.FindControl("lblIdEmp"), Label)
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
            Dim oEmpDom As New EmpleadosDomicilios
            With oEmpDom
                .IdEmp = CInt(lblIdEmp.Text)
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
                If Request.Params("TipoOperacion") = "0" Then
                    .ActualizarDomicilio(0, CType(Session("ArregloAuditoria"), String()))
                End If
            End With
            Me.MultiView1.SetActiveView(viewCapturaExitosa)
        Catch Ex As Exception
            Me.lblErrores.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewErrores)
        End Try
    End Sub
    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
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
