Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Planteles

Partial Class PlantelesGruposPorSemestreQna
    Inherits System.Web.UI.Page
    Private Overloads Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Overloads Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dv As DataView, ByVal SelectedValue As String)
        ddl.DataSource = dv
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub

    Private Sub BindDatos()
        Dim oSem As New Semestre
        Me.ddlSemestres.DataSource = oSem.ObtenSemestres
        Me.ddlSemestres.DataTextField = "Semestre"
        Me.ddlSemestres.DataValueField = "IdSemestre"
        Me.ddlSemestres.DataBind()
        If Me.ddlSemestres.Items.Count = 0 Then
            Me.ddlSemestres.Items.Insert(0, "No existe información de semestres")
            Me.ddlSemestres.Items(0).Value = -1
            Me.btnConsultarQuincenas.Enabled = False
        Else
            Me.btnConsultarQuincenas.Enabled = True
        End If
    End Sub
    'Private Sub BindQuincenas(Optional ByVal pSortExpression As String = "Quincena", Optional ByVal pSortDirection As String = "desc")
    Private Sub BindQuincenas()
        'Dim oQna As New Quincenas
        'Dim myDataView As New DataView()
        'Dim dt As DataTable = oQna.ObtenOrdinariasPorSemestre(CShort(Me.ddlSemestres.SelectedValue))

        'myDataView = dt.DefaultView

        ''If (pSortExpression <> String.Empty) Then
        ''    myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
        ''End If

        'With ddlQuincenas
        '    .DataSource = myDataView
        '    .DataTextField = "Quincena"
        '    .DataValueField = "IdQuincena"
        '    .DataBind()
        '    pnlQuincenas.GroupingText = "Quincenas asociadas al semestre: " + Me.ddlSemestres.SelectedItem.Text + " (Seleccione quincena)"
        'End With
        Dim dt As DataTable
        Dim oQna As New Quincenas
        Dim dr() As DataRow
        Dim pSelectedValue As String = "0"

        dt = oQna.ObtenOrdinariasPorSemestre(CShort(Me.ddlSemestres.SelectedValue))
        dr = dt.Select("AbrevEstatusQna In ('A')", "Quincena Desc") 'Verificamos si alguna quincena está abierta para captura

        If dr.Length = 0 Then
            dr = dt.Select("AbrevEstatusQna In ('B')", "Quincena Desc") 'Verificamos si alguna quincena está lista para cálculo
        End If

        If dr.Length = 0 Then
            dr = dt.Select("AbrevEstatusQna In ('C')", "Quincena Desc") 'Verificamos si alguna quincena está calculada
        End If

        If dr.Length = 0 Then
            dr = dt.Select("AbrevEstatusQna In ('D')", "Quincena Desc") 'Verificamos si alguna quincena no calculada
        End If

        If dr.Length > 0 Then
            pSelectedValue = dr(0).Item("IdQuincena").ToString
        End If

        With ddlQuincenas
            dt.DefaultView.Sort = "Quincena Desc"
            .DataSource = dt
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
        End With
        If pSelectedValue <> "0" Then
            ddlQuincenas.SelectedValue = pSelectedValue
        End If
        pnlQuincenas.GroupingText = "Quincenas asociadas al semestre: " + Me.ddlSemestres.SelectedItem.Text + " (Seleccione quincena)"
    End Sub
    Private Sub BindPlanteles(Optional ByVal pSortExpression As String = "Plantel", Optional ByVal pSortDirection As String = "asc")
        Dim oPlantel As New Plantel
        Dim myDataView As New DataView()
        Dim dt As DataTable = oPlantel.ObtenVigentesPorQna(CShort(Me.ddlQuincenas.SelectedValue))

        myDataView = dt.DefaultView

        If (pSortExpression <> String.Empty) Then
            myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
        End If

        With ddlPlanteles
            .DataSource = myDataView
            .DataTextField = "Plantel"
            .DataValueField = "ClaveCTSE"
            .DataBind()
            pnlPlanteles.GroupingText = "Planteles vigentes en la quincena: " + Me.ddlQuincenas.SelectedItem.Text + " (Seleccione plantel)"
        End With

    End Sub
    Private Sub BindGrupos()
        Dim oPlantel As New Plantel
        Dim ds As DataSet

        ds = oPlantel.ObtenGruposPorSemestreQna(CShort(ddlSemestres.SelectedValue), CShort(ddlQuincenas.SelectedValue), ddlPlanteles.SelectedValue)

        pnlSemestres2.GroupingText = "Información mostrada relacionada al Semestre " + ddlSemestres.SelectedItem.Text + ", Quincena " + ddlQuincenas.SelectedItem.Text + ", Plantel " + ddlPlanteles.SelectedItem.Text

        If Right(ddlSemestres.SelectedItem.Text, 1) = "B" Then
            gvSegSem.Visible = False
            gvCuartoSem.Visible = False
            gvSextoSem.Visible = False
            lbAddGrupoSegSem.Visible = False
            lbAddGrupoCuartoSem.Visible = False
            lbAddGrupoSextoSem.Visible = False

            gvPrimSem.DataSource = ds.Tables(0)
            gvPrimSem.DataBind()
            gvPrimSem.Visible = True
            lbAddGrupoPrimSem.Visible = True

            If gvPrimSem.Rows.Count = 0 Then
                gvPrimSem.EmptyDataText = "Sin información de grupos en el Primer Semestre (" + ddlSemestres.SelectedItem.Text + ")"
                gvPrimSem.DataBind()
            End If

            gvTercSem.DataSource = ds.Tables(1)
            gvTercSem.DataBind()
            gvTercSem.Visible = True
            lbAddGrupoTercSem.Visible = True

            If gvTercSem.Rows.Count = 0 Then
                gvTercSem.EmptyDataText = "Sin información de grupos en el Tercer Semestre (" + ddlSemestres.SelectedItem.Text + ")"
                gvTercSem.DataBind()
            End If

            gvQuintoSem.DataSource = ds.Tables(2)
            gvQuintoSem.DataBind()
            gvQuintoSem.Visible = True
            lbAddGrupoQuintoSem.Visible = True

            If gvQuintoSem.Rows.Count = 0 Then
                gvQuintoSem.EmptyDataText = "Sin información de grupos en el Quinto Semestre (" + ddlSemestres.SelectedItem.Text + ")"
                gvQuintoSem.DataBind()
            End If
        Else
            gvPrimSem.Visible = False
            gvTercSem.Visible = False
            gvQuintoSem.Visible = False
            lbAddGrupoPrimSem.Visible = False
            lbAddGrupoTercSem.Visible = False
            lbAddGrupoQuintoSem.Visible = False

            gvSegSem.DataSource = ds.Tables(0)
            gvSegSem.DataBind()
            gvSegSem.Visible = True
            lbAddGrupoSegSem.Visible = True

            If gvSegSem.Rows.Count = 0 Then
                gvSegSem.EmptyDataText = "Sin información de grupos en el Segundo Semestre (" + ddlSemestres.SelectedItem.Text + ")"
                gvSegSem.DataBind()
            End If

            gvCuartoSem.DataSource = ds.Tables(1)
            gvCuartoSem.DataBind()
            gvCuartoSem.Visible = True
            lbAddGrupoCuartoSem.Visible = True

            If gvCuartoSem.Rows.Count = 0 Then
                gvCuartoSem.EmptyDataText = "Sin información de grupos en el Cuarto Semestre (" + ddlSemestres.SelectedItem.Text + ")"
                gvCuartoSem.DataBind()
            End If

            gvSextoSem.DataSource = ds.Tables(2)
            gvSextoSem.DataBind()
            gvSextoSem.Visible = True
            lbAddGrupoSextoSem.Visible = True

            If gvSextoSem.Rows.Count = 0 Then
                gvSextoSem.EmptyDataText = "Sin información de grupos en el Sexto Semestre (" + ddlSemestres.SelectedItem.Text + ")"
                gvSextoSem.DataBind()
            End If
        End If

    End Sub
    Private Property sortOrder As String
        Get
            If (ViewState("sortOrder").ToString() = "desc") Then
                ViewState("sortOrder") = "asc"
            Else
                ViewState("sortOrder") = "desc"
            End If

            Return ViewState("sortOrder").ToString()
        End Get

        Set(value As String)
            ViewState("sortOrder") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            ViewState("sortOrder") = ""
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
            If Me.ddlSemestres.SelectedValue <> -1 Then
                BindQuincenas()
                BindPlanteles("Plantel", "asc")
                rblOrdenPlanteles.Items(0).Text = "Ordenar planteles por clave"
                rblOrdenPlanteles.Items(1).Text = "Ordenar planteles por nombre (actual)"
                BindGrupos()
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        'ViewState("sortOrder") = "desc"
        BindQuincenas()
        Select Case rblOrdenPlanteles.SelectedValue
            Case "0"
                BindPlanteles("ClavePlantel", "asc")
                rblOrdenPlanteles.Items(0).Text = "Ordenar planteles por clave (actual)"
                rblOrdenPlanteles.Items(1).Text = "Ordenar planteles por nombre"
            Case "1"
                BindPlanteles("Plantel", "asc")
                rblOrdenPlanteles.Items(0).Text = "Ordenar planteles por clave"
                rblOrdenPlanteles.Items(1).Text = "Ordenar planteles por nombre (actual)"
        End Select
        BindGrupos()
    End Sub

    Protected Sub btnConsultarPlanteles_Click(sender As Object, e As System.EventArgs) Handles btnConsultarPlanteles.Click
        Select Case rblOrdenPlanteles.SelectedValue
            Case "0"
                BindPlanteles("ClavePlantel", "asc")
                rblOrdenPlanteles.Items(0).Text = "Ordenar planteles por clave (actual)"
                rblOrdenPlanteles.Items(1).Text = "Ordenar planteles por nombre"
            Case "1"
                BindPlanteles("Plantel", "asc")
                rblOrdenPlanteles.Items(0).Text = "Ordenar planteles por clave"
                rblOrdenPlanteles.Items(1).Text = "Ordenar planteles por nombre (actual)"
        End Select
        BindGrupos()
    End Sub

    Protected Sub btnAplicarOrden_Click(sender As Object, e As System.EventArgs) Handles btnAplicarOrden.Click
        Select Case rblOrdenPlanteles.SelectedValue
            Case "0"
                BindPlanteles("ClavePlantel", "asc")
                rblOrdenPlanteles.Items(0).Text = "Ordenar planteles por clave (actual)"
                rblOrdenPlanteles.Items(1).Text = "Ordenar planteles por nombre"
            Case "1"
                BindPlanteles("Plantel", "asc")
                rblOrdenPlanteles.Items(0).Text = "Ordenar planteles por clave"
                rblOrdenPlanteles.Items(1).Text = "Ordenar planteles por nombre (actual)"
        End Select
        BindGrupos()
    End Sub

    Protected Sub btnConsultarGrupos_Click(sender As Object, e As System.EventArgs) Handles btnConsultarGrupos.Click
        BindGrupos()
    End Sub
    Protected Sub lbAddGrupo_Click(sender As Object, e As System.EventArgs) Handles lbAddGrupoPrimSem.Click, lbAddGrupoTercSem.Click, lbAddGrupoQuintoSem.Click, lbAddGrupoSegSem.Click, lbAddGrupoCuartoSem.Click, lbAddGrupoSextoSem.Click
        MultiView1.SetActiveView(viewAddGrupo)
        Dim lbAddGrupo As LinkButton = CType(sender, LinkButton)
        Dim oPlantel As New Plantel
        Dim dt As DataTable
        Dim vlEsBachGral As Boolean = False
        Dim vlEsEMSAD As Boolean = False
        Dim oGrupos As New Grupo
        Dim oMateria As New Materia
        Dim oQna As New Quincenas
        Dim myDataView As New DataView()
        Dim dtCapac, dtActsParaEsc, dtGposDisc As DataTable

        dt = oPlantel.ObtenInfParaCrearGrupo(ddlPlanteles.SelectedValue, CShort(ddlSemestres.SelectedValue), 0)

        lblPlantel.Text = ddlPlanteles.SelectedItem.Text
        lblClavePlantel.Text = dt.Rows(0).Item("ClaveCTSE").ToString

        vlEsBachGral = dt.Rows(0).Item("EsBachGral")
        vlEsEMSAD = dt.Rows(0).Item("EsEMSAD")

        Select Case lbAddGrupo.CommandArgument
            Case 1
                lblSemestre.Text = "PRIMERO"
                If gvPrimSem.Rows.Count > 0 Then
                    lblGrupo.Text = (CInt(gvPrimSem.Rows(gvPrimSem.Rows.Count - 1).Cells(1).Text) + 1).ToString
                Else
                    lblGrupo.Text = "101"
                End If
            Case 2
                lblSemestre.Text = "SEGUNDO"
                If gvSegSem.Rows.Count > 0 Then
                    lblGrupo.Text = (CInt(gvSegSem.Rows(gvSegSem.Rows.Count - 1).Cells(1).Text) + 1).ToString
                Else
                    lblGrupo.Text = "201"
                End If
            Case 3
                lblSemestre.Text = "TERCERO"
                If gvTercSem.Rows.Count > 0 Then
                    lblGrupo.Text = (CInt(gvTercSem.Rows(gvTercSem.Rows.Count - 1).Cells(1).Text) + 1).ToString
                Else
                    lblGrupo.Text = "301"
                End If
            Case 4
                lblSemestre.Text = "CUARTO"
                If gvCuartoSem.Rows.Count > 0 Then
                    lblGrupo.Text = (CInt(gvCuartoSem.Rows(gvCuartoSem.Rows.Count - 1).Cells(1).Text) + 1).ToString
                Else
                    lblGrupo.Text = "401"
                End If
            Case 5
                lblSemestre.Text = "QUINTO"
                If gvQuintoSem.Rows.Count > 0 Then
                    lblGrupo.Text = (CInt(gvQuintoSem.Rows(gvQuintoSem.Rows.Count - 1).Cells(1).Text) + 1).ToString
                Else
                    lblGrupo.Text = "501"
                End If
            Case 6
                lblSemestre.Text = "SEXTO"
                If gvSextoSem.Rows.Count > 0 Then
                    lblGrupo.Text = (CInt(gvSextoSem.Rows(gvSextoSem.Rows.Count - 1).Cells(1).Text) + 1).ToString
                Else
                    lblGrupo.Text = "601"
                End If
        End Select

        chkbxPermiteHrsDef.Checked = False
        chkbxPermiteHrsProv.Checked = True
        chkbxPermiteHrsInt.Checked = False

        chkbxGrupoUNA.Enabled = CBool(dt.Rows(0).Item("ParticipaEnProgramaUNA"))
        chkbxBachGral.Checked = vlEsBachGral
        chkbxBachGralArtes.Enabled = CBool(dt.Rows(0).Item("BachEnArte"))
        chkbxEMSAD.Checked = vlEsEMSAD

        chkbxReqGpoDisc.Checked = CInt(lbAddGrupo.CommandArgument) >= 5

        dtGposDisc = oGrupos.ObtenGruposDisciplinarios(chkbxBachGral.Checked, chkbxEMSAD.Checked, chkbxBachGralArtes.Checked)
        LlenaDDL(ddlGposDisc, "GrupoDisciplinario", "IdGrupoDisciplinario", dtGposDisc, Nothing)

        ddlGposDisc.Visible = CInt(lbAddGrupo.CommandArgument) >= 5
        lblGposDiscNoDisp.Visible = CInt(lbAddGrupo.CommandArgument) <= 4

        chkbxReqParaEscolar.Checked = IIf(chkbxBachGralArtes.Checked, False, True)

        dtActsParaEsc = oMateria.ObtenActividadesParaEscolares(CByte(Left(lblGrupo.Text, 1)), True)

        LlenaDDL(ddlActsParaEsc, "Materia", "IdMateria", dtActsParaEsc, Nothing)

        ddlActsParaEsc.Visible = IIf(chkbxBachGralArtes.Checked, False, True)
        lblActsParaEscNoDisp.Visible = IIf(chkbxBachGralArtes.Checked, True, False)

        chkbxReqCapTrab.Checked = CInt(lbAddGrupo.CommandArgument) >= 3

        dtCapac = oGrupos.ObtenCapacitaciones(CShort(ddlSemestres.SelectedValue), chkbxBachGral.Checked, chkbxEMSAD.Checked, chkbxBachGralArtes.Checked)

        LlenaDDL(ddlCapTrab, "Capacitacion", "IdCapacitacion", dtCapac, Nothing)

        ddlCapTrab.Visible = CInt(lbAddGrupo.CommandArgument) >= 3
        lblCapTrabNoDisp.Visible = CInt(lbAddGrupo.CommandArgument) <= 2

        myDataView = oQna.ObtenOrdinariasPorSemestre(CShort(Me.ddlSemestres.SelectedValue)).DefaultView
        myDataView.Sort = "Quincena Asc"

        LlenaDDL(ddlQnaIniNueCreac, "Quincena", "IdQuincena", myDataView, Nothing)
        LlenaDDL(ddlQnaFinNueCreac, "Quincena", "IdQuincena", myDataView, Nothing)
        ddlQnaFinNueCreac.Items.Add(New ListItem("999999", "32767"))
    End Sub

    Protected Sub chkbxBachGralArtes_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxBachGralArtes.CheckedChanged
        Dim dt As DataTable
        Dim oPlantel As New Plantel
        Dim vlEsBachGral As Boolean
        Dim vlEsEMSAD As Boolean

        dt = oPlantel.ObtenInfParaCrearGrupo(ddlPlanteles.SelectedValue, CShort(ddlSemestres.SelectedValue), 0)

        vlEsBachGral = dt.Rows(0).Item("EsBachGral")
        vlEsEMSAD = dt.Rows(0).Item("EsEMSAD")

        ddlActsParaEsc.Visible = chkbxBachGralArtes.Checked = False
        lblActsParaEscNoDisp.Visible = chkbxBachGralArtes.Checked = True
        If vlEsBachGral Then
            chkbxBachGral.Checked = chkbxBachGralArtes.Checked = False
        End If

        If vlEsEMSAD Then
            chkbxEMSAD.Checked = chkbxBachGralArtes.Checked = False
        End If

    End Sub

    Protected Sub chkbxGpoNuevaCreac_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxGpoNuevaCreac.CheckedChanged
        ddlQnaIniNueCreac.Visible = chkbxGpoNuevaCreac.Checked
        ddlQnaFinNueCreac.Visible = chkbxGpoNuevaCreac.Checked
        lblQnaIniNueCreacNoDisp.Visible = Not chkbxGpoNuevaCreac.Checked
        lblQnaFinNueCreacNoDisp.Visible = Not chkbxGpoNuevaCreac.Checked
        CVPeriodoNuevaCreac.Enabled = chkbxGpoNuevaCreac.Checked
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim oGrupo As New Grupo

        oGrupo.CreaNuevo(lblClavePlantel.Text, lblGrupo.Text, CShort(ddlSemestres.SelectedValue), chkbxPermiteHrsDef.Checked, chkbxPermiteHrsProv.Checked, _
                        chkbxPermiteHrsInt.Checked, chkbxGrupoUNA.Checked, chkbxBachGral.Checked, chkbxEMSAD.Checked, _
                        chkbxBachGralArtes.Checked, chkbxReqGpoDisc.Checked, CByte(ddlGposDisc.SelectedValue), chkbxReqParaEscolar.Checked, _
                        CShort(ddlActsParaEsc.SelectedValue), chkbxReqCapTrab.Checked, CByte(ddlCapTrab.SelectedValue), _
                        chkbxGpoNuevaCreac.Checked, CShort(ddlQnaIniNueCreac.SelectedValue), CShort(ddlQnaFinNueCreac.SelectedValue))
        BindGrupos()
        MultiView1.SetActiveView(viewConsulta)
    End Sub

    Protected Sub ibConsultarModificar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        MultiView1.SetActiveView(viewConsultaModificaGrupo)
        Dim ibConsultarModificar As ImageButton = CType(sender, ImageButton)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim drInfGrupo As DataRow
        Dim vlIdTblgrupo As Integer
        Dim oGrupo As New Grupo
        Dim dtInfPlantel As DataTable
        Dim oPlantel As New Plantel
        Dim vlEsBachGral As Boolean = False
        Dim vlEsEMSAD As Boolean = False
        Dim dtCapac, dtActsParaEsc, dtGposDisc As DataTable
        Dim oMateria As New Materia
        Dim myDataView As New DataView()
        Dim oQna As New Quincenas
        vlIdTblgrupo = CInt(CType(gvr.FindControl("lblIdTblGrupo"), Label).Text)
        drInfGrupo = oGrupo.ObtenPorIdTblGrupo(vlIdTblgrupo)

        dtInfPlantel = oPlantel.ObtenInfParaCrearGrupo(drInfGrupo("ClaveCTSE").ToString, CShort(ddlSemestres.SelectedValue), 0)

        vlEsBachGral = dtInfPlantel.Rows(0).Item("EsBachGral")
        vlEsEMSAD = dtInfPlantel.Rows(0).Item("EsEMSAD")

        Select Case CInt(drInfGrupo("Semestre"))
            Case 1
                lblSemestre0.Text = "PRIMERO"
            Case 2
                lblSemestre0.Text = "SEGUNDO"
            Case 3
                lblSemestre0.Text = "TERCERO"
            Case 4
                lblSemestre0.Text = "CUARTO"
            Case 5
                lblSemestre0.Text = "QUINTO"
            Case 6
                lblSemestre0.Text = "SEXTO"
        End Select
        lblClavePlantel0.Text = drInfGrupo("ClaveCTSE").ToString
        lblPlantel0.Text = drInfGrupo("Plantel").ToString
        lblGrupo0.Text = drInfGrupo("Grupo").ToString
        lblIdTblGrupo0.Text = vlIdTblgrupo.ToString
        chkbxPermiteHrsDef0.Checked = CBool(drInfGrupo("PermiteHrsDef"))
        chkbxPermiteHrsProv0.Checked = CBool(drInfGrupo("PermiteHrsProv"))
        chkbxPermiteHrsInt0.Checked = CBool(drInfGrupo("PermiteHrsInt"))
        chkbxGrupoUNA0.Enabled = CBool(dtInfPlantel.Rows(0).Item("ParticipaEnProgramaUNA"))
        chkbxGrupoUNA0.Checked = CBool(drInfGrupo("GrupoProgramaUNA"))
        chkbxBachGral0.Checked = vlEsBachGral
        chkbxBachGralArtes0.Enabled = CBool(dtInfPlantel.Rows(0).Item("BachEnArte"))
        chkbxBachGralArtes0.Checked = CBool(drInfGrupo("BachGeneralArte"))
        chkbxEMSAD0.Checked = vlEsEMSAD

        chkbxReqGpoDisc0.Checked = CInt(Left(drInfGrupo("Grupo").ToString, 1)) >= 5

        dtGposDisc = oGrupo.ObtenGruposDisciplinarios(chkbxBachGral0.Checked, chkbxEMSAD0.Checked, chkbxBachGralArtes0.Checked)

        LlenaDDL(ddlGposDisc0, "GrupoDisciplinario", "IdGrupoDisciplinario", dtGposDisc, drInfGrupo("IdGrupoDisciplinario").ToString)

        ddlGposDisc0.Visible = CInt(Left(drInfGrupo("Grupo").ToString, 1)) >= 5
        lblGposDiscNoDisp0.Visible = CInt(Left(drInfGrupo("Grupo").ToString, 1)) <= 4

        chkbxReqParaEscolar0.Checked = IIf(chkbxBachGralArtes0.Checked, False, True)

        dtActsParaEsc = oMateria.ObtenActividadesParaEscolares(CByte(Left(lblGrupo0.Text, 1)), False, chkbxGrupoUNA0.Checked)

        LlenaDDL(ddlActsParaEsc0, "Materia", "IdMateria", dtActsParaEsc, drInfGrupo("IdMateriaParaEscolar").ToString)

        ddlActsParaEsc0.Visible = IIf(chkbxBachGralArtes0.Checked, False, True)
        lblActsParaEscNoDisp0.Visible = IIf(chkbxBachGralArtes0.Checked, True, False)

        chkbxReqCapTrab0.Checked = CInt(Left(drInfGrupo("Grupo").ToString, 1)) >= 3

        dtCapac = oGrupo.ObtenCapacitaciones(CShort(ddlSemestres.SelectedValue), chkbxBachGral0.Checked, chkbxEMSAD0.Checked, chkbxBachGralArtes0.Checked)

        LlenaDDL(ddlCapTrab0, "Capacitacion", "IdCapacitacion", dtCapac, drInfGrupo("IdCapacitacion").ToString)

        ddlCapTrab0.Visible = CInt(Left(drInfGrupo("Grupo").ToString, 1)) >= 3
        lblCapTrabNoDisp0.Visible = CInt(Left(drInfGrupo("Grupo").ToString, 1)) <= 2

        chkbxGpoNuevaCreac0.Checked = CBool(drInfGrupo("GrupoNuevaCreacion"))

        myDataView = oQna.ObtenOrdinariasPorSemestre(CShort(Me.ddlSemestres.SelectedValue)).DefaultView
        myDataView.Sort = "Quincena Asc"

        If drInfGrupo("IdQnaIniNuevaCreacion").ToString <> "32767" Then
            LlenaDDL(ddlQnaIniNueCreac0, "Quincena", "IdQuincena", myDataView, drInfGrupo("IdQnaIniNuevaCreacion").ToString)
        Else
            LlenaDDL(ddlQnaIniNueCreac0, "Quincena", "IdQuincena", myDataView, Nothing)
        End If
        LlenaDDL(ddlQnaFinNueCreac0, "Quincena", "IdQuincena", myDataView, Nothing)
        ddlQnaFinNueCreac0.Items.Add(New ListItem("999999", "32767"))
        ddlQnaFinNueCreac0.SelectedValue = drInfGrupo("IdQnaFinNuevaCreacion").ToString
        ddlQnaIniNueCreac0.Visible = chkbxGpoNuevaCreac0.Checked
        ddlQnaFinNueCreac0.Visible = chkbxGpoNuevaCreac0.Checked
        lblQnaIniNueCreacNoDisp0.Visible = Not ddlQnaIniNueCreac0.Visible
        lblQnaFinNueCreacNoDisp0.Visible = Not ddlQnaFinNueCreac0.Visible
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar0.Click
        MultiView1.SetActiveView(viewConsulta)
    End Sub

    Protected Sub btnCancelar_Click1(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        MultiView1.SetActiveView(viewConsulta)
    End Sub

    Protected Sub chkbxGpoNuevaCreac0_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxGpoNuevaCreac0.CheckedChanged
        ddlQnaIniNueCreac0.Visible = chkbxGpoNuevaCreac0.Checked
        ddlQnaFinNueCreac0.Visible = chkbxGpoNuevaCreac0.Checked
        lblQnaIniNueCreacNoDisp0.Visible = Not chkbxGpoNuevaCreac0.Checked
        lblQnaFinNueCreacNoDisp0.Visible = Not chkbxGpoNuevaCreac0.Checked
        CVPeriodoNuevaCreac0.Enabled = chkbxGpoNuevaCreac0.Checked
    End Sub

    Protected Sub chkbxBachGralArtes0_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxBachGralArtes0.CheckedChanged
        Dim dt As DataTable
        Dim oPlantel As New Plantel
        Dim vlEsBachGral As Boolean
        Dim vlEsEMSAD As Boolean
        Dim dtCapac As DataTable
        Dim oGrupo As New Grupo

        dt = oPlantel.ObtenInfParaCrearGrupo(ddlPlanteles.SelectedValue, CShort(ddlSemestres.SelectedValue), 0)

        vlEsBachGral = dt.Rows(0).Item("EsBachGral")
        vlEsEMSAD = dt.Rows(0).Item("EsEMSAD")

        ddlActsParaEsc0.Visible = chkbxBachGralArtes0.Checked = False
        lblActsParaEscNoDisp0.Visible = chkbxBachGralArtes0.Checked = True
        If vlEsBachGral Then
            chkbxBachGral0.Checked = chkbxBachGralArtes0.Checked = False
        End If

        If vlEsEMSAD Then
            chkbxEMSAD0.Checked = chkbxBachGralArtes0.Checked = False
        End If

        dtCapac = oGrupo.ObtenCapacitaciones(CShort(ddlSemestres.SelectedValue), chkbxBachGral0.Checked, chkbxEMSAD0.Checked, chkbxBachGralArtes0.Checked)

        LlenaDDL(ddlCapTrab0, "Capacitacion", "IdCapacitacion", dtCapac, Nothing)

        ddlCapTrab0.Visible = CInt(Left(lblGrupo0.Text, 1)) >= 3
        lblCapTrabNoDisp0.Visible = CInt(Left(lblGrupo0.Text, 1)) <= 2

    End Sub

    Protected Sub btnGuardar0_Click(sender As Object, e As System.EventArgs) Handles btnGuardar0.Click
        Dim oGrupo As New Grupo

        oGrupo.ActualizarDatos(lblClavePlantel0.Text, lblGrupo0.Text, CShort(ddlSemestres.SelectedValue), chkbxPermiteHrsDef0.Checked, chkbxPermiteHrsProv0.Checked, _
                        chkbxPermiteHrsInt0.Checked, chkbxGrupoUNA0.Checked, chkbxBachGral0.Checked, chkbxEMSAD0.Checked, _
                        chkbxBachGralArtes0.Checked, chkbxReqGpoDisc0.Checked, CByte(ddlGposDisc0.SelectedValue), chkbxReqParaEscolar0.Checked, _
                        CShort(ddlActsParaEsc0.SelectedValue), chkbxReqCapTrab0.Checked, CByte(ddlCapTrab0.SelectedValue), _
                        chkbxGpoNuevaCreac0.Checked, CShort(ddlQnaIniNueCreac0.SelectedValue), CShort(ddlQnaFinNueCreac0.SelectedValue),
                        CInt(lblIdTblGrupo0.Text))
        BindGrupos()
        MultiView1.SetActiveView(viewConsulta)
    End Sub
End Class
