Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV
#Region "Clase Bancos"
    Public Class Bancos
#Region "Clase Bancos: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdBanco As Byte
#End Region
#Region "Clase Bancos: Propiedades públicas"
        Public Property IdBanco() As Byte
            Get
                Return Me._IdBanco
            End Get
            Set(ByVal value As Byte)
                Me._IdBanco = value
            End Set
        End Property
#End Region
#Region "Clase Bancos: Métodos públicos"
        Public Function ObtenTodos(Optional ByVal pBancosParaTIB As Boolean = False) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@BancosParaTIB", SqlDbType.Bit)}

                Prms(0).Value = pBancosParaTIB

                Return _DataCOBAEV.RunProc("SP_SBancos", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCtasPagadoras(ByVal pIdBanco As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBanco", SqlDbType.TinyInt)}

                Prms(0).Value = pIdBanco

                Return _DataCOBAEV.RunProc("SP_SCtasPagadorasPorIdBanco", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal pIdBanco As Byte, Optional ByVal pBancosParaTIB As Boolean = False) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                              New SqlParameter("@BancosParaTIB", SqlDbType.Bit)}

                Prms(0).Value = pIdBanco
                Prms(1).Value = pBancosParaTIB

                Return _DataCOBAEV.RunProc("SP_SBancos", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSecuencialBANORTE(ByVal pIdBanco As Byte, ByVal pIdQuincena As Short, _
                                               ByVal pOrigen As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 5)}

                Prms(0).Value = pIdBanco
                Prms(1).Value = pIdQuincena
                Prms(2).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_SConsTXTBANORTE", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSecuencialBANORTE(ByVal pIdBanco As Byte, ByVal pAnio As Short, _
                                               ByVal pIdMesValue As String, ByVal pOrigen As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdBanco", SqlDbType.TinyInt), _
                                              New SqlParameter("@Anio", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMesValue", SqlDbType.NVarChar, 5), _
                                              New SqlParameter("@Origen", SqlDbType.NVarChar, 5)}

                Prms(0).Value = pIdBanco
                Prms(1).Value = pAnio
                Prms(2).Value = pIdMesValue
                Prms(3).Value = pOrigen

                Return _DataCOBAEV.RunProc("SP_SConsTXTBANORTE", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorNumBancoCLABE(ByVal pNumBancoCLABE As String, Optional ByVal pBancosParaTIB As Boolean = False) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumBancoCLABE", SqlDbType.NVarChar, 3), _
                                              New SqlParameter("@BancosParaTIB", SqlDbType.Bit)}

                Prms(0).Value = pNumBancoCLABE
                Prms(1).Value = pBancosParaTIB

                Return _DataCOBAEV.RunProc("SP_SBancos", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace
