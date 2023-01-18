Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Administracion
Partial Class ConsultasDeduccionesClave431
    Inherits System.Web.UI.Page
    Private Sub BindgvHistoriaClave431()
        Dim oDeduc As New Deduccion
        Dim oEmp As New Empleado
        Dim dr As DataRow
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "HistoriaDeduccionesPorEmpleado")

        If hfRFC.Value.Trim <> String.Empty Then
            dr = oEmp.BuscarPorRFC(hfRFC.Value)

            gvEmpleado.DataSource = dr.Table
            gvEmpleado.DataBind()

            Me.gvHistoriaClave431.DataSource = oDeduc.HistPrestamoISSSTE(CInt(dr("IdEmp")))
            Me.gvHistoriaClave431.DataBind()

            If gvHistoriaClave431.Rows.Count = 0 Then
                Me.gvHistoriaClave431.EmptyDataText = "Sin información de préstamos ISSSTE."
                Me.gvHistoriaClave431.DataBind()
            End If

            gvHistoriaClave431.Visible = True
            gvEmpleado.Visible = True
            pnl1.Visible = True
        Else
            gvHistoriaClave431.Visible = False
            gvEmpleado.Visible = False
            pnl1.Visible = True
        End If

        gvHistoriaClave431.Columns(10).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            'Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            'Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false;")
        End If
    End Sub
    Protected Sub ibActualizar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindgvHistoriaClave431()
    End Sub

    Protected Sub gvHistoriaClave431_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvHistoriaClave431.RowCancelingEdit
        gvHistoriaClave431.SelectedIndex = e.RowIndex
        gvHistoriaClave431.EditIndex = -1
        BindgvHistoriaClave431()
    End Sub

    'Protected Sub gvHistoriaClave434_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvHistoriaClave431.RowDataBound
    '    Select Case e.Row.RowType
    '        Case DataControlRowType.DataRow
    '            'Dim lblIdEmp As Label = CType(gvEmpleado.Rows(0).FindControl("lblIdEmp"), Label)
    '            'Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)

    '            'If e.Row.RowIndex = 0 Then
    '            '    ibModificar.OnClientClick = "javascript:abreVentanaChica('HistoriaClave434.aspx?TipoOperacion=0&IdEmp=" + lblIdEmp.Text + "');"
    '            'Else
    '            '    ibModificar.Visible = False
    '            'End If
    '            'e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
    '            'e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
    '            'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvHistoriaClave431, "Select$" + e.Row.RowIndex.ToString)
    '    End Select
    'End Sub

    Protected Sub ibModificar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        BindgvHistoriaClave431()
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If IsPostBack = False Then
            BindgvHistoriaClave431()
        End If
    End Sub

    Protected Sub gvHistoriaClave431_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvHistoriaClave431.RowEditing
        'Me.gvHistoriaClave431.Columns(0).Visible = False 'Select
        'Me.gvSemestres.Columns(13).Visible = False 'Delete
        gvHistoriaClave431.SelectedIndex = -1
        gvHistoriaClave431.EditIndex = e.NewEditIndex
        BindgvHistoriaClave431()

        Dim tbNumPrestamoISSSTE As TextBox = CType(gvHistoriaClave431.Rows(e.NewEditIndex).FindControl("tbNumPrestamoISSSTE"), TextBox)
        If Not IsNumeric(tbNumPrestamoISSSTE.Text) Then
            tbNumPrestamoISSSTE.Text = String.Empty
        End If
    End Sub

    Protected Sub gvHistoriaClave431_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvHistoriaClave431.RowUpdating
        Dim tbNumPrestamoISSSTE As TextBox = CType(gvHistoriaClave431.Rows(e.RowIndex).FindControl("tbNumPrestamoISSSTE"), TextBox)
        Dim lblIdQnaIni As Label = CType(gvHistoriaClave431.Rows(e.RowIndex).FindControl("lblIdQnaIni"), Label)
        Dim lblIdQnaFin As Label = CType(gvHistoriaClave431.Rows(e.RowIndex).FindControl("lblIdQnaFin"), Label)
        Dim lblIdEmp As Label = CType(gvEmpleado.Rows(0).FindControl("lblIdEmp"), Label)
        Dim lblIdDeduccion As Label = CType(gvHistoriaClave431.Rows(e.RowIndex).FindControl("lblIdDeduccion"), Label)

        Dim oDeduc As New Deduccion

        oDeduc.UpdPrestamoISSSTE(tbNumPrestamoISSSTE.Text, CInt(lblIdEmp.Text), CShort(lblIdQnaIni.Text), CShort(lblIdQnaFin.Text), CShort(lblIdDeduccion.Text), CType(Session("ArregloAuditoria"), String()))

        gvHistoriaClave431.SelectedIndex = e.RowIndex
        gvHistoriaClave431.EditIndex = -1
        BindgvHistoriaClave431()
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            If Request.Params(1).Contains("BtnSearch") Then
                If hfRFC.Value <> String.Empty Then
                    gvHistoriaClave431.EditIndex = -1
                    BindgvHistoriaClave431()
                    pnl1.Visible = True
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                gvHistoriaClave431.EditIndex = -1
                BindgvHistoriaClave431()
                Me.pnl1.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                BindgvHistoriaClave431()
                Me.pnl1.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    gvHistoriaClave431.EditIndex = -1
                    BindgvHistoriaClave431()
                    pnl1.Visible = True
                End If
            End If
        End If
    End Sub
End Class
