Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports DataAccessLayer.COBAEV.Administracion
Partial Class ImportarPercepcionesBAK
    Inherits System.Web.UI.Page
    Private dr As DataRow
    Private dsInconsistenciasPercMasivas As DataSet

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, _
                        ByVal dt As DataTable, Optional ByVal SelectedValue As String = "", _
                        Optional ByVal Habilitado As Boolean = True)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        Try
            ddl.DataBind()
        Catch
        End Try
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        ddl.Enabled = Habilitado
    End Sub
    Private Sub BindQnas()
        Dim oQna As New Quincenas
        With Me.ddlQnasAbiertasParaCaptura
            .DataSource = oQna.ObtenAbiertasParaCaptura()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count > 0 Then
                Me.btnImportar.Enabled = True
                Me.btnEliminar.Enabled = True
            Else
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas abiertas")
                .Items(0).Value = -1
                Me.btnImportar.Enabled = False
                Me.btnEliminar.Enabled = False
            End If
        End With
    End Sub
    Private Sub LlenadrInconsistenciaPercMasiva(ByVal s As String, ByVal IdError As Short)
        Dim drInconsistenciaPercMasiva As DataRow
        drInconsistenciaPercMasiva = dsInconsistenciasPercMasivas.Tables(0).NewRow
        drInconsistenciaPercMasiva(0) = s.Substring(0, 5)
        drInconsistenciaPercMasiva(1) = CDec(s.Substring(5, 8))
        drInconsistenciaPercMasiva(2) = 1
        Select Case IdError
            Case 1

            Case 2
                drInconsistenciaPercMasiva(3) = "Número de empleado duplicado."
            Case 3
                drInconsistenciaPercMasiva(3) = "Importe incorrecto."
            Case 4
                drInconsistenciaPercMasiva(3) = "Número de quincenas incorrecto."
            Case 5
                drInconsistenciaPercMasiva(3) = "Registro existente en nuestra base de datos."
            Case 6
                drInconsistenciaPercMasiva(3) = "Empleado no vigente."
        End Select
        drInconsistenciaPercMasiva(4) = IdError
        dsInconsistenciasPercMasivas.Tables(0).Rows.Add(drInconsistenciaPercMasiva)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oPercepcion As New Percepcion

            Me.MultiView1.SetActiveView(Me.viewPercepciones)
            LlenaDDL(Me.ddlPercepciones, "Percepcion", "IdPercepcion", oPercepcion.ObtenMasivas(True), String.Empty)
            BindQnas()
        End If
    End Sub

    Protected Sub btnImportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Dim Archivo As String = ConfigurationManager.AppSettings("RutaImportarPercepciones") + "\" + _
                                Me.ddlPercepciones.SelectedItem.Text.Substring(1, 3) + ".txt"
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsPercsMasivas As DataSet
        Dim oQna As New Quincenas
        Dim dt As DataTable
        Dim sr As System.IO.StreamReader = Nothing
        Dim oEmp As New Empleado
        'Dim Importe As Decimal
        Try
            sr = New System.IO.StreamReader(Archivo, System.Text.Encoding.Default, True)

            dsPercsMasivas = _DataCOBAEV.setDataSetPercepcionesMasivas
            dsInconsistenciasPercMasivas = _DataCOBAEV.setDataSetInconsistenciasPercMasivas

            While sr.Peek() <> -1
                Dim s As String = sr.ReadLine()
                If String.IsNullOrEmpty(s) Then
                    Continue While
                Else
                    Dim drPercepcionMasiva As DataRow
                    drPercepcionMasiva = dsPercsMasivas.Tables(0).NewRow
                    drPercepcionMasiva(0) = s.Substring(0, 5)
                    If Not oEmp.EstaVigente(drPercepcionMasiva(0).ToString, Me.ddlQnasAbiertasParaCaptura.SelectedValue) Then
                        LlenadrInconsistenciaPercMasiva(s, 6)
                        Continue While
                    End If
                    Try
                        drPercepcionMasiva(1) = CDec(s.Substring(5, 8))
                        If CDec(s.Substring(5, 8)) <= 0 Then
                            LlenadrInconsistenciaPercMasiva(s, 3)
                            Continue While
                        End If
                    Catch ex As Exception
                        Select Case ex.GetType().FullName
                            Case "System.InvalidCastException"
                                'Agregar a inconsistencias
                                LlenadrInconsistenciaPercMasiva(s, 3)
                                Continue While
                        End Select
                    End Try
                    Try
                        drPercepcionMasiva(2) = 1 'CByte(s.Substring(13, 2))
                        'If CByte(s.Substring(13, 2)) <= 0 Then
                        If drPercepcionMasiva(2) <= 0 Then
                            LlenadrInconsistenciaPercMasiva(s, 4)
                            Continue While
                        End If
                    Catch ex As Exception
                        Select Case ex.GetType().FullName
                            Case "System.InvalidCastException"
                                'Agregar a inconsistencias
                                LlenadrInconsistenciaPercMasiva(s, 4)
                                Continue While
                        End Select
                    End Try
                    drPercepcionMasiva(3) = CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue)
                    drPercepcionMasiva(4) = Me.ddlQnasAbiertasParaCaptura.SelectedItem.Text
                    'If CByte(s.Substring(13, 2)) = 1 Then
                    If drPercepcionMasiva(2) = 1 Then
                        drPercepcionMasiva(5) = CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue)
                        drPercepcionMasiva(6) = Me.ddlQnasAbiertasParaCaptura.SelectedItem.Text
                    Else
                        dt = oQna.ObtenParaVigFin(CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue), drPercepcionMasiva(2))
                        drPercepcionMasiva(5) = CShort(dt.Rows(0).Item("IdQuincena"))
                        drPercepcionMasiva(6) = dt.Rows(0).Item("Quincena").ToString
                    End If
                    Try
                        dsPercsMasivas.Tables(0).Rows.Add(drPercepcionMasiva)
                    Catch ex As Exception
                        Select Case ex.GetType().FullName
                            Case "System.Data.ConstraintException"
                                'Agregar a inconsistencias
                                'LlenadrInconsistenciaDeducMasiva(s, 2)
                                dsPercsMasivas.Tables(0).Rows.Find(drPercepcionMasiva(0)).Item("ImportePercepcion") = CDec(dsPercsMasivas.Tables(0).Rows.Find(drPercepcionMasiva(0)).Item("ImportePercepcion")) + drPercepcionMasiva(1)
                                Continue While
                        End Select
                    End Try
                    'Validamos que no exista duplicidad en la tabla donde insertaremos los registros
                    Dim oPlazasPercepcionesCantidadVariable As New PlazasPercepcionesCantidadVariable
                    With oPlazasPercepcionesCantidadVariable
                        .IdPercepcion = CShort(Me.ddlPercepciones.SelectedValue)
                        .IdQnaVigIniPerc = CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue)
                        .ImpPerc = CDec(s.Substring(5, 8))
                        If .ValidaSiExisteRegistro(s.Substring(0, 5)) = True Then
                            'Agregar a inconsistencias
                            LlenadrInconsistenciaPercMasiva(s, 5)
                            Continue While
                        End If
                    End With
                End If
            End While
            sr.Close()
            Me.gvPercMasivas.DataSource = dsPercsMasivas.Tables(0)
            Me.gvPercMasivas.DataBind()
            Me.gvPercMasivas.Visible = True
            Me.btnGuardar.Enabled = Me.gvPercMasivas.Rows.Count > 0
            Me.gvInconsistencias.DataSource = dsInconsistenciasPercMasivas.Tables(0)
            Me.gvInconsistencias.DataBind()
            Me.gvInconsistencias.Visible = True
            If Me.gvInconsistencias.Rows.Count > 0 Then
                For Each drc As DataRow In dsInconsistenciasPercMasivas.Tables(0).Rows
                    Select Case CShort(drc("IdError"))
                        Case 1, 5
                            dsPercsMasivas.Tables(0).Rows.Find(drc("NumEmp")).Delete()
                            dsPercsMasivas.Tables(0).AcceptChanges()
                    End Select
                Next
                Me.gvPercMasivas.DataSource = dsPercsMasivas.Tables(0)
                Me.gvPercMasivas.DataBind()
            End If
            Me.lblIdPercepcion.Text = Me.ddlPercepciones.SelectedValue
            Me.lblIdPercepcion2.Text = Me.ddlPercepciones.SelectedValue
            Me.lblPercepcion.Text = Me.ddlPercepciones.SelectedItem.Text
            Me.lblPercepcion.Visible = True
            Me.lblPercepcion2.Text = Me.ddlPercepciones.SelectedItem.Text
            Me.lblPercepcion2.Visible = True
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
        Me.MultiView1.SetActiveView(Me.viewPercepciones)
    End Sub

    Protected Sub gvPercMasivas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercMasivas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim oEmp As New Empleado
                Dim oUsr As New Usuario
                Dim dr As DataRow
                Dim lblEmpleado As Label = CType(e.Row.FindControl("lblEmpleado"), Label)
                Dim dt As DataTable
                oUsr.Login = Session("Login")
                dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
                oEmp.NumEmp = CType(e.Row.FindControl("lblNumEmp"), Label).Text
                dt = oEmp.Buscar(Empleado.TipoBusqueda.NumeroDeEmpleado, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
                If dt.Rows.Count > 0 Then
                    lblEmpleado.Text = dt.Rows(0).Item("Apellido_Paterno") + " " + dt.Rows(0).Item("Apellido_Materno") + " " + dt.Rows(0).Item("Nombre")
                Else
                    'Agregar a inconsistencias
                    Dim drInconsistenciaPercMasiva As DataRow
                    drInconsistenciaPercMasiva = dsInconsistenciasPercMasivas.Tables(0).NewRow
                    drInconsistenciaPercMasiva(0) = CType(e.Row.FindControl("lblNumEmp"), Label).Text
                    drInconsistenciaPercMasiva(1) = CType(e.Row.FindControl("lblImportePercepcion"), Label).Text
                    drInconsistenciaPercMasiva(2) = CType(e.Row.FindControl("lblNumQnas"), Label).Text
                    drInconsistenciaPercMasiva(3) = "Número de empleado inexistente."
                    drInconsistenciaPercMasiva(4) = 1
                    dsInconsistenciasPercMasivas.Tables(0).Rows.Add(drInconsistenciaPercMasiva)
                End If
        End Select
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim oPerc As New Percepcion
            For Each gvr As GridViewRow In Me.gvPercMasivas.Rows
                With oPerc
                    .IdPercepcion = CShort(Me.lblIdPercepcion.Text)
                    .ImportePercepcion = CDec(CType(gvr.FindControl("lblImportePercepcion"), Label).Text)
                    .IdQnaInicio = CShort(CType(gvr.FindControl("lblIdQnaIni"), Label).Text)
                    .IdQnaFin = CShort(CType(gvr.FindControl("lblIdQnaIni"), Label).Text) 'CShort(CType(gvr.FindControl("lblIdQnaFin"), Label).Text)
                    .InsMasiva(Percepcion.TipoInsercion.ParaPago, CType(gvr.FindControl("lblNumEmp"), Label).Text, CType(Session("ArregloAuditoria"), String()))
                End With
            Next
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
        Response.Redirect("~/ABC/Nomina/ImportarPercepciones.aspx?TipoOperacion=1")
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim oPerc As New Percepcion
            With oPerc
                .DelMasiva(CShort(Me.ddlPercepciones.SelectedValue), CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue), CShort(Me.ddlQnasAbiertasParaCaptura.SelectedValue), CType(Session("ArregloAuditoria"), String()))
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
End Class
