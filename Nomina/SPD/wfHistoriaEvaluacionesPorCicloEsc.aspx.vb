Imports System.Data
Imports DataAccessLayer.COBAEV.SPD
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Empleados

Partial Class wfHistoriaEvaluacionesPorCicloEsc
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub ConfiguraItemsPagina()
        Dim oEvaluaciones As New Evaluaciones
        Dim dt As DataTable

        lblLegend.Text = "Historial encontrado del ciclo escolar: " + ddlCiclosEscolares.SelectedItem.Text

        dt = oEvaluaciones.ObtenPorCicloEscolar(CByte(ddlCiclosEscolares.SelectedValue))

        If dt.Rows.Count > 0 Then
            gvHistoriaEvaluaciones.DataSource = dt
        End If

        gvHistoriaEvaluaciones.DataBind()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim oCOBACH As New CiclosEscolares

            LlenaDDL(ddlCiclosEscolares, "CicloEscolar", "IdCicloEsc", oCOBACH.ObtenCiclosEscolares(), Nothing)

            If ddlCiclosEscolares.SelectedValue <> "-1" Then
                ConfiguraItemsPagina()
                pnlCaptura.Visible = True
            Else
                pnlCaptura.Visible = False
            End If
        End If
    End Sub

    Protected Sub ddlCiclosEscolares_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCiclosEscolares.SelectedIndexChanged
        ConfiguraItemsPagina()
    End Sub

    Protected Sub lnkbtnRFC_Click(sender As Object, e As System.EventArgs)
        Dim vlRFC As String = CType(sender, LinkButton).Text
        Dim oEmp As New Empleado
        Dim dr As DataRow
        Dim dt As DataTable

        dr = oEmp.BuscarPorRFC(vlRFC)

        Dim oEvaluaciones As New Evaluaciones

        lblLegend2.Text = "Historial de evaluaciones realizadas por: " + (dr("ApellidoPaterno").ToString + " " + dr("ApellidoMaterno").ToString _
                                                        + " " + dr("Nombre").ToString).ToString.Trim

        dt = oEvaluaciones.ObtenPorEmpleado(vlRFC)

        If dt.Rows.Count > 0 Then
            gvHistoriaEvaluacionesEmp.DataSource = dt
        End If

        gvHistoriaEvaluacionesEmp.DataBind()

        Me.ibNuevosValores_MPE.Show()
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.ibNuevosValores_MPE.Hide()
    End Sub
End Class
