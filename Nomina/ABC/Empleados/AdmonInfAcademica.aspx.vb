Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class ABC_Empleados_AdmonInfAcademica
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim oInfAcad As New InfAcademica
            Dim ddlNivAcad As DropDownList = Nothing
            Dim ddlCarrPorNiv As DropDownList = Nothing
            Dim chbTitulado As CheckBox = Nothing
            Dim tbNumCedProf As TextBox = Nothing
            Dim chbIncompleta As CheckBox = Nothing
            Dim chbCursando As CheckBox = Nothing
            Dim dtNiveles As DataTable = Nothing
            Dim drNivel As DataRow = Nothing
            Dim tbAbrevProf As TextBox = Nothing

            Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
            Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

            BtnNewSearch.Visible = False
            BtnCancelSearch.Visible = False
            BtnSearch.Visible = False

            dtNiveles = oInfAcad.ObtenNiveles()

            If Request.Params("TipoOperacion") = "0" Then
                Dim oEmp As New Empleado
                Dim lblIdNivel_E As Label = Nothing
                Dim lblIdCarrera_E As Label = Nothing

                Me.dvNivAcad.ChangeMode(DetailsViewMode.Edit)

                Me.dvNivAcad.DataSource = oEmp.ObtenHistAcadPorIdEstudio(CInt(Request.Params("IdEstudio")))
                Me.dvNivAcad.DataBind()

                ddlNivAcad = CType(Me.dvNivAcad.FindControl("ddlNivAcad_E"), DropDownList)
                lblIdNivel_E = CType(Me.dvNivAcad.FindControl("lblIdNivel_E"), Label)
                ddlCarrPorNiv = CType(Me.dvNivAcad.FindControl("ddlCarrPorNiv_E"), DropDownList)
                lblIdCarrera_E = CType(Me.dvNivAcad.FindControl("lblIdCarrera_E"), Label)
                chbTitulado = CType(Me.dvNivAcad.FindControl("chbTitulado_E"), CheckBox)
                tbNumCedProf = CType(Me.dvNivAcad.FindControl("tbNumCedProf_E"), TextBox)
                chbIncompleta = CType(Me.dvNivAcad.FindControl("chbIncompleta_E"), CheckBox)
                chbCursando = CType(Me.dvNivAcad.FindControl("chbCursando_E"), CheckBox)
                tbAbrevProf = CType(Me.dvNivAcad.FindControl("tbAbrevProf_E"), TextBox)

                LlenaDDL(ddlNivAcad, "Nivel", "IdNivel", dtNiveles, lblIdNivel_E.Text)
                LlenaDDL(ddlCarrPorNiv, "Carrera", "IdCarrera", oInfAcad.ObtenCarrerasPorNivel(CByte(lblIdNivel_E.Text)), lblIdCarrera_E.Text)

                drNivel = oInfAcad.ObtenNivel(CByte(ddlNivAcad.SelectedValue))
                chbTitulado.Enabled = CBool(drNivel("RequiereTitulacion"))
                tbNumCedProf.Enabled = CBool(drNivel("RequiereTitulacion")) And chbTitulado.Checked
                tbAbrevProf.Enabled = CBool(drNivel("PermiteAbrevProf"))

                Me.MultiView1.SetActiveView(Me.viewCaptura)
            ElseIf Request.Params("TipoOperacion") = "1" Then
                ddlNivAcad = CType(Me.dvNivAcad.FindControl("ddlNivAcad_I"), DropDownList)
                ddlCarrPorNiv = CType(Me.dvNivAcad.FindControl("ddlCarrPorNiv_I"), DropDownList)
                chbTitulado = CType(Me.dvNivAcad.FindControl("chbTitulado_I"), CheckBox)
                tbNumCedProf = CType(Me.dvNivAcad.FindControl("tbNumCedProf_I"), TextBox)
                chbIncompleta = CType(Me.dvNivAcad.FindControl("chbIncompleta_I"), CheckBox)
                chbCursando = CType(Me.dvNivAcad.FindControl("chbCursando_I"), CheckBox)
                tbAbrevProf = CType(Me.dvNivAcad.FindControl("tbAbrevProf_I"), TextBox)

                LlenaDDL(ddlNivAcad, "Nivel", "IdNivel", dtNiveles, Nothing)
                LlenaDDL(ddlCarrPorNiv, "Carrera", "IdCarrera", oInfAcad.ObtenCarrerasPorNivel(CByte(ddlNivAcad.SelectedValue)), Nothing)
                chbTitulado.Enabled = CBool(dtNiveles.Rows(0).Item("RequiereTitulacion"))
                tbNumCedProf.Text = String.Empty
                tbNumCedProf.Enabled = CBool(dtNiveles.Rows(0).Item("RequiereTitulacion"))
                tbAbrevProf.Enabled = CBool(dtNiveles.Rows(0).Item("PermiteAbrevProf"))

                Me.MultiView1.SetActiveView(Me.viewCaptura)
            ElseIf Request.Params("TipoOperacion") = "3" Then
                oInfAcad.DelEstudiosPorEmpleado(CInt(Request.Params("IdEstudio")), CType(Session("ArregloAuditoria"), String()))
                Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
            End If

            Dim btnCancelar As Button
            Dim vlTipoOp2 As String

            Select Case dvNivAcad.CurrentMode
                Case DetailsViewMode.ReadOnly
                    vlTipoOp2 = ""
                Case DetailsViewMode.Edit
                    vlTipoOp2 = "_E"
                Case DetailsViewMode.Insert
                    vlTipoOp2 = "_I"
                Case Else
                    vlTipoOp2 = ""
            End Select

            btnCancelar = CType(dvNivAcad.FindControl("btnCancelar" + vlTipoOp2), Button)

            If Session("URLAnt") Is Nothing = False Then
                If Session("URLAnt").ToString.Contains(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString) Then
                    btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                    lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                Else
                    btnCancelar.PostBackUrl = "~/" + Session("URLAnt")
                    lbOtraOperacion0.PostBackUrl = "~/" + Session("URLAnt")
                End If
            Else
                btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
            End If
        End If
    End Sub

    Private Sub AplicaValidaciones()
        Dim vl_IdEstudio As Integer
        Dim ddlNivAcad As DropDownList
        Dim ddlCarrPorNiv As DropDownList
        Dim vl_RFCEmp As String

        vl_IdEstudio = IIf(Request.Params("TipoOperacion") = "0", CInt(Request.Params("IdEstudio")), 0)
        ddlNivAcad = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("ddlNivAcad_E"), DropDownList), CType(Me.dvNivAcad.FindControl("ddlNivAcad_I"), DropDownList))
        ddlCarrPorNiv = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("ddlCarrPorNiv_E"), DropDownList), CType(Me.dvNivAcad.FindControl("ddlCarrPorNiv_I"), DropDownList))
        vl_RFCEmp = IIf(Request.Params("TipoOperacion") = "0", String.Empty, Request.Params("RFCEmp"))

        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            .TipoOperacion = CByte(Request.Params("TipoOperacion"))
            .RFC = vl_RFCEmp
            .IdEstudio = vl_IdEstudio
            .IdNivel = CByte(ddlNivAcad.SelectedValue)
            .IdCarrera = CShort(ddlCarrPorNiv.SelectedValue)
            If Not .ValidaPaginasOperacion(dsValida) Then
                Session.Add("dsValida", dsValida)
                Response.Redirect("~/ErroresPagina2.aspx")
                Exit Sub
            Else
                Session.Remove("dsValida")
            End If
        End With
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            AplicaValidaciones()

            Dim vl_IdEstudio As Integer
            Dim ddlNivAcad As DropDownList
            Dim ddlCarrPorNiv As DropDownList
            Dim vl_RFCEmp As String
            Dim tbFecha, tbAbrevProf As TextBox
            Dim tbNumCedProf As TextBox
            Dim chbTitulado As CheckBox
            Dim chbIncompleta As CheckBox
            Dim chbCursando As CheckBox

            Dim chbUltNivEstudios As CheckBox
            Dim vl_SiglasIni As String
            Dim oEmp As New InfAcademica

            vl_IdEstudio = IIf(Request.Params("TipoOperacion") = "0", CInt(Request.Params("IdEstudio")), 0)
            vl_RFCEmp = IIf(Request.Params("TipoOperacion") = "0", String.Empty, Request.Params("RFCEmp"))
            ddlNivAcad = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("ddlNivAcad_E"), DropDownList), CType(Me.dvNivAcad.FindControl("ddlNivAcad_I"), DropDownList))
            tbFecha = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("tbFecha_E"), TextBox), CType(Me.dvNivAcad.FindControl("tbFecha_I"), TextBox))
            ddlCarrPorNiv = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("ddlCarrPorNiv_E"), DropDownList), CType(Me.dvNivAcad.FindControl("ddlCarrPorNiv_I"), DropDownList))
            chbTitulado = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbTitulado_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbTitulado_I"), CheckBox))
            tbNumCedProf = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("tbNumCedProf_E"), TextBox), CType(Me.dvNivAcad.FindControl("tbNumCedProf_I"), TextBox))
            chbIncompleta = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbIncompleta_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbIncompleta_I"), CheckBox))
            chbCursando = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbCursando_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbCursando_I"), CheckBox))
            chbUltNivEstudios = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbUltNivEstudios_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbUltNivEstudios_I"), CheckBox))
            tbAbrevProf = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("tbAbrevProf_E"), TextBox), CType(Me.dvNivAcad.FindControl("tbAbrevProf_I"), TextBox))
            vl_SiglasIni = tbAbrevProf.Text.Trim.ToUpper

            If Request.Params("TipoOperacion") = "0" Then
                oEmp.UpdEstudiosPorEmpleado(CInt(vl_IdEstudio), CByte(ddlNivAcad.SelectedValue), tbFecha.Text, CShort(ddlCarrPorNiv.SelectedValue), chbTitulado.Checked, chbUltNivEstudios.Checked, vl_SiglasIni, chbIncompleta.Checked, chbCursando.Checked, tbNumCedProf.Text, CType(Session("ArregloAuditoria"), String()))
            ElseIf Request.Params("TipoOperacion") = "1" Then
                oEmp.AddEstudiosPorEmpleado(vl_RFCEmp, CByte(ddlNivAcad.SelectedValue), tbFecha.Text, CShort(ddlCarrPorNiv.SelectedValue), chbTitulado.Checked, chbUltNivEstudios.Checked, vl_SiglasIni, chbIncompleta.Checked, chbCursando.Checked, tbNumCedProf.Text, CType(Session("ArregloAuditoria"), String()))
            End If
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
    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub

    Protected Sub ddlNivAcad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oEmp As New Empleado
        Dim oInfAcad As New InfAcademica
        Dim ddlNivAcad As DropDownList = Nothing
        Dim ddlCarrPorNiv As DropDownList = Nothing
        Dim dt As DataTable = Nothing
        Dim vlSelectedValue As String = Nothing
        Dim chbTitulado As CheckBox = Nothing
        Dim drNivel As DataRow = Nothing
        Dim vlChecked As Boolean = False
        Dim tbAbrevProf As TextBox
        Dim chbUltNivEstudios As CheckBox
        Dim chbIncompleta As CheckBox
        Dim chbCursando As CheckBox
        Dim tbNumCedProf As TextBox

        ddlNivAcad = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("ddlNivAcad_E"), DropDownList), CType(Me.dvNivAcad.FindControl("ddlNivAcad_I"), DropDownList))
        ddlCarrPorNiv = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("ddlCarrPorNiv_E"), DropDownList), CType(Me.dvNivAcad.FindControl("ddlCarrPorNiv_I"), DropDownList))
        chbTitulado = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbTitulado_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbTitulado_I"), CheckBox))
        tbNumCedProf = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("tbNumCedProf_E"), TextBox), CType(Me.dvNivAcad.FindControl("tbNumCedProf_I"), TextBox))
        chbUltNivEstudios = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbUltNivEstudios_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbUltNivEstudios_I"), CheckBox))
        tbAbrevProf = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("tbAbrevProf_E"), TextBox), CType(Me.dvNivAcad.FindControl("tbAbrevProf_I"), TextBox))
        chbIncompleta = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbIncompleta_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbIncompleta_I"), CheckBox))
        chbCursando = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbCursando_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbCursando_I"), CheckBox))

        drNivel = oInfAcad.ObtenNivel(CByte(ddlNivAcad.SelectedValue))

        LlenaDDL(ddlCarrPorNiv, "Carrera", "IdCarrera", oInfAcad.ObtenCarrerasPorNivel(CByte(ddlNivAcad.SelectedValue)), Nothing)

        chbTitulado.Checked = False
        chbTitulado.Enabled = CBool(drNivel("RequiereTitulacion"))
        chbUltNivEstudios.Checked = False
        chbIncompleta.Checked = False
        chbCursando.Checked = False

        tbNumCedProf.Text = IIf(CBool(drNivel("RequiereTitulacion")) = False, String.Empty, tbNumCedProf.Text)
        tbNumCedProf.Enabled = CBool(drNivel("RequiereTitulacion"))
        tbAbrevProf.Text = IIf(CBool(drNivel("PermiteAbrevProf")) = False, String.Empty, tbAbrevProf.Text)
        tbAbrevProf.Enabled = CBool(drNivel("PermiteAbrevProf"))
    End Sub

    Protected Sub chbTitulado_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim chbTitulado As CheckBox = Nothing
        Dim chbIncompleta As CheckBox
        Dim chbCursando As CheckBox
        Dim tbNumCedProf As TextBox

        chbTitulado = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbTitulado_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbTitulado_I"), CheckBox))
        tbNumCedProf = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("tbNumCedProf_E"), TextBox), CType(Me.dvNivAcad.FindControl("tbNumCedProf_I"), TextBox))
        chbIncompleta = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbIncompleta_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbIncompleta_I"), CheckBox))
        chbCursando = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbCursando_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbCursando_I"), CheckBox))

        If chbTitulado.Checked Then
            tbNumCedProf.Enabled = True
            chbIncompleta.Checked = False
            chbCursando.Checked = False
        Else
            tbNumCedProf.Text = String.Empty
            tbNumCedProf.Enabled = False
        End If
    End Sub

    Protected Sub chbCursando_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim chbTitulado As CheckBox = Nothing
        Dim chbIncompleta As CheckBox
        Dim chbCursando As CheckBox
        Dim tbNumCedProf As TextBox

        chbTitulado = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbTitulado_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbTitulado_I"), CheckBox))
        tbNumCedProf = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("tbNumCedProf_E"), TextBox), CType(Me.dvNivAcad.FindControl("tbNumCedProf_I"), TextBox))
        chbIncompleta = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbIncompleta_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbIncompleta_I"), CheckBox))
        chbCursando = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbCursando_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbCursando_I"), CheckBox))

        If chbCursando.Checked Then
            chbIncompleta.Checked = False
            tbNumCedProf.Text = String.Empty
            tbNumCedProf.Enabled = False
            chbTitulado.Checked = False
        End If
    End Sub

    Protected Sub chbIncompleta_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim chbTitulado As CheckBox = Nothing
        Dim chbIncompleta As CheckBox
        Dim chbCursando As CheckBox
        Dim tbNumCedProf As TextBox

        chbTitulado = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbTitulado_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbTitulado_I"), CheckBox))
        tbNumCedProf = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("tbNumCedProf_E"), TextBox), CType(Me.dvNivAcad.FindControl("tbNumCedProf_I"), TextBox))
        chbIncompleta = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbIncompleta_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbIncompleta_I"), CheckBox))
        chbCursando = IIf(Request.Params("TipoOperacion") = "0", CType(Me.dvNivAcad.FindControl("chbCursando_E"), CheckBox), CType(Me.dvNivAcad.FindControl("chbCursando_I"), CheckBox))

        If chbIncompleta.Checked Then
            chbTitulado.Checked = False
            tbNumCedProf.Text = String.Empty
            tbNumCedProf.Enabled = False
            chbCursando.Checked = False
        End If
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        Dim btnCancelar As Button
        Dim strPostbackURL As String
        Dim vlTipoOp2 As String

        Select Case dvNivAcad.CurrentMode
            Case DetailsViewMode.ReadOnly
                vlTipoOp2 = ""
            Case DetailsViewMode.Edit
                vlTipoOp2 = "_E"
            Case DetailsViewMode.Insert
                vlTipoOp2 = "_I"
            Case Else
                vlTipoOp2 = ""
        End Select

        btnCancelar = CType(dvNivAcad.FindControl("btnCancelar" + vlTipoOp2), Button)

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

        btnCancelar = CType(dvNivAcad.FindControl("btnCancelar" + vlTipoOp2), Button)
        btnCancelar.PostBackUrl = strPostbackURL
        lbOtraOperacion0.PostBackUrl = strPostbackURL

        MultiView1.SetActiveView(viewCaptura)
    End Sub
End Class
