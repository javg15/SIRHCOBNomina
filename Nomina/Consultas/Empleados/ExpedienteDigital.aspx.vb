Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV
Partial Class Consultas_Empleados_ExpedienteDigital
    Inherits System.Web.UI.Page
    Public Function setDataSetExpedientes() As DataSet
        Try
            Dim dsExpedientes As New DataSet
            Dim dtDocumentos As DataTable = New DataTable("Documentos")

            Dim PrimaryKeys(1) As DataColumn

            Dim dcCveDoc As DataColumn
            Dim dcDescDoc As DataColumn
            Dim dcNumPag As DataColumn
            Dim dcNomArchivo As DataColumn

            dcCveDoc = New DataColumn
            dcCveDoc.DataType = System.Type.GetType("System.String")
            dcCveDoc.ColumnName = "CveDoc"
            dcCveDoc.Caption = "Clave del documento"

            dcDescDoc = New DataColumn
            dcDescDoc.DataType = System.Type.GetType("System.String")
            dcDescDoc.ColumnName = "DescDoc"
            dcDescDoc.Caption = "Descripción del documento"

            dcNumPag = New DataColumn
            dcNumPag.DataType = System.Type.GetType("System.Byte")
            dcNumPag.ColumnName = "NumPag"
            dcNumPag.Caption = "Número de página"

            dcNomArchivo = New DataColumn
            dcNomArchivo.DataType = System.Type.GetType("System.String")
            dcNomArchivo.ColumnName = "NomArchivo"
            dcNomArchivo.Caption = "Nombre del archivo"

            PrimaryKeys(0) = dcCveDoc

            dtDocumentos.Columns.Add(dcCveDoc)
            dtDocumentos.Columns.Add(dcDescDoc)
            dtDocumentos.Columns.Add(dcNumPag)
            dtDocumentos.Columns.Add(dcNomArchivo)

            dtDocumentos.PrimaryKey = PrimaryKeys

            dsExpedientes.Tables.Add(dtDocumentos)

            Return dsExpedientes
        Catch ex As Exception
            Throw New System.Exception("Error:" & ex.Message.ToString)
        End Try
    End Function

    Private Sub CargaExpediente()
        Dim Files As String(), File As String
        Dim ds As DataSet
        Dim dr As DataRow
        Dim oExp As New Expediente

        ds = setDataSetExpedientes()
        Try
            Files = IO.Directory.GetFiles(ConfigurationManager.AppSettings("RutaExpedientes") + Session("NumEmpParaCons"), "*.jpg")

            For Each File In Files
                dr = oExp.ObtenInfSobreDocumento(IO.Path.GetFileNameWithoutExtension(File).Substring(5, 4))

                If Not dr Is Nothing Then
                    Dim drDocumento As DataRow
                    drDocumento = ds.Tables(0).NewRow
                    drDocumento(0) = dr("CveDoc")
                    drDocumento(1) = dr("DescDoc")
                    drDocumento(2) = dr("NumPag")
                    drDocumento(3) = IO.Path.GetFileNameWithoutExtension(File)
                    ds.Tables(0).Rows.Add(drDocumento)
                End If
            Next
        Catch
        End Try
        Files = Nothing
        Try
            Files = IO.Directory.GetFiles(ConfigurationManager.AppSettings("RutaExpedientes") + Session("NumEmpParaCons"), "*.pdf")

            For Each File In Files
                dr = oExp.ObtenInfSobreDocumento(IO.Path.GetFileNameWithoutExtension(File).Substring(5, 4))

                If Not dr Is Nothing Then
                    Dim drDocumento As DataRow
                    drDocumento = ds.Tables(0).NewRow
                    drDocumento(0) = dr("CveDoc")
                    drDocumento(1) = dr("DescDoc")
                    drDocumento(2) = dr("NumPag")
                    drDocumento(3) = IO.Path.GetFileName(File) '.GetFileNameWithoutExtension(File)
                    ds.Tables(0).Rows.Add(drDocumento)
                End If
            Next
        Catch
        End Try
        Me.gvDocumentos.DataSource = ds.Tables(0)
        Me.gvDocumentos.DataBind()
        gvDocumentos.Visible = True
    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado

        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        If oEmp.RFC <> String.Empty Then
            'Me.gvDocumentos.DataSource = oEmp.ObtenPlazasVigentes()
            CargaExpediente()
            BindgvHistoriaCentrosDeAdscripcPoEmp(oEmp.RFC)
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            Else
                Me.lblEmpInf.Text = String.Empty
            End If
            'Me.gvDocumentos.DataBind()
        End If
    End Sub
    Private Sub BindgvHistoriaCentrosDeAdscripcPoEmp(ByVal pRFCEmp As String)
        Dim oAdcripcion As New CentroDeTrabajo

        gvHistoriaCentrosDeAdscripcPoEmp.DataSource = oAdcripcion.ObtenHistoriaCentrosDeAdscrip(pRFCEmp)
        gvHistoriaCentrosDeAdscripcPoEmp.DataBind()

    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
    '        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
    '        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
    '        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
    '        Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
    '        ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
    '    End If
    'End Sub

    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub

    Protected Sub WucBuscaEmpleados1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.Load
        BindDatos()
    End Sub

    Protected Sub gvDocumentos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim lbVerDoc As LinkButton = CType(e.Row.FindControl("lbVerDoc"), LinkButton)
        Dim lblNomArch As Label = CType(e.Row.FindControl("lblNomArch"), Label)

        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                If (System.IO.File.Exists(ConfigurationManager.AppSettings("RutaExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text)) = True Then
                    lbVerDoc.OnClientClick = "javascript:abreVentanaImpresion('" + ConfigurationManager.AppSettings("ServerExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text + "','Documento_" + lblNomArch.Text + "'); return false;"
                Else
                    lbVerDoc.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                      + "?URLImagen=" + ConfigurationManager.AppSettings("ServerExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text _
                          + "&IdReporte=23','Documento_" + lblNomArch.Text + "'); return false;"
                End If
                'lbVerDoc.OnClientClick = "javascript:alert('" + ConfigurationManager.AppSettings("ServerExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text + "');"
        End Select
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    BindDatos()
                    pnl1.Visible = True
                Else
                    pnl1.Visible = False
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                pnl1.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                pnl1.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindDatos()
                    pnl1.Visible = True
                End If
            End If
            End If
    End Sub
End Class
