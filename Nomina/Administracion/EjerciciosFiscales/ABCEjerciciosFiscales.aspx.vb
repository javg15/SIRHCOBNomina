Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class ABCEjerciciosFiscales
    Inherits System.Web.UI.Page
    Private Sub SetPropertyEnabled_rfv(prfvRFC As Boolean, prfvNombre As Boolean, prfvNumEmp As Boolean)
        Dim rfvRFC As RequiredFieldValidator = CType(wucSearchEmps2.FindControl("rfvRFC"), RequiredFieldValidator)
        Dim rfvNombre As RequiredFieldValidator = CType(wucSearchEmps2.FindControl("rfvNombre"), RequiredFieldValidator)
        Dim rfvNumEmp As RequiredFieldValidator = CType(wucSearchEmps2.FindControl("rfvNumEmp"), RequiredFieldValidator)

        rfvRFC.Enabled = prfvRFC
        rfvNombre.Enabled = prfvNombre
        rfvNumEmp.Enabled = prfvNumEmp
    End Sub
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

        Me.gvEjersFisc.DataSource = oEjerFisc.ObtenTodos()
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
        lbCrearNuevoEjerFisc.Visible = vlEjerConcluido
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oUsr As New Usuario
            Dim dt As DataTable
            Dim oSem As New Semestre

            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EjerciciosFiscales")
            lbCrearNuevoEjerFisc.Visible = CBool(dt.Rows(0).Item("Insercion")) 'And Not oSem.ExisteParaCapturaDePlantillas()
            BindgvEjersFisc()
            Me.gvEjersFisc.Columns(9).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            Me.gvEjersFisc.Columns(10).Visible = False 'CBool(dt.Rows(0).Item("Eliminacion"))
        End If
    End Sub
    Protected Sub gvEjersFisc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvEjersFisc.SelectedIndexChanged
    End Sub

    Protected Sub gvEjersFisc_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvEjersFisc.RowEditing
        Me.gvEjersFisc.Columns(0).Visible = False 'Select
        Me.gvEjersFisc.SelectedIndex = -1
        Me.gvEjersFisc.EditIndex = e.NewEditIndex
        BindgvEjersFisc()
        lbCrearNuevoEjerFisc.Visible = False

        Dim ddlTipoBusqueda As DropDownList
        ddlTipoBusqueda = CType(wucSearchEmps2.FindControl("ddlTipoBusqueda"), DropDownList)

        Select Case ddlTipoBusqueda.SelectedValue
            Case "RFC"
                SetPropertyEnabled_rfv(False, False, False)
            Case "Nombre"
                SetPropertyEnabled_rfv(False, False, False)
            Case "NumEmp"
                SetPropertyEnabled_rfv(False, False, False)
        End Select
    End Sub
    Protected Sub gvEjersFisc_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvEjersFisc.RowCancelingEdit
        Me.gvEjersFisc.Columns(0).Visible = True 'Select
        Me.gvEjersFisc.SelectedIndex = e.RowIndex
        Me.gvEjersFisc.EditIndex = -1
        BindgvEjersFisc()
        Dim ddlTipoBusqueda As DropDownList
        ddlTipoBusqueda = CType(wucSearchEmps2.FindControl("ddlTipoBusqueda"), DropDownList)

        Select Case ddlTipoBusqueda.SelectedValue
            Case "RFC"
                SetPropertyEnabled_rfv(False, False, False)
            Case "Nombre"
                SetPropertyEnabled_rfv(False, False, False)
            Case "NumEmp"
                SetPropertyEnabled_rfv(False, False, False)
        End Select
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
                Dim chbxConcluidoE As CheckBox = CType(gvEjersFisc.Rows(vlFila).FindControl("chbxConcluidoE"), CheckBox)
                Dim chbxCapNoSubsidioE As CheckBox = CType(gvEjersFisc.Rows(vlFila).FindControl("chbxCapNoSubsidioE"), CheckBox)
                Dim chbxCapDeConstSdosE As CheckBox = CType(gvEjersFisc.Rows(vlFila).FindControl("chbxCapDeConstSdosE"), CheckBox)
                Dim txtbxFechaSATE As TextBox = CType(gvEjersFisc.Rows(vlFila).FindControl("txtbxFechaSATE"), TextBox)
                Dim txtbxFolioOperacionSATE As TextBox = CType(gvEjersFisc.Rows(vlFila).FindControl("txtbxFolioOperacionSATE"), TextBox)
                Dim hfNumEmp As HiddenField = CType(Me.wucSearchEmps2.FindControl("hfNumEmp"), HiddenField)
                Dim lblIdEmpFirmanteE As Label = CType(gvEjersFisc.Rows(vlFila).FindControl("lblIdEmpFirmanteE"), Label)

                With oEjerFisc
                    .Anio = CShort(lblAnioE.Text)
                    .Concluido = chbxConcluidoE.Checked
                    .FechaSAT = txtbxFechaSATE.Text.Trim
                    .FolioOperacionSAT = txtbxFolioOperacionSATE.Text.Trim
                    .NumEmp = String.Empty
                    .PermiteCapturaNoSubsidio = chbxCapNoSubsidioE.Checked
                    .PermiteCapturaDeConstancias = chbxCapDeConstSdosE.Checked
                    .IdEmpFirmante = CInt(lblIdEmpFirmanteE.Text)
                    .ActualizarInf(CType(Session("ArregloAuditoria"), String()))
                End With
            End If
            Me.gvEjersFisc.Columns(0).Visible = True 'Select     
            Me.gvEjersFisc.SelectedIndex = e.RowIndex
            Me.gvEjersFisc.EditIndex = -1
            BindgvEjersFisc()

            Dim oUsr As New Usuario
            Dim dt As DataTable
            Dim oAplic As New Aplicacion
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EjerciciosFiscales")
            lbCrearNuevoEjerFisc.Visible = CBool(dt.Rows(0).Item("Insercion"))

            Dim ddlTipoBusqueda As DropDownList
            ddlTipoBusqueda = CType(wucSearchEmps2.FindControl("ddlTipoBusqueda"), DropDownList)

            Select Case ddlTipoBusqueda.SelectedValue
                Case "RFC"
                    SetPropertyEnabled_rfv(False, False, False)
                Case "Nombre"
                    SetPropertyEnabled_rfv(False, False, False)
                Case "NumEmp"
                    SetPropertyEnabled_rfv(False, False, False)
            End Select
        End If
    End Sub

    Protected Sub lbCrearNuevoEjerFisc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbCrearNuevoEjerFisc.Click
        Dim oEjerFisc As New EjercicioFiscal
        oEjerFisc.CreaNuevo(CType(Session("ArregloAuditoria"), String()))

        Me.gvEjersFisc.Columns(0).Visible = True
        Me.gvEjersFisc.SelectedIndex = -1
        Me.gvEjersFisc.EditIndex = -1
        BindgvEjersFisc()
        Dim ddlTipoBusqueda As DropDownList
        ddlTipoBusqueda = CType(wucSearchEmps2.FindControl("ddlTipoBusqueda"), DropDownList)

        Select Case ddlTipoBusqueda.SelectedValue
            Case "RFC"
                SetPropertyEnabled_rfv(False, False, False)
            Case "Nombre"
                SetPropertyEnabled_rfv(False, False, False)
            Case "NumEmp"
                SetPropertyEnabled_rfv(False, False, False)
        End Select

    End Sub

    Protected Sub gvEjersFisc_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If Me.gvEjersFisc.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        End If
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.ibEditarFirmante_MPE.Hide()
        Dim ddlTipoBusqueda As DropDownList
        ddlTipoBusqueda = CType(wucSearchEmps2.FindControl("ddlTipoBusqueda"), DropDownList)

        Select Case ddlTipoBusqueda.SelectedValue
            Case "RFC"
                SetPropertyEnabled_rfv(False, False, False)
            Case "Nombre"
                SetPropertyEnabled_rfv(False, False, False)
            Case "NumEmp"
                SetPropertyEnabled_rfv(False, False, False)
        End Select
    End Sub

    Protected Sub ibEditarFirmante_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim ddlTipoBusqueda As DropDownList
        ddlTipoBusqueda = CType(wucSearchEmps2.FindControl("ddlTipoBusqueda"), DropDownList)

        Select ddlTipoBusqueda.SelectedValue
            Case "RFC"
                SetPropertyEnabled_rfv(True, False, False)
            Case "Nombre"
                SetPropertyEnabled_rfv(False, True, False)
            Case "NumEmp"
                SetPropertyEnabled_rfv(False, False, True)
        End Select
        Me.ibEditarFirmante_MPE.Show()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim oEjerFisc As New EjercicioFiscal
        Dim vlFila As Integer

        If gvEjersFisc.EditIndex <> -1 Then
            vlFila = gvEjersFisc.EditIndex
            Dim lblAnioE As Label = CType(gvEjersFisc.Rows(vlFila).FindControl("lblAnioE"), Label)
            Dim chbxConcluidoE As CheckBox = CType(gvEjersFisc.Rows(vlFila).FindControl("chbxConcluidoE"), CheckBox)
            Dim chbxCapNoSubsidioE As CheckBox = CType(gvEjersFisc.Rows(vlFila).FindControl("chbxCapNoSubsidioE"), CheckBox)
            Dim chbxCapDeConstSdosE As CheckBox = CType(gvEjersFisc.Rows(vlFila).FindControl("chbxCapDeConstSdosE"), CheckBox)
            Dim txtbxFechaSATE As TextBox = CType(gvEjersFisc.Rows(vlFila).FindControl("txtbxFechaSATE"), TextBox)
            Dim txtbxFolioOperacionSATE As TextBox = CType(gvEjersFisc.Rows(vlFila).FindControl("txtbxFolioOperacionSATE"), TextBox)
            Dim hfNumEmp As HiddenField = CType(Me.wucSearchEmps2.FindControl("hfNumEmp"), HiddenField)

            With oEjerFisc
                .Anio = CShort(lblAnioE.Text)
                .Concluido = chbxConcluidoE.Checked
                .FechaSAT = txtbxFechaSATE.Text.Trim
                .FolioOperacionSAT = txtbxFolioOperacionSATE.Text.Trim
                .NumEmp = hfNumEmp.Value.Trim
                .PermiteCapturaNoSubsidio = chbxCapNoSubsidioE.Checked
                .PermiteCapturaDeConstancias = chbxCapDeConstSdosE.Checked
                .IdEmpFirmante = 0
                .ActualizarInf(CType(Session("ArregloAuditoria"), String()))
                BindgvEjersFisc()
            End With
        End If

        Me.ibEditarFirmante_MPE.Hide()
        Dim ddlTipoBusqueda As DropDownList
        ddlTipoBusqueda = CType(wucSearchEmps2.FindControl("ddlTipoBusqueda"), DropDownList)

        Select Case ddlTipoBusqueda.SelectedValue
            Case "RFC"
                SetPropertyEnabled_rfv(False, False, False)
            Case "Nombre"
                SetPropertyEnabled_rfv(False, False, False)
            Case "NumEmp"
                SetPropertyEnabled_rfv(False, False, False)
        End Select
    End Sub
End Class
