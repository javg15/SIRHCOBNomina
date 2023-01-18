Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Partial Class Consultas_Empleados_DiasParaPagoQnal
    Inherits System.Web.UI.Page
    Private Sub SubActualizar()
        Me.gvEmps.EditIndex = -1
        BindddlAños()
        BindDatos()

        Me.gvEmps.Columns(0).Visible = True 'Select
        'Me.gvEmps.Columns(6).Visible = True 'Delete

        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsDiasParaPagoQnal")
        Me.gvEmps.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
    End Sub
    Private Sub SubCancelingEditgvEmps()
        Me.gvEmps.Columns(0).Visible = True 'Select

        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsDiasParaPagoQnal")
        Me.gvEmps.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))

        'Me.gvEmps.Columns(6).Visible = True 'Delete
        Me.gvEmps.SelectedIndex = -1
        Me.gvEmps.EditIndex = -1
        BindgvEmps(-1)
    End Sub

    Private Sub BindddlAños()
        Dim oQna As New Quincenas
        With Me.ddlAños
            .DataSource = oQna.ObtenAños(True)
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
                Me.btnConsultarQuincenas.Enabled = False
            Else
                Me.btnConsultarQuincenas.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        If oEmp.RFC <> String.Empty Then
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
                pnl1.Visible = True
            Else
                Me.lblEmpInf.Text = String.Empty
                pnl1.Visible = False
            End If
        End If
        BindgvEmps()
    End Sub
    Private Sub BindgvEmps(Optional ByVal Fila As SByte = -1)
        Dim oEmp As New Empleado
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        Dim lblAnio As Label
        With Me.gvEmps
            If Fila = -1 Then
                If hfRFC.Value <> String.Empty Then .DataSource = oEmp.ObtenDiasParaPagoQnal(hfRFC.Value, CShort(Me.ddlAños.SelectedValue))
            Else
                lblAnio = CType(Me.gvEmps.Rows(Fila).FindControl("lblAnio"), Label)
                If hfRFC.Value <> String.Empty Then .DataSource = oEmp.ObtenDiasParaPagoQnal(hfRFC.Value, CShort(lblAnio.Text))
            End If
            .DataBind()
            .Enabled = True
        End With
        Me.ddlAños.Enabled = hfRFC.Value <> String.Empty
        Me.btnConsultarQuincenas.Enabled = hfRFC.Value <> String.Empty
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Response.Expires = 0
            Dim oUsr As New Usuario
            Dim dt As DataTable

            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsDiasParaPagoQnal")
            Me.gvEmps.Columns(5).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            Me.gvEmps.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))

            'Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            'Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            'Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
            BindddlAños()
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()            
        End If
    End Sub
    Protected Sub gvEmps_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmps.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblDias As Label = CType(e.Row.FindControl("lblDias"), Label)
                Dim lblAbiertaParaCaptura As Label = CType(e.Row.FindControl("lblAbiertaParaCaptura"), Label)
                Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                If Me.gvEmps.EditIndex = -1 Then
                    ibEditar.Enabled = lblAbiertaParaCaptura.Text = "True"
                    ibEliminar.Enabled = lblAbiertaParaCaptura.Text = "True" And lblDias.Text <> "15"
                End If
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub
    Protected Sub gvEmps_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvEmps.RowCancelingEdit
        SubCancelingEditgvEmps()
    End Sub

    Protected Sub gvEmps_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvEmps.RowEditing
        Dim a As Byte
        Me.gvEmps.Columns(0).Visible = False 'Select
        Me.gvEmps.Columns(6).Visible = False 'Delete
        Me.gvEmps.SelectedIndex = -1
        Me.gvEmps.EditIndex = e.NewEditIndex
        BindgvEmps(e.NewEditIndex)

        Dim fila As Integer = Me.gvEmps.EditIndex
        Dim lblIdEmp As Label = CType(Me.gvEmps.Rows(fila).FindControl("lblIdEmp"), Label)
        Dim lblIdQuincena As Label = CType(Me.gvEmps.Rows(fila).FindControl("lblIdQuincena"), Label)
        Dim lblDias As Label = CType(Me.gvEmps.Rows(fila).FindControl("lblDias"), Label)
        Dim ddlDias As DropDownList = CType(Me.gvEmps.Rows(fila).FindControl("ddlDias"), DropDownList)

        For a = 0 To 13
            ddlDias.Items.Insert(a, (a + 1).ToString)
            ddlDias.Items(a).Value = (a + 1).ToString
        Next
        If lblDias.Text <> "15" Then
            ddlDias.Items.FindByValue(lblDias.Text).Selected = True
        Else
            ddlDias.Items.FindByValue("14").Selected = True
        End If
    End Sub

    Protected Sub gvEmps_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvEmps.RowUpdating
        Dim lblIdEmp As Label = CType(Me.gvEmps.Rows(e.RowIndex).FindControl("lblIdEmp"), Label)
        Dim lblIdQuincena As Label = CType(Me.gvEmps.Rows(e.RowIndex).FindControl("lblIdQuincena"), Label)
        Dim ddlDias As DropDownList = CType(Me.gvEmps.Rows(e.RowIndex).FindControl("ddlDias"), DropDownList)

        Dim oEmp As New Empleado

        oEmp.Ins_O_UpdDiasParaPagoQnal(CInt(lblIdEmp.Text), CShort(lblIdQuincena.Text), CShort(ddlDias.SelectedValue), CType(Session("ArregloAuditoria"), String()))

        Me.gvEmps.Columns(0).Visible = True 'Select

        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsDiasParaPagoQnal")
        Me.gvEmps.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))

        'Me.gvEmps.Columns(6).Visible = True 'Delete     
        Me.gvEmps.SelectedIndex = e.RowIndex
        Me.gvEmps.EditIndex = -1
        BindgvEmps(e.RowIndex)
    End Sub
    Protected Sub gvEmps_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvEmps.SelectedIndexChanged

    End Sub

    Protected Sub gvEmps_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvEmps.RowDeleting
        Dim lblIdEmp As Label = CType(Me.gvEmps.Rows(e.RowIndex).FindControl("lblIdEmp"), Label)
        Dim lblIdQuincena As Label = CType(Me.gvEmps.Rows(e.RowIndex).FindControl("lblIdQuincena"), Label)

        Dim oEmp As New Empleado
        oEmp.EliminaDiasParaPagoQnal(CInt(lblIdEmp.Text), CShort(lblIdQuincena.Text), CType(Session("ArregloAuditoria"), String()))

        If e.RowIndex = Me.gvEmps.SelectedIndex Then Me.gvEmps.SelectedIndex = -1

        BindgvEmps(e.RowIndex)
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        'If Request.Params(1).Contains("BtnSearch") Then
        '    BindDatos()
        'ElseIf Request.Params(1).Contains("BtnNewSearch") Then
        '    SubCancelingEditgvEmps()
        '    Me.ddlAños.Enabled = False
        '    Me.btnConsultarQuincenas.Enabled = False
        '    Me.gvEmps.Enabled = False
        'ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
        '    gvEmps.Enabled = True
        '    SubActualizar()
        'End If

        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(1).Contains("BtnSearch") Then
                'If hfRFC.Value <> String.Empty Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    SubActualizar()
                    pnl1.Visible = True
                Else
                    pnl1.Visible = False
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                SubActualizar()
                Me.pnl1.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                Me.pnl1.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    SubActualizar()
                    pnl1.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.gvEmps.EditIndex = -1
        BindDatos()
        Me.gvEmps.Columns(0).Visible = True 'Select
        'Me.gvEmps.Columns(6).Visible = True 'Delete

        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsDiasParaPagoQnal")
        Me.gvEmps.Columns(6).Visible = CBool(dt.Rows(0).Item("Eliminacion"))

    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        SubActualizar()
    End Sub
End Class
