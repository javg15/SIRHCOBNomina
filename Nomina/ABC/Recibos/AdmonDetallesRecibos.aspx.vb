Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Partial Class ABC_Recibos_AdmonDetallesRecibos
    Inherits System.Web.UI.Page
    Private Sub SetPermisos(ByVal drRecibo As DataRow) '(dsRecibo As DataSet)
        Dim oUsr As New Usuario

        gvDatosComplem.Columns(5).Visible = False
        gvDatosComplem.Columns(6).Visible = False

        If Request.Params("TipoOperacion") = "4" Then
            btnGeneraRecibo.Visible = False
            BtnFinalizarRecibo.Visible = False
            lbAddPerc.Visible = False
            lbAddDeduc.Visible = False
            gvPercepciones.Columns(7).Visible = False
            gvPercepciones.Columns(8).Visible = False
            gvDeducciones.Columns(7).Visible = False
            gvDeducciones.Columns(8).Visible = False
            gvDatosComplem.Columns(5).Visible = False
            gvDatosComplem.Columns(6).Visible = False
            gvSubsidioCausado.Columns(1).Visible = False
        Else
            btnGeneraRecibo.Visible = False
            BtnFinalizarRecibo.Visible = False
            lbAddPerc.Visible = True
            lbAddDeduc.Visible = True
            gvPercepciones.Columns(7).Visible = True
            gvPercepciones.Columns(8).Visible = True
            gvDeducciones.Columns(7).Visible = True
            gvDeducciones.Columns(8).Visible = True
            gvDatosComplem.Columns(5).Visible = True
            gvDatosComplem.Columns(6).Visible = True

            Select Case CShort(drRecibo("IdTipoRecibo"))
                Case 4
                    gvPercepciones.Columns(4).Visible = False
                    gvPercepciones.Columns(5).Visible = False
                    gvDeducciones.Columns(4).Visible = False
                    gvDeducciones.Columns(5).Visible = False
                Case 2, 5, 18
                    gvDatosComplem.Columns(5).Visible = True
                    gvDatosComplem.Columns(6).Visible = True
            End Select

            'mvSubsidioCausado.SetActiveView(viewgvSubsidioCausado)
            gvSubsidioCausado.Columns(1).Visible = False
            If oUsr.EsVIP(Session("Login")) Or oUsr.EsAdministrador(Session("Login")) Then
                'mvSubsidioCausado.SetActiveView(viewSinPermisosSubsidioCausado)
                gvSubsidioCausado.Columns(1).Visible = True
            End If
        End If

    End Sub
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
            Dim oUsr As New Usuario

            'Determinamos posibles observaciones sobre claves que pueden ser necesarias incluir en el recibo.
            'Las observaciones son meramente informativas para ayduar al usuario que realiza el recibo a no omitir
            'alguna clave o poner alguna clave de más
            DeterminaObservaciones()

            dsRecibo = oRecibo.ConsultaImportes(CShort(Request.Params("IdRecibo")))

            gvPercepciones.DataSource = dsRecibo.Tables(1)
            gvDeducciones.DataSource = dsRecibo.Tables(2)
            dvTotalPerc.DataSource = dsRecibo.Tables(0)
            dvTotalDeduc.DataSource = dsRecibo.Tables(0)
            dvNetoPagar.DataSource = dsRecibo.Tables(0)
            gvDatosComplem.DataSource = dsRecibo.Tables(3)
            gvSubsidioCausado.DataSource = dsRecibo.Tables(4)

            gvPercepciones.DataBind()
            gvDeducciones.DataBind()
            dvTotalPerc.DataBind()
            dvTotalDeduc.DataBind()
            dvNetoPagar.DataBind()
            gvDatosComplem.DataBind()
            gvSubsidioCausado.DataBind()

            If dsRecibo.Tables(1).Rows.Count > 0 Then
                lblTotPercs = CType(gvPercepciones.FooterRow.FindControl("lblTotPercs"), Label)
                lblTotPercs.Text = Format(dsRecibo.Tables(1).Compute("Sum(Importe)", ""), "$ ###,###,##0.00")
                lblTotPercsRetro = CType(gvPercepciones.FooterRow.FindControl("lblTotPercsRetro"), Label)
                lblTotPercsRetro.Text = Format(dsRecibo.Tables(1).Compute("Sum(ImporteParaRetroactivo)", ""), "$ ###,###,##0.00")
                lblTotPercsAgui = CType(gvPercepciones.FooterRow.FindControl("lblTotPercsAgui"), Label)
                lblTotPercsAgui.Text = Format(dsRecibo.Tables(1).Compute("Sum(ImporteParaAguinaldo)", ""), "$ ###,###,##0.00")
                lblTotPercsGrav = CType(gvPercepciones.FooterRow.FindControl("lblTotPercsGrav"), Label)
                lblTotPercsGrav.Text = Format(dsRecibo.Tables(1).Compute("Sum(ImporteGravado)", ""), "$ ###,###,##0.00")
            End If

            If dsRecibo.Tables(2).Rows.Count > 0 Then
                lblTotDeducs = CType(gvDeducciones.FooterRow.FindControl("lblTotDeducs"), Label)
                lblTotDeducs.Text = Format(dsRecibo.Tables(2).Compute("Sum(Importe)", ""), "$ ###,###,##0.00")
                lblTotDeducsRetro = CType(gvDeducciones.FooterRow.FindControl("lblTotDeducsRetro"), Label)
                lblTotDeducsRetro.Text = Format(dsRecibo.Tables(2).Compute("Sum(ImporteParaRetroactivo)", ""), "$ ###,###,##0.00")
                lblTotDeducsAgui = CType(gvDeducciones.FooterRow.FindControl("lblTotDeducsAgui"), Label)
                lblTotDeducsAgui.Text = Format(dsRecibo.Tables(2).Compute("Sum(ImporteParaAguinaldo)", ""), "$ ###,###,##0.00")
                lblTotDeducsGrav = CType(gvDeducciones.FooterRow.FindControl("lblTotDeducsGrav"), Label)
                lblTotDeducsGrav.Text = Format(dsRecibo.Tables(2).Compute("Sum(ImporteGravado)", ""), "$ ###,###,##0.00")
            End If

            'mvSubsidioCausado.SetActiveView(viewgvSubsidioCausado)

        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim drRecibo As DataRow
            Dim oRecibo As New Recibos
            Dim oQna As New Quincenas
            Dim dtQnasAbiertasParaCaptura As DataTable

            Response.Expires = 0
            MultiView1.SetActiveView(View1)

            Dim vlComplementoURL As String = String.Empty

            If Request.Params("Anio") Is Nothing = False And Request.Params("IdQuincena") Is Nothing = False And Request.Params("OpcsRecibos") Is Nothing Then
                vlComplementoURL = "?Anio=" + Request.Params("Anio").ToString + "&IdQuincena=" + Request.Params("IdQuincena").ToString
            Else
                If Request.Params("Anio") Is Nothing = False And Request.Params("IdQuincena") Is Nothing = False And Request.Params("OpcsRecibos") Is Nothing = False Then
                    vlComplementoURL = "?Anio=" + Request.Params("Anio").ToString + "&IdQuincena=" + Request.Params("IdQuincena").ToString + "&OpcsRecibos=" + Request.Params("OpcsRecibos").ToString
                Else
                    If Request.Params("Anio2") Is Nothing = False And Request.Params("TipoRecibo") Is Nothing = False And Request.Params("OpcsRecibos") Is Nothing = False Then
                        vlComplementoURL = "?Anio2=" + Request.Params("Anio2").ToString + "&TipoRecibo=" + Request.Params("TipoRecibo").ToString + "&OpcsRecibos=" + Request.Params("OpcsRecibos").ToString
                    Else
                        If Request.Params("OpcsRecibos") Is Nothing = False Then
                            vlComplementoURL = "?OpcsRecibos=" + Request.Params("OpcsRecibos").ToString
                        End If
                    End If
                End If
            End If

            If Session("URLAnt") Is Nothing = False Then
                If Session("URLAnt").ToString.Contains(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString) Then
                    ibRegresar.PostBackUrl = "~/MenuPrincipal.aspx"
                Else
                    ibRegresar.PostBackUrl = "~/" + Session("URLAnt") + vlComplementoURL
                End If
            Else
                ibRegresar.PostBackUrl = "~/MenuPrincipal.aspx"
            End If

            dtQnasAbiertasParaCaptura = oQna.ObtenAbiertasParaCaptura()

            ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                       + "?IdRecibo=" + Request.Params("IdRecibo") _
                                       + "&IdReporte=2','Recibo_" _
                                       + Request.Params("IdRecibo") + "');"


            Me.iblAfectacion.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                           + "?IdQuincena=" + Request.Params("IdRecibo") _
                           + "&IdFondoPresup=16" _
                           + "&IdFecha=NULL" _
                           + "&IdConcepto=NULL" _
                           + "&IdReporte=157'); return false;"

            Me.iblAfectacionPago.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                          + "?IdQuincena=" + Request.Params("IdRecibo") _
                          + "&IdFondoPresup=17" _
                          + "&IdFecha=NULL" _
                          + "&IdConcepto=NULL" _
                          + "&IdReporte=157'); return false;"


            oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
            drRecibo = oRecibo.ObtenPorId().Rows(0)

            tbNumRecibo.Text = drRecibo("NumRecibo").ToString
            tbTipoRecibo.Text = drRecibo("DescTipoRecibo").ToString
            tbConceptoRecibo.Text = drRecibo("ObservacionesRecibo").ToString
            tbQuincena.Text = drRecibo("Quincena").ToString
            lblIdQuincena.Text = drRecibo("IdQuincenaAplicacion").ToString
            tbClaveCobro.Text = drRecibo("Plaza").ToString
            tbRFC.Text = drRecibo("RFCEmp").ToString
            tbNombre.Text = drRecibo("NomEmp").ToString
            tbTipoPresup.Text = drRecibo("DescFondoPresup").ToString
            tbCentResp.Text = drRecibo("ClaveCT").ToString
            tbPlantel.Text = drRecibo("ClavePlantel").ToString + "-" + drRecibo("DescPlantel").ToString
            tbRegimenISSSTE.Text = drRecibo("DescRegimenISSSTE").ToString
            ibDevolucion.Visible = drRecibo("QnaDeDevol").ToString = String.Empty And Not Request.Params("Devolucion") Is Nothing And dtQnasAbiertasParaCaptura.Rows.Count > 0
            ibEliminarDevolucion.Visible = drRecibo("QnaDeDevol").ToString <> String.Empty And Not Request.Params("Devolucion") Is Nothing And dtQnasAbiertasParaCaptura.Rows.Count > 0

            btnGeneraRecibo.Enabled = True

            lbAddPerc.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Recibos/AdmonConceptosRecibos.aspx?TipoOperacion=1&IdRecibo=" _
                                            + Request.Params("IdRecibo") + "&TipoConcepto=P');"
            lbAddDeduc.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Recibos/AdmonConceptosRecibos.aspx?TipoOperacion=1&IdRecibo=" _
                                            + Request.Params("IdRecibo") + "&TipoConcepto=D');"

            BindRecibo()

            SetPermisos(drRecibo)
        End If
    End Sub

    Protected Sub btnGeneraRecibo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraRecibo.Click
        ValidaOperacion()
        Dim oRecibo As New Recibos
        Dim oNom As New Nomina
        With oRecibo
            .EliminaImportes(CShort(Request.Params("IdRecibo")), CType(Session("ArregloAuditoria"), String()))
            .CalculaImportes(tbRFC.Text, CShort(lblIdQuincena.Text), CShort(Request.Params("IdRecibo")), CType(Session("ArregloAuditoria"), String()))
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
            lblExito.Text = "Operación realizada exitosamente."
            MultiView1.SetActiveView(View2)
        Catch ex As Exception
            lblError.Text = ex.Message
            MultiView1.SetActiveView(View3)
        End Try
    End Sub

    Protected Sub gvDatosComplem_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim ibModificar, ibEliminar As ImageButton
        Dim lbAddDatosComplem As LinkButton
        Dim oRecibo As New Recibos
        Dim drRecibo As DataRow
        Dim vlIdTipoRecibo As Byte = Nothing
        Dim vlTipoDeReciboPermiteCapturaDeDatosComp As Boolean = False

        oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
        drRecibo = oRecibo.ObtenPorId().Rows(0)

        vlIdTipoRecibo = CByte(drRecibo("IdTipoRecibo"))
        vlTipoDeReciboPermiteCapturaDeDatosComp = oRecibo.TipoDeReciboPermiteCapturaDeDatosComp(vlIdTipoRecibo)

        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)
                ibEliminar = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                ibEliminar.OnClientClick = "javascript:abreVentanaMediana('AdmonDatosComplementarios.aspx?TipoOperacion=3&IdRecibo=" + Request.Params("IdRecibo") + "');"
                ibModificar.OnClientClick = "javascript:abreVentanaMediana('AdmonDatosComplementarios.aspx?TipoOperacion=0&IdRecibo=" + Request.Params("IdRecibo") + "');"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(gvDatosComplem, "Select$" + e.Row.RowIndex.ToString)
            Case DataControlRowType.EmptyDataRow
                lbAddDatosComplem = CType(e.Row.FindControl("lbAddDatosComplem"), LinkButton)
                lbAddDatosComplem.OnClientClick = "javascript:abreVentanaMediana('AdmonDatosComplementarios.aspx?TipoOperacion=1&IdRecibo=" + Request.Params("IdRecibo") + "');"
                If Request.Params("TipoOperacion") = "4" Then
                    lbAddDatosComplem.Visible = False
                Else
                    lbAddDatosComplem.Visible = vlTipoDeReciboPermiteCapturaDeDatosComp
                    'Select Case CByte(drRecibo("IdTipoRecibo"))
                    '    Case 2, 5, 18
                    '        lbAddDatosComplem.Visible = True
                    'End Select
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
            lblExito.Text = "Operación realizada exitosamente."
            MultiView1.SetActiveView(View2)
        Catch ex As Exception
            lblError.Text = ex.Message
            MultiView1.SetActiveView(View3)
        End Try
    End Sub

    Protected Sub ibEliminarDevolucion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibEliminarDevolucion.Click
        Dim oRecibo As New Recibos
        Try
            oRecibo.EliminaDevolucion(CShort(Request.Params("IdRecibo")), CType(Session("ArregloAuditoria"), String()))
            lblExito.Text = "Operación realizada exitosamente."
            MultiView1.SetActiveView(View2)
        Catch ex As Exception
            lblError.Text = ex.Message
            MultiView1.SetActiveView(View3)
        End Try
    End Sub

    Protected Sub gvSubsidioCausado_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSubsidioCausado.RowDataBound
        Dim lbAddSubsidioCausado As LinkButton
        Dim oUsr As New Usuario

        Select Case e.Row.RowType
            Case DataControlRowType.EmptyDataRow
                lbAddSubsidioCausado = CType(e.Row.FindControl("lbAddSubsidioCausado"), LinkButton)
                If Request.Params("TipoOperacion") = "4" Then
                    lbAddSubsidioCausado.Visible = False
                Else
                    If oUsr.EsVIP(Session("Login")) Or oUsr.EsAdministrador(Session("Login")) Then
                        lbAddSubsidioCausado.Visible = True
                    End If
                End If
        End Select
    End Sub

    Protected Sub gvSubsidioCausado_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvSubsidioCausado.RowEditing
        Dim drRecibo As DataRow
        Dim oRecibo As New Recibos
        Dim dsRecibo As DataSet

        btnGeneraRecibo.Visible = False
        BtnFinalizarRecibo.Visible = False
        lbAddPerc.Visible = False
        lbAddDeduc.Visible = False
        gvPercepciones.Columns(7).Visible = False
        gvPercepciones.Columns(8).Visible = False
        gvDeducciones.Columns(7).Visible = False
        gvDeducciones.Columns(8).Visible = False
        gvDatosComplem.Columns(5).Visible = False
        gvDatosComplem.Columns(6).Visible = False

        oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
        drRecibo = oRecibo.ObtenPorId().Rows(0)

        gvSubsidioCausado.EditIndex = e.NewEditIndex

        dsRecibo = oRecibo.ConsultaImportes(CShort(Request.Params("IdRecibo")))

        gvSubsidioCausado.DataSource = dsRecibo.Tables(4)
        gvSubsidioCausado.DataBind()
    End Sub

    Protected Sub gvSubsidioCausado_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvSubsidioCausado.RowCancelingEdit
        Dim oRecibo As New Recibos
        Dim dsRecibo As DataSet
        Dim drRecibo As DataRow

        oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
        drRecibo = oRecibo.ObtenPorId().Rows(0)

        gvSubsidioCausado.EditIndex = -1

        dsRecibo = oRecibo.ConsultaImportes(CShort(Request.Params("IdRecibo")))

        gvSubsidioCausado.DataSource = dsRecibo.Tables(4)
        gvSubsidioCausado.DataBind()

        SetPermisos(drRecibo)
    End Sub

    Protected Sub gvSubsidioCausado_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvSubsidioCausado.RowUpdating
        Dim oRecibo As New Recibos
        Dim dsRecibo As DataSet
        Dim drRecibo As DataRow

        Dim txtbxSubsidioCausado As TextBox = CType(gvSubsidioCausado.Rows(e.RowIndex).FindControl("txtbxSubsidioCausado"), TextBox)

        If txtbxSubsidioCausado.Text.Trim = String.Empty Then
            txtbxSubsidioCausado.Text = "0.00"
        End If

        oRecibo.ActualizaSubsidioCausado(CShort(Request.Params("IdRecibo")), CDec(txtbxSubsidioCausado.Text), CType(Session("ArregloAuditoria"), String()))

        oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
        drRecibo = oRecibo.ObtenPorId().Rows(0)

        gvSubsidioCausado.EditIndex = -1

        dsRecibo = oRecibo.ConsultaImportes(CShort(Request.Params("IdRecibo")))

        gvSubsidioCausado.DataSource = dsRecibo.Tables(4)
        gvSubsidioCausado.DataBind()

        SetPermisos(drRecibo)
    End Sub
End Class

