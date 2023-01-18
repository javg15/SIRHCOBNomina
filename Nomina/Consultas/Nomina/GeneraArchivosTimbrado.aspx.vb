'Imports DataAccessLayer.COBAEV.Administracion
'Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports ClosedXML.Excel
Imports System.IO
Partial Class ArchivosQnalesParaTimbrado
    Inherits System.Web.UI.Page
    Private Sub BindddlAños()
        Dim oQna As New Quincenas
        With Me.ddlAños
            .DataSource = oQna.ObtenAños(True)
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
                Me.btnConsultarQuincenas.Enabled = False
            Else
                Me.btnConsultarQuincenas.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindQuincenas()
        Dim oQna As New Quincenas
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue))
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0            
        End If
        Me.ibExportarExcel.Visible = gvQuincenas.SelectedIndex <> -1
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub

    Protected Sub gvQuincenas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuincenas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvQuincenas, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindQuincenas()
                ActualizaInfParaGenerarArchivo()
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        BindQuincenas()
    End Sub
    Private Sub ActualizaInfParaGenerarArchivo()
        Dim gvrQna As GridViewRow
        Dim lblIdQuincena As Label

        gvrQna = gvQuincenas.SelectedRow
        lblIdQuincena = gvrQna.FindControl("lblIdQuincena")

        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VentanaArchivosExcelTimbrado.aspx" _
            + "?IdQuincena=" + lblIdQuincena.Text _
            + "&TipoArchivo=" + Me.ddlTipoArchivo.SelectedValue + "','Archivo_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoArchivo.SelectedValue + "');"
    End Sub
    'Protected Sub ibExportarExcel_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibExportarExcel.Click
    '    Select Case ddlTipoArchivo.SelectedValue
    '        Case "0" 'PLANTILLA_CONCEPTOS
    '            GeneraPLANTILLA_CONCEPTOS()
    '        Case "1" 'PLANTILLA_EMPLEADOS
    '            GeneraPLANTILLA_EMPLEADOS()
    '        Case "2" 'PLANTILLA_PLAZA
    '            GeneraPLANTILLA_PLAZA()
    '    End Select
    'End Sub

    'Private Sub GeneraPLANTILLA_CONCEPTOS()
    '    Dim dt As New DataTable("CONCEPTOS")
    '    Dim oNomina As New Nomina
    '    Dim gvrQna As GridViewRow
    '    Dim lblIdQuincena As Label

    '    gvrQna = gvQuincenas.SelectedRow
    '    lblIdQuincena = gvrQna.FindControl("lblIdQuincena")

    '    dt = oNomina.GeneraPlantillaConceptosParaTimbrado(CShort(lblIdQuincena.Text))

    '    Using wb As New XLWorkbook()
    '        wb.Worksheets.Add(dt)
    '        wb.Worksheet(1).Name = "CONCEPTOS"
    '        wb.Worksheet(1).Range("A2", "A" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("B2", "B" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("C2", "C" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("D2", "D" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("E2", "E" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("F2", "F" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("G2", "G" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("H2", "H" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("I2", "I" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("J2", "J" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("K2", "K" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("L2", "L" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("M2", "M" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("N2", "N" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheets.First().Tables.First().ShowAutoFilter = False
    '        wb.Worksheets.First().Tables.First().Theme = XLTableTheme.None
    '        'wb.SaveAs("PLANTILLA_CONCEPTOS.xlsx")
    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.Charset = ""
    '        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    '        Response.AddHeader("content-disposition", "attachment;filename=PLANTILLA_CONCEPTOS.xlsx")
    '        Using MyMemoryStream As New MemoryStream()
    '            wb.SaveAs(MyMemoryStream)
    '            MyMemoryStream.WriteTo(Response.OutputStream)
    '            Response.Flush()
    '            Try
    '                Response.[End]()
    '            Catch Ex As Threading.ThreadAbortException

    '            End Try
    '        End Using
    '    End Using
    'End Sub

    'Private Sub GeneraPLANTILLA_EMPLEADOS()
    '    Dim dt As New DataTable("EMPLEADO")
    '    Dim oNomina As New Nomina
    '    Dim gvrQna As GridViewRow
    '    Dim lblIdQuincena As Label

    '    gvrQna = gvQuincenas.SelectedRow
    '    lblIdQuincena = gvrQna.FindControl("lblIdQuincena")

    '    dt = oNomina.GeneraPlantillaEmpleadosParaTimbrado(CShort(lblIdQuincena.Text))

    '    Using wb As New XLWorkbook()
    '        wb.Worksheets.Add(dt)
    '        wb.Worksheet(1).Name = "EMPLEADO"
    '        wb.Worksheet(1).Range("A2", "A" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("B2", "B" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("C2", "C" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("D2", "D" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("E2", "E" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("F2", "F" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("G2", "G" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("H2", "H" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheets.First().Tables.First().ShowAutoFilter = False
    '        wb.Worksheets.First().Tables.First().Theme = XLTableTheme.None

    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.Charset = ""
    '        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    '        Response.AddHeader("content-disposition", "attachment;filename=PLANTILLA_EMPLEADOS.xlsx")
    '        Using MyMemoryStream As New MemoryStream()
    '            wb.SaveAs(MyMemoryStream)
    '            MyMemoryStream.WriteTo(Response.OutputStream)
    '            Response.Flush()
    '            Try
    '                Response.[End]()
    '            Catch Ex As Threading.ThreadAbortException

    '            End Try
    '        End Using
    '    End Using
    'End Sub

    'Private Sub GeneraPLANTILLA_PLAZA()
    '    Dim dt As New DataTable("PLAZA")
    '    Dim oNomina As New Nomina
    '    Dim gvrQna As GridViewRow
    '    Dim lblIdQuincena As Label

    '    gvrQna = gvQuincenas.SelectedRow
    '    lblIdQuincena = gvrQna.FindControl("lblIdQuincena")

    '    dt = oNomina.GeneraPlantillaPlazaParaTimbrado(CShort(lblIdQuincena.Text))

    '    Using wb As New XLWorkbook()
    '        wb.Worksheets.Add(dt)
    '        wb.Worksheet(1).Name = "PLAZA"
    '        wb.Worksheet(1).Range("A2", "A" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("B2", "B" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("C2", "C" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("D2", "D" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("E2", "E" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("F2", "F" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("G2", "G" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("H2", "H" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("I2", "I" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("J2", "J" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("K2", "K" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("L2", "L" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("M2", "M" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("N2", "N" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.DateTime)

    '        wb.Worksheet(1).Range("O2", "O" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.DateTime)
    '        wb.Worksheet(1).Range("P2", "P" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.DateTime)
    '        wb.Worksheet(1).Range("Q2", "Q" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("R2", "R" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("S2", "S" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("T2", "T" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("U2", "U" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("V2", "V" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("W2", "W" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("X2", "X" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("Y2", "Y" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("Z2", "Z" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AA2", "AA" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AB2", "AB" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)

    '        wb.Worksheet(1).Range("AC2", "AC" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AD2", "AD" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AE2", "AE" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AF2", "AF" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AG2", "AG" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AH2", "AH" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AI2", "AI" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AJ2", "AJ" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AK2", "AK" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AL2", "AL" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AM2", "AM" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AN2", "AN" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AO2", "AO" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AP2", "AP" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)

    '        wb.Worksheet(1).Range("AQ2", "AQ" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
    '        wb.Worksheet(1).Range("AR2", "AR" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)

    '        wb.Worksheets.First().Tables.First().ShowAutoFilter = False
    '        wb.Worksheets.First().Tables.First().Theme = XLTableTheme.None

    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.Charset = ""
    '        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    '        Response.AddHeader("content-disposition", "attachment;filename=PLANTILLA_PLAZA.xlsx")
    '        Using MyMemoryStream As New MemoryStream()
    '            wb.SaveAs(MyMemoryStream)
    '            MyMemoryStream.WriteTo(Response.OutputStream)
    '            Response.Flush()
    '            Try
    '                Response.[End]()
    '            Catch Ex As Threading.ThreadAbortException

    '            End Try
    '        End Using
    '    End Using
    'End Sub

    Protected Sub gvQuincenas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvQuincenas.SelectedIndexChanged
        ActualizaInfParaGenerarArchivo()
    End Sub

    Protected Sub ddlTipoArchivo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTipoArchivo.SelectedIndexChanged
        ActualizaInfParaGenerarArchivo()
    End Sub
End Class