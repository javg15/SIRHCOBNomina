Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class wucEfectos2
    Inherits System.Web.UI.UserControl
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        If dt.Rows.Count > 0 Then
            ddl.DataSource = dt
            ddl.DataTextField = TextField
            ddl.DataValueField = ValueField
            ddl.DataBind()
            If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oQna As New Quincenas
            If ddlQnaInicio.Items.Count = 0 Then
                LlenaDDL(Me.ddlQnaInicio, "Quincena", "IdQuincena", oQna.ObtenAbiertasParaCaptura(), String.Empty)
            End If
            LlenaDDL(Me.ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(Me.ddlQnaInicio.SelectedValue, Short), True), String.Empty)
            Me.ddlQnaFin.SelectedIndex = Me.ddlQnaFin.Items.Count - 1
        End If
    End Sub

    Protected Sub ddlQnaInicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlQnaInicio.SelectedIndexChanged
        If Not chbxEspecificarNumQuincenas.Checked Then
            Dim oQna As New Quincenas
            LlenaDDL(Me.ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(Me.ddlQnaInicio.SelectedValue, Short), True), String.Empty)
            Me.ddlQnaFin.SelectedIndex = Me.ddlQnaFin.Items.Count - 1
        Else
            With CVNumQnas
                .ErrorMessage = "Valor debe ser mayor de 0"
                .ValueToCompare = "1"
            End With
            'chbxEspecificarNumQuincenas_CheckedChanged(sender, e)
        End If
    End Sub

    Protected Sub chbxEspecificarNumQuincenas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbxEspecificarNumQuincenas.CheckedChanged
        If Me.hfQnaFin.Value.Trim <> String.Empty And Not chbxEspecificarNumQuincenas.Checked Then
            Dim oQna As New Quincenas
            If Not Me.ddlQnaInicio.Enabled Then
                LlenaDDL(Me.ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenAbiertasParaCaptura(), String.Empty)
                ddlQnaFin.Items.Insert(0, "999999")
                ddlQnaFin.Items(0).Value = "0"
                Me.ddlQnaFin.SelectedIndex = Me.ddlQnaFin.Items.Count - 1
            Else
                LlenaDDL(Me.ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(Me.ddlQnaInicio.SelectedValue, Short), True), String.Empty)
                Me.ddlQnaFin.SelectedIndex = Me.ddlQnaFin.Items.Count - 1
            End If
        ElseIf Me.hfQnaFin.Value.Trim <> String.Empty And chbxEspecificarNumQuincenas.Checked Then
            ddlQnaFin.Items.Clear()
            ddlQnaFin.Items.Insert(0, Me.hfQnaFin.Value)
            ddlQnaFin.Items(0).Value = "-1"
        End If
        ddlQnaFin.Enabled = Not chbxEspecificarNumQuincenas.Checked
        lblTermino.Enabled = Not chbxEspecificarNumQuincenas.Checked
        txtbxNumQnas.Enabled = chbxEspecificarNumQuincenas.Checked
        RFVNumQnas.Enabled = txtbxNumQnas.Enabled
        CVNumQnas.Enabled = txtbxNumQnas.Enabled
    End Sub
End Class
