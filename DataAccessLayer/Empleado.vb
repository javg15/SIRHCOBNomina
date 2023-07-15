Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV.Empleados
#Region "Clase EmpleadosConReduccionDeSueldo"
    Public Class EmpleadosConReduccionDeSueldo
#Region "Clase EmpleadosConReduccionDeSueldo: Propiedades públicas"
        Public Property IdReduccion() As Byte
            Get
                Return _IdReduccion
            End Get
            Set(ByVal Value As Byte)
                _IdReduccion = Value
            End Set
        End Property
        Public Property IdEmp() As Integer
            Get
                Return _IdEmp
            End Get
            Set(ByVal Value As Integer)
                _IdEmp = Value
            End Set
        End Property
        Public Property IdQnaIni() As Integer
            Get
                Return _IdQnaIni
            End Get
            Set(ByVal Value As Integer)
                _IdQnaIni = Value
            End Set
        End Property
        Public Property IdQnaFin() As Integer
            Get
                Return _IdQnaFin
            End Get
            Set(ByVal Value As Integer)
                _IdQnaFin = Value
            End Set
        End Property

        Public Property PorcDesc() As Decimal
            Get
                Return _PorcDesc
            End Get
            Set(ByVal Value As Decimal)
                _PorcDesc = Value
            End Set
        End Property

#End Region
#Region "Clase EmpleadosConReduccionDeSueldo: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdEmp, _IdReduccion As Integer
        Private _PorcDesc As Decimal
        Private _IdQnaIni, _IdQnaFin As Integer
#End Region
#Region "Clase EmpleadosConReduccionDeSueldo: Métodos públicos"

        Public Function ObtenReducciones(ByVal parametros As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@parametros", SqlDbType.NVarChar)}

                Prms(0).Value = parametros

                Return _DataCOBAEV.RunProc("SP_SEmpsConReduccionDeSdo", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function AgregaNueva(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As String
            Try
                Dim Prms As SqlParameter() = {
                            New SqlParameter("@IdReduccion", SqlDbType.Int),
                            New SqlParameter("@IdEmp", SqlDbType.Int),
                            New SqlParameter("@PorcDesc", SqlDbType.Decimal),
                            New SqlParameter("@IdQnaIni", SqlDbType.Int),
                            New SqlParameter("@IdQnaFin", SqlDbType.Int),
                            New SqlParameter("@error", SqlDbType.NVarChar, 200)
                            }

                If TipoOperacion = 1 Then
                    Prms(0).Value = 0
                Else
                    Prms(0).Value = IdReduccion
                End If
                Prms(0).Direction = ParameterDirection.InputOutput
                Prms(1).Value = Me._IdEmp
                Prms(2).Value = Me._PorcDesc
                Prms(3).Value = Me._IdQnaIni
                Prms(4).Value = Me._IdQnaFin
                Prms(5).Value = ""
                Prms(5).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_IoUEmpleadosConReduccionDeSueldo", Prms, Nomina, ArregloAuditoria)

                Return Prms(0).Value & "&" & Prms(5).Value 'Retornamos IdReduccion & posible error
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualizar(ByVal QnaVigIni As Integer, ByVal QnaVigFin As Integer, ByVal ArregloAuditoria() As String) As Integer
            Return AgregaNueva(0, ArregloAuditoria)
        End Function
#End Region
    End Class
#End Region
#Region "Clase EmpleadoPlazas"
    Public Class EmpleadoPlazas
#Region "Clase EmpleadoPlazas: Propiedades públicas"
        Public Property NuevoIngreso() As Integer
            Get
                Return _NuevoIngreso
            End Get
            Set(ByVal Value As Integer)
                _NuevoIngreso = Value
            End Set
        End Property
        Public Property IdEsquemaPago() As Byte
            Get
                Return _IdEsquemaPago
            End Get
            Set(ByVal Value As Byte)
                _IdEsquemaPago = Value
            End Set
        End Property
        Public Property FechaInicio() As String
            Get
                Return _FechaInicio
            End Get
            Set(ByVal value As String)
                _FechaInicio = value
            End Set
        End Property
        Public Property FechaFin() As String
            Get
                Return _FechaFin
            End Get
            Set(ByVal value As String)
                _FechaFin = value
            End Set
        End Property
        Public Property FechaFinLSGS() As String
            Get
                Return _FechaFinLSGS
            End Get
            Set(ByVal value As String)
                _FechaFinLSGS = value
            End Set
        End Property
        Public Property IdTipoSemestre() As Byte
            Get
                Return Me._IdTipoSemestre
            End Get
            Set(ByVal value As Byte)
                Me._IdTipoSemestre = value
            End Set
        End Property
        Public Property IdMotGralBaja() As Byte
            Get
                Return Me._IdMotGralBaja
            End Get
            Set(ByVal value As Byte)
                Me._IdMotGralBaja = value
            End Set
        End Property
        Public Property IdFuncionPri() As Short
            Get
                Return _IdFuncionPri
            End Get
            Set(ByVal Value As Short)
                _IdFuncionPri = Value
            End Set
        End Property
        Public Property IdFuncionSec() As Byte
            Get
                Return _IdFuncionSec
            End Get
            Set(ByVal Value As Byte)
                _IdFuncionSec = Value
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
        Public Property IdEmp() As Integer
            Get
                Return _IdEmp
            End Get
            Set(ByVal Value As Integer)
                _IdEmp = Value
            End Set
        End Property
        Public Property IdEmpFuncion() As Byte
            Get
                Return _IdEmpFuncion
            End Get
            Set(ByVal Value As Byte)
                _IdEmpFuncion = Value
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
        Public Property IdPlantelAdscripReal() As Short
            Get
                Return _IdPlantelAdscripReal
            End Get
            Set(ByVal Value As Short)
                _IdPlantelAdscripReal = Value
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
        Public Property IdCT() As Short
            Get
                Return _IdCT
            End Get
            Set(ByVal Value As Short)
                _IdCT = Value
            End Set
        End Property
        Public Property IdCategoria() As Short
            Get
                Return _IdCategoria
            End Get
            Set(ByVal Value As Short)
                _IdCategoria = Value
            End Set
        End Property
        Public Property IdSindicato() As Byte
            Get
                Return _IdSindicato
            End Get
            Set(ByVal Value As Byte)
                _IdSindicato = Value
            End Set
        End Property
        Public Property IdPlazaTipoOcupacion() As Byte
            Get
                Return _IdPlazaTipoOcupacion
            End Get
            Set(ByVal Value As Byte)
                _IdPlazaTipoOcupacion = Value
            End Set
        End Property
        Public Property IdMotivoInterinato() As Byte
            Get
                Return Me._IdMotivoInterinato
            End Get
            Set(ByVal Value As Byte)
                Me._IdMotivoInterinato = Value
            End Set
        End Property
        Public Property RFCEmpTitular() As String
            Get
                Return Me._RFCEmpTitular
            End Get
            Set(ByVal Value As String)
                Me._RFCEmpTitular = Value
            End Set
        End Property
        Public Property TratarComoBase() As Boolean
            Get
                Return Me._TratarComoBase
            End Get
            Set(ByVal Value As Boolean)
                Me._TratarComoBase = Value
            End Set
        End Property
        Public Property InterinoPuro() As Boolean
            Get
                Return Me._InterinoPuro
            End Get
            Set(ByVal Value As Boolean)
                Me._InterinoPuro = Value
            End Set
        End Property
        Public Property FechaAlta() As Date
            Get
                Return Me._FechaAlta
            End Get
            Set(ByVal Value As Date)
                Me._FechaAlta = Value
            End Set
        End Property
        Public Property FechaBaja() As Date
            Get
                Return Me._FechaBaja
            End Get
            Set(ByVal Value As Date)
                Me._FechaBaja = Value
            End Set
        End Property
        Public Property IdPuesto() As Short
            Get
                Return Me._IdPuesto
            End Get
            Set(ByVal Value As Short)
                Me._IdPuesto = Value
            End Set
        End Property

#End Region
#Region "Clase EmpleadoPlazas: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdEmp, _IdPlaza As Integer
        Private _IdEmpFuncion, _IdTipoNomina, _IdSindicato, _IdPlazaTipoOcupacion, _IdMotivoInterinato, _IdFuncionSec, _IdMotGralBaja As Byte
        Private _IdPlantel, _IdCT, _IdCategoria, _IdFuncionPri As Short
        Private _RFCEmpTitular As String
        Private _TratarComoBase, _InterinoPuro As Boolean
        Private _IdTipoSemestre, _IdEsquemaPago As Byte
        Private _FechaAlta, _FechaBaja As Date
        Private _FechaInicio, _FechaFin, _FechaFinLSGS As String
        Private _IdPlantelAdscripReal As Short
        Private _IdPuesto As Short
        Private _NuevoIngreso As Integer
#End Region
#Region "Clase EmpleadoPlazas: Métodos públicos"
        Public Function ObtenInfDeTblPlazasHistoria(ByVal pIdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = pIdPlaza

                Return _DataCOBAEV.RunProc("SP_SPlazasHistoria", Prms, DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObservsPlaza(ByVal pIdPlaza As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}
                Prms(0).Value = pIdPlaza

                Return _DataCOBAEV.RunProc("SP_SObservsPlaza", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function SeLePudenAgregarMasPlazas(ByVal pRFCEmp As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Dim dr As DataRow

                Prms(0).Value = pRFCEmp

                dr = _DataCOBAEV.RunProc("SP_VSiSePuedeAgregarMasPlazasAlEmp", Prms, DataRow, Nomina)

                Return (CBool(dr("Result")))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function TienePagosRelacionados(ByVal pIdPlaza As Integer) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}
                Dim dr As DataRow

                Prms(0).Value = pIdPlaza

                dr = _DataCOBAEV.RunProc("SP_ValidaSiPlazaTienePagosRegistrados", Prms, DataRow, Nomina)

                Return (CBool(dr("Result")))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodasLasObservaciones(pdtUsr As DataTable) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt),
                                              New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit),
                                              New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit),
                                              New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}

                Prms(0).Value = pdtUsr.Rows(0).Item("IdRol")
                Prms(1).Value = pdtUsr.Rows(0).Item("ConsultaZonasEspecificas")
                Prms(2).Value = pdtUsr.Rows(0).Item("ConsultaPlantelesEspecificos")
                Prms(3).Value = pdtUsr.Rows(0).Item("IdUsuario")

                Return _DataCOBAEV.RunProc("SP_SDetectaObservsSobrePlazas", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenObservaciones(ByVal pIdPlaza As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}
                Dim dtWarnings As DataTable

                Prms(0).Value = pIdPlaza

                dtWarnings = _DataCOBAEV.RunProc("SP_SObservacionesSobrePlazas", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
                dtWarnings = IIf(dtWarnings.Rows.Count = 0, New DataTable, dtWarnings)

                Return dtWarnings
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function TienePagosAPartirDeQna(ByVal IdQuincena As Short, ByVal TipoOperacion As Byte) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.SmallInt),
                                                New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = Me._IdPlaza
                Prms(1).Value = TipoOperacion
                Prms(2).Value = IdQuincena
                Return CBool(_DataCOBAEV.RunProc("SP_ValidaSiPlzTienePagosAPartirDeUnaQna", Prms, "PlzTienePagosAPartirDeUnaQna", Nomina).Tables(0).Rows(0).Item(0))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMotivoGeneralDeBajaDefault(ByVal IdQuincena As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SMotivoGralBajaDefaultDadaUnaQna", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMotivoGeneralDeBaja(ByVal IdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = IdPlaza

                Return _DataCOBAEV.RunProc("SP_SPlazasMotivosDeBaja", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFechaLSGS(ByVal IdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = IdPlaza

                Return _DataCOBAEV.RunProc("SP_SPlazasFechaLSGS", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPuestoSEFIPLAN(ByVal IdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = IdPlaza

                Return _DataCOBAEV.RunProc("SP_SPlazasPuestoSefiplan", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSiPlazaSeraTratadaComoBase(ByVal IdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = IdPlaza

                Return _DataCOBAEV.RunProc("SP_SPlazaTratadaComoBase", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDatosComplementarios(ByVal IdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = IdPlaza

                Return _DataCOBAEV.RunProc("SP_SEmpsPlazasDatosComplem", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFuncionesPri_Y_Sec(ByVal IdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = IdPlaza

                Return _DataCOBAEV.RunProc("SP_SFuncPri_Y_SecPorIdPlaza", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTitular() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = Me._IdPlaza

                Return _DataCOBAEV.RunProc("SP_STitularDePlaza", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal pIdPlaza As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = pIdPlaza

                Return _DataCOBAEV.RunProc("SP_SBuscaPlazaPorId", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@Quincena", SqlDbType.Int),
                                                New SqlParameter("@IdPlaza", SqlDbType.Int)}
                Prms(0).Value = DBNull.Value
                Prms(1).Value = DBNull.Value
                Prms(2).Value = Me._IdPlaza
                Return _DataCOBAEV.RunProc("SP_SEmpleadosPlazas", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenPorIdConOcup() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@Quincena", SqlDbType.Int),
                                                New SqlParameter("@IdPlaza", SqlDbType.Int)}
                Prms(0).Value = DBNull.Value
                Prms(1).Value = DBNull.Value
                Prms(2).Value = Me._IdPlaza
                Return _DataCOBAEV.RunProc("SP_SEmpleadosPlazasConOcup", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenUltimaOcupada(ByVal RFC As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = RFC
                Return _DataCOBAEV.RunProc("SP_SEmpleadosPlazasUltVig", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraBaja(ByVal IdQnaVigIni As Short, ByVal IdQnaVigFin As Short, ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int),
                            New SqlParameter("@IdQnaVigIni", SqlDbType.SmallInt),
                            New SqlParameter("@IdQnaVigFin", SqlDbType.SmallInt),
                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                            New SqlParameter("@IdMotGralBaja", SqlDbType.TinyInt),
                            New SqlParameter("@FechaInicio", SqlDbType.DateTime),
                            New SqlParameter("@FechaFin", SqlDbType.DateTime),
                            New SqlParameter("@FechaFinLSGS", SqlDbType.DateTime)}

                Prms(0).Value = _IdPlaza
                Prms(1).Value = IdQnaVigIni
                Prms(2).Value = IdQnaVigFin
                Prms(3).Value = TipoOperacion
                Prms(4).Value = _IdMotGralBaja
                If _FechaInicio = String.Empty Then
                    Prms(5).Value = DBNull.Value
                Else
                    Prms(5).Value = CDate(_FechaInicio)
                End If
                'Prms(5).Value = IIf(_FechaInicio = String.Empty, DBNull.Value, CDate(_FechaInicio))
                If _FechaFin = String.Empty Then
                    Prms(6).Value = DBNull.Value
                Else
                    Prms(6).Value = CDate(_FechaFin)
                End If
                'Prms(6).Value = IIf(_FechaFin = String.Empty, DBNull.Value, CDate(_FechaFin))
                If _FechaFinLSGS = String.Empty Then
                    Prms(7).Value = DBNull.Value
                Else
                    Prms(7).Value = CDate(_FechaFinLSGS)
                End If

                Return _DataCOBAEV.RunProc("SP_IoUPlazasHistoria", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AgregaNueva(ByVal RFCEmp As String, ByVal QnaVigIni As Short, ByVal QnaVigFin As Short, ByVal IdPlazaOcup As Integer, ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Integer
            Try
                Dim Prms As SqlParameter() = {
                            New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                            New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt),
                            New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                            New SqlParameter("@IdTipoNomina", SqlDbType.TinyInt),
                            New SqlParameter("@IdCT", SqlDbType.SmallInt),
                            New SqlParameter("@IdCategoria", SqlDbType.SmallInt),
                            New SqlParameter("@IdSindicato", SqlDbType.TinyInt),
                            New SqlParameter("@IdPlazaTipoOcupacion", SqlDbType.TinyInt),
                            New SqlParameter("@IdQnaVigIni", SqlDbType.SmallInt),
                            New SqlParameter("@IdQnaVigFin", SqlDbType.SmallInt),
                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                            New SqlParameter("@IdPlaza", SqlDbType.Int),
                            New SqlParameter("@IdMotivoInterinato", SqlDbType.TinyInt),
                            New SqlParameter("@RFCEmpTitular", SqlDbType.NVarChar, 13),
                            New SqlParameter("@IdFuncionPri", SqlDbType.SmallInt),
                            New SqlParameter("@IdFuncionSec", SqlDbType.TinyInt),
                            New SqlParameter("@IdMotGralBaja", SqlDbType.TinyInt),
                            New SqlParameter("@TratarComoBase", SqlDbType.Bit),
                            New SqlParameter("@IdPlazaCreada", SqlDbType.Int),
                            New SqlParameter("@IdTipoSemestre", SqlDbType.TinyInt),
                            New SqlParameter("@InterinoPuro", SqlDbType.Bit),
                            New SqlParameter("@FechaInicio", SqlDbType.DateTime),
                            New SqlParameter("@FechaFin", SqlDbType.DateTime),
                            New SqlParameter("@IdPlantelAdscripReal", SqlDbType.SmallInt),
                            New SqlParameter("@IdEsquemaPago", SqlDbType.TinyInt),
                            New SqlParameter("@IdPuesto", SqlDbType.SmallInt),
                            New SqlParameter("@FechaFinLSGS", SqlDbType.DateTime),
                            New SqlParameter("@IdPlazaOcup", SqlDbType.Int),
                            New SqlParameter("@NuevoIngreso", SqlDbType.Int)
                            }


                If TipoOperacion = 0 Then
                    Prms(0).Value = DBNull.Value
                Else
                    Prms(0).Value = RFCEmp
                End If
                Prms(1).Value = Me._IdEmpFuncion
                Prms(2).Value = Me._IdPlantel
                Prms(3).Value = Me._IdTipoNomina
                Prms(4).Value = Me._IdCT
                Prms(5).Value = Me._IdCategoria
                Prms(6).Value = Me._IdSindicato
                Prms(7).Value = Me._IdPlazaTipoOcupacion
                Prms(8).Value = QnaVigIni
                Prms(9).Value = QnaVigFin
                Prms(10).Value = TipoOperacion
                If TipoOperacion = 0 Then
                    Prms(11).Value = Me._IdPlaza
                Else
                    Prms(11).Value = DBNull.Value
                End If
                Prms(12).Value = Me._IdMotivoInterinato
                If Me._RFCEmpTitular.Trim <> String.Empty Then
                    Prms(13).Value = Me._RFCEmpTitular
                Else
                    Prms(13).Value = DBNull.Value
                End If
                Prms(14).Value = Me._IdFuncionPri
                Prms(15).Value = Me._IdFuncionSec
                Prms(16).Value = Me._IdMotGralBaja
                Prms(17).Value = Me._TratarComoBase
                Prms(18).Direction = ParameterDirection.Output
                Prms(19).Value = Me._IdTipoSemestre
                Prms(20).Value = Me._InterinoPuro
                If _FechaInicio = String.Empty Then
                    Prms(21).Value = DBNull.Value
                Else
                    Prms(21).Value = CDate(_FechaInicio)
                End If
                'Prms(5).Value = IIf(_FechaInicio = String.Empty, DBNull.Value, CDate(_FechaInicio))
                If _FechaFin = String.Empty Then
                    Prms(22).Value = DBNull.Value
                Else
                    Prms(22).Value = CDate(_FechaFin)
                End If
                Prms(23).Value = _IdPlantelAdscripReal
                Prms(24).Value = _IdEsquemaPago
                'Prms(21).Value = IIf(_FechaInicio = String.Empty, DBNull.Value, CDate(_FechaInicio))
                'Prms(22).Value = IIf(_FechaFin = String.Empty, DBNull.Value, CDate(_FechaFin))
                Prms(25).Value = Me._IdPuesto
                If _FechaFinLSGS = String.Empty Then
                    Prms(26).Value = DBNull.Value
                Else
                    Prms(26).Value = CDate(_FechaFinLSGS)
                End If

                Prms(27).Value = IdPlazaOcup
                Prms(28).Value = Me._NuevoIngreso

                _DataCOBAEV.RunProc("SP_IoUEmpleadosPlazas", Prms, Nomina, ArregloAuditoria)

                Return CInt(Prms(18).Value) 'Retornamos el IdPlaza creado
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualizar(ByVal QnaVigIni As Integer, ByVal QnaVigFin As Integer, ByVal IdPlazaOcup As Integer, ByVal ArregloAuditoria() As String) As Integer
            Return AgregaNueva(String.Empty, QnaVigIni, QnaVigFin, IdPlazaOcup, 0, ArregloAuditoria)
        End Function
        Public Function Actualizar2(ByVal QnaVigIni As Integer, ByVal QnaVigFin As Integer, ByVal ArregloAuditoria() As String) As Integer
            Return AgregaNueva2(String.Empty, QnaVigIni, QnaVigFin, 0, ArregloAuditoria)
        End Function
        Public Function AgregaNueva2(ByVal RFCEmp As String, ByVal QnaVigIni As Short, ByVal QnaVigFin As Short, ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Integer
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                            New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt),
                            New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                            New SqlParameter("@IdTipoNomina", SqlDbType.TinyInt),
                            New SqlParameter("@IdCT", SqlDbType.SmallInt),
                            New SqlParameter("@IdCategoria", SqlDbType.SmallInt),
                            New SqlParameter("@IdSindicato", SqlDbType.TinyInt),
                            New SqlParameter("@IdPlazaTipoOcupacion", SqlDbType.TinyInt),
                            New SqlParameter("@IdQnaVigIni", SqlDbType.SmallInt),
                            New SqlParameter("@IdQnaVigFin", SqlDbType.SmallInt),
                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                            New SqlParameter("@IdPlaza", SqlDbType.Int),
                            New SqlParameter("@IdMotivoInterinato", SqlDbType.TinyInt),
                            New SqlParameter("@RFCEmpTitular", SqlDbType.NVarChar, 13),
                            New SqlParameter("@IdFuncionPri", SqlDbType.SmallInt),
                            New SqlParameter("@IdFuncionSec", SqlDbType.TinyInt),
                            New SqlParameter("@IdMotGralBaja", SqlDbType.TinyInt),
                            New SqlParameter("@TratarComoBase", SqlDbType.Bit),
                            New SqlParameter("@IdPlazaCreada", SqlDbType.Int),
                            New SqlParameter("@IdTipoSemestre", SqlDbType.TinyInt),
                            New SqlParameter("@InterinoPuro", SqlDbType.Bit),
                            New SqlParameter("@FechaAlta", SqlDbType.DateTime),
                            New SqlParameter("@FechaBaja", SqlDbType.DateTime),
                            New SqlParameter("@IdPuesto", SqlDbType.TinyInt)}

                If TipoOperacion = 0 Then
                    Prms(0).Value = DBNull.Value
                Else
                    Prms(0).Value = RFCEmp
                End If
                Prms(1).Value = Me._IdEmpFuncion
                Prms(2).Value = Me._IdPlantel
                Prms(3).Value = Me._IdTipoNomina
                Prms(4).Value = Me._IdCT
                Prms(5).Value = Me._IdCategoria
                Prms(6).Value = Me._IdSindicato
                Prms(7).Value = Me._IdPlazaTipoOcupacion
                Prms(8).Value = QnaVigIni
                Prms(9).Value = QnaVigFin
                Prms(10).Value = TipoOperacion
                If TipoOperacion = 0 Then
                    Prms(11).Value = Me._IdPlaza
                Else
                    Prms(11).Value = DBNull.Value
                End If
                Prms(12).Value = Me._IdMotivoInterinato
                If Me._RFCEmpTitular.Trim <> String.Empty Then
                    Prms(13).Value = Me._RFCEmpTitular
                Else
                    Prms(13).Value = DBNull.Value
                End If
                Prms(14).Value = Me._IdFuncionPri
                Prms(15).Value = Me._IdFuncionSec
                Prms(16).Value = Me._IdMotGralBaja
                Prms(17).Value = Me._TratarComoBase
                Prms(18).Direction = ParameterDirection.Output
                Prms(19).Value = Me._IdTipoSemestre
                Prms(20).Value = Me._InterinoPuro
                Prms(21).Value = Me._FechaAlta
                Prms(22).Value = Me._FechaBaja
                Prms(23).Value = Me._IdPuesto

                _DataCOBAEV.RunProc("SP_IoUEmpleadosPlazas", Prms, Nomina, ArregloAuditoria)

                Return CInt(Prms(18).Value) 'Retornamos el IdPlaza creado
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraBaja2(ByVal IdQnaVigIni As Short, ByVal IdQnaVigFin As Short, ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int),
                            New SqlParameter("@IdQnaVigIni", SqlDbType.SmallInt),
                            New SqlParameter("@IdQnaVigFin", SqlDbType.SmallInt),
                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                            New SqlParameter("@IdMotGralBaja", SqlDbType.TinyInt),
                            New SqlParameter("@FechaAlta", SqlDbType.DateTime),
                            New SqlParameter("@FechaBaja", SqlDbType.DateTime)}

                Prms(0).Value = Me._IdPlaza
                Prms(1).Value = IdQnaVigIni
                Prms(2).Value = IdQnaVigFin
                Prms(3).Value = TipoOperacion
                Prms(4).Value = Me._IdMotGralBaja
                Prms(5).Value = Me._FechaAlta
                Prms(6).Value = Me._FechaBaja

                Return _DataCOBAEV.RunProc("SP_IoUPlazasHistoria", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaTitular(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdMotivoInterinato", SqlDbType.TinyInt),
                                            New SqlParameter("@RFCEmpTitular", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdPlaza", SqlDbType.Int),
                                            New SqlParameter("@IdPlazaTipoOcupacion", SqlDbType.TinyInt)}
                Prms(0).Value = Me._IdMotivoInterinato
                If Me._RFCEmpTitular.Trim <> String.Empty Then
                    Prms(1).Value = Me._RFCEmpTitular
                Else
                    Prms(1).Value = DBNull.Value
                End If
                Prms(2).Value = Me._IdPlaza
                Prms(3).Value = Me._IdPlazaTipoOcupacion
                Return _DataCOBAEV.RunProc("SP_UPlazasInterinas", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
#Region "Clase EmpleadoFuncion"
    Public Class EmpleadoFuncion
#Region "Clase EmpleadoFuncion: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase EmpleadoFuncion: Métodos públicos"
        Public Function ObtenFuncionesParaAsigDePlaza() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEmpsFuncsParaAsigDePlaza", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFunciones() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEmpleadosFunciones", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodas() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@TodosLosRegistros", SqlDbType.Bit)
                    }

                Prms(0).Value = True

                Return _DataCOBAEV.RunProc("SP_SEmpleadosFunciones", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenTodasParaTipificar() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@TodosLosRegistros", SqlDbType.Bit),
                                            New SqlParameter("@ParaTipificarCategoria", SqlDbType.Bit
                                            )
                    }

                Prms(0).Value = True
                Prms(1).Value = True

                Return _DataCOBAEV.RunProc("SP_SEmpleadosFunciones", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

#End Region
    End Class
#End Region
#Region "Clase Empleado"
    Public Class Empleado
#Region "Clase Empleado: Propiedades públicas"
        Public Enum TipoBusqueda
            RFC = 0
            Nombre = 1
            NumeroDeEmpleado = 2
            CURP = 3
        End Enum
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal Value As String)
                _Email = Value
            End Set
        End Property
        Public Property IdEmp() As Integer
            Get
                Return _IdEmp
            End Get
            Set(ByVal Value As Integer)
                _IdEmp = Value
            End Set
        End Property
        Public Property RFC() As String
            Get
                Return _RFC
            End Get
            Set(ByVal Value As String)
                _RFC = Value
            End Set
        End Property
        Public Property CURPEmp() As String
            Get
                Return _CURPEmp
            End Get
            Set(ByVal Value As String)
                _CURPEmp = Value
            End Set
        End Property
        Public Property ApePatEmp() As String
            Get
                Return _ApePatEmp
            End Get
            Set(ByVal Value As String)
                _ApePatEmp = Value
            End Set
        End Property
        Public Property ApeMatEmp() As String
            Get
                Return _ApeMatEmp
            End Get
            Set(ByVal Value As String)
                _ApeMatEmp = Value
            End Set
        End Property
        Public Property NomEmp() As String
            Get
                Return _NomEmp
            End Get
            Set(ByVal Value As String)
                _NomEmp = Value
            End Set
        End Property
        Public Property EstatusEmp() As Byte
            Get
                Return _EstatusEmp
            End Get
            Set(ByVal Value As Byte)
                _EstatusEmp = Value
            End Set
        End Property
        Public Property NumEmp() As String
            Get
                Return _NumEmp
            End Get
            Set(ByVal Value As String)
                _NumEmp = Value
            End Set
        End Property
        Public Property IdSexo() As Byte
            Get
                Return _IdSexo
            End Get
            Set(ByVal Value As Byte)
                _IdSexo = Value
            End Set
        End Property
        Public Property IdNacionalidad() As Byte
            Get
                Return _IdNacionalidad
            End Get
            Set(ByVal Value As Byte)
                _IdNacionalidad = Value
            End Set
        End Property
        Public Property IdEdoCivil() As Byte
            Get
                Return _IdEdoCivil
            End Get
            Set(ByVal Value As Byte)
                _IdEdoCivil = Value
            End Set
        End Property
        Public Property IdEdo() As Byte
            Get
                Return _IdEdo
            End Get
            Set(ByVal Value As Byte)
                _IdEdo = Value
            End Set
        End Property
        Public Property FecNacEmp() As Date
            Get
                Return _FecNacEmp
            End Get
            Set(ByVal Value As Date)
                _FecNacEmp = Value
            End Set
        End Property
        Public Property FchIngCOBAEV() As Date
            Get
                Return _FchIngCOBAEV
            End Get
            Set(ByVal Value As Date)
                _FchIngCOBAEV = Value
            End Set
        End Property
        Public Property QnaIngCOBAEV() As Integer
            Get
                Return _QnaIngCOBAEV
            End Get
            Set(ByVal Value As Integer)
                _QnaIngCOBAEV = Value
            End Set
        End Property
        Public Property AniosAnt() As Byte
            Get
                Return _AniosAnt
            End Get
            Set(ByVal Value As Byte)
                _AniosAnt = Value
            End Set
        End Property
        Public Property MesesAnt() As Byte
            Get
                Return _MesesAnt
            End Get
            Set(ByVal Value As Byte)
                _MesesAnt = Value
            End Set
        End Property
        Public Property DiasAnt() As Byte
            Get
                Return _DiasAnt
            End Get
            Set(ByVal Value As Byte)
                _DiasAnt = Value
            End Set
        End Property
        Public Property CobraPrimaAnt() As Boolean
            Get
                Return _CobraPrimaAnt
            End Get
            Set(ByVal Value As Boolean)
                _CobraPrimaAnt = Value
            End Set
        End Property
        Public Property QuincenaCalculo() As Integer
            Get
                Return _QuincenaCalculo
            End Get
            Set(ByVal Value As Integer)
                _QuincenaCalculo = Value
            End Set
        End Property
        Public Property HomologaEnSemestreA() As Boolean
            Get
                Return _HomologaEnSemestreA
            End Get
            Set(ByVal Value As Boolean)
                _HomologaEnSemestreA = Value
            End Set
        End Property
        Public Property HomologaEnSemestreB() As Boolean
            Get
                Return _HomologaEnSemestreB
            End Get
            Set(ByVal Value As Boolean)
                _HomologaEnSemestreB = Value
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
        Public Property IdCategoriaSemA() As Short
            Get
                Return _IdCategoriaSemA
            End Get
            Set(ByVal Value As Short)
                _IdCategoriaSemA = Value
            End Set
        End Property
        Public Property IdCategoriaSemB() As Short
            Get
                Return _IdCategoriaSemB
            End Get
            Set(ByVal Value As Short)
                _IdCategoriaSemB = Value
            End Set
        End Property
        Public Property NSS() As String
            Get
                Return _NSS
            End Get
            Set(ByVal Value As String)
                _NSS = Value
            End Set
        End Property
        Public Property CuentaBancaria() As String
            Get
                Return _CuentaBancaria
            End Get
            Set(ByVal Value As String)
                _CuentaBancaria = Value
            End Set
        End Property
        Public Property IdBanco() As Byte
            Get
                Return _IdBanco
            End Get
            Set(ByVal Value As Byte)
                _IdBanco = Value
            End Set
        End Property
        Public Property IdRegimenISSSTE() As Byte
            Get
                Return _IdRegimenISSSTE
            End Get
            Set(ByVal Value As Byte)
                _IdRegimenISSSTE = Value
            End Set
        End Property
        Public Property IncluirEnPagomatico() As Byte
            Get
                Return _IncluirEnPagomatico
            End Get
            Set(ByVal Value As Byte)
                _IncluirEnPagomatico = Value
            End Set
        End Property
        Public Property IdZonaEcoA() As Byte
            Get
                Return _IdZonaEcoA
            End Get
            Set(ByVal Value As Byte)
                _IdZonaEcoA = Value
            End Set
        End Property
        Public Property IdZonaEcoB() As Byte
            Get
                Return _IdZonaEcoB
            End Get
            Set(ByVal Value As Byte)
                _IdZonaEcoB = Value
            End Set
        End Property
#End Region
#Region "Clase Empleado: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _RFC, _NSS, _CuentaBancaria, _Email As String
        Private _NomEmp, _NumEmp, _CURPEmp, _ApePatEmp, _ApeMatEmp As String
        Private _EstatusEmp, _IdSexo, _IdNacionalidad, _IdEdoCivil, _IdEdo, _IdBanco, _IdRegimenISSSTE As Byte
        Private _AniosAnt, _MesesAnt, _DiasAnt As Byte
        Private _IdEmp, _QnaIngCOBAEV, _QuincenaCalculo As Integer
        Private _FecNacEmp, _FchIngCOBAEV As Date
        Private _CobraPrimaAnt, _HomologaEnSemestreA, _HomologaEnSemestreB, _IncluirEnPagomatico As Boolean
        Private _IdPlantel, _IdCategoriaSemA, _IdCategoriaSemB As Short
        Private _IdZonaEcoA, _IdZonaEcoB As Byte
#End Region
#Region "Clase Empleado: Métodos públicos"
        Public Function ObtenUltimoSueldoMensualOrddinario(ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SObtenUltSdoMenOrd", Prms, Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function SeLePuedeCrearReciboEnQna(ByVal pRFCEmp As String, ByVal pIdQuincena As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Dim dr As DataRow

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdQuincena

                dr = _DataCOBAEV.RunProc("SP_VEmpleadosRecibosEnQna", Prms, DataRow, Nomina)

                Return CBool(dr("Result"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaDatos(pNumEmp As String, pRFCEmp As String, pEMail As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5),
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@EMail", SqlDbType.NVarChar, 100)}

                Prms(0).Value = IIf(pNumEmp = "", DBNull.Value, pNumEmp)
                Prms(1).Value = IIf(pRFCEmp = "", DBNull.Value, pRFCEmp)
                Prms(2).Value = IIf(pEMail = "", DBNull.Value, pEMail)

                Return _DataCOBAEV.RunProc("SP_VDatosEmpleado", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function TieneEmail(pRFCEmp As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Dim dr As DataRow

                Prms(0).Value = pRFCEmp

                dr = _DataCOBAEV.RunProc("SP_VSiEmpTieneEmail", Prms, DataRow, Nomina)

                Return CBool(dr("Result"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdInfParaRegistroDeEmail(pNumEmp As String, pRFCEmp As String, pEmail As String,
                                                  pCodigoRegistroEmail As String, pConfirmado As Boolean) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5),
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@Email", SqlDbType.NVarChar, 100),
                                                New SqlParameter("@CodigoRegistroEmail", SqlDbType.NVarChar, 10),
                                                New SqlParameter("@Confirmado", SqlDbType.Bit)}

                Prms(0).Value = pNumEmp
                Prms(1).Value = pRFCEmp
                Prms(2).Value = pEmail
                Prms(3).Value = pCodigoRegistroEmail
                Prms(4).Value = pConfirmado

                Return _DataCOBAEV.RunProc("SP_IoUEmpleadosRegistroEmail", Prms, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AddInfParaRegistroDeEmail(pNumEmp As String, pRFCEmp As String, pEmail As String,
                                                  pCodigoRegistroEmail As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5),
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@Email", SqlDbType.NVarChar, 100),
                                                New SqlParameter("@CodigoRegistroEmail", SqlDbType.NVarChar, 10)}

                Prms(0).Value = pNumEmp
                Prms(1).Value = pRFCEmp
                Prms(2).Value = pEmail
                Prms(3).Value = pCodigoRegistroEmail

                Return _DataCOBAEV.RunProc("SP_IoUEmpleadosRegistroEmail", Prms, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AddInfDeSolicitudDeEstDePuntyAsist(pRFCEmp As String, pParte As Byte, pAnio As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@Parte", SqlDbType.TinyInt),
                                              New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pParte
                Prms(2).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_IEstimulosDePuntualidadYAsistencia", Prms, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdInfDeSolicitudDeEstDePuntyAsist(pRFCEmp As String, pParte As Byte, pAnio As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@Parte", SqlDbType.TinyInt),
                                              New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pParte
                Prms(2).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_UEstimulosDePuntualidadYAsistencia", Prms, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdInfDeSolicitudDeDiasEcoNoDisf(pRFCEmp As String, pAnio As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_UDiasEconomicosNoDisf", Prms, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaInfParaRegistroDeEmail(pNumEmp As String, pRFCEmp As String, pEmail As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5),
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@Email", SqlDbType.NVarChar, 100)}

                Prms(0).Value = pNumEmp
                Prms(1).Value = pRFCEmp
                Prms(2).Value = pEmail

                Return _DataCOBAEV.RunProc("SP_VEmpleadosRegistroEmail", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaInfDeSolicitudDeEstDePuntyAsist(pNumEmp As String, pRFCEmp As String, pParte As Byte, pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5),
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@Parte", SqlDbType.TinyInt),
                                                New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pNumEmp
                Prms(1).Value = pRFCEmp
                Prms(2).Value = pParte
                Prms(3).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_VInfDeSolicitudDeEstDePuntyAsist", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaInfDeSolicitudDeDiasEcoNoDisf(pNumEmp As String, pRFCEmp As String, pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5),
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pNumEmp
                Prms(1).Value = pRFCEmp
                Prms(2).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_VInfDeSolicitudDeDiasEcoNoDisf", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaCodigoRegistroEmail(pRFCEmp As String, pCodigoRegistroEmail As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@CodigoRegistroEmail", SqlDbType.NVarChar, 10)}
                Dim dr As DataRow

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pCodigoRegistroEmail

                dr = _DataCOBAEV.RunProc("SP_VCodigoRegistroEmail", Prms, DataRow, Nomina)

                Return CBool(dr("CodigoRegistroEmailOK"))

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function EsDocenteEnSemestre(pRFCEmp As String, ByVal pIdSemestre As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}
                Dim dr As DataRow

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdSemestre

                dr = _DataCOBAEV.RunProc("SP_VSiEmpEsDocEnSemestre", Prms, DataRow, Nomina)

                Return CBool(dr("Result"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelCategoriaBase(pRFCEmp As String, pTipoSemestre As String, ByVal pIdCategoria As Short,
                                         pHoras As Byte, pIdQnaIni As Short, pIdQnaFin As Short,
                                         ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@TipoSemestre", SqlDbType.NVarChar, 3),
                                              New SqlParameter("@IdCategoria", SqlDbType.SmallInt),
                                              New SqlParameter("@Horas", SqlDbType.TinyInt),
                                              New SqlParameter("@IdQnaIni", SqlDbType.SmallInt),
                                              New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pTipoSemestre
                Prms(2).Value = pIdCategoria
                Prms(3).Value = pHoras
                Prms(4).Value = pIdQnaIni
                Prms(5).Value = pIdQnaFin

                Return _DataCOBAEV.RunProc("SP_DEmpleadosCategoriasBase", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AddCategoriaBase(pRFCEmp As String, pTipoSemestre As String, ByVal pIdCategoria As Short,
                                         pHoras As Byte, pIdQnaIni As Short, pIdQnaFin As Short,
                                         ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@TipoSemestre", SqlDbType.NVarChar, 3),
                                              New SqlParameter("@IdCategoria", SqlDbType.SmallInt),
                                              New SqlParameter("@Horas", SqlDbType.TinyInt),
                                              New SqlParameter("@IdQnaIni", SqlDbType.SmallInt),
                                              New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pTipoSemestre
                Prms(2).Value = pIdCategoria
                Prms(3).Value = pHoras
                Prms(4).Value = pIdQnaIni
                Prms(5).Value = pIdQnaFin

                Return _DataCOBAEV.RunProc("SP_IEmpleadosCategoriasBase", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdCategoriaBase(pRFCEmp As String, pTipoSemestreAnt As String, ByVal pIdCategoriaAnt As Short,
                                 pHorasAnt As Byte, pIdQnaIniAnt As Short, pIdQnaFinAnt As Short,
                                 pTipoSemestreNew As String, ByVal pIdCategoriaNew As Short,
                                 pHorasNew As Byte, pIdQnaIniNew As Short, pIdQnaFinNew As Short,
                                 ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@TipoSemestreAnt", SqlDbType.NVarChar, 3),
                                              New SqlParameter("@IdCategoriaAnt", SqlDbType.SmallInt),
                                              New SqlParameter("@HorasAnt", SqlDbType.TinyInt),
                                              New SqlParameter("@IdQnaIniAnt", SqlDbType.SmallInt),
                                              New SqlParameter("@IdQnaFinAnt", SqlDbType.SmallInt),
                                              New SqlParameter("@TipoSemestreNew", SqlDbType.NVarChar, 3),
                                              New SqlParameter("@IdCategoriaNew", SqlDbType.SmallInt),
                                              New SqlParameter("@HorasNew", SqlDbType.TinyInt),
                                              New SqlParameter("@IdQnaIniNew", SqlDbType.SmallInt),
                                              New SqlParameter("@IdQnaFinNew", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pTipoSemestreAnt
                Prms(2).Value = pIdCategoriaAnt
                Prms(3).Value = pHorasAnt
                Prms(4).Value = pIdQnaIniAnt
                Prms(5).Value = pIdQnaFinAnt
                Prms(6).Value = pTipoSemestreNew
                Prms(7).Value = pIdCategoriaNew
                Prms(8).Value = pHorasNew
                Prms(9).Value = pIdQnaIniNew
                Prms(10).Value = pIdQnaFinNew

                Return _DataCOBAEV.RunProc("SP_UEmpleadosCategoriasBase", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSiCobroComoAdmvo_o_DocEnQna(pRFCEmp As String, ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_STipoPlazaEmpCobroEnQna", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistConceptosPorEjerc(ByVal pRFCEmp As String, ByVal pEjercicio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                               New SqlParameter("@Ejercicio", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pEjercicio

                Return _DataCOBAEV.RunProc("SP_SEmpleadoHistoricoConceptos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistConceptoDetallePorEjerc(ByVal pRFCEmp As String, ByVal pIdConcepto As Short, ByVal pTipoConcepto As String, ByVal pEjercicio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdConcepto", SqlDbType.SmallInt),
                                            New SqlParameter("@TipoConcepto", SqlDbType.NVarChar, 1),
                                            New SqlParameter("@Ejercicio", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdConcepto
                Prms(2).Value = pTipoConcepto
                Prms(3).Value = pEjercicio

                Return _DataCOBAEV.RunProc("SP_SEmpleadoHistoricoConceptoDetalle", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPercsDeducsVigentes(ByVal pRFCEmp As String) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SEmpleadoPercsDeducsVigentes", Prms, "EmpleadoPercsDeducsVigentes", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPagosProvisionados(ByVal pRFCEmp As String, ByVal pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SPagosProvisionadosPorEmp", Prms, Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPagosBonosProductividad(ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SBonoCentralesPorEmp", Prms, Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenFechasAltayBaja(ByVal pRFCEmp As String, pIdPlaza As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = pIdPlaza

                Return _DataCOBAEV.RunProc("SP_SEmpsBajasISSSTE", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenMotivosDeBaja(ByVal pIdMotGralBaja As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdMotGralBaja", SqlDbType.SmallInt)}

                Prms(0).Value = pIdMotGralBaja

                Return _DataCOBAEV.RunProc("SP_SMotivosGeneralesDeBaja", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMotivosDeBaja() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SMotivosGeneralesDeBaja", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMotivosDeBajaSegunTipoOcupacion(ByVal pIdTipoEmpleado As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTipoEmpleado", SqlDbType.SmallInt)}

                Prms(0).Value = pIdTipoEmpleado

                Return _DataCOBAEV.RunProc("SP_SMotivosGeneralesDeBajaSegunTipoOcupacion", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFuncionesPrimarias() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SFuncionesPrimarias", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFuncionesSecundarias() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SFuncionesSecundarias", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFuncionesSecundarias(pSoloOpcionesValidas As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@SoloOpcionesValidas", SqlDbType.Bit)}

                Prms(0).Value = pSoloOpcionesValidas

                Return _DataCOBAEV.RunProc("SP_SFuncionesSecundarias", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDiasPagadosPorQna(ByVal RFCEmp As String, ByVal IdQuincena As Short, Optional ByVal IdQuincenaAplicacion As Short = 0, Optional ByVal Adeudo As Boolean = False, Optional ByVal Devolucion As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                               New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                               New SqlParameter("@IdQuincenaAplicacion", SqlDbType.SmallInt),
                                               New SqlParameter("@Adeudo", SqlDbType.Bit),
                                               New SqlParameter("@Devolucion", SqlDbType.Bit)}
                Prms(0).Value = RFCEmp
                Prms(1).Value = IdQuincena
                Prms(2).Value = IdQuincenaAplicacion
                Prms(3).Value = Adeudo
                Prms(4).Value = Devolucion

                Return _DataCOBAEV.RunProc("SP_SEmpsDiasPagadosPorQna", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaDiasParaPagoQnal(ByVal IdEmp As Integer, ByVal IdQuincena As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                               New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = IdEmp
                Prms(1).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_DEmpsDiasParaPagoQnal", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaDiaEconomicos(ByVal IdEmp As Integer, ByVal Fecha As Date, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                               New SqlParameter("@Fecha", SqlDbType.DateTime)}
                Prms(0).Value = IdEmp
                Prms(1).Value = Fecha

                Return _DataCOBAEV.RunProc("SP_DDiasEconomicos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Ins_O_UpdDiasParaPagoQnal(ByVal IdEmp As Integer, ByVal IdQuincena As Short, ByVal NumDiasAPagar As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                               New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                               New SqlParameter("@NumDiasAPagar", SqlDbType.TinyInt)}
                Prms(0).Value = IdEmp
                Prms(1).Value = IdQuincena
                Prms(2).Value = NumDiasAPagar

                Return _DataCOBAEV.RunProc("SP_IoUEmpsDiasParaPagoQnal", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Ins_O_UpdDiasEconomicos(ByVal IdEmp As Integer, ByVal FechaAnt As Date, ByVal FechaNueva As Date, ByVal IdUsuario As Short, ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@FechaAnt", SqlDbType.DateTime),
                                            New SqlParameter("@FechaNueva", SqlDbType.DateTime),
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}
                Prms(0).Value = IdEmp
                Prms(1).Value = FechaAnt
                Prms(2).Value = FechaNueva
                Prms(3).Value = IdUsuario
                Prms(4).Value = TipoOperacion

                Return _DataCOBAEV.RunProc("SP_IoUDiasEconomicos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDiasParaPagoQnal(ByVal RFCEmp As String, ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                               New SqlParameter("@Anio", SqlDbType.SmallInt)}
                Prms(0).Value = RFCEmp
                Prms(1).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SEmpsDiasParaPagoQnal", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenResumenPagoQnalesPorAnio(ByVal RFCEmp As String, ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                               New SqlParameter("@Anio", SqlDbType.SmallInt)}
                Prms(0).Value = RFCEmp
                Prms(1).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SEmpResumenPagosQnalesPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenResumenPagoQnalesPorAnio2(ByVal RFCEmp As String, ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                               New SqlParameter("@Anio", SqlDbType.SmallInt)}
                Prms(0).Value = RFCEmp
                Prms(1).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SEmpResumenPagosQnalesPorAnio2", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDiasEconomicosPorAño(ByVal RFCEmp As String, ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                               New SqlParameter("@Anio", SqlDbType.SmallInt)}
                Prms(0).Value = RFCEmp
                Prms(1).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SDiasEcoAnualesPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSubsidioParaEmpleoAcumulado(ByVal RFCEmp As String, ByVal Anio As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = RFCEmp
                Prms(1).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SSubsidioParaElEmpleoAcumulado", Prms, "SubsidioParaElEmpleoAcumulado", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistoriaClave(ByVal RFCEmp As String, ByVal IdClave As Short, ByVal PercDeduc As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                               New SqlParameter("@IdClave", SqlDbType.SmallInt),
                                               New SqlParameter("@PercDeduc", SqlDbType.Char, 1)}
                Prms(0).Value = RFCEmp
                Prms(1).Value = IdClave
                Prms(2).Value = PercDeduc

                Return _DataCOBAEV.RunProc("SP_SHistoriaClavesPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorPlantel(ByVal IdPlantel As Short, Optional ByVal ParaCalculo As Boolean = False, Optional ByVal IdQnaParaCalculo As Short = 0) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                                                New SqlParameter("@ParaCalculo", SqlDbType.Bit),
                                                New SqlParameter("@IdQnaParaCalculo", SqlDbType.SmallInt)}
                Prms(0).Value = IdPlantel
                Prms(1).Value = ParaCalculo
                Prms(2).Value = IdQnaParaCalculo
                Return _DataCOBAEV.RunProc("SP_SEmpleadosPorPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEmpsParaCalcDePensionAlim(ByVal pIdPlantel As Short, ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = pIdPlantel
                Prms(1).Value = pIdQuincena
                Return _DataCOBAEV.RunProc("SP_SEmpsParaCalculoPensionAlim", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConAutorizacionDeHomolgacion(ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SAutorizacionesHomologacion", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConEstDePuntYAsistPorSemestre(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_SEstimulosDePuntualidadYAsistencia", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConEstimuloDocente(ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SEstimulosDocentes", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConEstimuloDocente(ByVal RFCEmp As String, ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt),
                                            New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = Anio
                Prms(1).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_SEstimulosDocentes", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConAdeudos(ByVal IdQuincena As Short, ByVal IdRol As Byte, ByVal ConsultaZonasEspecificas As Boolean, ByVal ConsultaPlantelesEspecificos As Boolean, ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt),
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit),
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit),
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = IdQuincena
                Prms(1).Value = IdRol
                Prms(2).Value = ConsultaZonasEspecificas
                Prms(3).Value = ConsultaPlantelesEspecificos
                Prms(4).Value = CShort(drUsr("IdUsuario"))
                Prms(0).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SEmpleadosAdeudos", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConAdeudos(ByVal RFCEmp As String, ByVal IdQnaAplicacion As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                            New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = IdQnaAplicacion
                Prms(1).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_SEmpleadosAdeudos", Prms, "EmpleadosAdeudos", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConDevoluciones(ByVal IdQuincena As Short, ByVal IdRol As Byte, ByVal ConsultaZonasEspecificas As Boolean, ByVal ConsultaPlantelesEspecificos As Boolean, ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt),
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit),
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit),
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = IdQuincena
                Prms(1).Value = IdRol
                Prms(2).Value = ConsultaZonasEspecificas
                Prms(3).Value = ConsultaPlantelesEspecificos
                Prms(4).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SEmpleadosDevoluciones", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConDevoluciones(ByVal RFCEmp As String, ByVal IdQnaAplicacion As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                            New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = IdQnaAplicacion
                Prms(1).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_SEmpleadosDevoluciones", Prms, "EmpleadosDevoluciones", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CreaTablaParaEspecificarDias(ByVal IdQnaIni As Short, ByVal IdQnaFin As Short, ByVal IncluirAdicionales As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQnaIni", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaFin", SqlDbType.SmallInt),
                                            New SqlParameter("@IncluirAdicionales", SqlDbType.Bit)}

                Prms(0).Value = IdQnaIni
                Prms(1).Value = IdQnaFin
                Prms(2).Value = IncluirAdicionales

                Return _DataCOBAEV.RunProc("SP_SCreaTablaQnasDias", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaAdeudo(ByVal IdQnaIni As Short, ByVal IdQnaFin As Short, ByVal IdQnaAplicacion As Short, ByVal IdTipoAdeudo As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQnaIni", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaFin", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaAplicacion", SqlDbType.SmallInt),
                                            New SqlParameter("@IdTipoAdeudo", SqlDbType.TinyInt),
                                            New SqlParameter("@NumDias", SqlDbType.TinyInt)}

                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin
                Prms(3).Value = IdQnaAplicacion
                Prms(4).Value = IdTipoAdeudo

                Return _DataCOBAEV.RunProc("SP_IEmpleadosAdeudos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaDevolucion(ByVal IdQnaIni As Short, ByVal IdQnaFin As Short, ByVal IdQnaAplicacion As Short, ByVal IdTipoDevolucion As Byte, ByVal NumPagos As Byte,
                                    ByVal DescIncluyeAdic As Boolean, ByVal PeriodoIncluyeAdic As Boolean, ByVal AplicarDescMax As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQnaIni", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaFin", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaAplicacion", SqlDbType.SmallInt),
                                            New SqlParameter("@IdTipoDevolucion", SqlDbType.TinyInt),
                                            New SqlParameter("@NumDias", SqlDbType.TinyInt),
                                            New SqlParameter("@NumPagos", SqlDbType.TinyInt),
                                            New SqlParameter("@DescIncluyeAdic", SqlDbType.Bit),
                                            New SqlParameter("@PeriodoIncluyeAdic", SqlDbType.Bit),
                                            New SqlParameter("@AplicarDescMax", SqlDbType.Bit)}

                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin
                Prms(3).Value = IdQnaAplicacion
                Prms(4).Value = IdTipoDevolucion
                Prms(6).Value = NumPagos
                Prms(7).Value = DescIncluyeAdic
                Prms(8).Value = PeriodoIncluyeAdic
                Prms(9).Value = AplicarDescMax

                Return _DataCOBAEV.RunProc("SP_IEmpleadosDevoluciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdAdeudo(ByVal IdQnaIni As Short, ByVal IdQnaFin As Short, ByVal IdQnaAplicacion As Short,
                                    ByVal IdQnaAplicacionAnt As Short, ByVal IdTipoAdeudo As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQnaIni", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaFin", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaAplicacion", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaAplicacionAnt", SqlDbType.SmallInt),
                                            New SqlParameter("@IdTipoAdeudo", SqlDbType.TinyInt)}

                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin
                Prms(3).Value = IdQnaAplicacion
                Prms(4).Value = IdQnaAplicacionAnt
                Prms(5).Value = IdTipoAdeudo

                Return _DataCOBAEV.RunProc("SP_UEmpleadosAdeudos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdDevolucion(ByVal IdQnaIni As Short, ByVal IdQnaFin As Short, ByVal IdQnaAplicacion As Short, ByVal IdQnaAplicacionAnt As Short, ByVal IdTipoDevolucion As Byte, ByVal NumPagos As Byte,
                     ByVal DescIncluyeAdic As Boolean, ByVal PeriodoIncluyeAdic As Boolean, ByVal AplicarDescMax As Boolean,
                     ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQnaIni", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaFin", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaAplicacion", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaAplicacionAnt", SqlDbType.SmallInt),
                                            New SqlParameter("@IdTipoDevolucion", SqlDbType.TinyInt),
                                            New SqlParameter("@NumPagos", SqlDbType.TinyInt),
                                            New SqlParameter("@DescIncluyeAdic", SqlDbType.Bit),
                                            New SqlParameter("@PeriodoIncluyeAdic", SqlDbType.Bit),
                                            New SqlParameter("@AplicarDescMax", SqlDbType.Bit)}

                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin
                Prms(3).Value = IdQnaAplicacion
                Prms(4).Value = IdQnaAplicacionAnt
                Prms(5).Value = IdTipoDevolucion
                Prms(6).Value = NumPagos
                Prms(7).Value = DescIncluyeAdic
                Prms(8).Value = PeriodoIncluyeAdic
                Prms(9).Value = AplicarDescMax

                Return _DataCOBAEV.RunProc("SP_UEmpleadosDevoluciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdNumDiasAdeudo(ByVal IdQuincena As Short, ByVal IdQnaAplicacion As Short, ByVal NumDias As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQnaAplicacion", SqlDbType.SmallInt),
                                            New SqlParameter("@NumDias", SqlDbType.TinyInt),
                                            New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQnaAplicacion
                Prms(2).Value = NumDias
                Prms(3).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_UEmpleadosAdeudos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdNumDiasDevolucion(ByVal IdQuincena As Short, ByVal IdQnaAplicacion As Short, ByVal NumDias As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQnaAplicacion", SqlDbType.SmallInt),
                                            New SqlParameter("@NumDias", SqlDbType.TinyInt),
                                            New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQnaAplicacion
                Prms(2).Value = NumDias
                Prms(3).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_UEmpleadosDevoluciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelAdeudo(ByVal IdQnaAplicacion As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQnaAplicacion", SqlDbType.SmallInt)}

                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQnaAplicacion

                Return _DataCOBAEV.RunProc("SP_DEmpleadosAdeudos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelDevolucion(ByVal IdQnaAplicacion As Short, ByVal ArregloAuditoria() As String) As Byte
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQnaAplicacion", SqlDbType.SmallInt),
                                            New SqlParameter("@NumPagos", SqlDbType.TinyInt)}

                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQnaAplicacion
                Prms(2).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_DEmpleadosDevoluciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Return CByte(Prms(2).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNumDesctosDevolucion(ByVal IdQnaAplicacion As Short, ByVal ArregloAuditoria() As String) As Byte
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQnaAplicacion", SqlDbType.SmallInt),
                                            New SqlParameter("@NumDesctos", SqlDbType.TinyInt)}

                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQnaAplicacion
                Prms(2).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_SNumDesctosDeUnaDevol", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Return CByte(Prms(2).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ABCHoraAdeudo(ByVal IdHora As Integer, ByVal IdQuincena As Short, ByVal Bandera As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int),
                                            New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                            New SqlParameter("@Bandera", SqlDbType.Bit)}

                Prms(0).Value = IdHora
                Prms(1).Value = IdQuincena
                Prms(2).Value = Bandera

                Return _DataCOBAEV.RunProc("SP_ABCHorasAdeudos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ABCHoraDevolucion(ByVal IdHora As Integer, ByVal IdQuincena As Short, ByVal Bandera As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int),
                                            New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                            New SqlParameter("@Bandera", SqlDbType.Bit)}

                Prms(0).Value = IdHora
                Prms(1).Value = IdQuincena
                Prms(2).Value = Bandera

                Return _DataCOBAEV.RunProc("SP_ABCHorasDevoluciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsParaEstimuloDocente(ByVal Anio As Short, ByVal Importe As Decimal, ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@Anio", SqlDbType.SmallInt),
                                            New SqlParameter("@Importe", SqlDbType.Decimal),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = Anio
                Prms(2).Value = Importe
                Prms(3).Value = TipoOperacion

                Return _DataCOBAEV.RunProc("SP_IoUEstimuloDocente", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdParaEstimuloDocente(ByVal Anio As Short, ByVal Importe As Decimal, ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                InsParaEstimuloDocente(Anio, Importe, TipoOperacion, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelDeEstimuloDocente(ByVal Anio As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@Anio", SqlDbType.SmallInt)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = Anio

                Return _DataCOBAEV.RunProc("SP_DEstimuloDocente", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaDeEstDePuntYAsist(ByVal IdSemestre As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_DEstimulosDePuntualidadYAsistencia", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsEstDePuntYAsist(ByVal IdSemestre As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_IEstimulosDePuntualidadYAsistencia", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConSaldoNegativo(ByVal IdQuincena As Short, ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = Login
                Prms(1).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SSaldosNegativosPorQna", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarParaRecibo(ByVal IdQuincena As Short, ByVal IdRol As Byte, ByVal ConsultaZonasEspecificas As Boolean, ByVal ConsultaPlantelesEspecificos As Boolean, ByVal Login As String, Optional ByVal VerTodos As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt),
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit),
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit),
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = IdQuincena
                Prms(1).Value = IdRol
                Prms(2).Value = ConsultaZonasEspecificas
                If VerTodos = True Then
                    Prms(3).Value = False
                Else
                    Prms(3).Value = ConsultaPlantelesEspecificos
                End If
                Prms(4).Value = CShort(drUsr("IdUsuario"))
                Return _DataCOBAEV.RunProc("SP_SBuscaEmpleadosRecibos", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarPorId(ByVal IdEmp As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int)}

                Prms(0).Value = IdEmp

                Return _DataCOBAEV.RunProc("SP_SBuscaEmpleadosPorId", Prms, DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarPorId(ByVal IdEmp As Integer, ByVal Origen As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@Origen", SqlDbType.NVarChar, 30)}

                Prms(0).Value = IdEmp
                Prms(1).Value = Origen

                Return _DataCOBAEV.RunProc("SP_SBuscaEmpleadosPorId", Prms, DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Buscar(ByVal pTipoBusqueda As TipoBusqueda, ByVal IdRol As Byte, ByVal ConsultaZonasEspecificas As Boolean, ByVal ConsultaPlantelesEspecificos As Boolean, ByVal Login As String, Optional ByVal VerTodos As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@NomEmp", SqlDbType.NVarChar, 30),
                                                New SqlParameter("@TipoBusqueda", SqlDbType.TinyInt),
                                                New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5),
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt),
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit),
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit),
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt),
                                                New SqlParameter("@CURPEmp", SqlDbType.NVarChar, 18)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()
                If pTipoBusqueda = TipoBusqueda.RFC Then
                    Prms(0).Value = _RFC
                    Prms(1).Value = DBNull.Value
                    Prms(3).Value = DBNull.Value
                    Prms(8).Value = DBNull.Value
                ElseIf pTipoBusqueda = TipoBusqueda.Nombre Then
                    Prms(0).Value = DBNull.Value
                    Prms(1).Value = _NomEmp
                    Prms(3).Value = DBNull.Value
                    Prms(8).Value = DBNull.Value
                ElseIf pTipoBusqueda = TipoBusqueda.CURP Then
                    Prms(0).Value = DBNull.Value
                    Prms(1).Value = DBNull.Value
                    Prms(3).Value = DBNull.Value
                    Prms(8).Value = Me._CURPEmp
                Else
                    Prms(0).Value = DBNull.Value
                    Prms(1).Value = DBNull.Value
                    Prms(3).Value = _NumEmp
                    Prms(8).Value = DBNull.Value
                End If
                Prms(2).Value = pTipoBusqueda
                Prms(4).Value = IdRol
                If VerTodos = True Then
                    Prms(5).Value = False
                Else
                    Prms(5).Value = ConsultaZonasEspecificas
                End If
                If VerTodos = True Then
                    Prms(6).Value = False
                Else
                    Prms(6).Value = ConsultaPlantelesEspecificos
                End If
                Prms(7).Value = CShort(drUsr("IdUsuario"))
                Return _DataCOBAEV.RunProc("SP_SBuscaEmpleados", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarApellidos(ByVal Apellido As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Apellido", SqlDbType.NVarChar, 30)}
                Prms(0).Value = Apellido
                Return _DataCOBAEV.RunProc("SP_SBuscaApellidos", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarNombres(ByVal Nombre As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Nombre", SqlDbType.NVarChar, 30)}
                Prms(0).Value = Nombre
                Return _DataCOBAEV.RunProc("SP_SBuscaNombres", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDatosPersonales() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13)}
                Prms(0).Value = _RFC
                Return _DataCOBAEV.RunProc("SP_SEmpleadosDatosPersonales", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEmpsValidadosPorSeguridadSocial() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13)}
                Prms(0).Value = _RFC
                Return _DataCOBAEV.RunProc("SP_SEmpsValidadosPorSeguridadSocial", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEmpsSinAplicDeSubsidioParaEmpleo(ByVal RFC As String, ByVal Anio As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@Anio", SqlDbType.SmallInt)}
                Prms(0).Value = RFC
                Prms(1).Value = Anio
                Return _DataCOBAEV.RunProc("SP_SEmpsSinAplicDeSubsidioParaEmpleo", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaEmpsValidadosPorSegSoc(ByVal RFC As String, ByVal SuspenderPagoQnal As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@SuspenderPagoQnal", SqlDbType.Bit)}
                Prms(0).Value = RFC
                Prms(1).Value = SuspenderPagoQnal

                Return _DataCOBAEV.RunProc("SP_IoUEmpsValidadosPorSeguridadSocial", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaEmpsSinAplicDeSubsidioParaEmpleo(ByVal RFC As String, ByVal Anio As Short, ByVal AplicarSubsidioParaEmpleo As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@Anio", SqlDbType.SmallInt),
                                            New SqlParameter("@AplicarSubsidioParaEmpleo", SqlDbType.Bit)}
                Prms(0).Value = RFC
                Prms(1).Value = Anio
                Prms(2).Value = AplicarSubsidioParaEmpleo

                Return _DataCOBAEV.RunProc("SP_IoUEmpsSinAplicDeSubsidioParaEmpleo", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDatosLaboralesPorRFCEmp(ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SEmpleadosDatosLaborales2", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDatosLaborales() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13)}
                Prms(0).Value = _RFC
                Return _DataCOBAEV.RunProc("SP_SEmpleadosDatosLaborales", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDatosLaboralesPorIdEmp() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int)}
                Prms(0).Value = Me._IdEmp
                Return _DataCOBAEV.RunProc("SP_SEmpleadosDatosLaborales", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDatosLaboralesPorIdEmp(ByVal pIdEmp As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int)}
                Prms(0).Value = pIdEmp
                Return _DataCOBAEV.RunProc("SP_SEmpleadosDatosLaborales", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDatosAcademicos() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13)}
                Prms(0).Value = _RFC
                Return _DataCOBAEV.RunProc("SP_SEmpleadosDatosAcademicos", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazasBase(pRFCEmp As String, pHistoriaCompleta As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@HistoriaCompleta", SqlDbType.Bit)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pHistoriaCompleta

                Return _DataCOBAEV.RunProc("SP_SEmpleadosCategoriasBase", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAntiguedad() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdEmp", SqlDbType.Int)}
                Prms(0).Value = IIf(_RFC.Trim = String.Empty, DBNull.Value, _RFC)
                Prms(1).Value = IIf(_IdEmp = 0, DBNull.Value, _IdEmp)
                Return _DataCOBAEV.RunProc("SP_SEmpleadosAntiguedad", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDomicilio() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13)}
                Prms(0).Value = _RFC
                Return _DataCOBAEV.RunProc("SP_SEmpleadosDomicilios", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDomicilioFiscal() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13)}
                Prms(0).Value = _RFC
                Return _DataCOBAEV.RunProc("SP_SEmpleadosDomicilioFiscal", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CalculaPagoQuincenal(ByVal IdQuincena As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = _RFC
                Prms(1).Value = IdQuincena
                Return _DataCOBAEV.RunProc("SP_SCalcPagoQnal", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConsultaPagoAcumuladoPorPeriodo(ByVal RFCEmp As String, ByVal IdQnaIni As Short, ByVal IdQnaFin As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQnaIni", SqlDbType.SmallInt),
                                                New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}
                Prms(0).Value = RFCEmp
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin

                Return _DataCOBAEV.RunProc("SP_SPagosAcumuladosPorPeriodo", Prms, "PagosAcumuladosPorPeriodo", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConsultaPagoAcumuladoPorPeriodoDesglosado(ByVal RFCEmp As String, ByVal IdQnaIni As Short, ByVal IdQnaFin As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQnaIni", SqlDbType.SmallInt),
                                                New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}
                Prms(0).Value = RFCEmp
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin

                Return _DataCOBAEV.RunProc("SP_SPagosAcumuladosPorPeriodoDesglosados", Prms, "PagosAcumuladosPorPeriodo", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConsultaPagoQnal(ByVal IdQuincena As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = _RFC
                Prms(1).Value = IdQuincena
                Return _DataCOBAEV.RunProc("SP_SConsultaPagoQnal", Prms, "PagoQnalEmpleado", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConsultaPagoQnalCategoria(ByVal IdQuincena As Short, ByVal IdCategoria As Short, ByVal IdZonaEco As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                                New SqlParameter("@IdCategoria", SqlDbType.SmallInt),
                                                New SqlParameter("@IdZonaEco", SqlDbType.SmallInt)
                                            }
                Prms(0).Value = _RFC
                Prms(1).Value = IdQuincena
                Prms(2).Value = IdCategoria
                Prms(3).Value = IdZonaEco
                Return _DataCOBAEV.RunProc("SP_SConsultaPagoQnalCategoria", Prms, "PagoQnalEmpleado", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConsultaPagoQnal2(ByVal IdQuincena As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = _RFC
                Prms(1).Value = IdQuincena
                Return _DataCOBAEV.RunProc("SP_SConsultaPagoQnal2", Prms, "PagoQnalEmpleado", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConsultaPagoQnal(ByVal pRFCEmp As String, ByVal pIdPlaza As Integer, ByVal pIdQuincena As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdPlaza_Aux", SqlDbType.Int),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdPlaza
                Prms(2).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SConsultaPagoQnal", Prms, "PagoQnalEmpleado", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DetalleDePagoQnal(ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = _RFC
                Prms(1).Value = IdQuincena
                Return _DataCOBAEV.RunProc("SP_SDetallePago", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistoriaDetallePagoHoras(RFCEmp As String, ByVal IdQuincena As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincenaAplicacion", SqlDbType.SmallInt)}
                Prms(0).Value = _RFC
                Prms(1).Value = IdQuincena
                Return _DataCOBAEV.RunProc("SP_SHistoriaDetallePagoHoras", Prms, "DetallePagoQnal", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistoriaDetallePagoCategorias(RFCEmp As String, ByVal IdQuincena As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincenaAplicacion", SqlDbType.SmallInt)}
                Prms(0).Value = _RFC
                Prms(1).Value = IdQuincena
                Return _DataCOBAEV.RunProc("SP_SHistoriaDetallePagoCategorias", Prms, "DetallePagoQnal", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function DetalleDePagoQnalAdeudo(ByVal IdQuincena As Short, ByVal IdQuincenaAplicacion As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                                New SqlParameter("@Adeudo", SqlDbType.Bit),
                                                New SqlParameter("@IdQuincenaAplicacion", SqlDbType.SmallInt)}
                Prms(0).Value = _RFC
                Prms(1).Value = IdQuincena
                Prms(2).Value = True
                Prms(3).Value = IdQuincenaAplicacion
                Return _DataCOBAEV.RunProc("SP_SDetallePago", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DetalleDePagoQnalDevolucion(ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                                New SqlParameter("@Devolucion", SqlDbType.Bit)}
                Prms(0).Value = _RFC
                Prms(1).Value = IdQuincena
                Prms(2).Value = True
                Return _DataCOBAEV.RunProc("SP_SDetallePago", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DetalleDePagoSemestral(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}
                Prms(0).Value = _RFC
                Prms(1).Value = IdSemestre
                Return _DataCOBAEV.RunProc("SP_SDetallePagoHistorico", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCargaHoraria(ByVal pRFC As String, ByVal pIdSemestre As Short, ByVal pIdQuincena As Short, ByVal pHistoriaCompletaSemestre As Boolean) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdSemestre", SqlDbType.SmallInt),
                                            New SqlParameter("@HistoriaCompletaSemestre", SqlDbType.Bit),
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = pRFC
                Prms(1).Value = pIdSemestre
                Prms(2).Value = pHistoriaCompletaSemestre
                Prms(3).Value = IIf(pIdQuincena = 0, DBNull.Value, pIdQuincena)
                Return _DataCOBAEV.RunProc("SP_SCargaHoraria", Prms, "CargaHoraria", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCargaHoraria(ByVal IdSemestre As Short, ByVal HistoriaCompletaSemestre As Boolean) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdSemestre", SqlDbType.SmallInt),
                                            New SqlParameter("@HistoriaCompletaSemestre", SqlDbType.Bit)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = IdSemestre
                Prms(2).Value = HistoriaCompletaSemestre
                Return _DataCOBAEV.RunProc("SP_SCargaHoraria", Prms, "CargaHoraria", Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCargaHorariaInterina(ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SCargaHorariaInterina", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCargaHorariaParaOP(ByVal pRFC As String, ByVal pIdSemestre As Short, ByVal pHistoriaCompletaSemestre As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdSemestre", SqlDbType.SmallInt),
                                            New SqlParameter("@HistoriaCompletaSemestre", SqlDbType.Bit)}
                Prms(0).Value = pRFC
                Prms(1).Value = pIdSemestre
                Prms(2).Value = pHistoriaCompletaSemestre
                Return _DataCOBAEV.RunProc("SP_SCargaHorariaParaOP", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCargaHorariaDadaUnaQna(ByVal IdQnaIni As Short, ByVal IdQnaFin As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQnaIni", SqlDbType.SmallInt),
                                            New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin
                Return _DataCOBAEV.RunProc("SP_SCargaHoraria", Prms, Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function HaTenidoCargaHoraria() As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@HaTenidoCargaHoraria", SqlDbType.Bit)}
                Prms(0).Value = Me._RFC
                Prms(1).Direction = ParameterDirection.InputOutput
                Prms(1).Value = 0
                _DataCOBAEV.RunProc("SP_SCargaHoraria", Prms, Nomina)
                Return Prms(1).Value
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function TienePagosEnSemestreActual() As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = Me._RFC
                Return CBool(_DataCOBAEV.RunProc("SP_SEmpTienePagosEnSemestreActual", Prms, "EmpTienePagosEnSemestreActual", Nomina).Tables(0).Rows(0).Item(0))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCargaHorariaSemestreActual() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@SemestreActual", SqlDbType.Bit)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = True
                Return _DataCOBAEV.RunProc("SP_SCargaHoraria", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CreaCargaHorariaSemestreActual(ByVal IdSemestre As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = IdSemestre
                Return _DataCOBAEV.RunProc("SP_IHorasNuevaCarga", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AgregaHoraInterinaACargaHoraria(ByVal pIdHora As Integer, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int)}

                Prms(0).Value = pIdHora

                Return _DataCOBAEV.RunProc("SP_IHoraInterina", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazaEnSemestre(pRFC As String, pIdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}
                Prms(0).Value = pRFC
                Prms(1).Value = pIdSemestre

                Return _DataCOBAEV.RunProc("SP_SPlazasPorSemestre", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazasVigentes() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = Me._RFC
                Return _DataCOBAEV.RunProc("SP_SEmpleadosPlazas", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazasVigentesHistoria() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = Me._RFC
                Return _DataCOBAEV.RunProc("SP_SEmpleadosPlazasHistoria", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazasVigentesHistoria2() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = Me._RFC
                Return _DataCOBAEV.RunProc("SP_SEmpleadosPlazasHistoria2", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazasVigentesHistoria2(ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = pRFCEmp
                Return _DataCOBAEV.RunProc("SP_SEmpleadosPlazasHistoria2", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazasVigParaBajaPersona(ByVal pRFCEmp As String, ByVal pFechaBaja As Date) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@FechaBaja", SqlDbType.DateTime)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pFechaBaja

                Return _DataCOBAEV.RunProc("SP_SMP_BajaPersonaPlazas", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistoriaAcademica(ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = pRFCEmp
                Return _DataCOBAEV.RunProc("SP_SEstudiosPorEmpleado", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistAcadPorIdEstudio(ByVal pIdEstudio As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEstudio", SqlDbType.Int)}
                Prms(0).Value = pIdEstudio
                Return _DataCOBAEV.RunProc("SP_SEstudiosPorEmpleadoPorIdEstudio", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazasVigentes2(ByVal RFC As String, ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = RFC
                Prms(1).Value = IdQuincena
                Return _DataCOBAEV.RunProc("SP_SEmpleadosPlazas", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EstaVigente(ByVal NumEmp As String, ByVal IdQuincena As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Dim dt As DataTable

                Prms(0).Value = NumEmp
                Prms(1).Value = IdQuincena

                dt = _DataCOBAEV.RunProc("SP_ValidaSiEmpTienePlazasVigentesEnUnaQnaDada", Prms, Table, Nomina)

                Return CBool(dt.Rows(0).Item("Result"))

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EstaVigentePorCURP(ByVal CURPEmp As String, ByVal IdQuincena As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CURPEmp", SqlDbType.NVarChar, 18),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Dim dt As DataTable

                Prms(0).Value = CURPEmp
                Prms(1).Value = IdQuincena

                dt = _DataCOBAEV.RunProc("SP_ValidaSiEmpTienePlazasVigentesEnUnaQnaDada", Prms, Table, Nomina)

                Return CBool(dt.Rows(0).Item("Result"))

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistoria() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = Me._RFC
                Return _DataCOBAEV.RunProc("SP_SHistoriaEmpleado", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistoria(ByVal pRFCEmp As String, ByVal pSoloUltPlaza As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@SoloUltPlaza", SqlDbType.Bit)}
                Prms(0).Value = pRFCEmp
                Prms(1).Value = pSoloUltPlaza

                Return _DataCOBAEV.RunProc("SP_SHistoriaEmpleado2", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizarAntiguedad(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ActualizacionAutomatica", SqlDbType.Bit),
                                            New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@FchIngCOBAEV", SqlDbType.DateTime),
                                            New SqlParameter("@QnaIngCOBAEV", SqlDbType.Int),
                                            New SqlParameter("@AniosAnt", SqlDbType.TinyInt),
                                            New SqlParameter("@MesesAnt", SqlDbType.TinyInt),
                                            New SqlParameter("@DiasAnt", SqlDbType.TinyInt),
                                            New SqlParameter("@CobraPrimaAnt", SqlDbType.Bit),
                                            New SqlParameter("@QuincenaCalculo", SqlDbType.Int)}
                Prms(0).Value = False
                Prms(1).Value = Me._IdEmp
                Prms(2).Value = Me._FchIngCOBAEV
                Prms(3).Value = Me._QnaIngCOBAEV
                Prms(4).Value = Me._AniosAnt
                Prms(5).Value = Me._MesesAnt
                Prms(6).Value = Me._DiasAnt
                Prms(7).Value = Me._CobraPrimaAnt
                Prms(8).Value = Me._QuincenaCalculo

                Return _DataCOBAEV.RunProc("SP_UEmpleadosAntiguedad", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualizar(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Res As Boolean
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@CURPEmp", SqlDbType.NVarChar, 18),
                                            New SqlParameter("@ApePatEmp", SqlDbType.NVarChar, 30),
                                            New SqlParameter("@ApeMatEmp", SqlDbType.NVarChar, 30),
                                            New SqlParameter("@NomEmp", SqlDbType.NVarChar, 30),
                                            New SqlParameter("@EstatusEmp", SqlDbType.TinyInt),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}
                Prms(0).Direction = ParameterDirection.InputOutput
                Prms(0).Value = IIf(TipoOperacion = 1, DBNull.Value, _IdEmp)
                Prms(1).Value = Me._RFC
                Prms(2).Value = Me._CURPEmp
                Prms(3).Value = Me._ApePatEmp
                Prms(4).Value = Me._ApeMatEmp
                Prms(5).Value = Me._NomEmp
                Prms(6).Value = Me._EstatusEmp
                Prms(7).Value = TipoOperacion

                Res = _DataCOBAEV.RunProc("SP_IoUEmpleados", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Me._IdEmp = Prms(0).Value

                Return Res
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Insertar(ByVal ArregloAuditoria() As String) As Boolean
            Return Actualizar(1, ArregloAuditoria)
        End Function
        Public Function InsertarAutorizacionHomologacion(ByVal IdQuincena As Short, ByVal ArregloAuditoria() As String) As Boolean
            Return ActualizarAutorizacionHomologacion(1, IdQuincena, ArregloAuditoria)
        End Function
        Public Function ActualizarAutorizacionHomologacion(ByVal TipoOperacion As Byte, ByVal IdQuincena As Short, ByVal ArregloAuditoria() As String, Optional ByVal IdQuincenaNueva As Short = -1) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                                             New SqlParameter("@IdQuincenaActual", SqlDbType.SmallInt)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQuincena
                Prms(2).Value = TipoOperacion
                If IdQuincenaNueva = -1 Then
                    Prms(3).Value = DBNull.Value
                Else
                    Prms(3).Value = IdQuincenaNueva
                End If

                Return _DataCOBAEV.RunProc("SP_IoUAutorizacionesHomologacion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaAutorizacionHomologacion(ByVal IdQuincena As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_DAutorizacionesHomologacion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizarDatosPersonales(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@IdSexo", SqlDbType.TinyInt),
                                            New SqlParameter("@IdNacionalidad", SqlDbType.TinyInt),
                                            New SqlParameter("@IdEdoCivil", SqlDbType.TinyInt),
                                            New SqlParameter("@IdEdo", SqlDbType.TinyInt),
                                            New SqlParameter("@FecNacEmp", SqlDbType.DateTime),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                                            New SqlParameter("@Email", SqlDbType.NVarChar, 100)}
                Prms(0).Value = _IdEmp
                Prms(1).Value = _IdSexo
                Prms(2).Value = _IdNacionalidad
                Prms(3).Value = _IdEdoCivil
                Prms(4).Value = _IdEdo
                Prms(5).Value = _FecNacEmp
                Prms(6).Value = TipoOperacion
                Prms(7).Value = _Email

                Return _DataCOBAEV.RunProc("SP_IoUEmpleadosDatosPersonales", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertarDatosPersonales(ByVal ArregloAuditoria() As String) As Boolean
            Return ActualizarDatosPersonales(1, ArregloAuditoria)
        End Function
        Public Function ActualizarDatosLaborales(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5),
                                            New SqlParameter("@HomologaEnSemestreA", SqlDbType.Bit),
                                            New SqlParameter("@HomologaEnSemestreB", SqlDbType.Bit),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                                            New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                                            New SqlParameter("@IdCategoriaSemA", SqlDbType.SmallInt),
                                            New SqlParameter("@IdCategoriaSemB", SqlDbType.SmallInt),
                                            New SqlParameter("@IdZonaEcoA", SqlDbType.TinyInt),
                                            New SqlParameter("@IdZonaEcoB", SqlDbType.TinyInt)}

                Prms(0).Value = _IdEmp
                Prms(1).Value = IIf(Me._NumEmp = String.Empty, DBNull.Value, Me._NumEmp.PadLeft(5, "0"))
                Prms(2).Value = Me._HomologaEnSemestreA
                Prms(3).Value = Me._HomologaEnSemestreB
                Prms(4).Value = TipoOperacion
                If Me._IdPlantel = 0 Then
                    Prms(5).Value = DBNull.Value
                Else
                    Prms(5).Value = Me._IdPlantel
                End If
                Prms(6).Value = Me._IdCategoriaSemA
                Prms(7).Value = Me._IdCategoriaSemB
                Prms(8).Value = Me._IdZonaEcoA
                Prms(9).Value = Me._IdZonaEcoB

                Return _DataCOBAEV.RunProc("SP_IoUEmpleadosDatosLaborales", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizarDatosLaborales2(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As String
            Try
                Dim Res As Boolean
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5),
                                            New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}

                Prms(0).Value = _IdEmp
                Prms(1).Direction = ParameterDirection.InputOutput
                Prms(1).Value = IIf(Me._NumEmp = String.Empty, DBNull.Value, Me._NumEmp.PadLeft(5, "0"))
                If Me._IdPlantel = 0 Then
                    Prms(2).Value = DBNull.Value
                Else
                    Prms(2).Value = Me._IdPlantel
                End If
                Prms(3).Value = TipoOperacion

                Res = _DataCOBAEV.RunProc("SP_IoUEmpleadosDatosLaborales2", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Me._NumEmp = Prms(1).Value

                Return Res
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertarDatosLaborales2(ByVal ArregloAuditoria() As String) As Boolean
            Return ActualizarDatosLaborales2(1, ArregloAuditoria)
        End Function
        Public Function ActualizarDatosSegSoc(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@NSS", SqlDbType.NVarChar, 11),
                                            New SqlParameter("@IdRegimenISSSTE", SqlDbType.TinyInt)}

                Prms(0).Value = _IdEmp
                Prms(1).Value = IIf(Me._NSS = String.Empty, DBNull.Value, Me._NSS)
                Prms(2).Value = Me._IdRegimenISSSTE

                Return _DataCOBAEV.RunProc("SP_UEmpleadosDatosSegSoc", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizarDatosPagomatico(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@IdBanco", SqlDbType.TinyInt),
                                            New SqlParameter("@CuentaBancaria", SqlDbType.NVarChar, 18),
                                            New SqlParameter("@IncluirEnPagomatico", SqlDbType.Bit),
                                               New SqlParameter("@Msj", SqlDbType.NVarChar, 500)}
                Dim oAplic As New Aplicacion

                Dim vlResult As Boolean
                Dim vlResult2 As Boolean

                Prms(0).Value = _IdEmp
                Prms(1).Value = Me._IdBanco
                Prms(2).Value = IIf(Me._CuentaBancaria = String.Empty, DBNull.Value, Me._CuentaBancaria)
                Prms(3).Value = Me._IncluirEnPagomatico
                Prms(4).Direction = ParameterDirection.Output

                vlResult = _DataCOBAEV.RunProc("SP_UEmpleadosDatosPagomatico", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                If Prms(4).Value <> String.Empty Then
                    vlResult2 = oAplic.InsMsjsParaUsuarios("SP_UEmpleadosDatosPagomatico", ArregloAuditoria(1), Prms(4).Value)
                End If

                Return vlResult
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertarDatosLaborales(ByVal ArregloAuditoria() As String) As Boolean
            Return ActualizarDatosLaborales(1, ArregloAuditoria)
        End Function
        Public Function ActualizarMamas(ByVal TipoOperacion As Byte, ByVal EsMama As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@EsMama", SqlDbType.Bit),
                                                New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}
                Prms(0).Value = Me._RFC
                Prms(1).Value = EsMama
                Prms(2).Value = TipoOperacion

                Return _DataCOBAEV.RunProc("SP_IoUEmpleadosMamas", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertarMamas(ByVal EsMama As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Return ActualizarMamas(1, EsMama, ArregloAuditoria)
        End Function
        Public Function GenerarRFC() As String
            Dim RetVal As String = ""
            Dim ds As DataSet
            Dim Param As SqlParameter() = {New SqlParameter("@ApePatEmp", SqlDbType.NVarChar, 30),
                New SqlParameter("@ApeMatEmp", SqlDbType.NVarChar, 30),
                New SqlParameter("@NomEmp", SqlDbType.NVarChar, 30),
                New SqlParameter("@FecNacEmp", SqlDbType.DateTime)}
            Param(0).Value = Me._ApePatEmp
            Param(1).Value = Me._ApeMatEmp
            Param(2).Value = Me._NomEmp
            Param(3).Value = Me._FecNacEmp
            Try
                ds = _DataCOBAEV.RunProc("Sp_SGeneraRfc", Param, "GeneraRfc", DataCOBAEV.BD.Nomina)
                If ds.Tables.Count = 1 Then
                    If ds.Tables(0).Rows.Count = 1 Then
                        RetVal = CStr(ds.Tables(0).Rows(0).Item(0))
                    End If
                End If
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
            Return RetVal
        End Function
        Public Function GenerarCURP() As String
            Dim RetVal As String = ""
            Dim ds As DataSet
            Dim Param As SqlParameter() = {New SqlParameter("@ApePatEmp", SqlDbType.NVarChar, 30),
                New SqlParameter("@ApeMatEmp", SqlDbType.NVarChar, 30),
                New SqlParameter("@NomEmp", SqlDbType.NVarChar, 30),
                New SqlParameter("@FecNacEmp", SqlDbType.DateTime),
                New SqlParameter("@IdSexo", SqlDbType.TinyInt),
                New SqlParameter("@IdEdo", SqlDbType.TinyInt)}
            Param(0).Value = Me._ApePatEmp
            Param(1).Value = Me._ApeMatEmp
            Param(2).Value = Me._NomEmp
            Param(3).Value = Me._FecNacEmp
            Param(4).Value = Me.IdSexo
            Param(5).Value = Me.IdEdo
            Try
                ds = _DataCOBAEV.RunProc("Sp_SGeneraCurp", Param, "GeneraCurp", DataCOBAEV.BD.Nomina)
                If ds.Tables.Count = 1 Then
                    If ds.Tables(0).Rows.Count = 1 Then
                        RetVal = CStr(ds.Tables(0).Rows(0).Item(0))
                    End If
                End If
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
            Return RetVal
        End Function
        Public Function ObtenSigNumEmp() As DataRow
            Try
                Return _DataCOBAEV.RunProc("SP_SUltNumEmp", DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFuncion() As Byte
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@FuncionEmpleado", SqlDbType.TinyInt)}
                Prms(0).Value = Me._RFC
                Prms(1).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_SFuncionEmpleado", Prms, DataCOBAEV.BD.Nomina)

                Return Prms(1).Value

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarPorRFC(ByVal RFCEmp As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_SBuscaEmpleadosPorRFC", Prms, DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarPorNumEmp(ByVal NumEmp As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)}

                Prms(0).Value = NumEmp

                Return _DataCOBAEV.RunProc("SP_SBuscaEmpleadosPorNumEmp", Prms, DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
#Region "Clase EmpleadosHijos"
    Public Class EmpleadosHijos
#Region "Clase EmpleadosHijos: Propiedades públicas"
        Public Property IncluirParaCalculo() As Boolean
            Get
                Return Me._IncluirParaCalculo
            End Get
            Set(ByVal Value As Boolean)
                Me._IncluirParaCalculo = Value
            End Set
        End Property
        Public Property RFCEmp() As String
            Get
                Return _RFCEmp
            End Get
            Set(ByVal Value As String)
                _RFCEmp = Value
            End Set
        End Property
        Public Property IdEmpHijo() As Integer
            Get
                Return _IdEmpHijo
            End Get
            Set(ByVal Value As Integer)
                _IdEmpHijo = Value
            End Set
        End Property
        Public Property IdEmp() As Integer
            Get
                Return _IdEmp
            End Get
            Set(ByVal Value As Integer)
                _IdEmp = Value
            End Set
        End Property
        Public Property RFCHijo() As String
            Get
                Return _RFCHijo
            End Get
            Set(ByVal Value As String)
                _RFCHijo = Value
            End Set
        End Property
        Public Property CURPHijo() As String
            Get
                Return _CURPHijo
            End Get
            Set(ByVal Value As String)
                _CURPHijo = Value
            End Set
        End Property
        Public Property ApePatHijo() As String
            Get
                Return _ApePatHijo
            End Get
            Set(ByVal Value As String)
                _ApePatHijo = Value
            End Set
        End Property
        Public Property ApeMatHijo() As String
            Get
                Return _ApeMatHijo
            End Get
            Set(ByVal Value As String)
                _ApeMatHijo = Value
            End Set
        End Property
        Public Property NomHijo() As String
            Get
                Return _NomHijo
            End Get
            Set(ByVal Value As String)
                _NomHijo = Value
            End Set
        End Property
        Public Property FechaNacHijo() As Date
            Get
                Return _FechaNacHijo
            End Get
            Set(ByVal Value As Date)
                _FechaNacHijo = Value
            End Set
        End Property
        Public Property IdSexo() As Byte
            Get
                Return _IdSexo
            End Get
            Set(ByVal Value As Byte)
                _IdSexo = Value
            End Set
        End Property
        Public Property IdEdo() As Byte
            Get
                Return _IdEdo
            End Get
            Set(ByVal Value As Byte)
                _IdEdo = Value
            End Set
        End Property
#End Region
#Region "Clase EmpleadosHijos: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _RFCEmp, _RFCHijo, _CURPHijo, _ApePatHijo, _ApeMatHijo, _NomHijo As String
        Private _IdEmpHijo, _IdEmp As Integer
        Private _FechaNacHijo As Date
        Private _IdSexo, _IdEdo As Byte
        Private _IncluirParaCalculo As Boolean
#End Region
#Region "Clase EmpleadosHijos: Métodos públicos"
        Public Function ObtenHijos() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = Me._RFCEmp
                Prms(1).Value = DBNull.Value
                Return _DataCOBAEV.RunProc("SP_SEmpleadosHijos", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualizar(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@RFCHijo", SqlDbType.NVarChar, 13),
                                            New SqlParameter("@CURPHijo", SqlDbType.NVarChar, 18),
                                            New SqlParameter("@ApePatHijo", SqlDbType.NVarChar, 30),
                                            New SqlParameter("@ApeMatHijo", SqlDbType.NVarChar, 30),
                                            New SqlParameter("@NomHijo", SqlDbType.NVarChar, 30),
                                            New SqlParameter("@FechaNacHijo", SqlDbType.DateTime),
                                            New SqlParameter("@IdSexo", SqlDbType.TinyInt),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                                            New SqlParameter("@IdEmpHijo", SqlDbType.SmallInt),
                                            New SqlParameter("@IdEdo", SqlDbType.TinyInt),
                                            New SqlParameter("@IncluirParaCalculo", SqlDbType.Bit)}
                Prms(0).Value = IIf(Me._RFCEmp = String.Empty, DBNull.Value, Me._RFCEmp)
                Prms(1).Value = IIf(Me._RFCHijo.Trim = String.Empty, DBNull.Value, Me._RFCHijo.ToUpper.Trim)
                Prms(2).Value = IIf(Me._CURPHijo.Trim = String.Empty, DBNull.Value, Me._CURPHijo.ToUpper.Trim)
                Prms(3).Value = Me._ApePatHijo.ToUpper.Trim
                Prms(4).Value = IIf(Me._ApeMatHijo.Trim = String.Empty, DBNull.Value, Me._ApeMatHijo.ToUpper.Trim)
                Prms(5).Value = Me._NomHijo.ToUpper.Trim
                Prms(6).Value = Me._FechaNacHijo
                Prms(7).Value = Me._IdSexo
                Prms(8).Value = TipoOperacion
                Prms(9).Value = IIf(Me._IdEmpHijo = 0, DBNull.Value, Me._IdEmpHijo)
                Prms(10).Value = Me._IdEdo
                Prms(11).Value = Me._IncluirParaCalculo
                Return _DataCOBAEV.RunProc("SP_IoUEmpleadosHijos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Insertar(ByVal ArregloAuditoria() As String) As Boolean
            Return Actualizar(1, ArregloAuditoria)
        End Function
        Public Function ObtenPorId() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmpHijo", SqlDbType.SmallInt)}
                Prms(0).Value = Me._IdEmpHijo
                Return _DataCOBAEV.RunProc("SP_SEmpleadosHijos", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
#Region "Clase EmpleadosDomicilios"
    Public Class EmpleadosDomicilios
#Region "Clase EmpleadosDomicilios: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _CalleDom, _NumExtDom, _NumIntDom, _NomColDom, _CodPosDom As String
        Private _IdEmp, _IdCol, _IdLoc As Integer
        Private _IdMun As Short
        Private _IdEdo As Byte
        Private _ColoniaCapturada As Boolean
#End Region
#Region "Clase EmpleadosDomicilios: Propiedades públicas"
        Public Property IdEmp() As Integer
            Get
                Return Me._IdEmp
            End Get
            Set(ByVal value As Integer)
                Me._IdEmp = value
            End Set
        End Property
        Public Property CalleDom() As String
            Get
                Return Me._CalleDom
            End Get
            Set(ByVal value As String)
                Me._CalleDom = value
            End Set
        End Property
        Public Property NumExtDom() As String
            Get
                Return Me._NumExtDom
            End Get
            Set(ByVal value As String)
                Me._NumExtDom = value
            End Set
        End Property
        Public Property NumIntDom() As String
            Get
                Return Me._NumIntDom
            End Get
            Set(ByVal value As String)
                Me._NumIntDom = value
            End Set
        End Property
        Public Property IdEdo() As Byte
            Get
                Return Me._IdEdo
            End Get
            Set(ByVal value As Byte)
                Me._IdEdo = value
            End Set
        End Property
        Public Property IdMun() As Short
            Get
                Return Me._IdMun
            End Get
            Set(ByVal value As Short)
                Me._IdMun = value
            End Set
        End Property
        Public Property IdLoc() As Integer
            Get
                Return Me._IdLoc
            End Get
            Set(ByVal value As Integer)
                Me._IdLoc = value
            End Set
        End Property
        Public Property IdCol() As Integer
            Get
                Return Me._IdCol
            End Get
            Set(ByVal value As Integer)
                Me._IdCol = value
            End Set
        End Property
        Public Property ColoniaCapturada() As Boolean
            Get
                Return Me._ColoniaCapturada
            End Get
            Set(ByVal value As Boolean)
                Me._ColoniaCapturada = value
            End Set
        End Property
        Public Property NomColDom() As String
            Get
                Return Me._NomColDom
            End Get
            Set(ByVal value As String)
                Me._NomColDom = value
            End Set
        End Property
        Public Property CodPosDom() As String
            Get
                Return Me._CodPosDom
            End Get
            Set(ByVal value As String)
                Me._CodPosDom = value
            End Set
        End Property
#End Region
#Region "Clase EmpleadosDomicilios: Métodos públicos"
        Public Function ActualizarDomicilio(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@CalleDom", SqlDbType.NVarChar, 60),
                                            New SqlParameter("@NumExtDom", SqlDbType.NVarChar, 15),
                                            New SqlParameter("@NumIntDom", SqlDbType.NVarChar, 15),
                                            New SqlParameter("@IdEdo", SqlDbType.TinyInt),
                                            New SqlParameter("@IdMun", SqlDbType.SmallInt),
                                            New SqlParameter("@IdLoc", SqlDbType.Int),
                                            New SqlParameter("@IdCol", SqlDbType.Int),
                                            New SqlParameter("@NomColDom", SqlDbType.NVarChar, 60),
                                            New SqlParameter("@CodPosDom", SqlDbType.NVarChar, 10),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}
                Prms(0).Value = Me._IdEmp
                Prms(1).Value = Me._CalleDom
                Prms(2).Value = Me._NumExtDom
                Prms(3).Value = Me._NumIntDom
                Prms(4).Value = Me._IdEdo
                Prms(5).Value = Me._IdMun
                Prms(6).Value = Me._IdLoc
                If Me.ColoniaCapturada = True Then
                    Prms(7).Value = -1
                    Prms(8).Value = Me._NomColDom
                Else
                    Prms(7).Value = Me._IdCol
                    Prms(8).Value = String.Empty
                End If
                Prms(9).Value = Me._CodPosDom
                Prms(10).Value = TipoOperacion
                Return _DataCOBAEV.RunProc("SP_IoUEmpleadosDomicilios", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizarDomicilioFiscal(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int),
                                            New SqlParameter("@CalleDom", SqlDbType.NVarChar, 60),
                                            New SqlParameter("@NumExtDom", SqlDbType.NVarChar, 15),
                                            New SqlParameter("@NumIntDom", SqlDbType.NVarChar, 15),
                                            New SqlParameter("@IdEdo", SqlDbType.TinyInt),
                                            New SqlParameter("@IdMun", SqlDbType.SmallInt),
                                            New SqlParameter("@IdLoc", SqlDbType.Int),
                                            New SqlParameter("@IdCol", SqlDbType.Int),
                                            New SqlParameter("@NomColDom", SqlDbType.NVarChar, 60),
                                            New SqlParameter("@CodPosDom", SqlDbType.NVarChar, 10),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}
                Prms(0).Value = Me._IdEmp
                Prms(1).Value = Me._CalleDom
                Prms(2).Value = Me._NumExtDom
                Prms(3).Value = Me._NumIntDom
                Prms(4).Value = Me._IdEdo
                Prms(5).Value = Me._IdMun
                Prms(6).Value = Me._IdLoc
                If Me.ColoniaCapturada = True Then
                    Prms(7).Value = -1
                    Prms(8).Value = Me._NomColDom
                Else
                    Prms(7).Value = Me._IdCol
                    Prms(8).Value = String.Empty
                End If
                Prms(9).Value = Me._CodPosDom
                Prms(10).Value = TipoOperacion
                Return _DataCOBAEV.RunProc("SP_IoUEmpleadosDomicilioFiscal", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertarDomicilio(ByVal ArregloAuditoria() As String) As Boolean
            Return ActualizarDomicilio(1, ArregloAuditoria)
        End Function
#End Region
    End Class
#End Region
#Region "Clase InfAcademica"
    Public Class InfAcademica
#Region "Clase InfAcademica: Propiedades públicas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase InfAcademica: Propiedades privadas"

#End Region
#Region "Clase InfAcademica: Métodos públicos"
        Public Function DelEstudiosPorEmpleado(ByVal pIdEstudio As Integer, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEstudio", SqlDbType.Int)}

                Prms(0).Value = pIdEstudio

                Return _DataCOBAEV.RunProc("SP_DEstudiosPorEmpleado", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdEstudiosPorEmpleado(ByVal pIdEstudio As Integer, ByVal pIdNivel As Byte, ByVal pFecha As String, ByVal pIdCarrera As Short,
                                               ByVal pTitulado As Boolean, ByVal pUltNivEstudios As Boolean, ByVal pSiglasINI As String,
                                               ByVal pIncompleta As Boolean, ByVal pCursando As Boolean, ByVal pNumCedProf As String,
                                               ByVal pIdInstEduc As Integer,
                                               ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEstudio", SqlDbType.Int),
                                              New SqlParameter("@IdNivel", SqlDbType.TinyInt),
                                              New SqlParameter("@Fecha", SqlDbType.DateTime),
                                              New SqlParameter("@IdCarrera", SqlDbType.SmallInt),
                                              New SqlParameter("@Titulado", SqlDbType.Bit),
                                              New SqlParameter("@UltNivEstudios", SqlDbType.Bit),
                                              New SqlParameter("@SiglasINI", SqlDbType.NVarChar, 10),
                                              New SqlParameter("@Incompleta", SqlDbType.Bit),
                                              New SqlParameter("@Cursando", SqlDbType.Bit),
                                              New SqlParameter("@NumCedProf", SqlDbType.NVarChar, 20),
                                              New SqlParameter("@IdInstEduc", SqlDbType.Int)}

                Prms(0).Value = pIdEstudio
                Prms(1).Value = pIdNivel
                Prms(2).Value = IIf(IsDate(pFecha), CDate(pFecha), Date.Today)
                Prms(3).Value = pIdCarrera
                Prms(4).Value = pTitulado
                Prms(5).Value = pUltNivEstudios
                Prms(6).Value = pSiglasINI
                Prms(7).Value = pIncompleta
                Prms(8).Value = pCursando
                Prms(9).Value = pNumCedProf
                Prms(10).Value = pIdInstEduc

                Return _DataCOBAEV.RunProc("SP_UEstudiosPorEmpleado", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AddEstudiosPorEmpleado(ByVal pRFCEmp As String, ByVal pIdNivel As Byte, ByVal pFecha As String, ByVal pIdCarrera As Short,
                                               ByVal pTitulado As Boolean, ByVal pUltNivEstudios As Boolean, ByVal pSiglasINI As String,
                                               ByVal pIncompleta As Boolean, ByVal pCursando As Boolean, ByVal pNumCedProf As String,
                                               ByVal pIdInstEduc As Integer,
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@IdNivel", SqlDbType.TinyInt),
                                              New SqlParameter("@Fecha", SqlDbType.DateTime),
                                              New SqlParameter("@IdCarrera", SqlDbType.SmallInt),
                                              New SqlParameter("@Titulado", SqlDbType.Bit),
                                              New SqlParameter("@UltNivEstudios", SqlDbType.Bit),
                                              New SqlParameter("@SiglasINI", SqlDbType.NVarChar, 10),
                                              New SqlParameter("@Incompleta", SqlDbType.Bit),
                                              New SqlParameter("@Cursando", SqlDbType.Bit),
                                              New SqlParameter("@NumCedProf", SqlDbType.NVarChar, 20),
                                              New SqlParameter("@IdInstEduc", SqlDbType.Int)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdNivel
                Prms(2).Value = IIf(IsDate(pFecha), CDate(pFecha), Date.Today)
                Prms(3).Value = pIdCarrera
                Prms(4).Value = pTitulado
                Prms(5).Value = pUltNivEstudios
                Prms(6).Value = pSiglasINI
                Prms(7).Value = pIncompleta
                Prms(8).Value = pCursando
                Prms(9).Value = pNumCedProf
                Prms(10).Value = pIdInstEduc

                Return _DataCOBAEV.RunProc("SP_IEstudiosPorEmpleado", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNiveles() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEstudiosNiveles", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCarrerasPorNivel(ByVal pIdNivel As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdNivel", SqlDbType.TinyInt)}

                Prms(0).Value = pIdNivel

                Return _DataCOBAEV.RunProc("SP_SCarrerasPorNivel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInstitucionesEducativas(ByVal pIdNivel As Integer, ByVal pIdEdo As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdNivel", SqlDbType.TinyInt),
                                                New SqlParameter("@ClaveEntidad", SqlDbType.TinyInt)}

                Prms(0).Value = pIdNivel
                Prms(1).Value = pIdEdo

                Return _DataCOBAEV.RunProc("SP_SInstitucionEducativa", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNivel(ByVal pIdNivel As Byte) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdNivel", SqlDbType.TinyInt)}

                Prms(0).Value = pIdNivel

                Return _DataCOBAEV.RunProc("SP_SEstudiosNivelesPorId", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace