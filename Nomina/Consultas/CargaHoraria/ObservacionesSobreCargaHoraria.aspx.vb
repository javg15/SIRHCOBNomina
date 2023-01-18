Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports System.Data
Partial Class ObservacionesSobreCargaHoraria
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0

            Dim oEmpleado As New Hora

            gvObservaciones.DataSource = oEmpleado.ObtenObservacionesSobreCargaHoraria(Request.Params("RFCEmp"), CShort(Request.Params("IdSemestre")))
            gvObservaciones.DataBind()

            Me.lbCerrar.OnClientClick = "javascript:window.close();"
        End If
    End Sub
End Class
