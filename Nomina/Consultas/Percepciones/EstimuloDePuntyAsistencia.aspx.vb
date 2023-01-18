Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.InformacionAcademica
Partial Class Consultas_Percepciones_EstimuloDePuntyAsistencia
    Inherits System.Web.UI.Page
    Private Sub ActualizaInfParaGenerarArchivo()
        Me.ibExportarExcel1.OnClientClick = "javascript:abreVentanaImpresion('../../VentanaExportarArchivosAExcel.aspx" _
            + "?strAnioParte=" + ddlPartes.SelectedValue _
            + "&TipoArchivo=0','Archivo_" + ddlPartes.SelectedValue.Replace("-", "_") + "_TA0');"
        Me.ibExportarExcel2.OnClientClick = "javascript:abreVentanaImpresion('../../VentanaExportarArchivosAExcel.aspx" _
            + "?strAnioParte=" + ddlPartes.SelectedValue _
            + "&TipoArchivo=0','Archivo_" + ddlPartes.SelectedValue.Replace("-", "_") + "_TA0');"
    End Sub
    Private Sub BindPartes()
        Dim oPerc As New Percepcion
        Me.ddlPartes.DataSource = oPerc.ObtenPartesEstDePuntyAsistDadoUnAnio(CShort(ddlAños.SelectedValue))
        Me.ddlPartes.DataTextField = "strParte"
        Me.ddlPartes.DataValueField = "strValue"
        Me.ddlPartes.DataBind()
        If Me.ddlPartes.Items.Count = 0 Then
            Me.ddlPartes.Items.Insert(0, "Sin información")
            Me.ddlPartes.Items(0).Value = -1
            Me.btnConsultarEmps.Enabled = False
            ibExportarExcel1.Visible = False
            ibExportarExcel2.Visible = False
        Else
            ActualizaInfParaGenerarArchivo()
            BindgvEstPuntYAsist()
            Me.btnConsultarEmps.Enabled = True
            ibExportarExcel1.Visible = True
            ibExportarExcel2.Visible = True
        End If
    End Sub

    Private Sub BindAños()
        Dim oPerc As New Percepcion
        Me.ddlAños.DataSource = oPerc.ObtenAniosEstDePuntyAsist()
        Me.ddlAños.DataTextField = "Anio"
        Me.ddlAños.DataValueField = "Anio"
        Me.ddlAños.DataBind()
        If Me.ddlAños.Items.Count = 0 Then
            Me.ddlAños.Items.Insert(0, "Sin información")
            Me.ddlAños.Items(0).Value = -1
            Me.ddlPartes.Items.Insert(0, "Sin información")
            Me.ddlPartes.Items(0).Value = -1
            Me.btnConsultarEmps.Enabled = False
            ibExportarExcel1.Visible = False
            ibExportarExcel2.Visible = False
        Else
            BindPartes()
            Me.btnConsultarEmps.Enabled = True
        End If
    End Sub
    Private Sub BindgvEstPuntYAsist()
        Dim oEmp As New Percepcion
        With oEmp
            Me.gvEstPuntYAsist.DataSource = .ObtenSEmpsParaPuntyAsistPorAnioyParte(ddlPartes.SelectedValue, False)
            Me.gvEstPuntYAsist.DataBind()
            Me.gvEstPuntYAsist.Visible = True
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindAños()
        End If
    End Sub

    Protected Sub btnConsultarEmps_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarEmps.Click
        ActualizaInfParaGenerarArchivo()
        BindgvEstPuntYAsist()
    End Sub

    Protected Sub gvEstPuntYAsist_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEstPuntYAsist.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(Me.gvEstPuntYAsist.Rows(e.CommandArgument).FindControl("lbRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(Me.gvEstPuntYAsist.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(Me.gvEstPuntYAsist.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(Me.gvEstPuntYAsist.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(Me.gvEstPuntYAsist.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(Me.gvEstPuntYAsist.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
                Me.gvEstPuntYAsist.SelectedIndex = CInt(e.CommandArgument)
            Case Else '"CmdEliminar", "CmdModificar"
                BindgvEstPuntYAsist()
        End Select
    End Sub

    Protected Sub gvEstPuntYAsist_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEstPuntYAsist.RowDataBound
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
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvEstPuntYAsist, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        BindPartes()
    End Sub
End Class
