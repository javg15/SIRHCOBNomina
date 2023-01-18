Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Partial Class Consultas_Percepciones_Retroactivas
    Inherits System.Web.UI.Page
    Private Sub BindQnas()
        Dim oQna As New Quincenas
        With Me.ddlQnas
            .DataSource = oQna.ObtenConRetroactivos
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas disponibles para consulta")
                .Items(0).Value = -1
                Me.btnConsultarQna.Enabled = False
            Else
                Me.btnConsultarQna.Enabled = True
                BindgvRetroactivos()
            End If
        End With
    End Sub
    Private Sub BindgvRetroactivos()
        Dim oPerc As New Percepcion
        Dim oQna As New Quincenas
        Dim dtQna As DataTable
        With oPerc
            Me.gvPercRetro.DataSource = oPerc.ObtenRetroactivasPorQna(CShort(Me.ddlQnas.SelectedValue))
            Me.gvPercRetro.DataBind()
        End With
        oQna.IdQuincena = CShort(Me.ddlQnas.SelectedValue)
        dtQna = oQna.ObtenPorId(False)

        Me.gvPercRetro.Columns(12).Visible = True
        If dtQna.Rows(0).Item("IdEstatusQuincena") = 3 Then Me.gvPercRetro.Columns(12).Visible = False

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindQnas()
        End If
    End Sub

    Protected Sub btnConsultarQna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQna.Click
        BindgvRetroactivos()
    End Sub

    Protected Sub gvPercRetro_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPercRetro.RowCommand
        Select Case e.CommandName
            Case "CmdModificar", "Select"
                BindgvRetroactivos()
        End Select
    End Sub

    Protected Sub gvPercRetro_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercRetro.RowDataBound
        Dim ibModificar As ImageButton
        Dim lblIdPercRetro As Label
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lblIdPercRetro = CType(e.Row.FindControl("lblIdPercRetro"), Label)
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)
                ibModificar.OnClientClick = "javascript:abreVentanaChica('../../ABC/Percepciones/AdmonPercRetro.aspx?TipoOperacion=0&IdPercRetro=" + lblIdPercRetro.Text + "'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPercRetro, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub ibRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindQnas()
    End Sub
End Class
