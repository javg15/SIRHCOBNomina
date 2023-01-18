Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Empleados.EstadosCiviles
    Public Class EstadoCivil
        Private _DataCOBAEV As New DataCOBAEV
        Public Function ObtenTodos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEstadosCiviles", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorSexo(ByVal IdSexo As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSexo", SqlDbType.TinyInt)}
                Prms(0).Value = IdSexo
                Return _DataCOBAEV.RunProc("SP_SEstadosCiviles", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
    End Class
End Namespace
