Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class ABCSalariosMinimos
    Inherits System.Web.UI.Page
    Private Sub BindgvSMG()
        Dim oEjerFisc As New EjercicioFiscal
        Me.gvSMG.DataSource = oEjerFisc.ObtenSalariosMinimosVigentes()
        Me.gvSMG.DataBind()
        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "SMG")
        gvSMG.Columns(8).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        gvSMG.Columns(9).Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub
    Private Sub BindgvSMGHist(pIdZonaEco2 As Byte)
        Dim oEjerFisc As New EjercicioFiscal
        Me.gvSMGHist.DataSource = oEjerFisc.ObtenHistSalariosMinimosDadaUnaZonaEco(pIdZonaEco2)
        Me.gvSMGHist.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            BindgvSMG()
            'BindgvSMGHist()
        End If
    End Sub

    Protected Sub gvSMG_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvSMG.RowCancelingEdit
        Me.gvSMG.Columns(0).Visible = True 'Select
        Me.gvSMG.SelectedIndex = e.RowIndex
        Me.gvSMG.EditIndex = -1
        BindgvSMG()
        If e.RowIndex <> -1 Then
            Dim lblIdZonaEco2 As Label = CType(gvSMG.SelectedRow.FindControl("lblIdZonaEco2"), Label)
            Dim lblLetraZonaEco2 As Label = CType(gvSMG.SelectedRow.FindControl("lblLetraZonaEco2"), Label)
            lblValoresHistoricos.Text = "Valores históricos para la zona: " + lblLetraZonaEco2.Text
            lblValoresHistoricos.Visible = True
            BindgvSMGHist(CByte(lblIdZonaEco2.Text))
        End If
    End Sub

    Protected Sub gvSMG_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSMG.RowDataBound
        Dim lblIdQnaIni As Label = CType(e.Row.FindControl("lblIdQnaIni"), Label)
        'Dim lblImporteSMG As Label = CType(e.Row.FindControl("lblImporteSMG"), Label)
        Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
        Dim ibNuevosValores As ImageButton = CType(e.Row.FindControl("ibNuevosValores"), ImageButton)
        Dim oQna As New Quincenas
        Dim ddlQnas As New DropDownList
        Dim li As ListItem
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                With ddlQnas
                    .DataSource = oQna.ObtenPosiblesParaIniSalariosMinimos()
                    .DataTextField = "Quincena"
                    .DataValueField = "IdQuincena"
                    .DataBind()
                    li = ddlQnas.Items.FindByValue(lblIdQnaIni.Text)
                    If li Is Nothing Then
                        ibEditar.Enabled = False
                        ibEditar.ToolTip = "Modificar valores (No disponible)"
                        ibEditar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    End If
                    If lblIdQnaIni.Text = "0" Then
                        ibEditar.Visible = False
                        ibNuevosValores.Visible = False
                    End If
                End With
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub
    Protected Sub gvSMGHist_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSMGHist.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvSMG_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvSMG.RowEditing
        Me.gvSMG.Columns(0).Visible = False 'Select
        Me.gvSMG.SelectedIndex = -1
        Me.gvSMG.EditIndex = e.NewEditIndex
        BindgvSMG()
        If e.NewEditIndex <> -1 Then
            Dim lblIdZonaEco2 As Label = CType(gvSMG.SelectedRow.FindControl("lblIdZonaEco2"), Label)
            Dim lblLetraZonaEco2 As Label = CType(gvSMG.SelectedRow.FindControl("lblLetraZonaEco2"), Label)
            lblValoresHistoricos.Text = "Valores históricos para la zona: " + lblLetraZonaEco2.Text
            lblValoresHistoricos.Visible = True
            BindgvSMGHist(CByte(lblIdZonaEco2.Text))
        End If
        'BindgvSMGHist(False)
        Me.gvSMG.Columns(9).Visible = False 'Nuevos valores
    End Sub

    Protected Sub gvSMG_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvSMG.SelectedIndexChanged
        Dim lblIdZonaEco2 As Label = CType(gvSMG.SelectedRow.FindControl("lblIdZonaEco2"), Label)
        Dim lblLetraZonaEco2 As Label = CType(gvSMG.SelectedRow.FindControl("lblLetraZonaEco2"), Label)
        lblValoresHistoricos.Text = "Valores históricos para la zona: " + lblLetraZonaEco2.Text
        lblValoresHistoricos.Visible = True
        BindgvSMGHist(CByte(lblIdZonaEco2.Text))
    End Sub

    Protected Sub gvSMGHist_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvSMGHist.SelectedIndexChanged

    End Sub

    Protected Sub ibNuevosValores_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblIdZonaEco2 As Label = CType(gvr.FindControl("lblIdZonaEco2"), Label)
        Dim lblLetraZonaEco2 As Label = CType(gvr.FindControl("lblLetraZonaEco2"), Label)
        Dim lblImporteSMG As Label = CType(gvr.FindControl("lblImporteSMG"), Label)
        Dim oQna As New Quincenas
        gvSMG.SelectedIndex = gvr.RowIndex

        lblValoresHistoricos.Text = "Valores históricos para la zona: " + lblLetraZonaEco2.Text
        lblValoresHistoricos.Visible = True
        BindgvSMGHist(CByte(lblIdZonaEco2.Text))

        lblBarraTitulo.Text = "Capture los nuevos valores"
        lblZonaEcoValor.Text = lblLetraZonaEco2.Text
        txtbxImporteSMG.Text = CDec(lblImporteSMG.Text)
        With ddlInicio
            .DataSource = oQna.ObtenPosiblesParaIniSalariosMinimos()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
        End With
        lblFin.Visible = False
        ddlFin.Visible = False
        CvRangoQnas.Enabled = False
        Me.ibNuevosValores_MPE.Show()
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.ibNuevosValores_MPE.Hide()
    End Sub

    Protected Sub ibEditar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblIdZonaEco2 As Label = CType(gvr.FindControl("lblIdZonaEco2"), Label)
        Dim lblLetraZonaEco2 As Label = CType(gvr.FindControl("lblLetraZonaEco2"), Label)
        Dim lblIdQnaIni As Label = CType(gvr.FindControl("lblIdQnaIni"), Label)
        Dim lblImporteSMG As Label = CType(gvr.FindControl("lblImporteSMG"), Label)
        Dim oQna As New Quincenas
        gvSMG.SelectedIndex = gvr.RowIndex

        lblValoresHistoricos.Text = "Valores históricos para la zona: " + lblLetraZonaEco2.Text
        lblValoresHistoricos.Visible = True
        BindgvSMGHist(CByte(lblIdZonaEco2.Text))

        lblBarraTitulo.Text = "Modifique los valores"
        lblZonaEcoValor.Text = lblLetraZonaEco2.Text
        txtbxImporteSMG.Text = CDec(lblImporteSMG.Text)
        With ddlInicio
            .DataSource = oQna.ObtenPosiblesParaIniSalariosMinimos()
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

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim lblIdZonaEco2 As Label = CType(gvSMG.SelectedRow.FindControl("lblIdZonaEco2"), Label)
        Dim lblLetraZonaEco2 As Label = CType(gvSMG.SelectedRow.FindControl("lblLetraZonaEco2"), Label)
        Dim lblIdQnaIni As Label = CType(gvSMG.SelectedRow.FindControl("lblIdQnaIni"), Label)
        Dim lblIdQnaFin As Label = CType(gvSMG.SelectedRow.FindControl("lblIdQnaFin"), Label)
        Dim lblImporteSMG As Label = CType(gvSMG.SelectedRow.FindControl("lblImporteSMG"), Label)
        Dim vlTipoOperacion As Byte
        Dim oEjerFisc As New EjercicioFiscal

        vlTipoOperacion = IIf(Left(Me.lblBarraTitulo.Text, 1) = "C", 1, 0)

        oEjerFisc.InsActInfSalariosMinimos(CByte(lblIdZonaEco2.Text), CDec(txtbxImporteSMG.Text), CShort(ddlInicio.SelectedValue), _
                                           vlTipoOperacion, CDec(lblImporteSMG.Text), CShort(lblIdQnaIni.Text), _
                                           CShort(lblIdQnaFin.Text), CType(Session("ArregloAuditoria"), String()))
        BindgvSMG()

        lblValoresHistoricos.Text = "Valores históricos para la zona: " + lblLetraZonaEco2.Text
        lblValoresHistoricos.Visible = True
        BindgvSMGHist(CByte(lblIdZonaEco2.Text))

        Me.ibNuevosValores_MPE.Hide()
    End Sub
End Class
