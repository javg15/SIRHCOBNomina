Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports DataAccessLayer.COBAEV.Administracion
Partial Class ImportarDeducciones
    Inherits System.Web.UI.Page
    Private dr As DataRow
    Private dsInconsistenciasDeducMasivas As DataSet

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
        With ddlQnasAbiertasParaCaptura
            .DataSource = oQna.ObtenAbiertasParaCaptura()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count > 0 Then
                btnImportar.Enabled = True
                btnEliminar.Enabled = True
            Else
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas abiertas")
                .Items(0).Value = -1
                btnImportar.Enabled = False
                btnEliminar.Enabled = False
            End If
        End With
    End Sub
    Private Sub LlenadrInconsistenciaDeducMasiva(ByVal s As String, ByVal IdError As Short)
        Try

            Dim drInconsistenciaDeducMasiva As DataRow
            drInconsistenciaDeducMasiva = dsInconsistenciasDeducMasivas.Tables(0).NewRow
            drInconsistenciaDeducMasiva(0) = s.Substring(0, 5)
            drInconsistenciaDeducMasiva(1) = CDec(s.Substring(5, 8))
            drInconsistenciaDeducMasiva(2) = 1
            Select Case IdError
                Case 1

                Case 2
                    drInconsistenciaDeducMasiva(3) = "Número de empleado duplicado."
                Case 3
                    drInconsistenciaDeducMasiva(3) = "Importe incorrecto."
                Case 4
                    drInconsistenciaDeducMasiva(3) = "Número de quincenas incorrecto."
                Case 5
                    drInconsistenciaDeducMasiva(3) = "Registro existente en nuestra base de datos."
                Case 6
                    drInconsistenciaDeducMasiva(3) = "Empleado no vigente."
            End Select
            drInconsistenciaDeducMasiva(4) = IdError
            dsInconsistenciasDeducMasivas.Tables(0).Rows.Add(drInconsistenciaDeducMasiva)
        Catch ex As Exception
            Select Case ex.GetType().FullName
                Case "System.Data.ConstraintException"
                    dsInconsistenciasDeducMasivas.Tables(0).Rows.Find(s.Substring(0, 5)).Item("ImporteDeduccion") = CDec(dsInconsistenciasDeducMasivas.Tables(0).Rows.Find(s.Substring(0, 5)).Item("ImporteDeduccion")) + CDec(s.Substring(5, 8))
            End Select
        End Try
    End Sub
    Private Sub Procesa()
        Dim oDeduccion As New Deduccion
        Dim TargetPath As String = String.Empty
        Dim strAnio As String
        Dim strQna As String
        Dim i As Integer

        strAnio = Left(ddlQnasAbiertasParaCaptura.SelectedItem.Text, 4)
        strQna = ddlQnasAbiertasParaCaptura.SelectedItem.Text

        LlenaDDL(ddlDeducciones, "Deduccion", "IdDeduccion", oDeduccion.ObtenMasivas(True), String.Empty)

        i = 0
        'flagCambios = False
        While ddlDeducciones.Items.Count > 0
            TargetPath = ConfigurationManager.AppSettings("RutaImportarDeducciones")
            TargetPath = TargetPath + "\" + strAnio.ToString
            TargetPath = TargetPath + "\" + strQna.Replace("-", "_").ToString
            TargetPath = TargetPath + "\" + ddlDeducciones.Items(i).Text.Substring(1, 3) + ".txt"
            If Not File.Exists(TargetPath) Then
                ddlDeducciones.Items.RemoveAt(i)
                i = 0
            Else
                i = i + 1
                If i >= ddlDeducciones.Items.Count Then
                    Exit While
                End If
            End If
        End While

        If ddlDeducciones.Items.Count = 0 Then
            ddlDeducciones.Items.Insert(0, New ListItem("No hay deducciones para importar.", "-1"))
            btnImportar.Visible = False
            btnEliminar.Visible = False
            btnGuardar.Visible = False
        Else
            btnImportar.Visible = True
            btnEliminar.Visible = True
            btnGuardar.Visible = False
        End If

        gvDeducMasivas.DataSource = Nothing
        gvInconsistencias.DataSource = Nothing
        gvDeducMasivas.DataBind()
        gvInconsistencias.DataBind()
        gvDeducMasivas.Visible = False
        gvInconsistencias.Visible = False

        lblIdDeduccion.Text = String.Empty
        lblIdDeduccion2.Text = String.Empty
        lblDeduccion.Text = String.Empty
        lblDeduccion.Visible = False
        lblDeduccion2.Text = String.Empty
        lblDeduccion2.Visible = False

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MultiView1.SetActiveView(viewDeducciones)
            BindQnas()

            Procesa()
        End If
    End Sub

    Protected Sub btnImportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Dim TargetPath As String = String.Empty
        Dim strAnio As String
        Dim strQna As String

        strAnio = Left(ddlQnasAbiertasParaCaptura.SelectedItem.Text, 4)
        strQna = ddlQnasAbiertasParaCaptura.SelectedItem.Text

        TargetPath = ConfigurationManager.AppSettings("RutaImportarDeducciones")
        TargetPath = TargetPath + "\" + strAnio.ToString
        TargetPath = TargetPath + "\" + strQna.Replace("-", "_").ToString

        Dim Archivo As String = TargetPath + "\" + _
                                ddlDeducciones.SelectedItem.Text.Substring(1, 3) + ".txt"

        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsDeduccionesMasivas As DataSet
        Dim oQna As New Quincenas
        Dim dt As DataTable
        Dim sr As System.IO.StreamReader = Nothing
        Dim oEmp As New Empleado
        'Dim Importe As Decimal
        Try
            sr = New System.IO.StreamReader(Archivo, System.Text.Encoding.Default, True)

            dsDeduccionesMasivas = _DataCOBAEV.setDataSetDeduccionesMasivas()
            dsInconsistenciasDeducMasivas = _DataCOBAEV.setDataSetInconsistenciasDeducMasivas()

            While sr.Peek() <> -1
                Dim s As String = sr.ReadLine()

                If String.IsNullOrEmpty(s) Then
                    Continue While
                Else
                    Dim drDeduccionMasiva As DataRow
                    drDeduccionMasiva = dsDeduccionesMasivas.Tables(0).NewRow
                    drDeduccionMasiva(0) = s.Substring(0, 5)
                    If Not oEmp.EstaVigente(drDeduccionMasiva(0).ToString, ddlQnasAbiertasParaCaptura.SelectedValue) Then
                        LlenadrInconsistenciaDeducMasiva(s, 6)
                        Continue While
                    End If
                    Try
                        drDeduccionMasiva(1) = CDec(s.Substring(5, 8))
                        If CDec(s.Substring(5, 8)) <= 0 Then
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
                        drDeduccionMasiva(2) = 1 'CByte(s.Substring(13, 2))
                        'If CByte(s.Substring(13, 2)) <= 0 Then
                        If drDeduccionMasiva(2) <= 0 Then
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
                    drDeduccionMasiva(3) = CShort(ddlQnasAbiertasParaCaptura.SelectedValue)
                    drDeduccionMasiva(4) = ddlQnasAbiertasParaCaptura.SelectedItem.Text
                    'If CByte(s.Substring(13, 2)) = 1 Then
                    If drDeduccionMasiva(2) = 1 Then
                        drDeduccionMasiva(5) = CShort(ddlQnasAbiertasParaCaptura.SelectedValue)
                        drDeduccionMasiva(6) = ddlQnasAbiertasParaCaptura.SelectedItem.Text
                    Else
                        dt = oQna.ObtenParaVigFin(CShort(ddlQnasAbiertasParaCaptura.SelectedValue), drDeduccionMasiva(2))
                        drDeduccionMasiva(5) = CShort(dt.Rows(0).Item("IdQuincena"))
                        drDeduccionMasiva(6) = dt.Rows(0).Item("Quincena").ToString
                    End If
                    Try
                        dsDeduccionesMasivas.Tables(0).Rows.Add(drDeduccionMasiva)
                    Catch ex As Exception
                        Select Case ex.GetType().FullName
                            Case "System.Data.ConstraintException"
                                'Agregar a inconsistencias
                                'LlenadrInconsistenciaDeducMasiva(s, 2)
                                dsDeduccionesMasivas.Tables(0).Rows.Find(drDeduccionMasiva(0)).Item("ImporteDeduccion") = CDec(dsDeduccionesMasivas.Tables(0).Rows.Find(drDeduccionMasiva(0)).Item("ImporteDeduccion")) + drDeduccionMasiva(1)
                                Continue While
                        End Select
                    End Try
                    'Validamos que no exista duplicidad en la tabla donde insertaremos los registros
                    Dim oPlazasDeduccionesCantidadVariable As New PlazasDeduccionesCantidadVariable
                    With oPlazasDeduccionesCantidadVariable
                        .IdDeduccion = CShort(ddlDeducciones.SelectedValue)
                        .IdQnaVigIniDeduc = CShort(ddlQnasAbiertasParaCaptura.SelectedValue)
                        .ImpDeduc = CDec(s.Substring(5, 8))
                        If .ValidaSiExisteRegistro(s.Substring(0, 5)) = True Then
                            'Agregar a inconsistencias
                            LlenadrInconsistenciaDeducMasiva(s, 5)
                            Continue While
                        End If
                    End With
                End If
            End While
            sr.Close()
            gvDeducMasivas.DataSource = dsDeduccionesMasivas.Tables(0)
            gvDeducMasivas.DataBind()
            gvDeducMasivas.Visible = True
            btnGuardar.Visible = gvDeducMasivas.Rows.Count > 0
            gvInconsistencias.DataSource = dsInconsistenciasDeducMasivas.Tables(0)
            gvInconsistencias.DataBind()
            gvInconsistencias.Visible = True
            If gvInconsistencias.Rows.Count > 0 Then
                For Each drc As DataRow In dsInconsistenciasDeducMasivas.Tables(0).Rows
                    Select Case CShort(drc("IdError"))
                        Case 1, 5
                            dsDeduccionesMasivas.Tables(0).Rows.Find(drc("NumEmp")).Delete()
                            dsDeduccionesMasivas.Tables(0).AcceptChanges()
                    End Select
                Next
                gvDeducMasivas.DataSource = dsDeduccionesMasivas.Tables(0)
                gvDeducMasivas.DataBind()
            End If
            lblIdDeduccion.Text = ddlDeducciones.SelectedValue
            lblIdDeduccion2.Text = ddlDeducciones.SelectedValue
            lblDeduccion.Text = ddlDeducciones.SelectedItem.Text
            lblDeduccion.Visible = True
            lblDeduccion2.Text = ddlDeducciones.SelectedItem.Text
            lblDeduccion2.Visible = True
        Catch ex As Exception
            'sr.Close()
            lblError.Text = ex.Message
            MultiView1.Visible = False
            MultiView2.Visible = True
            MultiView2.SetActiveView(viewError)
        Finally
            sr.Close()
        End Try
    End Sub

    Protected Sub lbError_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbError.Click
        MultiView2.Visible = False
        MultiView1.Visible = True
        MultiView1.SetActiveView(viewDeducciones)
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
                oEmp.NumEmp = CType(e.Row.FindControl("lblNumEmp"), Label).Text
                dt = oEmp.Buscar(Empleado.TipoBusqueda.NumeroDeEmpleado, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
                If dt.Rows.Count > 0 Then
                    lblEmpleado.Text = dt.Rows(0).Item("Apellido_Paterno") + " " + dt.Rows(0).Item("Apellido_Materno") + " " + dt.Rows(0).Item("Nombre")
                Else
                    'Agregar a inconsistencias
                    Dim drInconsistenciaDeducMasiva As DataRow
                    drInconsistenciaDeducMasiva = dsInconsistenciasDeducMasivas.Tables(0).NewRow
                    drInconsistenciaDeducMasiva(0) = CType(e.Row.FindControl("lblNumEmp"), Label).Text
                    drInconsistenciaDeducMasiva(1) = CType(e.Row.FindControl("lblImporteDeduccion"), Label).Text
                    drInconsistenciaDeducMasiva(2) = CType(e.Row.FindControl("lblNumQnas"), Label).Text
                    drInconsistenciaDeducMasiva(3) = "Número de empleado inexistente."
                    drInconsistenciaDeducMasiva(4) = 1
                    dsInconsistenciasDeducMasivas.Tables(0).Rows.Add(drInconsistenciaDeducMasiva)
                End If
        End Select
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim oDeduc As New Deduccion
            For Each gvr As GridViewRow In gvDeducMasivas.Rows
                With oDeduc
                    .IdDeduccion = CShort(lblIdDeduccion.Text)
                    .ImporteDeduccion = CDec(CType(gvr.FindControl("lblImporteDeduccion"), Label).Text)
                    .IdQnaInicio = CShort(CType(gvr.FindControl("lblIdQnaIni"), Label).Text)
                    .IdQnaFin = CShort(CType(gvr.FindControl("lblIdQnaIni"), Label).Text) 'CShort(CType(gvr.FindControl("lblIdQnaFin"), Label).Text)
                    .InsMasiva(Deduccion.TipoInsercion.ParaPago, CType(gvr.FindControl("lblNumEmp"), Label).Text, CType(Session("ArregloAuditoria"), String()))
                End With
            Next
            MultiView1.SetActiveView(viewExito)
            lblExito.Text = "Proceso realizado correctamente."
        Catch ex As Exception
            lblError.Text = ex.Message
            MultiView1.Visible = False
            MultiView2.Visible = True
            MultiView2.SetActiveView(viewError)
        End Try
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim oDeduc As New Deduccion
            With oDeduc
                .DelMasiva(CShort(ddlDeducciones.SelectedValue), CShort(ddlQnasAbiertasParaCaptura.SelectedValue), CShort(ddlQnasAbiertasParaCaptura.SelectedValue), CType(Session("ArregloAuditoria"), String()))
            End With
            MultiView1.SetActiveView(viewExito)
            lblExito.Text = "Proceso realizado correctamente."
        Catch ex As Exception
            lblError.Text = ex.Message
            MultiView1.Visible = False
            MultiView2.Visible = True
            MultiView2.SetActiveView(viewError)
        End Try
    End Sub

    Protected Sub lbExito_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/ABC/Nomina/ImportarDeducciones.aspx?TipoOperacion=1")
    End Sub

    Protected Sub ddlQnasAbiertasParaCaptura_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlQnasAbiertasParaCaptura.SelectedIndexChanged
        Procesa()
    End Sub

    Protected Sub ddlDeducciones_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlDeducciones.SelectedIndexChanged
        btnImportar.Visible = True
        btnEliminar.Visible = True
        btnGuardar.Visible = False
        gvDeducMasivas.DataSource = Nothing
        gvInconsistencias.DataSource = Nothing
        gvDeducMasivas.DataBind()
        gvInconsistencias.DataBind()
        gvDeducMasivas.Visible = False
        gvInconsistencias.Visible = False

        lblIdDeduccion.Text = String.Empty
        lblIdDeduccion2.Text = String.Empty
        lblDeduccion.Text = String.Empty
        lblDeduccion.Visible = False
        lblDeduccion2.Text = String.Empty
        lblDeduccion2.Visible = False
    End Sub
End Class
