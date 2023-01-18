Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Partial Class ABC_Recibos_AdmonDetallesRecibosBAK
    Inherits System.Web.UI.Page
    Private Sub DeterminaObservaciones()
        Dim oRecibo As New Recibos

        gvObservs.DataSource = oRecibo.DeterminaObservaciones(CShort(Request.Params("IdRecibo")))
        gvObservs.DataBind()

        lblObservaciones.Visible = gvObservs.Rows.Count > 0
        gvObservs.Visible = gvObservs.Rows.Count > 0
    End Sub
    Private Sub ValidaOperacion(Optional ByVal TipoOperacion As Byte = 1)
        'Código de validación
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        Dim drUsr As DataRow
        Dim oUsr As New Usuario

        dsValida = _DataCOBAEV.setDataSetErrores()
        oUsr.Login = Session("Login")
        drUsr = oUsr.ObtenerPorLogin()

        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            .TipoOperacion = TipoOperacion
            .IdRecibo = CShort(Request.Params("IdRecibo"))
            .IdUsuario = CInt(drUsr("IdUsuario"))
            If Not .ValidaPaginasOperacion(dsValida) Then
                'If TipoOperacion <> 5 Then
                Session.Add("dsValida", dsValida)
                Response.Redirect("~/ErroresPagina.aspx")
                'Else
                '    gvObservs.DataSource = dsValida
                '    gvObservs.DataBind()
                '    gvObservs.Visible = gvObservs.Rows.Count > 0
                'End If
            Else
                Session.Remove("dsValida")
            End If
        End With
        'Código de validación
    End Sub
    Private Sub BindRecibo()
        Try
            Dim oRecibo As New Recibos
            Dim dsRecibo As DataSet
            Dim lblTotPercs, lblTotPercsRetro, lblTotPercsAgui, lblTotPercsGrav As Label
            Dim lblTotDeducs, lblTotDeducsRetro, lblTotDeducsAgui, lblTotDeducsGrav As Label

            'Determinamos posibles observaciones sobre claves que pueden ser necesarias incluir en el recibo.
            'Las observaciones son meramente informativas para ayduar al usuario que realiza el recibo a no omitir
            'alguna clave o poner alguna clave de más
            DeterminaObservaciones()

            dsRecibo = oRecibo.ConsultaImportes(CShort(Request.Params("IdRecibo")))

            Me.gvPercepciones.DataSource = dsRecibo.Tables(1)
            Me.gvDeducciones.DataSource = dsRecibo.Tables(2)
            Me.dvTotalPerc.DataSource = dsRecibo.Tables(0)
            Me.dvTotalDeduc.DataSource = dsRecibo.Tables(0)
            Me.dvNetoPagar.DataSource = dsRecibo.Tables(0)
            Me.gvDatosComplem.DataSource = dsRecibo.Tables(3)

            Me.gvPercepciones.DataBind()
            Me.gvDeducciones.DataBind()
            Me.dvTotalPerc.DataBind()
            Me.dvTotalDeduc.DataBind()
            Me.dvNetoPagar.DataBind()
            Me.gvDatosComplem.DataBind()

            If dsRecibo.Tables(1).Rows.Count > 0 Then
                lblTotPercs = CType(Me.gvPercepciones.FooterRow.FindControl("lblTotPercs"), Label)
                lblTotPercs.Text = Format(dsRecibo.Tables(1).Compute("Sum(Importe)", ""), "$ ###,###,##0.00")
                lblTotPercsRetro = CType(Me.gvPercepciones.FooterRow.FindControl("lblTotPercsRetro"), Label)
                lblTotPercsRetro.Text = Format(dsRecibo.Tables(1).Compute("Sum(ImporteParaRetroactivo)", ""), "$ ###,###,##0.00")
                lblTotPercsAgui = CType(Me.gvPercepciones.FooterRow.FindControl("lblTotPercsAgui"), Label)
                lblTotPercsAgui.Text = Format(dsRecibo.Tables(1).Compute("Sum(ImporteParaAguinaldo)", ""), "$ ###,###,##0.00")
                lblTotPercsGrav = CType(Me.gvPercepciones.FooterRow.FindControl("lblTotPercsGrav"), Label)
                lblTotPercsGrav.Text = Format(dsRecibo.Tables(1).Compute("Sum(ImporteGravado)", ""), "$ ###,###,##0.00")
            End If

            If dsRecibo.Tables(2).Rows.Count > 0 Then
                lblTotDeducs = CType(Me.gvDeducciones.FooterRow.FindControl("lblTotDeducs"), Label)
                lblTotDeducs.Text = Format(dsRecibo.Tables(2).Compute("Sum(Importe)", ""), "$ ###,###,##0.00")
                lblTotDeducsRetro = CType(Me.gvDeducciones.FooterRow.FindControl("lblTotDeducsRetro"), Label)
                lblTotDeducsRetro.Text = Format(dsRecibo.Tables(2).Compute("Sum(ImporteParaRetroactivo)", ""), "$ ###,###,##0.00")
                lblTotDeducsAgui = CType(Me.gvDeducciones.FooterRow.FindControl("lblTotDeducsAgui"), Label)
                lblTotDeducsAgui.Text = Format(dsRecibo.Tables(2).Compute("Sum(ImporteParaAguinaldo)", ""), "$ ###,###,##0.00")
                lblTotDeducsGrav = CType(Me.gvDeducciones.FooterRow.FindControl("lblTotDeducsGrav"), Label)
                lblTotDeducsGrav.Text = Format(dsRecibo.Tables(2).Compute("Sum(ImporteGravado)", ""), "$ ###,###,##0.00")
            End If

        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Me.MultiView1.SetActiveView(Me.View1)
            Dim drRecibo As DataRow
            Dim oRecibo As New Recibos
            Dim oQna As New Quincenas
            Dim dtQnasAbiertasParaCaptura As DataTable

            dtQnasAbiertasParaCaptura = oQna.ObtenAbiertasParaCaptura()

            ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx?IdRecibo=" + Request.Params("IdRecibo") + "&IdReporte=2','Recibo_" + Request.Params("IdRecibo") + "');"

            oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
            drRecibo = oRecibo.ObtenPorId().Rows(0)

            Me.tbNumRecibo.Text = drRecibo("NumRecibo").ToString
            Me.tbTipoRecibo.Text = drRecibo("DescTipoRecibo").ToString
            Me.tbConceptoRecibo.Text = drRecibo("ObservacionesRecibo").ToString
            Me.tbQuincena.Text = drRecibo("Quincena").ToString
            Me.lblIdQuincena.Text = drRecibo("IdQuincenaAplicacion").ToString
            Me.tbClaveCobro.Text = drRecibo("Plaza").ToString
            Me.tbRFC.Text = drRecibo("RFCEmp").ToString
            Me.tbNombre.Text = drRecibo("NomEmp").ToString
            Me.tbTipoPresup.Text = drRecibo("DescFondoPresup").ToString
            Me.tbCentResp.Text = drRecibo("ClaveCT").ToString
            Me.tbPlantel.Text = drRecibo("ClavePlantel").ToString + "-" + drRecibo("DescPlantel").ToString
            Me.tbRegimenISSSTE.Text = drRecibo("DescRegimenISSSTE").ToString
            Me.ibDevolucion.Visible = drRecibo("QnaDeDevol").ToString = String.Empty And Not Request.Params("Devolucion") Is Nothing And dtQnasAbiertasParaCaptura.Rows.Count > 0
            Me.ibEliminarDevolucion.Visible = drRecibo("QnaDeDevol").ToString <> String.Empty And Not Request.Params("Devolucion") Is Nothing And dtQnasAbiertasParaCaptura.Rows.Count > 0

            Me.btnGeneraRecibo.Enabled = True

            Me.lbAddPerc.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Recibos/AdmonConceptosRecibos.aspx?TipoOperacion=1&IdRecibo=" _
                                            + Request.Params("IdRecibo") + "&TipoConcepto=P');"
            Me.lbAddDeduc.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Recibos/AdmonConceptosRecibos.aspx?TipoOperacion=1&IdRecibo=" _
                                            + Request.Params("IdRecibo") + "&TipoConcepto=D');"


            BindRecibo()

            Me.gvDatosComplem.Columns(5).Visible = False
            Me.gvDatosComplem.Columns(6).Visible = False
            Select Case CShort(drRecibo("IdTipoRecibo"))
                Case 4
                    Me.gvPercepciones.Columns(4).Visible = False
                    Me.gvPercepciones.Columns(5).Visible = False
                    Me.gvDeducciones.Columns(4).Visible = False
                    Me.gvDeducciones.Columns(5).Visible = False
                Case 2, 5
                    Me.gvDatosComplem.Columns(5).Visible = True
                    Me.gvDatosComplem.Columns(6).Visible = True
            End Select

            If Request.Params("TipoOperacion") = "4" Then
                Me.btnGeneraRecibo.Visible = False
                Me.BtnFinalizarRecibo.Visible = False
                Me.lbAddPerc.Visible = False
                Me.lbAddDeduc.Visible = False
                Me.gvPercepciones.Columns(7).Visible = False
                Me.gvPercepciones.Columns(8).Visible = False
                Me.gvDeducciones.Columns(7).Visible = False
                Me.gvDeducciones.Columns(8).Visible = False
                Me.gvDatosComplem.Columns(5).Visible = False
                Me.gvDatosComplem.Columns(6).Visible = False
            End If
        End If
    End Sub

    Protected Sub btnGeneraRecibo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraRecibo.Click
        ValidaOperacion()
        Dim oRecibo As New Recibos
        Dim oNom As New Nomina
        With oRecibo
            .EliminaImportes(CShort(Request.Params("IdRecibo")), CType(Session("ArregloAuditoria"), String()))
            .CalculaImportes(Me.tbRFC.Text, CShort(Me.lblIdQuincena.Text), CShort(Request.Params("IdRecibo")), CType(Session("ArregloAuditoria"), String()))
        End With
        BindRecibo()
    End Sub

    Protected Sub lbAddPerc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindRecibo()
    End Sub

    Protected Sub lbAddDeduc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindRecibo()
    End Sub

    Protected Sub gvPercepciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPerc As Label = CType(e.Row.FindControl("lblIdPerc_E"), Label)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)

                ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Recibos/AdmonConceptosRecibos.aspx?TipoOperacion=0&IdRecibo=" _
                                            + Request.Params("IdRecibo") + "&TipoConcepto=P&IdConcepto=" + lblIdPerc.Text + "');"
                ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Recibos/AdmonConceptosRecibos.aspx?TipoOperacion=3&IdRecibo=" _
                            + Request.Params("IdRecibo") + "&TipoConcepto=P&IdConcepto=" + lblIdPerc.Text + "');"
        End Select
    End Sub

    Protected Sub gvDeducciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdDeduc As Label = CType(e.Row.FindControl("lblIdDeduc"), Label)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)

                ibModificar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Recibos/AdmonConceptosRecibos.aspx?TipoOperacion=0&IdRecibo=" _
                                            + Request.Params("IdRecibo") + "&TipoConcepto=D&IdConcepto=" + lblIdDeduc.Text + "');"
                ibEliminar.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Recibos/AdmonConceptosRecibos.aspx?TipoOperacion=3&IdRecibo=" _
                            + Request.Params("IdRecibo") + "&TipoConcepto=D&IdConcepto=" + lblIdDeduc.Text + "');"
        End Select
    End Sub

    Protected Sub ibModificar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindRecibo()
    End Sub

    Protected Sub ibEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindRecibo()
    End Sub

    Protected Sub ibModificar_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindRecibo()
    End Sub

    Protected Sub ibEliminar_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindRecibo()
    End Sub

    Protected Sub BtnFinalizarRecibo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFinalizarRecibo.Click
        Try
            Dim oRecibo As New Recibos
            With oRecibo
                .IdRecibo = CShort(Request.Params("IdRecibo"))
                .IdEstatusRecibo = 6 'Lo cambiamos al estatus de Captura finalizada
                .ActualizaEstatus(CType(Session("ArregloAuditoria"), String()))
            End With
            Me.lblExito.Text = "Operación realizada exitosamente."
            Me.MultiView1.SetActiveView(Me.View2)
        Catch ex As Exception
            Me.lblError.Text = ex.Message
            Me.MultiView1.SetActiveView(Me.View3)
        End Try
    End Sub

    Protected Sub gvDatosComplem_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim ibModificar, ibEliminar As ImageButton
        Dim lbAddDatosComplem As LinkButton
        Dim oRecibo As New Recibos
        Dim drRecibo As DataRow
        oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
        drRecibo = oRecibo.ObtenPorId().Rows(0)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)
                ibEliminar = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                ibEliminar.OnClientClick = "javascript:abreVentanaMediana('AdmonDatosComplementarios.aspx?TipoOperacion=3&IdRecibo=" + Request.Params("IdRecibo") + "');"
                ibModificar.OnClientClick = "javascript:abreVentanaMediana('AdmonDatosComplementarios.aspx?TipoOperacion=0&IdRecibo=" + Request.Params("IdRecibo") + "');"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvDatosComplem, "Select$" + e.Row.RowIndex.ToString)
            Case DataControlRowType.EmptyDataRow
                lbAddDatosComplem = CType(e.Row.FindControl("lbAddDatosComplem"), LinkButton)
                lbAddDatosComplem.OnClientClick = "javascript:abreVentanaMediana('AdmonDatosComplementarios.aspx?TipoOperacion=1&IdRecibo=" + Request.Params("IdRecibo") + "');"
                If Request.Params("TipoOperacion") = "4" Then
                    lbAddDatosComplem.Visible = False
                Else
                    lbAddDatosComplem.Visible = False
                    Select Case CShort(drRecibo("IdTipoRecibo"))
                        Case 2, 5
                            lbAddDatosComplem.Visible = True
                    End Select
                End If
        End Select
    End Sub

    Protected Sub ibEliminar_Click2(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindRecibo()
    End Sub

    Protected Sub ibModificar_Click2(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindRecibo()
    End Sub

    Protected Sub lbAddDatosComplem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindRecibo()
    End Sub

    Protected Sub ibDevolucion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibDevolucion.Click
        Dim oRecibo As New Recibos
        Try
            oRecibo.GeneraDevolucion(CShort(Request.Params("IdRecibo")), CType(Session("ArregloAuditoria"), String()))
            Me.lblExito.Text = "Operación realizada exitosamente."
            Me.MultiView1.SetActiveView(Me.View2)
        Catch ex As Exception
            Me.lblError.Text = ex.Message
            Me.MultiView1.SetActiveView(Me.View3)
        End Try
    End Sub

    Protected Sub ibEliminarDevolucion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibEliminarDevolucion.Click
        Dim oRecibo As New Recibos
        Try
            oRecibo.EliminaDevolucion(CShort(Request.Params("IdRecibo")), CType(Session("ArregloAuditoria"), String()))
            Me.lblExito.Text = "Operación realizada exitosamente."
            Me.MultiView1.SetActiveView(Me.View2)
        Catch ex As Exception
            Me.lblError.Text = ex.Message
            Me.MultiView1.SetActiveView(Me.View3)
        End Try
    End Sub
End Class

