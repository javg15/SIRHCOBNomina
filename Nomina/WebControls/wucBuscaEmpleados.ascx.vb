Partial Class WebControls_wucBuscaEmpleados
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        If Not Session("RFCParaCons") Is Nothing Then
            If Session("NoLlenar") Is Nothing And Session("NoLimpiar") Is Nothing Then
                Me.txtbxRFC.Text = Session("RFCParaCons")
                'Me.txtbxNumEmp.Text = Session("NumEmpParaCons")
                Me.txtbxNomEmp.Text = Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons")
                Me.hfRFC.Value = Session("RFCParaCons")
                'Me.hfNumEmp.Value = Session("NumEmpParaCons")
                Me.hfNomEmp.Value = Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons")
            Else
                Session.Remove("NoLlenar")
                Session.Remove("NoLimpiar")
            End If
        Else
            If Session("NoLimpiar") Is Nothing Then
                Me.txtbxRFC.Text = String.Empty
                'Me.txtbxNumEmp.Text = String.Empty
                Me.txtbxNomEmp.Text = String.Empty
                Me.hfRFC.Value = String.Empty
                Me.hfNomEmp.Value = String.Empty
                'Me.hfNumEmp.Value = String.Empty
            Else
                Session.Remove("NoLlenar")
                Session.Remove("NoLimpiar")
            End If
        End If
        'End If
    End Sub
End Class
