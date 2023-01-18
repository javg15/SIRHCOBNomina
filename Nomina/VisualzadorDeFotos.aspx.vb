Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Partial Class Consultas_Empleados_VisualzadorDeFotos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oEmp As New Empleado
            Dim dr As DataRow
            oEmp.RFC = Request.Params("RFCEmp")
            dr = oEmp.ObtenDatosLaborales().Rows(0)
            Try
                Me.imgFoto.ImageUrl = ConfigurationManager.AppSettings("ServerExpedientes") + "Fotos/" + dr("NumEmp") + ".jpg"
            Catch
                Me.imgFoto.ImageUrl = String.Empty
            End Try
            Me.lbCerrar.OnClientClick = "javascript:window.close();"
        End If
    End Sub
End Class
