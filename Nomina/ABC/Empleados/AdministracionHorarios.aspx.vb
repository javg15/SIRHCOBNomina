Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Planteles
Imports DataAccessLayer.COBAEV.Empleados

Partial Class AdministracionHorarios
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Public dr As DataRow



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.Params("IdHora") Is Nothing = False Then
                If Request.Params("TipoOperacion") = "4" Then
                    Dim oPlantel As New Plantel
                    Dim oMateria As New Materia
                    Dim oGrupo As New Grupo
                    Dim oHora As New Hora
                    Dim oPlantelHorario As New PlantelesHorarios
                    Dim oEmpleado As New Empleado
                    Dim oHorariosClase As New HorariosClase

                    oHora.IdHora = CInt(Request.Params("IdHora"))
                    ds = oHora.ObtenPorId()
                    dr = ds.Tables(0).Rows(0)
                    oHora.IdPlantel = dr("IdPlantel")
                    oHora.IdMateria = dr("IdMateria")
                    oHora.IdGrupo = dr("IdGrupo")
                    oHora.Horas = dr("Cantidad")

                    oHorariosClase.IdHora = Request.Params("IdHora")
                    Dim dt As DataTable = oHorariosClase.ObtenPorId(oHorariosClase.IdHora)

                    hidIdHora.Text = Request.Params("IdHora")
                    dr = oPlantel.ObtenPorId(oHora.IdPlantel).Rows(0)

                    lblPlantel.Text = dr("ClavePlantel") + " - " + dr("DescPlantel")

                    dr = oMateria.ObtenPorId(oHora.IdMateria)
                    lblMateria.Text = dr("ClaveMateria") + " - " + dr("NombreMateria")
                    oGrupo.IdGrupo = oHora.IdGrupo
                    lblGrupo.Text = oGrupo.ObtenPorId()("Grupo")
                    oEmpleado.RFC = Request.Params("RFCEmp")
                    Dim drEmp As DataRow = oEmpleado.ObtenDatosPersonales().Rows(0)
                    lblEmpleado.Text = drEmp("NumEmp") +
                        " - " + drEmp("ApePatEmp") +
                        " " + drEmp("ApeMatEmp") +
                        " " + drEmp("NomEmp")

                    Dim Observaciones As String = ""
                    For i = 0 To dt.Rows.Count - 1
                        If Observaciones <> dt.Rows(i).Item("Observaciones") Then
                            lblObservaciones.Text = lblObservaciones.Text + dt.Rows(i).Item("Observaciones") + ";  "
                            Observaciones = dt.Rows(i).Item("Observaciones")
                        End If
                    Next

                    lblTotalHoras.Text = oHora.Horas


                    BindDatos(CInt(Request.Params("IdHora")))
                ElseIf Request.Params("TipoOperacion") = "1" Or Request.Params("TipoOperacion") = "2" Then
                    Actualizar()
                End If
            End If

        End If


    End Sub


    Protected Sub Actualizar()
        Dim IdHora As String = Request.Params("IdHora")
        Dim IdHorariosClase As String = Request.Params("IdHorariosClase")
        Dim HoraInicio As String = Request.Params("HoraInicio")
        Dim HoraFin As String = Request.Params("HoraFin")
        Dim Dia As String = Request.Params("dia")

        Try

            Dim respuesta As String = ""
            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim oHorariosClase As New HorariosClase

            oHorariosClase = New HorariosClase

            If IdHora = "" Then IdHora = "0"
            If IdHorariosClase = "" Then IdHorariosClase = "0"
            If Request.Params("TipoOperacion") = 1 Then
                With oHorariosClase
                    .IdHorariosClase = CInt(IdHorariosClase)
                    .IdHora = CInt(IdHora)
                    .Dia = Dia
                    .HoraInicio = TimeSpan.Parse(HoraInicio)
                    .HoraFin = TimeSpan.Parse(HoraFin)
                End With


                respuesta = oHorariosClase.AgregaNueva(1, CType(Session("ArregloAuditoria"), String()))
            ElseIf Request.Params("TipoOperacion") = 2 Then
                With oHorariosClase
                    .IdHorariosClase = CInt(IdHorariosClase)
                End With
                respuesta = oHorariosClase.Eliminar(CType(Session("ArregloAuditoria"), String()))
            End If


            If respuesta.Split("&")(1) = "" Then
                hidIdHorariosClase.Value = respuesta.Split("&")(0)
            Else
                'Me.lblError.Text = respuesta.Split("&")(1)
            End If
            BindDatos(CInt(Request.Params("IdHora")))
        Catch Ex As Exception
            'Me.lblError.Text = Ex.Message
        End Try
    End Sub

    Public Sub BindDatos(ByVal IdHoras As Integer)
        Dim oHoras As New HorariosClase
        Dim dt As DataTable = oHoras.ObtenHorariosClase("&IdHora=" + IdHoras.ToString)
        hidCantidadHorasHorario.Value = dt.Rows(0).Item("horassuma")
        With Me.gvHoras
            .DataSource = dt
            .DataBind()
        End With

    End Sub

    Protected Sub gvHoras_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvHoras.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                hidHorasRestantes.Text = lblTotalHoras.Text
            Case DataControlRowType.DataRow
                Dim lblDomingo As Label = CType(e.Row.FindControl("lblDomingo"), Label)
                Dim lblSabado As Label = CType(e.Row.FindControl("lblSabado"), Label)
                Dim lblViernes As Label = CType(e.Row.FindControl("lblViernes"), Label)
                Dim lblJueves As Label = CType(e.Row.FindControl("lblJueves"), Label)
                Dim lblMiercoles As Label = CType(e.Row.FindControl("lblMiercoles"), Label)
                Dim lblMartes As Label = CType(e.Row.FindControl("lblMartes"), Label)
                Dim lblLunes As Label = CType(e.Row.FindControl("lblLunes"), Label)
                Dim lblHoraInicio As Label = CType(e.Row.FindControl("lblHoraInicio"), Label)
                Dim lblHoraFin As Label = CType(e.Row.FindControl("lblHoraFin"), Label)

                Dim ibAdd1 As ImageButton = CType(e.Row.FindControl("ibAdd1"), ImageButton)
                Dim ibEliminar1 As ImageButton = CType(e.Row.FindControl("ibEliminar1"), ImageButton)
                Dim imgDocenteTT1 As Image = CType(e.Row.FindControl("imgDocenteTT1"), Image)
                Dim imgGrupoTT1 As Image = CType(e.Row.FindControl("imgGrupoTT1"), Image)

                Dim ibAdd2 As ImageButton = CType(e.Row.FindControl("ibAdd2"), ImageButton)
                Dim ibEliminar2 As ImageButton = CType(e.Row.FindControl("ibEliminar2"), ImageButton)
                Dim imgDocenteTT2 As Image = CType(e.Row.FindControl("imgDocenteTT2"), Image)
                Dim imgGrupoTT2 As Image = CType(e.Row.FindControl("imgGrupoTT2"), Image)

                Dim ibAdd3 As ImageButton = CType(e.Row.FindControl("ibAdd3"), ImageButton)
                Dim ibEliminar3 As ImageButton = CType(e.Row.FindControl("ibEliminar3"), ImageButton)
                Dim imgDocenteTT3 As Image = CType(e.Row.FindControl("imgDocenteTT3"), Image)
                Dim imgGrupoTT3 As Image = CType(e.Row.FindControl("imgGrupoTT3"), Image)

                Dim ibAdd4 As ImageButton = CType(e.Row.FindControl("ibAdd4"), ImageButton)
                Dim ibEliminar4 As ImageButton = CType(e.Row.FindControl("ibEliminar4"), ImageButton)
                Dim imgDocenteTT4 As Image = CType(e.Row.FindControl("imgDocenteTT4"), Image)
                Dim imgGrupoTT4 As Image = CType(e.Row.FindControl("imgGrupoTT4"), Image)

                Dim ibAdd5 As ImageButton = CType(e.Row.FindControl("ibAdd5"), ImageButton)
                Dim ibEliminar5 As ImageButton = CType(e.Row.FindControl("ibEliminar5"), ImageButton)
                Dim imgDocenteTT5 As Image = CType(e.Row.FindControl("imgDocenteTT5"), Image)
                Dim imgGrupoTT5 As Image = CType(e.Row.FindControl("imgGrupoTT5"), Image)

                Dim ibAdd6 As ImageButton = CType(e.Row.FindControl("ibAdd6"), ImageButton)
                Dim ibEliminar6 As ImageButton = CType(e.Row.FindControl("ibEliminar6"), ImageButton)
                Dim imgDocenteTT6 As Image = CType(e.Row.FindControl("imgDocenteTT6"), Image)
                Dim imgGrupoTT6 As Image = CType(e.Row.FindControl("imgGrupoTT6"), Image)

                Dim ibAdd7 As ImageButton = CType(e.Row.FindControl("ibAdd7"), ImageButton)
                Dim ibEliminar7 As ImageButton = CType(e.Row.FindControl("ibEliminar7"), ImageButton)
                Dim imgDocenteTT7 As Image = CType(e.Row.FindControl("imgDocenteTT7"), Image)
                Dim imgGrupoTT7 As Image = CType(e.Row.FindControl("imgGrupoTT7"), Image)

                Dim clickAgregar As String = "javascript:abreVentMediaScreen('../../ABC/Empleados/AdministracionHorarios.aspx?TipoOperacion=1" _
                    + "&IdHora=" + hidIdHora.Text _
                    + "&dia=[dia]" _
                    + "&HoraInicio=" + lblHoraInicio.Text _
                    + "&HoraFin=" + lblHoraFin.Text + "&sub=1','HorariosSub');"

                ibAdd1.OnClientClick = clickAgregar.Replace("[dia]", "lunes")
                ibEliminar1.OnClientClick = "javascript:abreVentMediaScreen('../../ABC/Empleados/AdministracionHorarios.aspx?TipoOperacion=2" _
                    + "&IdHora=" + hidIdHora.Text _
                    + "&IdHorariosClase=" + lblLunes.Text + "&sub=1','HorariosSub');"
                ibAdd2.OnClientClick = clickAgregar.Replace("[dia]", "martes")
                ibEliminar2.OnClientClick = "javascript:abreVentMediaScreen('../../ABC/Empleados/AdministracionHorarios.aspx?TipoOperacion=2" _
                    + "&IdHora=" + hidIdHora.Text _
                    + "&IdHorariosClase=" + lblMartes.Text + "&sub=1','HorariosSub');"
                ibAdd3.OnClientClick = clickAgregar.Replace("[dia]", "miercoles")
                ibEliminar3.OnClientClick = "javascript:abreVentMediaScreen('../../ABC/Empleados/AdministracionHorarios.aspx?TipoOperacion=2" _
                    + "&IdHora=" + hidIdHora.Text _
                    + "&IdHorariosClase=" + lblMiercoles.Text + "&sub=1','HorariosSub');"
                ibAdd4.OnClientClick = clickAgregar.Replace("[dia]", "jueves")
                ibEliminar4.OnClientClick = "javascript:abreVentMediaScreen('../../ABC/Empleados/AdministracionHorarios.aspx?TipoOperacion=2" _
                    + "&IdHora=" + hidIdHora.Text _
                    + "&IdHorariosClase=" + lblJueves.Text + "&sub=1','HorariosSub');"
                ibAdd5.OnClientClick = clickAgregar.Replace("[dia]", "viernes")
                ibEliminar5.OnClientClick = "javascript:abreVentMediaScreen('../../ABC/Empleados/AdministracionHorarios.aspx?TipoOperacion=2" _
                    + "&IdHora=" + hidIdHora.Text _
                    + "&IdHorariosClase=" + lblViernes.Text + "&sub=1','HorariosSub');"
                ibAdd6.OnClientClick = clickAgregar.Replace("[dia]", "sabado")
                ibEliminar6.OnClientClick = "javascript:abreVentMediaScreen('../../ABC/Empleados/AdministracionHorarios.aspx?TipoOperacion=2" _
                    + "&IdHora=" + hidIdHora.Text _
                    + "&IdHorariosClase=" + lblSabado.Text + "&sub=1','HorariosSub');"
                ibAdd7.OnClientClick = clickAgregar.Replace("[dia]", "domingo")
                ibEliminar7.OnClientClick = "javascript:abreVentMediaScreen('../../ABC/Empleados/AdministracionHorarios.aspx?TipoOperacion=2" _
                    + "&IdHora=" + hidIdHora.Text _
                    + "&IdHorariosClase=" + lblDomingo.Text + "&sub=1','HorariosSub');"

                ibAdd1.Visible = False
                ibEliminar1.Visible = False
                imgDocenteTT1.Visible = False
                imgGrupoTT1.Visible = False

                ibAdd2.Visible = False
                ibEliminar2.Visible = False
                imgDocenteTT2.Visible = False
                imgGrupoTT2.Visible = False

                ibAdd3.Visible = False
                ibEliminar3.Visible = False
                imgDocenteTT3.Visible = False
                imgGrupoTT3.Visible = False

                ibAdd4.Visible = False
                ibEliminar4.Visible = False
                imgDocenteTT4.Visible = False
                imgGrupoTT4.Visible = False

                ibAdd5.Visible = False
                ibEliminar5.Visible = False
                imgDocenteTT5.Visible = False
                imgGrupoTT5.Visible = False

                ibAdd6.Visible = False
                ibEliminar6.Visible = False
                imgDocenteTT6.Visible = False
                imgGrupoTT6.Visible = False

                ibAdd7.Visible = False
                ibEliminar7.Visible = False
                imgDocenteTT7.Visible = False
                imgGrupoTT7.Visible = False

                If lblLunes.Text = "0" Then
                    If CInt(hidCantidadHorasHorario.Value) < CInt(lblTotalHoras.Text) Then ibAdd1.Visible = True
                Else
                    ibEliminar1.Visible = True
                End If

                If lblMartes.Text = "0" Then
                    If CInt(hidCantidadHorasHorario.Value) < CInt(lblTotalHoras.Text) Then ibAdd2.Visible = True
                Else
                    ibEliminar2.Visible = True
                End If


                If lblMiercoles.Text = "0" Then
                    If CInt(hidCantidadHorasHorario.Value) < CInt(lblTotalHoras.Text) Then ibAdd3.Visible = True
                Else
                    ibEliminar3.Visible = True
                End If


                If lblJueves.Text = "0" Then
                    If CInt(hidCantidadHorasHorario.Value) < CInt(lblTotalHoras.Text) Then ibAdd4.Visible = True
                Else
                    ibEliminar4.Visible = True
                End If


                If lblViernes.Text = "0" Then
                    If CInt(hidCantidadHorasHorario.Value) < CInt(lblTotalHoras.Text) Then ibAdd5.Visible = True
                Else
                    ibEliminar5.Visible = True
                End If

                If lblSabado.Text = "0" Then
                    If CInt(hidCantidadHorasHorario.Value) < CInt(lblTotalHoras.Text) Then ibAdd6.Visible = True
                Else
                    ibEliminar6.Visible = True
                End If

                If lblDomingo.Text = "0" Then
                    If CInt(hidCantidadHorasHorario.Value) < CInt(lblTotalHoras.Text) Then ibAdd7.Visible = True
                Else
                    ibEliminar7.Visible = True
                End If

                If imgDocenteTT1.ToolTip <> "" Then imgDocenteTT1.Visible = True
                If imgDocenteTT2.ToolTip <> "" Then imgDocenteTT2.Visible = True
                If imgDocenteTT3.ToolTip <> "" Then imgDocenteTT3.Visible = True
                If imgDocenteTT4.ToolTip <> "" Then imgDocenteTT4.Visible = True
                If imgDocenteTT5.ToolTip <> "" Then imgDocenteTT5.Visible = True
                If imgDocenteTT6.ToolTip <> "" Then imgDocenteTT6.Visible = True
                If imgDocenteTT7.ToolTip <> "" Then imgDocenteTT7.Visible = True

                If imgGrupoTT1.ToolTip <> "" Then imgGrupoTT1.Visible = True
                If imgGrupoTT2.ToolTip <> "" Then imgGrupoTT2.Visible = True
                If imgGrupoTT3.ToolTip <> "" Then imgGrupoTT3.Visible = True
                If imgGrupoTT4.ToolTip <> "" Then imgGrupoTT4.Visible = True
                If imgGrupoTT5.ToolTip <> "" Then imgGrupoTT5.Visible = True
                If imgGrupoTT6.ToolTip <> "" Then imgGrupoTT6.Visible = True
                If imgGrupoTT7.ToolTip <> "" Then imgGrupoTT7.Visible = True

                hidHorasRestantes.Text = CInt(hidHorasRestantes.Text) - gvHoras.Rows.Count
        End Select



    End Sub


End Class
