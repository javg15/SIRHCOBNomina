Imports System.Data.SqlClient
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV.MovsDePersonal
#Region "Clase Niveles Salariales"
    Public Class NivelesSalariales
#Region "Niveles Salariales: Propiedades Privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Niveles Salariales: Propiedades Públicas"

#End Region
#Region "Niveles Salariales: Métodos Públicos"
        Public Function GetPorQna(ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.Int)}

                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SNivelesSalariales", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.MovsPersonal)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
#Region "Niveles Salariales: Métodos Privados"

#End Region
    End Class
#End Region
#Region "Clase Puestos"
    Public Class Puestos
#Region "Clase Puestos: Propiedades Privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Puestos: Propiedades Públicas"

#End Region
#Region "Clase Puestos: Métodos Públicos"
        Public Function GetNivelSalarialPorQna(ByVal pNivelSalarial As String, ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NivelSalarial", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@IdQuincena", SqlDbType.Int)}

                Prms(0).Value = pNivelSalarial
                Prms(1).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SNivelSalarial", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.MovsPersonal)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GetVigentesPorQna(ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.Int)}

                Prms(0).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SPuestosVigentesPorQna", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.MovsPersonal)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GetPlazas(ByVal pCvePuestoCompuesta As String, ByVal pCveZonaEco As String, ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CvePuestoCompuesta", SqlDbType.NVarChar, 14), _
                                              New SqlParameter("@CveZonaEco", SqlDbType.NVarChar, 2), _
                                            New SqlParameter("@IdQuincena", SqlDbType.Int)}

                Prms(0).Value = pCvePuestoCompuesta
                Prms(1).Value = pCveZonaEco
                Prms(2).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SPlazasPorPuesto", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.MovsPersonal)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
#Region "Clase Puestos: Métodos Privados"

#End Region
    End Class
#End Region
#Region "Clase MovsDePersonal"

    Public Class MovsDePersonal
#Region "Clase MovsDePersonal: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase MovsDePersonal: Métodos privados"

#End Region
#Region "Clase MovsDePersonal: Métodos públicos"
        Public Function ElminaPorIdPlaza(ByVal pIdPlaza As Integer, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = pIdPlaza

                Return _DataCOBAEV.RunProc("SP_DSMP_MovDePersPorIdPlaza", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorEmpleado(pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}
                Prms(0).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SMP_MovimientosDePersonal", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTramites() As DataTable
            Try

                Return _DataCOBAEV.RunProc("SP_SMP_Tramites", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMotivosPorTramite(pIdTramite As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTramite", SqlDbType.SmallInt)}

                Prms(0).Value = pIdTramite

                Return _DataCOBAEV.RunProc("SP_SMP_Motivos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfTramiteMotivo(pIdTramite As Short, pIdMotivo As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTramite", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMotivo", SqlDbType.SmallInt)}

                Prms(0).Value = pIdTramite
                Prms(1).Value = pIdMotivo

                Return _DataCOBAEV.RunProc("SP_SMP_Motivos", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class

    Public Class OrdenesDePresentacion
#Region "Clase OrdenesDePresentacion: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase OrdenesDePresentacion: Métodos públicos"

        Public Function EstaAbiertaParaCaptura(ByVal pIdOrdenDePres As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdOrdenDePres", SqlDbType.Int)}

                Prms(0).Value = pIdOrdenDePres

                Return _DataCOBAEV.RunProc("SP_VSiOrdenDePresEstaAbiertaParaCaptura", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAbiertasPorUsr(ByVal pLogin As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                               New SqlParameter("@Administrador", SqlDbType.Bit)}
                Dim oUsr As New Usuario
                Dim drUsr, drRol As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)
                oUsr.Login = pLogin
                drRol = oUsr.ObtenerPropiedadesDelRol().Rows(0)

                Prms(0).Value = CShort(drUsr("IdUsuario"))
                Prms(1).Value = CBool(drRol("Administrador"))

                Return _DataCOBAEV.RunProc("SP_SOrdenesDePresAbiertasParaCaptura", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaInf(ByVal pIdOrdenDePres As Integer, ByVal pFchParaOrdDePres As String, ByVal pOficioDePropuesta As String, ByVal pLogin As String, _
        ByVal pIdEstatusOP As Byte, ByVal pIdOrigenPropuesta As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdOrdenDePres", SqlDbType.SmallInt), _
                                            New SqlParameter("@FchParaOrdDePres", SqlDbType.DateTime), _
                                            New SqlParameter("@OficioDePropuesta", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdEstatusOP", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdOrigenPropuesta", SqlDbType.TinyInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)

                Prms(0).Value = pIdOrdenDePres
                Prms(1).Value = IIf(pFchParaOrdDePres.Trim = String.Empty, DBNull.Value, pFchParaOrdDePres.Trim)
                Prms(2).Value = pOficioDePropuesta
                Prms(3).Value = CShort(drUsr("IdUsuario"))
                Prms(4).Value = pIdEstatusOP
                Prms(5).Value = pIdOrigenPropuesta

                Return _DataCOBAEV.RunProc("SP_UOrdenesDePresentacion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTipo(ByVal pIdOrdenDePres As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdOrdenDePres", SqlDbType.Int)}

                Prms(0).Value = pIdOrdenDePres

                Return _DataCOBAEV.RunProc("SP_SOrdenesDePresTipo", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesEstatus() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEstatusOrdenesDePres", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorEjercUsr(ByVal pLogin As String, ByVal pEjercicio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                               New SqlParameter("@Ejercicio", SqlDbType.SmallInt), _
                                               New SqlParameter("@Administrador", SqlDbType.Bit)}
                Dim oUsr As New Usuario
                Dim drUsr, drRol As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)
                oUsr.Login = pLogin
                drRol = oUsr.ObtenerPropiedadesDelRol().Rows(0)

                Prms(0).Value = CShort(drUsr("IdUsuario"))
                Prms(1).Value = pEjercicio
                Prms(2).Value = CBool(drRol("Administrador"))

                Return _DataCOBAEV.RunProc("SP_SOrdenesDePresentacion", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraNueva(ByVal pLogin As String, ByVal ArregloAuditoria() As String) As Integer
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuarioCreador", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdOrdenDePres", SqlDbType.Int)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)
                oUsr.Login = pLogin

                Prms(0).Value = CShort(drUsr("IdUsuario"))
                Prms(1).Direction = ParameterDirection.Output

                _DataCOBAEV.RunProc("SP_IOrdenDePresentacion", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Return Prms(1).Value
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AsociaHora(ByVal pIdHora As Integer, ByVal pIdOrdenDePres As Integer, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int), _
                                                New SqlParameter("@IdOrdenDePres", SqlDbType.Int)}

                Prms(0).Value = pIdHora
                Prms(1).Value = pIdOrdenDePres

                Return _DataCOBAEV.RunProc("SP_IOrdenesDePresentacionHoras", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AsociaAPlaza(ByVal pIdPlaza As Integer, ByVal pIdOrdenDePres As Integer, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                                New SqlParameter("@IdOrdenDePres", SqlDbType.Int)}

                Prms(0).Value = pIdPlaza
                Prms(1).Value = pIdOrdenDePres

                Return _DataCOBAEV.RunProc("SP_IOrdenesDePresentacionPlazas", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
    Public Class Cadenas
#Region "Clase Cadenas: Propiedades públicas"
#End Region
#Region "Clase Cadenas: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Cadenas: Métodos públicos"
        Public Function TieneMovsDePersAsociados(ByVal pIdCadena As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.Int)}

                Prms(0).Value = pIdCadena

                Return _DataCOBAEV.RunProc("SP_VSiCadenaTieneMovsDePers", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EstaAbiertaParaCaptura(ByVal pIdCadena As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.Int)}

                Prms(0).Value = pIdCadena

                Return _DataCOBAEV.RunProc("SP_VSiCadenaEstaAbiertaParaCaptura", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function Elimina(ByVal pIdCadena As Integer, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.Int)}

                Prms(0).Value = pIdCadena

                Return _DataCOBAEV.RunProc("SP_DCadena", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaMov(ByVal pIdCadena As Integer, ByVal pIdPlaza As Integer, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.Int), _
                                                New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = pIdCadena
                Prms(1).Value = pIdPlaza

                Return _DataCOBAEV.RunProc("SP_DCadenaPlaza", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal pIdCadena As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.Int)}

                Prms(0).Value = pIdCadena

                Return _DataCOBAEV.RunProc("SP_SCadenas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMovsAsociados(ByVal pIdCadena As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.Int)}

                Prms(0).Value = pIdCadena

                Return _DataCOBAEV.RunProc("SP_SCadenasPlazas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AgregaNumOrdPresAMov(ByVal pIdCadena As Integer, ByVal pIdPlaza As Integer, ByVal pLogin As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.Int), _
                                            New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                            New SqlParameter("@GeneraNumOrdPres", SqlDbType.Bit)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)
                oUsr.Login = pLogin

                Prms(0).Value = pIdCadena
                Prms(1).Value = pIdPlaza
                Prms(2).Value = CShort(drUsr("IdUsuario"))
                Prms(3).Value = True

                Return _DataCOBAEV.RunProc("SP_UCadenaPlaza", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaMov(ByVal pIdCadena As Integer, ByVal pIdPlaza As Integer, ByVal pLogin As String, ByVal pTipoMov As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.Int), _
                                            New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                            New SqlParameter("@TipoMov", SqlDbType.NVarChar, 1)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)
                oUsr.Login = pLogin

                Prms(0).Value = pIdCadena
                Prms(1).Value = pIdPlaza
                Prms(2).Value = CShort(drUsr("IdUsuario"))
                Prms(3).Value = pTipoMov

                Return _DataCOBAEV.RunProc("SP_UCadenaPlaza", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaMov(ByVal pIdCadenaAnt As Integer, ByVal pIdCadenaNueva As Integer, ByVal pIdPlaza As Integer, ByVal pLogin As String, ByVal pTipoMov As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.Int), _
                                            New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                            New SqlParameter("@TipoMov", SqlDbType.NVarChar, 1), _
                                            New SqlParameter("@IdCadenaNueva", SqlDbType.Int)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)
                oUsr.Login = pLogin

                Prms(0).Value = pIdCadenaAnt
                Prms(1).Value = pIdPlaza
                Prms(2).Value = CShort(drUsr("IdUsuario"))
                Prms(3).Value = pTipoMov
                Prms(4).Value = pIdCadenaNueva

                Return _DataCOBAEV.RunProc("SP_UCadenaPlaza", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function AgregaMovs(ByVal pIdCadena As Integer, ByVal pIdPlaza As Integer, ByVal pLogin As String, ByVal pTipoMov As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.Int), _
                                            New SqlParameter("@IdPlaza", SqlDbType.Int), _
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                            New SqlParameter("@TipoMov", SqlDbType.NVarChar, 1)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)
                oUsr.Login = pLogin

                Prms(0).Value = pIdCadena
                Prms(1).Value = pIdPlaza
                Prms(2).Value = CShort(drUsr("IdUsuario"))
                Prms(3).Value = pTipoMov

                Return _DataCOBAEV.RunProc("SP_ICadenaPlaza", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSiPlazaEstaEnCadena(ByVal pIdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = pIdPlaza

                Return _DataCOBAEV.RunProc("SP_SCadenasPlazas", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSiPlazaEstaEnCadena2(ByVal pIdOrdenDePres As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdOrdenDePres", SqlDbType.Int)}

                Prms(0).Value = pIdOrdenDePres

                Return _DataCOBAEV.RunProc("SP_SCadenasPlazas", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfOrdDePresDePlaza(ByVal pIdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}

                Prms(0).Value = pIdPlaza

                Return _DataCOBAEV.RunProc("SP_SNumOrdPresDePlaza", Prms, DataCOBAEV.Tipoconsulta.DataRow, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenAbiertasPorUsr(ByVal pLogin As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                               New SqlParameter("@Administrador", SqlDbType.Bit)}
                Dim oUsr As New Usuario
                Dim drUsr, drRol As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)
                oUsr.Login = pLogin
                drRol = oUsr.ObtenerPropiedadesDelRol().Rows(0)

                Prms(0).Value = CShort(drUsr("IdUsuario"))
                Prms(1).Value = CBool(drRol("Administrador"))

                Return _DataCOBAEV.RunProc("SP_SCadenasAbiertasParaCaptura", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ActualizaInf(ByVal pIdCadena As Integer, ByVal pFchParaOrdDePres As String, ByVal pOficioDePropuesta As String, ByVal pLogin As String, _
        ByVal pIdEstatusCadena As Byte, ByVal pIdOrigenPropuesta As Byte, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCadena", SqlDbType.SmallInt), _
                                            New SqlParameter("@FchParaOrdDePres", SqlDbType.DateTime), _
                                            New SqlParameter("@OficioDePropuesta", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdEstatusCadena", SqlDbType.TinyInt), _
                                            New SqlParameter("@IdOrigenPropuesta", SqlDbType.TinyInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)

                Prms(0).Value = pIdCadena
                Prms(1).Value = IIf(pFchParaOrdDePres.Trim = String.Empty, DBNull.Value, pFchParaOrdDePres.Trim)
                Prms(2).Value = pOficioDePropuesta
                Prms(3).Value = CShort(drUsr("IdUsuario"))
                Prms(4).Value = pIdEstatusCadena
                Prms(5).Value = pIdOrigenPropuesta

                Return _DataCOBAEV.RunProc("SP_UCadena", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPosiblesEstatus() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEstatusCadenas", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorEjercUsr(ByVal pLogin As String, ByVal pEjercicio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                               New SqlParameter("@Ejercicio", SqlDbType.SmallInt), _
                                               New SqlParameter("@Administrador", SqlDbType.Bit)}
                Dim oUsr As New Usuario
                Dim drUsr, drRol As DataRow

                drUsr = oUsr.ObtenerPorLogin(pLogin)
                oUsr.Login = pLogin
                drRol = oUsr.ObtenerPropiedadesDelRol().Rows(0)

                Prms(0).Value = CShort(drUsr("IdUsuario"))
                Prms(1).Value = pEjercicio
                Prms(2).Value = CBool(drRol("Administrador"))

                Return _DataCOBAEV.RunProc("SP_SCadenas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function CreaNueva(ByVal pIdUsuario As Short, ByVal ArregloAuditoria() As String) As String
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumCadena", SqlDbType.NVarChar, 6), _
                                            New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}

                Prms(0).Direction = ParameterDirection.Output
                Prms(1).Value = pIdUsuario

                _DataCOBAEV.RunProc("SP_ICadena", Prms, DataCOBAEV.BD.Nomina, ArregloAuditoria)

                Return Prms(1).Value

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
    Public Class OrigenPropuestas
#Region "Clase OrigenPropuestas: Propiedades públicas"
#End Region
#Region "Clase OrigenPropuestas: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase OrigenPropuestas: Métodos públicos"
        Public Function ObtenOrigenPropuestas() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SOrigenPropuestas", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace
