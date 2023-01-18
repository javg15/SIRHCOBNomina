Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports System.Data
Imports DataAccessLayer.COBAEV.MovsDePersonal

Partial Class Consultas_Empleados_CargaHorariaOP
    Inherits System.Web.UI.Page
    Private Sub BindSemestres()
        Dim oSem As New Semestre
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
    Private Sub BindDatos()
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
        BindSemestres()
    End Sub
    Private Sub BindCargaHoraria()
        Dim oEmp As New Empleado
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim vlRFC As String = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If vlRFC.Trim <> String.Empty Then
            With Me.gvCargaHoraria
                .DataSource = oEmp.ObtenCargaHorariaParaOP(vlRFC, CType(Me.ddlSemestres.SelectedValue, Short), Me.chkbxCargaHorariaConHistoria.Checked)
                .DataBind()
            End With
        End If
    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
    '        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
    '        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
    '        Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
    '        ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
    '    End If
    'End Sub
    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
        If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
        Me.btnOP.Enabled = False
    End Sub

    Protected Sub btnConsultarCargaHoraria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarCargaHoraria.Click
        BindCargaHoraria()
        Me.btnOP.Enabled = False
    End Sub

    Protected Sub gvCargaHoraria_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCargaHoraria.RowDataBound
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdHora As Label = CType(e.Row.FindControl("lblIdHora"), Label)
                Dim lblNombramiento As Label = CType(e.Row.FindControl("lblNombramiento"), Label)
                Dim lblIdOP As Label = CType(e.Row.FindControl("lblIdOP"), Label)
                Dim lbOP As LinkButton = CType(e.Row.FindControl("lbOP"), LinkButton)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim lblIdEstatusOP As Label = CType(e.Row.FindControl("lblIdEstatusOP"), Label)
                Dim vlNomTitular As String
                Dim drInfTitular As DataRow
                Dim oHora As New Hora

                imgInfTitular.Visible = False
                If lblNombramiento.Text = "I" Then
                    imgInfTitular.Visible = True
                    drInfTitular = oHora.ObtenTitular(CInt(lblIdHora.Text))
                    vlNomTitular = (drInfTitular("ApePatEmp") + " " + drInfTitular("ApeMatEmp") + " " + drInfTitular("NomEmp")).ToString.Trim
                    If vlNomTitular = String.Empty Then
                        vlNomTitular = "Información del titular no capturada."
                    End If
                    imgInfTitular.ToolTip = vlNomTitular
                End If


                Dim ibVerDetalles As ImageButton = CType(e.Row.FindControl("ibVerDetalles"), ImageButton)
                Dim ChckBxSel As CheckBox = CType(e.Row.FindControl("ChckBxSel"), CheckBox)
                ibVerDetalles.OnClientClick = "javascript:abreVentMedAncha2('../../ABC/Empleados/AdministracionCargaHoraria.aspx?RFCEmp=" + hfRFC.Value.Trim + "&IdHora=" + lblIdHora.Text + "&TipoOperacion=4" + "&ValidacionAlCargarPagina=SI&IdSemestre=" + Me.ddlSemestres.SelectedValue + "'); return false;"

                If lblIdEstatusOP.Text = "3" Then
                    lbOP.Text = ""
                End If

                If lblNombramiento.Text = "D" Or lbOP.Text.Trim <> "" Then ChckBxSel.Enabled = False
                If lblIdOP.Text <> "0" And lblNombramiento.Text = "I" Then
                    lbOP.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                + "?IdOrdenDePres=" + lblIdOP.Text + "&IdReporte=73','OP_" + lblIdOP.Text + "'); return false;"
                ElseIf lblIdOP.Text <> "0" And lblNombramiento.Text = "P" Then
                    lbOP.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                + "?IdOrdenDePres=" + lblIdOP.Text + "&IdReporte=74','OP_" + lblIdOP.Text + "'); return false;"
                End If

                'lbOP.Visible = lblIdEstatusOP.Text <> "3"
                'If ChckBxSel.Enabled = False And lblIdEstatusOP.Text = "3" Then
                '    ChckBxSel.Enabled = True
                'End If

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
            If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
        End If
    End Sub
    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    BindDatos()
                    If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
                    pnl1.Visible = True
                    pnl2.Visible = True
                Else
                    pnl1.Visible = False
                    pnl2.Visible = False
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                pnl1.Visible = False
                pnl2.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                pnl1.Visible = True
                pnl2.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindDatos()
                    If Me.ddlSemestres.SelectedValue <> -1 Then BindCargaHoraria()
                    pnl1.Visible = True
                    pnl2.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub ChckBxSel_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, CheckBox).NamingContainer, GridViewRow)
        Dim ChckBxSel As CheckBox = CType(sender, CheckBox)
        Dim ChckBxSel2 As CheckBox
        Dim lblIdHora As Label = CType(gvr.FindControl("lblIdHora"), Label)
        Dim oHora As Hora
        Dim dt As DataTable

        If ChckBxSel.Checked = False Then
            BindCargaHoraria()
            Me.btnOP.Enabled = False
        Else
            oHora = New Hora
            dt = oHora.ObtenGrupoParaOP(CInt(lblIdHora.Text))

            For Each gvr2 As GridViewRow In gvCargaHoraria.Rows
                ChckBxSel2 = CType(gvr2.FindControl("ChckBxSel"), CheckBox)
                If ChckBxSel2 Is Nothing = False And CInt(CType(gvr2.FindControl("lblIdHora"), Label).Text) <> CInt(lblIdHora.Text) Then
                    ChckBxSel2.Checked = False : ChckBxSel2.Enabled = False
                End If
            Next

            For Each dr As DataRow In dt.Rows
                For Each gvr2 As GridViewRow In gvCargaHoraria.Rows
                    ChckBxSel2 = CType(gvr2.FindControl("ChckBxSel"), CheckBox)
                    If CInt(CType(gvr2.FindControl("lblIdHora"), Label).Text) = CInt(dr(0)) Then ChckBxSel2.Checked = True
                Next
            Next

            Me.btnOP.Enabled = True
        End If
    End Sub

    Protected Sub btnOP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim oOrdPres As New OrdenesDePresentacion
            Dim IdOrdenDePres As Integer
            Dim ChckBxSel As CheckBox
            Dim lblIdHora As Label

            IdOrdenDePres = oOrdPres.GeneraNueva(Session("Login"), CType(Session("ArregloAuditoria"), String()))

            For Each gvr As GridViewRow In gvCargaHoraria.Rows
                ChckBxSel = CType(gvr.FindControl("ChckBxSel"), CheckBox)
                If ChckBxSel.Checked Then
                    lblIdHora = CType(gvr.FindControl("lblIdHora"), Label)
                    oOrdPres.AsociaHora(CInt(lblIdHora.Text), IdOrdenDePres, CType(Session("ArregloAuditoria"), String()))
                End If
            Next
            Me.btnOP.Enabled = False
            BindCargaHoraria()
        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
End Class
