Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV
    Public Class Conexion
        Private _Cnn As SqlConnection
        Public Function AbrirCnnBD(ByVal BD As String) As SqlConnection
            Try
                Select Case BD
                    Case "Administracion"
                        _Cnn = New SqlConnection(ConfigurationManager.AppSettings("CadCnnBDAdmon"))
                    Case "Nomina"
                        _Cnn = New SqlConnection(ConfigurationManager.AppSettings("CadCnnBDNomina"))
                    Case "MovsPersonal"
                        _Cnn = New SqlConnection(ConfigurationManager.AppSettings("CadCnnBDMovsPersonal"))
                End Select
                _Cnn.Open()
                Return _Cnn
            Catch ex As Exception
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Function
        Public Sub CerrarCnnBD()
            Try
                _Cnn.Close()
            Catch ex As Exception
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Sub
    End Class
End Namespace

