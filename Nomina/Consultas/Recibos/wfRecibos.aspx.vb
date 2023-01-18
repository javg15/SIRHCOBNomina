Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Empleados.Sexos
Imports DataAccessLayer.COBAEV.Mexico.Estados
Imports DataAccessLayer.COBAEV.Administracion
Partial Class wfRecibos
    Inherits System.Web.UI.Page
    Private Sub BindRecibos(ByVal pIdRecibo As Short)
        Try
            Dim oRecibo As New Recibos
            Dim dsRecibo As DataSet
            Dim lblTotPercs, lblTotPercsRetro, lblTotPercsAgui, lblTotPercsGrav As Label
            Dim lblTotDeducs, lblTotDeducsRetro, lblTotDeducsAgui, lblTotDeducsGrav As Label

            'Determinamos posibles observaciones sobre claves que pueden ser necesarias incluir en el recibo.
            'Las observaciones son meramente informativas para ayduar al usuario que realiza el recibo a no omitir
            'alguna clave o poner alguna clave de más
            'DeterminaObservaciones()

            dsRecibo = oRecibo.ConsultaImportes(pIdRecibo)

            gvPercepciones.DataSource = dsRecibo.Tables(1)
            gvDeducciones.DataSource = dsRecibo.Tables(2)
            gvTotales.DataSource = dsRecibo.Tables(4)

            If oRecibo.EsIndemnizatorio(pIdRecibo) Then
                If dsRecibo.Tables(3).Rows.Count > 0 Then
                    gvRecibosDatosComplem.DataSource = dsRecibo.Tables(3)
                Else
                    gvRecibosDatosComplem.EmptyDataText = "No ha sido capturados aún los conceptos indemnizatorios para el Recibo."
                End If
            Else
                gvRecibosDatosComplem.EmptyDataText = "El Recibo no corresponde a una Indemnización."
            End If

            gvPercepciones.DataBind()
            gvDeducciones.DataBind()
            gvTotales.DataBind()
            gvRecibosDatosComplem.DataBind()

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

    Private Sub BindgvRecibos()
        Dim oRecibo As New Recibos
        Dim oUsr As New Usuario
        Dim dr As DataRow
        Dim oAplic As New Aplicacion

        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        If ddlOpcsRecibos.SelectedValue = "1" Then
            With oRecibo
                If Me.ddlAnios.SelectedValue <> -1 Then
                    Me.gvRecibos.DataSource = .ObtenRecibosPorAnio(CShort(Me.ddlAnios.SelectedValue), CShort(Me.ddlQuincenas.SelectedValue), _
                                                CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
                End If
                Me.gvRecibos.DataBind()
                lblEmpInfConsulta3.Text = "Pagos realizados en la quincena " + ddlQuincenas.SelectedItem.Text + " mediante recibos fuera de nómina"
                pnlRecibosPorAnioQna.Visible = True
                'ValidaPermisos()
            End With
        ElseIf ddlOpcsRecibos.SelectedValue = "2" Then
            With oRecibo
                If Me.ddlAnios2.SelectedValue <> -1 Then
                    Me.gvRecibosAnioTipo.DataSource = .ObtenRecibosPorAnioTipo(CShort(Me.ddlAnios2.SelectedValue), CByte(Me.ddlTiposRecibos.SelectedValue), _
                                                CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
                End If
                Me.gvRecibosAnioTipo.DataBind()
                lblRecibosAnioTipo.Text = "Pagos realizados durante el año " + ddlAnios2.SelectedItem.Text + " mediante recibos fuera de nómina del tipo " + ddlTiposRecibos.SelectedItem.Text
                pnlRecibosPorAnioTipo.Visible = True
                'ValidaPermisos()
            End With
        End If
    End Sub
    Private Sub BindAnios(ByVal pddlAnios As DropDownList)
        Dim oAnio As New Anios
        With pddlAnios
            .DataSource = oAnio.ObtenParaConsultaDeRecibos()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay años disponibles para consulta")
                .Items(0).Value = -1
            Else
                If ddlOpcsRecibos.SelectedValue = "1" Then
                    If Request.Params("Anio") Is Nothing = False Then
                        Try
                            ddlAnios.SelectedValue = Request.Params("Anio").ToString
                        Catch
                        End Try
                    End If
                    BindQnas()
                ElseIf ddlOpcsRecibos.SelectedValue = "2" Then
                    If Request.Params("Anio2") Is Nothing = False Then
                        Try
                            ddlAnios.SelectedValue = Request.Params("Anio2").ToString
                        Catch
                        End Try
                    End If
                    BindTiposDeRecibos()
                End If
            End If
        End With
    End Sub
    Private Sub BindTiposDeRecibos()
        Dim oRecibo As New Recibos
        With ddlTiposRecibos
            .DataSource = oRecibo.ObtenTipos()
            .DataTextField = "DescTipoRecibo"
            .DataValueField = "IdTipoRecibo"
            .DataBind()
            If .Items.Count = 0 Or Me.ddlAnios2.SelectedValue = "-1" Then
                .Items.Clear()
                .Items.Insert(0, "No hay tipos de recibos disponibles para consulta.")
                .Items(0).Value = -1
                btnConsultaRecibosPorTipo.Enabled = False
            Else
                If Request.Params("TipoRecibo") Is Nothing = False Then
                    Try
                        ddlTiposRecibos.SelectedValue = Request.Params("TipoRecibo").ToString
                    Catch
                    End Try
                End If
                btnConsultaRecibosPorTipo.Enabled = True
            End If
            BindgvRecibos()
        End With
    End Sub
    Private Sub BindQnas()
        Dim oRecibo As New Recibos
        With Me.ddlQuincenas
            .DataSource = oRecibo.ObtenQnasPorAnioParaConsulta(CShort(Me.ddlAnios.SelectedValue), Session("Login"))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Or Me.ddlAnios.SelectedValue = "-1" Then
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas disponibles para consulta")
                .Items(0).Value = -1
                btnConsultarAnio.Enabled = False
            Else
                If Request.Params("IdQuincena") Is Nothing = False Then
                    Try
                        ddlQuincenas.SelectedValue = Request.Params("IdQuincena").ToString
                    Catch
                    End Try
                End If
                btnConsultarAnio.Enabled = True
            End If
            BindgvRecibos()
        End With
    End Sub
    'Private Sub setPermisos(ByVal pOpcion As String)
    Private Sub setPermisos()
        Dim oUsr As New Usuario
        Dim dtPermisosUsuario As DataTable
        Dim dtQna As DataTable = Nothing
        Dim oQna As New Quincenas
        Dim vlHayQnaAbierta As Boolean
        Dim vlEmpSeLePuedeCrearReciboEnQna As Boolean = False
        Dim oEmp As New Empleado

        dtPermisosUsuario = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Recibos")
        vlHayQnaAbierta = oQna.HayAbiertasParaCapturaDeRecibos()

        If vlHayQnaAbierta Then
            dtQna = oQna.ObtenAbiertasParaCapturaDeRecibos()
            If ddlOpcsRecibos.SelectedValue = "0" Then 'Recibos por Empleado
                vlEmpSeLePuedeCrearReciboEnQna = oEmp.SeLePuedeCrearReciboEnQna(Session("RFCParaCons").ToString(), CShort(dtQna.Rows(0).Item("IdQuincena")))
            End If
        End If

        If ddlOpcsRecibos.SelectedValue = "0" Then 'Recibos por Empleado
            If vlEmpSeLePuedeCrearReciboEnQna Then
                lbNuevoRecibo.Visible = False
                lblEmpSeLePuedeCrearReciboEnQna.Text = "El empleado está registrado para poder crearle un recibo en la quincena " + dtQna.Rows(0).Item("Quincena").ToString
                lblEmpSeLePuedeCrearReciboEnQna.Visible = True
            Else
                lbNuevoRecibo.Visible = CBool(dtPermisosUsuario.Rows(0).Item("Insercion")) And vlHayQnaAbierta 'Permiso inserción

                If vlHayQnaAbierta Then
                    lbNuevoRecibo_CBE.ConfirmText = "La operación solicitada le permitirá crear posteriormente un recibo para el empleado. " + _
                                    "El recibo quedará asociado a la quincena " + dtQna.Rows(0).Item("Quincena").ToString + ". ¿Continuar?"
                End If

                lblEmpSeLePuedeCrearReciboEnQna.Visible = False
                End If
            gvHistorialRecibosPorEmp.Columns(14).Visible = False 'CBool(dtPermisosUsuario.Rows(0).Item("Eliminacion")) And vlHayQnaAbierta 'Permiso eliminación
            gvHistorialRecibosPorEmp.Columns(15).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Consulta")) 'Permiso consulta para ver detalles
            gvHistorialRecibosPorEmp.Columns(16).Visible = False 'CBool(dtPermisosUsuario.Rows(0).Item("Actualizacion")) And vlHayQnaAbierta 'Permiso baja
            gvHistorialRecibosPorEmp.Columns(17).Visible = False 'CBool(dtPermisosUsuario.Rows(0).Item("Actualizacion")) And vlHayQnaAbierta 'Permiso modificación
        ElseIf ddlOpcsRecibos.SelectedValue = "1" Then 'Recibos por Año/Quincena o Año/Tipo
            gvRecibos.Columns(14).Visible = False 'CBool(dtPermisosUsuario.Rows(0).Item("Eliminacion")) And vlHayQnaAbierta
            gvRecibos.Columns(15).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Consulta")) 'Permiso consulta para ver detalles
            gvRecibos.Columns(16).Visible = False 'CBool(dtPermisosUsuario.Rows(0).Item("Actualizacion")) And vlHayQnaAbierta 'And QnaEstaAbiertaParaCaptura
            gvRecibos.Columns(17).Visible = False 'CBool(dtPermisosUsuario.Rows(0).Item("Actualizacion")) And vlHayQnaAbierta
        ElseIf ddlOpcsRecibos.SelectedValue = "2" Then 'Recibos por Año/Tipo
            gvRecibosAnioTipo.Columns(14).Visible = False 'CBool(dtPermisosUsuario.Rows(0).Item("Eliminacion")) And vlHayQnaAbierta
            gvRecibosAnioTipo.Columns(15).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Consulta")) 'Permiso consulta para ver detalles
            gvRecibosAnioTipo.Columns(16).Visible = False 'CBool(dtPermisosUsuario.Rows(0).Item("Actualizacion")) And vlHayQnaAbierta 'And QnaEstaAbiertaParaCaptura
            gvRecibosAnioTipo.Columns(17).Visible = False 'CBool(dtPermisosUsuario.Rows(0).Item("Actualizacion")) And vlHayQnaAbierta
        End If
    End Sub
    Private Sub BindgvHistorialRecibos()
        Dim oRecibo As New Recibos
        Dim vlRFCEmp As String
        Dim txtbxRFC As TextBox = CType(wucBuscaEmps.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(wucBuscaEmps.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(wucBuscaEmps.FindControl("hfNomEmp"), HiddenField)
        Dim dtRecibosPorEmp As DataTable
        vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
            'vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, "", Session("RFCParaCons"))
            'If Not Session("RFCParaCons") Is Nothing Or vlRFCEmp <> String.Empty Then
            dtRecibosPorEmp = oRecibo.ObtenRecibosPorEmpleado(vlRFCEmp, Session("Login"))
            Me.gvHistorialRecibosPorEmp.DataSource = dtRecibosPorEmp
            Me.gvHistorialRecibosPorEmp.DataBind()
            lblEmpInfConsulta.Text = "Pagos realizados al empleado " + _
                                        IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + _
                                        " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value) + _
                                        " mediante recibos fuera de nómina"
            gvHistorialRecibosPorEmp.Enabled = True
            pnlRecibosPorEmp.Visible = True
        Else
            pnlRecibosPorEmp.Visible = False
            lblEmpInfConsulta.Text = String.Empty
        End If
    End Sub

    Protected Sub gvHistorialRecibosPorEmp_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvHistorialRecibosPorEmp.RowDataBound
        Dim oUsr As New Usuario
        Dim drUsuario As DataRow
        Dim lblEstatusQnaAplic As Label
        Dim lblPermisoConsulta As Label
        Dim ibModificar As ImageButton
        Dim ibConsultaDetalles As ImageButton

        Dim lblIdRecibo, lblIdUsuario, lblUsuario As Label
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lblIdRecibo = CType(e.Row.FindControl("lblIdRecibo"), Label)
                lblIdUsuario = CType(e.Row.FindControl("lblIdUsuario"), Label)
                lblUsuario = CType(e.Row.FindControl("lblUsuario"), Label)
                oUsr.IdUsuario = CShort(lblIdUsuario.Text)
                drUsuario = oUsr.ObtenerPorId()
                lblUsuario.Text = drUsuario("Login")
                lblUsuario.ToolTip = (drUsuario("ApellidoPaterno").ToString.Trim + " " + drUsuario("ApellidoMaterno").ToString.Trim + " " + drUsuario("Nombre").ToString.Trim).ToString.Trim

                lblEstatusQnaAplic = CType(e.Row.FindControl("lblEstatusQnaAplic"), Label)
                lblPermisoConsulta = CType(e.Row.FindControl("lblPermisoConsulta"), Label)

                ibConsultaDetalles = CType(e.Row.FindControl("ibConsultaDetalles"), ImageButton)
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)

                If lblPermisoConsulta.Text = "1" Then
                    'ibConsultaDetalles.OnClientClick = "javascript:abreVentanaImpresion('../../ABC/Recibos/AdmonDetallesRecibos.aspx?TipoOperacion=4&IdRecibo=" + lblIdRecibo.Text + "','Recibo" + lblIdRecibo.Text + "'); return false;"
                    ibConsultaDetalles.PostBackUrl = "../../ABC/Recibos/AdmonDetallesRecibos.aspx?TipoOperacion=4&IdRecibo=" + lblIdRecibo.Text + "&OpcsRecibos=" + ddlOpcsRecibos.SelectedValue
                Else
                    ibConsultaDetalles.OnClientClick = "javascript:alert('Lo sentimos, no cuenta con permisos suficientes para consultar el Recibo.'); return false;"
                End If

                ibModificar.ImageUrl = "~/Imagenes/Modificar.png"
                ibModificar.ToolTip = "Utilice esta opción si lo que desea es modificar algún dato de la información del Recibo."
                ibModificar.Enabled = True
                If lblEstatusQnaAplic.Text <> "A" Then 'Abierta para captura
                    ibModificar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    ibModificar.ToolTip = "Imposible modificar la información del Recibo."
                    ibModificar.Enabled = False
                End If
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(gvHistorialRecibosPorEmp, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    Protected Sub wucBuscaEmps_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles wucBuscaEmps.PreRender
        If IsPostBack And (Request.Params("Opcion") = "InfPorEmp" Or ddlOpcsRecibos.SelectedValue = "0") Then
            Dim oMetodoComun As New MetodosComunes
            Dim c As Control = oMetodoComun.GetPostBackControl(Page)

            If c Is Nothing Then Exit Sub

            Dim hfRFC As HiddenField = CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(wucBuscaEmps.FindControl("txtbxRFC"), TextBox)
            If c.ID = "BtnSearch" Then
                If txtbxRFC.Text <> String.Empty Then
                    'If Session("RFCParaCons").ToString <> String.Empty Then
                    setPermisos()
                    pnlRecibosPorEmp.Visible = True
                    MultiView1.SetActiveView(viewRecibosPorEmp)
                    BindgvHistorialRecibos()
                Else
                    pnlRecibosPorEmp.Visible = False
                End If
            ElseIf c.ID = "BtnNewSearch" Then
                pnlRecibosPorEmp.Visible = False
            ElseIf c.ID = "BtnCancelSearch" Then
                pnlRecibosPorEmp.Visible = True
            ElseIf c.ID = "lnkbtnrfc" Then
                setPermisos()
                pnlRecibosPorEmp.Visible = True
                MultiView1.SetActiveView(viewRecibosPorEmp)
                BindgvHistorialRecibos()
            End If
        End If
    End Sub

    Protected Sub lbNuevoRecibo_Click(sender As Object, e As System.EventArgs)
        Dim oRecibo As New Recibos
        Dim hfRFC As HiddenField = CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)

        'Try
        oRecibo.InsertaEnEmpleadosRecibos(hfRFC.Value, CType(Session("ArregloAuditoria"), String()))
        setPermisos()
        'Me.lblExito.Text = "Operación realizada con éxito."
        'Me.MultiView1.SetActiveView(Me.View_Exito)
        'Catch ex As Exception
        '    Me.lblError.Text = ex.Message
        '    Me.MultiView1.SetActiveView(Me.View_Errores)
        'End Try
    End Sub

    Protected Sub ddlAnios_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAnios.SelectedIndexChanged
        BindQnas()
    End Sub

    Protected Sub btnConsultarAnio_Click(sender As Object, e As System.EventArgs) Handles btnConsultarAnio.Click
        BindgvRecibos()
    End Sub

    Protected Sub gvRecibos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRecibos.RowDataBound
        Dim oUsr As New Usuario
        Dim drUsuario As DataRow
        Dim lblEstatusQnaAplic As Label
        Dim lblPermisoConsulta As Label
        Dim ibModificar As ImageButton
        Dim ibConsultaDetalles As ImageButton

        Dim lblIdRecibo, lblIdUsuario, lblUsuario As Label
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lblIdRecibo = CType(e.Row.FindControl("lblIdRecibo"), Label)
                lblIdUsuario = CType(e.Row.FindControl("lblIdUsuario"), Label)
                lblUsuario = CType(e.Row.FindControl("lblUsuario"), Label)
                oUsr.IdUsuario = CShort(lblIdUsuario.Text)
                drUsuario = oUsr.ObtenerPorId()
                lblUsuario.Text = drUsuario("Login")
                lblUsuario.ToolTip = (drUsuario("ApellidoPaterno").ToString.Trim + " " + drUsuario("ApellidoMaterno").ToString.Trim + " " + drUsuario("Nombre").ToString.Trim).ToString.Trim

                lblEstatusQnaAplic = CType(e.Row.FindControl("lblEstatusQnaAplic"), Label)
                lblPermisoConsulta = CType(e.Row.FindControl("lblPermisoConsulta"), Label)

                ibConsultaDetalles = CType(e.Row.FindControl("ibConsultaDetalles"), ImageButton)
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)

                If lblPermisoConsulta.Text = "1" Then
                    'ibConsultaDetalles.OnClientClick = "javascript:abreVentanaImpresion('../../ABC/Recibos/AdmonDetallesRecibos.aspx?TipoOperacion=4&IdRecibo=" + lblIdRecibo.Text + "','Recibo" + lblIdRecibo.Text + "'); return false;"
                    ibConsultaDetalles.PostBackUrl = "../../ABC/Recibos/AdmonDetallesRecibos.aspx?TipoOperacion=4&IdRecibo=" + lblIdRecibo.Text + "&Anio=" + ddlAnios.SelectedValue + "&IdQuincena=" + ddlQuincenas.SelectedValue + "&OpcsRecibos=" + ddlOpcsRecibos.SelectedValue
                Else
                    ibConsultaDetalles.OnClientClick = "javascript:alert('Lo sentimos, no cuenta con permisos suficientes para consultar el Recibo.'); return false;"
                End If

                ibModificar.ImageUrl = "~/Imagenes/Modificar.png"
                ibModificar.ToolTip = "Utilice esta opción si lo que desea es modificar algún dato de la información del Recibo."
                ibModificar.Enabled = True
                If lblEstatusQnaAplic.Text <> "A" Then 'Abierta para captura
                    ibModificar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    ibModificar.ToolTip = "Imposible modificar la información del Recibo."
                    ibModificar.Enabled = False
                End If
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(gvRecibos, "Select$" + e.Row.RowIndex.ToString)
        End Select

    End Sub

    Protected Sub ibConsultaDetalles_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim gv As GridView = CType(CType(sender.NamingContainer, GridViewRow).NamingContainer, GridView)
        Dim lblIdRecibo As Label = CType(gvr.FindControl("lblIdRecibo"), Label)
        Dim vlIdRecibo As Short = CShort(lblIdRecibo.Text)
        Dim vlTipoOperacion As String = "0"
        Dim dtRecibo As DataTable
        Dim oRecibo As New Recibos

        gv.SelectedIndex = gvr.RowIndex

        dtRecibo = oRecibo.ObtenPorId(vlIdRecibo)

        lblEmpInfConsulta4.Text = "Información del recibo " + dtRecibo.Rows(0).Item("AnioNumRecibo").ToString

        With dvReciboDetalles
            .DataSource = dtRecibo
            .DataBind()
        End With

        With dvReciboDetallesEmp
            .DataSource = dtRecibo
            .DataBind()
        End With

        BindRecibos(vlIdRecibo)

        btnExportarAPDF.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx?IdRecibo=" + Request.Params("IdRecibo") + "&IdReporte=2','Recibo_" + Request.Params("IdRecibo") + "');"

        MultiView1.SetActiveView(viewRecibosDetalles)
    End Sub

    Protected Sub btnRegresar_Click(sender As Object, e As System.EventArgs) Handles btnRegresar.Click
        If ddlOpcsRecibos.SelectedValue = "0" Then
            MultiView1.SetActiveView(viewRecibosPorEmp)
        ElseIf ddlOpcsRecibos.SelectedValue = "1" Then
            MultiView1.SetActiveView(viewRecibosPorAnioQna)
        ElseIf ddlOpcsRecibos.SelectedValue = "2" Then
            MultiView1.SetActiveView(viewRecibosPorTipo)
        End If
    End Sub

    Protected Sub btnIrOpcsRecibos_Click(sender As Object, e As System.EventArgs) Handles btnIrOpcsRecibos.Click, ddlOpcsRecibos.SelectedIndexChanged
        If ddlOpcsRecibos.SelectedValue = "0" Then
            MultiView1.SetActiveView(viewRecibosPorEmp)
            CType(wucBuscaEmps.FindControl("ddlTipoBusqueda"), DropDownList).Height = Unit.Pixel(20)
            CType(wucBuscaEmps.FindControl("BtnNewSearch"), Button).Height = Unit.Pixel(20)
            CType(wucBuscaEmps.FindControl("BtnCancelSearch"), Button).Height = Unit.Pixel(20)
            CType(wucBuscaEmps.FindControl("BtnSearch"), Button).Height = Unit.Pixel(20)
            CType(wucBuscaEmps.FindControl("txtbxRFC"), TextBox).Height = Unit.Pixel(20)
            CType(wucBuscaEmps.FindControl("txtbxNomEmp"), TextBox).Height = Unit.Pixel(20)
            CType(wucBuscaEmps.FindControl("txtbxNumEmp"), TextBox).Height = Unit.Pixel(20)
            If Session("RFCParaCons") Is Nothing = False Then
                If Session("RFCParaCons").ToString <> String.Empty Then
                    BindgvHistorialRecibos()
                    setPermisos()
                End If
            End If
        ElseIf ddlOpcsRecibos.SelectedValue = "1" Then
            BindAnios(ddlAnios)
            setPermisos()
            MultiView1.SetActiveView(viewRecibosPorAnioQna)
        ElseIf ddlOpcsRecibos.SelectedValue = "2" Then
            BindAnios(ddlAnios2)
            setPermisos()
            MultiView1.SetActiveView(viewRecibosPorTipo)
        End If
    End Sub

    Protected Sub btnConsultaRecibosPorTipo_Click(sender As Object, e As System.EventArgs) Handles btnConsultaRecibosPorTipo.Click
        BindgvRecibos()
    End Sub

    Protected Sub gvRecibosAnioTipo_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRecibosAnioTipo.RowDataBound
        Dim oUsr As New Usuario
        Dim drUsuario As DataRow
        Dim lblEstatusQnaAplic As Label
        Dim lblPermisoConsulta As Label
        Dim ibModificar As ImageButton
        Dim ibConsultaDetalles As ImageButton

        Dim lblIdRecibo, lblIdUsuario, lblUsuario As Label
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lblIdRecibo = CType(e.Row.FindControl("lblIdRecibo"), Label)
                lblIdUsuario = CType(e.Row.FindControl("lblIdUsuario"), Label)
                lblUsuario = CType(e.Row.FindControl("lblUsuario"), Label)
                oUsr.IdUsuario = CShort(lblIdUsuario.Text)
                drUsuario = oUsr.ObtenerPorId()
                lblUsuario.Text = drUsuario("Login")
                lblUsuario.ToolTip = (drUsuario("ApellidoPaterno").ToString.Trim + " " + drUsuario("ApellidoMaterno").ToString.Trim + " " + drUsuario("Nombre").ToString.Trim).ToString.Trim

                lblEstatusQnaAplic = CType(e.Row.FindControl("lblEstatusQnaAplic"), Label)
                lblPermisoConsulta = CType(e.Row.FindControl("lblPermisoConsulta"), Label)

                ibConsultaDetalles = CType(e.Row.FindControl("ibConsultaDetalles"), ImageButton)
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)

                If lblPermisoConsulta.Text = "1" Then
                    'ibConsultaDetalles.OnClientClick = "javascript:abreVentanaImpresion('../../ABC/Recibos/AdmonDetallesRecibos.aspx?TipoOperacion=4&IdRecibo=" + lblIdRecibo.Text + "','Recibo" + lblIdRecibo.Text + "'); return false;"
                    ibConsultaDetalles.PostBackUrl = "../../ABC/Recibos/AdmonDetallesRecibos.aspx?TipoOperacion=4&IdRecibo=" + lblIdRecibo.Text + "&Anio2=" + ddlAnios2.SelectedValue + "&TipoRecibo=" + ddlTiposRecibos.SelectedValue + "&OpcsRecibos=" + ddlOpcsRecibos.SelectedValue
                Else
                    ibConsultaDetalles.OnClientClick = "javascript:alert('Lo sentimos, no cuenta con permisos suficientes para consultar el Recibo.'); return false;"
                End If

                ibModificar.ImageUrl = "~/Imagenes/Modificar.png"
                ibModificar.ToolTip = "Utilice esta opción si lo que desea es modificar algún dato de la información del Recibo."
                ibModificar.Enabled = True
                If lblEstatusQnaAplic.Text <> "A" Then 'Abierta para captura
                    ibModificar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    ibModificar.ToolTip = "Imposible modificar la información del Recibo."
                    ibModificar.Enabled = False
                End If
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(gvRecibosAnioTipo, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.Params("OpcsRecibos") Is Nothing = False Then
                ddlOpcsRecibos.SelectedValue = Request.Params("OpcsRecibos").ToString
                'Request.Params.Remove("OpcsRecibos")
            End If

            If ddlOpcsRecibos.SelectedValue = "0" Then
                MultiView1.SetActiveView(viewRecibosPorEmp)
                CType(wucBuscaEmps.FindControl("ddlTipoBusqueda"), DropDownList).Height = Unit.Pixel(20)
                CType(wucBuscaEmps.FindControl("BtnNewSearch"), Button).Height = Unit.Pixel(20)
                CType(wucBuscaEmps.FindControl("BtnCancelSearch"), Button).Height = Unit.Pixel(20)
                CType(wucBuscaEmps.FindControl("BtnSearch"), Button).Height = Unit.Pixel(20)
                CType(wucBuscaEmps.FindControl("txtbxRFC"), TextBox).Height = Unit.Pixel(20)
                CType(wucBuscaEmps.FindControl("txtbxNomEmp"), TextBox).Height = Unit.Pixel(20)
                CType(wucBuscaEmps.FindControl("txtbxNumEmp"), TextBox).Height = Unit.Pixel(20)
                If Session("RFCParaCons") Is Nothing = False Then
                    If Session("RFCParaCons").ToString <> String.Empty Then
                        BindgvHistorialRecibos()
                        setPermisos()
                    End If
                End If
            ElseIf ddlOpcsRecibos.SelectedValue = "1" Then
                BindAnios(ddlAnios)
                setPermisos()
                MultiView1.SetActiveView(viewRecibosPorAnioQna)
            ElseIf ddlOpcsRecibos.SelectedValue = "2" Then
                BindAnios(ddlAnios2)
                setPermisos()
                MultiView1.SetActiveView(viewRecibosPorTipo)
            End If
        End If
    End Sub

    Protected Sub ibAddPercs_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) ' Handles ibAddPercs.Click

    End Sub

    Protected Sub ddlOpcsRecibos_SelectedIndexChanged(sender As Object, e As System.EventArgs)

    End Sub
End Class
