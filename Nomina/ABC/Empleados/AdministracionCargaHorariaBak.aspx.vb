Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Planteles
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Nominas

Partial Class AdministracionCargaHorariaBak
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Public dr As DataRow
    Private Sub AplicaValidaciones()
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        Dim ddlPlanteles As DropDownList = Nothing
        Dim ddlGrupos As DropDownList = Nothing
        Dim ddlEstatus As DropDownList = Nothing
        Dim ddlQnaIni As DropDownList = Nothing
        Dim ddlQnaFin As DropDownList = Nothing
        Dim ddlNombramiento As DropDownList = Nothing

        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            .RFC = Session("RFCParaCons")
            .IdQuincena = 0
            .AsociarInterinas = IIf(Request.Params("AsociarInterinas") Is Nothing, False, True)
            .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
            If Request.Params("TipoOperacion") <> "2" Then
                If Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Insert Then
                    .Cantidad = CByte(CType(Me.dvCargaHoraria.FindControl("txtbxCantidadIns"), TextBox).Text)
                    .IdMateria = CShort(CType(Me.dvCargaHoraria.FindControl("ddlMateriasI"), DropDownList).SelectedValue)
                    .IdHora = IIf(Request.Params("IdHora") Is Nothing, 0, CType(Request.Params("IdHora"), Integer))
                    .IdTipoNomina = CByte(CType(Me.dvCargaHoraria.FindControl("ddlNominasI"), DropDownList).SelectedValue)
                ElseIf Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Edit Then
                    .Cantidad = CByte(CType(Me.dvCargaHoraria.FindControl("txtbxCantidad"), TextBox).Text)
                    .IdHora = CType(Request.Params("IdHora"), Integer)
                    .IdMateria = CShort(CType(Me.dvCargaHoraria.FindControl("ddlMaterias"), DropDownList).SelectedValue)
                    .IdTipoNomina = CByte(CType(Me.dvCargaHoraria.FindControl("ddlNominas"), DropDownList).SelectedValue)
                End If
                .IdSemestre = CShort(Request.Params("IdSemestre")) 'CShort(CType(Me.dvCargaHoraria.FindControl("ddlSemestres"), DropDownList).Text)
            Else
                .CargaDePlantilla = True
            End If

            If Me.dvCargaHoraria.DefaultMode = DetailsViewMode.Insert Then
                ddlPlanteles = CType(Me.dvCargaHoraria.FindControl("ddlPlantelesI"), DropDownList)
                ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGruposI"), DropDownList)
                ddlEstatus = CType(Me.dvCargaHoraria.FindControl("ddlEstatus"), DropDownList)
                ddlQnaIni = CType(Me.dvCargaHoraria.FindControl("ddlQnaIni_I"), DropDownList)
                ddlQnaFin = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_I"), DropDownList)
                ddlNombramiento = (CType(Me.dvCargaHoraria.FindControl("ddlNombramientoI"), DropDownList))
            Else
                ddlPlanteles = CType(Me.dvCargaHoraria.FindControl("ddlPlanteles"), DropDownList)
                ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGrupos"), DropDownList)
                ddlEstatus = CType(Me.dvCargaHoraria.FindControl("ddlEstatus"), DropDownList)
                ddlQnaIni = CType(Me.dvCargaHoraria.FindControl("ddlQnaIni_E"), DropDownList)
                ddlQnaFin = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_E"), DropDownList)
                ddlNombramiento = (CType(Me.dvCargaHoraria.FindControl("ddlNombramientoE"), DropDownList))
            End If
            .IdPlantel = CShort(ddlPlanteles.SelectedValue)
            .IdGrupo = CShort(ddlGrupos.SelectedValue)
            .IdEstatusHora = CByte(ddlEstatus.SelectedValue)
            .IdQnaIni = CShort(ddlQnaIni.SelectedValue)
            .IdQnaFin = CShort(ddlQnaFin.SelectedValue)
            .IdNombramiento = CByte(ddlNombramiento.SelectedValue)

            If Request.Params("ValidacionAlCargarPagina") Is Nothing = False Then
                If Not oValidacion.ValidaPaginasOperacion(dsValida, False) Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            Else
                If Not oValidacion.ValidaPaginasOperacion(dsValida) Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            End If
            'If Not .ValidaPaginasOperacion(dsValida) Then
            '    Session.Add("dsValida", dsValida)
            '    Response.Redirect("~/ErroresPagina2.aspx")
            'Else
            '    Session.Remove("dsValida")
            'End If
        End With
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        Try
            ddl.DataBind()
            If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        Catch
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Remove("RFCParaCons2")
            Session.Remove("ApePatParaCons2")
            Session.Remove("ApeMatParaCons2")
            Session.Remove("NombreParaCons2")
            Session.Remove("NumEmpParaCons2")

            Me.Response.Expires = 0

            Dim oEmp As New Empleado
            Dim oEmpleadoPlaza As New EmpleadoPlazas
            Dim oPlantel As New Plantel
            Dim oMateria As New Materia
            Dim oGrupo As New Grupo
            Dim oSemestre As New Semestre
            Dim oTipoNomina As New TipoDeNomina
            Dim oQna As New Quincenas
            Dim oHoras As New Hora
            Dim HoraSePuedeModificar As Boolean = True
            Dim HoraSePuedeLimitarAuto As Boolean = True

            oEmp.RFC = Request.Params("RFCEmp")

            Dim oHora As New Hora
            oHora.IdHora = CType(Request.Params("IdHora"), Integer)
            If Request.Params("AsociarInterinas") Is Nothing = False And Request.Params("TipoOperacion") = "0" Then
                ds = oHora.ObtenPorId(True)
            Else
                ds = oHora.ObtenPorId()
            End If

            Dim ddlTipoHora As DropDownList = Nothing
            Dim ddlPlanteles As DropDownList = Nothing
            Dim ddlMaterias As DropDownList = Nothing
            Dim ddlNominas As DropDownList = Nothing
            Dim ddlGrupos As DropDownList = Nothing
            Dim txtbxCantidad As TextBox = Nothing
            Dim ddlQnaIni As DropDownList = Nothing
            Dim ddlQnaFin As DropDownList = Nothing
            Dim ddlFchIni As DropDownList = Nothing
            Dim ddlFchFin As DropDownList = Nothing
            Dim ddlNombramiento As DropDownList = Nothing
            Dim ddlMotivoInterinato As DropDownList = Nothing
            Dim chbLimitarASemAntMismoTipo As CheckBox = Nothing
            Dim chkbxFrenteGrupo As CheckBox = Nothing

            If Request.Params("TipoOperacion") = "1" And Request.Params("IdHora") Is Nothing Then
                Me.dvCargaHoraria.DefaultMode = DetailsViewMode.Insert
                ddlTipoHora = CType(Me.dvCargaHoraria.FindControl("ddlTipoHoraI"), DropDownList)
                ddlPlanteles = CType(Me.dvCargaHoraria.FindControl("ddlPlantelesI"), DropDownList)
                ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMateriasI"), DropDownList)
                ddlNominas = CType(Me.dvCargaHoraria.FindControl("ddlNominasI"), DropDownList)
                ddlNombramiento = (CType(Me.dvCargaHoraria.FindControl("ddlNombramientoI"), DropDownList))
                ddlMotivoInterinato = (CType(Me.dvCargaHoraria.FindControl("ddlMotivoInterinatoI"), DropDownList))
                ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGruposI"), DropDownList)
                txtbxCantidad = CType(Me.dvCargaHoraria.FindControl("txtbxCantidadIns"), TextBox)
                ddlQnaIni = CType(Me.dvCargaHoraria.FindControl("ddlQnaIni_I"), DropDownList)
                ddlQnaFin = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_I"), DropDownList)
                ddlFchIni = CType(Me.dvCargaHoraria.FindControl("ddlFchIni_I"), DropDownList)
                ddlFchFin = CType(Me.dvCargaHoraria.FindControl("ddlFchFin_I"), DropDownList)
                chbLimitarASemAntMismoTipo = CType(Me.dvCargaHoraria.FindControl("chbLimitarASemAntMismoTipo_I"), CheckBox)
                chkbxFrenteGrupo = CType(Me.dvCargaHoraria.FindControl("chkbxFrenteGrupoI"), CheckBox)
            ElseIf Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "1" Or Request.Params("TipoOperacion") = "4" Then
                Me.dvCargaHoraria.DefaultMode = DetailsViewMode.Edit
                dr = ds.Tables(0).Rows(0)

                Me.dvCargaHoraria.DataSource = ds.Tables(0)
                Me.dvCargaHoraria.DataBind()
                ddlPlanteles = CType(Me.dvCargaHoraria.FindControl("ddlPlanteles"), DropDownList)
                ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMaterias"), DropDownList)
                ddlTipoHora = CType(Me.dvCargaHoraria.FindControl("ddlTipoHoraE"), DropDownList)
                ddlNominas = CType(Me.dvCargaHoraria.FindControl("ddlNominas"), DropDownList)
                ddlNombramiento = (CType(Me.dvCargaHoraria.FindControl("ddlNombramientoE"), DropDownList))
                ddlMotivoInterinato = (CType(Me.dvCargaHoraria.FindControl("ddlMotivoInterinatoE"), DropDownList))
                ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGrupos"), DropDownList)
                txtbxCantidad = CType(Me.dvCargaHoraria.FindControl("txtbxCantidad"), TextBox)
                ddlQnaIni = CType(Me.dvCargaHoraria.FindControl("ddlQnaIni_E"), DropDownList)
                ddlQnaFin = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_E"), DropDownList)
                ddlFchIni = CType(Me.dvCargaHoraria.FindControl("ddlFchIni_E"), DropDownList)
                ddlFchFin = CType(Me.dvCargaHoraria.FindControl("ddlFchFin_E"), DropDownList)
                chbLimitarASemAntMismoTipo = CType(Me.dvCargaHoraria.FindControl("chbLimitarASemAntMismoTipo_E"), CheckBox)
                chkbxFrenteGrupo = CType(Me.dvCargaHoraria.FindControl("chkbxFrenteGrupo"), CheckBox)
                If Request.Params("TipoOperacion") = "4" Then
                    CType(Me.dvCargaHoraria.FindControl("btnGuardar"), Button).Visible = False
                End If
            End If

            Dim ddlPlazas As DropDownList = CType(Me.dvCargaHoraria.FindControl("ddlPlazas"), DropDownList)
            Dim ddlSemestres As DropDownList = CType(Me.dvCargaHoraria.FindControl("ddlSemestres"), DropDownList)
            Dim ddlEstatus As DropDownList = CType(Me.dvCargaHoraria.FindControl("ddlEstatus"), DropDownList)

            If Request.Params("TipoOperacion") = "1" And Request.Params("IdHora") Is Nothing Then
                Me.MultiView1.SetActiveView(Me.View1)
                LlenaDDL(ddlPlazas, "Plazas", "IdPlaza", oEmp.ObtenPlazasVigentes(), String.Empty)
                'LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorEmpPorRFC(Request.Params("RFCEmp")), String.Empty)
                LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenPorUsuario(Session("Login")), String.Empty)
                LlenaDDL(ddlMaterias, "Materia", "IdMateria", oMateria.ObtenTodas(True), String.Empty)
                ddlMaterias_SelectedIndexChanged(sender, e)
                LlenaDDL(ddlEstatus, "DescEstatus", "IdEstatusHora", oHora.ObtenEstatus(True), String.Empty)
                LlenaDDL(ddlTipoHora, "TipoHora", "IdTipoHora", oHora.ObtenTiposPorMateria(CType(ddlMaterias.SelectedValue, Short), True), String.Empty)
                LlenaDDL(ddlNombramiento, "DescNombramiento", "IdNombramiento", oHora.ObtenNombramientos(True), String.Empty)
                ddlNombramientoE_SelectedIndexChanged(sender, e)
                LlenaDDL(ddlMotivoInterinato, "DescMotivoInterinato", "IdMotivoHoraInterina", oHora.ObtenMotivosInterinatos(), String.Empty)
                'LlenaDDL(ddlGrupos, "Grupo", "IdGrupo", oGrupo.ObtenTodos(), String.Empty)
                LlenaDDL(ddlGrupos, "Grupo", "IdGrupo", oGrupo.ObtenPorIdSemestre(CShort(Request.Params("IdSemestre"))), String.Empty)
                'LlenaDDL(ddlSemestres, "Semestre", "IdSemestre", oSemestre.ObtenActual(True), String.Empty)
                oSemestre.IdSemestre = CShort(Request.Params("IdSemestre"))
                LlenaDDL(ddlSemestres, "Semestre", "IdSemestre", oSemestre.ObtenPorId(), String.Empty)
                LlenaDDL(ddlNominas, "DescTipoNomina", "IdTipoNomina", oTipoNomina.ObtenTodas(True), String.Empty)
                ddlNominas_SelectedIndexChanged(sender, e)
                LlenaDDL(ddlQnaIni, "Quincena", "IdQuincena", oQna.ObtenPosiblesQnasIniParaHoras(CShort(ddlSemestres.SelectedValue)), String.Empty)
                LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenPosiblesQnasFinParaHoras(CShort(ddlSemestres.SelectedValue), CShort(ddlQnaIni.SelectedValue)), String.Empty)
                ddlQnaFin.SelectedIndex = ddlQnaFin.Items.Count - 1
                LlenaDDL(ddlFchIni, "Fecha", "Fecha", oQna.ObtenFechasPorQuincena(CShort(ddlQnaIni.SelectedValue), "I"), String.Empty)
                LlenaDDL(ddlFchFin, "Fecha", "Fecha", oQna.ObtenFechasPorQuincena(CShort(ddlQnaFin.SelectedValue), "F"), String.Empty)
            ElseIf Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "1" Or Request.Params("TipoOperacion") = "4" Then
                Me.MultiView1.SetActiveView(Me.View1)

                If Request.Params("TipoOperacion") = "0" Then
                    HoraSePuedeModificar = oHora.SePuedeModificar(CInt(Request.Params("IdHora")), CShort(Request.Params("IdSemestre")))
                    HoraSePuedeLimitarAuto = oHora.SePuedeLimitarAuto(CInt(Request.Params("IdHora")), CShort(Request.Params("IdSemestre")))
                End If

                LlenaDDL(ddlPlazas, "Plazas", "IdPlaza", oEmp.ObtenPlazasVigentes(), dr("IdPlaza"))
                If ddlPlazas.Items.Count = 0 Then
                    With oEmpleadoPlaza
                        .IdPlaza = CInt(dr("IdPlaza"))
                        LlenaDDL(ddlPlazas, "Plazas", "IdPlaza", .ObtenPorId.Table, dr("IdPlaza"))
                    End With
                End If
                'LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorEmpPorRFC(Request.Params("RFCEmp")), dr("IdPlantel"))
                LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenPorUsuario(Session("Login")), dr("IdPlantel"))
                ddlPlanteles.Enabled = HoraSePuedeModificar
                LlenaDDL(ddlMaterias, "Materia", "IdMateria", oMateria.ObtenTodas(True), dr("IdMateria"))
                ddlMaterias.Enabled = HoraSePuedeModificar
                'LlenaDDL(ddlGrupos, "Grupo", "IdGrupo", oGrupo.ObtenTodos(), dr("IdGrupo")) 
                'LlenaDDL(ddlGrupos, "Grupo", "IdGrupo", oGrupo.ObtenPorIdSemestre(CShort(dr("IdSemestre"))), dr("IdGrupo"))
                LlenaDDL(ddlGrupos, "Grupo", "IdGrupo", oGrupo.ObtenPorIdSemestre(CShort(Request.Params("IdSemestre"))), dr("IdGrupo"))
                ddlGrupos.Enabled = HoraSePuedeModificar 'kAnd ddlGrupos.SelectedValue = dr("IdGrupo")
                LlenaDDL(ddlTipoHora, "TipoHora", "IdTipoHora", oHora.ObtenTiposPorMateria(CType(ddlMaterias.SelectedValue, Short), True), dr("IdTipoHora"))
                ddlTipoHora.Enabled = HoraSePuedeModificar
                LlenaDDL(ddlNombramiento, "DescNombramiento", "IdNombramiento", oHora.ObtenNombramientos(True), dr("IdNombramiento"))
                ddlNombramiento.Enabled = HoraSePuedeModificar
                oHoras.IdNombramiento = CByte(ddlNombramiento.SelectedValue)
                If oHoras.EsInterina() And dr("RFCEmp").ToString <> String.Empty Then
                    Session.Add("RFCParaCons2", dr("RFCEmp"))
                    Session.Add("ApePatParaCons2", dr("ApePatEmp"))
                    Session.Add("ApeMatParaCons2", dr("ApeMatEmp"))
                    Session.Add("NombreParaCons2", dr("NomEmp"))
                    Dim drEmp As DataRow
                    oEmp.RFC = dr("RFCEmp").ToString
                    drEmp = oEmp.ObtenDatosPersonales().Rows(0)
                    Session.Add("NumEmpParaCons2", drEmp("NumEmp"))
                Else
                    Session.Remove("RFCParaCons2")
                    Session.Remove("ApePatParaCons2")
                    Session.Remove("ApeMatParaCons2")
                    Session.Remove("NombreParaCons2")
                    Session.Remove("NumEmpParaCons2")
                End If
                ddlNombramientoE_SelectedIndexChanged(sender, e)
                LlenaDDL(ddlMotivoInterinato, "DescMotivoInterinato", "IdMotivoHoraInterina", oHora.ObtenMotivosInterinatos(), dr("IdMotivoHoraInterina"))
                oHoras.IdNombramiento = CByte(ddlNombramiento.SelectedValue)
                ddlMotivoInterinato.Enabled = HoraSePuedeModificar And oHoras.EsInterina()
                'LlenaDDL(ddlSemestres, "Semestre", "IdSemestre", oSemestre.ObtenActual(True), dr("IdSemestre"))

                If Request.Params("TipoOperacion") <> "1" Then
                    LlenaDDL(ddlSemestres, "Semestre", "IdSemestre", ds.Tables(6), dr("IdSemestre"))
                    ddlSemestres.Enabled = HoraSePuedeModificar
                    chbLimitarASemAntMismoTipo.Visible = True And Request.Params("IdSemestre").ToString <> dr("IdSemestre").ToString _
                                                            And HoraSePuedeLimitarAuto
                Else
                    oSemestre.IdSemestre = CShort(Request.Params("IdSemestre"))
                    LlenaDDL(ddlSemestres, "Semestre", "IdSemestre", oSemestre.ObtenPorId(), String.Empty)
                    chbLimitarASemAntMismoTipo.Visible = False
                End If

                LlenaDDL(ddlEstatus, "DescEstatus", "IdEstatusHora", oHora.ObtenEstatus(True), dr("IdEstatusHora"))
                ddlEstatus.Enabled = HoraSePuedeModificar
                LlenaDDL(ddlNominas, "DescTipoNomina", "IdTipoNomina", oTipoNomina.ObtenTodas(True), dr("IdTipoNomina"))
                ddlNominas.Enabled = HoraSePuedeModificar
                ddlNominas_SelectedIndexChanged(sender, e)

                If ddlMaterias.Enabled = False Then txtbxCantidad.Text = dr("Cantidad")
                txtbxCantidad.Enabled = HoraSePuedeModificar

                LlenaDDL(ddlQnaIni, "Quincena", "IdQuincena", oQna.ObtenPosiblesQnasIniParaHoras(CShort(ddlSemestres.SelectedValue)), dr("IdQuincenaIni"))
                If Request.Params("TipoOperacion") <> "1" Then
                    ddlQnaIni.Enabled = HoraSePuedeModificar And Request.Params("IdSemestre").ToString = dr("IdSemestre").ToString
                Else
                    ddlQnaIni.Enabled = HoraSePuedeModificar
                End If

                'LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenPosiblesQnasFinParaHoras(CShort(ddlSemestres.SelectedValue), CShort(ddlQnaIni.SelectedValue)), dr("IdQuincenaFin"))
                If Request.Params("TipoOperacion") <> "0" Then
                    LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenPosiblesQnasFinParaHoras(CShort(Request.Params("IdSemestre")), CShort(ddlQnaIni.SelectedValue)), dr("IdQuincenaFin"))
                Else
                    LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenPosiblesQnasFinParaHoras(CShort(Request.Params("IdSemestre")), CShort(ddlQnaIni.SelectedValue), CInt(Request.Params("IdHora"))), dr("IdQuincenaFin"))
                End If

                LlenaDDL(ddlFchIni, "Fecha", "Fecha", oQna.ObtenFechasPorQuincena(CShort(ddlQnaIni.SelectedValue), "I"), dr("FchIni"))
                LlenaDDL(ddlFchFin, "Fecha", "Fecha", oQna.ObtenFechasPorQuincena(CShort(ddlQnaFin.SelectedValue), "F"), dr("FchFin"))

                chkbxFrenteGrupo.Enabled = HoraSePuedeModificar

                CType(Me.dvCargaHoraria.FindControl("btnGuardar"), Button).CausesValidation = IIf(CBool(dr("ProgramaUNA")) = True, False, True)

                If Request.Params("TipoOperacion") = "4" Then
                    CType(Me.dvCargaHoraria.FindControl("btnGuardar"), Button).Visible = False
                End If

                If (Request.Params("TipoOperacion") = "1" And Request.Params("AddInterina") Is Nothing = False) Then
                    'AplicaValidaciones()
                    Me.lblExito.Text = "La operación solicitada fue realizada correctamente."
                    Me.MultiView1.SetActiveView(Me.View2)
                    oEmp.AgregaHoraInterinaACargaHoraria(CInt(Request.Params("IdHora")), CType(Session("ArregloAuditoria"), String()))
                End If
            ElseIf Request.Params("TipoOperacion") = "2" Then
                'CType(Me.dvCargaHoraria.FindControl("btnGuardar"), Button).CausesValidation = False
                AplicaValidaciones()
                Me.MultiView1.SetActiveView(Me.View2)
                'Dim dt As DataTable
                'dt = oEmp.ObtenCargaHorariaSemestreActual()
                'If dt.Rows.Count = 0 Then
                oEmp.CreaCargaHorariaSemestreActual(CType(Request.Params("IdSemestre"), Short), CType(Session("ArregloAuditoria"), String()))
                'Else
                'Me.MultiView1.SetActiveView(Me.View3)
                'End If
            End If
        End If
    End Sub
    Protected Sub ddlMaterias_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dr As DataRow
        Dim ddlMaterias As DropDownList = Nothing
        Dim ddlTipoHora As DropDownList = Nothing
        Dim ddlGrupos As DropDownList = Nothing
        Dim txtbxCantidad As New TextBox
        Dim hfCantidad As New HiddenField
        Dim ddlTipoHoraSelectedValue As String
        Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = Nothing
        Dim drHora As DataRow = Nothing

        If Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Insert Then
            txtbxCantidad = CType(Me.dvCargaHoraria.FindControl("txtbxCantidadIns"), TextBox)
            hfCantidad = CType(Me.dvCargaHoraria.FindControl("hfCantidadIns"), HiddenField)
            ddlTipoHora = CType(Me.dvCargaHoraria.FindControl("ddlTipoHoraI"), DropDownList)
            ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMateriasI"), DropDownList)
            ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGruposI"), DropDownList)
            WucBuscaEmpleados2 = CType(Me.dvCargaHoraria.FindControl("WucBuscaEmpleados2_I"), WebControls_wucSearchEmps2)
        ElseIf Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Edit Then
            txtbxCantidad = CType(Me.dvCargaHoraria.FindControl("txtbxCantidad"), TextBox)
            hfCantidad = CType(Me.dvCargaHoraria.FindControl("hfCantidad"), HiddenField)
            ddlTipoHora = CType(Me.dvCargaHoraria.FindControl("ddlTipoHoraE"), DropDownList)
            ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMaterias"), DropDownList)
            ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGrupos"), DropDownList)
            WucBuscaEmpleados2 = CType(Me.dvCargaHoraria.FindControl("WucBuscaEmpleados2_E"), WebControls_wucSearchEmps2)
        End If

        Dim ddlTipoBusqueda As DropDownList = CType(WucBuscaEmpleados2.FindControl("ddlTipoBusqueda"), DropDownList)
        Dim rfvRFC As RequiredFieldValidator = CType(WucBuscaEmpleados2.FindControl("rfvRFC"), RequiredFieldValidator)
        Dim rfvNombre As RequiredFieldValidator = CType(WucBuscaEmpleados2.FindControl("rfvNombre"), RequiredFieldValidator)
        Dim rfvNumEmp As RequiredFieldValidator = CType(WucBuscaEmpleados2.FindControl("rfvNumEmp"), RequiredFieldValidator)

        Dim oMateria As New Materia
        oMateria.IdMateria = CType(ddlMaterias.SelectedValue, Short)
        dr = oMateria.ObtenHoras()

        Select Case ddlTipoBusqueda.SelectedValue
            Case "RFC"
                rfvRFC.Enabled = IIf(CBool(dr("ProgramaUNA")) = True, False, True)
                rfvNombre.Enabled = False
                rfvNumEmp.Enabled = False
            Case "NumEmp"
                rfvRFC.Enabled = False
                rfvNombre.Enabled = False
                rfvNumEmp.Enabled = IIf(CBool(dr("ProgramaUNA")) = True, False, True)
            Case "Nombre"
                rfvRFC.Enabled = False
                rfvNombre.Enabled = IIf(CBool(dr("ProgramaUNA")) = True, False, True)
                rfvNumEmp.Enabled = False
        End Select

        CType(Me.dvCargaHoraria.FindControl("btnGuardar"), Button).CausesValidation = IIf(CBool(dr("ProgramaUNA")) = True, False, True)

        Dim drMateria As DataRow
        Dim PermiteModifHorasMateria As Boolean = False
        drMateria = oMateria.ObtenPorId(CShort(ddlMaterias.SelectedValue))
        PermiteModifHorasMateria = CBool(drMateria("PermiteModifHorasMateria"))

        Dim HoraSePuedeModificar As Boolean = True

        Dim oHora As New Hora
        If Request.Params("TipoOperacion") = "0" Then
            HoraSePuedeModificar = oHora.SePuedeModificar(CInt(Request.Params("IdHora")), CShort(Request.Params("IdSemestre")))

            If Page.IsPostBack = False Then
                oHora.IdHora = CType(Request.Params("IdHora"), Integer)
                If Request.Params("AsociarInterinas") Is Nothing = False And Request.Params("TipoOperacion") = "0" Then
                    ds = oHora.ObtenPorId(True)
                Else
                    ds = oHora.ObtenPorId()
                End If
                drHora = ds.Tables(0).Rows(0)
            End If

            'HoraSePuedeLimitarAuto = oHora.SePuedeLimitarAuto(CInt(Request.Params("IdHora")), CShort(Request.Params("IdSemestre")))
        End If

        txtbxCantidad.ReadOnly = IIf(PermiteModifHorasMateria = True, False, True)

        If Request.Params("TipoOperacion") = "0" And Page.IsPostBack = False Then
            txtbxCantidad.Text = drHora("Cantidad")
        Else
            txtbxCantidad.Text = dr("HorasMateria")
        End If

        hfCantidad.Value = txtbxCantidad.Text

        ddlTipoHoraSelectedValue = ddlTipoHora.SelectedValue

        Dim oHoras As New Hora
        LlenaDDL(ddlTipoHora, "TipoHora", "IdTipoHora", oHoras.ObtenTiposPorMateria(CType(ddlMaterias.SelectedValue, Short), True), ddlTipoHoraSelectedValue)
        ddlMaterias.Focus()

        'Deshabilitamos el ddlGrupos si la materia elegida tiene el indicador de que no es frente a grupo,
        'como el caso de las horas de apoyo a la educación.
        ddlGrupos.Enabled = Not dr("NoGrupo")
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            AplicaValidaciones()

            Dim ddlTipoHora As DropDownList = Nothing
            Dim ddlPlanteles As DropDownList = Nothing
            Dim ddlMaterias As DropDownList = Nothing
            Dim ddlNominas As DropDownList = Nothing
            Dim ddlGrupos As DropDownList = Nothing
            Dim txtbxCantidad As TextBox = Nothing
            Dim ddlQnaIni As DropDownList = Nothing
            Dim ddlQnaFin As DropDownList = Nothing
            Dim ddlFchIni As DropDownList = Nothing
            Dim ddlFchFin As DropDownList = Nothing
            Dim ddlNombramiento As DropDownList = Nothing
            Dim ddlMotivoInterinato As DropDownList = Nothing
            Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = Nothing
            If Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Insert Then
                ddlTipoHora = CType(Me.dvCargaHoraria.FindControl("ddlTipoHoraI"), DropDownList)
                ddlNombramiento = CType(Me.dvCargaHoraria.FindControl("ddlNombramientoI"), DropDownList)
                ddlMotivoInterinato = CType(Me.dvCargaHoraria.FindControl("ddlMotivoInterinatoI"), DropDownList)
                WucBuscaEmpleados2 = CType(Me.dvCargaHoraria.FindControl("WucBuscaEmpleados2_I"), WebControls_wucSearchEmps2)
                ddlPlanteles = CType(Me.dvCargaHoraria.FindControl("ddlPlantelesI"), DropDownList)
                ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMateriasI"), DropDownList)
                ddlNominas = CType(Me.dvCargaHoraria.FindControl("ddlNominasI"), DropDownList)
                ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGruposI"), DropDownList)
                txtbxCantidad = CType(Me.dvCargaHoraria.FindControl("txtbxCantidadIns"), TextBox)
                ddlQnaIni = CType(Me.dvCargaHoraria.FindControl("ddlQnaIni_I"), DropDownList)
                ddlQnaFin = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_I"), DropDownList)
                ddlFchIni = CType(Me.dvCargaHoraria.FindControl("ddlFchIni_I"), DropDownList)
                ddlFchFin = CType(Me.dvCargaHoraria.FindControl("ddlFchFin_I"), DropDownList)
            ElseIf Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Edit Then
                ddlPlanteles = CType(Me.dvCargaHoraria.FindControl("ddlPlanteles"), DropDownList)
                ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMaterias"), DropDownList)
                ddlTipoHora = CType(Me.dvCargaHoraria.FindControl("ddlTipoHoraE"), DropDownList)
                ddlNombramiento = CType(Me.dvCargaHoraria.FindControl("ddlNombramientoE"), DropDownList)
                ddlMotivoInterinato = CType(Me.dvCargaHoraria.FindControl("ddlMotivoInterinatoE"), DropDownList)
                WucBuscaEmpleados2 = CType(Me.dvCargaHoraria.FindControl("WucBuscaEmpleados2_E"), WebControls_wucSearchEmps2)
                ddlNominas = CType(Me.dvCargaHoraria.FindControl("ddlNominas"), DropDownList)
                ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGrupos"), DropDownList)
                txtbxCantidad = CType(Me.dvCargaHoraria.FindControl("txtbxCantidad"), TextBox)
                ddlQnaIni = CType(Me.dvCargaHoraria.FindControl("ddlQnaIni_E"), DropDownList)
                ddlQnaFin = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_E"), DropDownList)
                ddlFchIni = CType(Me.dvCargaHoraria.FindControl("ddlFchIni_E"), DropDownList)
                ddlFchFin = CType(Me.dvCargaHoraria.FindControl("ddlFchFin_E"), DropDownList)
            End If

            Dim ddlPlazas As DropDownList = CType(Me.dvCargaHoraria.FindControl("ddlPlazas"), DropDownList)
            Dim ddlSemestres As DropDownList = CType(Me.dvCargaHoraria.FindControl("ddlSemestres"), DropDownList)
            Dim ddlEstatus As DropDownList = CType(Me.dvCargaHoraria.FindControl("ddlEstatus"), DropDownList)
            If ddlTipoHora Is Nothing Then ddlTipoHora = CType(Me.dvCargaHoraria.FindControl("ddlTipoHoraI"), DropDownList)
            Dim hfRFC As HiddenField = CType(WucBuscaEmpleados2.FindControl("hfRFC"), HiddenField)

            Dim oHoras As New Hora
            With oHoras
                .IdHora = CType(Request.Params("IdHora"), Integer)
                .IdPlaza = CType(ddlPlazas.SelectedValue, Integer)
                .IdPlantel = CShort(ddlPlanteles.SelectedValue)
                .IdMateria = CType(ddlMaterias.SelectedValue, Short)
                'If txtbxCantidad.ReadOnly Then
                '    .Horas = 0
                'Else
                .Horas = CByte(txtbxCantidad.Text)
                'End If
                .IdGrupo = CType(ddlGrupos.SelectedValue, Byte)
                .IdTipoHora = CType(ddlTipoHora.SelectedValue, Byte)
                .IdNombramiento = CType(ddlNombramiento.SelectedValue, Byte)
                .IdMotivoHoraInterina = CType(ddlMotivoInterinato.SelectedValue, Byte)
                .RFCEmp = hfRFC.Value
                .IdTipoNomina = CType(ddlNominas.SelectedValue, Byte)
                '.IdSemestre = CShort(Request.Params("IdSemestre")) 'CType(ddlSemestres.SelectedValue, Short)
                .IdSemestre = CType(ddlSemestres.SelectedValue, Short)
                .IdEstatusHora = CType(ddlEstatus.SelectedValue, Byte)
                .IdQuincenaIni = CShort(ddlQnaIni.SelectedValue)
                .IdQuincenaFin = CShort(ddlQnaFin.SelectedValue)
                .FchIni = CDate(ddlFchIni.SelectedItem.Text)
                .FchFin = CDate(ddlFchFin.SelectedItem.Text)
                If Request.Params("TipoOperacion") = "0" Then
                    Dim HoraSePuedeModificar As Boolean
                    Dim oHora As New Hora

                    If Request.Params("TipoOperacion") = "0" Then
                        HoraSePuedeModificar = oHora.SePuedeModificar(CInt(Request.Params("IdHora")), CShort(Request.Params("IdSemestre")))
                    End If

                    .SoloModifQnaFin = HoraSePuedeModificar

                    '.IdTipoHora = CType(CType(Me.dvCargaHoraria.FindControl("ddlTipoHoraE"), DropDownList).SelectedValue, Byte)
                    If Request.Params("AsociarInterinas") Is Nothing Then
                        .Actualizar(0, CType(Session("ArregloAuditoria"), String()))
                    Else
                        .ActualizarInterinas(CType(Session("ArregloAuditoria"), String()))
                    End If
                    Me.MultiView1.SetActiveView(Me.View2)
                    Me.lblExito.Text = "Modificación realizada exitosamente."
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .SoloModifQnaFin = True
                    '.IdTipoHora = CType(CType(Me.dvCargaHoraria.FindControl("ddlTipoHoraI"), DropDownList).SelectedValue, Byte)
                    If Request.Params("AsociarInterinas") Is Nothing Then
                        .Insertar(CType(Session("ArregloAuditoria"), String()))
                    Else
                        .InsertarInterinas(CType(Session("ArregloAuditoria"), String()))
                    End If
                    Me.MultiView1.SetActiveView(Me.View2)
                    Me.lblExito.Text = "Inserción realizada exitosamente."
                End If
            End With
        Catch Ex As Exception
            Me.MultiView1.SetActiveView(Me.View3)
            Me.lblError.Text = Ex.Message
        End Try
    End Sub
    Protected Sub ddlNominas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlMaterias As DropDownList = Nothing
        Dim ddlNominas As DropDownList = Nothing
        Dim txtbxCantidad As TextBox = Nothing
        Dim rfvCantidad As RequiredFieldValidator = Nothing
        Dim rvCantidad As RangeValidator = Nothing
        Dim ddlGrupos As DropDownList = Nothing
        Dim chkbxFrenteGrupo As CheckBox = Nothing
        If Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Edit Then
            ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMaterias"), DropDownList)
            ddlNominas = CType(Me.dvCargaHoraria.FindControl("ddlNominas"), DropDownList)
            txtbxCantidad = CType(Me.dvCargaHoraria.FindControl("txtbxCantidad"), TextBox)
            rfvCantidad = CType(Me.dvCargaHoraria.FindControl("rfvCantidad"), RequiredFieldValidator)
            rvCantidad = CType(Me.dvCargaHoraria.FindControl("rvCantidad"), RangeValidator)
            ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGrupos"), DropDownList)
            chkbxFrenteGrupo = CType(Me.dvCargaHoraria.FindControl("chkbxFrenteGrupo"), CheckBox)
        ElseIf Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Insert Then
            ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMateriasI"), DropDownList)
            ddlNominas = CType(Me.dvCargaHoraria.FindControl("ddlNominasI"), DropDownList)
            txtbxCantidad = CType(Me.dvCargaHoraria.FindControl("txtbxCantidadIns"), TextBox)
            rfvCantidad = CType(Me.dvCargaHoraria.FindControl("rfvCantidadI"), RequiredFieldValidator)
            rvCantidad = CType(Me.dvCargaHoraria.FindControl("rvCantidadI"), RangeValidator)
            ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGruposI"), DropDownList)
            chkbxFrenteGrupo = CType(Me.dvCargaHoraria.FindControl("chkbxFrenteGrupoI"), CheckBox)
        End If

        Dim oMateria As New Materia
        Dim drMateria As DataRow
        Dim PermiteModifHorasMateria As Boolean = False
        drMateria = oMateria.ObtenPorId(CShort(ddlMaterias.SelectedValue))
        PermiteModifHorasMateria = CBool(drMateria("PermiteModifHorasMateria"))

        Dim HoraSePuedeModificar As Boolean = True

        Dim oHora As New Hora
        If Request.Params("TipoOperacion") = "0" Then
            HoraSePuedeModificar = oHora.SePuedeModificar(CInt(Request.Params("IdHora")), CShort(Request.Params("IdSemestre")))
            'HoraSePuedeLimitarAuto = oHora.SePuedeLimitarAuto(CInt(Request.Params("IdHora")), CShort(Request.Params("IdSemestre")))
        End If
        Select Case ddlNominas.SelectedValue
            Case "3", "2"
                ddlMaterias.Enabled = False
                'txtbxCantidad.Text = "1"
                txtbxCantidad.Focus()
                txtbxCantidad.ReadOnly = False
                rfvCantidad.Enabled = True
                rvCantidad.Enabled = True
                ddlGrupos.Enabled = False
                chkbxFrenteGrupo.Enabled = True
            Case Else
                ddlMaterias.Enabled = HoraSePuedeModificar ' True
                txtbxCantidad.ReadOnly = True And PermiteModifHorasMateria = False
                rfvCantidad.Enabled = False
                rvCantidad.Enabled = False
                ddlMaterias_SelectedIndexChanged(sender, e)
                ddlGrupos.Enabled = HoraSePuedeModificar 'True
                chkbxFrenteGrupo.Enabled = False
        End Select

        LlenaDDL(ddlMaterias, "Materia", "IdMateria", oMateria.ObtenTodas(True), drMateria("IdMateria"))

        '3	03	CISCO
        '2	02	DIES
        '4	04	EMSAD
        '1	01	NORMAL
        '5	05	RECURSOS PROPIOS
    End Sub

    Protected Sub ddlQnaIni_E_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlQnaIni As DropDownList = Nothing
        Dim ddlQnaFin As DropDownList = Nothing
        Dim ddlFchIni As DropDownList = Nothing
        Dim ddlFchFin As DropDownList = Nothing
        Dim ddlSemestres As DropDownList = Nothing
        Dim oQna As New Quincenas
        If Me.dvCargaHoraria.DefaultMode = DetailsViewMode.Edit Then
            ddlQnaIni = CType(Me.dvCargaHoraria.FindControl("ddlQnaIni_E"), DropDownList)
            ddlQnaFin = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_E"), DropDownList)
            ddlFchIni = CType(Me.dvCargaHoraria.FindControl("ddlFchIni_E"), DropDownList)
            ddlFchFin = CType(Me.dvCargaHoraria.FindControl("ddlFchFin_E"), DropDownList)
        ElseIf Me.dvCargaHoraria.DefaultMode = DetailsViewMode.Insert Then
            ddlQnaIni = CType(Me.dvCargaHoraria.FindControl("ddlQnaIni_I"), DropDownList)
            ddlQnaFin = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_I"), DropDownList)
            ddlFchIni = CType(Me.dvCargaHoraria.FindControl("ddlFchIni_I"), DropDownList)
            ddlFchFin = CType(Me.dvCargaHoraria.FindControl("ddlFchFin_I"), DropDownList)
        End If
        ddlSemestres = CType(Me.dvCargaHoraria.FindControl("ddlSemestres"), DropDownList)
        LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenPosiblesQnasFinParaHoras(CShort(ddlSemestres.SelectedValue), CShort(ddlQnaIni.SelectedValue)), String.Empty)
        ddlQnaFin.SelectedIndex = ddlQnaFin.Items.Count - 1
        LlenaDDL(ddlFchIni, "Fecha", "Fecha", oQna.ObtenFechasPorQuincena(CShort(ddlQnaIni.SelectedValue), "I"), String.Empty)
        LlenaDDL(ddlFchFin, "Fecha", "Fecha", oQna.ObtenFechasPorQuincena(CShort(ddlQnaFin.SelectedValue), "F"), String.Empty)
    End Sub

    Protected Sub ddlQnaIni_I_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddlQnaIni_E_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub ddlQnaFin_E_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlQnaFin As DropDownList = Nothing
        Dim ddlFchFin As DropDownList = Nothing
        Dim oQna As New Quincenas
        If Me.dvCargaHoraria.DefaultMode = DetailsViewMode.Edit Then
            ddlQnaFin = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_E"), DropDownList)
            ddlFchFin = CType(Me.dvCargaHoraria.FindControl("ddlFchFin_E"), DropDownList)
        ElseIf Me.dvCargaHoraria.DefaultMode = DetailsViewMode.Insert Then
            ddlQnaFin = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_I"), DropDownList)
            ddlFchFin = CType(Me.dvCargaHoraria.FindControl("ddlFchFin_I"), DropDownList)
        End If
        LlenaDDL(ddlFchFin, "Fecha", "Fecha", oQna.ObtenFechasPorQuincena(CShort(ddlQnaFin.SelectedValue), "F"), String.Empty)
    End Sub

    Protected Sub ddlQnaFin_I_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddlQnaFin_E_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub chkbxFrenteGrupo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlMaterias As DropDownList = Nothing
        Dim txtbxCantidad As TextBox = Nothing
        Dim rfvCantidad As RequiredFieldValidator = Nothing
        Dim rvCantidad As RangeValidator = Nothing
        Dim ddlGrupos As DropDownList = Nothing
        Dim chkbxFrenteGrupo As CheckBox = Nothing
        If Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Edit Then
            ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMaterias"), DropDownList)
            txtbxCantidad = CType(Me.dvCargaHoraria.FindControl("txtbxCantidad"), TextBox)
            rfvCantidad = CType(Me.dvCargaHoraria.FindControl("rfvCantidad"), RequiredFieldValidator)
            rvCantidad = CType(Me.dvCargaHoraria.FindControl("rvCantidad"), RangeValidator)
            ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGrupos"), DropDownList)
            chkbxFrenteGrupo = CType(Me.dvCargaHoraria.FindControl("chkbxFrenteGrupo"), CheckBox)
        ElseIf Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Insert Then
            ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMateriasI"), DropDownList)
            txtbxCantidad = CType(Me.dvCargaHoraria.FindControl("txtbxCantidadIns"), TextBox)
            rfvCantidad = CType(Me.dvCargaHoraria.FindControl("rfvCantidadI"), RequiredFieldValidator)
            rvCantidad = CType(Me.dvCargaHoraria.FindControl("rvCantidadI"), RangeValidator)
            ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGruposI"), DropDownList)
            chkbxFrenteGrupo = CType(Me.dvCargaHoraria.FindControl("chkbxFrenteGrupoI"), CheckBox)
        End If

        Dim oMateria As New Materia
        Dim drMateria As DataRow
        Dim PermiteModifHorasMateria As Boolean = False
        drMateria = oMateria.ObtenPorId(CShort(ddlMaterias.SelectedValue))
        PermiteModifHorasMateria = CBool(drMateria("PermiteModifHorasMateria"))

        Select Case chkbxFrenteGrupo.Checked
            Case False
                ddlMaterias.Enabled = False
                'txtbxCantidad.Text = "1"
                txtbxCantidad.Focus()
                txtbxCantidad.ReadOnly = False
                rfvCantidad.Enabled = True
                rvCantidad.Enabled = True
                ddlGrupos.Enabled = False
                'chkbxFrenteGrupo.Enabled = True
            Case Else
                ddlMaterias.Enabled = True
                txtbxCantidad.ReadOnly = True And PermiteModifHorasMateria = False
                rfvCantidad.Enabled = False
                rvCantidad.Enabled = False
                ddlMaterias_SelectedIndexChanged(sender, e)
                ddlGrupos.Enabled = True
                'chkbxFrenteGrupo.Enabled = False
        End Select
        '3	03	CISCO
        '2	02	DIES
        '4	04	EMSAD
        '1	01	NORMAL
        '5	05	RECURSOS PROPIOS
    End Sub

    Protected Sub ddlNombramientoE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oHoras As New Hora
        Dim ddlNombramiento As DropDownList = Nothing
        Dim ddlMotivoInterinato As DropDownList = Nothing
        Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = Nothing
        Dim LblEmpTitularSD As Label = Nothing
        If Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Insert Then
            ddlNombramiento = CType(Me.dvCargaHoraria.FindControl("ddlNombramientoI"), DropDownList)
            ddlMotivoInterinato = CType(Me.dvCargaHoraria.FindControl("ddlMotivoInterinatoI"), DropDownList)
            WucBuscaEmpleados2 = CType(Me.dvCargaHoraria.FindControl("WucBuscaEmpleados2_I"), WebControls_wucSearchEmps2)
            LblEmpTitularSD = CType(Me.dvCargaHoraria.FindControl("LblEmpTitularSDI"), Label)
        ElseIf Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Edit Then
            ddlNombramiento = CType(Me.dvCargaHoraria.FindControl("ddlNombramientoE"), DropDownList)
            ddlMotivoInterinato = CType(Me.dvCargaHoraria.FindControl("ddlMotivoInterinatoE"), DropDownList)
            WucBuscaEmpleados2 = CType(Me.dvCargaHoraria.FindControl("WucBuscaEmpleados2_E"), WebControls_wucSearchEmps2)
            LblEmpTitularSD = CType(Me.dvCargaHoraria.FindControl("LblEmpTitularSDE"), Label)
        End If

        Dim txtbxRFC As TextBox = CType(WucBuscaEmpleados2.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(WucBuscaEmpleados2.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados2.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(WucBuscaEmpleados2.FindControl("hfNomEmp"), HiddenField)
        Dim txtbxNumEmp As TextBox = CType(WucBuscaEmpleados2.FindControl("txtbxNumEmp"), TextBox)
        Dim hfNumEmp As HiddenField = CType(WucBuscaEmpleados2.FindControl("hfNumEmp"), HiddenField)
        'Dim ibBuscarEmp As ImageButton = CType(WucBuscaEmpleados2.FindControl("ibBuscarEmp"), ImageButton)
        'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=AdministracionCargaHoraria','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false")

        oHoras.IdNombramiento = CByte(ddlNombramiento.SelectedValue)
        If oHoras.EsInterina() Then
            ddlMotivoInterinato.Enabled = True
            WucBuscaEmpleados2.Visible = True
            LblEmpTitularSD.Visible = False
        Else
            ddlMotivoInterinato.Enabled = False
            ddlMotivoInterinato.SelectedValue = "1"
            WucBuscaEmpleados2.Visible = False
            LblEmpTitularSD.Visible = True
        End If
    End Sub

    Protected Sub chbLimitarASemAntMismoTipo_E_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlQnaIni As DropDownList = CType(Me.dvCargaHoraria.FindControl("ddlQnaIni_E"), DropDownList)
        Dim ddlQnaFin As DropDownList = CType(Me.dvCargaHoraria.FindControl("ddlQnaFin_E"), DropDownList)
        Dim chbLimitarASemAntMismoTipo As CheckBox = Nothing
        Dim oSem As New Semestre
        Dim oQna As New Quincenas
        Dim oHora As New Hora
        Dim ds As DataSet
        Dim dr As DataRow

        oHora.IdHora = CType(Request.Params("IdHora"), Integer)
        If Request.Params("AsociarInterinas") Is Nothing = False And Request.Params("TipoOperacion") = "0" Then
            ds = oHora.ObtenPorId(True)
        Else
            ds = oHora.ObtenPorId()
        End If
        dr = ds.Tables(0).Rows(0)

        chbLimitarASemAntMismoTipo = CType(Me.dvCargaHoraria.FindControl("chbLimitarASemAntMismoTipo_E"), CheckBox)

        If chbLimitarASemAntMismoTipo.Checked Then
            LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oSem.ObtenUltDeUnTipo(CShort(Request.Params("IdSemestre"))), String.Empty)
        Else
            LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenPosiblesQnasFinParaHoras(CShort(Request.Params("IdSemestre")), CShort(ddlQnaIni.SelectedValue)), dr("IdQuincenaFin"))
        End If
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If IsPostBack = False Then
            Dim HoraSePuedeModificar As Boolean
            Dim oHora As New Hora
            Dim ddlNombramiento As DropDownList = Nothing
            'Dim ibBuscarEmp As ImageButton = Nothing
            Dim ddlMaterias As DropDownList = Nothing
            Dim ddlGrupos As DropDownList = Nothing
            Dim WucBuscaEmpleados2 As WebControls_wucSearchEmps2 = Nothing
            Dim BtnSearch As Button = Nothing ' CType(WucBuscaEmpleados2.FindControl("BtnSearch"), Button)
            Dim BtnNewSearch As Button = Nothing 'CType(WucBuscaEmpleados2.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = Nothing 'CType(WucBuscaEmpleados2.FindControl("BtnCancelSearch"), Button)
            'Dim btnLimpiarValores As Button
            If Request.Params("TipoOperacion") = "0" Then
                HoraSePuedeModificar = oHora.SePuedeModificar(CInt(Request.Params("IdHora")), CShort(Request.Params("IdSemestre")))
                ddlGrupos = CType(Me.dvCargaHoraria.FindControl("ddlGrupos"), DropDownList)
                ddlMaterias = CType(Me.dvCargaHoraria.FindControl("ddlMaterias"), DropDownList)
                ddlNombramiento = CType(Me.dvCargaHoraria.FindControl("ddlNombramientoE"), DropDownList)
                WucBuscaEmpleados2 = CType(Me.dvCargaHoraria.FindControl("WucBuscaEmpleados2_E"), WebControls_wucSearchEmps2)
                oHora.IdNombramiento = CByte(ddlNombramiento.SelectedValue)
                If oHora.EsInterina() Then
                    BtnSearch = CType(WucBuscaEmpleados2.FindControl("BtnSearch"), Button)
                    BtnNewSearch = CType(WucBuscaEmpleados2.FindControl("BtnNewSearch"), Button)
                    BtnCancelSearch = CType(WucBuscaEmpleados2.FindControl("BtnCancelSearch"), Button)
                    ddlMaterias.Enabled = HoraSePuedeModificar
                    ddlGrupos.Enabled = HoraSePuedeModificar
                    BtnSearch.Visible = HoraSePuedeModificar
                    BtnNewSearch.Visible = HoraSePuedeModificar
                    BtnCancelSearch.Visible = HoraSePuedeModificar
                    'ibBuscarEmp = CType(WucBuscaEmpleados2.FindControl("ibBuscarEmp"), ImageButton)
                    'ibBuscarEmp.Visible = HoraSePuedeModificar
                    'btnLimpiarValores = CType(WucBuscaEmpleados2.FindControl("btnLimpiarValores"), Button)
                    'btnLimpiarValores.Enabled = HoraSePuedeModificar
                End If
            End If
        End If
    End Sub
End Class
