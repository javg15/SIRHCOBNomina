Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV
#Region "Clase Zonageografica"
    Public Class Zonageografica
#Region "Clase Zonageografica: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdZonaGeografica As Byte
#End Region
#Region "Clase Zonageografica: Propiedades públicas"
        Public Property IdZonageografica() As Byte
            Get
                Return Me._IdZonaGeografica
            End Get
            Set(ByVal value As Byte)
                Me._IdZonaGeografica = value
            End Set
        End Property
#End Region
#Region "Clase Zonageografica: Métodos públicos"
        Public Function ObtenPorUsuario(ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SZonasGeograficas", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodas() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SZonasGeograficas", DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodasConAnalista() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SZonasGeoConAnalista", DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlanteles() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdZonaGeografica", SqlDbType.TinyInt)}
                Prms(0).Value = Me._IdZonaGeografica

                Return _DataCOBAEV.RunProc("SP_SPlantelesPorZonaGeografica", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlanteles(ByVal pZonaGeo As Byte, ByVal pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdZonaGeo", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = pZonaGeo
                Prms(1).Value = pIdQuincena


                Return _DataCOBAEV.RunProc("SP_SPlantelesPorZonaGeo", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlanteles(ByVal pZonaGeo As Byte, ByVal pIdQuincena As Short, ByVal pDeZonageoEnAdelante As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdZonaGeo", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                              New SqlParameter("@DeZonageoEnAdelante", SqlDbType.SmallInt)}
                Prms(0).Value = pZonaGeo
                Prms(1).Value = pIdQuincena
                Prms(2).Value = pDeZonageoEnAdelante

                Return _DataCOBAEV.RunProc("SP_SPlantelesPorZonaGeo", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace
