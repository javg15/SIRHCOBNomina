Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports System.Data
Partial Class Consultas_Empleados_CargaHorariaRecibos
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oSem As New Semestre
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
            lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            lblEmpInf.Visible = True
            Me.pnlSemestres.Visible = True
        Else
            lblEmpInf.Text = String.Empty
            lblEmpInf.Visible = False
            Me.pnlSemestres.Visible = False
        End If
        Me.ddlSemestres.DataSource = oSem.ObtenSemestres
        Me.ddlSemestres.DataTextField = "Semestre"
        Me.ddlSemestres.DataValueField = "IdSemestre"
        Me.ddlSemestres.DataBind()
        If Me.ddlSemestres.Items.Count = 0 Then
            Me.ddlSemestres.Items.Insert(0, "No existe información de semestres")
            Me.ddlSemestres.Items(0).Value = -1
            Me.btnConsultarCargaHoraria.Enabled = False
        Else
            Me.btnConsultarCargaHoraria.Enabled = True
        End If
    End Sub
    Private Sub BindCargaHoraria()
        Dim ds As DataSet
        Dim oEmp As New Empleado
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If oEmp.RFC <> String.Empty Then
            ds = oEmp.ObtenCargaHoraria(CType(Me.ddlSemestres.SelectedValue, Short), Me.chkbxCargaHorariaConHistoria.Checked)
            With Me.gvCargaHoraria
                .DataSource = ds.Tables(0)
                .DataBind()
                .SelectedIndex = -1
                .Columns(14).Visible = Me.ddlSemestres.SelectedIndex = 0 And Not oEmp.TienePagosEnSemestreActual()
                .Columns(15).Visible = Me.ddlSemestres.SelectedIndex = 0
                .Columns(16).Visible = Me.ddlSemestres.SelectedIndex = 0
                .Columns(17).Visible = Me.ddlSemestres.SelectedIndex = 0
                Me.lbNuevaCargaHoraria.Visible = .Rows.Count > 0 And Me.ddlSemestres.SelectedIndex > 0
            End With
            With Me.gvResumen1
                .DataSource = ds.Tables(2)
                .DataBind()
            End With
            chkbxCargaHorariaConHistoria.Enabled = Me.ddlSemestres.SelectedIndex = 0
            Me.lbNuevaCargaHoraria.OnClientClick = "javascript:abreVentanaChica('../../ABC/Empleados/AdministracionCargaHoraria.aspx?IdSemestre=" + Me.ddlSemestres.SelectedValue + "&RFCEmp=" + oEmp.RFC + "&TipoOperacion=2" + "'); return false;"
            BindCargaHorariaAnexa()
        End If
    End Sub
    Private Sub BindCargaHorariaAnexa()
        Dim ds As DataSet
        Dim oEmp As New Empleado
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If oEmp.RFC <> String.Empty Then
            ds = oEmp.ObtenCargaHoraria(CType(Me.ddlSemestres.SelectedValue, Short), Me.chkbxCargaHorariaConHistoria.Checked)
            With Me.gvCargaHorariaAnexa
                .DataSource = ds.Tables(1)
                .DataBind()
                .SelectedIndex = -1
                .Columns(15).Visible = Me.ddlSemestres.SelectedIndex = 0
                .Columns(16).Visible = Me.ddlSemestres.SelectedIndex = 0
            End With
            With Me.gvResumen2
                .DataSource = ds.Tables(3)
                .DataBind()
            End With
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false")
        End If
    End Sub
    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
        If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
    End Sub

    Protected Sub btnConsultarCargaHoraria_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindCargaHoraria()
    End Sub

    Protected Sub gvCargaHoraria_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCargaHoraria.RowCommand
        Select Case e.CommandName
            Case "Eliminar"
                Dim oHora As New Hora
                oHora.IdHora = CInt(e.CommandArgument)
                oHora.EliminaPorId(CType(Session("ArregloAuditoria"), String()))
                If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
        End Select
    End Sub

    Protected Sub gvCargaHoraria_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCargaHoraria.RowDataBound
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdHora As Label = CType(e.Row.FindControl("lblIdHora"), Label)
                Dim lblNombramiento As Label = CType(e.Row.FindControl("lblNombramiento"), Label)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibAddHoras As ImageButton = CType(e.Row.FindControl("ibAddHoras"), ImageButton)
                Dim ibRemplazar As ImageButton = CType(e.Row.FindControl("ibRemplazar"), ImageButton)
                If lblNombramiento.Text <> "D" Then
                    ibRemplazar.Enabled = False
                End If
                ibEliminar.CommandArgument = lblIdHora.Text
                ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=0" + "'); return false;"
                ibAddHoras.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=1" + "'); return false;"
                ibRemplazar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=1" + "&AsociarInterinas=1'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvCargaHoraria, "Select$" + e.Row.RowIndex.ToString)
            Case DataControlRowType.EmptyDataRow
                Dim lbNuevaCargaHoraria As LinkButton = CType(e.Row.FindControl("lbNuevaCargaHoraria"), LinkButton)
                Dim oEmp As New Empleado
                oEmp.RFC = hfRFC.Value
                lbNuevaCargaHoraria.Visible = Me.ddlSemestres.SelectedIndex = 0
                lbNuevaCargaHoraria.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&TipoOperacion=1" + "'); return false;"
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
            If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
        End If
    End Sub

    Protected Sub ddlSemestres_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        chkbxCargaHorariaConHistoria.Enabled = Me.ddlSemestres.SelectedIndex = 0
        If Me.ddlSemestres.SelectedIndex > 0 Then
            chkbxCargaHorariaConHistoria.Checked = False
        End If
    End Sub

    Protected Sub gvCargaHorariaAnexa_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdHora As Label = CType(e.Row.FindControl("lblIdHora"), Label)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                ibEliminar.CommandArgument = lblIdHora.Text
                ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=0" + "&AsociarInterinas=1'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvCargaHorariaAnexa, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvCargaHorariaAnexa_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Select Case e.CommandName
            Case "Eliminar"
                Dim oHora As New Hora
                oHora.IdHora = CInt(e.CommandArgument)
                oHora.EliminaPorId(CType(Session("ArregloAuditoria"), String()), True)
                If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHorariaAnexa()
        End Select
    End Sub
End Class
