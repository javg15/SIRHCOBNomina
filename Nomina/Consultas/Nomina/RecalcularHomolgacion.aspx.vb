Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Partial Class Consultas_Nomina_RecalcularHomologacion
    Inherits System.Web.UI.Page
    Private Sub BindQnas()
        Dim oQna As New Quincenas
        With Me.ddlQnas
            .DataSource = oQna.ObtenParaAutorizacionHomologacion
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas disponibles para consulta")
                .Items(0).Value = -1
                Me.btnConsultarQna.Enabled = False
            Else
                Me.btnConsultarQna.Enabled = True
                BindgvRecalculosHomologacion()
            End If
        End With
    End Sub
    Private Sub BindgvRecalculosHomologacion()
        Dim oEmp As New Empleado
        With oEmp
            Me.gvRecalculosHomologacion.DataSource = .ConAutorizacionDeHomolgacion(CType(Me.ddlQnas.SelectedValue, Short))
            Me.gvRecalculosHomologacion.DataBind()
            Me.gvRecalculosHomologacion.Visible = True
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindQnas()
            Me.lbAgregarNuevaAut.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonAutorizacionesHomologacion.aspx?TipoOperacion=1');"
        End If
    End Sub

    Protected Sub btnConsultarQna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQna.Click
        BindgvRecalculosHomologacion()
    End Sub

    Protected Sub gvRecalculosHomologacion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvRecalculosHomologacion.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(Me.gvRecalculosHomologacion.Rows(e.CommandArgument).FindControl("lbRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(Me.gvRecalculosHomologacion.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(Me.gvRecalculosHomologacion.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(Me.gvRecalculosHomologacion.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(Me.gvRecalculosHomologacion.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(Me.gvRecalculosHomologacion.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
                Me.gvRecalculosHomologacion.SelectedIndex = CInt(e.CommandArgument)
            Case Else '"CmdEliminar", "CmdModificar"
                BindgvRecalculosHomologacion()
                If Me.gvRecalculosHomologacion.Rows.Count = 0 Then BindQnas()
        End Select
    End Sub

    Protected Sub gvRecalculosHomologacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRecalculosHomologacion.RowDataBound
        Dim LnkBtn As LinkButton
        Dim ibModificar, ibEliminar As ImageButton
        Dim lblIdQuincena As Label
        Dim lblApePat, lblApeMat, lblNombre As Label
        Dim NombreCompleto As String
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lblIdQuincena = CType(e.Row.FindControl("lblIdQuincena"), Label)
                LnkBtn = CType(e.Row.FindControl("lbRFC"), LinkButton)
                lblApePat = CType(e.Row.FindControl("lblApePat"), Label)
                lblApeMat = CType(e.Row.FindControl("lblApeMat"), Label)
                lblNombre = CType(e.Row.FindControl("lblNombre"), Label)
                NombreCompleto = lblApePat.Text + " " + lblApeMat.Text + " " + lblNombre.Text
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)
                ibEliminar = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString
                ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonAutorizacionesHomologacion.aspx?TipoOperacion=0&IdQuincena=" + lblIdQuincena.Text + "&RFC=" + LnkBtn.Text + "&Nombre=" + NombreCompleto + "'); return false;"
                ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonAutorizacionesHomologacion.aspx?TipoOperacion=3&IdQuincena=" + lblIdQuincena.Text + "&RFC=" + LnkBtn.Text + "&Nombre=" + NombreCompleto + "'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvRecalculosHomologacion, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub lbAgregarNuevaAut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAgregarNuevaAut.Click
        BindgvRecalculosHomologacion()
        If Me.gvRecalculosHomologacion.Rows.Count = 0 Then BindQnas()
    End Sub
End Class
