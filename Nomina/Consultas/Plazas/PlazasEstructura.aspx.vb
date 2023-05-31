Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Plazas
Imports DataAccessLayer.COBAEV

Partial Class PlazasEstructura
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then



        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos(Request.Params("idPlazaOcup"))
        End If
    End Sub

    Private Sub BindDatos(idPlazaOcup As String)
        Dim oEmp As New Empleado
        Dim oSMP_Plazas As New SMP_Plazas

        With gvDatos
            .DataSource = oSMP_Plazas.ObtenHistorial(idPlazaOcup)
            .DataBind()
            .Visible = True
        End With
    End Sub


End Class
