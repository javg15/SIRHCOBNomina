Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV.Nominas
#Region "Clase Reportes"
    Public Class Reportes
#Region "Propiedades privadas: Clase Reportes"
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdReporte As Short
#End Region
#Region "Propiedades públicas: Clase Reportes"
        Public Property IdReporte() As Short
            Get
                Return Me._IdReporte
            End Get
            Set(ByVal value As Short)
                Me._IdReporte = value
            End Set
        End Property
#End Region
#Region "Métodos públicos: Clase Reportes"
        Public Function ObtenInfParaImpresion(ByVal IdReporte As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdReporte", SqlDbType.SmallInt)}

                Prms(0).Value = IdReporte

                Return _DataCOBAEV.RunProc("SP_SReportesInfParaImpresion", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfParaImpresion(ByVal IdReporte As Short, ByVal SubTipoReporte As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdReporte", SqlDbType.SmallInt), _
                                              New SqlParameter("@SubTipoReporte", SqlDbType.TinyInt)}

                Prms(0).Value = IdReporte
                Prms(1).Value = SubTipoReporte

                Return _DataCOBAEV.RunProc("SP_SReportesInfParaImpresion", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorPagina(ByVal IdPagina As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPagina", SqlDbType.SmallInt)}

                Prms(0).Value = IdPagina

                Return _DataCOBAEV.RunProc("SP_SReportesPorPagina", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorPagina(ByVal pIdPagina As Short, ByVal pIdRol As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPagina", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdRol", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPagina
                Prms(1).Value = pIdRol

                Return _DataCOBAEV.RunProc("SP_SReportesPorPagina", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenOpcionesVarias(ByVal pIdReporte As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdReporte", SqlDbType.SmallInt)}

                Prms(0).Value = pIdReporte

                Return _DataCOBAEV.RunProc("SP_SReportesOpcionesVarias", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace


