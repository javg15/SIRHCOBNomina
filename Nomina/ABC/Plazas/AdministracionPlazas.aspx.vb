Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Plazas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Administracion

Partial Class AdministracionPlazas
    Inherits System.Web.UI.Page
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

        'If dtEmpPlaza.Rows.Count > 0 Then
        gvPlazasHistoria.DataSource = dtEmpPlaza
        gvPlazasHistoria.DataBind()
        'Else
        'gvPlazasHistoria.EmptyDataText = "El empleado nunca ha tenido plaza."
        'gvPlazasHistoria.DataBind()
        'End If
        'gvPlazasHistoria.Visible = True
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Response.Expires = 0

            Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
            Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)
            Dim btnCancelar As Button

            Dim chkFueraTiempo As CheckBox = CType(Me.dvPlaza.FindControl("chkFueraTiempo"), CheckBox)
            Dim oUsuario As New Usuario

            If Not chkFueraTiempo Is Nothing Then
                chkFueraTiempo.Visible = False
                If oUsuario.EsAdministrador(Session("Login")) Or oUsuario.EsSuperAdmin(Session("Login")) Then
                    chkFueraTiempo.Visible = True
                End If
            End If


            BtnNewSearch.Visible = False
            BtnCancelSearch.Visible = False
            BtnSearch.Visible = False

            btnCancelar = CType(dvPlaza.FindControl("btnCancelar"), Button)

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
                    'btnCancelar0.PostBackUrl = "~/MenuPrincipal.aspx"
                    'lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                Else
                    btnCancelar.PostBackUrl = "~/" + Session("URLAnt") + vlComplementoURL
                    'btnCancelar0.PostBackUrl = "~/" + Session("URLAnt")
                    'lbOtraOperacion0.PostBackUrl = "~/" + Session("URLAnt")
                End If
            Else
                btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                'btnCancelar0.PostBackUrl = "~/MenuPrincipal.aspx"
                'lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
            End If

            Session.Remove("RFCParaCons2")
            Session.Remove("ApePatParaCons2")
            Session.Remove("ApeMatParaCons2")
            Session.Remove("NombreParaCons2")
            Session.Remove("NumEmpParaCons2")

            Me.MultiView1.SetActiveView(Me.viewPlazas)
            Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
            Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
            Dim lblZECentroAdscripFisica As Label = CType(Me.dvPlaza.FindControl("lblZECentroAdscripFisica"), Label)
            Dim lblZEPlantelAdscripReal As Label = CType(Me.dvPlaza.FindControl("lblZEPlantelAdscripReal"), Label)
            Dim ddlCentrosDeTrabajo As DropDownList = CType(Me.dvPlaza.FindControl("ddlCentrosDeTrabajo"), DropDownList)
            Dim ddlTiposDeNominas As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeNominas"), DropDownList)
            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
            Dim ddlSindicatos As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicatos"), DropDownList)
            Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
            Dim ChckBxTratarComoBase As CheckBox = CType(Me.dvPlaza.FindControl("ChckBxTratarComoBase"), CheckBox)
            Dim chkbxInterinoPuro As CheckBox = CType(Me.dvPlaza.FindControl("chkbxInterinoPuro"), CheckBox)
            Dim ddlFuncionesPri As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesPri"), DropDownList)
            Dim ddlFuncionesSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesSec"), DropDownList)
            Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
            Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
            Dim ddlMotivoInterinato As DropDownList = (CType(Me.dvPlaza.FindControl("ddlMotivoInterinatoI"), DropDownList))
            Dim ddlCadenas As DropDownList = CType(Me.dvPlaza.FindControl("ddlCadenas"), DropDownList)
            Dim ddlTiposDeSemestres As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeSemestres"), DropDownList)
            Dim ddlEsquemaPago As DropDownList = CType(Me.dvPlaza.FindControl("ddlEsquemaPago"), DropDownList)
            Dim ddlPuesto As DropDownList = CType(Me.dvPlaza.FindControl("ddlPuesto"), DropDownList) 'CODIGO AGREGADO POR ALEXIS CORTEZ 24/08/2021'
            Dim lblFechaBajaISSSTE As Label = CType(Me.dvPlaza.FindControl("lblFechaBajaISSSTE"), Label)
            Dim txtbxFechaBajaISSSTE As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE"), TextBox)
            Dim txtbxFechaBajaISSSTE_CV As CompareValidator = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE_CV"), CompareValidator)
            Dim lblFechaBajaISSSTE2 As Label = CType(Me.dvPlaza.FindControl("lblFechaBajaISSSTE2"), Label)  'CODIGO AGREGADO POR ALEXIS CORTEZ 29/09/2021'
            Dim txtbxFechaBajaISSSTE2 As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE2"), TextBox) 'CODIGO AGREGADO POR ALEXIS CORTEZ 29/09/2021'
            Dim txtbxFechaBajaISSSTE_CV2 As CompareValidator = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE_CV2"), CompareValidator) 'CODIGO AGREGADO POR ALEXIS CORTEZ 29/09/2021'
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
            Dim drfechasLSGS As DataRow
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
            Dim drPuesto As DataRow
            Dim oNomina As New Nomina
            Dim tblEsquemaPagoPorDefault As DataTable
            Dim gvDatos As GridView = CType(Me.dvPlaza.FindControl("gvDatos"), GridView)
            Dim oSMP_Plaza As New SMP_Plazas

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
                LlenaDDL(ddlMotivosDeBaja, "MotGralBaja", "IdMotGralBaja", oEmp2.ObtenMotivosDeBajaSegunTipoOcupacion(ddlPlazasTipoOcup.SelectedValue))
                LlenaDDL(ddlCadenas, "NumCadena", "IdCadena", oCadena.ObtenAbiertasPorUsr(Session("Login")))
                LlenaDDL(ddlTiposDeSemestres, "TipoSemestre", "IdTipoSemestre", oSemestre.ObtenTipos())

                tblEsquemaPagoPorDefault = oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue))
                LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), True), tblEsquemaPagoPorDefault.Rows(0).Item("IdEsquemaPago").ToString)
                'CODIGO AGREGADO POR ALEXIS CORTEZ 24/08/2021'
                LlenaDDL(ddlPuesto, "Puesto", "IdPuesto", oNomina.ObtenPuestos(CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), Session("RFCParaCons").ToString))
                'CODIGO AGREGADO POR ALEXIS CORTEZ 24/08/2021'

                LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True))
                Dim dtQnasAbiertasParaCaptura As DataTable
                dtQnasAbiertasParaCaptura = oQna.ObtenAbiertasParaCaptura()
                If dtQnasAbiertasParaCaptura.Rows.Count > 0 Then
                    ddlQnaInicio.SelectedValue = CStr(dtQnasAbiertasParaCaptura.Rows(0).Item("IdQuincena"))
                Else
                    ddlQnaInicio.SelectedIndex = 0
                End If
                'ddlQnaInicio.SelectedIndex = 1
                LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True))

                drMotGralDeBaja = oEmp2.ObtenMotivosDeBaja(CShort(ddlMotivosDeBaja.SelectedValue))

                lblFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))
                lblFechaBajaISSSTE.Text = drMotGralDeBaja("TextoEtiquetaBaja").ToString
                txtbxFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))

                Dim fechaActual As Date = Date.Now

                'CODIGO AGREGADO POR ALEXIS 29/09/2021'
                If drMotGralDeBaja("IdMotGralBaja") = 11 Then
                    lblFechaBajaISSSTE2.Visible = True
                    txtbxFechaBajaISSSTE2.Visible = True
                Else
                    lblFechaBajaISSSTE2.Visible = False
                    txtbxFechaBajaISSSTE2.Visible = False
                End If

                'CODIGO AGREGADOR POR ALEXIS 29/09/2021'

                drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaTermino.SelectedValue), "F")

                'txtbxFechaBajaISSSTE.Text = drQna("Fecha").ToString
                txtbxFechaBajaISSSTE.Text = fechaActual.AddDays(1).ToShortDateString

                txtbxFechaBajaISSSTE_CV.Enabled = txtbxFechaBajaISSSTE.Visible

                'CODIGO AGREGADO POR ALEXIS 29/09/2021'
                txtbxFechaBajaISSSTE2.Text = fechaActual.AddDays(2).ToShortDateString
                txtbxFechaBajaISSSTE_CV2.Enabled = txtbxFechaBajaISSSTE2.Visible
                'CODIGO AGREGADO POR ALEXIS 29/09/2021'

                gvDatos.DataSource = oSMP_Plaza.ObtenPlazasOcupacion(ddlCTAdscipReal.SelectedValue, ddlCategorias.SelectedValue, ddlPlazasTipoOcup.SelectedValue, 1, CType(Request.Params("IdPlaza"), Integer), CShort(If(ddlQnaInicio.SelectedValue = "", 0, ddlQnaInicio.SelectedValue)))
                gvDatos.DataBind()

            ElseIf Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "2" Or Request.Params("TipoOperacion") = "4" _
              Or (Request.Params("TipoOperacion") = "1" And Request.Params("CopiarUltVig") = "SI") Then 'Actualizar o Eliminar
                'BindgvPlazasHistoria()
                If Request.Params("CopiarUltVig") Is Nothing Then
                    oEmpleadoPlaza.IdPlaza = CType(Request.Params("IdPlaza"), Integer)
                    dr = oEmpleadoPlaza.ObtenPorIdConOcup()
                    drPlazasHistoria = oEmpleadoPlaza.ObtenInfDeTblPlazasHistoria(CType(Request.Params("IdPlaza"), Integer))
                    'drFuncionPriSecPorPlaza = oEmpleadoPlaza.ObtenFuncionesPri_Y_Sec(CInt(Request.Params("IdPlaza")))
                    drEmpsPlazasDatosComplemen = oEmpleadoPlaza.ObtenDatosComplementarios(CInt(Request.Params("IdPlaza")))
                    drMotivoGeneralDeBaja = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(Request.Params("IdPlaza")))
                    drTratarPlazaComoBase = oEmpleadoPlaza.ObtenSiPlazaSeraTratadaComoBase(CInt(Request.Params("IdPlaza")))
                    drCadena = oCadena.ObtenSiPlazaEstaEnCadena(CInt(Request.Params("IdPlaza")))
                    drPuesto = oEmpleadoPlaza.ObtenPuestoSEFIPLAN(CInt(Request.Params("IdPlaza")))
                    drfechasLSGS = oEmpleadoPlaza.ObtenFechaLSGS(CInt(Request.Params("IdPlaza")))
                Else
                    dr = oEmpleadoPlaza.ObtenUltimaOcupada(Request.Params("RFCEmp"))
                    drPlazasHistoria = oEmpleadoPlaza.ObtenInfDeTblPlazasHistoria(CInt(dr("IdPlaza")))
                    'drFuncionPriSecPorPlaza = oEmpleadoPlaza.ObtenFuncionesPri_Y_Sec(CInt(dr("IdPlaza")))
                    drEmpsPlazasDatosComplemen = oEmpleadoPlaza.ObtenDatosComplementarios(CInt(Request.Params("IdPlaza")))
                    drMotivoGeneralDeBaja = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(dr("IdPlaza")))
                    drTratarPlazaComoBase = oEmpleadoPlaza.ObtenSiPlazaSeraTratadaComoBase(CInt(dr("IdPlaza")))
                    drCadena = oCadena.ObtenSiPlazaEstaEnCadena(CInt(dr("IdPlaza")))
                    drPuesto = oEmpleadoPlaza.ObtenPuestoSEFIPLAN(CInt(Request.Params("IdPlaza")))
                    drfechasLSGS = oEmpleadoPlaza.ObtenFechaLSGS(CInt(Request.Params("IdPlaza")))
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
                    LlenaDDL(ddlCadenas, "NumCadena", "IdCadena", oCadena.ObtenAbiertasPorUsr(Session("Login")))
                ElseIf Request.Params("TipoOperacion") = "4" Then
                    ddlCadenas.Items.Add(New ListItem(drCadena("NumCadena").ToString, drCadena("IdCadena").ToString))
                ElseIf Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "2" Then
                    LlenaDDL(ddlCadenas, "NumCadena", "IdCadena", oCadena.ObtenAbiertasPorUsr(Session("Login")))
                    If CType(ddlCadenas.Items.FindByValue(drCadena("IdCadena").ToString), ListItem) Is Nothing Then
                        ddlCadenas.Items.Add(New ListItem(drCadena("NumCadena").ToString, drCadena("IdCadena").ToString))
                    End If
                    ddlCadenas.SelectedValue = drCadena("IdCadena").ToString
                End If

                LlenaDDL(ddlTiposDeSemestres, "TipoSemestre", "IdTipoSemestre", oSemestre.ObtenTipos(), dr("IdTipoSemestre").ToString)
                LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), True), drEmpsPlazasDatosComplemen("IdEsquemaPago").ToString)
                'CODIGO AGREGADO POR ALEXIS CORTEZ 24/08/2021'
                Try
                    LlenaDDL(ddlPuesto, "Puesto", "IdPuesto", oNomina.ObtenPuestos(CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), Session("RFCParaCons").ToString), drPuesto("IdPuesto").ToString)
                Catch e1 As NullReferenceException
                    LlenaDDL(ddlPuesto, "Puesto", "IdPuesto", oNomina.ObtenPuestos(999, 999, "999"))
                End Try
                'CODIGO AGREGADO POR ALEXIS CORTEZ 24/08/2021'

                '\/bloque temporal, para que los analistas no vean (operen aun) el apartado de plazas
                Dim CVIdPlazas As RequiredFieldValidator = CType(dvPlaza.FindControl("CVIdPlazas"), RequiredFieldValidator)
                Dim CVIdTitular As CompareValidator = CType(dvPlaza.FindControl("CVIdTitular"), CompareValidator)

                If oUsuario.EsAdministrador(Session("Login")) Or oUsuario.EsSuperAdmin(Session("Login")) Then
                    CVIdPlazas.Enabled = True
                    gvDatos.Visible = True
                Else
                    CVIdPlazas.Enabled = False
                    gvDatos.Visible = False
                End If
                '/\ bloque temporal, para que los analistas no vean (operen aun) el apartado de plazas

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

                        CVIdPlazas.Enabled = False
                        CVIdTitular.Enabled = False
                    End If

                    If Request.Params("TipoOperacion") = "0" Then
                        EmpPlzTienePagoEnQna = oEmpleadoPlaza.TienePagosAPartirDeQna(CShort(dr("QnaVigIni").ToString), CByte(Request.Params("TipoOperacion")))
                    End If



                    If Request.Params("TipoOperacion") = "2" Or (Request.Params("TipoOperacion") = "0" And EmpPlzTienePagoEnQna) Then
                        ddlQnaInicio.Items.Insert(0, dr("Inicio").ToString)
                        ddlQnaInicio.Items(0).Value = dr("QnaVigIni").ToString
                        If Request.Params("TipoOperacion") = "2" Then ddlQnaInicio.Enabled = False
                    Else
                        If Request.Params("CopiarUltVig") = "SI" Then
                            LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True))
                            ddlQnaInicio.SelectedIndex = 1
                            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True))
                        Else
                            If Request.Params("TipoOperacion") = "4" Then
                                ddlQnaInicio.Items.Insert(0, dr("Inicio").ToString)
                                ddlQnaInicio.Items(0).Value = dr("QnaVigIni").ToString
                            Else
                                LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True), dr("QnaVigIni").ToString)
                            End If
                        End If
                    End If
                    If Request.Params("TipoOperacion") <> "2" Then
                        If Request.Params("CopiarUltVig") Is Nothing Then
                            If Request.Params("TipoOperacion") = "4" Then
                                ddlQnaTermino.Items.Insert(0, dr("Término").ToString)
                                ddlQnaTermino.Items(0).Value = dr("QnaVigFin").ToString
                            Else
                                LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True), dr("QnaVigFin").ToString)
                            End If
                        End If
                    Else
                        LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenPosiblesParaPago(CType(Request.Params("IdPlaza"), Integer)), dr("QnaVigFin").ToString)
                    End If
                    ddlQnaTermino.Enabled = True
                    ddlMotivosDeBaja.Enabled = True 'Lo habilitamos para que se pueda modificar el motivo de la baja en todo momento

                    drMotGralDeBaja = oEmp2.ObtenMotivosDeBaja(CShort(ddlMotivosDeBaja.SelectedValue))

                    lblFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))
                    lblFechaBajaISSSTE.Text = drMotGralDeBaja("TextoEtiquetaBaja").ToString
                    txtbxFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))

                    drQna = oQna.ObtenFechaInioFinQna(CShort(ddlQnaTermino.SelectedValue), "F")

                    txtbxFechaBajaISSSTE.Text = drPlazasHistoria("FechaFin")

                    txtbxFechaBajaISSSTE_CV.Enabled = txtbxFechaBajaISSSTE.Visible

                    'CODIGO AGREGADO POR ALEXIS 29/09/2021'
                    If (drMotivoGeneralDeBaja("IdMotGralBaja") = 11) Then
                        lblFechaBajaISSSTE2.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))
                        txtbxFechaBajaISSSTE2.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))
                        Try
                            txtbxFechaBajaISSSTE2.Text = drfechasLSGS("FechaFin")
                        Catch e1 As NullReferenceException
                            txtbxFechaBajaISSSTE2.Text = drPlazasHistoria("FechaFin")
                        End Try
                        txtbxFechaBajaISSSTE_CV2.Enabled = txtbxFechaBajaISSSTE2.Visible
                    End If
                    'CODIGO AGREGADOR POR ALEXIS 29/09/2021'

                    ddlCadenas.Enabled = True 'Lo habilitamos para que el usuario pueda indicar si el movimiento de baja formará parte de una cadena o no
                    If Request.Params("TipoOperacion") = "4" Then
                        CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Visible = False
                    End If

                    'Plazas base
                    gvDatos.DataSource = oSMP_Plaza.ObtenPlazasOcupacion(ddlCTAdscipReal.SelectedValue, ddlCategorias.SelectedValue, ddlPlazasTipoOcup.SelectedValue, 1, CType(Request.Params("IdPlaza"), Integer), CShort(If(ddlQnaInicio.SelectedValue = "", 0, ddlQnaInicio.SelectedValue)))
                    gvDatos.DataBind()

                    Dim hidIdPlazas As TextBox = CType(Me.dvPlaza.FindControl("hidIdPlazas"), TextBox)
                    If Not IsDBNull(dr("IdPlazas_Ocup")) Then
                        hidIdPlazas.Text = CInt(dr("IdPlazas_Ocup"))

                        For i = 0 To gvDatos.Rows.Count - 1
                            If CType(gvDatos.Rows(i).FindControl("lblIdPlazas"), Label).Text = dr("IdPlazas_Ocup") Then
                                gvDatos.SelectedIndex = i
                            End If
                        Next
                    End If
                End If
            End If
    End Sub
    Protected Sub CheckedChanged_chkbxInterinoPuro(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
        Dim chkbxInterinoPuro As CheckBox = CType(Me.dvPlaza.FindControl("chkbxInterinoPuro"), CheckBox)
        Dim gvDatos As GridView = CType(Me.dvPlaza.FindControl("gvDatos"), GridView)
        Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        Dim oSMP_Plaza As New SMP_Plazas

        If Not chkbxInterinoPuro.Checked Then
            gvDatos.DataSource = oSMP_Plaza.ObtenPlazasOcupacion(ddlCTAdscipReal.SelectedValue, ddlCategorias.SelectedValue, ddlPlazasTipoOcup.SelectedValue, 1, CType(Request.Params("IdPlaza"), Integer), CShort(If(ddlQnaInicio.SelectedValue = "", 0, ddlQnaInicio.SelectedValue)))
        Else
            gvDatos.DataSource = oSMP_Plaza.ObtenPlazasOcupacion(ddlCTAdscipReal.SelectedValue, ddlCategorias.SelectedValue, 8, 1, CType(Request.Params("IdPlaza"), Integer), CShort(If(ddlQnaInicio.SelectedValue = "", 0, ddlQnaInicio.SelectedValue)))
        End If
        gvDatos.DataBind()
    End Sub
    Protected Sub gvDatos_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        Dim gvDatos As GridView = CType(Me.dvPlaza.FindControl("gvDatos"), GridView)
        Dim hidIdPlazas As TextBox = CType(Me.dvPlaza.FindControl("hidIdPlazas"), TextBox)

        If e.NewSelectedIndex >= 0 Then
            Dim lblIdPlazas As Label = CType(gvDatos.Rows(e.NewSelectedIndex).FindControl("lblIdPlazas"), Label)

            hidIdPlazas.Text = lblIdPlazas.Text
        Else
            hidIdPlazas.Text = "0"
        End If
    End Sub
    Protected Sub CheckedChanged_chkFueraTiempo(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chkFueraTiempo As CheckBox = CType(sender, CheckBox)
        Dim oQna As New Quincenas
        Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)

        If chkFueraTiempo.Checked Then
            LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenListasCalculadas())
        Else
            LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True))
        End If
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Deshabilitamos el botón guardar para evitar el doble click
            'CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Visible = False

            Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
            Dim ddlQuincenaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim ddlFuncionesPri As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesPri"), DropDownList)
            Dim ddlFuncionesSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesSec"), DropDownList)
            Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
            Dim ddlCadenas As DropDownList = CType(Me.dvPlaza.FindControl("ddlCadenas"), DropDownList)
            Dim ddlTiposDeSemestres As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeSemestres"), DropDownList)
            Dim ddlEsquemaPago As DropDownList = CType(Me.dvPlaza.FindControl("ddlEsquemaPago"), DropDownList)
            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
            Dim ddlSindicatos As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicatos"), DropDownList)
            Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
            Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
            Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
            Dim txtbxFechaBajaISSSTE As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE"), TextBox)
            Dim txtbxFechaBajaISSSTE2 As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE2"), TextBox)
            Dim ddlPuesto As DropDownList = CType(Me.dvPlaza.FindControl("ddlPuesto"), DropDownList) 'CODIGO AGREGADO POR ALEXIS CORTEZ 01/09/2021'
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
                .IdQnaFin = CShort(ddlQuincenaTermino.SelectedValue)
                .IdEmpFuncion = CByte(ddlEmpleadosFunciones.SelectedValue)
                .IdMotGralBaja = CByte(ddlMotivosDeBaja.SelectedValue)
                .IdTipoSemestre = CByte(ddlTiposDeSemestres.SelectedValue)
                .IdCategoria = CShort(ddlCategorias.SelectedValue)
                .IdSindicato = CByte(ddlSindicatos.SelectedValue)
                .IdTipoEmp = CByte(ddlPlazasTipoOcup.SelectedValue)
                .IdPlantel = CShort(ddlPlanteles.SelectedValue)
                .IdPuesto = CShort(ddlPuesto.SelectedValue)
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
            Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim ddlMotivoInterinato As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivoInterinatoI"), DropDownList)
            Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = CType(Me.dvPlaza.FindControl("WucBuscaEmpleados2_I"), WebControls_wucSearchEmps2)
            Dim hfRFC As HiddenField = CType(WucBuscaEmpleados2.FindControl("hfRFC"), HiddenField)
            Dim ChckBxTratarComoBase As CheckBox = CType(Me.dvPlaza.FindControl("ChckBxTratarComoBase"), CheckBox)
            Dim chkbxInterinoPuro As CheckBox = CType(Me.dvPlaza.FindControl("chkbxInterinoPuro"), CheckBox)
            Dim hidIdPlazas As TextBox = CType(Me.dvPlaza.FindControl("hidIdPlazas"), TextBox)
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
                .IdPuesto = CShort(ddlPuesto.SelectedValue)
                If txtbxFechaBajaISSSTE.Visible = True Then
                    .FechaFin = IIf(txtbxFechaBajaISSSTE.Text <> String.Empty, txtbxFechaBajaISSSTE.Text, String.Empty)
                Else
                    .FechaFin = String.Empty
                End If
                If txtbxFechaBajaISSSTE2.Visible = True Then
                    .FechaFinLSGS = IIf(txtbxFechaBajaISSSTE2.Text <> String.Empty, txtbxFechaBajaISSSTE2.Text, String.Empty)
                Else
                    .FechaFinLSGS = String.Empty
                End If

                hidIdPlazas.Text = If(hidIdPlazas.Text = "", "0", hidIdPlazas.Text)
                If Request.Params("TipoOperacion") = "0" Then
                    .IdPlaza = CInt(Request.Params("IdPlaza"))
                    vl_IdPlaza = CInt(Request.Params("IdPlaza"))
                    .Actualizar(CType(ddlQnaInicio.SelectedValue, Short), CType(ddlQnaTermino.SelectedValue, Short), CType(hidIdPlazas.Text, Integer), CType(Session("ArregloAuditoria"), String()))
                    oCadena.ActualizaMov(CInt(ddlCadenas.SelectedValue), CInt(Request.Params("IdPlaza")), Session("Login"), "A", CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    IdPlazaCreada = .AgregaNueva(Request.Params("RFCEmp"), CType(ddlQnaInicio.SelectedValue, Short), CType(ddlQnaTermino.SelectedValue, Short), CType(hidIdPlazas.Text, Integer), 1, CType(Session("ArregloAuditoria"), String()))
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
        Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim chkFueraTiempo As CheckBox = CType(Me.dvPlaza.FindControl("chkFueraTiempo"), CheckBox)
        Dim gvDatos As GridView = CType(Me.dvPlaza.FindControl("gvDatos"), GridView)

        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
        Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
        Dim ddlPuesto As DropDownList = CType(Me.dvPlaza.FindControl("ddlPuesto"), DropDownList)
        Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
        Dim oSMP_Plaza As New SMP_Plazas
        Dim oQna As New Quincenas

        If chkFueraTiempo.Checked Then
            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenListasCalculadas())
        Else
            If Request.Params("TipoOperacion") <> "2" Then
                LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True))
            Else
                LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenPosiblesParaPago(CType(Request.Params("IdPlaza"), Integer)))
            End If
        End If
        gvDatos.DataSource = oSMP_Plaza.ObtenPlazasOcupacion(ddlCTAdscipReal.SelectedValue, ddlCategorias.SelectedValue, ddlPlazasTipoOcup.SelectedValue, 1, CType(Request.Params("IdPlaza"), Integer), CShort(If(ddlQnaInicio.SelectedValue = "", 0, ddlQnaInicio.SelectedValue)))
        gvDatos.databind()
    End Sub

    Protected Sub ddlEmpleadosFunciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlTiposDeNominas As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeNominas"), DropDownList)
        Dim ddlMotivoInterinatoI As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivoInterinatoI"), DropDownList)
        Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
        Dim oCatego As New Categoria
        Dim oTipoDeNomina As New TipoDeNomina
        Dim oEmp As New Empleado
        ddlCategorias.DataSource = oCatego.ObtenPorFuncionDelEmpleado(CByte(ddlEmpleadosFunciones.SelectedValue))
        ddlCategorias.DataBind()
        ddlCategorias_SelectedIndexChanged(sender, e)

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

        ddlCategorias_SelectedIndexChanged1(sender, e)

    End Sub
    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim oPlaza As New Plazas.TipoOcupacion
        Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
        Dim chkbxInterinoPuro As CheckBox = CType(Me.dvPlaza.FindControl("chkbxInterinoPuro"), CheckBox)

        Dim OcupacionEsInterina As Boolean
        OcupacionEsInterina = oPlaza.EsInterina(CByte(ddlPlazasTipoOcup.SelectedValue), True)

        If (OcupacionEsInterina And chkbxInterinoPuro.Checked = False) Then
            Try
                Dim gvDatos As GridView = CType(sender, GridView)
                Dim lblTitular As Label = CType(gvDatos.SelectedRow.FindControl("lblTitular"), Label)
                Dim NumEmp As String = lblTitular.Text.Substring(0, 5)
                Dim empleadosInterino As WebControls_wucSearchEmps2 = CType(dvPlaza.FindControl("WucBuscaEmpleados2_I"), WebControls_wucSearchEmps2)

                Dim txtbxNumEmp As TextBox = CType(empleadosInterino.FindControl("txtbxNumEmp"), TextBox)
                Dim BtnSearch2 As Button = CType(empleadosInterino.FindControl("BtnSearch"), Button)

                txtbxNumEmp.Text = NumEmp
                empleadosInterino.PerformClick_BtnSearch()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Protected Sub gvDatos_DataBound(sender As Object, e As EventArgs)
        Dim gvDatos As GridView = CType(sender, GridView)
        Dim hidIdPlazas As TextBox = CType(Me.dvPlaza.FindControl("hidIdPlazas"), TextBox)

        gvDatos.SelectedIndex = -1
        hidIdPlazas.Text = "0"
    End Sub

    Protected Sub gvDatos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lnSelectPlaza As ImageButton = CType(e.Row.FindControl("lnSelectPlaza"), ImageButton)
                Dim lblDescEstatusPlaza As Label = CType(e.Row.FindControl("lblDescEstatusPlaza"), Label)
                Dim lblIdPlazas As Label = CType(e.Row.FindControl("lblIdPlazas"), Label)
                Dim hidIdPlazaOcupada As HiddenField = CType(dvPlaza.FindControl("hidIdPlazaOcupada"), HiddenField)
                Dim gvDatos As GridView = CType(dvPlaza.FindControl("gvDatos"), GridView)

                If lblDescEstatusPlaza.Text.ToUpper = "(VACANTE)" Or lblDescEstatusPlaza.Text.ToUpper = "" Then
                    lnSelectPlaza.Visible = True
                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                Else
                    lnSelectPlaza.Visible = False
                    e.Row.Attributes.Add("OnMouseOver", "")
                    e.Row.Attributes.Add("OnMouseOut", "")

                    If lblIdPlazas.Text = hidIdPlazaOcupada.Value Then
                        e.Row.BackColor = Drawing.Color.Orange
                    End If
                End If
        End Select
    End Sub

    Protected Sub ddlCategorias_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlTiposDeNominas As DropDownList = CType(Me.dvPlaza.FindControl("ddlTiposDeNominas"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlEsquemaPago As DropDownList = CType(Me.dvPlaza.FindControl("ddlEsquemaPago"), DropDownList)
        Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
        Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
        Dim ddlPuesto As DropDownList = CType(Me.dvPlaza.FindControl("ddlPuesto"), DropDownList)
        Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
        Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)

        Dim gvDatos As GridView = CType(Me.dvPlaza.FindControl("gvDatos"), GridView)

        Dim tblEsquemaPagoPorDefault As DataTable

        Dim oTipoDeNomina As New TipoDeNomina
        Dim SelectedValueAnt As String
        Dim oNomina As New Nomina
        Dim oPlaza As New SMP_Plazas


        SelectedValueAnt = ddlTiposDeNominas.SelectedValue
        LlenaDDL(ddlTiposDeNominas, "DescFondoPresup", "IdTipoNomina", oTipoDeNomina.ObtenPorCategoria(CShort(ddlCategorias.SelectedValue)))

        tblEsquemaPagoPorDefault = oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue))
        LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), True), tblEsquemaPagoPorDefault.Rows(0).Item("IdEsquemaPago").ToString)

        'CODIGO AGREGADO POR ALEXIS CORTEZ 01/09/2021'
        LlenaDDL(ddlPuesto, "Puesto", "IdPuesto", oNomina.ObtenPuestos(CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), Session("RFCParaCons").ToString))
        'CODIGO AGREGADO POR ALEXIS CORTEZ 01/09/2021'

        'ddlTiposDeNominas.DataSource = oTipoDeNomina.ObtenPorCategoria(CByte(ddlCategorias.SelectedValue))
        'ddlTiposDeNominas.DataBind()
        gvDatos.DataSource = oPlaza.ObtenPlazasOcupacion(ddlCTAdscipReal.SelectedValue, ddlCategorias.SelectedValue, ddlPlazasTipoOcup.SelectedValue, 1, CType(Request.Params("IdPlaza"), Integer), CShort(If(ddlQnaInicio.SelectedValue = "", 0, ddlQnaInicio.SelectedValue)))
        gvDatos.DataBind()

        'Para evitar el error de que se quiera asignar un valor a SelectedValue inexistente
        Try
            ddlTiposDeNominas.SelectedValue = SelectedValueAnt
            ddlPlazasTipoOcup_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ddlPlanteles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim lblZECentroAdscripFisica As Label = CType(Me.dvPlaza.FindControl("lblZECentroAdscripFisica"), Label)
        Dim ddlCentrosDeTrabajo As DropDownList = CType(Me.dvPlaza.FindControl("ddlCentrosDeTrabajo"), DropDownList)
        Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
        Dim ddlEsquemaPago As DropDownList = CType(Me.dvPlaza.FindControl("ddlEsquemaPago"), DropDownList)
        Dim ddlPuesto As DropDownList = CType(Me.dvPlaza.FindControl("ddlPuesto"), DropDownList)

        Dim oCT As New CentroDeTrabajo
        Dim dtPlantelAdscripFisica As DataTable
        Dim drPlantelAdscripFisica As DataRow
        Dim oPlantel As New Plantel
        Dim oNomina As New Nomina
        Dim tblEsquemaPagoPorDefault As DataTable

        dtPlantelAdscripFisica = oPlantel.ObtenPorId(CShort(ddlPlanteles.SelectedValue))
        drPlantelAdscripFisica = dtPlantelAdscripFisica.Rows(0)
        lblZECentroAdscripFisica.Text = "Zona económica " + drPlantelAdscripFisica("ClaveZonaEco").ToString
        ddlCentrosDeTrabajo.DataSource = oCT.ObtenPorPlantel(CShort(ddlPlanteles.SelectedValue))
        ddlCentrosDeTrabajo.DataBind()
        ddlCTAdscipReal.SelectedValue = ddlPlanteles.SelectedValue

        tblEsquemaPagoPorDefault = oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue))
        LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), True), tblEsquemaPagoPorDefault.Rows(0).Item("IdEsquemaPago").ToString)
        'CODIGO AGREGADO POR ALEXIS CORTEZ 01/09/2021'
        LlenaDDL(ddlPuesto, "Puesto", "IdPuesto", oNomina.ObtenPuestos(CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), Session("RFCParaCons").ToString))
        'CODIGO AGREGADO POR ALEXIS CORTEZ 01/09/2021'

        'LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue)))
    End Sub

    Protected Sub ddlPlazasTipoOcup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oPlaza As New Plazas.TipoOcupacion
        Dim ddlPlazasTipoOcup As DropDownList = Nothing
        Dim ddlMotivoInterinato As DropDownList = Nothing
        Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = Nothing
        Dim LblEmpTitularSD As Label = Nothing
        Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
        Dim ChckBxTratarComoBase As CheckBox = CType(Me.dvPlaza.FindControl("ChckBxTratarComoBase"), CheckBox)
        Dim chkbxInterinoPuro As CheckBox = CType(Me.dvPlaza.FindControl("chkbxInterinoPuro"), CheckBox)
        Dim OcupacionEsInterina, OcupacionEsProvisional, OcupacionEsBase As Boolean
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
        Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
        Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        Dim gvDatos As GridView = CType(Me.dvPlaza.FindControl("gvDatos"), GridView)

        Dim oCategoria As New Categoria
        Dim drCategoriaHomologada As DataRow
        Dim oEmp As New Empleado
        Dim oSMP_Plaza As New SMP_Plazas

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
        Dim btnUpdTitularPlaza As Button = CType(Me.dvPlaza.FindControl("btnUpdTitularPlaza"), Button)
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
        If drCategoriaHomologada("CategoriaEsHomologada") And (OcupacionEsInterina Or OcupacionEsProvisional Or OcupacionEsBase) Then
            ChckBxTratarComoBase.Enabled = True And Request.Params("TipoOperacion") <> "2"
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
            btnUpdTitularPlaza.Visible = False
            Session.Remove("RFCParaCons2")
            Session.Remove("ApePatParaCons2")
            Session.Remove("ApeMatParaCons2")
            Session.Remove("NombreParaCons2")
            Session.Remove("NumEmpParaCons2")
            WucBuscaEmpleados2.DataBind()
        End If

        'If Request.Params("TipoOperacion") <> "4" Then
        LlenaDDL(ddlMotivosDeBaja, "MotGralBaja", "IdMotGralBaja", oEmp.ObtenMotivosDeBajaSegunTipoOcupacion(ddlPlazasTipoOcup.SelectedValue))
        'End If
        gvDatos.DataSource = oSMP_Plaza.ObtenPlazasOcupacion(ddlCTAdscipReal.SelectedValue, ddlCategorias.SelectedValue, ddlPlazasTipoOcup.SelectedValue, 1, CType(Request.Params("IdPlaza"), Integer), CShort(If(ddlQnaInicio.SelectedValue = "", 0, ddlQnaInicio.SelectedValue)))
        gvDatos.DataBind()
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
        Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
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
        Dim lblFechaBajaISSSTE2 As Label = CType(Me.dvPlaza.FindControl("lblFechaBajaISSSTE2"), Label)  'CODIGO AGREGADO POR ALEXIS CORTEZ 29/09/2021'
        Dim txtbxFechaBajaISSSTE2 As TextBox = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE2"), TextBox) 'CODIGO AGREGADO POR ALEXIS CORTEZ 29/09/2021'
        Dim txtbxFechaBajaISSSTE_CV2 As CompareValidator = CType(Me.dvPlaza.FindControl("txtbxFechaBajaISSSTE_CV2"), CompareValidator) 'CODIGO AGREGADO POR ALEXIS CORTEZ 29/09/2021'
        Dim drMotGralDeBaja As DataRow
        Dim oEmp2 As New Empleado
        Dim fechaActual As Date = Date.Now

        drMotGralDeBaja = oEmp2.ObtenMotivosDeBaja(CShort(ddlMotivosDeBaja.SelectedValue))

        lblFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))
        lblFechaBajaISSSTE.Text = drMotGralDeBaja("TextoEtiquetaBaja").ToString
        txtbxFechaBajaISSSTE.Visible = CBool(drMotGralDeBaja("PedirBajaParaISSSTE"))

        txtbxFechaBajaISSSTE_CV.Enabled = txtbxFechaBajaISSSTE.Visible

        'CODIGO AGREGADO POR ALEXIS CORTEZ 29/09/2021'
        If drMotGralDeBaja("IdMotGralBaja") = 11 Then
            lblFechaBajaISSSTE2.Visible = True
            txtbxFechaBajaISSSTE.Text = fechaActual.AddDays(1).ToShortDateString
        Else
            lblFechaBajaISSSTE2.Visible = False
        End If
        txtbxFechaBajaISSSTE2.Visible = lblFechaBajaISSSTE2.Visible
        txtbxFechaBajaISSSTE_CV2.Enabled = txtbxFechaBajaISSSTE2.Visible
        txtbxFechaBajaISSSTE2.Text = fechaActual.AddDays(2).ToShortDateString
        'CODIGO AGREGADO POR ALEXIS CORTEZ 29/09/2021'
    End Sub

    Protected Sub ddlCTAdscipReal_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim ddlCTAdscipReal As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTAdscipReal"), DropDownList)
        Dim lblZEPlantelAdscripReal As Label = CType(Me.dvPlaza.FindControl("lblZEPlantelAdscripReal"), Label)
        Dim ddlPlazasTipoOcup As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasTipoOcup"), DropDownList)
        Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        Dim gvDatos As GridView = CType(Me.dvPlaza.FindControl("gvDatos"), GridView)
        Dim dtPlantelAdscripReal As DataTable
        Dim drPlantelAdscripReal As DataRow
        Dim oPlantel As New Plantel
        Dim oPlaza As New SMP_Plazas

        dtPlantelAdscripReal = oPlantel.ObtenPorId(CShort(ddlCTAdscipReal.SelectedValue))
        drPlantelAdscripReal = dtPlantelAdscripReal.Rows(0)

        lblZEPlantelAdscripReal.Text = "Zona económica " + drPlantelAdscripReal("ClaveZonaEco").ToString

        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        gvDatos.DataSource = oPlaza.ObtenPlazasOcupacion(ddlCTAdscipReal.SelectedValue, ddlCategorias.SelectedValue, ddlPlazasTipoOcup.SelectedValue, 1, CType(Request.Params("IdPlaza"), Integer), CShort(If(ddlQnaInicio.SelectedValue = "", 0, ddlQnaInicio.SelectedValue)))
        gvDatos.DataBind()
    End Sub

    Protected Sub lbReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles lbReintentarCaptura.Click
        CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Visible = True
        MultiView1.SetActiveView(viewPlazas)
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        Dim btnCancelar As Button
        Dim strPostbackURL As String

        btnCancelar = CType(dvPlaza.FindControl("btnCancelar"), Button)

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

        btnCancelar = CType(dvPlaza.FindControl("btnCancelar"), Button)
        btnCancelar.PostBackUrl = strPostbackURL
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
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibWarning As ImageButton = CType(e.Row.FindControl("ibWarning"), ImageButton)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim lblOcupacion As Label = CType(e.Row.FindControl("lblOcupacion"), Label)

                Dim oEmpleadoPlaza As New EmpleadoPlazas
                Dim drFuncionPriSecPorPlaza As DataRow
                Dim drMotivoGeneralDeBajaPorPlaza As DataRow
                Dim oPlaza As New EmpleadoPlazas
                Dim dtWarnings As DataTable
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

                ibDetalles.PostBackUrl = "../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text
                ibWarning.OnClientClick = "javascript:abreVentMedAncha('../Plazas/ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                dtWarnings = oPlaza.ObtenObservaciones(CInt(lblIdPlaza.Text))
                ibWarning.Visible = dtWarnings.Rows.Count > 0
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
                pnlUltPlazaVig.Visible = True
                gvPlazasHistoria.Visible = True
                BindgvPlazasHistoria()
            End If
        End If
    End Sub

    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnReintentarOp.Click
        MultiView1.SetActiveView(viewPlazas)
    End Sub
End Class
