Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Mexico.Estados
    Public Class Estado
        Private _DataCOBAEV As New DataCOBAEV
        Public Function ObtenTodos(ByVal ParaAdministracion As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaAdministracion", SqlDbType.Bit)}
                Prms(0).Value = ParaAdministracion

                Return _DataCOBAEV.RunProc("SP_SEstados", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMunicipios(ByVal IdEdo As Byte, ByVal ParaAdministracion As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEdo", SqlDbType.TinyInt), _
                                            New SqlParameter("@ParaAdministracion", SqlDbType.Bit)}
                Prms(0).Value = IdEdo
                Prms(1).Value = ParaAdministracion
                Return _DataCOBAEV.RunProc("SP_SMunicipiosPorEstado", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEstados", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaDomicilio(ByVal ParaCURP As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaCURP", SqlDbType.TinyInt)}
                Prms(0).Value = ParaCURP
                Return _DataCOBAEV.RunProc("SP_SEstados", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMunicipios(ByVal IdEdo As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEdo", SqlDbType.TinyInt)}
                Prms(0).Value = IdEdo
                Return _DataCOBAEV.RunProc("SP_SMunicipiosPorEstado", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorDescCortaCURP(ByVal DescCortaCURP As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@DescCortaCURP", SqlDbType.NVarChar, 2)}
                Prms(0).Value = DescCortaCURP
                Return _DataCOBAEV.RunProc("SP_SEstadoPorDescCortaCURP", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
    End Class
End Namespace
