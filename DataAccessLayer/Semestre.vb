Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.InformacionAcademica
    Public Class Semestre
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdSemestre As Short
        Public Function ObtenTipos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SSemestresTipos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Property IdSemestre() As Short
            Get
                Return _IdSemestre
            End Get
            Set(ByVal Value As Short)
                _IdSemestre = Value
            End Set
        End Property
        Public Function ExisteParaCapturaDePlantillas() As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ExisteParaCapturaDePlantillas", SqlDbType.Bit)}

                Prms(0).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_VSiExisteSemParaCapturaDePlantillas", Prms, DataCOBAEV.BD.Nomina)

                Return CBool(Prms(0).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsParaCapturaDePlantillas(ByVal IdSemestre As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                            New SqlParameter("@EsParaCapturaDePlantillas", SqlDbType.Bit)}

                Prms(0).Value = IdSemestre
                Prms(1).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_VSiSemestreEsParaCapturaDePlantillas", Prms, DataCOBAEV.BD.Nomina)

                Return CBool(Prms(1).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsActual(ByVal IdSemestre As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                            New SqlParameter("@EsSemestreActual", SqlDbType.Bit)}

                Prms(0).Value = IdSemestre
                Prms(1).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_VSiSemestreEsActual", Prms, DataCOBAEV.BD.Nomina)

                Return CBool(Prms(1).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CreaNuevo(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Return _DataCOBAEV.RunProc("SP_ISemestres", DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaInf(ByVal IdSemestre As Short, ByVal Actual As Boolean, ByVal IdQuincenaIni As Short, ByVal IdQuincenaFin As Short, _
        ByVal IdQuincenaFinInterinas As Short, ByVal PermiteModificacion As Boolean, ByVal PermiteCargaDePlantillas As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                            New SqlParameter("@Actual", SqlDbType.Bit), _
                                            New SqlParameter("@IdQuincenaIni", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQuincenaFin", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQuincenaFinInterinas", SqlDbType.SmallInt), _
                                            New SqlParameter("@PermiteModificacion", SqlDbType.Bit), _
                                            New SqlParameter("@PermiteCargaDePlantillas", SqlDbType.Bit)}

                Prms(0).Value = IdSemestre
                Prms(1).Value = Actual
                Prms(2).Value = IdQuincenaIni
                Prms(3).Value = IdQuincenaFin
                Prms(4).Value = IdQuincenaFinInterinas
                Prms(5).Value = PermiteModificacion
                Prms(6).Value = PermiteCargaDePlantillas

                _DataCOBAEV.RunProc("SP_USemestres", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Return CBool(Prms(0).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SSemestres2", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasFin(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_SSemestresQnasFin", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasIni(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_SSemestresQnasIni", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_SSemestres2", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = Me._IdSemestre

                Return _DataCOBAEV.RunProc("SP_SSemestres", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSemestres() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SSemestres", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAnios() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SAnios", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenActual(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit), _
                                                New SqlParameter("@SemestreActual", SqlDbType.Bit)}
                Prms(0).Value = ParaDDL
                Prms(1).Value = True
                Return _DataCOBAEV.RunProc("SP_SSemestres", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AdmiteModificaciones() As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                            New SqlParameter("@Resultado", SqlDbType.Bit)}

                Prms(0).Value = Me._IdSemestre
                Prms(1).Direction = ParameterDirection.Output
                _DataCOBAEV.RunProc("SP_SSemestreSePuedeModificar", Prms, DataCOBAEV.BD.Nomina)
                Return Prms(1).Value

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenUltDeUnTipo(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_SUltSemestreDeUnTipo", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
    End Class
End Namespace
