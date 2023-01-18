Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class ABCPercsPorPagoFijo
    Inherits System.Web.UI.Page
    Private Sub BindgvPercepciones()
        Dim lblIdPercepcion As Label
        Dim lblIdEmpFuncion As Label

        Dim oPerc As New Percepcion
        Me.gvPercepciones.DataSource = oPerc.ObtenPorPagoFijo()
        Me.gvPercepciones.DataBind()

        If gvPercepciones.SelectedIndex <> -1 Then
            lblIdPercepcion = CType(gvPercepciones.SelectedRow.FindControl("lblIdPercepcion"), Label)
            lblIdEmpFuncion = CType(gvPercepciones.SelectedRow.FindControl("lblIdEmpFuncion"), Label)
            BindgvPercsHist(CShort(lblIdPercepcion.Text), CByte(lblIdEmpFuncion.Text))
            lblValoresHistoricos.Visible = True
            gvPercsHist.Visible = True
        End If

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "PercepcionesPorPagoFijo")
        gvPercepciones.Columns(10).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        gvPercepciones.Columns(11).Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub
    Private Sub BindgvPercsHist(ByVal pIdPercepcion As Short, ByVal pIdEmpFuncion As Byte)
        Dim oPerc As New Percepcion
        Me.gvPercsHist.DataSource = oPerc.ObtenPorPagoFijoHistoria(pIdPercepcion, pIdEmpFuncion)
        Me.gvPercsHist.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            BindgvPercepciones()
            'BindgvPercsHist(False)
        End If
    End Sub

    Protected Sub gvPercepciones_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvPercepciones.RowCancelingEdit
        Me.gvPercepciones.Columns(0).Visible = True 'Select
        Me.gvPercepciones.SelectedIndex = e.RowIndex
        Me.gvPercepciones.EditIndex = -1
        BindgvPercepciones()
        'BindgvPercsHist(False)
    End Sub

    Protected Sub gvPercepciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercepciones.RowDataBound
        Dim lblIdQnaIni As Label = CType(e.Row.FindControl("lblIdQnaIni"), Label)
        Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
        Dim ibNuevosValores As ImageButton = CType(e.Row.FindControl("ibNuevosValores"), ImageButton)
        Dim oQna As New Quincenas
        Dim ddlQnas As New DropDownList
        Dim li As ListItem
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                With ddlQnas
                    .DataSource = oQna.ObtenPosiblesParaInicioPercepcion()
                    .DataTextField = "Quincena"
                    .DataValueField = "IdQuincena"
                    .DataBind()
                    li = ddlQnas.Items.FindByValue(lblIdQnaIni.Text)
                    If li Is Nothing Then
                        ibEditar.Enabled = False
                        ibEditar.ToolTip = "Modificar valores (No disponible)"
                        ibEditar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                        ibNuevosValores.Visible = True
                    Else
                        ibEditar.Enabled = True
                        ibNuevosValores.Visible = False
                    End If
                End With
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

    Protected Sub gvPercepciones_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvPercepciones.RowEditing
        Me.gvPercepciones.Columns(0).Visible = False 'Select
        Me.gvPercepciones.SelectedIndex = -1
        Me.gvPercepciones.EditIndex = e.NewEditIndex
        BindgvPercepciones()
        'BindgvPercsHist(False)
        Me.gvPercepciones.Columns(9).Visible = False 'Nuevos valores
    End Sub

    Protected Sub gvPercepciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvPercepciones.SelectedIndexChanged
        Dim lblIdPercepcion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdPercepcion"), Label)
        Dim lblIdEmpFuncion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdEmpFuncion"), Label)
        BindgvPercsHist(CShort(lblIdPercepcion.Text), CByte(lblIdEmpFuncion.Text))
        lblValoresHistoricos.Visible = True
        gvPercsHist.Visible = True
        'BindgvPercsHist(False)
    End Sub

    Protected Sub gvPercsHist_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvPercsHist.SelectedIndexChanged

    End Sub

    Protected Sub ibNuevosValores_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblImpPerc As Label = CType(gvr.FindControl("lblImpPerc"), Label)
        Dim oQna As New Quincenas
        gvPercepciones.SelectedIndex = gvr.RowIndex
        lblBarraTitulo.Text = "Capture los nuevos valores"
        txtbxImporte.Text = CDec(lblImpPerc.Text)
        With ddlInicio
            .DataSource = oQna.ObtenPosiblesParaInicioPercepcion()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
        End With
        lblFin.Visible = False
        ddlFin.Visible = False
        CvRangoQnas.Enabled = False
        Me.ibNuevosValores_MPE.Show()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.ibNuevosValores_MPE.Hide()
    End Sub

    Protected Sub ibEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblIdQnaIni As Label = CType(gvr.FindControl("lblIdQnaIni"), Label)
        Dim lblImpPerc As Label = CType(gvr.FindControl("lblImpPerc"), Label)
        Dim oQna As New Quincenas
        gvPercepciones.SelectedIndex = gvr.RowIndex
        lblBarraTitulo.Text = "Modifique los valores"
        txtbxImporte.Text = CDec(lblImpPerc.Text)
        With ddlInicio
            .DataSource = oQna.ObtenPosiblesParaInicioPercepcion()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            .SelectedValue = lblIdQnaIni.Text
        End With
        lblFin.Visible = False
        ddlFin.Visible = False
        CvRangoQnas.Enabled = False
        Me.ibNuevosValores_MPE.Show()
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim lblIdPercepcion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdPercepcion"), Label)
        Dim lblIdQnaIni As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdQnaIni"), Label)
        Dim lblImpPerc As Label = CType(gvPercepciones.SelectedRow.FindControl("lblImpPerc"), Label)
        Dim lblIdEmpFuncion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdEmpFuncion"), Label)
        Dim vlTipoOperacion As Byte
        Dim oPerc As New Percepcion

        vlTipoOperacion = IIf(Left(Me.lblBarraTitulo.Text, 1) = "C", 1, 0)

        oPerc.InsActInfPercPorPagoFijo(CShort(lblIdPercepcion.Text), CDec(txtbxImporte.Text), CShort(ddlInicio.SelectedValue), _
                                       vlTipoOperacion, CDec(lblImpPerc.Text), CShort(lblIdQnaIni.Text), _
                                       CByte(lblIdEmpFuncion.Text), CType(Session("ArregloAuditoria"), String()))
        BindgvPercepciones()
        Me.ibNuevosValores_MPE.Hide()
    End Sub
End Class
