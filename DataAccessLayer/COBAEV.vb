Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV
#Region "Clase CiclosEscolares"
    Public Class CiclosEscolares
#Region "Clase CiclosEscolares: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase CiclosEscolares: Métodos públicos"
        Public Function ObtenCiclosEscolares() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SCiclosEscolares", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

#Region "Clase Calendario"
    Public Class CalendarioLaboral
#Region "Clase Calendario: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Calendario: Métodos públicos"
        Public Function ObtenPeriodosNoLaborables() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SPeriodosNoLaborablesPorAnio", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPeriodosNoLaborables(ByVal pAnio As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@Anio", SqlDbType.SmallInt)}

                Prms(0).Value = pAnio

                Return _DataCOBAEV.RunProc("SP_SPeriodosNoLaborablesPorAnio", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace