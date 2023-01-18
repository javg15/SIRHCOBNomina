Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Imports System.IO.Stream
Imports System.IO.StreamWriter
 
Partial Class GeneraTXTFOVISSSTE
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
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnioConFOVISSSTE(CShort(Me.ddlAños.SelectedValue))
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0
        Else
            Me.gvQuincenas.EmptyDataText = "No existen quincenas con descuento de préstamo hipotecario FOVISSSTE en el año " + ddlAños.SelectedValue
            Me.gvQuincenas.DataBind()
        End If
    End Sub
    Private Sub CreaLinkParaImpresion()
        If Me.gvQuincenas.Rows.Count > 0 Then
            Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
            Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
            If File.Exists(ConfigurationManager.AppSettings("RutaFOVISSSTE") + "FOVISSSTE_" + lblQuincena.Text.Replace("-", "_") + ".txt") Then
                Me.ibDescargar.Enabled = True
                lblMsjDescargar.Text = "Descargar archivo"
            Else
                Me.ibDescargar.Enabled = False
                lblMsjDescargar.Text = "Archivo sin generar"
            End If
            Me.ibGenerarTXT.Enabled = True
        Else
            Me.ibDescargar.Enabled = False
            Me.ibGenerarTXT.Enabled = False
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
        If File.Exists(ConfigurationManager.AppSettings("RutaFOVISSSTE") + "FOVISSSTE_" + lblQuincena.Text.Replace("-", "_") + ".txt") Then
            Response.ContentType = "text/plain"
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + "FOVISSSTE_" + lblQuincena.Text.Replace("-", "_") + ".txt")
            Response.TransmitFile(Server.MapPath("~/FOVISSSTE/" + "FOVISSSTE_" + lblQuincena.Text.Replace("-", "_") + ".txt"))
            Response.End()
        End If
    End Sub

    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CreaLinkParaImpresion()
    End Sub

    Protected Sub ibGenerarTXT_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibGenerarTXT.Click
        'System.Threading.Thread.Sleep(1000)
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim oFOVISSSTE As New FOVISSSTE
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Try
            Dim dt As New DataTable

            Dim FilePath As String = ConfigurationManager.AppSettings("RutaFOVISSSTE") + "FOVISSSTE_" + lblQuincena.Text.Replace("-", "_") + ".txt"

            System.IO.File.Delete(FilePath)

            strStreamW = System.IO.File.OpenWrite(FilePath)
            strStreamWriter = New System.IO.StreamWriter(strStreamW, System.Text.Encoding.ASCII)

            If Me.ddlTipoDesc.SelectedValue = 1 Then
                dt = oFOVISSSTE.GeneraTXTFOVISSSTE(CShort(lblIdQuincena.Text))
            Else
                dt = oFOVISSSTE.GeneraTXTFOVISSSTEPARATODOS(CShort(lblIdQuincena.Text))
            End If

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
End Class