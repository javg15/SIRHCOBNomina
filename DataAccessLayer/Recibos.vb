Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV.Nominas
#Region "Clase Recibos"
    Public Class Recibos
#Region "Propiedades privadas: Clase Recibos"
        Private _DataCOBAEV As New DataCOBAEV
        Private _Anio, _IdUsuario, _IdRecibo, _IdQuincenaAplicacion, _IdConcepto As Short
        Private _Fecha, _FechaRealDePago As Date
        Private _IdEstatusRecibo, _IdTipoRecibo, _IdFondoPresup As Byte
        Private _RFCEmp, _ObservacionesRecibo, _TipoConcepto, _QnaIniAdeudo, _QnaFinAdeudo, _ClaveDeCobro As String
        Private _IdEmp, _IdPlaza As Integer
        Private _Importe, _ImporteParaAguinaldo, _ImporteParaRetroactivo, _ImporteGravado As Decimal
        Private _DiasExentos As Decimal
        Private _ReciboImplicaAdeudo, _MostrarEnRecibo As Boolean
        Private _IgnorarEmpParaPasivos, _IgnorarReciboParaDecAnual, _ReciboDeSustitucion As Boolean
        Private _Recibotimbrado As Boolean
        Private _SubsidioCausado As Decimal
        Private _AnioPasivos As Integer
        Private _PagaTercero As Integer
        Private _IdBeneficiario As Integer
        Private _NombreBeneficiario As String
#End Region
#Region "Propiedades públicas: Clase Recibos"
        Public Property DiasExentos() As Decimal
            Get
                Return _DiasExentos
            End Get
            Set(ByVal value As Decimal)
                _DiasExentos = value
            End Set
        End Property
        Public Property SubsidioCausado() As Decimal
            Get
                Return _SubsidioCausado
            End Get
            Set(ByVal value As Decimal)
                _SubsidioCausado = value
            End Set
        End Property
        Public Property Recibotimbrado() As Boolean
            Get
                Return _Recibotimbrado
            End Get
            Set(ByVal value As Boolean)
                _Recibotimbrado = value
            End Set
        End Property
        Public Property ReciboDeSustitucion() As Boolean
            Get
                Return _ReciboDeSustitucion
            End Get
            Set(ByVal value As Boolean)
                _ReciboDeSustitucion = value
            End Set
        End Property
        Public Property IgnorarReciboParaDecAnual() As Boolean
            Get
                Return _IgnorarReciboParaDecAnual
            End Get
            Set(ByVal value As Boolean)
                _IgnorarReciboParaDecAnual = value
            End Set
        End Property
        Public Property IgnorarEmpParaPasivos() As Boolean
            Get
                Return _IgnorarEmpParaPasivos
            End Get
            Set(ByVal value As Boolean)
                _IgnorarEmpParaPasivos = value
            End Set
        End Property
        Public Property ImporteGravado() As Decimal
            Get
                Return Me._ImporteGravado
            End Get
            Set(ByVal value As Decimal)
                Me._ImporteGravado = value
            End Set
        End Property
        Public Property MostrarEnRecibo() As Boolean
            Get
                Return Me._MostrarEnRecibo
            End Get
            Set(ByVal value As Boolean)
                Me._MostrarEnRecibo = value
            End Set
        End Property
        Public Property ReciboImplicaAdeudo() As Boolean
            Get
                Return Me._ReciboImplicaAdeudo
            End Get
            Set(ByVal value As Boolean)
                Me._ReciboImplicaAdeudo = value
            End Set
        End Property
        Public Property ImporteParaAguinaldo() As Decimal
            Get
                Return Me._ImporteParaAguinaldo
            End Get
            Set(ByVal value As Decimal)
                Me._ImporteParaAguinaldo = value
            End Set
        End Property
        Public Property ImporteParaRetroactivo() As Decimal
            Get
                Return Me._ImporteParaRetroactivo
            End Get
            Set(ByVal value As Decimal)
                Me._ImporteParaRetroactivo = value
            End Set
        End Property
        Public Property Importe() As Decimal
            Get
                Return Me._Importe
            End Get
            Set(ByVal value As Decimal)
                Me._Importe = value
            End Set
        End Property
        Public Property TipoConcepto() As String
            Get
                Return Me._TipoConcepto
            End Get
            Set(ByVal value As String)
                Me._TipoConcepto = value
            End Set
        End Property
        Public Property IdConcepto() As Short
            Get
                Return Me._IdConcepto
            End Get
            Set(ByVal value As Short)
                Me._IdConcepto = value
            End Set
        End Property
        Public Property IdQuincenaAplicacion() As Short
            Get
                Return Me._IdQuincenaAplicacion
            End Get
            Set(ByVal value As Short)
                Me._IdQuincenaAplicacion = value
            End Set
        End Property
        Public Property IdEmp() As Integer
            Get
                Return Me._IdEmp
            End Get
            Set(ByVal value As Integer)
                Me._IdEmp = value
            End Set
        End Property
        Public Property IdPlaza() As Integer
            Get
                Return Me._IdPlaza
            End Get
            Set(ByVal value As Integer)
                Me._IdPlaza = value
            End Set
        End Property
        Public Property AnioPasivos As Integer
            Get
                Return Me._AnioPasivos
            End Get
            Set(value As Integer)
                Me._AnioPasivos = value
            End Set
        End Property
        Public Property PagaTercero As Integer
            Get
                Return Me._PagaTercero
            End Get
            Set(value As Integer)
                Me._PagaTercero = value

            End Set
        End Property

        Public Property IdBeneficiario As Integer
            Get
                Return Me._IdBeneficiario
            End Get
            Set(value As Integer)
                Me._IdBeneficiario = value
            End Set
        End Property

        Public Property NombreBeneficiario As Integer
            Get
                Return Me._NombreBeneficiario
            End Get
            Set(value As Integer)
                Me._NombreBeneficiario = value
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
        Public Property ObservacionesRecibo() As String
            Get
                Return Me._ObservacionesRecibo
            End Get
            Set(ByVal value As String)
                Me._ObservacionesRecibo = value
            End Set
        End Property
        Public Property Anio() As Short
            Get
                Return Me._Anio
            End Get
            Set(ByVal value As Short)
                Me._Anio = value
            End Set
        End Property
        Public Property Fecha() As Date
            Get
                Return Me._Fecha
            End Get
            Set(ByVal value As Date)
                Me._Fecha = value
            End Set
        End Property
        Public Property FechaRealDePago() As Date
            Get
                Return _FechaRealDePago
            End Get
            Set(ByVal value As Date)
                _FechaRealDePago = value
            End Set
        End Property
        Public Property IdUsuario() As Short
            Get
                Return Me._IdUsuario
            End Get
            Set(ByVal value As Short)
                Me._IdUsuario = value
            End Set
        End Property
        Public Property IdRecibo() As Short
            Get
                Return Me._IdRecibo
            End Get
            Set(ByVal value As Short)
                Me._IdRecibo = value
            End Set
        End Property
        Public Property IdEstatusRecibo() As Byte
            Get
                Return Me._IdEstatusRecibo
            End Get
            Set(ByVal value As Byte)
                Me._IdEstatusRecibo = value
            End Set
        End Property
        Public Property IdTipoRecibo() As Byte
            Get
                Return Me._IdTipoRecibo
            End Get
            Set(ByVal value As Byte)
                Me._IdTipoRecibo = value
            End Set
        End Property
        Public Property IdFondoPresup() As Byte
            Get
                Return Me._IdFondoPresup
            End Get
            Set(ByVal value As Byte)
                Me._IdFondoPresup = value
            End Set
        End Property
        Public Property QnaIniAdeudo() As String
            Get
                Return Me._QnaIniAdeudo
            End Get
            Set(ByVal value As String)
                Me._QnaIniAdeudo = value
            End Set
        End Property
        Public Property QnaFinAdeudo() As String
            Get
                Return Me._QnaFinAdeudo
            End Get
            Set(ByVal value As String)
                Me._QnaFinAdeudo = value
            End Set
        End Property
        Public Property ClaveDeCobro() As String
            Get
                Return Me._ClaveDeCobro
            End Get
            Set(ByVal value As String)
                Me._ClaveDeCobro = value
            End Set
        End Property
#End Region

#Region "Métodos públicos: Clase Recibos"
        Public Function TipoDeReciboPermiteCapturaDeDatosComp(ByVal pIdTipoRecibo As Byte) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTipoRecibo", SqlDbType.TinyInt), _
                                              New SqlParameter("@PermiteCapturaDeDatosComp", SqlDbType.Bit)}
                Prms(0).Value = pIdTipoRecibo
                Prms(1).Direction = ParameterDirection.InputOutput

                _DataCOBAEV.RunProc("SP_SReciboPermiteCapturaDeDatosComp", Prms, DataCOBAEV.BD.Nomina)

                Return CBool(Prms(1).Value)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaSubsidioCausado(ByVal pIdRecubo As Short, ByVal pSubsidioCausado As Decimal, _
                                                 ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                             New SqlParameter("@SubsidioCausado", SqlDbType.Decimal)}

                Prms(0).Value = pIdRecubo
                Prms(1).Value = pSubsidioCausado

                Return _DataCOBAEV.RunProc("SP_URecibosSubsidioCausado", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function DeterminaObservaciones(ByVal IdRecibo As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}

                Prms(0).Value = IdRecibo

                Return _DataCOBAEV.RunProc("SP_VDeterminaObservsSobreRecibos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaDevolucion(ByVal IdRecibo As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}

                Prms(0).Value = IdRecibo

                Return _DataCOBAEV.RunProc("SP_DRecibosDevoluciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraDevolucion(ByVal IdRecibo As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}

                Prms(0).Value = IdRecibo

                Return _DataCOBAEV.RunProc("SP_IRecibosDevoluciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaEnEmpleadosRecibos(ByVal RFCEmp As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = RFCEmp

                Return _DataCOBAEV.RunProc("SP_IEmpleadosRecibos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaEmpleadosRecibos(ByVal IdEmp As Integer, ByVal IdQnaIni As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                             New SqlParameter("@IdQnaIni", SqlDbType.SmallInt)}

                Prms(0).Value = IdEmp
                Prms(1).Value = IdQnaIni

                Return _DataCOBAEV.RunProc("SP_DEmpleadosRecibos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ValidaSiProcedeEliminarEmpleadosRecibos(ByVal IdEmp As Integer, ByVal IdQnaIni As Short, ByVal IdQnaFin As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                             New SqlParameter("@IdQnaIni", SqlDbType.SmallInt), _
                                             New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}
                Dim dr As DataRow

                Prms(0).Value = IdEmp
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin

                dr = _DataCOBAEV.RunProc("SP_VSiProcedeDEmpleadosRecibos", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
                Return CBool(dr(0))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaEmpleadosRecibos(ByVal IdEmp As Integer, ByVal IdQnaIni As Short, ByVal IdQnaFin As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                             New SqlParameter("@IdQnaIni", SqlDbType.SmallInt), _
                                             New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}

                Prms(0).Value = IdEmp
                Prms(1).Value = IdQnaIni
                Prms(2).Value = IdQnaFin

                Return _DataCOBAEV.RunProc("SP_UEmpleadosRecibos", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasParaVigFin(ByVal IdQnaIni As Short, ByVal IdQnaFin As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQnaIni", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQnaFin", SqlDbType.SmallInt)}

                Prms(0).Value = IdQnaIni
                Prms(1).Value = IdQnaFin

                Return _DataCOBAEV.RunProc("SP_SQnasParaVigFinalDeRecibos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEmpleados() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEmpleadosRecibos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasPorAnioParaConsulta(ByVal Anio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = Anio

                Return _DataCOBAEV.RunProc("SP_SQnasPorAnioParaConsultaDeRecibos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenQnasPorAnioParaConsulta(ByVal pAnio As Short, ByVal pLogin As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}

                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                Dim drPropiedadesDelRol As DataRow
                oUsr.Login = pLogin
                drUsr = oUsr.ObtenerPorLogin()
                drPropiedadesDelRol = oUsr.ObtenerPropiedadesDelRol().Rows(0)

                Prms(0).Value = pAnio
                Prms(1).Value = CByte(drPropiedadesDelRol("IdRol"))
                Prms(2).Value = CBool(drPropiedadesDelRol("ConsultaZonasEspecificas"))
                Prms(3).Value = CBool(drPropiedadesDelRol("ConsultaPlantelesEspecificos"))
                Prms(4).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SQnasPorAnioParaConsultaDeRecibos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaEstatus(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                             New SqlParameter("@IdEstatusRecibo", SqlDbType.TinyInt)}

                Prms(0).Value = Me._IdRecibo
                Prms(1).Value = Me._IdEstatusRecibo

                Return _DataCOBAEV.RunProc("SP_UEstatusRecibo", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaImportesDeConceptos(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                             New SqlParameter("@IdConcepto", SqlDbType.SmallInt), _
                                            New SqlParameter("@TipoConcepto", SqlDbType.Char, 1)}

                Prms(0).Value = Me._IdRecibo
                Prms(1).Value = Me._IdConcepto
                Prms(2).Value = Me._TipoConcepto

                Return _DataCOBAEV.RunProc("SP_DConceptosEnRecibosImportes", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenImportesDeConceptos() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                             New SqlParameter("@IdConcepto", SqlDbType.SmallInt), _
                                            New SqlParameter("@TipoConcepto", SqlDbType.Char, 1)}

                Prms(0).Value = Me._IdRecibo
                Prms(1).Value = Me._IdConcepto
                Prms(2).Value = Me._TipoConcepto

                Return _DataCOBAEV.RunProc("SP_SConceptosEnRecibosImportes", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDatosParaIndemnizaciones(ByVal IdRecibo As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}

                Prms(0).Value = IdRecibo

                Return _DataCOBAEV.RunProc("SP_SRecibosDatosParaIndemnizaciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaDatosParaIndemnizaciones(ByVal IdRecibo As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}

                Prms(0).Value = IdRecibo

                Return _DataCOBAEV.RunProc("SP_DRecibosDatosParaIndemnizaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaDatosParaIndemnizaciones(ByVal IdRecibo As Short, ByVal AniosDeServicio As Decimal, ByVal IngresoExcento As Decimal, _
                                                        ByVal UltimoSueldo As Decimal, ByVal ISRUltimoSueldo As Decimal, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                             New SqlParameter("@AniosDeServicio", SqlDbType.Decimal), _
                                            New SqlParameter("@IngresoExcento", SqlDbType.Decimal), _
                                            New SqlParameter("@UltimoSueldo", SqlDbType.Decimal), _
                                            New SqlParameter("@ISRUltimoSueldo", SqlDbType.Decimal)}

                Prms(0).Value = IdRecibo
                Prms(1).Value = AniosDeServicio
                Prms(2).Value = IngresoExcento
                Prms(3).Value = UltimoSueldo
                Prms(4).Value = ISRUltimoSueldo

                Return _DataCOBAEV.RunProc("SP_URecibosDatosParaIndemnizaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        'Obten beneficiarios dado un empleado específico

        Public Function ObtenBeneficiarios(ByVal idRecibo As Integer, ByVal idEmp As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.Int),
                                              New SqlParameter("@IdEmp", SqlDbType.Int)
                                             }

                Prms(0).Value = idRecibo
                Prms(1).Value = idEmp

                Return _DataCOBAEV.RunProc("[SP_SBeneficiariosRecibos]", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function InsertaDatosParaIndemnizaciones(ByVal IdRecibo As Short, ByVal AniosDeServicio As Decimal, ByVal IngresoExcento As Decimal, _
                                                        ByVal UltimoSueldo As Decimal, ByVal ISRUltimoSueldo As Decimal, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                             New SqlParameter("@AniosDeServicio", SqlDbType.Decimal), _
                                            New SqlParameter("@IngresoExcento", SqlDbType.Decimal), _
                                            New SqlParameter("@UltimoSueldo", SqlDbType.Decimal), _
                                            New SqlParameter("@ISRUltimoSueldo", SqlDbType.Decimal)}

                Prms(0).Value = IdRecibo
                Prms(1).Value = AniosDeServicio
                Prms(2).Value = IngresoExcento
                Prms(3).Value = UltimoSueldo
                Prms(4).Value = ISRUltimoSueldo

                Return _DataCOBAEV.RunProc("SP_IRecibosDatosParaIndemnizaciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaConceptos(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                             New SqlParameter("@IdConcepto", SqlDbType.SmallInt), _
                                            New SqlParameter("@TipoConcepto", SqlDbType.Char, 1), _
                                            New SqlParameter("@Importe", SqlDbType.Decimal), _
                                            New SqlParameter("@ImporteParaRetroactivo", SqlDbType.Decimal), _
                                            New SqlParameter("@ImporteParaAguinaldo", SqlDbType.Decimal), _
                                            New SqlParameter("@MostrarEnRecibo", SqlDbType.Bit), _
                                            New SqlParameter("@ImporteGravado", SqlDbType.Decimal), _
                                            New SqlParameter("@DiasExentos", SqlDbType.Decimal)}

                Prms(0).Value = _IdRecibo
                Prms(1).Value = _IdConcepto
                Prms(2).Value = _TipoConcepto
                Prms(3).Value = _Importe
                Prms(4).Value = _ImporteParaRetroactivo
                Prms(5).Value = _ImporteParaAguinaldo
                Prms(6).Value = _MostrarEnRecibo
                Prms(7).Value = _ImporteGravado
                Prms(8).Value = _DiasExentos

                Return _DataCOBAEV.RunProc("SP_UConceptosEnRecibosImportes", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaConceptos(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                             New SqlParameter("@IdConcepto", SqlDbType.SmallInt), _
                                            New SqlParameter("@TipoConcepto", SqlDbType.Char, 1), _
                                            New SqlParameter("@Importe", SqlDbType.Decimal), _
                                            New SqlParameter("@ImporteParaRetroactivo", SqlDbType.Decimal), _
                                            New SqlParameter("@ImporteParaAguinaldo", SqlDbType.Decimal), _
                                            New SqlParameter("@MostrarEnRecibo", SqlDbType.Bit), _
                                            New SqlParameter("@ImporteGravado", SqlDbType.Decimal), _
                                            New SqlParameter("@DiasExentos", SqlDbType.Decimal)}

                Prms(0).Value = _IdRecibo
                Prms(1).Value = _IdConcepto
                Prms(2).Value = _TipoConcepto
                Prms(3).Value = _Importe
                Prms(4).Value = _ImporteParaRetroactivo
                Prms(5).Value = _ImporteParaAguinaldo
                Prms(6).Value = _MostrarEnRecibo
                Prms(7).Value = _ImporteGravado
                Prms(8).Value = _DiasExentos

                Return _DataCOBAEV.RunProc("SP_IConceptosEnRecibosImportes", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenConceptos(ByVal IdRecibo As Short, ByVal IdConcepto As Short, ByVal TipoConcepto As String, ByVal TipoOperacion As Byte, ByVal IdRol As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdConcepto", SqlDbType.SmallInt), _
                                                New SqlParameter("@TipoConcepto", SqlDbType.NVarChar, 1), _
                                                New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt)}
                Prms(0).Value = IdRecibo
                Prms(1).Value = IdConcepto
                Prms(2).Value = TipoConcepto
                Prms(3).Value = TipoOperacion
                Prms(4).Value = IdRol

                Return _DataCOBAEV.RunProc("SP_SConceptosParaRecibo", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenRecibosPorEmpleado(ByVal pRFCEmp As String, ByVal pLogin As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                Dim drPropiedadesDelRol As DataRow
                oUsr.Login = pLogin
                drUsr = oUsr.ObtenerPorLogin()
                drPropiedadesDelRol = oUsr.ObtenerPropiedadesDelRol().Rows(0)

                Prms(0).Value = pRFCEmp
                Prms(1).Value = CByte(drPropiedadesDelRol("IdRol"))
                Prms(2).Value = CBool(drPropiedadesDelRol("ConsultaZonasEspecificas"))
                Prms(3).Value = CBool(drPropiedadesDelRol("ConsultaPlantelesEspecificos"))
                Prms(4).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SRecibosEmpleado", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenRecibosPorAnio(ByVal Anio As Short, ByVal IdQuincena As Short, ByVal IdRol As Byte, ByVal ConsultaZonasEspecificas As Boolean, ByVal ConsultaPlantelesEspecificos As Boolean, ByVal Login As String, Optional ByVal VerTodos As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = Anio
                Prms(1).Value = IdRol
                Prms(2).Value = ConsultaZonasEspecificas
                Prms(3).Value = ConsultaPlantelesEspecificos
                Prms(4).Value = CShort(drUsr("IdUsuario"))
                Prms(5).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SRecibosPorAnioQna", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenRecibosPorAnioTipo(ByVal pAnio As Short, ByVal pIdTipoRecibo As Byte, _
                                                ByVal pIdRol As Byte, ByVal pConsultaZonasEspecificas As Boolean, _
                                                ByVal pConsultaPlantelesEspecificos As Boolean, _
                                                ByVal pLogin As String, Optional ByVal pVerTodos As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdTipoRecibo", SqlDbType.TinyInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = pLogin
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = pAnio
                Prms(1).Value = pIdRol
                Prms(2).Value = pConsultaZonasEspecificas
                Prms(3).Value = pConsultaPlantelesEspecificos
                Prms(4).Value = CShort(drUsr("IdUsuario"))
                Prms(5).Value = pIdTipoRecibo

                Return _DataCOBAEV.RunProc("SP_SRecibosPorAnioTipo", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDatosProbables() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SDatosParaNuevoRecibo", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaNuevo(ByVal ArregloAuditoria() As String) As String
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int), _
                                            New SqlParameter("@NumRecibo", SqlDbType.NVarChar, 4), _
                                            New SqlParameter("@Fecha", SqlDbType.DateTime), _
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdTipoRecibo", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdFondoPresup", SqlDbType.TinyInt), _
                                            New SqlParameter("@QnaIniAdeudo", SqlDbType.NVarChar, 6), _
                                            New SqlParameter("@QnaFinAdeudo", SqlDbType.NVarChar, 6), _
                                            New SqlParameter("@ObservacionesRecibo", SqlDbType.NVarChar, 400), _
                                            New SqlParameter("@IdQuincenaAplicacion", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                            New SqlParameter("@ClaveDeCobro", SqlDbType.NVarChar, 8),
                                            New SqlParameter("@IgnorarEmpParaPasivos", SqlDbType.Bit), _
                                            New SqlParameter("@IgnorarReciboParaDecAnual", SqlDbType.Bit), _
                                            New SqlParameter("@FechaRealDePago", SqlDbType.DateTime), _
                                            New SqlParameter("@ReciboDeSustitucion", SqlDbType.Bit),
                                            New SqlParameter("@ReciboTimbrado", SqlDbType.Bit),
                                            New SqlParameter("@AnioPasivos", SqlDbType.SmallInt),
                                            New SqlParameter("@PagaTercero", SqlDbType.SmallInt),
                                            New SqlParameter("@IdBeneficiario", SqlDbType.Int)}


                Prms(0).Value = _IdEmp
                Prms(1).Direction = ParameterDirection.Output
                Prms(2).Value = _Fecha
                Prms(3).Value = _IdUsuario
                Prms(4).Value = _IdTipoRecibo
                Prms(5).Value = _IdFondoPresup
                Prms(6).Value = _QnaIniAdeudo
                Prms(7).Value = _QnaFinAdeudo
                Prms(8).Value = _ObservacionesRecibo
                Prms(9).Value = _IdQuincenaAplicacion
                Prms(10).Value = _IdPlaza
                Prms(11).Value = _ClaveDeCobro
                Prms(12).Value = _IgnorarEmpParaPasivos
                Prms(13).Value = _IgnorarReciboParaDecAnual
                Prms(14).Value = _FechaRealDePago
                Prms(15).Value = _ReciboDeSustitucion
                Prms(16).Value = _Recibotimbrado
                Prms(17).Value = _AnioPasivos
                Prms(18).Value = _PagaTercero
                Prms(19).Value = _IdBeneficiario

                _DataCOBAEV.RunProc("SP_IRecibo", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Return Prms(1).Value
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(Optional ByVal pIdRecibo As Short = 0) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}

                Prms(0).Value = IIf(pIdRecibo = 0, _IdRecibo, pIdRecibo)

                Return _DataCOBAEV.RunProc("SP_SReciboPorId", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaPorId(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}

                Prms(0).Value = Me._IdRecibo

                Return _DataCOBAEV.RunProc("SP_DReciboPorId", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualiza(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt), _
                                            New SqlParameter("@Fecha", SqlDbType.DateTime), _
                                            New SqlParameter("@IdEstatusRecibo", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdTipoRecibo", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdFondoPresup", SqlDbType.TinyInt), _
                                            New SqlParameter("@QnaIniAdeudo", SqlDbType.NVarChar, 6), _
                                            New SqlParameter("@QnaFinAdeudo", SqlDbType.NVarChar, 6), _
                                            New SqlParameter("@ObservacionesRecibo", SqlDbType.NVarChar, 400), _
                                            New SqlParameter("@IdQuincenaAplicacion", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                            New SqlParameter("@ClaveDeCobro", SqlDbType.NVarChar, 8), _
                                            New SqlParameter("@IgnorarEmpParaPasivos", SqlDbType.Bit), _
                                            New SqlParameter("@IgnorarReciboParaDecAnual", SqlDbType.Bit), _
                                            New SqlParameter("@FechaRealDePago", SqlDbType.DateTime), _
                                            New SqlParameter("@ReciboDeSustitucion", SqlDbType.Bit), _
                                            New SqlParameter("@ReciboTimbrado", SqlDbType.Bit), _
                                            New SqlParameter("@AnioPasivos", SqlDbType.SmallInt),
                                            New SqlParameter("@PagaTercero", SqlDbType.SmallInt),
                                            New SqlParameter("@IdBeneficiario", SqlDbType.Int)}


                Prms(0).Value = _IdRecibo
                Prms(1).Value = _Fecha
                Prms(2).Value = _IdEstatusRecibo
                Prms(3).Value = _IdTipoRecibo
                Prms(4).Value = _IdFondoPresup
                Prms(5).Value = _QnaIniAdeudo
                Prms(6).Value = _QnaFinAdeudo
                Prms(7).Value = _ObservacionesRecibo
                Prms(8).Value = _IdQuincenaAplicacion
                Prms(9).Value = _IdPlaza
                Prms(10).Value = _ClaveDeCobro
                Prms(11).Value = _IgnorarEmpParaPasivos
                Prms(12).Value = _IgnorarReciboParaDecAnual
                Prms(13).Value = _FechaRealDePago
                Prms(14).Value = _ReciboDeSustitucion
                Prms(15).Value = _Recibotimbrado
                Prms(16).Value = _AnioPasivos
                Prms(17).Value = _PagaTercero
                Prms(18).Value = _IdBeneficiario

                Return _DataCOBAEV.RunProc("SP_URecibo", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesEstatus() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEstatusRecibos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesEstatus(ByVal pObtenerSoloEstatusENPROCESO As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ObtenerSoloENPROCESO", SqlDbType.Bit)}

                Prms(0).Value = pObtenerSoloEstatusENPROCESO

                Return _DataCOBAEV.RunProc("SP_SEstatusRecibos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTipos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_STiposDeRecibos", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaImportes(ByVal IdRecibo As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}

                Prms(0).Value = IdRecibo

                Return _DataCOBAEV.RunProc("SP_DRecibosImportes", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CalculaImportes(ByVal RFC As String, ByVal IdQuincena As Short, ByVal IdRecibo As Short, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}
                Prms(0).Value = RFC
                Prms(1).Value = IdQuincena
                Prms(2).Value = IdRecibo

                Return _DataCOBAEV.RunProc("SP_SCalcReciboImportes", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ConsultaImportes(ByVal IdRecibo As Short) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}

                Prms(0).Value = IdRecibo

                Return _DataCOBAEV.RunProc("SP_SConsultaReciboImportes", Prms, "PagoQnalEmpleado", DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSiExisteRecibo(ByVal RFCEmp As String, ByVal IdQnaPago As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13), _
                                                New SqlParameter("@IdQnaPago", SqlDbType.SmallInt)}

                Prms(0).Value = RFCEmp
                Prms(1).Value = IdQnaPago

                Return _DataCOBAEV.RunProc("SP_SExisteRecibo", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsIndemnizatorio(ByVal pIdRecibo As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRecibo", SqlDbType.SmallInt)}
                Dim vldrRecibo As DataRow

                Prms(0).Value = pIdRecibo

                vldrRecibo = _DataCOBAEV.RunProc("SP_SReciboEsIndemnizatorio", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CBool(vldrRecibo("ReciboEsIndemnizatorio"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEstatusActual(ByVal pIdEstatusRecibo As Byte) As String
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEstatusRecibo", SqlDbType.TinyInt)}
                Dim vldrRecibo As DataRow

                Prms(0).Value = pIdEstatusRecibo

                vldrRecibo = _DataCOBAEV.RunProc("SP_SReciboEstatus", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

                Return CStr(vldrRecibo("ReciboEstatus"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace


