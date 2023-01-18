Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Empleados.Sexos
    Public Class Sexo
        Private _DataCOBAEV As New DataCOBAEV
        Public Function ObtenTodos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SSexos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorAbrevCURP(ByVal AbrevCURP As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@AbrevCURP", SqlDbType.NVarChar, 1)}
                Prms(0).Value = AbrevCURP
                Return _DataCOBAEV.RunProc("SP_SSexoPorAbrevCURP", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
    End Class
End Namespace
