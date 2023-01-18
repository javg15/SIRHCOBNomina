Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV
#Region "Clase FOVISSSTE"
    Public Class FOVISSSTE
#Region "Clase FOVISSSTE: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase FOVISSSTE: Propiedades públicas"
#End Region
#Region "Clase ISSSTE: Métodos públicos"
        Public Function GeneraTXTFOVISSSTE(ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTFOVISSSTE", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTFOVISSSTEPARATODOS(ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Prms(0).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTFOVISSSTE_PARATODOS", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace
