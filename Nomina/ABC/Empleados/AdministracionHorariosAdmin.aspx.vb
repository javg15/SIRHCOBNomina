Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Planteles
Imports DataAccessLayer.COBAEV.Empleados

Partial Class AdministracionHorariosAdmin
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Public dr As DataRow



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.Params("RFCEmp") Is Nothing = False Then

                Dim oPlantel As New Plantel
                Dim oCategoria As New Categoria
                Dim oEmpleado As New Empleado

                Dim oPlaza As New EmpleadoPlazas

                oEmpleado.RFC = Request.Params("RFCEmp")
                Dim dr As DataRow = oEmpleado.BuscarPorRFC(Request.Params("RFCEmp"))
                Dim IdEmpleado As Integer = dr("IdEmp")

                Dim drPlantel As DataRow = oPlaza.ObtenPorId(Request.Params("IdPlaza")).Rows(0)
                Dim IdPlantel As Integer = drPlantel("IdPlantel")
                hidIdPlantel.Value = IdPlantel

                hidIdSemestre.Value = CInt(Request.Params("IdSemestre"))

                dr = oPlantel.ObtenPorId(IdPlantel).Rows(0)
                lblPlantel.Text = dr("ClavePlantel") + " - " + dr("DescPlantel")
                lblCategoria.Text = drPlantel("DescCategoria")

                oEmpleado.IdEmp = CInt(IdEmpleado)
                Dim drEmp As DataRow = oEmpleado.ObtenDatosPersonales().Rows(0)
                lblEmpleado.Text = drEmp("NumEmp") +
                        " - " + drEmp("ApePatEmp") +
                        " " + drEmp("ApeMatEmp") +
                        " " + drEmp("NomEmp")

                hidIdEmpleado.Value = oEmpleado.IdEmp

                ActualizarControles()

                Me.MVMain.SetActiveView(Me.vwMain)

            End If
        End If
    End Sub

    Protected Sub ibEliminar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim oHorariosAdmin As New HorariosAdmin
        Dim lblIdHorariosAdmin As Label = CType(gvr.FindControl("lblIdHorariosAdmin"), Label)

        oHorariosAdmin.IdHorariosAdmin = lblIdHorariosAdmin.Text
        oHorariosAdmin.Eliminar(CType(Session("ArregloAuditoria"), String()))

        ActualizarControles()
    End Sub

    Private Sub ActualizarControles()
        Dim oHorariosAdmin As New HorariosAdmin
        Dim dtForm As DataTable = oHorariosAdmin.ObtenPorId(hidIdEmpleado.Value, hidIdPlantel.Value, hididsemestre.value)

        chkLunes.Enabled = True
        chkMartes.Enabled = True
        chkMiercoles.Enabled = True
        chkJueves.Enabled = True
        chkViernes.Enabled = True
        chkSabado.Enabled = True
        chkDomingo.Enabled = True

        chkLunes.Checked = False
        chkMartes.Checked = False
        chkMiercoles.Checked = False
        chkJueves.Checked = False
        chkViernes.Checked = False
        chkSabado.Checked = False
        chkDomingo.Checked = False

        gvHorarios.DataSource = dtForm
        gvHorarios.DataBind()

        For Each row As DataRow In dtForm.Rows
            If row("Dia").ToString().ToUpper() = "LUNES" Then
                chkLunes.Enabled = False
                chkLunes.Checked = True
            End If
            If row("Dia").ToString().ToUpper() = "MARTES" Then
                chkMartes.Enabled = False
                chkMartes.Checked = True
            End If

            If row("Dia").ToString().ToUpper() = "MIERCOLES" Then
                chkMiercoles.Enabled = False
                chkMiercoles.Checked = True
            End If
            If row("Dia").ToString().ToUpper() = "JUEVES" Then
                chkJueves.Enabled = False
                chkJueves.Checked = True
            End If
            If row("Dia").ToString().ToUpper() = "VIERNES" Then
                chkViernes.Enabled = False
                chkViernes.Checked = True
            End If
            If row("Dia").ToString().ToUpper() = "SABADO" Then
                chkSabado.Enabled = False
                chkSabado.Checked = True
            End If
            If row("Dia").ToString().ToUpper() = "DOMINGO" Then
                chkDomingo.Enabled = False
                chkDomingo.Checked = True
            End If
        Next
    End Sub

    Protected Sub btnGuardarModifes_Click(sender As Object, e As EventArgs) Handles btnGuardarModifes.Click
        Try
            Dim ddlHoraInicio As DropDownList = CType(Me.pnlHorasEd.FindControl("ddlHoraIni"), DropDownList)
            Dim ddlMinutosIni As DropDownList = CType(Me.pnlHorasEd.FindControl("ddlMinutosIni"), DropDownList)
            Dim ddlHoraFin As DropDownList = CType(Me.pnlHorasEd.FindControl("ddlHoraFin"), DropDownList)
            Dim ddlMinutosFin As DropDownList = CType(Me.pnlHorasEd.FindControl("ddlMinutosFin"), DropDownList)
            Dim hidIdEmpleado As HiddenField = CType(Me.pnlHorasEd.FindControl("hidIdEmpleado"), HiddenField)
            Dim hidIdHorariosAdmin As HiddenField = CType(Me.pnlHorasEd.FindControl("hidIdHorariosAdmin"), HiddenField)
            Dim ddlTipoJornada As DropDownList = CType(Me.pnlHorasEd.FindControl("ddlTipoJornada"), DropDownList)

            Dim chkDias As New List(Of CheckBox)
            chkDias.Add(CType(Me.pnlHorasEd.FindControl("chkLunes"), CheckBox))
            chkDias.Add(CType(Me.pnlHorasEd.FindControl("chkMartes"), CheckBox))
            chkDias.Add(CType(Me.pnlHorasEd.FindControl("chkMiercoles"), CheckBox))
            chkDias.Add(CType(Me.pnlHorasEd.FindControl("chkJueves"), CheckBox))
            chkDias.Add(CType(Me.pnlHorasEd.FindControl("chkViernes"), CheckBox))
            chkDias.Add(CType(Me.pnlHorasEd.FindControl("chkSabado"), CheckBox))
            chkDias.Add(CType(Me.pnlHorasEd.FindControl("chkDomingo"), CheckBox))

            Dim respuesta As String = ""
            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim oHorariosAdmin As New HorariosAdmin

            If hidIdHorariosAdmin.Value = "" Then hidIdHorariosAdmin.Value = "0"
            If hidIdEmpleado.Value = "" Then hidIdEmpleado.Value = "0"

            For Each checkBoxItem As CheckBox In chkDias
                If (checkBoxItem.Enabled And checkBoxItem.Checked) Then
                    With oHorariosAdmin
                        .IdHorariosAdmin = 0
                        .IdEmpleado = CInt(hidIdEmpleado.Value)
                        .TipoJornada = ddlTipoJornada.SelectedValue
                        .Dia = checkBoxItem.Text
                        .HoraInicio = TimeSpan.Parse(ddlHoraInicio.SelectedValue + ":" + ddlMinutosIni.SelectedValue)
                        .HoraFin = TimeSpan.Parse(ddlHoraFin.SelectedValue + ":" + ddlMinutosFin.SelectedValue)
                        .IdPlantel = CInt(hidIdPlantel.Value)
                        .IdSemestre = CInt(hidIdSemestre.Value)
                    End With

                    If (hidIdHorariosAdmin.Value Is Nothing Or hidIdHorariosAdmin.Value = "0") Then
                        respuesta = oHorariosAdmin.AgregaNueva(1, CType(Session("ArregloAuditoria"), String()))
                    Else
                        respuesta = oHorariosAdmin.AgregaNueva(0, CType(Session("ArregloAuditoria"), String()))
                    End If


                    If respuesta.Split("&")(1) = "" Then
                        hidIdHorariosAdmin.Value = respuesta.Split("&")(0)
                        Me.MVMain.SetActiveView(Me.viewExito)

                    Else
                        Me.lblError.Text = respuesta.Split("&")(1)
                        Me.MVMain.SetActiveView(Me.viewError)
                        'Me.lblError.Text = respuesta.Split("&")(1)
                    End If
                End If
            Next
            ActualizarControles()

        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MVMain.SetActiveView(Me.viewError)
            'Me.lblError.Text = Ex.Message
        End Try
    End Sub
    Protected Sub btnReintentarOp_Click(sender As Object, e As EventArgs) Handles btnReintentarOp.Click
        MVMain.SetActiveView(vwMain)
    End Sub
    Protected Sub btnCancelarOp_Click(sender As Object, e As EventArgs) Handles btnCancelarOp.Click
        MVMain.SetActiveView(vwMain)
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As EventArgs) Handles lbOtraOperacion.Click
        MVMain.SetActiveView(vwMain)
    End Sub

    Protected Sub ddlHoraIni_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlHoraIni.SelectedIndexChanged
        ActualizarJornada()
    End Sub
    Private Sub ActualizarJornada()
        Dim HoraInicio, HoraFin As DateTime
        HoraInicio = DateTime.Parse(ddlHoraIni.SelectedValue + ":" + ddlMinutosIni.SelectedValue)
        HoraFin = DateTime.Parse(ddlHoraFin.SelectedValue + ":" + ddlMinutosFin.SelectedValue)

        If HoraFin < HoraInicio Then
            txtJornada.Text = (HoraFin.AddHours(24) - HoraInicio).ToString
        Else
            txtJornada.Text = (HoraFin - HoraInicio).ToString
        End If
    End Sub
    Protected Sub ddlMinutosIni_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMinutosIni.SelectedIndexChanged
        ActualizarJornada()
    End Sub
    Protected Sub ddlHoraFin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlHoraFin.SelectedIndexChanged
        ActualizarJornada()
    End Sub
    Protected Sub ddlMinutosFin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMinutosFin.SelectedIndexChanged
        ActualizarJornada()
    End Sub
    Protected Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        If chkLunes.Enabled Then chkLunes.Checked = chkTodos.Checked
        If chkMartes.Enabled Then chkMartes.Checked = chkTodos.Checked
        If chkMiercoles.Enabled Then chkMiercoles.Checked = chkTodos.Checked
        If chkJueves.Enabled Then chkJueves.Checked = chkTodos.Checked
        If chkViernes.Enabled Then chkViernes.Checked = chkTodos.Checked
    End Sub
End Class
