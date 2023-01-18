Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Imports System.IO.Stream
Imports System.IO.StreamWriter
 
Partial Class PagomaticoTXT
    Inherits System.Web.UI.Page
    Private Sub DescargaArchivo(ByVal pFile As String)
        Response.ContentType = "text/plain"
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + pFile) 'drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString)
        Response.TransmitFile(Server.MapPath("~/Pagomatico/" + pFile)) 'drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString))
        Response.End()
        'HttpContext.Current.Response.End()
    End Sub
    Private Sub BindddlAños()
        Dim oQna As New Quincenas
        With Me.ddlAños
            .DataSource = oQna.ObtenAños(True)
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
                Me.btnConsultarQuincenas.Enabled = False
            Else
                Me.btnConsultarQuincenas.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindQuincenas()
        Dim oQna As New Quincenas
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue))
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0
        End If
    End Sub
    Private Sub BindddlBancos()
        Dim ddlAux As New DropDownList
        Dim oBanco As New Bancos
        Dim li As ListItem
        LlenaDDL(Me.ddlBancos, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
        LlenaDDL(ddlAux, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
        li = Me.ddlBancos.Items.FindByText("SIN DEFINIR")
        If li Is Nothing = False Then
            Me.ddlBancos.Items.Remove(li)
            ddlAux.Items.Remove(li)
        End If

        'Código agregado para los casos de pensión alimenticia
        For Each Item As ListItem In ddlAux.Items
            If Item.Text.Contains("BANAMEX") Then
                Me.ddlBancos.Items.Add(New ListItem(Item.Text.Trim + " (PENSION ALIMENTICIA)", Item.Value + "." + Item.Value + "PA"))
                Me.ddlBancos.Items.Add(New ListItem(Item.Text.Trim + " (PENSION ALIMENTICIA CLABE)", Item.Value + "." + Item.Value + "PACLABE"))
                Me.ddlBancos.Items.Add(New ListItem(Item.Text.Trim + " (PENSION ALIMENTICIA LAYOUT C)", Item.Value + "." + Item.Value + "PALAYOUTC"))
            ElseIf Item.Text.Contains("BANCOMER") Then
                Me.ddlBancos.Items.Add(New ListItem(Item.Text.Trim + " (PENSION ALIMENTICIA)", Item.Value + "." + Item.Value + "PA"))
            ElseIf Item.Text.Contains("BANORTE") Then
                Me.ddlBancos.Items.Add(New ListItem(Item.Text.Trim + " (CLABE)", Item.Value + "." + Item.Value + "NCLABE"))
                Me.ddlBancos.Items.Add(New ListItem(Item.Text.Trim + " (PENSION ALIMENTICIA)", Item.Value + "." + Item.Value + "PA"))
                Me.ddlBancos.Items.Add(New ListItem(Item.Text.Trim + " (PENSION ALIMENTICIA CLABE)", Item.Value + "." + Item.Value + "PACLABE"))
            End If
        Next
        'Código agregado para los casos de pensión alimenticia

    End Sub
    Private Sub CreaLinkParaImpresion()
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Dim oBanco As New Bancos
        Dim drBanco As DataRow
        Dim drBanco2 As DataRow
        Dim vlCompNomArchDisp As String

        drBanco = oBanco.ObtenPorId(CByte(Left(ddlBancos.SelectedValue, 1)))

        If Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA)") Then
            'If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + Me.ddlBancos.Items.FindByValue(Left(Me.ddlBancos.SelectedValue, 1)).Text + "PA_" + lblQuincena.Text.Replace("-", "_") + ".txt") Then
            If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + "PA_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                Me.ibDescargar.Enabled = True
                lblMsjDescargar.Text = "Descargar archivo"
            Else
                Me.ibDescargar.Enabled = False
                lblMsjDescargar.Text = "Archivo sin generar"
            End If
        ElseIf Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA CLABE)") Then
            'If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + Me.ddlBancos.Items.FindByValue(Left(Me.ddlBancos.SelectedValue, 1)).Text + "PACLABE_" + lblQuincena.Text.Replace("-", "_") + ".txt") Then
            If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + "PACLABE_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                Me.ibDescargar.Enabled = True
                lblMsjDescargar.Text = "Descargar archivo"
            Else
                Me.ibDescargar.Enabled = False
                lblMsjDescargar.Text = "Archivo sin generar"
            End If
        ElseIf Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA LAYOUT C)") Then
            'If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + Me.ddlBancos.Items.FindByValue(Left(Me.ddlBancos.SelectedValue, 1)).Text + "PALAYOUTC_" + lblQuincena.Text.Replace("-", "_") + ".txt") Then
            If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + "PALAYOUTC_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                Me.ibDescargar.Enabled = True
                lblMsjDescargar.Text = "Descargar archivo"
            Else
                Me.ibDescargar.Enabled = False
                lblMsjDescargar.Text = "Archivo sin generar"
            End If
        Else
            vlCompNomArchDisp = String.Empty
            If drBanco("NombreCortoBanco").ToString = "BANORTE" Then
                If Me.ddlBancos.SelectedItem.Text.Contains("(CLABE)") Then
                    drBanco2 = oBanco.ObtenSecuencialBANORTE(CByte(ddlBancos.SelectedValue), CShort(lblIdQuincena.Text), "N")
                    vlCompNomArchDisp = drBanco2("CompParaNombreArchivDisp").ToString
                    If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_NCLABE_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                        Me.ibDescargar.Enabled = True
                        lblMsjDescargar.Text = "Descargar archivo"
                    Else
                        Me.ibDescargar.Enabled = False
                        lblMsjDescargar.Text = "Archivo sin generar"
                    End If
                Else
                    drBanco2 = oBanco.ObtenSecuencialBANORTE(CByte(ddlBancos.SelectedValue), CShort(lblIdQuincena.Text), "N")
                    vlCompNomArchDisp = drBanco2("CompParaNombreArchivDisp").ToString
                    If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                        Me.ibDescargar.Enabled = True
                        lblMsjDescargar.Text = "Descargar archivo"
                    Else
                        Me.ibDescargar.Enabled = False
                        lblMsjDescargar.Text = "Archivo sin generar"
                    End If
                End If
            Else
                If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                    Me.ibDescargar.Enabled = True
                    lblMsjDescargar.Text = "Descargar archivo"
                Else
                    Me.ibDescargar.Enabled = False
                    lblMsjDescargar.Text = "Archivo sin generar"
                End If
            End If
            'If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + Me.ddlBancos.SelectedItem.Text + "_" + lblQuincena.Text.Replace("-", "_") + ".txt") Then

        End If
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Protected Sub gvQuincenas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuincenas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim oPlantel As New Plantel
            Dim drBanco As DataRow
            Dim oBanco As New Bancos
            Dim vlCons As Integer

            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindQuincenas()
                BindddlBancos()

                drBanco = oBanco.ObtenPorId(CByte(Left(ddlBancos.SelectedValue, 1)))

                For vlCons = 1 To 99 Step 1
                    ddlCons.Items.Add(New ListItem(vlCons.ToString.PadLeft(2, "0"), vlCons.ToString.PadLeft(2, "0")))
                Next

                ddlCons.Enabled = CBool(drBanco("ReqConsecutivo"))
                ddlCons.SelectedIndex = 0
                txtbxFecha.Text = String.Empty
                txtbxFecha.Enabled = CBool(drBanco("ReqFechaPago"))
                'CreaLinkParaImpresion()
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        BindQuincenas()
        'CreaLinkParaImpresion()
    End Sub

    Protected Sub ddlBancos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBancos.SelectedIndexChanged
        'CreaLinkParaImpresion()
        Dim drBanco As DataRow
        Dim oBanco As New Bancos

        drBanco = oBanco.ObtenPorId(CByte(Left(ddlBancos.SelectedValue, 1)))
        ddlCons.Enabled = CBool(drBanco("ReqConsecutivo"))
        ddlCons.SelectedIndex = 0
        txtbxFecha.Text = String.Empty
        txtbxFecha.Enabled = CBool(drBanco("ReqFechaPago"))
    End Sub

    Protected Sub ibDescargar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibDescargar.Click
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim oBanco As New Bancos
        Dim drBanco As DataRow
        Dim drBanco2 As DataRow
        Dim vlCompNomArchDisp As String

        drBanco = oBanco.ObtenPorId(CByte(Left(ddlBancos.SelectedValue, 1)))

        If Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA)") Then
            'If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + Me.ddlBancos.Items.FindByValue(Left(Me.ddlBancos.SelectedValue, 1)).Text + "PA_" + lblQuincena.Text.Replace("-", "_") + ".txt") Then
            If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + "PA_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                Response.ContentType = "text/plain"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + drBanco("NombreParaArchivosDisp").ToString + "PA_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString)
                Response.TransmitFile(Server.MapPath("~/Pagomatico/" + drBanco("NombreParaArchivosDisp").ToString + "PA_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString))
                Response.End()
            End If
        ElseIf Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA CLABE)") Then
            If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + "PACLABE_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                Response.ContentType = "text/plain"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + drBanco("NombreParaArchivosDisp").ToString + "PACLABE_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString)
                Response.TransmitFile(Server.MapPath("~/Pagomatico/" + drBanco("NombreParaArchivosDisp").ToString + "PACLABE_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString))
                Response.End()
            End If
        ElseIf Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA LAYOUT C)") Then
            If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + "PALAYOUTC_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                Response.ContentType = "text/plain"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + drBanco("NombreParaArchivosDisp").ToString + "PALAYOUTC_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString)
                Response.TransmitFile(Server.MapPath("~/Pagomatico/" + drBanco("NombreParaArchivosDisp").ToString + "PALAYOUTC_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString))
                Response.End()
            End If
        Else
            vlCompNomArchDisp = String.Empty
            If drBanco("NombreCortoBanco").ToString = "BANORTE" Then
                If Me.ddlBancos.SelectedItem.Text.Contains("(CLABE)") Then
                    drBanco2 = oBanco.ObtenSecuencialBANORTE(CByte(ddlBancos.SelectedValue), CShort(lblIdQuincena.Text), "N")
                    vlCompNomArchDisp = drBanco2("CompParaNombreArchivDisp").ToString
                    If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_NCLABE_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                        Response.ContentType = "text/plain"
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_NCLABE" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString)
                        Response.TransmitFile(Server.MapPath("~/Pagomatico/" + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_NCLABE_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString))
                        Response.End()
                    End If
                Else
                    drBanco2 = oBanco.ObtenSecuencialBANORTE(CByte(ddlBancos.SelectedValue), CShort(lblIdQuincena.Text), "N")
                    vlCompNomArchDisp = drBanco2("CompParaNombreArchivDisp").ToString
                    If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                        Response.ContentType = "text/plain"
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString)
                        Response.TransmitFile(Server.MapPath("~/Pagomatico/" + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString))
                        Response.End()
                    End If
                End If
            Else
                If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                    Response.ContentType = "text/plain"
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString)
                    Response.TransmitFile(Server.MapPath("~/Pagomatico/" + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString))
                    Response.End()
                End If
            End If
        End If
    End Sub
    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'CreaLinkParaImpresion()
    End Sub

    Protected Sub ibGenerarTXT_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibGenerarTXT.Click
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter = Nothing
        Dim oNomina As New Nomina
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Dim oBanco As New Bancos
        Dim drBanco As DataRow
        Dim vlCompNomArchDisp As String = String.Empty
        Dim dt As New DataTable

        Dim FilePath As String
        Dim File As String = String.Empty
        Dim vlSecuencial As String = String.Empty
        Dim vlSecuencial2 As String = String.Empty
        Dim vlFechaPago As Date = "31/12/2099"

        Try
            drBanco = oBanco.ObtenPorId(CByte(Left(ddlBancos.SelectedValue, 1)))

            If ddlCons.Enabled Then
                If Me.ddlBancos.SelectedItem.Text.Contains("BANORTE") Then
                    vlSecuencial = ddlCons.SelectedValue
                End If
                vlSecuencial2 = ddlCons.SelectedValue
                vlFechaPago = CDate(IIf(txtbxFecha.Text.Trim = String.Empty, "31/12/2099", txtbxFecha.Text))
            End If

            If Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA)") Then
                File = drBanco("NombreParaArchivosDisp").ToString + vlSecuencial + "_PA_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString
                FilePath = ConfigurationManager.AppSettings("RutaPagomatico") + File
            ElseIf Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA CLABE)") Then
                File = drBanco("NombreParaArchivosDisp").ToString + vlSecuencial + "_PACLABE_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString
                FilePath = ConfigurationManager.AppSettings("RutaPagomatico") + File
            ElseIf Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA LAYOUT C)") Then
                File = drBanco("NombreParaArchivosDisp").ToString + vlSecuencial + "_PALAYC_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString
                FilePath = ConfigurationManager.AppSettings("RutaPagomatico") + File
            ElseIf Me.ddlBancos.SelectedItem.Text.Contains("(CLABE)") Then
                File = drBanco("NombreParaArchivosDisp").ToString + vlSecuencial + "_NCLABE_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString
                FilePath = ConfigurationManager.AppSettings("RutaPagomatico") + File
            Else
                File = drBanco("NombreParaArchivosDisp").ToString + vlSecuencial + "_" + lblQuincena.Text.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString
                FilePath = ConfigurationManager.AppSettings("RutaPagomatico") + File
            End If

            System.IO.File.Delete(FilePath)
            strStreamW = System.IO.File.OpenWrite(FilePath)
            strStreamWriter = New System.IO.StreamWriter(strStreamW, System.Text.Encoding.ASCII)

            If Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA)") Then
                If ddlCons.Enabled Then
                    dt = oNomina.GeneraTXTPagomaticoPA(CByte(Left(Me.ddlBancos.SelectedValue, 1)), CShort(lblIdQuincena.Text), vlSecuencial2, vlFechaPago)
                Else
                    dt = oNomina.GeneraTXTPagomaticoPA(CByte(Left(Me.ddlBancos.SelectedValue, 1)), CShort(lblIdQuincena.Text))
                End If
            ElseIf Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA CLABE)") Then
                If ddlCons.Enabled Then
                    dt = oNomina.GeneraTXTPagomaticoPACLABE(CByte(Left(Me.ddlBancos.SelectedValue, 1)), CShort(lblIdQuincena.Text), vlSecuencial2, vlFechaPago)
                Else
                    dt = oNomina.GeneraTXTPagomaticoPACLABE(CByte(Left(Me.ddlBancos.SelectedValue, 1)), CShort(lblIdQuincena.Text))
                End If
            ElseIf Me.ddlBancos.SelectedItem.Text.Contains("(CLABE)") Then
                If ddlCons.Enabled Then
                    dt = oNomina.GeneraTXTPagomaticoCLABE(CByte(Left(Me.ddlBancos.SelectedValue, 1)), CShort(lblIdQuincena.Text), vlSecuencial2, vlFechaPago, True)
                Else
                    dt = oNomina.GeneraTXTPagomaticoCLABE(CByte(Left(Me.ddlBancos.SelectedValue, 1)), CShort(lblIdQuincena.Text), True)
                End If
            ElseIf Me.ddlBancos.SelectedItem.Text.Contains("(PENSION ALIMENTICIA LAYOUT C)") Then
                dt = oNomina.GeneraTXTPagomaticoPALayoutC(CByte(Left(Me.ddlBancos.SelectedValue, 1)), CShort(lblIdQuincena.Text))
            Else
                If ddlCons.Enabled Then
                    dt = oNomina.GeneraTXTPagomatico(CByte(Me.ddlBancos.SelectedValue), CShort(lblIdQuincena.Text), vlSecuencial2, vlFechaPago)
                Else
                    dt = oNomina.GeneraTXTPagomatico(CByte(Me.ddlBancos.SelectedValue), CShort(lblIdQuincena.Text))
                End If
            End If

            Dim dr As System.Data.DataRow

            For Each dr In dt.Rows
                strStreamWriter.WriteLine(dr(0).ToString)
            Next

            strStreamWriter.Close()

            DescargaArchivo(File)

        Catch ext As Threading.ThreadAbortException
            strStreamWriter = Nothing
        Catch ex As Exception
            strStreamWriter = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub
End Class