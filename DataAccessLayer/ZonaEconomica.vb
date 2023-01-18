Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV
#Region "Clase ZonaEconomica"
    Public Class ZonaEconomica
#Region "Clase Zonageografica: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdZonaEconomica As Byte
#End Region
#Region "Clase Zonageografica: Propiedades públicas"
        Public Property IdZonaEconomica() As Byte
            Get
                Return Me._IdZonaEconomica
            End Get
            Set(ByVal value As Byte)
                Me._IdZonaEconomica = value
            End Set
        End Property
#End Region
#Region "Clase Zonageografica: Métodos públicos"
        Public Function ObtenPorId(ByVal pIdZonaEco As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdZonaEco", SqlDbType.TinyInt)}

                Prms(0).Value = pIdZonaEco

                Return _DataCOBAEV.RunProc("SP_SZonaEcoXId", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodas() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SZonasEconomicas", DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodasSinComodin() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@SinComodin", SqlDbType.Bit)}

                Prms(0).Value = True

                Return _DataCOBAEV.RunProc("SP_SZonasEconomicas", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace
