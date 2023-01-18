Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV
#Region "Clase Busquedas"
    Public Class Busquedas
#Region "Clase Busquedas: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Busquedas: Propiedades públicas"
#End Region
#Region "Clase Busquedas: Métodos públicos"
        Public Function ObtenTipos() As DataTable
            Return _DataCOBAEV.RunProc("SP_STiposDeBusquedas", DataCOBAEV.Tipoconsulta.Table, Nomina)
        End Function
        Public Function RealiarPor(ByVal pTipoBusqueda As String, ByVal pTextoABuscar As String, _
                                        ByVal pIdRol As Byte, ByVal pConsultaZonasEspecificas As Boolean, _
                                        ByVal pConsultaPlantelesEspecificos As Boolean, ByVal pLogin As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@TipoBusqueda", SqlDbType.NVarChar, 20), _
                                                New SqlParameter("@TextoABuscar", SqlDbType.NVarChar, 100), _
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}

                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = pLogin
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = pTipoBusqueda
                Prms(1).Value = pTextoABuscar
                Prms(2).Value = pIdRol
                Prms(3).Value = pConsultaZonasEspecificas
                Prms(4).Value = pConsultaPlantelesEspecificos
                Prms(5).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SBusquedasVarias", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace
