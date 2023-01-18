Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class ABC_Percs_BonoApoyoSupAcad
    Inherits System.Web.UI.Page
    Private Sub BindgvPercepciones(pVigentes As Boolean)
        Dim oPerc As New Percepcion
        Me.gvPercepciones.DataSource = oPerc.ObtenInfBonoApoyoSupAcademica(pVigentes)
        Me.gvPercepciones.DataBind()
        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "BonoApoyoSuperacionAcademica")
        gvPercepciones.Columns(8).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        gvPercepciones.Columns(9).Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub
    Private Sub BindgvPercsHist(pVigentes As Boolean)
        Dim oPerc As New Percepcion
        Me.gvPercsHist.DataSource = oPerc.ObtenInfBonoApoyoSupAcademica(pVigentes)
        Me.gvPercsHist.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            BindgvPercepciones(True)
            BindgvPercsHist(False)
        End If
    End Sub

    Protected Sub gvPercepciones_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvPercepciones.RowCancelingEdit
        Me.gvPercepciones.Columns(0).Visible = True 'Select
        Me.gvPercepciones.SelectedIndex = e.RowIndex
        Me.gvPercepciones.EditIndex = -1
        BindgvPercepciones(True)
        BindgvPercsHist(False)
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
                    Else
                        ibNuevosValores.Enabled = False
                        ibNuevosValores.ImageUrl = "~/Imagenes/Add2Disabled.png"
                        ibNuevosValores.ToolTip = "Capturar nuevos valores para éste rango de horas (No disponible)"
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

    Protected Sub gvPercepciones_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvPercepciones.RowEditing
        Me.gvPercepciones.Columns(0).Visible = False 'Select
        Me.gvPercepciones.SelectedIndex = -1
        Me.gvPercepciones.EditIndex = e.NewEditIndex
        BindgvPercepciones(True)
        BindgvPercsHist(False)
        Me.gvPercepciones.Columns(9).Visible = False 'Nuevos valores
    End Sub

    Protected Sub gvPercepciones_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPercepciones.SelectedIndexChanged

    End Sub

    Protected Sub gvPercsHist_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPercsHist.SelectedIndexChanged

    End Sub

    Protected Sub ibNuevosValores_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim i As Integer
        Dim li, li2 As ListItem
        Dim lblHrsLimInf As Label = CType(gvr.FindControl("lblHrsLimInf"), Label)
        Dim lblHrsLimSup As Label = CType(gvr.FindControl("lblHrsLimSup"), Label)
        Dim lblImporteAnual As Label = CType(gvr.FindControl("lblImporteAnual"), Label)
        Dim oQna As New Quincenas
        gvPercepciones.SelectedIndex = gvr.RowIndex
        lblBarraTitulo.Text = "Capture los nuevos valores"
        Me.ddlHrsLimInf.Items.Clear()
        Me.ddlHrsLimSup.Items.Clear()
        For i = 1 To 40 Step 1
            li = New ListItem(i.ToString, i.ToString)
            li2 = New ListItem(i.ToString, i.ToString)
            Me.ddlHrsLimInf.Items.Add(li)
            Me.ddlHrsLimSup.Items.Add(li2)
        Next
        ddlHrsLimInf.SelectedIndex = CInt(lblHrsLimInf.Text) - 1
        ddlHrsLimSup.SelectedIndex = CInt(lblHrsLimSup.Text) - 1
        ddlHrsLimInf.Enabled = False
        ddlHrsLimSup.Enabled = False
        txtbxImporteAnual.Text = CDec(lblImporteAnual.Text)
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

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.ibNuevosValores_MPE.Hide()
    End Sub

    Protected Sub ibEditar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim i As Integer
        Dim li, li2 As ListItem
        Dim lblHrsLimInf As Label = CType(gvr.FindControl("lblHrsLimInf"), Label)
        Dim lblHrsLimSup As Label = CType(gvr.FindControl("lblHrsLimSup"), Label)
        Dim lblIdQnaIni As Label = CType(gvr.FindControl("lblIdQnaIni"), Label)
        Dim lblImporteAnual As Label = CType(gvr.FindControl("lblImporteAnual"), Label)
        Dim oQna As New Quincenas
        gvPercepciones.SelectedIndex = gvr.RowIndex
        lblBarraTitulo.Text = "Modifique los valores"
        Me.ddlHrsLimInf.Items.Clear()
        Me.ddlHrsLimSup.Items.Clear()
        For i = 1 To 40 Step 1
            li = New ListItem(i.ToString, i.ToString)
            li2 = New ListItem(i.ToString, i.ToString)
            Me.ddlHrsLimInf.Items.Add(li)
            Me.ddlHrsLimSup.Items.Add(li2)
        Next
        ddlHrsLimInf.SelectedIndex = CInt(lblHrsLimInf.Text) - 1
        ddlHrsLimSup.SelectedIndex = CInt(lblHrsLimSup.Text) - 1
        txtbxImporteAnual.Text = CDec(lblImporteAnual.Text)
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

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim lblHrsLimInf As Label = CType(gvPercepciones.SelectedRow.FindControl("lblHrsLimInf"), Label)
        Dim lblHrsLimSup As Label = CType(gvPercepciones.SelectedRow.FindControl("lblHrsLimSup"), Label)
        Dim lblIdQnaIni As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdQnaIni"), Label)
        Dim lblImporteAnual As Label = CType(gvPercepciones.SelectedRow.FindControl("lblImporteAnual"), Label)
        Dim vlTipoOperacion As Byte
        Dim oPerc As New Percepcion

        vlTipoOperacion = IIf(Left(Me.lblBarraTitulo.Text, 1) = "C", 1, 0)

        oPerc.InsActInfBonoApoyoSupAcademica(CByte(Me.ddlHrsLimInf.SelectedValue), CByte(ddlHrsLimSup.SelectedValue), CDec(txtbxImporteAnual.Text), _
                                                CShort(ddlInicio.SelectedValue), vlTipoOperacion, CByte(lblHrsLimInf.Text), CByte(lblHrsLimSup.Text), _
                                                CDec(lblImporteAnual.Text), CShort(lblIdQnaIni.Text), CType(Session("ArregloAuditoria"), String()))
        BindgvPercepciones(True)
        BindgvPercsHist(False)
        Me.ibNuevosValores_MPE.Hide()
    End Sub
End Class
