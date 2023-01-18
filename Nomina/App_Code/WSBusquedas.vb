Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections.Generic
Imports System.Web.Script.Services
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Mexico.Estados.Municipios.Localidades
Imports Microsoft.VisualBasic

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ScriptService()> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WSBusquedas
    Inherits System.Web.Services.WebService
    <WebMethod()> _
Public Function BuscarColonias(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim ListaColonias As String = String.Empty

        Dim dt As DataTable
        Dim oLocalidad As New Localidad

        dt = oLocalidad.BuscarColonias(prefixText)

        For Each dr As DataRow In dt.Rows
            ListaColonias += dr("NomColDom") & vbLf
        Next

        Return ListaColonias.Split(vbLf)
    End Function

    <WebMethod()> _
    Public Function BuscarCalles(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim ListaCalles As String = String.Empty

        Dim dt As DataTable
        Dim oLocalidad As New Localidad

        dt = oLocalidad.BuscarCalles(prefixText)

        For Each dr As DataRow In dt.Rows
            ListaCalles += dr("CalleDom") & vbLf
        Next

        Return ListaCalles.Split(vbLf)
    End Function

    <WebMethod()> _
    Public Function BuscarApellidos(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim ListaApellidos As String = String.Empty

        Dim dt As datatable
        Dim oEmp As New Empleado

        dt = oEmp.BuscarApellidos(prefixText)

        For Each dr As DataRow In dt.Rows
            ListaApellidos += dr("Apellido") & vbLf
        Next

        Return ListaApellidos.Split(vbLf)
    End Function

    <WebMethod()> _
    Public Function BuscarNombres(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim ListaNombres As String = String.Empty

        Dim dt As DataTable
        Dim oEmp As New Empleado

        dt = oEmp.BuscarNombres(prefixText)

        For Each dr As DataRow In dt.Rows
            ListaNombres += dr("Nombre") & vbLf
        Next

        Return ListaNombres.Split(vbLf)
    End Function

End Class

