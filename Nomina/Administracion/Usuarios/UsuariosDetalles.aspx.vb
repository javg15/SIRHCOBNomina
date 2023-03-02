Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class Administracion_Usuarios_UsuariosDetalles
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindRoles(Optional ByVal SelectedValue As String = "")
        Dim oAplicacion As New Aplicacion
        Dim ddlRoles As DropDownList = CType(Me.dvUsuarios.FindControl("ddlRoles"), DropDownList)
        LlenaDDL(ddlRoles, "NombreRol", "IdRol", oAplicacion.ObtenerRoles(), SelectedValue)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            If Request.Params("TipoOperacion") = "0" Then
                Me.lblHeadPage.Text = "Usuarios: Vista detalle (Modificación)"
            ElseIf Request.Params("TipoOperacion") = "4" Then
                Me.lblHeadPage.Text = "Usuarios: Vista detalle (Consulta)"
            End If

            Dim txtbxLogin As TextBox = CType(Me.dvUsuarios.FindControl("txtbxLogin"), TextBox)
            Dim txtbxPassw1 As TextBox = CType(Me.dvUsuarios.FindControl("txtbxPassw1"), TextBox)
            Dim txtbxPassw2 As TextBox = CType(Me.dvUsuarios.FindControl("txtbxPassw2"), TextBox)
            Dim txtbxApePat As TextBox = CType(Me.dvUsuarios.FindControl("txtbxApePat"), TextBox)
            Dim txtbxApeMat As TextBox = CType(Me.dvUsuarios.FindControl("txtbxApeMat"), TextBox)
            Dim txtbxNombre As TextBox = CType(Me.dvUsuarios.FindControl("txtbxNombre"), TextBox)
            Dim txtbxIniciales As TextBox = CType(Me.dvUsuarios.FindControl("txtbxIniciales"), TextBox)
            Dim RFVPassw1 As RequiredFieldValidator = CType(Me.dvUsuarios.FindControl("RFVPassw1"), RequiredFieldValidator)
            Dim RFVPassw2 As RequiredFieldValidator = CType(Me.dvUsuarios.FindControl("RFVPassw2"), RequiredFieldValidator)
            Dim CVPassw As CompareValidator = CType(Me.dvUsuarios.FindControl("CVPassw"), CompareValidator)
            Dim btnGuardar As Button = CType(Me.dvUsuarios.FindControl("btnGuardar"), Button)

            Me.MultiView1.SetActiveView(Me.viewCaptura)
            If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "4" Or Request.Params("TipoOperacion") = "5" Then
                Dim dr As DataRow
                Dim oUsr As New Usuario
                oUsr.IdUsuario = CShort(Request.Params("IdUsuario"))
                dr = oUsr.ObtenerPorId()
                txtbxLogin.Text = dr("Login")

                If oUsr.EsSuperAdmin(txtbxLogin.Text) Then
                    txtbxPassw1.Enabled = True
                    txtbxPassw2.Enabled = True
                    CVPassw.Enabled = True
                Else
                    txtbxPassw1.Enabled = False
                    txtbxPassw2.Enabled = False
                    RFVPassw1.Enabled = False
                    RFVPassw2.Enabled = False
                    CVPassw.Enabled = False
                End If


                txtbxApePat.Text = dr("ApellidoPaterno")
                txtbxApeMat.Text = dr("ApellidoMaterno")
                txtbxNombre.Text = dr("Nombre")
                txtbxIniciales.Text = dr("Iniciales")
                BindRoles(dr("IdRol"))
                If Request.Params("TipoOperacion") = "4" Then
                    btnGuardar.Enabled = False
                End If
            End If
            If Request.Params("TipoOperacion") = "1" Then
                BindRoles(1)
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtbxLogin As TextBox = CType(Me.dvUsuarios.FindControl("txtbxLogin"), TextBox)
            Dim txtbxPassw1 As TextBox = CType(Me.dvUsuarios.FindControl("txtbxPassw1"), TextBox)
            Dim txtbxApePat As TextBox = CType(Me.dvUsuarios.FindControl("txtbxApePat"), TextBox)
            Dim txtbxApeMat As TextBox = CType(Me.dvUsuarios.FindControl("txtbxApeMat"), TextBox)
            Dim txtbxNombre As TextBox = CType(Me.dvUsuarios.FindControl("txtbxNombre"), TextBox)
            Dim txtbxIniciales As TextBox = CType(Me.dvUsuarios.FindControl("txtbxIniciales"), TextBox)
            Dim ddlRoles As DropDownList = CType(Me.dvUsuarios.FindControl("ddlRoles"), DropDownList)
            Dim oUsr As New Usuario
            With oUsr
                If Request.Params("TipoOperacion") = "0" Then
                    .IdUsuario = CShort(Request.Params("IdUsuario"))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .IdUsuario = 0
                End If
                .Login = txtbxLogin.Text.Trim.ToUpper
                .Password = txtbxPassw1.Text
                .ApellidoPaterno = txtbxApePat.Text.Trim.ToUpper
                .ApellidoMaterno = txtbxApeMat.Text.Trim.ToUpper
                .Nombre = txtbxNombre.Text.Trim.ToUpper
                .IdRol = CByte(ddlRoles.SelectedValue)
                .Iniciales = txtbxIniciales.Text.Trim.ToUpper
                If Request.Params("TipoOperacion") = "0" Then
                    .Actualizar(0, CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .Insertar(CType(Session("ArregloAuditoria"), String()))
                End If
            End With
            Me.MultiView1.SetActiveView(viewCapturaExitosa)
        Catch Ex As Exception
            Me.lblErrores.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewErrores)
        End Try
    End Sub

    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub
End Class
