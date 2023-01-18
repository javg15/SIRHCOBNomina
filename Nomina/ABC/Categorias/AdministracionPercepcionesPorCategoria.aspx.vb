Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Imports System.Data
Partial Class Administracion_PercepcionesPorCategoria
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oCatego As New Categoria
        Dim oQna As New Quincenas
        Dim crItem As ListItem
        With oCatego
            .IdCategoria = CShort(Request.Params("IdCategoria"))
            .IdPercepcion = CShort(Request.Params("IdPercepcion"))
            .IdZonaEco = CByte(Request.Params("IdZonaEco"))
            .IdQnaVigIniPerc = CShort(Request.Params("IdQnaVigIniPerc"))
            Me.dvPercepcion.DataSource = oCatego.ObtenPercepcionParaModificar()
            Me.dvPercepcion.DataBind()
            If Request.Params("TipoOperacion") = "1" Then
                Dim ddlQnaIni As DropDownList = CType(Me.dvNuevosValores.FindControl("ddlQnaIni"), DropDownList)
                With ddlQnaIni
                    .DataSource = oQna.ObtenPosiblesParaInicioPercepcion()
                    .DataTextField = "Quincena"
                    .DataValueField = "IdQuincena"
                    .DataBind()
                    If .Items(0).Text <= CType(Me.dvPercepcion.FindControl("lblVigIniPerc"), Label).Text Then CType(Me.dvNuevosValores.FindControl("btnGuardar"), Button).Enabled = False
                End With
            ElseIf Request.Params("TipoOperacion") = "0" Then
                Dim ddlVigIniPerc As DropDownList = CType(Me.dvPercepcion.FindControl("ddlVigIniPerc"), DropDownList)
                With ddlVigIniPerc
                    .DataSource = oQna.ObtenPosiblesParaInicioPercepcion()
                    .DataTextField = "Quincena"
                    .DataValueField = "IdQuincena"
                    .DataBind()
                    crItem = .Items.FindByValue(Request.Params("IdQnaVigIniPerc").ToString)
                    .SelectedValue = Request.Params("IdQnaVigIniPerc").ToString
                    If crItem Is Nothing Then CType(Me.dvPercepcion.FindControl("btnGuardar"), Button).Enabled = False
                End With
            End If
        End With
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            If Request.Params("TipoOperacion") = "1" Then
                Me.dvPercepcion.ChangeMode(DetailsViewMode.ReadOnly)
                Me.dvNuevosValores.ChangeMode(DetailsViewMode.Insert)
            ElseIf Request.Params("TipoOperacion") = "0" Then
                Me.dvPercepcion.ChangeMode(DetailsViewMode.Edit)
                Me.dvNuevosValores.Visible = False
            End If
            Me.MultiView1.SetActiveView(Me.viewCaptura)
            BindDatos()
        End If
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim oValidacion As New Validaciones
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsValida As DataSet
            Dim ddlVigIniPerc As DropDownList = CType(Me.dvPercepcion.FindControl("ddlVigIniPerc"), DropDownList)

            dsValida = _DataCOBAEV.setDataSetErrores()

            With oValidacion
                .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
                .IdQuincena = CShort(Request.Params("IdQnaVigIniPerc"))
                .IdQuincenaNueva = CShort(ddlVigIniPerc.SelectedValue)
                If Not .ValidaPaginasOperacion(dsValida) Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            End With

            Dim oCatego As New Categoria
            Dim txtbxImpMenPerc As TextBox = CType(Me.dvPercepcion.FindControl("txtbxImpMenPerc"), TextBox)
            Dim ChBxModifRP As CheckBox = CType(Me.dvPercepcion.FindControl("ChBxModifRP"), CheckBox)

            With oCatego
                .IdCategoria = CShort(Request.Params("IdCategoria"))
                .IdPercepcion = CShort(Request.Params("IdPercepcion"))
                .IdZonaEco = CByte(Request.Params("IdZonaEco"))
                .IdQnaVigIniPerc = CShort(ddlVigIniPerc.SelectedValue)
                .ImpMenPerc = CDec(txtbxImpMenPerc.Text)
                .ActualizaPercepcionPorCategoria(ChBxModifRP.Checked, CType(Session("ArregloAuditoria"), String()))
            End With
            Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
            Me.lblCapturaExitosa.Text = "Actualización realizada correctamente."
        Catch ex As Exception
            Me.MultiView1.SetActiveView(Me.viewErrores)
            Me.lblErrores.Text = ex.Message
        End Try
    End Sub

    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub

    Protected Sub btnGuardar_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim oValidacion As New Validaciones
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsValida As DataSet
            dsValida = _DataCOBAEV.setDataSetErrores()

            With oValidacion
                .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
                .IdQuincena = CShort(Request.Params("IdQnaVigIniPerc"))
                '.IdQuincenaNueva = CShort(ddlQnaIni.SelectedValue)
                If Not .ValidaPaginasOperacion(dsValida) Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            End With

            Dim oCatego As New Categoria
            Dim txtbxNuevoImporte As TextBox = CType(Me.dvNuevosValores.FindControl("txtbxNuevoImporte"), TextBox)
            Dim ddlQnaIni As DropDownList = CType(Me.dvNuevosValores.FindControl("ddlQnaIni"), DropDownList)
            Dim ChBxModifRP As CheckBox = CType(Me.dvNuevosValores.FindControl("ChBxModifRP"), CheckBox)

            With oCatego
                .IdCategoria = CShort(Request.Params("IdCategoria"))
                .IdPercepcion = CShort(Request.Params("IdPercepcion"))
                .IdZonaEco = CByte(Request.Params("IdZonaEco"))
                .IdQnaVigIniPerc = CShort(ddlQnaIni.SelectedValue)
                .ImpMenPerc = CDec(txtbxNuevoImporte.Text)
                .InsertaPercepcionPorCategoria(ChBxModifRP.Checked, CType(Session("ArregloAuditoria"), String()))
            End With
            Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
            Me.lblCapturaExitosa.Text = "Inserción realizada correctamente."
        Catch ex As Exception
            Me.MultiView1.SetActiveView(Me.viewErrores)
            Me.lblErrores.Text = ex.Message
        End Try
    End Sub
End Class
