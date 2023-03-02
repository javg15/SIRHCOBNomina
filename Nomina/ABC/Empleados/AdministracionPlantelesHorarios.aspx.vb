Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Nominas

Partial Class AdministracionPlantelesHorarios
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Public dr As DataRow

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        Try
            ddl.DataBind()
            If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        Catch
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.Params("IdPlantel") Is Nothing = False And Request.Params("IdPlantel") Is Nothing = False Then
                Dim oPlantel As New Plantel

                BindDatos(CInt(Request.Params("IdPlantel")))

                Dim lblPlantel As Label = CType(Me.pnlEd.FindControl("lblPlantel"), Label)
                Dim hidIdPlantel As TextBox = CType(Me.pnlEd.FindControl("hidIdPlantel"), TextBox)
                hidIdPlantel.Text = Request.Params("IdPlantel")

                lblPlantel.Text = oPlantel.ObtenPorId(CShort(hidIdPlantel.Text))(0)("DescPlantel")
                hidIdPlantel.Text = Request.Params("IdPlantel")
            End If

            MVMain.SetActiveView(vwMain)
        End If


    End Sub

    Protected Sub ibModificar_Click(sender As Object, e As System.EventArgs)
        Dim gvHoras As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim oQna As New Quincenas

        Dim lblInicio As Label = CType(gvHoras.FindControl("lblInicio"), Label)
        Dim lblTermino As Label = CType(gvHoras.FindControl("lblTermino"), Label)

        txtInicio.Text = lblInicio.Text
        txtTermino.Text = lblTermino.Text

        hidIdPlantelesHorarios.Value = "0"

        pnlEd.Enabled = True
        MVMain.SetActiveView(vwHorariosEd)
    End Sub

    Public Sub BindDatos(ByVal IdPlantel As Integer)
        Dim oHoras As New PlantelesHorarios
        With Me.gvHoras
            .DataSource = oHoras.ObtenHorarios("&IdPlantel=" + IdPlantel.ToString)
            .DataBind()
        End With
    End Sub
    Protected Sub lbAgregarHorario_Click(sender As Object, e As EventArgs) Handles lbAgregarHorario.Click
        txtInicio.Text = ""
        txtTermino.Text = ""

        hidIdPlantelesHorarios.Value = "0"

        MVMain.SetActiveView(vwHorariosEd)
    End Sub
    Protected Sub btnGuardarModifes_Click(sender As Object, e As EventArgs) Handles btnGuardarModifes.Click
        Try
            Dim hidIdPlantelesHorarios As HiddenField = CType(Me.pnlEd.FindControl("hidIdPlantelesHorarios"), HiddenField)
            Dim hidIdPlantel As TextBox = CType(Me.pnlEd.FindControl("hidIdPlantel"), TextBox)
            Dim txtInicio As TextBox = CType(Me.pnlEd.FindControl("txtInicio"), TextBox)
            Dim txtTermino As TextBox = CType(Me.pnlEd.FindControl("txtTermino"), TextBox)

            Dim respuesta As String
            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim oPlanteHorario As New PlantelesHorarios

            If hidIdPlantelesHorarios.Value = "" Then hidIdPlantelesHorarios.Value = "0"

            With oPlanteHorario
                .IdPlantelesHorarios = CInt(hidIdPlantelesHorarios.Value)
                .IdPlanteles = CInt(hidIdPlantel.Text)
                .Inicio = Convert.ToDateTime(txtInicio.Text)
                .Termino = Convert.ToDateTime(txtTermino.Text)
                .Estatus = "A"
            End With

            If (hidIdPlantelesHorarios.Value Is Nothing Or hidIdPlantelesHorarios.Value = "0") Then
                respuesta = oPlanteHorario.AgregaNueva(1, CType(Session("ArregloAuditoria"), String()))
            Else
                respuesta = oPlanteHorario.AgregaNueva(0, CType(Session("ArregloAuditoria"), String()))
            End If

            If respuesta.Split("&")(1) = "" Then
                CType(Me.pnlEd.FindControl("hidIdPlantelesHorarios"), HiddenField).Value = respuesta.Split("&")(0)
                BindDatos(CInt(hidIdPlantel.Text))
                Me.MVMain.SetActiveView(Me.viewExito)
            Else
                Me.lblError.Text = respuesta.Split("&")(1)
                Me.MVMain.SetActiveView(Me.viewError)
            End If
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MVMain.SetActiveView(Me.viewError)
        End Try

    End Sub

    Protected Sub btnReintentarOp_Click(sender As Object, e As EventArgs) Handles btnReintentarOp.Click
        MVMain.SetActiveView(vwHorariosEd)
    End Sub
    Protected Sub btnCancelarOp_Click(sender As Object, e As EventArgs) Handles btnCancelarOp.Click
        MVMain.SetActiveView(vwMain)
    End Sub
    Protected Sub lbOtraOperacion_Click(sender As Object, e As EventArgs) Handles lbOtraOperacion.Click
        MVMain.SetActiveView(vwHorariosEd)
    End Sub
    Protected Sub lbOtraOperacion0_Click(sender As Object, e As EventArgs) Handles lbOtraOperacion0.Click
        MVMain.SetActiveView(vwMain)
    End Sub
    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        MVMain.SetActiveView(vwMain)
    End Sub
    Protected Sub lbBackPlanteles_Click(sender As Object, e As EventArgs) Handles lbBackPlanteles.Click

    End Sub
End Class
