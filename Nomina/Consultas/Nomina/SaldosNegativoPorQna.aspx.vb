Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Partial Class Consultas_Nomina_SaldosNegativoPorQna
    Inherits System.Web.UI.Page
    Private Sub BindQnas()
        Dim oQna As New Quincenas
        With Me.ddlQnas
            .DataSource = oQna.ObtenListasParaCalculo
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas disponibles para consulta")
                .Items(0).Value = -1
                Me.btnConsultarQna.Enabled = False
            Else
                BindgvSaldosNegativos()
            End If
        End With
    End Sub
    Private Sub BindgvSaldosNegativos()
        Dim oEmp As New Empleado
        With oEmp
            Me.gvSaldosNegativos.DataSource = .ConSaldoNegativo(CType(Me.ddlQnas.SelectedValue, Short), Session("Login"))
            Me.gvSaldosNegativos.DataBind()
            Me.gvSaldosNegativos.Visible = True
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindQnas()
        End If
    End Sub
    Protected Sub gvSaldosNegativos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvSaldosNegativos.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(Me.gvSaldosNegativos.Rows(e.CommandArgument).FindControl("lbRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(Me.gvSaldosNegativos.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(Me.gvSaldosNegativos.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(Me.gvSaldosNegativos.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(Me.gvSaldosNegativos.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(Me.gvSaldosNegativos.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
        End Select
    End Sub

    Protected Sub gvSaldosNegativos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSaldosNegativos.RowDataBound
        Dim LnkBtn As LinkButton
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                LnkBtn = CType(e.Row.FindControl("lbRFC"), LinkButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvSaldosNegativos, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    Protected Sub btnConsultarQna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQna.Click
        BindgvSaldosNegativos()
    End Sub
End Class
