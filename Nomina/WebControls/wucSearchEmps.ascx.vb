Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class WebControls_wucSearchEmps
    Inherits System.Web.UI.UserControl
    Private Sub MuestraFoto()
        'Dim lbVerFoto As LinkButton = CType(FindControl("wucMuestraFoto1").FindControl("lbVerFoto"), LinkButton)
        Dim imgFoto As ImageButton = CType(FindControl("wucMuestraFoto1").FindControl("imgFoto"), ImageButton)
        Dim imgFoto2 As Image = CType(FindControl("wucMuestraFoto1").FindControl("imgFoto2"), Image)
        Dim strNiveles As String = ""
        Dim strRuta As String = ""
        Dim arrayNiveles() As String
        Dim iNiv As Integer
        Dim oEmp As New Empleado
        Dim drEmp As DataRow
        Dim vlServerExpedientes As String = String.Empty

        If Left(Request.ServerVariables("REMOTE_ADDR").ToString, 3) = "10." Or Request.ServerVariables("REMOTE_ADDR").ToString = "::1" Then
            vlServerExpedientes = ConfigurationManager.AppSettings("ServerExpedientes")
        Else
            vlServerExpedientes = ConfigurationManager.AppSettings("ServerExpedientes2")
        End If

        If hfRFC.Value <> String.Empty Then

            strRuta = Request.Url.AbsolutePath
            arrayNiveles = strRuta.Split("/")

            For iNiv = 1 To arrayNiveles.Length - 3
                strNiveles += "../"
            Next

            Try
                If IO.File.Exists(ConfigurationManager.AppSettings("RutaExpedientes") + "Fotos\" + hfNumEmp.Value + ".jpg") Then
                    'imgFoto.ImageUrl = ConfigurationManager.AppSettings("RutaExpedientes") + "Fotos\" + hfNumEmp.Value + ".jpg"
                    'imgFoto2.ImageUrl = ConfigurationManager.AppSettings("RutaExpedientes") + "Fotos\" + hfNumEmp.Value + ".jpg"
                    imgFoto.ImageUrl = vlServerExpedientes + "Fotos/" + hfNumEmp.Value + ".jpg"
                    imgFoto2.ImageUrl = vlServerExpedientes + "Fotos/" + hfNumEmp.Value + ".jpg"
                Else
                    drEmp = oEmp.BuscarPorNumEmp(hfNumEmp.Value)
                    'imgFoto.ImageUrl = ConfigurationManager.AppSettings("RutaExpedientes") + "Fotos\SinFoto" + Right(Left(drEmp("CURP").ToString, 11), 1) + ".jpg"
                    'imgFoto2.ImageUrl = ConfigurationManager.AppSettings("RutaExpedientes") + "Fotos\SinFoto" + Right(Left(drEmp("CURP").ToString, 11), 1) + ".jpg"
                    imgFoto.ImageUrl = vlServerExpedientes + "Fotos/SinFoto" + Right(Left(drEmp("CURP").ToString, 11), 1) + ".jpg"
                    imgFoto2.ImageUrl = vlServerExpedientes + "Fotos/SinFoto" + Right(Left(drEmp("CURP").ToString, 11), 1) + ".jpg"
                End If
                imgFoto.Visible = True
                imgFoto2.Visible = True
            Catch
                imgFoto.ImageUrl = String.Empty
                imgFoto2.ImageUrl = String.Empty
                imgFoto.Visible = False
                imgFoto2.Visible = False
            End Try
        Else
            imgFoto.ImageUrl = String.Empty
            imgFoto2.ImageUrl = String.Empty
            imgFoto.Visible = False
            imgFoto2.Visible = False
            'lbVerFoto.Visible = False
        End If
    End Sub
    Private Sub SetPropertyText_TxtBx(pTxtBxRFC As String, pTxtBxNombre As String, pTxtBxNumEmp As String)
        txtbxRFC.Text = pTxtBxRFC
        txtbxNomEmp.Text = pTxtBxNombre
        txtbxNumEmp.Text = pTxtBxNumEmp
    End Sub
    Public Sub SetButtonVisible(pBtnNewSearch As Boolean, pBtnCancelSearch As Boolean, pBtnSearch As Boolean)
        BtnNewSearch.Visible = pBtnNewSearch
        BtnCancelSearch.Visible = pBtnCancelSearch
        BtnSearch.Visible = pBtnSearch
    End Sub
    Public Sub SetPropertyReadOnly_TxtBx(pTxtBxRFC As Boolean, pTxtBxNombre As Boolean, pTxtBxNumEmp As Boolean)
        txtbxRFC.ReadOnly = pTxtBxRFC
        txtbxNomEmp.ReadOnly = pTxtBxNombre
        txtbxNumEmp.ReadOnly = pTxtBxNumEmp
    End Sub
    Public Sub SetPropertyEnabled_rfv(prfvRFC As Boolean, prfvNombre As Boolean, prfvNumEmp As Boolean)
        rfvRFC.Enabled = prfvRFC
        rfvNombre.Enabled = prfvNombre
        rfvNumEmp.Enabled = prfvNumEmp
    End Sub
    Private Sub FillDatos(dt As DataTable)
        Session.Add("RFCParaCons", dt.Rows(0).Item("rfc"))
        Session.Add("CURPParaCons", dt.Rows(0).Item("curp"))
        Session.Add("ApePatParaCons", dt.Rows(0).Item("apellido_paterno"))
        Session.Add("ApeMatParaCons", dt.Rows(0).Item("apellido_materno"))
        Session.Add("NombreParaCons", dt.Rows(0).Item("nombre"))
        Session.Add("NumEmpParaCons", dt.Rows(0).Item("numemp"))
        txtbxRFC.Text = Session("RFCParaCons")
        txtbxNomEmp.Text = (Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons")).ToString.Trim
        txtbxNumEmp.Text = Session("NumEmpParaCons")
        hfRFC.Value = txtbxRFC.Text
        hfNomEmp.Value = txtbxNomEmp.Text
        hfNumEmp.Value = txtbxNumEmp.Text
        ddlTipoBusqueda.Enabled = False
        BtnNewSearch.Enabled = True
        BtnCancelSearch.Enabled = False
        SetPropertyReadOnly_TxtBx(True, True, True)
        SetPropertyEnabled_rfv(False, False, False)
        BtnSearch.Enabled = False
        pnlPopUp.Visible = False
    End Sub
    Private Sub BuscarEmpleado()
        Dim oEmp As New Empleado
        Dim oUsr As New Usuario
        Dim dr As DataRow
        Dim dt As DataTable
        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        If ddlTipoBusqueda.SelectedValue.ToUpper = "NOMBRE" Then
            oEmp.NomEmp = txtbxNomEmp.Text.Trim.ToUpper
            dt = oEmp.Buscar(Empleado.TipoBusqueda.Nombre, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
        ElseIf ddlTipoBusqueda.SelectedValue.ToUpper = "RFC" Then   'RFC
            oEmp.RFC = txtbxRFC.Text.Trim.ToUpper
            dt = oEmp.Buscar(Empleado.TipoBusqueda.RFC, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
        Else 'Número de empleado
            oEmp.NumEmp = txtbxNumEmp.Text.Trim
            dt = oEmp.Buscar(Empleado.TipoBusqueda.NumeroDeEmpleado, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
        End If

        CType(FindControl("wucMuestraFoto1"), WebControls_wucMuestraFoto).Visible = False
        If dt.Rows.Count = 0 Then
            Me.gvEmpleados.EmptyDataText = "No se encontraron empleados con los criterios de búsqueda establecidos."
            Me.gvEmpleados.DataBind()
            Me.gvEmpleados.Visible = True
            pnlPopUp.Height = System.Web.UI.WebControls.Unit.Percentage(100)
            pnlPopUp.Visible = True
        ElseIf dt.Rows.Count = 1 Then
            FillDatos(dt)
            MuestraFoto()
            CType(FindControl("wucMuestraFoto1"), WebControls_wucMuestraFoto).Visible = True
        Else
            Me.gvEmpleados.DataSource = dt
            Me.gvEmpleados.DataBind()
            Me.gvEmpleados.Visible = True
            pnlPopUp.Visible = True
        End If
    End Sub
    Private Sub CodeSelectedIndexChanged_ddlTipoBusqueda()
        Select Case ddlTipoBusqueda.SelectedValue
            Case "RFC"
                SetPropertyText_TxtBx(String.Empty, String.Empty, String.Empty)
                SetPropertyReadOnly_TxtBx(False, True, True)
                SetPropertyEnabled_rfv(True, False, False)
                txtbxRFC.Focus()
            Case "Nombre"
                SetPropertyText_TxtBx(String.Empty, String.Empty, String.Empty)
                SetPropertyReadOnly_TxtBx(True, False, True)
                SetPropertyEnabled_rfv(False, True, False)
                txtbxNomEmp.Focus()
            Case "NumEmp"
                SetPropertyText_TxtBx(String.Empty, String.Empty, String.Empty)
                SetPropertyReadOnly_TxtBx(True, True, False)
                SetPropertyEnabled_rfv(False, False, True)
                txtbxNumEmp.Focus()
        End Select
    End Sub
    Protected Sub ddlTipoBusqueda_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTipoBusqueda.SelectedIndexChanged
        CodeSelectedIndexChanged_ddlTipoBusqueda()
    End Sub

    Protected Sub BtnSearch_Click(sender As Object, e As System.EventArgs) Handles BtnSearch.Click
        BuscarEmpleado()
    End Sub

    Public Sub PerformClick_BtnSearch()
        BtnSearch_Click(BtnSearch, Nothing)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("RFCParaCons") Is Nothing Then
                ddlTipoBusqueda.Enabled = True
                BtnNewSearch.Enabled = False
                BtnCancelSearch.Enabled = False
                txtbxRFC.Text = String.Empty
                txtbxNomEmp.Text = String.Empty
                txtbxNumEmp.Text = String.Empty
                hfRFC.Value = txtbxRFC.Text
                hfNomEmp.Value = txtbxNomEmp.Text
                hfNumEmp.Value = txtbxNumEmp.Text
                txtbxNumEmp.Focus()
                SetPropertyReadOnly_TxtBx(True, True, False)
                SetPropertyEnabled_rfv(False, False, True)
                BtnSearch.Enabled = True
                MuestraFoto()
                CType(FindControl("wucMuestraFoto1"), WebControls_wucMuestraFoto).Visible = False
            Else
                ddlTipoBusqueda.Enabled = False
                BtnNewSearch.Enabled = True
                BtnCancelSearch.Enabled = False
                txtbxRFC.Text = Session("RFCParaCons")
                txtbxNomEmp.Text = (Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons")).ToString.Trim
                txtbxNumEmp.Text = Session("NumEmpParaCons")
                hfRFC.Value = txtbxRFC.Text
                hfNomEmp.Value = txtbxNomEmp.Text
                hfNumEmp.Value = txtbxNumEmp.Text
                SetPropertyReadOnly_TxtBx(True, True, True)
                SetPropertyEnabled_rfv(False, False, False)
                BtnSearch.Enabled = False
                MuestraFoto()
                CType(FindControl("wucMuestraFoto1"), WebControls_wucMuestraFoto).Visible = True
            End If
        End If
    End Sub

    Protected Sub gvEmpleados_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEmpleados.RowCommand
        Dim gvr As GridViewRow
        Dim RowIndex As Integer

        Try
            gvr = e.CommandSource.NamingContainer
            RowIndex = gvr.RowIndex
        Catch
            gvr = gvEmpleados.Rows(e.CommandArgument)
            RowIndex = gvr.RowIndex
        End Try

        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(gvr.FindControl("LnkBtnRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(gvr.FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(gvr.FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(gvr.FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(gvr.FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(gvr.FindControl("lblNumEmp"), Label).Text)
                txtbxRFC.Text = Session("RFCParaCons")
                txtbxNomEmp.Text = (Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons")).ToString.Trim
                txtbxNumEmp.Text = Session("NumEmpParaCons")
                hfRFC.Value = txtbxRFC.Text
                hfNomEmp.Value = txtbxNomEmp.Text
                hfNumEmp.Value = txtbxNumEmp.Text
                ddlTipoBusqueda.Enabled = False
                BtnNewSearch.Enabled = True
                BtnCancelSearch.Enabled = False
                SetPropertyReadOnly_TxtBx(True, True, True)
                SetPropertyEnabled_rfv(False, False, False)
                BtnSearch.Enabled = False
                pnlPopUp.Visible = False
                MuestraFoto()
                CType(FindControl("wucMuestraFoto1"), WebControls_wucMuestraFoto).Visible = True
                'BtnSearch_ModalPopupExtender.Hide()
            Case "Select"
                'BtnSearch_ModalPopupExtender.Show()
                'MuestraFoto()
                'CType(FindControl("wucMuestraFoto1"), WebControls_wucMuestraFoto).Visible = True
                pnlPopUp.Visible = True
        End Select
    End Sub
    Protected Sub gvEmpleados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmpleados.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                'Dim lb As LinkButton = CType(e.Row.FindControl("lnkbtnrfc"), LinkButton)

                'ScriptManager.GetCurrent(Page).RegisterAsyncPostBackControl(lb)

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvEmpleados, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub imgbtnClose_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgbtnClose.Click, imgbtnClose0.Click
        'BtnSearch_ModalPopupExtender.Hide()
        pnlPopUp.Visible = False
    End Sub
    Public Sub BtnNewSearch_Click2()
        BtnNewSearch_Click(BtnNewSearch, Nothing)
    End Sub

    Protected Sub BtnNewSearch_Click(sender As Object, e As System.EventArgs) Handles BtnNewSearch.Click     
        ddlTipoBusqueda.Enabled = True
        BtnNewSearch.Enabled = False
        BtnCancelSearch.Enabled = True
        txtbxRFC.Text = String.Empty
        txtbxNomEmp.Text = String.Empty
        txtbxNumEmp.Text = String.Empty
        hfRFC.Value = txtbxRFC.Text
        hfNomEmp.Value = txtbxNomEmp.Text
        hfNumEmp.Value = txtbxNumEmp.Text
        CodeSelectedIndexChanged_ddlTipoBusqueda()
        BtnSearch.Enabled = True
        MuestraFoto()
        CType(FindControl("wucMuestraFoto1"), WebControls_wucMuestraFoto).Visible = False
    End Sub

    Protected Sub BtnCancelSearch_Click(sender As Object, e As System.EventArgs) Handles BtnCancelSearch.Click
        ddlTipoBusqueda.Enabled = False
        BtnNewSearch.Enabled = True
        BtnCancelSearch.Enabled = False
        If Session("RFCParaCons") Is Nothing Then
            txtbxRFC.Text = String.Empty
            txtbxNomEmp.Text = String.Empty
            txtbxNumEmp.Text = String.Empty
            hfRFC.Value = txtbxRFC.Text
            hfNomEmp.Value = txtbxNomEmp.Text
            hfNumEmp.Value = txtbxNumEmp.Text
        Else
            txtbxRFC.Text = Session("RFCParaCons")
            txtbxNomEmp.Text = (Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons")).ToString.Trim
            txtbxNumEmp.Text = Session("NumEmpParaCons")
            hfRFC.Value = txtbxRFC.Text
            hfNomEmp.Value = txtbxNomEmp.Text
            hfNumEmp.Value = txtbxNumEmp.Text
        End If
        SetPropertyReadOnly_TxtBx(True, True, True)
        SetPropertyEnabled_rfv(False, False, False)
        BtnSearch.Enabled = False
        pnlPopUp.Visible = False
        MuestraFoto()
        CType(FindControl("wucMuestraFoto1"), WebControls_wucMuestraFoto).Visible = True
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        pnlPopUp.Visible = False
    End Sub

    'Protected Sub lnkbtnrfc_DataBinding(sender As Object, e As System.EventArgs)
    '    Dim lb As LinkButton = sender
    '    Dim sm As ScriptManager = CType(Me.Page.Master.FindControl("ScriptManager1"), ScriptManager)

    '    sm.RegisterAsyncPostBackControl(lb)

    'End Sub

    'Protected Sub lnkbtnrfc_Click(sender As Object, e As System.EventArgs)
    '    'Session.Add("RFCParaCons", CType(gvr.FindControl("LnkBtnRFC"), LinkButton).Text)
    '    'Session.Add("CURPParaCons", CType(gvr.FindControl("lblCURP"), Label).Text)
    '    'Session.Add("ApePatParaCons", CType(gvr.FindControl("lblApePat"), Label).Text)
    '    'Session.Add("ApeMatParaCons", CType(gvr.FindControl("lblApeMat"), Label).Text)
    '    'Session.Add("NombreParaCons", CType(gvr.FindControl("lblNombre"), Label).Text)
    '    'Session.Add("NumEmpParaCons", CType(gvr.FindControl("lblNumEmp"), Label).Text)
    '    txtbxRFC.Text = Session("RFCParaCons")
    '    txtbxNomEmp.Text = (Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons")).ToString.Trim
    '    txtbxNumEmp.Text = Session("NumEmpParaCons")
    '    hfRFC.Value = txtbxRFC.Text
    '    hfNomEmp.Value = txtbxNomEmp.Text
    '    hfNumEmp.Value = txtbxNumEmp.Text
    '    ddlTipoBusqueda.Enabled = False
    '    BtnNewSearch.Enabled = True
    '    BtnCancelSearch.Enabled = False
    '    SetPropertyReadOnly_TxtBx(True, True, True)
    '    SetPropertyEnabled_rfv(False, False, False)
    '    BtnSearch.Enabled = False
    '    pnlPopUp.Visible = False
    'End Sub
End Class
