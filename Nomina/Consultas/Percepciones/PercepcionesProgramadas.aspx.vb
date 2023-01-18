Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Partial Class Consultas_Percepciones_Programadas
    Inherits System.Web.UI.Page
    Private Sub BindSemestres()
        Dim oSem As New Semestre
        Me.ddlSemestres.DataSource = oSem.ObtenSemestres
        Me.ddlSemestres.DataTextField = "Semestre"
        Me.ddlSemestres.DataValueField = "IdSemestre"
        Me.ddlSemestres.DataBind()
        If Me.ddlSemestres.Items.Count = 0 Then
            Me.ddlSemestres.Items.Insert(0, "No existe información de semestres")
            Me.ddlSemestres.Items(0).Value = -1
            Me.btnConsulta.Enabled = False
        Else
            Me.btnConsulta.Enabled = True
        End If
    End Sub
    Private Sub BindPercProg()
        Dim oPerc As New Percepcion
        Me.gvPercProg.DataSource = oPerc.ObtenProgramadasPorSemestre(CShort(Me.ddlSemestres.SelectedValue))
        Me.gvPercProg.DataBind()
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindSemestres()
            If Me.ddlSemestres.SelectedValue <> -1 Then BindPercProg()
        End If
    End Sub

    Protected Sub gvPercProg_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPercProg.RowCommand
        BindPercProg()
    End Sub

    Protected Sub gvPercProg_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercProg.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibModificar, ibPercDeduc As ImageButton
                Dim lblIdPercepcion, lblNumParte, lblIdQnaPago, lblQnaPago As Label
                lblIdPercepcion = CType(e.Row.FindControl("lblIdPercepcion"), Label)
                lblNumParte = CType(e.Row.FindControl("lblNumParte"), Label)
                lblIdQnaPago = CType(e.Row.FindControl("lblIdQnaPago"), Label)
                lblQnaPago = CType(e.Row.FindControl("lblQnaPago"), Label)
                ibPercDeduc = CType(e.Row.FindControl("ibPercDeduc"), ImageButton)
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)
                ibPercDeduc.OnClientClick = "javascript:abreVentMedAncha('DeducsPercsAsocAPercProg.aspx?IdPercepcion=" + lblIdPercepcion.Text + "&TipoOperacion=4'); return false;"
                If lblQnaPago.Text = "N/D" Then
                    ibModificar.Enabled = False
                    ibModificar.ToolTip = "Opción no disponible para este registro."
                ElseIf lblQnaPago.Text = "S/D" Then
                    ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Percepciones/AdmonPercProg.aspx?IdSemestre=" + Me.ddlSemestres.SelectedValue + "&IdQnaPago=" + lblIdQnaPago.Text + "&IdPercepcion=" + lblIdPercepcion.Text + "&NumParte=" + lblNumParte.Text + "&TipoOperacion=1'); return false;"
                Else
                    ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Percepciones/AdmonPercProg.aspx?IdSemestre=" + Me.ddlSemestres.SelectedValue + "&IdQnaPago=" + lblIdQnaPago.Text + "&IdPercepcion=" + lblIdPercepcion.Text + "&NumParte=" + lblNumParte.Text + "&TipoOperacion=0'); return false;"
                End If
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPercProg, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub btnConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        BindPercProg()
    End Sub

End Class
