Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class AdmonPrestaciones
    Inherits System.Web.UI.Page

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindgvEjersFisc()
        Dim oEjerFisc As New EjercicioFiscal
        Dim gvr As GridViewRow
        Dim chbxConcluido As CheckBox
        Dim vlEjerConcluido As Boolean = True
        Dim vlTipoOp As String = IIf(gvEjersFisc.EditIndex = -1, "", "E")

        Me.gvEjersFisc.DataSource = oEjerFisc.ObtenInfParaAdmonDePrestaciones()
        Me.gvEjersFisc.DataBind()

        For Each gvr In gvEjersFisc.Rows
            chbxConcluido = CType(gvr.FindControl("chbxConcluido" + vlTipoOp), CheckBox)
            If chbxConcluido Is Nothing Then
                If vlTipoOp = String.Empty Then
                    vlTipoOp = "E"
                Else
                    vlTipoOp = String.Empty
                End If
                chbxConcluido = CType(gvr.FindControl("chbxConcluido" + vlTipoOp), CheckBox)
            End If
            If chbxConcluido.Checked = False Then
                vlEjerConcluido = False
                Exit For
            End If
        Next
        'lbCrearNuevoEjerFisc.Visible = vlEjerConcluido
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oUsr As New Usuario
            Dim dt As DataTable
            Dim oSem As New Semestre

            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "AdmonPrestaciones")
            BindgvEjersFisc()
            Me.gvEjersFisc.Columns(6).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            Me.gvEjersFisc.Columns(7).Visible = False 'CBool(dt.Rows(0).Item("Eliminacion"))
            If gvEjersFisc.Rows.Count > 0 Then
                gvEjersFisc.SelectedIndex = 0
                gvEjersFisc_SelectedIndexChanged(sender, e)
            End If
        End If
    End Sub
    Protected Sub gvEjersFisc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvEjersFisc.SelectedIndexChanged
        Dim lblAnio As Label
        Dim chbxCapt1aParteClave125 As CheckBox
        Dim chbxCapt2aParteClave125 As CheckBox
        Dim chbxCaptClave181 As CheckBox

        lblAnio = CType(gvEjersFisc.SelectedRow.FindControl("lblAnio"), Label)
        chbxCapt1aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt1aParteClave125"), CheckBox)
        chbxCapt2aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt2aParteClave125"), CheckBox)
        chbxCaptClave181 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCaptClave181"), CheckBox)
        If lblAnio Is Nothing Then
            lblAnio = CType(gvEjersFisc.SelectedRow.FindControl("lblAnioE"), Label)
            chbxCapt1aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt1aParteClave125E"), CheckBox)
            chbxCapt2aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt2aParteClave125E"), CheckBox)
            chbxCaptClave181 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCaptClave181E"), CheckBox)
        End If
        chbxCapt1aParteClave125.Text = "Permite captura (1a. Parte " + lblAnio.Text + ")"
        chbxCapt2aParteClave125.Text = "Permite captura (2a. Parte " + (CShort(lblAnio.Text) - 1).ToString + ")"
        chbxCaptClave181.Text = "Permite captura (" + (CShort(lblAnio.Text) - 1).ToString + ")"
    End Sub

    Protected Sub gvEjersFisc_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvEjersFisc.RowEditing
        Me.gvEjersFisc.Columns(0).Visible = False 'Select
        Me.gvEjersFisc.SelectedIndex = -1
        Me.gvEjersFisc.EditIndex = e.NewEditIndex
        BindgvEjersFisc()

        Dim lblAnio As Label
        Dim chbxCapt1aParteClave125 As CheckBox
        Dim chbxCapt2aParteClave125 As CheckBox
        Dim chbxCaptClave181 As CheckBox

        lblAnio = CType(gvEjersFisc.Rows(e.NewEditIndex).FindControl("lblAnio"), Label)
        chbxCapt1aParteClave125 = CType(gvEjersFisc.Rows(e.NewEditIndex).FindControl("chbxCapt1aParteClave125"), CheckBox)
        chbxCapt2aParteClave125 = CType(gvEjersFisc.Rows(e.NewEditIndex).FindControl("chbxCapt2aParteClave125"), CheckBox)
        chbxCaptClave181 = CType(gvEjersFisc.Rows(e.NewEditIndex).FindControl("chbxCaptClave181"), CheckBox)
        If lblAnio Is Nothing Then
            lblAnio = CType(gvEjersFisc.Rows(e.NewEditIndex).FindControl("lblAnioE"), Label)
            chbxCapt1aParteClave125 = CType(gvEjersFisc.Rows(e.NewEditIndex).FindControl("chbxCapt1aParteClave125E"), CheckBox)
            chbxCapt2aParteClave125 = CType(gvEjersFisc.Rows(e.NewEditIndex).FindControl("chbxCapt2aParteClave125E"), CheckBox)
            chbxCaptClave181 = CType(gvEjersFisc.Rows(e.NewEditIndex).FindControl("chbxCaptClave181E"), CheckBox)
        End If
        chbxCapt1aParteClave125.Text = "Permite captura (1a. Parte " + lblAnio.Text + ")"
        chbxCapt2aParteClave125.Text = "Permite captura (2a. Parte " + (CShort(lblAnio.Text) - 1).ToString + ")"
        chbxCaptClave181.Text = "Permite captura (" + (CShort(lblAnio.Text) - 1).ToString + ")"
    End Sub
    Protected Sub gvEjersFisc_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvEjersFisc.RowCancelingEdit
        Me.gvEjersFisc.Columns(0).Visible = True 'Select
        Me.gvEjersFisc.SelectedIndex = e.RowIndex
        Me.gvEjersFisc.EditIndex = -1
        BindgvEjersFisc()

        Dim lblAnio As Label
        Dim chbxCapt1aParteClave125 As CheckBox
        Dim chbxCapt2aParteClave125 As CheckBox
        Dim chbxCaptClave181 As CheckBox

        lblAnio = CType(gvEjersFisc.SelectedRow.FindControl("lblAnio"), Label)
        chbxCapt1aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt1aParteClave125"), CheckBox)
        chbxCapt2aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt2aParteClave125"), CheckBox)
        chbxCaptClave181 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCaptClave181"), CheckBox)
        If lblAnio Is Nothing Then
            lblAnio = CType(gvEjersFisc.SelectedRow.FindControl("lblAnioE"), Label)
            chbxCapt1aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt1aParteClave125E"), CheckBox)
            chbxCapt2aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt2aParteClave125E"), CheckBox)
            chbxCaptClave181 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCaptClave181E"), CheckBox)
        End If
        chbxCapt1aParteClave125.Text = "Permite captura (1a. Parte " + lblAnio.Text + ")"
        chbxCapt2aParteClave125.Text = "Permite captura (2a. Parte " + (CShort(lblAnio.Text) - 1).ToString + ")"
        chbxCaptClave181.Text = "Permite captura (" + (CShort(lblAnio.Text) - 1).ToString + ")"
    End Sub

    Protected Sub gvEjersFisc_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)

    End Sub

    Protected Sub gvEjersFisc_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvEjersFisc.RowUpdating
        If Me.gvEjersFisc.EditIndex <> -1 Then
            Dim oEjerFisc As New EjercicioFiscal
            Dim vlFila As Integer

            If gvEjersFisc.EditIndex <> -1 Then
                vlFila = gvEjersFisc.EditIndex
                Dim lblAnioE As Label = CType(gvEjersFisc.Rows(vlFila).FindControl("lblAnioE"), Label)
                Dim chbxCapt1aParteClave125E As CheckBox = CType(gvEjersFisc.Rows(vlFila).FindControl("chbxCapt1aParteClave125E"), CheckBox)
                Dim chbxCapt2aParteClave125E As CheckBox = CType(gvEjersFisc.Rows(vlFila).FindControl("chbxCapt2aParteClave125E"), CheckBox)
                Dim chbxCaptClave181E As CheckBox = CType(gvEjersFisc.Rows(vlFila).FindControl("chbxCaptClave181E"), CheckBox)

                With oEjerFisc
                    .UpdInfDeAdmonPrestaciones(CShort(lblAnioE.Text), chbxCapt1aParteClave125E.Checked, chbxCapt2aParteClave125E.Checked, _
                                   chbxCaptClave181E.Checked, CType(Session("ArregloAuditoria"), String()))
                End With
            End If
            Me.gvEjersFisc.Columns(0).Visible = True 'Select     
            Me.gvEjersFisc.SelectedIndex = e.RowIndex
            Me.gvEjersFisc.EditIndex = -1
            BindgvEjersFisc()

            Dim lblAnio As Label
            Dim chbxCapt1aParteClave125 As CheckBox
            Dim chbxCapt2aParteClave125 As CheckBox
            Dim chbxCaptClave181 As CheckBox

            lblAnio = CType(gvEjersFisc.SelectedRow.FindControl("lblAnio"), Label)
            chbxCapt1aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt1aParteClave125"), CheckBox)
            chbxCapt2aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt2aParteClave125"), CheckBox)
            chbxCaptClave181 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCaptClave181"), CheckBox)
            If lblAnio Is Nothing Then
                lblAnio = CType(gvEjersFisc.SelectedRow.FindControl("lblAnioE"), Label)
                chbxCapt1aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt1aParteClave125E"), CheckBox)
                chbxCapt2aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt2aParteClave125E"), CheckBox)
                chbxCaptClave181 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCaptClave181E"), CheckBox)
            End If
            chbxCapt1aParteClave125.Text = "Permite captura (1a. Parte " + lblAnio.Text + ")"
            chbxCapt2aParteClave125.Text = "Permite captura (2a. Parte " + (CShort(lblAnio.Text) - 1).ToString + ")"
            chbxCaptClave181.Text = "Permite captura (" + (CShort(lblAnio.Text) - 1).ToString + ")"
        End If
    End Sub

    Protected Sub gvEjersFisc_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim chbxConcluido As CheckBox
        Dim ibEditar As ImageButton

        If Me.gvEjersFisc.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    chbxConcluido = CType(e.Row.FindControl("chbxConcluido"), CheckBox)
                    ibEditar = CType(e.Row.FindControl("ibEditar"), ImageButton)

                    ibEditar.Visible = Not chbxConcluido.Checked

                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        Else
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    chbxConcluido = CType(e.Row.FindControl("chbxConcluido"), CheckBox)
                    ibEditar = CType(e.Row.FindControl("ibEditar"), ImageButton)

                    If ibEditar Is Nothing = False Then
                        ibEditar.Visible = Not chbxConcluido.Checked
                    End If

                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        End If
    End Sub

    Protected Sub gvEjersFisc_SelectedIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvEjersFisc.SelectedIndexChanging
        Dim lblAnio As Label
        Dim chbxCapt1aParteClave125 As CheckBox
        Dim chbxCapt2aParteClave125 As CheckBox
        Dim chbxCaptClave181 As CheckBox

        lblAnio = CType(gvEjersFisc.SelectedRow.FindControl("lblAnio"), Label)
        chbxCapt1aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt1aParteClave125"), CheckBox)
        chbxCapt2aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt2aParteClave125"), CheckBox)
        chbxCaptClave181 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCaptClave181"), CheckBox)
        If lblAnio Is Nothing Then
            lblAnio = CType(gvEjersFisc.SelectedRow.FindControl("lblAnioE"), Label)
            chbxCapt1aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt1aParteClave125E"), CheckBox)
            chbxCapt2aParteClave125 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCapt2aParteClave125E"), CheckBox)
            chbxCaptClave181 = CType(gvEjersFisc.SelectedRow.FindControl("chbxCaptClave181E"), CheckBox)
        End If
        chbxCapt1aParteClave125.Text = "Permite captura"
        chbxCapt2aParteClave125.Text = "Permite captura"
        chbxCaptClave181.Text = "Permite captura"
    End Sub
End Class
