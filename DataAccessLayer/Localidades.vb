Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Mexico.Estados.Municipios.Localidades
    Public Class Localidad
        Private _DataCOBAEV As New DataCOBAEV
        Public Function InsertaActualiza(ByVal IdMun As Short, ByVal IdLoc As Integer, ByVal NomLoc As String, ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdMun", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdLoc", SqlDbType.Int), _
                                            New SqlParameter("@NomLoc", SqlDbType.NVarChar, 85), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}
                Prms(0).Value = IdMun
                Prms(1).Value = IdLoc
                Prms(2).Value = NomLoc
                Prms(3).Value = TipoOperacion

                Return _DataCOBAEV.RunProc("SP_IoULocalidades", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCodigoPostal(ByVal IdLoc As Integer) As String
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdLoc", SqlDbType.Int), _
                                            New SqlParameter("@CodPos", SqlDbType.NVarChar, 10)}
                Prms(0).Value = IdLoc
                Prms(1).Direction = ParameterDirection.Output
                _DataCOBAEV.RunProc("SP_SCodigoPostalPorLocalidad", Prms, DataCOBAEV.BD.Nomina)
                Return Prms(1).Value
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenColonias(ByVal IdLoc As Integer, ByVal ParaAdministracion As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdLoc", SqlDbType.Int), _
                                             New SqlParameter("@ParaAdministracion", SqlDbType.Bit)}
                Prms(0).Value = IdLoc
                Prms(1).Value = ParaAdministracion
                Return _DataCOBAEV.RunProc("SP_SColoniasPorLocalidad", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenColonias(ByVal IdLoc As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdLoc", SqlDbType.Int)}
                Prms(0).Value = IdLoc
                Return _DataCOBAEV.RunProc("SP_SColoniasPorLocalidad", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarCalles(ByVal Calle As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Calle", SqlDbType.NVarChar, 60)}
                Prms(0).Value = Calle
                Return _DataCOBAEV.RunProc("SP_SBuscaCalles", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarColonias(ByVal Colonia As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Colonia", SqlDbType.NVarChar, 60)}
                Prms(0).Value = Colonia
                Return _DataCOBAEV.RunProc("SP_SBuscaColonias", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
    End Class
End Namespace
