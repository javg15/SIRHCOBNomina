Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data.SqlClient
Imports System.Data
Partial Class mpSesionIniciada
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        '<script type="text/javascript" language="javascript" src="<%= ResolveClientUrl("~/JavaScript.js") %>"></script>
        '<script type="text/javascript" language="javascript" src="<%= ResolveClientUrl("~/JavaScript2.js") %>"></script>
        Dim miScript As Literal = New Literal()
        Dim miScript2 As Literal = New Literal()

        miScript.Text = "<script type='text/javascript' language='javascript' src='" + ResolveClientUrl("~/JavaScript.js") + "'></script>"
        miScript2.Text = "<script type='text/javascript' language='javascript' src='" + ResolveClientUrl("~/JavaScript2.js") + "'></script>"

        Page.Header.Controls.Add(miScript)
        Page.Header.Controls.Add(miScript2)

        If Not IsPostBack Then
            Dim oUsr As New Usuario
            Dim oValidacion As New Validaciones
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsValida As DataSet
            Dim drUsr As DataRow = Nothing
            Dim UsrTienePermiso As Boolean

            dsValida = _DataCOBAEV.setDataSetErrores()
            oUsr.Login = Session("Login")
            Try
                drUsr = oUsr.ObtenerPorLogin()
            Catch
                Response.Redirect("~/Login.aspx")
            End Try
            If Session("Login") Is Nothing Then
                Response.Redirect("~/Login.aspx")
            Else
                oUsr.Login = Session("Login")
            End If

            If Request.Params("TipoOperacion") Is Nothing Then
                UsrTienePermiso = oUsr.TienePermisoSobrePagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString, 4)
            Else
                UsrTienePermiso = oUsr.TienePermisoSobrePagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString, CByte(Request.Params("TipoOperacion")))
            End If

            If Not UsrTienePermiso Then 'oUsr.TienePermisoSobrePagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString, CByte(Request.Params("TipoOperacion"))) Then
                Response.Redirect("~/SinPermiso.aspx?Home=SI")
            Else
                With oValidacion
                    .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                    .RFC = IIf(Session("RFCParaCons") Is Nothing, String.Empty, Session("RFCParaCons"))
                    .IdRecibo = IIf(Request.Params("IdRecibo") Is Nothing, 0, CShort(Request.Params("IdRecibo")))
                    .IdUsuario = CInt(drUsr("IdUsuario"))
                    .TipoOperacion2 = CSByte(Request.Params("TipoOperacion"))
                End With
                If Request.Params("ValidacionAlCargarPagina") Is Nothing = False Then
                    If Not oValidacion.ValidaPaginas(dsValida, True) Then
                        Session.Add("dsValida", dsValida)
                        Response.Redirect("~/ErroresPagina.aspx?Home=SI")
                    Else
                        Session.Remove("dsValida")
                    End If
                Else
                    If Not oValidacion.ValidaPaginas(dsValida) Then
                        Session.Add("dsValida", dsValida)
                        Response.Redirect("~/ErroresPagina.aspx?Home=SI")
                    Else
                        Session.Remove("dsValida")
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = ConfigurationManager.AppSettings("NombreCortoEmpresa") + " " + Page.Title.Substring(Page.Title.IndexOf("-"))
        Catch
            Page.Title = ConfigurationManager.AppSettings("NombreCortoEmpresa")
        End Try
        If Not IsPostBack Then
            Dim vlHayQnaAbierta As Boolean
            Dim oQna As New Quincenas

            vlHayQnaAbierta = oQna.HayAbiertasParaCaptura()

            pnlWarning2.Visible = Not vlHayQnaAbierta

            Session.Remove("pFchImpRpt")
            If System.IO.File.Exists(ConfigurationManager.AppSettings("RutaImagenes") + Date.Now.Month.ToString + ".gif") Then
                Me.ImgGifAnim.ImageUrl = "~/Imagenes/" + Date.Now.Month.ToString + ".gif"
                Me.ImgGifAnim.Visible = True
            Else
                Me.ImgGifAnim.ImageUrl = "~/Imagenes/Comodin.gif"
                Me.ImgGifAnim.Visible = False
            End If

            Me.LoginStatus1.LogoutText = "Cerrar sesión de: " + Session("Login").ToString.ToUpper
            If Request.Url.Segments(Request.Url.Segments.Length - 1).ToString.ToUpper <> "OPCIONESDECALCULO.ASPX" Then
                Session.Remove("CalculandoNomina")
            End If

            Dim URL As String
            Dim oUsr As New Usuario
            Dim dtMenuItems As New DataTable
            Dim oAplic As New Aplicacion

            oUsr.Login = Session("Login")
            dtMenuItems = oUsr.ObtenerNodosMenu()

            For Each drMenuItem As DataRow In dtMenuItems.Rows
                If drMenuItem("IdNodoMenu").Equals(drMenuItem("IdNodoMenuPadre")) Then
                    Dim mnuMenuItem As New MenuItem
                    mnuMenuItem.Value = drMenuItem("IdNodoMenu").ToString
                    mnuMenuItem.Text = drMenuItem("DescNodoMenu").ToString
                    mnuMenuItem.ImageUrl = drMenuItem("URLImagen").ToString
                    If CType(drMenuItem("Javascript"), Boolean) Then
                        URL = "javascript:" + drMenuItem("FuncionJavascript").ToString + "('"
                        URL += "http://" + Request.Url.Authority + Request.Url.Segments(0).ToString + Request.Url.Segments(1).ToString + drMenuItem("URLNodoMenu").ToString
                        If dtMenuItems("NombreVentana").ToString = String.Empty Then
                            URL += drMenuItem("Parametros").ToString + "')"
                        Else
                            URL += drMenuItem("Parametros").ToString + "','" + dtMenuItems("NombreVentana").ToString + "')"
                        End If
                        mnuMenuItem.NavigateUrl = URL
                    Else
                        mnuMenuItem.NavigateUrl = drMenuItem("URLNodoMenu").ToString + drMenuItem("Parametros").ToString
                    End If
                    mnuMenuItem.Target = drMenuItem("TargetNodoMenu").ToString

                    Menu1.Items.Add(mnuMenuItem)

                    AddMenuItem(mnuMenuItem, dtMenuItems)
                End If
            Next
            Me.lbAddPage.Text = "Agregar página " + Request.Url.Segments(Request.Url.Segments.Length - 1).ToString + " al Catálogo"
            Me.lbAddPage.Visible = oUsr.EsSuperAdmin(Session("Login")) And Not oAplic.PaginaEstaRegistrada(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString, ConfigurationManager.AppSettings("NombreAplicacion").ToString)
        End If
    End Sub
    Private Sub AddMenuItem(ByRef mnuMenuItem As MenuItem, ByRef dtMenuItems As DataTable)
        Dim URL As String
        For Each drMenuItem As DataRow In dtMenuItems.Rows
            If drMenuItem("IdNodoMenuPadre").ToString.Equals(mnuMenuItem.Value) AndAlso _
                Not drMenuItem("IdNodoMenu").Equals(drMenuItem("IdNodoMenuPadre")) Then
                Dim mnuNewMenuItem As New MenuItem
                mnuNewMenuItem.Value = drMenuItem("IdNodoMenu")
                mnuNewMenuItem.Text = drMenuItem("DescNodoMenu")
                mnuNewMenuItem.ImageUrl = drMenuItem("URLImagen")
                If CType(drMenuItem("Javascript"), Boolean) Then
                    URL = "javascript:" + drMenuItem("FuncionJavascript").ToString + "('"
                    URL += "http://" + Request.Url.Authority + Request.Url.Segments(0).ToString + Request.Url.Segments(1).ToString + drMenuItem("URLNodoMenu").ToString
                    URL += drMenuItem("Parametros").ToString + "')"
                    mnuNewMenuItem.NavigateUrl = URL
                Else
                    mnuNewMenuItem.NavigateUrl = drMenuItem("URLNodoMenu") + drMenuItem("Parametros").ToString
                End If
                mnuNewMenuItem.Target = drMenuItem("TargetNodoMenu")
                mnuMenuItem.ChildItems.Add(mnuNewMenuItem)

                AddMenuItem(mnuNewMenuItem, dtMenuItems)
            End If
        Next
    End Sub
    Protected Sub LoginStatus1_LoggingOut(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles LoginStatus1.LoggingOut
        Me.Session.RemoveAll()
    End Sub

    Protected Sub lbAddPage_Click(sender As Object, e As System.EventArgs) Handles lbAddPage.Click
        Dim oAplic As New Aplicacion
        Dim oUsr As New Usuario

        oAplic.AgregaPagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString, ConfigurationManager.AppSettings("NombreAplicacion").ToString, CType(Session("ArregloAuditoria"), String()))

        Me.lbAddPage.Visible = oUsr.EsSuperAdmin(Session("Login")) And Not oAplic.PaginaEstaRegistrada(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString, ConfigurationManager.AppSettings("NombreAplicacion").ToString)
    End Sub
End Class
