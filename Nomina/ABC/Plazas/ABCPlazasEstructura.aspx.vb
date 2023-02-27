Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Plazas
Imports DataAccessLayer.COBAEV

Partial Class ABCPlazasEstructura
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Response.Expires = 0
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim oPlantel As New Plantel
            Dim dr, drE As DataRow
            Dim oEmpleadoPlaza As New EmpleadoPlazas
            Dim oEmpleado As New Empleado

            oEmpleadoPlaza.IdPlaza = CType(Request.Params("IdPlaza"), Integer)

            dr = oEmpleadoPlaza.ObtenPorId()
            oEmpleadoPlaza.IdEmp = CType(dr("IdEmp"), Integer)
            drE = oEmpleado.BuscarPorId(oEmpleadoPlaza.IdEmp)

            BindddlPlanteles(CInt(dr("IdPlantel")))
            BindddlCategorias(CInt(dr("IdCategoria")))
            BindddlEstatusPlaza(0)

            lblNombreEmpleado.Text = drE("NumEmp") + " - " + drE("ApellidoPaterno") + " " + drE("ApellidoMaterno") + " " + drE("Nombre")

            RecargaInformacion()
        End If
    End Sub


    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        Dim R As DataRow = dt.NewRow
        'renglon de seleccion nula
        R(TextField) = "-"
        R(ValueField) = "0"
        dt.Rows.InsertAt(R, 0)

        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub

    Private Sub BindddlCategorias(ByVal IdSelected As Integer)
        Dim oCategoria As New Categoria

        LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenTodas(), IdSelected)
    End Sub

    Private Sub BindddlPlanteles(ByVal IdSelected As Integer)
        Dim oPlantel As New Plantel

        LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True), IdSelected)
    End Sub

    Private Sub BindddlEstatusPlaza(ByVal IdSelected As Integer)
        Dim oSMP_Plazas As New SMP_Plazas

        LlenaDDL(ddlEstatusPlaza, "DescEstatusPlaza", "IdEstatusPlaza", oSMP_Plazas.ObtenEstatus(), Nothing)
    End Sub

    Private Sub RecargaInformacion()

        BindDatos()

    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado

        Dim oSMP_Plazas As New SMP_Plazas

        With gvDatos
            .DataSource = oSMP_Plazas.ObtenEstructura(ddlPlanteles.SelectedValue _
                                , ddlCategorias.SelectedValue _
                                , 0 _
                                , 0 _
                                , ddlEstatusPlaza.SelectedValue)
            .DataBind()
            .Visible = True
        End With
    End Sub


    Private Sub gvRowDataBound(ByVal pGVREA As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case pGVREA.Row.RowType
            Case DataControlRowType.DataRow


        End Select
    End Sub

    Protected Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        gvRowDataBound(e)
    End Sub

    Protected Sub ibCleanCategoria_Click(sender As Object, e As ImageClickEventArgs) Handles ibCleanCategoria.Click
        ddlCategorias.SelectedValue = "0"
    End Sub
    Protected Sub ibCleanPlanteles_Click(sender As Object, e As ImageClickEventArgs) Handles ibCleanPlanteles.Click
        ddlPlanteles.SelectedValue = "0"
    End Sub
    Protected Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        RecargaInformacion()
    End Sub

    Protected Sub lbUltNombTitular_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        'BindgvAusenciasJustificadas(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub

    Protected Sub lbUltNombOcupante_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        'BindgvAusenciasNoJustificadas(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub
End Class
