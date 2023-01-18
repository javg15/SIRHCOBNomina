'Imports Microsoft.Reporting.WebForms
'Imports System.Collections.Generic
'Imports System.IO
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports ClosedXML.Excel
Imports System.IO
Partial Class VentanaExportarArchivosAExcel
    Inherits System.Web.UI.Page
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If IsPostBack = False Then
    '        Select Case Request.Params("TipoArchivo")
    '            Case "0" 'PLANTILLA_CONCEPTOS
    '                GeneraPLANTILLA_CONCEPTOS()
    '            Case "1" 'PLANTILLA_EMPLEADOS
    '                GeneraPLANTILLA_EMPLEADOS()
    '            Case "2" 'PLANTILLA_PLAZA
    '                GeneraPLANTILLA_PLAZA()
    '        End Select
    '    End If
    'End Sub
    Private Sub GeneraExcelDeSolicPorEstDePuntyAsist()
        Dim dt As New DataTable("ESTPORPUNTYASIST")
        Dim oNomina As New Nomina

        Dim oEmp As New Percepcion
        dt = oEmp.ObtenSEmpsParaPuntyAsistPorAnioyParte(Request.Params("strAnioParte"), True)

        Using wb As New XLWorkbook()
            wb.Worksheets.Add(dt)
            wb.Worksheet(1).Name = "ESTPORPUNTYASIST"
            wb.Worksheet(1).Range("A2", "A" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("B2", "B" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("C2", "C" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("D2", "D" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("E2", "E" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("F2", "F" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("G2", "G" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("H2", "H" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("I2", "I" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.DateTime)
            wb.Worksheet(1).Range("J2", "J" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("K2", "K" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheets.First().Tables.First().ShowAutoFilter = False
            wb.Worksheets.First().Tables.First().Theme = XLTableTheme.None
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=SOLICESTPORPUNTYASIST.xlsx")
            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Try
                    Response.[End]()
                Catch Ex As Threading.ThreadAbortException

                End Try
            End Using
        End Using
    End Sub
    Private Sub GeneraExcelDeDiasEcoNoDisf()
        Dim dt As New DataTable("DIASECONODISF")
        Dim oNomina As New Nomina

        Dim oEmp As New Percepcion
        dt = oEmp.ObtenSEmpsParaDiasEcoNoDisfPorAnio(Request.Params("strAnio"), True)

        Using wb As New XLWorkbook()
            wb.Worksheets.Add(dt)
            wb.Worksheet(1).Name = "ESTPORPUNTYASIST"
            wb.Worksheet(1).Range("A2", "A" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("B2", "B" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("C2", "C" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("D2", "D" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("E2", "E" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("F2", "F" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("G2", "G" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("H2", "H" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.DateTime)
            wb.Worksheet(1).Range("I2", "I" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("J2", "J" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheets.First().Tables.First().ShowAutoFilter = False
            wb.Worksheets.First().Tables.First().Theme = XLTableTheme.None
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=DIASECONODISF.xlsx")
            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Try
                    Response.[End]()
                Catch Ex As Threading.ThreadAbortException

                End Try
            End Using
        End Using
    End Sub
    Private Sub GeneraPLANTILLA_EMPLEADOS()
        Dim dt As New DataTable("EMPLEADO")
        Dim oNomina As New Nomina
        'Dim gvrQna As GridViewRow
        'Dim lblIdQuincena As Label

        'gvrQna = gvQuincenas.SelectedRow
        'lblIdQuincena = gvrQna.FindControl("lblIdQuincena")

        dt = oNomina.GeneraPlantillaEmpleadosParaTimbrado(CShort(Request.Params("IdQuincena")))

        Using wb As New XLWorkbook()
            wb.Worksheets.Add(dt)
            wb.Worksheet(1).Name = "EMPLEADO"
            wb.Worksheet(1).Range("A2", "A" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("B2", "B" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("C2", "C" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("D2", "D" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("E2", "E" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("F2", "F" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("G2", "G" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("H2", "H" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheets.First().Tables.First().ShowAutoFilter = False
            wb.Worksheets.First().Tables.First().Theme = XLTableTheme.None

            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=PLANTILLA_EMPLEADOS.xlsx")
            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Try
                    Response.[End]()
                Catch Ex As Threading.ThreadAbortException

                End Try
            End Using
        End Using
    End Sub

    Private Sub GeneraPLANTILLA_PLAZA()
        Dim dt As New DataTable("PLAZA")
        Dim oNomina As New Nomina
        'Dim gvrQna As GridViewRow
        'Dim lblIdQuincena As Label

        'gvrQna = gvQuincenas.SelectedRow
        'lblIdQuincena = gvrQna.FindControl("lblIdQuincena")

        dt = oNomina.GeneraPlantillaPlazaParaTimbrado(CShort(Request.Params("IdQuincena")))

        Using wb As New XLWorkbook()
            wb.Worksheets.Add(dt)
            wb.Worksheet(1).Name = "PLAZA"
            wb.Worksheet(1).Range("A2", "A" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("B2", "B" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("C2", "C" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("D2", "D" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("E2", "E" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("F2", "F" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("G2", "G" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("H2", "H" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("I2", "I" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("J2", "J" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("K2", "K" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("L2", "L" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("M2", "M" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("N2", "N" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.DateTime)

            wb.Worksheet(1).Range("O2", "O" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.DateTime)
            wb.Worksheet(1).Range("P2", "P" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.DateTime)
            wb.Worksheet(1).Range("Q2", "Q" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("R2", "R" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("S2", "S" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("T2", "T" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("U2", "U" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("V2", "V" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("W2", "W" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("X2", "X" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("Y2", "Y" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("Z2", "Z" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AA2", "AA" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AB2", "AB" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)

            wb.Worksheet(1).Range("AC2", "AC" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AD2", "AD" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AE2", "AE" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AF2", "AF" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AG2", "AG" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AH2", "AH" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AI2", "AI" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AJ2", "AJ" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AK2", "AK" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AL2", "AL" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AM2", "AM" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AN2", "AN" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AO2", "AO" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AP2", "AP" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)

            wb.Worksheet(1).Range("AQ2", "AQ" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AR2", "AR" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)

            wb.Worksheets.First().Tables.First().ShowAutoFilter = False
            wb.Worksheets.First().Tables.First().Theme = XLTableTheme.None

            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=PLANTILLA_PLAZA.xlsx")
            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Try
                    Response.[End]()
                Catch Ex As Threading.ThreadAbortException

                End Try
            End Using
        End Using
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If IsPostBack = False Then
            'Timer1.Enabled = True
            Select Case Request.Params("TipoArchivo")
                Case "0" 'SOLICITUDES DE ESTÍMULOS POR PUNTUALIDAD Y ASISTENCIA
                    GeneraExcelDeSolicPorEstDePuntyAsist()
                Case "1"
                    GeneraExcelDeDiasEcoNoDisf()
                    'Case "1" 'PLANTILLA_EMPLEADOS
                    '    GeneraPLANTILLA_EMPLEADOS()
                    'Case "2" 'PLANTILLA_PLAZA
                    '    GeneraPLANTILLA_PLAZA()
            End Select
        End If
    End Sub

    'Protected Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
    '    'Timer1.Enabled = False
    '    Select Case Request.Params("TipoArchivo")
    '        Case "0" 'PLANTILLA_CONCEPTOS
    '            GeneraPLANTILLA_CONCEPTOS()
    '        Case "1" 'PLANTILLA_EMPLEADOS
    '            GeneraPLANTILLA_EMPLEADOS()
    '        Case "2" 'PLANTILLA_PLAZA
    '            GeneraPLANTILLA_PLAZA()
    '    End Select
    'End Sub
End Class