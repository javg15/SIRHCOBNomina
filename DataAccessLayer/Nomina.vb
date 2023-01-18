Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Nominas
#Region "Clase Declaración anual"
    Public Class DeclaracionAnual
#Region "Clase Declaración anual: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Declaración anual: Propiedades públicas"
#End Region
#Region "Clase  Declaración anual: Métodos públicos"
        Public Function ObtenSubsidioParaEmpleoAcumulado(ByVal Anio As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SSubsidioEmpleoAcumuladoPorEjercicio", Prms, "SubsidioEmpleoAcumuladoPorEjercicio", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

#Region "Clase Deducción"
    Public Class Deduccion
        Public Enum OrdenDeducciones
            OrdenadasPorClave = 1
            OrdenadasPorNombre = 2
        End Enum
#Region "Clase Deducción: Propiedades privadas"
        Private _IdDeduccion, _IdQnaInicio, _IdQnaFin, _NumQnas, _IdProc As Short
        Private _IdPlaza, _VigIniDeduc, _IdDeducCapturada As Integer
        Private _ImporteDeduccion As Decimal
        Private _DataCOBAEV As New DataCOBAEV
        Private _EspecificarNumQuincenas, _MostrarParaCaptura, _Activa, _EfectosAbiertos, _Masiva As Boolean
        Private _CalcularComoVigente, _IncluirParaNegativos, _DosPorcNomina, _ValidaParaRP As Boolean
        Private _RFCEmp, _NumPrestamoISSSTE, _ClaveDeduccion, _NombreDeduccion, _URL, _Horas As String
        Private _IdAmbitoConcepto, _IdEmpFuncion, _IdZonaEco, _IdClasifDeduc As Byte
        Private _IdDeduccionPadre, _IdPercParaDevol, _IdPercNoOrdParaDevol, _IdTipoDeducSAT As Short
        Private _DeduccionPorLey, _IncluirParaRecibos, _ConceptoIndemnizatorio, _DerivadaDePercsDeducs As Boolean
        Private _IdFormaDePago1A, _IdFormaDePago1D As Byte
        Private _ImporteMaxADescontarDeduc As Decimal
        Private _PorceDescDeduc As Decimal
#End Region
#Region "Clase Deducción: Propiedades públicas"
        Public Property PorceDescDeduc() As Decimal
            Get
                Return _PorceDescDeduc
            End Get
            Set(ByVal Value As Decimal)
                _PorceDescDeduc = Value
            End Set
        End Property
        Public Property ImporteMaxADescontarDeduc() As Decimal
            Get
                Return _ImporteMaxADescontarDeduc
            End Get
            Set(ByVal Value As Decimal)
                _ImporteMaxADescontarDeduc = Value
            End Set
        End Property

        Public Property DerivadaDePercsDeducs() As Boolean
            Get
                Return _DerivadaDePercsDeducs
            End Get
            Set(ByVal Value As Boolean)
                _DerivadaDePercsDeducs = Value
            End Set
        End Property
        Public Property IdTipoDeducSAT() As Short
            Get
                Return _IdTipoDeducSAT
            End Get
            Set(ByVal Value As Short)
                _IdTipoDeducSAT = Value
            End Set
        End Property
        Public Property IdPercNoOrdParaDevol() As Short
            Get
                Return _IdPercNoOrdParaDevol
            End Get
            Set(ByVal Value As Short)
                _IdPercNoOrdParaDevol = Value
            End Set
        End Property
        Public Property IdPercParaDevol() As Short
            Get
                Return _IdPercParaDevol
            End Get
            Set(ByVal Value As Short)
                _IdPercParaDevol = Value
            End Set
        End Property
        Public Property IdFormaDePago1A() As Byte
            Get
                Return Me._IdFormaDePago1A
            End Get
            Set(ByVal Value As Byte)
                Me._IdFormaDePago1A = Value
            End Set
        End Property
        Public Property IdFormaDePago1D() As Byte
            Get
                Return Me._IdFormaDePago1D
            End Get
            Set(ByVal Value As Byte)
                Me._IdFormaDePago1D = Value
            End Set
        End Property
        Public Property ConceptoIndemnizatorio() As Boolean
            Get
                Return _ConceptoIndemnizatorio
            End Get
            Set(ByVal Value As Boolean)
                _ConceptoIndemnizatorio = Value
            End Set
        End Property
        Public Property IncluirParaRecibos() As Boolean
            Get
                Return _IncluirParaRecibos
            End Get
            Set(ByVal Value As Boolean)
                _IncluirParaRecibos = Value
            End Set
        End Property
        Public Property DeduccionPorLey() As Boolean
            Get
                Return _DeduccionPorLey
            End Get
            Set(ByVal Value As Boolean)
                _DeduccionPorLey = Value
            End Set
        End Property
        Public Property IdDeduccionPadre() As Short
            Get
                Return _IdDeduccionPadre
            End Get
            Set(ByVal Value As Short)
                _IdDeduccionPadre = Value
            End Set
        End Property
        Public Property ValidaParaRP() As Boolean
            Get
                Return _ValidaParaRP
            End Get
            Set(ByVal Value As Boolean)
                _ValidaParaRP = Value
            End Set
        End Property
        Public Property DosPorcNomina() As Boolean
            Get
                Return _DosPorcNomina
            End Get
            Set(ByVal Value As Boolean)
                _DosPorcNomina = Value
            End Set
        End Property
        Public Property IdClasifDeduc() As Byte
            Get
                Return Me._IdClasifDeduc
            End Get
            Set(ByVal Value As Byte)
                Me._IdClasifDeduc = Value
            End Set
        End Property
        Public Property IncluirParaNegativos() As Boolean
            Get
                Return _IncluirParaNegativos
            End Get
            Set(ByVal Value As Boolean)
                _IncluirParaNegativos = Value
            End Set
        End Property
        Public Property Horas() As String
            Get
                Return Me._Horas
            End Get
            Set(ByVal Value As String)
                Me._Horas = Value
            End Set
        End Property
        Public Property URL() As String
            Get
                Return Me._URL
            End Get
            Set(ByVal Value As String)
                Me._URL = Value
            End Set
        End Property
        Public Property CalcularComoVigente() As Boolean
            Get
                Return _CalcularComoVigente
            End Get
            Set(ByVal Value As Boolean)
                _CalcularComoVigente = Value
            End Set
        End Property
        Public Property Masiva() As Boolean
            Get
                Return _Masiva
            End Get
            Set(ByVal Value As Boolean)
                _Masiva = Value
            End Set
        End Property
        Public Property IdZonaEco() As Byte
            Get
                Return Me._IdZonaEco
            End Get
            Set(ByVal Value As Byte)
                Me._IdZonaEco = Value
            End Set
        End Property
        Public Property IdEmpFuncion() As Byte
            Get
                Return Me._IdEmpFuncion
            End Get
            Set(ByVal Value As Byte)
                Me._IdEmpFuncion = Value
            End Set
        End Property
        Public Property EfectosAbiertos() As Boolean
            Get
                Return _EfectosAbiertos
            End Get
            Set(ByVal Value As Boolean)
                _EfectosAbiertos = Value
            End Set
        End Property
        Public Property Activa() As Boolean
            Get
                Return _Activa
            End Get
            Set(ByVal Value As Boolean)
                _Activa = Value
            End Set
        End Property
        Public Property IdAmbitoConcepto() As Byte
            Get
                Return Me._IdAmbitoConcepto
            End Get
            Set(ByVal Value As Byte)
                Me._IdAmbitoConcepto = Value
            End Set
        End Property
        Public Property MostrarParaCaptura() As Boolean
            Get
                Return _MostrarParaCaptura
            End Get
            Set(ByVal Value As Boolean)
                _MostrarParaCaptura = Value
            End Set
        End Property
        Public Property IdProc() As Short
            Get
                Return _IdProc
            End Get
            Set(ByVal Value As Short)
                _IdProc = Value
            End Set
        End Property
        Public Property NombreDeduccion() As String
            Get
                Return Me._NombreDeduccion
            End Get
            Set(ByVal Value As String)
                Me._NombreDeduccion = Value
            End Set
        End Property
        Public Property ClaveDeduccion() As String
            Get
                Return Me._ClaveDeduccion
            End Get
            Set(ByVal Value As String)
                Me._ClaveDeduccion = Value
            End Set
        End Property
        Public Property NumPrestamoISSSTE() As String
            Get
                Return Me._NumPrestamoISSSTE
            End Get
            Set(ByVal value As String)
                Me._NumPrestamoISSSTE = value
            End Set
        End Property
        Public Property RFCEmp() As String
            Get
                Return Me._RFCEmp
            End Get
            Set(ByVal value As String)
                Me._RFCEmp = value
            End Set
        End Property
        Public Property IdDeducCapturada() As Integer
            Get
                Return _IdDeducCapturada
            End Get
            Set(ByVal Value As Integer)
                _IdDeducCapturada = Value
            End Set
        End Property
        Public Property IdDeduccion() As Short
            Get
                Return _IdDeduccion
            End Get
            Set(ByVal Value As Short)
                _IdDeduccion = Value
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
        Public Property ImporteDeduccion() As Decimal
            Get
                Return _ImporteDeduccion
            End Get
            Set(ByVal Value As Decimal)
                _ImporteDeduccion = Value
            End Set
        End Property
        Public Property IdQnaInicio() As Short
            Get
                Return _IdQnaInicio
            End Get
            Set(ByVal Value As Short)
                _IdQnaInicio = Value
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
        Public Property EspecificarNumQuincenas() As Boolean
            Get
                Return _EspecificarNumQuincenas
            End Get
            Set(ByVal Value As Boolean)
                _EspecificarNumQuincenas = Value
            End Set
        End Property
        Public Property NumQnas() As Short
            Get
                Return _NumQnas
            End Get
            Set(ByVal Value As Short)
                _NumQnas = Value
            End Set
        End Property
        Public Property VigIniDeduc() As Integer
            Get
                Return _VigIniDeduc
            End Get
            Set(ByVal Value As Integer)
                _VigIniDeduc = Value
            End Set
        End Property
        Public Enum TipoInsercion
            EnCatalogo = 0
            ParaPago = 1
        End Enum
        Public Enum TipoActualizacion
            EnCatalogo = 0
            ParaPago = 1
        End Enum
#End Region
        Public Function InsActInfDeducPorPagoFijo(ByVal pIdDeduccion As Short, ByVal pImporteNew As Decimal, _
                                                 ByVal pIdQnaIniNew As Short, ByVal pTipoOperacion As Byte, _
                                                ByVal pImporteAct As Decimal, ByVal pIdQnaIniAct As Short, _
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                New SqlParameter("@ImporteNew", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIniNew", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                                New SqlParameter("@ImporteAct", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIniAct", SqlDbType.SmallInt)}

                Prms(0).Value = pIdDeduccion
                Prms(1).Value = pImporteNew
                Prms(2).Value = pIdQnaIniNew
                Prms(3).Value = pTipoOperacion
                Prms(4).Value = pImporteAct
                Prms(5).Value = pIdQnaIniAct

                Return _DataCOBAEV.RunProc("SP_IoUDeduccionesPorPagoFijo", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorPagoFijoHistoria(ByVal pIdDeduccion As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdDeduccion

                Return _DataCOBAEV.RunProc("SP_SDeducsPorPagoFijoHistoria", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorPagoFijo() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SDeducsPorPagoFijo", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AddParaCalculoDeDeduccion(ByVal pIdDeduccion As Short, pIdDeduccion2 As Short, _
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdDeduccion2", SqlDbType.SmallInt)}

                Prms(0).Value = pIdDeduccion
                Prms(1).Value = pIdDeduccion2

                Return _DataCOBAEV.RunProc("SP_IDeduccionesParaCalculoDeDeduccion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelParaCalculoDeDeduccion(ByVal pIdDeduccion As Short, pIdDeduccion2 As Short, _
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdDeduccion2", SqlDbType.SmallInt)}

                Prms(0).Value = pIdDeduccion
                Prms(1).Value = pIdDeduccion2

                Return _DataCOBAEV.RunProc("SP_DDeduccionesParaCalculoDeDeduccion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AddParaCalculoDePercepcion(ByVal pIdDeduccion As Short, pIdPercepcion As Short, _
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdDeduccion
                Prms(1).Value = pIdPercepcion

                Return _DataCOBAEV.RunProc("SP_IDeduccionesParaCalculoDePercepcion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelParaCalculoDePercepcion(ByVal pIdDeduccion As Short, pIdPercepcion As Short, _
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdDeduccion
                Prms(1).Value = pIdPercepcion

                Return _DataCOBAEV.RunProc("SP_DDeduccionesParaCalculoDePercepcion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenPercsDeducsParaSuCalculo(pIdDeduccion As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdDeduccion

                Return _DataCOBAEV.RunProc("SP_STblsDePercsDeducsParaCalcDeDeduc", Prms, "dsPercsDeducs", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenActivasDerivadaDePercsDeducs(Optional pTipoOrden As String = "CLAVE") As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@TipoOrden", SqlDbType.NVarChar, 20), _
                                              New SqlParameter("@DerivadaDePercsDeducs", SqlDbType.Bit)}

                Prms(0).Value = pTipoOrden
                Prms(1).Value = True

                Return _DataCOBAEV.RunProc("SP_SDeduccionesActivas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenSoloActivas(Optional pTipoOrden As String = "CLAVE") As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@TipoOrden", SqlDbType.NVarChar, 20)}

                Return _DataCOBAEV.RunProc("SP_SDeduccionesActivas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaInf(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveDeduccion", SqlDbType.NVarChar, 3), _
                                                    New SqlParameter("@NombreDeduccion", SqlDbType.NVarChar, 40), _
                                                    New SqlParameter("@IdProc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@MostrarParaCaptura", SqlDbType.Bit), _
                                                    New SqlParameter("@IdAmbitoConcepto", SqlDbType.TinyInt), _
                                                    New SqlParameter("@Activa", SqlDbType.Bit), _
                                                    New SqlParameter("@EfectosAbiertos", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdZonaEco", SqlDbType.TinyInt), _
                                                    New SqlParameter("@Masiva", SqlDbType.Bit), _
                                                    New SqlParameter("@CalcularComoVigente", SqlDbType.Bit), _
                                                    New SqlParameter("@URL", SqlDbType.NVarChar, 50), _
                                                    New SqlParameter("@Horas", SqlDbType.Char, 1), _
                                                    New SqlParameter("@IdClasifDeduc", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IncluirParaNegativos", SqlDbType.Bit), _
                                                    New SqlParameter("@DosPorcNomina", SqlDbType.Bit), _
                                                    New SqlParameter("@ValidaParaRP", SqlDbType.Bit), _
                                                    New SqlParameter("@IdDeduccionPadre", SqlDbType.SmallInt), _
                                                    New SqlParameter("@DeduccionPorLey", SqlDbType.Bit), _
                                                    New SqlParameter("@IncluirParaRecibos", SqlDbType.Bit), _
                                                    New SqlParameter("@ConceptoIndemnizatorio", SqlDbType.Bit), _
                                                    New SqlParameter("@IdPercParaDevol", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdFormaDePago1A", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdFormaDePago1D", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPercNoOrdParaDevol", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdTipoDeducSAT", SqlDbType.SmallInt), _
                                                    New SqlParameter("@DerivadaDePercsDeducs", SqlDbType.Bit)
                                              }

                Prms(0).Value = Me._ClaveDeduccion
                Prms(1).Value = Me._NombreDeduccion
                Prms(2).Value = Me._IdProc
                Prms(3).Value = Me._MostrarParaCaptura
                Prms(4).Value = Me._IdAmbitoConcepto
                Prms(5).Value = Me._Activa
                Prms(6).Value = Me._EfectosAbiertos
                Prms(7).Value = Me._NumQnas
                Prms(8).Value = Me._IdEmpFuncion
                Prms(9).Value = Me._IdZonaEco
                Prms(10).Value = Me._Masiva
                Prms(11).Value = Me.CalcularComoVigente
                Prms(12).Value = IIf(Me._URL = String.Empty, DBNull.Value, Me._URL)
                Prms(13).Value = Me._Horas
                Prms(14).Value = Me._IdClasifDeduc
                Prms(15).Value = Me._IncluirParaNegativos
                Prms(16).Value = Me._DosPorcNomina
                Prms(17).Value = Me._ValidaParaRP
                Prms(18).Value = Me._IdDeduccionPadre
                Prms(19).Value = Me._DeduccionPorLey
                Prms(20).Value = Me._IncluirParaRecibos
                Prms(21).Value = Me._ConceptoIndemnizatorio
                Prms(22).Value = Me._IdPercParaDevol
                Prms(23).Value = Me._IdFormaDePago1A
                Prms(24).Value = Me._IdFormaDePago1D
                Prms(25).Value = Me._IdDeduccion
                Prms(26).Value = Me._IdPercNoOrdParaDevol
                Prms(27).Value = Me._IdTipoDeducSAT
                Prms(28).Value = Me._DerivadaDePercsDeducs

                Return _DataCOBAEV.RunProc("SP_UDeduccion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CrearNueva(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveDeduccion", SqlDbType.NVarChar, 3), _
                                                    New SqlParameter("@NombreDeduccion", SqlDbType.NVarChar, 40), _
                                                    New SqlParameter("@IdProc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@MostrarParaCaptura", SqlDbType.Bit), _
                                                    New SqlParameter("@IdAmbitoConcepto", SqlDbType.TinyInt), _
                                                    New SqlParameter("@Activa", SqlDbType.Bit), _
                                                    New SqlParameter("@EfectosAbiertos", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdZonaEco", SqlDbType.TinyInt), _
                                                    New SqlParameter("@Masiva", SqlDbType.Bit), _
                                                    New SqlParameter("@CalcularComoVigente", SqlDbType.Bit), _
                                                    New SqlParameter("@URL", SqlDbType.NVarChar, 50), _
                                                    New SqlParameter("@Horas", SqlDbType.Char, 1), _
                                                    New SqlParameter("@IdClasifDeduc", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IncluirParaNegativos", SqlDbType.Bit), _
                                                    New SqlParameter("@DosPorcNomina", SqlDbType.Bit), _
                                                    New SqlParameter("@ValidaParaRP", SqlDbType.Bit), _
                                                    New SqlParameter("@IdDeduccionPadre", SqlDbType.SmallInt), _
                                                    New SqlParameter("@DeduccionPorLey", SqlDbType.Bit), _
                                                    New SqlParameter("@IncluirParaRecibos", SqlDbType.Bit), _
                                                    New SqlParameter("@ConceptoIndemnizatorio", SqlDbType.Bit), _
                                                    New SqlParameter("@IdPercParaDevol", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdFormaDePago1A", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdFormaDePago1D", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdPercNoOrdParaDevol", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdTipoDeducSAT", SqlDbType.SmallInt), _
                                                    New SqlParameter("@DerivadaDePercsDeducs", SqlDbType.Bit)
                                              }

                Prms(0).Value = Me._ClaveDeduccion
                Prms(1).Value = Me._NombreDeduccion
                Prms(2).Value = Me._IdProc
                Prms(3).Value = Me._MostrarParaCaptura
                Prms(4).Value = Me._IdAmbitoConcepto
                Prms(5).Value = Me._Activa
                Prms(6).Value = Me._EfectosAbiertos
                Prms(7).Value = Me._NumQnas
                Prms(8).Value = Me._IdEmpFuncion
                Prms(9).Value = Me._IdZonaEco
                Prms(10).Value = Me._Masiva
                Prms(11).Value = Me.CalcularComoVigente
                Prms(12).Value = IIf(Me._URL = String.Empty, DBNull.Value, Me._URL)
                Prms(13).Value = Me._Horas
                Prms(14).Value = Me._IdClasifDeduc
                Prms(15).Value = Me._IncluirParaNegativos
                Prms(16).Value = Me._DosPorcNomina
                Prms(17).Value = Me._ValidaParaRP
                Prms(18).Value = Me._IdDeduccionPadre
                Prms(19).Value = Me._DeduccionPorLey
                Prms(20).value = Me._IncluirParaRecibos
                Prms(21).Value = Me._ConceptoIndemnizatorio
                Prms(22).Value = Me._IdPercParaDevol
                Prms(23).Value = Me._IdFormaDePago1A
                Prms(24).Value = Me._IdFormaDePago1D
                Prms(25).Value = Me._IdPercNoOrdParaDevol
                Prms(26).Value = Me._IdTipoDeducSAT
                Prms(27).Value = Me._DerivadaDePercsDeducs

                Return _DataCOBAEV.RunProc("SP_INuevaDeduccion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenClasifSAT() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SCatalogoTipoDeducsSAT", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenClasifInterna() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SClasificacionDeducciones", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenParaDeducPadre(pParaDeducPadre As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDeducPadre", SqlDbType.Bit)}

                Prms(0).Value = pParaDeducPadre

                Return _DataCOBAEV.RunProc("SP_SDeducciones2", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#Region "Clase Deducción: Métodos públicos"
        Public Function ObtenParaUpdate(pIdDeduccion As Short, pParaUpdate As Boolean) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                              New SqlParameter("@ParaUpdate", SqlDbType.Bit)}

                Prms(0).Value = pIdDeduccion
                Prms(1).Value = pParaUpdate

                Return _DataCOBAEV.RunProc("SP_SDeduccionPorId", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNuevaClave() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SNuevaClaveDeduccion", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenTodasParaABC(pOrdenDeducs As OrdenDeducciones) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Orden", SqlDbType.TinyInt)}

                Prms(0).Value = pOrdenDeducs

                Return _DataCOBAEV.RunProc("SP_SDeducciones2", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFormasDePago() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SFormasDePago", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaRelacionarConPercepcion() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@DevolverSoloNoOrd", SqlDbType.Bit)}

                Prms(0).Value = True

                Return _DataCOBAEV.RunProc("SP_SDeducciones2", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function TieneNumPrestamoISSSTE(pCURPEmp As String, pNumPrestamoISSSTE As String, pIdDeduccion As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CURPEmp", SqlDbType.NVarChar, 18), _
                                              New SqlParameter("@NumPrestamoISSSTE", SqlDbType.NVarChar, 18), _
                                              New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}
                Dim dr As DataRow

                Prms(0).Value = pCURPEmp
                Prms(1).Value = pNumPrestamoISSSTE
                Prms(2).Value = pIdDeduccion

                dr = _DataCOBAEV.RunProc("SP_VSiEmpTieneNumPrestamoISSSTERegistrado", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("Result"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function TieneNumPrestamoISSSTEVigente(pCURPEmp As String, pNumPrestamoISSSTE As String, pIdQnaAbiertaParaCaptura As Short, pIdDeduccion As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CURPEmp", SqlDbType.NVarChar, 18), _
                                              New SqlParameter("@NumPrestamoISSSTE", SqlDbType.NVarChar, 18), _
                                              New SqlParameter("@IdQnaAbiertaParaCaptura", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}
                Dim dr As DataRow

                Prms(0).Value = pCURPEmp
                Prms(1).Value = pNumPrestamoISSSTE
                Prms(2).Value = pIdQnaAbiertaParaCaptura
                Prms(3).Value = pIdDeduccion

                dr = _DataCOBAEV.RunProc("SP_VSiEmpTieneNumPrestamoISSSTERegistrado", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("Result"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function TienePrestamoISSSTEVigente(pCURPEmp As String, pIdQnaVigIniDeduc As Short, pIdQnaVigFinDeduc As Short, pIdDeduccion As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CURPEmp", SqlDbType.NVarChar, 18), _
                                              New SqlParameter("@IdQnaVigIniDeduc", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdQnaVigFinDeduc", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}
                Dim dr As DataRow

                Prms(0).Value = pCURPEmp
                Prms(1).Value = pIdQnaVigIniDeduc
                Prms(2).Value = pIdQnaVigFinDeduc
                Prms(3).Value = pIdDeduccion

                dr = _DataCOBAEV.RunProc("SP_VSiEmpTienePrestamoISSSTEVigente", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("Result"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDiferentesPorcDescClave434() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SDifPorcDescClave434", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistoria(ByVal RFCEmp As String) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_SDeduccionesHistoria", Prms, "DeduccionesHistoria", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Elimina(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeducCapturada", SqlDbType.Int), _
                                                New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = Me._IdDeducCapturada
                Prms(1).Value = Me._IdPlaza
                Prms(2).Value = Me._IdDeduccion
                Prms(3).Value = Me._RFCEmp

                Return _DataCOBAEV.RunProc("SP_DDeducciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCapturadasPorEmpleado(ByVal RFCEmp As String, ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = RFCEmp
                Prms(1).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SDeducciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorIdDeCaptura() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeducCapturada", SqlDbType.Int), _
                                                New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = Me._IdDeducCapturada
                Prms(1).Value = Me._IdDeduccion
                Prms(2).Value = Me._IdPlaza

                Return _DataCOBAEV.RunProc("SP_SDeducciones", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaPrestamoISSSTE(ByVal TipoInsercion As TipoInsercion, ByVal ArregloAuditoria() As String) As Boolean
            Try
                If TipoInsercion = Deduccion.TipoInsercion.ParaPago Then
                    Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                    New SqlParameter("@ImporteDeduccion", SqlDbType.Decimal), _
                                                    New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                    New SqlParameter("@EspecificarNumQuincenas", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.SmallInt), _
                                                    New SqlParameter("@TipoInsercion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@NumPrestamoISSSTE", SqlDbType.NVarChar, 11)
                                                 }

                    Prms(0).Value = Me._IdDeduccion
                    Prms(1).Value = Me._IdPlaza
                    Prms(2).Value = Me._ImporteDeduccion
                    Prms(3).Value = Me._IdQnaInicio
                    Prms(4).Value = Me._IdQnaFin
                    Prms(5).Value = Me._EspecificarNumQuincenas
                    Prms(6).Value = Me._NumQnas
                    Prms(7).Value = TipoInsercion
                    Prms(8).Value = Me._NumPrestamoISSSTE

                    Return _DataCOBAEV.RunProc("SP_IDeducciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
                End If
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Inserta2(ByVal TipoInsercion As TipoInsercion, ByVal ArregloAuditoria() As String) As Boolean
            Try
                If TipoInsercion = Deduccion.TipoInsercion.ParaPago Then
                    Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                    New SqlParameter("@ImporteDeduccion", SqlDbType.Decimal), _
                                                    New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                    New SqlParameter("@EspecificarNumQuincenas", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@TipoInsercion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@NumPrestamoISSSTE", SqlDbType.NVarChar, 11), _
                                                    New SqlParameter("@PorceDescDeduc", SqlDbType.Decimal), _
                                                    New SqlParameter("@ImporteMaxADescontarDeduc", SqlDbType.Decimal)
                                                 }

                    Prms(0).Value = _IdDeduccion
                    Prms(1).Value = _IdPlaza
                    Prms(2).Value = _ImporteDeduccion
                    Prms(3).Value = _IdQnaInicio
                    Prms(4).Value = _IdQnaFin
                    Prms(5).Value = _EspecificarNumQuincenas
                    Prms(6).Value = _NumQnas
                    Prms(7).Value = TipoInsercion
                    Prms(8).Value = _NumPrestamoISSSTE
                    Prms(9).Value = PorceDescDeduc
                    Prms(10).Value = ImporteMaxADescontarDeduc

                    Return _DataCOBAEV.RunProc("SP_IDeducciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
                End If
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Inserta(ByVal TipoInsercion As TipoInsercion, ByVal ArregloAuditoria() As String) As Boolean
            Try
                If TipoInsercion = Deduccion.TipoInsercion.ParaPago Then
                    Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                    New SqlParameter("@ImporteDeduccion", SqlDbType.Decimal), _
                                                    New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                    New SqlParameter("@EspecificarNumQuincenas", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@TipoInsercion", SqlDbType.TinyInt)}

                    Prms(0).Value = Me._IdDeduccion
                    Prms(1).Value = Me._IdPlaza
                    Prms(2).Value = Me._ImporteDeduccion
                    Prms(3).Value = Me._IdQnaInicio
                    Prms(4).Value = Me._IdQnaFin
                    Prms(5).Value = Me._EspecificarNumQuincenas
                    Prms(6).Value = Me._NumQnas
                    Prms(7).Value = TipoInsercion

                    Return _DataCOBAEV.RunProc("SP_IDeducciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
                End If
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsMasiva(ByVal TipoInsercion As TipoInsercion, ByVal NumEmp As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                If TipoInsercion = Deduccion.TipoInsercion.ParaPago Then
                    Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@ImporteDeduccion", SqlDbType.Decimal), _
                                                    New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                    New SqlParameter("@TipoInsercion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)}

                    Prms(0).Value = Me._IdDeduccion
                    Prms(1).Value = Me._ImporteDeduccion
                    Prms(2).Value = Me._IdQnaInicio
                    Prms(3).Value = Me._IdQnaFin
                    Prms(4).Value = TipoInsercion
                    Prms(5).Value = NumEmp

                    Return _DataCOBAEV.RunProc("SP_IDeducciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
                End If
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsMasivaClave431(ByVal pTipoOrden As String, ByVal pCURPEmp As String, ByVal ArregloAuditoria() As String) As Boolean
            Try

                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                New SqlParameter("@ImporteDeduccion", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoOrden", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@CURPEmp", SqlDbType.NVarChar, 18), _
                                                New SqlParameter("@NumPrestamoISSSTE", SqlDbType.NVarChar, 11)}

                Prms(0).Value = Me._IdDeduccion
                Prms(1).Value = Me._ImporteDeduccion
                Prms(2).Value = Me._IdQnaInicio
                Prms(3).Value = Me._IdQnaFin
                Prms(4).Value = pTipoOrden
                Prms(5).Value = pCURPEmp
                Prms(6).Value = IIf(Me._NumPrestamoISSSTE.Trim = "", DBNull.Value, Me._NumPrestamoISSSTE.Trim)

                Return _DataCOBAEV.RunProc("SP_IDeduccion431", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelMasiva(ByVal IdDeduccion As Short, ByVal IdQnaIni As Short, ByVal IdQnaFin As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaIni", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}

                Prms(0).Value = IdDeduccion
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin

                Return _DataCOBAEV.RunProc("SP_DDeducsCaptMasivamente", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdPrestamoISSSTE(ByVal TipoActualizacion As TipoActualizacion, ByVal ArregloAuditoria() As String) As Boolean
            Try
                If TipoActualizacion = Deduccion.TipoInsercion.ParaPago Then
                    Dim Prms As SqlParameter() = {New SqlParameter("@IdDeducCapturada", SqlDbType.Int), _
                                                    New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                    New SqlParameter("@ImporteDeduccion", SqlDbType.Decimal), _
                                                    New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                    New SqlParameter("@EspecificarNumQuincenas", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.SmallInt), _
                                                    New SqlParameter("@TipoActualizacion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@NumPrestamoISSSTE", SqlDbType.NVarChar, 11)
                                                  }

                    Prms(0).Value = Me._IdDeducCapturada
                    Prms(1).Value = Me._IdDeduccion
                    Prms(2).Value = Me._IdPlaza
                    Prms(3).Value = Me._ImporteDeduccion
                    Prms(4).Value = Me._IdQnaInicio
                    Prms(5).Value = Me._IdQnaFin
                    Prms(6).Value = Me._EspecificarNumQuincenas
                    Prms(7).Value = Me._NumQnas
                    Prms(8).Value = TipoActualizacion
                    Prms(9).Value = IIf(Me._NumPrestamoISSSTE Is Nothing, DBNull.Value, Me._NumPrestamoISSSTE)

                    Return _DataCOBAEV.RunProc("SP_UDeducciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
                End If
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualiza2(ByVal TipoActualizacion As TipoActualizacion, ByVal ArregloAuditoria() As String) As Boolean
            Try
                If TipoActualizacion = Deduccion.TipoInsercion.ParaPago Then
                    Dim Prms As SqlParameter() = {New SqlParameter("@IdDeducCapturada", SqlDbType.Int), _
                                                    New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                    New SqlParameter("@ImporteDeduccion", SqlDbType.Decimal), _
                                                    New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                    New SqlParameter("@EspecificarNumQuincenas", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@TipoActualizacion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@NumPrestamoISSSTE", SqlDbType.NVarChar, 11), _
                                                    New SqlParameter("@PorceDescDeduc", SqlDbType.Decimal), _
                                                    New SqlParameter("@ImporteMaxADescontarDeduc", SqlDbType.Decimal)
                                                  }

                    Prms(0).Value = Me._IdDeducCapturada
                    Prms(1).Value = Me._IdDeduccion
                    Prms(2).Value = Me._IdPlaza
                    Prms(3).Value = Me._ImporteDeduccion
                    Prms(4).Value = Me._IdQnaInicio
                    Prms(5).Value = Me._IdQnaFin
                    Prms(6).Value = Me._EspecificarNumQuincenas
                    Prms(7).Value = Me._NumQnas
                    Prms(8).Value = TipoActualizacion
                    Prms(9).Value = IIf(Me._NumPrestamoISSSTE Is Nothing, DBNull.Value, Me._NumPrestamoISSSTE)
                    Prms(10).Value = PorceDescDeduc
                    Prms(11).Value = ImporteMaxADescontarDeduc

                    Return _DataCOBAEV.RunProc("SP_UDeducciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
                End If
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualiza(ByVal TipoActualizacion As TipoActualizacion, ByVal ArregloAuditoria() As String) As Boolean
            Try
                If TipoActualizacion = Deduccion.TipoInsercion.ParaPago Then
                    Dim Prms As SqlParameter() = {New SqlParameter("@IdDeducCapturada", SqlDbType.Int), _
                                                    New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                    New SqlParameter("@ImporteDeduccion", SqlDbType.Decimal), _
                                                    New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                    New SqlParameter("@EspecificarNumQuincenas", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@TipoActualizacion", SqlDbType.TinyInt)
                                                  }

                    Prms(0).Value = Me._IdDeducCapturada
                    Prms(1).Value = Me._IdDeduccion
                    Prms(2).Value = Me._IdPlaza
                    Prms(3).Value = Me._ImporteDeduccion
                    Prms(4).Value = Me._IdQnaInicio
                    Prms(5).Value = Me._IdQnaFin
                    Prms(6).Value = Me._EspecificarNumQuincenas
                    Prms(7).Value = Me._NumQnas
                    Prms(8).Value = TipoActualizacion

                    Return _DataCOBAEV.RunProc("SP_UDeducciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
                End If
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}

                Prms(0).Value = _IdDeduccion

                Return _DataCOBAEV.RunProc("SP_SDeducciones", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal pIdDeduccion As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdDeduccion

                Return _DataCOBAEV.RunProc("SP_SDeduccionPorId", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DeducCaptPermiteABC(ByVal pRFCEmp As String, ByVal pIdDeducCapturada As Integer, ByVal pIdDeduccion As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdDeducCapturada", SqlDbType.Int), _
                                                New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdDeducCapturada
                Prms(2).Value = pIdDeduccion

                Return _DataCOBAEV.RunProc("SP_VSiDeducCaptPermiteABC", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
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
                    dt = _DataCOBAEV.RunProc("SP_SDeducciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_SDeducciones", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorRol(ByVal IdRol As Byte) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt)}

                Prms(0).Value = IdRol
                dt = _DataCOBAEV.RunProc("SP_SDeduccionesPorRol", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAplicadasPorEmp(ByVal RFCEmp As String) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = RFCEmp
                dt = _DataCOBAEV.RunProc("SP_SDeduccionesAplicadasPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAplicadasPorQuincena(ByVal IdRol As Byte, ByVal IdQuincena As Short) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = IdRol
                Prms(1).Value = IdQuincena

                dt = _DataCOBAEV.RunProc("SP_SDeduccionesQuincenalesPorRol", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMasivas(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                If ParaDDL Then
                    Prms(0).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_SDeduccionesMasivas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_SDeduccionesMasivas", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfParaCaptura(ByVal RFCEmp As String, ByVal IdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                                New SqlParameter("@ObtenInfParaCaptura", SqlDbType.Bit), _
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = _IdDeduccion
                Prms(1).Value = True
                Prms(2).Value = RFCEmp
                Prms(3).Value = IdPlaza

                Return _DataCOBAEV.RunProc("SP_SDeducciones", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EmpsConPrestHipFOVISSSTE() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEmpsConClave434", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdPrestamoISSSTE(pNumPrestamoISSSTE As String, ByVal pIdEmp As Integer, pIdQnaIni As Short, pIdQnaFin As Short, _
                                          pIdDeduccion As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumPrestamoISSSTE", SqlDbType.NVarChar, 11), _
                                              New SqlParameter("@IdEmp", SqlDbType.Int), _
                                              New SqlParameter("@IdQnaIni", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}

                Prms(0).Value = pNumPrestamoISSSTE
                Prms(1).Value = pIdEmp
                Prms(2).Value = pIdQnaIni
                Prms(3).Value = pIdQnaFin
                Prms(4).Value = pIdDeduccion

                Return _DataCOBAEV.RunProc("SP_UDeduccion431", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function HistPrestamoISSSTE(ByVal IdEmp As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int)}

                Prms(0).Value = IdEmp

                Return _DataCOBAEV.RunProc("SP_SHistoriaClave431PorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function HistPrestHipFOVISSSTE(ByVal IdEmp As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int)}

                Prms(0).Value = IdEmp

                Return _DataCOBAEV.RunProc("SP_SHistoriaClave434PorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function HistPagosPrestHipFOVISSSTE(ByVal IdEmp As Integer, ByVal PorcDesc As Decimal, ByVal IdQnaIni As Short, ByVal IdQnaFin As Short, ByVal IncluirDeduc451 As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                                New SqlParameter("@PorcDesc", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIni", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                New SqlParameter("@IncluirDeduc451", SqlDbType.Bit)}

                Prms(0).Value = IdEmp
                Prms(1).Value = PorcDesc
                Prms(2).Value = IdQnaIni
                Prms(3).Value = IdQnaFin
                Prms(4).Value = IncluirDeduc451

                Return _DataCOBAEV.RunProc("SP_SHistPagosDeduc434y451", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsNuevoPorcParaPrestHipFOVISSSTE(ByVal IdEmp As Integer, ByVal PorcDesc As Decimal, ByVal IdQnaIni As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                                New SqlParameter("@PorcDesc", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIni", SqlDbType.SmallInt)}

                Prms(0).Value = IdEmp
                Prms(1).Value = PorcDesc
                Prms(2).Value = IdQnaIni

                Return _DataCOBAEV.RunProc("SP_IHistoriaDeduccion434", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

#Region "Clase Percepción"
    Public Class Percepcion
        Public Enum OrdenPercepciones
            OrdenadasPorClave = 1
            OrdenadasPorNombre = 2
        End Enum
#Region "Clase Percepción: Propiedades privadas"
        Private _IdPercepcion, _IdQnaInicio, _IdQnaFin, _NumQnas As Short
        Private _IdPlaza, _VigIniPerc, _IdPercCapturada As Integer
        Private _ImportePercepcion As Decimal
        Private _DataCOBAEV As New DataCOBAEV
        Private _EspecificarNumQuincenas As Boolean
        Private _NumDias As Byte

        Private _ClavePercepcion, _NombrePercepcion, _URL, _Gravar, _Horas As String
        Private _IdProc, _IdPercepcionPadre As Short
        Private _MostrarParaCaptura, _Activa, _EfectosAbiertos, _Multiplica, _Pension, _ISSSTE As Boolean
        Private _DosPorcNomina, _ValidaParaRP, _Ordinaria, _Masiva, _RequiereDias, _IncluirParaRecibos As Boolean
        Private _ConceptoIndemnizatorio, _PercepcionPorLey, _Ficticia, _ImpuestoAbsorbidoPorColegio As Boolean
        Private _IdAmbitoConcepto, _IdZonaEco, _IdEmpFuncion, _NumQnasRequeridas As Byte
        Private _IdFormaDePago1A, _IdFormaDePago1D, _IdFormaDePago2A, _IdFormaDePago2D As Byte
        Private _IdDeduccionContraria As Short, _IdPercepcionAdeudo As Short, _IdPercepcionRetro, _IdTipoPercSAT As Short
        Private _DerivadaDePercsDeducs As Boolean
#End Region

#Region "Clase Percepción: Propiedades públicas"
        Public Property DerivadaDePercsDeducs() As Boolean
            Get
                Return _DerivadaDePercsDeducs
            End Get
            Set(ByVal Value As Boolean)
                _DerivadaDePercsDeducs = Value
            End Set
        End Property
        Public Property IdTipoPercSAT() As Short
            Get
                Return _IdTipoPercSAT
            End Get
            Set(ByVal Value As Short)
                _IdTipoPercSAT = Value
            End Set
        End Property
        Public Property IdFormaDePago1A() As Byte
            Get
                Return Me._IdFormaDePago1A
            End Get
            Set(ByVal Value As Byte)
                Me._IdFormaDePago1A = Value
            End Set
        End Property
        Public Property IdFormaDePago1D() As Byte
            Get
                Return Me._IdFormaDePago1D
            End Get
            Set(ByVal Value As Byte)
                Me._IdFormaDePago1D = Value
            End Set
        End Property
        Public Property IdFormaDePago2A() As Byte
            Get
                Return Me._IdFormaDePago2A
            End Get
            Set(ByVal Value As Byte)
                Me._IdFormaDePago2A = Value
            End Set
        End Property
        Public Property IdFormaDePago2D() As Byte
            Get
                Return Me._IdFormaDePago2D
            End Get
            Set(ByVal Value As Byte)
                Me._IdFormaDePago2D = Value
            End Set
        End Property
        Public Property ClavePercepcion() As String
            Get
                Return Me._ClavePercepcion
            End Get
            Set(ByVal Value As String)
                Me._ClavePercepcion = Value
            End Set
        End Property
        Public Property NombrePercepcion() As String
            Get
                Return Me._NombrePercepcion
            End Get
            Set(ByVal Value As String)
                Me._NombrePercepcion = Value
            End Set
        End Property
        Public Property URL() As String
            Get
                Return Me._URL
            End Get
            Set(ByVal Value As String)
                Me._URL = Value
            End Set
        End Property
        Public Property Gravar() As String
            Get
                Return Me._Gravar
            End Get
            Set(ByVal Value As String)
                Me._Gravar = Value
            End Set
        End Property
        Public Property Horas() As String
            Get
                Return Me._Horas
            End Get
            Set(ByVal Value As String)
                Me._Horas = Value
            End Set
        End Property
        Public Property IdProc() As Short
            Get
                Return _IdProc
            End Get
            Set(ByVal Value As Short)
                _IdProc = Value
            End Set
        End Property
        Public Property IdPercepcionPadre() As Short
            Get
                Return _IdPercepcionPadre
            End Get
            Set(ByVal Value As Short)
                _IdPercepcionPadre = Value
            End Set
        End Property
        Public Property IdDeduccionContraria() As Short
            Get
                Return _IdDeduccionContraria
            End Get
            Set(ByVal Value As Short)
                _IdDeduccionContraria = Value
            End Set
        End Property
        Public Property IdPercepcionAdeudo() As Short
            Get
                Return _IdPercepcionAdeudo
            End Get
            Set(ByVal Value As Short)
                _IdPercepcionAdeudo = Value
            End Set
        End Property
        Public Property IdPercepcionRetro() As Short
            Get
                Return _IdPercepcionRetro
            End Get
            Set(ByVal Value As Short)
                _IdPercepcionRetro = Value
            End Set
        End Property
        Public Property MostrarParaCaptura() As Boolean
            Get
                Return _MostrarParaCaptura
            End Get
            Set(ByVal Value As Boolean)
                _MostrarParaCaptura = Value
            End Set
        End Property
        Public Property Activa() As Boolean
            Get
                Return _Activa
            End Get
            Set(ByVal Value As Boolean)
                _Activa = Value
            End Set
        End Property
        Public Property EfectosAbiertos() As Boolean
            Get
                Return _EfectosAbiertos
            End Get
            Set(ByVal Value As Boolean)
                _EfectosAbiertos = Value
            End Set
        End Property
        Public Property Multiplica() As Boolean
            Get
                Return _Multiplica
            End Get
            Set(ByVal Value As Boolean)
                _Multiplica = Value
            End Set
        End Property
        Public Property Pension() As Boolean
            Get
                Return _Pension
            End Get
            Set(ByVal Value As Boolean)
                _Pension = Value
            End Set
        End Property
        Public Property ISSSTE() As Boolean
            Get
                Return _ISSSTE
            End Get
            Set(ByVal Value As Boolean)
                _ISSSTE = Value
            End Set
        End Property
        Public Property DosPorcNomina() As Boolean
            Get
                Return _DosPorcNomina
            End Get
            Set(ByVal Value As Boolean)
                _DosPorcNomina = Value
            End Set
        End Property
        Public Property ValidaParaRP() As Boolean
            Get
                Return _ValidaParaRP
            End Get
            Set(ByVal Value As Boolean)
                _ValidaParaRP = Value
            End Set
        End Property
        Public Property Ordinaria() As Boolean
            Get
                Return _Ordinaria
            End Get
            Set(ByVal Value As Boolean)
                _Ordinaria = Value
            End Set
        End Property
        Public Property Masiva() As Boolean
            Get
                Return _Masiva
            End Get
            Set(ByVal Value As Boolean)
                _Masiva = Value
            End Set
        End Property
        Public Property RequiereDias() As Boolean
            Get
                Return _RequiereDias
            End Get
            Set(ByVal Value As Boolean)
                _RequiereDias = Value
            End Set
        End Property
        Public Property IncluirParaRecibos() As Boolean
            Get
                Return _IncluirParaRecibos
            End Get
            Set(ByVal Value As Boolean)
                _IncluirParaRecibos = Value
            End Set
        End Property
        Public Property ConceptoIndemnizatorio() As Boolean
            Get
                Return _ConceptoIndemnizatorio
            End Get
            Set(ByVal Value As Boolean)
                _ConceptoIndemnizatorio = Value
            End Set
        End Property
        Public Property PercepcionPorLey() As Boolean
            Get
                Return _PercepcionPorLey
            End Get
            Set(ByVal Value As Boolean)
                _PercepcionPorLey = Value
            End Set
        End Property
        Public Property Ficticia() As Boolean
            Get
                Return _Ficticia
            End Get
            Set(ByVal Value As Boolean)
                _Ficticia = Value
            End Set
        End Property
        Public Property ImpuestoAbsorbidoPorColegio() As Boolean
            Get
                Return _ImpuestoAbsorbidoPorColegio
            End Get
            Set(ByVal Value As Boolean)
                _ImpuestoAbsorbidoPorColegio = Value
            End Set
        End Property
        Public Property IdAmbitoConcepto() As Byte
            Get
                Return Me._IdAmbitoConcepto
            End Get
            Set(ByVal Value As Byte)
                Me._IdAmbitoConcepto = Value
            End Set
        End Property
        Public Property IdZonaEco() As Byte
            Get
                Return Me._IdZonaEco
            End Get
            Set(ByVal Value As Byte)
                Me._IdZonaEco = Value
            End Set
        End Property
        Public Property IdEmpFuncion() As Byte
            Get
                Return Me._IdEmpFuncion
            End Get
            Set(ByVal Value As Byte)
                Me._IdEmpFuncion = Value
            End Set
        End Property

        Public Property NumDias() As Byte
            Get
                Return Me._NumDias
            End Get
            Set(ByVal Value As Byte)
                Me._NumDias = Value
            End Set
        End Property
        Public Property IdPercCapturada() As Integer
            Get
                Return _IdPercCapturada
            End Get
            Set(ByVal Value As Integer)
                _IdPercCapturada = Value
            End Set
        End Property
        Public Property IdPercepcion() As Short
            Get
                Return _IdPercepcion
            End Get
            Set(ByVal Value As Short)
                _IdPercepcion = Value
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
        Public Property ImportePercepcion() As Decimal
            Get
                Return _ImportePercepcion
            End Get
            Set(ByVal Value As Decimal)
                _ImportePercepcion = Value
            End Set
        End Property
        Public Property IdQnaInicio() As Short
            Get
                Return _IdQnaInicio
            End Get
            Set(ByVal Value As Short)
                _IdQnaInicio = Value
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
        Public Property EspecificarNumQuincenas() As Boolean
            Get
                Return _EspecificarNumQuincenas
            End Get
            Set(ByVal Value As Boolean)
                _EspecificarNumQuincenas = Value
            End Set
        End Property
        Public Property NumQnas() As Byte
            Get
                Return _NumQnas
            End Get
            Set(ByVal Value As Byte)
                _NumQnas = Value
            End Set
        End Property
        Public Property VigIniPerc() As Integer
            Get
                Return _VigIniPerc
            End Get
            Set(ByVal Value As Integer)
                _VigIniPerc = Value
            End Set
        End Property
        Public Enum TipoInsercion
            EnCatalogo = 0
            ParaPago = 1
        End Enum
        Public Enum TipoActualizacion
            EnCatalogo = 0
            ParaPago = 1
        End Enum
        Public Property NumQnasRequeridas() As Byte
            Get
                Return _NumQnasRequeridas
            End Get
            Set(ByVal Value As Byte)
                _NumQnasRequeridas = Value
            End Set
        End Property
#End Region
#Region "Clase Percepción: Métodos público"
        Public Function ObtenCobrosEnAnioPorEmp(ByVal pRFCEmp As String, ByVal pAnio As Short, ByVal pClavePercepcion As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {
                                              New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@Anio", SqlDbType.SmallInt),
                                              New SqlParameter("@ClavePercepcion", SqlDbType.NVarChar, 3)
                                            }

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio
                Prms(2).Value = pClavePercepcion

                Return _DataCOBAEV.RunProc("SP_SPercepcionCobradaEnAnioPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSolicitudesDiasEcoNoDisfPorAnio(pstrAnio As String, ByVal pRFCEmp As String, Optional pParaExportarAEXCEL As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@strAnio", SqlDbType.NVarChar, 4), _
                                              New SqlParameter("@ParaExportarAEXCEL", SqlDbType.Bit), _
                                              New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = pstrAnio
                Prms(1).Value = pParaExportarAEXCEL
                Prms(2).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SEmpsParaDiasEcoNoDisfPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSolicitudesEsPuntAsistPorAnio(ByVal pRFCEmp As String, ByVal pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() =
                                            {
                                              New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@Anio", SqlDbType.SmallInt)
                                            }

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SEmpsParaPuntyAsistPorAnioyParte", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSEmpsParaDiasEcoNoDisfPorAnio(pstrAnio As String, Optional pParaExportarAEXCEL As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@strAnio", SqlDbType.NVarChar, 4), _
                                              New SqlParameter("@ParaExportarAEXCEL", SqlDbType.Bit)}

                Prms(0).Value = pstrAnio
                Prms(1).Value = pParaExportarAEXCEL

                Return _DataCOBAEV.RunProc("SP_SEmpsParaDiasEcoNoDisfPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSEmpsParaPuntyAsistPorAnioyParte(pstrAnioParte As String, Optional pParaExportarAEXCEL As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@strAnioParte", SqlDbType.NVarChar, 6), _
                                              New SqlParameter("@ParaExportarAEXCEL", SqlDbType.Bit)}

                Prms(0).Value = pstrAnioParte
                Prms(1).Value = pParaExportarAEXCEL

                Return _DataCOBAEV.RunProc("SP_SEmpsParaPuntyAsistPorAnioyParte", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPartesEstDePuntyAsistDadoUnAnio(pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SAniosEstPuntyAsistPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAniosDiasEcoNoDisf() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SAniosDiasEconomicosNoDisf", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAniosEstDePuntyAsist() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SAniosEstPuntyAsist", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsActInfPercPorPagoFijo(ByVal pIdPercepcion As Short, ByVal pImporteNew As Decimal, _
                                                 ByVal pIdQnaIniNew As Short, ByVal pTipoOperacion As Byte, _
                                                ByVal pImporteAct As Decimal, ByVal pIdQnaIniAct As Short, _
                                                ByVal pIdEmpFuncion As Byte, _
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@ImporteNew", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIniNew", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                                New SqlParameter("@ImporteAct", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIniAct", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdIdEmpFuncion", SqlDbType.TinyInt)}

                Prms(0).Value = pIdPercepcion
                Prms(1).Value = pImporteNew
                Prms(2).Value = pIdQnaIniNew
                Prms(3).Value = pTipoOperacion
                Prms(4).Value = pImporteAct
                Prms(5).Value = pIdQnaIniAct
                Prms(6).Value = pIdEmpFuncion

                Return _DataCOBAEV.RunProc("SP_IoUPercepcionesPorPagoFijo", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorPagoFijoHistoria(ByVal pIdPercepcion As Short, ByVal pIdEmpFuncion As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt)}

                Prms(0).Value = pIdPercepcion
                Prms(1).Value = pIdEmpFuncion

                Return _DataCOBAEV.RunProc("SP_SPercsPorPagoFijoHistoria", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorPagoFijo() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SPercsPorPagoFijo", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenReferentesADescDeHoras() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SPercsReferentesADescDeHoras", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMaterialDidactico() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SPercsParaMatDid", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AddParaCalculoDeDeduccion(ByVal pIdPercepcion As Short, pIdDeduccion As Short, _
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPercepcion
                Prms(1).Value = pIdDeduccion

                Return _DataCOBAEV.RunProc("SP_IPercepcionesParaCalculoDeDeduccion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelParaCalculoDeDeduccion(ByVal pIdPercepcion As Short, pIdDeduccion As Short, _
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPercepcion
                Prms(1).Value = pIdDeduccion

                Return _DataCOBAEV.RunProc("SP_DPercepcionesParaCalculoDeDeduccion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AddParaCalculoDePercepcion(ByVal pIdPercepcion As Short, pIdPercepcion2 As Short, _
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion2", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPercepcion
                Prms(1).Value = pIdPercepcion2

                Return _DataCOBAEV.RunProc("SP_IPercepcionesParaCalculoDePercepcion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelParaCalculoDePercepcion(ByVal pIdPercepcion As Short, pIdPercepcion2 As Short, _
                                                ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion2", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPercepcion
                Prms(1).Value = pIdPercepcion2

                Return _DataCOBAEV.RunProc("SP_DPercepcionesParaCalculoDePercepcion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenClasifSAT() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SCatalogoTipoPercsSAT", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CveDeEstDeAntFueUsadaEnPeriodoX(ByVal pIdPercepcion As Short, ByVal pIdQnaIni As Short) As Boolean
            Try
                Dim dr As DataRow
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdQnaIni", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPercepcion
                Prms(1).Value = pIdQnaIni

                dr = _DataCOBAEV.RunProc("SP_VSiPercFueUsadaEnXPeriodo", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("Resultado"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfEstimuloAntiguedad(ByVal pVigentes As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@SoloVigentes", SqlDbType.Bit)}

                Prms(0).Value = pVigentes

                Return _DataCOBAEV.RunProc("SP_SEstimuloDeAntiguedad", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfEstimuloAntiguedad(ByVal pVigentes As Boolean, ByVal pIdEmpFuncion As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@SoloVigentes", SqlDbType.Bit),
                                              New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt)}

                Prms(0).Value = pVigentes
                Prms(1).Value = pIdEmpFuncion

                Return _DataCOBAEV.RunProc("SP_SEstimuloDeAntiguedad", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfBonoApoyoSupAcademica(ByVal pVigentes As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@SoloVigentes", SqlDbType.Bit)}

                Prms(0).Value = pVigentes

                Return _DataCOBAEV.RunProc("SP_SBonoApoyoSupAcad", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenInfPrimaDeAntiguedad(ByVal pVigentes As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@SoloVigentes", SqlDbType.Bit)}

                Prms(0).Value = pVigentes

                Return _DataCOBAEV.RunProc("SP_SPrimaDeAntiguedad", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenInfPrimaDeAntiguedad(ByVal pVigentes As Boolean, ByVal pIdEmpFuncion As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@SoloVigentes", SqlDbType.Bit), _
                                              New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt)}

                Prms(0).Value = pVigentes
                Prms(1).Value = pIdEmpFuncion

                Return _DataCOBAEV.RunProc("SP_SPrimaDeAntiguedad", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsActInfEstimuloAntiguedad(ByVal pIdPercepcion As Short, ByVal pNumAniosNew As Byte, pIdEmpFuncion As Byte, _
                                                        pDiasAPagarNew As Byte, pIdQnaIniNew As Short, pTipoOperacion As Byte, _
                                                        pNumAniosAct As Byte, pDiasAPagarAct As Byte, _
                                                        pIdQnaIniAct As Short, _
                                                        ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                              New SqlParameter("@NumAniosNew", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                                New SqlParameter("@DiasAPagarNew", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdQnaIniNew", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                                New SqlParameter("@NumAniosAct", SqlDbType.TinyInt), _
                                                New SqlParameter("@DiasAPagarAct", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdQnaIniAct", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPercepcion
                Prms(1).Value = pNumAniosNew
                Prms(2).Value = pIdEmpFuncion
                Prms(3).Value = pDiasAPagarNew
                Prms(4).Value = pIdQnaIniNew
                Prms(5).Value = pTipoOperacion
                Prms(6).Value = pNumAniosAct
                Prms(7).Value = pDiasAPagarAct
                Prms(8).Value = pIdQnaIniAct

                Return _DataCOBAEV.RunProc("SP_IoUTblEstimuloAntiguedad", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsActInfPrimaDeAntiguedad(ByVal pLimInfNew As Byte, pLimSupNew As Byte, _
                                                        pPorcentajeNew As Decimal, pIdQnaIniNew As Short, pTipoOperacion As Byte, _
                                                        pLimInfAct As Byte, pLimSupAct As Byte, _
                                                        pPorcentajeAct As Decimal, pIdQnaIniAct As Short, _
                                                        pIdEmpFuncion As Byte,
                                                        ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@LimInfNew", SqlDbType.TinyInt), _
                                                New SqlParameter("@LimSupNew", SqlDbType.TinyInt), _
                                                New SqlParameter("@PorcentajeNew", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIniNew", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                                New SqlParameter("@LimInfAct", SqlDbType.TinyInt), _
                                                New SqlParameter("@LimSupAct", SqlDbType.TinyInt), _
                                                New SqlParameter("@PorcentajeAct", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIniAct", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt)}

                Prms(0).Value = pLimInfNew
                Prms(1).Value = pLimSupNew
                Prms(2).Value = pPorcentajeNew
                Prms(3).Value = pIdQnaIniNew
                Prms(4).Value = pTipoOperacion
                Prms(5).Value = pLimInfAct
                Prms(6).Value = pLimSupAct
                Prms(7).Value = pPorcentajeAct
                Prms(8).Value = pIdQnaIniAct
                Prms(9).Value = pIdEmpFuncion

                Return _DataCOBAEV.RunProc("SP_IoUPorcentajesClave223", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsActInfBonoApoyoSupAcademica(ByVal pHrsLimInfNew As Byte, pHrsLimSupNew As Byte, _
                                                        pImporteNew As Decimal, pIdQnaIniNew As Short, pTipoOperacion As Byte, _
                                                        pHrsLimInfAct As Byte, pHrsLimSupAct As Byte, _
                                                        pImporteAct As Decimal, pIdQnaIniAct As Short, _
                                                        ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@HrsLimInfNew", SqlDbType.TinyInt), _
                                                New SqlParameter("@HrsLimSupNew", SqlDbType.TinyInt), _
                                                New SqlParameter("@ImporteNew", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIniNew", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                                New SqlParameter("@HrsLimInfAct", SqlDbType.TinyInt), _
                                                New SqlParameter("@HrsLimSupAct", SqlDbType.TinyInt), _
                                                New SqlParameter("@ImporteAct", SqlDbType.Decimal), _
                                                New SqlParameter("@IdQnaIniAct", SqlDbType.SmallInt)}

                Prms(0).Value = pHrsLimInfNew
                Prms(1).Value = pHrsLimSupNew
                Prms(2).Value = pImporteNew
                Prms(3).Value = pIdQnaIniNew
                Prms(4).Value = pTipoOperacion
                Prms(5).Value = pHrsLimInfAct
                Prms(6).Value = pHrsLimSupAct
                Prms(7).Value = pImporteAct
                Prms(8).Value = pIdQnaIniAct

                Return _DataCOBAEV.RunProc("SP_IoUBonoApoyoSupAcad", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaUpdate(pIdPercepcion As Short, pParaUpdate As Boolean) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                              New SqlParameter("@ParaUpdate", SqlDbType.Bit)}

                Prms(0).Value = pIdPercepcion
                Prms(1).Value = pParaUpdate

                Return _DataCOBAEV.RunProc("SP_SPercepcionPorId", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFormasDePago() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SFormasDePago", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaInf(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClavePercepcion", SqlDbType.NVarChar, 3), _
                                                    New SqlParameter("@NombrePercepcion", SqlDbType.NVarChar, 50), _
                                                    New SqlParameter("@IdProc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@MostrarParaCaptura", SqlDbType.Bit), _
                                                    New SqlParameter("@IdAmbitoConcepto", SqlDbType.TinyInt), _
                                                    New SqlParameter("@Activa", SqlDbType.Bit), _
                                                    New SqlParameter("@EfectosAbiertos", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdZonaEco", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@URL", SqlDbType.NVarChar, 50), _
                                                    New SqlParameter("@Horas", SqlDbType.Char, 1), _
                                                    New SqlParameter("@DosPorcNomina", SqlDbType.Bit), _
                                                    New SqlParameter("@ValidaParaRP", SqlDbType.Bit), _
                                                    New SqlParameter("@IdPercepcionPadre", SqlDbType.SmallInt), _
                                                    New SqlParameter("@ImpuestoAbsorbidoPorColegio", SqlDbType.Bit), _
                                                    New SqlParameter("@Ordinaria", SqlDbType.Bit), _
                                                    New SqlParameter("@Masiva", SqlDbType.Bit), _
                                                    New SqlParameter("@RequiereDias", SqlDbType.Bit), _
                                                    New SqlParameter("@IncluirParaRecibos", SqlDbType.Bit), _
                                                    New SqlParameter("@ConceptoIndemnizatorio", SqlDbType.Bit), _
                                                    New SqlParameter("@PercepcionPorLey", SqlDbType.Bit), _
                                                    New SqlParameter("@Ficticia", SqlDbType.Bit), _
                                                    New SqlParameter("@IdDeducContrariaDePerc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPercAdeudoDePerc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPercRetroDePerc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@NumQnasRequeridas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdFormaDePago1A", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdFormaDePago1D", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdFormaDePago2A", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdFormaDePago2D", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdTipoPercSAT", SqlDbType.SmallInt), _
                                                    New SqlParameter("@DerivadaDePercsDeducs", SqlDbType.Bit)
                                              }

                Prms(0).Value = Me._ClavePercepcion
                Prms(1).Value = Me._NombrePercepcion
                Prms(2).Value = Me._IdProc
                Prms(3).Value = Me._MostrarParaCaptura
                Prms(4).Value = Me._IdAmbitoConcepto
                Prms(5).Value = Me._Activa
                Prms(6).Value = Me._EfectosAbiertos
                Prms(7).Value = Me._NumQnas
                Prms(8).Value = Me._IdZonaEco
                Prms(9).Value = Me._IdEmpFuncion
                Prms(10).Value = IIf(Me._URL = String.Empty, DBNull.Value, Me._URL)
                Prms(11).Value = Me._Horas
                Prms(12).Value = Me._DosPorcNomina
                Prms(13).Value = Me._ValidaParaRP
                Prms(14).Value = Me._IdPercepcionPadre
                Prms(15).Value = Me._ImpuestoAbsorbidoPorColegio
                Prms(16).Value = Me._Ordinaria
                Prms(17).Value = Me._Masiva
                Prms(18).Value = Me._RequiereDias
                Prms(19).Value = Me._IncluirParaRecibos
                Prms(20).Value = Me._ConceptoIndemnizatorio
                Prms(21).Value = Me._PercepcionPorLey
                Prms(22).Value = Me._Ficticia
                Prms(23).Value = Me._IdDeduccionContraria
                Prms(24).Value = Me._IdPercepcionAdeudo
                Prms(25).Value = Me._IdPercepcionRetro
                Prms(26).Value = Me._NumQnasRequeridas
                Prms(27).Value = Me._IdFormaDePago1A
                Prms(28).Value = Me._IdFormaDePago1D
                Prms(29).Value = Me._IdFormaDePago2A
                Prms(30).Value = Me._IdFormaDePago2D
                Prms(31).Value = Me._IdPercepcion
                Prms(32).Value = Me._IdTipoPercSAT
                Prms(33).Value = Me._DerivadaDePercsDeducs

                Return _DataCOBAEV.RunProc("SP_UPercepcion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CrearNueva(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClavePercepcion", SqlDbType.NVarChar, 3), _
                                                    New SqlParameter("@NombrePercepcion", SqlDbType.NVarChar, 50), _
                                                    New SqlParameter("@IdProc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@MostrarParaCaptura", SqlDbType.Bit), _
                                                    New SqlParameter("@IdAmbitoConcepto", SqlDbType.TinyInt), _
                                                    New SqlParameter("@Activa", SqlDbType.Bit), _
                                                    New SqlParameter("@EfectosAbiertos", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdZonaEco", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@URL", SqlDbType.NVarChar, 50), _
                                                    New SqlParameter("@Horas", SqlDbType.Char, 1), _
                                                    New SqlParameter("@DosPorcNomina", SqlDbType.Bit), _
                                                    New SqlParameter("@ValidaParaRP", SqlDbType.Bit), _
                                                    New SqlParameter("@IdPercepcionPadre", SqlDbType.SmallInt), _
                                                    New SqlParameter("@ImpuestoAbsorbidoPorColegio", SqlDbType.Bit), _
                                                    New SqlParameter("@Ordinaria", SqlDbType.Bit), _
                                                    New SqlParameter("@Masiva", SqlDbType.Bit), _
                                                    New SqlParameter("@RequiereDias", SqlDbType.Bit), _
                                                    New SqlParameter("@IncluirParaRecibos", SqlDbType.Bit), _
                                                    New SqlParameter("@ConceptoIndemnizatorio", SqlDbType.Bit), _
                                                    New SqlParameter("@PercepcionPorLey", SqlDbType.Bit), _
                                                    New SqlParameter("@Ficticia", SqlDbType.Bit), _
                                                    New SqlParameter("@IdDeducContrariaDePerc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPercAdeudoDePerc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPercRetroDePerc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@NumQnasRequeridas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdFormaDePago1A", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdFormaDePago1D", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdFormaDePago2A", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdFormaDePago2D", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdTipoPercSAT", SqlDbType.SmallInt), _
                                                    New SqlParameter("@DerivadaDePercsDeducs", SqlDbType.Bit)
                                              }

                Prms(0).Value = Me._ClavePercepcion
                Prms(1).Value = Me._NombrePercepcion
                Prms(2).Value = Me._IdProc
                Prms(3).Value = Me._MostrarParaCaptura
                Prms(4).Value = Me._IdAmbitoConcepto
                Prms(5).Value = Me._Activa
                Prms(6).Value = Me._EfectosAbiertos
                Prms(7).Value = Me._NumQnas
                'Prms(8).Value = IIf(Me._NumQnas = 0, DBNull.Value, Me._NumQnas)
                Prms(8).Value = Me._IdZonaEco
                Prms(9).Value = Me._IdEmpFuncion
                Prms(10).Value = IIf(Me._URL = String.Empty, DBNull.Value, Me._URL)
                Prms(11).Value = Me._Horas
                Prms(12).Value = Me._DosPorcNomina
                Prms(13).Value = Me._ValidaParaRP
                Prms(14).Value = Me._IdPercepcionPadre
                Prms(15).Value = Me._ImpuestoAbsorbidoPorColegio
                Prms(16).Value = Me._Ordinaria
                Prms(17).Value = Me._Masiva
                Prms(18).Value = Me._RequiereDias
                Prms(19).Value = Me._IncluirParaRecibos
                Prms(20).Value = Me._ConceptoIndemnizatorio
                Prms(21).Value = Me._PercepcionPorLey
                Prms(22).Value = Me._Ficticia
                Prms(23).Value = Me._IdDeduccionContraria
                Prms(24).Value = Me._IdPercepcionAdeudo
                Prms(25).Value = Me._IdPercepcionRetro
                Prms(26).Value = Me._NumQnasRequeridas
                Prms(27).Value = Me._IdFormaDePago1A
                Prms(28).Value = Me._IdFormaDePago1D
                Prms(29).Value = Me._IdFormaDePago2A
                Prms(30).Value = Me._IdFormaDePago2D
                Prms(31).Value = Me._IdTipoPercSAT
                Prms(32).Value = Me._DerivadaDePercsDeducs

                Return _DataCOBAEV.RunProc("SP_INuevaPercepcion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNuevaClave() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SNuevaClavePercepcion", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenTodasParaABC(pOrdenPercs As OrdenPercepciones) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Orden", SqlDbType.TinyInt)}

                Prms(0).Value = pOrdenPercs

                Return _DataCOBAEV.RunProc("SP_SPercepciones2", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenPercsDeducsParaSuCalculo(pIdPercepcion As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPercepcion

                Return _DataCOBAEV.RunProc("SP_STblsDePercsDeducsParaCalcDePerc", Prms, "dsPercsDeducs", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenActivasDerivadaDePercsDeducs(Optional pTipoOrden As String = "CLAVE") As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@TipoOrden", SqlDbType.NVarChar, 20), _
                                              New SqlParameter("@DerivadaDePercsDeducs", SqlDbType.Bit)}

                Prms(0).Value = pTipoOrden
                Prms(1).Value = True

                Return _DataCOBAEV.RunProc("SP_SPercepcionesActivas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenSoloActivas(Optional pTipoOrden As String = "CLAVE") As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@TipoOrden", SqlDbType.NVarChar, 20)}

                Return _DataCOBAEV.RunProc("SP_SPercepcionesActivas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenNoFicticias() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IncluirFicticias", SqlDbType.Bit)}

                Prms(0).Value = False

                Return _DataCOBAEV.RunProc("SP_SPercepciones2", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenNoFicticias(pParaAsociarComoAdeudo As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IncluirFicticias", SqlDbType.Bit),
                                              New SqlParameter("@ParaAsociarComoAdeudo", SqlDbType.Bit)}

                Prms(0).Value = DBNull.Value
                Prms(1).Value = pParaAsociarComoAdeudo

                Return _DataCOBAEV.RunProc("SP_SPercepciones2", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenNoFicticias(pParaAsociarComoAdeudo As Boolean, pParaAsociarComoRetro As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IncluirFicticias", SqlDbType.Bit),
                                              New SqlParameter("@ParaAsociarComoAdeudo", SqlDbType.Bit),
                                              New SqlParameter("@ParaAsociarComoRetro", SqlDbType.Bit)}

                Prms(0).Value = DBNull.Value
                Prms(1).Value = pParaAsociarComoAdeudo
                Prms(2).Value = pParaAsociarComoRetro

                Return _DataCOBAEV.RunProc("SP_SPercepciones2", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenOrdinarias(Optional pTipoOrden As String = "CLAVE") As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@TipoOrden", SqlDbType.NVarChar, 20)}

                Prms(0).Value = pTipoOrden

                Return _DataCOBAEV.RunProc("SP_SPercsOrdinarias", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNoOrdinarias(Optional pTipoOrden As String = "CLAVE") As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@TipoOrden", SqlDbType.NVarChar, 20)}

                Prms(0).Value = pTipoOrden

                Return _DataCOBAEV.RunProc("SP_SPercsNoOrdinarias", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsMasiva(ByVal TipoInsercion As TipoInsercion, ByVal NumEmp As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                If TipoInsercion = Percepcion.TipoInsercion.ParaPago Then
                    Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@ImportePercepcion", SqlDbType.Decimal), _
                                                    New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                    New SqlParameter("@TipoInsercion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)}

                    Prms(0).Value = Me._IdPercepcion
                    Prms(1).Value = Me._ImportePercepcion
                    Prms(2).Value = Me._IdQnaInicio
                    Prms(3).Value = Me._IdQnaFin
                    Prms(4).Value = TipoInsercion
                    Prms(5).Value = NumEmp

                    Return _DataCOBAEV.RunProc("SP_IPercepciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
                End If
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelMasiva(ByVal IdPercepcion As Short, ByVal IdQnaIni As Short, ByVal IdQnaFin As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaIni", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}

                Prms(0).Value = IdPercepcion
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin

                Return _DataCOBAEV.RunProc("SP_DPercsCaptMasivamente", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMasivas(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                If ParaDDL Then
                    Prms(0).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_SPercepcionesMasivas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_SPercepcionesMasivas", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAplicadasPorQuincena(ByVal IdRol As Byte, ByVal IdQuincena As Short) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = IdRol
                Prms(1).Value = IdQuincena

                dt = _DataCOBAEV.RunProc("SP_SPercepcionesQuincenalesPorRol", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Elimina(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercCapturada", SqlDbType.Int), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = Me._IdPercCapturada
                Prms(1).Value = Me._IdPercepcion
                Prms(2).Value = Me._IdPlaza

                Return _DataCOBAEV.RunProc("SP_DPercepciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCapturadasPorEmpleado(ByVal RFCEmp As String, ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = RFCEmp
                Prms(1).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SPercepciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorIdDeCaptura() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercCapturada", SqlDbType.Int), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = Me._IdPercCapturada
                Prms(1).Value = Me._IdPercepcion
                Prms(2).Value = Me._IdPlaza

                Return _DataCOBAEV.RunProc("SP_SPercepciones", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Inserta(ByVal TipoInsercion As TipoInsercion, ByVal ArregloAuditoria() As String) As Boolean
            Try
                If TipoInsercion = Percepcion.TipoInsercion.ParaPago Then
                    Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                    New SqlParameter("@ImportePercepcion", SqlDbType.Decimal), _
                                                    New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                    New SqlParameter("@EspecificarNumQuincenas", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@TipoInsercion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@NumDias", SqlDbType.TinyInt)}

                    Prms(0).Value = Me._IdPercepcion
                    Prms(1).Value = Me._IdPlaza
                    Prms(2).Value = Me._ImportePercepcion
                    Prms(3).Value = Me._IdQnaInicio
                    Prms(4).Value = Me._IdQnaFin
                    Prms(5).Value = Me._EspecificarNumQuincenas
                    Prms(6).Value = Me._NumQnas
                    Prms(7).Value = TipoInsercion
                    Prms(8).Value = Me._NumDias

                    Return _DataCOBAEV.RunProc("SP_IPercepciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
                End If

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualiza(ByVal TipoActualizacion As TipoActualizacion, ByVal ArregloAuditoria() As String) As Boolean
            Try
                If TipoActualizacion = Deduccion.TipoInsercion.ParaPago Then
                    Dim Prms As SqlParameter() = {New SqlParameter("@IdPercCapturada", SqlDbType.Int), _
                                                    New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                    New SqlParameter("@ImportePercepcion", SqlDbType.Decimal), _
                                                    New SqlParameter("@IdQnaInicio", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaFin", SqlDbType.SmallInt), _
                                                    New SqlParameter("@EspecificarNumQuincenas", SqlDbType.Bit), _
                                                    New SqlParameter("@NumQnas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@TipoActualizacion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@NumDias", SqlDbType.TinyInt)}

                    Prms(0).Value = Me._IdPercCapturada
                    Prms(1).Value = Me._IdPercepcion
                    Prms(2).Value = Me._IdPlaza
                    Prms(3).Value = Me._ImportePercepcion
                    Prms(4).Value = Me._IdQnaInicio
                    Prms(5).Value = Me._IdQnaFin
                    Prms(6).Value = Me._EspecificarNumQuincenas
                    Prms(7).Value = Me._NumQnas
                    Prms(8).Value = TipoActualizacion
                    Prms(9).Value = Me._NumDias

                    Return _DataCOBAEV.RunProc("SP_UPercepciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
                End If
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt)}

                Prms(0).Value = _IdPercepcion

                Return _DataCOBAEV.RunProc("SP_SPercepciones", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal pIdPercepcion As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPercepcion

                Return _DataCOBAEV.RunProc("SP_SPercepcionPorId", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
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
                    dt = _DataCOBAEV.RunProc("SP_SPercepciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_SPercepciones", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorRol(ByVal IdRol As Byte) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt)}

                Prms(0).Value = IdRol
                dt = _DataCOBAEV.RunProc("SP_SPercepcionesPorRol", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAplicadasPorEmp(ByVal RFCEmp As String) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = RFCEmp
                dt = _DataCOBAEV.RunProc("SP_SPercepcionesAplicadasPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfParaCaptura(ByVal RFCEmp As String, ByVal IdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@ObtenInfParaCaptura", SqlDbType.Bit), _
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = _IdPercepcion
                Prms(1).Value = True
                Prms(2).Value = RFCEmp
                Prms(3).Value = IdPlaza

                Return _DataCOBAEV.RunProc("SP_SPercepciones", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenProgramadasPorSemestre(ByVal IdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = IdSemestre

                Return _DataCOBAEV.RunProc("SP_SPercepcionesProgramadas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenRetroactivasPorQna(ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SPercepcionesRetroactivas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenProgramada(ByVal IdSemestre As Short, ByVal IdQnaPago As Short, ByVal NumParte As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQnaPago", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@NumParte", SqlDbType.TinyInt)}

                Prms(0).Value = IdSemestre
                Prms(1).Value = IdQnaPago
                Prms(2).Value = Me._IdPercepcion
                Prms(3).Value = NumParte

                Return _DataCOBAEV.RunProc("SP_SPercepcionProgramada", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenRetroactiva(ByVal IdPercRetro As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercRetro", SqlDbType.SmallInt)}

                Prms(0).Value = IdPercRetro

                Return _DataCOBAEV.RunProc("SP_SPercepcionRetroactiva", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPercsAsocAPercProg() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt)}

                Prms(0).Value = Me._IdPercepcion

                Return _DataCOBAEV.RunProc("SP_SPercsAsociadasAPercsProgramadas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDeducsAsocAPercProg() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt)}

                Prms(0).Value = Me._IdPercepcion

                Return _DataCOBAEV.RunProc("SP_SDeducsAsociadasAPercsProgramadas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsPercProg(ByVal IdQna2aParte As Short, ByVal IdQnaPago As Short, ByVal NumParte As Byte, ByVal PagarIndividualmente As Boolean, _
                    ByVal TipoOperacion As Byte, ByVal IdSemestre As Short, ByVal IdTipoImpuesto As Byte, _
                    ByVal DiasPerc As Short, ByVal MesActualParaImpuesto As Boolean, ByVal ArregloAuditoria() As String, Optional ByVal IdQnaPagoAnt As Short = 0) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaPago", SqlDbType.SmallInt), _
                                                    New SqlParameter("@NumParte", SqlDbType.TinyInt), _
                                                    New SqlParameter("@PagarIndividualmente", SqlDbType.Bit), _
                                                    New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdQnaPagoAnt", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdTipoImpuesto", SqlDbType.TinyInt), _
                                                    New SqlParameter("@DiasPerc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@MesActualParaImpuesto", SqlDbType.Bit),
                                                    New SqlParameter("@IdQna2aParte", SqlDbType.SmallInt)}

                Prms(0).Value = Me._IdPercepcion
                Prms(1).Value = IdQnaPago
                Prms(2).Value = NumParte
                Prms(3).Value = PagarIndividualmente
                Prms(4).Value = TipoOperacion
                Prms(5).Value = IdQnaPagoAnt
                Prms(6).Value = IdSemestre
                Prms(7).Value = IdTipoImpuesto
                Prms(8).Value = DiasPerc
                Prms(9).Value = MesActualParaImpuesto
                Prms(10).Value = IdQna2aParte

                Return _DataCOBAEV.RunProc("SP_IoUPercepcionesProgramadasHistoria", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsPercProgConRetro(ByVal IdQna2aParte As Short, ByVal IdQnaPago As Short, ByVal NumParte As Byte, ByVal PagarIndividualmente As Boolean, _
                        ByVal TipoOperacion As Byte, ByVal IdSemestre As Short, ByVal IdTipoImpuesto As Byte, _
                        ByVal DiasPerc As Short, ByVal IdQnaRetro As Short, ByVal MesActualParaImpuesto As Boolean, _
                        ByVal ArregloAuditoria() As String, Optional ByVal IdQnaPagoAnt As Short = 0) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaPago", SqlDbType.SmallInt), _
                                                    New SqlParameter("@NumParte", SqlDbType.TinyInt), _
                                                    New SqlParameter("@PagarIndividualmente", SqlDbType.Bit), _
                                                    New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdQnaPagoAnt", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdTipoImpuesto", SqlDbType.TinyInt), _
                                                    New SqlParameter("@DiasPerc", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaRetro", SqlDbType.SmallInt), _
                                                    New SqlParameter("@MesActualParaImpuesto", SqlDbType.Bit),
                                                    New SqlParameter("@IdQna2aParte", SqlDbType.SmallInt)}

                Prms(0).Value = Me._IdPercepcion
                Prms(1).Value = IdQnaPago
                Prms(2).Value = NumParte
                Prms(3).Value = PagarIndividualmente
                Prms(4).Value = TipoOperacion
                Prms(5).Value = IdQnaPagoAnt
                Prms(6).Value = IdSemestre
                Prms(7).Value = IdTipoImpuesto
                Prms(8).Value = DiasPerc
                Prms(9).Value = IdQnaRetro
                Prms(10).Value = MesActualParaImpuesto
                Prms(11).Value = IdQna2aParte

                Return _DataCOBAEV.RunProc("SP_IoUPercepcionesProgramadasHistoria", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdPercProg(ByVal IdQna2aParte As Short, ByVal IdQnaPago As Short, ByVal IdQnaPagoAnt As Short, ByVal NumParte As Byte, ByVal PagarIndividualmente As Boolean, _
                                    ByVal TipoOperacion As Byte, ByVal IdSemestre As Short, ByVal IdTipoImpuesto As Byte, ByVal DiasPerc As Short, _
                                    ByVal MesActualParaImpuesto As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            InsPercProg(IdQna2aParte, IdQnaPago, NumParte, PagarIndividualmente, TipoOperacion, IdSemestre, IdTipoImpuesto, DiasPerc, MesActualParaImpuesto, ArregloAuditoria, IdQnaPagoAnt)
        End Function
        Public Function UpdPercProgConRetro(ByVal IdQna2aParte As Short, ByVal IdQnaPago As Short, ByVal IdQnaPagoAnt As Short, ByVal NumParte As Byte, _
                ByVal PagarIndividualmente As Boolean, ByVal TipoOperacion As Byte, ByVal IdSemestre As Short, ByVal IdTipoImpuesto As Byte, _
                ByVal DiasPerc As Short, ByVal IdQnaRetro As Short, ByVal MesActualParaImpuesto As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            InsPercProgConRetro(IdQna2aParte, IdQnaPago, NumParte, PagarIndividualmente, TipoOperacion, IdSemestre, IdTipoImpuesto, DiasPerc, IdQnaRetro, MesActualParaImpuesto, ArregloAuditoria, IdQnaPagoAnt)
        End Function
        Public Function UpdPercRetro(ByVal IdPercRetro As Short, ByVal PorcInc As Decimal, ByVal IncluirEnPago As Boolean, ByVal ArregloAuditoria() As String, _
                                     pRetroPorDiferencia As Boolean, pImporteDiferencia As Decimal) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercRetro", SqlDbType.SmallInt), _
                                              New SqlParameter("@PorcInc", SqlDbType.Decimal), _
                                              New SqlParameter("@IncluirEnPago", SqlDbType.Bit), _
                                              New SqlParameter("@RetroPorDiferencia", SqlDbType.Bit),
                                              New SqlParameter("@ImporteDiferencia", SqlDbType.Decimal)}

                Prms(0).Value = IdPercRetro
                Prms(1).Value = PorcInc
                Prms(2).Value = IncluirEnPago
                Prms(3).Value = pRetroPorDiferencia
                Prms(4).Value = pImporteDiferencia

                Return _DataCOBAEV.RunProc("SP_UPercepcionesRetroactivas", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DelPercProg(ByVal IdQnaPago As Short, ByVal NumParte As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdQnaPago", SqlDbType.Decimal), _
                                                    New SqlParameter("@NumParte", SqlDbType.TinyInt)}

                Prms(0).Value = Me._IdPercepcion
                Prms(1).Value = IdQnaPago
                Prms(2).Value = NumParte

                Return _DataCOBAEV.RunProc("SP_DPercepcionesProgramadasHistoria", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

#Region "Clase Nómina"
    Public Class Nomina
#Region "Clase Nómina: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Nómina: Métodos públicos"
        Public Function getPorEmpDiasExentosPorAnioPerc(ByVal pRFCEmp As String, ByVal pIdConcepto As Short, ByVal pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                              New SqlParameter("@IdConcepto", SqlDbType.SmallInt), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt)}
                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdConcepto
                Prms(2).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SEmpsDiasExentosPorAnioPerc", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function getPorEmpDiasExentosPorAnioPerc(ByVal pIdRecibo As Short, ByVal pIdConcepto As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdConcepto", SqlDbType.SmallInt)}
                Prms(0).Value = pIdRecibo
                Prms(1).Value = pIdConcepto

                Return _DataCOBAEV.RunProc("SP_SEmpsDiasExentosPorAnioPerc", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function getConciliacionParaRecFin(ByVal pIdQuincena As Short, ByVal pAnio As Short, _
                                   ByVal pIdMes As Byte, ByVal pOrigen As String, ByVal pNumAfect As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 4), _
                                              New SqlParameter("@NumAfect", SqlDbType.NVarChar, 20)}

                Prms(0).Value = pIdQuincena
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMes
                Prms(3).Value = pOrigen
                Prms(4).Value = pNumAfect

                Return _DataCOBAEV.RunProc("SP_SConciliacionNominaParaRecFin", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaInf(ByVal pIdQuincena As Short, ByVal pLogin As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQna", SqlDbType.SmallInt), _
                                              New SqlParameter("@Login", SqlDbType.NVarChar, 30)}

                Prms(0).Value = pIdQuincena
                Prms(1).Value = pLogin

                Return _DataCOBAEV.RunProc("SP_SValidaNomina", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsUpdInfCompCheques(ByVal pId_Emp_BenefPA As Integer, ByVal pIdQuincena As Short, ByVal pAnio As Short, _
                                   ByVal pIdMes As Byte, ByVal pAdicional As Byte, ByVal pIdPlantel As Short, _
                                   ByVal pIdRecibo As Short, ByVal pTipoCheque As String, _
                                   ByVal pIdBanco As Byte, ByVal pCuentaPagadora As String, _
                                   ByVal pNumCheque As String, ByVal pFechaEmision As Date, _
                                   ByVal pFechaPagoCheque As Date, ByVal pObservaciones As String, _
                                   ByVal pCancelado As Boolean, ByVal pFechaCancelacion As Date, _
                                   ByVal pTipoOperacion As Byte) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Id_Emp_BenefPA", SqlDbType.Int), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                                New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoCheque", SqlDbType.NVarChar, 4), _
                                                New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@CuentaPagadora", SqlDbType.NVarChar, 18), _
                                                New SqlParameter("@NumCheque", SqlDbType.NVarChar, 20), _
                                                New SqlParameter("@FechaEmision", SqlDbType.DateTime), _
                                                New SqlParameter("@FechaPagoCheque", SqlDbType.DateTime), _
                                                New SqlParameter("@Observaciones", SqlDbType.NVarChar, 150), _
                                                New SqlParameter("@Cancelado", SqlDbType.Bit), _
                                                New SqlParameter("@FechaCancelacion", SqlDbType.DateTime), _
                                                New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}

                Prms(0).Value = pId_Emp_BenefPA
                Prms(1).Value = pIdQuincena
                Prms(2).Value = pAnio
                Prms(3).Value = pIdMes
                Prms(4).Value = pAdicional
                Prms(5).Value = pIdPlantel
                Prms(6).Value = pIdRecibo
                Prms(7).Value = pTipoCheque
                Prms(8).Value = pIdBanco
                Prms(9).Value = pCuentaPagadora
                Prms(10).Value = pNumCheque
                Prms(11).Value = pFechaEmision
                Prms(12).Value = pFechaPagoCheque
                Prms(13).Value = pObservaciones
                Prms(14).Value = pCancelado
                Prms(15).Value = pFechaCancelacion
                Prms(16).Value = pTipoOperacion

                Return _DataCOBAEV.RunProc("SP_IoUTblChequesInfComp", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function getCheques(ByVal pIdQuincena As Short, ByVal pAnio As Short, _
                                   ByVal pIdMes As Byte, ByVal pOrigen As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 4)}

                Prms(0).Value = pIdQuincena
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMes
                Prms(3).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_SConsultaCheques", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function getDepositosCheques(ByVal pIdQuincena As Short, ByVal pAnio As Short, _
                                   ByVal pIdMes As Byte, ByVal pOrigen As String, ByVal pIdBanco As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 4), _
                                              New SqlParameter("@IdBanco", SqlDbType.TinyInt)}

                Prms(0).Value = pIdQuincena
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMes
                Prms(3).Value = pOrigen
                Prms(4).Value = pIdBanco

                Return _DataCOBAEV.RunProc("SP_SConsultaDepositosResumen", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function getCheque(ByVal pId_Emp_BenefPA As Integer, ByVal pIdQuincena As Short, ByVal pAnio As Short, _
                                   ByVal pIdMes As Byte, ByVal pAdicional As Byte, ByVal pIdPlantel As Short, _
                                   ByVal pIdRecibo As Short, ByVal pTipoCheque As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Id_Emp_BenefPA", SqlDbType.Int), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                                New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoCheque", SqlDbType.NVarChar, 4)}

                Prms(0).Value = pId_Emp_BenefPA
                Prms(1).Value = pIdQuincena
                Prms(2).Value = pAnio
                Prms(3).Value = pIdMes
                Prms(4).Value = pAdicional
                Prms(5).Value = pIdPlantel
                Prms(6).Value = pIdRecibo
                Prms(7).Value = pTipoCheque

                Return _DataCOBAEV.RunProc("SP_SConsultaCheque", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function getEsquemasDePago(ByVal pRFCEmp As String, ByVal pIdCategoria As Short, ByVal pIdPlantel As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                              New SqlParameter("@IdCategoria", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdPlantel", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdCategoria
                Prms(2).Value = pIdPlantel

                Return _DataCOBAEV.RunProc("SP_STblEsquemasDePago", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function getEsquemasDePago(ByVal pRFCEmp As String, ByVal pIdCategoria As Short, ByVal pIdPlantel As Short, ByVal pParaAsignar As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13),
                                              New SqlParameter("@IdCategoria", SqlDbType.SmallInt),
                                              New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                                              New SqlParameter("@ParaAsignar", SqlDbType.Bit)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdCategoria
                Prms(2).Value = pIdPlantel
                Prms(3).Value = pParaAsignar

                Return _DataCOBAEV.RunProc("SP_STblEsquemasDePago", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPuestos(ByVal pIdCategoria As Short, ByVal pIdPlantel As Short, ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt),
                                              New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                                              New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = pIdCategoria
                Prms(1).Value = pIdPlantel
                Prms(2).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SPuestosSefiplan", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCorreosVarios(ByVal pToken As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Token", SqlDbType.NVarChar, 50)}
                Prms(0).Value = pToken

                Return _DataCOBAEV.RunProc("SP_SCorreosVarios", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DeterminaSiConceptoGrava(ByVal pIdConcepto As Short, ByVal pTipoConcepto As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdConcepto", SqlDbType.SmallInt), _
                                              New SqlParameter("@TipoConcepto", SqlDbType.NVarChar, 1), _
                                              New SqlParameter("@Grava", SqlDbType.Bit)}
                Prms(0).Value = pIdConcepto
                Prms(1).Value = pTipoConcepto
                Prms(2).Direction = ParameterDirection.InputOutput

                _DataCOBAEV.RunProc("SP_SDeterminaSiConceptoGrava", Prms, DataCOBAEV.BD.Nomina)

                Return CBool(Prms(2).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConceptoRequiereDiasExentos(ByVal pIdConcepto As Short, ByVal pTipoConcepto As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdConcepto", SqlDbType.SmallInt), _
                                              New SqlParameter("@TipoConcepto", SqlDbType.NVarChar, 1), _
                                              New SqlParameter("@RequiereDiasExentos", SqlDbType.Bit)}
                Prms(0).Value = pIdConcepto
                Prms(1).Value = pTipoConcepto
                Prms(2).Direction = ParameterDirection.InputOutput

                _DataCOBAEV.RunProc("SP_SConceptoRequiereDiasExentos", Prms, DataCOBAEV.BD.Nomina)

                Return CBool(Prms(2).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraPlantillaConceptosParaTimbrado(ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SPlantilla_Conceptos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraPlantillaConceptosParaTimbradoV2Punto0(ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SPlantilla_ConceptosV2_0", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraPlantillaDatosGeneralesParaTimbrado(ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SPlantilla_DatosGrales", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraPlantillaPlazaParaTimbrado(ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SPlantilla_Plaza", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraPlantillaEmpleadosParaTimbrado(ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SPlantilla_Empleados", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaEnNominaIndice(ByVal pIdQuincena As Short, ByVal pIdFondoPresup As Byte, ByVal pPagina As Short, _
                                              pIdEmp As Integer) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdFondoPresup", SqlDbType.TinyInt), _
                                                New SqlParameter("@Pagina", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdEmp", SqlDbType.Int)}
                Prms(0).Value = pIdQuincena
                Prms(1).Value = pIdFondoPresup
                Prms(2).Value = pPagina
                Prms(3).Value = pIdEmp

                Return _DataCOBAEV.RunProc("SP_INominaIndice", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEmpsParaGenerarIndice(ByVal pIdQuincena As Short, ByVal pIdFondoPresup As Byte, ByVal pIdPlantel As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdFondoPresup", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdPlantel", SqlDbType.SmallInt)}
                Prms(0).Value = pIdQuincena
                Prms(1).Value = pIdFondoPresup
                Prms(2).Value = pIdPlantel

                Return _DataCOBAEV.RunProc("SP_SEmpsPagadosEnNominaPorPlantelyQna", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsParaEnvioDeComprobantesDePago(ByVal pIdQuincena As Short, ByVal pIdFondoPresup As Byte, _
                                                   ByVal pIdPlantel As Short, ByVal pZonaGeografica As Byte, _
                                                   ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdFondoPresup", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdZonaGeografica", SqlDbType.TinyInt), _
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = pIdQuincena
                Prms(1).Value = pIdFondoPresup
                Prms(2).Value = IIf(pIdPlantel = 0, DBNull.Value, pIdPlantel)
                Prms(3).Value = IIf(pZonaGeografica = 0, DBNull.Value, pZonaGeografica)
                Prms(4).Value = IIf(pRFCEmp = "", DBNull.Value, pRFCEmp)

                Return _DataCOBAEV.RunProc("SP_SEmpsParaEnvioDeComprobantes", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsParaEnvioDeComprobantesDePago(ByVal pIdQuincena As Short, ByVal pIdFondoPresup As Byte, _
                                                   ByVal pIdPlantel As Short, ByVal pZonaGeografica As Byte, _
                                                   ByVal pRFCEmp As String, ByVal pNumEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdFondoPresup", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdZonaGeografica", SqlDbType.TinyInt), _
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                              New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)}
                Prms(0).Value = pIdQuincena
                Prms(1).Value = pIdFondoPresup
                Prms(2).Value = IIf(pIdPlantel = 0, DBNull.Value, pIdPlantel)
                Prms(3).Value = IIf(pZonaGeografica = 0, DBNull.Value, pZonaGeografica)
                Prms(4).Value = IIf(pRFCEmp = "", DBNull.Value, pRFCEmp)
                Prms(5).Value = IIf(pNumEmp = "", DBNull.Value, pNumEmp)

                Return _DataCOBAEV.RunProc("SP_SEmpsParaEnvioDeComprobantes", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAmbitoAplicDePercDeduc() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SAmbitoConcepto", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaSimEmpTienePlazaVigente(ByVal pNumEmp As String) As Boolean
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)
                                            }
                Dim dr As DataRow

                Prms(0).Value = pNumEmp

                dr = _DataCOBAEV.RunProc("SP_VSiEmpTienePlazasVigentes", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("Result"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CalculaImpuestoPorLey(ByVal PercepcionesAGravar As Decimal, ByVal Mensual_O_Qnal As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ImpPercGrav", SqlDbType.Float), _
                                                New SqlParameter("@Mensual_O_Qnal", SqlDbType.NVarChar, 1)}

                Prms(0).Value = PercepcionesAGravar
                Prms(1).Value = Mensual_O_Qnal

                Return _DataCOBAEV.RunProc("SP_SCalculaImpuestoPorLey_Manual", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CalculaImpuestoPorReglamento(ByVal PercepcionesAGravar As Decimal, ByVal UltimoSueldoMensualOrdinario As Decimal, ByVal Dias As Short) As Decimal
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ImpPercGrav", SqlDbType.Float), _
                                                New SqlParameter("@ImpIngGrav", SqlDbType.Float), _
                                                New SqlParameter("@DiasPerc", SqlDbType.SmallInt), _
                                                New SqlParameter("@Importe", SqlDbType.Float)}

                Prms(0).Value = PercepcionesAGravar
                Prms(1).Value = UltimoSueldoMensualOrdinario
                Prms(2).Value = Dias
                Prms(3).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_SCalculaImpuestoPorReglamento_Manual", Prms, DataCOBAEV.BD.Nomina)

                Return Prms(3).Value
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoCompensacion(ByVal IdBanco As Byte, ByVal Año As Short, ByVal IdMesValue As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMesValue", SqlDbType.NVarChar, 5)}
                Prms(0).Value = IdBanco
                Prms(1).Value = Año
                Prms(2).Value = IdMesValue

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTCompensacion", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoCompensacion2(ByVal pIdBanco As Byte, ByVal pAnio As Short, _
                                                         ByVal pIdMesValue As String, pIdBancoInfComp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMesValue", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@IdBancoInfComp", SqlDbType.NVarChar, 2)
                                              }
                Prms(0).Value = pIdBanco
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMesValue
                Prms(3).Value = pIdBancoInfComp

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTCompensacion", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoCompenCLABE(ByVal pIdBanco As Byte, ByVal pAnio As Short, _
                                                                ByVal pIdMesValue As String, pIdBancoInfComp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMesValue", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@IdBancoInfComp", SqlDbType.NVarChar, 2)
                                              }
                Prms(0).Value = pIdBanco
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMesValue
                Prms(3).Value = pIdBancoInfComp

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTCompensacionCLABE", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoCompensacion2(ByVal pIdBanco As Byte, ByVal pAnio As Short, _
                                                         ByVal pIdMesValue As String, pIdBancoInfComp As String, _
                                                         ByVal pSecuencialAux As String, ByVal pFechaPagoAux As Date) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMesValue", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@IdBancoInfComp", SqlDbType.NVarChar, 2), _
                                                New SqlParameter("@SecuencialAux", SqlDbType.NVarChar, 4), _
                                               New SqlParameter("@FechaPagoAux", SqlDbType.DateTime)}
                Prms(0).Value = pIdBanco
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMesValue
                Prms(3).Value = pIdBancoInfComp
                Prms(4).Value = pSecuencialAux
                Prms(5).Value = pFechaPagoAux

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTCompensacion", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoCompenCLABE(ByVal pIdBanco As Byte, ByVal pAnio As Short, _
                                                         ByVal pIdMesValue As String, pIdBancoInfComp As String, _
                                                         ByVal pSecuencialAux As String, ByVal pFechaPagoAux As Date) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMesValue", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@IdBancoInfComp", SqlDbType.NVarChar, 2), _
                                                New SqlParameter("@SecuencialAux", SqlDbType.NVarChar, 4), _
                                               New SqlParameter("@FechaPagoAux", SqlDbType.DateTime)}
                Prms(0).Value = pIdBanco
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMesValue
                Prms(3).Value = pIdBancoInfComp
                Prms(4).Value = pSecuencialAux
                Prms(5).Value = pFechaPagoAux

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTCompensacionCLABE", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTDeduccionesMasivas(ByVal IdDeduccion As Short, ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                               New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdDeduccion

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTDeducsMasivas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoPACLABE(ByVal IdBanco As Byte, ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                               New SqlParameter("@IdBanco", SqlDbType.TinyInt)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdBanco

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTNominaPALayoutD", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoPACLABE(ByVal IdBanco As Byte, ByVal IdQuincena As Short, _
                                                   ByVal pSecuencialAux As String, ByVal pFechaPagoAux As Date) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                               New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                               New SqlParameter("@SecuencialAux", SqlDbType.NVarChar, 4), _
                                               New SqlParameter("@FechaPagoAux", SqlDbType.DateTime)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdBanco
                Prms(2).Value = pSecuencialAux
                Prms(3).Value = pFechaPagoAux

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTNominaPALayoutD", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoPA(ByVal IdBanco As Byte, ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                               New SqlParameter("@IdBanco", SqlDbType.TinyInt)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdBanco

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTNominaPA", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoPA(ByVal IdBanco As Byte, ByVal IdQuincena As Short, _
                                              ByVal pSecuencialAux As String, ByVal pFechaPagoAux As Date) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                               New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                               New SqlParameter("@SecuencialAux", SqlDbType.NVarChar, 4), _
                                               New SqlParameter("@FechaPagoAux", SqlDbType.DateTime)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdBanco
                Prms(2).Value = pSecuencialAux
                Prms(3).Value = pFechaPagoAux

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTNominaPA", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoPALayoutC(ByVal IdBanco As Byte, ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                               New SqlParameter("@IdBanco", SqlDbType.TinyInt)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdBanco

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTNominaPALayoutC", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomatico(ByVal IdBanco As Byte, ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                               New SqlParameter("@IdBanco", SqlDbType.TinyInt)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdBanco

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTNomina", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoCLABE(ByVal IdBanco As Byte, ByVal IdQuincena As Short, pCLABE As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                               New SqlParameter("@IdBanco", SqlDbType.TinyInt),
                                              New SqlParameter("@CLABE", SqlDbType.Bit)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdBanco
                Prms(2).Value = pCLABE

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTNomina", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomatico(ByVal IdBanco As Byte, ByVal IdQuincena As Short, _
                                            ByVal pSecuencialAux As String, ByVal pFechaPagoAux As Date) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                               New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                               New SqlParameter("@SecuencialAux", SqlDbType.NVarChar, 4), _
                                               New SqlParameter("@FechaPagoAux", SqlDbType.DateTime)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdBanco
                Prms(2).Value = pSecuencialAux
                Prms(3).Value = pFechaPagoAux

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTNomina", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTPagomaticoCLABE(ByVal IdBanco As Byte, ByVal IdQuincena As Short, _
                                    ByVal pSecuencialAux As String, ByVal pFechaPagoAux As Date, pCLABE As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                               New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                               New SqlParameter("@SecuencialAux", SqlDbType.NVarChar, 4), _
                                               New SqlParameter("@FechaPagoAux", SqlDbType.DateTime),
                                                New SqlParameter("@CLABE", SqlDbType.Bit)
                                              }
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdBanco
                Prms(2).Value = pSecuencialAux
                Prms(3).Value = pFechaPagoAux
                Prms(4).Value = pCLABE

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTNomina", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GetFondosPresupuestales() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SFondosPresupuestales", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GetEjerciciosAnteriores() As DataTable
            Try
                Return _DataCOBAEV.RunProc("[SP_SEjerciciosAnteriores]", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        

        Public Function GetFuentesFinanciamiento() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_FuentesFinanciamiento", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GetTiposDeImpuesto() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_STiposDeImpuesto", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaPagoQuincenal(ByVal IdQuincena As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = IdQuincena
                Return _DataCOBAEV.RunProc("SP_DHistoriaPago", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaPagoQuincenal(ByVal IdQuincena As Short, ByVal RFC As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = RFC
                Return _DataCOBAEV.RunProc("SP_DHistoriaPago", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaPagoQuincenal(ByVal IdQuincena As Short, ByVal IdPlantel As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPlantel", SqlDbType.SmallInt)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdPlantel
                Return _DataCOBAEV.RunProc("SP_DHistoriaPago", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

#Region "Clase TiposDeAdeudos"
    Public Class TiposDeAdeudos
#Region "Clase TiposDeAdeudos: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase TiposDeAdeudos: Métodos públicos"
        Public Function ObtenPorFuncionDelEmpleado(ByVal RFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_STiposDeAdeudos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

#Region "Clase TiposDeDevoluciones"
    Public Class TiposDeDevoluciones
#Region "Clase TiposDeDevoluciones: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase TiposDeDevoluciones: Métodos públicos"
        Public Function ObtenPorFuncionDelEmpleado(ByVal RFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_STiposDeDevoluciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

#Region "Clase PlazasDeduccionesCantidadVariable"
    Public Class PlazasDeduccionesCantidadVariable
#Region "Propiedades privadas"
        Private _IdDeduccion, _IdQnaVigIniDeduc, _IdQnaVigFinDeduc As Short
        Private _ImpDeduc As Decimal
        Private _DataCOBAEV As New DataCOBAEV
        Private _TipoOrden As String
#End Region
#Region "Propiedades públicas"
        Public Property IdDeduccion() As Short
            Get
                Return Me._IdDeduccion
            End Get
            Set(ByVal value As Short)
                Me._IdDeduccion = value
            End Set
        End Property
        Public Property IdQnaVigIniDeduc() As Short
            Get
                Return Me._IdQnaVigIniDeduc
            End Get
            Set(ByVal value As Short)
                Me._IdQnaVigIniDeduc = value
            End Set
        End Property
        Public Property IdQnaVigFinDeduc() As Short
            Get
                Return Me._IdQnaVigFinDeduc
            End Get
            Set(ByVal value As Short)
                Me._IdQnaVigFinDeduc = value
            End Set
        End Property
        Public Property ImpDeduc() As Decimal
            Get
                Return Me._ImpDeduc
            End Get
            Set(ByVal value As Decimal)
                Me._ImpDeduc = value
            End Set
        End Property
        Public Property TipoOrden() As String
            Get
                Return Me._TipoOrden
            End Get
            Set(ByVal value As String)
                Me._TipoOrden = value
            End Set
        End Property
#End Region
#Region "Métodos públicos"
        Public Function ValidaSiExisteRegistro(ByVal NumEmp As String) As Boolean
            Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5), _
                                            New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQnaVigIniDeduc", SqlDbType.SmallInt), _
                                            New SqlParameter("@ImpDeduc", SqlDbType.Decimal)}
            Dim dr As DataRow

            Prms(0).Value = NumEmp
            Prms(1).Value = Me._IdDeduccion
            Prms(2).Value = Me._IdQnaVigIniDeduc
            Prms(3).Value = Me._ImpDeduc

            dr = _DataCOBAEV.RunProc("SP_VDupEnPlazasDeduccionesCantidadVariable", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

            Return CBool(dr(0))
        End Function
        Public Function ValidaSiExisteRegistroPorCURP(ByVal CURPEmp As String) As Boolean
            Dim Prms As SqlParameter() = {New SqlParameter("@CURPEmp", SqlDbType.NVarChar, 18), _
                                            New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQnaVigIniDeduc", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQnaVigFinDeduc", SqlDbType.SmallInt), _
                                            New SqlParameter("@ImpDeduc", SqlDbType.Decimal), _
                                            New SqlParameter("@TipoOrden", SqlDbType.NVarChar, 5)}
            Dim dr As DataRow

            Prms(0).Value = CURPEmp
            Prms(1).Value = Me._IdDeduccion
            Prms(2).Value = Me._IdQnaVigIniDeduc
            Prms(3).Value = Me._IdQnaVigFinDeduc
            Prms(4).Value = Me._ImpDeduc
            Prms(5).Value = Me._TipoOrden

            dr = _DataCOBAEV.RunProc("SP_VDupEnPlazasDeduccionesCantidadVariable", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

            Return CBool(dr(0))
        End Function
#End Region
    End Class
#End Region

#Region "Clase PlazasPercepcionesCantidadVariable"
    Public Class PlazasPercepcionesCantidadVariable
#Region "Propiedades privadas"
        Private _IdPercepcion, _IdQnaVigIniPerc As Short
        Private _ImpPerc As Decimal
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Propiedades públicas"
        Public Property IdPercepcion() As Short
            Get
                Return Me._IdPercepcion
            End Get
            Set(ByVal value As Short)
                Me._IdPercepcion = value
            End Set
        End Property
        Public Property IdQnaVigIniPerc() As Short
            Get
                Return Me._IdQnaVigIniPerc
            End Get
            Set(ByVal value As Short)
                Me._IdQnaVigIniPerc = value
            End Set
        End Property
        Public Property ImpPerc() As Decimal
            Get
                Return Me._ImpPerc
            End Get
            Set(ByVal value As Decimal)
                Me._ImpPerc = value
            End Set
        End Property
#End Region
#Region "Métodos públicos"
        Public Function ValidaSiExisteRegistro(ByVal NumEmp As String) As Boolean
            Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5), _
                                            New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQnaVigIniPerc", SqlDbType.SmallInt), _
                                            New SqlParameter("@ImpPerc", SqlDbType.Decimal)}
            Dim dr As DataRow

            Prms(0).Value = NumEmp
            Prms(1).Value = Me._IdPercepcion
            Prms(2).Value = Me._IdQnaVigIniPerc
            Prms(3).Value = Me._ImpPerc

            dr = _DataCOBAEV.RunProc("SP_VDupEnPlazasPercepcionesCantidadVariable", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

            Return CBool(dr(0))
        End Function
#End Region
    End Class
#End Region

#Region "Clase Compensacion"
    Public Class Compensacion
#Region "Clase Compensacion: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Compensacion: Propiedades públicas"
        Public Enum TipoBusqueda
            RFC = 0
            Nombre = 1
            NumeroDeEmpleado = 2
            CURP = 3
        End Enum
#End Region
#Region "Clase Compensacion: Métodos públicos"
        Public Function BuscaAfectacionesPorAnioMes(ByVal pAnio As Short, ByVal pIdMes As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMes", SqlDbType.TinyInt)
                                            }

                Prms(0).Value = pAnio
                Prms(1).Value = pIdMes

                Return _DataCOBAEV.RunProc("SP_SBuscaAfectacionesPorAnioMes", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DeleteNombramiento(ByVal pIdPlaza As Integer, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@IdPlaza", SqlDbType.Int)
                                            }

                Prms(0).Value = pIdPlaza

                Return _DataCOBAEV.RunProc("SP_DEmpsSoloCompenPlazas", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdNombramientoAEmpleado(ByVal pIdPlaza As Integer, pIdPlantel As Short, pIdCT As Short, pIdCTSec As Short, pIdCategoria As Short, _
                                                 pIdFuncionPri As Short, pIdFuncionSec As Byte, pIdQuincenaIni As Short, _
                                                 pIdQuincenaFin As Short, pIdMotGralBaja As Byte, pEstaFisic As Boolean, _
                                                 pPrioridadNombCompen As Boolean, pIdEmpFuncion As Byte, _
                                                 ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdCT", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdCategoria", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdFuncionPri", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdFuncionSec", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdQuincenaIni", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQuincenaFin", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMotGralBaja", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdCTSec", SqlDbType.SmallInt), _
                                                New SqlParameter("@EstaFisicamente", SqlDbType.Bit), _
                                                New SqlParameter("@PrioridadNombCompen", SqlDbType.Bit), _
                                                New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt)
                                            }

                Prms(0).Value = pIdPlaza
                Prms(1).Value = pIdPlantel
                Prms(2).Value = pIdCT
                Prms(3).Value = pIdCategoria
                Prms(4).Value = pIdFuncionPri
                Prms(5).Value = pIdFuncionSec
                Prms(6).Value = pIdQuincenaIni
                Prms(7).Value = pIdQuincenaFin
                Prms(8).Value = pIdMotGralBaja
                Prms(9).Value = IIf(pIdCTSec = 0, DBNull.Value, pIdCTSec)
                Prms(10).Value = pEstaFisic
                Prms(11).Value = pPrioridadNombCompen
                Prms(12).Value = pIdEmpFuncion

                Return _DataCOBAEV.RunProc("SP_UEmpsSoloCompenPlazas", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AddNombramientoAEmpleado(ByVal pNumEmp As String, pIdPlantel As Short, pIdCT As Short, pIdCTSec As Short, pIdCategoria As Short, _
                                                 pIdFuncionPri As Short, pIdFuncionSec As Byte, pIdQuincenaIni As Short, _
                                                 pIdQuincenaFin As Short, pIdMotGralBaja As Byte, pEstaFisic As Boolean, _
                                                 pPrioridadNombCompen As Boolean, pIdEmpFuncion As Byte, _
                                                 ByVal ArregloAuditoria() As String) As Integer
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdCT", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdCategoria", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdFuncionPri", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdFuncionSec", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdQuincenaIni", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQuincenaFin", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMotGralBaja", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                New SqlParameter("@IdCTSec", SqlDbType.SmallInt), _
                                                New SqlParameter("@EstaFisicamente", SqlDbType.Bit), _
                                                New SqlParameter("@PrioridadNombCompen", SqlDbType.Bit), _
                                                New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt)
                                            }

                Prms(0).Value = pNumEmp
                Prms(1).Value = pIdPlantel
                Prms(2).Value = pIdCT
                Prms(3).Value = pIdCategoria
                Prms(4).Value = pIdFuncionPri
                Prms(5).Value = pIdFuncionSec
                Prms(6).Value = pIdQuincenaIni
                Prms(7).Value = pIdQuincenaFin
                Prms(8).Value = pIdMotGralBaja
                Prms(9).Direction = ParameterDirection.InputOutput
                Prms(10).Value = IIf(pIdCTSec = 0, DBNull.Value, pIdCTSec)
                Prms(11).Value = pEstaFisic
                Prms(12).Value = pPrioridadNombCompen
                Prms(13).Value = pIdEmpFuncion

                _DataCOBAEV.RunProc("SP_IEmpsSoloCompenPlazas", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Return CInt(Prms(9).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaSimEmpTienePlazaVigente(ByVal pNumEmp As String) As Boolean
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)
                                            }
                Dim dr As DataRow

                Prms(0).Value = pNumEmp

                dr = _DataCOBAEV.RunProc("SP_VEmpsSoloCompenTienePlazaVigente", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(dr("Result"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscaPlazasPorEmp(ByVal pIdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@IdPlaza", SqlDbType.Int)
                                            }

                Prms(0).Value = pIdPlaza

                Return _DataCOBAEV.RunProc("SP_SEmpsSoloCompenPlazas", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscaAniosConCompensacionPorEmp(ByVal pNumEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)
                                            }

                Prms(0).Value = pNumEmp

                Return _DataCOBAEV.RunProc("SP_SBuscaAniosEmpsConCompen", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscaAniosConCompenPorEmp(ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)
                                            }

                Prms(0).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SBuscaAniosEmpsConCompen2", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscaPlazaVigenteEnNominaPorEmp(ByVal pNumEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)
                                            }

                Prms(0).Value = pNumEmp

                Return _DataCOBAEV.RunProc("SP_SEmpsSoloCompenBuscaPlazaVigenteEnNomina", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscaPlazasPorEmp(ByVal pNumEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)
                                            }

                Prms(0).Value = pNumEmp

                Return _DataCOBAEV.RunProc("SP_SEmpsSoloCompenPlazas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarEmpleadosPorNumEmp(ByVal pTipoBusqueda As TipoBusqueda, ByVal pNumEmp As String, ByVal pOrigen As String) As DataTable
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@TipoBusqueda", SqlDbType.TinyInt), _
                                                New SqlParameter("@BuscaNumEmp", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@Origen", SqlDbType.NVarChar, 20)
                                            }

                Prms(0).Value = pTipoBusqueda
                Prms(1).Value = pNumEmp
                Prms(2).Value = pOrigen
                Return _DataCOBAEV.RunProc("SP_SBuscaEmpsEnCompen", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarEmpleados2(ByVal pTipoBusqueda As TipoBusqueda, pRFC As String, pNomEmp As String, pNumEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@TipoBusqueda", SqlDbType.TinyInt), _
                                                New SqlParameter("@RFC", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@NomEmp", SqlDbType.NVarChar, 90), _
                                                New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@BuscaComoEnNumFicticio", SqlDbType.Bit)
                                            }

                Prms(0).Value = pTipoBusqueda
                Prms(1).Value = pRFC
                Prms(2).Value = pNomEmp
                Prms(3).Value = pNumEmp
                Prms(4).Value = True
                Return _DataCOBAEV.RunProc("SP_SBuscaEmpsEnCompen", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function BuscarEmpleados(ByVal pTipoBusqueda As TipoBusqueda, pRFC As String, pNomEmp As String, pNumEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() =
                                            {
                                                New SqlParameter("@TipoBusqueda", SqlDbType.TinyInt), _
                                                New SqlParameter("@RFC", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@NomEmp", SqlDbType.NVarChar, 90), _
                                                New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5)
                                            }

                Prms(0).Value = pTipoBusqueda
                Prms(1).Value = pRFC
                Prms(2).Value = pNomEmp
                Prms(3).Value = pNumEmp
                Return _DataCOBAEV.RunProc("SP_SBuscaEmpsEnCompen", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function RecalculaISR(ByVal Anio As Short, ByVal IdMesValue As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMesValue", SqlDbType.NVarChar, 5)}

                Prms(0).Value = Anio
                Prms(1).Value = IdMesValue

                Return _DataCOBAEV.RunProc("SP_SRecalculaISRCompensaciones", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function TieneISRRecalculado(ByVal Anio As Short, ByVal IdMesValue As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                                New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                                New SqlParameter("@Recalculada", SqlDbType.Bit)}

                Prms(0).Value = Anio
                Prms(1).Value = CByte(IdMesValue.Substring(0, 2))
                Prms(2).Value = CByte(IdMesValue.Substring(3, 2))
                Prms(3).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_SCompensacionRecalculadaISR", Prms, DataCOBAEV.BD.Nomina)

                Return CBool(Prms(3).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaModificacion(ByVal IdEmp As Integer, ByVal Origen As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                                New SqlParameter("@Origen", SqlDbType.NVarChar, 30)}

                Prms(0).Value = IdEmp
                Prms(1).Value = Origen

                Return _DataCOBAEV.RunProc("SP_SCompensaciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaModificacionC1(ByVal pRFCEmp As String, ByVal pAnio As Short, ByVal pIdMes As Byte, _
                                               ByVal pAdicional As Byte, ByVal pOrigen As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                              New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMes
                Prms(3).Value = pAdicional
                Prms(4).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_SCompensaciones2", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaModificacionC2(ByVal pClaveCobro As String, ByVal pAnio As Short, ByVal pIdMes As Byte, _
                                               ByVal pAdicional As Byte, ByVal pOrigen As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                              New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pClaveCobro
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMes
                Prms(3).Value = pAdicional
                Prms(4).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_SCompensaciones3", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNumsDeAdic(ByVal pRFCEmp As String, ByVal pAnio As Short, ByVal pIdMes As Byte, _
                                               ByVal pAdicional As Byte, ByVal pOrigen As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                              New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMes
                Prms(3).Value = pAdicional
                Prms(4).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_SCompenAdicionales", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNumsDeAdicC2(ByVal pClaveCobro As String, ByVal pAnio As Short, ByVal pIdMes As Byte, _
                                               ByVal pAdicional As Byte, ByVal pOrigen As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                              New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pClaveCobro
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMes
                Prms(3).Value = pAdicional
                Prms(4).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_SCompenAdicionales3", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNumsDeAdicC2(ByVal pClaveCobro As String, ByVal pAnio As Short, ByVal pOrigen As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pClaveCobro
                Prms(1).Value = pAnio
                Prms(2).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_SCompenAdicionales3", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNumsDeAdic(ByVal pRFCEmp As String, ByVal pAnio As Short, ByVal pOrigen As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio
                Prms(2).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_SCompenAdicionales", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaRegistro(ByVal pIdEmp As Integer, ByVal Origen As String, ByVal Importe As Decimal, ByVal PagarConCheque As Boolean, ByVal ClaveCobro As String, _
                                        ByVal IdBanco As Byte, ByVal CuentaBancaria As String, ByVal ApePat As String, ByVal ApeMat As String, ByVal Nombre As String, _
                                        ByVal Observaciones As String, ByVal MesesQueAmparaPago As Byte, ByVal NumEmpOficial As String, ByVal NumEmpAfectado As String, _
                                        ByVal pRFCEMP As String, ByVal pAnio As Short, ByVal pIdMes As Byte, _
                                        ByVal pAdicionalNew As Byte, ByVal pAdicionalAnt As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                                New SqlParameter("@Origen", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Importe", SqlDbType.Decimal), _
                                                New SqlParameter("@PagarConCheque", SqlDbType.Bit), _
                                                New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8), _
                                                New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@CuentaBancaria", SqlDbType.NVarChar, 18), _
                                                New SqlParameter("@ApePat", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@ApeMat", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Nombre", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Observaciones", SqlDbType.NVarChar, 100), _
                                                New SqlParameter("@MesesQueAmparaPago", SqlDbType.TinyInt), _
                                                New SqlParameter("@NumEmpOficial", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@NumEmpAfectado", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                                New SqlParameter("@AdicionalNew", SqlDbType.TinyInt), _
                                                New SqlParameter("@AdicionalAnt", SqlDbType.TinyInt)}

                If Origen = "C2" Then
                    Prms(0).Value = pIdEmp
                Else
                    Prms(0).Value = DBNull.Value
                End If

                Prms(1).Value = Origen
                Prms(2).Value = Importe
                Prms(3).Value = PagarConCheque
                Prms(4).Value = ClaveCobro
                Prms(5).Value = IdBanco
                Prms(6).Value = CuentaBancaria
                If Origen = "C2" Then
                    Prms(7).Value = ApePat
                    Prms(8).Value = ApeMat
                    Prms(9).Value = Nombre
                    'Prms(10).Value = Observaciones
                Else
                    Prms(7).Value = DBNull.Value
                    Prms(8).Value = DBNull.Value
                    Prms(9).Value = DBNull.Value
                    'Prms(10).Value = DBNull.Value
                End If
                Prms(10).Value = Observaciones
                Prms(11).Value = MesesQueAmparaPago
                Prms(12).Value = NumEmpOficial
                Prms(13).Value = NumEmpAfectado
                Prms(14).Value = pRFCEMP
                Prms(15).Value = pAnio
                Prms(16).Value = pIdMes
                Prms(17).Value = pAdicionalNew
                Prms(18).Value = pAdicionalAnt

                Return _DataCOBAEV.RunProc("SP_UCompensaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaRegistro(ByVal pIdEmp As Integer, ByVal Origen As String, ByVal Importe As Decimal, ByVal PagarConCheque As Boolean, ByVal ClaveCobro As String, _
                                        ByVal IdBanco As Byte, ByVal CuentaBancaria As String, ByVal ApePat As String, ByVal ApeMat As String, ByVal Nombre As String, _
                                        ByVal Observaciones As String, ByVal MesesQueAmparaPago As Byte, ByVal NumEmpOficial As String, ByVal NumEmpAfectado As String, _
                                        ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                                New SqlParameter("@Origen", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Importe", SqlDbType.Decimal), _
                                                New SqlParameter("@PagarConCheque", SqlDbType.Bit), _
                                                New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8), _
                                                New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@CuentaBancaria", SqlDbType.NVarChar, 18), _
                                                New SqlParameter("@ApePat", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@ApeMat", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Nombre", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Observaciones", SqlDbType.NVarChar, 100), _
                                                New SqlParameter("@MesesQueAmparaPago", SqlDbType.TinyInt), _
                                                New SqlParameter("@NumEmpOficial", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@NumEmpAfectado", SqlDbType.NVarChar, 5)}

                Prms(0).Value = pIdEmp
                Prms(1).Value = Origen
                Prms(2).Value = Importe
                Prms(3).Value = PagarConCheque
                Prms(4).Value = ClaveCobro
                Prms(5).Value = IdBanco
                Prms(6).Value = CuentaBancaria
                If Origen = "EXTRAORDINARIO" Then
                    Prms(7).Value = ApePat
                    Prms(8).Value = ApeMat
                    Prms(9).Value = Nombre
                    'Prms(10).Value = Observaciones
                Else
                    Prms(7).Value = DBNull.Value
                    Prms(8).Value = DBNull.Value
                    Prms(9).Value = DBNull.Value
                    'Prms(10).Value = DBNull.Value
                End If
                Prms(10).Value = Observaciones
                Prms(11).Value = MesesQueAmparaPago
                Prms(12).Value = NumEmpOficial
                Prms(13).Value = NumEmpAfectado

                Return _DataCOBAEV.RunProc("SP_UCompensaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaRegistro2(ByVal IdEmp As Integer, ByVal Origen As String, ByVal Importe As Decimal, ByVal PagarConCheque As Boolean, ByVal ClaveCobro As String, _
                                ByVal IdBanco As Byte, ByVal CuentaBancaria As String, ByVal ApePat As String, ByVal ApeMat As String, ByVal Nombre As String, _
                                ByVal Observaciones As String, ByVal MesesQueAmparaPago As Byte, ByVal NumEmpOficial As String, ByVal NumEmpAfectado As String, _
                                ByVal ArregloAuditoria() As String) As Integer
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                                New SqlParameter("@Origen", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Importe", SqlDbType.Decimal), _
                                                New SqlParameter("@PagarConCheque", SqlDbType.Bit), _
                                                New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8), _
                                                New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@CuentaBancaria", SqlDbType.NVarChar, 18), _
                                                New SqlParameter("@ApePat", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@ApeMat", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Nombre", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Observaciones", SqlDbType.NVarChar, 100), _
                                                New SqlParameter("@MesesQueAmparaPago", SqlDbType.TinyInt), _
                                                New SqlParameter("@NumEmpOficial", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@NumEmpAfectado", SqlDbType.NVarChar, 5)}

                Prms(0).Direction = ParameterDirection.InputOutput
                Prms(0).Value = IIf(IdEmp = 0, DBNull.Value, IdEmp)
                Prms(1).Value = Origen
                Prms(2).Value = Importe
                Prms(3).Value = PagarConCheque
                Prms(4).Value = ClaveCobro
                Prms(5).Value = IdBanco
                Prms(6).Value = CuentaBancaria
                If Origen = "EXTRAORDINARIO" Then
                    Prms(7).Value = ApePat
                    Prms(8).Value = ApeMat
                    Prms(9).Value = Nombre
                    'Prms(10).Value = Observaciones
                Else
                    Prms(7).Value = DBNull.Value
                    Prms(8).Value = DBNull.Value
                    Prms(9).Value = DBNull.Value
                    'Prms(10).Value = DBNull.Value
                End If
                Prms(10).Value = Observaciones
                Prms(11).Value = MesesQueAmparaPago
                Prms(12).Value = NumEmpOficial
                Prms(13).Value = NumEmpAfectado

                _DataCOBAEV.RunProc("SP_ICompensaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Return CInt(Prms(0).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaRegistro(ByVal RFCEmp As String, ByVal Origen As String, ByVal Importe As Decimal, ByVal PagarConCheque As Boolean, ByVal ClaveCobro As String, _
                                        ByVal IdBanco As Byte, ByVal CuentaBancaria As String, ByVal ApePat As String, ByVal ApeMat As String, ByVal Nombre As String, _
                                        ByVal Observaciones As String, ByVal MesesQueAmparaPago As Byte, ByVal NumEmpOficial As String, ByVal NumEmpAfectado As String, _
                                        ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@Origen", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Importe", SqlDbType.Decimal), _
                                                New SqlParameter("@PagarConCheque", SqlDbType.Bit), _
                                                New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8), _
                                                New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@CuentaBancaria", SqlDbType.NVarChar, 18), _
                                                New SqlParameter("@ApePat", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@ApeMat", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Nombre", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Observaciones", SqlDbType.NVarChar, 100), _
                                                New SqlParameter("@MesesQueAmparaPago", SqlDbType.TinyInt), _
                                                New SqlParameter("@NumEmpOficial", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@NumEmpAfectado", SqlDbType.NVarChar, 5)}

                Prms(0).Value = RFCEmp
                Prms(1).Value = Origen
                Prms(2).Value = Importe
                Prms(3).Value = PagarConCheque
                Prms(4).Value = ClaveCobro
                Prms(5).Value = IdBanco
                Prms(6).Value = CuentaBancaria
                If Origen = "EXTRAORDINARIO" Then
                    Prms(7).Value = ApePat
                    Prms(8).Value = ApeMat
                    Prms(9).Value = Nombre
                    'Prms(10).Value = Observaciones
                Else
                    Prms(7).Value = DBNull.Value
                    Prms(8).Value = DBNull.Value
                    Prms(9).Value = DBNull.Value
                    'Prms(10).Value = DBNull.Value
                End If
                Prms(10).Value = Observaciones
                Prms(11).Value = MesesQueAmparaPago
                Prms(12).Value = NumEmpOficial
                Prms(13).Value = NumEmpAfectado

                Return _DataCOBAEV.RunProc("SP_ICompensaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaRegistro(ByVal RFCEmp As String, ByVal Origen As String, ByVal Importe As Decimal, ByVal PagarConCheque As Boolean, ByVal ClaveCobro As String, _
                                        ByVal IdBanco As Byte, ByVal CuentaBancaria As String, ByVal ApePat As String, ByVal ApeMat As String, ByVal Nombre As String, _
                                        ByVal Observaciones As String, ByVal MesesQueAmparaPago As Byte, ByVal NumEmpOficial As String, ByVal NumEmpAfectado As String, _
                                        ByVal pAnio As Short, ByVal pIdMes As Byte, ByVal pAdicional As Byte,
                                        ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@Origen", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Importe", SqlDbType.Decimal), _
                                                New SqlParameter("@PagarConCheque", SqlDbType.Bit), _
                                                New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8), _
                                                New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                                New SqlParameter("@CuentaBancaria", SqlDbType.NVarChar, 18), _
                                                New SqlParameter("@ApePat", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@ApeMat", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Nombre", SqlDbType.NVarChar, 30), _
                                                New SqlParameter("@Observaciones", SqlDbType.NVarChar, 100), _
                                                New SqlParameter("@MesesQueAmparaPago", SqlDbType.TinyInt), _
                                                New SqlParameter("@NumEmpOficial", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@NumEmpAfectado", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                                New SqlParameter("@Adicional", SqlDbType.TinyInt)}

                Prms(0).Value = RFCEmp
                Prms(1).Value = Origen
                Prms(2).Value = Importe
                Prms(3).Value = PagarConCheque
                Prms(4).Value = ClaveCobro
                Prms(5).Value = IdBanco
                Prms(6).Value = CuentaBancaria
                If Origen = "C2" Then
                    Prms(7).Value = ApePat
                    Prms(8).Value = ApeMat
                    Prms(9).Value = Nombre
                    'Prms(10).Value = Observaciones
                Else
                    Prms(7).Value = DBNull.Value
                    Prms(8).Value = DBNull.Value
                    Prms(9).Value = DBNull.Value
                    'Prms(10).Value = DBNull.Value
                End If
                Prms(10).Value = Observaciones
                Prms(11).Value = MesesQueAmparaPago
                Prms(12).Value = NumEmpOficial
                Prms(13).Value = NumEmpAfectado
                Prms(14).Value = pAnio
                Prms(15).Value = pIdMes
                Prms(16).Value = pAdicional

                Return _DataCOBAEV.RunProc("SP_ICompensaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function PosiblesDatosParaNuevaCompe(ByVal RFCEmp As String, ByVal IdEmp As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdEmp2", SqlDbType.Int)}

                Prms(0).Value = IIf(RFCEmp = String.Empty, DBNull.Value, RFCEmp)
                Prms(1).Value = IIf(IdEmp = 0, DBNull.Value, IdEmp)

                Return _DataCOBAEV.RunProc("SP_SPosiblesDatosParaNuevaCompensacion", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function PosiblesDatosParaNuevaCompe(ByVal pClaveCobro As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8)}

                Prms(0).Value = pClaveCobro

                Return _DataCOBAEV.RunProc("SP_SPosiblesDatosParaNuevaCompensacion", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaRegistro(ByVal IdEmp As Integer, ByVal Origen As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                                New SqlParameter("@Origen", SqlDbType.NVarChar, 30)}

                Prms(0).Value = IdEmp
                Prms(1).Value = Origen

                Return _DataCOBAEV.RunProc("SP_DCompensaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaRegistroC1(ByVal pRFCEmp As String, ByVal pAnio As Short, ByVal pIdMes As Byte, _
                                               ByVal pAdicional As Byte, ByVal pOrigen As String, _
                                               ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                              New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMes
                Prms(3).Value = pAdicional
                Prms(4).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_DCompensaciones2", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaRegistroC2(ByVal pClaveCobro As String, ByVal pAnio As Short, ByVal pIdMes As Byte, _
                                               ByVal pAdicional As Byte, ByVal pOrigen As String, _
                                               ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                              New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pClaveCobro
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMes
                Prms(3).Value = pAdicional
                Prms(4).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_DCompensaciones3", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CreaSigMesParaPago(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Return _DataCOBAEV.RunProc("SP_ICompensacionesParaNuevoAnioMes", DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CreaMesAdic(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Return _DataCOBAEV.RunProc("SP_IAniosMesesCompeAdic", DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CreaSigMesParaPago(ByVal pAnio As Short, ByVal pIdMes As Byte, ByVal pAdicional As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                                New SqlParameter("@Adicional", SqlDbType.TinyInt)}

                Prms(0).Value = pAnio
                Prms(1).Value = pIdMes
                Prms(2).Value = pAdicional

                Return _DataCOBAEV.RunProc("SP_IAniosMesesCompensaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSigMesParaPago() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SSigMesParaPagoDeCompensacion", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAñosPagados(ByVal ParaRecalculoDeISR As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaRecalculoDeISR", SqlDbType.Bit)}
                Prms(0).Value = ParaRecalculoDeISR
                Return _DataCOBAEV.RunProc("SP_SAniosCompensaciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAñosPagados() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SAniosCompensaciones", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEstatusAnioMesAdic(ByVal Año As Short, ByVal IdMesValue As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMesValue", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@EstatusAnioMesAdic", SqlDbType.Bit)}

                Prms(0).Value = Año
                Prms(1).Value = IdMesValue
                Prms(2).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_SDeterminaEstatusDeAnioMesAdic", Prms, DataCOBAEV.BD.Nomina)

                Return CBool(Prms(2).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMesesPagadosPorAño(ByVal Año As Short, ByVal ParaRecalculoDeISR As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@ParaRecalculoDeISR", SqlDbType.Bit)}

                Prms(0).Value = Año
                Prms(1).Value = ParaRecalculoDeISR

                Return _DataCOBAEV.RunProc("SP_SMesesCompensacionesPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEmpsPorAñoMes(ByVal Año As Short, ByVal IdMesValue As String) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMesValue", SqlDbType.NVarChar, 5)}

                Prms(0).Value = Año
                Prms(1).Value = IdMesValue

                Return _DataCOBAEV.RunProc("SP_SEmpsConCompePorAnioMes", Prms, "EmpsConCompePorAnioMes", DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAcumuladoPorEmp(ByVal IdEmp As Integer, ByVal Anio As Short, ByVal Origen As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@Origen", SqlDbType.NVarChar, 30)}

                Prms(0).Value = IdEmp
                Prms(1).Value = Anio
                Prms(2).Value = Origen

                Return _DataCOBAEV.RunProc("SP_SEmpCompeAcumuladaPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAcumuladoPorEmp2(ByVal pRFCEmp As String, ByVal pAnio As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SEmpCompeAcumuladaPorAnio2", Prms, "EmpCompeAcumuladaPorAnio2", DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAcumuladoPorEmp3(ByVal pClaveCobro As String, ByVal pAnio As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCobro", SqlDbType.NVarChar, 8), _
                                                New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pClaveCobro
                Prms(1).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SEmpCompeAcumuladaPorAnio3", Prms, "EmpCompeAcumuladaPorAnio3", DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMesesPorAnio(ByVal pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SAniosMesesCompensaciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaISRRecalculado(ByVal pAnio As Short, ByVal pIdMes As Byte) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt)}

                Prms(0).Value = pAnio
                Prms(1).Value = pIdMes

                Return _DataCOBAEV.RunProc("SP_VRecalculoISRCompe", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaSiHayMesAbiertoParaCaptura(ByVal pAnio As Short, ByVal pIdMes As Byte, ByVal pAdicional As Byte) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                              New SqlParameter("@Adicional", SqlDbType.TinyInt)}

                Prms(0).Value = pAnio
                Prms(1).Value = pIdMes
                Prms(2).Value = pAdicional

                Return _DataCOBAEV.RunProc("SP_VSiHayMesAbiertoParaCompe", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaSiHayMesAbiertoParaCaptura() As DataRow
            Try
                Return _DataCOBAEV.RunProc("SP_VSiHayMesAbiertoParaCompe", DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function UpdAniosMesesCompensaciones(ByVal pAnio As Short, ByVal pIdMes As Byte, ByVal pAdicional As Byte, ByVal pCerrado As Boolean, _
                                                    ByVal pISRRecalculado As Boolean, ByVal pComentarios As String, ByVal pFechaDePago As Date, _
                                                    ByVal pMesNormal As Boolean, ByVal pMesComp As Boolean, _
                                                    ByVal pNumAfect1 As String, ByVal pNumAfect2 As String, _
                                                    ByVal pDescDelPago As String, _
                                                    ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdMes", SqlDbType.TinyInt), _
                                                New SqlParameter("@Adicional", SqlDbType.TinyInt), _
                                                New SqlParameter("@Cerrado", SqlDbType.Bit), _
                                                New SqlParameter("@ISRRecalculado", SqlDbType.Bit), _
                                                New SqlParameter("@Comentarios", SqlDbType.NVarChar, 100), _
                                                New SqlParameter("@FechaDePago", SqlDbType.DateTime), _
                                                New SqlParameter("@MesNormal", SqlDbType.Bit), _
                                                New SqlParameter("@Complementaria", SqlDbType.Bit), _
                                                New SqlParameter("@NumAfect1", SqlDbType.NVarChar, 20), _
                                                New SqlParameter("@NumAfect2", SqlDbType.NVarChar, 20), _
                                                New SqlParameter("@DescDelPago", SqlDbType.NVarChar, 200)}

                Prms(0).Value = pAnio
                Prms(1).Value = pIdMes
                Prms(2).Value = pAdicional
                Prms(3).Value = pCerrado
                Prms(4).Value = pISRRecalculado
                Prms(5).Value = pComentarios
                Prms(6).Value = pFechaDePago
                Prms(7).Value = pMesNormal
                Prms(8).Value = pMesComp
                Prms(9).Value = pNumAfect1
                Prms(10).Value = pNumAfect2
                Prms(11).Value = pDescDelPago

                Return _DataCOBAEV.RunProc("SP_UAniosMesesCompensaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

#Region "Clase Devolucion"
    Public Class Devolucion
#Region "Clase Devolucion: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Devolucion: Propiedades públicas"

#End Region
#Region "Clase Devolucion: Métodos públicos"
        Public Function ObtenQnaRealDePago(ByVal pRFCEmp As String, ByVal pIdQuincenaAdeudo As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQuincenaAdeudo", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdQuincenaAdeudo

                Return _DataCOBAEV.RunProc("SP_SQnaRealDePagoDeAdeudo", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSiExisteDevolucion(ByVal RFCEmp As String, ByVal IdQnaPago As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQnaPago", SqlDbType.SmallInt)}

                Prms(0).Value = RFCEmp
                Prms(1).Value = IdQnaPago

                Return _DataCOBAEV.RunProc("SP_SExisteDevolucion", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraDevolucion(ByVal RFCEmp As String, ByVal IdQnaPago As Short, ByVal IdQnaDev As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQnaPago", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQnaDev", SqlDbType.SmallInt)}

                Prms(0).Value = RFCEmp
                Prms(1).Value = IdQnaPago
                Prms(2).Value = IdQnaDev

                Return _DataCOBAEV.RunProc("SP_IHistoriaDevoluciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAniosParaConsulta() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SAniosParaConsultaDeDevs", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasPorAnioParaConsulta(ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SQnasPorAnioParaConsultaDeDevs", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDevsPorAnioQna(ByVal Anio As Short, ByVal IdQuincenaDevolucion As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQuincenaDevolucion", SqlDbType.SmallInt)}

                Prms(0).Value = Anio
                Prms(1).Value = IdQuincenaDevolucion

                Return _DataCOBAEV.RunProc("SP_SDevolsPorAnioQuincena", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

#Region "Clase Adeudo"
    Public Class Adeudo
#Region "Clase Adeudo: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Adeudo: Propiedades públicas"

#End Region
#Region "Clase Adeudo: Métodos públicos"
        Public Function ObtenQnaOrdRealDePago(ByVal pRFCEmp As String, ByVal pIdQuincenaAdic As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQuincenaAdic", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdQuincenaAdic

                Return _DataCOBAEV.RunProc("SP_SQnaOrdRealDelPagoAdic", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnaRealDePago(ByVal pRFCEmp As String, ByVal pIdQuincenaAdeudo As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQuincenaAdeudo", SqlDbType.SmallInt)}

                Prms(0).Value = pRFCEmp
                Prms(1).Value = pIdQuincenaAdeudo

                Return _DataCOBAEV.RunProc("SP_SQnaRealDePagoDeAdeudo", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace