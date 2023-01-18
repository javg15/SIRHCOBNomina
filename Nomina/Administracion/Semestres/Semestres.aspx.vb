Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class Administracion_Semestres
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindgvSemestres()
        Dim oSem As New Semestre
        Me.gvSemestres.DataSource = oSem.ObtenTodos
        Me.gvSemestres.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oUsr As New Usuario
            Dim dt As DataTable
            Dim oSem As New Semestre
            BindgvSemestres()
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Semestres")
            lbCrearNuevoSemestre.Visible = CBool(dt.Rows(0).Item("Insercion")) And Not oSem.ExisteParaCapturaDePlantillas()
            Me.gvSemestres.Columns(13).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            Me.gvSemestres.Columns(14).Visible = False 'CBool(dt.Rows(0).Item("Eliminacion"))
        End If
    End Sub
    Protected Sub gvSemestres_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvSemestres.SelectedIndexChanged
    End Sub

    Protected Sub gvSemestres_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvSemestres.RowEditing
        Me.gvSemestres.Columns(0).Visible = False 'Select
        'Me.gvSemestres.Columns(13).Visible = False 'Delete
        Me.gvSemestres.SelectedIndex = -1
        Me.gvSemestres.EditIndex = e.NewEditIndex
        BindgvSemestres()
        Dim fila As Integer = Me.gvSemestres.EditIndex
        Dim lblIdSemestre As Label = CType(Me.gvSemestres.Rows(fila).FindControl("lblIdSemestre_E"), Label)
        Dim lblIdQuincenaIni As Label = CType(Me.gvSemestres.Rows(fila).FindControl("lblIdQuincenaIni_E"), Label)
        Dim ddlQnaIni As DropDownList = CType(Me.gvSemestres.Rows(fila).FindControl("ddlQnaIni"), DropDownList)
        Dim lblIdQuincenaFin As Label = CType(Me.gvSemestres.Rows(fila).FindControl("lblIdQuincenaFin_E"), Label)
        Dim ddlQnaFin As DropDownList = CType(Me.gvSemestres.Rows(fila).FindControl("ddlQnaFin"), DropDownList)
        Dim lblIdQuincenaFinInterinas As Label = CType(Me.gvSemestres.Rows(fila).FindControl("lblIdQuincenaFinInterinas_E"), Label)
        Dim ddlQnaFinInt As DropDownList = CType(Me.gvSemestres.Rows(fila).FindControl("ddlQnaFinInt"), DropDownList)

        Dim oSemestre As New Semestre

        LlenaDDL(ddlQnaIni, "Quincena", "IdQuincena", oSemestre.ObtenQnasIni(CShort(lblIdSemestre.Text)), lblIdQuincenaIni.Text)
        LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oSemestre.ObtenQnasFin(CShort(lblIdSemestre.Text)), lblIdQuincenaFin.Text)
        LlenaDDL(ddlQnaFinInt, "Quincena", "IdQuincena", oSemestre.ObtenQnasFin(CShort(lblIdSemestre.Text)), lblIdQuincenaFinInterinas.Text)
    End Sub
    Protected Sub gvSemestres_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvSemestres.RowCancelingEdit
        Me.gvSemestres.Columns(0).Visible = True 'Select
        'Me.gvSemestres.Columns(13).Visible = True 'Delete
        Me.gvSemestres.SelectedIndex = e.RowIndex
        Me.gvSemestres.EditIndex = -1
        BindgvSemestres()
    End Sub

    Protected Sub gvSemestres_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)

    End Sub

    Protected Sub gvSemestres_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvSemestres.RowUpdating
        If Me.gvSemestres.EditIndex <> -1 Then
            Dim lblIdSemestre_E As Label = CType(Me.gvSemestres.Rows(e.RowIndex).FindControl("lblIdSemestre_E"), Label)
            Dim ddlQnaIni As DropDownList = CType(Me.gvSemestres.Rows(e.RowIndex).FindControl("ddlQnaIni"), DropDownList)
            Dim ddlQnaFin As DropDownList = CType(Me.gvSemestres.Rows(e.RowIndex).FindControl("ddlQnaFin"), DropDownList)
            Dim ddlQnaFinInt As DropDownList = CType(Me.gvSemestres.Rows(e.RowIndex).FindControl("ddlQnaFinInt"), DropDownList)
            Dim ChkBxActual_E As CheckBox = CType(Me.gvSemestres.Rows(e.RowIndex).FindControl("ChkBxActual_E"), CheckBox)
            Dim ChkBxPermiteModif_E As CheckBox = CType(Me.gvSemestres.Rows(e.RowIndex).FindControl("ChkBxPermiteModif_E"), CheckBox)
            Dim ChkBxPermiteCargaPlanti_E As CheckBox = CType(Me.gvSemestres.Rows(e.RowIndex).FindControl("ChkBxPermiteCargaPlanti_E"), CheckBox)
            Dim oSem As New Semestre

            oSem.ActualizaInf(CShort(lblIdSemestre_E.Text), ChkBxActual_E.Checked, CShort(ddlQnaIni.SelectedValue), CShort(ddlQnaFin.SelectedValue), _
                    CShort(ddlQnaFinInt.SelectedValue), ChkBxPermiteModif_E.Checked, ChkBxPermiteCargaPlanti_E.Checked, CType(Session("ArregloAuditoria"), String()))

            Me.gvSemestres.Columns(0).Visible = True 'Select
            'Me.gvSemestres.Columns(13).Visible = True 'Delete        
            Me.gvSemestres.SelectedIndex = e.RowIndex
            Me.gvSemestres.EditIndex = -1
            BindgvSemestres()

            Dim oUsr As New Usuario
            Dim dt As DataTable
            Dim oAplic As New Aplicacion
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Semestres")
            lbCrearNuevoSemestre.Visible = CBool(dt.Rows(0).Item("Insercion")) And Not oSem.ExisteParaCapturaDePlantillas()

        End If
    End Sub

    Protected Sub lbCrearNuevoSemestre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbCrearNuevoSemestre.Click
        Dim oSemestre As New Semestre
        oSemestre.CreaNuevo(CType(Session("ArregloAuditoria"), String()))
        BindgvSemestres()
    End Sub

    Protected Sub gvSemestres_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If Me.gvSemestres.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    'Dim lblIdSemestre As Label = CType(e.Row.FindControl("lblIdSemestre"), Label)
                    'Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
                    'Dim oSem As New Semestre
                    'ibEditar.Visible = oSem.EsActual(CShort(lblIdSemestre.Text)) Or oSem.EsParaCapturaDePlantillas(CShort(lblIdSemestre.Text))
                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        End If
    End Sub
End Class
