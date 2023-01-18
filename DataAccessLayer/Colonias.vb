Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Mexico.Estados.Municipios.Localidades.Colonias
    Public Class Colonia
        Private _DataCOBAEV As New DataCOBAEV
        Public Function InsertaActualiza(ByVal IdLoc As Integer, ByVal IdCol As Integer, ByVal NomCol As String, ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdLoc", SqlDbType.Int), _
                                            New SqlParameter("@IdCol", SqlDbType.Int), _
                                            New SqlParameter("@NomCol", SqlDbType.NVarChar, 60), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}
                Prms(0).Value = IdLoc
                Prms(1).Value = IdCol
                Prms(2).Value = NomCol
                Prms(3).Value = TipoOperacion

                Return _DataCOBAEV.RunProc("SP_IoUColonias", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaCodigoPostal(ByVal IdEdo As Byte, ByVal IdMun As Short, ByVal IdLoc As Integer, ByVal IdCol As Integer, ByVal CodPos As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEdo", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdMun", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdLoc", SqlDbType.Int), _
                                            New SqlParameter("@IdCol", SqlDbType.Int), _
                                            New SqlParameter("@CodPos", SqlDbType.NVarChar, 10)}
                Prms(0).Value = IdEdo
                Prms(1).Value = IdMun
                Prms(2).Value = IdLoc
                Prms(3).Value = IdCol
                Prms(4).Value = CodPos

                Return _DataCOBAEV.RunProc("SP_UCodigoPostal", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCodigoPostal(ByVal IdCol As Integer) As String
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCol", SqlDbType.Int), _
                                            New SqlParameter("@CodPos", SqlDbType.NVarChar, 10)}
                Prms(0).Value = IdCol
                Prms(1).Direction = ParameterDirection.Output
                _DataCOBAEV.RunProc("SP_SCodigoPostalPorColonia", Prms, DataCOBAEV.BD.Nomina)
                Return Prms(1).Value
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
    End Class
End Namespace
