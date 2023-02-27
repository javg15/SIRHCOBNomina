Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Planteles
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Nominas

Partial Class AdministracionHorarios
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Public dr As DataRow
    Private Sub AplicaValidaciones()
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet

        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            .RFC = Session("RFCParaCons")
            .IdQuincena = 0
            .AsociarInterinas = IIf(Request.Params("AsociarInterinas") Is Nothing, False, True)
            .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
            If Request.Params("TipoOperacion") <> "2" Then

            Else
                .CargaDePlantilla = True
            End If


            If Request.Params("ValidacionAlCargarPagina") Is Nothing = False Then
                If Not oValidacion.ValidaPaginasOperacion(dsValida, False) Then
                    'Session.Add("dsValida", dsValida)
                    'Response.Redirect("~/ErroresPagina2.aspx")
                    Session.Add("dsValida", dsValida)
                    Exit Sub
                Else
                    Session.Remove("dsValida")
                End If
            Else
                If Not oValidacion.ValidaPaginasOperacion(dsValida) Then
                    'Session.Add("dsValida", dsValida)
                    'Response.Redirect("~/ErroresPagina2.aspx")
                    Session.Add("dsValida", dsValida)
                Else
                    Session.Remove("dsValida")
                End If
            End If
        End With
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        Try
            ddl.DataBind()
            If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        Catch
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Remove("RFCParaCons2")
            Session.Remove("ApePatParaCons2")
            Session.Remove("ApeMatParaCons2")
            Session.Remove("NombreParaCons2")
            Session.Remove("NumEmpParaCons2")

            Me.Response.Expires = 0

            Dim oEmp As New Empleado

            oEmp.RFC = Request.Params("RFCEmp")

            Dim oHora As New Hora
            oHora.IdHora = CType(Request.Params("IdHora"), Integer)
            If Request.Params("AsociarInterinas") Is Nothing = False And Request.Params("TipoOperacion") = "0" Then
                ds = oHora.ObtenPorId(True)
            Else
                ds = oHora.ObtenPorId()
            End If


            Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
            Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

            Dim BtnNewSearchI As Button = Nothing '= CType(Me.WucBuscaEmpleados2_E.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearchI As Button = Nothing '= CType(Me.WucBuscaEmpleados2_E.FindControl("BtnCancelSearch"), Button)
            Dim BtnSearchI As Button = Nothing '= CType(Me.WucBuscaEmpleados2_E.FindControl("BtnSearch"), Button)
            Dim WucBuscaEmpleados2_E As UserControl

            BtnNewSearch.Visible = False
            BtnCancelSearch.Visible = False
            BtnSearch.Visible = False

            If Request.Params("TipoOperacion") = "1" And Request.Params("IdHora") Is Nothing Then
            ElseIf Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "1" Or Request.Params("TipoOperacion") = "4" Then
            End If


        End If
    End Sub

End Class
