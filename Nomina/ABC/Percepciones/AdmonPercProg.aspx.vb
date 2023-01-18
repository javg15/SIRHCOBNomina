Imports DataAccessLayer.COBAEV.Nominas
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Imports System.Data
Partial Class Administracion_Percepciones_AdmonPercProg
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oPerc As New Percepcion
        Dim oQna As New Quincenas
        Dim ddlQnasPago, ddlTipoImpuesto, ddlQnasPago2aParte As DropDownList
        Dim chbxFormaPago, chbxMesActualParaImpuesto As CheckBox
        Dim ds As DataSet
        Dim dt As DataTable
        Dim dt2 As DataTable
        Dim oNomina As New Nomina
        Dim txtbxDias As TextBox
        Dim hfDias As HiddenField
        With oPerc
            .IdPercepcion = CShort(Request.Params("IdPercepcion"))
            dt = oPerc.ObtenProgramada(CShort(Request.Params("IdSemestre")), CShort(Request.Params("IdQnaPago")), CByte(Request.Params("NumParte")))
            Me.dvPercepcion.DataSource = dt
            Me.dvPercepcion.DataBind()
        End With
        If Request.Params("TipoOperacion") = "0" Then
            CType(Me.dvPercepcion.FindControl("lblHeader"), Label).Text = "Actualizar parámetros de percepción programada"
        ElseIf Request.Params("TipoOperacion") = "1" Then
            CType(Me.dvPercepcion.FindControl("lblHeader"), Label).Text = "Parametrizar percepción programada"
        End If
        chbxFormaPago = CType(Me.dvPercepcion.FindControl("chbxFormaPago"), CheckBox)
        ddlQnasPago = CType(Me.dvPercepcion.FindControl("ddlQnasPago"), DropDownList)
        With ddlQnasPago
            ds = oQna.ObtenParaPercProg2(CShort(Request.Params("IdSemestre")), chbxFormaPago.Checked, CShort(Request.Params("IdPercepcion")), CShort(Request.Params("IdQnaPago")))
            dt2 = IIf(ds.Tables(0).Rows.Count > 0, ds.Tables(0), ds.Tables(1))
            .DataSource = dt2 'IIf(ds.Tables(0).Rows.Count > 0, ds.Tables(0), ds.Tables(1))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            CType(Me.dvPercepcion.FindControl("btnGuardar"), Button).Enabled = .SelectedValue <> "-1"
            If Request.Params("IdQnaPago") <> "0" Then .SelectedValue = Request.Params("IdQnaPago")
        End With
        ddlQnasPago2aParte = CType(Me.dvPercepcion.FindControl("ddlQnasPago2aParte"), DropDownList)
        With ddlQnasPago2aParte
            ds = oQna.ObtenParaPercProg2(CShort(Request.Params("IdSemestre")), chbxFormaPago.Checked, CShort(Request.Params("IdPercepcion")), CShort(Request.Params("IdQnaPago")))
            dt2 = IIf(ds.Tables(0).Rows.Count > 0, ds.Tables(0), ds.Tables(1))
            .DataSource = dt2 'IIf(ds.Tables(0).Rows.Count > 0, ds.Tables(0), ds.Tables(1))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            CType(Me.dvPercepcion.FindControl("btnGuardar"), Button).Enabled = .SelectedValue <> "-1"
            If Request.Params("IdQnaPago") <> "0" Then
                .SelectedValue = dt.Rows(0).Item("IdQna2aParte").ToString 'Request.Params("IdQnaPago")
            End If
            .Enabled = CBool(dt.Rows(0).Item("RequiereIdQnaPara2aParte"))
            If .Enabled = False Then
                .Items.Clear()
                .Items.Insert(0, "999999")
                .Items(0).Value = "32767"
            End If
        End With
        If Request.Params("IdPercepcion") = "180" Then
            CType(Me.dvPercepcion.FindControl("ddlQnasRetro"), DropDownList).Enabled = True
            BindQnasRetro(dt.Rows(0).Item("IdQnaRetro"))
        End If
        ddlTipoImpuesto = CType(Me.dvPercepcion.FindControl("ddlTipoImpuesto"), DropDownList)
        With ddlTipoImpuesto
            .DataSource = oNomina.GetTiposDeImpuesto()
            .DataTextField = "NombreImpuesto"
            .DataValueField = "IdTipoImpuesto"
            .DataBind()
            If Request.Params("IdQnaPago") <> "0" Then .SelectedValue = dt.Rows(0).Item("IdTipoImpuesto")
        End With
        ddlTipoImpuesto.Enabled = False
        txtbxDias = CType(Me.dvPercepcion.FindControl("txtbxDias"), TextBox)
        hfDias = CType(Me.dvPercepcion.FindControl("hfDias"), HiddenField)
        txtbxDias.Text = dt.Rows(0).Item("DiasPerc")
        txtbxDias.Enabled = ddlTipoImpuesto.SelectedValue = "2" 'Por reglamento
        hfDias.Value = dt.Rows(0).Item("DiasPerc")

        RFVDias = CType(Me.dvPercepcion.FindControl("RFVDias"), RequiredFieldValidator)
        RVDias = CType(Me.dvPercepcion.FindControl("RVDias"), RangeValidator)
        If Not txtbxDias.Enabled Then
            RFVDias.Enabled = False
            RVDias.Enabled = False
        End If
        chbxMesActualParaImpuesto = CType(Me.dvPercepcion.FindControl("chbxMesActualParaImpuesto"), CheckBox)
        If chbxFormaPago.Checked = False Then
            chbxMesActualParaImpuesto.Enabled = False
        Else
            chbxMesActualParaImpuesto.Enabled = True
        End If
        'CType(dvPercepcion.FindControl("btnGuardar"), Button).Enabled = ddlQnasPago.SelectedValue <> "-1"
        chbxFormaPago.Enabled = (Request.Params("IdQnaPago") <> "0" And dt2.Rows(0).Item("IdEstatusQuincena").ToString <> "3") _
                                    Or (Request.Params("IdQnaPago") = "0" And dt2.Rows(0).Item("IdEstatusQuincena").ToString <> "3")
        ddlQnasPago.Enabled = chbxFormaPago.Enabled
        ddlQnasPago2aParte.Enabled = chbxFormaPago.Enabled
        ddlQnasRetro.Enabled = chbxFormaPago.Enabled And Request.Params("IdPercepcion") = "180"
        txtbxDias.Enabled = chbxFormaPago.Enabled
        chbxMesActualParaImpuesto.Enabled = chbxFormaPago.Enabled
        CType(dvPercepcion.FindControl("btnGuardar"), Button).Enabled = chbxFormaPago.Enabled
        CType(dvPercepcion.FindControl("btnDesasociar"), Button).Enabled = chbxFormaPago.Enabled And Request.Params("IdQnaPago") <> "0"
    End Sub
    Private Sub BindQnasRetro(Optional ByVal IdQnaRetro As Short = 0)
        Dim ds As DataSet
        Dim ddlQnasRetro, ddlQnasPago As DropDownList
        Dim oQna As New Quincenas
        ddlQnasRetro = CType(Me.dvPercepcion.FindControl("ddlQnasRetro"), DropDownList)
        ddlQnasPago = CType(Me.dvPercepcion.FindControl("ddlQnasPago"), DropDownList)
        With ddlQnasRetro
            oQna.IdQuincena = CShort(ddlQnasPago.SelectedValue)
            ds = oQna.ObtenParaPercRetro(CShort(Request.Params("IdSemestre")), CShort(Request.Params("IdPercepcion")))
            .DataSource = ds.Tables(0)
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existen quincenas disponibles")
                .Items(0).Value = "-1"
            Else
                If IdQnaRetro <> 0 Then .SelectedValue = IdQnaRetro.ToString
            End If
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "1" Then
                Me.dvPercepcion.ChangeMode(DetailsViewMode.Edit)
            End If
            Me.MultiView1.SetActiveView(Me.viewCaptura)
            BindDatos()
            'If Request.Params("IdQnaPago") <> "0" Then CType(Me.dvPercepcion.FindControl("btnDesasociar"), Button).Enabled = True
        End If
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '    Dim oValidacion As New Validaciones
            '    Dim _DataCOBAEV As New DataCOBAEV
            '    Dim dsValida As DataSet
            '    Dim ddlVigIniPerc As DropDownList = CType(Me.dvPercepcion.FindControl("ddlVigIniPerc"), DropDownList)
            '    dsValida = _DataCOBAEV.setDataSetErrores()

            '    With oValidacion
            '        .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            '        .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
            '        .IdQuincena = CShort(Request.Params("IdQnaVigIniPerc"))
            '        .IdQuincenaNueva = CShort(ddlVigIniPerc.SelectedValue)
            '        If Not .ValidaPaginasOperacion(dsValida) Then
            '            Session.Add("dsValida", dsValida)
            '            Response.Redirect("~/ErroresPagina2.aspx")
            '        Else
            '            Session.Remove("dsValida")
            '        End If
            '    End With

            Dim oPerc As New Percepcion
            Dim IdQnaPago, IdQnaPagoAnt, IdSemestre, IdQnaRetro, IdQna2aParte As Short
            Dim chbxFormaPago, chbxMesActualParaImpuesto As CheckBox
            Dim IdTipoImpuesto As Byte
            Dim DiasPerc As Short
            IdQnaPago = CShort(CType(Me.dvPercepcion.FindControl("ddlQnasPago"), DropDownList).SelectedValue)
            IdQna2aParte = CShort(CType(Me.dvPercepcion.FindControl("ddlQnasPago2aParte"), DropDownList).SelectedValue)
            IdQnaRetro = CShort(CType(Me.dvPercepcion.FindControl("ddlQnasRetro"), DropDownList).SelectedValue)
            IdQnaPagoAnt = CShort(Request.Params("IdQnaPago"))
            IdSemestre = CShort(Request.Params("IdSemestre"))
            chbxFormaPago = CType(Me.dvPercepcion.FindControl("chbxFormaPago"), CheckBox)
            IdTipoImpuesto = CByte(CType(Me.dvPercepcion.FindControl("ddlTipoImpuesto"), DropDownList).SelectedValue)
            chbxMesActualParaImpuesto = CType(Me.dvPercepcion.FindControl("chbxMesActualParaImpuesto"), CheckBox)
            If IdTipoImpuesto = 1 Then
                DiasPerc = 0
            Else
                DiasPerc = CShort(CType(Me.dvPercepcion.FindControl("txtbxDias"), TextBox).Text)
            End If
            With oPerc
                .IdPercepcion = CShort(Request.Params("IdPercepcion"))
                If Request.Params("TipoOperacion") = "0" Then
                    If .IdPercepcion <> 180 Then
                        .UpdPercProg(IdQna2aParte, IdQnaPago, IdQnaPagoAnt, CByte(Request.Params("NumParte")), chbxFormaPago.Checked, CByte(Request.Params("TipoOperacion")), IdSemestre, IdTipoImpuesto, DiasPerc, chbxMesActualParaImpuesto.Checked, CType(Session("ArregloAuditoria"), String()))
                    Else
                        .UpdPercProgConRetro(IdQna2aParte, IdQnaPago, IdQnaPagoAnt, CByte(Request.Params("NumParte")), chbxFormaPago.Checked, CByte(Request.Params("TipoOperacion")), IdSemestre, IdTipoImpuesto, DiasPerc, IdQnaRetro, chbxMesActualParaImpuesto.Checked, CType(Session("ArregloAuditoria"), String()))
                    End If
                    Me.lblCapturaExitosa.Text = "Actualización realizada correctamente."
                    Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    If .IdPercepcion <> 180 Then
                        .InsPercProg(IdQna2aParte, IdQnaPago, CByte(Request.Params("NumParte")), chbxFormaPago.Checked, CByte(Request.Params("TipoOperacion")), IdSemestre, IdTipoImpuesto, DiasPerc, chbxMesActualParaImpuesto.Checked, CType(Session("ArregloAuditoria"), String()))
                    Else
                        .InsPercProgConRetro(IdQna2aParte, IdQnaPago, CByte(Request.Params("NumParte")), chbxFormaPago.Checked, CByte(Request.Params("TipoOperacion")), IdSemestre, IdTipoImpuesto, DiasPerc, IdQnaRetro, chbxMesActualParaImpuesto.Checked, CType(Session("ArregloAuditoria"), String()))
                    End If
                    Me.lblCapturaExitosa.Text = "Inserción realizada correctamente."
                    Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
                End If
            End With
        Catch ex As Exception
            Me.MultiView1.SetActiveView(Me.viewErrores)
            Me.lblErrores.Text = ex.Message
        End Try
    End Sub

    Protected Sub chbxFormaPago_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oQna As New Quincenas
        Dim ddlQnasPago, ddlTipoImpuesto As DropDownList
        Dim chbxFormaPago, chbxMesActualParaImpuesto As CheckBox
        Dim ds As DataSet
        Dim oPerc As New Percepcion
        Dim dt As DataTable
        With oPerc
            .IdPercepcion = CShort(Request.Params("IdPercepcion"))
            dt = oPerc.ObtenProgramada(CShort(Request.Params("IdSemestre")), CShort(Request.Params("IdQnaPago")), CByte(Request.Params("NumParte")))
        End With
        chbxFormaPago = CType(Me.dvPercepcion.FindControl("chbxFormaPago"), CheckBox)
        ddlQnasPago = CType(Me.dvPercepcion.FindControl("ddlQnasPago"), DropDownList)
        ddlTipoImpuesto = CType(Me.dvPercepcion.FindControl("ddlTipoImpuesto"), DropDownList)
        chbxMesActualParaImpuesto = CType(Me.dvPercepcion.FindControl("chbxMesActualParaImpuesto"), CheckBox)
        With ddlQnasPago
            ds = oQna.ObtenParaPercProg2(CShort(Request.Params("IdSemestre")), chbxFormaPago.Checked, CShort(Request.Params("IdPercepcion")), CShort(Request.Params("IdQnaPago")))
            .DataSource = IIf(ds.Tables(0).Rows.Count > 0, ds.Tables(0), ds.Tables(1))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            CType(Me.dvPercepcion.FindControl("btnGuardar"), Button).Enabled = .SelectedValue <> "-1"
            If .Items.FindByValue(Request.Params("IdQnaPago")) Is Nothing = False Then .SelectedValue = Request.Params("IdQnaPago")
        End With
        With ddlQnasPago2aParte
            ds = oQna.ObtenParaPercProg2(CShort(Request.Params("IdSemestre")), chbxFormaPago.Checked, CShort(Request.Params("IdPercepcion")), CShort(Request.Params("IdQnaPago")))
            .DataSource = IIf(ds.Tables(0).Rows.Count > 0, ds.Tables(0), ds.Tables(1))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            CType(Me.dvPercepcion.FindControl("btnGuardar"), Button).Enabled = .SelectedValue <> "-1"
            If .Items.FindByValue(Request.Params("IdQnaPago")) Is Nothing = False Then .SelectedValue = Request.Params("IdQnaPago")
            .Enabled = CBool(dt.Rows(0).Item("RequiereIdQnaPara2aParte"))
            If .Enabled = False Then
                .Items.Clear()
                .Items.Insert(0, "999999")
                .Items(0).Value = "32767"
            End If
        End With
        If Request.Params("IdPercepcion") = "180" Then
            BindQnasRetro(dt.Rows(0).Item("IdQnaRetro"))
        End If
        If chbxFormaPago.Checked = False Then
            chbxMesActualParaImpuesto.Checked = False
            chbxMesActualParaImpuesto.Enabled = False
            ddlTipoImpuesto.SelectedIndex = 0 'Por Ley
        Else
            chbxMesActualParaImpuesto.Enabled = True
            ddlTipoImpuesto.SelectedIndex = 1 'Por reglamento
        End If
        ddlTipoImpuesto.Enabled = False
        ddlTipoImpuesto_SelectedIndexChanged(sender, e)
        CType(dvPercepcion.FindControl("btnGuardar"), Button).Enabled = ddlQnasPago.SelectedValue <> "-1"
    End Sub

    Protected Sub lbReintentar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentar.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub

    Protected Sub ddlTipoImpuesto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlTipoImpuesto As DropDownList
        Dim txtbxDias As TextBox
        Dim hfDias As HiddenField
        Dim RFVDias As RequiredFieldValidator
        Dim RVDias As RangeValidator
        ddlTipoImpuesto = CType(Me.dvPercepcion.FindControl("ddlTipoImpuesto"), DropDownList)
        txtbxDias = CType(Me.dvPercepcion.FindControl("txtbxDias"), TextBox)
        hfDias = CType(Me.dvPercepcion.FindControl("hfDias"), HiddenField)
        RFVDias = CType(Me.dvPercepcion.FindControl("RFVDias"), RequiredFieldValidator)
        RVDias = CType(Me.dvPercepcion.FindControl("RVDias"), RangeValidator)
        txtbxDias.Enabled = Not txtbxDias.Enabled
        If Not txtbxDias.Enabled Then
            txtbxDias.Text = "0"
            RFVDias.Enabled = False
            RVDias.Enabled = False
        Else
            If hfDias.Value = "0" Then
                txtbxDias.Text = "1"
            Else
                txtbxDias.Text = hfDias.Value
            End If
            RFVDias.Enabled = True
            RVDias.Enabled = True
        End If
        txtbxDias.Enabled = ddlTipoImpuesto.SelectedValue = "2" 'Por reglamento
    End Sub

    Protected Sub ddlQnasPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Request.Params("IdPercepcion") = "180" Then
            BindQnasRetro()
        End If
    End Sub

    Protected Sub btnDesasociar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '    Dim oValidacion As New Validaciones
            '    Dim _DataCOBAEV As New DataCOBAEV
            '    Dim dsValida As DataSet
            '    Dim ddlVigIniPerc As DropDownList = CType(Me.dvPercepcion.FindControl("ddlVigIniPerc"), DropDownList)
            '    dsValida = _DataCOBAEV.setDataSetErrores()

            '    With oValidacion
            '        .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            '        .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
            '        .IdQuincena = CShort(Request.Params("IdQnaVigIniPerc"))
            '        .IdQuincenaNueva = CShort(ddlVigIniPerc.SelectedValue)
            '        If Not .ValidaPaginasOperacion(dsValida) Then
            '            Session.Add("dsValida", dsValida)
            '            Response.Redirect("~/ErroresPagina2.aspx")
            '        Else
            '            Session.Remove("dsValida")
            '        End If
            '    End With

            Dim oPerc As New Percepcion
            Dim IdQnaPago As Short
            IdQnaPago = CShort(CType(Me.dvPercepcion.FindControl("ddlQnasPago"), DropDownList).SelectedValue)
            With oPerc
                .IdPercepcion = CShort(Request.Params("IdPercepcion"))
                .DelPercProg(IdQnaPago, CByte(Request.Params("NumParte")), CType(Session("ArregloAuditoria"), String()))
                Me.lblCapturaExitosa.Text = "Eliminación realizada correctamente."
                Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
            End With
        Catch ex As Exception
            Me.MultiView1.SetActiveView(Me.viewErrores)
            Me.lblErrores.Text = ex.Message
        End Try
    End Sub
End Class
