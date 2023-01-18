Imports DataAccessLayer.COBAEV.DataCOBAEV.BD
Imports DataAccessLayer.COBAEV.DataCOBAEV.Tipoconsulta
Imports System.Data.SqlClient
Imports System.Configuration
Namespace COBAEV.Empleados
#Region "Clase Expediente"
    Public Class Expediente
#Region "Clase Bancos: Propiedades privadas"
        Private _DataCOBAEV As New DataCOBAEV
        Private _CveDoc As String
#End Region
#Region "Clase Expediente: Propiedades públicas"
        Public Property CveDoc() As String
            Get
                Return Me._CveDoc
            End Get
            Set(ByVal value As String)
                Me._CveDoc = value
            End Set
        End Property
#End Region
#Region "Clase Expediente: Métodos públicos"
        Public Function InsertaNombresDeArchivos(ByVal pNombreArchivo As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NombreArchivo", SqlDbType.NVarChar, 50)}

                Prms(0).Value = pNombreArchivo

                Return _DataCOBAEV.RunProc("SP_INombresDeArchivos", Prms, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function

        Public Function InsertaEmpsDocs(ByVal StrDocs As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@StrDocs", SqlDbType.NVarChar, 4000)}

                Prms(0).Value = StrDocs

                Return _DataCOBAEV.RunProc("SP_IoUEmpsDocs", Prms, Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function EliminaEmpsDocs(ByVal NumEmp As String, ByVal CveDoc As String, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@NumEmp", SqlDbType.NVarChar, 5), _
                                                New SqlParameter("@CveDoc", SqlDbType.NVarChar, 4)}

                Prms(0).Value = NumEmp
                Prms(1).Value = CveDoc

                Return _DataCOBAEV.RunProc("SP_DEmpsDocs", Prms, Nomina, ArregloAuditoria)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfSobreDocumento2(ByVal CveDoc As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CveDoc", SqlDbType.NVarChar, 4)}

                Prms(0).Value = CveDoc

                Return _DataCOBAEV.RunProc("SP_SInfDeDocDeExp2", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenInfSobreDocumento(ByVal CveDoc As String) As DataRow
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CveDoc", SqlDbType.NVarChar, 4)}

                Prms(0).Value = CveDoc

                Return _DataCOBAEV.RunProc("SP_SInfDeDocDeExp", Prms, DataCOBAEV.Tipoconsulta.DataRow, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenDifTiposDeDocs() As DataTable
            Try
                Return _DataCOBAEV.RunProc("SP_SDocsParaExpedientes", DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
        Public Function ObtenNumHojasDeDocumento(ByVal CveDoctRangoIni As String) As DataTable
            Try
                Dim Prms As SqlParameter() = {New SqlParameter("@CveDoctRangoIni", SqlDbType.NVarChar, 4)}

                Prms(0).Value = CveDoctRangoIni

                Return _DataCOBAEV.RunProc("SP_SNumPagsParaDocsDeExpedientes", Prms, DataCOBAEV.Tipoconsulta.Table, Nomina)

            Catch ex As Exception
                Throw (New System.Exception(ex.Message.ToString))
            End Try
        End Function
#End Region
    End Class
#End Region
End Namespace
