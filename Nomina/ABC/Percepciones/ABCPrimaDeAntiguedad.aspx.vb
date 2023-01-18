Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class ABCPrimaDeAntiguedad
    Inherits System.Web.UI.Page
    Private Sub BindgvPercepciones(pVigentes As Boolean)
        Dim oPerc As New Percepcion
        Me.gvPercepciones.DataSource = oPerc.ObtenInfPrimaDeAntiguedad(pVigentes)
        Me.gvPercepciones.DataBind()
        If gvPercepciones.SelectedIndex <> -1 Then
            BindgvPercsHist(False)
        Else
            lblValoresHistoricos.Visible = False
            gvPercsHist.Visible = False
        End If
        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "PorcentajesClave223")
        gvPercepciones.Columns(12).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        gvPercepciones.Columns(13).Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub
    Private Sub BindgvPercsHist(pVigentes As Boolean, Optional ByVal pIdEmpFuncion As Byte = 0)
        Dim oPerc As New Percepcion
        Dim lblIdEmpFuncion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdEmpFuncion"), Label)
        Dim lblDescEmpFuncion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblDescEmpFuncion"), Label)
        lblValoresHistoricos.Text = "Valores históricos para empleados con carácter: " + lblDescEmpFuncion.Text
        lblValoresHistoricos.Visible = True
        pIdEmpFuncion = CByte(lblIdEmpFuncion.Text)
        Me.gvPercsHist.DataSource = oPerc.ObtenInfPrimaDeAntiguedad(pVigentes, pIdEmpFuncion)
        Me.gvPercsHist.DataBind()
        gvPercsHist.Visible = True
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            BindgvPercepciones(True)
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
                        ibNuevosValores.ToolTip = "Capturar nuevos valores para éste rango de años (No disponible)"
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
        'BindgvPercsHist(False)
        Me.gvPercepciones.Columns(11).Visible = False 'Nuevos valores
    End Sub

    Protected Sub gvPercepciones_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPercepciones.SelectedIndexChanged
        'Dim lblIdEmpFuncion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdEmpFuncion"), Label)
        'Dim lblDescEmpFuncion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblDescEmpFuncion"), Label)
        'lblValoresHistoricos.Text = "Valores históricos para empleados con carácter: " + lblDescEmpFuncion.Text
        'lblValoresHistoricos.Visible = True
        BindgvPercsHist(False)
    End Sub

    Protected Sub gvPercsHist_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPercsHist.SelectedIndexChanged

    End Sub

    Protected Sub ibNuevosValores_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim i As Integer
        Dim li, li2 As ListItem
        Dim lblLimiteInf As Label = CType(gvr.FindControl("lblLimiteInf"), Label)
        Dim lblLimiteSup As Label = CType(gvr.FindControl("lblLimiteSup"), Label)
        Dim lblPorcentaje As Label = CType(gvr.FindControl("lblPorcentaje"), Label)
        Dim oQna As New Quincenas
        gvPercepciones.SelectedIndex = gvr.RowIndex
        lblBarraTitulo.Text = "Capture los nuevos valores"
        Me.ddlLimInf.Items.Clear()
        Me.ddlLimSup.Items.Clear()
        For i = 1 To 99 Step 1
            li = New ListItem(i.ToString, i.ToString)
            li2 = New ListItem(i.ToString, i.ToString)
            Me.ddlLimInf.Items.Add(li)
            Me.ddlLimSup.Items.Add(li2)
        Next
        ddlLimInf.SelectedIndex = CInt(lblLimiteInf.Text) - 1
        ddlLimSup.SelectedIndex = CInt(lblLimiteSup.Text) - 1
        ddlLimInf.Enabled = False
        ddlLimSup.Enabled = False
        txtbxPorcentaje.Text = CDec(lblPorcentaje.Text.Replace("%", ""))
        With ddlInicio
            .DataSource = oQna.ObtenPosiblesParaInicioPercepcion()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
        End With
        lblFin.Visible = False
        ddlFin.Visible = False
        CVRangoQnas.Enabled = False
        Me.ibNuevosValores_MPE.Show()
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.ibNuevosValores_MPE.Hide()
        BindgvPercsHist(False)
    End Sub

    Protected Sub ibEditar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim i As Integer
        Dim li, li2 As ListItem
        Dim lblLimiteInf As Label = CType(gvr.FindControl("lblLimiteInf"), Label)
        Dim lblLimiteSup As Label = CType(gvr.FindControl("lblLimiteSup"), Label)
        Dim lblIdQnaIni As Label = CType(gvr.FindControl("lblIdQnaIni"), Label)
        Dim lblPorcentaje As Label = CType(gvr.FindControl("lblPorcentaje"), Label)
        Dim oQna As New Quincenas
        gvPercepciones.SelectedIndex = gvr.RowIndex
        lblBarraTitulo.Text = "Modifique los valores"
        Me.ddlLimInf.Items.Clear()
        Me.ddlLimSup.Items.Clear()
        For i = 1 To 99 Step 1
            li = New ListItem(i.ToString, i.ToString)
            li2 = New ListItem(i.ToString, i.ToString)
            Me.ddlLimInf.Items.Add(li)
            Me.ddlLimSup.Items.Add(li2)
        Next
        ddlLimInf.SelectedIndex = CInt(lblLimiteInf.Text) - 1
        ddlLimSup.SelectedIndex = CInt(lblLimiteSup.Text) - 1
        txtbxPorcentaje.Text = CDec(lblPorcentaje.Text.Replace("%", ""))
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
        Dim lblIdEmpFuncion As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdEmpFuncion"), Label)
        Dim lblLimiteInf As Label = CType(gvPercepciones.SelectedRow.FindControl("lblLimiteInf"), Label)
        Dim lblLimiteSup As Label = CType(gvPercepciones.SelectedRow.FindControl("lblLimiteSup"), Label)
        Dim lblIdQnaIni As Label = CType(gvPercepciones.SelectedRow.FindControl("lblIdQnaIni"), Label)
        Dim lblPorcentaje As Label = CType(gvPercepciones.SelectedRow.FindControl("lblPorcentaje"), Label)
        Dim vlTipoOperacion As Byte
        Dim oPerc As New Percepcion

        vlTipoOperacion = IIf(Left(Me.lblBarraTitulo.Text, 1) = "C", 1, 0)

        oPerc.InsActInfPrimaDeAntiguedad(CByte(Me.ddlLimInf.SelectedValue), CByte(ddlLimSup.SelectedValue), CDec(txtbxPorcentaje.Text), _
                                                CShort(ddlInicio.SelectedValue), vlTipoOperacion, CByte(lblLimiteInf.Text), CByte(lblLimiteSup.Text), _
                                                CDec(lblPorcentaje.Text.Replace("%", "")), CShort(lblIdQnaIni.Text), CByte(lblIdEmpFuncion.Text), _
                                                CType(Session("ArregloAuditoria"), String()))
        Me.ibNuevosValores_MPE.Hide()
        BindgvPercepciones(True)
    End Sub
End Class
