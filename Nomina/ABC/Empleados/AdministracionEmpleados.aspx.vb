Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Empleados.Sexos
Imports DataAccessLayer.COBAEV.Empleados.EstadosCiviles
Imports DataAccessLayer.COBAEV.Empleados.Nacionalidades
Imports DataAccessLayer.COBAEV.Mexico.Estados
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class ABC_Empleados_AdministracionEmpleados
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Public dr As DataRow
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindEstadosCiviles(Optional ByVal SelectedValue As String = "")
        Dim oEstadoCivil As New EstadoCivil
        Dim ddlSexos As DropDownList = CType(Me.dvDatosPers.FindControl("ddlSexos"), DropDownList)
        Dim ddlEstadosCiviles As DropDownList = CType(Me.dvDatosPers.FindControl("ddlEstadosCiviles"), DropDownList)
        If SelectedValue = String.Empty Then
            If CType(ddlSexos.SelectedValue, Byte) = 3 Then
                LlenaDDL(ddlEstadosCiviles, "DescEdoCivil", "IdEdoCivil", oEstadoCivil.ObtenTodos(), 99)
            Else
                LlenaDDL(ddlEstadosCiviles, "DescEdoCivil", "IdEdoCivil", oEstadoCivil.ObtenPorSexo(CType(ddlSexos.SelectedValue, Byte)), 99)
            End If
        Else
            LlenaDDL(ddlEstadosCiviles, "DescEdoCivil", "IdEdoCivil", oEstadoCivil.ObtenPorSexo(CType(ddlSexos.SelectedValue, Byte)), SelectedValue)
        End If
    End Sub
    Private Sub BindNacionalidades(Optional ByVal SelectedValue As String = "")
        Dim oNacionalidad As New Nacionalidad
        Dim ddlSexos As DropDownList = CType(Me.dvDatosPers.FindControl("ddlSexos"), DropDownList)
        Dim ddlNacionalidades As DropDownList = CType(Me.dvDatosPers.FindControl("ddlNacionalidades"), DropDownList)
        If SelectedValue = String.Empty Then
            If CType(ddlSexos.SelectedValue, Byte) = 3 Then
                LlenaDDL(ddlNacionalidades, "NomNacionalidad", "IdNacionalidad", oNacionalidad.ObtenTodas, 99)
            Else
                LlenaDDL(ddlNacionalidades, "NomNacionalidad", "IdNacionalidad", oNacionalidad.ObtenPorSexo(CType(ddlSexos.SelectedValue, Byte)), 99)
            End If
        Else
            LlenaDDL(ddlNacionalidades, "NomNacionalidad", "IdNacionalidad", oNacionalidad.ObtenPorSexo(CType(ddlSexos.SelectedValue, Byte)), SelectedValue)
        End If
    End Sub
    Private Sub BindSexos(Optional ByVal SelectedValue As String = "3")
        Dim oSexo As New Sexo
        Dim ddlSexos As DropDownList = CType(Me.dvDatosPers.FindControl("ddlSexos"), DropDownList)
        LlenaDDL(ddlSexos, "DescSexo", "IdSexo", oSexo.ObtenTodos(), SelectedValue)
    End Sub
    Private Sub BindEstados(Optional ByVal SelectedValue As String = "30")
        Dim oEstado As New Estado
        Dim ddlEstados As DropDownList = CType(Me.dvDatosPers.FindControl("ddlEstados"), DropDownList)
        LlenaDDL(ddlEstados, "NomEdo", "IdEdo", oEstado.ObtenTodos, SelectedValue)
    End Sub
    Private Sub BindPlantelesParaPago(Optional ByVal SelectedValue As String = "", Optional ByVal IdEmp As Integer = 0)
        Dim oPlantel As New Plantel
        Dim ddlPlantelesParaPago As DropDownList = CType(Me.dvDatosPers.FindControl("ddlPlantelesParaPago"), DropDownList)
        If SelectedValue <> String.Empty Then
            LlenaDDL(ddlPlantelesParaPago, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorEmp(IdEmp), SelectedValue)
        Else
            LlenaDDL(ddlPlantelesParaPago, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorUsr(Session("Login")), SelectedValue)
        End If
    End Sub
    Private Sub BindNumEmp(Optional ByVal NumEmp As String = "")
        Dim oEmp As New Empleado
        Dim txtbxNumEmp As TextBox = CType(Me.dvDatosPers.FindControl("txtbxNumEmp"), TextBox)
        Dim hfNumEmp As HiddenField = CType(Me.dvDatosPers.FindControl("hfNumEmp"), HiddenField)
        If Request.Params("TipoOperacion") = "0" Then 'Actualizar
            txtbxNumEmp.Text = NumEmp
        ElseIf Request.Params("TipoOperacion") = "1" Then
            txtbxNumEmp.Text = oEmp.ObtenSigNumEmp("NumEmp").ToString
        End If
        hfNumEmp.Value = txtbxNumEmp.Text
    End Sub
    Private Sub BindEsMama(Optional ByVal EsMama As String = "")
        Dim ddlSexos As DropDownList = CType(Me.dvDatosPers.FindControl("ddlSexos"), DropDownList)
        Dim ddlEsMama As DropDownList = CType(Me.dvDatosPers.FindControl("ddlEsMama"), DropDownList)
        Select Case ddlSexos.SelectedValue
            Case 1 'Femenino
                If EsMama = String.Empty Then
                    ddlEsMama.SelectedValue = "1"
                    ddlEsMama.Items(2).Enabled = False
                    ddlEsMama.Enabled = True
                Else
                    Select Case EsMama
                        Case "Sí"
                            ddlEsMama.SelectedValue = "0"
                            ddlEsMama.Items(2).Enabled = False
                            ddlEsMama.Enabled = True
                        Case "No"
                            ddlEsMama.SelectedValue = "1"
                            ddlEsMama.Items(2).Enabled = False
                            ddlEsMama.Enabled = True
                    End Select
                End If
            Case 2, 3 'Masculino, Sin especificar
                ddlEsMama.SelectedValue = "2"
                ddlEsMama.Items(2).Enabled = True
                ddlEsMama.Enabled = False
        End Select
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim lblIdEmp As Label = CType(Me.dvDatosPers.FindControl("lblIdEmp"), Label)
            Dim txtbxRFC As TextBox = CType(Me.dvDatosPers.FindControl("txtbxRFC"), TextBox)
            Dim txtbxCURP As TextBox = CType(Me.dvDatosPers.FindControl("txtbxCURP"), TextBox)
            Dim txtbxApePat As TextBox = CType(Me.dvDatosPers.FindControl("txtbxApePat"), TextBox)
            Dim txtbxApeMat As TextBox = CType(Me.dvDatosPers.FindControl("txtbxApeMat"), TextBox)
            Dim txtbxNombre As TextBox = CType(Me.dvDatosPers.FindControl("txtbxNombre"), TextBox)
            Dim txtbxFecNac As TextBox = CType(Me.dvDatosPers.FindControl("txtbxFecNac"), TextBox)
            Dim txtbxEmail As TextBox = CType(Me.dvDatosPers.FindControl("txtbxEmail"), TextBox)
            Dim hfFecNac As HiddenField = CType(Me.dvDatosPers.FindControl("hfFecNac"), HiddenField)
            Dim ibFecNac As ImageButton = CType(Me.dvDatosPers.FindControl("ibFecNac"), ImageButton)
            If Request.Params("TipoOperacion") = "0" Then 'Actualizar
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Dim oEmp As New Empleado
                Dim dr As DataRow
                oEmp.RFC = Request.Params("RFCEmp")
                dr = oEmp.ObtenDatosPersonales().Rows(0)
                lblIdEmp.Text = dr("IdEmp")
                txtbxRFC.Text = dr("RFCEmp")
                txtbxCURP.Text = dr("CURPEmp")
                txtbxApePat.Text = dr("ApePatEmp")
                txtbxApeMat.Text = dr("ApeMatEmp")
                txtbxNombre.Text = dr("NomEmp")
                BindSexos(dr("IdSexo"))
                BindNacionalidades(dr("IdNacionalidad"))
                BindEstadosCiviles(dr("IdEdoCivil"))
                BindEstados(dr("IdEdo"))
                txtbxFecNac.Text = dr("FecNacEmp")
                ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + txtbxFecNac.ClientID + "','" + hfFecNac.ClientID + "'); return false")
                BindEsMama(dr("Mama"))
                txtbxEmail.Text = dr("Email")
                BindNumEmp(dr("NumEmp"))
                BindPlantelesParaPago(dr("IdPlantel").ToString, CInt(dr("IdEmp")))
                'CType(Me.dvDatosPers.FindControl("btnNumEmp"), Button).Enabled = False
            ElseIf Request.Params("TipoOperacion") = "1" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                lblIdEmp.Text = "0"
                BindSexos()
                BindNacionalidades()
                BindEstadosCiviles()
                BindEstados()
                ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + txtbxFecNac.ClientID + "','" + hfFecNac.ClientID + "'); return false")
                BindEsMama()
                BindPlantelesParaPago()
                'BindNumEmp()
            End If
        End If
    End Sub
    Protected Sub ddlSexos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindNacionalidades()
        BindEstadosCiviles()
        BindEsMama()
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtbxRFC As TextBox = CType(Me.dvDatosPers.FindControl("txtbxRFC"), TextBox)
            Dim txtbxCURP As TextBox = CType(Me.dvDatosPers.FindControl("txtbxCURP"), TextBox)

            'Código de validación
            Dim oValidacion As New Validaciones
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsValida As DataSet
            dsValida = _DataCOBAEV.setDataSetErrores()

            With oValidacion
                .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
                .RFC = txtbxRFC.Text.Trim
                .CURPEmp = txtbxCURP.Text.Trim
                If Not .ValidaPaginasOperacion(dsValida) Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina.aspx?Home=SI")
                Else
                    Session.Remove("dsValida")
                End If
            End With
            'Código de validación

            Dim lblIdEmp As Label = CType(Me.dvDatosPers.FindControl("lblIdEmp"), Label)
            'Dim txtbxRFC As TextBox = CType(Me.dvDatosPers.FindControl("txtbxRFC"), TextBox)
            'Dim txtbxCURP As TextBox = CType(Me.dvDatosPers.FindControl("txtbxCURP"), TextBox)
            Dim txtbxApePat As TextBox = CType(Me.dvDatosPers.FindControl("txtbxApePat"), TextBox)
            Dim txtbxApeMat As TextBox = CType(Me.dvDatosPers.FindControl("txtbxApeMat"), TextBox)
            Dim txtbxNombre As TextBox = CType(Me.dvDatosPers.FindControl("txtbxNombre"), TextBox)
            Dim ddlSexos As DropDownList = CType(Me.dvDatosPers.FindControl("ddlSexos"), DropDownList)
            Dim ddlNacionalidades As DropDownList = CType(Me.dvDatosPers.FindControl("ddlNacionalidades"), DropDownList)
            Dim ddlEstadosCiviles As DropDownList = CType(Me.dvDatosPers.FindControl("ddlEstadosCiviles"), DropDownList)
            Dim ddlEstados As DropDownList = CType(Me.dvDatosPers.FindControl("ddlEstados"), DropDownList)
            Dim txtbxFecNac As TextBox = CType(Me.dvDatosPers.FindControl("txtbxFecNac"), TextBox)
            Dim ddlEsMama As DropDownList = CType(Me.dvDatosPers.FindControl("ddlEsMama"), DropDownList)
            Dim hfNumEmp As HiddenField = CType(Me.dvDatosPers.FindControl("hfNumEmp"), HiddenField)
            Dim txtbxNumEmp As TextBox = CType(Me.dvDatosPers.FindControl("txtbxNumEmp"), TextBox)
            Dim ddlPlantelesParaPago As DropDownList = CType(Me.dvDatosPers.FindControl("ddlPlantelesParaPago"), DropDownList)
            Dim txtbxEmail As TextBox = CType(Me.dvDatosPers.FindControl("txtbxEmail"), TextBox)
            Dim oEmpleado As New Empleado
            With oEmpleado
                .IdEmp = CInt(lblIdEmp.Text)
                .RFC = txtbxRFC.Text.Trim.ToUpper
                .CURPEmp = txtbxCURP.Text.Trim.ToUpper
                .ApePatEmp = txtbxApePat.Text.Trim.ToUpper
                .ApeMatEmp = txtbxApeMat.Text.Trim.ToUpper
                .NomEmp = txtbxNombre.Text.Trim.ToUpper
                'If Request.Params("TipoOperacion") Is Nothing Then
                '    .EstatusEmp = 
                'Else
                '    .EstatusEmp = 1
                'End If
                If Request.Params("TipoOperacion") = "0" Then
                    .Actualizar(0, CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .Insertar(CType(Session("ArregloAuditoria"), String()))
                End If
                .IdSexo = CType(ddlSexos.SelectedValue, Integer)
                .IdNacionalidad = CType(ddlNacionalidades.SelectedValue, Short)
                .IdEdoCivil = CType(ddlEstadosCiviles.SelectedValue, Byte)
                .IdEdo = CType(ddlEstados.SelectedValue, Byte)
                .FecNacEmp = CType(txtbxFecNac.Text, Date)
                .Email = txtbxEmail.Text.Trim.ToUpper
                If Request.Params("TipoOperacion") = "0" Then
                    .ActualizarDatosPersonales(0, CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .InsertarDatosPersonales(CType(Session("ArregloAuditoria"), String()))
                End If

                If Request.Params("TipoOperacion") = "0" Then
                    .ActualizarMamas(0, IIf(ddlEsMama.SelectedValue = "0", True, False), CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .InsertarMamas(IIf(ddlEsMama.SelectedValue = "0", True, False), CType(Session("ArregloAuditoria"), String()))
                End If

                If txtbxNumEmp.Text.Trim = String.Empty Then txtbxNumEmp.Text = "0"
                .NumEmp = IIf(CInt(txtbxNumEmp.Text.Trim) > 0, txtbxNumEmp.Text.Trim, "")
                .IdPlantel = CShort(ddlPlantelesParaPago.SelectedValue)
                If Request.Params("TipoOperacion") = "0" Then
                    .ActualizarDatosLaborales2(0, CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .InsertarDatosLaborales2(CType(Session("ArregloAuditoria"), String()))
                End If

                Session.Add("RFCParaCons", .RFC)
                Session.Add("CURPParaCons", .CURPEmp)
                Session.Add("ApePatParaCons", .ApePatEmp)
                Session.Add("ApeMatParaCons", .ApeMatEmp)
                Session.Add("NombreParaCons", .NomEmp)
                Session.Add("NumEmpParaCons", .NumEmp)
            End With
            Me.MultiView1.SetActiveView(viewCapturaExitosa)
        Catch Ex As Exception
            Dim Indice As Int32
            Indice = Ex.Message.IndexOf("Error:", 0)
            If Indice <> -1 Then
                Me.lblErrores.Text = Ex.Message.Substring(Indice, Ex.Message.Length - Indice)
                Me.MultiView1.SetActiveView(Me.viewErrores)
            End If
        End Try
    End Sub

    Protected Sub btnGeneraRFC_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.dvDatosPers.FindControl("txtbxRFC"), TextBox)
        Dim txtbxCURP As TextBox = CType(Me.dvDatosPers.FindControl("txtbxCURP"), TextBox)
        Dim txtbxApePat As TextBox = CType(Me.dvDatosPers.FindControl("txtbxApePat"), TextBox)
        Dim txtbxApeMat As TextBox = CType(Me.dvDatosPers.FindControl("txtbxApeMat"), TextBox)
        Dim txtbxNombre As TextBox = CType(Me.dvDatosPers.FindControl("txtbxNombre"), TextBox)
        Dim txtbxFecNac As TextBox = CType(Me.dvDatosPers.FindControl("txtbxFecNac"), TextBox)
        Dim ddlSexos As DropDownList = CType(Me.dvDatosPers.FindControl("ddlSexos"), DropDownList)
        Dim ddlEstados As DropDownList = CType(Me.dvDatosPers.FindControl("ddlEstados"), DropDownList)
        With oEmp
            .ApePatEmp = txtbxApePat.Text.ToUpper.Trim
            .ApeMatEmp = txtbxApeMat.Text.ToUpper.Trim
            .NomEmp = txtbxNombre.Text.ToUpper.Trim
            .FecNacEmp = CType(txtbxFecNac.Text, Date)
            txtbxRFC.Text = oEmp.GenerarRFC()
            .IdSexo = CType(ddlSexos.SelectedValue, Byte)
            .IdEdo = CType(ddlEstados.SelectedValue, Byte)
            txtbxCURP.Text = oEmp.GenerarCURP()
        End With
    End Sub

    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub

    Protected Sub btnNumEmp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindNumEmp()
    End Sub
    Protected Sub txtbxCURP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtbxCURP As TextBox = CType(Me.dvDatosPers.FindControl("txtbxCURP"), TextBox)
            Dim txtbxRFC As TextBox = CType(Me.dvDatosPers.FindControl("txtbxRFC"), TextBox)
            Dim txtbxFecNac As TextBox = CType(Me.dvDatosPers.FindControl("txtbxFecNac"), TextBox)
            Dim hfFecNac As HiddenField = CType(Me.dvDatosPers.FindControl("hfFecNac"), HiddenField)
            Dim ddlEstados As DropDownList = CType(Me.dvDatosPers.FindControl("ddlEstados"), DropDownList)
            Dim Año As String
            Dim oEdo As New Estado
            Dim oSexo As New Sexo
            Dim dt, dt2 As DataTable

            If txtbxRFC.Text.Trim = String.Empty And txtbxCURP.Text.Trim.Length >= 10 Then
                txtbxRFC.Text = txtbxCURP.Text.Substring(0, 10)
            End If
            If txtbxCURP.Text.Trim.Length >= 11 Then
                dt2 = oSexo.ObtenPorAbrevCURP(txtbxCURP.Text.Substring(10, 1))
                ddlSexos.SelectedValue = dt2.Rows(0).Item("IdSexo")
                BindNacionalidades()
                BindEstadosCiviles()
                BindEsMama()
            End If
            If txtbxCURP.Text.Trim.Length >= 13 Then
                dt = oEdo.ObtenPorDescCortaCURP(txtbxCURP.Text.Substring(11, 2))
                ddlEstados.SelectedValue = dt.Rows(0).Item("IdEdo")
            End If
            If txtbxCURP.Text.Trim <> String.Empty And txtbxCURP.Text.Trim.Length >= 10 Then
                Año = String.Empty
                If IsNumeric(txtbxCURP.Text.Substring(4, 2)) Then
                    If CInt(txtbxCURP.Text.Substring(4, 2)) > CInt(Date.Today.Year.ToString.Substring(2, 2)) Then
                        Año = "19"
                    Else
                        Año = "20"
                    End If
                End If
                If Año <> String.Empty Then
                    txtbxFecNac.Text = txtbxCURP.Text.Substring(8, 2) + "/" + txtbxCURP.Text.Substring(6, 2) + "/" + Año _
                                        + txtbxCURP.Text.Substring(4, 2)
                    If IsDate(txtbxFecNac.Text) Then
                        hfFecNac.Value = txtbxFecNac.Text
                    Else
                        txtbxFecNac.Text = String.Empty
                        hfFecNac.Value = String.Empty
                    End If
                End If
            End If
        Catch
        End Try
    End Sub

    Protected Sub txtbxRFC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtbxRFC As TextBox = CType(Me.dvDatosPers.FindControl("txtbxRFC"), TextBox)
            Dim txtbxCURP As TextBox = CType(Me.dvDatosPers.FindControl("txtbxCURP"), TextBox)
            Dim txtbxFecNac As TextBox = CType(Me.dvDatosPers.FindControl("txtbxFecNac"), TextBox)
            Dim hfFecNac As HiddenField = CType(Me.dvDatosPers.FindControl("hfFecNac"), HiddenField)
            Dim Año As String
            If txtbxCURP.Text.Trim = String.Empty And txtbxRFC.Text.Trim.Length >= 10 Then
                txtbxCURP.Text = txtbxRFC.Text.Substring(0, 10)
            End If
            If txtbxRFC.Text.Trim <> String.Empty And txtbxRFC.Text.Trim.Length >= 10 Then
                Año = String.Empty
                If IsNumeric(txtbxRFC.Text.Substring(4, 2)) Then
                    If CInt(txtbxRFC.Text.Substring(4, 2)) > CInt(Date.Today.Year.ToString.Substring(2, 2)) Then
                        Año = "19"
                    Else
                        Año = "20"
                    End If
                End If
                If Año <> String.Empty Then
                    txtbxFecNac.Text = txtbxRFC.Text.Substring(8, 2) + "/" + txtbxRFC.Text.Substring(6, 2) + "/" + Año _
                                    + txtbxRFC.Text.Substring(4, 2)
                    If IsDate(txtbxFecNac.Text) Then
                        hfFecNac.Value = txtbxFecNac.Text
                    Else
                        txtbxFecNac.Text = String.Empty
                        hfFecNac.Value = String.Empty
                    End If
                End If
            End If
        Catch
        End Try
    End Sub
End Class
