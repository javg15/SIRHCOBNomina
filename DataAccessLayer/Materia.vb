Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.InformacionAcademica
    Public Class Materia
        Private _IdMateria As Integer
        Private _DataCOBAEV As New DataCOBAEV
        Public Property IdMateria() As Short
            Get
                Return _IdMateria
            End Get
            Set(ByVal Value As Short)
                _IdMateria = Value
            End Set
        End Property
        Public Function ObtenHoras() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdMateria", SqlDbType.Int)}

                Prms(0).Value = _IdMateria

                Return _DataCOBAEV.RunProc("SP_SHorasPorMateria", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(pIdMateria As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdMateria", SqlDbType.SmallInt)}

                Prms(0).Value = pIdMateria

                Return _DataCOBAEV.RunProc("SP_SMaterias", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodas(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                If ParaDDL Then
                    Prms(0).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_SMaterias", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_SMaterias", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorSemestre(ByVal pIdSemestre As Short, Optional ByVal ParaDDL As Boolean = False, Optional ByVal pIdMateria As Short = -1, Optional pIdPlantel As Short = -1) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                                New SqlParameter("@ParaDDL", SqlDbType.Bit), _
                                                New SqlParameter("@IdMateria", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPlantel", SqlDbType.SmallInt)}

                Prms(0).Value = pIdSemestre
                Prms(2).Value = IIf(pIdMateria <> -1, pIdMateria, DBNull.Value)
                Prms(3).Value = IIf(pIdPlantel <> -1, pIdPlantel, DBNull.Value)
                If ParaDDL Then
                    Prms(1).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_SMateriasPorSemestre", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_SMateriasPorSemestre", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenActividadesParaEscolares(pSemestre As Byte, pParaNuevoGrupo As Boolean, Optional pMateriasUNA As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Semestre", SqlDbType.TinyInt), _
                                              New SqlParameter("@ParaNuevoGrupo", SqlDbType.Bit), _
                                              New SqlParameter("@MateriasUNA", SqlDbType.Bit)}


                Prms(0).Value = pSemestre
                Prms(1).Value = pParaNuevoGrupo
                Prms(2).Value = pMateriasUNA

                Return _DataCOBAEV.RunProc("SP_SMateriasParaEscolares", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
    End Class
End Namespace