Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class ObservacionesSobrePlazas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0

            Dim oPlaza As New EmpleadoPlazas

            gvObservaciones.DataSource = oPlaza.ObtenObservaciones(CInt(Request.Params("IdPlaza")))
            gvObservaciones.DataBind()

            Me.lbCerrar.OnClientClick = "javascript:window.close();"
        End If
    End Sub
End Class
