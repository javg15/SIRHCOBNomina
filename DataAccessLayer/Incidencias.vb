Imports System.Data.SqlClient
Namespace COBAEV
#Region "Clase Incidencias"
    Public Class Incidencias
#Region "Incidencias: Propiedades Privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Incidencias: Propiedades Públicas"

#End Region
#Region "Incidencias: Métodos Públicos"
        Public Function ObtenTiposDeJustPorJefe(ByVal pTipoIncidencia) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTipoIncidencia", SqlDbType.NVarChar, 10)}

                Prms(0).Value = pTipoIncidencia
                Return _DataCOBAEV.RunProc("SP_STiposDeIndicenciasJustifPorJefe", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Elimina(ByVal pFolioIncidencia As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@FolioIncidencia", SqlDbType.NVarChar, 10)}

                Prms(0).Value = pFolioIncidencia

                Return _DataCOBAEV.RunProc("SP_DControlIncidencias", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTipos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_STiposDeIncidencias", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal pIdTipoIncidencia As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTipoIncidencia", SqlDbType.SmallInt)}

                Prms(0).Value = pIdTipoIncidencia

                Return _DataCOBAEV.RunProc("SP_STiposDeIncidenciaPorId", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorFolio(ByVal pFolioIncidencia As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@FolioIncidencia", SqlDbType.NVarChar, 10)}

                Prms(0).Value = pFolioIncidencia

                Return _DataCOBAEV.RunProc("SP_SIncidenciaPorFolio", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function Inserta(ByVal pAnio As Short,
                                ByVal pIdTipoIncidencia As Byte,
                                ByVal pIdEmp As Integer,
                                ByVal FechaIni As Date,
                                ByVal FechaFin As Date,
                                ByVal pDiasLicMedica As Short,
                                ByVal pFolioISSSTE As String,
                                ByVal pFolioIncidencia2 As String,
                                ByVal pIdUsuario As Short,
                                ByVal pTipoOperacion As Byte,
                                ByVal pFechaJust As String,
                                ByVal pIdTipoJustifPorJefe As Byte,
                                ByVal ArregloAuditoria() As String) As String
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt),
                                              New SqlParameter("@FolioIncidencia", SqlDbType.NVarChar, 10),
                                              New SqlParameter("@IdTipoIncidencia", SqlDbType.TinyInt),
                                            New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@FechaIni", SqlDbType.DateTime),
                                            New SqlParameter("@FechaFin", SqlDbType.DateTime),
                                            New SqlParameter("@DiasLicMedica", SqlDbType.SmallInt),
                                            New SqlParameter("@FolioISSSTE", SqlDbType.NVarChar, 50),
                                            New SqlParameter("@FolioIncidencia2", SqlDbType.NVarChar, 150),
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                                              New SqlParameter("@FechaJust", SqlDbType.DateTime),
                                              New SqlParameter("@IdTipoJustifPorJefe", SqlDbType.TinyInt)}

                Prms(0).Value = pAnio
                Prms(1).Direction = ParameterDirection.InputOutput
                Prms(2).Value = pIdTipoIncidencia
                Prms(3).Value = pIdEmp
                Prms(4).Value = FechaIni
                Prms(5).Value = FechaFin
                Prms(6).Value = pDiasLicMedica
                Prms(7).Value = pFolioISSSTE
                Prms(8).Value = pFolioIncidencia2
                Prms(9).Value = pIdUsuario
                Prms(10).Value = pTipoOperacion
                Prms(11).Value = IIf(pFechaJust = String.Empty, DBNull.Value, IIf(pFechaJust = "31/12/2099", DBNull.Value, pFechaJust))
                Prms(12).Value = pIdTipoJustifPorJefe

                _DataCOBAEV.RunProc("SP_IoUControlDeIndicencias", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Return Prms(1).Value
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualiza(ByVal pAnio As Short, ByVal pFolioIncidencia As String, ByVal pIdTipoIncidencia As Byte,
                                     ByVal pIdEmp As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date,
                                     ByVal pDiasLicMedica As Short, ByVal pFolioISSSTE As String,
                                     ByVal pFolioIncidencia2 As String,
                                     ByVal pIdUsuario As Short,
                                     ByVal pTipoOperacion As Byte, ByVal pFechaJust As String,
                                     ByVal pIdTipoJustifPorJefe As Byte,
                                     ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt),
                                              New SqlParameter("@FolioIncidencia", SqlDbType.NVarChar, 10),
                                              New SqlParameter("@IdTipoIncidencia", SqlDbType.TinyInt),
                                            New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@FechaIni", SqlDbType.DateTime),
                                            New SqlParameter("@FechaFin", SqlDbType.DateTime),
                                            New SqlParameter("@DiasLicMedica", SqlDbType.SmallInt),
                                            New SqlParameter("@FolioISSSTE", SqlDbType.NVarChar, 50),
                                            New SqlParameter("@FolioIncidencia2", SqlDbType.NVarChar, 150),
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                                            New SqlParameter("@FechaJust", SqlDbType.DateTime),
                                            New SqlParameter("@IdTipoJustifPorJefe", SqlDbType.TinyInt)}

                Prms(0).Value = pAnio
                Prms(1).Direction = ParameterDirection.InputOutput
                Prms(1).Value = pFolioIncidencia
                Prms(2).Value = pIdTipoIncidencia
                Prms(3).Value = pIdEmp
                Prms(4).Value = FechaIni
                Prms(5).Value = FechaFin
                Prms(6).Value = pDiasLicMedica
                Prms(7).Value = pFolioISSSTE
                Prms(8).Value = pFolioIncidencia2
                Prms(9).Value = pIdUsuario
                Prms(10).Value = pTipoOperacion
                Prms(11).Value = IIf(pFechaJust = String.Empty, DBNull.Value, IIf(pFechaJust = "31/12/2099", DBNull.Value, pFechaJust))
                Prms(12).Value = pIdTipoJustifPorJefe

                Return _DataCOBAEV.RunProc("SP_IoUControlDeIndicencias", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenPorAnioEmp(ByVal pRFCEmp As String, ByVal pAnio As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                               New SqlParameter("@Anio", SqlDbType.SmallInt)}
                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SIncidenciasAnualesPorEmp", Prms, "IncidenciasAnualesPorEmp", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenPorTipoAnioMesEmp(ByVal pRFCEmp As String, ByVal pAnio As Short, _
                                               ByVal pMes As Byte, ByVal pNomCortoTipoIncidencia As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                               New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@Mes", SqlDbType.TinyInt), _
                                              New SqlParameter("@NomCortoTipoIncidencia", SqlDbType.NVarChar, 10)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio
                Prms(2).Value = pMes
                Prms(3).Value = pNomCortoTipoIncidencia

                Return _DataCOBAEV.RunProc("SP_SIncidenciasAnualesPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenPermisosEconomicos(ByVal pRFCEmp As String, ByVal pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                               New SqlParameter("@Anio", SqlDbType.SmallInt)}
                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SDiasEcoAnualesPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPermisosEconomicos(ByVal pRFCEmp As String, ByVal pAnio As Short, ByVal pMes As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                               New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@Mes", SqlDbType.TinyInt)}
                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio
                Prms(2).Value = pMes

                Return _DataCOBAEV.RunProc("SP_SDiasEcoAnualesPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
#Region "Incidencias: Métodos Privados"

#End Region
    End Class
#End Region
End Namespace
