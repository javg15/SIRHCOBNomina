Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV
Namespace COBAEV.Administracion
    Public Class Usuario
        Private _Login As String
        Private _Password As String
        Private _ApellidoPaterno, _ApellidoMaterno, _Nombre As String
        Private _IdRol As Byte
        Private _IdUsuario As Short
        Private _DataCOBAEV As New DataCOBAEV
        Private _Iniciales As String
        Public Property Iniciales() As String
            Get
                Return _Iniciales
            End Get
            Set(ByVal Value As String)
                _Iniciales = Value
            End Set
        End Property
        Public Property IdUsuario() As Short
            Get
                Return _IdUsuario
            End Get
            Set(ByVal Value As Short)
                _IdUsuario = Value
            End Set
        End Property
        Public Property Login() As String
            Get
                Return _Login
            End Get
            Set(ByVal Value As String)
                _Login = Value
            End Set
        End Property
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal Value As String)
                _Password = Value
            End Set
        End Property
        Public Property ApellidoPaterno() As String
            Get
                Return _ApellidoPaterno
            End Get
            Set(ByVal Value As String)
                _ApellidoPaterno = Value
            End Set
        End Property
        Public Property ApellidoMaterno() As String
            Get
                Return _ApellidoMaterno
            End Get
            Set(ByVal Value As String)
                _ApellidoMaterno = Value
            End Set
        End Property
        Public Property Nombre() As String
            Get
                Return _Nombre
            End Get
            Set(ByVal Value As String)
                _Nombre = Value
            End Set
        End Property
        Public Property IdRol() As Byte
            Get
                Return _IdRol
            End Get
            Set(ByVal Value As Byte)
                _IdRol = Value
            End Set
        End Property
        Public Function EsValido() As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@Password", SqlDbType.NVarChar, 15), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@UsuarioValido", SqlDbType.Bit)}

                Prms(0).Value = _Login
                Prms(1).Value = _Password
                Prms(2).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(3).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_SValidaUsuario", Prms, 0)

                Return Prms(3).Value

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsValido(ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@Password", SqlDbType.NVarChar, 15), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@UsuarioValido", SqlDbType.Bit)}

                Prms(0).Value = _Login
                Prms(1).Value = _Password
                Prms(2).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(3).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_SValidaUsuario", Prms, 0, ArregloAuditoria)

                Return Prms(3).Value

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerNodosMenu() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}
                Prms(0).Value = _Login
                Prms(1).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Return _DataCOBAEV.RunProc("SP_SMenuPorUsuario", Prms, DataCOBAEV.Tipoconsulta.Table, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPropiedadesDelRol() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}

                Prms(0).Value = _Login
                Prms(1).Value = ConfigurationManager.AppSettings("NombreAplicacion")

                Return _DataCOBAEV.RunProc("SP_SPropiedadesDelRolDelUsr", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Administracion)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPropiedadesDelRol(ByVal pLogin As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}
                Prms(0).Value = pLogin
                Prms(1).Value = ConfigurationManager.AppSettings("NombreAplicacion")

                Return _DataCOBAEV.RunProc("SP_SPropiedadesDelRolDelUsr", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Administracion)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function TienePermisoSobrePagina(ByVal NombrePagina As String, ByVal TipoOperacion As Byte) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@NombrePagina", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                            New SqlParameter("@TienePermiso", SqlDbType.Bit)}
                Prms(0).Value = _Login
                Prms(1).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(2).Value = NombrePagina
                Prms(3).Value = TipoOperacion
                Prms(4).Direction = ParameterDirection.Output
                _DataCOBAEV.RunProc("SP_SValidaPermisos", Prms, DataCOBAEV.BD.Administracion)
                Return Prms(4).Value
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPermisosSobreTabla(ByVal pLogin As String, ByVal pNombreTabla As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@NombreTabla", SqlDbType.NVarChar, 40)}

                Prms(0).Value = pLogin
                Prms(1).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(2).Value = pNombreTabla

                Return _DataCOBAEV.RunProc("SP_SPermisosSobreTabla", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Administracion)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPorAplicacion() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20)}
                Prms(0).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Return _DataCOBAEV.RunProc("SP_SUsuariosPorAplicacion", Prms, DataCOBAEV.Tipoconsulta.Table, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPorId() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}
                Prms(0).Value = _IdUsuario
                Return _DataCOBAEV.RunProc("SP_SUsuarios", Prms, DataCOBAEV.Tipoconsulta.DataRow, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal pIdUsuario As Short) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}

                Prms(0).Value = pIdUsuario

                Return _DataCOBAEV.RunProc("SP_SUsuarios", Prms, DataCOBAEV.Tipoconsulta.DataRow, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPorLogin(ByVal pLogin As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30)}
                Prms(0).Value = pLogin
                Return _DataCOBAEV.RunProc("SP_SUsuarios", Prms, DataCOBAEV.Tipoconsulta.DataRow, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenerPorLogin() As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30)}
                Prms(0).Value = Me._Login
                Return _DataCOBAEV.RunProc("SP_SUsuarios", Prms, DataCOBAEV.Tipoconsulta.DataRow, 0)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizarPassword() As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@Password", SqlDbType.NVarChar, 15)}
                Prms(0).Value = Me._Login
                Prms(1).Value = Me._Password

                Return _DataCOBAEV.RunProc("SP_UPasswordDeUsuario", Prms, DataCOBAEV.BD.Administracion)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Actualizar(ByVal TipoOperacion As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                            New SqlParameter("@Login", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@Password", SqlDbType.NVarChar, 15), _
                                            New SqlParameter("@ApellidoPaterno", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@ApellidoMaterno", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@Nombre", SqlDbType.NVarChar, 30), _
                                            New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                            New SqlParameter("@NombreAplicacion", SqlDbType.NVarChar, 20), _
                                            New SqlParameter("@TipoOperacion", SqlDbType.TinyInt), _
                                            New SqlParameter("@Iniciales", SqlDbType.NVarChar, 5)}
                Prms(0).Value = IIf(TipoOperacion = 1, DBNull.Value, Me._IdUsuario)
                Prms(1).Value = Me._Login
                Prms(2).Value = IIf(TipoOperacion = 0, DBNull.Value, Me._Password)
                Prms(3).Value = Me._ApellidoPaterno
                Prms(4).Value = Me._ApellidoMaterno
                Prms(5).Value = Me._Nombre
                Prms(6).Value = Me._IdRol
                Prms(7).Value = ConfigurationManager.AppSettings("NombreAplicacion")
                Prms(8).Value = TipoOperacion
                Prms(9).Value = Me._Iniciales

                Return _DataCOBAEV.RunProc("SP_IoUUsuarios", Prms, DataCOBAEV.BD.Administracion, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Insertar(ByVal ArregloAuditoria() As String) As Boolean
            Return Actualizar(1, ArregloAuditoria)
        End Function
        Public Function EsAdministrador(ByVal Login As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30)}
                Dim drAdmin As DataRow

                Prms(0).Value = Login

                drAdmin = _DataCOBAEV.RunProc("SP_SUsuarioEsAdministrador", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Administracion)

                Return CBool(drAdmin("Administrador"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsSuperAdmin(ByVal Login As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30)}
                Dim drAdmin As DataRow

                Prms(0).Value = Login

                drAdmin = _DataCOBAEV.RunProc("SP_SUsuarioEsSuperAdmin", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Administracion)

                Return CBool(drAdmin("EsSuperAdmin"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsSegSoc(ByVal Login As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30)}
                Dim drSegSoc As DataRow

                Prms(0).Value = Login

                drSegSoc = _DataCOBAEV.RunProc("SP_SUsrEsSegSoc", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Administracion)

                Return CBool(drSegSoc("EsSegSoc"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsAnalistaDeSegSoc(ByVal Login As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30)}
                Dim drSegSoc As DataRow

                Prms(0).Value = Login

                drSegSoc = _DataCOBAEV.RunProc("SP_SUsrEsAnalistaSegSoc", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Administracion)

                Return CBool(drSegSoc("EsAnalistaSegSoc"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsVIP(ByVal Login As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30)}
                Dim drVIP As DataRow

                Prms(0).Value = Login

                drVIP = _DataCOBAEV.RunProc("SP_SUsuarioEsVIP", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Administracion)

                Return CBool(drVIP("VIP"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsEnlaceContable(ByVal Login As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30)}
                Dim drEnlaceContable As DataRow

                Prms(0).Value = Login

                drEnlaceContable = _DataCOBAEV.RunProc("SP_SUsrEsEnlaceContable", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Administracion)

                Return CBool(drEnlaceContable("EsEnlaceContable"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsAnalista(ByVal Login As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Login", SqlDbType.NVarChar, 30)}
                Dim drAnalista As DataRow

                Prms(0).Value = Login

                drAnalista = _DataCOBAEV.RunProc("SP_SUsrEsAnalista", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Administracion)

                Return CBool(drAnalista("EsAnalista"))
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
    End Class
End Namespace