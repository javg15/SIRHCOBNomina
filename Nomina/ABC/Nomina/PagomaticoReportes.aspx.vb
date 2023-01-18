Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Imports System.IO.Stream
Imports System.IO.StreamWriter
 
Partial Class PagomaticoReportes
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
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue))
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0
        End If
    End Sub
    Private Sub BindddlBancos()
        Dim oBanco As New Bancos
        Dim li As ListItem
        LlenaDDL(Me.ddlBancos, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
        li = Me.ddlBancos.Items.FindByText("SIN DEFINIR")
        If li Is Nothing = False Then Me.ddlBancos.Items.Remove(li)
    End Sub
    Private Sub CreaLinkParaImpresion()
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Select Case Me.ddlReportes.SelectedValue
            Case "0"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?IdBanco=" + Me.ddlBancos.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=4','" + Me.ddlBancos.SelectedItem.Text + "_" + lblQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "1"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?IdBanco=" + Me.ddlBancos.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=5','" + Me.ddlBancos.SelectedItem.Text + "_" + lblQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "2"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?IdPlantel=" + ddlPlanteles.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=6','" + Me.ddlBancos.SelectedItem.Text + "_" + lblQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "3"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?IdPlantel=0" _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=7','" + Me.ddlBancos.SelectedItem.Text + "_" + lblQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "4"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?IdBanco=" + Me.ddlBancos.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=61','PAGOMATICOPORBANCOPA_" + Me.ddlBancos.SelectedItem.Text + "_" + lblQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "5"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?IdBanco=" + Me.ddlBancos.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=107','PAGOMATICOPORBANCOPACLABE_" + Me.ddlBancos.SelectedItem.Text + "_" + lblQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "6"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?IdBanco=" + Me.ddlBancos.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=119','" + Me.ddlBancos.SelectedItem.Text + "SOLORESUMEN_" + lblQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "7"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?IdBanco=" + Me.ddlBancos.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=155','" + Me.ddlBancos.SelectedItem.Text + "SOLORESUMENCLABE_" + lblQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "8"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?IdBanco=" + Me.ddlBancos.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=156','" + Me.ddlBancos.SelectedItem.Text + "CLABE_" + lblQuincena.Text.Replace("-", "_") + "'); return false;"
        End Select
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
                BindddlBancos()
                LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorUsr(Session("Login")), Nothing)

                ddlReportes_SelectedIndexChanged(sender, e)

                'CreaLinkParaImpresion()
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
    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CreaLinkParaImpresion()
    End Sub
    Protected Sub ddlReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlReportes.SelectedIndexChanged
        Dim oUsr As New Usuario
        Dim oReporte As New Reportes
        Dim drReporte As DataRow

        Me.lblPlanteles.Visible = ddlReportes.SelectedValue = "2"
        Me.ddlPlanteles.Visible = ddlReportes.SelectedValue = "2"
        Dim vlIdReporte As Short = CShort(ddlReportes.SelectedValue)

        If oUsr.EsAdministrador(Session("Login")) Or oUsr.EsVIP(Session("Login")) Then
            Select Case Me.ddlReportes.SelectedValue
                Case "0"
                    vlIdReporte = 4
                Case "1"
                    vlIdReporte = 5
                Case "2"
                    vlIdReporte = 6
                Case "3"
                    vlIdReporte = 7
                Case "4"
                    vlIdReporte = 61
                Case "5"
                    vlIdReporte = 107
                Case "6"
                    vlIdReporte = 119
                Case "7"
                    vlIdReporte = 155
                Case "8"
                    vlIdReporte = 156
            End Select
            drReporte = oReporte.ObtenOpcionesVarias(vlIdReporte)
            pnlFchImpRpt.Visible = CBool(drReporte("PedirFechaDeImp"))

            Session.Remove("pFchImpRpt")
            txtbxFchImpRpt.Text = String.Empty
        End If

        CreaLinkParaImpresion()
    End Sub

    Protected Sub txtbxFchImpRpt_TextChanged(sender As Object, e As System.EventArgs) Handles txtbxFchImpRpt.TextChanged
        If IsDate(txtbxFchImpRpt.Text.Trim) Then
            Session.Add("pFchImpRpt", txtbxFchImpRpt.Text)
        Else
            txtbxFchImpRpt.Text = String.Empty
            Session.Remove("pFchImpRpt")
        End If
    End Sub
End Class