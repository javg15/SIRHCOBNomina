Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.InformacionAcademica
Partial Class EstPuntAsistPorEmp
    Inherits System.Web.UI.Page
    Private Sub BindAños()
        Dim oPerc As New Percepcion
        ddlAños.DataSource = oPerc.ObtenAniosDiasEcoNoDisf()
        ddlAños.DataTextField = "AnioSolicitud"
        ddlAños.DataValueField = "AnioSolicitud"
        ddlAños.DataBind()
        If Me.ddlAños.Items.Count = 0 Then
            MultiView1.Visible = False
            ddlAños.Items.Insert(0, "Sin información")
            ddlAños.Items(0).Value = -1
            btnConsultarEmps.Enabled = False
        Else
            If Session("RFCParaCons") Is Nothing Then
                gvEstPuntAsist.EmptyDataText = "Sin solicitudes registradas en el año " + ddlAños.SelectedItem.Text
                gvEstPuntAsist.DataBind()
                gvEstPuntAsist_2.EmptyDataText = "Sin pagos registrados en el año " + ddlAños.SelectedItem.Text
                gvEstPuntAsist_2.DataBind()
                MultiView1.Visible = False
            Else
                BindgvEstPuntAsist()
                BindgvEstPuntAsist_2()
                MultiView1.Visible = True
            End If
            btnConsultarEmps.Enabled = True
        End If
    End Sub
    Private Sub BindgvEstPuntAsist()
        Dim oEmp As New Percepcion
        With oEmp
            gvEstPuntAsist.DataSource = .ObtenSolicitudesEsPuntAsistPorAnio(Session("RFCParaCons").ToString, CShort(ddlAños.SelectedValue))
            gvEstPuntAsist.DataBind()
            gvEstPuntAsist.Visible = True
        End With
    End Sub
    Private Sub BindgvEstPuntAsist_2()
        Dim oEmp As New Percepcion
        With oEmp
            gvEstPuntAsist_2.DataSource = .ObtenCobrosEnAnioPorEmp(Session("RFCParaCons").ToString, CShort(ddlAños.SelectedValue), "125")
            gvEstPuntAsist_2.DataBind()
            gvEstPuntAsist_2.Visible = True
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindAños()
        End If
    End Sub

    Protected Sub btnConsultarEmps_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarEmps.Click
        'ActualizaInfParaGenerarArchivo()
        BindgvEstPuntAsist()
        BindgvEstPuntAsist_2()
    End Sub
    Protected Sub gvEstPuntAsist_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEstPuntAsist.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(gvEstPuntAsist.Rows(e.CommandArgument).FindControl("lbRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(gvEstPuntAsist.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(gvEstPuntAsist.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(gvEstPuntAsist.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(gvEstPuntAsist.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(gvEstPuntAsist.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
                Me.gvEstPuntAsist.SelectedIndex = CInt(e.CommandArgument)
            Case Else '"CmdEliminar", "CmdModificar"
                BindgvEstPuntAsist()
                BindgvEstPuntAsist_2()
        End Select
    End Sub

    Protected Sub gvEstPuntAsist_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEstPuntAsist.RowDataBound
        Dim LnkBtn As LinkButton
        Dim ibEliminar As ImageButton
        'Dim lblIdSemestre As Label
        Dim lblApePat, lblApeMat, lblNombre As Label
        Dim NombreCompleto As String
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                'lblIdSemestre = CType(e.Row.FindControl("lblIdSemestre"), Label)
                LnkBtn = CType(e.Row.FindControl("lbRFC"), LinkButton)
                lblApePat = CType(e.Row.FindControl("lblApePat"), Label)
                lblApeMat = CType(e.Row.FindControl("lblApeMat"), Label)
                lblNombre = CType(e.Row.FindControl("lblNombre"), Label)
                NombreCompleto = lblApePat.Text + " " + lblApeMat.Text + " " + lblNombre.Text
                ibEliminar = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString
                'ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Nomina/AdmonEstimuloDePuntyAsistencia.aspx?TipoOperacion=3&IdSemestre=" + lblIdSemestre.Text + "&RFC=" + LnkBtn.Text + "&Nombre=" + NombreCompleto + "'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(gvEstPuntAsist, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(0).Contains("BtnSearch") Or Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    BindAños()
                    BindgvEstPuntAsist()
                    BindgvEstPuntAsist_2()
                    MultiView1.Visible = True
                Else
                    MultiView1.Visible = False
                End If
            ElseIf Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnNewSearch") Then
                MultiView1.Visible = False
            ElseIf Request.Params(0).Contains("BtnCancelSearch") Or Request.Params(1).Contains("BtnCancelSearch") Then
                MultiView1.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindAños()
                    BindgvEstPuntAsist()
                    BindgvEstPuntAsist_2()
                    MultiView1.Visible = True
                End If
            End If
        End If
    End Sub
End Class
