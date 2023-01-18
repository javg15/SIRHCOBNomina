Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class ABC_Recibos_AdmonDatosComplementarios
    Inherits System.Web.UI.Page
    Private Sub AplicaValidaciones()
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            '.RFC = Session("RFCParaCons")
            '.IdQuincena = 0
            .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
            'If Request.Params("TipoOperacion") <> "2" Then
            '    If Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Insert Then
            '        .Cantidad = CByte(CType(Me.dvCargaHoraria.FindControl("txtbxCantidadIns"), TextBox).Text)
            '    ElseIf Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Edit Then
            '        .Cantidad = CByte(CType(Me.dvCargaHoraria.FindControl("txtbxCantidad"), TextBox).Text)
            '        .IdHora = CType(Request.Params("IdHora"), Integer)
            '    End If
            'End If
            If Not .ValidaPaginasOperacion(dsValida) Then
                Session.Add("dsValida", dsValida)
                Response.Redirect("~/ErroresPagina2.aspx")
            Else
                Session.Remove("dsValida")
            End If
        End With
    End Sub
    Private Sub BinddvDatosComplemen()
        Dim oRecibo As New Recibos
        If Request.Params("TipoOperacion") = "0" Then
            Me.dvDatosComplemen.DataSource = oRecibo.ObtenDatosParaIndemnizaciones(CShort(Request.Params("IdRecibo")))
        End If
        Me.dvDatosComplemen.DataBind()
    End Sub

    Private Sub EliminaDatosComplemen()
        Try
            Dim oRecibo As New Recibos
            oRecibo.EliminaDatosParaIndemnizaciones(CShort(Request.Params("IdRecibo")), CType(Session("ArregloAuditoria"), String()))
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Me.MultiView1.SetActiveView(Me.viewEditar)
            If Request.Params("TipoOperacion") = "0" Then
                Me.dvDatosComplemen.DefaultMode = DetailsViewMode.Edit
                BinddvDatosComplemen()
                Me.dvDatosComplemen.HeaderText = "Modificar datos complementarios"
            ElseIf Request.Params("TipoOperacion") = "1" Then
                Me.dvDatosComplemen.DefaultMode = DetailsViewMode.Insert
                Me.dvDatosComplemen.HeaderText = "Capturar datos complementarios"
            ElseIf Request.Params("TipoOperacion") = "3" Then
                EliminaDatosComplemen()
            End If
        End If
    End Sub

    Protected Sub btnGurdar_E_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ''AplicaValidaciones()
            Dim Terminacion As String = String.Empty
            If Me.dvDatosComplemen.CurrentMode = DetailsViewMode.Edit Then
                Terminacion = "_E"
            ElseIf Me.dvDatosComplemen.CurrentMode = DetailsViewMode.Insert Then
                Terminacion = "_I"
            End If

            Dim tbAniosDeServicio As TextBox = CType(Me.dvDatosComplemen.FindControl("tbAniosDeServicio" + Terminacion), TextBox)
            Dim tbIngresoExcento As TextBox = CType(Me.dvDatosComplemen.FindControl("tbIngresoExcento" + Terminacion), TextBox)
            Dim tbUltimoSueldo As TextBox = CType(Me.dvDatosComplemen.FindControl("tbUltimoSueldo" + Terminacion), TextBox)
            Dim tbISRUltimoSueldo As TextBox = CType(Me.dvDatosComplemen.FindControl("tbISRUltimoSueldo" + Terminacion), TextBox)

            Dim oRecibo As New Recibos
            Dim oUsr As New Usuario
            With oRecibo
                .IdRecibo = CShort(Request.Params("IdRecibo"))
                If Request.Params("TipoOperacion") = "0" Then
                    .ActualizaDatosParaIndemnizaciones(CShort(Request.Params("IdRecibo")), CDec(tbAniosDeServicio.Text), _
                                                        CDec(tbIngresoExcento.Text), CDec(tbUltimoSueldo.Text), CDec(tbISRUltimoSueldo.Text), _
                                                        CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .InsertaDatosParaIndemnizaciones(CShort(Request.Params("IdRecibo")), CDec(tbAniosDeServicio.Text), _
                                                        CDec(tbIngresoExcento.Text), CDec(tbUltimoSueldo.Text), CDec(tbISRUltimoSueldo.Text), _
                                                        CType(Session("ArregloAuditoria"), String()))
                End If
            End With
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub
End Class
