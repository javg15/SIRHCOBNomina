Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.InformacionAcademica
Partial Class Consultas_Percepciones_EstimuloDocente
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oSem As New Semestre
        Me.ddlAnios.DataSource = oSem.ObtenAnios
        Me.ddlAnios.DataTextField = "Anio"
        Me.ddlAnios.DataValueField = "Anio"
        Me.ddlAnios.DataBind()
        If Me.ddlAnios.Items.Count = 0 Then
            Me.ddlAnios.Items.Insert(0, "No existe información sobre años.")
            Me.ddlAnios.Items(0).Value = -1
            Me.btnConsultar.Enabled = False
        Else
            Me.btnConsultar.Enabled = True
        End If
    End Sub
    Private Sub BindgvEstimulosDocentes()
        Dim oEmp As New Empleado
        With oEmp
            Me.gvEstimulosDocentes.DataSource = .ConEstimuloDocente(CType(Me.ddlAnios.SelectedValue, Short))
            Me.gvEstimulosDocentes.DataBind()
            Me.gvEstimulosDocentes.Visible = True
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDatos()
            Me.lbAgregarNuevoEmp.Text = "Agregar nuevo empleado (Año: " + Me.ddlAnios.SelectedItem.Text + ")"
            Me.lbAgregarNuevoEmp.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonEstimuloDocente.aspx?TipoOperacion=1&Anio=" + Me.ddlAnios.SelectedValue + "');"
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        BindgvEstimulosDocentes()
        Me.lbAgregarNuevoEmp.Text = "Agregar nuevo empleado (Año: " + Me.ddlAnios.SelectedItem.Text + ")"
        Me.lbAgregarNuevoEmp.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonEstimuloDocente.aspx?TipoOperacion=1&Anio=" + Me.ddlAnios.SelectedValue + "');"
    End Sub

    Protected Sub gvEstimulosDocentes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEstimulosDocentes.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(Me.gvEstimulosDocentes.Rows(e.CommandArgument).FindControl("lbRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(Me.gvEstimulosDocentes.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(Me.gvEstimulosDocentes.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(Me.gvEstimulosDocentes.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(Me.gvEstimulosDocentes.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(Me.gvEstimulosDocentes.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
                Me.gvEstimulosDocentes.SelectedIndex = CInt(e.CommandArgument)
            Case Else '"CmdEliminar", "CmdModificar"
                BindgvEstimulosDocentes()
        End Select
    End Sub

    Protected Sub gvEstimulosDocentes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEstimulosDocentes.RowDataBound
        Dim LnkBtn As LinkButton
        Dim ibModificar, ibEliminar As ImageButton
        Dim lblAnio As Label
        'Dim lblApePat, lblApeMat, lblNombre, lblImporte As Label
        'Dim NombreCompleto As String
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lblAnio = CType(e.Row.FindControl("lblAnio"), Label)
                LnkBtn = CType(e.Row.FindControl("lbRFC"), LinkButton)
                'lblApePat = CType(e.Row.FindControl("lblApePat"), Label)
                'lblApeMat = CType(e.Row.FindControl("lblApeMat"), Label)
                'lblNombre = CType(e.Row.FindControl("lblNombre"), Label)
                'lblImporte = CType(e.Row.FindControl("lblImporte"), Label)
                'NombreCompleto = lblApePat.Text + " " + lblApeMat.Text + " " + lblNombre.Text
                ibEliminar = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString
                'ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonEstimuloDocente.aspx?TipoOperacion=3&Anio=" + lblAnio.Text + "&RFC=" + LnkBtn.Text + "&Nombre=" + NombreCompleto + "&Importe=" + lblImporte.Text + "'); return false;"
                'ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonEstimuloDocente.aspx?TipoOperacion=0&Anio=" + lblAnio.Text + "&RFC=" + LnkBtn.Text + "&Nombre=" + NombreCompleto + "&Importe=" + lblImporte.Text + "'); return false;"
                ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonEstimuloDocente.aspx?TipoOperacion=3&Anio=" + lblAnio.Text + "&RFC=" + LnkBtn.Text + "'); return false;"
                ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonEstimuloDocente.aspx?TipoOperacion=0&Anio=" + lblAnio.Text + "&RFC=" + LnkBtn.Text + "'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvEstimulosDocentes, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub lbAgregarNuevoEmp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAgregarNuevoEmp.Click
        BindgvEstimulosDocentes()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindgvEstimulosDocentes()
        End If
    End Sub
End Class
