Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class Administracion_Roles
    Inherits System.Web.UI.Page
    Public dtMenuRol As DataTable
    Private Sub GuardaPropiedadesDelRol()
        Dim oRol As New Aplicacion
        With oRol
            .IdRol = CType(Me.ddlRoles.SelectedValue, Byte)
            .ConsultaZonasEspecificas = Me.chbxlstOpcsRol.Items(0).Selected
            .ConsultaPlantelesEspecificos = Me.chbxlstOpcsRol.Items(1).Selected
            .VisibilidadDeQnasAdic = Me.chbxlstOpcsRol.Items(2).Selected
            .CalculaDecAnual = Me.chbxlstOpcsRol.Items(3).Selected
            .Administrador = Me.chbxlstOpcsRol.Items(4).Selected
            oRol.ActualizarPropiedades(CType(Session("ArregloAuditoria"), String()))
        End With
    End Sub

    Private Sub BindchbxlstOpcsRol()
        Dim oAplic As New Aplicacion
        Dim drPropRol As DataRow

        drPropRol = oAplic.ObtenerPropiedadesRol(CByte(Me.ddlRoles.SelectedValue))

        Me.chbxlstOpcsRol.Items(0).Selected = drPropRol("ConsultaZonasEspecificas")
        Me.chbxlstOpcsRol.Items(1).Selected = drPropRol("ConsultaPlantelesEspecificos")
        Me.chbxlstOpcsRol.Items(2).Selected = drPropRol("VisibilidadDeQnasAdic")
        Me.chbxlstOpcsRol.Items(3).Selected = drPropRol("CalculaDecAnual")
        Me.chbxlstOpcsRol.Items(4).Selected = drPropRol("Administrador")
    End Sub
    Private Sub BindTreeView()
        Dim oAplicacion As New Aplicacion
        Dim dtMenuItems As New DataTable

        dtMenuItems = oAplicacion.ObtenerNodosMenu()

        If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "4" Then
            dtMenuRol = oAplicacion.ObtenerNodosMenuPorRol(CType(Me.ddlRoles.SelectedValue, Byte))
        End If

        For Each drMenuItem As DataRow In dtMenuItems.Rows
            If drMenuItem("IdNodoMenu").Equals(drMenuItem("IdNodoMenuPadre")) Then
                Dim mnuMenuItem As New TreeNode
                mnuMenuItem.Value = drMenuItem("IdNodoMenu").ToString
                mnuMenuItem.Text = drMenuItem("DescNodoMenu").ToString
                mnuMenuItem.SelectAction = TreeNodeSelectAction.None
                Me.TreeView1.Nodes.Add(mnuMenuItem)

                If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "4" Then
                    For Each drMenuRol As DataRow In dtMenuRol.Rows
                        If mnuMenuItem.Value = drMenuRol("IdNodoMenu").ToString Then
                            mnuMenuItem.Checked = True
                        End If
                    Next
                End If

                AddMenuItem(mnuMenuItem, dtMenuItems)
            End If
        Next
        Me.TreeView1.ExpandAll()
    End Sub
    Private Sub AddMenuItem(ByRef mnuMenuItem As TreeNode, ByRef dtMenuItems As DataTable)
        For Each drMenuItem As DataRow In dtMenuItems.Rows
            If drMenuItem("IdNodoMenuPadre").ToString.Equals(mnuMenuItem.Value) AndAlso _
                Not drMenuItem("IdNodoMenu").Equals(drMenuItem("IdNodoMenuPadre")) Then
                Dim mnuNewMenuItem As New TreeNode
                mnuNewMenuItem.Value = drMenuItem("IdNodoMenu")
                mnuNewMenuItem.Text = drMenuItem("DescNodoMenu")
                mnuNewMenuItem.SelectAction = TreeNodeSelectAction.None
                mnuMenuItem.ChildNodes.Add(mnuNewMenuItem)

                If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "4" Then
                    For Each drMenuRol As DataRow In dtMenuRol.Rows
                        If mnuNewMenuItem.Value = drMenuRol("IdNodoMenu").ToString Then
                            mnuNewMenuItem.Checked = True
                        End If
                    Next
                End If

                AddMenuItem(mnuNewMenuItem, dtMenuItems)
            End If
        Next
    End Sub
    Private Sub BindRoles()
        Dim oAplicacion As New Aplicacion
        Me.ddlRoles.DataSource = oAplicacion.ObtenerRoles
        Me.ddlRoles.DataTextField = "NombreRol"
        Me.ddlRoles.DataValueField = "IdRol"
        Me.ddlRoles.DataBind()
        Me.lblElegirRol.Visible = True
        Me.ddlRoles.Visible = True
    End Sub
    Private Sub CheckedNodesParent(ByVal NodeParent As TreeNode)
        Dim Bandera As Boolean = False
        If NodeParent.ChildNodes.Count > 0 Then
            For Each NodoHijo As TreeNode In NodeParent.ChildNodes
                If NodoHijo.Checked = True Then Bandera = True
            Next
        End If
        NodeParent.Checked = Bandera
        If NodeParent.Parent Is Nothing = False Then
            CheckedNodesParent(NodeParent.Parent)
        End If
    End Sub
    Private Sub CheckedChildNodes(ByVal Node As TreeNode)
        If Node.ChildNodes.Count > 0 Then
            For Each NodoHijo As TreeNode In Node.ChildNodes
                NodoHijo.Checked = Node.Checked
                CheckedChildNodes(NodoHijo)
            Next
        End If
    End Sub
    Private Sub GuardaCambios(Optional ByVal IdRol As Byte = 0)
        For Each Nodo As TreeNode In Me.TreeView1.Nodes
            IdRol = GuardaRol(Nodo, IdRol)
            If Nodo.ChildNodes.Count > 0 Then
                For Each NodoHijo As TreeNode In Nodo.ChildNodes
                    IdRol = GuardaCambiosHijos(NodoHijo, IdRol)
                Next
            End If
        Next
    End Sub
    Private Function GuardaCambiosHijos(ByVal Nodo As TreeNode, ByVal IdRol As Byte) As Byte
        IdRol = GuardaRol(Nodo, IdRol)
        If Nodo.ChildNodes.Count > 0 Then
            For Each NodoHijo As TreeNode In Nodo.ChildNodes
                IdRol = GuardaCambiosHijos(NodoHijo, IdRol)
            Next
        End If
        Return IdRol
    End Function
    Private Function GuardaRol(ByVal Nodo As TreeNode, ByVal IdRol As Byte) As Byte
        Dim oAplicacion As New Aplicacion
        With oAplicacion
            If Me.Request.Params("TipoOperacion") = "0" Then 'Actualización
                .IdRol = CType(Me.ddlRoles.SelectedValue, Byte)
                .NombreRol = ""
            ElseIf Me.Request.Params("TipoOperacion") = "1" Then
                .IdRol = IdRol
                If IdRol = 0 Then
                    .NombreRol = Me.txtbxNombreRol.Text.Trim
                Else
                    .NombreRol = ""
                End If
            End If
            .IdNodoMenu = CType(Nodo.Value, Byte)
            .NodoChecked = Nodo.Checked
            .ConsultaZonasEspecificas = Me.chbxlstOpcsRol.Items(0).Selected
            .ConsultaPlantelesEspecificos = Me.chbxlstOpcsRol.Items(1).Selected
            .VisibilidadDeQnasAdic = Me.chbxlstOpcsRol.Items(2).Selected
            .CalculaDecAnual = Me.chbxlstOpcsRol.Items(3).Selected
            .Administrador = Me.chbxlstOpcsRol.Items(4).Selected
            Return .GuardaRol(CType(Me.Request.Params("TipoOperacion"), Byte), CType(Session("ArregloAuditoria"), String()))
        End With
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.MultiView1.SetActiveView(Me.viewCaptura)
            If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "4" Then
                BindRoles()
                BindchbxlstOpcsRol()
            ElseIf Request.Params("TipoOperacion") = "1" Then
                Me.lblOpcMenu.Text = "Seleccione las opciones de menú que conformarán el nuevo rol:"
                Me.lblNuevoRol.Visible = True
                Me.txtbxNombreRol.Visible = True
                Me.btnModificar.Visible = False
                Me.btnGuardar.Visible = True
                Me.chbxlstOpcsRol.Enabled = True
                Me.TreeView1.Enabled = True
            End If
            BindTreeView()
            Me.TreeView1.Attributes.Add("onclick", String.Format("$get('{0}').click();", BtnTreeView.ClientID))
            BtnTreeView.Attributes.Add("style", "visibility: hidden")
        End If
    End Sub

    Protected Sub ddlRoles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRoles.SelectedIndexChanged
        Me.TreeView1.Nodes.Clear()
        BindchbxlstOpcsRol()
        BindTreeView()
        Me.chbxlstOpcsRol.Enabled = False
        Me.TreeView1.Enabled = False
        'Me.TreeView1.Enabled = False
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.CommandName = "Modificar"
        Me.CBEGuardar.Enabled = False
    End Sub

    Protected Sub btnModificar_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles btnModificar.Command
        Select Case e.CommandName
            Case "Modificar"
                Me.chbxlstOpcsRol.Enabled = True
                Me.TreeView1.Enabled = True
                Me.btnModificar.Text = "Guardar"
                Me.btnModificar.CommandName = "Guardar"
                Me.CBEGuardar.Enabled = True
            Case "Guardar"
                Try
                    If Request.Params("TipoOperacion") = "0" Then
                        GuardaPropiedadesDelRol()
                    End If
                    GuardaCambios()
                    Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
                Catch ex As Exception
                    Me.MultiView1.SetActiveView(Me.viewErrores)
                    Me.lblErrores.Text = ex.Message
                End Try
        End Select
    End Sub
    Protected Sub TreeView1_TreeNodeCheckChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles TreeView1.TreeNodeCheckChanged
        CheckedChildNodes(e.Node)
        If e.Node.Parent Is Nothing = False Then CheckedNodesParent(e.Node.Parent)
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            GuardaCambios()
            Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
        Catch ex As Exception
            Me.MultiView1.SetActiveView(Me.viewErrores)
            Me.lblErrores.Text = ex.Message
        End Try
    End Sub

    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub

    Protected Sub lbConsultaRoles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbConsultaRoles.Click
        Response.Redirect("~/Administracion/Roles.aspx?TipoOperacion=4")
    End Sub

    Protected Sub lbNuevoRol_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbNuevoRol.Click
        Response.Redirect("~/Administracion/Roles.aspx?TipoOperacion=1")
    End Sub
End Class
