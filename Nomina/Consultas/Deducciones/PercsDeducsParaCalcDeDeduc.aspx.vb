Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class PercsDeducsParaCalcDeDeduc
    Inherits System.Web.UI.Page
    Private Sub BindGW()
        Dim oDeduc As New Deduccion
        Dim ds As DataSet

        If ddlConcepto.SelectedValue <> "-1" Then
            lblMsjPrincipal.Text = "Percepciones y Deducciones que participan en el cálculo de la deducción <br />" + ddlConcepto.SelectedItem.Text + "<br />"
        Else
            lblMsjPrincipal.Text = "Opción no disponible."
        End If
        hfIdConcepto.Value = ddlConcepto.SelectedValue

        ds = oDeduc.ObtenPercsDeducsParaSuCalculo(CShort(ddlConcepto.SelectedValue))

        With gvPercsSi
            If ddlConcepto.SelectedValue <> "-1" Then .DataSource = ds.Tables(0)
            .DataBind()
        End With

        With gvPercsNo
            If ddlConcepto.SelectedValue <> "-1" Then .DataSource = ds.Tables(1)
            .DataBind()
        End With

        With gvDeducsSi
            If ddlConcepto.SelectedValue <> "-1" Then .DataSource = ds.Tables(2)
            .DataBind()
        End With

        With gvDeducsNo
            If ddlConcepto.SelectedValue <> "-1" Then .DataSource = ds.Tables(3)
            .DataBind()
        End With

        Dim oUsr As New Usuario
        Dim dt As DataTable
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "PercepcionesParaCalculoDeDeduccion")

        gvPercsSi.Columns(4).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
        gvPercsNo.Columns(4).Visible = CBool(dt.Rows(0).Item("Insercion"))

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "DeduccionesParaCalculoDeDeduccion")

        gvDeducsSi.Columns(4).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
        gvDeducsNo.Columns(4).Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oDeduc As New Deduccion

            With ddlConcepto
                .DataSource = oDeduc.ObtenActivasDerivadaDePercsDeducs()
                .DataValueField = "IdDeduccion"
                .DataTextField = "DescDeducParaDDL"
                .DataBind()
                If .Items.Count = 0 Then
                    .Items.Insert(0, "No hay deducciones disponibles para la operación solicitada.")
                    .Items(0).Value = "-1"
                End If
            End With
            BindGW()
        End If
    End Sub
    Protected Sub gvPercsSi_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercsSi.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvPercsSi_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPercsSi.SelectedIndexChanged

    End Sub

    Protected Sub gvPercsNo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPercsNo.SelectedIndexChanged

    End Sub

    Protected Sub gvPercsNo_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPercsNo.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvDeducsSi_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvDeducsSi.SelectedIndexChanged

    End Sub

    Protected Sub gvDeducsSi_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDeducsSi.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvDeducsNo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvDeducsNo.SelectedIndexChanged

    End Sub

    Protected Sub gvDeducsNo_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDeducsNo.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub ibQuitarPerc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblIdPercepcion As Label = CType(gvr.FindControl("lblIdPercepcion"), Label)
        Dim oPerc As New Percepcion

        oPerc.DelParaCalculoDeDeduccion(CShort(lblIdPercepcion.Text), CShort(hfIdConcepto.Value), CType(Session("ArregloAuditoria"), String()))
        BindGW()
    End Sub

    Protected Sub ibAddPerc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblIdPercepcion As Label = CType(gvr.FindControl("lblIdPercepcion"), Label)
        Dim oPerc As New Percepcion

        oPerc.AddParaCalculoDeDeduccion(CShort(lblIdPercepcion.Text), CShort(hfIdConcepto.Value), CType(Session("ArregloAuditoria"), String()))
        BindGW()
    End Sub

    Protected Sub ibQuitarDeduc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblIdDeduccion As Label = CType(gvr.FindControl("lblIdDeduccion"), Label)
        Dim oDeduc As New Deduccion

        oDeduc.DelParaCalculoDeDeduccion(CShort(hfIdConcepto.Value), CShort(lblIdDeduccion.Text), CType(Session("ArregloAuditoria"), String()))
        BindGW()
    End Sub

    Protected Sub ibAddDeduc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblIdDeduccion As Label = CType(gvr.FindControl("lblIdDeduccion"), Label)
        Dim oDeduc As New Deduccion

        oDeduc.AddParaCalculoDeDeduccion(CShort(hfIdConcepto.Value), CShort(lblIdDeduccion.Text), CType(Session("ArregloAuditoria"), String()))
        BindGW()
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click
        BindGW()
    End Sub

    Private Sub ddlConcepto_Load(sender As Object, e As EventArgs) Handles ddlConcepto.Load

    End Sub
End Class
