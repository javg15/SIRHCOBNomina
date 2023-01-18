Partial Class WebControls_wucBuscaEmpleados2
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("RFCParaCons2") Is Nothing Then
            Me.txtbxRFC.Text = Session("RFCParaCons2")
            Me.txtbxNomEmp.Text = Session("ApePatParaCons2") + " " + Session("ApeMatParaCons2") + " " + Session("NombreParaCons2")
            Me.hfRFC.Value = Session("RFCParaCons2")
            Me.hfNomEmp.Value = Session("ApePatParaCons2") + " " + Session("ApeMatParaCons2") + " " + Session("NombreParaCons2")
        Else
            Me.txtbxRFC.Text = String.Empty
            Me.txtbxNomEmp.Text = String.Empty
            Me.hfRFC.Value = String.Empty
            Me.hfNomEmp.Value = String.Empty
        End If
    End Sub

    Protected Sub btnLimpiarValores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpiarValores.Click
        Session.Remove("RFCParaCons2")
        Session.Remove("ApePatParaCons2")
        Session.Remove("ApeMatParaCons2")
        Session.Remove("NombreParaCons2")
        Me.txtbxRFC.Text = String.Empty
        Me.txtbxNomEmp.Text = String.Empty
        Me.hfRFC.Value = String.Empty
        Me.hfNomEmp.Value = String.Empty
    End Sub
End Class
