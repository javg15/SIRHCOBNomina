Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class ABC_Percs_EstDeAnt
    Inherits System.Web.UI.Page
    Private Sub BindgvPercepciones(pVigentes As Boolean)
        Dim oPerc As New Percepcion
        Me.gvPercepciones.DataSource = oPerc.ObtenInfEstimuloAntiguedad(pVigentes)
        Me.gvPercepciones.DataBind()
        If gvPercepciones.SelectedIndex <> -1 Then
            BindgvPercsHist(False)
        Else
            lblValoresHistoricos.Visible = False
            gvPercsHist.Visible = False
        End If
        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "TblEstimuloAntiguedad")
        gvPercepciones.Columns(10).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        gvPercepciones.Columns(11).Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub
    Private Sub BindgvPercsHist(pVigentes As Boolean, Optional ByVal pIdEmpFuncion As Byte = 0)
        Dim oPerc As New Percepcion
        Dim lblIdEmpFuncion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdEmpFuncion"), Label)
        Dim lblDescEmpFuncion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblDescEmpFuncion"), Label)
        lblValoresHistoricos.Text = "Valores históricos para empleados con carácter: " + lblDescEmpFuncion.Text
        lblValoresHistoricos.Visible = True
        pIdEmpFuncion = CByte(lblIdEmpFuncion.Text)
        Me.gvPercsHist.DataSource = oPerc.ObtenInfEstimuloAntiguedad(pVigentes, pIdEmpFuncion)
        Me.gvPercsHist.DataBind()
        gvPercsHist.Visible = True
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            BindgvPercepciones(True)
            'BindgvPercsHist(False)
        End If
    End Sub

    Protected Sub gvPercepciones_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvPercepciones.RowCancelingEdit
        Me.gvPercepciones.Columns(0).Visible = True 'Select
        Me.gvPercepciones.SelectedIndex = e.RowIndex
        Me.gvPercepciones.EditIndex = -1
        BindgvPercepciones(True)
        'BindgvPercsHist(False)
    End Sub

    Protected Sub gvPercepciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercepciones.RowDataBound
        Dim lblIdPercepcion As Label = CType(e.Row.FindControl("lblIdPercepcion"), Label)
        Dim lblIdQnaIni As Label = CType(e.Row.FindControl("lblIdQnaIni"), Label)
        Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
        Dim ibNuevosValores As ImageButton = CType(e.Row.FindControl("ibNuevosValores"), ImageButton)

        Dim oPerc As New Percepcion

        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                If oPerc.CveDeEstDeAntFueUsadaEnPeriodoX(CShort(lblIdPercepcion.Text), CShort(lblIdQnaIni.Text)) Then
                    ibEditar.Enabled = False
                    ibEditar.ToolTip = "Modificar valores para éste registro (No disponible)"
                    ibEditar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                Else
                    ibNuevosValores.Enabled = False
                    ibNuevosValores.ImageUrl = "~/Imagenes/Add2Disabled.png"
                    ibNuevosValores.ToolTip = "Capturar nuevos valores a partir de éste registro (No disponible)"
                End If
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub
    Protected Sub gvPercepcionesHistoria_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercsHist.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvPercepciones_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvPercepciones.RowEditing
        Me.gvPercepciones.Columns(0).Visible = False 'Select
        Me.gvPercepciones.SelectedIndex = -1
        Me.gvPercepciones.EditIndex = e.NewEditIndex
        BindgvPercepciones(True)
        'BindgvPercsHist(False)
        Me.gvPercepciones.Columns(11).Visible = False 'Nuevos valores
    End Sub

    Protected Sub gvPercepciones_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPercepciones.SelectedIndexChanged
        BindgvPercsHist(False)
    End Sub

    Protected Sub gvPercsHist_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPercsHist.SelectedIndexChanged

    End Sub

    Protected Sub ibNuevosValores_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblDescEmpFuncionAux As Label = CType(gvr.FindControl("lblDescEmpFuncion"), Label)
        Dim lblNumAnios As Label = CType(gvr.FindControl("lblNumAnios"), Label)
        Dim lblDiasAPagar As Label = CType(gvr.FindControl("lblDiasAPagar"), Label)
        Dim lblIdQnaIni As Label = CType(gvr.FindControl("lblIdQnaIni"), Label)
        Dim oQna As New Quincenas
        gvPercepciones.SelectedIndex = gvr.RowIndex
        lblBarraTitulo.Text = "Capture los nuevos valores"
        lblDescEmpFuncion.Text = lblDescEmpFuncionAux.Text
        txtbxAniosAnt.Text = lblNumAnios.Text
        txtbxDiasAPagar.Text = lblDiasAPagar.Text
        With ddlInicio
            .DataSource = oQna.ObtenPosiblesParaInicioPercepcion()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            '.SelectedValue = lblIdQnaIni.Text
        End With
        lblFin.Visible = False
        ddlFin.Visible = False
        CvRangoQnas.Enabled = False
        Me.ibNuevosValores_MPE.Show()
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.ibNuevosValores_MPE.Hide()
        BindgvPercsHist(False)
    End Sub

    Protected Sub ibEditar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblDescEmpFuncionAux As Label = CType(gvr.FindControl("lblDescEmpFuncion"), Label)
        Dim lblNumAnios As Label = CType(gvr.FindControl("lblNumAnios"), Label)
        Dim lblDiasAPagar As Label = CType(gvr.FindControl("lblDiasAPagar"), Label)
        Dim lblIdQnaIni As Label = CType(gvr.FindControl("lblIdQnaIni"), Label)
        Dim lblInicio As Label = CType(gvr.FindControl("lblInicio"), Label)
        Dim oQna As New Quincenas
        gvPercepciones.SelectedIndex = gvr.RowIndex
        lblBarraTitulo.Text = "Modifique los valores"
        lblDescEmpFuncion.Text = lblDescEmpFuncionAux.Text
        txtbxAniosAnt.Text = lblNumAnios.Text
        txtbxDiasAPagar.Text = lblDiasAPagar.Text
        With ddlInicio
            .DataSource = oQna.ObtenPosiblesParaInicioPercepcion()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            Try
                .SelectedValue = lblIdQnaIni.Text
            Catch
                .Items.Add(New ListItem(lblInicio.Text, lblIdQnaIni.Text))
                .SelectedValue = lblIdQnaIni.Text
            End Try
        End With
        lblFin.Visible = False
        ddlFin.Visible = False
        CvRangoQnas.Enabled = False
        Me.ibNuevosValores_MPE.Show()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Me.ibNuevosValores_MPE.Hide()
        Dim lblIdPercepcion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdPercepcion"), Label)
        Dim lblIdEmpFuncion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdEmpFuncion"), Label)
        Dim lblNumAnios As Label = CType(gvPercepciones.SelectedRow.FindControl("lblNumAnios"), Label)
        Dim lblIdQnaIni As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdQnaIni"), Label)
        Dim lblDiasAPagar As Label = CType(gvPercepciones.SelectedRow.FindControl("lblDiasAPagar"), Label)
        Dim vlTipoOperacion As Byte
        Dim oPerc As New Percepcion

        vlTipoOperacion = IIf(Left(Me.lblBarraTitulo.Text, 1) = "C", 1, 0)

        oPerc.InsActInfEstimuloAntiguedad(CByte(lblIdPercepcion.Text), CByte(txtbxAniosAnt.Text), CByte(lblIdEmpFuncion.Text), CDec(txtbxDiasAPagar.Text), _
                                               CShort(ddlInicio.SelectedValue), vlTipoOperacion, CByte(lblNumAnios.Text), CByte(lblDiasAPagar.Text), _
                                                CShort(lblIdQnaIni.Text), CType(Session("ArregloAuditoria"), String()))
        BindgvPercepciones(True)
    End Sub
End Class
