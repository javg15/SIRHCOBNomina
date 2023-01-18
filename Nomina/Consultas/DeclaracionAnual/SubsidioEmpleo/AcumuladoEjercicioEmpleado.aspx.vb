Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion

Partial Class SubsidioEmpleoAcumuladoEjercicioEmpleado
    Inherits System.Web.UI.Page
    Private Sub BindddlAños()
        Dim oEjercicioFiscal As New EjercicioFiscal
        With Me.ddlAños
            .DataSource = oEjercicioFiscal.ObtenAños()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, New ListItem("No existe información de años", "-1"))
                Me.btnConsultar.Enabled = False
                Me.ChkBxSubsidioParaEmpleo.Enabled = False
                Me.ChkBxSubsidioParaEmpleo.Checked = False
            Else
                Me.btnConsultar.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindgvAcumulado()
        Dim dtPermisos As DataTable
        Dim oUsr As New Usuario
        Dim drEmpsSinAplicDeSubsidioParaEmpleo As DataRow
        Dim oEjercicioFiscal As New EjercicioFiscal
        Dim drEjericioFiscal As DataRow
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oEmp As New Empleado
        Dim ds As DataSet
        Me.lblMsj.Text = String.Empty
        If hfRFC.Value.Trim <> String.Empty Then
            Me.lblMsj.Text = "Subsidio para el empleo acumulado durante el ejercicio " + Me.ddlAños.SelectedItem.Text + "<br />por el empleado " + hfNomEmp.Value
            ds = oEmp.ObtenSubsidioParaEmpleoAcumulado(hfRFC.Value, CShort(Me.ddlAños.SelectedValue))
            drEmpsSinAplicDeSubsidioParaEmpleo = oEmp.ObtenEmpsSinAplicDeSubsidioParaEmpleo(hfRFC.Value, CShort(Me.ddlAños.SelectedValue))
            Me.gvAcumulado.DataSource = ds.Tables(0)
            Me.gvTotalAcumulado.DataSource = ds.Tables(1)
            Me.ddlAños.Enabled = True
            Me.btnConsultar.Enabled = True

            dtPermisos = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsSinAplicDeSubsidioParaEmpleo")
            drEjericioFiscal = oEjercicioFiscal.ObtenDetalles(CShort(Me.ddlAños.SelectedValue))
            Me.ChkBxSubsidioParaEmpleo.Enabled = False
            Me.ChkBxSubsidioParaEmpleo.Checked = CBool(drEmpsSinAplicDeSubsidioParaEmpleo("EmpSinAplicDeSubsidioParaEmpleo"))
            Me.ChkBxSubsidioParaEmpleo.Visible = True
            Me.lblAnio.Text = Me.ddlAños.SelectedValue
            Me.btnModificar.Text = "Modificar"
            Me.btnModificar.Visible = CBool(dtPermisos.Rows(0).Item("Actualizacion")) And Not CBool(drEjericioFiscal("Concluido")) And CBool(drEjericioFiscal("PermiteCapturaNoSubsidio"))
            Me.btnGuardar.Visible = False
        Else
            Me.ddlAños.Enabled = False
            Me.btnConsultar.Enabled = False
            Me.ChkBxSubsidioParaEmpleo.Visible = False
            Me.lblAnio.Text = ""
            Me.btnModificar.Visible = False
            Me.btnGuardar.Visible = False
        End If
        Me.gvAcumulado.DataBind()
        Me.gvTotalAcumulado.DataBind()
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Protected Sub gvAcumulado_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAcumulado.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvAcumulado, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If IsPostBack = False Then
    '        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
    '        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
    '        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
    '        Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
    '        ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); ")
    '    End If
    'End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindgvAcumulado()
            End If
        End If
    End Sub
    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindddlAños()
        If Me.ddlAños.SelectedValue <> -1 Then
            BindgvAcumulado()
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        BindgvAcumulado()
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        'If Request.Params(1).Contains("ibBuscarEmp") Then
        '    If Me.ddlAños.SelectedValue <> -1 Then
        '        BindgvAcumulado()
        '    End If
        'End If
        If IsPostBack Then
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    BindgvAcumulado()
                    pnlAños.Visible = True
                    pnl1.Visible = True
                    pnl2.Visible = True
                Else
                    pnlAños.Visible = False
                    pnl1.Visible = False
                    pnl2.Visible = False
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                pnlAños.Visible = False
                pnl1.Visible = False
                pnl2.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                pnlAños.Visible = True
                pnl1.Visible = True
                pnl2.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindgvAcumulado()
                    pnlAños.Visible = True
                    pnl1.Visible = True
                    pnl2.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.btnModificar.Text = "Modificar" Then
            Me.ChkBxSubsidioParaEmpleo.Enabled = True
            Me.btnModificar.Text = "Cancelar"
            Me.btnGuardar.Visible = True
        Else
            BindgvAcumulado()
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim oEmp As New Empleado

            oEmp.ActualizaEmpsSinAplicDeSubsidioParaEmpleo(hfRFC.Value, CShort(Me.lblAnio.Text), Me.ChkBxSubsidioParaEmpleo.Checked, CType(Session("ArregloAuditoria"), String()))
            BindgvAcumulado()
        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
End Class