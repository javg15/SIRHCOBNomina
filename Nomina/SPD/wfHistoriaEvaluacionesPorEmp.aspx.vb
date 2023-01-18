Imports System.Data
Imports DataAccessLayer.COBAEV.SPD

Partial Class wfHistoriaEvaluacionesPorEmp
    Inherits System.Web.UI.Page
    Private Sub ConfiguraItemsPagina()
        Dim oEvaluaciones As New Evaluaciones
        Dim dt As DataTable
        Dim hfRFC As HiddenField = CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)
        Dim txtbxNomEmp As TextBox = CType(wucBuscaEmps.FindControl("txtbxNomEmp"), TextBox)

        lblLegend.Text = "Historial encontrado de: " + txtbxNomEmp.Text

        dt = oEvaluaciones.ObtenPorEmpleado(hfRFC.Value)

        If dt.Rows.Count > 0 Then
            gvHistoriaEvaluaciones.DataSource = dt
        End If

        gvHistoriaEvaluaciones.DataBind()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim hfRFC As HiddenField = CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)

            If hfRFC.Value <> String.Empty Then
                ConfiguraItemsPagina()
                pnlCaptura.Visible = True
            Else
                pnlCaptura.Visible = False
            End If
        End If
    End Sub

    Protected Sub wucBuscaEmps_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles wucBuscaEmps.PreRender
        If IsPostBack Then
            Dim txtbxRFC As TextBox = CType(wucBuscaEmps.FindControl("txtbxRFC"), TextBox)

            If Request.Params(0).Contains("BtnSearch") Or Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    ConfiguraItemsPagina()
                    pnlCaptura.Visible = True
                Else
                    pnlCaptura.Visible = False
                End If
            ElseIf Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnNewSearch") Then
                pnlCaptura.Visible = False
            ElseIf Request.Params(0).Contains("BtnCancelSearch") Or Request.Params(1).Contains("BtnCancelSearch") Then
                pnlCaptura.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    ConfiguraItemsPagina()
                    pnlCaptura.Visible = True
                End If
            End If
        End If
    End Sub
End Class
