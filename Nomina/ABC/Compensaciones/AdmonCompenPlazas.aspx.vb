Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Plazas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.MovsDePersonal
Partial Class AdmonCompenPlazas
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        If Request.Params("TipoOperacion") = "2" Then ddl.Enabled = False
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Response.Expires = 0
            Me.MultiView1.SetActiveView(Me.viewPlazas)
            Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
            Dim ddlCentrosDeTrabajo As DropDownList = CType(Me.dvPlaza.FindControl("ddlCentrosDeTrabajo"), DropDownList)
            Dim ddlCTSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTSec"), DropDownList)
            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
            Dim ddlFuncionesPri As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesPri"), DropDownList)
            Dim ddlFuncionesSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesSec"), DropDownList)
            Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
            Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
            Dim chbkEstaFisic As CheckBox = CType(Me.dvPlaza.FindControl("chbkEstaFisic"), CheckBox)
            Dim chbkPrioridadNombComp As CheckBox = CType(Me.dvPlaza.FindControl("chbkPrioridadNombComp"), CheckBox)
            Dim oEmp As New EmpleadoFuncion
            Dim oPlantel As New Plantel
            Dim oTipoDeNomina As New TipoDeNomina
            Dim oCT As New CentroDeTrabajo
            Dim oCategoria As New Categoria
            Dim oPlaza As New TipoOcupacion
            Dim oQna As New Quincenas
            Dim oEmpleadoPlaza As New EmpleadoPlazas
            Dim dr As DataRow
            Dim oEmp2 As New Empleado
            'Dim drFuncionPriPorCatego As DataRow
            'Dim oNomina As New Nomina
            Dim oCompen As New Compensacion
            Dim crItem As ListItem

            If Request.Params("TipoOperacion") = "1" Then 'Insertar
                'Si el empleado tiene plaza vigente en nómina
                'If oNomina.ValidaSimEmpTienePlazaVigente(CStr(Request.Params("NumEmp"))) = True Then
                If Request.Params("EmpTienePlazaVigEnNomina") = "SI" Then
                    dr = oCompen.BuscaPlazaVigenteEnNominaPorEmp(CStr(Request.Params("NumEmp"))).Rows(0)

                    LlenaDDL(ddlEmpleadosFunciones, "DescEmpFuncion", "IdEmpFuncion", oEmp.ObtenFunciones(), dr("IdEmpFuncion").ToString)
                    LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True), dr("IdPlantel").ToString)
                    LlenaDDL(ddlCentrosDeTrabajo, "CentroDeTrabajo", "IdCT", oCT.ObtenPorPlantel(CShort(ddlPlanteles.SelectedValue)), dr("IdCT").ToString)
                    LlenaDDL(ddlCTSec, "CentroDeTrabajo", "IdCT", oCT.ObtenSecPorPlantelyCTPadre(CShort(ddlPlanteles.SelectedValue), CShort(ddlCentrosDeTrabajo.SelectedValue)), dr("IdCTSec").ToString)
                    LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenPorFuncionDelEmpleado(CByte(ddlEmpleadosFunciones.SelectedValue), True), dr("IdCategoria").ToString)

                    LlenaDDL(ddlFuncionesPri, "FuncionPri", "IdFuncionPri", oEmp2.ObtenFuncionesPrimarias(), dr("IdFuncionPri").ToString)
                    LlenaDDL(ddlFuncionesSec, "FuncionSec", "IdFuncionSec", oEmp2.ObtenFuncionesSecundarias(), dr("IdFuncionSec").ToString)
                    LlenaDDL(ddlMotivosDeBaja, "MotGralBaja", "IdMotGralBaja", oEmp2.ObtenMotivosDeBaja(), dr("IdMotGralBaja").ToString)

                    chbkEstaFisic.Checked = CBool(dr("EstaFisicamente2"))
                    chbkPrioridadNombComp.Enabled = True
                    chbkPrioridadNombComp.Checked = CBool(dr("PrioridadNombCompen2"))

                    If (Request.Params("TipoOperacion") = "0") Then
                        ddlQnaInicio.Items.Insert(0, dr("Inicio").ToString)
                        ddlQnaInicio.Items(0).Value = dr("IdQuincenaIni").ToString
                    Else
                        If Request.Params("TipoOperacion") = "4" Then
                            ddlQnaInicio.Items.Insert(0, dr("Inicio").ToString)
                            ddlQnaInicio.Items(0).Value = dr("IdQuincenaIni").ToString
                        Else
                            LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True), dr("IdQuincenaIni").ToString)
                        End If
                    End If
                    'If Request.Params("TipoOperacion") <> "2" Then
                    If Request.Params("TipoOperacion") = "4" Then
                        ddlQnaTermino.Items.Insert(0, dr("Fin").ToString)
                        ddlQnaTermino.Items(0).Value = dr("IdQuincenaFin").ToString
                    Else
                        LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True), dr("IdQuincenaFin").ToString)
                    End If
                    'Else
                    '    LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenPosiblesParaPago(CType(Request.Params("IdPlaza"), Integer)), dr("IdQuincenaFin").ToString)
                    'End If
                    ddlQnaTermino.Enabled = True
                    ddlMotivosDeBaja.Enabled = True
                    If Request.Params("TipoOperacion") = "4" Then
                        CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Enabled = False
                    End If

                Else 'Si el empleado no tiene plaza vigente en nómina
                    LlenaDDL(ddlEmpleadosFunciones, "DescEmpFuncion", "IdEmpFuncion", oEmp.ObtenFunciones())
                    LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True))
                    LlenaDDL(ddlCentrosDeTrabajo, "CentroDeTrabajo", "IdCT", oCT.ObtenPorPlantel(CShort(ddlPlanteles.SelectedValue)))
                    LlenaDDL(ddlCTSec, "CentroDeTrabajo", "IdCT", oCT.ObtenSecPorPlantelyCTPadre(CShort(ddlPlanteles.SelectedValue), CShort(ddlCentrosDeTrabajo.SelectedValue)))
                    LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenPorFuncionDelEmpleado(CByte(ddlEmpleadosFunciones.SelectedValue), True))
                    LlenaDDL(ddlFuncionesPri, "FuncionPri", "IdFuncionPri", oEmp2.ObtenFuncionesPrimarias())
                    LlenaDDL(ddlFuncionesSec, "FuncionSec", "IdFuncionSec", oEmp2.ObtenFuncionesSecundarias())
                    LlenaDDL(ddlMotivosDeBaja, "MotGralBaja", "IdMotGralBaja", oEmp2.ObtenMotivosDeBaja())
                    LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True))
                    ddlQnaInicio.SelectedIndex = 1
                    LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True))
                    ddlQuincenaTermino_SelectedIndexChanged(sender, e)

                    chbkEstaFisic.Checked = True
                    If Request.Params("EmpTienePlazaVigEnNomina") = "SI" Then
                        chbkPrioridadNombComp.Enabled = True
                    Else
                        chbkPrioridadNombComp.Enabled = False
                    End If
                    chbkPrioridadNombComp.Checked = False
                End If
            ElseIf Request.Params("TipoOperacion") = "0" Then 'Actualizar 
                dr = oCompen.BuscaPlazasPorEmp(CInt(Request.Params("IdPlaza")))

                LlenaDDL(ddlEmpleadosFunciones, "DescEmpFuncion", "IdEmpFuncion", oEmp.ObtenFunciones(), dr("IdEmpFuncion").ToString)
                LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True), dr("IdPlantel").ToString)
                LlenaDDL(ddlCentrosDeTrabajo, "CentroDeTrabajo", "IdCT", oCT.ObtenPorPlantel(CShort(ddlPlanteles.SelectedValue)), dr("IdCT").ToString)
                LlenaDDL(ddlCTSec, "CentroDeTrabajo", "IdCT", oCT.ObtenSecPorPlantelyCTPadre(CShort(ddlPlanteles.SelectedValue), CShort(ddlCentrosDeTrabajo.SelectedValue)), dr("IdCTSec").ToString)
                LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenPorFuncionDelEmpleado(CByte(ddlEmpleadosFunciones.SelectedValue), True), dr("IdCategoria").ToString)

                LlenaDDL(ddlFuncionesPri, "FuncionPri", "IdFuncionPri", oEmp2.ObtenFuncionesPrimarias(), dr("IdFuncionPri").ToString)
                LlenaDDL(ddlFuncionesSec, "FuncionSec", "IdFuncionSec", oEmp2.ObtenFuncionesSecundarias(), dr("IdFuncionSec").ToString)
                LlenaDDL(ddlMotivosDeBaja, "MotGralBaja", "IdMotGralBaja", oEmp2.ObtenMotivosDeBaja(), dr("IdMotGralBaja").ToString)

                chbkEstaFisic.Checked = CBool(dr("EstaFisicamente2"))
                chbkPrioridadNombComp.Enabled = True
                chbkPrioridadNombComp.Checked = CBool(dr("PrioridadNombCompen2"))

                If (Request.Params("TipoOperacion") = "0") Then
                    LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True), dr("IdQuincenaIni").ToString)
                    crItem = ddlQnaInicio.Items.FindByValue(dr("IdQuincenaIni").ToString)

                    If crItem Is Nothing Then
                        ddlQnaInicio.Items.Clear()
                        ddlQnaInicio.Items.Insert(0, dr("Inicio").ToString)
                        ddlQnaInicio.Items(0).Value = dr("IdQuincenaIni").ToString
                    End If
                Else
                    If Request.Params("TipoOperacion") = "4" Then
                        ddlQnaInicio.Items.Insert(0, dr("Inicio").ToString)
                        ddlQnaInicio.Items(0).Value = dr("IdQuincenaIni").ToString
                    Else
                        LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True), dr("IdQuincenaIni").ToString)
                    End If
                End If
                'If Request.Params("TipoOperacion") <> "2" Then
                If Request.Params("TipoOperacion") = "4" Then
                    ddlQnaTermino.Items.Insert(0, dr("Fin").ToString)
                    ddlQnaTermino.Items(0).Value = dr("IdQuincenaFin").ToString
                Else
                    LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True), dr("IdQuincenaFin").ToString)
                End If
                'Else
                '    LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenPosiblesParaPago(CType(Request.Params("IdPlaza"), Integer)), dr("IdQuincenaFin").ToString)
                'End If
                ddlQnaTermino.Enabled = True
                ddlMotivosDeBaja.Enabled = True
                If Request.Params("TipoOperacion") = "4" Then
                    CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Enabled = False
                End If
            ElseIf Request.Params("TipoOperacion") = "3" Then
                oCompen.DeleteNombramiento(CInt(Request.Params("IdPlaza")), CType(Session("ArregloAuditoria"), String()))
                Me.MultiView1.SetActiveView(Me.viewExito)
                Me.lblExito.Text = "Nombramiento eliminado exitosamente."
            End If
        End If
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
            Dim ddlCentrosDeTrabajo As DropDownList = CType(Me.dvPlaza.FindControl("ddlCentrosDeTrabajo"), DropDownList)
            Dim ddlCTSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTSec"), DropDownList)
            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
            Dim ddlFuncionesPri As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesPri"), DropDownList)
            Dim ddlFuncionesSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionesSec"), DropDownList)
            Dim ddlQuincenaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
            Dim ddlQuincenaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
            Dim chbkEstaFisic As CheckBox = CType(Me.dvPlaza.FindControl("chbkEstaFisic"), CheckBox)
            Dim chbkPrioridadNombComp As CheckBox = CType(Me.dvPlaza.FindControl("chbkPrioridadNombComp"), CheckBox)
            Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)

            Dim oCompen As New Compensacion

            Dim vlIdPlazaCreada As Integer

            Dim pNumEmp As String = Nothing
            Dim pIdPlaza As Integer
            Dim pIdPlantel, pIdCT, pIdCTSec, pIdCategoria, pIdFuncionPri, pIdQuincenaIni, pIdQuincenaFin As Short
            Dim pIdFuncionSec, pIdMotGralBaja, pIdEmpFuncion As Byte
            Dim pEstaFisic, pPrioridadNombComp As Boolean

            If Request.Params("TipoOperacion") = "0" Then
                pNumEmp = String.Empty
                pIdPlaza = CInt(Request.Params("IdPlaza"))
            ElseIf Request.Params("TipoOperacion") = "1" Then
                pNumEmp = CStr(Request.Params("NumEmp"))
                pIdPlaza = 0
            End If

            pIdEmpFuncion = CByte(ddlEmpleadosFunciones.SelectedValue)
            pIdPlantel = CShort(ddlPlanteles.SelectedValue)
            pIdCT = CShort(ddlCentrosDeTrabajo.SelectedValue)
            pIdCTSec = CShort(ddlCTSec.SelectedValue)
            pIdCategoria = CShort(ddlCategorias.SelectedValue)
            pIdFuncionPri = CShort(ddlFuncionesPri.SelectedValue)
            pIdFuncionSec = CByte(ddlFuncionesSec.SelectedValue)
            pIdQuincenaIni = CShort(ddlQuincenaInicio.SelectedValue)
            pIdQuincenaFin = CShort(ddlQuincenaTermino.SelectedValue)
            pIdMotGralBaja = CByte(ddlMotivosDeBaja.SelectedValue)
            pEstaFisic = CBool(chbkEstaFisic.Checked)
            pPrioridadNombComp = CBool(chbkPrioridadNombComp.Checked)

            If Request.Params("TipoOperacion") = "0" Then
                oCompen.UpdNombramientoAEmpleado(pIdPlaza, pIdPlantel, pIdCT, pIdCTSec, pIdCategoria, pIdFuncionPri, _
                                                 pIdFuncionSec, pIdQuincenaIni, pIdQuincenaFin, pIdMotGralBaja, _
                                                 pEstaFisic, pPrioridadNombComp, pIdEmpFuncion, _
                                                 CType(Session("ArregloAuditoria"), String()))
            ElseIf Request.Params("TipoOperacion") = "1" Then
                vlIdPlazaCreada = oCompen.AddNombramientoAEmpleado(pNumEmp, pIdPlantel, pIdCT, pIdCTSec, pIdCategoria, _
                                                                   pIdFuncionPri, pIdFuncionSec, pIdQuincenaIni, pIdQuincenaFin, _
                                                                   pIdMotGralBaja, pEstaFisic, pPrioridadNombComp, _
                                                                   pIdEmpFuncion, _
                                                                   CType(Session("ArregloAuditoria"), String()))
            ElseIf Request.Params("TipoOperacion") = "2" Then

            End If
            Me.MultiView1.SetActiveView(Me.viewExito)
            If Request.Params("TipoOperacion") = "0" Then
                Me.lblExito.Text = "Nombramiento modificado exitosamente."
            ElseIf Request.Params("TipoOperacion") = "1" Then
                Me.lblExito.Text = "Nombramiento creado exitosamente."
            End If
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub ddlQuincenaInicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim oQna As New Quincenas
        If Request.Params("TipoOperacion") <> "2" Then
            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True))
        Else
            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenPosiblesParaPago(CType(Request.Params("IdPlaza"), Integer)))
        End If
    End Sub

    Protected Sub ddlPlanteles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
        Dim ddlCentrosDeTrabajo As DropDownList = CType(Me.dvPlaza.FindControl("ddlCentrosDeTrabajo"), DropDownList)
        Dim ddlCTSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTSec"), DropDownList)
        Dim oCT As New CentroDeTrabajo

        LlenaDDL(ddlCentrosDeTrabajo, "CentroDeTrabajo", "IdCT", oCT.ObtenPorPlantel(CShort(ddlPlanteles.SelectedValue)))
        LlenaDDL(ddlCTSec, "CentroDeTrabajo", "IdCT", oCT.ObtenSecPorPlantelyCTPadre(CShort(ddlPlanteles.SelectedValue), CShort(ddlCentrosDeTrabajo.SelectedValue)))

        'ddlCentrosDeTrabajo.DataSource = oCT.ObtenPorPlantel(CShort(ddlPlanteles.SelectedValue))
        'ddlCentrosDeTrabajo.DataBind()
        'ddlCTSec.DataSource = oCT.ObtenSecPorPlantelyCTPadre(CShort(ddlPlanteles.SelectedValue), CShort(ddlCentrosDeTrabajo.SelectedValue))
        'ddlCTSec.DataBind()
    End Sub

    Protected Sub ddlCategorias_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCategorias.SelectedIndexChanged
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
        drMotivoBajaDefault = oEmpleadoPlaza.ObtenMotivoGeneralDeBajaDefault(CShort(ddlQnaTermino.SelectedValue))
        ddlMotivosDeBaja.SelectedValue = drMotivoBajaDefault("IdMotGralBaja").ToString
    End Sub

    Protected Sub ddlMotivosDeBaja_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim ddlMotivosDeBaja As DropDownList = CType(Me.dvPlaza.FindControl("ddlMotivosDeBaja"), DropDownList)
        Dim oEmpleadoPlaza As New EmpleadoPlazas
        Dim drMotivoBajaDefault As DataRow

        If ddlQnaTermino.Text = "32767" And ddlMotivosDeBaja.Text <> "25" Then
            drMotivoBajaDefault = oEmpleadoPlaza.ObtenMotivoGeneralDeBajaDefault(CShort(ddlQnaTermino.SelectedValue))
            ddlMotivosDeBaja.SelectedValue = drMotivoBajaDefault("IdMotGralBaja").ToString
        End If
    End Sub

    Protected Sub ddlCentrosDeTrabajo_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim ddlPlanteles As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlanteles"), DropDownList)
        Dim ddlCentrosDeTrabajo As DropDownList = CType(Me.dvPlaza.FindControl("ddlCentrosDeTrabajo"), DropDownList)
        Dim ddlCTSec As DropDownList = CType(Me.dvPlaza.FindControl("ddlCTSec"), DropDownList)
        Dim oCT As New CentroDeTrabajo

        LlenaDDL(ddlCTSec, "CentroDeTrabajo", "IdCT", oCT.ObtenSecPorPlantelyCTPadre(CShort(ddlPlanteles.SelectedValue), CShort(ddlCentrosDeTrabajo.SelectedValue)))

    End Sub

    Protected Sub ddlEmpleadosFunciones_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim oCategoria As New Categoria

        LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenPorFuncionDelEmpleado(CByte(ddlEmpleadosFunciones.SelectedValue), True))

        ddlCategorias_SelectedIndexChanged1(sender, e)
    End Sub
End Class
