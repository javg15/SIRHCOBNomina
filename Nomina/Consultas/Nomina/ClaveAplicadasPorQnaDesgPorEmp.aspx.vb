Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Imports System.IO.Stream
Imports System.IO.StreamWriter
 
Partial Class ClaveAplicadasPorQnaDesgPorEmp
    Inherits System.Web.UI.Page
    Private Sub BindddlAños()
        Dim oQna As New Quincenas
        With Me.ddlAños
            .DataSource = oQna.ObtenAños(True)
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
                Me.btnConsultarQuincenas.Enabled = False
            Else
                Me.btnConsultarQuincenas.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindQuincenas()
        Dim oQna As New Quincenas
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue))
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0
        End If
    End Sub
    Private Sub BindDeducciones()
        Dim oUsr As New Usuario
        Dim dr2 As DataRow
        Dim oDeduccion As New Deduccion
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        oUsr.Login = Session("Login")
        dr2 = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        LlenaDDL(Me.ddlClaves, "Deduccion", "IdDeduccion", oDeduccion.ObtenAplicadasPorQuincena(CByte(dr2("IdRol")), CShort(lblIdQuincena.Text)), Nothing)
        With Me.ddlClaves
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existen deducciones aplicadas en la quincena seleccionada")
                .Items(0).Value = -1
                Me.ibImprimir.Enabled = False
                Me.ibImprimirExcel.Enabled = False
            Else
                Me.ibImprimir.Enabled = True
                Me.ibImprimirExcel.Enabled = True
            End If
        End With
        Me.pnlClaves.GroupingText = "Seleccione deducción"
    End Sub
    Private Sub BindPercepciones()
        Dim oUsr As New Usuario
        Dim dr2 As DataRow
        Dim oPercepcion As New Percepcion
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        oUsr.Login = Session("Login")
        dr2 = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        LlenaDDL(Me.ddlClaves, "Percepcion", "IdPercepcion", oPercepcion.ObtenAplicadasPorQuincena(CByte(dr2("IdRol")), CShort(lblIdQuincena.Text)), Nothing)
        With Me.ddlClaves
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existen percepciones aplicadas en la quincena seleccionada")
                .Items(0).Value = -1
                Me.ibImprimir.Enabled = False
                Me.ibImprimirExcel.Enabled = False
            Else
                Me.ibImprimir.Enabled = True
                Me.ibImprimirExcel.Enabled = True
            End If
        End With
        Me.pnlClaves.GroupingText = "Seleccione percepción"
    End Sub
    Private Sub CreaLinkParaImpresion()
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Dim oUsr As New Usuario
        Dim dr2, drUsr As DataRow
        oUsr.Login = Session("Login")
        drUsr = oUsr.ObtenerPorLogin()
        dr2 = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        Select Case Me.ddlReportes.SelectedValue
            Case "17"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                        + "?IdDeduccion=" + Me.ddlClaves.SelectedValue _
                        + "&IdQuincena=" + lblIdQuincena.Text _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','DescuentoDeduccion_" + Me.ddlClaves.SelectedValue + "_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimirExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                        + "?IdDeduccion=" + Me.ddlClaves.SelectedValue _
                        + "&IdQuincena=" + lblIdQuincena.Text _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','DescuentoDeduccion_" + Me.ddlClaves.SelectedValue + "_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimir.Enabled = Me.ddlTipoClave.SelectedValue = "D"
                Me.ibImprimirExcel.Enabled = Me.ddlTipoClave.SelectedValue = "D"
            Case "18"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                        + "?IdPercDeduc=" + Me.ddlClaves.SelectedValue _
                        + "&IdQuincena=" + lblIdQuincena.Text _
                        + "&PercDeduc=" + Me.ddlTipoClave.SelectedValue _
                        + "&IdRol=" + dr2("IdRol").ToString _
                        + "&ConsultaZonasEsp=" + dr2("ConsultaZonasEspecificas").ToString _
                        + "&ConsPlantelesEsp=" + dr2("ConsultaPlantelesEspecificos").ToString _
                        + "&IdUsuario=" + drUsr("IdUsuario").ToString _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','" + Me.ddlTipoClave.SelectedValue + "_" + Me.ddlClaves.SelectedValue + "_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimirExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                        + "?IdPercDeduc=" + Me.ddlClaves.SelectedValue _
                        + "&IdQuincena=" + lblIdQuincena.Text _
                        + "&PercDeduc=" + Me.ddlTipoClave.SelectedValue _
                        + "&IdRol=" + dr2("IdRol").ToString _
                        + "&ConsultaZonasEsp=" + dr2("ConsultaZonasEspecificas").ToString _
                        + "&ConsPlantelesEsp=" + dr2("ConsultaPlantelesEspecificos").ToString _
                        + "&IdUsuario=" + drUsr("IdUsuario").ToString _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','" + Me.ddlTipoClave.SelectedValue + "_" + Me.ddlClaves.SelectedValue + "_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimir.Enabled = True
                Me.ibImprimirExcel.Enabled = True
            Case "38"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                        + "?TipoConcepto=P" _
                        + "&ImpresionGeneral=False" _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','CatalogoPercepcionesVigentes'); return false;"
                Me.ibImprimirExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                        + "?TipoConcepto=P" _
                        + "&ImpresionGeneral=False" _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','CatalogoPercepcionesVigentes'); return false;"
            Case "39"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                        + "?TipoConcepto=D" _
                        + "&ImpresionGeneral=False" _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','CatalogoDeduccionesVigentes'); return false;"
                Me.ibImprimirExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                        + "?TipoConcepto=D" _
                        + "&ImpresionGeneral=False" _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','CatalogoDeduccionesVigentes'); return false;"
            Case "165"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                        + "?IdPercDeduc=" + Me.ddlClaves.SelectedValue _
                        + "&IdQuincena=" + lblIdQuincena.Text _
                        + "&PercDeduc=" + Me.ddlTipoClave.SelectedValue _
                        + "&IdRol=" + dr2("IdRol").ToString _
                        + "&ConsultaZonasEsp=" + dr2("ConsultaZonasEspecificas").ToString _
                        + "&ConsPlantelesEsp=" + dr2("ConsultaPlantelesEspecificos").ToString _
                        + "&IdUsuario=" + drUsr("IdUsuario").ToString _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','" + Me.ddlTipoClave.SelectedValue + "_" + Me.ddlClaves.SelectedValue + "_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimirExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                        + "?IdPercDeduc=" + Me.ddlClaves.SelectedValue _
                        + "&IdQuincena=" + lblIdQuincena.Text _
                        + "&PercDeduc=" + Me.ddlTipoClave.SelectedValue _
                        + "&IdRol=" + dr2("IdRol").ToString _
                        + "&ConsultaZonasEsp=" + dr2("ConsultaZonasEspecificas").ToString _
                        + "&ConsPlantelesEsp=" + dr2("ConsultaPlantelesEspecificos").ToString _
                        + "&IdUsuario=" + drUsr("IdUsuario").ToString _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','" + Me.ddlTipoClave.SelectedValue + "_" + Me.ddlClaves.SelectedValue + "_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimir.Enabled = True
                Me.ibImprimirExcel.Enabled = True
        End Select
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Protected Sub gvQuincenas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuincenas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim oPlantel As New Plantel
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindQuincenas()
                If Me.ddlTipoClave.SelectedValue = "D" Then
                    BindDeducciones()
                Else
                    BindPercepciones()
                End If
                CreaLinkParaImpresion()
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        BindQuincenas()
        CreaLinkParaImpresion()
    End Sub
    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.ddlTipoClave.SelectedValue = "D" Then
            BindDeducciones()
        Else
            BindPercepciones()
        End If
        CreaLinkParaImpresion()
    End Sub
    Protected Sub ddlReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.ddlTipoClave.SelectedValue = "D" Then
            BindDeducciones()
        Else
            BindPercepciones()
        End If
        CreaLinkParaImpresion()
    End Sub

    Protected Sub ddlTipoClave_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoClave.SelectedIndexChanged
        If Me.ddlTipoClave.SelectedValue = "D" Then
            BindDeducciones()
        Else
            BindPercepciones()
        End If
        CreaLinkParaImpresion()
    End Sub

    Protected Sub ddlClaves_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CreaLinkParaImpresion()
    End Sub
End Class