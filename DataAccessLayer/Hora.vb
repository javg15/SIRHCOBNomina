Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.InformacionAcademica
    Public Class Hora
#Region "Propiedades Privadas"
        Private _IdHora, _IdPlaza As Integer
        Private _IdMateria, _IdSemestre, _IdPlantel, _IdQuincenaIni, _IdQuincenaFin As Short
        Private _IdGrupo, _IdTipoHora, _IdNombramiento, _IdTipoNomina, _IdEstatusHora, _Horas, _IdMotivoHoraInterina As Byte
        Private _DataCOBAEV As New DataCOBAEV
        Private _FchIni, _FchFin As DateTime
        Private _RFCEmp As String
        Private _SoloModifQnaFin, _InactivasRenuncia As Boolean
#End Region
#Region "Propiedades Publicas"
        Public Property InactivasRenuncia() As Boolean
            Get
                Return _InactivasRenuncia
            End Get
            Set(ByVal Value As Boolean)
                _InactivasRenuncia = Value
            End Set
        End Property
        Public Property SoloModifQnaFin() As Boolean
            Get
                Return _SoloModifQnaFin
            End Get
            Set(ByVal Value As Boolean)
                _SoloModifQnaFin = Value
            End Set
        End Property
        Public Property IdHora() As Integer
            Get
                Return _IdHora
            End Get
            Set(ByVal Value As Integer)
                _IdHora = Value
            End Set
        End Property
        Public Property IdPlaza() As Integer
            Get
                Return _IdPlaza
            End Get
            Set(ByVal Value As Integer)
                _IdPlaza = Value
            End Set
        End Property
        Public Property IdPlantel() As Short
            Get
                Return _IdPlantel
            End Get
            Set(ByVal Value As Short)
                _IdPlantel = Value
            End Set
        End Property
        Public Property IdMateria() As Short
            Get
                Return _IdMateria
            End Get
            Set(ByVal Value As Short)
                _IdMateria = Value
            End Set
        End Property
        Public Property IdGrupo() As Byte
            Get
                Return _IdGrupo
            End Get
            Set(ByVal Value As Byte)
                _IdGrupo = Value
            End Set
        End Property
        Public Property IdTipoHora() As Byte
            Get
                Return _IdTipoHora
            End Get
            Set(ByVal Value As Byte)
                _IdTipoHora = Value
            End Set
        End Property
        Public Property IdNombramiento() As Byte
            Get
                Return _IdNombramiento
            End Get
            Set(ByVal Value As Byte)
                _IdNombramiento = Value
            End Set
        End Property
        Public Property IdTipoNomina() As Byte
            Get
                Return _IdTipoNomina
            End Get
            Set(ByVal Value As Byte)
                _IdTipoNomina = Value
            End Set
        End Property
        Public Property IdSemestre() As Short
            Get
                Return _IdSemestre
            End Get
            Set(ByVal Value As Short)
                _IdSemestre = Value
            End Set
        End Property
        Public Property IdEstatusHora() As Byte
            Get
                Return _IdEstatusHora
            End Get
            Set(ByVal Value As Byte)
                _IdEstatusHora = Value
            End Set
        End Property
        Public Property Horas() As Byte
            Get
                Return Me._Horas
            End Get
            Set(ByVal Value As Byte)
                Me._Horas = Value
            End Set
        End Property
        Public Property IdQuincenaIni() As Short
            Get
                Return _IdQuincenaIni
            End Get
            Set(ByVal Value As Short)
                _IdQuincenaIni = Value
            End Set
        End Property
        Public Property IdQuincenaFin() As Short
            Get
                Return _IdQuincenaFin
            End Get
            Set(ByVal Value As Short)
                _IdQuincenaFin = Value
            End Set
        End Property
        Public Property FchIni() As Date
            Get
                Return Me._FchIni
            End Get
            Set(ByVal Value As Date)
                Me._FchIni = Value
            End Set
        End Property
        Public Property FchFin() As Date
            Get
                Return Me._FchFin
            End Get
            Set(ByVal Value As Date)
                Me._FchFin = Value
            End Set
        End Property
        Public Property IdMotivoHoraInterina() As Byte
            Get
                Return Me._IdMotivoHoraInterina
            End Get
            Set(ByVal Value As Byte)
                Me._IdMotivoHoraInterina = Value
            End Set
        End Property
        Public Property RFCEmp() As String
            Get
                Return Me._RFCEmp
            End Get
            Set(ByVal Value As String)
                Me._RFCEmp = Value
            End Set
        End Property
#End Region
#Region "Métodos Públicos"
        Public Function ObtenTitular(pIdHora As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int)}

                Prms(0).Value = pIdHora

                Return _DataCOBAEV.RunProc("SP_STitularDeHora", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodasLasObservaciones(pdtUsr As DataTable) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                              New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                              New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}

                Prms(0).Value = pdtUsr.Rows(0).Item("IdRol")
                Prms(1).Value = pdtUsr.Rows(0).Item("ConsultaZonasEspecificas")
                Prms(2).Value = pdtUsr.Rows(0).Item("ConsultaPlantelesEspecificos")
                Prms(3).Value = pdtUsr.Rows(0).Item("IdUsuario")

                Return _DataCOBAEV.RunProc("SP_SDetectaObservsSobreCargaHoraria", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenObservacionesSobreCargaHoraria(ByVal pRFCEmp As String, ByVal pIdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                              New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}
                Dim dtWarnings As DataTable

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdSemestre

                dtWarnings = _DataCOBAEV.RunProc("SP_SObservSobreCargaHoraria", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                dtWarnings = IIf(dtWarnings.Rows.Count = 0, New DataTable, dtWarnings)

                Return dtWarnings
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenGrupoParaOP(ByVal pIdHora As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int)}

                Prms(0).Value = pIdHora

                Return _DataCOBAEV.RunProc("SP_SHorasParaOP", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsInterina() As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdNombramiento", SqlDbType.TinyInt)}

                Prms(0).Value = Me._IdNombramiento

                Return _DataCOBAEV.RunProc("SP_VSiNombramientoEsInterino", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMotivosInterinatos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SMotivosHorasInterinas", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNombramientoPorAbrev(pAbrevNombramiento As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@AbrevNombramiento", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pAbrevNombramiento

                Return _DataCOBAEV.RunProc("SP_SNombramientos", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNombramientosPorId() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdNombramiento", SqlDbType.TinyInt)}

                Prms(0).Value = Me._IdNombramiento

                Return _DataCOBAEV.RunProc("SP_SNombramientos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNombramientos(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                If ParaDDL Then
                    Prms(0).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_SNombramientos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_SNombramientos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEstatusPorAbrev(pAbrevEstatus As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@AbrevEstatus", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pAbrevEstatus

                Return _DataCOBAEV.RunProc("SP_SEstatusHoras", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEstatusPorId() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEstatusHora", SqlDbType.TinyInt)}

                Prms(0).Value = Me._IdEstatusHora

                Return _DataCOBAEV.RunProc("SP_SEstatusHoras", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEstatus(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                If ParaDDL Then
                    Prms(0).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_SEstatusHoras", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_SEstatusHoras", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorTipoHora(pTipoHora As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@TipoHora", SqlDbType.NVarChar, 1)}

                Prms(0).Value = pTipoHora

                Return _DataCOBAEV.RunProc("SP_STiposDeHoraDocentes", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTiposPorId() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTipoHora", SqlDbType.TinyInt)}

                Prms(0).Value = Me._IdTipoHora

                Return _DataCOBAEV.RunProc("SP_STiposDeHoraDocentes", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTipos(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                If ParaDDL Then
                    Prms(0).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_STiposDeHoraDocentes", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_STiposDeHoraDocentes", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTiposPorMateria(ByVal IdMateria As Short, Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@IdMateria", SqlDbType.SmallInt), _
                                                New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                If ParaDDL Then
                    Prms(0).Value = IdMateria
                    Prms(1).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_STiposDeHoraDocentesPorMateria", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                Else
                    Prms(0).Value = IdMateria
                    Prms(1).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_STiposDeHoraDocentesPorMateria", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(Optional ByVal Interina As Boolean = False) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int), _
                                            New SqlParameter("@Interina", SqlDbType.Bit)}

                Prms(0).Value = _IdHora
                Prms(1).Value = Interina

                Return _DataCOBAEV.RunProc("SP_SHorasPorId", Prms, "dsHoras", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function SePuedeModificar() As Boolean
            Try
                Dim dr As DataRow
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int)}

                Prms(0).Value = _IdHora

                dr = _DataCOBAEV.RunProc("SP_VHoraSePuedeModificar", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("Result"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function SePuedeLimitarAuto(pIdHora As Integer, pIdSemestre As Short) As Boolean
            Try
                Dim dr As DataRow
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int), _
                                              New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = pIdHora
                Prms(1).Value = pIdSemestre

                dr = _DataCOBAEV.RunProc("SP_VSiHoraSePuedeLimitarAuto", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("Result"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function SePuedeEliminar(ByVal pIdHora As Integer) As Boolean
            Try
                Dim dr As DataRow
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int)}

                Prms(0).Value = pIdHora

                dr = _DataCOBAEV.RunProc("SP_VSiHoraSePuedeEliminar", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("HoraSePuedeEliminar"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function SePuedeModificar(ByVal pIdHora As Integer, Optional ByVal pIdSemestre As Short = 0) As Boolean
            Try
                Dim dr As DataRow
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int),
                                              New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = pIdHora
                Prms(1).Value = IIf(pIdSemestre = 0, DBNull.Value, pIdSemestre)

                dr = _DataCOBAEV.RunProc("SP_VSiHoraSePuedeModificar", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("HoraSePuedeModificar"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EstaVigente(ByVal pIdHora As Integer) As Boolean
            Try
                Dim dr As DataRow
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int)}

                Prms(0).Value = pIdHora

                dr = _DataCOBAEV.RunProc("SP_VSiHoraEstaVigente", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("HoraVigente"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualizar(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String, Optional ByVal AsociarInterinas As Boolean = False) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                                            New SqlParameter("@IdPlaza", SqlDbType.Int),
                                            New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                                            New SqlParameter("@IdMateria", SqlDbType.SmallInt),
                                            New SqlParameter("@IdGrupo", SqlDbType.TinyInt),
                                            New SqlParameter("@IdTipoHora", SqlDbType.TinyInt),
                                            New SqlParameter("@IdNombramiento", SqlDbType.TinyInt),
                                            New SqlParameter("@IdTipoNomina", SqlDbType.TinyInt),
                                            New SqlParameter("@IdSemestre", SqlDbType.SmallInt),
                                            New SqlParameter("@IdEstatusHora", SqlDbType.TinyInt),
                                            New SqlParameter("@Horas", SqlDbType.TinyInt),
                                            New SqlParameter("@IdQuincenaIni", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQuincenaFin", SqlDbType.SmallInt),
                                            New SqlParameter("@FchIni", SqlDbType.DateTime),
                                            New SqlParameter("@FchFin", SqlDbType.DateTime),
                                            New SqlParameter("@AsociarInterinas", SqlDbType.Bit),
                                            New SqlParameter("@IdMotivoHoraInterina", SqlDbType.TinyInt),
                                            New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@SoloModifQnaFin", SqlDbType.Bit),
                                            New SqlParameter("@InactivasRenuncia", SqlDbType.Bit)}
                Prms(0).Value = _IdHora
                Prms(1).Value = TipoOperacion
                Prms(2).Value = _IdPlaza
                Prms(3).Value = Me._IdPlantel
                Prms(4).Value = _IdMateria
                Prms(5).Value = _IdGrupo
                Prms(6).Value = _IdTipoHora
                Prms(7).Value = _IdNombramiento
                Prms(8).Value = _IdTipoNomina
                Prms(9).Value = _IdSemestre
                Prms(10).Value = _IdEstatusHora
                If Me._Horas = 0 Then
                    Prms(11).Value = DBNull.Value
                Else
                    Prms(11).Value = Me._Horas
                End If
                Prms(12).Value = Me._IdQuincenaIni
                Prms(13).Value = Me._IdQuincenaFin
                Prms(14).Value = Me._FchIni
                Prms(15).Value = Me._FchFin
                Prms(16).Value = AsociarInterinas
                Prms(17).Value = Me.IdMotivoHoraInterina
                Prms(18).Value = Me._RFCEmp
                Prms(19).Value = Me._SoloModifQnaFin
                Prms(20).Value = Me._InactivasRenuncia
                Return _DataCOBAEV.RunProc("SP_IoUHoras", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizarInterinas(ByVal ArregloAuditoria() As String) As Boolean
            Return Actualizar(0, ArregloAuditoria, True)
        End Function
        Public Function Insertar(ByVal ArregloAuditoria() As String) As Boolean
            Return Actualizar(1, ArregloAuditoria)
        End Function
        Public Function InsertarInterinas(ByVal ArregloAuditoria() As String) As Boolean
            Return Actualizar(1, ArregloAuditoria, True)
        End Function
        Public Function EliminaPorId(ByVal ArregloAuditoria() As String, Optional ByVal EsInterina As Boolean = False) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int), _
                                            New SqlParameter("@EsInterina", SqlDbType.Bit)}

                Prms(0).Value = _IdHora
                Prms(1).Value = EsInterina

                Return _DataCOBAEV.RunProc("SP_DHorasPorId", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
End Namespace
