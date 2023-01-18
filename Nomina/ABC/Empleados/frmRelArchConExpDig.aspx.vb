Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports System.IO
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Drawing.Imaging
Imports System.Drawing

Partial Class frmRelArchConExpDig
    Inherits System.Web.UI.Page
    Private Sub RenombraArchivos()
        Dim Files As String(), File As String
        Try
            Files = Directory.GetFiles(ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP"), "*.jpg")

            For Each File In Files
                CambiaCalidadDeArchivoJPG(File)
            Next
        Catch
        End Try

    End Sub
    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo

        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing

    End Function
    Private Sub CambiaCalidadDeArchivoJPG(TargetPath As String)
        Dim vlPath As String = ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP")
        Dim bmp1 As New Bitmap(TargetPath)

        Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)

        Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

        Dim myEncoderParameters As New EncoderParameters(1)

        Dim myEncoderParameter As New EncoderParameter(myEncoder, 50L)
        myEncoderParameters.Param(0) = myEncoderParameter
        bmp1.Save(vlPath + Path.GetFileNameWithoutExtension(TargetPath) + "TMP" + ".jpg", jgpEncoder, myEncoderParameters)
        bmp1.Dispose()
        File.Delete(TargetPath)
        File.Move(vlPath + Path.GetFileNameWithoutExtension(TargetPath) + "TMP" + ".jpg", TargetPath)
    End Sub
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

            'Dim PrimaryKeys(1) As DataColumn

            Dim dcCveDoc As DataColumn
            Dim dcDescDoc As DataColumn
            Dim dcNumPag As DataColumn
            Dim dcNomArchivo As DataColumn
            Dim dcNumEmp As DataColumn
            Dim dcNomEmp As DataColumn
            Dim dcIdDoc As DataColumn
            Dim dcIdEmp As DataColumn

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

            dcNumEmp = New DataColumn
            dcNumEmp.DataType = System.Type.GetType("System.String")
            dcNumEmp.ColumnName = "NumEmp"
            dcNumEmp.Caption = "Núm. Emp."

            dcNomEmp = New DataColumn
            dcNomEmp.DataType = System.Type.GetType("System.String")
            dcNomEmp.ColumnName = "NomEmp"
            dcNomEmp.Caption = "Nombre empleado"

            dcIdDoc = New DataColumn
            dcIdDoc.DataType = System.Type.GetType("System.Int32")
            dcIdDoc.ColumnName = "IdDoc"
            dcIdDoc.Caption = "Id Documento"

            dcIdEmp = New DataColumn
            dcIdEmp.DataType = System.Type.GetType("System.Int32")
            dcIdEmp.ColumnName = "IdEmp"
            dcIdEmp.Caption = "Id Emp"

            'PrimaryKeys(0) = dcCveDoc

            dtDocumentos.Columns.Add(dcCveDoc)
            dtDocumentos.Columns.Add(dcDescDoc)
            dtDocumentos.Columns.Add(dcNumPag)
            dtDocumentos.Columns.Add(dcNomArchivo)
            dtDocumentos.Columns.Add(dcNumEmp)
            dtDocumentos.Columns.Add(dcNomEmp)
            dtDocumentos.Columns.Add(dcIdDoc)
            dtDocumentos.Columns.Add(dcIdEmp)

            'dtDocumentos.PrimaryKey = PrimaryKeys

            dsExpedientes.Tables.Add(dtDocumentos)

            Return dsExpedientes
        Catch ex As Exception
            Throw New System.Exception("Error:" & ex.Message.ToString)
        End Try
    End Function
    Private Sub CargaArchivos()
        Dim Files As String(), File As String
        Dim ds As DataSet
        Dim dr As DataRow
        Dim drEmpleado As DataRow
        Dim oExp As New Expediente
        Dim oEmp As New Empleado
        Dim drDocumento As DataRow

        ds = setDataSetExpedientes()
        Try
            Files = Directory.GetFiles(ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP"), "*.jpg")

            For Each File In Files
                dr = Nothing
                drEmpleado = Nothing
                If Path.GetFileNameWithoutExtension(File).Length = 9 Then
                    dr = oExp.ObtenInfSobreDocumento(Path.GetFileNameWithoutExtension(File).Substring(5, 4))
                    drEmpleado = oEmp.BuscarPorNumEmp(Path.GetFileNameWithoutExtension(File).Substring(0, 5))
                End If


                If Not dr Is Nothing Then
                    drDocumento = ds.Tables(0).NewRow
                    drDocumento(0) = dr("CveDoc")
                    drDocumento(1) = dr("DescDoc")
                    drDocumento(2) = dr("NumPag")
                    drDocumento(3) = Path.GetFileNameWithoutExtension(File)
                    drDocumento(6) = CInt(dr("IdDocumento"))
                    If drEmpleado Is Nothing = False Then
                        drDocumento(4) = drEmpleado("NumEmp")
                        drDocumento(5) = Trim(drEmpleado("Nombre").ToString.Trim + " " + drEmpleado("ApellidoPaterno").ToString.Trim + " " + drEmpleado("ApellidoMaterno").ToString.Trim)
                        drDocumento(7) = drEmpleado("IdEmp")
                    Else
                        drDocumento(4) = Path.GetFileNameWithoutExtension(File).Substring(0, 5)
                        drDocumento(5) = "NÚMERO DE EMPLEADO INCORRECTO"
                        drDocumento(7) = 0
                    End If
                    ds.Tables(0).Rows.Add(drDocumento)
                Else
                    drDocumento = ds.Tables(0).NewRow
                    drDocumento(0) = String.Empty
                    drDocumento(1) = String.Empty
                    drDocumento(2) = 0
                    drDocumento(3) = Path.GetFileNameWithoutExtension(File)
                    drDocumento(6) = 0
                    drDocumento(4) = String.Empty
                    drDocumento(5) = String.Empty
                    drDocumento(7) = 0
                    ds.Tables(0).Rows.Add(drDocumento)
                End If
            Next
        Catch
        End Try
        Files = Nothing

        Try
            Files = Directory.GetFiles(ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP"), "*.pdf")

            For Each File In Files
                dr = Nothing
                drEmpleado = Nothing
                If Path.GetFileNameWithoutExtension(File).Length = 9 Then
                    dr = oExp.ObtenInfSobreDocumento(Path.GetFileNameWithoutExtension(File).Substring(5, 4))
                    drEmpleado = oEmp.BuscarPorNumEmp(Path.GetFileNameWithoutExtension(File).Substring(0, 5))
                End If


                If Not dr Is Nothing Then
                    drDocumento = ds.Tables(0).NewRow
                    drDocumento(0) = dr("CveDoc")
                    drDocumento(1) = dr("DescDoc")
                    drDocumento(2) = dr("NumPag")
                    drDocumento(3) = Path.GetFileNameWithoutExtension(File)
                    drDocumento(6) = CInt(dr("IdDocumento"))
                    If drEmpleado Is Nothing = False Then
                        drDocumento(4) = drEmpleado("NumEmp")
                        drDocumento(5) = Trim(drEmpleado("Nombre").ToString.Trim + " " + drEmpleado("ApellidoPaterno").ToString.Trim + " " + drEmpleado("ApellidoMaterno").ToString.Trim)
                        drDocumento(7) = drEmpleado("IdEmp")
                    Else
                        drDocumento(4) = Path.GetFileNameWithoutExtension(File).Substring(0, 5)
                        drDocumento(5) = "NÚMERO DE EMPLEADO INCORRECTO"
                        drDocumento(7) = 0
                    End If
                    ds.Tables(0).Rows.Add(drDocumento)
                Else
                    drDocumento = ds.Tables(0).NewRow
                    drDocumento(0) = String.Empty
                    drDocumento(1) = String.Empty
                    drDocumento(2) = 0
                    drDocumento(3) = Path.GetFileNameWithoutExtension(File)
                    drDocumento(6) = 0
                    drDocumento(4) = String.Empty
                    drDocumento(5) = String.Empty
                    drDocumento(7) = 0
                    ds.Tables(0).Rows.Add(drDocumento)
                End If
            Next
        Catch
        End Try

        Me.gvDocumentos.DataSource = ds.Tables(0)
        Me.gvDocumentos.DataBind()
        Me.gvDocumentos.Visible = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oUsr As New Usuario
        Dim dt As DataTable

        If Not IsPostBack Then
            RenombraArchivos()

            CargaArchivos()

            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsDocs")

            If CBool(dt.Rows(0).Item("Consulta")) = False Then Response.Redirect("~/SinPermiso.aspx?Home=SI")
        End If
    End Sub
    Protected Sub gvDocumentos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        'Dim lbVerDoc As LinkButton = CType(e.Row.FindControl("lbVerDoc"), LinkButton)
        Dim ibVerDoc As ImageButton = CType(e.Row.FindControl("ibVerDoc"), ImageButton)
        Dim lblNomArch As Label = CType(e.Row.FindControl("lblNomArch"), Label)
        Dim tbNomArch As TextBox = CType(e.Row.FindControl("tbNomArch"), TextBox)
        Dim lblCveDoc As Label = CType(e.Row.FindControl("lblCveDoc"), Label)
        Dim lblDescDoc As Label = CType(e.Row.FindControl("lblDescDoc"), Label)
        Dim lblIdDoc As Label = CType(e.Row.FindControl("lblIdDoc"), Label)
        Dim lblIdEmp As Label = CType(e.Row.FindControl("lblIdEmp"), Label)
        Dim lblNumEmp As Label = CType(e.Row.FindControl("lblNumEmp"), Label)
        Dim lblNomEmp As Label = CType(e.Row.FindControl("lblNomEmp"), Label)
        Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
        'Dim lbVerDoc2 As LinkButton = CType(e.Row.FindControl("lbVerDoc2"), LinkButton)
        Dim ibVerDoc2 As ImageButton = CType(e.Row.FindControl("ibVerDoc2"), ImageButton)
        Dim ibAddDoc As ImageButton = CType(e.Row.FindControl("ibAddDoc"), ImageButton)
        Dim iWarning As System.Web.UI.WebControls.Image = CType(e.Row.FindControl("ibWarning"), System.Web.UI.WebControls.Image)
        Dim ibVerExp As ImageButton = CType(e.Row.FindControl("ibVerExp"), ImageButton)

        Dim PathDocExistente As String = ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP")
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                iWarning.Visible = lblIdDoc.Text = "0" Or lblIdEmp.Text = "0"
                ibAddDoc.Visible = Not iWarning.Visible
                ibVerExp.Visible = lblIdEmp.Text <> "0"

                If lblNomArch Is Nothing Then
                    lblNomArch = New Label
                    lblNomArch.Text = tbNomArch.Text
                End If

                ibVerDoc.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?URLImagen=" + ConfigurationManager.AppSettings("ServerExpedientesTMP") + lblNomArch.Text _
                    + "&IdReporte=23','DocNuevo_" + lblNomArch.Text + "'); return false;"

                If File.Exists(ConfigurationManager.AppSettings("RutaExpedientes") + Left(lblNomArch.Text, 5) + "/" + lblNomArch.Text + ".jpg") Then
                    ibVerDoc2.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                        + "?URLImagen=" + ConfigurationManager.AppSettings("ServerExpedientes") + Left(lblNomArch.Text, 5) + "/" + lblNomArch.Text _
                        + "&IdReporte=23','DocOriginal_" + lblNomArch.Text + "'); return false;"
                    ibVerDoc2.Visible = True
                Else
                    ibVerDoc2.Visible = False
                End If

                ibEliminar.CommandArgument = lblCveDoc.Text

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub ibEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblNomArch As Label = CType(gvr.FindControl("lblNomArch"), Label)
        Dim vlNumEmp As String = Left(lblNomArch.Text, 5)
        Dim vlCveDoc As String = Right(lblNomArch.Text, 4)

        Dim TargetPath As String = ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP")
        File.Delete(TargetPath + lblNomArch.Text + ".jpg")

        CargaArchivos()
    End Sub

    Protected Sub ibAddDoc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)

        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblNomArch As Label = CType(gvr.FindControl("lblNomArch"), Label)
        Dim lblNomEmp As Label = CType(gvr.FindControl("lblNomEmp"), Label)

        Dim SourcePath As String = String.Empty
        Dim TargetPath As String = String.Empty

        Dim oDoc As New Expediente

        

        'Si ya existe una archivo con el mismo nombre, lo eliminamos para después subir el nuevo documento
        

        Try
            SourcePath = ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP") + lblNomArch.Text + ".jpg"
            TargetPath = ConfigurationManager.AppSettings("RutaExpedientes") + Left(lblNomArch.Text, 5)

            'Si no tiene expediente creado, lo creamos automáticamente
            If Not Directory.Exists(TargetPath) Then
                Directory.CreateDirectory(TargetPath)
            End If

            If File.Exists(TargetPath + "\" + lblNomArch.Text + ".jpg") Then
                File.Delete(TargetPath + "\" + lblNomArch.Text + ".jpg")
            End If

            File.Move(SourcePath, TargetPath + "\" + lblNomArch.Text + ".jpg")
        Catch
        End Try

        Try
            SourcePath = ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP") + lblNomArch.Text + ".pdf"
            TargetPath = ConfigurationManager.AppSettings("RutaExpedientes") + Left(lblNomArch.Text, 5)

            'Si no tiene expediente creado, lo creamos automáticamente
            If Not Directory.Exists(TargetPath) Then
                Directory.CreateDirectory(TargetPath)
            End If

            If File.Exists(TargetPath + "\" + lblNomArch.Text + ".pdf") Then
                File.Delete(TargetPath + "\" + lblNomArch.Text + ".pdf")
            End If

            File.Move(SourcePath, TargetPath + "\" + lblNomArch.Text + ".pdf")
        Catch
        End Try

        oDoc.InsertaEmpsDocs(Left(lblNomArch.Text, 5) + "," + Right(lblNomArch.Text, 4), CType(Session("ArregloAuditoria"), String()))

        CargaArchivos()

        'If gvExpedienteDigital.Visible = True And lblInfNumEmp.Text = Left(lblNomArch.Text, 5) Then
        CargaExpediente(Left(lblNomArch.Text, 5), lblNomEmp.Text)
        'End If
    End Sub

    Protected Sub ibVerExp_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblNumEmp As Label = CType(gvr.FindControl("lblNumEmp"), Label)
        Dim lblNomEmp As Label = CType(gvr.FindControl("lblNomEmp"), Label)

        CargaExpediente(lblNumEmp.Text, lblNomEmp.Text)
    End Sub

    Private Sub CargaExpediente(pNumEmp As String, pNomEmp As String)
        Dim Files As String(), File As String
        Dim ds As DataSet
        Dim dr As DataRow
        Dim oExp As New Expediente

        lblInfNumEmp.Text = pNumEmp
        lblInfNomEmp.Text = pNomEmp
        lblExpediente.Text = "Expediente digital del empleado:"
        lblExpediente.Visible = True
        lblInfNumEmp.Visible = True
        lblInfNomEmp.Visible = True

        ds = setDataSetExpedientes()
        Try
            If Directory.Exists(ConfigurationManager.AppSettings("RutaExpedientes") + pNumEmp) Then
                Files = Directory.GetFiles(ConfigurationManager.AppSettings("RutaExpedientes") + pNumEmp, "*.jpg")

                For Each File In Files
                    dr = oExp.ObtenInfSobreDocumento(Path.GetFileNameWithoutExtension(File).Substring(5, 4))

                    If Not dr Is Nothing Then
                        Dim drDocumento As DataRow
                        drDocumento = ds.Tables(0).NewRow
                        drDocumento(0) = dr("CveDoc")
                        drDocumento(1) = dr("DescDoc")
                        drDocumento(2) = dr("NumPag")
                        drDocumento(3) = Path.GetFileNameWithoutExtension(File)
                        ds.Tables(0).Rows.Add(drDocumento)
                    End If
                Next
                Files = Nothing
                Files = Directory.GetFiles(ConfigurationManager.AppSettings("RutaExpedientes") + pNumEmp, "*.pdf")

                For Each File In Files
                    dr = oExp.ObtenInfSobreDocumento(Path.GetFileNameWithoutExtension(File).Substring(5, 4))

                    If Not dr Is Nothing Then
                        Dim drDocumento As DataRow
                        drDocumento = ds.Tables(0).NewRow
                        drDocumento(0) = dr("CveDoc")
                        drDocumento(1) = dr("DescDoc")
                        drDocumento(2) = dr("NumPag")
                        drDocumento(3) = Path.GetFileNameWithoutExtension(File)
                        ds.Tables(0).Rows.Add(drDocumento)
                    End If
                Next

                gvExpedienteDigital.DataSource = ds.Tables(0)
                gvExpedienteDigital.DataBind()
                If gvExpedienteDigital.Rows.Count = 0 Then
                    lblExpediente.Text = lblExpediente.Text + " (Sin documentos registrados)"
                    gvExpedienteDigital.Visible = False
                Else
                    gvExpedienteDigital.Visible = True
                End If
            Else
                lblExpediente.Text = lblExpediente.Text + " (Sin documentos registrados)"
                gvExpedienteDigital.Visible = False
            End If
        Catch
        End Try
    End Sub

    Protected Sub gvExpedienteDigital_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvExpedienteDigital.RowDataBound
        'Dim lbVerDoc As LinkButton = CType(e.Row.FindControl("lbVerDoc"), LinkButton)
        'Dim lbCrearExpediente As LinkButton = CType(e.Row.FindControl("lbCrearExpediente"), LinkButton)
        Dim lblNomArch As Label = CType(e.Row.FindControl("lblNomArch"), Label)
        'Dim lblNumEmp As Label = CType(e.Row.FindControl("lblNumEmp"), Label)
        Dim lblCveDoc As Label = CType(e.Row.FindControl("lblCveDoc"), Label)
        Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminarDeExp"), ImageButton)
        Dim ibVerDoc As ImageButton = CType(e.Row.FindControl("ibVerDoc"), ImageButton)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                'ibVerDoc.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                '    + "?URLImagen=" + ConfigurationManager.AppSettings("ServerExpedientes") + lblInfNumEmp.Text + "/" + lblNomArch.Text _
                '    + "&IdReporte=23','DocOriginal_" + lblNomArch.Text + "'); return false;"

                If (System.IO.File.Exists(ConfigurationManager.AppSettings("RutaExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text)) = True Then
                    ibVerDoc.OnClientClick = "javascript:abreVentanaImpresion('" + ConfigurationManager.AppSettings("ServerExpedientes") + Session("NumEmpParaCons") + "/" + lblNomArch.Text + "','Documento_" + lblNomArch.Text + "'); return false;"
                Else
                    ibVerDoc.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?URLImagen=" + ConfigurationManager.AppSettings("ServerExpedientes") + lblInfNumEmp.Text + "/" + lblNomArch.Text _
                    + "&IdReporte=23','DocOriginal_" + lblNomArch.Text + "'); return false;"
                End If

                ibEliminar.CommandArgument = lblCveDoc.Text
                'Case DataControlRowType.EmptyDataRow
                '    lbCrearExpediente.Visible = Not Directory.Exists(ConfigurationManager.AppSettings("RutaExpedientes") + Session("NumEmpParaCons"))
        End Select
    End Sub

    Protected Sub ibRenameFile_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Me.gvDocumentos.Columns(4).Visible = False
        Me.gvDocumentos.SelectedIndex = -1
        Me.gvDocumentos.EditIndex = gvr.DataItemIndex
        CargaArchivos()
    End Sub

    Protected Sub ibGuardar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)

        Dim lblNomArchOld As Label = CType(gvr.FindControl("lblNomArchOld"), Label)
        Dim tbNomArch As TextBox = CType(gvr.FindControl("tbNomArch"), TextBox)
        Dim SourcePath As String = String.Empty
        Dim TargetPath As String = String.Empty

        SourcePath = ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP") + lblNomArchOld.Text + ".jpg"
        TargetPath = ConfigurationManager.AppSettings("RutaArchivosDigitalesTMP") + tbNomArch.Text + ".jpg"

        File.Move(SourcePath, TargetPath)

        Me.gvDocumentos.Columns(4).Visible = True
        'Me.gvDocumentos.SelectedIndex = gvr.RowIndex
        Me.gvDocumentos.EditIndex = -1
        CargaArchivos()

    End Sub

    Protected Sub ibCancelar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)

        Me.gvDocumentos.Columns(4).Visible = True
        'Me.gvDocumentos.SelectedIndex = gvr.RowIndex
        Me.gvDocumentos.EditIndex = -1
        CargaArchivos()
    End Sub

    Protected Sub ibEliminarDeExp_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim lblNomArch As Label = CType(gvr.FindControl("lblNomArch"), Label)
        Dim vlNumEmp As String = Left(lblNomArch.Text, 5)
        Dim vlCveDoc As String = Right(lblNomArch.Text, 4)
        Dim oDoc As New Expediente
        Dim drEmpleado As DataRow
        Dim oEmp As New Empleado
        Dim dr As DataRow

        Dim Indice As Short
        Dim HayDocs As Boolean = False
        'Dim ibEliminar As ImageButton = CType(sender, ImageButton)
        Dim TargetPath As String = ConfigurationManager.AppSettings("RutaExpedientes") + vlNumEmp + "\"

        File.Delete(TargetPath + lblNomArch.Text + ".jpg")

        dr = oDoc.ObtenInfSobreDocumento2(vlCveDoc)

        For Indice = CShort(dr("CveDoctRangoIni")) To CShort(dr("CveDocRangoFin"))
            If File.Exists(TargetPath + vlNumEmp + Indice.ToString.PadLeft(4, "0") + ".jpg") Then
                HayDocs = True
                Exit For
            End If
        Next

        If Not HayDocs Then
            oDoc.EliminaEmpsDocs(vlNumEmp, vlCveDoc, CType(Session("ArregloAuditoria"), String()))
        End If

        drEmpleado = oEmp.BuscarPorNumEmp(vlNumEmp)
        CargaExpediente(vlNumEmp, Trim(drEmpleado("Nombre").ToString.Trim + " " + drEmpleado("ApellidoPaterno").ToString.Trim + " " + drEmpleado("ApellidoMaterno").ToString.Trim))
    End Sub
End Class
