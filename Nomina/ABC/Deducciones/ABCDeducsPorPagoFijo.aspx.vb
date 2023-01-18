Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class ABCDeducsPorPagoFijo
    Inherits System.Web.UI.Page
    Private Sub BindgvConceptos()
        Dim lblIdConcepto As Label

        Dim oDeduc As New Deduccion
        Me.gvConceptos.DataSource = oDeduc.ObtenPorPagoFijo()
        Me.gvConceptos.DataBind()

        If gvConceptos.SelectedIndex <> -1 Then
            lblIdConcepto = CType(gvConceptos.SelectedRow.FindControl("lblIdConcepto"), Label)
            BindgvConceptosHist(CShort(lblIdConcepto.Text))
            lblValoresHistoricos.Visible = True
            gvConceptosHist.Visible = True
        End If

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "DeduccionesPorPagoFijo")
        gvConceptos.Columns(8).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        gvConceptos.Columns(9).Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub
    Private Sub BindgvConceptosHist(ByVal pIdConcepto As Short)
        Dim oDeduc As New Deduccion
        Me.gvConceptosHist.DataSource = oDeduc.ObtenPorPagoFijoHistoria(pIdConcepto)
        Me.gvConceptosHist.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            BindgvConceptos()
            'BindgvPercsHist(False)
        End If
    End Sub

    Protected Sub gvConceptos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvConceptos.RowDataBound
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
                        ibEditar.Visible = False
                        ibEditar.ToolTip = "Modificar valores (No disponible)"
                        ibEditar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                        ibNuevosValores.Visible = True
                    Else
                        ibEditar.Visible = True
                        ibNuevosValores.Visible = False
                    End If
                End With
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub
    Protected Sub gvPercepcionesHistoria_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvConceptosHist.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvConceptos_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvConceptos.RowEditing
        Me.gvConceptos.Columns(0).Visible = False 'Select
        Me.gvConceptos.SelectedIndex = -1
        Me.gvConceptos.EditIndex = e.NewEditIndex
        BindgvConceptos()
        'BindgvPercsHist(False)
        Me.gvConceptos.Columns(9).Visible = False 'Nuevos valores
    End Sub

    Protected Sub gvConceptos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConceptos.SelectedIndexChanged
        Dim lblIdConcepto As Label = CType(gvConceptos.SelectedRow.FindControl("lblIdConcepto"), Label)
        BindgvConceptosHist(CShort(lblIdConcepto.Text))
        lblValoresHistoricos.Visible = True
        gvConceptosHist.Visible = True
        'BindgvPercsHist(False)
    End Sub

    Protected Sub gvPercsHist_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConceptosHist.SelectedIndexChanged

    End Sub

    Protected Sub ibNuevosValores_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblImporte As Label = CType(gvr.FindControl("lblImporte"), Label)
        Dim oQna As New Quincenas
        gvConceptos.SelectedIndex = gvr.RowIndex
        lblBarraTitulo.Text = "Capture los nuevos valores"
        txtbxImporte.Text = CDec(lblImporte.Text)
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
        Dim lblImporte As Label = CType(gvr.FindControl("lblImporte"), Label)
        Dim oQna As New Quincenas
        gvConceptos.SelectedIndex = gvr.RowIndex
        lblBarraTitulo.Text = "Modifique los valores"
        txtbxImporte.Text = CDec(lblImporte.Text)
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
        Dim lblIdConcepto As Label = CType(gvConceptos.SelectedRow.FindControl("lblIdConcepto"), Label)
        Dim lblIdQnaIni As Label = CType(gvConceptos.SelectedRow.FindControl("lblIdQnaIni"), Label)
        Dim lblImporte As Label = CType(gvConceptos.SelectedRow.FindControl("lblImporte"), Label)
        Dim vlTipoOperacion As Byte
        Dim oDeduc As New Deduccion

        vlTipoOperacion = IIf(Left(Me.lblBarraTitulo.Text, 1) = "C", 1, 0)

        oDeduc.InsActInfDeducPorPagoFijo(CShort(lblIdConcepto.Text), CDec(txtbxImporte.Text), CShort(ddlInicio.SelectedValue), _
                                       vlTipoOperacion, CDec(lblImporte.Text), CShort(lblIdQnaIni.Text), CType(Session("ArregloAuditoria"), String()))
        BindgvConceptos()
        Me.ibNuevosValores_MPE.Hide()
    End Sub

    Protected Sub gvConceptos_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvConceptos.RowCancelingEdit
        Me.gvConceptos.Columns(0).Visible = True 'Select
        Me.gvConceptos.SelectedIndex = e.RowIndex
        Me.gvConceptos.EditIndex = -1
        BindgvConceptos()
        'BindgvPercsHist(False)
    End Sub
End Class
