Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Empleados.Sexos
Imports DataAccessLayer.COBAEV.Mexico.Estados
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Nominas
Partial Class AdmonPensionAlimenticia
    Inherits System.Web.UI.Page
    Private dr As DataRow
    Private Sub AplicaValidaciones(ByVal dr As DataRow)
        Dim ddlQnaInicio As DropDownList = CType(Me.dvBeneficiarios.FindControl("WucEfectos1").FindControl("ddlQnaInicio"), DropDownList)

        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            .IdBeneficiario = CType(Request.Params("IdBeneficiario"), Short)
            .IdQnaIni = CShort(dr("IdQnaIni"))
            .TipoOperacion = CByte(Request.Params("TipoOperacion"))
            If Not .ValidaPaginasOperacion(dsValida, False) Then
                Session.Add("dsValida", dsValida)
                Response.Redirect("~/ErroresPagina2.aspx", True)
            Else
                Session.Remove("dsValida")
            End If
        End With
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindPlantelesParaPago(Optional ByVal IdPlantel As String = Nothing)
        Dim oPlantel As New Plantel
        'Dim RFC As String = IIf(Request.Params("RFCEmp") Is Nothing, String.Empty, Request.Params("RFCEmp"))
        'Dim IdBeneficiario As Short = IIf(Request.Params("IdBeneficiario") Is Nothing, 0, CType(Request.Params("IdBeneficiario"), Short))
        'Dim WucEfectos1 As WebControls_wucEfectos = CType(Me.dvBeneficiarios.FindControl("WucEfectos1"), WebControls_wucEfectos)
        'Dim ddlQnaInicio As DropDownList = CType(WucEfectos1.FindControl("ddlQnaInicio"), DropDownList)
        'Dim IdQnaIni As Short = CType(ddlQnaInicio.SelectedValue, Short)
        Dim ddlPlanteles As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlPlanteles"), DropDownList)
        LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(), IdPlantel)
        ddlPlanteles.Enabled = Not Request.Params("TipoOperacion") = "6"
    End Sub
    Private Sub BindParentescos(Optional ByVal IdParentesco As String = "7")
        Dim oPatentesco As New Parentesco
        Dim ddlSexos As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlSexos"), DropDownList)
        Dim ddlParentescos As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlParentescos"), DropDownList)
        If CType(ddlSexos.SelectedValue, Byte) = 3 Then
            LlenaDDL(ddlParentescos, "DescParentesco", "IdParentesco", oPatentesco.ObtenTodos(), IdParentesco)
        Else
            LlenaDDL(ddlParentescos, "DescParentesco", "IdParentesco", oPatentesco.ObtenPorSexo(CType(ddlSexos.SelectedValue, Byte)), IdParentesco)
        End If
        ddlParentescos.Enabled = Not Request.Params("TipoOperacion") = "6"
    End Sub
    Private Sub BindSexos(Optional ByVal IdSexo As String = "3")
        Dim oSexo As New Sexo
        Dim ddlSexos As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlSexos"), DropDownList)
        LlenaDDL(ddlSexos, "DescSexo", "IdSexo", oSexo.ObtenTodos(), IdSexo)
        ddlSexos.Enabled = Not Request.Params("TipoOperacion") = "6"
    End Sub
    Private Sub BindEstados(Optional ByVal IdEdo As String = "30")
        Dim oEstado As New Estado
        Dim ddlEstados As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlEstados"), DropDownList)
        LlenaDDL(ddlEstados, "NomEdo", "IdEdo", oEstado.ObtenTodos, IdEdo)
        ddlEstados.Enabled = Not Request.Params("TipoOperacion") = "6"
    End Sub
    Private Sub BindPrioridadCalculo(Optional ByVal IdPrioridadCalculo As String = "1")
        Dim oEmp As New BeneficiariosPensionAlimenticia
        Dim RFCEmp As String = IIf(Request.Params("RFCEmp") Is Nothing, String.Empty, Request.Params("RFCEmp"))
        Dim IdBeneficiario As Short = IIf(Request.Params("IdBeneficiario") Is Nothing, 0, CType(Request.Params("IdBeneficiario"), Short))
        Dim ddlPrioridadCalculo As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlPrioridadCalculo"), DropDownList)
        oEmp.RFCEmp = RFCEmp
        oEmp.IdBeneficiario = IdBeneficiario
        LlenaDDL(ddlPrioridadCalculo, "PrioridadCalculo", "IdPrioridadCalculo", oEmp.ObtenListaDePrioridadDeCalculo(), IdPrioridadCalculo)
        If IdPrioridadCalculo = "1" And RFCEmp <> String.Empty Then
            ddlPrioridadCalculo.SelectedValue = ddlPrioridadCalculo.Items.Count.ToString
        End If
        ddlPrioridadCalculo.Enabled = Not Request.Params("TipoOperacion") = "6"
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Response.Expires = 0
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Dim txtbxFecNac As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxFecNac"), TextBox)
                Dim hfFecNac As HiddenField = CType(Me.dvBeneficiarios.FindControl("hfFecNac"), HiddenField)
                Dim ibFecNac As ImageButton = CType(Me.dvBeneficiarios.FindControl("ibFecNac"), ImageButton)
                Dim oQna As New Quincenas
                If Request.Params("TipoOperacion") = "1" Then
                    'If oQna.ObtenAbiertasParaCaptura().Rows.Count = 0 Then
                    '    Page.Controls.Clear()
                    '    Response.Write("<b>No hay quincenas abiertas para captura.<b />")
                    '    Response.End()
                    'End If
                    BindSexos()

                    ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + txtbxFecNac.ClientID + "','" + hfFecNac.ClientID + "'); return false")

                    Dim oEstado As New Estado
                    Dim ddlEstados As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlEstados"), DropDownList)
                    LlenaDDL(ddlEstados, "NomEdo", "IdEdo", oEstado.ObtenTodos, 30)

                    BindParentescos()
                    BindPrioridadCalculo()
                ElseIf Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "6" Then
                    Dim WucEfectos1 As WebControls_wucEfectos = CType(Me.dvBeneficiarios.FindControl("WucEfectos1"), WebControls_wucEfectos)
                    Dim oBenefPensionAlimenticia As New BeneficiariosPensionAlimenticia
                    Dim ddlQnaInicio As DropDownList = CType(Me.dvBeneficiarios.FindControl("WucEfectos1").FindControl("ddlQnaInicio"), DropDownList)
                    Dim ddlQnaFin As DropDownList = CType(Me.dvBeneficiarios.FindControl("WucEfectos1").FindControl("ddlQnaFin"), DropDownList)
                    Dim chbxEspecificarNumQuincenas As CheckBox = CType(Me.dvBeneficiarios.FindControl("WucEfectos1").FindControl("chbxEspecificarNumQuincenas"), CheckBox)
                    Dim btnGeneraRFC As Button = CType(Me.dvBeneficiarios.FindControl("btnGeneraRFC"), Button)

                    oBenefPensionAlimenticia.IdBeneficiario = Request.Params("IdBeneficiario")
                    dr = oBenefPensionAlimenticia.ObtenPorId()

                    oQna.IdQuincena = CShort(dr("IdQnaIni"))
                    ddlQnaInicio.DataSource = oQna.ObtenPorId(False)
                    ddlQnaInicio.DataTextField = "Quincena"
                    ddlQnaInicio.DataValueField = "IdQuincena"
                    ddlQnaInicio.DataBind()

                    oQna.IdQuincena = CShort(dr("IdQnaFin"))
                    ddlQnaFin.DataSource = oQna.ObtenPorId(False)
                    ddlQnaFin.DataTextField = "Quincena"
                    ddlQnaFin.DataValueField = "IdQuincena"
                    ddlQnaFin.DataBind()

                    Dim txtbxRFC As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxRFC"), TextBox)
                    Dim txtbxCURP As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxCURP"), TextBox)
                    Dim txtbxApePat As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxApePat"), TextBox)
                    Dim txtbxApeMat As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxApeMat"), TextBox)
                    Dim txtbxNombre As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxNombre"), TextBox)
                    Dim txtbxPorc As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxPorc"), TextBox)

                    txtbxRFC.Text = dr("RFC").ToString
                    txtbxCURP.Text = dr("CURP").ToString
                    txtbxApePat.Text = dr("ApePat").ToString
                    txtbxApeMat.Text = dr("ApeMat").ToString
                    txtbxNombre.Text = dr("Nombre").ToString
                    BindSexos(dr("IdSexo").ToString)
                    txtbxFecNac.Text = dr("FecNac").ToString.Substring(0, 10)
                    ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + txtbxFecNac.ClientID + "','" + hfFecNac.ClientID + "'); return false")
                    BindEstados(dr("IdEdo").ToString)
                    BindParentescos(dr("IdParentesco").ToString)
                    txtbxPorc.Text = dr("Porcentaje").ToString
                    BindPrioridadCalculo(dr("PrioridadCalculo").ToString)

                    If Request.Params("TipoOperacion") = "6" Then
                        txtbxRFC.Enabled = False
                        txtbxCURP.Enabled = False
                        txtbxApePat.Enabled = False
                        txtbxApeMat.Enabled = False
                        txtbxNombre.Enabled = False
                        txtbxFecNac.Enabled = False
                        ibFecNac.Enabled = False
                        txtbxPorc.Enabled = False
                        ddlQnaInicio.Enabled = False
                        chbxEspecificarNumQuincenas.Enabled = False
                        If btnGeneraRFC Is Nothing = False Then btnGeneraRFC.Enabled = False
                    End If
                ElseIf Request.Params("TipoOperacion") = "3" Then
                    'Inicio: Si la operación es de eliminar el registro del beneficiario
                    Dim oBenefPensionAlimenticia As New BeneficiariosPensionAlimenticia

                    oBenefPensionAlimenticia.IdBeneficiario = Request.Params("IdBeneficiario")
                    dr = oBenefPensionAlimenticia.ObtenPorId()

                    AplicaValidaciones(dr)

                    oBenefPensionAlimenticia.Eliminar(CShort(Request.Params("IdBeneficiario")), CType(Session("ArregloAuditoria"), String()))

                    Me.MultiView1.SetActiveView(viewCapturaExitosa)
                End If
            Catch Ex As Exception
                Me.lblErrores.Text = Ex.Message
                Me.lbReintentarCaptura.Visible = False
                If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "1" Then
                    Me.lbReintentarCaptura.Visible = True
                End If
                Me.MultiView1.SetActiveView(Me.viewErrores)
            End Try
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim WucEfectos1 As WebControls_wucEfectos = CType(Me.dvBeneficiarios.FindControl("WucEfectos1"), WebControls_wucEfectos)
            Dim ddlQnaFin As DropDownList = CType(WucEfectos1.FindControl("ddlQnaFin"), DropDownList)
            Dim IdQnaFin As Short = CType(ddlQnaFin.SelectedValue, Short)

            Dim oValidacion As New Validaciones
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsValida As DataSet
            dsValida = _DataCOBAEV.setDataSetErrores()

            Dim txtbxPorc As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxPorc"), TextBox)

            With oValidacion
                .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                .RFC = Session("RFCParaCons")
                .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
                If Request.Params("TipoOperacion") = "0" Then
                    .IdBeneficiario = CType(Request.Params("IdBeneficiario"), Short)
                    .Porcentaje = CDec(txtbxPorc.Text)
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .IdBeneficiario = 0
                    .Porcentaje = 0
                ElseIf Request.Params("TipoOperacion") = "6" Then
                    .IdBeneficiario = CType(Request.Params("IdBeneficiario"), Short)
                    .IdQnaFin = IdQnaFin
                End If
                If Not .ValidaPaginasOperacion(dsValida, False) Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            End With

            Dim txtbxRFC As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxRFC"), TextBox)
            Dim txtbxCURP As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxCURP"), TextBox)
            Dim txtbxApePat As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxApePat"), TextBox)
            Dim txtbxApeMat As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxApeMat"), TextBox)
            Dim txtbxNombre As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxNombre"), TextBox)
            Dim ddlSexos As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlSexos"), DropDownList)
            Dim txtbxFecNac As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxFecNac"), TextBox)
            Dim ddlEstados As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlEstados"), DropDownList)
            Dim ddlParentescos As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlParentescos"), DropDownList)
            'Dim txtbxPorc As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxPorc"), TextBox)
            Dim ddlPrioridadCalculo As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlPrioridadCalculo"), DropDownList)
            Dim ddlPlanteles As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlPlanteles"), DropDownList)
            'Dim WucEfectos1 As WebControls_wucEfectos = CType(Me.dvBeneficiarios.FindControl("WucEfectos1"), WebControls_wucEfectos)
            Dim ddlQnaInicio As DropDownList = CType(WucEfectos1.FindControl("ddlQnaInicio"), DropDownList)
            Dim IdQnaIni As Short = CType(ddlQnaInicio.SelectedValue, Short)
            'Dim ddlQnaFin As DropDownList = CType(WucEfectos1.FindControl("ddlQnaFin"), DropDownList)
            'Dim IdQnaFin As Short = CType(ddlQnaFin.SelectedValue, Short)
            Dim oEmp As New BeneficiariosPensionAlimenticia
            With oEmp
                .RFCBeneficiario = txtbxRFC.Text.Trim.ToUpper
                .CURPBeneficiario = txtbxCURP.Text.Trim.ToUpper
                .ApePatBeneficiario = txtbxApePat.Text.Trim.ToUpper
                .ApeMatBeneficiario = txtbxApeMat.Text.Trim.ToUpper
                .NomBeneficiario = txtbxNombre.Text.Trim.ToUpper
                .IdSexo = CByte(ddlSexos.SelectedValue)
                .FecNac = txtbxFecNac.Text.Trim
                .IdEdo = CByte(ddlEstados.SelectedValue)
                .IdParentesco = CByte(ddlParentescos.SelectedValue)
                .Porcentaje = CType(txtbxPorc.Text, Decimal)
                .PrioridadCalculo = CType(ddlPrioridadCalculo.SelectedItem.Text, Byte)
                .IdQnaIni = IdQnaIni
                .IdQnaFin = IdQnaFin
                .IdPlantel = CType(ddlPlanteles.SelectedValue, Short)
                If Request.Params("TipoOperacion") = "0" Then
                    .RFCEmp = String.Empty
                    .IdBeneficiario = CType(Request.Params("IdBeneficiario"), Short)
                    .Actualizar(0, CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .RFCEmp = Request.Params("RFCEmp")
                    .IdBeneficiario = 0
                    .Insertar(CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "6" Then
                    .IdBeneficiario = CType(Request.Params("IdBeneficiario"), Short)
                    '.ActualizarVigenciaFinal(CByte(Request.Params("TipoOperacion")), CType(Session("ArregloAuditoria"), String()))
                End If
            End With
            Me.MultiView1.SetActiveView(viewCapturaExitosa)
        Catch Ex As Exception
            Me.lblErrores.Text = Ex.Message
            Me.lbReintentarCaptura.Visible = False
            If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "1" Then
                Me.lbReintentarCaptura.Visible = True
            End If
            Me.MultiView1.SetActiveView(Me.viewErrores)
        End Try
    End Sub

    Protected Sub btnGeneraRFC_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxRFC"), TextBox)
        Dim txtbxCURP As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxCURP"), TextBox)
        Dim txtbxApePat As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxApePat"), TextBox)
        Dim txtbxApeMat As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxApeMat"), TextBox)
        Dim txtbxNombre As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxNombre"), TextBox)
        Dim txtbxFecNac As TextBox = CType(Me.dvBeneficiarios.FindControl("txtbxFecNac"), TextBox)
        Dim ddlSexos As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlSexos"), DropDownList)
        Dim ddlEstados As DropDownList = CType(Me.dvBeneficiarios.FindControl("ddlEstados"), DropDownList)
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

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            If Request.Params("TipoOperacion") = "1" Then
                BindPlantelesParaPago()
            ElseIf Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "6" Then
                Dim WucEfectos1 As WebControls_wucEfectos = CType(Me.dvBeneficiarios.FindControl("WucEfectos1"), WebControls_wucEfectos)
                Dim ddlQnaInicio As DropDownList = CType(WucEfectos1.FindControl("ddlQnaInicio"), DropDownList)
                Dim ddlQnaFin As DropDownList = CType(WucEfectos1.FindControl("ddlQnaFin"), DropDownList)
                ddlQnaInicio.SelectedValue = dr("IdQnaIni").ToString
                ddlQnaFin.SelectedValue = dr("IdQnaFin").ToString
                BindPlantelesParaPago(dr("IdPlantel").ToString)
            End If
        End If
    End Sub

    Protected Sub ddlSexos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindParentescos()
    End Sub
End Class
