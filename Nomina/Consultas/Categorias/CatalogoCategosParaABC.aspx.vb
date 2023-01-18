Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Partial Class CatalogoCategosParaABC
    Inherits System.Web.UI.Page
    Private Property sortOrderDesc As String
        Get
            If (ViewState("sortOrderDesc").ToString() = "desc") Then
                ViewState("sortOrderDesc") = "asc"
            Else
                ViewState("sortOrderDesc") = "desc"
            End If

            Return ViewState("sortOrderDesc").ToString()
        End Get

        Set(value As String)
            ViewState("sortOrderDesc") = value
        End Set
    End Property

    Private Property sortOrderClave As String
        Get
            If (ViewState("sortOrderClave").ToString() = "desc") Then
                ViewState("sortOrderClave") = "asc"
            Else
                ViewState("sortOrderClave") = "desc"
            End If

            Return ViewState("sortOrderClave").ToString()
        End Get

        Set(value As String)
            ViewState("sortOrderClave") = value
        End Set
    End Property

    Private Sub BindCategos(Optional ByVal pSortExpression As String = "Quincena", Optional ByVal pSortDirection As String = "desc")
        Dim oCatego As New Categoria
        Dim myDataView As New DataView()
        Dim dt As DataTable = oCatego.ObtenTodas()
        myDataView = dt.DefaultView

        If (pSortExpression <> String.Empty) Then
            myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
        End If

        gvCategos.DataSource = myDataView
        gvCategos.DataBind()

        Dim oUsr As New Usuario
        Dim dtPerms As DataTable
        dtPerms = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Categorias")
        gvCategos.Columns(4).Visible = CBool(dtPerms.Rows(0).Item("Consulta"))
        gvCategos.Columns(5).Visible = CBool(dtPerms.Rows(0).Item("Actualizacion"))
        gvCategos.Columns(6).Visible = CBool(dtPerms.Rows(0).Item("Insercion"))
        lbCrearNuevaCatego.Visible = CBool(dtPerms.Rows(0).Item("Insercion"))
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lbCrearNuevaCatego.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Categorias/ABCCategorias.aspx?TipoOperacion=1&CrearCopia=NO','VentNueva');"
            ViewState("sortOrderClave") = ""
            ViewState("sortOrderDesc") = ""
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindCategos("DescCategoria", "asc")
            ViewState("sortOrderDesc") = "asc"
        End If
    End Sub
    Protected Sub gvCategos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCategos.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibCrearCopiaCatego As ImageButton = CType(e.Row.FindControl("ibCrearCopiaCatego"), ImageButton)
                Dim lblIdCategoria As Label = CType(e.Row.FindControl("lblIdCategoria"), Label)

                ibDetalles.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Categorias/ABCCategorias.aspx?IdCategoria=" + lblIdCategoria.Text + "&TipoOperacion=4','Vent" + lblIdCategoria.Text + "Consulta'); return false;"
                ibModificar.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Categorias/ABCCategorias.aspx?IdCategoria=" + lblIdCategoria.Text + "&TipoOperacion=0','Vent" + lblIdCategoria.Text + "Modificacion'); return false;"
                ibCrearCopiaCatego.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Categorias/ABCCategorias.aspx?IdCategoria=" + lblIdCategoria.Text + "&TipoOperacion=1&CrearCopia=SI','Vent" + lblIdCategoria.Text + "Copia');"

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvCategos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvCategos.SelectedIndexChanged

    End Sub

    Protected Sub lbCrearNuevaCatego_Click(sender As Object, e As System.EventArgs) Handles lbCrearNuevaCatego.Click
        BindCategos()
        BindCategos("DescCategoria", "asc")
        ViewState("sortOrderDesc") = "asc"
    End Sub

    Protected Sub ibCrearCopiaCatego_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        BindCategos()
        BindCategos("DescCategoria", "asc")
        ViewState("sortOrderDesc") = "asc"
    End Sub

    Protected Sub gvCategos_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvCategos.Sorting
        Select Case e.SortExpression
            Case "ClaveCategoria"
                BindCategos(e.SortExpression, sortOrderClave)
            Case "DescCategoria"
                BindCategos(e.SortExpression, sortOrderDesc)
        End Select
    End Sub
End Class
