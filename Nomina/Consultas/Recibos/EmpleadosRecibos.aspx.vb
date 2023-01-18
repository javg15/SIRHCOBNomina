Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Partial Class Consultas_Recibos_EmpleadosRecibos
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        If dt.Rows.Count > 0 Then
            ddl.DataSource = dt
            ddl.DataTextField = TextField
            ddl.DataValueField = ValueField
            ddl.DataBind()
            If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        End If
    End Sub
    Private Sub BindgvEmps()
        Dim oRecibo As New Recibos
        With gvEmps
            .DataSource = oRecibo.ObtenEmpleados()
            .DataBind()
        End With
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oUsr As New Usuario
            Dim dt As DataTable
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpleadosRecibos")
            Me.lbAgregarEmps.Visible = CBool(dt.Rows(0).Item("Insercion"))
            Me.gvEmps.Columns(11).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            Me.gvEmps.Columns(12).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
            BindgvEmps()
            Me.lbAgregarEmps.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Recibos/AgregarEmpsParaRecibos.aspx?TipoOperacion=1');"
        End If
    End Sub
    Protected Sub gvEmps_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmps.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lbRFCEmp As LinkButton = CType(e.Row.FindControl("lbRFCEmp"), LinkButton)
                Dim lblIdEmp As Label = CType(e.Row.FindControl("lblIdEmp"), Label)
                Dim lblIdQnaIni As Label = CType(e.Row.FindControl("lblIdQnaIni"), Label)
                Dim lblIdQnaFin As Label = CType(e.Row.FindControl("lblIdQnaFin"), Label)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                If Me.gvEmps.EditIndex = -1 Then
                    Dim oRecibo As New Recibos
                    ibEliminar.Enabled = oRecibo.ValidaSiProcedeEliminarEmpleadosRecibos(CInt(lblIdEmp.Text), CShort(lblIdQnaIni.Text), CShort(lblIdQnaFin.Text))
                End If
                lbRFCEmp.CommandArgument = e.Row.RowIndex
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub
    Protected Sub gvEmps_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEmps.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Dim lbRFCEmp As LinkButton = CType(Me.gvEmps.Rows(e.CommandArgument).FindControl("lbRFCEmp"), LinkButton)
                Dim oEmp As New Empleado
                Dim dr As DataRow
                dr = oEmp.BuscarPorRFC(lbRFCEmp.Text)
                Session.Add("RFCParaCons", dr("RFC"))
                Session.Add("CURPParaCons", dr("CURP"))
                Session.Add("ApePatParaCons", dr("ApellidoPaterno"))
                Session.Add("ApeMatParaCons", dr("ApellidoMaterno"))
                Session.Add("NombreParaCons", dr("Nombre"))
                Session.Add("NumEmpParaCons", dr("NumEmp"))
        End Select
    End Sub
    Protected Sub gvEmps_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvEmps.RowCancelingEdit
        Me.gvEmps.Columns(0).Visible = True 'Select
        Me.gvEmps.Columns(12).Visible = True 'Delete
        Me.gvEmps.SelectedIndex = e.RowIndex
        Me.gvEmps.EditIndex = -1
        BindgvEmps()
    End Sub

    Protected Sub gvEmps_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvEmps.RowEditing
        Me.gvEmps.Columns(0).Visible = False 'Select
        Me.gvEmps.Columns(12).Visible = False 'Delete
        Me.gvEmps.SelectedIndex = -1
        Me.gvEmps.EditIndex = e.NewEditIndex
        BindgvEmps()
        Dim fila As Integer = Me.gvEmps.EditIndex
        Dim lblIdEmp As Label = CType(Me.gvEmps.Rows(fila).FindControl("lblIdEmp"), Label)
        Dim lblIdQnaIni As Label = CType(Me.gvEmps.Rows(fila).FindControl("lblIdQnaIni"), Label)
        Dim lblIdQnaFin As Label = CType(Me.gvEmps.Rows(fila).FindControl("lblIdQnaFin"), Label)
        Dim ddlQnasFin As DropDownList = CType(Me.gvEmps.Rows(fila).FindControl("ddlQnasFin"), DropDownList)

        Dim oRecibo As New Recibos
        LlenaDDL(ddlQnasFin, "Quincena", "IdQuincena", oRecibo.ObtenQnasParaVigFin(CShort(lblIdQnaIni.Text), CShort(lblIdQnaFin.Text)), lblIdQnaFin.Text)
    End Sub

    Protected Sub gvEmps_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvEmps.RowUpdating
        Dim lblIdEmp As Label = CType(Me.gvEmps.Rows(e.RowIndex).FindControl("lblIdEmp"), Label)
        Dim lblIdQnaIni As Label = CType(Me.gvEmps.Rows(e.RowIndex).FindControl("lblIdQnaIni"), Label)
        Dim ddlQnasFin As DropDownList = CType(Me.gvEmps.Rows(e.RowIndex).FindControl("ddlQnasFin"), DropDownList)

        Dim oRecibo As New Recibos

        oRecibo.ActualizaEmpleadosRecibos(CInt(lblIdEmp.Text), CShort(lblIdQnaIni.Text), CShort(ddlQnasFin.SelectedValue), CType(Session("ArregloAuditoria"), String()))

        Me.gvEmps.Columns(0).Visible = True 'Select
        Me.gvEmps.Columns(12).Visible = True 'Delete        
        Me.gvEmps.SelectedIndex = e.RowIndex
        Me.gvEmps.EditIndex = -1
        BindgvEmps()
    End Sub
    Protected Sub gvEmps_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvEmps.SelectedIndexChanged

    End Sub

    Protected Sub gvEmps_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvEmps.RowDeleting
        Dim lblIdEmp As Label = CType(Me.gvEmps.Rows(e.RowIndex).FindControl("lblIdEmp"), Label)
        Dim lblIdQnaIni As Label = CType(Me.gvEmps.Rows(e.RowIndex).FindControl("lblIdQnaIni"), Label)

        Dim oRecibo As New Recibos
        oRecibo.EliminaEmpleadosRecibos(CInt(lblIdEmp.Text), CShort(lblIdQnaIni.Text), CType(Session("ArregloAuditoria"), String()))

        If e.RowIndex = Me.gvEmps.SelectedIndex Then Me.gvEmps.SelectedIndex = -1

        BindgvEmps()
    End Sub

    Protected Sub lbAgregarEmps_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAgregarEmps.Click
        BindgvEmps()
    End Sub
End Class
