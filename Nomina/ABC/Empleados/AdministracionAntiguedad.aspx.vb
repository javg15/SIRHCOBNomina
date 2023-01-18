Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Partial Class ABC_Empleados_AdministracionAntiguedad
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim btnCancelar As Button
        Dim strPostbackURL As String

        btnCancelar = CType(dvAntiguedad.FindControl("btnCancelar"), Button)

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

        oEmp.RFC = String.Empty
        oEmp.IdEmp = CType(Request.Params("IdEmp"), Integer)
        Me.dvAntiguedad.DataSource = oEmp.ObtenAntiguedad()
        Me.dvAntiguedad.DataBind()

        btnCancelar = CType(dvAntiguedad.FindControl("btnCancelar"), Button)
        btnCancelar.PostBackUrl = strPostbackURL
        lbOtraOperacion0.PostBackUrl = strPostbackURL
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim btnCancelar As Button
            Response.Expires = 0

            Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
            Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

            BtnNewSearch.Visible = False
            BtnCancelSearch.Visible = False
            BtnSearch.Visible = False

            If Request.Params("TipoOperacion") = "0" Then
                Me.MultiView1.SetActiveView(Me.viewAntiguedad)
                BindDatos()
                btnCancelar = CType(dvAntiguedad.FindControl("btnCancelar"), Button)

                If Session("URLAnt") Is Nothing = False Then
                    If Session("URLAnt").ToString.Contains(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString) Then
                        btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                        lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                    Else
                        btnCancelar.PostBackUrl = "~/" + Session("URLAnt")
                        lbOtraOperacion0.PostBackUrl = "~/" + Session("URLAnt")
                    End If
                Else
                    btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                    lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                End If
            ElseIf Request.Params("TipoOperacion") = "1" Then

            End If
            'Dim txtbxFchIngCOBAEV As TextBox = CType(Me.dvAntiguedad.FindControl("txtbxFchIngCOBAEV"), TextBox)
            'Dim hfFchIngCOBAEV As HiddenField = CType(Me.dvAntiguedad.FindControl("hfFchIngCOBAEV"), HiddenField)
            'Dim ibFecNac As ImageButton = CType(Me.dvAntiguedad.FindControl("ibFecNac"), ImageButton)
            'ibFecNac.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + txtbxFchIngCOBAEV.ClientID + "','" + hfFchIngCOBAEV.ClientID + "'); return false")
        End If
    End Sub

    Protected Sub dvAntiguedad_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvAntiguedad.DataBound
        Dim RVFchINgCOBAEV As RangeValidator = CType(Me.dvAntiguedad.Rows(0).FindControl("RVFchIngCOBAEV"), RangeValidator)
        RVFchINgCOBAEV.MaximumValue = Date.Today.AddDays(15).ToShortDateString
        RVFchINgCOBAEV.ErrorMessage += " [" + RVFchINgCOBAEV.MinimumValue + "-" + RVFchINgCOBAEV.MaximumValue + "]"
    End Sub

    Protected Sub btnGurdar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtbxFchIngCOBAEV As TextBox = CType(Me.dvAntiguedad.FindControl("txtbxFchIngCOBAEV"), TextBox)
            Dim txtbxQnaIngCOBAEV As TextBox = CType(Me.dvAntiguedad.FindControl("txtbxQnaIngCOBAEV"), TextBox)
            Dim txtbxAnios As TextBox = CType(Me.dvAntiguedad.FindControl("txtbxAnios"), TextBox)
            Dim txtbxMeses As TextBox = CType(Me.dvAntiguedad.FindControl("txtbxMeses"), TextBox)
            Dim txtbxDias As TextBox = CType(Me.dvAntiguedad.FindControl("txtbxDias"), TextBox)
            Dim txtbxQuincenaCalculo As TextBox = CType(Me.dvAntiguedad.FindControl("txtbxQuincenaCalculo"), TextBox)
            Dim chkbxCobraPrimaAnt As CheckBox = CType(Me.dvAntiguedad.FindControl("chkbxCobraPrimaAnt"), CheckBox)
            Dim oEmpleado As New Empleado
            With oEmpleado
                .IdEmp = CType(Request.Params("IdEmp"), Integer)
                .FchIngCOBAEV = CType(txtbxFchIngCOBAEV.Text, Date)
                .QnaIngCOBAEV = CType(txtbxQnaIngCOBAEV.Text, Integer)
                .AniosAnt = CType(txtbxAnios.Text, Byte)
                .MesesAnt = CType(txtbxMeses.Text, Byte)
                .DiasAnt = CType(txtbxDias.Text, Byte)
                .QuincenaCalculo = CType(txtbxQuincenaCalculo.Text, Integer)
                .CobraPrimaAnt = chkbxCobraPrimaAnt.Checked
                .ActualizarAntiguedad(CType(Session("ArregloAuditoria"), String()))
            End With
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        'Response.Redirect(Request.RawUrl)
        MultiView1.SetActiveView(viewAntiguedad)
        BindDatos()
    End Sub

    Protected Sub lbReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles lbReintentarCaptura.Click
        MultiView1.SetActiveView(viewAntiguedad)
    End Sub
End Class
