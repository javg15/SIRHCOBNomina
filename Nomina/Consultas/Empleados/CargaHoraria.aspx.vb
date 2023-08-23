Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports System.Data
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Administracion
Partial Class Consultas_Empleados_CargaHoraria
    Inherits System.Web.UI.Page
    Private Sub BindSemestres()
        Dim oSem As New Semestre
        Me.ddlSemestres.DataSource = oSem.ObtenSemestres
        Me.ddlSemestres.DataTextField = "Semestre"
        Me.ddlSemestres.DataValueField = "IdSemestre"
        Me.ddlSemestres.DataBind()
        If Me.ddlSemestres.Items.Count = 0 Then
            Me.ddlSemestres.Items.Insert(0, "No existe información de semestres")
            Me.ddlSemestres.Items(0).Value = -1
        Else
            If Request.Params("IdSemestre") Is Nothing = False Then
                ddlSemestres.SelectedValue = Request.Params("IdSemestre")
            End If
        End If
        Me.btnConsultarCargaHoraria.Enabled = Me.ddlSemestres.Items.Count > 0
    End Sub
    Private Sub BindQuincenas()
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
    End Sub
    Private Sub BindDatos()
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)

        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
            lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            lblEmpInf.Visible = True
            Me.pnlSemestres.Visible = True
            pnl1.Visible = True
            pnl2.Visible = True
            pnl3.Visible = True
            PnlPlazas.Visible = True
        Else
            lblEmpInf.Text = String.Empty
            lblEmpInf.Visible = False
            Me.pnlSemestres.Visible = False
            pnl1.Visible = False
            pnl2.Visible = False
            pnl3.Visible = False
            PnlPlazas.Visible = False
        End If
        BindSemestres()
        BindQuincenas()
    End Sub
    Private Sub BindCargaHoraria()
        Dim oEmpleado As New Hora
        Dim dtObservCargaHoraria As DataTable
        Dim ds As DataSet
        Dim oEmp As New Empleado
        Dim oSemestre As New Semestre
        Dim EsSemestreActual As Boolean = oSemestre.EsActual(CShort(Me.ddlSemestres.SelectedValue))
        Dim EsSemestreParaCargaDePlantillas As Boolean = oSemestre.EsParaCapturaDePlantillas(CShort(Me.ddlSemestres.SelectedValue))
        Dim ExisteSemestreParaCargaDePlantillas As Boolean = oSemestre.ExisteParaCapturaDePlantillas()
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        oSemestre.IdSemestre = CType(Me.ddlSemestres.SelectedValue, Short)
        Dim AdmiteModificaciones As Boolean = oSemestre.AdmiteModificaciones()
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If oEmp.RFC <> String.Empty Then

            ibWarning.Enabled = True
            ddlSemestres.Enabled = True
            btnConsultarCargaHoraria.Enabled = True
            chkbxCargaHorariaConHistoria.Enabled = True
            gvCargaHoraria.Visible = True
            lbNuevaCargaHoraria.Enabled = True
            gvCargaHorariaInterina.Visible = True
            gvCargaHorariaAnexa.Visible = True


            If Me.chkbxCargaHorariaConHistoria.Checked Then
                ds = oEmp.ObtenCargaHoraria(oEmp.RFC, CShort(Me.ddlSemestres.SelectedValue), 0, Me.chkbxCargaHorariaConHistoria.Checked)
            Else
                ds = oEmp.ObtenCargaHoraria(oEmp.RFC, CShort(Me.ddlSemestres.SelectedValue), CShort(ddlQuincenas.SelectedValue), Me.chkbxCargaHorariaConHistoria.Checked)
            End If

            With Me.gvCargaHoraria
                .DataSource = ds.Tables(0)
                .DataBind()
                .SelectedIndex = -1
                .Columns(14).Visible = AdmiteModificaciones '(AdmiteModificaciones And Not oEmp.TienePagosEnSemestreActual()) Or (AdmiteModificaciones And EsSemestreParaCargaDePlantillas)
                .Columns(15).Visible = AdmiteModificaciones
                .Columns(16).Visible = AdmiteModificaciones
                .Columns(17).Visible = AdmiteModificaciones
            End With

            dtObservCargaHoraria = oEmpleado.ObtenObservacionesSobreCargaHoraria(oEmp.RFC, CShort(Me.ddlSemestres.SelectedValue))
            ibWarning.OnClientClick = "javascript:abreVentMedAncha('../CargaHoraria/ObservacionesSobreCargaHoraria.aspx?TipoOperacion=4&RFCEmp=" + oEmp.RFC + "&IdSemestre=" + Me.ddlSemestres.SelectedValue + "'); return false;"
            Me.ibWarning.Visible = dtObservCargaHoraria.Rows.Count > 0

            With Me.gvResumen1
                .DataSource = ds.Tables(2)
                .DataBind()
            End With

            'chkbxCargaHorariaConHistoria.Enabled = EsSemestreActual
            chkbxCargaHorariaConHistoria.Enabled = True

            If EsSemestreParaCargaDePlantillas Then
                Me.gvCargaHorariaInterina.Visible = True
                BindCargaHorariaInterina()
            Else
                Me.gvCargaHorariaInterina.Visible = False
            End If

            Dim vlEmpEsDoc As Boolean = oEmp.EsDocenteEnSemestre(oEmp.RFC, CShort(Me.ddlSemestres.SelectedValue))

            gvCargaHorariaInterina.Columns(14).Visible = True
            If Not vlEmpEsDoc Then
                'gvCargaHoraria.DataSource = Nothing
                'gvCargaHoraria.DataBind()
                With gvCargaHoraria
                    .Columns(14).Visible = vlEmpEsDoc
                    .Columns(15).Visible = vlEmpEsDoc
                    .Columns(16).Visible = vlEmpEsDoc
                    .Columns(17).Visible = vlEmpEsDoc
                End With
                'gvResumen1.DataSource = Nothing
                'gvResumen1.DataBind()

                'gvCargaHorariaInterina.DataSource = Nothing
                'gvCargaHorariaInterina.DataBind()
                With gvCargaHorariaInterina
                    .Columns(14).Visible = vlEmpEsDoc
                End With
            End If

            BindgvPlazasEnSemestre(oEmp.RFC, CShort(ddlSemestres.SelectedValue))
            BindCargaHorariaAnexa(ds)
        End If
    End Sub

    Private Sub BindgvPlazasEnSemestre(pRFC As String, pIdSemestre As Short)
        Dim oEmp As New Empleado
        gvPlazasVigentes.DataSource = oEmp.ObtenPlazaEnSemestre(pRFC, pIdSemestre)
        gvPlazasVigentes.DataBind()
    End Sub

    Private Sub BindCargaHorariaAnexa(Optional ByVal ds As DataSet = Nothing)
        Dim oEmp As New Empleado
        Dim oSemestre As New Semestre
        oSemestre.IdSemestre = CType(Me.ddlSemestres.SelectedValue, Short)
        Dim AdmiteModificaciones As Boolean = oSemestre.AdmiteModificaciones()
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If oEmp.RFC <> String.Empty Then
            If ds Is Nothing Then ds = oEmp.ObtenCargaHoraria(CType(Me.ddlSemestres.SelectedValue, Short), Me.chkbxCargaHorariaConHistoria.Checked)
            With Me.gvCargaHorariaAnexa
                .DataSource = ds.Tables(1)
                .DataBind()
                .SelectedIndex = -1
                .Columns(15).Visible = AdmiteModificaciones
                .Columns(16).Visible = AdmiteModificaciones
            End With
            With Me.gvResumen2
                .DataSource = ds.Tables(3)
                .DataBind()
            End With

            Dim vlEmpEsDoc As Boolean = oEmp.EsDocenteEnSemestre(oEmp.RFC, CShort(Me.ddlSemestres.SelectedValue))
            If Not vlEmpEsDoc Then
                'gvCargaHorariaAnexa.DataSource = Nothing
                'gvCargaHoraria.DataBind()
                With gvCargaHorariaAnexa
                    .Columns(15).Visible = vlEmpEsDoc
                    .Columns(16).Visible = vlEmpEsDoc
                End With
                'gvResumen2.DataSource = Nothing
                'gvResumen1.DataBind()
            End If

        End If
    End Sub
    Private Sub BindCargaHorariaInterina()
        Dim dtCargaHorariaInterina As DataTable
        Dim oEmp As New Empleado
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If oEmp.RFC <> String.Empty Then
            dtCargaHorariaInterina = oEmp.ObtenCargaHorariaInterina(IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons")))
            With Me.gvCargaHorariaInterina
                .DataSource = dtCargaHorariaInterina
                .DataBind()
                .SelectedIndex = -1
            End With
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            'Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            'Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
        End If
    End Sub
    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
        If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
    End Sub

    Protected Sub btnConsultarCargaHoraria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarCargaHoraria.Click
        BindCargaHoraria()
    End Sub

    Protected Sub gvCargaHoraria_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Select Case e.CommandName
            Case "Eliminar", "Copiar", "Modificar", "Reemplazar"
                If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
        End Select
    End Sub

    Protected Sub gvCargaHoraria_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCargaHoraria.RowDataBound
        Dim oUsuario As New Usuario
        Dim drUsuario As DataRow

        oUsuario.Login = Session("Login")
        drUsuario = oUsuario.ObtenerPorLogin()

        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdHora As Label = CType(e.Row.FindControl("lblIdHora"), Label)
                Dim lblNombramiento As Label = CType(e.Row.FindControl("lblNombramiento"), Label)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibHorarios As ImageButton = CType(e.Row.FindControl("ibHorarios"), ImageButton)
                Dim ibAddHoras As ImageButton = CType(e.Row.FindControl("ibAddHoras"), ImageButton)
                Dim ibRemplazar As ImageButton = CType(e.Row.FindControl("ibRemplazar"), ImageButton)
                Dim lblTipoNomina As Label = CType(e.Row.FindControl("lblTipoNomina"), Label)
                Dim oHora As New Hora
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim vlNomTitular As String
                Dim drInfTitular As DataRow
                Dim lbCvePlantel As LinkButton = CType(e.Row.FindControl("lbCvePlantel"), LinkButton)
                Dim lblIdGrupo As Label = CType(e.Row.FindControl("lblIdGrupo"), Label)
                Dim lblIdPlantel As Label = CType(e.Row.FindControl("lblIdPlantel"), Label)
                Dim lblGrupo As Label = CType(e.Row.FindControl("lblGrupo"), Label)
                Dim lbGrupo As LinkButton = CType(e.Row.FindControl("lbGrupo"), LinkButton)
                Dim lblIdMateria As Label = CType(e.Row.FindControl("lblIdMateria"), Label)
                Dim lbNombreMateria As LinkButton = CType(e.Row.FindControl("lbNombreMateria"), LinkButton)
                Dim lbTipoHora As LinkButton = CType(e.Row.FindControl("lbTipoHora"), LinkButton)
                Dim lbEstatusHora As LinkButton = CType(e.Row.FindControl("lbEstatusHora"), LinkButton)
                Dim lbNombramiento As LinkButton = CType(e.Row.FindControl("lbNombramiento"), LinkButton)
                Dim lbTipoNomina As LinkButton = CType(e.Row.FindControl("lbTipoNomina"), LinkButton)

                ibHorarios.Visible = False
                If oUsuario.EsAnalista(oUsuario.Login) Or oUsuario.EsAdministrador(oUsuario.Login) _
                        Or oUsuario.EsSuperAdmin(oUsuario.Login) Then
                    ibHorarios.Visible = True
                End If


                'lbCvePlantel.OnClientClick = "javascript:abreVentMedAncha('../Planteles/PlantelesMaterias.aspx?IdHora=" + lblIdHora.Text + "'); return false;"
                lbCvePlantel.OnClientClick = "javascript:abreVentanaImpresion('../Planteles/PlantelesMaterias.aspx?IdHora=" + lblIdHora.Text + "&IdSemestre=" + ddlSemestres.SelectedValue + "','VentanaPlantel_" + lbCvePlantel.Text + "'); return false;"

                lbGrupo.Visible = lbGrupo.Text <> "0"
                lblGrupo.Visible = lbGrupo.Text = "0"

                lbGrupo.OnClientClick = "javascript:abreVentanaImpresion('../Planteles/PlantelGrupo.aspx?IdPlantel=" + lblIdPlantel.Text + "&IdGrupo=" + lblIdGrupo.Text + "&IdSemestre=" + ddlSemestres.SelectedValue + "','VentanaPlantel_" + lblIdPlantel.Text + "_Grupo'); return false;"
                lbNombreMateria.OnClientClick = "javascript:abreVentanaImpresion('../Planteles/MateriaEnPlantel.aspx?IdPlantel=" + lblIdPlantel.Text + "&IdMateria=" + lblIdMateria.Text + "&IdSemestre=" + ddlSemestres.SelectedValue + "','VentanaPlantel_" + lblIdPlantel.Text + "_Materia'); return false;"
                lbTipoHora.OnClientClick = "javascript:abreVentanaImpresion('../Planteles/TipoDeHoraEnPlantel.aspx?IdPlantel=" + lblIdPlantel.Text + "&TipoHora=" + lbTipoHora.Text + "&IdSemestre=" + ddlSemestres.SelectedValue + "','VentanaPlantel_" + lblIdPlantel.Text + "_TipoHora'); return false;"
                lbEstatusHora.OnClientClick = "javascript:abreVentanaImpresion('../Planteles/EstatusHoraEnPlantel.aspx?IdPlantel=" + lblIdPlantel.Text + "&AbrevEstatus=" + lbEstatusHora.Text + "&IdSemestre=" + ddlSemestres.SelectedValue + "','VentanaPlantel_" + lblIdPlantel.Text + "_EstatusHora'); return false;"
                lbNombramiento.OnClientClick = "javascript:abreVentanaImpresion('../Planteles/PlantelNombEmps.aspx?IdPlantel=" + lblIdPlantel.Text + "&AbrevNombramiento=" + lbNombramiento.Text + "&IdSemestre=" + ddlSemestres.SelectedValue + "','VentanaPlantel_" + lblIdPlantel.Text + "_Nombramiento'); return false;"
                lbTipoNomina.OnClientClick = "javascript:abreVentanaImpresion('../Planteles/PlantelHrsTipoNominaEmps.aspx?IdPlantel=" + lblIdPlantel.Text + "&AbrevTipoNomina=" + lbTipoNomina.Text + "&IdSemestre=" + ddlSemestres.SelectedValue + "','VentanaPlantel_" + lblIdPlantel.Text + "_TipoNomina'); return false;"

                imgInfTitular.Visible = False
                If lblNombramiento.Text = "I" Then
                    imgInfTitular.Visible = True
                    drInfTitular = oHora.ObtenTitular(CInt(lblIdHora.Text))
                    vlNomTitular = (drInfTitular("ApePatEmp") + " " + drInfTitular("ApeMatEmp") + " " + drInfTitular("NomEmp")).ToString.Trim
                    If vlNomTitular = String.Empty Then
                        vlNomTitular = "Información del titular no capturada."
                    End If
                    imgInfTitular.ToolTip = vlNomTitular
                End If

                'Si las horas son DIES O CISCO
                If lblTipoNomina.Text = "D" Or lblTipoNomina.Text = "C" Then
                    ibRemplazar.Enabled = True
                    ibRemplazar.ImageUrl = "~/Imagenes/Replace.png"
                    ibRemplazar.ToolTip = "Reemplazar horas interinamente."
                End If

                'If lblNombramiento.Text <> "D" And lblNombramiento.Text <> "P" Then
                '    ibRemplazar.Enabled = False
                '    ibRemplazar.ImageUrl = "~/Imagenes/ReplaceDisabled.png"
                '    ibRemplazar.ToolTip = "Reemplazar horas interinamente (Opción deshabilitada)."
                'End If

                ibEliminar.CommandArgument = lblIdHora.Text
                ibEliminar.Enabled = oHora.SePuedeEliminar(CInt(lblIdHora.Text))
                ibEliminar.ImageUrl = "~/Imagenes/Eliminar.png"
                If ibEliminar.Enabled = False Then
                    ibEliminar.ImageUrl = "~/Imagenes/EliminarDisabled.jpg"
                    ibEliminar.ToolTip = "No se permite eliminar el registro."
                End If

                If oHora.SePuedeModificar(CInt(lblIdHora.Text), CShort(ddlSemestres.SelectedValue)) = False Then
                    ibModificar.ToolTip = "Solo se permitirá modificar la vigencia final."
                    ibModificar.Enabled = oHora.EstaVigente(CInt(lblIdHora.Text))
                    ibModificar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    If ibModificar.Enabled = False Then
                        ibModificar.ToolTip = "No se permite modificar el registro."
                        ibRemplazar.Enabled = False
                        ibRemplazar.ImageUrl = "~/Imagenes/ReplaceDisabled.png"
                        ibRemplazar.ToolTip = "Reemplazar horas interinamente (Opción deshabilitada)."
                    End If

                End If

                ibHorarios.PostBackUrl = "../../ABC/Empleados/AdministracionHorarios.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=4" + "&ValidacionAlCargarPagina=NO&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&IdQuincena=" + ddlQuincenas.SelectedValue
                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=4" + "&ValidacionAlCargarPagina=NO&IdSemestre=" + Me.ddlSemestres.SelectedValue + "');"
                ibDetalles.PostBackUrl = "../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=4" + "&ValidacionAlCargarPagina=NO&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&IdQuincena=" + ddlQuincenas.SelectedValue
                'ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=0" + "&ValidacionAlCargarPagina=SI&IdSemestre=" + Me.ddlSemestres.SelectedValue + "');"
                ibModificar.PostBackUrl = "../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=0" + "&ValidacionAlCargarPagina=SI&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&IdQuincena=" + ddlQuincenas.SelectedValue
                'ibAddHoras.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=1" + "&ValidacionAlCargarPagina=SI&IdSemestre=" + Me.ddlSemestres.SelectedValue + "');"
                ibAddHoras.PostBackUrl = "../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=1" + "&ValidacionAlCargarPagina=SI&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&IdQuincena=" + ddlQuincenas.SelectedValue
                'ibRemplazar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=1" + "&AsociarInterinas=1&ValidacionAlCargarPagina=SI&IdSemestre=" + Me.ddlSemestres.SelectedValue + "');"
                ibRemplazar.PostBackUrl = "../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=1" + "&AsociarInterinas=1&ValidacionAlCargarPagina=SI&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&IdQuincena=" + ddlQuincenas.SelectedValue
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvCargaHoraria, "Select$" + e.Row.RowIndex.ToString)

                ''''''HORARIOS
                Dim lblHorasHorario As Label = CType(e.Row.FindControl("lblHorasHorario"), Label)
                Dim lblHoras As Label = CType(e.Row.FindControl("lblHoras"), Label)

                Dim Horas As Integer = 0
                Dim HorasHorario As Integer = 0

                If lblHorasHorario.Text <> "" Then HorasHorario = CInt(lblHorasHorario.Text)
                If lblHoras.Text <> "" Then Horas = CInt(lblHoras.Text)

                If Horas <> HorasHorario Then
                    lblHorasHorario.ForeColor = System.Drawing.Color.OrangeRed
                Else
                    lblHorasHorario.ForeColor = System.Drawing.Color.Black
                End If

            Case DataControlRowType.EmptyDataRow
                Dim lbNuevaCargaHoraria As LinkButton = CType(e.Row.FindControl("lbNuevaCargaHoraria"), LinkButton)
                Dim lblMsjgvVacio As Label = CType(e.Row.FindControl("lblMsjgvVacio"), Label)
                Dim oEmp As New Empleado
                Dim oSemestre As New Semestre
                oSemestre.IdSemestre = CType(Me.ddlSemestres.SelectedValue, Short)
                Dim AdmiteModificaciones As Boolean = oSemestre.AdmiteModificaciones()

                oEmp.RFC = hfRFC.Value
                lbNuevaCargaHoraria.Visible = (Me.ddlSemestres.SelectedIndex = 0 Or AdmiteModificaciones = True)
                'lbNuevaCargaHoraria.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&TipoOperacion=1&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&ValidacionAlCargarPagina=SI');"
                lbNuevaCargaHoraria.PostBackUrl = "../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&TipoOperacion=1&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&ValidacionAlCargarPagina=SI&IdQuincena=" + ddlQuincenas.SelectedValue

                If Not oEmp.EsDocenteEnSemestre(oEmp.RFC, CShort(Me.ddlSemestres.SelectedValue)) Then
                    lblMsjgvVacio.Text = "El empleado no es docente en la quincena actual."
                    lblMsjgvVacio.Visible = True
                    lbNuevaCargaHoraria.Visible = False
                    ibWarning.Visible = False
                Else
                    lblMsjgvVacio.Visible = False
                    lbNuevaCargaHoraria.Visible = (Me.ddlSemestres.SelectedIndex = 0 Or AdmiteModificaciones = True)
                End If

        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
            If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
        End If
    End Sub

    Protected Sub ddlSemestres_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemestres.SelectedIndexChanged
        Dim oSemestre As New Semestre
        Dim EsSemestreActual As Boolean = oSemestre.EsActual(CShort(Me.ddlSemestres.SelectedValue))

        BindQuincenas()

        chkbxCargaHorariaConHistoria.Enabled = EsSemestreActual

        'If Not EsSemestreActual Then chkbxCargaHorariaConHistoria.Checked = False
        chkbxCargaHorariaConHistoria.Enabled = True

        If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
    End Sub

    Protected Sub gvCargaHorariaAnexa_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCargaHorariaAnexa.RowDataBound


        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdHora As Label = CType(e.Row.FindControl("lblIdHora"), Label)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)


                ibEliminar.CommandArgument = lblIdHora.Text
                'ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=0" + "&AsociarInterinas=1&IdSemestre=" + Me.ddlSemestres.SelectedValue + "'); return false;"
                ibModificar.PostBackUrl = "../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=0" + "&AsociarInterinas=1&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&IdQuincena=" + ddlQuincenas.SelectedValue
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvCargaHorariaAnexa, "Select$" + e.Row.RowIndex.ToString)


        End Select
    End Sub
    Protected Sub ibEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oHora As New Hora
        oHora.IdHora = CInt(sender.CommandArgument)
        oHora.EliminaPorId(CType(Session("ArregloAuditoria"), String()))
        If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
    End Sub

    Protected Sub ibEliminar_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oHora As New Hora
        oHora.IdHora = CInt(sender.CommandArgument)
        oHora.EliminaPorId(CType(Session("ArregloAuditoria"), String()), True)
        If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHorariaAnexa()
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oMetodoComun As New MetodosComunes
        Dim c As Control = oMetodoComun.GetPostBackControl(Page)

        If c Is Nothing Then Exit Sub
        If c.ID = "BtnSearch" Then
            If hfRFC.Value <> String.Empty Then
                BindDatos()
                If Me.ddlSemestres.SelectedValue <> -1 Then
                    BindCargaHoraria()
                End If
                pnl1.Visible = True
                pnl2.Visible = True
                pnl3.Visible = True
                PnlPlazas.Visible = True
            End If
        ElseIf c.ID = "BtnNewSearch" Then
            pnl1.Visible = False
            pnl2.Visible = False
            pnl3.Visible = False
            PnlPlazas.Visible = False
        ElseIf c.ID = "BtnCancelSearch" Then
            pnl1.Visible = False
            pnl2.Visible = False
            pnl3.Visible = False
            PnlPlazas.Visible = False
        ElseIf c.ID = "lnkbtnrfc" Then
            BindDatos()
            If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
            pnl1.Visible = True
            pnl2.Visible = True
            pnl3.Visible = True
            PnlPlazas.Visible = True
        End If

        'If IsPostBack Then
        '    Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        '    If Request.Params(0).Contains("BtnSearch") Then
        '        If txtbxRFC.Text.Trim <> String.Empty Then
        '            BindDatos()
        '            If Me.ddlSemestres.SelectedValue <> -1 Then
        '                BindCargaHoraria()
        '            End If
        '            pnl1.Visible = True
        '            pnl2.Visible = True
        '            pnl3.Visible = True
        '            PnlPlazas.Visible = True
        '        Else
        '            pnl1.Visible = False
        '            pnl2.Visible = False
        '            pnl3.Visible = False
        '            PnlPlazas.Visible = False
        '        End If
        '    ElseIf Request.Params(0).Contains("BtnNewSearch") Then
        '        pnl1.Visible = False
        '        pnl2.Visible = False
        '        pnl3.Visible = False
        '        PnlPlazas.Visible = False
        '    ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
        '        pnl1.Visible = True
        '        pnl2.Visible = True
        '        pnl3.Visible = True
        '        PnlPlazas.Visible = True
        '    ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
        '        If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
        '            BindDatos()
        '            If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
        '            pnl1.Visible = True
        '            pnl2.Visible = True
        '            pnl3.Visible = True
        '            PnlPlazas.Visible = True
        '        End If
        '    End If
        'End If
    End Sub

    Protected Sub gvCargaHorariaInterina_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCargaHorariaInterina.RowCommand, gvCargaHoraria.RowCommand
        Select Case e.CommandName
            Case "Copiar"
                If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
        End Select
    End Sub

    Protected Sub gvCargaHorariaInterina_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCargaHorariaInterina.RowDataBound
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdHora As Label = CType(e.Row.FindControl("lblIdHora"), Label)
                Dim ibAddHora As ImageButton = CType(e.Row.FindControl("ibAddHora"), ImageButton)
                ibAddHora.CommandArgument = lblIdHora.Text
                'ibAddHora.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=1" + "&ValidacionAlCargarPagina=SI&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&AddInterina=SI');"
                ibAddHora.PostBackUrl = "../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=1" + "&ValidacionAlCargarPagina=SI&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&AddInterina=SI&IdQuincena=" + ddlQuincenas.SelectedValue
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvCargaHorariaInterina, "Select$" + e.Row.RowIndex.ToString)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitularI"), Image)
                Dim vlNomTitular As String
                Dim drInfTitular As DataRow
                Dim lblNombramiento As Label = CType(e.Row.FindControl("lblNombramientoI"), Label)
                Dim oHora As New Hora

                imgInfTitular.Visible = False
                If lblNombramiento.Text = "I" Then
                    imgInfTitular.Visible = True
                    drInfTitular = oHora.ObtenTitular(CInt(lblIdHora.Text))
                    vlNomTitular = (drInfTitular("ApePatEmp") + " " + drInfTitular("ApeMatEmp") + " " + drInfTitular("NomEmp")).ToString.Trim
                    If vlNomTitular = String.Empty Then
                        vlNomTitular = "Información del titular no capturada."
                    End If
                    imgInfTitular.ToolTip = vlNomTitular
                End If
        End Select
    End Sub

    Protected Sub gvPlazasVigentes_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazasVigentes.RowDataBound
        Dim oEmpleadoPlaza As New EmpleadoPlazas
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim lblNombreFuncionPri As Label = CType(e.Row.FindControl("lblNombreFuncionPri"), Label)
                Dim lblNombreFuncionSec As Label = CType(e.Row.FindControl("lblNombreFuncionSec"), Label)
                Dim lblMotGralBaja As Label = CType(e.Row.FindControl("lblMotGralBaja"), Label)
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibHorariosAdmin As ImageButton = CType(e.Row.FindControl("ibHorariosAdmin"), ImageButton)
                'Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                'Dim ibBaja As ImageButton = CType(e.Row.FindControl("ibBaja"), ImageButton)
                Dim ibWarning As ImageButton = CType(e.Row.FindControl("ibWarning"), ImageButton)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim lblOcupacion As Label = CType(e.Row.FindControl("lblOcupacion"), Label)
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

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&IdQuincena=" + ddlQuincenas.SelectedValue

                'If oPlaza.TienePagosRelacionados(CInt(lblIdPlaza.Text)) Then
                '    ibModificar.Enabled = False
                '    ibModificar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                '    ibModificar.ToolTip = "(Opción deshabilitada) La plaza tiene pagos relacionados, no se permiten modificaciones."
                'End If

                'ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=0&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                'ibBaja.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=2&IdPlaza=" + lblIdPlaza.Text + "');"
                ibWarning.OnClientClick = "javascript:abreVentMedAncha('../Plazas/ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                dtWarnings = oPlaza.ObtenObservaciones(CInt(lblIdPlaza.Text))
                ibWarning.Visible = dtWarnings.Rows.Count > 0
                'Case DataControlRowType.EmptyDataRow, DataControlRowType.Footer
                '    Dim lbAsignarPlaza As LinkButton = CType(e.Row.FindControl("lbAsignarPlaza"), LinkButton)
                '    Dim lbAsignarPlazaCopia As LinkButton = CType(e.Row.FindControl("lbAsignarPlazaCopia"), LinkButton)
                '    Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

                '    lbAsignarPlaza.Visible = oEmpleadoPlaza.SeLePudenAgregarMasPlazas(hfRFC.Value)

                '    lbAsignarPlaza.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "');"
                '    lbAsignarPlazaCopia.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=1&RFCEmp=" + hfRFC.Value + "&CopiarUltVig=SI');"

                Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
                hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
                Dim oEmp As New Empleado
                oEmp.RFC = hfRFC.Value
                ibHorariosAdmin.Visible = False
                If lblNombreFuncionPri.Text.ToUpper = "ADMINISTRATIVA" Then
                    ibHorariosAdmin.Visible = True
                    ibHorariosAdmin.PostBackUrl = "../../ABC/Empleados/AdministracionHorariosAdmin.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text
                ElseIf Not oEmp.EsDocenteEnSemestre(oEmp.RFC, CShort(Me.ddlSemestres.SelectedValue)) Then
                    ibHorariosAdmin.Visible = True
                    ibHorariosAdmin.PostBackUrl = "../../ABC/Empleados/AdministracionHorariosAdmin.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdSemestre=" + Me.ddlSemestres.SelectedValue + "&TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text
                End If
        End Select
    End Sub

    Protected Sub gvPlazasVigentes_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPlazasVigentes.RowCommand

    End Sub

    Protected Sub ddlQuincenas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlQuincenas.SelectedIndexChanged
        Dim oSemestre As New Semestre
        Dim EsSemestreActual As Boolean = oSemestre.EsActual(CShort(Me.ddlSemestres.SelectedValue))

        chkbxCargaHorariaConHistoria.Enabled = EsSemestreActual

        'If Not EsSemestreActual Then chkbxCargaHorariaConHistoria.Checked = False
        chkbxCargaHorariaConHistoria.Enabled = True

        If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
    End Sub

    Protected Sub chkbxCargaHorariaConHistoria_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxCargaHorariaConHistoria.CheckedChanged
        ddlQuincenas.Enabled = Not chkbxCargaHorariaConHistoria.Checked

        Dim oSemestre As New Semestre
        Dim EsSemestreActual As Boolean = oSemestre.EsActual(CShort(Me.ddlSemestres.SelectedValue))

        chkbxCargaHorariaConHistoria.Enabled = EsSemestreActual

        'If Not EsSemestreActual Then chkbxCargaHorariaConHistoria.Checked = False
        chkbxCargaHorariaConHistoria.Enabled = True

        If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
    End Sub
End Class
