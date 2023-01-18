Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Drawing

Namespace COBAEV.Nominas
#Region "Clase EjercicioFiscal"
    Public Class EjercicioFiscal
#Region "Clase EjercicioFiscal: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _Anio As Short
        Private _Concluido, _PermiteCapturaNoSubsidio, _PermiteCapturaDeConstancias As Boolean
        Private _FechaSAT, _FolioOperacionSAT, _NumEmp As String
        Private _IdEmpFirmante As Integer
#End Region
#Region "Clase EjercicioFiscal: Propiedades públicas"
        Public Property IdEmpFirmante() As Integer
            Get
                Return _IdEmpFirmante
            End Get
            Set(ByVal Value As Integer)
                _IdEmpFirmante = Value
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
        Public Property FolioOperacionSAT() As String
            Get
                Return _FolioOperacionSAT
            End Get
            Set(ByVal Value As String)
                _FolioOperacionSAT = Value
            End Set
        End Property
        Public Property FechaSAT() As String
            Get
                Return _FechaSAT
            End Get
            Set(ByVal Value As String)
                _FechaSAT = Value
            End Set
        End Property
        Public Property PermiteCapturaDeConstancias() As Boolean
            Get
                Return _PermiteCapturaDeConstancias
            End Get
            Set(ByVal Value As Boolean)
                _PermiteCapturaDeConstancias = Value
            End Set
        End Property
        Public Property PermiteCapturaNoSubsidio() As Boolean
            Get
                Return _PermiteCapturaNoSubsidio
            End Get
            Set(ByVal Value As Boolean)
                _PermiteCapturaNoSubsidio = Value
            End Set
        End Property
        Public Property Concluido() As Boolean
            Get
                Return _Concluido
            End Get
            Set(ByVal Value As Boolean)
                _Concluido = Value
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
#End Region
#Region "Clase EjercicioFiscal: Métodos públicos"
        Public Function InsActInfSalariosMinimos(ByVal pIdZonaEco2 As Byte, pImporteSMGNew As Decimal,
                                                        pIdQnaIniNew As Short, pTipoOperacion As Byte, _
                                                        pImporteSMGAct As Decimal, pIdQnaIniAct As Short, _
                                                        pIdQnaFinAct As Short, _
                                                        ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdZonaEco2", SqlDbType.TinyInt), _
                                                New SqlParameter("@ImporteSMGNew", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIniNew", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                                New SqlParameter("@ImporteSMGAct", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIniAct", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQnaFinAct", SqlDbType.SmallInt)}

                Prms(0).Value = pIdZonaEco2
                Prms(1).Value = pImporteSMGNew
                Prms(2).Value = pIdQnaIniNew
                Prms(3).Value = pTipoOperacion
                Prms(4).Value = pImporteSMGAct
                Prms(5).Value = pIdQnaIniAct
                Prms(6).Value = pIdQnaFinAct

                Return _DataCOBAEV.RunProc("SP_IoUSalariosMinimos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSalariosMinimosVigentes() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SSalariosMinimos", Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistSalariosMinimosDadaUnaZonaEco(ByVal pIdZonaEco2 As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdZonaEco2", SqlDbType.TinyInt)}

                Prms(0).Value = pIdZonaEco2

                Return _DataCOBAEV.RunProc("SP_SSalariosMinimos", Prms, Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CreaNuevo(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Return _DataCOBAEV.RunProc("SP_IEjercicioFiscal", DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizarInf(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@Concluido", SqlDbType.Bit), _
                                              New SqlParameter("@FechaSAT", SqlDbType.DateTime), _
                                              New SqlParameter("@FolioOperacionSAT", SqlDbType.NVarChar, 10), _
                                              New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5), _
                                              New SqlParameter("@PermiteCapturaNoSubsidio", SqlDbType.Bit), _
                                              New SqlParameter("@PermiteCapturaDeConstancias", SqlDbType.Bit), _
                                              New SqlParameter("@IdEmpFirmante", SqlDbType.Int)}

                Prms(0).Value = _Anio
                Prms(1).Value = _Concluido
                If IsDate(_FechaSAT) Then
                    Prms(2).Value = CDate(_FechaSAT)
                Else
                    Prms(2).Value = CDate("31/12/2099")
                End If
                Prms(3).Value = _FolioOperacionSAT
                Prms(4).Value = IIf(_NumEmp.Trim = String.Empty, DBNull.Value, _NumEmp)
                Prms(5).Value = _PermiteCapturaNoSubsidio
                Prms(6).Value = _PermiteCapturaDeConstancias
                Prms(7).Value = IIf(_IdEmpFirmante = 0, DBNull.Value, _IdEmpFirmante)

                Return _DataCOBAEV.RunProc("SP_UEjercicioFiscal", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdInfDeAdmonPrestaciones(ByVal pEjercicio As Short, pPermiteCapt1aParteClave125 As Boolean, _
                                                  ByVal pPermiteCapt2aParteClave125 As Boolean, ByVal pPermiteCaptClave181 As Boolean, _
                                                  ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Ejercicio", SqlDbType.SmallInt), _
                                              New SqlParameter("@PermiteCapt1aParteClave125", SqlDbType.Bit), _
                                              New SqlParameter("@PermiteCapt2aParteClave125", SqlDbType.Bit), _
                                              New SqlParameter("@PermiteCaptClave181", SqlDbType.Bit)}

                Prms(0).Value = pEjercicio
                Prms(1).Value = pPermiteCapt1aParteClave125
                Prms(2).Value = pPermiteCapt2aParteClave125
                Prms(3).Value = pPermiteCaptClave181

                Return _DataCOBAEV.RunProc("SP_UAdmonPrestaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEjercicioFiscal", Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfParaAdmonDePrestaciones() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SAdmonPrestaciones", Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTablasImpuestosSubsidio(ByVal Anio As Short, TipoTabla As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@TipoTabla", SqlDbType.NVarChar, 3)}

                Prms(0).Value = Anio
                Prms(1).Value = TipoTabla

                Return _DataCOBAEV.RunProc("SP_STablasImpuestosSubsidio", Prms, Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAños() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEjercicioFiscalAnios", Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDetalles(ByVal Anio As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SEjercicioFiscal", Prms, DataRow, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnas(ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Ejercicio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SQnasDelEjercicioFiscal", Prms, Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAcumuladoPorAnio(ByVal Anio As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SInstitucionalDecAnual", Prms, "InstitucionalDecAnual", DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAcumuladoPorAnioQna(ByVal Anio As Short, ByVal IdQuincena As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = Anio
                Prms(1).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SInstitucionalDecAnual", Prms, "InstitucionalDecAnual", DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraAcumulado(ByVal Anio As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SGeneraAcumuladoParaDecAnual", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraDeclaracionAnual(ByVal Anio As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SCalculaDeclaracionAnual", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function TieneAcumuladoAnual(ByVal Anio As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SExisteAcumuladoAnual", Prms, DataRow, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaSiEmpSolicitoConst(ByVal Ejercicio As Short, ByVal RFCEmp As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Ejercicio", SqlDbType.SmallInt), _
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = Ejercicio
                Prms(1).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_SEmpsExcParaCalculoDeDecAnual", Prms, DataRow, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdEmpsExcParaCalculoDeDecAnual(ByVal RFC As String, ByVal Anio As Short, ByVal SolicitoConstDeSueldos As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13), _
                                            New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                            New SqlParameter("@SolicitoConstDeSueldos", SqlDbType.Bit)}
                Prms(0).Value = RFC
                Prms(1).Value = Anio
                Prms(2).Value = SolicitoConstDeSueldos

                Return _DataCOBAEV.RunProc("SP_IoUEmpsExcParaCalculoDeDecAnual", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenListadoDeEmpsSinAplicDeSubsidio(ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Ejercicio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SEmpsSinAplicDeSubsidioParaEmpleo2", Prms, Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace
