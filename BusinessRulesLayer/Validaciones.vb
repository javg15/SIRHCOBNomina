Imports DataAccessLayer.COBAEV
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Validaciones
    Public Class Validaciones
#Region "Clase Validaciones: Variables privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _NombrePagina, _RFC, _Login, _CuentaBancaria, _CURPEmp As String
        Private _TipoOperacion, _Cantidad, _IdRol, _IdEmpFuncion, _IdBanco, _IdMotGralBaja As Byte
        Private _IdHora, _IdPlaza, _IdEmp As Integer
        Private _IdQuincena, _IdQuincenaNueva, _IdBeneficiario, _IdSemestre, _IdUsuario, _IdReporte As Short
        Private _IdQnaIni, _IdQnaFin As Short
        Private _Porcentaje, _ImportePercepcion, _ImporteDeduccion As Decimal
        Private _TipoOperacion2 As SByte
        Private _IdRecibo, _IdMateria, _IdDeduccion, _IdPercepcion, _IdPlantel, _IdPuesto As Short
        Private _CargaDePlantilla, _AsociarInterinas As Boolean
        Private _IdNivel As Byte
        Private _IdCarrera, _IdCategoria, _IdGrupo As Short
        Private _IdEstudio As Integer
        Private _IdTipoSemestre, _IdSindicato, _IdTipoEmp, _IdEstatusHora, _IdNombramiento, _IdTipoNomina As Byte
        Private _FechaPagoQna As Date
        Private _FechaAlta, _FechaBaja As Date
        Private _FechaInicial, _FechaFinal As Date
        Private _IdTipoIncidencia As Byte
        Private _FolioIncidencia As String
        Private _FolioISSSTE As String
        Private _IdTipoIncidenciaSubtipos As Byte

#End Region
#Region "Clase Validaciones: Propiedades públicas"
        Public Property FolioIncidencia As String
            Get
                Return _FolioIncidencia
            End Get
            Set(ByVal value As String)
                _FolioIncidencia = value
            End Set
        End Property
        Public Property FolioISSSTE As String
            Get
                Return _FolioISSSTE
            End Get
            Set(ByVal value As String)
                _FolioISSSTE = value
            End Set
        End Property

        Public Property IdTipoIncidencia() As Byte
            Get
                Return _IdTipoIncidencia
            End Get
            Set(ByVal value As Byte)
                _IdTipoIncidencia = value
            End Set
        End Property
        Public Property FechaInicial As Date
            Get
                Return _FechaInicial
            End Get
            Set(ByVal value As Date)
                _FechaInicial = value
            End Set
        End Property
        Public Property FechaFinal() As Date
            Get
                Return _FechaFinal
            End Get
            Set(ByVal value As Date)
                _FechaFinal = value
            End Set
        End Property
        Public Property FechaBaja() As Date
            Get
                Return _FechaBaja
            End Get
            Set(ByVal value As Date)
                _FechaBaja = value
            End Set
        End Property
        Public Property FechaAlta() As Date
            Get
                Return _FechaAlta
            End Get
            Set(ByVal value As Date)
                _FechaAlta = value
            End Set
        End Property
        Public Property FechaPagoQna() As Date
            Get
                Return Me._FechaPagoQna
            End Get
            Set(ByVal value As Date)
                Me._FechaPagoQna = value
            End Set
        End Property
        Public Property IdTipoNomina() As Byte
            Get
                Return Me._IdTipoNomina
            End Get
            Set(ByVal value As Byte)
                Me._IdTipoNomina = value
            End Set
        End Property
        Public Property IdNombramiento() As Byte
            Get
                Return Me._IdNombramiento
            End Get
            Set(ByVal value As Byte)
                Me._IdNombramiento = value
            End Set
        End Property
        Public Property IdEstatusHora() As Byte
            Get
                Return Me._IdEstatusHora
            End Get
            Set(ByVal value As Byte)
                Me._IdEstatusHora = value
            End Set
        End Property
        Public Property IdGrupo() As Short
            Get
                Return Me._IdGrupo
            End Get
            Set(ByVal value As Short)
                Me._IdGrupo = value
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
        Public Property ImporteDeduccion() As Decimal
            Get
                Return _ImporteDeduccion
            End Get
            Set(ByVal Value As Decimal)
                _ImporteDeduccion = Value
            End Set
        End Property
        Public Property IdPlantel() As Short
            Get
                Return Me._IdPlantel
            End Get
            Set(ByVal value As Short)
                Me._IdPlantel = value
            End Set
        End Property
        Public Property IdPuesto() As Short
            Get
                Return Me._IdPuesto
            End Get
            Set(ByVal value As Short)
                Me._IdPuesto = value
            End Set
        End Property
        Public Property IdTipoEmp() As Byte
            Get
                Return Me._IdTipoEmp
            End Get
            Set(ByVal value As Byte)
                Me._IdTipoEmp = value
            End Set
        End Property
        Public Property IdCategoria() As Short
            Get
                Return Me._IdCategoria
            End Get
            Set(ByVal value As Short)
                Me._IdCategoria = value
            End Set
        End Property
        Public Property IdSindicato() As Byte
            Get
                Return Me._IdSindicato
            End Get
            Set(ByVal value As Byte)
                Me._IdSindicato = value
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
        Public Property IdNivel() As Byte
            Get
                Return Me._IdNivel
            End Get
            Set(ByVal value As Byte)
                Me._IdNivel = value
            End Set
        End Property
        Public Property IdCarrera() As Short
            Get
                Return Me._IdCarrera
            End Get
            Set(ByVal value As Short)
                Me._IdCarrera = value
            End Set
        End Property
        Public Property IdEstudio As Integer
            Get
                Return Me._IdEstudio
            End Get
            Set(ByVal value As Integer)
                Me._IdEstudio = value
            End Set
        End Property
        Public Property AsociarInterinas() As Boolean
            Get
                Return Me._AsociarInterinas
            End Get
            Set(ByVal value As Boolean)
                Me._AsociarInterinas = value
            End Set
        End Property
        Public Property CargaDePlantilla() As Boolean
            Get
                Return Me._CargaDePlantilla
            End Get
            Set(ByVal value As Boolean)
                Me._CargaDePlantilla = value
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
        Public Property IdEmp() As Integer
            Get
                Return Me._IdEmp
            End Get
            Set(ByVal value As Integer)
                Me._IdEmp = value
            End Set
        End Property
        Public Property CuentaBancaria() As String
            Get
                Return Me._CuentaBancaria
            End Get
            Set(ByVal value As String)
                Me._CuentaBancaria = value
            End Set
        End Property
        Public Property IdBanco() As Byte
            Get
                Return Me._IdBanco
            End Get
            Set(ByVal value As Byte)
                Me._IdBanco = value
            End Set
        End Property
        Public Property IdQnaIni() As Short
            Get
                Return Me._IdQnaIni
            End Get
            Set(ByVal value As Short)
                Me._IdQnaIni = value
            End Set
        End Property
        Public Property IdQnaFin() As Short
            Get
                Return Me._IdQnaFin
            End Get
            Set(ByVal value As Short)
                Me._IdQnaFin = value
            End Set
        End Property
        Public Property IdEmpFuncion() As Byte
            Get
                Return Me._IdEmpFuncion
            End Get
            Set(ByVal value As Byte)
                Me._IdEmpFuncion = value
            End Set
        End Property
        Public Property IdRol() As Byte
            Get
                Return Me._IdRol
            End Get
            Set(ByVal value As Byte)
                Me._IdRol = value
            End Set
        End Property
        Public Property IdReporte() As Short
            Get
                Return Me._IdReporte
            End Get
            Set(ByVal value As Short)
                Me._IdReporte = value
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
        Public Property IdUsuario() As Short
            Get
                Return Me._IdUsuario
            End Get
            Set(ByVal value As Short)
                Me._IdUsuario = value
            End Set
        End Property
        Public Property Login() As String
            Get
                Return Me._Login
            End Get
            Set(ByVal value As String)
                Me._Login = value
            End Set
        End Property
        Public Property NombrePagina() As String
            Get
                Return Me._NombrePagina
            End Get
            Set(ByVal value As String)
                Me._NombrePagina = value
            End Set
        End Property
        Public Property RFC() As String
            Get
                Return Me._RFC
            End Get
            Set(ByVal value As String)
                Me._RFC = value
            End Set
        End Property
        Public Property TipoOperacion() As Byte
            Get
                Return Me._TipoOperacion
            End Get
            Set(ByVal value As Byte)
                Me._TipoOperacion = value
            End Set
        End Property
        Public Property TipoOperacion2() As SByte
            Get
                Return Me._TipoOperacion2
            End Get
            Set(ByVal value As SByte)
                Me._TipoOperacion2 = value
            End Set
        End Property
        Public Property Cantidad() As Byte
            Get
                Return Me._Cantidad
            End Get
            Set(ByVal value As Byte)
                Me._Cantidad = value
            End Set
        End Property
        Public Property IdHora() As Integer
            Get
                Return Me._IdHora
            End Get
            Set(ByVal value As Integer)
                Me._IdHora = value
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
        Public Property IdQuincena() As Short
            Get
                Return Me._IdQuincena
            End Get
            Set(ByVal value As Short)
                Me._IdQuincena = value
            End Set
        End Property
        Public Property IdQuincenaNueva() As Short
            Get
                Return Me._IdQuincenaNueva
            End Get
            Set(ByVal value As Short)
                Me._IdQuincenaNueva = value
            End Set
        End Property
        Public Property IdBeneficiario() As Short
            Get
                Return Me._IdBeneficiario
            End Get
            Set(ByVal value As Short)
                Me._IdBeneficiario = value
            End Set
        End Property
        Public Property Porcentaje() As Decimal
            Get
                Return Me._Porcentaje
            End Get
            Set(ByVal value As Decimal)
                Me._Porcentaje = value
            End Set
        End Property
        Public Property IdSemestre() As Short
            Get
                Return Me._IdSemestre
            End Get
            Set(ByVal value As Short)
                Me._IdSemestre = value
            End Set
        End Property
        Public Property IdMateria() As Short
            Get
                Return Me._IdMateria
            End Get
            Set(ByVal value As Short)
                Me._IdMateria = value
            End Set
        End Property
        Public Property IdDeduccion() As Short
            Get
                Return Me._IdDeduccion
            End Get
            Set(ByVal value As Short)
                Me._IdDeduccion = value
            End Set
        End Property
        Public Property IdPercepcion() As Short
            Get
                Return Me._IdPercepcion
            End Get
            Set(ByVal value As Short)
                Me._IdPercepcion = value
            End Set
        End Property
        Public Property CURPEmp() As String
            Get
                Return Me._CURPEmp
            End Get
            Set(ByVal value As String)
                Me._CURPEmp = value
            End Set
        End Property
        Public Property IdTipoIncidenciaSubtipos() As String
            Get
                Return Me._IdTipoIncidenciaSubtipos
            End Get
            Set(ByVal value As String)
                Me._IdTipoIncidenciaSubtipos = value
            End Set
        End Property
#End Region
#Region "Clase Validaciones: Métodos públicos"
        Public Function ValidaPaginas(ByRef dsValida As DataSet, ByVal ValidacionAlCargarPagina As Boolean) As Boolean
            Try
                Dim RetVal As Boolean = False
                Dim dsProc As DataSet

                RetVal = True

                Dim vlParamProc As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50), _
                        New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                        New SqlParameter("@ValidacionAlCargarPagina", SqlDbType.Bit)}

                vlParamProc(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                vlParamProc(1).Value = Me._NombrePagina
                If Me._TipoOperacion2 = -1 Then
                    vlParamProc(2).Value = DBNull.Value
                Else
                    vlParamProc(2).Value = Me._TipoOperacion2
                End If
                vlParamProc(3).Value = ValidacionAlCargarPagina

                dsProc = _DataCOBAEV.RunProc("Sp_ValidacionesPaginas", vlParamProc, "ValidacionesPaginas", DataCOBAEV.BD.Administracion)
                Dim I As Int16

                For I = 0 To dsProc.Tables(0).Rows.Count - 1
                    ValidaProcedimientos(CInt(dsProc.Tables(0).Rows(I).Item(0)), dsProc.Tables(0).Rows(I).Item(1).ToString, dsValida, RetVal)
                Next I

                RetVal = Not (dsValida.Tables(0).Rows.Count > 0)

                Return RetVal
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
        End Function
        Public Function ValidaPaginas(ByRef dsValida As DataSet) As Boolean
            Try
                Dim RetVal As Boolean = False
                Dim dsProc As DataSet

                RetVal = True

                Dim vlParamProc As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50), _
                        New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}

                vlParamProc(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                vlParamProc(1).Value = Me._NombrePagina
                If Me._TipoOperacion2 = -1 Then
                    vlParamProc(2).Value = DBNull.Value
                Else
                    vlParamProc(2).Value = Me._TipoOperacion2
                End If
                dsProc = _DataCOBAEV.RunProc("Sp_ValidacionesPaginas", vlParamProc, "ValidacionesPaginas", DataCOBAEV.BD.Administracion)
                Dim I As Int16

                For I = 0 To dsProc.Tables(0).Rows.Count - 1
                    ValidaProcedimientos(CInt(dsProc.Tables(0).Rows(I).Item(0)), dsProc.Tables(0).Rows(I).Item(1).ToString, dsValida, RetVal)
                Next I

                RetVal = Not (dsValida.Tables(0).Rows.Count > 0)

                Return RetVal
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
        End Function
        Public Function ValidaPagsPercDeduc(ByRef dsValida As DataSet, ByVal ValidacionAlCargarPagina As Boolean, ByVal IdPercDeduc As Short, ByVal TipoPercDeduc As String) As Boolean
            Try
                Dim RetVal As Boolean = False
                Dim dsProc As DataSet

                RetVal = True

                Dim vlParamProc As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                            New SqlParameter("@ValidacionAlCargarPagina", SqlDbType.Bit), _
                                            New SqlParameter("@IdPercDeduc", SqlDbType.SmallInt), _
                                            New SqlParameter("@TipoPercDeduc", SqlDbType.NVarChar, 1)}

                vlParamProc(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                vlParamProc(1).Value = Me._NombrePagina
                vlParamProc(2).Value = Me._TipoOperacion
                vlParamProc(3).Value = ValidacionAlCargarPagina
                vlParamProc(4).Value = IdPercDeduc
                vlParamProc(5).Value = TipoPercDeduc

                dsProc = _DataCOBAEV.RunProc("Sp_ValidacionesPagsPercDeduc", vlParamProc, "ValidacionesPagsPercDeduc", DataCOBAEV.BD.Administracion)
                Dim I As Int16

                For I = 0 To dsProc.Tables(0).Rows.Count - 1
                    ValidaProcedimientos(CInt(dsProc.Tables(0).Rows(I).Item(0)), dsProc.Tables(0).Rows(I).Item(1).ToString, dsValida, RetVal)
                Next I

                RetVal = Not (dsValida.Tables(0).Rows.Count > 0)

                Return RetVal
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
        End Function
        Public Function ValidaPagsPercDeduc(ByRef dsValida As DataSet, ByVal IdPercDeduc As Short, ByVal TipoPercDeduc As String) As Boolean
            Try
                Dim RetVal As Boolean = False
                Dim dsProc As DataSet

                RetVal = True
                Dim vlParamProc As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdPercDeduc", SqlDbType.SmallInt), _
                                            New SqlParameter("@TipoPercDeduc", SqlDbType.NVarChar, 1)}

                vlParamProc(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                vlParamProc(1).Value = Me._NombrePagina
                vlParamProc(2).Value = Me._TipoOperacion
                vlParamProc(3).Value = IdPercDeduc
                vlParamProc(4).Value = TipoPercDeduc

                dsProc = _DataCOBAEV.RunProc("Sp_ValidacionesPagsPercDeduc", vlParamProc, "ValidacionesPagsPercDeduc", DataCOBAEV.BD.Administracion)
                Dim I As Int16

                For I = 0 To dsProc.Tables(0).Rows.Count - 1
                    ValidaProcedimientos(CInt(dsProc.Tables(0).Rows(I).Item(0)), dsProc.Tables(0).Rows(I).Item(1).ToString, dsValida, RetVal)
                Next I

                RetVal = Not (dsValida.Tables(0).Rows.Count > 0)

                Return RetVal
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
        End Function
        Public Function ValidaPagsIncidencias(ByRef dsValida As DataSet, ByVal pNombrePagina As String,
                                              ByVal pIdTipoIncidencia As Byte, ByVal pTipoOperacion As Byte,
                                              ByVal pIdTipoIncidenciaSubtipos As Byte) As Boolean
            Try
                Dim RetVal As Boolean = False
                Dim dsProc As DataSet

                RetVal = True
                Dim vlParamProc As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20),
                                            New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50),
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt),
                                            New SqlParameter("@IdTipoIncidencia", SqlDbType.TinyInt),
                                            New SqlParameter("@IdTipoIncidenciaSubtipos", SqlDbType.TinyInt)}

                vlParamProc(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                vlParamProc(1).Value = pNombrePagina
                vlParamProc(2).Value = pTipoOperacion
                vlParamProc(3).Value = pIdTipoIncidencia
                vlParamProc(4).Value = pIdTipoIncidenciaSubtipos

                dsProc = _DataCOBAEV.RunProc("SP_ValidacionesSobreIncidencias", vlParamProc, "ValidacionesSobreIncidencias", DataCOBAEV.BD.Administracion)
                Dim I As Int16

                For I = 0 To dsProc.Tables(0).Rows.Count - 1
                    ValidaProcedimientos(CInt(dsProc.Tables(0).Rows(I).Item(0)), dsProc.Tables(0).Rows(I).Item(1).ToString, dsValida, RetVal)
                Next I

                RetVal = Not (dsValida.Tables(0).Rows.Count > 0)

                Return RetVal
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
        End Function
        Public Function ValidaPaginasOperacion(ByRef dsValida As DataSet, ByVal ValidacionAlCargarPagina As Boolean) As Boolean
            Try
                Dim RetVal As Boolean = False
                Dim dsProc As DataSet

                RetVal = True
                Dim vlParamProc As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                            New SqlParameter("@ValidacionAlCargarPagina", SqlDbType.Bit)}

                vlParamProc(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                vlParamProc(1).Value = Me._NombrePagina
                vlParamProc(2).Value = Me._TipoOperacion
                vlParamProc(3).Value = ValidacionAlCargarPagina
                dsProc = _DataCOBAEV.RunProc("SP_ValidacionesPaginas", vlParamProc, "ValidacionesPaginasOperacion", DataCOBAEV.BD.Administracion)
                Dim I As Int16

                For I = 0 To dsProc.Tables(0).Rows.Count - 1
                    ValidaProcedimientos(CInt(dsProc.Tables(0).Rows(I).Item(0)), dsProc.Tables(0).Rows(I).Item(1).ToString, dsValida, RetVal)
                Next I

                RetVal = Not (dsValida.Tables(0).Rows.Count > 0)

                Return RetVal
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
        End Function
        Public Function ValidaPaginasOperacion(ByRef dsValida As DataSet) As Boolean
            Try
                Dim RetVal As Boolean = False
                Dim dsProc As DataSet

                RetVal = True
                Dim vlParamProc As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt)}

                vlParamProc(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                vlParamProc(1).Value = _NombrePagina
                vlParamProc(2).Value = _TipoOperacion
                dsProc = _DataCOBAEV.RunProc("SP_ValidacionesPaginas", vlParamProc, "ValidacionesPaginasOperacion", DataCOBAEV.BD.Administracion)
                Dim I As Int16

                For I = 0 To dsProc.Tables(0).Rows.Count - 1
                    ValidaProcedimientos(CInt(dsProc.Tables(0).Rows(I).Item(0)), dsProc.Tables(0).Rows(I).Item(1).ToString, dsValida, RetVal)
                Next I

                RetVal = Not (dsValida.Tables(0).Rows.Count > 0)

                Return RetVal
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
        End Function
#End Region
#Region "Clase Validaciones: Métodos privados"

        Private Sub ValidaProcedimientos(ByVal IdProc As Int32, ByVal ProcName As String, ByRef dsValida As DataSet, ByRef RetVal As Boolean)
            Dim dsParam As New DataSet, J As Int16
            dsParam = getParameters(IdProc)
            Dim vlParam(dsParam.Tables(0).Rows.Count - 1) As IDataParameter
            For J = 0 To dsParam.Tables(0).Rows.Count - 1
                If IsDBNull(dsParam.Tables(0).Rows(J).Item(2)) Then
                    Dim Param As New SqlParameter(dsParam.Tables(0).Rows(J).Item(0).ToString(), CInt(dsParam.Tables(0).Rows(J).Item(1)))
                    vlParam.SetValue(Param, J)
                Else
                    Dim Param As New SqlParameter(dsParam.Tables(0).Rows(J).Item(0).ToString(), CInt(dsParam.Tables(0).Rows(J).Item(1)), CInt(dsParam.Tables(0).Rows(J).Item(2)))
                    vlParam.SetValue(Param, J)
                End If
                Select Case dsParam.Tables(0).Rows(J).Item(3).ToString().ToUpper
                    Case "RFC" : vlParam(J).Value = Me._RFC
                    Case "RFCEMP" : vlParam(J).Value = Me._RFC
                    Case "CANTIDAD" : vlParam(J).Value = Me._Cantidad
                    Case "IDHORA" : vlParam(J).Value = IIf(Me._IdHora = 0, DBNull.Value, Me._IdHora)
                    Case "TIPOOPERACION" : vlParam(J).Value = IIf(Me._TipoOperacion = 5, DBNull.Value, Me._TipoOperacion)
                    Case "IDPLAZA" : vlParam(J).Value = Me._IdPlaza
                    Case "IDQUINCENA" : vlParam(J).Value = IIf(Me._IdQuincena = 0, DBNull.Value, Me._IdQuincena)
                    Case "IDBENEFICIARIO" : vlParam(J).Value = Me._IdBeneficiario
                    Case "PORCENTAJE" : vlParam(J).Value = Me._Porcentaje
                    Case "IDQUINCENANUEVA" : vlParam(J).Value = Me._IdQuincenaNueva
                    Case "IDSEMESTRE" : vlParam(J).Value = IIf(Me._IdSemestre = 0 Or IsNothing(Me._IdSemestre), DBNull.Value, Me._IdSemestre)
                    Case "IDRECIBO" : vlParam(J).Value = Me._IdRecibo
                    Case "LOGIN" : vlParam(J).Value = Me._Login
                    Case "IDUSUARIO" : vlParam(J).Value = Me._IdUsuario
                    Case "IDROL" : vlParam(J).Value = Me._IdRol
                    Case "IDREPORTE" : vlParam(J).Value = Me._IdReporte
                    Case "IDMATERIA" : vlParam(J).Value = Me._IdMateria
                    Case "IDDEDUCCION" : vlParam(J).Value = Me._IdDeduccion
                    Case "IDPERCEPCION" : vlParam(J).Value = Me._IdPercepcion
                    Case "IDQNAINI" : vlParam(J).Value = Me._IdQnaIni
                    Case "IDQNAFIN" : vlParam(J).Value = Me._IdQnaFin
                    Case "IDEMPFUNCION" : vlParam(J).Value = Me._IdEmpFuncion
                    Case "IDEMP" : vlParam(J).Value = Me._IdEmp
                    Case "IDBANCO" : vlParam(J).Value = Me._IdBanco
                    Case "CUENTABANCARIA" : vlParam(J).Value = Me._CuentaBancaria
                    Case "CURPEMP" : vlParam(J).Value = IIf(Me._CURPEmp Is Nothing, String.Empty, Me._CURPEmp)
                    Case "IDMOTGRALBAJA" : vlParam(J).Value = Me._IdMotGralBaja
                    Case "CARGADEPLANTILLA" : vlParam(J).Value = Me._CargaDePlantilla
                    Case "ASOCIARINTERINAS" : vlParam(J).Value = Me._AsociarInterinas
                    Case "IDNIVEL" : vlParam(J).Value = Me._IdNivel
                    Case "IDCARRERA" : vlParam(J).Value = Me._IdCarrera
                    Case "IDESTUDIO" : vlParam(J).Value = Me._IdEstudio
                    Case "IDTIPOSEMESTRE" : vlParam(J).Value = Me._IdTipoSemestre
                    Case "IDCATEGORIA" : vlParam(J).Value = Me._IdCategoria
                    Case "IDSINDICATO" : vlParam(J).Value = Me._IdSindicato
                    Case "IDTIPOEMP" : vlParam(J).Value = Me._IdTipoEmp
                    Case "IDPLANTEL" : vlParam(J).Value = Me._IdPlantel
                    Case "IMPORTEPERCEPCION" : vlParam(J).Value = Me._ImportePercepcion
                    Case "IDGRUPO" : vlParam(J).Value = Me._IdGrupo
                    Case "IDESTATUSHORA" : vlParam(J).Value = Me._IdEstatusHora
                    Case "IDNOMBRAMIENTO" : vlParam(J).Value = Me._IdNombramiento
                    Case "IDTIPONOMINA" : vlParam(J).Value = Me._IdTipoNomina
                    Case "IMPORTEDEDUCCION" : vlParam(J).Value = Me._ImporteDeduccion
                    Case "FECHAPAGOQNA" : vlParam(J).Value = Me._FechaPagoQna
                    Case "FECHAALTA" : vlParam(J).Value = Me._FechaAlta
                    Case "FECHABAJA" : vlParam(J).Value = Me._FechaBaja
                    Case "FECHAINICIAL" : vlParam(J).Value = Me._FechaInicial
                    Case "FECHAFINAL" : vlParam(J).Value = Me._FechaFinal
                    Case "IDTIPOINCIDENCIA" : vlParam(J).Value = Me._IdTipoIncidencia
                    Case "FOLIOINCIDENCIA" : vlParam(J).Value = Me._FolioIncidencia
                    Case "FOLIOISSSTE" : vlParam(J).Value = Me._FolioISSSTE
                    Case "IDPUESTO" : vlParam(J).Value = Me._IdPuesto
                    Case "IDTIPOINCIDENCIASUBTIPOS" : vlParam(J).Value = Me._IdTipoIncidenciaSubtipos
                End Select
            Next J
            dsParam.Dispose()
            Dim dsErrores As DataSet
            dsErrores = getValida(IdProc, ProcName, vlParam, dsValida, RetVal)
            If Not dsErrores Is Nothing Then
                Dim drValida As DataRow
                If dsErrores.Tables(0).Rows.Count > 0 Then
                    drValida = dsValida.Tables(0).NewRow
                    drValida(0) = dsErrores.Tables(0).Rows(0).Item(0)
                    drValida(1) = dsErrores.Tables(0).Rows(0).Item(1)
                    Try
                        dsValida.Tables(0).Rows.Add(drValida)
                    Catch ex As Exception
                        Throw New System.Exception(ex.Message.ToString)
                    End Try
                End If
                RetVal = False
            End If
        End Sub
        Private Function getParameters(ByVal IdProc As Int16) As DataSet
            Try
                Dim dsParametros As DataSet
                Dim vlParamParam As SqlParameter() = {New SqlParameter("@IdProc", SqlDbType.Int)}
                vlParamParam(0).Value = IdProc
                dsParametros = Me._DataCOBAEV.RunProc("Sp_SParametrosProc", vlParamParam, "ParametrosProc", DataCOBAEV.BD.Administracion)
                Return dsParametros
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
        End Function
        Private Overloads Function getValida(ByVal IdProc As Int32, ByVal ProcName As String, ByVal parameters As IDataParameter(), ByRef dsValida As DataSet, ByRef RetVal As Boolean) As DataSet
            Try
                Dim dsRes As DataSet
                dsRes = Me._DataCOBAEV.RunProc(ProcName, parameters, "Validacion", DataCOBAEV.BD.Nomina)
                Dim ds As DataSet
                Select Case CInt(dsRes.Tables(0).Rows(0).Item(0))
                    Case 0
                        ds = Nothing
                    Case Else
                        Dim vlParameters As SqlParameter() = {New SqlParameter("@IdProc", SqlDbType.Int)}
                        vlParameters(0).Value = IdProc
                        ds = Me._DataCOBAEV.RunProc("Sp_SIdError", vlParameters, "Errores", DataCOBAEV.BD.Administracion)
                End Select
                Return ds
            Catch ex As Exception
                Throw New System.Exception(ex.Message.ToString)
            End Try
        End Function

#End Region
    End Class
End Namespace