Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV.Empleados
#Region "Clase BeneficiariosPensionAlimenticia"
    Public Class BeneficiariosPensionAlimenticia
#Region "Clase BeneficiariosPensionAlimenticia: Propiedades públicas"
        Public Enum TipoBusqueda
            RFC = 0
            Nombre = 1
            NumeroDeEmpleado = 2
            CURP = 3
        End Enum
        Public Property AplicarSoloEnQnasOrd() As Boolean
            Get
                Return _AplicarSoloEnQnasOrd
            End Get
            Set(ByVal Value As Boolean)
                _AplicarSoloEnQnasOrd = Value
            End Set
        End Property
        Public Property IdFormaCalcPA() As Byte
            Get
                Return _IdFormaCalcPA
            End Get
            Set(ByVal Value As Byte)
                _IdFormaCalcPA = Value
            End Set
        End Property
        Public Property MontoFijo() As Decimal
            Get
                Return _MontoFijo
            End Get
            Set(ByVal Value As Decimal)
                _MontoFijo = Value
            End Set
        End Property
        Public Property NumDeSalMin() As Decimal
            Get
                Return _NumDeSalMin
            End Get
            Set(ByVal Value As Decimal)
                _NumDeSalMin = Value
            End Set
        End Property
        Public Property OficioDictamenPA() As String
            Get
                Return _OficioDictamenPA
            End Get
            Set(ByVal value As String)
                _OficioDictamenPA = value
            End Set
        End Property
        Public Property ExpedienteDictamenPA() As String
            Get
                Return _ExpedienteDictamenPA
            End Get
            Set(ByVal value As String)
                _ExpedienteDictamenPA = value
            End Set
        End Property
        Public Property IdBeneficiarioDivision() As Short
            Get
                Return _IdBeneficiarioDivision
            End Get
            Set(ByVal value As Short)
                _IdBeneficiarioDivision = value
            End Set
        End Property
        Public Property CuentaBancaria() As String
            Get
                Return _CuentaBancaria
            End Get
            Set(ByVal value As String)
                _CuentaBancaria = value
            End Set
        End Property
        Public Property CLABE() As String
            Get
                Return _CLABE
            End Get
            Set(ByVal value As String)
                _CLABE = value
            End Set
        End Property
        Public Property IdBancoCLABE() As Byte
            Get
                Return _IdBancoCLABE
            End Get
            Set(ByVal Value As Byte)
                _IdBancoCLABE = Value
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
        Public Property IdBanco2() As Byte
            Get
                Return _IdBanco2
            End Get
            Set(ByVal Value As Byte)
                _IdBanco2 = Value
            End Set
        End Property
        Public Property PagoInterbancario() As Boolean
            Get
                Return _PagoInterbancario
            End Get
            Set(ByVal Value As Boolean)
                _PagoInterbancario = Value
            End Set
        End Property
        Public Property IncluirEnPagomatico() As Boolean
            Get
                Return _IncluirEnPagomatico
            End Get
            Set(ByVal Value As Boolean)
                _IncluirEnPagomatico = Value
            End Set
        End Property
        Public Property IdBeneficiario() As Short
            Get
                Return _IdBeneficiario
            End Get
            Set(ByVal Value As Short)
                _IdBeneficiario = Value
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
        Public Property RFCEmp() As String
            Get
                Return _RFCEmp
            End Get
            Set(ByVal Value As String)
                _RFCEmp = Value
            End Set
        End Property
        Public Property RFCBeneficiario() As String
            Get
                Return _RFCBeneficiario
            End Get
            Set(ByVal Value As String)
                _RFCBeneficiario = Value
            End Set
        End Property
        Public Property CURPBeneficiario() As String
            Get
                Return _CURPBeneficiario
            End Get
            Set(ByVal Value As String)
                _CURPBeneficiario = Value
            End Set
        End Property
        Public Property ApePatBeneficiario() As String
            Get
                Return _ApePatBeneficiario
            End Get
            Set(ByVal Value As String)
                _ApePatBeneficiario = Value
            End Set
        End Property
        Public Property ApeMatBeneficiario() As String
            Get
                Return _ApeMatBeneficiario
            End Get
            Set(ByVal Value As String)
                _ApeMatBeneficiario = Value
            End Set
        End Property
        Public Property NomBeneficiario() As String
            Get
                Return _NomBeneficiario
            End Get
            Set(ByVal Value As String)
                _NomBeneficiario = Value
            End Set
        End Property
        Public Property IdParentesco() As Byte
            Get
                Return _IdParentesco
            End Get
            Set(ByVal Value As Byte)
                _IdParentesco = Value
            End Set
        End Property
        Public Property Porcentaje() As Decimal
            Get
                Return _Porcentaje
            End Get
            Set(ByVal Value As Decimal)
                _Porcentaje = Value
            End Set
        End Property
        Public Property PrioridadCalculo() As Byte
            Get
                Return _PrioridadCalculo
            End Get
            Set(ByVal Value As Byte)
                _PrioridadCalculo = Value
            End Set
        End Property
        Public Property IdQnaIni() As Short
            Get
                Return _IdQnaIni
            End Get
            Set(ByVal Value As Short)
                _IdQnaIni = Value
            End Set
        End Property
        Public Property IdQnaFin() As Short
            Get
                Return _IdQnaFin
            End Get
            Set(ByVal Value As Short)
                _IdQnaFin = Value
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
        Public Property FecNac() As String
            Get
                Return _FecNac
            End Get
            Set(ByVal Value As String)
                _FecNac = Value
            End Set
        End Property
#End Region
#Region "Clase BeneficiariosPensionAlimenticia: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _RFCEmp, _RFCBeneficiario, _CuentaBancaria, _CLABE As String
        Private _NomBeneficiario, _CURPBeneficiario, _ApePatBeneficiario, _ApeMatBeneficiario As String
        Private _IdParentesco, _PrioridadCalculo, _IdSexo, _IdEdo, _IdBanco, _IdBancoCLABE, _IdBanco2 As Byte
        Private _Porcentaje As Decimal
        Private _IdQnaIni, _IdQnaFin, _IdPlantel, _IdBeneficiario, _IdBeneficiarioDivision As Short
        Private _IdEmp As Integer
        Private _FecNac, _OficioDictamenPA, _ExpedienteDictamenPA As String
        Private _IncluirEnPagomatico, _PagoInterbancario As Boolean
        Private _IdFormaCalcPA As Byte
        Private _NumDeSalMin, _MontoFijo As Decimal
        Private _AplicarSoloEnQnasOrd As Boolean
#End Region
#Region "Clase BeneficiariosPensionAlimenticia: Métodos públicos"
        Public Function BuscarBenefPenAlim(pNomEmp As String, ByVal IdRol As Byte, ByVal ConsultaZonasEspecificas As Boolean, ByVal ConsultaPlantelesEspecificos As Boolean, ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@NomBPA", SqlDbType.NVarChar, 90), _
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)
                                            }

                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = pNomEmp
                Prms(1).Value = IdRol
                Prms(2).Value = ConsultaZonasEspecificas
                Prms(3).Value = ConsultaPlantelesEspecificos
                Prms(4).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SBuscaBenefPenAlim", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSiSePuedeModificarInf(ByVal pIdBeneficiarioPA As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBeneficiario", SqlDbType.SmallInt)}
                Dim vlResult As Boolean

                Prms(0).Value = pIdBeneficiarioPA

                vlResult = _DataCOBAEV.RunProc("SP_VRegBenefPensionAlimenticia", Prms, Nomina)

                Return Not vlResult
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenListaDePrioridadDeCalculo() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdBeneficiario", SqlDbType.SmallInt)}
                Prms(0).Value = IIf(Me._RFCEmp = String.Empty, DBNull.Value, Me._RFCEmp)
                Prms(1).Value = IIf(Me._IdBeneficiario = 0, DBNull.Value, Me._IdBeneficiario)
                Return _DataCOBAEV.RunProc("SP_SPrioridadCalculo", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenListaDePrioridadDeCalculo(ByVal pRFCEmp As String, ByVal pTipoOperacion As String, _
                                                       Optional ByVal pIdBeneficiario As Short = 0, _
                                                       Optional ByVal pCopia As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdBeneficiario", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoOperacion", SqlDbType.NVarChar, 1), _
                                                New SqlParameter("@Copia", SqlDbType.Bit)}
                Prms(0).Value = pRFCEmp
                Prms(1).Value = IIf(pIdBeneficiario = 0, DBNull.Value, pIdBeneficiario)
                Prms(2).Value = pTipoOperacion
                Prms(3).Value = pCopia

                Return _DataCOBAEV.RunProc("SP_SPrioridadCalculo", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal pIdBeneficiarioPA As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBeneficiario", SqlDbType.SmallInt)}
                Prms(0).Value = pIdBeneficiarioPA
                Return _DataCOBAEV.RunProc("SP_SBeneficiariosPensionAlimenticia", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBeneficiario", SqlDbType.SmallInt)}
                Prms(0).Value = Me._IdBeneficiario
                Return _DataCOBAEV.RunProc("SP_SBeneficiariosPensionAlimenticia", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenBeneficiariosDePensionAlimenticia(ByVal HistoricoCompleto As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@HistoricoCompleto", SqlDbType.Bit)}
                Prms(0).Value = Me._RFCEmp
                Prms(1).Value = DBNull.Value
                Prms(2).Value = HistoricoCompleto
                Return _DataCOBAEV.RunProc("SP_SBeneficiariosPensionAlimenticia", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenBeneficiariosDePensionAlimenticia() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFC", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = Me._RFCEmp
                Prms(1).Value = DBNull.Value
                Return _DataCOBAEV.RunProc("SP_SBeneficiariosPensionAlimenticia", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Eliminar(ByVal pIdBeneficiario As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBeneficiario", SqlDbType.SmallInt)}

                Prms(0).Value = pIdBeneficiario

                Return _DataCOBAEV.RunProc("SP_DBeneficiarioPensionAlimenticia", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizarVigenciaFinal(ByVal pIdBeneficiario As Short, ByVal pIdQnaFin As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBeneficiario", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}

                Prms(0).Value = pIdBeneficiario
                Prms(1).Value = pIdQnaFin

                Return _DataCOBAEV.RunProc("SP_UBenefPensionAlimenticiaHistoria", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualizar(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                            New SqlParameter("@RFCBenef", SqlDbType.NVarChar, 13), _
                                            New SqlParameter("@CURPBenef", SqlDbType.NVarChar, 18), _
                                            New SqlParameter("@ApePatBenef", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@ApeMatBenef", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@NomBenef", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@IdSexo", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdEdo", SqlDbType.TinyInt), _
                                            New SqlParameter("@FecNac", SqlDbType.DateTime), _
                                            New SqlParameter("@IdParentesco", SqlDbType.TinyInt), _
                                            New SqlParameter("@Porcentaje", SqlDbType.Decimal), _
                                            New SqlParameter("@PrioridadCalculo", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdQnaIni", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdBeneficiario", SqlDbType.SmallInt), _
                                            New SqlParameter("@IncluirEnPagomatico", SqlDbType.Bit), _
                                            New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                            New SqlParameter("@CuentaBancaria", SqlDbType.NVarChar, 18), _
                                            New SqlParameter("@IdBeneficiarioDivision", SqlDbType.SmallInt), _
                                            New SqlParameter("@PagoInterbancario", SqlDbType.Bit), _
                                            New SqlParameter("@IdBancoCLABE", SqlDbType.TinyInt), _
                                            New SqlParameter("@CLABE", SqlDbType.NVarChar, 18), _
                                            New SqlParameter("@IdBanco2", SqlDbType.TinyInt), _
                                            New SqlParameter("@OficioDictamenPA", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@ExpedienteDictamenPA", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@IdFormaCalcPA", SqlDbType.TinyInt), _
                                            New SqlParameter("@NumDeSalMin", SqlDbType.Decimal), _
                                            New SqlParameter("@AplicarSoloEnQnasOrd", SqlDbType.Bit), _
                                            New SqlParameter("@MontoFijo", SqlDbType.Decimal)}

                Prms(0).Value = IIf(Me._RFCEmp = String.Empty, DBNull.Value, Me._RFCEmp)
                Prms(1).Value = IIf(Me._RFCBeneficiario.Trim = String.Empty, DBNull.Value, Me._RFCBeneficiario.ToUpper.Trim)
                Prms(2).Value = IIf(Me._CURPBeneficiario.Trim = String.Empty, DBNull.Value, Me._CURPBeneficiario.ToUpper.Trim)
                Prms(3).Value = Me._ApePatBeneficiario.ToUpper.Trim
                Prms(4).Value = IIf(Me._ApeMatBeneficiario.Trim = String.Empty, DBNull.Value, Me._ApeMatBeneficiario.ToUpper.Trim)
                Prms(5).Value = Me._NomBeneficiario.ToUpper.Trim
                Prms(6).Value = Me._IdSexo
                Prms(7).Value = Me._IdEdo
                If Me._FecNac = String.Empty Then
                    Prms(8).Value = DBNull.Value
                Else
                    Prms(8).Value = CDate(Me._FecNac)
                End If
                Prms(9).Value = _IdParentesco
                Prms(10).Value = _Porcentaje
                Prms(11).Value = _PrioridadCalculo
                Prms(12).Value = _IdQnaIni
                Prms(13).Value = _IdQnaFin
                Prms(14).Value = _IdPlantel
                Prms(15).Value = TipoOperacion
                Prms(16).Value = IIf(_IdBeneficiario = 0, DBNull.Value, _IdBeneficiario)
                Prms(17).Value = _IncluirEnPagomatico
                Prms(18).Value = _IdBanco
                Prms(19).Value = IIf(_CuentaBancaria = String.Empty, "0000000000000000", _CuentaBancaria)
                Prms(20).Value = IIf(_IdBeneficiarioDivision = 0, DBNull.Value, _IdBeneficiarioDivision)
                Prms(21).Value = _PagoInterbancario
                Prms(22).Value = _IdBancoCLABE
                Prms(23).Value = IIf(_CLABE = String.Empty, "000000000000000000", _CLABE)
                Prms(24).Value = _IdBanco2

                Prms(25).Value = IIf(_OficioDictamenPA = String.Empty, DBNull.Value, _OficioDictamenPA)
                Prms(26).Value = IIf(_ExpedienteDictamenPA = String.Empty, DBNull.Value, _ExpedienteDictamenPA)
                Prms(27).Value = _IdFormaCalcPA
                Prms(28).Value = _NumDeSalMin
                Prms(29).Value = _AplicarSoloEnQnasOrd
                Prms(30).Value = _MontoFijo

                Return _DataCOBAEV.RunProc("SP_IoUBeneficiariosPensionAlimenticia", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Insertar(ByVal ArregloAuditoria() As String) As Boolean
            Return Actualizar(1, ArregloAuditoria)
        End Function
        Public Function ObtenUltQnaCobrada(ByVal pIdBeneficiario As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBeneficiario", SqlDbType.SmallInt)}

                Prms(0).Value = pIdBeneficiario

                Return _DataCOBAEV.RunProc("SP_SUltQnaCobradaPorBenefPA", Prms, Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace