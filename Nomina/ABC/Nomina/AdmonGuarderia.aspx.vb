Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Empleados.Sexos
Imports DataAccessLayer.COBAEV.Mexico.Estados
Imports System.Data
Partial Class AdmonGuarderia
    Inherits System.Web.UI.Page
    Private dr As DataRow
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindSexos(Optional ByVal IdSexo As String = "3")
        Dim oSexo As New Sexo
        Dim ddlSexos As DropDownList = CType(Me.dvHijos.FindControl("ddlSexos"), DropDownList)
        LlenaDDL(ddlSexos, "DescSexo", "IdSexo", oSexo.ObtenTodos(), IdSexo)
    End Sub
    Private Sub BindEstados(Optional ByVal IdEdo As String = "30")
        Dim oEstado As New Estado
        Dim ddlEstados As DropDownList = CType(Me.dvHijos.FindControl("ddlEstados"), DropDownList)
        LlenaDDL(ddlEstados, "NomEdo", "IdEdo", oEstado.ObtenTodos, IdEdo)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Me.MultiView1.SetActiveView(Me.viewCaptura)
            Dim txtbxFecNac As TextBox = CType(Me.dvHijos.FindControl("txtbxFecNac"), TextBox)
            Dim hfFecNac As HiddenField = CType(Me.dvHijos.FindControl("hfFecNac"), HiddenField)
            Dim ibFecNac As ImageButton = CType(Me.dvHijos.FindControl("ibFecNac"), ImageButton)
            If Request.Params("TipoOperacion") = "1" Then
                BindSexos()

                ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + txtbxFecNac.ClientID + "','" + hfFecNac.ClientID + "'); return false")

                Dim oEstado As New Estado
                Dim ddlEstados As DropDownList = CType(Me.dvHijos.FindControl("ddlEstados"), DropDownList)
                LlenaDDL(ddlEstados, "NomEdo", "IdEdo", oEstado.ObtenTodos, 30)
            ElseIf Request.Params("TipoOperacion") = "0" Then
                Dim oEmp As New EmpleadosHijos
                oEmp.IdEmpHijo = Request.Params("IdEmpHijo")
                dr = oEmp.ObtenPorId()

                Dim txtbxRFC As TextBox = CType(Me.dvHijos.FindControl("txtbxRFC"), TextBox)
                Dim txtbxCURP As TextBox = CType(Me.dvHijos.FindControl("txtbxCURP"), TextBox)
                Dim txtbxApePat As TextBox = CType(Me.dvHijos.FindControl("txtbxApePat"), TextBox)
                Dim txtbxApeMat As TextBox = CType(Me.dvHijos.FindControl("txtbxApeMat"), TextBox)
                Dim txtbxNombre As TextBox = CType(Me.dvHijos.FindControl("txtbxNombre"), TextBox)
                Dim chbxIncluirParaCalculo As CheckBox = CType(Me.dvHijos.FindControl("chbxIncluirParaCalculo"), CheckBox)

                txtbxRFC.Text = dr("RFC").ToString
                txtbxCURP.Text = dr("CURP").ToString
                txtbxApePat.Text = dr("ApePat").ToString
                txtbxApeMat.Text = dr("ApeMat").ToString
                txtbxNombre.Text = dr("Nombre").ToString
                BindSexos(dr("IdSexo").ToString)
                txtbxFecNac.Text = dr("FechaNacHijo").ToString.Substring(0, 10)
                ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + txtbxFecNac.ClientID + "','" + hfFecNac.ClientID + "'); return false")
                BindEstados(dr("IdEdo").ToString)
                chbxIncluirParaCalculo.Checked = dr("IncluirParaCalculo")
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtbxRFC As TextBox = CType(Me.dvHijos.FindControl("txtbxRFC"), TextBox)
            Dim txtbxCURP As TextBox = CType(Me.dvHijos.FindControl("txtbxCURP"), TextBox)
            Dim txtbxApePat As TextBox = CType(Me.dvHijos.FindControl("txtbxApePat"), TextBox)
            Dim txtbxApeMat As TextBox = CType(Me.dvHijos.FindControl("txtbxApeMat"), TextBox)
            Dim txtbxNombre As TextBox = CType(Me.dvHijos.FindControl("txtbxNombre"), TextBox)
            Dim ddlSexos As DropDownList = CType(Me.dvHijos.FindControl("ddlSexos"), DropDownList)
            Dim txtbxFecNac As TextBox = CType(Me.dvHijos.FindControl("txtbxFecNac"), TextBox)
            Dim ddlEstados As DropDownList = CType(Me.dvHijos.FindControl("ddlEstados"), DropDownList)
            Dim chbxIncluirParaCalculo As CheckBox = CType(Me.dvHijos.FindControl("chbxIncluirParaCalculo"), CheckBox)
            Dim oEmp As New EmpleadosHijos
            With oEmp
                .RFCHijo = txtbxRFC.Text.Trim.ToUpper
                .CURPHijo = txtbxCURP.Text.Trim.ToUpper
                .ApePatHijo = txtbxApePat.Text.Trim.ToUpper
                .ApeMatHijo = txtbxApeMat.Text.Trim.ToUpper
                .NomHijo = txtbxNombre.Text.Trim.ToUpper
                .FechaNacHijo = CDate(txtbxFecNac.Text)
                .IdSexo = CByte(ddlSexos.SelectedValue)
                .IdEdo = CByte(ddlEstados.SelectedValue)
                .IncluirParaCalculo = CBool(chbxIncluirParaCalculo.Checked)
                If Request.Params("TipoOperacion") = "0" Then
                    .RFCEmp = String.Empty
                    .IdEmpHijo = CType(Request.Params("IdEmpHijo"), Integer)
                    .Actualizar(0, CType(Session("ArregloAuditoria"), String()))
                Else
                    .RFCEmp = Request.Params("RFCEmp")
                    .IdEmpHijo = 0
                    .Insertar(CType(Session("ArregloAuditoria"), String()))
                End If
            End With
            Me.MultiView1.SetActiveView(viewCapturaExitosa)
        Catch Ex As Exception
            Me.lblErrores.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewErrores)
        End Try
    End Sub

    Protected Sub btnGeneraRFC_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.dvHijos.FindControl("txtbxRFC"), TextBox)
        Dim txtbxCURP As TextBox = CType(Me.dvHijos.FindControl("txtbxCURP"), TextBox)
        Dim txtbxApePat As TextBox = CType(Me.dvHijos.FindControl("txtbxApePat"), TextBox)
        Dim txtbxApeMat As TextBox = CType(Me.dvHijos.FindControl("txtbxApeMat"), TextBox)
        Dim txtbxNombre As TextBox = CType(Me.dvHijos.FindControl("txtbxNombre"), TextBox)
        Dim txtbxFecNac As TextBox = CType(Me.dvHijos.FindControl("txtbxFecNac"), TextBox)
        Dim ddlSexos As DropDownList = CType(Me.dvHijos.FindControl("ddlSexos"), DropDownList)
        Dim ddlEstados As DropDownList = CType(Me.dvHijos.FindControl("ddlEstados"), DropDownList)
        With oEmp
            .ApePatEmp = txtbxApePat.Text.ToUpper.Trim
            .ApeMatEmp = txtbxApeMat.Text.ToUpper.Trim
            .NomEmp = txtbxNombre.Text.ToUpper.Trim
            .FecNacEmp = CType(txtbxFecNac.Text, Date)
            txtbxRFC.Text = oEmp.GenerarRFC()
            .IdSexo = CType(ddlSexos.SelectedValue, Byte)
            .IdEdo = CType(ddlEstados.SelectedValue, Byte)
            txtbxCURP.Text = oEmp.GenerarCURP()
        End With
    End Sub

    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click

        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub

    'Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
    '    If Not IsPostBack Then
    '        If Request.Params("TipoOperacion") = "1" Then
    '            'BindPlantelesParaPago()
    '        ElseIf Request.Params("TipoOperacion") = "0" Then
    '            Dim WucEfectos1 As WebControls_wucEfectos = CType(Me.dvHijos.FindControl("WucEfectos1"), WebControls_wucEfectos)
    '            Dim ddlQnaInicio As DropDownList = CType(WucEfectos1.FindControl("ddlQnaInicio"), DropDownList)
    '            Dim ddlQnaFin As DropDownList = CType(WucEfectos1.FindControl("ddlQnaFin"), DropDownList)
    '            ddlQnaInicio.SelectedValue = dr("IdQnaIni").ToString
    '            ddlQnaFin.SelectedValue = dr("IdQnaFin").ToString
    '            BindPlantelesParaPago(dr("IdPlantel").ToString)
    '        End If
    '    End If
    'End Sub

    'Protected Sub ddlSexos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    BindParentescos()
    'End Sub
End Class
