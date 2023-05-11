Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV.Empleados
#Region "Clase Categoria"
    Public Class Categoria
#Region "Clase Categoria: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdCategoria, _IdPercepcion, _IdQnaVigIniPerc, _IdFuncionPri, _IdCategoriaRP, _IdPercepcionHoras As Short
        Private _IdZonaEco, _Horas, _IdEmpFuncion As Byte
        Private _ImpMenPerc As Decimal
        Private _EsCategoHomologada, _TieneCategoAsocRP, _CategoriaTecnicaDocente, _Activa As Boolean
        Private _RecursosPropios As Boolean
        Private _IdPercMatDid As Short
        Private _DescCategoria, _ClaveCategoria, _Puesto As String
#End Region
#Region "Clase Categoria: Propiedades públicas"
        Public Property EsCategoHomologada() As Boolean
            Get
                Return Me._EsCategoHomologada
            End Get
            Set(ByVal value As Boolean)
                Me._EsCategoHomologada = value
            End Set
        End Property
        Public Property IdFuncionPri() As Short
            Get
                Return Me._IdFuncionPri
            End Get
            Set(ByVal value As Short)
                Me._IdFuncionPri = value
            End Set
        End Property
        Public Property IdCategoriaRP() As Short
            Get
                Return Me._IdCategoriaRP
            End Get
            Set(ByVal value As Short)
                Me._IdCategoriaRP = value
            End Set
        End Property
        Public Property TieneCategoAsocRP() As Boolean
            Get
                Return Me._TieneCategoAsocRP
            End Get
            Set(ByVal value As Boolean)
                Me._TieneCategoAsocRP = value
            End Set
        End Property
        Public Property CategoriaTecnicaDocente() As Boolean
            Get
                Return Me._CategoriaTecnicaDocente
            End Get
            Set(ByVal value As Boolean)
                Me._CategoriaTecnicaDocente = value
            End Set
        End Property
        Public Property Activa() As Boolean
            Get
                Return Me._Activa
            End Get
            Set(ByVal value As Boolean)
                Me._Activa = value
            End Set
        End Property
        Public Property RecursosPropios() As Boolean
            Get
                Return Me._RecursosPropios
            End Get
            Set(ByVal value As Boolean)
                Me._RecursosPropios = value
            End Set
        End Property
        Public Property Horas() As Byte
            Get
                Return Me._Horas
            End Get
            Set(ByVal value As Byte)
                Me._Horas = value
            End Set
        End Property
        Public Property IdPercepcionHoras() As Short
            Get
                Return Me._IdPercepcionHoras
            End Get
            Set(ByVal value As Short)
                Me._IdPercepcionHoras = value
            End Set
        End Property
        Public Property IdPercMatDid() As Short
            Get
                Return Me._IdPercMatDid
            End Get
            Set(ByVal value As Short)
                Me._IdPercMatDid = value
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
        Public Property Puesto() As String
            Get
                Return Me._Puesto
            End Get
            Set(ByVal value As String)
                Me._Puesto = value
            End Set
        End Property
        Public Property DescCategoria() As String
            Get
                Return Me._DescCategoria
            End Get
            Set(ByVal value As String)
                Me._DescCategoria = value
            End Set
        End Property
        Public Property ClaveCategoria() As String
            Get
                Return Me._ClaveCategoria
            End Get
            Set(ByVal value As String)
                Me._ClaveCategoria = value
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
        Public Property IdPercepcion() As Short
            Get
                Return Me._IdPercepcion
            End Get
            Set(ByVal value As Short)
                Me._IdPercepcion = value
            End Set
        End Property
        Public Property IdZonaEco() As Byte
            Get
                Return Me._IdZonaEco
            End Get
            Set(ByVal value As Byte)
                Me._IdZonaEco = value
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
        Public Property ImpMenPerc() As Decimal
            Get
                Return Me._ImpMenPerc
            End Get
            Set(ByVal value As Decimal)
                Me._ImpMenPerc = value
            End Set
        End Property
#End Region
#Region "Clase Categoria: Métodos públicos"
        Public Function ObtenSoloRP(ByVal pSoloActivas As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@SoloActivas", SqlDbType.Bit)}

                Prms(0).Value = pSoloActivas

                Return _DataCOBAEV.RunProc("SP_SCategosRP", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTipificadores() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_STipificadoresCategoria", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaUpdate(ByVal pIdCategoria As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt), _
                                              New SqlParameter("@ParaUpdate", SqlDbType.Bit)}

                Prms(0).Value = pIdCategoria
                Prms(1).Value = True

                Return _DataCOBAEV.RunProc("SP_SCategoriaPorId", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNuevaClave() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SNuevaClaveCategoria", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaInf(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCategoria", SqlDbType.NVarChar, 3), _
                                                    New SqlParameter("@DescCategoria", SqlDbType.NVarChar, 50), _
                                                    New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdZonaEco", SqlDbType.TinyInt), _
                                                    New SqlParameter("@Horas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdPercMatDid", SqlDbType.SmallInt), _
                                                    New SqlParameter("@RecursosPropios", SqlDbType.Bit), _
                                                    New SqlParameter("@Activo", SqlDbType.Bit), _
                                                    New SqlParameter("@Puesto", SqlDbType.NVarChar, 15), _
                                                    New SqlParameter("@IdRama", SqlDbType.SmallInt), _
                                                    New SqlParameter("@Codigo", SqlDbType.NVarChar, 10), _
                                                    New SqlParameter("@NivelSalarial", SqlDbType.NVarChar, 5), _
                                                    New SqlParameter("@CategoriaTecnicaDocente", SqlDbType.Bit), _
                                                    New SqlParameter("@TieneCategoAsocRP", SqlDbType.Bit), _
                                                    New SqlParameter("@IdCategoriaRP", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPercepcionHoras", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdFuncionPri", SqlDbType.SmallInt), _
                                                    New SqlParameter("@EsCategoHomologada", SqlDbType.Bit), _
                                                    New SqlParameter("@IdCategoria", SqlDbType.SmallInt)
                                              }

                Prms(0).Value = Me._ClaveCategoria
                Prms(1).Value = Me._DescCategoria
                Prms(2).Value = Me._IdEmpFuncion
                Prms(3).Value = Me._IdZonaEco
                Prms(4).Value = Me._Horas
                Prms(5).Value = Me._IdPercMatDid
                Prms(6).Value = Me._RecursosPropios
                Prms(7).Value = Me._Activa
                Prms(8).Value = Me._Puesto
                Prms(9).Value = DBNull.Value
                Prms(10).Value = DBNull.Value
                Prms(11).Value = DBNull.Value
                Prms(12).Value = Me._CategoriaTecnicaDocente
                Prms(13).Value = Me._TieneCategoAsocRP
                Prms(14).Value = Me._IdCategoriaRP
                Prms(15).Value = Me._IdPercepcionHoras
                Prms(16).Value = Me._IdFuncionPri
                Prms(17).Value = Me._EsCategoHomologada
                Prms(18).Value = Me._IdCategoria

                Return _DataCOBAEV.RunProc("SP_UCategoria", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CrearNueva(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCategoria", SqlDbType.NVarChar, 3), _
                                                    New SqlParameter("@DescCategoria", SqlDbType.NVarChar, 50), _
                                                    New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdZonaEco", SqlDbType.TinyInt), _
                                                    New SqlParameter("@Horas", SqlDbType.TinyInt), _
                                                    New SqlParameter("@IdPercMatDid", SqlDbType.SmallInt), _
                                                    New SqlParameter("@RecursosPropios", SqlDbType.Bit), _
                                                    New SqlParameter("@Activo", SqlDbType.Bit), _
                                                    New SqlParameter("@Puesto", SqlDbType.NVarChar, 15), _
                                                    New SqlParameter("@IdRama", SqlDbType.SmallInt), _
                                                    New SqlParameter("@Codigo", SqlDbType.NVarChar, 10), _
                                                    New SqlParameter("@NivelSalarial", SqlDbType.NVarChar, 5), _
                                                    New SqlParameter("@CategoriaTecnicaDocente", SqlDbType.Bit), _
                                                    New SqlParameter("@TieneCategoAsocRP", SqlDbType.Bit), _
                                                    New SqlParameter("@IdCategoriaRP", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdPercepcionHoras", SqlDbType.SmallInt), _
                                                    New SqlParameter("@IdFuncionPri", SqlDbType.SmallInt), _
                                                    New SqlParameter("@EsCategoHomologada", SqlDbType.Bit)
                                              }

                Prms(0).Value = Me._ClaveCategoria
                Prms(1).Value = Me._DescCategoria
                Prms(2).Value = Me._IdEmpFuncion
                Prms(3).Value = Me._IdZonaEco
                Prms(4).Value = Me._Horas
                Prms(5).Value = Me._IdPercMatDid
                Prms(6).Value = Me._RecursosPropios
                Prms(7).Value = Me._Activa
                Prms(8).Value = Me._Puesto
                Prms(9).Value = DBNull.Value
                Prms(10).Value = DBNull.Value
                Prms(11).Value = DBNull.Value
                Prms(12).Value = Me._CategoriaTecnicaDocente
                Prms(13).Value = Me._TieneCategoAsocRP
                Prms(14).Value = Me._IdCategoriaRP
                Prms(15).Value = Me._IdPercepcionHoras
                Prms(16).Value = Me._IdFuncionPri
                Prms(17).Value = Me._EsCategoHomologada

                Return _DataCOBAEV.RunProc("SP_INuevaCategoria", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        'Public Function ObtenAdmvasDirec() As DataTable
        '    Try
        '        Return _DataCOBAEV.RunProc("SP_SCategoriasPorFuncion", DataCOBAEV.Tipoconsulta.Table, Nomina)
        '    Catch ex As Exception
        '        Throw (New System.Exception(ex.Message.ToString))
        '    End Try
        'End Function
        'Public Function ObtenAdmvasDirec(ByVal pIdEmpFuncion As Byte, ByVal pParaNombDeCompen As Boolean) As DataTable
        '    Try
        '        Dim Prms As SqlParameter() = {New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
        '                                      New SqlParameter("@ParaNombDeCompen", SqlDbType.Bit)}

        '        Prms(0).Value = pIdEmpFuncion
        '        Prms(1).Value = pParaNombDeCompen

        '        Return _DataCOBAEV.RunProc("SP_SCategoriasPorFuncion", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
        '    Catch ex As Exception
        '        Throw (New System.Exception(ex.Message.ToString))
        '    End Try
        'End Function
        Public Function ObtenPorFuncionDelEmpleado(ByVal IdEmpFuncion As Byte, ByVal pParaNombDeCompen As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                              New SqlParameter("@ParaNombDeCompen", SqlDbType.Bit)}

                Prms(0).Value = IdEmpFuncion
                Prms(1).Value = pParaNombDeCompen

                Return _DataCOBAEV.RunProc("SP_SCategoriasPorFuncion", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenOcupHistorica(ByVal pIdPlantel As Short, ByVal pIdCT As Short, ByVal pIdCategoria As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdCT", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdCategoria", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pIdCT
                Prms(2).Value = pIdCategoria

                Return _DataCOBAEV.RunProc("SP_SHistoricoOcupPorCategoDir", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDirectivasOcupPorPlantelyCT(ByVal pIdPlantel As Short, ByVal pIdCT As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdCT", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pIdCT

                Return _DataCOBAEV.RunProc("SP_SPlCTCategosDirOcup", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFuncionPrimaria(ByVal IdCategoria As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt)}

                Prms(0).Value = IdCategoria

                Return _DataCOBAEV.RunProc("SP_SFuncionPrimariaPorCategoria", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodas() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SCategorias", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenFiltradas(pIdEmpFuncion As Byte, pEstatus As Byte, pTipoPresup As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                              New SqlParameter("@Estatus", SqlDbType.TinyInt), _
                                              New SqlParameter("@TipoPresup ", SqlDbType.TinyInt)
                                              }

                Prms(0).Value = pIdEmpFuncion
                Prms(1).Value = pEstatus
                Prms(2).Value = pTipoPresup

                Return _DataCOBAEV.RunProc("SP_SCategorias2", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDetalles(pClavePuesto As String, pCveIdentificadorPuesto As Byte, Optional pIdQuincena As Short = 0) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClavePuesto", SqlDbType.NVarChar, 10), _
                                              New SqlParameter("@CveIdentificadorPuesto", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pClavePuesto
                Prms(1).Value = pCveIdentificadorPuesto
                Prms(2).Value = IIf(pIdQuincena = 0, DBNull.Value, pIdQuincena)

                Return _DataCOBAEV.RunProc("SP_SCategoriaDetalles", Prms, DataCOBAEV.Tipoconsulta.Table, MovsPersonal)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenActivasBasificables() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ActivasBasificables", SqlDbType.Bit)}

                Prms(0).Value = True

                Return _DataCOBAEV.RunProc("SP_SCategorias", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenActivasyNORP() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@SoloActivasyNoRP", SqlDbType.Bit)}

                Prms(0).Value = True

                Return _DataCOBAEV.RunProc("SP_SCategorias", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHomologadas() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SCategoriasHomologadas", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPercepcionesOrdinariasAsociadas(Optional ByVal Historia As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt), _
                                                New SqlParameter("@Historia", SqlDbType.Bit)}
                Prms(0).Value = Me._IdCategoria
                Prms(1).Value = Historia
                Return _DataCOBAEV.RunProc("SP_SPercepcionesOrdinariasPorCategoria", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEmpleadosVigentes(ByVal IdRol As Byte, ByVal ConsultaZonasEspecificas As Boolean, ByVal ConsultaPlantelesEspecificos As Boolean, ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}

                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = Me._IdCategoria
                Prms(1).Value = IdRol
                Prms(2).Value = ConsultaZonasEspecificas
                Prms(3).Value = ConsultaPlantelesEspecificos
                Prms(4).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SEmpleadosPorCategoria", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorFuncionDelEmpleado(ByVal IdEmpFuncion As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt)
                    }

                Prms(0).Value = IdEmpFuncion

                Return _DataCOBAEV.RunProc("SP_SCategoriasPorFuncion", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorFuncionDelEmpleado(ByVal pIdEmpFuncion As Byte, ByVal pIdEmpFuncion3 As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdEmpFuncion3", SqlDbType.TinyInt)}

                Prms(0).Value = pIdEmpFuncion
                Prms(1).Value = pIdEmpFuncion3

                Return _DataCOBAEV.RunProc("SP_SCategoriasPorFuncion", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorFuncEmp_TipoNomina(ByVal pIdEmpFuncion As Byte, ByVal pIdTipoNomina As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdTipoNomina", SqlDbType.TinyInt)}

                Prms(0).Value = pIdEmpFuncion
                Prms(1).Value = pIdTipoNomina

                Return _DataCOBAEV.RunProc("SP_SCategosPorFuncEmp_TipoNomina", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPercepcionesAsociadas(Optional ByVal Historia As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt)}
                Prms(0).Value = Me._IdCategoria
                Return _DataCOBAEV.RunProc("SP_SPercepcionesPorCategoria", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPercepcionParaModificar() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdZonaEco", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdQnaVigIniPerc", SqlDbType.SmallInt)}
                Prms(0).Value = Me._IdCategoria
                Prms(1).Value = Me._IdPercepcion
                Prms(2).Value = Me._IdZonaEco
                Prms(3).Value = Me._IdQnaVigIniPerc
                Return _DataCOBAEV.RunProc("SP_SPercepcionOrdinariaPorCategoria", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt)}
                Prms(0).Value = Me._IdCategoria
                Return _DataCOBAEV.RunProc("SP_SCategoriaPorId", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(pIdCategoria As Short, pParaCapturaPlazaBase As Boolean) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt), _
                                              New SqlParameter("@ParaCapturaPlazaBase", SqlDbType.Bit)}

                Prms(0).Value = pIdCategoria
                Prms(1).Value = pParaCapturaPlazaBase

                Return _DataCOBAEV.RunProc("SP_SCategoriaPorId", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSiEsHomologada(ByVal pIdCategoria As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt)}
                Prms(0).Value = pIdCategoria
                Return _DataCOBAEV.RunProc("SP_SCategoriaEsHomologada", Prms, DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaPercepcionPorCategoria(ByVal ModificarRP As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdZonaEco", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdQnaVigIniPerc", SqlDbType.SmallInt), _
                                                New SqlParameter("@ImpMenPerc", SqlDbType.Decimal), _
                                                New SqlParameter("@ModificaRP", SqlDbType.Bit)}
                Prms(0).Value = Me._IdCategoria
                Prms(1).Value = Me._IdPercepcion
                Prms(2).Value = Me._IdZonaEco
                Prms(3).Value = Me._IdQnaVigIniPerc
                Prms(4).Value = Me._ImpMenPerc
                Prms(5).Value = ModificarRP
                Return _DataCOBAEV.RunProc("SP_UCategoriasPercepciones", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaPercepcionPorCategoria(ByVal ModificarRP As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdZonaEco", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdQnaVigIniPerc", SqlDbType.SmallInt), _
                                                New SqlParameter("@ImpMenPerc", SqlDbType.Decimal), _
                                                New SqlParameter("@ModificaRP", SqlDbType.Bit)}
                Prms(0).Value = Me._IdCategoria
                Prms(1).Value = Me._IdPercepcion
                Prms(2).Value = Me._IdZonaEco
                Prms(3).Value = Me._IdQnaVigIniPerc
                Prms(4).Value = Me._ImpMenPerc
                Prms(5).Value = ModificarRP
                Return _DataCOBAEV.RunProc("SP_ICategoriasPercepciones", Prms, Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace