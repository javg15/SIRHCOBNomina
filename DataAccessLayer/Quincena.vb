Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV.Nominas
    Public Class Quincenas
        Private _Anio, _IdQuincena As Short
        Private _Quincena As Integer
        Private _DataCOBAEV As New DataCOBAEV
        Private _Adicional, _IdEstatusQuincena As Byte
        Private _PeriodoVacacional, _AplicarAjusteISPT, _PagoDeRetroactividad, _LiberadaParaPortalAdmvo As Boolean
        Private _FechaDePago, _FechaCierre As Date
        Private _Observaciones, _Observaciones2 As String
        Private _PermiteABCdeRecibos, _Subsidiado As Boolean
        Public Property Subsidiado() As Boolean
            Get
                Return _Subsidiado
            End Get
            Set(ByVal value As Boolean)
                _Subsidiado = value
            End Set
        End Property
        Public Property PermiteABCdeRecibos() As Boolean
            Get
                Return _PermiteABCdeRecibos
            End Get
            Set(ByVal value As Boolean)
                _PermiteABCdeRecibos = value
            End Set

        End Property
        Public Property LiberadaParaPortalAdmvo() As Boolean
            Get
                Return Me._LiberadaParaPortalAdmvo
            End Get
            Set(ByVal value As Boolean)
                Me._LiberadaParaPortalAdmvo = value
            End Set
        End Property
        Public Property PagoDeRetroactividad() As Boolean
            Get
                Return Me._PagoDeRetroactividad
            End Get
            Set(ByVal value As Boolean)
                Me._PagoDeRetroactividad = value
            End Set
        End Property
        Public Property AplicarAjusteISPT() As Boolean
            Get
                Return Me._AplicarAjusteISPT
            End Get
            Set(ByVal value As Boolean)
                Me._AplicarAjusteISPT = value
            End Set
        End Property
        Public Property Anio() As Short
            Get
                Return _Anio
            End Get
            Set(ByVal Value As Short)
                _Anio = Value
            End Set
        End Property
        Public Property Quincena() As Integer
            Get
                Return _Quincena
            End Get
            Set(ByVal Value As Integer)
                _Quincena = Value
            End Set
        End Property
        Public Property Adicional() As Byte
            Get
                Return _Adicional
            End Get
            Set(ByVal Value As Byte)
                _Adicional = Value
            End Set
        End Property
        Public Property IdQuincena() As Short
            Get
                Return _IdQuincena
            End Get
            Set(ByVal Value As Short)
                _IdQuincena = Value
            End Set
        End Property
        Public Property IdEstatusQuincena() As Byte
            Get
                Return _IdEstatusQuincena
            End Get
            Set(ByVal Value As Byte)
                _IdEstatusQuincena = Value
            End Set
        End Property
        Public Property PeriodoVacacional() As Boolean
            Get
                Return _PeriodoVacacional
            End Get
            Set(ByVal Value As Boolean)
                _PeriodoVacacional = Value
            End Set
        End Property
        Public Property FechaDePago() As Date
            Get
                Return _FechaDePago
            End Get
            Set(ByVal Value As Date)
                _FechaDePago = Value
            End Set
        End Property
        Public Property FechaCierre() As Date
            Get
                Return _FechaCierre
            End Get
            Set(ByVal Value As Date)
                _FechaCierre = Value
            End Set
        End Property
        Public Property Observaciones() As String
            Get
                Return _Observaciones
            End Get
            Set(ByVal Value As String)
                _Observaciones = Value
            End Set
        End Property
        Public Property Observaciones2() As String
            Get
                Return _Observaciones2
            End Get
            Set(ByVal Value As String)
                _Observaciones2 = Value
            End Set
        End Property
        Public Function EstaLiberadaParaPortalAdmvo(ByVal pIdQuincena As Short) As Boolean
            Try
                Dim vlResult As Boolean
                Dim dr As DataRow
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdQuincena

                dr = _DataCOBAEV.RunProc("SP_VSiQnaLiberadaParaPortalAdmvo", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                vlResult = dr("Result")

                Return vlResult
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function HayAbiertasParaCapturaDeRecibos() As Boolean
            Try
                Dim vlResult As Boolean
                Dim dr As DataRow

                dr = _DataCOBAEV.RunProc("SP_VSiHayQnasAbiertasParaCapturaDeRecibos", DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                vlResult = dr("Result")

                Return Not vlResult
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function HayAbiertasParaCaptura() As Boolean
            Try
                Dim vlResult As Boolean
                Dim dr As DataRow

                dr = _DataCOBAEV.RunProc("SP_VSiHayQnasAbiertasParaCaptura", DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                vlResult = dr("Result")

                Return Not vlResult
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFechasPorQnaParaMovPers(ByVal pIdQuincena As Short, ByVal pFechaLimiteInferior As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                              New SqlParameter("@FechaLimiteInferior", SqlDbType.NVarChar, 10)}

                Prms(0).Value = pIdQuincena
                Prms(1).Value = pFechaLimiteInferior

                Return _DataCOBAEV.RunProc("SP_SQuincenaFechas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFechasPorQnaParaMovPers(ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SQuincenaFechas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaInicioDeMovPers(ByVal pToparHastaActual As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ToparHastaActual", SqlDbType.Bit)}

                Prms(0).Value = pToparHastaActual

                Return _DataCOBAEV.RunProc("SP_SQnasOrdPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaTerminoDeMovPers(ByVal pAnio As Short, pIdQuincenaLimiteInf As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pAnio
                Prms(1).Value = pIdQuincenaLimiteInf

                Return _DataCOBAEV.RunProc("SP_SQnasOrdPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesParaIniSalariosMinimos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SQnasIniSalariosMinimos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnaActual() As DataRow
            Try
                Return _DataCOBAEV.RunProc("SP_SQnaActual", DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnaParaConsultaDeDatosDeCargaHoraria(ByVal pIdSemestre As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = pIdSemestre
                Return _DataCOBAEV.RunProc("SP_SQnaParaConsultaDeInfSobreHoras", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEmpsParaNotificacionDePagoViaEmail(ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SEmpsParaEnviarEmailDePago", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEmpsParaNotificacionDePagoViaEmail(ByVal pIdQuincena As Short, pNumEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                              New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)}

                Prms(0).Value = pIdQuincena
                Prms(1).Value = pNumEmp

                Return _DataCOBAEV.RunProc("SP_SEmpsParaEnviarEmailDePago", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsAdicional(pIdQuincena As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SQuincenaEsAdicional", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaPorId(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = Me._IdQuincena

                Return _DataCOBAEV.RunProc("SP_DQuincenaPorId", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualizar(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                            New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdEstatusQuincena", SqlDbType.TinyInt), _
                                            New SqlParameter("@PeriodoVacacional", SqlDbType.Bit), _
                                            New SqlParameter("@FechaDePago", SqlDbType.DateTime), _
                                            New SqlParameter("@FechaCierre", SqlDbType.DateTime), _
                                            New SqlParameter("@Observaciones", SqlDbType.NVarChar, 200), _
                                            New SqlParameter("@Observaciones2", SqlDbType.NVarChar, 200), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                            New SqlParameter("@AplicarAjusteISPT", SqlDbType.Bit), _
                                            New SqlParameter("@PagoDeRetroactividad", SqlDbType.Bit), _
                                            New SqlParameter("@LiberadaParaPortalAdmvo", SqlDbType.Bit), _
                                            New SqlParameter("@PermiteABCdeRecibos", SqlDbType.Bit),
                                            New SqlParameter("@Subsidiado", SqlDbType.Bit)}

                Prms(0).Value = _IdQuincena
                Prms(1).Value = _Adicional
                Prms(2).Value = _IdEstatusQuincena
                Prms(3).Value = _PeriodoVacacional
                Prms(4).Value = _FechaDePago
                Prms(5).Value = IIf(_FechaCierre = Nothing, DBNull.Value, _FechaCierre)
                Prms(6).Value = _Observaciones
                Prms(7).Value = _Observaciones2
                Prms(8).Value = TipoOperacion
                Prms(9).Value = _AplicarAjusteISPT
                Prms(10).Value = _PagoDeRetroactividad
                Prms(11).Value = _LiberadaParaPortalAdmvo
                Prms(12).Value = _PermiteABCdeRecibos
                Prms(13).Value = _Subsidiado

                Return _DataCOBAEV.RunProc("SP_IoUQuincenas", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Insertar(ByVal ArregloAuditoria() As String) As Boolean
            Actualizar(1, ArregloAuditoria)
        End Function
        Public Function ObtenFechaFinQuincena(ByVal pIdQuincena As Short, ByVal pInicio_O_Fin As String, pSoloFechaInioFinQna As Boolean) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@Inicio_O_Fin", SqlDbType.NVarChar, 1), _
                                              New SqlParameter("@SoloFechaInioFinQna", SqlDbType.Bit)}

                Prms(0).Value = pIdQuincena
                Prms(1).Value = pInicio_O_Fin
                Prms(2).Value = pSoloFechaInioFinQna

                Return _DataCOBAEV.RunProc("SP_SFechaParaEfectosHoras", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFechaInioFinQna(ByVal pIdQuincena As Short, ByVal pInicio_O_Fin As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IoF", SqlDbType.NVarChar, 1)}

                Prms(0).Value = pIdQuincena
                Prms(1).Value = pInicio_O_Fin

                Return _DataCOBAEV.RunProc("SP_SFechaInioFinQna", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFechaFinQuincena_DEV(ByVal pIdQuincena As Short, ByVal pInicio_O_Fin As String, pSoloFechaInioFinQna As Boolean) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@Inicio_O_Fin", SqlDbType.NVarChar, 1), _
                                              New SqlParameter("@SoloFechaInioFinQna", SqlDbType.Bit)}

                Prms(0).Value = pIdQuincena
                Prms(1).Value = pInicio_O_Fin
                Prms(2).Value = pSoloFechaInioFinQna

                Return _DataCOBAEV.RunProc("SP_SFechaParaEfectosHoras_DEV", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFechasPorQuincena(ByVal IdQuincena As Short, ByVal Inicio_O_Fin As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@Inicio_O_Fin", SqlDbType.NVarChar, 1)}

                Prms(0).Value = IdQuincena
                Prms(1).Value = Inicio_O_Fin

                Return _DataCOBAEV.RunProc("SP_SFechaParaEfectosHoras", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesQnasIniParaHoras(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_SPosiblesQnasIniParaHoras", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesQnasFinParaHoras(ByVal IdSemestre As Short, ByVal IdQuincenaIni As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQuincenaIni", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre
                Prms(1).Value = IdQuincenaIni

                Return _DataCOBAEV.RunProc("SP_SPosiblesQnasFinParaHoras", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesQnasFinParaHoras(ByVal pIdSemestre As Short, ByVal pIdQuincenaIni As Short, pIdHora As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQuincenaIni", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdHora", SqlDbType.Int)}

                Prms(0).Value = pIdSemestre
                Prms(1).Value = pIdQuincenaIni
                Prms(2).Value = pIdHora

                Return _DataCOBAEV.RunProc("SP_SPosiblesQnasFinParaHoras", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesEstatus() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = Me._IdQuincena

                Return _DataCOBAEV.RunProc("SP_SPosiblesEstatusQuincena", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal Adicional As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                        New SqlParameter("@Adicional", SqlDbType.Bit)}

                Prms(0).Value = Me._IdQuincena
                Prms(1).Value = Adicional

                Return _DataCOBAEV.RunProc("SP_SQuincenaPorId", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAnteriorNoAdic() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = Me._IdQuincena

                Return _DataCOBAEV.RunProc("SP_SQnaAntNoAdic", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSiguienteNoAdic(ByVal pIdQuincena As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SQnaSigNoAdic", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenIniParaAdeudo(ByVal NumQnas As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                        New SqlParameter("@NumQnas", SqlDbType.TinyInt)}

                Prms(0).Value = Me._IdQuincena
                Prms(1).Value = NumQnas

                Return _DataCOBAEV.RunProc("SP_SQnaIniParaAdeudo", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenIniParaDevolucion(ByVal NumQnas As Byte) As DataTable
            Try
                Return ObtenIniParaAdeudo(NumQnas)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCalculadasPorAnio(ByVal pAnio As Short, ByVal pMostrarAdicionales As Boolean, _
                                               ByVal pLiberadaParaPortalAdmvo As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                            New SqlParameter("@MostrarAdicionales", SqlDbType.Bit), _
                                              New SqlParameter("@LiberadaParaPortalAdmvo", SqlDbType.Bit)}

                Prms(0).Value = pAnio
                Prms(1).Value = pMostrarAdicionales
                Prms(2).Value = pLiberadaParaPortalAdmvo

                Return _DataCOBAEV.RunProc("SP_SQnasCalculadasPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCalculadasPorAnio(ByVal Anio As Short, ByVal MostrarAdicionales As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                            New SqlParameter("@MostrarAdicionales", SqlDbType.Bit)}

                Prms(0).Value = Anio
                Prms(1).Value = MostrarAdicionales

                Return _DataCOBAEV.RunProc("SP_SQnasCalculadasPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCalculadasPorAnio(ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SQnasCalculadasPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCalculadasPorAnioConFOVISSSTE(ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SQnasCalculadasPorAnioConFOVISSSTE", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCalculadasPorAnioConISSSTE(ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SQnasCalculadasPorAnioConISSSTE", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMesesCalculadosPorAnio(ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SMesesCalculadosPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorAnioParaImpresionDePlantillas(ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SQnasParaImpresionDePlantillas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorSemestre(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_SQuincenasPorSemestre", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenOrdinariasPorSemestre(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                              New SqlParameter("@SoloOrdinarias", SqlDbType.Bit)}

                Prms(0).Value = IdSemestre
                Prms(1).Value = True

                Return _DataCOBAEV.RunProc("SP_SQuincenasPorSemestre", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesParaPago(ByVal IdPlaza As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = IdPlaza

                Return _DataCOBAEV.RunProc("SP_SQnasPosiblesParaBajaDePlaza", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorQuincena() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = True
                Prms(1).Value = Me._IdQuincena

                Return _DataCOBAEV.RunProc("SP_SQuincenas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasPagadasPorEmp(ByVal RFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_SQnasPagadasPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasPagadasPorEmp(ByVal RFCEmp As String, ByVal Anio As Short, Optional ByVal VisibilidadDeQnasAdic As Boolean = True) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                                New SqlParameter("@Anio", SqlDbType.SmallInt),
                                                New SqlParameter("@VisibilidadDeQnasAdic", SqlDbType.Bit)}

                Prms(0).Value = RFCEmp
                Prms(1).Value = Anio
                Prms(2).Value = VisibilidadDeQnasAdic

                Return _DataCOBAEV.RunProc("SP_SQnasPagadasPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAñosConPago(ByVal RFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_SAniosConPagosPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaVigIni(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@EsVigIni", SqlDbType.Bit), _
                                                New SqlParameter("@EsVigFin", SqlDbType.Bit), _
                                                New SqlParameter("@ParaDDL", SqlDbType.Bit), _
                                                New SqlParameter("@QnaVigIni", SqlDbType.Int)}

                Prms(0).Value = True
                Prms(1).Value = False
                Prms(2).Value = ParaDDL
                Prms(3).Value = DBNull.Value

                Return _DataCOBAEV.RunProc("SP_SQuincenas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaVigFin(ByVal IdQnaVigIni As Short, Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@EsVigIni", SqlDbType.Bit), _
                                                New SqlParameter("@EsVigFin", SqlDbType.Bit), _
                                                New SqlParameter("@ParaDDL", SqlDbType.Bit), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = False
                Prms(1).Value = True
                Prms(2).Value = ParaDDL
                Prms(3).Value = IdQnaVigIni

                Return _DataCOBAEV.RunProc("SP_SQuincenas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaVigFin(ByVal IdQuincena As Short, ByVal NumQnas As Int16) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt),
                                                New SqlParameter("@NumQnas", SqlDbType.SmallInt)}

                Prms(0).Value = IdQuincena
                Prms(1).Value = NumQnas

                Return _DataCOBAEV.RunProc("SP_SQnaParaVigFinal", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaAutorizacionHomologacion() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SQnasAutorizacionHomologacion", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenConAdeudos(ByVal IdRol As Byte, ByVal ConsultaZonasEspecificas As Boolean, ByVal ConsultaPlantelesEspecificos As Boolean, ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}

                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = IdRol
                Prms(1).Value = ConsultaZonasEspecificas
                Prms(2).Value = ConsultaPlantelesEspecificos
                Prms(3).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SQnasConAdeudos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenConDevoluciones(ByVal IdRol As Byte, ByVal ConsultaZonasEspecificas As Boolean, ByVal ConsultaPlantelesEspecificos As Boolean, ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = IdRol
                Prms(1).Value = ConsultaZonasEspecificas
                Prms(2).Value = ConsultaPlantelesEspecificos
                Prms(3).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SQnasConDevoluciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenConRetroactivos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SQnasConRetroactivos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAbiertasParaCaptura() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SQuincenasAbiertasParaCaptura", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAbiertasParaCapturaDeRecibos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SQnasAbiertasParaCaptDeRecibos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenListasCalculadas() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                Prms(0).Value = True

                Return _DataCOBAEV.RunProc("SP_SQuincenas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenListasParaCalculo() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit), _
                                                New SqlParameter("@QnasListasParaCalculo", SqlDbType.Bit)}

                Prms(0).Value = True
                Prms(1).Value = True

                Return _DataCOBAEV.RunProc("SP_SQuincenas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesParaInicioPercepcion() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SQnasInicioPercepcion", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaPercProg2(ByVal IdSemestre As Short, ByVal PagarIndividualmente As Boolean, ByVal IdPercepcion As Short, pIdQnaPago As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@PagarIndividualmente", SqlDbType.Bit), _
                                              New SqlParameter("@IdQnaPago", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre
                Prms(1).Value = IdPercepcion
                Prms(2).Value = PagarIndividualmente
                Prms(3).Value = pIdQnaPago

                Return _DataCOBAEV.RunProc("SP_SQnasParaPercProg", Prms, "QnasParaPercProg", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaPercProg(ByVal IdSemestre As Short, ByVal PagarIndividualmente As Boolean, ByVal IdPercepcion As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@PagarIndividualmente", SqlDbType.Bit)}

                Prms(0).Value = IdSemestre
                Prms(1).Value = IdPercepcion
                Prms(2).Value = PagarIndividualmente

                Return _DataCOBAEV.RunProc("SP_SQnasParaPercProg", Prms, "QnasParaPercProg", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaPercRetro(ByVal IdSemestre As Short, ByVal IdPercepcion As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQnaPago", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt)}
                Prms(0).Value = Me._IdQuincena
                Prms(1).Value = IdSemestre
                Prms(2).Value = IdPercepcion

                Return _DataCOBAEV.RunProc("SP_SQnasParaPercRetro", Prms, "QnasParaPercRetro", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAños(ByVal ParaImpresionDeNomina As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaImpresionDeNomina", SqlDbType.Bit)}

                Prms(0).Value = ParaImpresionDeNomina

                Return _DataCOBAEV.RunProc("SP_SAnios", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasFinParaPeriodoDeConsultaDePago(ByVal IdQnaFin As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQnaIni", SqlDbType.SmallInt)}

                Prms(0).Value = IdQnaFin

                Return _DataCOBAEV.RunProc("SP_SQnasPagadasAPartirDeUnaQna", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasFinParaCaptura(ByVal IdQnaFin As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQnaIni", SqlDbType.SmallInt)}

                Prms(0).Value = IdQnaFin

                Return _DataCOBAEV.RunProc("SP_SQnasAPartirDeUnaQna", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAñosParaConsultaDePagos(ByVal ParaConsultaDePagos As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaConsultaDePagos", SqlDbType.Bit)}

                Prms(0).Value = ParaConsultaDePagos

                Return _DataCOBAEV.RunProc("SP_SAnios", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDadaUnaFecha(ByVal pFecha As String, ByVal pFechaIniFin As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Fecha", SqlDbType.DateTime), _
                                              New SqlParameter("@FechaIniFin", SqlDbType.NVarChar, 1)}

                Prms(0).Value = CDate(pFecha)
                Prms(1).Value = pFechaIniFin

                Return _DataCOBAEV.RunProc("SP_SQuincenaDadaUnaFecha", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        'Public Function ObtenParaConsultaDePago() As DataSet
        '    Try
        '        Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

        '        If _Anio = 0 Then
        '            Prms(0).Value = DBNull.Value
        '        Else
        '            Prms(0).Value = _Anio
        '        End If
        '        Return _DataCOBAEV.RunProc("SP_SQnasParaConsultaDePago", Prms, "QnasParaConsultaDePago", DataCOBAEV.BD.Nomina)
        '    Catch ex As Exception
        '        Throw (New System.Exception(ex.Message.ToString))
        '    End Try
        'End Function
    End Class
#Region "Clase Anios"
    Public Class Anios
#Region "Propiedades privadas: Clase Anios"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Propiedades públicas: Clase Anios"

#End Region
#Region "Métodos públicos: Clase Anios"
        Public Function ObtenParaConsultaDeRecibos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SAniosParaConsultaDeRecibos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDesdeInicioCOBACH(ByVal pDesdeInicioCOBACH As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@DesdeInicioCOBACH", SqlDbType.Bit)}

                Prms(0).Value = pDesdeInicioCOBACH

                Return _DataCOBAEV.RunProc("SP_SAnios", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDesdeInicioCOBACH(ByVal pDesdeInicioCOBACH As Boolean, pMayoresQueAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@DesdeInicioCOBACH", SqlDbType.Bit), _
                                              New SqlParameter("@MayoresQueAnio", SqlDbType.SmallInt)}

                Prms(0).Value = pDesdeInicioCOBACH
                Prms(1).Value = pMayoresQueAnio

                Return _DataCOBAEV.RunProc("SP_SAnios", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasOrdinarias(ByVal pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SQnasOrdPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasOrdMayoresOIgualesA(ByVal pAnio As Short, pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pAnio
                Prms(1).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SQnasOrdPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenQnasOrdinariasPagadas(ByVal pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SQnasOrdPagadasPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenConQnasOrdPagadas() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SAniosConQnasOrdPagadas", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace

