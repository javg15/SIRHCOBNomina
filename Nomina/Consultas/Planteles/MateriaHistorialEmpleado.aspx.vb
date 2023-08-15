﻿Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Plazas
Imports DataAccessLayer.COBAEV

Partial Class MateriaHistorialEmpleado
    Inherits System.Web.UI.Page

    Private Property sortOrder As String
        Get
            If (ViewState("sortOrder").ToString() = "desc") Then
                ViewState("sortOrder") = "asc"
            Else
                ViewState("sortOrder") = "desc"
            End If

            Return ViewState("sortOrder").ToString()
        End Get

        Set(value As String)
            ViewState("sortOrder") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("sortOrder") = ""
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos(Request.Params("Grupo"))
        End If
    End Sub

    Private Sub BindDatos(Optional ByVal pSortExpression As String = "Grupo", Optional ByVal pSortDirection As String = "asc")
        Dim oPlantel As New Plantel
        Dim myDataView As New DataView()

        Dim EncabezadoSeleccionado As Boolean = False

        Dim dt As DataTable = oPlantel.ObtenEmpsHistorial(Request.Params("IdPlantel"), Request.Params("IdMateria"), Request.Params("IdEmpleado"))
        Dim dt2 As DataTable = oPlantel.ObtenEmpsHistorial(Request.Params("IdPlantel"), Request.Params("IdMateria"), Request.Params("IdEmpleado"))

        For i As Integer = dt2.Rows.Count - 1 To 0 Step -1
            If dt2.Rows(i).Item("IdEmp") <> Request.Params("IdEmpleado") Or EncabezadoSeleccionado = True Then
                dt2.Rows.Remove(dt2.Rows(i))
            ElseIf dt2.Rows(i).Item("IdEmp") = Request.Params("IdEmpleado") And EncabezadoSeleccionado = False Then
                EncabezadoSeleccionado = True
            End If
        Next
        gvEmpleado.DataSource = dt2
        gvEmpleado.DataBind()

        myDataView = dt.DefaultView

        If (pSortExpression <> String.Empty) Then
            Select Case pSortExpression
                Case "Grupo"
                    myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
                Case "QuincenaIni"
                    myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
                Case "QuincenaFin"
                    myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
                Case "Semestre"
                    myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
            End Select
        End If

        '-----------
        ddlGrupo.DataSource = dt.DefaultView.ToTable(True, {"IdGrupo", "Grupo"})
        ddlGrupo.DataTextField = "Grupo"
        ddlGrupo.DataValueField = "IdGrupo"
        ddlGrupo.DataBind()
        ddlGrupo.SelectedValue = Request.Params("IdGrupo")

        Dim dtDocente As New DataTable
        dtDocente = dt.DefaultView.ToTable(True, {"IdEmp", "ApePatEmp", "ApeMatEmp", "NomEmp"})

        Dim row As DataRow
        row = dtDocente.NewRow()
        row(0) = 0
        row(1) = "-"
        row(2) = "-Todos-"
        row(3) = "-"
        dtDocente.Rows.InsertAt(row, 0)
        ddlDocente.DataSource = dtDocente
        ddlDocente.DataSource.Columns.Add("NombreEmpleado", GetType(String), "ApePatEmp + ' ' + ApeMatEmp + ' ' + NomEmp")
        ddlDocente.DataTextField = "NombreEmpleado"
        ddlDocente.DataValueField = "IdEmp"
        ddlDocente.DataBind()
        ddlDocente.SelectedValue = Request.Params("IdEmpleado")

        myDataView.RowFilter = "IdGrupo = '" + ddlGrupo.SelectedValue + "' And IdEmp = '" + ddlDocente.SelectedValue + "'"
        gvDatos.DataSource = myDataView
        gvDatos.DataBind()

    End Sub

    Protected Sub gvDatos_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvDatos.Sorting
        BindDatos(e.SortExpression, sortOrder)
    End Sub

    Protected Sub gvDatos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDatos.RowDataBound
        'Dim lblIdEmp As Label = CType(e.Row.FindControl("lblIdEmp"), Label)

        'Select Case e.Row.RowType
        ' Case DataControlRowType.DataRow
        'If lblIdEmp.Text = Request.Params("IdEmpleado") Then
        'e.Row.BackColor = Drawing.Color.Orange
        'End If
        'End Select
    End Sub

    Protected Sub gvEmpleado_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvEmpleado.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.BackColor = Drawing.Color.Orange
        End Select
    End Sub
    Protected Sub ddlGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlGrupo.SelectedIndexChanged
        Dim oPlantel As New Plantel
        Dim myDataView As New DataView()
        Dim dt As DataTable = oPlantel.ObtenEmpsHistorial(Request.Params("IdPlantel"), Request.Params("IdMateria"), Request.Params("IdEmpleado"))

        myDataView = dt.DefaultView

        If ddlDocente.SelectedValue <> "0" Then
            myDataView.RowFilter = "IdGrupo = '" + ddlGrupo.SelectedValue + "' And IdEmp = '" + ddlDocente.SelectedValue + "'"
        Else
            myDataView.RowFilter = "IdGrupo = '" + ddlGrupo.SelectedValue + "'"
        End If

        gvDatos.DataSource = myDataView
        gvDatos.DataBind()
    End Sub
    Protected Sub ddlDocente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDocente.SelectedIndexChanged
        Dim oPlantel As New Plantel
        Dim myDataView As New DataView()
        Dim dt As DataTable = oPlantel.ObtenEmpsHistorial(Request.Params("IdPlantel"), Request.Params("IdMateria"), Request.Params("IdEmpleado"))

        myDataView = dt.DefaultView

        If ddlDocente.SelectedValue <> "0" Then
            myDataView.RowFilter = "IdGrupo = '" + ddlGrupo.SelectedValue + "' And IdEmp = '" + ddlDocente.SelectedValue + "'"
        Else
            myDataView.RowFilter = "IdGrupo = '" + ddlGrupo.SelectedValue + "'"
        End If

        gvDatos.DataSource = myDataView
        gvDatos.DataBind()
    End Sub
End Class
