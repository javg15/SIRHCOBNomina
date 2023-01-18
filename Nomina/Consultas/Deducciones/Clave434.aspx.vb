Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Administracion
Partial Class ConsultasDeduccionesClave434
    Inherits System.Web.UI.Page
    Private Sub BindgvHistoriaClave434()
        Dim oDeduc As New Deduccion
        Dim oEmp As New Empleado
        Dim dr As DataRow
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oUsr As New Usuario
        Dim dt As DataTable

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "HistoriaDeduccion434")

        If hfRFC.Value.Trim <> String.Empty Then
            dr = oEmp.BuscarPorRFC(hfRFC.Value)

            gvEmpleado.DataSource = dr.Table
            gvEmpleado.DataBind()

            Me.gvHistoriaClave434.DataSource = oDeduc.HistPrestHipFOVISSSTE(CInt(dr("IdEmp")))
            Me.gvHistoriaClave434.DataBind()

            If gvHistoriaClave434.Rows.Count = 0 Then
                Me.gvHistoriaClave434.EmptyDataText = "Sin información de préstamos hipotecarios FOVISSSTE."
                Me.gvHistoriaClave434.DataBind()
            End If

            gvHistoriaClave434.Visible = True
            gvEmpleado.Visible = True
            pnl1.Visible = True
        Else
            gvHistoriaClave434.Visible = False
            gvEmpleado.Visible = False
            pnl1.Visible = True
        End If
        gvHistoriaClave434.Columns(6).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
    End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
    '        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
    '        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
    '        Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
    '        ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false;")
    '    End If
    'End Sub
    Protected Sub ibActualizar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindgvHistoriaClave434()
    End Sub

    Protected Sub gvHistoriaClave434_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvHistoriaClave434.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdEmp As Label = CType(gvEmpleado.Rows(0).FindControl("lblIdEmp"), Label)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)

                If e.Row.RowIndex = 0 Then
                    ibModificar.OnClientClick = "javascript:abreVentMedAncha('HistoriaClave434.aspx?TipoOperacion=0&IdEmp=" + lblIdEmp.Text + "');"
                Else
                    ibModificar.Visible = False
                End If
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvHistoriaClave434, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub ibModificar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        BindgvHistoriaClave434()
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If IsPostBack = False Then
            BindgvHistoriaClave434()
        End If
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            If Request.Params(1).Contains("BtnSearch") Then
                If hfRFC.Value <> String.Empty Then
                    BindgvHistoriaClave434()
                    pnl1.Visible = True
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                Me.pnl1.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                Me.pnl1.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindgvHistoriaClave434()
                    pnl1.Visible = True
                End If
            End If
        End If
    End Sub
End Class
