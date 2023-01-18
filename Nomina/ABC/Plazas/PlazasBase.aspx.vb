Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Partial Class AdmonPlazasBase
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindgvPlazasBase()
        Dim oEmp As New Empleado
        Me.gvPlazasBase.DataSource = oEmp.ObtenPlazasBase(Request.Params("RFCEmp"), False)
        Me.gvPlazasBase.DataBind()

        If gvPlazasBase.Rows.Count = 0 Then
            gvPlazasBase.EmptyDataText = "No existe información sobre plazas base para el empleado."
            gvPlazasBase.DataBind()
        End If
    End Sub
    Private Sub BindgvPlazasBaseHistoria()
        Dim oEmp As New Empleado
        Me.gvPlazasBaseHistoria.DataSource = oEmp.ObtenPlazasBase(Request.Params("RFCEmp"), True)
        Me.gvPlazasBaseHistoria.DataBind()

        If gvPlazasBase.Rows.Count = 0 Then
            gvPlazasBase.EmptyDataText = "No existe información sobre plazas base para el empleado."
            gvPlazasBase.DataBind()
        End If

        If lbVerHistoria.CommandName = "OcultarHistoria" And gvPlazasBaseHistoria.Rows.Count = 0 Then
            lblMsjTitulo1.Visible = False
            Me.gvPlazasBaseHistoria.Visible = False
            lbVerHistoria.CommandName = "VerHistoria"
            lbVerHistoria.Text = "Ver histórico de plazas base"
        End If
    End Sub
    Private Sub AplicarPermisos(dt As DataTable)
        Dim oUsr As New Usuario

        If IsNothing(dt) Then dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpleadosCategoriasBase")

        lbAddPlazaBase.Visible = CBool(dt.Rows(0).Item("Insercion"))
        gvPlazasBase.Columns(5).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        gvPlazasBase.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
        lbVerHistoria.Visible = CBool(dt.Rows(0).Item("Consulta")) And gvPlazasBaseHistoria.Rows.Count > 0
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0

            Dim oUsr As New Usuario
            Dim dt As DataTable
            Dim oEmp As New Empleado

            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpleadosCategoriasBase")
            If CBool(dt.Rows(0).Item("Consulta")) Then
                BindgvPlazasBase()
                Me.gvPlazasBaseHistoria.DataSource = oEmp.ObtenPlazasBase(Request.Params("RFCEmp"), True)
                Me.gvPlazasBaseHistoria.DataBind()
                AplicarPermisos(dt)
            Else
                gvPlazasBase.EmptyDataText = "Usuario sin permisos para visualizar la información solicitada."
                gvPlazasBase.DataBind()
            End If
        End If
    End Sub
    Protected Sub lbAddPlazaBase_Click(sender As Object, e As System.EventArgs) Handles lbAddPlazaBase.Click
        Dim oCategos As New Categoria
        Dim oAnios As New Anios
        Dim oQna As New Quincenas

        lblMsjTitulo.Text = "Capture la información"

        LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategos.ObtenActivasBasificables(), Nothing)
        ddlCategorias_SelectedIndexChanged(sender, e)

        LlenaDDL(ddlAniosIni, "Anio", "Anio", oAnios.ObtenDesdeInicioCOBACH(True), Nothing)
        LlenaDDL(ddlQnasIni, "Quincena", "IdQuincena", oAnios.ObtenQnasOrdinarias(CShort(ddlAniosIni.SelectedValue)), Nothing)

        LlenaDDL(ddlAniosFin, "Anio", "Anio", oAnios.ObtenDesdeInicioCOBACH(True, CShort(ddlAniosIni.SelectedValue)), Nothing)
        LlenaDDL(ddlQnasFin, "Quincena", "IdQuincena", oAnios.ObtenQnasOrdinarias(CShort(ddlAniosFin.SelectedValue)), Nothing)

        ddlAniosFin.Enabled = True
        ddlQnasFin.Enabled = True
        chbEfectosAbiertos.Checked = False

        btnGuardar.Text = "Guardar"

        MultiView1.SetActiveView(Me.vistaAddPlazaBase)
    End Sub

    Protected Sub ddlCategorias_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCategorias.SelectedIndexChanged
        Dim oCategos As New Categoria
        Dim dr As DataRow

        dr = oCategos.ObtenPorId(CShort(ddlCategorias.SelectedValue), True)

        tbHoras.Text = CStr(dr("Horas"))
        If CByte(dr("Horas")) > 0 Or CByte(dr("IdEmpFuncion")) = 1 Then
            tbHoras.Enabled = False
        ElseIf CByte(dr("IdEmpFuncion")) = 2 And CByte(dr("Horas")) = 0 Then
            tbHoras.Enabled = True
        End If

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        gvPlazasBase.SelectedIndex = -1
        MultiView1.SetActiveView(Me.vistaConsulta)
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim oEmp As New Empleado

        Try
            If btnGuardar.Text = "Guardar" Then
                oEmp.AddCategoriaBase(Request.Params("RFCEmp"), ddlTipoSemestre.SelectedValue, CShort(ddlCategorias.SelectedValue), _
                                      CByte(tbHoras.Text), CShort(ddlQnasIni.SelectedValue), _
                                      IIf(chbEfectosAbiertos.Checked, 32767, CShort(ddlQnasFin.SelectedValue)), _
                                      CType(Session("ArregloAuditoria"), String()))
            Else
                Dim lblTipoSemestre = CType(gvPlazasBase.SelectedRow.FindControl("lblTipoSemestre"), Label)
                Dim lblIdCategoria = CType(gvPlazasBase.SelectedRow.FindControl("lblIdCategoria"), Label)
                Dim lblHoras = CType(gvPlazasBase.SelectedRow.FindControl("lblHoras"), Label)
                Dim lblIdQnaIni = CType(gvPlazasBase.SelectedRow.FindControl("lblIdQnaIni"), Label)
                Dim lblIdQnaFin = CType(gvPlazasBase.SelectedRow.FindControl("lblIdQnaFin"), Label)
                Dim lblQnaIni = CType(gvPlazasBase.SelectedRow.FindControl("lblQnaIni"), Label)
                Dim lblQnaFin = CType(gvPlazasBase.SelectedRow.FindControl("lblQnaFin"), Label)

                If lblHoras.Text = String.Empty Then lblHoras.Text = "0"

                oEmp.UpdCategoriaBase(Request.Params("RFCEmp"), lblTipoSemestre.Text, CShort(lblIdCategoria.Text), CByte(lblHoras.Text), _
                                     CShort(lblIdQnaIni.Text), IIf(lblIdQnaFin.Text = "32767", 32767, CShort(lblIdQnaFin.Text)), _
                                     ddlTipoSemestre.SelectedValue, CShort(ddlCategorias.SelectedValue), CByte(tbHoras.Text), _
                                     CShort(ddlQnasIni.SelectedValue), IIf(chbEfectosAbiertos.Checked, 32767, CShort(ddlQnasFin.SelectedValue)), _
                                     CType(Session("ArregloAuditoria"), String()))
            End If
            BindgvPlazasBase()
            BindgvPlazasBaseHistoria()
            AplicarPermisos(Nothing)
            gvPlazasBase.SelectedIndex = -1

            MultiView1.SetActiveView(Me.vistaConsulta)
        Catch Ex As Exception
            lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.vistaErrores)
        End Try
    End Sub

    Protected Sub ibModify_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender, ImageButton).DataItemContainer
        Dim lblTipoSemestre = CType(gvr.FindControl("lblTipoSemestre"), Label)
        Dim lblIdCategoria = CType(gvr.FindControl("lblIdCategoria"), Label)
        Dim lblHoras = CType(gvr.FindControl("lblHoras"), Label)
        Dim lblIdQnaIni = CType(gvr.FindControl("lblIdQnaIni"), Label)
        Dim lblIdQnaFin = CType(gvr.FindControl("lblIdQnaFin"), Label)
        Dim lblQnaIni = CType(gvr.FindControl("lblQnaIni"), Label)
        Dim lblQnaFin = CType(gvr.FindControl("lblQnaFin"), Label)
        Dim oCategos As New Categoria
        Dim dr As DataRow
        Dim oAnios As New Anios

        lblMsjTitulo.Text = "Modifique la información"

        gvPlazasBase.SelectedIndex = gvr.DataItemIndex

        ddlTipoSemestre.SelectedValue = lblTipoSemestre.Text

        LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategos.ObtenActivasBasificables(), lblIdCategoria.Text)

        dr = oCategos.ObtenPorId(CShort(ddlCategorias.SelectedValue), True)

        tbHoras.Text = IIf(lblHoras.Text = String.Empty, "0", lblHoras.Text)
        If CByte(dr("Horas")) > 0 Or CByte(dr("IdEmpFuncion")) = 1 Then
            tbHoras.Enabled = False
        ElseIf CByte(dr("IdEmpFuncion")) = 2 Then
            tbHoras.Enabled = True
        End If

        LlenaDDL(ddlAniosIni, "Anio", "Anio", oAnios.ObtenDesdeInicioCOBACH(True), Left(lblQnaIni.Text, 4))
        LlenaDDL(ddlQnasIni, "Quincena", "IdQuincena", oAnios.ObtenQnasOrdinarias(CShort(ddlAniosIni.SelectedValue)), lblIdQnaIni.Text)

        If lblIdQnaFin.Text = "32767" Then
            LlenaDDL(ddlAniosFin, "Anio", "Anio", oAnios.ObtenDesdeInicioCOBACH(True, CShort(ddlAniosIni.SelectedValue)), Nothing)
            LlenaDDL(ddlQnasFin, "Quincena", "IdQuincena", oAnios.ObtenQnasOrdinarias(CShort(ddlAniosFin.SelectedValue)), Nothing)
            ddlAniosFin.Enabled = False
            ddlQnasFin.Enabled = False
            chbEfectosAbiertos.Checked = True
        Else
            LlenaDDL(ddlAniosFin, "Anio", "Anio", oAnios.ObtenDesdeInicioCOBACH(True, CShort(ddlAniosIni.SelectedValue)), Left(lblQnaFin.Text, 4))
            LlenaDDL(ddlQnasFin, "Quincena", "IdQuincena", oAnios.ObtenQnasOrdinarias(CShort(ddlAniosFin.SelectedValue)), lblIdQnaFin.Text)
            ddlAniosFin.Enabled = True
            ddlQnasFin.Enabled = True
            chbEfectosAbiertos.Checked = False
        End If

        btnGuardar.Text = "Modificar"

        MultiView1.SetActiveView(Me.vistaAddPlazaBase)

    End Sub

    Protected Sub ibEliminar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender, ImageButton).DataItemContainer
        Dim lblTipoSemestre = CType(gvr.FindControl("lblTipoSemestre"), Label)
        Dim lblIdCategoria = CType(gvr.FindControl("lblIdCategoria"), Label)
        Dim lblHoras = CType(gvr.FindControl("lblHoras"), Label)
        Dim lblIdQnaIni = CType(gvr.FindControl("lblIdQnaIni"), Label)
        Dim lblIdQnaFin = CType(gvr.FindControl("lblIdQnaFin"), Label)
        Dim oEmp As New Empleado

        Try
            If lblHoras.Text = String.Empty Then lblHoras.Text = "0"

            oEmp.DelCategoriaBase(Request.Params("RFCEmp"), lblTipoSemestre.Text, CShort(lblIdCategoria.Text), CByte(lblHoras.Text), _
                                  CShort(lblIdQnaIni.Text), IIf(lblIdQnaFin.Text = "32767", 32767, CShort(lblIdQnaFin.Text)), _
                                  CType(Session("ArregloAuditoria"), String()))

            BindgvPlazasBase()
            BindgvPlazasBaseHistoria()
            AplicarPermisos(Nothing)
        Catch Ex As Exception
            lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.vistaErrores)
        End Try
    End Sub

    Protected Sub lbVerHistoria_Click(sender As Object, e As System.EventArgs) Handles lbVerHistoria.Click
        If lbVerHistoria.CommandName = "VerHistoria" Then
            lblMsjTitulo1.Visible = True
            BindgvPlazasBaseHistoria()
            Me.gvPlazasBaseHistoria.Visible = True
            lbVerHistoria.CommandName = "OcultarHistoria"
            lbVerHistoria.Text = "Ocultar histórico de plazas base"
        Else
            lblMsjTitulo1.Visible = False
            Me.gvPlazasBaseHistoria.Visible = False
            lbVerHistoria.CommandName = "VerHistoria"
            lbVerHistoria.Text = "Ver histórico de plazas base"
        End If
    End Sub
    Protected Sub ddlAniosIni_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAniosIni.SelectedIndexChanged
        Dim oAnios As New Anios

        LlenaDDL(ddlQnasIni, "Quincena", "IdQuincena", oAnios.ObtenQnasOrdinarias(CShort(ddlAniosIni.SelectedValue)), Nothing)
        LlenaDDL(ddlAniosFin, "Anio", "Anio", oAnios.ObtenDesdeInicioCOBACH(True, CShort(ddlAniosIni.SelectedValue)), Nothing)
        LlenaDDL(ddlQnasFin, "Quincena", "IdQuincena", oAnios.ObtenQnasOrdMayoresOIgualesA(CShort(ddlAniosFin.SelectedValue), CShort(ddlQnasIni.SelectedValue)), Nothing)
    End Sub

    Protected Sub ddlAniosFin_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAniosFin.SelectedIndexChanged
        Dim oAnios As New Anios

        LlenaDDL(ddlQnasFin, "Quincena", "IdQuincena", oAnios.ObtenQnasOrdMayoresOIgualesA(CShort(ddlAniosFin.SelectedValue), CShort(ddlQnasIni.SelectedValue)), Nothing)
    End Sub

    Protected Sub ddlQnasIni_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlQnasIni.SelectedIndexChanged
        Dim oAnios As New Anios

        LlenaDDL(ddlQnasFin, "Quincena", "IdQuincena", oAnios.ObtenQnasOrdMayoresOIgualesA(CShort(ddlAniosFin.SelectedValue), CShort(ddlQnasIni.SelectedValue)), Nothing)
    End Sub

    Protected Sub chbEfectosAbiertos_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbEfectosAbiertos.CheckedChanged
        ddlAniosFin.Enabled = Not chbEfectosAbiertos.Checked
        ddlQnasFin.Enabled = Not chbEfectosAbiertos.Checked
    End Sub
End Class
