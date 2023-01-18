Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion

Partial Class SubsidioEmpleoAcumuladoEjercicio
    Inherits System.Web.UI.Page
    Private Sub BindddlAños()
        Dim oEjercicioFiscal As New EjercicioFiscal
        With Me.ddlAños
            .DataSource = oEjercicioFiscal.ObtenAños()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, New ListItem("No existe información de años", "-1"))
                Me.btnConsultar.Enabled = False
            Else
                Me.btnConsultar.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindgvAcumulado()
        Dim oNom As New DeclaracionAnual
        Dim ds As DataSet
        Me.lblMsj.Text = String.Empty
        If Me.ddlAños.SelectedValue <> -1 Then
            Me.lblMsj.Text = "Subsidio para el empleo acumulado durante el ejercicio " + Me.ddlAños.SelectedItem.Text
            ds = oNom.ObtenSubsidioParaEmpleoAcumulado(CShort(Me.ddlAños.SelectedValue))
            Me.gvAcumulado.DataSource = ds.Tables(0)
            Me.gvTotalAcumulado.DataSource = ds.Tables(1)
            Me.ddlAños.Enabled = True
            Me.btnConsultar.Enabled = True
        Else
            Me.ddlAños.Enabled = False
            Me.btnConsultar.Enabled = False
        End If
        Me.gvAcumulado.DataBind()
        Me.gvTotalAcumulado.DataBind()
    End Sub
    Private Sub BindgvListadoEmps()
        Dim oEjerFisc As New EjercicioFiscal

        Me.lblMsj2.Text = String.Empty
        If Me.ddlAños.SelectedValue <> -1 Then
            Me.lblMsj2.Text = "Listado de empleados sin aplicación del subsidio para el empleo durante el ejercicio " + Me.ddlAños.SelectedItem.Text
            Me.gvListadoEmps.DataSource = oEjerFisc.ObtenListadoDeEmpsSinAplicDeSubsidio(CShort(Me.ddlAños.SelectedValue))
            Me.gvListadoEmps.DataBind()
        End If
    End Sub
    Protected Sub gvAcumulado_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAcumulado.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvAcumulado, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindgvAcumulado()
                BindgvListadoEmps()
            End If
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        BindgvAcumulado()
        BindgvListadoEmps()
    End Sub

    Protected Sub gvListadoEmps_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(Me.gvListadoEmps.Rows(e.CommandArgument).FindControl("LnkBtnRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(Me.gvListadoEmps.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(Me.gvListadoEmps.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(Me.gvListadoEmps.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(Me.gvListadoEmps.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(Me.gvListadoEmps.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
        End Select
    End Sub

    Protected Sub gvListadoEmps_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim LnkBtn As LinkButton
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                LnkBtn = CType(e.Row.FindControl("LnkBtnRFC"), LinkButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvListadoEmps, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
End Class