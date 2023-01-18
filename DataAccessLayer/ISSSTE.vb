Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV
#Region "Clase ISSSTE"
    Public Class ISSSTE
#Region "Clase ISSSTE: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdRegimenISSSTE As Byte
#End Region
#Region "Clase ISSSTE: Propiedades públicas"
        Public Property IdRegimenISSSTE() As Byte
            Get
                Return Me._IdRegimenISSSTE
            End Get
            Set(ByVal value As Byte)
                Me._IdRegimenISSSTE = value
            End Set
        End Property
#End Region
#Region "Clase ISSSTE: Métodos públicos"
        Public Function GeneraTXTSERICANOMINAS(ByVal pIdQuincena As Short, ByVal pIdTipoArchivo As Byte, ByVal pIdPrestamo As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdTipoArchivo", SqlDbType.TinyInt), _
                                              New SqlParameter("@IdPrestamo", SqlDbType.TinyInt)}
                Prms(0).Value = pIdQuincena
                Prms(1).Value = pIdTipoArchivo
                Prms(2).Value = pIdPrestamo

                Return _DataCOBAEV.RunProc("SP_SPersonalConISSSTE_Nominas", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SRegimenesISSSTE", DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTAltas(ByVal IdQuincena As Short, ByVal IdRegimenISSSTE1 As Byte, ByVal IdRegimenISSSTE2 As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRegimenISSSTE1", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdRegimenISSSTE2", SqlDbType.TinyInt)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdRegimenISSSTE1
                Prms(2).Value = IdRegimenISSSTE2

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTAltasISSSTE", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTBajas(ByVal IdQuincena As Short, ByVal IdRegimenISSSTE1 As Byte, ByVal IdRegimenISSSTE2 As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRegimenISSSTE1", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdRegimenISSSTE2", SqlDbType.TinyInt)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdRegimenISSSTE1
                Prms(2).Value = IdRegimenISSSTE2

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTBajasISSSTE", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTBajas(ByVal IdQuincena As Short, ByVal IdRegimenISSSTE1 As Byte, ByVal IdRegimenISSSTE2 As Byte, pConNumEmp As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRegimenISSSTE1", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdRegimenISSSTE2", SqlDbType.TinyInt), _
                                              New SqlParameter("@ConNumEmp", SqlDbType.Bit)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdRegimenISSSTE1
                Prms(2).Value = IdRegimenISSSTE2
                Prms(3).Value = pConNumEmp

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTBajasISSSTE", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function GeneraTXTModSal(ByVal IdQuincena As Short, ByVal IdRegimenISSSTE1 As Byte, ByVal IdRegimenISSSTE2 As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRegimenISSSTE1", SqlDbType.TinyInt), _
                                                New SqlParameter("@IdRegimenISSSTE2", SqlDbType.TinyInt)}
                Prms(0).Value = IdQuincena
                Prms(1).Value = IdRegimenISSSTE1
                Prms(2).Value = IdRegimenISSSTE2

                Return _DataCOBAEV.RunProc("SP_SGeneraTXTModSalISSSTE", Prms, DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace
