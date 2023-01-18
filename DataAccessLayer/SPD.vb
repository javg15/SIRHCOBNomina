Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.SPD
#Region "Clase Evaluaciones"
    Public Class Evaluaciones
#Region "Clase Evaluaciones: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Evaluaciones: Métodos públicos"
        Public Function ObtenPorEmpleado(ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SHistoriaEvaluacionesPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorCicloEscolar(ByVal pIdCicloEscolar As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCicloEsc", SqlDbType.SmallInt)}

                Prms(0).Value = pIdCicloEscolar

                Return _DataCOBAEV.RunProc("SP_SHistoriaEvaluacionesPorCicloEsc", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace