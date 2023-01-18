Imports DataAccessLayer.COBAEV.Nominas
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Imports System.Data
Partial Class Administracion_Percepciones_AdmonPercRetro
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oPerc As New Percepcion
        Dim oQna As New Quincenas
        Dim dt As DataTable
        Dim oNomina As New Nomina
        Dim txtbxPorcInc As TextBox = Nothing
        Dim chbxRetroPorDif As CheckBox = Nothing
        Dim txtbxImpDif As TextBox = Nothing

        With oPerc
            .IdPercepcion = CShort(Request.Params("IdPercRetro"))
            dt = oPerc.ObtenRetroactiva(CShort(Request.Params("IdPercRetro")))
            Me.dvPercepcion.DataSource = dt
            Me.dvPercepcion.DataBind()

            txtbxPorcInc = CType(Me.dvPercepcion.FindControl("txtbxPorcInc"), TextBox)
            chbxRetroPorDif = CType(Me.dvPercepcion.FindControl("chbxRetroPorDif"), CheckBox)
            txtbxImpDif = CType(Me.dvPercepcion.FindControl("txtbxImpDif"), TextBox)

            If chbxRetroPorDif.Checked Then
                txtbxPorcInc.Enabled = False
                txtbxImpDif.Enabled = True
            Else
                txtbxPorcInc.Enabled = True
                txtbxImpDif.Enabled = False
            End If
        End With
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            If Request.Params("TipoOperacion") = "0" Then
                Me.dvPercepcion.ChangeMode(DetailsViewMode.Edit)
            End If
            Me.MultiView1.SetActiveView(Me.viewCaptura)
            BindDatos()
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
            Dim IdPercRetro As Short = CShort(Request.Params("IdPercRetro"))
            Dim PorcInc As Decimal = CDec(CType(Me.dvPercepcion.FindControl("txtbxPorcInc"), TextBox).Text)
            Dim IncluirEnPago As Boolean = CType(Me.dvPercepcion.FindControl("chbxIncluirEnPago"), CheckBox).Checked
            Dim RetroPorDiferencia As Boolean = CType(Me.dvPercepcion.FindControl("chbxRetroPorDif"), CheckBox).Checked
            Dim ImporteDiferencia As Decimal = CDec(CType(Me.dvPercepcion.FindControl("txtbxImpDif"), TextBox).Text)
            With oPerc
                If Request.Params("TipoOperacion") = "0" Then
                    .UpdPercRetro(IdPercRetro, PorcInc, IncluirEnPago, CType(Session("ArregloAuditoria"), String()), RetroPorDiferencia, ImporteDiferencia)
                    Me.lblCapturaExitosa.Text = "Actualización realizada correctamente."
                    Me.MultiView1.SetActiveView(Me.viewCapturaExitosa)
                End If
            End With
        Catch ex As Exception
            Me.MultiView1.SetActiveView(Me.viewErrores)
            Me.lblErrores.Text = ex.Message
        End Try
    End Sub
    Protected Sub lbReintentar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentar.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub

    Protected Sub chbxRetroPorDif_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim txtbxPorcInc As TextBox = CType(Me.dvPercepcion.FindControl("txtbxPorcInc"), TextBox)
        Dim chbxRetroPorDif As CheckBox = CType(Me.dvPercepcion.FindControl("chbxRetroPorDif"), CheckBox)
        Dim txtbxImpDif As TextBox = CType(Me.dvPercepcion.FindControl("txtbxImpDif"), TextBox)

        If chbxRetroPorDif.Checked Then
            txtbxPorcInc.Enabled = False
            txtbxImpDif.Enabled = True
        Else
            txtbxPorcInc.Enabled = True
            txtbxImpDif.Enabled = False
        End If
    End Sub
End Class
