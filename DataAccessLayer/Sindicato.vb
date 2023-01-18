Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV
#Region "Clase Sindicato"
    Public Class Sindicato
#Region "Clase Sindicato: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Sindicato: Métodos públicos"
        Public Function ObtenTodos(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                If ParaDDL Then
                    Prms(0).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_SSindicatos", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_SSindicatos", DataCOBAEV.Tipoconsulta.Table, Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace