Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Imports System.Data.SqlClient
Imports System.Data
Partial Class MasterPageBlanca
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Dim ToolkitScriptManager1 As AjaxControlToolkit.ToolkitScriptManager
        'Dim lbAddPage_CBExtender As AjaxControlToolkit.ConfirmButtonExtender
        'Dim lbAddPage As LinkButton

        'lbAddPage_CBExtender = CType(Master.FindControl("lbAddPage_CBExtender"), AjaxControlToolkit.ConfirmButtonExtender)
        'lbAddPage = CType(Master.FindControl("lbAddPage"), LinkButton)
        'ToolkitScriptManager1 = CType(Master.FindControl("ToolkitScriptManager1"), AjaxControlToolkit.ToolkitScriptManager)


        Dim miScript As Literal = New Literal()

        miScript.Text = "<script type='text/javascript' language='javascript' src='" + ResolveClientUrl("~/JavaScript.js") + "'></script>"

        Page.Header.Controls.Add(miScript)

        If IsPostBack = False Then
            If Request.Url.Segments(Request.Url.Segments.Length - 1).ToString <> "ErroresPagina2.aspx" And _
                Request.Url.Segments(Request.Url.Segments.Length - 1).ToString <> "ErroresPagina.aspx" Then
                Dim oUsr As New Usuario
                Dim oValidacion As New Validaciones
                Dim _DataCOBAEV As New DataCOBAEV
                Dim dsValida As DataSet
                Dim drUsr As DataRow = Nothing

                Dim SaltarPermisos As Boolean = False

                SaltarPermisos = oUsr.EsSuperAdmin(Session("Login"))
                If SaltarPermisos Then Exit Sub

                dsValida = _DataCOBAEV.setDataSetErrores()
                oUsr.Login = Session("Login")
                Try
                    drUsr = oUsr.ObtenerPorLogin()
                Catch
                    Response.Redirect("~/Login.aspx")
                End Try
                If Not oUsr.TienePermisoSobrePagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString, CType(Request.Params("TipoOperacion"), Byte)) Then
                    Response.Redirect("~/SinPermiso.aspx")
                Else
                    With oValidacion
                        .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                        .RFC = IIf(Session("RFCEmp") Is Nothing, String.Empty, Session("RFCEmp"))
                        If .RFC = String.Empty Then
                            .RFC = IIf(Session("RFCParaCons") Is Nothing, String.Empty, Session("RFCParaCons"))
                        End If
                        .TipoOperacion2 = IIf(Request.Params("TipoOperacion") Is Nothing, -1, CSByte(Request.Params("TipoOperacion")))
                        .IdRecibo = IIf(Request.Params("IdRecibo") Is Nothing, 0, CShort(Request.Params("IdRecibo")))
                        .IdUsuario = CInt(drUsr("IdUsuario"))
                        .IdRol = CByte(drUsr("IdRol"))
                        Try
                            If Request.Params("IdReporte") Is Nothing = False And Request.Params("IdReporte").ToString.Substring(0, 2) = "CR" Then
                                .IdReporte = 0
                            Else
                                .IdReporte = IIf(Request.Params("IdReporte") Is Nothing, 0, CShort(Request.Params("IdReporte")))
                            End If
                        Catch
                            .IdReporte = IIf(Request.Params("IdReporte") Is Nothing, 0, CShort(Request.Params("IdReporte")))
                        End Try
                        .IdDeduccion = IIf(Request.Params("IdDeduccion") Is Nothing, 0, CShort(Request.Params("IdDeduccion")))
                        .IdPercepcion = IIf(Request.Params("IdPercepcion") Is Nothing, 0, CShort(Request.Params("IdPercepcion")))
                        .IdMotGralBaja = 0
                        .IdCategoria = IIf(Request.Params("IdCategoria") Is Nothing, 0, CShort(Request.Params("IdCategoria")))
                        .IdSindicato = IIf(Request.Params("IdSindicato") Is Nothing, 0, CByte(Request.Params("IdSindicato")))
                        .IdTipoEmp = IIf(Request.Params("IdTipoEmp") Is Nothing, 0, CByte(Request.Params("IdTipoEmp")))
                        .IdSemestre = IIf(Request.Params("IdSemestre") Is Nothing, 0, CShort(Request.Params("IdSemestre")))
                        If Request.Params("TipoConcepto") Is Nothing = False And Request.Params("IdConcepto") Is Nothing = False Then
                            If Request.Params("TipoConcepto").ToString = "P" Then
                                .IdPercepcion = CShort(Request.Params("IdConcepto").ToString)
                            ElseIf Request.Params("TipoConcepto").ToString = "D" Then
                                .IdDeduccion = CShort(Request.Params("IdConcepto").ToString)
                            End If
                        End If
                    End With
                    If Request.Params("ValidacionAlCargarPagina") Is Nothing = False Then
                        If Not oValidacion.ValidaPaginas(dsValida, True) And Request.Params("TipoOperacion") <> "4" Then
                            Session.Add("dsValida", dsValida)
                            Response.Redirect("~/ErroresPagina2.aspx")
                        Else
                            Session.Remove("dsValida")
                        End If
                    Else
                        If Not oValidacion.ValidaPaginas(dsValida) And Request.Params("TipoOperacion") <> "4" Then
                            Session.Add("dsValida", dsValida)
                            Response.Redirect("~/ErroresPagina2.aspx")
                        Else
                            Session.Remove("dsValida")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub lbAddPage_Click(sender As Object, e As System.EventArgs) Handles lbAddPage.Click
        Dim oAplic As New Aplicacion
        Dim oUsr As New Usuario

        oAplic.AgregaPagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString, ConfigurationManager.AppSettings("NombreAplicacion").ToString, CType(Session("ArregloAuditoria"), String()))

        Me.lbAddPage.Visible = oUsr.EsSuperAdmin(Session("Login")) And Not oAplic.PaginaEstaRegistrada(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString, ConfigurationManager.AppSettings("NombreAplicacion").ToString)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = ConfigurationManager.AppSettings("NombreCortoEmpresa") + " " + Page.Title.Substring(Page.Title.IndexOf("-"))
        Catch
            Page.Title = ConfigurationManager.AppSettings("NombreCortoEmpresa")
        End Try
        If Not IsPostBack Then
            Dim oUsr As New Usuario
            Dim oAplic As New Aplicacion

            lbAddPage.Text = "Agregar página " + Request.Url.Segments(Request.Url.Segments.Length - 1).ToString + " al Catálogo"
            lbAddPage.Visible = oUsr.EsSuperAdmin(Session("Login")) And Not oAplic.PaginaEstaRegistrada(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString, ConfigurationManager.AppSettings("NombreAplicacion").ToString)
        End If
    End Sub

End Class

