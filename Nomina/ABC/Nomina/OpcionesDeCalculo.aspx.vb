Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.Threading
Imports BusinessRulesLayer.COBAEV.Validaciones

Partial Class ABC_Nomina_OpcionesDeCalculo
    Inherits System.Web.UI.Page

    Private ThreadCalculo As Thread
    Private dtErroresCalculoNomina As DataTable

    Private Sub EliminaInfQuincena(Optional ByVal RFC As String = "", Optional ByVal pZonaGeo As Byte = 0, _
                                    Optional pIdQuincena As Short = 0)
        Dim oNom As New Nomina
        Dim oZonaGeo As New Zonageografica
        Dim dtPlanteles As DataTable

        oZonaGeo.ObtenPlanteles()
        Select Case Request.Params("TipoCalculo")
            Case "0"
                oNom.EliminaPagoQuincenal(CType(Me.ddlQnasParaCalculo.SelectedValue, Short), CType(Session("ArregloAuditoria"), String()))
            Case "1"
                oNom.EliminaPagoQuincenal(CType(Me.ddlQnasParaCalculo.SelectedValue, Short), CType(Me.ddlPlanteles.SelectedValue, Short), CType(Session("ArregloAuditoria"), String()))
            Case "2"
                oNom.EliminaPagoQuincenal(CType(Me.ddlQnasParaCalculo.SelectedValue, Short), RFC, CType(Session("ArregloAuditoria"), String()))
            Case "3"
                dtPlanteles = oZonaGeo.ObtenPlanteles(pZonaGeo, pIdQuincena)

                For Each drPlantel As DataRow In dtPlanteles.Rows
                    oNom.EliminaPagoQuincenal(CType(Me.ddlQnasParaCalculo.SelectedValue, Short), CShort(drPlantel("IdPlantel")), CType(Session("ArregloAuditoria"), String()))
                Next
        End Select
    End Sub
    Private Sub EliminaVarsDeSesion()
        Session.Remove("CalculandoNomina")
        Session.Remove("Plantel")
        Session.Remove("Empleado")
        Session.Remove("Plantel2")
        Session.Remove("Empleado2")
    End Sub
    Private Sub CalculaNomina(pTipoCalculo As String)
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsErrores As DataSet  '03/12/2013
        Dim drError As DataRow '03/12/2013
        Dim arregloRFC As New ArrayList '--  ACTUALIZACION EMPLEADO
        Dim RFC As String '--  ACTUALIZACION EMPLEADO
        Dim Encontrado As Boolean '--  ACTUALIZACION EMPLEADO

        dsErrores = _DataCOBAEV.setDataSetErrsCalculoNomina() '03/12/2013

        If Session("CalculandoNomina") = True Then  '22/09/2009
            Dim oPlantel As New Plantel
            Dim oEmpleado As New Empleado
            Dim dtPlanteles As DataTable = Nothing
            Dim dtEmpleados As DataTable
            Dim drPlantel, drEmpleado As DataRow
            Dim oNom As New Nomina
            Dim dtEmpsPensionAlimenticia As DataTable = Nothing
            Dim drEmpsPensionAlimenticia As DataRow
            Dim oZonaGeo As New Zonageografica

            'If Request.Params("TipoCalculo") = "0" Then
            If pTipoCalculo = "0" Then 'Cálculo general
                dtPlanteles = oPlantel.ObtenTodos(True)
            ElseIf pTipoCalculo = "1" Then 'Cálculo por plantel
                If Me.ChkBxCalculoHaciaAdelante.Checked Then
                    dtPlanteles = oPlantel.ObtenTodos(CShort(Me.ddlPlanteles.SelectedValue), True)
                Else
                    dtPlanteles = oPlantel.ObtenPorId(CShort(Me.ddlPlanteles.SelectedValue))
                End If
            ElseIf pTipoCalculo = "3" Then 'Cálculo por zona geográfica
                If Me.ChkBxCalculoHaciaAdelanteZG.Checked Then
                    dtPlanteles = oZonaGeo.ObtenPlanteles(CByte(ddlZonasGeo.SelectedValue), CShort(ddlQnasParaCalculo.SelectedValue), True)
                Else
                    dtPlanteles = oZonaGeo.ObtenPlanteles(CByte(ddlZonasGeo.SelectedValue), CShort(ddlQnasParaCalculo.SelectedValue))
                End If
            End If
            System.Threading.Thread.Sleep(5000)  '22/09/2009
            For Each drPlantel In dtPlanteles.Rows
                'If Me.ChkBxCalculoHaciaAdelante.Checked Then
                oNom.EliminaPagoQuincenal(CType(Me.ddlQnasParaCalculo.SelectedValue, Short),
                                            CShort(drPlantel("IdPlantel").ToString),
                                            CType(Session("ArregloAuditoria"), String()))
                'End If
                If Session("CalculandoNomina") Is Nothing Then  '22/09/2009
                    ThreadCalculo.Abort() '22/09/2009
                    Exit Sub  '22/09/2009
                End If '22/09/2009
                If pTipoCalculo = "3" Then 'Cálculo por zona geográfica
                    Session("Plantel") = "Calculando nómina a empleados de la " + drPlantel("NombreZonaGeografica").ToString + ", plantel: " ' 24/08/2015
                Else
                    Session("Plantel") = "Calculando nómina a empleados del plantel: " ' 22/09/2009
                End If
                'Session("Plantel") = "Calculando nómina a empleados del plantel: " ' 22/09/2009
                Session("Plantel2") = drPlantel("DescPlantel").ToString  '22/09/2009

                dtEmpleados = oEmpleado.ObtenPorPlantel(CShort(drPlantel("IdPlantel").ToString),
                                                        True, CShort(Me.ddlQnasParaCalculo.SelectedValue))

                arregloRFC.Clear() '--  ACTUALIZACION EMPLEADO
                For Each drEmpleado In dtEmpleados.Rows

                    If Session("CalculandoNomina") Is Nothing Then ' 22/09/2009
                        ThreadCalculo.Abort()  '22/09/2009
                        Exit Sub  '22/09/2009
                    End If  '22/09/2009
                    Session("Empleado") = "Empleado: "  '22/09/2009 '--  ACTUALIZACION EMPLEADO
                    Session("Empleado2") = drEmpleado("ApePatEmp").ToString +
                                        " " + drEmpleado("ApeMatEmp") + " " + drEmpleado("NomEmp")  '22/09/2009 '--  ACTUALIZACION EMPLEADO
                    oEmpleado.RFC = drEmpleado("RFC").ToString
                    Try
                        Encontrado = False '--  ACTUALIZACION EMPLEADO
                        If arregloRFC Is Nothing = False Then
                            For Each RFC In arregloRFC
                                If RFC = oEmpleado.RFC Then
                                    Encontrado = True
                                End If
                            Next
                        End If '--  ACTUALIZACION EMPLEADO

                        If Encontrado = False Then '--  ACTUALIZACION EMPLEADO
                            oEmpleado.CalculaPagoQuincenal(CType(Me.ddlQnasParaCalculo.SelectedValue, Short),
                                                       CType(Session("ArregloAuditoria"), String()))
                            arregloRFC.Add(oEmpleado.RFC) '--  ACTUALIZACION EMPLEADO
                        End If '--  ACTUALIZACION EMPLEADO
                    Catch ex As Exception
                        drError = dsErrores.Tables(0).NewRow()
                        drError(0) = oEmpleado.RFC
                        drError(1) = ex.Message
                        dsErrores.Tables(0).Rows.Add(drError)
                        Session("miTabla") = dsErrores.Tables(0)
                    End Try
                Next

                Session("Plantel") = "Calculando nómina a empleados de otros planteles con " + _
                                        "beneficiarios de pensión alimenticia en el plantel: "
                Session("Plantel2") = drPlantel("DescPlantel").ToString
                dtEmpsPensionAlimenticia = oEmpleado.ObtenEmpsParaCalcDePensionAlim(CShort(drPlantel("IdPlantel").ToString), _
                                                                                    CShort(Me.ddlQnasParaCalculo.SelectedValue))
                For Each drEmpsPensionAlimenticia In dtEmpsPensionAlimenticia.Rows
                    Session("Empleado") = "Empleado del plantel " + drEmpsPensionAlimenticia("DescPlantel2") + ": "
                    Session("Empleado2") = drEmpsPensionAlimenticia("ApePatEmp").ToString + _
                                        " " + drEmpsPensionAlimenticia("ApeMatEmp") + " " + drEmpsPensionAlimenticia("NomEmp")
                    oEmpleado.RFC = drEmpsPensionAlimenticia("RFCEmp").ToString
                    oNom.EliminaPagoQuincenal(CType(Me.ddlQnasParaCalculo.SelectedValue, Short), _
                                              drEmpsPensionAlimenticia("RFCEmp").ToString, _
                                              CType(Session("ArregloAuditoria"), String()))
                    Try
                        oEmpleado.CalculaPagoQuincenal(CType(Me.ddlQnasParaCalculo.SelectedValue, Short), _
                                                       CType(Session("ArregloAuditoria"), String()))
                        'dtEmpsPensionAlimenticia.Rows.Remove(drEmpsPensionAlimenticia)
                    Catch ex As Exception
                        drError = dsErrores.Tables(0).NewRow()
                        drError(0) = oEmpleado.RFC
                        drError(1) = ex.Message
                        dsErrores.Tables(0).Rows.Add(drError)
                        Session("miTabla") = dsErrores.Tables(0)
                    End Try
                Next
            Next

            lblCalcFin.Text = "Cálculo finalizado." '22/09/2009
            Session("Plantel") = "Cálculo finalizado."  '22/09/2009
            System.Threading.Thread.Sleep(5000) '22/09/2009
            EliminaVarsDeSesion() '22/09/2009
        End If  '22/09/2009
    End Sub
    Private Sub BindQnas()
        Dim oQna As New Quincenas
        With Me.ddlQnasParaCalculo
            .DataSource = oQna.ObtenListasParaCalculo
            .DataTextField = "QuincenaObservs"
            .DataValueField = "IdQuincena"
            .DataBind()
            '.Items.Insert(0, "201503")
            '.Items(0).Value = 2076
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas listas para cálculo")
                .Items(0).Value = -1
                Me.btnCalcular.Enabled = False
            End If
        End With
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub ValidaOperacion(Optional ByVal TipoOperacion As Byte = 1)
        'Código de validación
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            .TipoOperacion = TipoOperacion
            .RFC = Session("RFCParaCons")
            .IdQuincena = CShort(Me.ddlQnasParaCalculo.SelectedValue)
            If Not .ValidaPaginasOperacion(dsValida) Then
                Session.Add("dsValida", dsValida)
                Response.Redirect("~/ErroresPagina.aspx")
            Else
                Session.Remove("dsValida")
            End If
        End With
        'Código de validación
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            EliminaVarsDeSesion()  '22/09/2009
            Dim oQna As New Quincenas
            Select Case Request.Params("TipoCalculo")
                Case "0"
                    Me.MultiView1.SetActiveView(Me.viewCalculoGeneral)
                    Me.btnCalcular.Enabled = True
                Case "1"
                    Me.MultiView1.SetActiveView(Me.viewCalculoPlantel)
                    Dim oPlantel As New Plantel
                    LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True))
                    Me.btnCalcular.Enabled = True
                Case "2"
                    'Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
                    'Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
                    Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
                    'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
                    'Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
                    'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false")
                    If hfRFC.Value = String.Empty Or Me.ddlQnasParaCalculo.SelectedValue = "-1" Then
                        'Me.Timer2.Enabled = True
                        'Me.btnCalcular.Enabled = False
                    Else
                        Me.btnCalcular.Enabled = True
                    End If
                    Me.MultiView1.SetActiveView(Me.viewCalculoPersona)
                Case "3"
                    Me.MultiView1.SetActiveView(Me.viewCalculoPorZonaGeo)
                    Dim oZonaGeo As New Zonageografica
                    LlenaDDL(ddlZonasGeo, "NombreZonaGeografica", "IdZonaGeografica", oZonaGeo.ObtenTodas())
                    Me.btnCalcular.Enabled = True
            End Select
            BindQnas()
        End If
    End Sub
    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Dim dtErroresCalculoNomina As DataTable
        If Session("Plantel") <> String.Empty Then
            Me.lblPlantel.Text = Session("Plantel")
            Me.lblPlantel2.Text = Session("Plantel2")
            If DirectCast(Session("miTabla"), DataTable) Is Nothing = False Then
                gvErrores3.EmptyDataText = "Sin errores"
                gvErrores3.DataSource = DirectCast(Session("miTabla"), DataTable)
                gvErrores3.DataBind()
                gvErrores3.Visible = True
            End If
        End If
        If Session("Empleado") <> String.Empty Then
            Me.lblEmpleado.Text = Session("Empleado")
            Me.lblEmpleado2.Text = Session("Empleado2")
            If DirectCast(Session("miTabla"), DataTable) Is Nothing = False Then
                gvErrores3.EmptyDataText = "Sin errores"
                gvErrores3.DataSource = DirectCast(Session("miTabla"), DataTable)
                gvErrores3.DataBind()
                gvErrores3.Visible = True
            End If
        End If
        If Me.lblPlantel.Text = "Cálculo finalizado." Then
            If DirectCast(Session("miTabla"), DataTable) Is Nothing = False Then
                gvErrores3.EmptyDataText = "No hubo errores"
                gvErrores3.DataSource = DirectCast(Session("miTabla"), DataTable)
                gvErrores3.DataBind()
                gvErrores3.Visible = True
            End If
            Me.imgCalculando_Op2.Visible = False
            Me.lblPlantel2.Visible = False
            Me.lblEmpleado.Visible = False
            Me.lblEmpleado2.Visible = False
            'dtErroresCalculoNomina = CType(Session("dtErroresCalculoNomina"), DataTable)
            'gvErrores3.DataSource = dtErroresCalculoNomina
            'gvErrores3.DataBind()
            'gvErrores3.Visible = dtErroresCalculoNomina.Rows.Count > 0
            Me.Timer1.Enabled = False
        End If
    End Sub
    Protected Sub btnCalcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        If ThreadCalculo Is Nothing Then
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsErrores As DataSet
            Dim drError As DataRow
            Dim hfRFC As HiddenField = Nothing

            dsErrores = _DataCOBAEV.setDataSetErrsCalculoNomina()

            EliminaVarsDeSesion()
            Select Case Request.Params("TipoCalculo")
                Case "0"
                    Session.Add("CalculandoNomina", True)  '22/09/2009
                    Session.Add("Plantel", "")  '22/09/2009
                    Session.Add("Empleado", "")  '22/09/2009
                    Session.Add("Plantel2", "")  '22/09/2009
                    Session.Add("Empleado2", "")  '22/09/2009
                    Session("miTabla") = dsErrores.Tables(0)
                    Me.lblPlantel.Visible = True '22/09/2009
                    Me.lblPlantel2.Visible = True '22/09/2009
                    Me.lblEmpleado.Visible = True '22/09/2009
                    Me.lblEmpleado2.Visible = True '22/09/2009
                    Me.imgCalculando_Op2.Visible = True '22/09/2009
                    Me.Timer1.Enabled = True '22/09/2009
                    Me.ddlQnasParaCalculo.Enabled = False
                    Me.btnCalcular.Enabled = False
                    EliminaInfQuincena()
                    ' CalculaNomina() '22/09/2009
                    ThreadCalculo = New Thread(AddressOf CalculaNomina) '22/09/2009
                    ThreadCalculo.Start(Request.Params("TipoCalculo"))  '22/09/2009
                Case "1"
                    Session.Add("CalculandoNomina", True)
                    Session.Add("Plantel", "")
                    Session.Add("Empleado", "")
                    Session.Add("Plantel2", "")
                    Session.Add("Empleado2", "")
                    Session("miTabla") = dsErrores.Tables(0)
                    Me.lblPlantel_Op1.Visible = True
                    Me.lblPlantel2_Op1.Visible = True
                    Me.lblEmpleado_Op1.Visible = True
                    Me.lblEmpleado2_Op1.Visible = True
                    Me.imgCalculando_Op1.Visible = True
                    Me.lblPlantel_Op1.Text = "Preparando entorno para iniciar el cálculo, por favor espere..."
                    lblPlantel2_Op1.Text = String.Empty
                    lblEmpleado_Op1.Text = String.Empty
                    lblEmpleado2_Op1.Text = String.Empty
                    Me.Timer3.Enabled = True
                    Me.ddlQnasParaCalculo.Enabled = False
                    Me.btnCalcular.Enabled = False
                    Me.ddlPlanteles.Enabled = False
                    Me.ChkBxCalculoHaciaAdelante.Enabled = False
                    EliminaInfQuincena()
                    ThreadCalculo = New Thread(AddressOf CalculaNomina)
                    ThreadCalculo.Start(Request.Params("TipoCalculo"))
                Case "2"
                    Try
                        ValidaOperacion()
                        Me.btnCalcular.Enabled = False
                        Dim oEmp As New Empleado
                        hfRFC = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
                        EliminaInfQuincena(hfRFC.Value)
                        oEmp.RFC = hfRFC.Value
                        oEmp.CalculaPagoQuincenal(CType(Me.ddlQnasParaCalculo.SelectedValue, Short), _
                                                    CType(Session("ArregloAuditoria"), String()))
                        Me.lblCalculoPersonaFinalizado.Visible = True
                        Me.lbNuevoCalculo.Visible = True
                        gvErrores1.DataBind()
                        gvErrores1.Visible = True
                    Catch ex As Exception
                        drError = dsErrores.Tables(0).NewRow()
                        drError(0) = hfRFC.Value
                        drError(1) = ex.Message
                        dsErrores.Tables(0).Rows.Add(drError)
                        gvErrores1.DataSource = dsErrores.Tables(0)
                        gvErrores1.DataBind()
                        gvErrores1.Visible = True
                    End Try
                Case "3"
                    Session.Add("CalculandoNomina", True)
                    Session.Add("Plantel", "")
                    Session.Add("Empleado", "")
                    Session.Add("Plantel2", "")
                    Session.Add("Empleado2", "")
                    Session("miTabla") = dsErrores.Tables(0)
                    Me.lblZonaGeo_Op1.Visible = True
                    Me.lblZonaGeo2_Op1.Visible = True
                    Me.lblEmpleado_Op2.Visible = True
                    Me.lblEmpleado2_Op2.Visible = True
                    Me.imgCalculando_Op3.Visible = True
                    Me.lblZonaGeo_Op1.Text = "Preparando entorno para iniciar el cálculo, por favor espere..."
                    lblZonaGeo2_Op1.Text = String.Empty
                    lblEmpleado_Op2.Text = String.Empty
                    lblEmpleado2_Op2.Text = String.Empty
                    Me.Timer4.Enabled = True
                    Me.ddlQnasParaCalculo.Enabled = False
                    Me.btnCalcular.Enabled = False
                    Me.ddlZonasGeo.Enabled = False
                    Me.ChkBxCalculoHaciaAdelanteZG.Enabled = False
                    EliminaInfQuincena("", CByte(ddlZonasGeo.SelectedValue), CShort(ddlQnasParaCalculo.SelectedValue))
                    ThreadCalculo = New Thread(AddressOf CalculaNomina)
                    ThreadCalculo.Start(Request.Params("TipoCalculo"))
            End Select
        End If
    End Sub
    Protected Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If hfRFC.Value <> String.Empty And Me.ddlQnasParaCalculo.SelectedValue <> -1 Then
            Me.btnCalcular.Enabled = True
            Me.Timer2.Enabled = False
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Select Case Request.Params("TipoCalculo")
                Case "2"
                    Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
                    If hfRFC.Value = String.Empty Or Me.ddlQnasParaCalculo.SelectedValue = "-1" Then
                        'Me.Timer2.Enabled = True
                        ddlQnasParaCalculo.Enabled = False
                        Me.btnCalcular.Enabled = False
                    Else
                        ddlQnasParaCalculo.Enabled = True
                        Me.btnCalcular.Enabled = True
                    End If
            End Select
        End If
    End Sub
    Protected Sub lbNuevoCalculo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbNuevoCalculo.Click
        Me.btnCalcular.Enabled = True
        Me.lblCalculoPersonaFinalizado.Visible = False
        Me.lbNuevoCalculo.Visible = False
        Me.gvErrores1.Visible = False
    End Sub
    Protected Sub Timer3_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If Session("Plantel") <> String.Empty Then
            Me.lblPlantel_Op1.Text = Session("Plantel")
            Me.lblPlantel2_Op1.Text = Session("Plantel2")
            If DirectCast(Session("miTabla"), DataTable) Is Nothing = False Then
                gvErrores2.EmptyDataText = "Sin errores"
                gvErrores2.DataSource = DirectCast(Session("miTabla"), DataTable)
                gvErrores2.DataBind()
                gvErrores2.Visible = True
            End If
        End If
        If Session("Empleado") <> String.Empty Then
            Me.lblEmpleado_Op1.Text = Session("Empleado")
            Me.lblEmpleado2_Op1.Text = Session("Empleado2")
            If DirectCast(Session("miTabla"), DataTable) Is Nothing = False Then
                gvErrores2.EmptyDataText = "Sin errores"
                gvErrores2.DataSource = DirectCast(Session("miTabla"), DataTable)
                gvErrores2.DataBind()
                gvErrores2.Visible = True
            End If
        End If
        If Me.lblPlantel_Op1.Text = "Cálculo finalizado." Then
            If DirectCast(Session("miTabla"), DataTable) Is Nothing = False Then
                gvErrores2.EmptyDataText = "No hubo errores"
                gvErrores2.DataSource = DirectCast(Session("miTabla"), DataTable)
                gvErrores2.DataBind()
                gvErrores2.Visible = True
            End If
            Me.imgCalculando_Op1.Visible = False
            Me.lblPlantel2_Op1.Visible = False
            Me.lblEmpleado_Op1.Visible = False
            Me.lblEmpleado2_Op1.Visible = False

            Me.lbNuevoCalculoPorPlantel.Visible = True
            Me.Timer3.Enabled = False
        End If
    End Sub
    Protected Sub lbNuevoCalculoPorPlantel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbNuevoCalculoPorPlantel.Click
        Me.ddlQnasParaCalculo.Enabled = True
        Me.btnCalcular.Enabled = True
        Me.ddlPlanteles.Enabled = True
        Me.lblPlantel_Op1.Visible = False
        Me.ChkBxCalculoHaciaAdelante.Enabled = True
        Me.lbNuevoCalculoPorPlantel.Visible = False
        Me.gvErrores2.Visible = False
    End Sub
    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(1).Contains("BtnSearch") Then
            If hfRFC.Value <> String.Empty Then
                Me.ddlQnasParaCalculo.Enabled = True
                Me.btnCalcular.Enabled = True
            End If
        ElseIf Request.Params(1).Contains("BtnNewSearch") Then
            Me.ddlQnasParaCalculo.Enabled = False
            Me.btnCalcular.Enabled = False
            Select Case MultiView1.ActiveViewIndex
                Case 0 'General
                    Me.pnlGeneral.Visible = False
                Case 1 'Plantel
                    Me.pnlPlantel1.Visible = False
                    Me.pnlPlantel2.Visible = False
                Case 2 'Persona
                    Me.pnlPorPersona.Visible = False
            End Select
        ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
            Me.ddlQnasParaCalculo.Enabled = True
            Me.btnCalcular.Enabled = True
            Select Case MultiView1.ActiveViewIndex
                Case 0 'General
                    Me.pnlGeneral.Visible = True
                Case 1 'Plantel
                    Me.pnlPlantel1.Visible = True
                    Me.pnlPlantel2.Visible = True
                Case 2 'Persona
                    Me.pnlPorPersona.Visible = True
            End Select
        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                Me.ddlQnasParaCalculo.Enabled = True
                Me.btnCalcular.Enabled = True
            End If
        End If
    End Sub

    Protected Sub Timer4_Tick(sender As Object, e As System.EventArgs) Handles Timer4.Tick
        If Session("Plantel") <> String.Empty Then
            Me.lblZonaGeo_Op1.Text = Session("Plantel")
            Me.lblZonaGeo2_Op1.Text = Session("Plantel2")
            If DirectCast(Session("miTabla"), DataTable) Is Nothing = False Then
                gvErrores2.EmptyDataText = "Sin errores"
                gvErrores2.DataSource = DirectCast(Session("miTabla"), DataTable)
                gvErrores2.DataBind()
                gvErrores2.Visible = True
            End If
        End If
        If Session("Empleado") <> String.Empty Then
            Me.lblEmpleado_Op2.Text = Session("Empleado")
            Me.lblEmpleado2_Op2.Text = Session("Empleado2")
            If DirectCast(Session("miTabla"), DataTable) Is Nothing = False Then
                gvErrores2.EmptyDataText = "Sin errores"
                gvErrores2.DataSource = DirectCast(Session("miTabla"), DataTable)
                gvErrores2.DataBind()
                gvErrores2.Visible = True
            End If
        End If
        If Me.lblZonaGeo_Op1.Text = "Cálculo finalizado." Then
            If DirectCast(Session("miTabla"), DataTable) Is Nothing = False Then
                gvErrores2.EmptyDataText = "No hubo errores"
                gvErrores2.DataSource = DirectCast(Session("miTabla"), DataTable)
                gvErrores2.DataBind()
                gvErrores2.Visible = True
            End If
            Me.imgCalculando_Op3.Visible = False
            Me.lblZonaGeo2_Op1.Visible = False
            Me.lblEmpleado_Op2.Visible = False
            Me.lblEmpleado2_Op2.Visible = False

            Me.lbNuevoCalculoPorPlantel.Visible = True
            Me.Timer4.Enabled = False
        End If
    End Sub

    Protected Sub lbNuevoCalculoPorZonaGeo_Click(sender As Object, e As System.EventArgs) Handles lbNuevoCalculoPorZonaGeo.Click
        Me.ddlQnasParaCalculo.Enabled = True
        Me.btnCalcular.Enabled = True
        Me.ddlZonasGeo.Enabled = True
        Me.lblZonaGeo_Op1.Visible = False
        Me.ChkBxCalculoHaciaAdelanteZG.Enabled = True
        Me.lbNuevoCalculoPorZonaGeo.Visible = False
        Me.gvErrores2.Visible = False
    End Sub
End Class
