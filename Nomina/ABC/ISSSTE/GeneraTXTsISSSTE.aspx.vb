Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Imports System.IO.Stream
Imports System.IO.StreamWriter
 
Partial Class GeneraTXTsISSSTE
    Inherits System.Web.UI.Page
    Private Sub BindddlRegimenPensISSSTE()
        Dim oRegimenISSSTE As New ISSSTE
        With Me.ddlRegimenPensISSSTE
            .DataSource = oRegimenISSSTE.ObtenTodos()
            .DataTextField = "RegimenISSSTE"
            .DataValueField = "IdRegimenISSSTE"
            .DataBind()
        End With
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
            ddlRegimenPensISSSTE.Enabled = False
            ddlTipoArchivo.Enabled = False
            ibDescargar.Enabled = False
            ibGenerarTXT.Enabled = False
            Exit Sub
        Else
            ddlRegimenPensISSSTE.Enabled = True
            ddlTipoArchivo.Enabled = True
            Me.ibGenerarTXT.Enabled = True
        End If

        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Dim NombreArchivo As String = String.Empty
        Select Case Me.ddlTipoArchivo.SelectedValue
            Case "0"
                NombreArchivo = ConfigurationManager.AppSettings("NombreArchivoAltasISSSTE")
            Case "1"
                NombreArchivo = ConfigurationManager.AppSettings("NombreArchivoBajasISSSTE")
            Case "2"
                NombreArchivo = ConfigurationManager.AppSettings("NombreArchivoModSalISSSTE")
            Case "3"
                NombreArchivo = "BajasConNumEmp"
        End Select
        If File.Exists(ConfigurationManager.AppSettings("RutaISSSTE") + NombreArchivo + "_" + Me.ddlRegimenPensISSSTE.SelectedValue + "_" + lblQuincena.Text.Replace("-", "_") + ".txt") Then
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
                BindddlRegimenPensISSSTE()
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
                NombreArchivo = ConfigurationManager.AppSettings("NombreArchivoAltasISSSTE")
            Case "1"
                NombreArchivo = ConfigurationManager.AppSettings("NombreArchivoBajasISSSTE")
            Case "2"
                NombreArchivo = ConfigurationManager.AppSettings("NombreArchivoModSalISSSTE")
            Case "3"
                NombreArchivo = "BajasConNumEmp"
        End Select
        If File.Exists(ConfigurationManager.AppSettings("RutaISSSTE") + NombreArchivo + "_" + Me.ddlRegimenPensISSSTE.SelectedValue + "_" + lblQuincena.Text.Replace("-", "_") + ".txt") Then
            Response.ContentType = "text/plain"
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + NombreArchivo + "_" + Me.ddlRegimenPensISSSTE.SelectedValue + "_" + lblQuincena.Text.Replace("-", "_") + ".txt")
            Response.TransmitFile(Server.MapPath("~/ISSSTE/" + NombreArchivo + "_" + Me.ddlRegimenPensISSSTE.SelectedValue + "_" + lblQuincena.Text.Replace("-", "_") + ".txt"))
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
                    NombreArchivo = ConfigurationManager.AppSettings("NombreArchivoAltasISSSTE")
                Case "1"
                    NombreArchivo = ConfigurationManager.AppSettings("NombreArchivoBajasISSSTE")
                Case "2"
                    NombreArchivo = ConfigurationManager.AppSettings("NombreArchivoModSalISSSTE")
                Case "3"
                    NombreArchivo = "BajasConNumEmp"
            End Select

            Dim FilePath As String = ConfigurationManager.AppSettings("RutaISSSTE") + NombreArchivo + "_" + Me.ddlRegimenPensISSSTE.SelectedValue + "_" + lblQuincena.Text.Replace("-", "_") + ".txt"

            System.IO.File.Delete(FilePath)

            strStreamW = System.IO.File.OpenWrite(FilePath)
            strStreamWriter = New System.IO.StreamWriter(strStreamW, System.Text.Encoding.UTF8)

            Select Case Me.ddlTipoArchivo.SelectedValue
                Case "0"
                    dt = oISSSTE.GeneraTXTAltas(CShort(lblIdQuincena.Text), CByte(Me.ddlRegimenPensISSSTE.SelectedValue), CByte(Me.ddlRegimenPensISSSTE.SelectedValue))
                Case "1"
                    dt = oISSSTE.GeneraTXTBajas(CShort(lblIdQuincena.Text), CByte(Me.ddlRegimenPensISSSTE.SelectedValue), CByte(Me.ddlRegimenPensISSSTE.SelectedValue))
                Case "2"
                    dt = oISSSTE.GeneraTXTModSal(CShort(lblIdQuincena.Text), CByte(Me.ddlRegimenPensISSSTE.SelectedValue), CByte(Me.ddlRegimenPensISSSTE.SelectedValue))
                Case "3" 'Bajas Con NumEmp
                    dt = oISSSTE.GeneraTXTBajas(CShort(lblIdQuincena.Text), CByte(Me.ddlRegimenPensISSSTE.SelectedValue), CByte(Me.ddlRegimenPensISSSTE.SelectedValue))
            End Select

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