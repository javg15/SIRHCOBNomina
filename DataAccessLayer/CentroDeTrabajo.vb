Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV
#Region "Clase CentroDeTrabajo"
    Public Class CentroDeTrabajo
#Region "Clase CentroDeTrabajo: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _IdCT As Short
        Private _IdTipoCT As Byte
#End Region
#Region "Clase CentroDeTrabajo: Propiedades públicas"
        Public Property IdCT() As Short
            Get
                Return Me._IdCT
            End Get
            Set(ByVal value As Short)
                Me._IdCT = value
            End Set
        End Property
        Public Property IdTipoCT() As Byte
            Get
                Return Me._IdTipoCT
            End Get
            Set(ByVal value As Byte)
                Me._IdTipoCT = value
            End Set
        End Property
#End Region
#Region "Clase CentroDeTrabajo: Métodos públicos"
        Public Function ObtenHistoriaCentrosDeAdscrip(ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SHistoriaCentrosDeAdscripcPoEmp", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenSecPorPlantelyCTPadre(ByVal pIdPlantel As Short, ByVal pIdCTPadre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                                            New SqlParameter("@IdCT", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pIdCTPadre

                Return _DataCOBAEV.RunProc("SP_SCTsSecPorPlantelyCTSec", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorPlantel(ByVal IdPlantel As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt)}
                Prms(0).Value = IdPlantel

                Return _DataCOBAEV.RunProc("SP_SCentrosDeTrabajoPorPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorPlantel(ByVal pIdPlantel As Short, pOrdenarPor As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@OrdenarPor", SqlDbType.NVarChar, 10)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pOrdenarPor

                Return _DataCOBAEV.RunProc("SP_SDeptosPorCT", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCentrosDeTrabajo() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTipoCT", SqlDbType.TinyInt)}
                Prms(0).Value = Me._IdTipoCT

                Return _DataCOBAEV.RunProc("SP_SCentrosDeTrabajo", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCTsPorTipoDeCT(ByVal pIdTipoCT As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTipoCT", SqlDbType.TinyInt)}

                Prms(0).Value = pIdTipoCT

                Return _DataCOBAEV.RunProc("SP_SCTsPorTipoDeCT", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenEmpleadosVigentes(ByVal IdRol As Byte, ByVal ConsultaZonasEspecificas As Boolean, ByVal ConsultaPlantelesEspecificos As Boolean, ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCT", SqlDbType.SmallInt), _
                                                New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                                New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                                New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                                New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow
                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()
                Prms(0).Value = _IdCT
                Prms(1).Value = IdRol
                Prms(2).Value = ConsultaZonasEspecificas
                Prms(3).Value = ConsultaPlantelesEspecificos
                Prms(4).Value = CShort(drUsr("IdUsuario"))
                Return _DataCOBAEV.RunProc("SP_SEmpleadosPorCT", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId() As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdCT", SqlDbType.SmallInt)}
                Prms(0).Value = _IdCT

                Return _DataCOBAEV.RunProc("SP_SCentrosDeTrabajo", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDiferentesTipos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_STiposCentrosDeTrabajo", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace