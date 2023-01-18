Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports System.Data
Imports System.Drawing
Partial Class MovsDePersonal_NivelesSalariales
    Inherits System.Web.UI.Page
    Private Sub BindddlNivelesSalariales(ByVal pIdQuincena As Short)
        Dim oNivSalarial As New NivelesSalariales
        Dim dt As DataTable

        dt = oNivSalarial.GetPorQna(CShort(Request.Params("pIdQuincena")))

        ddlNivelesSalariales.DataSource = dt
        ddlNivelesSalariales.DataValueField = "NivelSalarial"
        ddlNivelesSalariales.DataTextField = "NivelSalarial"
        ddlNivelesSalariales.DataBind()
    End Sub

    Private Sub BindDatos(ByVal pNivelSalarial As String, ByVal pIdQuincena As Short)
        Dim oPuesto As New Puestos
        Dim dt As DataTable

        dt = oPuesto.GetNivelSalarialPorQna(pNivelSalarial, pIdQuincena)

        Me.gvNivelesSalariales.DataSource = dt
        Me.gvNivelesSalariales.DataBind()
    End Sub

    Protected Sub gvNivelesSalariales_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvNivelesSalariales.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ChkBxSeleccionar As CheckBox = CType(e.Row.FindControl("ChkBxSeleccionar"), CheckBox)

                If ChkBxSeleccionar.Checked Then e.Row.RowState = DataControlRowState.Selected

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then

            Dim ddlAños As DropDownList = CType(wucAnioQnas1.FindControl("ddlAños"), DropDownList)
            Dim ddlQnasPagadas As DropDownList = CType(wucAnioQnas1.FindControl("ddlQnasPagadas"), DropDownList)
            If ddlAños.SelectedValue = "-1" Or ddlQnasPagadas.SelectedValue = "-1" Then
                Label1.Visible = False
                btnConsultar.Enabled = False
                gvNivelesSalariales.DataBind()
            Else
                If ddlQnasPagadas.SelectedValue = "-1" Then
                    Label1.Visible = False
                    btnConsultar.Enabled = False
                    gvNivelesSalariales.DataBind()
                Else
                    Label1.Text = "Información obtenida con base en la quincena: " + Request.Params("pQuincena").ToString
                    Label1.Visible = True
                    btnConsultar.Enabled = True
                    ddlAños.SelectedValue = Left(Request.Params("pQuincena").ToString, 4)
                    ddlQnasPagadas.SelectedItem.Text = Request.Params("pQuincena").ToString
                    BindddlNivelesSalariales(CShort(Request.Params("pIdQuincena")))
                    ddlNivelesSalariales.SelectedValue = Request.Params("pNivelSalarial").ToString
                    BindDatos(Request.Params("pNivelSalarial").ToString, CShort(Request.Params("pIdQuincena")))
                    ' BindDatos(CShort(ddlQnasPagadas.SelectedValue))
                End If
            End If
        End If
        'If Not IsPostBack Then
        '    Label1.Text = "Información obtenida con base en la quincena: " + Request.Params("pQuincena")
        '    Label1.Visible = True
        '    BindDatos()
        'End If
    End Sub

    Protected Sub gvNivelesSalariales_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvNivelesSalariales.SelectedIndexChanged
        'BindDatos()
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click
        Dim ddlQnasPagadas As DropDownList = CType(wucAnioQnas1.FindControl("ddlQnasPagadas"), DropDownList)
        Label1.Text = "Información obtenida con base en la quincena: " + ddlQnasPagadas.SelectedItem.Text
        Label1.Visible = True
        btnConsultar.Enabled = True
        'BindddlNivelesSalariales(CShort(Request.Params("pIdQuincena")))
        gvNivelesSalariales.SelectedIndex = -1
        BindDatos(ddlNivelesSalariales.SelectedValue, CShort(ddlQnasPagadas.SelectedValue))
    End Sub
End Class
