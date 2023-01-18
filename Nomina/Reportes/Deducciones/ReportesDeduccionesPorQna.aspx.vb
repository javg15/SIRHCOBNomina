Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Imports System.IO.Stream
Imports System.IO.StreamWriter
 
Partial Class ReportesDeduccionesPorQna
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
        LlenaDDL(Me.ddlDeducciones, "Deduccion", "IdDeduccion", oDeduccion.ObtenAplicadasPorQuincena(CByte(dr2("IdRol")), CShort(lblIdQuincena.Text)), Nothing)
        With Me.ddlDeducciones
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
    End Sub
    Private Sub CreaLinkParaImpresion()
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblQuincena"), Label)
        Select Case Me.ddlReportes.SelectedValue
            Case "17"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                        + "?IdDeduccion=" + Me.ddlDeducciones.SelectedValue _
                        + "&IdQuincena=" + lblIdQuincena.Text _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','DescuentoDeduccion_" + Me.ddlDeducciones.SelectedValue + "_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimirExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                        + "?IdDeduccion=" + Me.ddlDeducciones.SelectedValue _
                        + "&IdQuincena=" + lblIdQuincena.Text _
                        + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','DescuentoDeduccion_" + Me.ddlDeducciones.SelectedValue + "_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
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
                BindDeducciones()
                CreaLinkParaImpresion()
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        BindQuincenas()
        CreaLinkParaImpresion()
    End Sub
    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindDeducciones()
        CreaLinkParaImpresion()
    End Sub
    Protected Sub ddlReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CreaLinkParaImpresion()
    End Sub

    Protected Sub ddlDeducciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDeducciones.SelectedIndexChanged
        CreaLinkParaImpresion()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class