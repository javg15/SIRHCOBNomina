Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Administracion
    Public Class Aplicacion
#Region "Clase Aplicación: Variables privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdRol, _IdNodoMenu As Byte
        Private _NombreRol As String
        Private _NodoChecked As Boolean
        Private _ConsultaZonasEspecificas, _ConsultaPlantelesEspecificos As Boolean
        Private _VisibilidadDeQnasAdic, _CalculaDecAnual, _Administrador As Boolean
#End Region
#Region "Clase Aplicación: Propiedades públicas"
        Public Property Administrador() As Boolean
            Get
                Return Me._Administrador
            End Get
            Set(ByVal value As Boolean)
                Me._Administrador = value
            End Set
        End Property
        Public Property CalculaDecAnual() As Boolean
            Get
                Return Me._CalculaDecAnual
            End Get
            Set(ByVal value As Boolean)
                Me._CalculaDecAnual = value
            End Set
        End Property
        Public Property VisibilidadDeQnasAdic() As Boolean
            Get
                Return Me._VisibilidadDeQnasAdic
            End Get
            Set(ByVal value As Boolean)
                Me._VisibilidadDeQnasAdic = value
            End Set
        End Property
        Public Property ConsultaPlantelesEspecificos() As Boolean
            Get
                Return Me._ConsultaPlantelesEspecificos
            End Get
            Set(ByVal value As Boolean)
                Me._ConsultaPlantelesEspecificos = value
            End Set
        End Property
        Public Property ConsultaZonasEspecificas() As Boolean
            Get
                Return Me._ConsultaZonasEspecificas
            End Get
            Set(ByVal value As Boolean)
                Me._ConsultaZonasEspecificas = value
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
        Public Property IdNodoMenu() As Byte
            Get
                Return Me._IdNodoMenu
            End Get
            Set(ByVal value As Byte)
                Me._IdNodoMenu = value
            End Set
        End Property
        Public Property NombreRol() As String
            Get
                Return Me._NombreRol
            End Get
            Set(ByVal value As String)
                Me._NombreRol = value
            End Set
        End Property
        Public Property NodoChecked() As Boolean
            Get
                Return Me._NodoChecked
            End Get
            Set(ByVal value As Boolean)
                Me._NodoChecked = value
            End Set
        End Property
#End Region
        Public Function UpdMsjsParaUsuario(ByVal pIdMsj As Integer, pAtendido As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdMsj", SqlDbType.Int), _
                                              New SqlParameter("@Atendido", SqlDbType.Int)}

                Prms(0).Value = pIdMsj
                Prms(1).Value = pAtendido

                Return _DataCOBAEV.RunProc("SP_UTblMsjsParaUsuarios", Prms, DataCOBAEV.BD.Administracion, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GetMsjsParaUsuario(pLogin As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30)}
                Dim dt As DataTable = Nothing

                If pLogin Is Nothing = False Then
                    Prms(0).Value = pLogin
                    dt = _DataCOBAEV.RunProc("SP_STblMsjsParaUsuarios", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Administracion)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsMsjsParaUsuarios(ByVal pNomProc As String, pLogin As String, pMsj As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NomProc", SqlDbType.NVarChar, 60), _
                                              New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                              New SqlParameter("@Msj", SqlDbType.NVarChar, 500)}
                Prms(0).Value = pNomProc
                Prms(1).Value = pLogin
                Prms(2).Value = pMsj

                Return _DataCOBAEV.RunProc("SP_ITblMsjsParaUsuarios", Prms, DataCOBAEV.BD.Administracion)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPermisosUsrTablasCampos(ByVal pLogin As String, ByVal pNombreTabla As String, _
                                                       ByVal pNombreCampo As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                              New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                              New SqlParameter("@NombreTabla", SqlDbType.NVarChar, 40), _
                                              New SqlParameter("@NombreCampo", SqlDbType.NVarChar, 50)}

                Prms(0).Value = pLogin
                Prms(1).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(2).Value = pNombreTabla
                Prms(3).Value = pNombreCampo

                Return _DataCOBAEV.RunProc("SP_SPermisosTablaCampo", Prms, DataCOBAEV.Tipoconsulta.DataRow, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsUpdRolesDeducciones(ByVal pIdRol As Byte, pIdDeduccion As Short, pPermisoCapturaNomina As Boolean, _
                                           pPermisoCapturaRecibo As Boolean, pPermisoConsulta As Boolean, _
                                           pPermisoTblRolesDeduccionesParaRecibos As Boolean, _
                                           pPermisoTblRolesDeducciones As Boolean, _
                                           ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdDeduccion", SqlDbType.SmallInt), _
                                              New SqlParameter("@PermisoCapturaNomina", SqlDbType.Bit), _
                                              New SqlParameter("@PermisoCapturaRecibo", SqlDbType.Bit), _
                                              New SqlParameter("@PermisoConsulta", SqlDbType.Bit), _
                                              New SqlParameter("@PermisoTblRolesDeduccionesParaRecibos", SqlDbType.Bit), _
                                              New SqlParameter("@PermisoTblRolesDeducciones", SqlDbType.Bit)}
                Prms(0).Value = pIdRol
                Prms(1).Value = pIdDeduccion
                Prms(2).Value = pPermisoCapturaNomina
                Prms(3).Value = pPermisoCapturaRecibo
                Prms(4).Value = pPermisoConsulta
                Prms(5).Value = pPermisoTblRolesDeduccionesParaRecibos
                Prms(6).Value = pPermisoTblRolesDeducciones

                Return _DataCOBAEV.RunProc("SP_IoURolesDeducciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsUpdRolesPercepciones(ByVal pIdRol As Byte, pIdPercepcion As Short, pPermisoCapturaNomina As Boolean, _
                                           pPermisoCapturaRecibo As Boolean, pPermisoConsulta As Boolean, _
                                           pPermisoTblRolesPercepcionesParaRecibos As Boolean, _
                                           pPermisoTblRolesPercepciones As Boolean, _
                                           ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdPercepcion", SqlDbType.SmallInt), _
                                              New SqlParameter("@PermisoCapturaNomina", SqlDbType.Bit), _
                                              New SqlParameter("@PermisoCapturaRecibo", SqlDbType.Bit), _
                                              New SqlParameter("@PermisoConsulta", SqlDbType.Bit), _
                                              New SqlParameter("@PermisoTblRolesPercepcionesParaRecibos", SqlDbType.Bit), _
                                              New SqlParameter("@PermisoTblRolesPercepciones", SqlDbType.Bit)}
                Prms(0).Value = pIdRol
                Prms(1).Value = pIdPercepcion
                Prms(2).Value = pPermisoCapturaNomina
                Prms(3).Value = pPermisoCapturaRecibo
                Prms(4).Value = pPermisoConsulta
                Prms(5).Value = pPermisoTblRolesPercepcionesParaRecibos
                Prms(6).Value = pPermisoTblRolesPercepciones

                Return _DataCOBAEV.RunProc("SP_IoURolesPercepciones", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsUpdRolesReportes(ByVal pIdRol As Byte, pIdReporte As Short, pPermiso As Boolean, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdReporte", SqlDbType.SmallInt), _
                                              New SqlParameter("@Permiso", SqlDbType.Bit)}
                Prms(0).Value = pIdRol
                Prms(1).Value = pIdReporte
                Prms(2).Value = pPermiso
                Return _DataCOBAEV.RunProc("SP_IoURolesReportes", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsUpdRolesPaginas(ByVal pIdRol As Byte, pIdPagina As Short, pActualizacion As Boolean, _
                                           pInsercion As Boolean, pEliminacion As Boolean, pConsulta As Boolean, _
                                           ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdPagina", SqlDbType.SmallInt), _
                                              New SqlParameter("@Actualizacion", SqlDbType.Bit), _
                                              New SqlParameter("@Insercion", SqlDbType.Bit), _
                                              New SqlParameter("@Eliminacion", SqlDbType.Bit), _
                                              New SqlParameter("@Consulta", SqlDbType.Bit)}
                Prms(0).Value = pIdRol
                Prms(1).Value = pIdPagina
                Prms(2).Value = pActualizacion
                Prms(3).Value = pInsercion
                Prms(4).Value = pEliminacion
                Prms(5).Value = pConsulta
                Return _DataCOBAEV.RunProc("SP_IoURolesPaginas", Prms, DataCOBAEV.BD.Administracion, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsUpdRolesTablas(ByVal pIdRol As Byte, pIdTabla As Short, pActualizacion As Boolean, _
                                           pInsercion As Boolean, pEliminacion As Boolean, pConsulta As Boolean, _
                                           pSoloConsulta As Boolean, pNombreTabla As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdTabla", SqlDbType.SmallInt), _
                                              New SqlParameter("@Actualizacion", SqlDbType.Bit), _
                                              New SqlParameter("@Insercion", SqlDbType.Bit), _
                                              New SqlParameter("@Eliminacion", SqlDbType.Bit), _
                                              New SqlParameter("@Consulta", SqlDbType.Bit), _
                                              New SqlParameter("@SoloConsulta", SqlDbType.Bit), _
                                              New SqlParameter("@NombreTabla", SqlDbType.NVarChar, 40)}
                Prms(0).Value = pIdRol
                Prms(1).Value = pIdTabla
                Prms(2).Value = pActualizacion
                Prms(3).Value = pInsercion
                Prms(4).Value = pEliminacion
                Prms(5).Value = pConsulta
                Prms(6).Value = pSoloConsulta
                Prms(7).Value = pNombreTabla
                Return _DataCOBAEV.RunProc("SP_IoURolesTablas", Prms, DataCOBAEV.BD.Administracion, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPermisosRolPaginas(ByVal pIdRol As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                              New SqlParameter("@IdRol", SqlDbType.TinyInt)}
                Prms(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(1).Value = pIdRol
                Return _DataCOBAEV.RunProc("SP_SPermisosRolesPaginas", Prms, DataCOBAEV.Tipoconsulta.Table, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPermisosRolPercepciones(ByVal pIdRol As Short, pNombreRol As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                              New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@NombreRol", SqlDbType.NVarChar, 50)}

                Prms(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(1).Value = pIdRol
                Prms(2).Value = pNombreRol

                Return _DataCOBAEV.RunProc("SP_SRolesPermisosSobrePercs", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPermisosRolDeducciones(ByVal pIdRol As Short, pNombreRol As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                              New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@NombreRol", SqlDbType.NVarChar, 50)}

                Prms(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(1).Value = pIdRol
                Prms(2).Value = pNombreRol

                Return _DataCOBAEV.RunProc("SP_SRolesPermisosSobreDeducs", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPermisosRolesPercepciones(ByVal pIdRol As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt)}

                Prms(0).Value = pIdRol

                Return _DataCOBAEV.RunProc("SP_SPermisosRolesPercepciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPermisosRolesPercepciones(ByVal pIdRol As Short, ByVal pIdPercepcion As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdPercepcion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdRol
                Prms(1).Value = pIdPercepcion

                Return _DataCOBAEV.RunProc("SP_SPermisosRolesPercepciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPermisosRolesDeducciones(ByVal pIdRol As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt)}

                Prms(0).Value = pIdRol

                Return _DataCOBAEV.RunProc("SP_SPermisosRolesDeducciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPermisosRolesDeducciones(ByVal pIdRol As Short, ByVal pIdDeduccion As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdDeduccion", SqlDbType.SmallInt)}

                Prms(0).Value = pIdRol
                Prms(1).Value = pIdDeduccion

                Return _DataCOBAEV.RunProc("SP_SPermisosRolesDeducciones", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPermisosRolReportes(ByVal pIdRol As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                              New SqlParameter("@IdRol", SqlDbType.TinyInt)}
                Prms(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(1).Value = pIdRol
                Return _DataCOBAEV.RunProc("SP_SPermisosRolesReportes", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPermisosRolTablas(ByVal pIdRol As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                              New SqlParameter("@IdRol", SqlDbType.TinyInt)}
                Prms(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(1).Value = pIdRol
                Return _DataCOBAEV.RunProc("SP_SPermisosRolesTablas", Prms, DataCOBAEV.Tipoconsulta.Table, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDeBDNomina() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SSPs", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPropiedadesRol(ByVal pIdRol As Byte) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}
                Prms(0).Value = pIdRol
                Prms(1).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Return _DataCOBAEV.RunProc("SP_SRolPorId", Prms, DataCOBAEV.Tipoconsulta.DataRow, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizarPropiedades(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                            New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                            New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                            New SqlParameter("@VisibilidadDeQnasAdic", SqlDbType.Bit), _
                                            New SqlParameter("@CalculaDecAnual", SqlDbType.Bit), _
                                            New SqlParameter("@Administrador", SqlDbType.Bit)}

                Prms(0).Value = Me._IdRol
                Prms(1).Value = Me._ConsultaZonasEspecificas
                Prms(2).Value = Me._ConsultaPlantelesEspecificos
                Prms(3).Value = Me._VisibilidadDeQnasAdic
                Prms(4).Value = Me._CalculaDecAnual
                Prms(5).Value = Me._Administrador

                Return _DataCOBAEV.RunProc("SP_URol", Prms, 0, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GuardaRol(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Byte
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                            New SqlParameter("@NombreRol", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@IdNodoMenu", SqlDbType.TinyInt), _
                                            New SqlParameter("@NodoChecked", SqlDbType.Bit), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                            New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                            New SqlParameter("@VisibilidadDeQnasAdic", SqlDbType.Bit), _
                                            New SqlParameter("@CalculaDecAnual", SqlDbType.Bit), _
                                            New SqlParameter("@Administrador", SqlDbType.Bit)}

                Prms(0).Direction = ParameterDirection.InputOutput
                If TipoOperacion = 0 Then 'Actualización
                    Prms(0).Value = Me._IdRol
                    Prms(1).Value = DBNull.Value
                Else
                    Prms(0).Value = IIf(Me._IdRol > 0, Me._IdRol, DBNull.Value)
                    Prms(1).Value = IIf(Me._NombreRol <> String.Empty, Me._NombreRol, DBNull.Value)
                End If
                Prms(2).Value = Me._IdNodoMenu
                Prms(3).Value = Me._NodoChecked
                Prms(4).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(5).Value = Me._ConsultaZonasEspecificas
                Prms(6).Value = Me._ConsultaPlantelesEspecificos
                Prms(7).Value = Me._VisibilidadDeQnasAdic
                Prms(8).Value = Me._CalculaDecAnual
                Prms(9).Value = Me._Administrador

                _DataCOBAEV.RunProc("SP_IRolNodosMenu", Prms, 0, ArregloAuditoria)

                Return Prms(0).Value
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerNodosMenu() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}
                Prms(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Return _DataCOBAEV.RunProc("SP_SMenuPorAplicacion", Prms, DataCOBAEV.Tipoconsulta.Table, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerRoles() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SRoles", DataCOBAEV.Tipoconsulta.Table, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerNodosMenuPorRol(ByVal IdRol As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}
                Prms(0).Value = IdRol
                Prms(1).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Return _DataCOBAEV.RunProc("SP_SMenuPorRol", Prms, DataCOBAEV.Tipoconsulta.Table, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPropiedadesPorRol(ByVal IdRol As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}
                Prms(0).Value = IdRol
                Prms(1).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Return _DataCOBAEV.RunProc("SP_SPropiedadesDelRolDelUsr", Prms, DataCOBAEV.Tipoconsulta.Table, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfSobrePagina(ByVal NombrePagina As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50)}
                Prms(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(1).Value = NombrePagina
                Return _DataCOBAEV.RunProc("SP_SPagina", Prms, DataCOBAEV.Tipoconsulta.DataRow, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function PaginaEstaRegistrada(ByVal pNombrePagina As String, pNombreAplicacion As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50), _
                                              New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}
                Prms(0).Value = pNombrePagina
                Prms(1).Value = pNombreAplicacion
                Return _DataCOBAEV.RunProc("SP_SVPaginaRegistrada", Prms, DataCOBAEV.BD.Administracion)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDatosEmpresa() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEmpresa", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Administracion)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AgregaPagina(ByVal pNombrePagina As String, pNombreAplicacion As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50), _
                                              New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}

                Prms(0).Value = pNombrePagina
                Prms(1).Value = pNombreAplicacion

                Return _DataCOBAEV.RunProc("SP_IPagina", Prms, DataCOBAEV.BD.Administracion, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AgregaTabla(ByVal pNombreTabla As String, pNombreAplicacion As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombreTabla", SqlDbType.NVarChar, 40), _
                                              New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}

                Prms(0).Value = pNombreTabla
                Prms(1).Value = pNombreAplicacion

                Return _DataCOBAEV.RunProc("SP_ITablas", Prms, DataCOBAEV.BD.Administracion, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
    End Class
#Region "Clase Auditoría"
    Public Class Auditoria
        Private _DataCOBAEV As New DataCOBAEV
#Region "Clase Aplicación: Propiedades públicas"
        Public Function InsertaRegistro(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim _Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@IP", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@NomAplic", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@Query", SqlDbType.NVarChar, 1000)}
                Dim strQuery As String

                _Prms(0).Value = ArregloAuditoria(1)
                _Prms(1).Value = ArregloAuditoria(0)
                _Prms(2).Value = ConfigurationManager.AppSettings("NombreAplicacion")

                strQuery = "EXEC " + ArregloAuditoria(2)

                _Prms(3).Value = strQuery

                Return _DataCOBAEV.RunProc("SP_IAuditoria", _Prms, DataCOBAEV.BD.Administracion)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function InsertaRegistro(ByVal ArregloAuditoria() As String, ByVal Prms As SqlParameter()) As Boolean
            Try
                Dim _Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@IP", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@NomAplic", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@Query", SqlDbType.NVarChar, 1000)}
                Dim strQuery As String
                Dim Ind As Byte

                _Prms(0).Value = ArregloAuditoria(1)
                _Prms(1).Value = ArregloAuditoria(0)
                _Prms(2).Value = ConfigurationManager.AppSettings("NombreAplicacion")

                strQuery = "EXEC " + ArregloAuditoria(2) + " "

                For Ind = 0 To Prms.Length - 1
                    If Prms(Ind).Value Is Nothing Then
                        strQuery += Prms(Ind).ParameterName + "=NULL"
                    Else
                        strQuery += Prms(Ind).ParameterName + "=" + Prms(Ind).Value.ToString
                    End If

                    If Ind < Prms.Length - 1 Then
                        strQuery += ", "
                    End If
                Next Ind

                _Prms(3).Value = strQuery

                Return _DataCOBAEV.RunProc("SP_IAuditoria", _Prms, DataCOBAEV.BD.Administracion)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace