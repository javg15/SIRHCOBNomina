Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV
#Region "Clase TipoDeNomina"
    Public Class TipoDeNomina
#Region "Clase TipoDeNomina: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase TipoDeNomina: Métodos públicos"
        Public Function ObtenParacargaHoraria() As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit), _
                                              New SqlParameter("@ParaCargaHoraria", SqlDbType.Bit)}

                Prms(0).Value = True
                Prms(1).Value = True
                dt = _DataCOBAEV.RunProc("SP_STiposDeNominas", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTipoPorAbrev(pAbrevTipoNomina As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@AbrevTipoNomina", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pAbrevTipoNomina
                Return _DataCOBAEV.RunProc("SP_STiposDeNominas", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodas(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                If ParaDDL Then
                    Prms(0).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_STiposDeNominas", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_STiposDeNominas", DataCOBAEV.Tipoconsulta.Table, Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorCategoria(ByVal IdCategoria As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt)}

                Prms(0).Value = IdCategoria
                Return _DataCOBAEV.RunProc("SP_STiposDeNominasPorCategoria", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaAsigDePlaza() As DataTable
            Try
                'Dim Prms As SqlParameter() = {New SqlParameter("@IdCategoria", SqlDbType.SmallInt)}

                Return _DataCOBAEV.RunProc("SP_STiposDeNominasParaAsigDePlaza", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace