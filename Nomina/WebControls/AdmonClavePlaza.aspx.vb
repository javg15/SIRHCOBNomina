Imports DataAccessLayer.COBAEV.Plazas
Partial Class AdmonClavePlaza
    Inherits System.Web.UI.Page

    Protected Sub btnConsultaPlaza_Click(sender As Object, e As System.EventArgs) Handles btnConsultaPlaza.Click
        Dim oSMP_Plaza As New SMP_Plazas

        dvConsultaPlaza.DataSource = oSMP_Plaza.ObtenPlazaDetalles(txtbxZE.Text, txtbxCveCatego.Text, txtbxHrs.Text, txtbxConsPlaza.Text)
        dvConsultaPlaza.DataBind()

    End Sub
End Class
