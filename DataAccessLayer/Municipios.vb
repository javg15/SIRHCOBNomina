Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Mexico.Estados.Municipios
    Public Class Municipio
        Private _DataCOBAEV As New DataCOBAEV
        Public Function InsertaActualiza(ByVal IdEdo As Byte, ByVal IdMun As Short, ByVal NomMun As String, ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEdo", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdMun", SqlDbType.Int), _
                                            New SqlParameter("@NomMun", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}
                Prms(0).Value = IdEdo
                Prms(1).Value = IdMun
                Prms(2).Value = NomMun
                Prms(3).Value = TipoOperacion

                Return _DataCOBAEV.RunProc("SP_IoUMunicipios", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenLocalidades(ByVal IdMun As Short, ByVal ParaAdministracion As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdMun", SqlDbType.SmallInt), _
                                                New SqlParameter("@ParaAdministracion", SqlDbType.Bit)}
                Prms(0).Value = IdMun
                Prms(1).Value = ParaAdministracion
                Return _DataCOBAEV.RunProc("SP_SLocalidadesPorMunicipio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenLocalidades(ByVal IdMun As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdMun", SqlDbType.SmallInt)}
                Prms(0).Value = IdMun
                Return _DataCOBAEV.RunProc("SP_SLocalidadesPorMunicipio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
    End Class
End Namespace
