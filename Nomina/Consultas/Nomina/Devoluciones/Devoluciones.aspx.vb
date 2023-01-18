Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Partial Class Consultas_Nomina_Devoluciones
    Inherits System.Web.UI.Page
    Private Sub BindAnios()
        Dim oDevol As New Devolucion
        With Me.ddlAnios
            .DataSource = oDevol.ObtenAniosParaConsulta()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay años disponibles para consulta")
                .Items(0).Value = -1
            Else
                BindQnas()
            End If
        End With
    End Sub
    Private Sub BindQnas()
        Dim oDevol As New Devolucion
        With Me.ddlQuincenas
            .DataSource = oDevol.ObtenQnasPorAnioParaConsulta(CShort(Me.ddlAnios.SelectedValue))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Or Me.ddlAnios.SelectedValue = "-1" Then
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas disponibles para consulta")
                .Items(0).Value = -1
                Me.btnConsultar.Enabled = False
            Else
                Me.btnConsultar.Enabled = True
            End If
            BindgvDevs()
        End With
    End Sub
    Private Sub BindgvDevs()
        Dim oNomina As New Devolucion
        With oNomina
            If Me.ddlAnios.SelectedValue <> -1 Then
                Me.gvDevs.DataSource = .ObtenDevsPorAnioQna(CShort(Me.ddlAnios.SelectedValue), CShort(Me.ddlQuincenas.SelectedValue))
            End If
            Me.gvDevs.DataBind()
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindAnios()
        End If
    End Sub
    Protected Sub lbCrearRecibo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.gvDevs.Rows.Count = 0 Then BindAnios()
        BindgvDevs()
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindgvDevs()
    End Sub

    Protected Sub gvDevs_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Me.gvDevs.PageIndex = e.NewPageIndex
        BindgvDevs()
    End Sub

    Protected Sub gvDevs_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDevs.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdEmp As Label = CType(e.Row.FindControl("lblIdEmp"), Label)
                Dim lbRFCEmp As LinkButton = CType(e.Row.FindControl("lbRFCEmp"), LinkButton)
                lbRFCEmp.CommandArgument = e.Row.RowIndex
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvDevs, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub ddlAnios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindQnas()
    End Sub

    Protected Sub gvDevs_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDevs.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Dim lbRFCEmp As LinkButton = CType(Me.gvDevs.Rows(e.CommandArgument).FindControl("lbRFCEmp"), LinkButton)
                Dim oEmp As New Empleado
                Dim dr As DataRow
                dr = oEmp.BuscarPorRFC(lbRFCEmp.Text)
                Session.Add("RFCParaCons", dr("RFC"))
                Session.Add("CURPParaCons", dr("CURP"))
                Session.Add("ApePatParaCons", dr("ApellidoPaterno"))
                Session.Add("ApeMatParaCons", dr("ApellidoMaterno"))
                Session.Add("NombreParaCons", dr("Nombre"))
                Session.Add("NumEmpParaCons", dr("NumEmp"))
                Me.gvDevs.SelectedIndex = CInt(e.CommandArgument)
        End Select
    End Sub
End Class
