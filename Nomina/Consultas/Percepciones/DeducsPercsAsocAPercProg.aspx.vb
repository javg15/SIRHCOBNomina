Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Partial Class Consultas_Percepciones_DeducsPercsAsocAPercProg
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Dim oPerc As New Percepcion
            oPerc.IdPercepcion = CShort(Request.Params("IdPercepcion"))
            Me.gvPercepciones.DataSource = oPerc.ObtenPercsAsocAPercProg()
            Me.gvPercepciones.DataBind()
            Me.gvDeducciones.DataSource = oPerc.ObtenDeducsAsocAPercProg()
            Me.gvDeducciones.DataBind()
            Me.lbCerrar.OnClientClick = "javascript:window.close();"
        End If
    End Sub
End Class
