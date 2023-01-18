Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Imports System.IO.Stream
Imports System.IO.StreamWriter
Imports DataAccessLayer.COBAEV.Empleados
Partial Class EmpleadosHistoriaClaves
    Inherits System.Web.UI.Page
    Private Sub ConsultaHistoriaClave()
        Dim oEmp As New Empleado
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If hfRFC.Value <> String.Empty Then
            Me.lblMsj1.Text = "Historia de la " + Me.ddlTipoClave.SelectedItem.Text.ToLower + " " + Me.ddlClaves.SelectedItem.Text.ToUpperInvariant _
                            + " aplicada al empleado:"
            Me.lblEmpInf.Text = hfNomEmp.Value.ToUpperInvariant
            Me.gvHistoriaClave.DataSource = oEmp.ObtenHistoriaClave(hfRFC.Value, CShort(Me.ddlClaves.SelectedValue), Me.ddlTipoClave.SelectedValue)
            Me.gvHistoriaClave.DataBind()
        End If
    End Sub
    Private Sub BindDeducciones()
        Dim oDeduccion As New Deduccion
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If hfRFC.Value <> String.Empty Then
            LlenaDDL(Me.ddlClaves, "Deduccion", "IdDeduccion", oDeduccion.ObtenAplicadasPorEmp(hfRFC.Value), Nothing)
        End If
        With Me.ddlClaves
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existen deducciones aplicadas en la quincena seleccionada")
                .Items(0).Value = -1
            Else
            End If
        End With
        Me.pnlClaves.GroupingText = "Seleccione deducción"
    End Sub
    Private Sub BindPercepciones()
        Dim oPercepcion As New Percepcion
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If hfRFC.Value <> String.Empty Then
            LlenaDDL(Me.ddlClaves, "Percepcion", "IdPercepcion", oPercepcion.ObtenAplicadasPorEmp(hfRFC.Value), Nothing)
        End If
        With Me.ddlClaves
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existen percepciones aplicadas en la quincena seleccionada")
                .Items(0).Value = -1
            Else
            End If
        End With
        Me.pnlClaves.GroupingText = "Seleccione percepción"
    End Sub

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Protected Sub ddlTipoClave_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoClave.SelectedIndexChanged
        If Me.ddlTipoClave.SelectedValue = "D" Then
            BindDeducciones()
        Else
            BindPercepciones()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            'Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            'Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            'Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            'Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false")
            If Me.ddlTipoClave.SelectedValue = "D" Then
                BindDeducciones()
            Else
                BindPercepciones()
            End If
        End If

    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        ConsultaHistoriaClave()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Me.btnConsultar.Enabled = hfNomEmp.Value <> String.Empty
    End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        If Me.ddlTipoClave.SelectedValue = "D" Then
            BindDeducciones()
        Else
            BindPercepciones()
        End If
        ConsultaHistoriaClave()
    End Sub
End Class