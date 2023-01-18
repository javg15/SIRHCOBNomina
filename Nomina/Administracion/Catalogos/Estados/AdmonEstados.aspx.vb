Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Imports DataAccessLayer.COBAEV.Mexico.Estados
Imports DataAccessLayer.COBAEV.Mexico.Estados.Municipios
Imports DataAccessLayer.COBAEV.Mexico.Estados.Municipios.Localidades
Imports DataAccessLayer.COBAEV.Mexico.Estados.Municipios.Localidades.Colonias
Partial Class Administracion_Catalogos_Estados_AdmonEstados
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindEstados(Optional ByVal SelectedValue As String = Nothing)
        Dim oEstado As New Estado
        LlenaDDL(Me.ddlEdos, "NomEdo", "IdEdo", oEstado.ObtenTodos(True), SelectedValue)
    End Sub
    Private Sub BindMunicipios()
        Dim oEdo As New Estado
        LlenaDDL(Me.ddlMuns, "NomMun", "IdMun", oEdo.ObtenMunicipios(CByte(Me.ddlEdos.SelectedValue), True), Nothing)
    End Sub
    Private Sub BindLocalidades()
        Dim oMunicipio As New Municipio
        LlenaDDL(ddlLocs, "NomLoc", "IdLoc", oMunicipio.ObtenLocalidades(CShort(ddlMuns.SelectedValue), True), Nothing)
        If ddlLocs.Items.Count = 0 Then
            ddlLocs.Items.Clear()
            ddlLocs.Items.Insert(0, "(VACIO)")
            ddlLocs.Items(0).Value = "0"
            Me.imgModifLoc.Visible = False
            Me.imgAddCol.Visible = False
            Me.imgModifCP.Visible = False
        ElseIf ddlLocs.Items.Count > 0 Then
            Me.imgModifLoc.Visible = True
            Me.imgAddCol.Visible = True
            Me.imgModifCP.Visible = True
        End If
    End Sub
    Private Sub BindColonias()
        Dim oLocalidad As New Localidad
        If ddlLocs.SelectedValue <> "0" Then
            LlenaDDL(ddlCols, "NomCol", "IdCol", oLocalidad.ObtenColonias(CInt(ddlLocs.SelectedValue), True), Nothing)
            If Me.ddlCols.Items.Count > 0 Then
                Me.imgModifCol.Visible = True
            Else
                ddlCols.Items.Clear()
                ddlCols.Items.Insert(0, "(VACIO)")
                ddlCols.Items(0).Value = "0"
                Me.imgModifCol.Visible = False
            End If
        Else
            ddlCols.Items.Clear()
            ddlCols.Items.Insert(0, "(VACIO)")
            ddlCols.Items(0).Value = "0"
            Me.imgModifCol.Visible = False
        End If
    End Sub
    Private Sub FilltxtbxCP()
        Dim oCol As New Colonia
        Dim oLoc As New Localidad
        Dim CP As String = ""
        Me.lblCP.Visible = False
        If ddlCols.SelectedValue <> "0" And ddlCols.SelectedValue <> String.Empty Then
            CP = oCol.ObtenCodigoPostal(CInt(ddlCols.SelectedValue))
            If CP <> String.Empty Then
                Me.lblCP.Visible = False
            End If
        Else
            If Me.ddlLocs.SelectedValue <> "0" Then
                CP = oLoc.ObtenCodigoPostal(CInt(ddlLocs.SelectedValue))
                If CP <> String.Empty Then
                    Me.lblCP.Visible = True
                End If
            End If
        End If
        Me.txtbxCP.Text = CP
        Me.imgModifCP.Visible = Me.ddlLocs.SelectedValue <> 0
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oAplic As New Aplicacion
            Dim dt As DataTable
            dt = oAplic.ObtenDatosEmpresa()
            Page.Title = dt.Rows(0).Item("NombreCortoEmpresa").ToString + " - Sistema de Nómina - Administración de estados, municipios, localidades, colonias y códigos postales"

            BindEstados(dt.Rows(0).Item("IdEdo").ToString)
            BindMunicipios()
            BindLocalidades()
            BindColonias()
            FilltxtbxCP()
        End If
    End Sub

    Protected Sub ddlEdos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEdos.SelectedIndexChanged
        'System.Threading.Thread.Sleep(500)
        BindMunicipios()
        BindLocalidades()
        BindColonias()
        FilltxtbxCP()
    End Sub

    Protected Sub ddlMuns_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMuns.SelectedIndexChanged
        'System.Threading.Thread.Sleep(500)
        BindLocalidades()
        BindColonias()
        FilltxtbxCP()
    End Sub

    Protected Sub ddlCols_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCols.SelectedIndexChanged
        'System.Threading.Thread.Sleep(500)
        FilltxtbxCP()
    End Sub

    Protected Sub ddlLocs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLocs.SelectedIndexChanged
        'System.Threading.Thread.Sleep(500)
        BindColonias()
        FilltxtbxCP()
    End Sub

    Protected Sub imgModifMun_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = False
        Me.ddlMuns.Enabled = False
        Me.imgModifMun.Visible = False
        Me.imgAddMun.Visible = False
        Me.lblModAddMun.Text = "Modifique el nombre de municipio"
        lblModAddMun.Visible = True
        Me.txtbxMun.Text = Me.ddlMuns.SelectedItem.Text
        Me.txtbxMun.Visible = True
        Me.imgGuardarMunModif.Visible = True
        Me.imgCancelMun.Visible = True
        Me.ddlLocs.Enabled = False
        Me.imgModifLoc.Visible = False
        Me.imgAddLoc.Visible = False
        Me.ddlCols.Enabled = False
        Me.imgModifCol.Visible = False
        Me.imgAddCol.Visible = False
        Me.imgModifCP.Visible = False
    End Sub

    Protected Sub imgCancelMun_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = True
        Me.ddlMuns.Enabled = True
        Me.imgModifMun.Visible = Me.ddlMuns.SelectedValue <> "0"
        Me.imgAddMun.Visible = Me.ddlEdos.SelectedValue <> "0"
        lblModAddMun.Visible = False
        Me.txtbxMun.Text = String.Empty
        Me.txtbxMun.Visible = False
        Me.imgGuardarMunModif.Visible = False
        Me.imgGuardarNuevoMun.Visible = False
        Me.imgCancelMun.Visible = False
        Me.ddlLocs.Enabled = True
        Me.imgModifLoc.Visible = Me.ddlLocs.SelectedValue <> "0"
        Me.imgAddLoc.Visible = Me.ddlMuns.SelectedValue <> "0"
        Me.ddlCols.Enabled = True
        Me.imgModifCol.Visible = Me.ddlCols.SelectedValue <> "0"
        Me.imgAddCol.Visible = Me.ddlLocs.SelectedValue <> "0"
        Me.imgModifCP.Visible = Me.ddlLocs.SelectedValue <> "0" Or Me.ddlCols.SelectedValue <> "0"
    End Sub

    Protected Sub imgAddMun_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = False
        Me.ddlMuns.Enabled = False
        Me.imgModifMun.Visible = False
        Me.imgAddMun.Visible = False
        Me.lblModAddMun.Text = "Escriba el nombre del nuevo municipio"
        lblModAddMun.Visible = True
        Me.txtbxMun.Text = String.Empty
        Me.txtbxMun.Visible = True
        Me.imgGuardarNuevoMun.Visible = True
        Me.imgCancelMun.Visible = True
        Me.ddlLocs.Enabled = False
        Me.imgModifLoc.Visible = False
        Me.imgAddLoc.Visible = False
        Me.ddlCols.Enabled = False
        Me.imgModifCol.Visible = False
        Me.imgAddCol.Visible = False
        Me.imgModifCP.Visible = False
    End Sub

    Protected Sub imgGuardarLocModif_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oLoc As New Localidad
        Dim IdLoc As Integer
        IdLoc = CInt(Me.ddlLocs.SelectedValue)
        oLoc.InsertaActualiza(CShort(Me.ddlMuns.SelectedValue), CInt(Me.ddlLocs.SelectedValue), Me.txtbxLoc.Text.Trim, 0, CType(Session("ArregloAuditoria"), String()))
        BindLocalidades()
        Me.ddlLocs.SelectedValue = IdLoc.ToString
        BindColonias()
        FilltxtbxCP()
        imgCancelLoc_Click(sender, e)
    End Sub

    Protected Sub imgGuardarNuevaLoc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oLoc As New Localidad
        Dim LI As ListItem
        oLoc.InsertaActualiza(CShort(Me.ddlMuns.SelectedValue), CInt(Me.ddlLocs.SelectedValue), Me.txtbxLoc.Text.Trim, 1, CType(Session("ArregloAuditoria"), String()))
        BindLocalidades()
        LI = Me.ddlLocs.Items.FindByText(Me.txtbxLoc.Text.Trim)
        If LI Is Nothing = False Then LI.Selected = True
        BindColonias()
        FilltxtbxCP()
        imgCancelLoc_Click(sender, e)
    End Sub

    Protected Sub imgCancelLoc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = True
        Me.ddlMuns.Enabled = True
        Me.imgModifMun.Visible = Me.ddlMuns.SelectedValue <> "0"
        Me.imgAddMun.Visible = Me.ddlEdos.SelectedValue <> "0"
        Me.ddlLocs.Enabled = True
        Me.imgModifLoc.Visible = Me.ddlLocs.SelectedValue <> "0"
        Me.imgAddLoc.Visible = Me.ddlMuns.SelectedValue <> "0"
        Me.lblModAddLoc.Text = String.Empty
        lblModAddLoc.Visible = False
        Me.txtbxLoc.Text = String.Empty
        Me.txtbxLoc.Visible = False
        Me.imgGuardarLocModif.Visible = False
        Me.imgGuardarNuevaLoc.Visible = False
        Me.imgCancelLoc.Visible = False
        Me.ddlCols.Enabled = True
        Me.imgModifCol.Visible = Me.ddlCols.SelectedValue <> "0"
        Me.imgAddCol.Visible = Me.ddlLocs.SelectedValue <> "0"
        Me.imgModifCP.Visible = Me.ddlLocs.SelectedValue <> "0" Or Me.ddlCols.SelectedValue <> "0"
    End Sub

    Protected Sub imgModifLoc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = False
        Me.ddlMuns.Enabled = False
        Me.imgModifMun.Visible = False
        Me.imgAddMun.Visible = False
        Me.ddlLocs.Enabled = False
        Me.imgModifLoc.Visible = False
        Me.imgAddLoc.Visible = False
        Me.lblModAddLoc.Text = "Modifique el nombre de la localidad"
        lblModAddLoc.Visible = True
        Me.txtbxLoc.Text = Me.ddlLocs.SelectedItem.Text
        Me.txtbxLoc.Visible = True
        Me.imgGuardarLocModif.Visible = True
        Me.imgCancelLoc.Visible = True
        Me.ddlCols.Enabled = False
        Me.imgModifCol.Visible = False
        Me.imgAddCol.Visible = False
        Me.imgModifCP.Visible = False
    End Sub

    Protected Sub imgAddLoc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = False
        Me.ddlMuns.Enabled = False
        Me.imgModifMun.Visible = False
        Me.imgAddMun.Visible = False
        Me.ddlLocs.Enabled = False
        Me.imgModifLoc.Visible = False
        Me.imgAddLoc.Visible = False
        Me.lblModAddLoc.Text = "Escriba el nombre de la nueva localidad"
        lblModAddLoc.Visible = True
        Me.txtbxLoc.Text = String.Empty
        Me.txtbxLoc.Visible = True
        Me.imgGuardarNuevaLoc.Visible = True
        Me.imgCancelLoc.Visible = True
        Me.ddlCols.Enabled = False
        Me.imgModifCol.Visible = False
        Me.imgAddCol.Visible = False
        Me.imgModifCP.Visible = False
    End Sub

    Protected Sub imgModifCol_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = False
        Me.ddlMuns.Enabled = False
        Me.imgModifMun.Visible = False
        Me.imgAddMun.Visible = False
        Me.ddlLocs.Enabled = False
        Me.imgModifLoc.Visible = False
        Me.imgAddLoc.Visible = False
        Me.ddlCols.Enabled = False
        Me.lblModAddCol.Text = "Modifique el nombre de la colonia"
        lblModAddCol.Visible = True
        Me.txtbxCol.Text = Me.ddlCols.SelectedItem.Text
        Me.txtbxCol.Visible = True
        Me.imgModifCol.Visible = False
        Me.imgAddCol.Visible = False
        Me.imgGuardarColModif.Visible = True
        Me.imgCancelCol.Visible = True
        Me.imgModifCP.Visible = False
    End Sub
    Protected Sub imgGuardarColModif_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oCol As New Colonia
        Dim IdCol As Integer
        IdCol = CInt(Me.ddlCols.SelectedValue)
        oCol.InsertaActualiza(CInt(Me.ddlLocs.SelectedValue), CInt(Me.ddlCols.SelectedValue), Me.txtbxCol.Text.Trim, 0, CType(Session("ArregloAuditoria"), String()))
        BindColonias()
        Me.ddlCols.SelectedValue = IdCol.ToString
        FilltxtbxCP()
        imgCancelCol_Click(sender, e)
    End Sub

    Protected Sub imgGuardarNuevaCol_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oCol As New Colonia
        Dim LI As ListItem
        oCol.InsertaActualiza(CInt(Me.ddlLocs.SelectedValue), CInt(Me.ddlCols.SelectedValue), Me.txtbxCol.Text.Trim, 1, CType(Session("ArregloAuditoria"), String()))
        BindColonias()
        LI = Me.ddlCols.Items.FindByText(Me.txtbxCol.Text)
        If LI Is Nothing = False Then LI.Selected = True
        FilltxtbxCP()
        imgCancelCol_Click(sender, e)
    End Sub

    Protected Sub imgCancelCol_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = True
        Me.ddlMuns.Enabled = True
        Me.imgModifMun.Visible = Me.ddlMuns.SelectedValue <> "0"
        Me.imgAddMun.Visible = Me.ddlEdos.SelectedValue <> "0"
        Me.ddlLocs.Enabled = True
        Me.imgModifLoc.Visible = Me.ddlLocs.SelectedValue <> "0"
        Me.imgAddLoc.Visible = Me.ddlMuns.SelectedValue <> "0"
        Me.ddlCols.Enabled = True
        Me.lblModAddCol.Text = String.Empty
        lblModAddCol.Visible = False
        Me.txtbxCol.Text = String.Empty
        Me.txtbxCol.Visible = False
        Me.imgModifCol.Visible = Me.ddlCols.SelectedValue <> "0"
        Me.imgAddCol.Visible = Me.ddlLocs.SelectedValue <> "0"
        Me.imgGuardarColModif.Visible = False
        Me.imgGuardarNuevaCol.Visible = False
        Me.imgCancelCol.Visible = False
        Me.imgModifCP.Visible = Me.ddlLocs.SelectedValue <> "0" Or Me.ddlCols.SelectedValue <> "0"
    End Sub

    Protected Sub imgAddCol_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = False
        Me.ddlMuns.Enabled = False
        Me.imgModifMun.Visible = False
        Me.imgAddMun.Visible = False
        Me.ddlLocs.Enabled = False
        Me.imgModifLoc.Visible = False
        Me.imgAddLoc.Visible = False
        Me.ddlCols.Enabled = False
        Me.lblModAddCol.Text = "Escriba el nombre de la nueva colonia"
        lblModAddCol.Visible = True
        Me.txtbxCol.Text = String.Empty
        Me.txtbxCol.Visible = True
        Me.imgModifCol.Visible = False
        Me.imgAddCol.Visible = False
        Me.imgGuardarNuevaCol.Visible = True
        Me.imgCancelCol.Visible = True
        Me.imgModifCP.Visible = False
    End Sub

    Protected Sub imgModifCP_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = False
        Me.ddlMuns.Enabled = False
        Me.imgModifMun.Visible = False
        Me.imgAddMun.Visible = False
        Me.ddlLocs.Enabled = False
        Me.imgModifLoc.Visible = False
        Me.imgAddLoc.Visible = False
        Me.ddlCols.Enabled = False
        Me.imgModifCol.Visible = False
        Me.imgAddCol.Visible = False
        Me.imgGuardarColModif.Visible = False
        Me.txtbxCP.Enabled = True
        Me.imgModifCP.Visible = False
        Me.imgGuardarCPModif.Visible = True
        Me.imgCancelCP.Visible = True
    End Sub

    Protected Sub imgGuardarCPModif_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oCol As New Colonia
        oCol.ActualizaCodigoPostal(CByte(Me.ddlEdos.SelectedValue), CShort(Me.ddlMuns.SelectedValue), CInt(Me.ddlLocs.SelectedValue), CInt(Me.ddlCols.SelectedValue), Me.txtbxCP.Text.Trim, CType(Session("ArregloAuditoria"), String()))
        imgCancelCP_Click(sender, e)
    End Sub

    Protected Sub imgCancelCP_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ddlEdos.Enabled = True
        Me.ddlMuns.Enabled = True
        Me.imgModifMun.Visible = Me.ddlMuns.SelectedValue <> "0"
        Me.imgAddMun.Visible = Me.ddlEdos.SelectedValue <> "0"
        Me.ddlLocs.Enabled = True
        Me.imgModifLoc.Visible = Me.ddlLocs.SelectedValue <> "0"
        Me.imgAddLoc.Visible = Me.ddlMuns.SelectedValue <> "0"
        Me.ddlCols.Enabled = True
        Me.imgModifCol.Visible = Me.ddlCols.SelectedValue <> "0"
        Me.imgAddCol.Visible = Me.ddlLocs.SelectedValue <> "0"
        Me.txtbxCP.Enabled = False
        Me.imgModifCP.Visible = Me.ddlLocs.SelectedValue <> "0" Or Me.ddlCols.SelectedValue <> "0"
        Me.imgGuardarCPModif.Visible = False
        Me.imgCancelCP.Visible = False
        FilltxtbxCP()
    End Sub

    Protected Sub imgGuardarMunModif_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oMun As New Municipio
        Dim IdMun As Integer
        IdMun = CInt(Me.ddlMuns.SelectedValue)
        oMun.InsertaActualiza(CByte(Me.ddlEdos.SelectedValue), CShort(Me.ddlMuns.SelectedValue), Me.txtbxMun.Text.Trim, 0, CType(Session("ArregloAuditoria"), String()))
        BindMunicipios()
        Me.ddlMuns.SelectedValue = IdMun.ToString
        BindLocalidades()
        BindColonias()
        FilltxtbxCP()
        imgCancelMun_Click(sender, e)
    End Sub

    Protected Sub imgGuardarNuevoMun_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oMun As New Municipio
        Dim LI As ListItem
        oMun.InsertaActualiza(CByte(Me.ddlEdos.SelectedValue), CShort(Me.ddlMuns.SelectedValue), Me.txtbxMun.Text.Trim, 1, CType(Session("ArregloAuditoria"), String()))
        BindMunicipios()
        LI = Me.ddlMuns.Items.FindByText(Me.txtbxMun.Text)
        If LI Is Nothing = False Then LI.Selected = True
        BindLocalidades()
        BindColonias()
        FilltxtbxCP()
        imgCancelMun_Click(sender, e)
    End Sub
End Class
