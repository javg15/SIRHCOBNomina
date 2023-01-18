Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.MovsDePersonal
Partial Class WebControls_wucAnioQnas
    Inherits System.Web.UI.UserControl
    Private Sub BindAnios()
        Dim oAnio As New Anios
        With Me.ddlAños
            .DataSource = oAnio.ObtenConQnasOrdPagadas()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                Me.ddlAños.Items.Clear()
                Me.ddlAños.Items.Add(New ListItem("No existe información de pago", "-1"))
            End If
        End With
    End Sub
    Private Sub BindQnas()
        Dim oAnio As New Anios

        With Me.ddlQnasPagadas
            If ddlAños.SelectedValue <> "-1" Then
                .DataSource = oAnio.ObtenQnasOrdinariasPagadas(CShort(ddlAños.SelectedValue))
                .DataTextField = "Quincena"
                .DataValueField = "IdQuincena"
                .DataBind()
                If .Items.Count = 0 Then
                    .Items.Clear()
                    .Items.Add(New ListItem("Información no disponible", "-1"))
                End If
            Else
                .Items.Clear()
                .Items.Add(New ListItem("Información no disponible", "-1"))
            End If
        End With
    End Sub
    Protected Sub ddlAños_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        BindQnas()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            BindAnios()
            BindQnas()
        End If
    End Sub

End Class
