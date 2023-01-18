Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports System.IO
Imports DataAccessLayer.COBAEV.Administracion

Partial Class AdmonExpedienteDigital
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
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
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

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
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
                pnl1.Visible = True
            Else
                Me.lblEmpInf.Text = String.Empty
                pnl1.Visible = False
            End If
            Me.gvDocumentos.DataBind()
        Else
            pnl1.Visible = False
        End If
    End Sub
    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim oUsr As New Usuario
        Dim dt As DataTable

        If Not IsPostBack Then
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsDocs")

            If CBool(dt.Rows(0).Item("Consulta")) = False Then Response.Redirect("~/SinPermiso.aspx?Home=SI")
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Not IsPostBack Then
            BindDatos()
        End If
    End Sub
    Protected Sub gvDocumentos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim lbVerDoc As LinkButton = CType(e.Row.FindControl("lbVerDoc"), LinkButton)
        Dim lbCrearExpediente As LinkButton = CType(e.Row.FindControl("lbCrearExpediente"), LinkButton)
        Dim lblNomArch As Label = CType(e.Row.FindControl("lblNomArch"), Label)
        Dim lblCveDoc As Label = CType(e.Row.FindControl("lblCveDoc"), Label)
        Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
        Dim ibVerDoc As ImageButton = CType(e.Row.FindControl("ibVerDoc"), ImageButton)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                'lbVerDoc.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                '   + "?URLImagen=" + ConfigurationManager.AppSettings("ServerExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text _
                '       + "&IdReporte=23','Documento_" + lblNomArch.Text + "'); return false;"

                'ibVerDoc.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                '    + "?URLImagen=" + ConfigurationManager.AppSettings("ServerExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text _
                '    + "&IdReporte=23','Documento_" + lblNomArch.Text + "'); return false;"

                If (System.IO.File.Exists(ConfigurationManager.AppSettings("RutaExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text)) = True Then
                    ibVerDoc.OnClientClick = "javascript:abreVentanaImpresion('" + ConfigurationManager.AppSettings("ServerExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text + "','Documento_" + lblNomArch.Text + "'); return false;"
                Else
                    ibVerDoc.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                        + "?URLImagen=" + ConfigurationManager.AppSettings("ServerExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text _
                        + "&IdReporte=23','Documento_" + lblNomArch.Text + "'); return false;"
                End If

                ibEliminar.CommandArgument = lblCveDoc.Text
            Case DataControlRowType.EmptyDataRow
                lbCrearExpediente.Visible = Not Directory.Exists(ConfigurationManager.AppSettings("RutaExpedientes") + Session("NumEmpParaCons"))
        End Select
    End Sub
    Protected Sub lbCrearExpediente_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Directory.CreateDirectory(ConfigurationManager.AppSettings("RutaExpedientes") + Session("NumEmpParaCons"))
        BindDatos()
    End Sub
    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        'If Request.Params(1).Contains("ibBuscarEmp") Then BindDatos()
        If IsPostBack Then
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    BindDatos()
                    pnl1.Visible = True
                Else
                    pnl1.Visible = False
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                Me.pnl1.Visible = False
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                Me.pnl1.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    BindDatos()
                    pnl1.Visible = True
                End If
            End If
        End If
    End Sub
    Protected Sub ibEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim dr As DataRow
        Dim oDoc As New Expediente
        Dim Indice As Short
        Dim HayDocs As Boolean = False
        Dim ibEliminar As ImageButton = CType(sender, ImageButton)
        Dim TargetPath As String = ConfigurationManager.AppSettings("RutaExpedientes") + Session("NumEmpParaCons") + "\"
        File.Delete(TargetPath + Session("NumEmpParaCons") + ibEliminar.CommandArgument + ".jpg")

        dr = oDoc.ObtenInfSobreDocumento2(ibEliminar.CommandArgument)

        For Indice = CShort(dr("CveDoctRangoIni")) To CShort(dr("CveDocRangoFin"))
            If File.Exists(TargetPath + Session("NumEmpParaCons") + Indice.ToString.PadLeft(4, "0") + ".jpg") Then
                HayDocs = True
                Exit For
            End If
        Next

        If Not HayDocs Then
            oDoc.EliminaEmpsDocs(Session("NumEmpParaCons"), ibEliminar.CommandArgument, CType(Session("ArregloAuditoria"), String()))
        End If

        BindDatos()
    End Sub
End Class
