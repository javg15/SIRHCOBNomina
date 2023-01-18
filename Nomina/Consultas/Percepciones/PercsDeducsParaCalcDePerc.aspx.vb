Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class PercsDeducsParaCalcDePerc
    Inherits System.Web.UI.Page
    Private Sub BindGW()
        Dim oPerc As New Percepcion
        Dim ds As DataSet

        If ddlConcepto.SelectedValue <> "-1" Then
            lblMsjPrincipal.Text = "Percepciones y Deducciones que participan en el cálculo de la percepción <br />" + ddlConcepto.SelectedItem.Text + "<br />"
        Else
            lblMsjPrincipal.Text = "Opción no disponible."
        End If
        hfidConcepto.Value = ddlConcepto.SelectedValue

        ds = oPerc.ObtenPercsDeducsParaSuCalculo(CShort(ddlConcepto.SelectedValue))

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
        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "PercepcionesParaCalculoDePercepcion")

        gvPercsSi.Columns(4).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
        gvPercsNo.Columns(4).Visible = CBool(dt.Rows(0).Item("Insercion"))

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "DeduccionesParaCalculoDePercepcion")

        gvDeducsSi.Columns(4).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
        gvDeducsNo.Columns(4).Visible = CBool(dt.Rows(0).Item("Insercion"))
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oPerc As New Percepcion

            With ddlConcepto
                .DataSource = oPerc.ObtenActivasDerivadaDePercsDeducs()
                .DataValueField = "IdPercepcion"
                .DataTextField = "DescPercParaDDL"
                .DataBind()
                If .Items.Count = 0 Then
                    .Items.Insert(0, "No hay percepciones disponibles para la operación solicitada.")
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

        oPerc.DelParaCalculoDePercepcion(CShort(hfidConcepto.Value), CShort(lblIdPercepcion.Text), CType(Session("ArregloAuditoria"), String()))
        BindGW()
    End Sub

    Protected Sub ibAddPerc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblIdPercepcion As Label = CType(gvr.FindControl("lblIdPercepcion"), Label)
        Dim oPerc As New Percepcion

        oPerc.AddParaCalculoDePercepcion(CShort(hfidConcepto.Value), CShort(lblIdPercepcion.Text), CType(Session("ArregloAuditoria"), String()))
        BindGW()
    End Sub

    Protected Sub ibQuitarDeduc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblIdDeduccion As Label = CType(gvr.FindControl("lblIdDeduccion"), Label)
        Dim oDeduc As New Deduccion

        oDeduc.DelParaCalculoDePercepcion(CShort(lblIdDeduccion.Text), CShort(hfidConcepto.Value), CType(Session("ArregloAuditoria"), String()))
        BindGW()
    End Sub

    Protected Sub ibAddDeduc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblIdDeduccion As Label = CType(gvr.FindControl("lblIdDeduccion"), Label)
        Dim oDeduc As New Deduccion

        oDeduc.AddParaCalculoDePercepcion(CShort(lblIdDeduccion.Text), CShort(hfidConcepto.Value), CType(Session("ArregloAuditoria"), String()))
        BindGW()
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click
        BindGW()
    End Sub
End Class
