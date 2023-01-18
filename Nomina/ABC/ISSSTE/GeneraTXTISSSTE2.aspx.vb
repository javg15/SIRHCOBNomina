Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Imports System.IO.Stream
Imports System.IO.StreamWriter
 
Partial Class GeneraTXTsISSSTE2
    Inherits System.Web.UI.Page
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
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnioConISSSTE(CShort(Me.ddlAños.SelectedValue))
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0
        Else
            Me.gvQuincenas.EmptyDataText = "No existen quincenas con descuentos ISSSTE en el año " + ddlAños.SelectedValue
            Me.gvQuincenas.DataBind()
        End If
    End Sub
    Private Sub CreaLinkParaImpresion()
        If Me.gvQuincenas.Rows.Count = 0 Then
            ddlTipoArchivo.Enabled = False
            ibDescargar.Enabled = False
            ibGenerarTXT.Enabled = False
            Exit Sub
        Else
            ddlTipoArchivo.Enabled = True
            Me.ibGenerarTXT.Enabled = True
        End If

        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Dim NombreArchivo As String = String.Empty
        Dim chkbxPagoDeRetro As CheckBox = CType(Me.gvQuincenas.SelectedRow.FindControl("chkbxPagoDeRetro"), CheckBox)

        ddlTipoArchivo.Items(0).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        ddlTipoArchivo.Items(1).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        ddlTipoArchivo.Items(2).Enabled = False 'Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        ddlTipoArchivo.Items(3).Enabled = False 'Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        ddlTipoArchivo.Items(4).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        ddlTipoArchivo.Items(5).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        ddlTipoArchivo.Items(6).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        ddlTipoArchivo.Items(7).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        ddlTipoArchivo.Items(8).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length > 6
        ddlTipoArchivo.Items(9).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length > 6
        ddlTipoArchivo.Items(10).Enabled = chkbxPagoDeRetro.Checked And lblQuincena.Text.Length > 6
        ddlTipoArchivo.Items(11).Enabled = chkbxPagoDeRetro.Checked And lblQuincena.Text.Length > 6
        ddlTipoArchivo.Items(12).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        ddlTipoArchivo.Items(13).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        ddlTipoArchivo.Items(14).Enabled = lblQuincena.Text.Length = 8
        ddlTipoArchivo.Items(15).Enabled = lblQuincena.Text.Length = 8
        '<< CODIGO AGREGADO POR ALEXIS 13/10/2021 >>'
        ddlTipoArchivo.Items(16).Enabled = Not chkbxPagoDeRetro.Checked And lblQuincena.Text.Length = 6
        '<< CODIGO AGREGADO POR ALEXIS 13/10/2021 >>'
        ddlTipoArchivo.Items(17).Enabled = chkbxPagoDeRetro.Checked And lblQuincena.Text.Length > 6


        Select Case Me.ddlTipoArchivo.SelectedValue
            Case "0"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
            Case "1"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
            Case "2"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "7", "3") + ".txt"
            Case "3"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "8", "4") + ".txt"
            Case "4"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
            Case "5"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
            Case "6"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "C" + IIf(Me.chkPrestamo.Checked, "7", "3") + ".txt"
            Case "7"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "C" + IIf(Me.chkPrestamo.Checked, "8", "4") + ".txt"
            Case "8"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "E" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
            Case "9"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "E" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
            Case "10"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "I" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
            Case "11"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "I" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
            Case "12"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "P" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
            Case "13"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "P2.txt"
            Case "14"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V1.txt"
            Case "15"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V2.txt"
                '<< CODIGO AGREGADO POR ALEXIS 13/10/2021 >>'
            Case "16"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "7", "3") + ".txt"
                '<< CODIGO AGREGADO POR ALEXIS 13/10/2021 >>'
            Case "17"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "I" + IIf(Me.chkPrestamo.Checked, "6", "3") + ".txt"
        End Select

        If File.Exists(ConfigurationManager.AppSettings("RutaISSSTE") + NombreArchivo) Then
            Me.ibDescargar.Enabled = True
            lblMsjDescargar.Text = "Descargar archivo"
        Else
            Me.ibDescargar.Enabled = False
            lblMsjDescargar.Text = "Archivo sin generar"
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
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindQuincenas()
                CreaLinkParaImpresion()
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        BindQuincenas()
        CreaLinkParaImpresion()
    End Sub

    Protected Sub ddlBancos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CreaLinkParaImpresion()
    End Sub

    Protected Sub ibDescargar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibDescargar.Click
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Dim NombreArchivo As String = String.Empty

        Select Case Me.ddlTipoArchivo.SelectedValue
            Case "0"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
            Case "1"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
            Case "2"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "7", "3") + ".txt"
            Case "3"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "8", "4") + ".txt"
            Case "4"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
            Case "5"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
            Case "6"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "C" + IIf(Me.chkPrestamo.Checked, "7", "3") + ".txt"
            Case "7"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "C" + IIf(Me.chkPrestamo.Checked, "8", "4") + ".txt"
            Case "8"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "E" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
            Case "9"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "E" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
            Case "10"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "I" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
            Case "11"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "I" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
            Case "12"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "P" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
            Case "13"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "P2.txt"
            'Case "14"
            '    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V1.txt"
            'Case "15"
            '    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V2.txt"
                '<< CODIGO AGREGADO POR ALEXIS 13/10/2021 >>'
            Case "16"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "7", "3") + ".txt"
                '<< CODIGO AGREGADO POR ALEXIS 13/10/2021 >>'
            Case "17"
                NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "I" + IIf(Me.chkPrestamo.Checked, "6", "3") + ".txt"

        End Select

        If File.Exists(ConfigurationManager.AppSettings("RutaISSSTE") + NombreArchivo) Then
            Response.ContentType = "text/plain"
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + NombreArchivo)
            Response.TransmitFile(Server.MapPath("~/ISSSTE/" + NombreArchivo))
            Response.End()
        End If
    End Sub

    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CreaLinkParaImpresion()
    End Sub

    Protected Sub ibGenerarTXT_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        System.Threading.Thread.Sleep(1000)
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim oISSSTE As New ISSSTE
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Try
            Dim dt As New DataTable
            Dim NombreArchivo As String = String.Empty
            Select Case Me.ddlTipoArchivo.SelectedValue
                Case "0"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
                Case "1"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
                Case "2"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "7", "3") + ".txt"
                Case "3"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "8", "4") + ".txt"
                Case "4"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
                Case "5"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
                Case "6"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "C" + IIf(Me.chkPrestamo.Checked, "7", "3") + ".txt"
                Case "7"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "C" + IIf(Me.chkPrestamo.Checked, "8", "4") + ".txt"
                Case "8"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "E" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
                Case "9"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "E" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
                Case "10"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "I" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
                Case "11"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "I" + IIf(Me.chkPrestamo.Checked, "6", "2") + ".txt"
                Case "12"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "P" + IIf(Me.chkPrestamo.Checked, "5", "1") + ".txt"
                Case "13"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "P2.txt"
                    'Case "14"
                    '    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "V1.txt"
                    'Case "15"
                    '    NombreArchivo = "NOM-23030087Q" +  Left(lblQuincena.Text, 6) + "V2.txt"
                '<< CODIGO AGREGADO POR ALEXIS 13/10/2021 >>'
                Case "16"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "O" + IIf(Me.chkPrestamo.Checked, "7", "3") + ".txt"
                    '<< CODIGO AGREGADO POR ALEXIS 13/10/2021 >>'
                Case "17"
                    NombreArchivo = "NOM-23030087Q" + Left(lblQuincena.Text, 6) + "I" + IIf(Me.chkPrestamo.Checked, "6", "3") + ".txt"
            End Select

            Dim FilePath As String = ConfigurationManager.AppSettings("RutaISSSTE") + NombreArchivo

            System.IO.File.Delete(FilePath)

            strStreamW = System.IO.File.OpenWrite(FilePath)
            strStreamWriter = New System.IO.StreamWriter(strStreamW, System.Text.Encoding.ASCII)

            dt = oISSSTE.GeneraTXTSERICANOMINAS(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoArchivo.SelectedValue), CByte(IIf(Me.chkPrestamo.Checked, 1, 0)))

            Dim dr As System.Data.DataRow

            For Each dr In dt.Rows
                strStreamWriter.WriteLine(dr(0).ToString)
            Next

            strStreamWriter.Close()
            CreaLinkParaImpresion()
        Catch ex As Exception
            strStreamWriter = Nothing
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Response.Expires = 0
        End If
    End Sub

    Protected Sub ddlRegimenPensISSSTE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CreaLinkParaImpresion()
    End Sub
End Class