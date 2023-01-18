Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Partial Class frmLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnContinuar.Click
        Dim oEmp As Empleado = Nothing
        Dim dt As DataTable = Nothing
        'Dim oAut As New FormsAuthentication
        Dim vlAuthenticated As New AuthenticateEventArgs

        Select Case btnContinuar.Text
            Case "Continuar"
                oEmp = New Empleado
                'dt = oEmp.Buscar(Empleado.TipoBusqueda.NumeroDeEmpleado, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
                uname.Enabled = False
                psw.Enabled = True
                btnContinuar.Text = "Iniciar sesión"
            Case Else

        End Select

    End Sub
End Class
