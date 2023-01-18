Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV.MovsDePersonal

Partial Class MovsDePersonal_OrdenesDePres
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub

    Private Sub BindddlAños()
        Dim oEjercicioFiscal As New EjercicioFiscal
        With Me.ddlAños
            .DataSource = oEjercicioFiscal.ObtenAños()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, New ListItem("No existe información de ejercicios", "-1"))
                Me.btnConsultar.Enabled = False
            Else
                Me.btnConsultar.Enabled = True
            End If
        End With
    End Sub

    Private Sub BindgvOPs()
        Dim oUsr As New Usuario
        Dim drUsr As DataRow

        drUsr = oUsr.ObtenerPorLogin(Session("Login"))

        Dim oOrdenPres As New OrdenesDePresentacion
        Me.gvOPs.DataSource = oOrdenPres.ObtenPorEjercUsr(Session("Login"), CShort(Me.ddlAños.SelectedValue))
        Me.gvOPs.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oUsr As New Usuario
            Dim dt As DataTable
            BindddlAños()
            BindgvOPs()
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "OrdenesDePresentacion")
            Me.lbCrearNuevaOP.Visible = CBool(dt.Rows(0).Item("Insercion"))
            Me.gvOPs.Columns(16).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            Me.gvOPs.Columns(17).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
            Me.gvOPs.Columns(18).Visible = CBool(dt.Rows(0).Item("Consulta"))
        End If
    End Sub

    Protected Sub gvCadenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub

    Protected Sub ibEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'Dim ibEliminar As ImageButton = CType(sender, ImageButton)
        'Dim Fila As GridViewRow = CType(ibEliminar.NamingContainer, GridViewRow)

        'Dim lblIdCadena As Label = CType(Me.gvOPs.Rows(Fila.RowIndex).FindControl("lblIdCadena"), Label)

        'Dim oCadena As New Cadenas

        'oCadena.Elimina(CInt(lblIdCadena.Text), CType(Session("ArregloAuditoria"), String()))

        'BindgvOPs()
    End Sub

    Protected Sub lbCrearNuevaOP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oOrdDePres As New OrdenesDePresentacion
        Dim oUsr As New Usuario
        Dim drUsr As DataRow

        oUsr.Login = Session("Login")
        drUsr = oUsr.ObtenerPorLogin()

        oOrdDePres.GeneraNueva(Session("Login"), CType(Session("ArregloAuditoria"), String()))
        BindgvOPs()
    End Sub

    Protected Sub gvOPs_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs)
        Me.gvOPs.Columns(0).Visible = True 'Select
        Me.gvOPs.SelectedIndex = e.RowIndex
        Me.gvOPs.EditIndex = -1
        BindgvOPs()

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "OrdenesDePresentacion")
        Me.lbCrearNuevaOP.Visible = CBool(dt.Rows(0).Item("Insercion"))
        Me.gvOPs.Columns(16).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        Me.gvOPs.Columns(17).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
        Me.gvOPs.Columns(18).Visible = CBool(dt.Rows(0).Item("Consulta"))
    End Sub

    Protected Sub gvOPs_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim oUsr As New Usuario
        Dim drUsr As DataRow
        If Me.gvOPs.EditIndex = -1 Then
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblIdUsuarioCreador As Label = CType(e.Row.FindControl("lblIdUsuarioCreador"), Label)
                    Dim lblIdUsuarioModifico As Label = CType(e.Row.FindControl("lblIdUsuarioModifico"), Label)
                    Dim lblLoginCreador As Label = CType(e.Row.FindControl("lblLoginCreador"), Label)
                    Dim lblLoginModifico As Label = CType(e.Row.FindControl("lblLoginModifico"), Label)
                    Dim ibVerOP As ImageButton = CType(e.Row.FindControl("ibVerOP"), ImageButton)
                    Dim lblIdOrdenDePres As Label = CType(e.Row.FindControl("lblIdOrdenDePres"), Label)
                    Dim lblNumCadena As Label = CType(e.Row.FindControl("lblNumCadena"), Label)
                    Dim lblIdCadena As Label = CType(e.Row.FindControl("lblIdCadena"), Label)
                    Dim lnkbtnNumCadena As LinkButton = CType(e.Row.FindControl("lnkbtnNumCadena"), LinkButton)
                    Dim chkbxSePuedeModificar As CheckBox = CType(e.Row.FindControl("chkbxSePuedeModificar"), CheckBox)
                    Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
                    Dim oOrdPres As New OrdenesDePresentacion
                    Dim drOrdPres As DataRow

                    'Inicio: Determinamos si la orden de presentación es Interina o Provisional
                    drOrdPres = oOrdPres.ObtenTipo(CInt(lblIdOrdenDePres.Text))
                    'Fin: Determinamos si la orden de presentación es Interina o Provisional

                    lblNumCadena.Visible = lblNumCadena.Text = "N/A"
                    lnkbtnNumCadena.Visible = lblNumCadena.Text <> "N/A"
                    lnkbtnNumCadena.OnClientClick = "javascript:abreVentMediaScreen('../Cadenas/CadenaMovsAsociados.aspx?IdCadena=" + lblIdCadena.Text + "','" + lblIdCadena.Text + "'); return false;"

                    ibEditar.Visible = chkbxSePuedeModificar.Checked

                    'Inicio: Seleccionamos el tipo de reporte que deberá mostrarse
                    If drOrdPres("TipoOrdenDePres").ToString = "IPH" Then 'Orden de presentación interina por horas
                        ibVerOP.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?IdOrdenDePres=" + lblIdOrdenDePres.Text + "&IdReporte=73','OP_" + lblIdOrdenDePres.Text + "'); return false;"
                    ElseIf drOrdPres("TipoOrdenDePres").ToString = "PPH" Then 'Orden de presentación provisional por horas
                        ibVerOP.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?IdOrdenDePres=" + lblIdOrdenDePres.Text + "&IdReporte=74','OP_" + lblIdOrdenDePres.Text + "'); return false;"
                    ElseIf drOrdPres("TipoOrdenDePres").ToString = "IPP" Then 'Orden de presentación interina por plaza
                        ibVerOP.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?IdOrdenDePres=" + lblIdOrdenDePres.Text + "&IdReporte=75','OP_" + lblIdOrdenDePres.Text + "'); return false;"
                        '+ "?IdPlaza=" + drOrdPres("IdPlaza").ToString + "&IdReporte=75','OP_" + lblIdOrdenDePres.Text + "'); return false;"
                    ElseIf drOrdPres("TipoOrdenDePres").ToString = "PPP" Then 'Orden de presentación provisional por plaza
                        ibVerOP.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                     + "?IdOrdenDePres=" + lblIdOrdenDePres.Text + "&IdReporte=76','OP_" + lblIdOrdenDePres.Text + "'); return false;"
                        '+ "?IdPlaza=" + drOrdPres("IdPlaza").ToString + "&IdReporte=76','OP_" + lblIdOrdenDePres.Text + "'); return false;"
                    End If
                    'Fin: Seleccionamos el tipo de reporte que deberá mostrarse

                    oUsr.IdUsuario = CShort(lblIdUsuarioCreador.Text)
                    drUsr = oUsr.ObtenerPorId()
                    lblLoginCreador.Text = drUsr("Login")
                    lblLoginCreador.ToolTip = drUsr("NomComUsr")

                    If lblIdUsuarioModifico.Text <> String.Empty Then
                        oUsr.IdUsuario = CShort(lblIdUsuarioModifico.Text)
                        drUsr = oUsr.ObtenerPorId()
                        lblLoginModifico.Text = drUsr("Login")
                        lblLoginModifico.ToolTip = drUsr("NomComUsr")
                    End If

                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            End Select
        Else
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblIdUsuarioCreador_E As Label = CType(e.Row.FindControl("lblIdUsuarioCreador_E"), Label)
                    Dim lblIdUsuarioModifico_E As Label = CType(e.Row.FindControl("lblIdUsuarioModifico_E"), Label)
                    Dim lblLoginCreador_E As Label = CType(e.Row.FindControl("lblLoginCreador_E"), Label)
                    Dim lblLoginModifico_E As Label = CType(e.Row.FindControl("lblLoginModifico_E"), Label)
                    Dim lblNumCadena As Label = CType(e.Row.FindControl("lblNumCadena_E"), Label)
                    Dim lblIdCadena As Label = CType(e.Row.FindControl("lblIdCadena_E"), Label)
                    Dim lnkbtnNumCadena As LinkButton = CType(e.Row.FindControl("lnkbtnNumCadena_E"), LinkButton)

                    If lblIdUsuarioCreador_E Is Nothing Then
                        lblIdUsuarioCreador_E = CType(e.Row.FindControl("lblIdUsuarioCreador"), Label)
                        lblIdUsuarioModifico_E = CType(e.Row.FindControl("lblIdUsuarioModifico"), Label)
                        lblLoginCreador_E = CType(e.Row.FindControl("lblLoginCreador"), Label)
                        lblLoginModifico_E = CType(e.Row.FindControl("lblLoginModifico"), Label)
                        lblNumCadena = CType(e.Row.FindControl("lblNumCadena"), Label)
                        lblIdCadena = CType(e.Row.FindControl("lblIdCadena"), Label)
                        lnkbtnNumCadena = CType(e.Row.FindControl("lnkbtnNumCadena"), LinkButton)
                    End If

                    lblNumCadena.Visible = lblNumCadena.Text = "N/A"
                    lnkbtnNumCadena.Visible = lblNumCadena.Text <> "N/A"
                    lnkbtnNumCadena.OnClientClick = "javascript:abreVentMediaScreen('../Cadenas/CadenaMovsAsociados.aspx?IdCadena=" + lblIdCadena.Text + "','" + lblIdCadena.Text + "'); return false;"

                    oUsr.IdUsuario = CShort(lblIdUsuarioCreador_E.Text)
                    drUsr = oUsr.ObtenerPorId()
                    lblLoginCreador_E.Text = drUsr("Login")
                    lblLoginCreador_E.ToolTip = drUsr("NomComUsr")

                    If lblIdUsuarioModifico_E.Text <> String.Empty Then
                        oUsr.IdUsuario = CShort(lblIdUsuarioModifico_E.Text)
                        drUsr = oUsr.ObtenerPorId()
                        lblLoginModifico_E.Text = drUsr("Login")
                        lblLoginModifico_E.ToolTip = drUsr("NomComUsr")
                    End If
            End Select

        End If
    End Sub

    Protected Sub gvOPs_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)

    End Sub

    Protected Sub gvOPs_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs)
        Me.gvOPs.Columns(0).Visible = False 'Select
        Me.gvOPs.Columns(17).Visible = False 'Delete
        Me.gvOPs.Columns(18).Visible = False 'VerOP
        Me.gvOPs.SelectedIndex = -1
        Me.gvOPs.EditIndex = e.NewEditIndex
        BindgvOPs()

        Dim fila As Integer = Me.gvOPs.EditIndex
        Dim lblIdEstatusOP_E As Label = CType(Me.gvOPs.Rows(fila).FindControl("lblIdEstatusOP_E"), Label)
        Dim lblIdOrigenPropuesta_E As Label = CType(Me.gvOPs.Rows(fila).FindControl("lblIdOrigenPropuesta_E"), Label)
        Dim ddlEstatusActualOP_E As DropDownList = CType(Me.gvOPs.Rows(fila).FindControl("ddlEstatusActualOP_E"), DropDownList)
        Dim ddlOrigenPropuesta_E As DropDownList = CType(Me.gvOPs.Rows(fila).FindControl("ddlOrigenPropuesta_E"), DropDownList)

        Dim oOrdDePres As New OrdenesDePresentacion
        Dim oOrigProp As New OrigenPropuestas

        LlenaDDL(ddlEstatusActualOP_E, "EstatusOP", "IdEstatusOP", oOrdDePres.ObtenPosiblesEstatus(), lblIdEstatusOP_E.Text)
        LlenaDDL(ddlOrigenPropuesta_E, "OrigenPropuesta", "IdOrigenPropuesta", oOrigProp.ObtenOrigenPropuestas(), lblIdOrigenPropuesta_E.Text)

    End Sub

    Protected Sub gvOPs_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs)
        If Me.gvOPs.EditIndex <> -1 Then
            Dim lblIdOrdenDePres_E As Label = CType(Me.gvOPs.Rows(e.RowIndex).FindControl("lblIdOrdenDePres_E"), Label)
            Dim tbOficioDePropuesta_E As TextBox = CType(Me.gvOPs.Rows(e.RowIndex).FindControl("tbOficioDePropuesta_E"), TextBox)
            Dim tbFchParaOrdDePres_E As TextBox = CType(Me.gvOPs.Rows(e.RowIndex).FindControl("tbFchParaOrdDePres_E"), TextBox)
            Dim ddlEstatusActualOP_E As DropDownList = CType(Me.gvOPs.Rows(e.RowIndex).FindControl("ddlEstatusActualOP_E"), DropDownList)
            Dim ddlOrigenPropuesta_E As DropDownList = CType(Me.gvOPs.Rows(e.RowIndex).FindControl("ddlOrigenPropuesta_E"), DropDownList)

            Dim oOrdPres As New OrdenesDePresentacion

            oOrdPres.ActualizaInf(CInt(lblIdOrdenDePres_E.Text), tbFchParaOrdDePres_E.Text.Trim, tbOficioDePropuesta_E.Text, _
                                Session("Login"), CByte(ddlEstatusActualOP_E.SelectedValue), _
                                CByte(ddlOrigenPropuesta_E.SelectedValue), CType(Session("ArregloAuditoria"), String()))

            Me.gvOPs.Columns(0).Visible = True 'Select
            Me.gvOPs.SelectedIndex = e.RowIndex
            Me.gvOPs.EditIndex = -1
            BindgvOPs()

            Dim oUsr As New Usuario
            Dim dt As DataTable
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "OrdenesDePresentacion")
            Me.lbCrearNuevaOP.Visible = CBool(dt.Rows(0).Item("Insercion"))
            Me.gvOPs.Columns(16).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
            Me.gvOPs.Columns(17).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
            Me.gvOPs.Columns(18).Visible = CBool(dt.Rows(0).Item("Consulta"))
        End If
    End Sub

    Protected Sub gvOPs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindgvOPs()
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindgvOPs()
    End Sub

    'Protected Sub btnExport_Click(sender As Object, e As System.EventArgs) Handles btnExport.Click
    '    Dim oUsr As New Usuario
    '    Dim drUsr As DataRow

    '    drUsr = oUsr.ObtenerPorLogin(Session("Login"))

    '    Dim oOrdenPres As New OrdenesDePresentacion
    '    Me.gvForExport.DataSource = oOrdenPres.ObtenPorEjercUsr(Session("Login"), CShort(Me.ddlAños.SelectedValue))
    '    Me.gvForExport.DataBind()

    '    ExportToExcel("Informe.xls", gvForExport)
    'End Sub

    'Private Sub ExportToExcel(ByVal nameReport As String, ByVal wControl As GridView)
    '    Dim responsePage As HttpResponse = Response
    '    Dim sw As New System.IO.StringWriter()
    '    Dim htw As New HtmlTextWriter(sw)
    '    Dim pageToRender As New Page()
    '    Dim form As New HtmlForm()
    '    form.Controls.Add(wControl)
    '    pageToRender.Controls.Add(form)
    '    responsePage.Clear()
    '    responsePage.Buffer = True
    '    responsePage.ContentType = "application/vnd.ms-excel"
    '    responsePage.AddHeader("Content-Disposition", "attachment;filename=" & nameReport)
    '    responsePage.Charset = "UTF-8"
    '    responsePage.ContentEncoding = Encoding.Default
    '    pageToRender.RenderControl(htw)
    '    responsePage.Write(sw.ToString())
    '    responsePage.End()
    'End Sub

    'Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
    '    Response.Clear()
    '    Response.Buffer = True

    '    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
    '    Response.Charset = ""
    '    Response.ContentType = "application/vnd.ms-excel"

    '    Dim sw As New System.IO.StringWriter()
    '    Dim hw As New HtmlTextWriter(sw)
    '    Dim gv As New GridView
    '    Dim oUsr As New Usuario
    '    Dim drUsr As DataRow

    '    drUsr = oUsr.ObtenerPorLogin(Session("Login"))

    '    Dim oOrdenPres As New OrdenesDePresentacion
    '    gv.DataSource = oOrdenPres.ObtenPorEjercUsr(Session("Login"), CShort(Me.ddlAños.SelectedValue))
    '    gv.AllowPaging = False
    '    gv.DataBind()

    '    gv.RenderControl(hw)

    '    'style to format numbers to string
    '    Dim style As String = "<style>.textmode{mso-number-format:\@;}</style>"
    '    Response.Write(style)
    '    Response.Output.Write(sw.ToString())
    '    Response.Flush()
    '    Response.End()
    'End Sub
End Class
