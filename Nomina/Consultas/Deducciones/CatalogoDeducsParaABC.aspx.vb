Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class CatalogoDeducsParaABC
    Inherits System.Web.UI.Page
    Private Sub BindvDeducs()
        Dim oDeduc As New Deduccion
        Me.gvDeducs.DataSource = oDeduc.ObtenTodasParaABC(Deduccion.OrdenDeducciones.OrdenadasPorClave)
        Me.gvDeducs.DataBind()
        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Deducciones")
        gvDeducs.Columns(4).Visible = CBool(dt.Rows(0).Item("Consulta"))
        gvDeducs.Columns(5).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        gvDeducs.Columns(6).Visible = CBool(dt.Rows(0).Item("Insercion"))
        lbCrearNuevaDeduc.Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'lbCrearNuevaDeduc.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Deducciones/ABCDeducciones.aspx?TipoOperacion=1&CrearCopia=NO','VentNueva');"
            lbCrearNuevaDeduc.PostBackUrl = "../../ABC/Deducciones/ABCDeducciones.aspx?TipoOperacion=1&CrearCopia=NO"
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindvDeducs()
        End If
    End Sub

    Protected Sub ibCrearCopiaDeduc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        BindvDeducs()
    End Sub

    Protected Sub lbCrearNuevaDeduc_Click(sender As Object, e As System.EventArgs) Handles lbCrearNuevaDeduc.Click
        BindvDeducs()
    End Sub

    Protected Sub gvDeducs_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDeducs.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibCrearCopiaDeduc As ImageButton = CType(e.Row.FindControl("ibCrearCopiaDeduc"), ImageButton)
                Dim lblIdDeduccion As Label = CType(e.Row.FindControl("lblIdDeduccion"), Label)

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Deducciones/ABCDeducciones.aspx?IdDeduccion=" + lblIdDeduccion.Text + "&TipoOperacion=4','Vent" + lblIdDeduccion.Text + "Consulta'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Deducciones/ABCDeducciones.aspx?IdDeduccion=" + lblIdDeduccion.Text + "&TipoOperacion=4"
                'ibModificar.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Deducciones/ABCDeducciones.aspx?IdDeduccion=" + lblIdDeduccion.Text + "&TipoOperacion=0','Vent" + lblIdDeduccion.Text + "Modificacion'); return false;"
                ibModificar.PostBackUrl = "../../ABC/Deducciones/ABCDeducciones.aspx?IdDeduccion=" + lblIdDeduccion.Text + "&TipoOperacion=0"
                'ibCrearCopiaDeduc.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Deducciones/ABCDeducciones.aspx?IdDeduccion=" + lblIdDeduccion.Text + "&TipoOperacion=1&CrearCopia=SI','Vent" + lblIdDeduccion.Text + "Copia');"
                ibCrearCopiaDeduc.PostBackUrl = "../../ABC/Deducciones/ABCDeducciones.aspx?IdDeduccion=" + lblIdDeduccion.Text + "&TipoOperacion=1&CrearCopia=SI"

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvDeducs_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvDeducs.SelectedIndexChanged

    End Sub
End Class
