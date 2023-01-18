Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Plazas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports DataAccessLayer.COBAEV.InformacionAcademica
Partial Class wfAdmonPlazas
    Inherits System.Web.UI.Page

    Private ddlSindicatos As DropDownList
    Private ddlEmpleadosFunciones As DropDownList
    Private ddlCadenas As DropDownList
    Private ddlTramites As DropDownList
    Private ddlMotivos As DropDownList
    Private ddlQnaTermino As DropDownList
    Private btnGuardar As Button
    Private btnValidar As Button
    Private btnCancelar As Button
    Private btnModificar As Button
    Private pnlCvePlaza As Panel
    Private pnlCvePlazaError As Panel
    Private imgPlazaCorrecta As Image
    Private txtbxConsPlaza As TextBox

    Private Sub Bind_ddlMotivos()
        Dim oMovDePers As New MovsDePersonal
        'Dim ddlCadenas As DropDownList = CType(Me.dvPlaza.FindControl("ddlCadenas"), DropDownList)
        'Dim ddlTramites As DropDownList = CType(Me.dvPlaza.FindControl("ddlTramites"), DropDownList)
        'Dim ddlMotivos As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivos"), DropDownList)
        'Dim ddlQuincenaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim txtbxFechaFin As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaFin"), TextBox)
        Dim chkbxVigFinAbierta As CheckBox = CType(Me.dvPlaza.FindControl("chkbxVigFinAbierta"), CheckBox)
        Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
        Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
        'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)

        Dim dtInfTraMot As DataTable
        Dim oCategoria As New Categoria

        dtInfTraMot = oMovDePers.ObtenInfTramiteMotivo(CShort(Request.Params("IdTramite")), CShort(Request.Params("IdMotivo")))

        LlenaDDL(ddlMotivos, "DescMotivo", "IdMotivo", oMovDePers.ObtenMotivosPorTramite(CShort(ddlTramites.SelectedValue)), Nothing)

        If Request.Params("TipoOperacion") = "1" Then
            If dtInfTraMot.Rows(0).Item("strIdEmpFuncion").ToString = "3" Then
                ddlEmpleadosFunciones.SelectedValue = "1" 'ADMINISTRATIVO/DIRECTIVO
                ddlEmpleadosFunciones.Enabled = False
                LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenPorFuncionDelEmpleado(CByte(ddlEmpleadosFunciones.SelectedValue), CByte(dtInfTraMot.Rows(0).Item("strIdEmpFuncion").ToString)))
                ddlSindicatos.SelectedValue = "3" 'LIBRE
                ddlSindicatos.Enabled = False
                ddlPlazasTipoOcup.Enabled = False
            End If
            ddlPlazasTipoOcup.SelectedValue = dtInfTraMot.Rows(0).Item("strIdNombramiento")
            ddlPlazasTipoOcup_SelectedIndexChanged(Nothing, Nothing)
            chkbxVigFinAbierta.Checked = Not CBool(dtInfTraMot.Rows(0).Item("PedirVigFin"))
            chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
            ddlMotivosDeBaja.SelectedValue = dtInfTraMot.Rows(0).Item("strIdMotGralBaja")
            ddlMotivosDeBaja_SelectedIndexChanged(Nothing, Nothing)
            ddlCadenas.SelectedValue = Request.Params("IdCadena")
            ddlTramites.SelectedValue = Request.Params("IdTramite")
            ddlMotivos.SelectedValue = Request.Params("IdMotivo")
        End If
    End Sub

    Private Sub Bind_ddlTramites()
        Dim oMovDePers As New MovsDePersonal

        LlenaDDL(ddlTramites, "DescTramite", "IdTramite", oMovDePers.ObtenTramites(), Nothing)
        Bind_ddlMotivos()

    End Sub

    Private Sub UpdateClavePlaza(Optional ByVal pValidaPlaza As Boolean = False)
        Dim oPlaza As New SMP_Plazas
        Dim dt As DataTable = Nothing
        Dim dr As DataRow = Nothing
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
        Dim lblCvePlazaTipo As Label = CType(dvPlaza.FindControl("lblCvePlazaTipo"), Label)
        Dim lblGuion1 As Label = CType(dvPlaza.FindControl("lblGuion1"), Label)
        Dim lblZonaEco As Label = CType(dvPlaza.FindControl("lblZonaEco"), Label)
        Dim lblGuion2 As Label = CType(dvPlaza.FindControl("lblGuion2"), Label)
        Dim lblCvePlazaDiferenciador As Label = CType(dvPlaza.FindControl("lblCvePlazaDiferenciador"), Label)
        Dim lblGuion3 As Label = CType(dvPlaza.FindControl("lblGuion3"), Label)
        Dim lblCveCategoCOBACH As Label = CType(dvPlaza.FindControl("lblCveCategoCOBACH"), Label)
        Dim lblGuion4 As Label = CType(dvPlaza.FindControl("lblGuion4"), Label)
        Dim lblHorasPlaza As Label = CType(dvPlaza.FindControl("lblHorasPlaza"), Label)
        Dim lblGuion5 As Label = CType(dvPlaza.FindControl("lblGuion5"), Label)
        'Dim txtbxConsPlaza As TextBox = CType(dvPlaza.FindControl("txtbxConsPlaza"), TextBox)
        Dim imgPlazaIncorrecta As Image = CType(dvPlaza.FindControl("imgPlazaIncorrecta"), Image)

        Try
            If pValidaPlaza = False Then
                txtbxConsPlaza.Text = String.Empty
                dt = oPlaza.ObtenCamposQueLaConforman(CShort(ddlCategorias.SelectedValue), CShort(ddlCTAdscipReal.SelectedValue))
            Else
                txtbxConsPlaza.Text = txtbxConsPlaza.Text.PadLeft(5, "0")
                dr = oPlaza.ObtenPlazaDetalles(lblZonaEco.Text, lblCveCategoCOBACH.Text, txtbxConsPlaza.Text)
                dt = dr.Table
            End If

            If dt Is Nothing = False Then
                If dt.Rows.Count > 0 Then
                    'If pValidaPlaza = False Then dr = dt.Rows(0)
                    dr = dt.Rows(0)

                    lblCvePlazaTipo.Text = dr("CvePlazaTipo").ToString
                    lblCvePlazaTipo.ToolTip = dr("CvePlazaTipoToolTip").ToString
                    lblGuion1.Text = " - "
                    lblZonaEco.Text = dr("ZonaEco").ToString
                    lblZonaEco.ToolTip = dr("ZonaEcoToolTip").ToString
                    lblGuion2.Text = " - "
                    lblCvePlazaDiferenciador.Text = dr("CvePlazaDiferenciador").ToString
                    lblCvePlazaDiferenciador.ToolTip = dr("CvePlazaDiferenciadorToolTip").ToString
                    lblGuion3.Text = " - "
                    lblCveCategoCOBACH.Text = dr("CveCategoCOBACH").ToString
                    lblCveCategoCOBACH.ToolTip = dr("CveCategoCOBACHToolTip").ToString
                    lblGuion4.Text = " - "
                    lblHorasPlaza.Text = dr("HorasPlaza").ToString
                    lblHorasPlaza.ToolTip = dr("HorasPlazaToolTip").ToString
                    lblGuion5.Text = " - "
                    pnlCvePlaza.Visible = True
                    pnlCvePlazaError.Visible = Not CBool(dr("PlazaValida"))
                    imgPlazaCorrecta.Visible = False
                    If pValidaPlaza = True Then
                        imgPlazaCorrecta.Visible = Not pnlCvePlazaError.Visible
                        ddlSindicatos.SelectedValue = dr("IdSindicato").ToString
                        dvPlaza.Enabled = False
                        btnValidar.Visible = False
                        btnGuardar.Visible = True
                        btnModificar.Visible = True
                    End If
                    'btnGuardar.Visible = True
                Else
                    'pnlCvePlaza.Visible = False
                    ddlSindicatos.SelectedValue = "3"
                    imgPlazaCorrecta.Visible = False
                    pnlCvePlazaError.Visible = True
                    If pValidaPlaza = True Then
                        dvPlaza.Enabled = False
                        btnValidar.Visible = False
                        btnGuardar.Visible = False
                        btnModificar.Visible = True
                        'imgPlazaCorrecta.Visible = False
                    End If
                    'btnGuardar.Visible = False
                End If
            Else
                ddlSindicatos.SelectedValue = "3"
                imgPlazaCorrecta.Visible = False
                pnlCvePlazaError.Visible = True
                If pValidaPlaza = True Then
                    dvPlaza.Enabled = False
                    btnValidar.Visible = False
                    btnGuardar.Visible = False
                    btnModificar.Visible = True
                    'imgPlazaCorrecta.Visible = False
                End If
                'btnGuardar.Visible = True
            End If
        Catch EX As Exception
            ddlSindicatos.SelectedValue = "3"
            imgPlazaCorrecta.Visible = False
            pnlCvePlazaError.Visible = True
            If pValidaPlaza = True Then
                dvPlaza.Enabled = False
                btnValidar.Visible = False
                btnGuardar.Visible = False
                btnModificar.Visible = True
                'imgPlazaCorrecta.Visible = False
            End If
            'btnGuardar.Visible = False
        End Try
    End Sub

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        If Request.Params("TipoOperacion") = "2" Then ddl.Enabled = False
    End Sub
    Private Sub BindgvPlazasHistoria()
        Dim oEmpPlaza As New Empleado
        Dim dtEmpPlaza As DataTable
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        dtEmpPlaza = oEmpPlaza.ObtenHistoria(IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons")), True)

        gvPlazasHistoria.DataSource = dtEmpPlaza
        gvPlazasHistoria.DataBind()

        If dtEmpPlaza.Rows.Count > 0 Then
            'Dim ddlSindicatos As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicatos"), DropDownList)
            'ddlSindicatos = CType(Me.dvPlaza.FindControl("ddlSindicatos"), DropDownList)

            Dim ddlEsquemaPago As DropDownList = CType(Me.dvPlaza.FindControl("ddlEsquemaPago"), DropDownList)
            'ddlSindicatos.SelectedValue = dtEmpPlaza.Rows(0).Item("IdSindicato").ToString
            ddlEsquemaPago.SelectedValue = dtEmpPlaza.Rows(0).Item("IdEsquemaPago").ToString
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Response.Expires = 0

            Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
            Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

            BtnNewSearch.Visible = False
            BtnCancelSearch.Visible = False
            BtnSearch.Visible = False

            btnCancelar = CType(dvBotones.FindControl("btnCancelar"), Button)

            If Request.Params("TipoOperacion") = "1" Then
                lbOtraOperacion.Visible = False
            Else
                lbOtraOperacion.Visible = True
            End If

            Dim vlComplementoURL As String = String.Empty

            If Request.Params("IdSemestre") Is Nothing = False And Request.Params("IdQuincena") Is Nothing = False Then
                vlComplementoURL = "?IdSemestre=" + Request.Params("IdSemestre").ToString + "&IdQuincena=" + Request.Params("IdQuincena").ToString
            End If

            If Session("URLAnt") Is Nothing = False Then
                If Session("URLAnt").ToString.Contains(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString) Then
                    btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                    ibRegresar.PostBackUrl = "~/MenuPrincipal.aspx"
                Else
                    btnCancelar.PostBackUrl = "~/" + Session("URLAnt") + vlComplementoURL
                    ibRegresar.PostBackUrl = "~/" + Session("URLAnt") + vlComplementoURL
                End If
            Else
                btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                ibRegresar.PostBackUrl = "~/MenuPrincipal.aspx"
            End If

            Session.Remove("RFCParaCons2")
            Session.Remove("ApePatParaCons2")
            Session.Remove("ApeMatParaCons2")
            Session.Remove("NombreParaCons2")
            Session.Remove("NumEmpParaCons2")

            Me.MultiView1.SetActiveView(Me.viewPlazas)

            pnlCvePlaza = CType(dvPlaza.FindControl("pnlCvePlaza"), Panel)
            pnlCvePlazaError = CType(dvPlaza.FindControl("pnlCvePlazaError"), Panel)

            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            ddlEmpleadosFunciones = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            txtbxConsPlaza = CType(dvPlaza.FindControl("txtbxConsPlaza"), TextBox)
            imgPlazaCorrecta = CType(Me.dvPlaza.FindControl("imgPlazaCorrecta"), Image)

            Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
            Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
            Dim lblZECentroAdscripFisica As Label = CType(Me.dvPlaza.FindControl("lblZECentroAdscripFisica"), Label)
            Dim lblZEPlantelAdscripReal As Label = CType(Me.dvPlaza.FindControl("lblZEPlantelAdscripReal"), Label)
            Dim ddlCentrosDeTrabajo As DropDownList = CType(Me.dvPlaza.FindControl("ddlCentrosDeTrabajo"), DropDownList)
            Dim ddlTiposDeNominas As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeNominas"), DropDownList)
            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)

            'Dim ddlSindicatos As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicatos"), DropDownList)
            ddlSindicatos = CType(Me.dvPlaza.FindControl("ddlSindicatos"), DropDownList)

            Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
            Dim ChckBxTratarComoBase As CheckBox = CType(Me.dvPlaza.FindControl("ChckBxTratarComoBase"), CheckBox)
            Dim chkbxInterinoPuro As CheckBox = CType(Me.dvPlaza.FindControl("chkbxInterinoPuro"), CheckBox)
            Dim ddlFuncionesPri As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesPri"), DropDownList)
            Dim ddlFuncionesSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesSec"), DropDownList)
            Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
            'Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            ddlQnaTermino = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
            Dim ddlMotivoInterinato As DropDownList = (CType(Me.dvPlaza.FindControl("ddlMotivoInterinatoI"), DropDownList))
            'Dim ddlCadenas As DropDownList = CType(Me.dvPlaza.FindControl("ddlCadenas"), DropDownList)
            ddlCadenas = CType(Me.dvPlaza.FindControl("ddlCadenas"), DropDownList)
            Dim ddlTiposDeSemestres As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeSemestres"), DropDownList)
            Dim ddlEsquemaPago As DropDownList = CType(Me.dvPlaza.FindControl("ddlEsquemaPago"), DropDownList)
            Dim lblFechaBajaISSSTE As Label = CType(Me.dvPlaza.FindControl("lblFechaBajaISSSTE"), Label)
            Dim txtbxFechaBajaISSSTE As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE"), TextBox)
            Dim txtbxFechaBajaISSSTE_CV As CompareValidator = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE_CV"), CompareValidator)
            Dim txtbxFechaIni As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaIni"), TextBox)
            Dim txtbxFechaFin As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaFin"), TextBox)
            Dim chkbxVigFinAbierta As CheckBox = CType(Me.dvPlaza.FindControl("chkbxVigFinAbierta"), CheckBox)
            Dim ibFechaFin As ImageButton = CType(dvPlaza.FindControl("ibFechaFin"), ImageButton)

            ddlTramites = CType(Me.dvPlaza.FindControl("ddlTramites"), DropDownList)
            ddlMotivos = CType(Me.dvPlaza.FindControl("ddlMotivos"), DropDownList)

            btnGuardar = CType(dvBotones.FindControl("btnGuardar"), Button)
            btnValidar = CType(dvBotones.FindControl("btnValidar"), Button)
            btnModificar = CType(dvBotones.FindControl("btnModificar"), Button)

            Dim oEmp As New EmpleadoFuncion
            Dim oPlantel As New Plantel
            Dim oTipoDeNomina As New TipoDeNomina
            Dim oCT As New CentroDeTrabajo
            Dim oCategoria As New Categoria
            Dim oSindicato As New Sindicato
            Dim oPlazaTipoOcupacion As New TipoOcupacion
            Dim oPlaza As New TipoOcupacion
            Dim oQna As New Quincenas
            Dim oEmpleadoPlaza As New EmpleadoPlazas
            Dim dr, dr2 As DataRow
            Dim drQna As DataRow
            Dim EmpPlzTienePagoEnQna As Boolean = False
            Dim oEmp2 As New Empleado
            Dim drFuncionPriPorCatego As DataRow
            'Dim drFuncionPriSecPorPlaza As DataRow
            Dim drEmpsPlazasDatosComplemen As DataRow
            Dim drMotivoGeneralDeBaja As DataRow
            Dim drMotGralDeBaja As DataRow
            Dim drTratarPlazaComoBase As DataRow
            Dim OcupacionEsInterina, OcupacionEsProvisional, OcupacionEsBase As Boolean
            Dim oCadena As New Cadenas
            Dim drCadena As DataRow
            Dim oSemestre As New Semestre
            Dim drPlazasHistoria As DataRow
            Dim dtPlantelAdscripFisica As DataTable
            Dim drPlantelAdscripFisica As DataRow
            Dim dtPlantelAdscripReal As DataTable
            Dim drPlantelAdscripReal As DataRow
            Dim oNomina As New Nomina
            Dim tblEsquemaPagoPorDefault As DataTable

            If Request.Params("TipoOperacion") = "1" And Request.Params("CopiarUltVig") Is Nothing Then 'Insertar
                'BindgvPlazasHistoria()

                lbOtraOperacion.Visible = False
                LlenaDDL(ddlEmpleadosFunciones, "DescEmpFuncion", "IdEmpFuncion", oEmp.ObtenFunciones)
                LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True))
                LlenaDDL(ddlCentrosDeTrabajo, "CentroDeTrabajo", "IdCT", oCT.ObtenPorPlantel(CShort(ddlPlanteles.SelectedValue)))
                LlenaDDL(ddlCTAdscipReal, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True), ddlPlanteles.SelectedValue)

                dtPlantelAdscripFisica = oPlantel.ObtenPorId(CShort(ddlPlanteles.SelectedValue))
                drPlantelAdscripFisica = dtPlantelAdscripFisica.Rows(0)

                dtPlantelAdscripReal = oPlantel.ObtenPorId(CShort(ddlCTAdscipReal.SelectedValue))
                drPlantelAdscripReal = dtPlantelAdscripReal.Rows(0)

                lblZECentroAdscripFisica.Text = "Zona económica " + drPlantelAdscripFisica("ClaveZonaEco").ToString
                lblZEPlantelAdscripReal.Text = "Zona económica " + drPlantelAdscripReal("ClaveZonaEco").ToString

                LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenPorFuncionDelEmpleado(CByte(ddlEmpleadosFunciones.SelectedValue)))
                LlenaDDL(ddlTiposDeNominas, "DescFondoPresup", "IdTipoNomina", oTipoDeNomina.ObtenPorCategoria(CShort(ddlCategorias.SelectedValue)))
                LlenaDDL(ddlSindicatos, "SiglasSindicato", "IdSindicato", oSindicato.ObtenTodos(True))
                LlenaDDL(ddlPlazasTipoOcup, "DescPlazaTipoOcupacion", "IdPlazaTipoOcupacion", oPlazaTipoOcupacion.ObtenTodos)
                ddlPlazasTipoOcup_SelectedIndexChanged(sender, e)
                LlenaDDL(ddlMotivoInterinato, "DescMotivoInterinato", "IdMotivoHoraInterina", oPlaza.ObtenMotivosInterinatos(), String.Empty)
                LlenaDDL(ddlFuncionesPri, "FuncionPri", "IdFuncionPri", oEmp2.ObtenFuncionesPrimarias())

                drFuncionPriPorCatego = oCategoria.ObtenFuncionPrimaria(CShort(ddlCategorias.SelectedValue))
                ddlFuncionesPri.Items.FindByValue(drFuncionPriPorCatego("IdFuncionPri").ToString).Selected = True

                LlenaDDL(ddlFuncionesSec, "FuncionSec", "IdFuncionSec", oEmp2.ObtenFuncionesSecundarias())
                LlenaDDL(ddlMotivosDeBaja, "MotGralBaja", "IdMotGralBaja", oEmp2.ObtenMotivosDeBaja(), "25")
                LlenaDDL(ddlCadenas, "NumCadena2", "IdCadena", oCadena.ObtenAbiertasPorUsr(Session("Login")))
                LlenaDDL(ddlTiposDeSemestres, "TipoSemestre", "IdTipoSemestre", oSemestre.ObtenTipos())

                tblEsquemaPagoPorDefault = oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue))
                LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), True), tblEsquemaPagoPorDefault.Rows(0).Item("IdEsquemaPago").ToString)

                LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True))
                Dim dtQnasAbiertasParaCaptura As DataTable
                dtQnasAbiertasParaCaptura = oQna.ObtenAbiertasParaCaptura()
                If dtQnasAbiertasParaCaptura.Rows.Count > 0 Then
                    ddlQnaInicio.SelectedValue = CStr(dtQnasAbiertasParaCaptura.Rows(0).Item("IdQuincena"))
                Else
                    ddlQnaInicio.SelectedIndex = 0
                End If
                'ddlQnaInicio.SelectedIndex = 1
                drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaInicio.SelectedValue), "I")
                txtbxFechaIni.Text = drQna.Item("Fecha").ToString

                LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True))
                If ddlQnaTermino.SelectedValue = "32767" Then
                    chkbxVigFinAbierta.Checked = True
                    ibFechaFin.Visible = False
                    'chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
                End If

                drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaTermino.SelectedValue), "F")
                txtbxFechaFin.Text = drQna.Item("Fecha").ToString

                drMotGralDeBaja = oEmp2.ObtenMotivosDeBaja(CShort(ddlMotivosDeBaja.SelectedValue))

                lblFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))
                lblFechaBajaISSSTE.Text = drMotGralDeBaja("TextoEtiquetaBaja").ToString
                txtbxFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))

                'drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaTermino.SelectedValue), "F")

                txtbxFechaBajaISSSTE.Text = drQna("Fecha").ToString

                txtbxFechaBajaISSSTE_CV.Enabled = txtbxFechaBajaISSSTE.Visible

                Bind_ddlTramites()

                UpdateClavePlaza()

            ElseIf Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "2" Or Request.Params("TipoOperacion") = "4" _
                  Or (Request.Params("TipoOperacion") = "1" And Request.Params("CopiarUltVig") = "SI") Then 'Actualizar o Eliminar
                'BindgvPlazasHistoria()
                If Request.Params("CopiarUltVig") Is Nothing Then
                    oEmpleadoPlaza.IdPlaza = CType(Request.Params("IdPlaza"), Integer)
                    dr = oEmpleadoPlaza.ObtenPorId()
                    drPlazasHistoria = oEmpleadoPlaza.ObtenInfDeTblPlazasHistoria(CType(Request.Params("IdPlaza"), Integer))
                    'drFuncionPriSecPorPlaza = oEmpleadoPlaza.ObtenFuncionesPri_Y_Sec(CInt(Request.Params("IdPlaza")))
                    drEmpsPlazasDatosComplemen = oEmpleadoPlaza.ObtenDatosComplementarios(CInt(Request.Params("IdPlaza")))
                    drMotivoGeneralDeBaja = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(Request.Params("IdPlaza")))
                    drTratarPlazaComoBase = oEmpleadoPlaza.ObtenSiPlazaSeraTratadaComoBase(CInt(Request.Params("IdPlaza")))
                    drCadena = oCadena.ObtenSiPlazaEstaEnCadena(CInt(Request.Params("IdPlaza")))
                Else
                    dr = oEmpleadoPlaza.ObtenUltimaOcupada(Request.Params("RFCEmp"))
                    drPlazasHistoria = oEmpleadoPlaza.ObtenInfDeTblPlazasHistoria(CInt(dr("IdPlaza")))
                    'drFuncionPriSecPorPlaza = oEmpleadoPlaza.ObtenFuncionesPri_Y_Sec(CInt(dr("IdPlaza")))
                    drEmpsPlazasDatosComplemen = oEmpleadoPlaza.ObtenDatosComplementarios(CInt(Request.Params("IdPlaza")))
                    drMotivoGeneralDeBaja = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(dr("IdPlaza")))
                    drTratarPlazaComoBase = oEmpleadoPlaza.ObtenSiPlazaSeraTratadaComoBase(CInt(dr("IdPlaza")))
                    drCadena = oCadena.ObtenSiPlazaEstaEnCadena(CInt(dr("IdPlaza")))
                End If
                LlenaDDL(ddlEmpleadosFunciones, "DescEmpFuncion", "IdEmpFuncion", oEmp.ObtenFunciones, dr("IdEmpFuncion").ToString)
                LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True), dr("IdPlantel").ToString)
                lblZECentroAdscripFisica.Text = "Zona económica " + drEmpsPlazasDatosComplemen("ZonaEcoPlantelAdscripFisica").ToString

                If Request.Params("TipoOperacion") = "4" Then
                    oCT.IdCT = CShort(dr("IdCT"))
                    LlenaDDL(ddlCentrosDeTrabajo, "CentroDeTrabajo", "IdCT", oCT.ObtenPorId(), dr("IdCT").ToString)
                Else
                    LlenaDDL(ddlCentrosDeTrabajo, "CentroDeTrabajo", "IdCT", oCT.ObtenPorPlantel(CShort(ddlPlanteles.SelectedValue)), dr("IdCT").ToString)
                End If

                LlenaDDL(ddlCTAdscipReal, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True), drEmpsPlazasDatosComplemen("IdPlantelAdscripReal").ToString)
                lblZEPlantelAdscripReal.Text = "Zona económica " + drEmpsPlazasDatosComplemen("ZonaEcoPlantelAdscripReal").ToString

                LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenPorFuncionDelEmpleado(CByte(ddlEmpleadosFunciones.SelectedValue)), dr("IdCategoria").ToString)
                'ddlCategorias.Enabled = True 'quitar
                LlenaDDL(ddlTiposDeNominas, "DescFondoPresup", "IdTipoNomina", oTipoDeNomina.ObtenPorCategoria(CShort(ddlCategorias.SelectedValue)), dr("IdTipoNomina").ToString)
                LlenaDDL(ddlSindicatos, "SiglasSindicato", "IdSindicato", oSindicato.ObtenTodos(True), dr("IdSindicato").ToString)
                LlenaDDL(ddlPlazasTipoOcup, "DescPlazaTipoOcupacion", "IdPlazaTipoOcupacion", oPlazaTipoOcupacion.ObtenTodos, dr("IdPlazaTipoOcupacion").ToString)
                ChckBxTratarComoBase.Checked = CBool(drTratarPlazaComoBase("TratarComoBase"))
                chkbxInterinoPuro.Checked = CBool(drTratarPlazaComoBase("InterinoPuro"))
                OcupacionEsInterina = oPlaza.EsInterina(CByte(ddlPlazasTipoOcup.SelectedValue), True)
                OcupacionEsProvisional = oPlaza.EsProvisional(CByte(ddlPlazasTipoOcup.SelectedValue), True)
                OcupacionEsBase = oPlaza.EsBase(CByte(ddlPlazasTipoOcup.SelectedValue), True)
                If Request.Params("TipoOperacion") = "2" Then
                    ChckBxTratarComoBase.Enabled = (OcupacionEsInterina = True Or OcupacionEsProvisional = True Or OcupacionEsBase = True)
                    chkbxInterinoPuro.Enabled = OcupacionEsInterina = True
                Else
                    ChckBxTratarComoBase.Enabled = False
                    chkbxInterinoPuro.Enabled = False
                End If
                dr2 = oEmpleadoPlaza.ObtenTitular()
                If oPlaza.EsInterina(CByte(ddlPlazasTipoOcup.SelectedValue), True) And dr2("RFCEmp").ToString <> String.Empty Then
                    Session.Add("RFCParaCons2", dr2("RFCEmp"))
                    Session.Add("ApePatParaCons2", dr2("ApePatEmp"))
                    Session.Add("ApeMatParaCons2", dr2("ApeMatEmp"))
                    Session.Add("NombreParaCons2", dr2("NomEmp"))
                    Session.Add("NumEmpParaCons2", dr2("NumEmp"))
                End If
                ddlPlazasTipoOcup_SelectedIndexChanged(sender, e)
                LlenaDDL(ddlMotivoInterinato, "DescMotivoInterinato", "IdMotivoHoraInterina", oPlaza.ObtenMotivosInterinatos(), dr2("IdMotivoInterinato"))

                LlenaDDL(ddlFuncionesPri, "FuncionPri", "IdFuncionPri", oEmp2.ObtenFuncionesPrimarias(), drEmpsPlazasDatosComplemen("IdFuncionPri").ToString)
                LlenaDDL(ddlFuncionesSec, "FuncionSec", "IdFuncionSec", oEmp2.ObtenFuncionesSecundarias(), drEmpsPlazasDatosComplemen("IdFuncionSec").ToString)
                LlenaDDL(ddlMotivosDeBaja, "MotGralBaja", "IdMotGralBaja", oEmp2.ObtenMotivosDeBaja(), drMotivoGeneralDeBaja("IdMotGralBaja").ToString)

                If (Request.Params("TipoOperacion") = "1" And Request.Params("CopiarUltVig") = "SI") Then
                    LlenaDDL(ddlCadenas, "NumCadena2", "IdCadena", oCadena.ObtenAbiertasPorUsr(Session("Login")))
                ElseIf Request.Params("TipoOperacion") = "4" Then
                    ddlCadenas.Items.Add(New ListItem(drCadena("NumCadena2").ToString, drCadena("IdCadena").ToString))
                ElseIf Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "2" Then
                    LlenaDDL(ddlCadenas, "NumCadena2", "IdCadena", oCadena.ObtenAbiertasPorUsr(Session("Login")))
                    If CType(ddlCadenas.Items.FindByValue(drCadena("IdCadena").ToString), ListItem) Is Nothing Then
                        ddlCadenas.Items.Add(New ListItem(drCadena("NumCadena2").ToString, drCadena("IdCadena").ToString))
                    End If
                    ddlCadenas.SelectedValue = drCadena("IdCadena").ToString
                End If

                LlenaDDL(ddlTiposDeSemestres, "TipoSemestre", "IdTipoSemestre", oSemestre.ObtenTipos(), dr("IdTipoSemestre").ToString)
                LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), True), drEmpsPlazasDatosComplemen("IdEsquemaPago").ToString)

                If Request.Params("TipoOperacion") = "2" Then
                    Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = CType(Me.dvPlaza.FindControl("WucBuscaEmpleados2_I"), WebControls_wucSearchEmps2)
                    Dim txtbxRFC As TextBox = CType(WucBuscaEmpleados2.FindControl("txtbxRFC"), TextBox)
                    Dim txtbxNomEmp As TextBox = CType(WucBuscaEmpleados2.FindControl("txtbxNomEmp"), TextBox)
                    Dim txtbxNumEmp As TextBox = CType(WucBuscaEmpleados2.FindControl("txtbxNumEmp"), TextBox)
                    Dim BtnSearch2 As Button = CType(WucBuscaEmpleados2.FindControl("BtnSearch"), Button)
                    Dim BtnNewSearch2 As Button = CType(WucBuscaEmpleados2.FindControl("BtnNewSearch"), Button)
                    Dim BtnCancelSearch2 As Button = CType(WucBuscaEmpleados2.FindControl("BtnCancelSearch"), Button)
                    txtbxRFC.Enabled = False
                    txtbxNomEmp.Enabled = False
                    txtbxNumEmp.Enabled = False
                    BtnSearch2.Visible = False
                    BtnNewSearch2.Visible = False
                    BtnCancelSearch2.Visible = False
                End If

                If Request.Params("TipoOperacion") = "0" Then
                    EmpPlzTienePagoEnQna = oEmpleadoPlaza.TienePagosAPartirDeQna(CShort(dr("QnaVigIni").ToString), CByte(Request.Params("TipoOperacion")))
                End If
                If Request.Params("TipoOperacion") = "2" Or (Request.Params("TipoOperacion") = "0" And EmpPlzTienePagoEnQna) Then
                    ddlQnaInicio.Items.Insert(0, dr("Inicio").ToString)
                    ddlQnaInicio.Items(0).Value = dr("QnaVigIni").ToString

                    txtbxFechaIni.Text = drPlazasHistoria.Item("FechaInicio").ToString

                    If Request.Params("TipoOperacion") = "2" Then
                        ddlQnaInicio.Enabled = False
                        txtbxFechaIni.Enabled = False
                    End If
                Else
                    If Request.Params("CopiarUltVig") = "SI" Then
                        LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True))
                        ddlQnaInicio.SelectedIndex = 1

                        drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaInicio.SelectedValue), "I")
                        txtbxFechaIni.Text = drQna.Item("Fecha").ToString

                        LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True))

                        If ddlQnaTermino.SelectedValue = "32767" Then
                            chkbxVigFinAbierta.Checked = True
                            ibFechaFin.Visible = False
                            'chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
                        End If

                        drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaTermino.SelectedValue), "F")
                        txtbxFechaFin.Text = drQna.Item("Fecha").ToString
                    Else
                        If Request.Params("TipoOperacion") = "4" Then
                            ddlQnaInicio.Items.Insert(0, dr("Inicio").ToString)
                            ddlQnaInicio.Items(0).Value = dr("QnaVigIni").ToString

                            txtbxFechaIni.Text = Left(drPlazasHistoria.Item("FechaInicio").ToString, 10)
                        Else
                            LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True), dr("QnaVigIni").ToString)

                            drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaInicio.SelectedValue), "I")
                            txtbxFechaIni.Text = drQna.Item("Fecha").ToString
                        End If
                    End If
                End If
                If Request.Params("TipoOperacion") <> "2" Then
                    If Request.Params("CopiarUltVig") Is Nothing Then
                        If Request.Params("TipoOperacion") = "4" Then
                            ddlQnaTermino.Items.Insert(0, dr("Término").ToString)
                            ddlQnaTermino.Items(0).Value = dr("QnaVigFin").ToString

                            If ddlQnaTermino.SelectedValue = "32767" Then
                                chkbxVigFinAbierta.Checked = True
                                ibFechaFin.Visible = False
                                'chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
                            End If

                            txtbxFechaFin.Text = Left(drPlazasHistoria.Item("FechaFin").ToString, 10)

                        Else
                            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True), dr("QnaVigFin").ToString)

                            If ddlQnaTermino.SelectedValue = "32767" Then
                                chkbxVigFinAbierta.Checked = True
                                ibFechaFin.Visible = False
                                'chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
                            End If

                            drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaTermino.SelectedValue), "F")
                            txtbxFechaFin.Text = drQna.Item("Fecha").ToString
                        End If
                    End If
                Else
                    LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenPosiblesParaPago(CType(Request.Params("IdPlaza"), Integer)), dr("QnaVigFin").ToString)

                    If ddlQnaTermino.SelectedValue = "32767" Then
                        chkbxVigFinAbierta.Checked = True
                        ibFechaFin.Visible = False
                        'chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
                    End If

                    drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaTermino.SelectedValue), "F")
                    txtbxFechaFin.Text = drQna.Item("Fecha").ToString
                End If
                'ddlQnaTermino.Enabled = True
                ddlMotivosDeBaja.Enabled = True 'Lo habilitamos para que se pueda modificar el motivo de la baja en todo momento

                drMotGralDeBaja = oEmp2.ObtenMotivosDeBaja(CShort(ddlMotivosDeBaja.SelectedValue))

                lblFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))
                lblFechaBajaISSSTE.Text = drMotGralDeBaja("TextoEtiquetaBaja").ToString
                txtbxFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))

                drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaTermino.SelectedValue), "F")

                txtbxFechaBajaISSSTE.Text = drPlazasHistoria("FechaFin").ToString

                txtbxFechaBajaISSSTE_CV.Enabled = txtbxFechaBajaISSSTE.Visible

                ddlCadenas.Enabled = True 'Lo habilitamos para que el usuario pueda indicar si el movimiento de baja formará parte de una cadena o no
                If Request.Params("TipoOperacion") = "4" Then
                    dvPlaza.Enabled = False
                    'CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Visible = False
                    btnGuardar.Visible = False
                    btnCancelar.Visible = False
                    'btnRegresar.Visible = True
                End If

                UpdateClavePlaza()
            End If
        Else
            pnlCvePlaza = CType(dvPlaza.FindControl("pnlCvePlaza"), Panel)
            pnlCvePlazaError = CType(dvPlaza.FindControl("pnlCvePlazaError"), Panel)
            ddlEmpleadosFunciones = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            txtbxConsPlaza = CType(dvPlaza.FindControl("txtbxConsPlaza"), TextBox)
            imgPlazaCorrecta = CType(Me.dvPlaza.FindControl("imgPlazaCorrecta"), Image)
            ddlSindicatos = CType(Me.dvPlaza.FindControl("ddlSindicatos"), DropDownList)
            ddlCadenas = CType(Me.dvPlaza.FindControl("ddlCadenas"), DropDownList)
            ddlQnaTermino = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            ddlTramites = CType(Me.dvPlaza.FindControl("ddlTramites"), DropDownList)
            ddlMotivos = CType(Me.dvPlaza.FindControl("ddlMotivos"), DropDownList)
            btnCancelar = CType(dvBotones.FindControl("btnCancelar"), Button)
            btnGuardar = CType(dvBotones.FindControl("btnGuardar"), Button)
            btnValidar = CType(dvBotones.FindControl("btnValidar"), Button)
            btnModificar = CType(dvBotones.FindControl("btnModificar"), Button)
        End If
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Deshabilitamos el botón guardar para evitar el doble click
            'CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Visible = False

            Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
            'Dim ddlQuincenaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim ddlFuncionesPri As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesPri"), DropDownList)
            Dim ddlFuncionesSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesSec"), DropDownList)
            Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
            'Dim ddlCadenas As DropDownList = CType(Me.dvPlaza.FindControl("ddlCadenas"), DropDownList)
            Dim ddlTiposDeSemestres As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeSemestres"), DropDownList)
            Dim ddlEsquemaPago As DropDownList = CType(Me.dvPlaza.FindControl("ddlEsquemaPago"), DropDownList)
            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
            'Dim ddlSindicatos As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicatos"), DropDownList)
            Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
            Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
            Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
            Dim txtbxFechaBajaISSSTE As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE"), TextBox)
            Dim vl_IdPlaza As Integer

            'Código de validación
            Dim oValidacion As New Validaciones
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsValida As DataSet
            dsValida = _DataCOBAEV.setDataSetErrores()

            With oValidacion
                .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
                .IdPlaza = CType(Request.Params("IdPlaza"), Integer)
                .IdQuincena = CShort(ddlQnaInicio.SelectedValue)
                .RFC = IIf(Request.Params("RFCEmp") Is Nothing, String.Empty, Request.Params("RFCEmp"))
                .IdQnaIni = CShort(ddlQnaInicio.SelectedValue)
                .IdQnaFin = CShort(ddlQnaTermino.SelectedValue)
                .IdEmpFuncion = CByte(ddlEmpleadosFunciones.SelectedValue)
                .IdMotGralBaja = CByte(ddlMotivosDeBaja.SelectedValue)
                .IdTipoSemestre = CByte(ddlTiposDeSemestres.SelectedValue)
                .IdCategoria = CShort(ddlCategorias.SelectedValue)
                .IdSindicato = CByte(ddlSindicatos.SelectedValue)
                .IdTipoEmp = CByte(ddlPlazasTipoOcup.SelectedValue)
                .IdPlantel = CShort(ddlPlanteles.SelectedValue)
                If Not .ValidaPaginasOperacion(dsValida) Then
                    Session.Add("dsValida", dsValida)
                    wucMuestraErrores1.ActualizaContenido()
                    MultiView1.SetActiveView(viewError)
                    Exit Sub
                    'Session.Add("dsValida", dsValida)
                    'Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            End With
            'Código de validación

            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim ddlTiposDeNominas As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeNominas"), DropDownList)
            Dim ddlCentrosDeTrabajo As DropDownList = CType(Me.dvPlaza.FindControl("ddlCentrosDeTrabajo"), DropDownList)
            'Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim ddlMotivoInterinato As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivoInterinatoI"), DropDownList)
            Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = CType(Me.dvPlaza.FindControl("WucBuscaEmpleados2_I"), WebControls_wucSearchEmps2)
            Dim hfRFC As HiddenField = CType(WucBuscaEmpleados2.FindControl("hfRFC"), HiddenField)
            Dim ChckBxTratarComoBase As CheckBox = CType(Me.dvPlaza.FindControl("ChckBxTratarComoBase"), CheckBox)
            Dim chkbxInterinoPuro As CheckBox = CType(Me.dvPlaza.FindControl("chkbxInterinoPuro"), CheckBox)
            Dim oEmpleadoPlaza As New EmpleadoPlazas
            Dim oCadena As New Cadenas
            Dim IdPlazaCreada As Integer
            With oEmpleadoPlaza
                .IdEmpFuncion = CType(ddlEmpleadosFunciones.SelectedValue, Byte)
                .IdPlantel = CType(ddlPlanteles.SelectedValue, Short)
                .IdPlantelAdscripReal = CType(ddlCTAdscipReal.SelectedValue, Short)
                .IdTipoNomina = CType(ddlTiposDeNominas.SelectedValue, Byte)
                .IdCT = CType(ddlCentrosDeTrabajo.SelectedValue, Short)
                .IdCategoria = CType(ddlCategorias.SelectedValue, Short)
                .IdSindicato = CType(ddlSindicatos.SelectedValue, Byte)
                .IdPlazaTipoOcupacion = CType(ddlPlazasTipoOcup.SelectedValue, Byte)
                .IdMotivoInterinato = CByte(ddlMotivoInterinato.SelectedValue)
                .RFCEmpTitular = hfRFC.Value
                .IdFuncionPri = CShort(ddlFuncionesPri.SelectedValue)
                .IdFuncionSec = CShort(ddlFuncionesSec.SelectedValue)
                .IdMotGralBaja = CByte(ddlMotivosDeBaja.SelectedValue)
                .TratarComoBase = ChckBxTratarComoBase.Checked
                .InterinoPuro = chkbxInterinoPuro.Checked
                .IdTipoSemestre = CByte(ddlTiposDeSemestres.SelectedValue)
                .FechaInicio = String.Empty
                .IdEsquemaPago = CByte(ddlEsquemaPago.SelectedValue)
                If txtbxFechaBajaISSSTE.Visible = True Then
                    .FechaFin = IIf(txtbxFechaBajaISSSTE.Text <> String.Empty, txtbxFechaBajaISSSTE.Text, String.Empty)
                Else
                    .FechaFin = String.Empty
                End If
                If Request.Params("TipoOperacion") = "0" Then
                    .IdPlaza = CInt(Request.Params("IdPlaza"))
                    vl_IdPlaza = CInt(Request.Params("IdPlaza"))
                    .Actualizar(CType(ddlQnaInicio.SelectedValue, Short), CType(ddlQnaTermino.SelectedValue, Short), CType(Session("ArregloAuditoria"), String()))
                    oCadena.ActualizaMov(CInt(ddlCadenas.SelectedValue), CInt(Request.Params("IdPlaza")), Session("Login"), "A", CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    IdPlazaCreada = .AgregaNueva(Request.Params("RFCEmp"), CType(ddlQnaInicio.SelectedValue, Short), CType(ddlQnaTermino.SelectedValue, Short), 1, CType(Session("ArregloAuditoria"), String()))
                    vl_IdPlaza = IdPlazaCreada
                    oCadena.AgregaMovs(CInt(ddlCadenas.SelectedValue), IdPlazaCreada, Session("Login"), "A", CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "2" Then
                    .IdPlaza = CInt(Request.Params("IdPlaza"))
                    vl_IdPlaza = CInt(Request.Params("IdPlaza"))
                    .GeneraBaja(CType(ddlQnaInicio.SelectedValue, Short), CType(ddlQnaTermino.SelectedValue, Short), CByte(Request.Params("TipoOperacion")), CType(Session("ArregloAuditoria"), String()))
                    oCadena.AgregaMovs(CInt(ddlCadenas.SelectedValue), CInt(Request.Params("IdPlaza")), Session("Login"), "B", CType(Session("ArregloAuditoria"), String()))
                End If
                Me.MultiView1.SetActiveView(Me.viewExito)
                If Request.Params("TipoOperacion") = "0" Then
                    gvObservsPlaza.DataSource = oEmpleadoPlaza.ObservsPlaza(vl_IdPlaza)
                    gvObservsPlaza.DataBind()
                    gvObservsPlaza.Visible = gvObservsPlaza.Rows.Count > 0
                    btnPrint.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                                            + "?IdPlaza=" + vl_IdPlaza.ToString _
                                                            + "&IdReporte=97" + "','RptObservPlaza_" + vl_IdPlaza.ToString + "'); return false;"
                    btnPrint.Visible = gvObservsPlaza.Visible
                    Me.lblExito.Text = "Plaza modificada exitosamente."
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    gvObservsPlaza.DataSource = oEmpleadoPlaza.ObservsPlaza(vl_IdPlaza)
                    gvObservsPlaza.DataBind()
                    gvObservsPlaza.Visible = gvObservsPlaza.Rows.Count > 0
                    btnPrint.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                                            + "?IdPlaza=" + vl_IdPlaza.ToString _
                                                            + "&IdReporte=97" + "','RptObservPlaza_" + vl_IdPlaza.ToString + "'); return false;"
                    btnPrint.Visible = gvObservsPlaza.Visible
                    Me.lblExito.Text = "Nueva plaza creada exitosamente."
                    oEmpleadoPlaza.ObservsPlaza(vl_IdPlaza)
                ElseIf Request.Params("TipoOperacion") = "2" Then
                    gvObservsPlaza.Visible = False
                    btnPrint.Visible = False
                    Me.lblExito.Text = "Plaza dada de baja exitosamente."
                End If
            End With
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub ddlQuincenaInicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        'Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim chkbxVigFinAbierta As CheckBox = CType(Me.dvPlaza.FindControl("chkbxVigFinAbierta"), CheckBox)
        Dim ibFechaFin As ImageButton = CType(Me.dvPlaza.FindControl("ibFechaFin"), ImageButton)

        Dim oQna As New Quincenas
        If Request.Params("TipoOperacion") <> "2" Then
            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True))

            If ddlQnaTermino.SelectedValue = "32767" Then
                chkbxVigFinAbierta.Checked = True
                ibFechaFin.Visible = False
                'chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
            End If
        Else
            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenPosiblesParaPago(CType(Request.Params("IdPlaza"), Integer)))

            If ddlQnaTermino.SelectedValue = "32767" Then
                chkbxVigFinAbierta.Checked = True
                ibFechaFin.Visible = False
                'chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
            End If
        End If
    End Sub

    Protected Sub ddlEmpleadosFunciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlTiposDeNominas As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeNominas"), DropDownList)
        Dim ddlMotivoInterinatoI As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivoInterinatoI"), DropDownList)
        Dim oCatego As New Categoria
        Dim oTipoDeNomina As New TipoDeNomina
        ddlCategorias.DataSource = oCatego.ObtenPorFuncionDelEmpleado(CByte(ddlEmpleadosFunciones.SelectedValue))
        ddlCategorias.DataBind()
        ddlCategorias_SelectedIndexChanged(Nothing, Nothing)

        'La parte de interinos solo funciona para administrativos
        If CByte(ddlEmpleadosFunciones.SelectedValue) = 2 Then
            Dim ddlMotivoInterinato As DropDownList = Nothing
            Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = Nothing
            Dim LblEmpTitularSD As Label = Nothing
            If Me.dvPlaza.CurrentMode = DetailsViewMode.Insert Then
                ddlMotivoInterinato = CType(Me.dvPlaza.FindControl("ddlMotivoInterinatoI"), DropDownList)
                WucBuscaEmpleados2 = CType(Me.dvPlaza.FindControl("WucBuscaEmpleados2_I"), WebControls_wucSearchEmps2)
                LblEmpTitularSD = CType(Me.dvPlaza.FindControl("LblEmpTitularSDI"), Label)
            End If

            ddlMotivoInterinato.Enabled = False
            ddlMotivoInterinato.SelectedValue = "1"
            WucBuscaEmpleados2.Visible = False
            LblEmpTitularSD.Visible = True
        End If

        ddlCategorias_SelectedIndexChanged1(Nothing, Nothing)
    End Sub

    Protected Sub ddlCategorias_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlTiposDeNominas As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeNominas"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlEsquemaPago As DropDownList = CType(Me.dvPlaza.FindControl("ddlEsquemaPago"), DropDownList)
        Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
        'Dim tblEsquemaPagoPorDefault As DataTable

        Dim oTipoDeNomina As New TipoDeNomina
        Dim SelectedValueAnt As String
        Dim oNomina As New Nomina

        SelectedValueAnt = ddlTiposDeNominas.SelectedValue
        LlenaDDL(ddlTiposDeNominas, "DescFondoPresup", "IdTipoNomina", oTipoDeNomina.ObtenPorCategoria(CShort(ddlCategorias.SelectedValue)))

        'tblEsquemaPagoPorDefault = oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue))
        'LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), True), tblEsquemaPagoPorDefault.Rows(0).Item("IdEsquemaPago").ToString)

        'ddlTiposDeNominas.DataSource = oTipoDeNomina.ObtenPorCategoria(CByte(ddlCategorias.SelectedValue))
        'ddlTiposDeNominas.DataBind()

        'Para evitar el error de que se quiera asignar un valor a SelectedValue inexistente
        Try
            ddlTiposDeNominas.SelectedValue = SelectedValueAnt
            ddlPlazasTipoOcup_SelectedIndexChanged(Nothing, Nothing)
        Catch ex As Exception

        End Try

        ddlCategorias_SelectedIndexChanged1(Nothing, Nothing)
        UpdateClavePlaza()
    End Sub

    Protected Sub ddlPlanteles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim lblZECentroAdscripFisica As Label = CType(Me.dvPlaza.FindControl("lblZECentroAdscripFisica"), Label)
        Dim ddlCentrosDeTrabajo As DropDownList = CType(Me.dvPlaza.FindControl("ddlCentrosDeTrabajo"), DropDownList)
        Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
        Dim ddlEsquemaPago As DropDownList = CType(Me.dvPlaza.FindControl("ddlEsquemaPago"), DropDownList)

        Dim oCT As New CentroDeTrabajo
        Dim dtPlantelAdscripFisica As DataTable
        Dim drPlantelAdscripFisica As DataRow
        Dim oPlantel As New Plantel
        Dim oNomina As New Nomina
        'Dim tblEsquemaPagoPorDefault As DataTable

        dtPlantelAdscripFisica = oPlantel.ObtenPorId(CShort(ddlPlanteles.SelectedValue))
        drPlantelAdscripFisica = dtPlantelAdscripFisica.Rows(0)
        lblZECentroAdscripFisica.Text = "Zona económica " + drPlantelAdscripFisica("ClaveZonaEco").ToString
        ddlCentrosDeTrabajo.DataSource = oCT.ObtenPorPlantel(CShort(ddlPlanteles.SelectedValue))
        ddlCentrosDeTrabajo.DataBind()
        'ddlCTAdscipReal.SelectedValue = ddlPlanteles.SelectedValue
        'ddlCTAdscipReal_SelectedIndexChanged(Nothing, Nothing)

        'tblEsquemaPagoPorDefault = oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue))
        'LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), True), tblEsquemaPagoPorDefault.Rows(0).Item("IdEsquemaPago").ToString)

        'LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue)))
    End Sub

    Protected Sub ddlPlazasTipoOcup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oPlaza As New Plazas.TipoOcupacion
        Dim ddlPlazasTipoOcup As DropDownList = Nothing
        Dim ddlMotivoInterinato As DropDownList = Nothing
        Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = Nothing
        Dim LblEmpTitularSD As Label = Nothing
        'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
        Dim ChckBxTratarComoBase As CheckBox = CType(Me.dvPlaza.FindControl("ChckBxTratarComoBase"), CheckBox)
        Dim chkbxInterinoPuro As CheckBox = CType(Me.dvPlaza.FindControl("chkbxInterinoPuro"), CheckBox)
        Dim OcupacionEsInterina, OcupacionEsProvisional, OcupacionEsBase As Boolean
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim oCategoria As New Categoria
        Dim drCategoriaHomologada As DataRow

        drCategoriaHomologada = oCategoria.ObtenSiEsHomologada(CShort(ddlCategorias.SelectedValue))

        If Me.dvPlaza.CurrentMode = DetailsViewMode.Insert Then
            ddlPlazasTipoOcup = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
            ddlMotivoInterinato = CType(Me.dvPlaza.FindControl("ddlMotivoInterinatoI"), DropDownList)
            WucBuscaEmpleados2 = CType(Me.dvPlaza.FindControl("WucBuscaEmpleados2_I"), WebControls_wucSearchEmps2)
            LblEmpTitularSD = CType(Me.dvPlaza.FindControl("LblEmpTitularSDI"), Label)
        End If

        Dim txtbxRFC As TextBox = CType(WucBuscaEmpleados2.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(WucBuscaEmpleados2.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados2.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(WucBuscaEmpleados2.FindControl("hfNomEmp"), HiddenField)
        'Dim ibBuscarEmp As ImageButton = CType(WucBuscaEmpleados2.FindControl("ibBuscarEmp"), ImageButton)
        Dim btnUpdTitularPlaza As Button = CType(dvBotones.FindControl("btnUpdTitularPlaza"), Button)
        'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=AdministracionPlazas','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false;")

        OcupacionEsInterina = oPlaza.EsInterina(CByte(ddlPlazasTipoOcup.SelectedValue), True)
        OcupacionEsProvisional = oPlaza.EsProvisional(CByte(ddlPlazasTipoOcup.SelectedValue), True)
        OcupacionEsBase = oPlaza.EsBase(CByte(ddlPlazasTipoOcup.SelectedValue), True)

        If Page.IsPostBack = True Or Request.Params("TipoOperacion") = "1" Then
            ChckBxTratarComoBase.Checked = False
            chkbxInterinoPuro.Checked = False
        End If
        ChckBxTratarComoBase.Enabled = (OcupacionEsInterina = True Or OcupacionEsProvisional = True Or OcupacionEsBase = True)
        chkbxInterinoPuro.Enabled = OcupacionEsInterina = True
        If Request.Params("TipoOperacion") = "2" Then
            ChckBxTratarComoBase.Enabled = False
            chkbxInterinoPuro.Enabled = False
        End If
        If drCategoriaHomologada("CategoriaEsHomologada") And Not OcupacionEsBase Then
            ChckBxTratarComoBase.Checked = True
            ChckBxTratarComoBase.Enabled = False
        ElseIf drCategoriaHomologada("CategoriaEsHomologada") And OcupacionEsBase Then
            ChckBxTratarComoBase.Checked = False
            ChckBxTratarComoBase.Enabled = False
            'ElseIf drCategoriaHomologada("CategoriaEsHomologada") And (OcupacionEsInterina Or OcupacionEsProvisional Or OcupacionEsBase) Then
            '    ChckBxTratarComoBase.Enabled = True And Request.Params("TipoOperacion") <> "2"
        Else
            ChckBxTratarComoBase.Checked = False
            ChckBxTratarComoBase.Enabled = False
        End If
        If OcupacionEsInterina And Request.Params("TipoOperacion") <> "2" Then
            chkbxInterinoPuro.Enabled = True
        Else
            'chkbxInterinoPuro.Checked = False
            chkbxInterinoPuro.Enabled = False
        End If
        If (OcupacionEsInterina) Then 'And ddlEmpleadosFunciones.SelectedValue = "1" Then
            Dim dr2 As DataRow
            Dim oEmpleadoPlaza As New EmpleadoPlazas
            oEmpleadoPlaza.IdPlaza = CInt(Request.Params("IdPlaza"))
            dr2 = oEmpleadoPlaza.ObtenTitular()
            If oPlaza.EsInterina(CByte(ddlPlazasTipoOcup.SelectedValue), True) And dr2("RFCEmp").ToString <> String.Empty Then
                Session.Add("RFCParaCons2", dr2("RFCEmp"))
                Session.Add("ApePatParaCons2", dr2("ApePatEmp"))
                Session.Add("ApeMatParaCons2", dr2("ApeMatEmp"))
                Session.Add("NombreParaCons2", dr2("NomEmp"))
                Session.Add("NumEmpParaCons2", dr2("NumEmp"))
            End If
            WucBuscaEmpleados2.DataBind()
            ddlMotivoInterinato.Enabled = True
            WucBuscaEmpleados2.Visible = True
            LblEmpTitularSD.Visible = False
            'btnUpdTitularPlaza.Visible = Request.Params("TipoOperacion") = "0"
        Else
            ddlMotivoInterinato.Enabled = False
            ddlMotivoInterinato.SelectedValue = "1"
            WucBuscaEmpleados2.Visible = False
            LblEmpTitularSD.Visible = True
            'btnUpdTitularPlaza.Visible = False
            dvBotones.Fields(0).Visible = False
            Session.Remove("RFCParaCons2")
            Session.Remove("ApePatParaCons2")
            Session.Remove("ApeMatParaCons2")
            Session.Remove("NombreParaCons2")
            Session.Remove("NumEmpParaCons2")
            WucBuscaEmpleados2.DataBind()
        End If
    End Sub

    Protected Sub btnUpdTitularPlaza_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
            Dim ddlMotivoInterinato As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivoInterinatoI"), DropDownList)
            Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = CType(Me.dvPlaza.FindControl("WucBuscaEmpleados2_I"), WebControls_wucSearchEmps2)
            Dim hfRFC As HiddenField = CType(WucBuscaEmpleados2.FindControl("hfRFC"), HiddenField)
            Dim oEmpPlaza As New EmpleadoPlazas
            With oEmpPlaza
                .IdMotivoInterinato = CByte(ddlMotivoInterinato.SelectedValue)
                .RFCEmpTitular = hfRFC.Value
                .IdPlaza = CInt(Request.Params("IdPlaza"))
                .IdPlazaTipoOcupacion = CByte(ddlPlazasTipoOcup.SelectedValue)
                .ActualizaTitular(CType(Session("ArregloAuditoria"), String()))
            End With
            Me.lblExito.Text = "Información modificada exitosamente."
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub ddlCategorias_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles ddlCategorias.SelectedIndexChanged
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlFuncionesPri As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesPri"), DropDownList)
        Dim drFuncionPriPorCatego As DataRow
        Dim oCategoria As New Categoria
        drFuncionPriPorCatego = oCategoria.ObtenFuncionPrimaria(CShort(ddlCategorias.SelectedValue))
        ddlFuncionesPri.SelectedIndex = -1
        ddlFuncionesPri.Items.FindByValue(drFuncionPriPorCatego("IdFuncionPri").ToString).Selected = True
    End Sub

    Protected Sub ddlQuincenaTermino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oEmpleadoPlaza As New EmpleadoPlazas
        'Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
        Dim drMotivoBajaDefault As DataRow

        Dim lblFechaBajaISSSTE As Label = CType(Me.dvPlaza.FindControl("lblFechaBajaISSSTE"), Label)
        Dim txtbxFechaBajaISSSTE As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE"), TextBox)
        Dim txtbxFechaBajaISSSTE_CV As CompareValidator = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE_CV"), CompareValidator)
        Dim drMotGralDeBaja As DataRow
        Dim oEmp2 As New Empleado
        Dim drQna As DataRow
        Dim oQna As New Quincenas

        drMotivoBajaDefault = oEmpleadoPlaza.ObtenMotivoGeneralDeBajaDefault(CShort(ddlQnaTermino.SelectedValue))

        drMotGralDeBaja = oEmp2.ObtenMotivosDeBaja(CShort(ddlMotivosDeBaja.SelectedValue))

        lblFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))
        lblFechaBajaISSSTE.Text = drMotGralDeBaja("TextoEtiquetaBaja").ToString
        txtbxFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))

        drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaTermino.SelectedValue), "F")

        txtbxFechaBajaISSSTE.Text = drQna("Fecha").ToString

        txtbxFechaBajaISSSTE_CV.Enabled = txtbxFechaBajaISSSTE.Visible
        'ddlMotivosDeBaja.SelectedValue = drMotivoBajaDefault("IdMotGralBaja").ToString
    End Sub

    Protected Sub ddlMotivosDeBaja_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
        Dim lblFechaBajaISSSTE As Label = CType(Me.dvPlaza.FindControl("lblFechaBajaISSSTE"), Label)
        Dim txtbxFechaBajaISSSTE As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE"), TextBox)
        Dim txtbxFechaBajaISSSTE_CV As CompareValidator = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE_CV"), CompareValidator)
        Dim drMotGralDeBaja As DataRow
        Dim oEmp2 As New Empleado

        drMotGralDeBaja = oEmp2.ObtenMotivosDeBaja(CShort(ddlMotivosDeBaja.SelectedValue))

        lblFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))
        lblFechaBajaISSSTE.Text = drMotGralDeBaja("TextoEtiquetaBaja").ToString
        txtbxFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))

        txtbxFechaBajaISSSTE_CV.Enabled = txtbxFechaBajaISSSTE.Visible
    End Sub

    Protected Sub ddlCTAdscipReal_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
        Dim lblZEPlantelAdscripReal As Label = CType(Me.dvPlaza.FindControl("lblZEPlantelAdscripReal"), Label)
        Dim dtPlantelAdscripReal As DataTable
        Dim drPlantelAdscripReal As DataRow
        Dim oPlantel As New Plantel

        dtPlantelAdscripReal = oPlantel.ObtenPorId(CShort(ddlCTAdscipReal.SelectedValue))
        drPlantelAdscripReal = dtPlantelAdscripReal.Rows(0)

        lblZEPlantelAdscripReal.Text = "Zona económica " + drPlantelAdscripReal("ClaveZonaEco").ToString

        UpdateClavePlaza()
    End Sub

    Protected Sub lbReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles lbReintentarCaptura.Click
        'CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Visible = True
        btnGuardar.Visible = True
        MultiView1.SetActiveView(viewPlazas)
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        'Dim btnCancelar As Button
        Dim strPostbackURL As String

        'btnCancelar = CType(dvPlaza.FindControl("btnCancelar"), Button)

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

        'btnCancelar = CType(dvPlaza.FindControl("btnCancelar"), Button)
        btnCancelar.PostBackUrl = strPostbackURL
        ibRegresar.PostBackUrl = strPostbackURL
        lbOtraOperacion0.PostBackUrl = strPostbackURL

        MultiView1.SetActiveView(viewPlazas)
    End Sub

    Protected Sub gvPlazasHistoria_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazasHistoria.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim lblNombreFuncionPri As Label = CType(e.Row.FindControl("lblNombreFuncionPri"), Label)
                Dim lblNombreFuncionSec As Label = CType(e.Row.FindControl("lblNombreFuncionSec"), Label)
                Dim lblMotGralBaja As Label = CType(e.Row.FindControl("lblMotGralBaja"), Label)
                'Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                'Dim ibWarning As ImageButton = CType(e.Row.FindControl("ibWarning"), ImageButton)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim lblOcupacion As Label = CType(e.Row.FindControl("lblOcupacion"), Label)

                Dim oEmpleadoPlaza As New EmpleadoPlazas
                Dim drFuncionPriSecPorPlaza As DataRow
                Dim drMotivoGeneralDeBajaPorPlaza As DataRow
                Dim oPlaza As New EmpleadoPlazas
                'Dim dtWarnings As DataTable
                Dim drInfTitular As DataRow
                Dim vlNomTitular As String

                imgInfTitular.Visible = False
                If lblOcupacion.Text = "I" Then
                    imgInfTitular.Visible = True
                    oEmpleadoPlaza.IdPlaza = CInt(lblIdPlaza.Text)
                    drInfTitular = oEmpleadoPlaza.ObtenTitular()
                    vlNomTitular = (drInfTitular("ApePatEmp") + " " + drInfTitular("ApeMatEmp") + " " + drInfTitular("NomEmp")).ToString.Trim
                    If vlNomTitular = String.Empty Then
                        vlNomTitular = "Información del titular no capturada."
                    End If
                    imgInfTitular.ToolTip = vlNomTitular
                End If

                drFuncionPriSecPorPlaza = oEmpleadoPlaza.ObtenFuncionesPri_Y_Sec(CInt(lblIdPlaza.Text))
                drMotivoGeneralDeBajaPorPlaza = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(lblIdPlaza.Text))

                lblNombreFuncionPri.Text = drFuncionPriSecPorPlaza("NombreFuncionPri").ToString
                lblNombreFuncionSec.Text = drFuncionPriSecPorPlaza("NombreFuncionSec").ToString
                lblMotGralBaja.Text = drMotivoGeneralDeBajaPorPlaza("DescMotGralBaja").ToString

                'ibDetalles.PostBackUrl = "../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text
                'ibWarning.OnClientClick = "javascript:abreVentMedAncha('../Plazas/ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                'dtWarnings = oPlaza.ObtenObservaciones(CInt(lblIdPlaza.Text))
                'ibWarning.Visible = dtWarnings.Rows.Count > 0
        End Select
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            If Request.Params("TipoOperacion") <> "1" Then
                pnlUltPlazaVig.Visible = False
                gvPlazasHistoria.Visible = False
                pnlInfPlaza.GroupingText = "Información de la plaza"
            Else
                pnlInfPlaza.GroupingText = "Información de la plaza asignada o por asignar"
                pnlUltPlazaVig.Visible = False
                gvPlazasHistoria.Visible = True
                BindgvPlazasHistoria()
            End If
        End If
    End Sub

    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnReintentarOp.Click
        MultiView1.SetActiveView(viewPlazas)
    End Sub

    Protected Sub ibCopiarRegistro_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        'Dim gvr As GridViewRow = CType(sender.DataItemContainer, GridViewRow)
        Dim oEmpPlaza As New Empleado
        Dim dtEmpPlaza As DataTable
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
        Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
        Dim ddlCentrosDeTrabajo As DropDownList = CType(Me.dvPlaza.FindControl("ddlCentrosDeTrabajo"), DropDownList)
        Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
        Dim ddlTiposDeNominas As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeNominas"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)

        'Dim ddlSindicatos As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicatos"), DropDownList)

        Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
        Dim ChckBxTratarComoBase As CheckBox = CType(Me.dvPlaza.FindControl("ChckBxTratarComoBase"), CheckBox)
        Dim ddlFuncionesPri As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesPri"), DropDownList)
        Dim ddlFuncionesSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesSec"), DropDownList)
        Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
        Dim ddlTiposDeSemestres As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeSemestres"), DropDownList)
        Dim ddlEsquemaPago As DropDownList = CType(Me.dvPlaza.FindControl("ddlEsquemaPago"), DropDownList)

        dtEmpPlaza = oEmpPlaza.ObtenHistoria(IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons")), True)

        ddlEmpleadosFunciones.SelectedValue = dtEmpPlaza.Rows(0).Item("IdEmpFuncion").ToString
        ddlEmpleadosFunciones_SelectedIndexChanged(Nothing, Nothing)
        ddlPlanteles.SelectedValue = dtEmpPlaza.Rows(0).Item("IdPlantel").ToString
        ddlPlanteles_SelectedIndexChanged(Nothing, Nothing)
        ddlCentrosDeTrabajo.SelectedValue = dtEmpPlaza.Rows(0).Item("IdCT").ToString
        ddlCTAdscipReal.SelectedValue = dtEmpPlaza.Rows(0).Item("IdPlantelAdscripReal").ToString
        ddlCTAdscipReal_SelectedIndexChanged(Nothing, Nothing)
        ddlTiposDeNominas.SelectedValue = dtEmpPlaza.Rows(0).Item("IdFondoPresup").ToString
        ddlCategorias.SelectedValue = dtEmpPlaza.Rows(0).Item("IdCategoria").ToString
        ddlCategorias_SelectedIndexChanged(Nothing, Nothing)
        ddlSindicatos.SelectedValue = dtEmpPlaza.Rows(0).Item("IdSindicato").ToString
        ddlPlazasTipoOcup.SelectedValue = dtEmpPlaza.Rows(0).Item("IdTipoEmp").ToString
        ddlPlazasTipoOcup_SelectedIndexChanged(Nothing, Nothing)
        ddlFuncionesPri.SelectedValue = dtEmpPlaza.Rows(0).Item("IdFuncionPri").ToString
        ddlFuncionesSec.SelectedValue = dtEmpPlaza.Rows(0).Item("IdFuncionSec").ToString
        ddlMotivosDeBaja.SelectedValue = "25"
        ddlMotivosDeBaja_SelectedIndexChanged(Nothing, Nothing)
        ddlTiposDeSemestres.SelectedValue = dtEmpPlaza.Rows(0).Item("IdTipoSemestre").ToString
        ddlEsquemaPago.SelectedValue = dtEmpPlaza.Rows(0).Item("IdEsquemaPago").ToString
    End Sub

    Protected Sub ibFechaIni_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim txtbxFechaIni As TextBox = CType(dvPlaza.FindControl("txtbxFechaIni"), TextBox)
        Dim wucCalendarFechIni = CType(dvPlaza.FindControl("wucCalendarFechIni"), wucCalendario)
        Dim pnlFechIni = CType(dvPlaza.FindControl("pnlFechIni"), Panel)
        Dim pnlFechFin = CType(dvPlaza.FindControl("pnlFechFin"), Panel)
        Dim ddlQnaInicio As DropDownList = CType(dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        'Dim ddlQnaTermino As DropDownList = CType(dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim oQna As New Quincenas
        Dim dtQna As DataTable = Nothing

        Dim vlCalendario As Calendar = CType(wucCalendarFechIni.FindControl("Calendar1"), Calendar)

        If txtbxFechaIni.Text.Trim <> String.Empty And IsDate(txtbxFechaIni.Text.Trim) Then
            vlCalendario.SelectedDate = CDate(txtbxFechaIni.Text).ToString("dd/MM/yyyy")
            vlCalendario.VisibleDate = CDate(txtbxFechaIni.Text).ToString("dd/MM/yyyy")

            wucCalendarFechIni.Calendar1VisibleMonthChanged()

            dtQna = oQna.ObtenDadaUnaFecha(txtbxFechaIni.Text, "I")
            LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", dtQna, Nothing)
        Else
            vlCalendario.VisibleDate = Today
            vlCalendario.SelectedDate = Nothing

            wucCalendarFechIni.Calendar1VisibleMonthChanged()

            dtQna = oQna.ObtenDadaUnaFecha(Today.ToString("dd/MM/yyyy"), "I")
            LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", dtQna, Nothing)
        End If

        pnlFechIni.Visible = Not pnlFechIni.Visible
        pnlFechFin.Visible = False
    End Sub

    Protected Sub ibFechaFin_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim txtbxFechaFin As TextBox = CType(dvPlaza.FindControl("txtbxFechaFin"), TextBox)
        Dim wucCalendarFechFin = CType(dvPlaza.FindControl("wucCalendarFechFin"), wucCalendario)
        Dim pnlFechIni = CType(dvPlaza.FindControl("pnlFechIni"), Panel)
        Dim pnlFechFin = CType(dvPlaza.FindControl("pnlFechFin"), Panel)
        'Dim ddlQnaInicio As DropDownList = CType(dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        'Dim ddlQnaTermino As DropDownList = CType(dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim chkbxVigFinAbierta As CheckBox = CType(dvPlaza.FindControl("chkbxVigFinAbierta"), CheckBox)
        Dim oQna As New Quincenas
        Dim dtQna As DataTable = Nothing

        Dim vlCalendario As Calendar = CType(wucCalendarFechFin.FindControl("Calendar1"), Calendar)

        If txtbxFechaFin.Text.Trim <> String.Empty And IsDate(txtbxFechaFin.Text.Trim) Then
            vlCalendario.SelectedDate = CDate(txtbxFechaFin.Text).ToString("dd/MM/yyyy")
            vlCalendario.VisibleDate = CDate(txtbxFechaFin.Text).ToString("dd/MM/yyyy")

            wucCalendarFechFin.Calendar1VisibleMonthChanged()

            dtQna = oQna.ObtenDadaUnaFecha(txtbxFechaFin.Text, "F")
            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", dtQna, Nothing)

            If ddlQnaTermino.SelectedValue = "32767" Then
                chkbxVigFinAbierta.Checked = True
                chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
            End If

        Else
            vlCalendario.VisibleDate = Today
            vlCalendario.SelectedDate = Nothing

            wucCalendarFechFin.Calendar1VisibleMonthChanged()

            dtQna = oQna.ObtenDadaUnaFecha(Today.ToString("dd/MM/yyyy"), "F")
            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", dtQna, Nothing)

            If ddlQnaTermino.SelectedValue = "32767" Then
                chkbxVigFinAbierta.Checked = True
                chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
            End If
        End If

        pnlFechFin.Visible = Not pnlFechFin.Visible
        pnlFechIni.Visible = False
    End Sub

    Protected Sub dvPlaza_PreRender(sender As Object, e As System.EventArgs) Handles dvPlaza.PreRender
        Dim oMetodoComun As New MetodosComunes
        Dim c As Control = oMetodoComun.GetPostBackControl(Page)

        Dim txtbxFechaIni As TextBox = CType(dvPlaza.FindControl("txtbxFechaIni"), TextBox)
        Dim txtbxFechaFin As TextBox = CType(dvPlaza.FindControl("txtbxFechaFin"), TextBox)
        Dim wucCalendarFechIni = CType(dvPlaza.FindControl("wucCalendarFechIni"), wucCalendario)
        Dim wucCalendarFechFin = CType(dvPlaza.FindControl("wucCalendarFechFin"), wucCalendario)
        Dim pnlFechIni = CType(dvPlaza.FindControl("pnlFechIni"), Panel)
        Dim pnlFechFin = CType(dvPlaza.FindControl("pnlFechFin"), Panel)
        Dim ddlQnaInicio As DropDownList = CType(dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        'Dim ddlQnaTermino As DropDownList = CType(dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim chkbxVigFinAbierta As CheckBox = CType(dvPlaza.FindControl("chkbxVigFinAbierta"), CheckBox)
        Dim oQna As New Quincenas
        Dim dtQna As DataTable = Nothing

        Dim vlCalendarioIni As Calendar = CType(wucCalendarFechIni.FindControl("Calendar1"), Calendar)
        Dim vlCalendarioFin As Calendar = CType(wucCalendarFechFin.FindControl("Calendar1"), Calendar)

        If IsPostBack Then
            If c Is Nothing = False Then
                If c.ID = "Calendar1" Then
                    If pnlFechIni.Visible Then
                        If txtbxFechaIni.Text <> vlCalendarioIni.SelectedDate().ToString("dd/MM/yyyy") Then
                            txtbxFechaIni.Text = vlCalendarioIni.SelectedDate().ToString("dd/MM/yyyy")
                            If txtbxFechaIni.Text = "01/01/0001" Then txtbxFechaIni.Text = String.Empty
                            If chkbxVigFinAbierta.Checked = False Then txtbxFechaFin.Text = txtbxFechaIni.Text
                            If txtbxFechaIni.Text <> "01/01/0001" And txtbxFechaIni.Text <> String.Empty Then pnlFechIni.Visible = Not pnlFechIni.Visible

                            dtQna = oQna.ObtenDadaUnaFecha(txtbxFechaIni.Text, "I")
                            LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", dtQna, Nothing)

                            dtQna = oQna.ObtenDadaUnaFecha(txtbxFechaFin.Text, "F")
                            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", dtQna, Nothing)

                            If ddlQnaTermino.SelectedValue = "32767" Then
                                chkbxVigFinAbierta.Checked = True
                                chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
                            End If
                        End If
                    Else
                        If pnlFechFin.Visible Then
                            If txtbxFechaFin.Text <> vlCalendarioFin.SelectedDate().ToString("dd/MM/yyyy") Then
                                txtbxFechaFin.Text = vlCalendarioFin.SelectedDate().ToString("dd/MM/yyyy")
                                If txtbxFechaFin.Text = "01/01/0001" Then txtbxFechaFin.Text = String.Empty
                                If txtbxFechaFin.Text <> "01/01/0001" And txtbxFechaFin.Text <> String.Empty Then pnlFechFin.Visible = Not pnlFechFin.Visible

                                dtQna = oQna.ObtenDadaUnaFecha(txtbxFechaFin.Text, "F")
                                LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", dtQna, Nothing)

                                If ddlQnaTermino.SelectedValue = "32767" Then
                                    chkbxVigFinAbierta.Checked = True
                                    chkbxVigFinAbierta_CheckedChanged(Nothing, Nothing)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub chkbxVigFinAbierta_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim chkbxVigFinAbierta As CheckBox = CType(dvPlaza.FindControl("chkbxVigFinAbierta"), CheckBox)
        Dim txtbxFechaIni As TextBox = CType(dvPlaza.FindControl("txtbxFechaIni"), TextBox)
        Dim txtbxFechaFin As TextBox = CType(dvPlaza.FindControl("txtbxFechaFin"), TextBox)
        Dim ddlQnaInicio As DropDownList = CType(dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        'Dim ddlQnaTermino As DropDownList = CType(dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim ibFechaFin As ImageButton = CType(dvPlaza.FindControl("ibFechaFin"), ImageButton)
        Dim oQna As New Quincenas
        Dim dtQna As DataTable = Nothing

        If chkbxVigFinAbierta.Checked Then
            ibFechaFin.Visible = False
            txtbxFechaFin.Text = "31/12/2099"

            dtQna = oQna.ObtenDadaUnaFecha(txtbxFechaFin.Text, "F")
            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", dtQna, Nothing)
        Else
            ibFechaFin.Visible = True
            txtbxFechaFin.Text = txtbxFechaIni.Text

            dtQna = oQna.ObtenDadaUnaFecha(txtbxFechaFin.Text, "F")
            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", dtQna, Nothing)
        End If
    End Sub

    Protected Sub ddlTramites_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Bind_ddlMotivos()
    End Sub


    Protected Sub btnValidar_Click(sender As Object, e As System.EventArgs)
        UpdateClavePlaza(True)
        'dvPlaza.Enabled = False
        'btnValidar.Visible = False
        'btnGuardar.Visible = True
        'btnModificar.Visible = True
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As System.EventArgs)
        dvPlaza.Enabled = True
        pnlCvePlaza.Visible = True
        'pnlCvePlazaError.Visible = False
        imgPlazaCorrecta.Visible = False
        btnValidar.Visible = True
        btnGuardar.Visible = False
        btnModificar.Visible = False
    End Sub

    Protected Sub txtbxConsPlaza_TextChanged(sender As Object, e As System.EventArgs)
        txtbxConsPlaza.Text = txtbxConsPlaza.Text.PadLeft(5, "0")
    End Sub
End Class
