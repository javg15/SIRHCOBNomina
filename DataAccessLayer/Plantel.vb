Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV
#Region "Clase Plantel"
    Public Class Plantel
#Region "Clase Plantel: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
#End Region
#Region "Clase Plantel: Métodos públicos"
        Public Function ObtenInfParaCrearGrupo(pClaveCTSE As String, pIdSemestre As Short, pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ClaveCTSE", SqlDbType.NVarChar, 12), _
                                              New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pClaveCTSE
                Prms(1).Value = IIf(pIdSemestre = 0, DBNull.Value, pIdSemestre)
                Prms(2).Value = IIf(pIdQuincena = 0, DBNull.Value, pIdQuincena)

                Return _DataCOBAEV.RunProc("SP_SPlantelInfParaCrearGrupo", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenGruposPorSemestreQna(ByVal pIdSemestre As Short, ByVal pIdQuincena As Short, ByVal pClaveCTSE As String) As DataSet
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdSemestre", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                              New SqlParameter("@ClaveCTSE", SqlDbType.NVarChar, 12)}

                Prms(0).Value = pIdSemestre
                Prms(1).Value = pIdQuincena
                Prms(2).Value = pClaveCTSE

                Return _DataCOBAEV.RunProc("SP_SGruposPlantelPorSemQna", Prms, "dsGruposPlantelPorSemQna", Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenVigentes() As DataTable
            Try

                Return _DataCOBAEV.RunProc("SP_SPlantelesVigentes", DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenVigentesPorQna(ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SPlantelesVigentesPorQna", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenVigentesPorQna(ByVal pIdQuincena As Short, ByVal pParaPensionAlim As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdQuincena", SqlDbType.SmallInt), _
                                                New SqlParameter("@ParaPensionAlim", SqlDbType.Bit)}

                Prms(0).Value = pIdQuincena
                Prms(1).Value = pParaPensionAlim

                Return _DataCOBAEV.RunProc("SP_SPlantelesVigentesPorQna", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorTipoNomina(pIdPlantel As Short, pAbrevTipoNomina As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@AbrevTipoNomina", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pAbrevTipoNomina

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorTipoNomina(pIdPlantel As Short, pAbrevTipoNomina As String, pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@AbrevTipoNomina", SqlDbType.NVarChar, 2), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pAbrevTipoNomina
                Prms(2).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorNombramiento(pIdPlantel As Short, pAbrevNombramiento As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@AbrevNombramiento", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pAbrevNombramiento

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorNombramiento(pIdPlantel As Short, pAbrevNombramiento As String, pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@AbrevNombramiento", SqlDbType.NVarChar, 2), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pAbrevNombramiento
                Prms(2).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorEstatusHora(pIdPlantel As Short, pAbrevEstatus As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@AbrevEstatus", SqlDbType.NVarChar, 2)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pAbrevEstatus

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorEstatusHora(pIdPlantel As Short, pAbrevEstatus As String, pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@AbrevEstatus", SqlDbType.NVarChar, 2), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pAbrevEstatus
                Prms(2).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorTipoDeHora(pIdPlantel As Short, pTipoHora As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@TipoHora", SqlDbType.NVarChar, 1)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pTipoHora

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorTipoDeHora(pIdPlantel As Short, pTipoHora As String, pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@TipoHora", SqlDbType.NVarChar, 1), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pTipoHora
                Prms(2).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorMateria(pIdPlantel As Short, pIdMateria As Short, pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMateria", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pIdMateria
                Prms(2).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorMateria(pIdPlantel As Short, pIdMateria As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMateria", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pIdMateria

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenEmpsPorMateria2(pIdPlantel As Short, pIdMateria As Short, pIdSemestre As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdMateria", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdSemestre", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pIdMateria
                Prms(2).Value = pIdSemestre

                Return _DataCOBAEV.RunProc("SP_SMateriaEnPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenMaterias(pIdHora As Integer, pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdHora", SqlDbType.Int),
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdHora
                Prms(1).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SMateriasPorPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenMaterias(pIdPlantel As Short, pIdGrupo As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                                              New SqlParameter("@IdGrupo", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pIdGrupo

                Return _DataCOBAEV.RunProc("SP_SMateriasPorPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Overloads Function ObtenMaterias(pIdPlantel As Short, pIdGrupo As Short, pIdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt),
                                              New SqlParameter("@IdGrupo", SqlDbType.SmallInt),
                                              New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pIdGrupo
                Prms(2).Value = pIdQuincena

                Return _DataCOBAEV.RunProc("SP_SMateriasPorPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlantelesPorUsr2(ByVal Login As String, ByVal pPermisoVerTodosLosPlanteles As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                                New SqlParameter("@PermisoVerTodosLosPlanteles", SqlDbType.Bit)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = CShort(drUsr("IdUsuario"))
                Prms(1).Value = CBool(drUsr("PermisoVerTodosLosPlanteles"))

                Return _DataCOBAEV.RunProc("SP_SPlantelesPorUsr", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlantelesPorUsr(ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SPlantelesPorUsr", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPlanteles() As DataTable
            Try
                Dim dt As DataTable

                dt = _DataCOBAEV.RunProc("SP_SSoloPlanteles", DataCOBAEV.Tipoconsulta.Table, Nomina)

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenHistoriaRespAdmvosAcad(ByVal pIdPlantel As Short, ByVal pIdFuncionSec As Byte) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdFuncionSec", SqlDbType.TinyInt)}

                Prms(0).Value = pIdPlantel
                Prms(1).Value = pIdFuncionSec

                dt = _DataCOBAEV.RunProc("SP_SHistRespAdmvosAcadPorPlantel", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodos(ByVal IdPlantel As Short, ByVal ParaDDL As Boolean) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt), _
                                            New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                Prms(0).Value = IdPlantel
                Prms(1).Value = ParaDDL

                dt = _DataCOBAEV.RunProc("SP_SPlanteles", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodos(Optional ByVal ParaDDL As Boolean = False) As DataTable
            Try
                Dim dt As DataTable
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit)}

                If ParaDDL Then
                    Prms(0).Value = ParaDDL
                    dt = _DataCOBAEV.RunProc("SP_SPlanteles", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)
                Else
                    dt = _DataCOBAEV.RunProc("SP_SPlanteles", DataCOBAEV.Tipoconsulta.Table, Nomina)
                End If

                Return dt
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorTipoDeNomina(ByVal pIdTipoNomina As Byte) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdTipoNomina", SqlDbType.TinyInt)}


                Prms(0).Value = pIdTipoNomina
                Return _DataCOBAEV.RunProc("SP_SPlantelesPorTipoNomina", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenTodos(ByVal pOrdenarPor As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@OrdenarPor", SqlDbType.NVarChar, 10)}

                Prms(0).Value = pOrdenarPor
                Return _DataCOBAEV.RunProc("SP_SPlanteles2", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenParaPago(ByVal RFC As String, ByVal IdBeneficiario As Short, ByVal IdQnaIni As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@ParaDDL", SqlDbType.Bit), _
                                            New SqlParameter("@RFC", SqlDbType.NVarChar, 13), _
                                            New SqlParameter("@IdBeneficiario", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdQnaIni", SqlDbType.SmallInt)}

                Prms(0).Value = True
                Prms(1).Value = IIf(RFC.Trim = String.Empty, DBNull.Value, RFC)
                Prms(2).Value = IIf(IdBeneficiario = 0, DBNull.Value, IdBeneficiario)
                Prms(3).Value = IdQnaIni
                Return _DataCOBAEV.RunProc("SP_SPlanteles", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaPagoPorEmp(ByVal IdEmp As Integer) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdEmp", SqlDbType.Int)}

                Prms(0).Value = IdEmp

                Return _DataCOBAEV.RunProc("SP_SPlantelesParaPagoPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaPagoPorEmpPorRFC(ByVal RFC As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@RFCEmp", SqlDbType.NVarChar, 13)}

                Prms(0).Value = RFC

                Return _DataCOBAEV.RunProc("SP_SPlantelesParaPagoPorEmp", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorUsuario(ByVal pLogin As String) As DataTable
            Try
                Dim oUsr As New Usuario
                Dim drUsr, drRol As DataRow
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                              New SqlParameter("@IdRol", SqlDbType.TinyInt), _
                                              New SqlParameter("@ConsultaZonasEspecificas", SqlDbType.Bit), _
                                              New SqlParameter("@ConsultaPlantelesEspecificos", SqlDbType.Bit), _
                                              New SqlParameter("@Administrador", SqlDbType.Bit)}

                drUsr = oUsr.ObtenerPorLogin(pLogin)
                oUsr.Login = pLogin
                drRol = oUsr.ObtenerPropiedadesDelRol().Rows(0)

                Prms(0).Value = CShort(drUsr("IdUsuario"))
                Prms(1).Value = CByte(drUsr("IdRol"))
                Prms(2).Value = CBool(drRol("ConsultaZonasEspecificas"))
                Prms(3).Value = CBool(drRol("ConsultaPlantelesEspecificos"))
                Prms(4).Value = CBool(drRol("Administrador"))

                Return _DataCOBAEV.RunProc("SP_SPlantelesPorUsr2", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function ObtenParaImpDePensionAlimPorUsr(ByVal Login As String, ByVal IdQuincena As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                            New SqlParameter("@PensionAlimenticia", SqlDbType.Bit), _
                                            New SqlParameter("@IdQuincena", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = CShort(drUsr("IdUsuario"))
                Prms(1).Value = True
                Prms(2).Value = IdQuincena

                Return _DataCOBAEV.RunProc("SP_SPlantelesParaPagoPorUsr", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaPagoPorUsr2(ByVal Login As String, ByVal pPermisoVerTodosLosPlanteles As Boolean) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                              New SqlParameter("@PermisoVerTodosLosPlanteles", SqlDbType.Bit)}

                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = CShort(drUsr("IdUsuario"))
                Prms(1).Value = CBool(drUsr("PermisoVerTodosLosPlanteles"))

                Return _DataCOBAEV.RunProc("SP_SPlantelesParaPagoPorUsr", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenParaPagoPorUsr(ByVal Login As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt)}
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                oUsr.Login = Login
                drUsr = oUsr.ObtenerPorLogin()

                Prms(0).Value = CShort(drUsr("IdUsuario"))

                Return _DataCOBAEV.RunProc("SP_SPlantelesParaPagoPorUsr", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenPorId(ByVal IdPlantel As Short) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdPlantel", SqlDbType.SmallInt)}

                Prms(0).Value = IdPlantel
                Return _DataCOBAEV.RunProc("SP_SPlanteles", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EsVisibleParaUsr(ByVal pIdUsuario As Short, ByVal pIdPlantel As Short) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@IdUsuario", SqlDbType.SmallInt), _
                                            New SqlParameter("@IdPlantel", SqlDbType.SmallInt)}

                Prms(0).Value = pIdUsuario
                Prms(1).Value = pIdPlantel

                Return _DataCOBAEV.RunProc("SP_VSiPlantelEsDeZGDelUsr", Prms, DataCOBAEV.BD.Nomina)
            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace