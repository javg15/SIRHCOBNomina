Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV

Partial Class DiasExentosPorAnioPercepcion
    Inherits System.Web.UI.Page
    Private Sub SubActualizar()
        BindddlAños()
        BindDatos()
    End Sub
    Private Sub BindddlAños()
        Dim oQna As New Quincenas
        With Me.ddlAños
            .DataSource = oQna.ObtenAños(True)
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
                Me.btnConsultarDiasExentos.Enabled = False
            Else
                Me.btnConsultarDiasExentos.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        If oEmp.RFC <> String.Empty Then
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
                pnl1.Visible = True
            Else
                Me.lblEmpInf.Text = String.Empty
                pnl1.Visible = False
            End If
        End If
        BindgvEmps()
    End Sub
    Private Sub BindgvEmps(Optional ByVal Fila As SByte = -1)
        Dim oEmp As New Nomina
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        If hfRFC.Value <> String.Empty Then
            gvDiasExentosPorPerc.DataSource = oEmp.getPorEmpDiasExentosPorAnioPerc(hfRFC.Value, ddlPercepciones.SelectedValue, ddlAños.SelectedValue)
            gvDiasExentosPorPerc.DataBind()
            gvDiasExentosPorPerc.Visible = True
        Else
            ddlAños.Enabled = False
            ddlPercepciones.Enabled = False
            btnConsultarDiasExentos.Enabled = False
            gvDiasExentosPorPerc.Visible = False
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Response.Expires = 0

            BindddlAños()
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub
    Protected Sub gvEmps_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvEmps_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDiasExentosPorPerc.SelectedIndexChanged

    End Sub
    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oMetodoComun As New MetodosComunes
        Dim c As Control = oMetodoComun.GetPostBackControl(Page)

        If c Is Nothing Then Exit Sub
        If c.ID = "BtnSearch" Then
            If hfRFC.Value <> String.Empty Then
                SubActualizar()
                pnl1.Visible = True
            Else
                pnl1.Visible = False
            End If
        ElseIf c.ID = "BtnNewSearch" Then
            SubActualizar()
            pnl1.Visible = False
        ElseIf c.ID = "BtnCancelSearch" Then
            pnl1.Visible = True
        ElseIf c.ID = "lnkbtnrfc" Then
            SubActualizar()
            pnl1.Visible = True
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarDiasExentos.Click
        BindDatos()
    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        SubActualizar()
    End Sub
End Class
