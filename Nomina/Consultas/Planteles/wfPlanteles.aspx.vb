Imports DataAccessLayer.COBAEV
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Partial Class wfPlanteles
    Inherits System.Web.UI.Page
    Private Sub BindgvPlanteles(Optional ByVal pSortExpression As String = "ClaveCOBAEV", Optional ByVal pSortDirection As String = "asc")
        Dim oPlantel As New Plantel

        Dim myDataView As New DataView()
        Dim dt As DataTable = oPlantel.ObtenVigentes()
        myDataView = dt.DefaultView

        If (pSortExpression <> String.Empty) Then
            Select Case pSortExpression
                Case "ClaveCOBAEV"
                    myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
                Case "Plantel"
                    myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
                Case "TipoPlantel"
                    myDataView.Sort = String.Format("{0} {1} {2}", pSortExpression, pSortDirection, ", ZonaGeo asc, ZonaEco asc, ClaveCOBAEV asc")
                Case "ZonaGeo"
                    myDataView.Sort = String.Format("{0} {1} {2}", pSortExpression, pSortDirection, ", ZonaEco asc, ClaveCOBAEV asc")
                Case "ZonaEco"
                    myDataView.Sort = String.Format("{0} {1} {2}", pSortExpression, pSortDirection, ", ZonaGeo asc, ClaveCOBAEV asc")
                Case "EMSAD"
                    myDataView.Sort = String.Format("{0} {1} {2}", pSortExpression, pSortDirection, ", ZonaGeo asc, ZonaEco asc, ClaveCOBAEV asc")
                Case "Turno"
                    myDataView.Sort = String.Format("{0} {1} {2}", pSortExpression, pSortDirection, ", ZonaGeo asc, ZonaEco asc, ClaveCOBAEV asc")
            End Select
        End If

        gvPlanteles.DataSource = myDataView
        gvPlanteles.DataBind()
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

    'Private Sub Bind_gvPlanteles()
    '    Dim oPlantel As New Plantel
    '    With gvPlanteles
    '        .DataSource = oPlantel.ObtenVigentes()
    '        .DataBind()
    '    End With
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("sortOrder") = ""
        End If
    End Sub

    Protected Sub gvPlanteles_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlanteles.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                'If e.Row.RowType = DataControlRowType.Header Then
                '    Dim img As New Image
                '    If sortOrder = "ASC" Then
                '        img.ImageUrl = "asc.gif"
                '    Else
                '        img.ImageUrl = "desc.gif"
                '    End If
                '    e.Row.Cells(0).Controls.Add(New LiteralControl(" "))
                '    e.Row.Cells(0).Controls.Add(img)
                'End If
            Case DataControlRowType.DataRow
                Dim lblIdPlantel As Label = CType(e.Row.FindControl("lblIdPlantel"), Label)
                Dim lblIdUsuario As Label = CType(e.Row.FindControl("lblIdUsuario"), Label)
                Dim lblNombreAnalista As Label = CType(e.Row.FindControl("lblNombreAnalista"), Label)
                Dim ibModificarHorarios As ImageButton = CType(e.Row.FindControl("ibModificarHorarios"), ImageButton)


                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                drUsr = oUsr.ObtenPorId(CShort(lblIdUsuario.Text))

                lblNombreAnalista.Text = drUsr("NomComUsr").ToString

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(gvPlanteles, "Select$" + e.Row.RowIndex.ToString)

                ibModificarHorarios.PostBackUrl = "../../ABC/Empleados/AdministracionPlantelesHorarios.aspx?IdPlantel=" + lblIdPlantel.Text
        End Select

    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindgvPlanteles("ClaveCOBAEV", "asc")
        End If
    End Sub

    Protected Sub gvPlanteles_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvPlanteles.Sorting
        BindgvPlanteles(e.SortExpression, sortOrder)
    End Sub

End Class
