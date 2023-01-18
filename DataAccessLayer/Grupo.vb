Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Planteles
    Public Class Grupo
#Region "Clase Grupo"
        Private _IdGrupo As Byte
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Grupo: Propiedades privadas"
        Public Property IdGrupo() As Byte
            Get
                Return _IdGrupo
            End Get
            Set(ByVal Value As Byte)
                _IdGrupo = Value
            End Set
        End Property
#End Region
#Region "Clase Grupo: Métodos públicos"
        Public Function ActualizarDatos(
                                  pClaveCTSE As String, pGrupo As String, pIdSemestre As Short, pPermiteHrsDef As Boolean, _
                                  pPermiteHrsProv As Boolean, pPermiteHrsInt As Boolean, pGrupoProgramaUNA As Boolean, _
                                  pBachGeneral As Boolean, pEMSAD As Boolean, pBachGeneralArte As Boolean, _
                                  pRequiereGrupoDisciplinario As Boolean, pIdGrupoDisciplinario As Byte, _
                                  pRequiereMateriaParaEscolar As Boolean, pIdMateriaParaEscolar As Short, _
                                  pRequiereCapacitacionTrabajo As Boolean, pIdCapacitacion As Byte, _
                                  pGrupoNuevaCreacion As Boolean, pIdQnaIniNuevaCreacion As Short, _
                                  pIdQnaFinNuevaCreacion As Short, pIdTblGrupo As Integer) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCTSE", SqlDbType.NVarChar, 12), _
                                                New SqlParameter("@Grupo", SqlDbType.NVarChar, 3), _
                                                New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                                New SqlParameter("@PermiteHrsDef", SqlDbType.Bit), _
                                                New SqlParameter("@PermiteHrsProv", SqlDbType.Bit), _
                                                New SqlParameter("@PermiteHrsInt", SqlDbType.Bit), _
                                                New SqlParameter("@GrupoProgramaUNA", SqlDbType.Bit), _
                                                New SqlParameter("@BachGeneral", SqlDbType.Bit), _
                                                New SqlParameter("@EMSAD", SqlDbType.Bit), _
                                                New SqlParameter("@BachGeneralArte", SqlDbType.Bit), _
                                                New SqlParameter("@RequiereGrupoDisciplinario", SqlDbType.Bit), _
                                                New SqlParameter("@IdGrupoDisciplinario", SqlDbType.TinyInt), _
                                                New SqlParameter("@RequiereMateriaParaEscolar", SqlDbType.Bit), _
                                                New SqlParameter("@IdMateriaParaEscolar", SqlDbType.SmallInt), _
                                                New SqlParameter("@RequiereCapacitacionTrabajo", SqlDbType.Bit), _
                                                New SqlParameter("@IdCapacitacion", SqlDbType.TinyInt), _
                                                New SqlParameter("@GrupoNuevaCreacion", SqlDbType.Bit), _
                                                New SqlParameter("@IdQnaIniNuevaCreacion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQnaFinNuevaCreacion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdTblGrupo", SqlDbType.Int)
                                             }

                Prms(0).Value = pClaveCTSE
                Prms(1).Value = pGrupo
                Prms(2).Value = pIdSemestre
                Prms(3).Value = pPermiteHrsDef
                Prms(4).Value = pPermiteHrsProv
                Prms(5).Value = pPermiteHrsInt
                Prms(6).Value = pGrupoProgramaUNA
                Prms(7).Value = pBachGeneral
                Prms(8).Value = pEMSAD
                Prms(9).Value = pBachGeneralArte
                Prms(10).Value = pRequiereGrupoDisciplinario
                Prms(11).Value = pIdGrupoDisciplinario
                Prms(12).Value = pRequiereMateriaParaEscolar
                Prms(13).Value = pIdMateriaParaEscolar
                Prms(14).Value = pRequiereCapacitacionTrabajo
                Prms(15).Value = pIdCapacitacion
                Prms(16).Value = pGrupoNuevaCreacion
                Prms(17).Value = pIdQnaIniNuevaCreacion
                Prms(18).Value = pIdQnaFinNuevaCreacion
                Prms(19).Value = pIdTblGrupo

                Return _DataCOBAEV.RunProc("SP_UTblGrupos", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CreaNuevo(pClaveCTSE As String, pGrupo As String, pIdSemestre As Short, pPermiteHrsDef As Boolean, _
                                  pPermiteHrsProv As Boolean, pPermiteHrsInt As Boolean, pGrupoProgramaUNA As Boolean, _
                                  pBachGeneral As Boolean, pEMSAD As Boolean, pBachGeneralArte As Boolean, _
                                  pRequiereGrupoDisciplinario As Boolean, pIdGrupoDisciplinario As Byte, _
                                  pRequiereMateriaParaEscolar As Boolean, pIdMateriaParaEscolar As Short, _
                                  pRequiereCapacitacionTrabajo As Boolean, pIdCapacitacion As Byte, _
                                  pGrupoNuevaCreacion As Boolean, pIdQnaIniNuevaCreacion As Short, _
                                  pIdQnaFinNuevaCreacion As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCTSE", SqlDbType.NVarChar, 12), _
                                                New SqlParameter("@Grupo", SqlDbType.NVarChar, 3), _
                                                New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                                New SqlParameter("@PermiteHrsDef", SqlDbType.Bit), _
                                                New SqlParameter("@PermiteHrsProv", SqlDbType.Bit), _
                                                New SqlParameter("@PermiteHrsInt", SqlDbType.Bit), _
                                                New SqlParameter("@GrupoProgramaUNA", SqlDbType.Bit), _
                                                New SqlParameter("@BachGeneral", SqlDbType.Bit), _
                                                New SqlParameter("@EMSAD", SqlDbType.Bit), _
                                                New SqlParameter("@BachGeneralArte", SqlDbType.Bit), _
                                                New SqlParameter("@RequiereGrupoDisciplinario", SqlDbType.Bit), _
                                                New SqlParameter("@IdGrupoDisciplinario", SqlDbType.TinyInt), _
                                                New SqlParameter("@RequiereMateriaParaEscolar", SqlDbType.Bit), _
                                                New SqlParameter("@IdMateriaParaEscolar", SqlDbType.SmallInt), _
                                                New SqlParameter("@RequiereCapacitacionTrabajo", SqlDbType.Bit), _
                                                New SqlParameter("@IdCapacitacion", SqlDbType.TinyInt), _
                                                New SqlParameter("@GrupoNuevaCreacion", SqlDbType.Bit), _
                                                New SqlParameter("@IdQnaIniNuevaCreacion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQnaFinNuevaCreacion", SqlDbType.SmallInt)
                                              }

                Prms(0).Value = pClaveCTSE
                Prms(1).Value = pGrupo
                Prms(2).Value = pIdSemestre
                Prms(3).Value = pPermiteHrsDef
                Prms(4).Value = pPermiteHrsProv
                Prms(5).Value = pPermiteHrsInt
                Prms(6).Value = pGrupoProgramaUNA
                Prms(7).Value = pBachGeneral
                Prms(8).Value = pEMSAD
                Prms(9).Value = pBachGeneralArte
                Prms(10).Value = pRequiereGrupoDisciplinario
                Prms(11).Value = pIdGrupoDisciplinario
                Prms(12).Value = pRequiereMateriaParaEscolar
                Prms(13).Value = pIdMateriaParaEscolar
                Prms(14).Value = pRequiereCapacitacionTrabajo
                Prms(15).Value = pIdCapacitacion
                Prms(16).Value = pGrupoNuevaCreacion
                Prms(17).Value = pIdQnaIniNuevaCreacion
                Prms(18).Value = pIdQnaFinNuevaCreacion

                Return _DataCOBAEV.RunProc("SP_ITblGrupos", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorIdTblGrupo(pIdTblGrupo As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTblGrupo", SqlDbType.Int)}

                Prms(0).Value = pIdTblGrupo

                Return _DataCOBAEV.RunProc("SP_STblGruposPorId", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdGrupo", SqlDbType.TinyInt)}

                Prms(0).Value = Me._IdGrupo

                Return _DataCOBAEV.RunProc("SP_SGrupos", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SGrupos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorIdSemestre(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_SGrupos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorIdSemestre(ByVal pIdSemestre As Short, ByVal pIdMateria As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMateria", SqlDbType.SmallInt)}

                Prms(0).Value = pIdSemestre
                Prms(1).Value = pIdMateria

                Return _DataCOBAEV.RunProc("SP_SGrupos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenGruposDisciplinarios(pBachGeneral As Boolean, pEMSAD As Boolean, pBachGeneralArte As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@BachGeneral", SqlDbType.Bit), _
                                              New SqlParameter("@EMSAD", SqlDbType.Bit), _
                                              New SqlParameter("@BachGeneralArte", SqlDbType.Bit)}

                Prms(0).Value = pBachGeneral
                Prms(1).Value = pEMSAD
                Prms(2).Value = pBachGeneralArte

                Return _DataCOBAEV.RunProc("SP_STblGruposDisciplinarios", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCapacitaciones(pIdSemestre As Short, pBachGeneral As Boolean, pEMSAD As Boolean, pBachGeneralArte As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                                New SqlParameter("@BachGeneral", SqlDbType.Bit), _
                                                New SqlParameter("@EMSAD", SqlDbType.Bit), _
                                                New SqlParameter("@BachGeneralArte", SqlDbType.Bit)}

                Prms(0).Value = pIdSemestre
                Prms(1).Value = pBachGeneral
                Prms(2).Value = pEMSAD
                Prms(3).Value = pBachGeneralArte

                Return _DataCOBAEV.RunProc("SP_SCapacitaciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
End Namespace