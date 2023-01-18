Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Partial Class ImportarClave431BAK
    Inherits System.Web.UI.Page
    Private dr As DataRow
    Private dsInconsistenciasDeducMasivas As DataSet

    'Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, _
    '                    ByVal dt As DataTable, Optional ByVal SelectedValue As String = "", _
    '                    Optional ByVal Habilitado As Boolean = True)
    '    ddl.DataSource = dt
    '    ddl.DataTextField = TextField
    '    ddl.DataValueField = ValueField
    '    Try
    '        ddl.DataBind()
    '    Catch
    '    End Try
    '    If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    '    ddl.Enabled = Habilitado
    'End Sub
    Private Sub BindQnas()
        Dim oQna As New Quincenas
        With Me.ddlQnasAbiertasParaCaptura
            .DataSource = oQna.ObtenAbiertasParaCaptura()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count > 0 Then
                Me.btnImportar.Enabled = True
                'Me.btnEliminar.Enabled = True
            Else
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas abiertas")
                .Items(0).Value = -1
                Me.btnImportar.Enabled = False
                Me.btnEliminar.Enabled = False
            End If
        End With
    End Sub
    Private Sub LlenadrInconsistenciaDeducMasiva(ByVal s As String, ByVal IdError As Short)
        Dim drInconsistenciaDeducMasiva As DataRow
        drInconsistenciaDeducMasiva = dsInconsistenciasDeducMasivas.Tables(0).NewRow
        drInconsistenciaDeducMasiva(0) = s.Substring(146, 18)
        drInconsistenciaDeducMasiva(1) = CDec(s.Substring(119, 7)) / 100
        drInconsistenciaDeducMasiva(2) = CByte(s.Substring(102, 3))

        Select Case IdError
            Case 1

            Case 2
                drInconsistenciaDeducMasiva(3) = "CURP duplicado."
            Case 3
                drInconsistenciaDeducMasiva(3) = "Importe incorrecto."
            Case 4
                drInconsistenciaDeducMasiva(3) = "Número de quincenas incorrecto."
            Case 5
                drInconsistenciaDeducMasiva(3) = "Registro existente en nuestra base de datos."
            Case 6
                drInconsistenciaDeducMasiva(3) = "Empleado no vigente."
            Case 7
                drInconsistenciaDeducMasiva(3) = "Tipo de orden incorrecto."
            Case 8
                drInconsistenciaDeducMasiva(3) = "Empleado viene en el archivo con dos o más movimientos de un mismo tipo."
            Case 9
                drInconsistenciaDeducMasiva(3) = "El empleado tiene préstamos vigentes actualmente, no se le puede aplicar una ALTA."
            Case 10
                drInconsistenciaDeducMasiva(3) = "Número de préstamo ISSSTE registrado con anterioridad."
            Case 11
                drInconsistenciaDeducMasiva(3) = "Préstamos ISSSTE " + Left(s.Substring(166, 11), 4) + ", solo se reciben entre enero y abril del año " + Left(ddlQnasAbiertasParaCaptura.SelectedItem.Text, 4) + "."
            Case 12
                drInconsistenciaDeducMasiva(3) = "Préstamo ISSSTE " + Left(s.Substring(166, 11), 4) + " demasiado desfasado, verifique por favor."
            Case 13
                drInconsistenciaDeducMasiva(3) = "Quincena " + s.Substring(107, 4) + s.Substring(105, 2) + " de inicio del préstamo diferente a la quincena abierta para captura."
            Case 14
                drInconsistenciaDeducMasiva(3) = "El número de préstamo ISSSTE a dar de BAJA, no está vigente actualmente en nuestro sistema."
            Case 15
                drInconsistenciaDeducMasiva(3) = "El registro no corresponde al concepto 03 ó 08."
        End Select
        drInconsistenciaDeducMasiva(4) = IdError
        Select Case s.Substring(101, 1)
            Case "1"
                drInconsistenciaDeducMasiva(5) = "ALTA"
            Case "2"
                drInconsistenciaDeducMasiva(5) = "BAJA"
            Case "3"
                drInconsistenciaDeducMasiva(5) = "ACT."
            Case Else
                drInconsistenciaDeducMasiva(5) = "ERROR"
        End Select
        'drInconsistenciaDeducMasiva(5) = CByte(s.Substring(101, 1))
        drInconsistenciaDeducMasiva(6) = s.Substring(166, 11)
        drInconsistenciaDeducMasiva(7) = s.Substring(117, 2)
        dsInconsistenciasDeducMasivas.Tables(0).Rows.Add(drInconsistenciaDeducMasiva)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oDeduccion As New Deduccion

            Me.MultiView1.SetActiveView(Me.viewDeducciones)
            ''LlenaDDL(Me.ddlDeducciones, "Deduccion", "IdDeduccion", oDeduccion.ObtenMasivas(True), String.Empty)
            BindQnas()
        End If
    End Sub

    Protected Sub btnImportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Dim Archivo As String = ConfigurationManager.AppSettings("RutaImportarDeducciones") + "\431.txt"

        'Me.ddlDeducciones.SelectedItem.Text.Substring(1, 3) + ".txt"

        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsDeduccionesMasivas As DataSet
        Dim oQna As New Quincenas
        Dim dt As DataTable
        Dim sr As System.IO.StreamReader = Nothing
        Dim oEmp As New Empleado
        Dim Keys(1) As Object
        'Dim Importe As Decimal
        Dim dtPermisos As DataTable
        Dim oSem As New Semestre
        Dim oUsr As New Usuario
        Dim oEmpleado As New Deduccion
        Dim strQnaInicio As String
        Dim vlIdDeduccion As Short = 0

        dtPermisos = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Semestres")

        Try
            sr = New System.IO.StreamReader(Archivo, System.Text.Encoding.Default, True)

            dsDeduccionesMasivas = _DataCOBAEV.setDataSetDeduccionesMasivas2()
            dsInconsistenciasDeducMasivas = _DataCOBAEV.setDataSetInconsistenciasDeducMasivas2()

            While sr.Peek() <> -1
                Dim s As String = sr.ReadLine()
                If String.IsNullOrEmpty(s) Then
                    Continue While
                Else
                    Dim drDeduccionMasiva As DataRow
                    drDeduccionMasiva = dsDeduccionesMasivas.Tables(0).NewRow

                    drDeduccionMasiva(9) = s.Substring(117, 2) 'Concepto
                    If drDeduccionMasiva(9) <> "03" And drDeduccionMasiva(9) <> "08" Then
                        vlIdDeduccion = 0
                        drDeduccionMasiva(10) = vlIdDeduccion
                        LlenadrInconsistenciaDeducMasiva(s, 15)
                        Continue While
                    Else
                        vlIdDeduccion = IIf(s.Substring(117, 2) = "03", 31, IIf(s.Substring(117, 2) = "08", 136, 0))
                        drDeduccionMasiva(10) = vlIdDeduccion
                    End If

                    drDeduccionMasiva(0) = s.Substring(146, 18) 'CURP

                    'If drDeduccionMasiva(0) = "COMR760914MVZRDC02" Then
                    '    vlIdDeduccion = vlIdDeduccion
                    '    'End If

                    If Not oEmp.EstaVigentePorCURP(drDeduccionMasiva(0).ToString, Me.ddlQnasAbiertasParaCaptura.SelectedValue) Then
                        LlenadrInconsistenciaDeducMasiva(s, 6)
                        Continue While
                    End If

                    'Verificamos que la quincena de inicio del préstamo sea igual a la quincena abierta para captura
                    strQnaInicio = s.Substring(107, 4) + s.Substring(105, 2)
                    If ddlQnasAbiertasParaCaptura.SelectedItem.Text <> strQnaInicio Then
                        LlenadrInconsistenciaDeducMasiva(s, 13)
                        Continue While
                    End If

                    Try
                        drDeduccionMasiva(1) = CDec(s.Substring(119, 7)) / 100 'Importe
                        If drDeduccionMasiva(1) < 0 Then
                            LlenadrInconsistenciaDeducMasiva(s, 3)
                            Continue While
                        End If
                    Catch ex As Exception
                        Select Case ex.GetType().FullName
                            Case "System.InvalidCastException"
                                'Agregar a inconsistencias
                                LlenadrInconsistenciaDeducMasiva(s, 3)
                                Continue While
                        End Select
                    End Try
                    Try
                        drDeduccionMasiva(2) = CByte(s.Substring(102, 3)) 'NumQnas
                        If drDeduccionMasiva(2) < 0 Then
                            LlenadrInconsistenciaDeducMasiva(s, 4)
                            Continue While
                        End If
                    Catch ex As Exception
                        Select Case ex.GetType().FullName
                            Case "System.InvalidCastException"
                                'Agregar a inconsistencias
                                LlenadrInconsistenciaDeducMasiva(s, 4)
                                Continue While
                        End Select
                    End Try

                    drDeduccionMasiva(3) = CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue)
                    drDeduccionMasiva(4) = Me.ddlQnasAbiertasParaCaptura.SelectedItem.Text
                    'If CByte(s.Substring(13, 2)) = 1 Then
                    If drDeduccionMasiva(2) = 1 Or drDeduccionMasiva(2) = 0 Then
                        drDeduccionMasiva(5) = CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue)
                        drDeduccionMasiva(6) = Me.ddlQnasAbiertasParaCaptura.SelectedItem.Text
                    Else
                        dt = oQna.ObtenParaVigFin(CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue), drDeduccionMasiva(2))
                        drDeduccionMasiva(5) = CShort(dt.Rows(0).Item("IdQuincena"))
                        drDeduccionMasiva(6) = dt.Rows(0).Item("Quincena").ToString
                    End If
                    Try
                        Select Case s.Substring(101, 1)
                            Case "1"
                                drDeduccionMasiva(7) = "ALTA"
                            Case "2"
                                drDeduccionMasiva(7) = "BAJA"
                            Case "3"
                                drDeduccionMasiva(7) = "ACT."
                            Case Else
                                drDeduccionMasiva(7) = "ERROR"
                        End Select
                        'drDeduccionMasiva(7) = CByte(s.Substring(101, 1)) 'TipoOrden
                        'If drDeduccionMasiva(7) < 1 Or drDeduccionMasiva(7) > 3 Then
                        If drDeduccionMasiva(7) = "ERROR" Then
                            LlenadrInconsistenciaDeducMasiva(s, 7)
                            Continue While
                        End If
                        If drDeduccionMasiva(7) = "ALTA" Then
                            'Validamos que no tenga un préstamo vigente en nuestra base de datos
                            If oEmpleado.TienePrestamoISSSTEVigente(s.Substring(146, 18), CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue), CShort(drDeduccionMasiva(5)), vlIdDeduccion) Then
                                LlenadrInconsistenciaDeducMasiva(s, 9)
                                Continue While
                            End If
                        End If


                        drDeduccionMasiva(8) = s.Substring(166, 11) 'número de préstamo ISSSTE
                        'Para las altas y actualizaciones
                        If s.Substring(101, 1) = "1" Then 'Or s.Substring(101, 1) = "3"
                            'Validamos en número de préstamo ISSSTE
                            '--->drDeduccionMasiva(8) = s.Substring(166, 11)
                            If oEmpleado.TieneNumPrestamoISSSTE(s.Substring(146, 18), s.Substring(166, 11), vlIdDeduccion) Then
                                LlenadrInconsistenciaDeducMasiva(s, 10)
                                Continue While
                            End If
                        End If

                        'Para las altas y actualizaciones
                        If s.Substring(101, 1) = "1" Then 'Or s.Substring(101, 1) = "3" 
                            'Validamos que el número de préstamo ISSSTE sea del año acutual o del año anterior, y si es del año anterior
                            'que solo se permita registrarlos entre enero y abril del año actual.
                            '--->drDeduccionMasiva(8) = s.Substring(166, 11)
                            If Left(drDeduccionMasiva(8), 4) <> Left(ddlQnasAbiertasParaCaptura.SelectedItem.Text, 4) Then
                                'Si el préstamo es del año anterior
                                If (CShort(Left(ddlQnasAbiertasParaCaptura.SelectedItem.Text, 4)) - CShort(Left(drDeduccionMasiva(8), 4))) = 1 Then
                                    'Solo se reciben préstamos ISSSTE del año anterior entre las quincenas 1 a 8 del año actual
                                    If CShort(Right(ddlQnasAbiertasParaCaptura.SelectedItem.Text, 2)) > 8 Then
                                        LlenadrInconsistenciaDeducMasiva(s, 11)
                                        Continue While
                                    End If
                                Else
                                    LlenadrInconsistenciaDeducMasiva(s, 12)
                                    Continue While
                                End If
                            End If
                        End If

                        'Para las bajas
                        If drDeduccionMasiva(7) = "BAJA" Then
                            'Validamos que el número de préstamo ISSSTE a dar de baja sea el que tiene vigente en la BD
                            '--->drDeduccionMasiva(8) = s.Substring(166, 11)
                            If oEmpleado.TieneNumPrestamoISSSTEVigente(s.Substring(146, 18), s.Substring(166, 11), CShort(ddlQnasAbiertasParaCaptura.SelectedValue), vlIdDeduccion) = False Then
                                LlenadrInconsistenciaDeducMasiva(s, 14)
                                Continue While
                            End If
                        End If

                    Catch ex As Exception
                        Select Case ex.GetType().FullName
                            Case "System.InvalidCastException"
                                'Agregar a inconsistencias
                                LlenadrInconsistenciaDeducMasiva(s, 7)
                                Continue While
                        End Select
                    End Try
                    Try
                        dsDeduccionesMasivas.Tables(0).Rows.Add(drDeduccionMasiva)
                    Catch ex As Exception
                        Select Case ex.GetType().FullName
                            Case "System.Data.ConstraintException"
                                LlenadrInconsistenciaDeducMasiva(s, 8)

                                Continue While
                        End Select
                    End Try
                    'Validamos que no exista duplicidad en la tabla donde insertaremos los registros
                    Dim oPlazasDeduccionesCantidadVariable As New PlazasDeduccionesCantidadVariable
                    With oPlazasDeduccionesCantidadVariable
                        .IdDeduccion = CShort(Me.ddlDeducciones.SelectedValue)
                        .IdQnaVigIniDeduc = CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue)
                        .IdQnaVigFinDeduc = CShort(drDeduccionMasiva(5))
                        .ImpDeduc = CDec(s.Substring(119, 7)) / 100
                        .TipoOrden = drDeduccionMasiva(7).ToString
                        If .ValidaSiExisteRegistroPorCURP(s.Substring(146, 18)) = True Then
                            'Agregar a inconsistencias
                            LlenadrInconsistenciaDeducMasiva(s, 5)
                            Continue While
                        End If
                    End With
                End If
            End While
            sr.Close()
            Me.gvDeducMasivas.DataSource = dsDeduccionesMasivas.Tables(0)
            Me.gvDeducMasivas.DataBind()
            Me.gvDeducMasivas.Visible = True
            Me.btnGuardar.Enabled = Me.gvDeducMasivas.Rows.Count > 0 And CBool(dtPermisos.Rows(0).Item("Insercion"))
            Me.gvInconsistencias.DataSource = dsInconsistenciasDeducMasivas.Tables(0)
            Me.gvInconsistencias.DataBind()
            Me.gvInconsistencias.Visible = True
            If Me.gvInconsistencias.Rows.Count > 0 Then
                For Each drc As DataRow In dsInconsistenciasDeducMasivas.Tables(0).Rows
                    Select Case CShort(drc("IdError"))
                        Case 1, 5
                            Keys(0) = drc("CURPEmp").ToString
                            Keys(1) = drc("TipoOrden").ToString
                            dsDeduccionesMasivas.Tables(0).Rows.Find(Keys).Delete()
                            dsDeduccionesMasivas.Tables(0).AcceptChanges()
                    End Select
                Next
                Me.gvDeducMasivas.DataSource = dsDeduccionesMasivas.Tables(0)
                Me.gvDeducMasivas.DataBind()
            End If
            Me.lblIdDeduccion.Text = Me.ddlDeducciones.SelectedValue
            Me.lblIdDeduccion2.Text = Me.ddlDeducciones.SelectedValue
            Me.lblDeduccion.Text = Me.ddlDeducciones.SelectedItem.Text
            Me.lblDeduccion.Visible = True
            Me.lblDeduccion2.Text = Me.ddlDeducciones.SelectedItem.Text
            Me.lblDeduccion2.Visible = True
        Catch ex As Exception
            'sr.Close()
            Me.lblError.Text = ex.Message
            Me.MultiView1.Visible = False
            Me.MultiView2.Visible = True
            Me.MultiView2.SetActiveView(Me.viewError)
        Finally
            sr.Close()
        End Try
    End Sub

    Protected Sub lbError_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbError.Click
        Me.MultiView2.Visible = False
        Me.MultiView1.Visible = True
        Me.MultiView1.SetActiveView(Me.viewDeducciones)
    End Sub

    Protected Sub gvDeducMasivas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDeducMasivas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim oEmp As New Empleado
                Dim oUsr As New Usuario
                Dim dr As DataRow
                Dim lblEmpleado As Label = CType(e.Row.FindControl("lblEmpleado"), Label)
                Dim dt As DataTable
                oUsr.Login = Session("Login")
                dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
                oEmp.CURPEmp = CType(e.Row.FindControl("lblCURPEmp"), Label).Text
                dt = oEmp.Buscar(Empleado.TipoBusqueda.CURP, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
                If dt.Rows.Count > 0 Then
                    lblEmpleado.Text = dt.Rows(0).Item("Apellido_Paterno") + " " + dt.Rows(0).Item("Apellido_Materno") + " " + dt.Rows(0).Item("Nombre")
                Else
                    'Agregar a inconsistencias
                    Dim drInconsistenciaDeducMasiva As DataRow
                    drInconsistenciaDeducMasiva = dsInconsistenciasDeducMasivas.Tables(0).NewRow
                    drInconsistenciaDeducMasiva(0) = CType(e.Row.FindControl("lblCURPEmp"), Label).Text
                    drInconsistenciaDeducMasiva(1) = CType(e.Row.FindControl("lblImporteDeduccion"), Label).Text
                    drInconsistenciaDeducMasiva(2) = CType(e.Row.FindControl("lblNumQnas"), Label).Text
                    drInconsistenciaDeducMasiva(3) = "CURP inexistente."
                    drInconsistenciaDeducMasiva(4) = 1
                    drInconsistenciaDeducMasiva(5) = CType(e.Row.FindControl("lblTipoOrden"), Label).Text
                    drInconsistenciaDeducMasiva(6) = CType(e.Row.FindControl("lblNumPrestamo"), Label).Text
                    drInconsistenciaDeducMasiva(7) = CType(e.Row.FindControl("lblConcepto"), Label).Text
                    drInconsistenciaDeducMasiva(8) = CType(e.Row.FindControl("lblIdDeduccion"), Label).Text

                    dsInconsistenciasDeducMasivas.Tables(0).Rows.Add(drInconsistenciaDeducMasiva)
                End If
        End Select
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim oDeduc As New Deduccion
            Dim lblTipoOrden As Label = Nothing
            Dim gvrc As GridViewRowCollection = Me.gvDeducMasivas.Rows
            'Procesamos primero las bajas

            For Each gvr As GridViewRow In gvrc 'Me.gvDeducMasivas.Rows
                With oDeduc
                    lblTipoOrden = CType(gvr.FindControl("lblTipoOrden"), Label)
                    If lblTipoOrden.Text = "BAJA" Then
                        .IdDeduccion = CShort(CType(gvr.FindControl("lblIdDeduccion"), Label).Text) 'CShort(Me.lblIdDeduccion.Text)
                        .ImporteDeduccion = CDec(CType(gvr.FindControl("lblImporteDeduccion"), Label).Text)
                        .IdQnaInicio = CShort(CType(gvr.FindControl("lblIdQnaIni"), Label).Text)
                        .IdQnaFin = CShort(CType(gvr.FindControl("lblIdQnaFin"), Label).Text) 'CShort(CType(gvr.FindControl("lblIdQnaFin"), Label).Text)
                        .NumPrestamoISSSTE = CType(gvr.FindControl("lblNumPrestamo"), Label).Text
                        .InsMasivaClave431(lblTipoOrden.Text, CType(gvr.FindControl("lblCURPEmp"), Label).Text, CType(Session("ArregloAuditoria"), String()))
                    End If
                End With
            Next gvr
            'Procesamos luego los cambios
            For Each gvr2 As GridViewRow In gvrc 'Me.gvDeducMasivas.Rows
                With oDeduc
                    lblTipoOrden = CType(gvr2.FindControl("lblTipoOrden"), Label)
                    If lblTipoOrden.Text = "ACT." Then
                        .IdDeduccion = CShort(CType(gvr2.FindControl("lblIdDeduccion"), Label).Text) ' CShort(Me.lblIdDeduccion.Text)
                        .ImporteDeduccion = CDec(CType(gvr2.FindControl("lblImporteDeduccion"), Label).Text)
                        .IdQnaInicio = CShort(CType(gvr2.FindControl("lblIdQnaIni"), Label).Text)
                        .IdQnaFin = CShort(CType(gvr2.FindControl("lblIdQnaFin"), Label).Text) 'CShort(CType(gvr.FindControl("lblIdQnaFin"), Label).Text)
                        .NumPrestamoISSSTE = CType(gvr2.FindControl("lblNumPrestamo"), Label).Text
                        .InsMasivaClave431(lblTipoOrden.Text, CType(gvr2.FindControl("lblCURPEmp"), Label).Text, CType(Session("ArregloAuditoria"), String()))
                    End If
                End With
            Next gvr2
            'Procesamos luego las altas
            For Each gvr3 As GridViewRow In gvrc 'Me.gvDeducMasivas.Rows
                With oDeduc
                    lblTipoOrden = CType(gvr3.FindControl("lblTipoOrden"), Label)
                    If lblTipoOrden.Text = "ALTA" Then
                        .IdDeduccion = CShort(CType(gvr3.FindControl("lblIdDeduccion"), Label).Text)  'CShort(Me.lblIdDeduccion.Text)
                        .ImporteDeduccion = CDec(CType(gvr3.FindControl("lblImporteDeduccion"), Label).Text)
                        .IdQnaInicio = CShort(CType(gvr3.FindControl("lblIdQnaIni"), Label).Text)
                        .IdQnaFin = CShort(CType(gvr3.FindControl("lblIdQnaFin"), Label).Text) 'CShort(CType(gvr.FindControl("lblIdQnaFin"), Label).Text)
                        .NumPrestamoISSSTE = CType(gvr3.FindControl("lblNumPrestamo"), Label).Text
                        .InsMasivaClave431(lblTipoOrden.Text, CType(gvr3.FindControl("lblCURPEmp"), Label).Text, CType(Session("ArregloAuditoria"), String()))
                    End If
                End With
            Next gvr3
            Me.MultiView1.SetActiveView(Me.viewExito)
            Me.lblExito.Text = "Proceso realizado correctamente."
        Catch ex As Exception
            Me.lblError.Text = ex.Message
            Me.MultiView1.Visible = False
            Me.MultiView2.Visible = True
            Me.MultiView2.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim oDeduc As New Deduccion
            With oDeduc
                .DelMasiva(CShort(Me.ddlDeducciones.SelectedValue), CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue), CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue), CType(Session("ArregloAuditoria"), String()))
            End With
            Me.MultiView1.SetActiveView(Me.viewExito)
            Me.lblExito.Text = "Proceso realizado correctamente."
        Catch ex As Exception
            Me.lblError.Text = ex.Message
            Me.MultiView1.Visible = False
            Me.MultiView2.Visible = True
            Me.MultiView2.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub lbExito_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/ABC/Nomina/ImportarClave431.aspx?TipoOperacion=1")
    End Sub

    Protected Sub gvInconsistencias_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim oEmp As New Empleado
                Dim oUsr As New Usuario
                Dim dr As DataRow
                Dim lblEmpleado As Label = CType(e.Row.FindControl("lblEmpleado"), Label)
                Dim dt As DataTable
                oUsr.Login = Session("Login")
                dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
                oEmp.CURPEmp = CType(e.Row.FindControl("lblCURPEmp"), Label).Text
                dt = oEmp.Buscar(Empleado.TipoBusqueda.CURP, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
                If dt.Rows.Count > 0 Then
                    lblEmpleado.Text = dt.Rows(0).Item("Apellido_Paterno") + " " + dt.Rows(0).Item("Apellido_Materno") + " " + dt.Rows(0).Item("Nombre")
                Else
                    lblEmpleado.Text = String.Empty
                End If
        End Select
    End Sub
End Class
