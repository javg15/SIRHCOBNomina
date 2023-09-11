Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Partial Class Administracion_Quincenas_Detalles
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oQna As New Quincenas
        Dim dt As DataTable
        Dim IdEstatusQna As Byte
        oQna.IdQuincena = CShort(Request.Params("IdQuincena"))
        If Request.Params("Adicional") = "1" Then
            dt = oQna.ObtenPorId(True)
        Else
            dt = oQna.ObtenPorId(False)
        End If
        Me.dvQuincenas.DataSource = dt
        Me.dvQuincenas.DataBind()
        IdEstatusQna = CByte(dt.Rows(0).Item("IdEstatusQuincena"))
        Dim ddlEstatusQuincena As DropDownList = CType(Me.dvQuincenas.FindControl("ddlEstatusQuincena"), DropDownList)
        Dim chkbxPeriodoVacacional As CheckBox = CType(Me.dvQuincenas.FindControl("chkbxPeriodoVacacional"), CheckBox)
        Dim lblDatosQna As Label = CType(Me.dvQuincenas.FindControl("lblDatosQna"), Label)
        Dim ibFecNac As ImageButton = CType(Me.dvQuincenas.FindControl("ibFecNac"), ImageButton)
        Dim txtbxFecNac As TextBox = CType(Me.dvQuincenas.FindControl("txtbxFecNac"), TextBox)
        Dim hfFecNac As HiddenField = CType(Me.dvQuincenas.FindControl("hfFecNac"), HiddenField)
        Dim ibFecCierre As ImageButton = CType(Me.dvQuincenas.FindControl("ibFecCierre"), ImageButton)
        Dim txtbxFecCierre As TextBox = CType(Me.dvQuincenas.FindControl("txtbxFecCierre"), TextBox)
        Dim hfFecCierre As HiddenField = CType(Me.dvQuincenas.FindControl("hfFecCierre"), HiddenField)
        Dim chbxPermiteABCdeRecibos As CheckBox = CType(Me.dvQuincenas.FindControl("chbxPermiteABCdeRecibos"), CheckBox)
        Dim chbxSubsidiado As CheckBox = CType(Me.dvQuincenas.FindControl("Subsidiado"), CheckBox)

        txtbxFecNac.Text = txtbxFecNac.Text.Substring(0, 10)
        hfFecNac.Value = txtbxFecNac.Text
        ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + txtbxFecNac.ClientID + "','" + hfFecNac.ClientID + "'); return false")
        txtbxFecCierre.Text = IIf(txtbxFecCierre.Text.Substring(0, 10) = "01/01/1900", String.Empty, txtbxFecCierre.Text.Substring(0, 10))
        hfFecCierre.Value = txtbxFecCierre.Text
        ibFecCierre.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + txtbxFecCierre.ClientID + "','" + hfFecCierre.ClientID + "'); return false")
        If Request.Params("Adicional") = "1" Then lblDatosQna.Text = "Nueva quincena adicional"
        With ddlEstatusQuincena
            .DataSource = oQna.ObtenPosiblesEstatus()
            .DataTextField = "DescEstatusQna"
            .DataValueField = "IdEstatusQnaNuevo"
            .DataBind()
            .SelectedValue = IdEstatusQna.ToString
            .Enabled = (Request.Params("Adicional") <> "1")
        End With
        chbxPermiteABCdeRecibos.Enabled = dt.Rows(0).Item("Quincena").ToString.Length = 6 And Request.Params("Adicional") <> "1"
        'chbxPermiteABCdeRecibos.Checked = chbxPermiteABCdeRecibos.Enabled
        If Request.Params("TipoOperacion") = "0" Then
            lblDatosQna.Text = "Modifica quincena"
            CType(Me.dvQuincenas.FindControl("btnGuardar"), Button).Text = "Actualizar"
        End If
        If Request.Params("TipoOperacion") = "3" Then
            lblDatosQna.Text = "Elimina quincena adicional"
            CType(Me.dvQuincenas.FindControl("btnGuardar"), Button).Text = "Elimina"
        End If
        If Request.Params("TipoOperacion") = "4" Then
            lblDatosQna.Text = "Consulta quincena"
            CType(Me.dvQuincenas.FindControl("btnGuardar"), Button).Visible = False
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Response.Expires = 0
                If Request.Params("TipoOperacion") = "0" Then
                    Me.lblHeadPage.Text = "Quincenas: Vista detalle (Modificación)"
                ElseIf Request.Params("TipoOperacion") = "4" Then
                    Me.lblHeadPage.Text = "Quincenas: Vista detalle (Consulta)"
                End If
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                BindDatos()
            Catch Ex As Exception
                Me.MultiView1.SetActiveView(Me.viewErrores)
                Me.lblErrores.Text = Ex.Message
            End Try
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim oValidacion As New Validaciones
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsValida As DataSet
            dsValida = _DataCOBAEV.setDataSetErrores()

            With oValidacion
                .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                '.IdQuincena = CShort(Request.Params("IdQuincena"))
                '.FechaPagoQna = CDate(txtbxFecNac.Text)
                .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
                If Not .ValidaPaginasOperacion(dsValida) Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            End With

            Dim oQna As New Quincenas
            Dim lbltxtNuevaAdic As Label = CType(Me.dvQuincenas.FindControl("lbltxtNuevaAdic"), Label)
            Dim ddlEstatusQuincena As DropDownList = CType(Me.dvQuincenas.FindControl("ddlEstatusQuincena"), DropDownList)
            Dim chkbxPeriodoVacacional As CheckBox = CType(Me.dvQuincenas.FindControl("chkbxPeriodoVacacional"), CheckBox)
            Dim txtbxFecNac As TextBox = CType(Me.dvQuincenas.FindControl("txtbxFecNac"), TextBox)
            Dim txtbxCierre As TextBox = CType(Me.dvQuincenas.FindControl("txtbxFecCierre"), TextBox)
            Dim tbObservs As TextBox = CType(Me.dvQuincenas.FindControl("tbObservs"), TextBox)
            Dim tbComentarios As TextBox = CType(Me.dvQuincenas.FindControl("tbComentarios"), TextBox)
            Dim chbxAplicarAjusteISPT As CheckBox = CType(Me.dvQuincenas.FindControl("chbxAplicarAjusteISPT"), CheckBox)
            Dim chbxPagoDeRetro As CheckBox = CType(Me.dvQuincenas.FindControl("chbxPagoDeRetro"), CheckBox)
            Dim chbxLiberadaParaPortalAdmvo As CheckBox = CType(Me.dvQuincenas.FindControl("chbxLiberadaParaPortalAdmvo"), CheckBox)
            Dim chbxPermiteABCdeRecibos As CheckBox = CType(Me.dvQuincenas.FindControl("chbxPermiteABCdeRecibos"), CheckBox)
            Dim chbxSubsidiado As CheckBox = CType(Me.dvQuincenas.FindControl("chbxSubsidiado"), CheckBox)

            oQna.IdQuincena = CShort(Request.Params("IdQuincena"))
            oQna.Adicional = CByte(lbltxtNuevaAdic.Text)
            oQna.IdEstatusQuincena = CByte(ddlEstatusQuincena.SelectedValue)
            oQna.PeriodoVacacional = chkbxPeriodoVacacional.Checked
            oQna.FechaDePago = CDate(txtbxFecNac.Text)
            If txtbxCierre.Text.Trim = String.Empty Then
                oQna.FechaCierre = Nothing
            Else
                oQna.FechaCierre = CDate(txtbxCierre.Text)
            End If
            oQna.Observaciones = tbObservs.Text
            oQna.Observaciones2 = tbComentarios.Text
            oQna.AplicarAjusteISPT = chbxAplicarAjusteISPT.Checked
            oQna.PagoDeRetroactividad = chbxPagoDeRetro.Checked
            oQna.LiberadaParaPortalAdmvo = chbxLiberadaParaPortalAdmvo.Checked
            oQna.PermiteABCdeRecibos = chbxPermiteABCdeRecibos.Checked
            oQna.Subsidiado = chbxSubsidiado.Checked

            If Request.Params("TipoOperacion") = "0" Then
                oQna.Actualizar(0, CType(Session("ArregloAuditoria"), String()))
                Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
                Me.lblCapturaExitosa.Text = "Actualización realizada exitosamente."
            ElseIf Request.Params("TipoOperacion") = "1" Then
                oQna.Insertar(CType(Session("ArregloAuditoria"), String()))
                Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
                Me.lblCapturaExitosa.Text = "Quincena adicional creada exitosamente."
            ElseIf Request.Params("TipoOperacion") = "3" Then
                oQna.EliminaPorId(CType(Session("ArregloAuditoria"), String()))
                Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
                Me.lblCapturaExitosa.Text = "Quincena adicional eliminada exitosamente."
            End If
        Catch Ex As Exception
            Me.MultiView1.SetActiveView(Me.viewErrores)
            Me.lblErrores.Text = Ex.Message
        End Try
    End Sub

    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub

    Protected Sub lbOtraOperacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbOtraOperacion.Click
        Response.Redirect(Request.RawUrl)
        'Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub
End Class
