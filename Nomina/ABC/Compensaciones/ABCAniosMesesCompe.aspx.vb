Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class Admon_ABCAniosMesesCompe
    Inherits System.Web.UI.Page
    Private Sub SetVisibilidadDeColumnas()
        Dim oUsr As New Usuario
        Dim dt As DataTable
        Dim dr As DataRow
        Dim oCompe As New Compensacion

        dr = oCompe.ValidaSiHayMesAbiertoParaCaptura()

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "AniosMesesCompensaciones")
        Me.gvAniosMesesCompe.Columns(14).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        Me.gvAniosMesesCompe.Columns(15).Visible = False
        Me.gvAniosMesesCompe.Columns(16).Visible = CBool(dt.Rows(0).Item("Insercion"))
        Me.lbAddMesAdic.Visible = CBool(dt.Rows(0).Item("Insercion")) And CBool(dr("MesAdicAbierto")) = True
    End Sub
    Private Sub BindddlAños()
        Dim oCompensacion As New Compensacion
        With Me.ddlAños
            .DataSource = oCompensacion.ObtenAñosPagados()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
            End If
        End With
    End Sub
    Private Sub BindgvAniosMesesCompe()
        Dim oCompe As New Compensacion
        Me.gvAniosMesesCompe.DataSource = oCompe.ObtenMesesPorAnio(Me.ddlAños.SelectedValue)
        Me.gvAniosMesesCompe.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindddlAños()
            BindgvAniosMesesCompe()
            SetVisibilidadDeColumnas()
        End If
    End Sub
    Protected Sub gvAniosMesesCompe_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAniosMesesCompe.SelectedIndexChanged
    End Sub

    Protected Sub gvAniosMesesCompe_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvAniosMesesCompe.RowEditing
        Me.gvAniosMesesCompe.Columns(0).Visible = False
        Me.gvAniosMesesCompe.Columns(16).Visible = False
        Me.gvAniosMesesCompe.SelectedIndex = -1
        Me.gvAniosMesesCompe.EditIndex = e.NewEditIndex
        BindgvAniosMesesCompe()

        Dim oCompe As New Compensacion
        Dim fila As Integer = Me.gvAniosMesesCompe.EditIndex
        Dim ChkBxISRRecalculado_E As CheckBox = CType(Me.gvAniosMesesCompe.Rows(fila).FindControl("ChkBxISRRecalculado_E"), CheckBox)
        Dim lblAnio_E As Label = CType(Me.gvAniosMesesCompe.Rows(fila).FindControl("lblAnio_E"), Label)
        Dim lblIdMes_E As Label = CType(Me.gvAniosMesesCompe.Rows(fila).FindControl("lblIdMes_E"), Label)
        Dim lblAdicional_E As Label = CType(Me.gvAniosMesesCompe.Rows(fila).FindControl("lblAdicional_E"), Label)
        Dim ChkBxEstatus_E As CheckBox = CType(Me.gvAniosMesesCompe.Rows(fila).FindControl("ChkBxEstatus_E"), CheckBox)
        Dim dr As DataRow

        dr = oCompe.ValidaSiHayMesAbiertoParaCaptura(CShort(lblAnio_E.Text), CByte(lblIdMes_E.Text), CByte(lblAdicional_E.Text))

        ChkBxEstatus_E.Enabled = CBool(dr("MesAdicAbierto")) = False
        ChkBxISRRecalculado_E.Visible = lblAdicional_E.Text = "0"
    End Sub
    Protected Sub gvAniosMesesCompe_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvAniosMesesCompe.RowCancelingEdit
        Me.gvAniosMesesCompe.Columns(0).Visible = True
        Me.gvAniosMesesCompe.SelectedIndex = e.RowIndex
        Me.gvAniosMesesCompe.EditIndex = -1
        BindgvAniosMesesCompe()

        SetVisibilidadDeColumnas()
    End Sub

    Protected Sub gvAniosMesesCompe_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAniosMesesCompe.RowDeleting

    End Sub

    Protected Sub gvAniosMesesCompe_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvAniosMesesCompe.RowUpdating
        Dim lblAnio_E As Label = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("lblAnio_E"), Label)
        Dim lblIdMes_E As Label = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("lblIdMes_E"), Label)
        Dim lblAdicional_E As Label = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("lblAdicional_E"), Label)
        Dim ChkBxEstatus_E As CheckBox = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("ChkBxEstatus_E"), CheckBox)
        Dim ChkBxISRRecalculado_E As CheckBox = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("ChkBxISRRecalculado_E"), CheckBox)
        Dim tbFchPago_E As TextBox = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("tbFchPago_E"), TextBox)
        Dim ChkBxMesNormal_E As CheckBox = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("ChkBxMesNormal_E"), CheckBox)
        Dim ChkBxMesComp_E As CheckBox = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("ChkBxMesComp_E"), CheckBox)
        Dim tbComentarios_E As TextBox = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("tbComentarios_E"), TextBox)
        Dim tbNumAfect1_E As TextBox = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("tbNumAfect1_E"), TextBox)
        Dim tbNumAfect2_E As TextBox = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("tbNumAfect2_E"), TextBox)
        Dim tbDescDelPago_E As TextBox = CType(Me.gvAniosMesesCompe.Rows(e.RowIndex).FindControl("tbDescDelPago_E"), TextBox)

        Dim oCompe As New Compensacion

        If lblAnio_E Is Nothing = False Then
            oCompe.UpdAniosMesesCompensaciones(CShort(lblAnio_E.Text), CByte(lblIdMes_E.Text), CByte(lblAdicional_E.Text), ChkBxEstatus_E.Checked, _
                    ChkBxISRRecalculado_E.Checked, tbComentarios_E.Text, CDate(tbFchPago_E.Text), ChkBxMesNormal_E.Checked, _
                    ChkBxMesComp_E.Checked, tbNumAfect1_E.Text.Trim.ToUpper, tbNumAfect2_E.Text.Trim.ToUpper,
                    tbDescDelPago_E.Text.Trim.ToUpper,
                    CType(Session("ArregloAuditoria"), String()))
        End If

        Me.gvAniosMesesCompe.Columns(0).Visible = True
        Me.gvAniosMesesCompe.SelectedIndex = e.RowIndex
        Me.gvAniosMesesCompe.EditIndex = -1
        BindgvAniosMesesCompe()

        SetVisibilidadDeColumnas()
    End Sub

    Protected Sub gvAniosMesesCompe_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAniosMesesCompe.RowDataBound
        If Me.gvAniosMesesCompe.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim oCompe As New Compensacion
                    Dim lblAnio As Label = CType(e.Row.FindControl("lblAnio"), Label)
                    Dim lblIdMes As Label = CType(e.Row.FindControl("lblIdMes"), Label)
                    Dim lblAdicional As Label = CType(e.Row.FindControl("lblAdicional"), Label)
                    Dim ChkBxISRRecalculado As CheckBox = CType(e.Row.FindControl("ChkBxISRRecalculado"), CheckBox)
                    Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
                    Dim ibAddAnioMesCompe As ImageButton = CType(e.Row.FindControl("ibAddAnioMesCompe"), ImageButton)
                    Dim ChkBxSigMesCreado As CheckBox = CType(e.Row.FindControl("ChkBxSigMesCreado"), CheckBox)
                    Dim dr As DataRow

                    dr = oCompe.ValidaISRRecalculado(CShort(lblAnio.Text), CByte(lblIdMes.Text))

                    ChkBxISRRecalculado.Visible = lblAdicional.Text = "0"
                    ibEditar.Visible = CBool(dr("ISRCompeRecalculada")) = False
                    ibAddAnioMesCompe.Visible = CBool(dr("ISRCompeRecalculada")) = True And ChkBxSigMesCreado.Checked = False

                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        ElseIf Me.gvAniosMesesCompe.EditIndex <> -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim oCompe As New Compensacion
                    Dim lblAnio As Label = CType(e.Row.FindControl("lblAnio"), Label)
                    Dim lblIdMes As Label = CType(e.Row.FindControl("lblIdMes"), Label)
                    Dim lblAdicional As Label = CType(e.Row.FindControl("lblAdicional"), Label)
                    Dim ChkBxISRRecalculado As CheckBox = CType(e.Row.FindControl("ChkBxISRRecalculado"), CheckBox)
                    Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
                    Dim dr As DataRow

                    If lblAnio Is Nothing = False Then
                        dr = oCompe.ValidaISRRecalculado(CShort(lblAnio.Text), CByte(lblIdMes.Text))

                        ChkBxISRRecalculado.Visible = lblAdicional.Text = "0"
                        ibEditar.Visible = CBool(dr("ISRCompeRecalculada")) = False
                    End If
            End Select
        End If
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        BindgvAniosMesesCompe()
    End Sub

    Protected Sub ibAddAnioMesCompe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim fila As Integer = CType(CType(sender, ImageButton).DataItemContainer, GridViewRow).RowIndex
        Dim lblAnio As Label = CType(Me.gvAniosMesesCompe.Rows(fila).FindControl("lblAnio"), Label)
        Dim lblIdMes As Label = CType(Me.gvAniosMesesCompe.Rows(fila).FindControl("lblIdMes"), Label)
        Dim lblAdicional As Label = CType(Me.gvAniosMesesCompe.Rows(fila).FindControl("lblAdicional"), Label)
        Dim oCompe As New Compensacion

        oCompe.CreaSigMesParaPago(CShort(lblAnio.Text), CByte(lblIdMes.Text), CByte(lblAdicional.Text), CType(Session("ArregloAuditoria"), String()))

        BindgvAniosMesesCompe()

        SetVisibilidadDeColumnas()
    End Sub

    Protected Sub lbAddMesAdic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAddMesAdic.Click
        Dim oCompe As New Compensacion

        oCompe.CreaMesAdic(CType(Session("ArregloAuditoria"), String()))

        BindgvAniosMesesCompe()

        SetVisibilidadDeColumnas()
    End Sub
End Class
