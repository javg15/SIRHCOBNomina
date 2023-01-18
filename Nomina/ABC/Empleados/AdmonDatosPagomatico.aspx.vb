Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class AdmonDatosPagomatico
    Inherits System.Web.UI.Page
    Private Sub AplicaValidaciones()
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        Dim ddlBancos As DropDownList = CType(Me.dvDatosLab.FindControl("ddlBancos"), DropDownList)
        Dim tbCuentaBancaria As TextBox = CType(Me.dvDatosLab.FindControl("tbCuentaBancaria"), TextBox)

        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            .IdEmp = CType(Request.Params("IdEmp"), Integer)
            .IdBanco = CByte(ddlBancos.SelectedValue)
            .CuentaBancaria = tbCuentaBancaria.Text.Trim
            .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
            If Not .ValidaPaginasOperacion(dsValida, False) Then
                Session.Add("dsValida", dsValida)
                Response.Redirect("~/ErroresPagina2.aspx")
            Else
                Session.Remove("dsValida")
            End If
        End With
    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado

        Dim btnCancelar As Button
        Dim strPostbackURL As String

        btnCancelar = CType(dvDatosLab.FindControl("btnCancelar"), Button)

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

        oEmp.RFC = String.Empty
        oEmp.IdEmp = CType(Request.Params("IdEmp"), Integer)
        Me.dvDatosLab.DataSource = oEmp.ObtenDatosLaboralesPorIdEmp
        Me.dvDatosLab.DataBind()

        btnCancelar = CType(dvDatosLab.FindControl("btnCancelar"), Button)
        btnCancelar.PostBackUrl = strPostbackURL
        lbOtraOperacion0.PostBackUrl = strPostbackURL
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim btnCancelar As Button
            Response.Expires = 0

            Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
            Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

            BtnNewSearch.Visible = False
            BtnCancelSearch.Visible = False
            BtnSearch.Visible = False

            If Request.Params("TipoOperacion") = "0" Then
                Me.MultiView1.SetActiveView(Me.viewEdit)
                BindDatos()
                btnCancelar = CType(dvDatosLab.FindControl("btnCancelar"), Button)

                If Session("URLAnt") Is Nothing = False Then
                    If Session("URLAnt").ToString.Contains(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString) Then
                        btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                        lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                    Else
                        btnCancelar.PostBackUrl = "~/" + Session("URLAnt")
                        lbOtraOperacion0.PostBackUrl = "~/" + Session("URLAnt")
                    End If
                Else
                    btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                    lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                End If

            ElseIf Request.Params("TipoOperacion") = "1" Then

            End If
        End If
    End Sub

    Protected Sub btnGurdar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            AplicaValidaciones()

            Dim ddlBancos As DropDownList = CType(Me.dvDatosLab.FindControl("ddlBancos"), DropDownList)
            Dim tbCuentaBancaria As TextBox = CType(Me.dvDatosLab.FindControl("tbCuentaBancaria"), TextBox)
            Dim chbIncluirEnPagomatico As CheckBox = CType(Me.dvDatosLab.FindControl("chbIncluirEnPagomatico"), CheckBox)
            Dim oEmpleado As New Empleado
            With oEmpleado
                .IdEmp = CType(Request.Params("IdEmp"), Integer)
                .IdBanco = CByte(ddlBancos.SelectedValue)
                .CuentaBancaria = tbCuentaBancaria.Text.Trim
                .IncluirEnPagomatico = chbIncluirEnPagomatico.Checked
                .ActualizarDatosPagomatico(CByte(Request.Params("TipoOperacion")), CType(Session("ArregloAuditoria"), String()))
            End With
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub dvDatosLab_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvDatosLab.DataBound
        Dim ddlBancos As DropDownList
        Dim lblIdBanco As Label
        Dim oBanco As New Bancos
        Dim dt As DataTable

        lblIdBanco = CType(Me.dvDatosLab.FindControl("lblIdBanco"), Label)
        ddlBancos = CType(Me.dvDatosLab.FindControl("ddlBancos"), DropDownList)

        dt = oBanco.ObtenTodos()
        With ddlBancos
            .DataSource = dt
            .DataTextField = "NombreCortoBanco"
            .DataValueField = "IdBanco"
            .DataBind()
            .SelectedValue = lblIdBanco.Text
        End With
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        MultiView1.SetActiveView(viewEdit)
        BindDatos()
    End Sub

    Protected Sub lbReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles lbReintentarCaptura.Click
        MultiView1.SetActiveView(viewEdit)
    End Sub
End Class
