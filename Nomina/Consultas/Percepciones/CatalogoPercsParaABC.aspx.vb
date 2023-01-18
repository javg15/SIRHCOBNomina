Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class CatalogoPercsParaABC
    Inherits System.Web.UI.Page
    Private Sub BindPercs()
        Dim oPerc As New Percepcion
        Me.gvPercs.DataSource = oPerc.ObtenTodasParaABC(Percepcion.OrdenPercepciones.OrdenadasPorClave)
        Me.gvPercs.DataBind()
        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Percepciones")
        gvPercs.Columns(4).Visible = CBool(dt.Rows(0).Item("Consulta"))
        gvPercs.Columns(5).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        gvPercs.Columns(6).Visible = CBool(dt.Rows(0).Item("Insercion"))
        lbCrearNuevaPerc.Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lbCrearNuevaPerc.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Percepciones/ABCPercepciones.aspx?TipoOperacion=1&CrearCopia=NO','VentNueva');"
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindPercs()
        End If
    End Sub
    Protected Sub gvPercProg_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercs.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibCrearCopiaPerc As ImageButton = CType(e.Row.FindControl("ibCrearCopiaPerc"), ImageButton)
                Dim lblIdPercepcion As Label = CType(e.Row.FindControl("lblIdPercepcion"), Label)

                ibDetalles.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Percepciones/ABCPercepciones.aspx?IdPercepcion=" + lblIdPercepcion.Text + "&TipoOperacion=4','Vent" + lblIdPercepcion.Text + "Consulta'); return false;"
                ibModificar.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Percepciones/ABCPercepciones.aspx?IdPercepcion=" + lblIdPercepcion.Text + "&TipoOperacion=0','Vent" + lblIdPercepcion.Text + "Modificacion'); return false;"
                ibCrearCopiaPerc.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Percepciones/ABCPercepciones.aspx?IdPercepcion=" + lblIdPercepcion.Text + "&TipoOperacion=1&CrearCopia=SI','Vent" + lblIdPercepcion.Text + "Copia');"

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPercs, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvPercs_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPercs.SelectedIndexChanged

    End Sub

    Protected Sub lbCrearNuevaPerc_Click(sender As Object, e As System.EventArgs) Handles lbCrearNuevaPerc.Click
        BindPercs()
    End Sub

    Protected Sub ibCrearCopiaPerc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        BindPercs()
    End Sub

End Class
