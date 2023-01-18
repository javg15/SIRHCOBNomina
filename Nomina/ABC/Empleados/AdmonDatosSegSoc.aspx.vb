Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV
Partial Class AdmonDatosSegSoc
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        oEmp.RFC = String.Empty

        Dim btnCancelar As Button
        Dim strPostbackURL As String

        btnCancelar = CType(dvDatosLab.FindControl("btnCancelar"), Button)

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

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
                Me.MultiView1.SetActiveView(Me.viewDatosLab)
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
            Dim tbNSS As TextBox = CType(Me.dvDatosLab.FindControl("tbNSS"), TextBox)
            Dim ddlRegimenISSSTE As DropDownList = CType(Me.dvDatosLab.FindControl("ddlRegimenISSSTE"), DropDownList)
            Dim oEmpleado As New Empleado
            With oEmpleado
                .IdEmp = CType(Request.Params("IdEmp"), Integer)
                .NSS = tbNSS.Text.Trim
                .IdRegimenISSSTE = CByte(ddlRegimenISSSTE.SelectedValue)
                .ActualizarDatosSegSoc(CByte(Request.Params("TipoOperacion")), CType(Session("ArregloAuditoria"), String()))
            End With
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub dvDatosLab_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvDatosLab.DataBound
        Dim ddlRegimenISSSTE As DropDownList
        Dim lblIdRegimenISSSTE As Label
        Dim oRegimenISSSTE As New ISSSTE
        Dim dt As DataTable
        lblIdRegimenISSSTE = CType(Me.dvDatosLab.FindControl("lblIdRegimenISSSTE"), Label)
        ddlRegimenISSSTE = CType(Me.dvDatosLab.FindControl("ddlRegimenISSSTE"), DropDownList)
        dt = oRegimenISSSTE.ObtenTodos()
        With ddlRegimenISSSTE
            .DataSource = dt
            .DataTextField = "RegimenISSSTE"
            .DataValueField = "IdRegimenISSSTE"
            .DataBind()
            .SelectedValue = lblIdRegimenISSSTE.Text
        End With
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        MultiView1.SetActiveView(viewDatosLab)
        BindDatos()
    End Sub

    Protected Sub lbReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles lbReintentarCaptura.Click
        MultiView1.SetActiveView(viewDatosLab)
    End Sub
End Class
