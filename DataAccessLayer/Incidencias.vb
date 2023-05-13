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
        Public Function ObtenTiposDeIncidenciaSubtipos(ByVal pIdTipoIncidencia, ByVal pIdSubtipoIncidencia) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTipoIncidencia", SqlDbType.NVarChar, 10),
                                            New SqlParameter("@IdTiposDeIndicenciasSubtipos", SqlDbType.NVarChar, 10)
                    }

                Prms(0).Value = pIdTipoIncidencia
                Prms(1).Value = pIdSubtipoIncidencia
                Return _DataCOBAEV.RunProc("SP_STiposDeIndicenciasSubtipos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Elimina(ByVal pId As Integer, ByVal pIdUsuarioElimina As Integer, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Id", SqlDbType.Int),
                    New SqlParameter("@IdUsuarioDel", SqlDbType.Int)
                }

                Prms(0).Value = pId
                Prms(1).Value = pIdUsuarioElimina

                Return _DataCOBAEV.RunProc("SP_DControlIncidencias", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTipos(ByVal pId As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.Int)}

                Prms(0).Value = pId

                Return _DataCOBAEV.RunProc("SP_STiposDeIncidencias", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTipoIncidenciaPorId(ByVal pIdTipoIncidencia As Short) As DataTable
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
        Public Function ObtenPorId(ByVal pIdIncidencia As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdIncidencia", SqlDbType.Int)}

                Prms(0).Value = pIdIncidencia

                Return _DataCOBAEV.RunProc("SP_SIncidenciaPorId", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function VInsercionPrevia_Incidencias(ByVal pRFCEmp As String,
                                ByVal pIdTipoIncidencia As Byte,
                                ByVal FechaIni As Date,
                                ByVal FechaFin As Date,
                                ByVal pTipoOperacion As Short,
                                ByVal pFolioIncidencia As String,
                                ByVal pIdTiposDeIndicenciasSubtipos As Byte) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@IdTipoIncidencia", SqlDbType.TinyInt),
                                            New SqlParameter("@FechaInicial", SqlDbType.DateTime),
                                            New SqlParameter("@FechaFinal", SqlDbType.DateTime),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                                            New SqlParameter("@FolioIncidencia", SqlDbType.NVarChar, 50),
                                            New SqlParameter("@IdTipoIncidenciaSubtipos", SqlDbType.TinyInt)
                }

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdTipoIncidencia
                Prms(2).Value = FechaIni
                Prms(3).Value = FechaFin
                Prms(4).Value = pTipoOperacion
                Prms(5).Value = pFolioIncidencia
                Prms(6).Value = pIdTiposDeIndicenciasSubtipos

                Return _DataCOBAEV.RunProc("SP_VInsercionPrevia_Incidencias", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function Inserta(ByVal pAnio As Short,
                                ByVal pFolioIncidencia As String,
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
                                ByVal pIdTiposDeIndicenciasSubtipos As Byte,
                                ByVal ArregloAuditoria() As String) As String
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Id", SqlDbType.Int, 10),
                                                New SqlParameter("@Anio", SqlDbType.SmallInt),
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
                                              New SqlParameter("@IdTiposDeIndicenciasSubtipos", SqlDbType.TinyInt),
                                              New SqlParameter("@FolioIncidenciaAutogenerado", SqlDbType.NVarChar, 10)
                                }

                Prms(0).Direction = ParameterDirection.InputOutput
                Prms(1).Value = pAnio
                Prms(2).Value = pFolioIncidencia
                Prms(2).Direction = ParameterDirection.InputOutput
                Prms(3).Value = pIdTipoIncidencia
                Prms(4).Value = pIdEmp
                Prms(5).Value = FechaIni
                Prms(6).Value = FechaFin
                Prms(7).Value = pDiasLicMedica
                Prms(8).Value = pFolioISSSTE
                Prms(9).Value = pFolioIncidencia2
                Prms(10).Value = pIdUsuario
                Prms(11).Value = pTipoOperacion
                Prms(12).Value = IIf(pFechaJust = String.Empty, DBNull.Value, IIf(pFechaJust = "31/12/2099", DBNull.Value, pFechaJust))
                Prms(13).Value = pIdTiposDeIndicenciasSubtipos
                Prms(14).Direction = ParameterDirection.InputOutput

                _DataCOBAEV.RunProc("SP_IoUControlDeIndicencias", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Return Prms(0).Value.ToString + "," + Prms(14).Value
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualiza(ByVal pId As Int32, ByVal pAnio As Short, ByVal pFolioIncidencia As String, ByVal pIdTipoIncidencia As Byte,
                                     ByVal pIdEmp As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date,
                                     ByVal pDiasLicMedica As Short, ByVal pFolioISSSTE As String,
                                     ByVal pFolioIncidencia2 As String,
                                     ByVal pIdUsuario As Short,
                                     ByVal pTipoOperacion As Byte, ByVal pFechaJust As String,
                                     ByVal pIdTiposDeIndicenciasSubtipos As Byte,
                                     ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Id", SqlDbType.Int),
                                            New SqlParameter("@Anio", SqlDbType.SmallInt),
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
                                            New SqlParameter("@IdTiposDeIndicenciasSubtipos", SqlDbType.TinyInt)}

                Prms(0).Value = pId
                Prms(0).Direction = ParameterDirection.InputOutput
                Prms(1).Value = pAnio
                Prms(2).Value = pFolioIncidencia
                Prms(3).Value = pIdTipoIncidencia
                Prms(4).Value = pIdEmp
                Prms(5).Value = FechaIni
                Prms(6).Value = FechaFin
                Prms(7).Value = pDiasLicMedica
                Prms(8).Value = pFolioISSSTE
                Prms(9).Value = pFolioIncidencia2
                Prms(10).Value = pIdUsuario
                Prms(11).Value = pTipoOperacion
                Prms(12).Value = IIf(pFechaJust = String.Empty, DBNull.Value, IIf(pFechaJust = "31/12/2099", DBNull.Value, pFechaJust))
                Prms(13).Value = pIdTiposDeIndicenciasSubtipos

                Return _DataCOBAEV.RunProc("SP_IoUControlDeIndicencias", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenPorAnioEmp(ByVal pRFCEmp As String, ByVal pAnio As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                               New SqlParameter("@Anio", SqlDbType.SmallInt)}
                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SIncidenciasAnualesPorEmp", Prms, "IncidenciasAnualesPorEmp", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenPorTipoAnioMesEmp(ByVal pRFCEmp As String, ByVal pAnio As Short,
                                               ByVal pMes As Byte, ByVal pNomCortoTipoIncidencia As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                               New SqlParameter("@Anio", SqlDbType.SmallInt),
                                                New SqlParameter("@Mes", SqlDbType.TinyInt),
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
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
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
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                               New SqlParameter("@Anio", SqlDbType.SmallInt),
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
