Imports DataAccessLayer.COBAEV
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Partial Class Administracion_CentrosDeTrabajo
    Inherits System.Web.UI.Page
    Private Sub BindgvCTs(Optional ByVal pSortExpression As String = "ClaveCT", Optional ByVal pSortDirection As String = "asc")
        Dim oCT As New CentroDeTrabajo

        Dim myDataView As New DataView()
        Dim dt As DataTable = oCT.ObtenCTsPorTipoDeCT(CByte(ddlFiltroTipoCT.SelectedValue))
        myDataView = dt.DefaultView

        If (pSortExpression <> String.Empty) Then
            Select Case pSortExpression
                Case "ClaveCT"
                    myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
                Case "NombreCT"
                    myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
                Case "ClaveZonaEco"
                    myDataView.Sort = String.Format("{0} {1} {2}", pSortExpression, pSortDirection, ", IdZonaGeografica asc, ClaveCT asc")
                Case "IdZonaGeografica"
                    myDataView.Sort = String.Format("{0} {1} {2}", pSortExpression, pSortDirection, ", ClaveZonaEco asc, ClaveCT asc")
            End Select
        End If

        gvCTs.DataSource = myDataView
        gvCTs.DataBind()
    End Sub
    Private Property sortOrder As String
        Get
            If (ViewState("sortOrder").ToString() = "desc") Then
                ViewState("sortOrder") = "asc"
            Else
                ViewState("sortOrder") = "desc"
            End If

            Return ViewState("sortOrder").ToString()
        End Get

        Set(value As String)
            ViewState("sortOrder") = value
        End Set
    End Property
    Private Sub BindddlFiltroTipoCT()
        Dim oCT As New CentroDeTrabajo
        With Me.ddlFiltroTipoCT
            .DataSource = oCT.ObtenDiferentesTipos
            .DataTextField = "DescTipoCT"
            .DataValueField = "IdTipoCT"
            .DataBind()
        End With
    End Sub
    Private Sub BindDatos()
        Dim oCT As New CentroDeTrabajo
        'oCT.IdTipoCT = CByte(Me.ddlFiltroTipoCT.SelectedValue)
        Me.gvCTs.DataSource = oCT.ObtenCTsPorTipoDeCT(CByte(ddlFiltroTipoCT.SelectedValue))
        Me.gvCTs.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("sortOrder") = ""
            BindddlFiltroTipoCT()
            'BindDatos()
        End If
    End Sub

    Protected Sub gvCTs_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCTs.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibEmpPorCT As ImageButton = CType(e.Row.FindControl("ibEmpPorCT"), ImageButton)
                Dim lblIdCT As Label = CType(e.Row.FindControl("lblIdCT"), Label)

                Dim lblIdUsuario As Label = CType(e.Row.FindControl("lblIdUsuario"), Label)
                Dim lblNombreAnalista As Label = CType(e.Row.FindControl("lblNombreAnalista"), Label)
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                pnlCTsPorTipo.GroupingText = "Centros de trabajo asociados al tipo: " + ddlFiltroTipoCT.SelectedItem.Text

                drUsr = oUsr.ObtenPorId(CShort(lblIdUsuario.Text))

                lblNombreAnalista.Text = drUsr("NomComUsr").ToString

                'Dim lbModificar As LinkButton = CType(e.Row.FindControl("lbModificar"), LinkButton)
                'Dim lblIdUsuario As Label = CType(e.Row.FindControl("lblIdUsuario"), Label)
                ibEmpPorCT.OnClientClick = "javascript:abreVentanaImpresion('EmpleadosPorCT.aspx?IdCT=" + lblIdCT.Text + "&TipoOperacion=4', '" + lblIdCT.Text + "'); return false;"
                'lbModificar.OnClientClick = "javascript:abreVentanaChica('Usuarios/UsuariosDetalles.aspx?IdUsuario=" + lblIdUsuario.Text + "&TipoOperacion=0'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvCTs, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub ddlFiltroTipoCT_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlFiltroTipoCT.SelectedIndexChanged
        ViewState("sortOrder") = "asc"
        BindgvCTs("ClaveCT", ViewState("sortOrder").ToString)
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click
        ViewState("sortOrder") = "asc"
        BindgvCTs("ClaveCT", ViewState("sortOrder").ToString)
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            'BindDatos()
            BindgvCTs("ClaveCT", "asc") 'sortOrder)
        End If
    End Sub

    Protected Sub gvCTs_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvCTs.Sorting
        BindgvCTs(e.SortExpression, sortOrder)
    End Sub
End Class
