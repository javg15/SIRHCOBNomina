Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas

Partial Class Consultas_Empleados_ConReduccionDeSueldo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim newListItem As ListItem
            newListItem = New ListItem("Quincena fin", "")
            newListItem.Selected = True
            ddlOrden.Items.Add(newListItem)

            newListItem = New ListItem("Nombre", "nombre")
            ddlOrden.Items.Add(newListItem)

            BindDatos("")
            MVMain.SetActiveView(vwMain)

        End If
    End Sub

    Protected Sub gvEmps_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEmps.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lbRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
        End Select
    End Sub

    Protected Sub gvEmps_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmps.RowDataBound
        Dim lbRFC As LinkButton
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lbRFC = CType(e.Row.FindControl("lbRFC"), LinkButton)
                lbRFC.CommandArgument = e.Row.RowIndex.ToString
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvEmps, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Public Sub BindDatos(ByVal orden As String)
        Dim oEmp As New EmpleadosConReduccionDeSueldo
        With Me.gvEmps
            .DataSource = oEmp.ObtenReducciones("&orden=" + orden)
            .DataBind()
        End With
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click
        BindDatos(ddlOrden.SelectedValue)
    End Sub

    Protected Sub ibModificar_Click(sender As Object, e As System.EventArgs)
        Dim gvEmps As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim oQna As New Quincenas

        Dim lblNumEmp As Label = CType(gvEmps.FindControl("lblNumEmp"), Label)
        Dim lblIdEmp As Label = CType(gvEmps.FindControl("lblIdEmp"), Label)
        Dim Nombre As String = CType(gvEmps.FindControl("lblApePat"), Label).Text _
                & " " & CType(gvEmps.FindControl("lblApeMat"), Label).Text _
                & " " & CType(gvEmps.FindControl("lblNombre"), Label).Text

        Dim lblPorcDesc As Label = CType(gvEmps.FindControl("lblPorcDesc"), Label)
        Dim lblIdQnaIni As Label = CType(gvEmps.FindControl("lblIdQnaIni"), Label)
        Dim lblIdQnaFin As Label = CType(gvEmps.FindControl("lblIdQnaFin"), Label)

        CType(Me.WucBuscaEmpleados1.FindControl("txtbxNumEmp"), TextBox).Text = lblNumEmp.Text
        WucBuscaEmpleados1.PerformClick_BtnSearch

        hidIdReduccion.Value = CType(gvEmps.FindControl("lblIdReduccion"), Label).Text
        hidIdEmpleado.Text = lblIdEmp.Text
        txtbxPorcentageReduccion.Text = lblPorcDesc.Text
        lblEmpleado.Text = Nombre
        LlenaDDL(ddlQuincenaInicio, "Quincena", "IdQuincena", oQna.ObtenListasCalculadas(), lblIdQnaIni.Text)
        LlenaDDL(ddlQuincenaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CShort(lblIdQnaIni.Text), True), lblIdQnaFin.Text)

        pnlEd.Enabled = True
        MVMain.SetActiveView(vwReduccionesEd)
    End Sub

    Private Sub BindddlQuincenas(ByVal ddlQuincenas As DropDownList, ByVal IdSelected As Integer)
        Dim oQna As New Quincenas

        LlenaDDL(ddlQuincenas, "Quincena", "IdQuincena", oQna.ObtenListasCalculadas(), IdSelected)
    End Sub

    Private Sub BindddlQuincenaTermino()
        Dim oQna As New Quincenas

        If ddlQuincenaInicio.SelectedValue > 0 Then
            LlenaDDL(ddlQuincenaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQuincenaInicio.SelectedValue, Short), True), 32767)
        End If
    End Sub

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "0")
        Dim R As DataRow = dt.NewRow
        'renglon de seleccion nula
        R(TextField) = "-"
        R(ValueField) = "0"
        dt.Rows.InsertAt(R, 0)

        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub

    Protected Sub ibEliminar_Click(sender As Object, e As System.EventArgs)

    End Sub

    Protected Sub btnGuardarModifReducciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarModifReducciones.Click
        Try

            Dim hidIdReduccion As HiddenField = CType(Me.pnlEd.FindControl("hidIdReduccion"), HiddenField)
            Dim ddlQnaInicio As DropDownList = CType(Me.pnlEd.FindControl("ddlQuincenaInicio"), DropDownList)
            Dim ddlQnaTermino As DropDownList = CType(Me.pnlEd.FindControl("ddlQuincenaFin"), DropDownList)
            Dim txtbxPorcentageReduccion As TextBox = CType(Me.pnlEd.FindControl("txtbxPorcentageReduccion"), TextBox)
            Dim hidIdEmpleado As TextBox = CType(Me.pnlEd.FindControl("hidIdEmpleado"), TextBox)

            Dim respuesta As String
            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim oEP As New EmpleadosConReduccionDeSueldo

            With oEP
                .IdEmp = hidIdEmpleado.Text
                .IdReduccion = hidIdReduccion.Value
                .IdQnaIni = ddlQnaInicio.SelectedValue
                .IdQnaFin = ddlQnaTermino.SelectedValue
                .PorcDesc = txtbxPorcentageReduccion.Text
            End With

            If (hidIdReduccion.Value Is Nothing Or hidIdReduccion.Value = "0") Then
                respuesta = oEP.AgregaNueva(1, CType(Session("ArregloAuditoria"), String()))
            Else
                respuesta = oEP.AgregaNueva(0, CType(Session("ArregloAuditoria"), String()))
            End If

            If respuesta.Split("&")(1) = "" Then
                CType(Me.pnlEd.FindControl("hidIdReduccion"), HiddenField).Value = respuesta.Split("&")(0)
                Me.MVMain.SetActiveView(Me.viewExito)
            Else
                Me.lblError.Text = respuesta.Split("&")(1)
                Me.MVMain.SetActiveView(Me.viewError)
            End If
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MVMain.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub btnCancelarReducciones_Click(sender As Object, e As System.EventArgs) Handles btnCancelarReducciones.Click

        MVMain.SetActiveView(vwMain)
        pnlEd.Enabled = False
    End Sub



    Protected Sub ddlQuincenaInicio_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles ddlQuincenaInicio.SelectedIndexChanged
        BindddlQuincenaTermino()
    End Sub

    Protected Sub lbAsignarReduccion_Click(sender As Object, e As EventArgs) Handles lbAsignarReduccion.Click
        WucBuscaEmpleados1.Visible = True

        PrepararNuevo()

        pnlEd.Enabled = True
        MVMain.SetActiveView(vwReduccionesEd)
    End Sub
    Protected Sub btnReintentarOp_Click(sender As Object, e As EventArgs) Handles btnReintentarOp.Click
        MVMain.SetActiveView(vwReduccionesEd)
    End Sub
    Protected Sub btnCancelarOp_Click(sender As Object, e As EventArgs) Handles btnCancelarOp.Click
        MVMain.SetActiveView(vwMain)
    End Sub
    Protected Sub lbOtraOperacion_Click(sender As Object, e As EventArgs) Handles lbOtraOperacion.Click
        MVMain.SetActiveView(vwReduccionesEd)
    End Sub

    Protected Sub PrepararNuevo()
        Dim oEmp As New Empleado
        Dim oQna As New Quincenas
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)

        hidIdReduccion.Value = "0"
        txtbxPorcentageReduccion.Text = "0"
        LlenaDDL(ddlQuincenaInicio, "Quincena", "IdQuincena", oQna.ObtenListasCalculadas(), 0)
        If txtbxRFC.Text <> "" Then
            oEmp.RFC = txtbxRFC.Text
            hidIdEmpleado.Text = oEmp.ObtenDatosPersonales()(0)("IdEmp")
            lblEmpleado.Text = txtbxNomEmp.Text
        End If
    End Sub


    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)
            Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
            BtnSearch.CausesValidation = False
            BtnNewSearch.CausesValidation = False
            BtnCancelSearch.CausesValidation = False

            If Request.Params(0).Contains("BtnSearch") Or Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    PrepararNuevo()
                    pnlEdCampos.Enabled = True
                Else
                    pnlEdCampos.Enabled = False
                End If
            ElseIf Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnNewSearch") Then
                pnlEdCampos.Enabled = False
            ElseIf Request.Params(0).Contains("BtnCancelSearch") Or Request.Params(1).Contains("BtnCancelSearch") Then
                pnlEdCampos.Enabled = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    PrepararNuevo()
                    pnlEdCampos.Enabled = True
                End If
            End If
        End If
    End Sub
    Protected Sub lbOtraOperacion0_Click(sender As Object, e As EventArgs) Handles lbOtraOperacion0.Click
        BindDatos(ddlOrden.SelectedValue)
        MVMain.SetActiveView(vwMain)
    End Sub
End Class
