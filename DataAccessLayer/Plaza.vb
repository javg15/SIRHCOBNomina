Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Plazas
#Region "Clase TipoOcupacion"
    Public Class TipoOcupacion
#Region "Clase TipoOcupacion: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase TipoOcupacion: Métodos públicos"
        Public Function ObtenTodos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SPlazasTipoOcupacion", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsInterina(ByVal IdNombramiento As Byte, ByVal NobramientoPlaza As Boolean) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdNombramiento", SqlDbType.TinyInt), _
                                            New SqlParameter("@NobramientoPlaza", SqlDbType.Bit)}

                Prms(0).Value = IdNombramiento
                Prms(1).Value = NobramientoPlaza

                Return _DataCOBAEV.RunProc("SP_VSiNombramientoEsInterino", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsProvisional(ByVal IdNombramiento As Byte, ByVal NobramientoPlaza As Boolean) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdNombramiento", SqlDbType.TinyInt), _
                                            New SqlParameter("@NobramientoPlaza", SqlDbType.Bit)}

                Prms(0).Value = IdNombramiento
                Prms(1).Value = NobramientoPlaza

                Return _DataCOBAEV.RunProc("SP_VSiNombramientoEsProvisional", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsBase(ByVal IdNombramiento As Byte, ByVal NobramientoPlaza As Boolean) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdNombramiento", SqlDbType.TinyInt), _
                                            New SqlParameter("@NobramientoPlaza", SqlDbType.Bit)}

                Prms(0).Value = IdNombramiento
                Prms(1).Value = NobramientoPlaza

                Return _DataCOBAEV.RunProc("SP_VSiNombramientoEsBase", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenMotivosInterinatos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SMotivosHorasInterinas", DataCOBAEV.Tipoconsulta.Table, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenSiCategoAsocEsDocHomooAdmva(ByVal pIdPlaza As Integer) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlaza", SqlDbType.Int)}
                Prms(0).Value = pIdPlaza
                Return _DataCOBAEV.RunProc("SP_SCategoriaEsHomologada", Prms, DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

#Region "Clase SMP_Plazas"
    Public Class SMP_Plazas
#Region "Clase SMP_Plazas: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase SMP_Plazas: Métodos públicos"
        Public Function ObtenPlazaDetalles(ByVal pZonaEco As String, ByVal pCveCategoCOBACH As String, _
                                                   pConsecutivo As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ZonaEco", SqlDbType.NVarChar, 3), _
                                              New SqlParameter("@CveCategoCOBACH", SqlDbType.NVarChar, 4), _
                                              New SqlParameter("@Consecutivo", SqlDbType.NVarChar, 5)}

                Prms(0).Value = pZonaEco
                Prms(1).Value = pCveCategoCOBACH
                Prms(2).Value = pConsecutivo

                Return _DataCOBAEV.RunProc("SP_SSMP_ConsultaPlaza", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazaDetalles(ByVal pZonaEco As String, ByVal pCveCategoCOBACH As String, _
                                           ByVal pHrsJornada As Decimal, pConsecutivo As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ZonaEco", SqlDbType.NVarChar, 3), _
                                              New SqlParameter("@CveCategoCOBACH", SqlDbType.NVarChar, 4), _
                                              New SqlParameter("@HrsJornada", SqlDbType.Float), _
                                              New SqlParameter("@Consecutivo", SqlDbType.NVarChar, 5)}

                Prms(0).Value = pZonaEco
                Prms(1).Value = pCveCategoCOBACH
                Prms(2).Value = pHrsJornada
                Prms(3).Value = pConsecutivo

                Return _DataCOBAEV.RunProc("SP_SSMP_ConsultaPlaza", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTipos() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SSMP_PlazasTipo", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfDeCvePlazaTipo(ByVal pCvePlazaTipo As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CvePlazaTipo", SqlDbType.NVarChar, 4)}

                Prms(0).Value = pCvePlazaTipo

                Return _DataCOBAEV.RunProc("SP_SSMP_PlazasTipo", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTipificaciones() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SEmpsFuncsParaTipificarCategos", DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazasPorZETipoFuncion(ByVal pZonaEco As String, ByVal pCvePlazaTipo As String, _
                                                    ByVal pIdEmpFuncion As Byte, ByVal pOrdenarPor As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ZonaEco", SqlDbType.NVarChar, 3), _
                                              New SqlParameter("@CvePlazaTipo", SqlDbType.NVarChar, 4), _
                                              New SqlParameter("@IdEmpFuncion", SqlDbType.TinyInt), _
                                              New SqlParameter("@OrdenarPor", SqlDbType.NVarChar, 10)}

                Prms(0).Value = pZonaEco
                Prms(1).Value = pCvePlazaTipo
                Prms(2).Value = pIdEmpFuncion
                Prms(3).Value = pOrdenarPor

                Return _DataCOBAEV.RunProc("SP_SSMP_PlazasPorZETipoFuncion", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDetalleCategoria(ByVal pZonaEco As String, ByVal pCvePlazaTipo As String, _
                                                    ByVal pCveCategoCOBACH As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ZonaEco", SqlDbType.NVarChar, 3), _
                                              New SqlParameter("@CvePlazaTipo", SqlDbType.NVarChar, 4), _
                                              New SqlParameter("@CveCategoCOBACH", SqlDbType.NVarChar, 4)}

                Prms(0).Value = pZonaEco
                Prms(1).Value = pCvePlazaTipo
                Prms(2).Value = pCveCategoCOBACH

                Return _DataCOBAEV.RunProc("SP_SSMP_DetalleCategoria", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDetallePlaza(ByVal pIdPlantel As Short, ByVal pZonaEco As String, ByVal pCvePlazaTipo As String, _
                                                    ByVal pCveCategoCOBACH As String, ByVal pHrsJornada As Decimal, _
                                                    ByVal pConsecutivo As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {
                                                New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                                New SqlParameter("@ZonaEco", SqlDbType.NVarChar, 3), _
                                                New SqlParameter("@CvePlazaTipo", SqlDbType.NVarChar, 4), _
                                                New SqlParameter("@CveCategoCOBACH", SqlDbType.NVarChar, 4), _
                                                New SqlParameter("@HrsJornada", SqlDbType.Float), _
                                                New SqlParameter("@Consecutivo", SqlDbType.NVarChar, 5)
                                              }

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pZonaEco
                Prms(2).Value = pCvePlazaTipo
                Prms(3).Value = pCveCategoCOBACH
                Prms(4).Value = pHrsJornada
                Prms(5).Value = pConsecutivo

                Return _DataCOBAEV.RunProc("SP_SSMP_PlazaDetalles", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDetallePlaza(ByVal pZonaEco As String, ByVal pCvePlazaTipo As String, _
                                                            ByVal pCveCategoCOBACH As String,
                                                            ByVal pConsecutivo As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {
                                                New SqlParameter("@ZonaEco", SqlDbType.NVarChar, 3), _
                                                New SqlParameter("@CvePlazaTipo", SqlDbType.NVarChar, 4), _
                                                New SqlParameter("@CveCategoCOBACH", SqlDbType.NVarChar, 4), _
                                                New SqlParameter("@Consecutivo", SqlDbType.NVarChar, 5)
                                              }

                Prms(0).Value = pZonaEco
                Prms(1).Value = pCvePlazaTipo
                Prms(2).Value = pCveCategoCOBACH
                Prms(3).Value = pConsecutivo

                Return _DataCOBAEV.RunProc("SP_SSMP_PlazaDetalles", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCamposQueLaConforman(ByVal pIdCategoria As Short, ByVal pIdPlantelAdscripReal As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {
                                                New SqlParameter("@IdCategoria", SqlDbType.SmallInt),
                                                New SqlParameter("@IdPlantelAdscripReal", SqlDbType.SmallInt)
                                              }

                Prms(0).Value = pIdCategoria
                Prms(1).Value = pIdPlantelAdscripReal

                Return _DataCOBAEV.RunProc("SP_SSMP_DatosParaClaveDePlaza", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDetallesPlazaPorZEyPlazaTipoyCveCatego(ByVal pZonaEco As String, ByVal pCvePlazaTipo As String, _
                                                    ByVal pCveCategoCOBACH As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {
                                                New SqlParameter("@ZonaEco", SqlDbType.NVarChar, 3), _
                                                New SqlParameter("@CvePlazaTipo", SqlDbType.NVarChar, 4), _
                                                New SqlParameter("@CveCategoCOBACH", SqlDbType.NVarChar, 4)
                                              }

                Prms(0).Value = pZonaEco
                Prms(1).Value = pCvePlazaTipo
                Prms(2).Value = pCveCategoCOBACH

                Return _DataCOBAEV.RunProc("SP_SSMP_PlazaPorZEyPlazaTipoyCveCatego", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlazaBasePorEmp(ByVal pRFCEmp As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {
                                                New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)
                                              }

                Prms(0).Value = pRFCEmp

                Return _DataCOBAEV.RunProc("SP_SSMP_PlazaBasePorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCategosXCvePlazaTipoYZonaEco(ByVal pCvePlazaTipo As String, ByVal pZonaEco As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CvePlazaTipo", SqlDbType.NVarChar, 4), _
                                              New SqlParameter("@ZonaEco", SqlDbType.NVarChar, 3)}

                Prms(0).Value = pCvePlazaTipo
                Prms(1).Value = pZonaEco

                Return _DataCOBAEV.RunProc("SP_SSMP_CategosXCvePlazaTipoYZonaEco", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenCategosXCvePlazaTipoYZonaEcoParaMovDePers(ByVal pCvePlazaTipo As String, ByVal pZonaEco As String, _
                                                                       ByVal pstrIdEmpFuncion As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CvePlazaTipo", SqlDbType.NVarChar, 4), _
                                              New SqlParameter("@ZonaEco", SqlDbType.NVarChar, 3), _
                                              New SqlParameter("@strIdEmpFuncion", SqlDbType.NVarChar, 10)}
                Dim dt As DataTable

                Prms(0).Value = pCvePlazaTipo
                Prms(1).Value = pZonaEco
                Prms(2).Value = pstrIdEmpFuncion

                dt = _DataCOBAEV.RunProc("SP_SSMP_CategosXCvePlazaTipoYZonaEco", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

                Return dt

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region

End Namespace