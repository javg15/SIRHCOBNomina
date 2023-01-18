Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class Administracion_Quincenas
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oSem As New Semestre
        Dim dt As DataTable
        Dim oUsr As New Usuario

        Me.ddlSemestres.DataSource = oSem.ObtenSemestres
        Me.ddlSemestres.DataTextField = "Semestre"
        Me.ddlSemestres.DataValueField = "IdSemestre"
        Me.ddlSemestres.DataBind()

        If Me.ddlSemestres.Items.Count = 0 Then
            Me.ddlSemestres.Items.Insert(0, "No existe información de semestres")
            Me.ddlSemestres.Items(0).Value = -1
            Me.btnConsultarQuincenas.Enabled = False
        Else

            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Quincenas")

            gvQuincenas.Columns(7).Visible = CBool(dt.Rows(0).Item("Insercion"))
            gvQuincenas.Columns(8).Visible = CBool(dt.Rows(0).Item("Consulta"))
            gvQuincenas.Columns(9).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
            gvQuincenas.Columns(10).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            gvQuincenas.Columns(11).Visible = CBool(dt.Rows(0).Item("Actualizacion")) Or oUsr.EsVIP(Session("Login"))

            Me.btnConsultarQuincenas.Enabled = True
        End If
    End Sub
    Private Sub BindQuincenas(Optional ByVal pSortExpression As String = "Quincena", Optional ByVal pSortDirection As String = "desc")
        Dim oQna As New Quincenas
        'Me.gvQuincenas.DataSource = oQna.ObtenPorSemestre(CShort(Me.ddlSemestres.SelectedValue))
        'Me.gvQuincenas.DataBind()

        Dim myDataView As New DataView()
        Dim dt As DataTable = oQna.ObtenPorSemestre(CShort(Me.ddlSemestres.SelectedValue))
        myDataView = dt.DefaultView

        If (pSortExpression <> String.Empty) Then
            myDataView.Sort = String.Format("{0} {1}", pSortExpression, pSortDirection)
        End If

        gvQuincenas.DataSource = myDataView
        Me.gvQuincenas.DataBind()

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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            ViewState("sortOrder") = ""
        End If
    End Sub

    Protected Sub gvQuincenas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvQuincenas.RowCommand
        Select e.CommandName
            Case "Sort"
            Case Else
                If Me.ddlSemestres.SelectedValue <> -1 Then BindQuincenas()
        End Select
    End Sub

    Protected Sub gvQuincenas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuincenas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibAddAdic As ImageButton = CType(e.Row.FindControl("ibAddAdic"), ImageButton)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim lblIdQuincena As Label = CType(e.Row.FindControl("lblIdQuincena"), Label)
                Dim lblQuincena As Label = CType(e.Row.FindControl("lblQuincena"), Label)
                Dim lblIdEstatusQuincena As Label = CType(e.Row.FindControl("lblIdEstatusQuincena"), Label)
                'ibDetalles.OnClientClick = "javascript:abreVentanaMediana('QuincenasDetalles.aspx?IdQuincena=" + lblIdQuincena.Text + "&IdEstatusQuincena=" + lblIdEstatusQuincena.Text + "&TipoOperacion=4&Adicional=0'); return false;"
                ibDetalles.PostBackUrl = "QuincenasDetalles.aspx?IdQuincena=" + lblIdQuincena.Text + "&IdEstatusQuincena=" + lblIdEstatusQuincena.Text + "&TipoOperacion=4&Adicional=0"
                'ibModificar.OnClientClick = "javascript:abreVentanaMediana('QuincenasDetalles.aspx?IdQuincena=" + lblIdQuincena.Text + "&IdEstatusQuincena=" + lblIdEstatusQuincena.Text + "&TipoOperacion=0&Adicional=0'); return false;"
                ibModificar.PostBackUrl = "QuincenasDetalles.aspx?IdQuincena=" + lblIdQuincena.Text + "&IdEstatusQuincena=" + lblIdEstatusQuincena.Text + "&TipoOperacion=0&Adicional=0"
                If lblQuincena.Text.Trim.Length = 6 Then
                    'ibAddAdic.OnClientClick = "javascript:abreVentanaMediana('QuincenasDetalles.aspx?IdQuincena=" + lblIdQuincena.Text + "&IdEstatusQuincena=" + lblIdEstatusQuincena.Text + "&TipoOperacion=1&Adicional=1'); return false;"
                    ibAddAdic.PostBackUrl = "QuincenasDetalles.aspx?IdQuincena=" + lblIdQuincena.Text + "&IdEstatusQuincena=" + lblIdEstatusQuincena.Text + "&TipoOperacion=1&Adicional=1"
                    ibEliminar.Enabled = False
                Else
                    ibAddAdic.Enabled = False
                    'ibEliminar.OnClientClick = "javascript:abreVentanaMediana('QuincenasDetalles.aspx?IdQuincena=" + lblIdQuincena.Text + "&IdEstatusQuincena=" + lblIdEstatusQuincena.Text + "&TipoOperacion=3&Adicional=0'); return false;"
                    ibEliminar.PostBackUrl = "javascript:abreVentanaMediana('QuincenasDetalles.aspx?IdQuincena=" + lblIdQuincena.Text + "&IdEstatusQuincena=" + lblIdEstatusQuincena.Text + "&TipoOperacion=3&Adicional=0"
                End If
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvQuincenas, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    'Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
    '    BindDatos()
    '    'If Me.ddlSemestres.SelectedValue <> -1 Then BindQuincenas()
    '    If Me.ddlSemestres.SelectedValue <> -1 Then
    '        ViewState("sortOrder") = "desc"
    '        BindQuincenas("Quincena", ViewState("sortOrder").ToString)
    '    End If
    'End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
            'If Me.ddlSemestres.SelectedValue <> -1 Then BindQuincenas()
            If Me.ddlSemestres.SelectedValue <> -1 Then BindQuincenas("Quincena", sortOrder)
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        'BindQuincenas()
        ViewState("sortOrder") = "desc"
        BindQuincenas("Quincena", ViewState("sortOrder").ToString)
    End Sub

    Protected Sub gvQuincenas_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvQuincenas.Sorting
        BindQuincenas(e.SortExpression, sortOrder)
    End Sub

    Protected Sub ibValidar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim ib As ImageButton
        Dim gvr As GridViewRow
        Dim lblQuincena As Label
        Dim lblIdQuincena As Label
        Dim oNomina As New Nomina

        ib = CType(sender, ImageButton)
        gvr = ib.NamingContainer

        lblQuincena = CType(gvr.FindControl("lblQuincena"), Label)
        lblIdQuincena = CType(gvr.FindControl("lblIdQuincena"), Label)

        pnlResultsValidacion.GroupingText = "Resultados al validar la quincena: " + lblQuincena.Text

        dvResultsValidacion.DataSource = oNomina.ValidaInf(CShort(lblIdQuincena.Text), Session("Login"))
        dvResultsValidacion.DataBind()

        MVQnas.SetActiveView(viewQnasResultsValidacion)
    End Sub

    Protected Sub btnRegresar_Click(sender As Object, e As System.EventArgs) Handles btnRegresar.Click
        MVQnas.SetActiveView(viewQnas)
    End Sub
End Class
