Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Planteles

Partial Class AdministracionHorarios
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Public dr As DataRow

    Private Sub LlenaDDLDias(Optional ByVal SelectedValue As String = "0")
        Dim dt As New DataTable()
        dt.Columns.Add("IdDia", GetType(Integer))
        dt.Columns.Add("Dia", GetType(String))
        Dim R As DataRow = dt.NewRow
        'renglon de seleccion nula
        R("Dia") = "-"
        R("IdDia") = "0"
        dt.Rows.InsertAt(R, 0)
        R = dt.NewRow
        R("Dia") = "Lunes"
        R("IdDia") = "1"
        dt.Rows.InsertAt(R, 1)
        R = dt.NewRow
        R("Dia") = "Martes"
        R("IdDia") = "2"
        dt.Rows.InsertAt(R, 2)
        R = dt.NewRow
        R("Dia") = "Miércoles"
        R("IdDia") = "3"
        dt.Rows.InsertAt(R, 3)
        R = dt.NewRow
        R("Dia") = "Jueves"
        R("IdDia") = "4"
        dt.Rows.InsertAt(R, 4)
        R = dt.NewRow
        R("Dia") = "Viernes"
        R("IdDia") = "5"
        dt.Rows.InsertAt(R, 5)
        R = dt.NewRow
        R("Dia") = "Sábado"
        R("IdDia") = "6"
        dt.Rows.InsertAt(R, 6)
        R = dt.NewRow
        R("Dia") = "Domingo"
        R("IdDia") = "7"
        dt.Rows.InsertAt(R, 7)

        ddlDia.DataSource = dt
        ddlDia.DataTextField = "Dia"
        ddlDia.DataValueField = "IdDia"
        ddlDia.DataBind()
        If SelectedValue Is Nothing = False Then ddlDia.SelectedValue = SelectedValue
    End Sub

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "0")
        Try
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
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.Params("IdHora") Is Nothing = False And Request.Params("IdHora") Is Nothing = False Then
                Dim oPlantel As New Plantel
                Dim oMateria As New Materia
                Dim oGrupo As New Grupo
                Dim oHora As New Hora
                Dim oPlantelHorario As New PlantelesHorarios

                oHora.IdHora = CInt(Request.Params("IdHora"))
                ds = oHora.ObtenPorId()
                dr = ds.Tables(0).Rows(0)
                oHora.IdPlantel = dr("IdPlantel")
                oHora.IdMateria = dr("IdMateria")
                oHora.IdGrupo = dr("IdGrupo")
                oHora.Horas = dr("Cantidad")

                hidIdHoras.Text = Request.Params("IdHora")

                Dim lblPlantel As Label = CType(Me.pnlEd.FindControl("lblPlantel"), Label)
                lblPlantel.Text = oPlantel.ObtenPorId(oHora.IdPlantel).Rows(0)("DescPlantel")
                Dim lblMateria As Label = CType(Me.pnlEd.FindControl("lblMateria"), Label)
                lblMateria.Text = oMateria.ObtenPorId(oHora.IdMateria)("NombreMateria")
                Dim lblGrupo As Label = CType(Me.pnlEd.FindControl("lblGrupo"), Label)
                oGrupo.IdGrupo = oHora.IdGrupo
                lblGrupo.Text = oGrupo.ObtenPorId()("Grupo")
                lblTotalHoras.Text = oHora.Horas

                LlenaDDLDias()
                LlenaDDL(ddlHoraInicio, "Inicio", "IdPlantelesHorarios", oPlantelHorario.ObtenHorarios("&IdPlantel=" + oHora.IdPlantel.ToString))
                txtCantidadHoras.Text = "0"

                BindDatos(CInt(Request.Params("IdHora")))
            End If

            MVMain.SetActiveView(vwMain)
        End If


    End Sub

    Protected Sub ibModificar_Click(sender As Object, e As System.EventArgs)
        Dim gvHoras As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)

        Dim lblIdHorariosClase As Label = CType(gvHoras.FindControl("lblIdHorariosClase"), Label)
        Dim lblDia As Label = CType(gvHoras.FindControl("lblDia"), Label)
        Dim lblIdDia As Label = CType(gvHoras.FindControl("lblIdDia"), Label)
        Dim lblInicio As Label = CType(gvHoras.FindControl("lblInicio"), Label)
        Dim lblIdHoraInicio As Label = CType(gvHoras.FindControl("lblIdHoraInicio"), Label)
        Dim lblCantidadHoras As Label = CType(gvHoras.FindControl("lblCantidadHoras"), Label)

        ddlDia.SelectedValue = lblIdDia.Text
        ddlHoraInicio.SelectedValue = lblIdHoraInicio.Text
        txtCantidadHoras.Text = lblCantidadHoras.Text

        hidIdHorariosClase.Value = lblIdHorariosClase.Text
        hidHorasRestantes.Text = CInt(hidHorasRestantes.Text) + CInt(txtCantidadHoras.Text)

        pnlEd.Enabled = True
        MVMain.SetActiveView(vwHorariosEd)
    End Sub

    Protected Sub ibEliminar_Click(sender As Object, e As System.EventArgs)
        Dim gvHoras As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)

        Dim lblIdHorariosClase As Label = CType(gvHoras.FindControl("lblIdHorariosClase"), Label)

        hidIdHorariosClase.Value = lblIdHorariosClase.Text

        Dim oHorariosClase As New HorariosClase

        With oHorariosClase
            .IdHorariosClase = CInt(hidIdHorariosClase.Value)
        End With

        oHorariosClase.Eliminar(CType(Session("ArregloAuditoria"), String()))

        BindDatos(CInt(Request.Params("IdHora")))
    End Sub

    Public Sub BindDatos(ByVal IdHoras As Integer)
        Dim oHoras As New HorariosClase
        With Me.gvHoras
            .DataSource = oHoras.ObtenHorariosClase("&IdHoras=" + IdHoras.ToString)
            .DataBind()
        End With
    End Sub
    Protected Sub lbAgregarHorario_Click(sender As Object, e As EventArgs) Handles lbAgregarHorario.Click
        Try
            ddlDia.SelectedValue = "0"
            ddlHoraInicio.SelectedValue = "0"
            txtCantidadHoras.Text = "0"

            hidIdHorariosClase.Value = "0"

            MVMain.SetActiveView(vwHorariosEd)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnGuardarModifes_Click(sender As Object, e As EventArgs) Handles btnGuardarModifes.Click
        Try
            Dim ddlHoraInicio As DropDownList = CType(Me.pnlEd.FindControl("ddlHoraInicio"), DropDownList)
            Dim txtCantidadHoras As TextBox = CType(Me.pnlEd.FindControl("txtCantidadHoras"), TextBox)
            Dim ddlDia As DropDownList = CType(Me.pnlEd.FindControl("ddlDia"), DropDownList)

            Dim respuesta As String
            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim oHorariosClase As New HorariosClase

            If hidIdHorariosClase.Value = "" Then hidIdHorariosClase.Value = "0"

            With oHorariosClase
                .IdHorariosClase = CInt(hidIdHorariosClase.Value)
                .Dia = CInt(ddlDia.SelectedValue)
                .IdPlantelesHorariosInicio = CInt(ddlHoraInicio.SelectedValue)
                .Horas = CInt(txtCantidadHoras.Text)
                .IdHoras = hidIdHoras.Text
            End With

            If (hidIdHorariosClase.Value Is Nothing Or hidIdHorariosClase.Value = "0") Then
                respuesta = oHorariosClase.AgregaNueva(1, CType(Session("ArregloAuditoria"), String()))
            Else
                respuesta = oHorariosClase.AgregaNueva(0, CType(Session("ArregloAuditoria"), String()))
            End If

            If respuesta.Split("&")(1) = "" Then
                hidIdHorariosClase.Value = respuesta.Split("&")(0)
                Me.MVMain.SetActiveView(Me.viewExito)
                BindDatos(CInt(Request.Params("IdHora")))
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
    Protected Sub gvHoras_DataBound(sender As Object, e As EventArgs) Handles gvHoras.DataBound

    End Sub
    Protected Sub gvHoras_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvHoras.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                hidHorasRestantes.Text = lblTotalHoras.Text
            Case DataControlRowType.DataRow
                Dim lblCantidadHoras As Label = CType(e.Row.FindControl("lblCantidadHoras"), Label)
                hidHorasRestantes.Text = CInt(hidHorasRestantes.Text) - CInt(lblCantidadHoras.Text)
        End Select



    End Sub
    Protected Sub txtCantidadHoras_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadHoras.TextChanged
        hidHorasRestantes.Text = CInt(hidHorasRestantes.Text) - CInt(txtCantidadHoras.Text)
    End Sub
End Class
