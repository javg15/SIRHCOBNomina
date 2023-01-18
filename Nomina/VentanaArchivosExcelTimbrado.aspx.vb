'Imports Microsoft.Reporting.WebForms
'Imports System.Collections.Generic
'Imports System.IO
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports ClosedXML.Excel
Imports System.IO
Partial Class VentanaArchivosExcelTimbrado
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
    Private Sub GeneraPlantillaDatosGeneralesV2Punto0()
        Dim dt As New DataTable("plantillaDatosGenerales")
        Dim oNomina As New Nomina
        'Dim gvrQna As GridViewRow
        'Dim lblIdQuincena As Label

        'gvrQna = gvQuincenas.SelectedRow
        'lblIdQuincena = gvrQna.FindControl("lblIdQuincena")

        dt = oNomina.GeneraPlantillaDatosGeneralesParaTimbrado(CShort(Request.Params("IdQuincena")))

        Using wb As New XLWorkbook()
            wb.Worksheets.Add(dt)
            wb.Worksheet(1).Name = "plantillaDatosGenerales"
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
            wb.Worksheet(1).Range("N2", "N" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)

            wb.Worksheet(1).Range("O2", "O" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("P2", "P" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
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
            wb.Worksheet(1).Range("AB2", "AB" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)

            wb.Worksheet(1).Range("AC2", "AC" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AD2", "AD" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AE2", "AE" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AF2", "AF" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AG2", "AG" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AH2", "AH" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AI2", "AI" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AJ2", "AJ" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AK2", "AK" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AL2", "AL" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AM2", "AM" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AN2", "AN" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AO2", "AO" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AP2", "AP" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)

            wb.Worksheet(1).Range("AQ2", "AQ" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AR2", "AR" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)

            wb.Worksheet(1).Range("AS2", "AS" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("AT2", "AT" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AU2", "AU" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("AV2", "AV" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)

            wb.Worksheets.First().Tables.First().ShowAutoFilter = False
            wb.Worksheets.First().Tables.First().Theme = XLTableTheme.None

            wb.Worksheet(1).Range("A1", "AV1").InsertRowsAbove(1)
            wb.Worksheet(1).Range("A1", "A1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("B1", "B1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("C1", "C1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("D1", "D1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("E1", "E1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("F1", "F1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("G1", "G1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("H1", "H1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("I1", "I1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("J1", "J1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("K1", "K1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("L1", "L1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("M1", "M1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("N1", "N1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("O1", "O1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("P1", "P1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("Q1", "Q1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("R1", "R1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("S1", "S1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("T1", "T1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("U1", "U1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("V1", "V1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("W1", "W1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("X1", "X1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("Y1", "Y1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("Z1", "Z1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("AA1", "AA1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("AB1", "AB1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AC1", "AC1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AD1", "AD1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("AE1", "AE1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("AF1", "AF1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("AG1", "AG1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("AH1", "AH1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("AI1", "AI1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AJ1", "AJ1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AK1", "AK1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AL1", "AL1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AM1", "AM1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AN1", "AN1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AO1", "AO1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AP1", "AP1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AQ1", "AQ1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AR1", "AR1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("AS1", "AS1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("AT1", "AT1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AU1", "AU1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("AV1", "AV1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")

            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=plantillaDatosGenerales.xlsx")
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
    Private Sub GeneraPLANTILLA_CONCEPTOSV2Punto0()
        Dim dt As New DataTable("plantillaConceptos")
        Dim oNomina As New Nomina
        'Dim gvrQna As GridViewRow
        'Dim lblIdQuincena As Label

        'gvrQna = gvQuincenas.SelectedRow
        'lblIdQuincena = gvrQna.FindControl("lblIdQuincena")

        dt = oNomina.GeneraPlantillaConceptosParaTimbradoV2Punto0(CShort(Request.Params("IdQuincena")))

        Using wb As New XLWorkbook()
            wb.Worksheets.Add(dt)
            wb.Worksheet(1).Name = "plantillaConceptos"

            wb.Worksheet(1).Range("A2", "A" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("B2", "B" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("C2", "C" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("D2", "D" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("E2", "E" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("F2", "F" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheet(1).Range("G2", "G" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("H2", "H" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)
            wb.Worksheet(1).Range("I2", "I" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Number)

            wb.Worksheets.First().Tables.First().ShowAutoFilter = False
            wb.Worksheets.First().Tables.First().Theme = XLTableTheme.None

            wb.Worksheet(1).Range("A1", "I1").InsertRowsAbove(1)
            wb.Worksheet(1).Range("A1", "A1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("B1", "B1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("C1", "C1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("D1", "D1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("E1", "E1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("F1", "F1").SetDataType(XLCellValues.Text).SetValue("(TIPO TEXTO)")
            wb.Worksheet(1).Range("G1", "G1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("H1", "H1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")
            wb.Worksheet(1).Range("I1", "I1").SetDataType(XLCellValues.Text).SetValue("(TIPO NUMERICO)")

            'wb.SaveAs("PLANTILLA_CONCEPTOS.xlsx")
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=plantillaCONCEPTOS.xlsx")
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

    Private Sub GeneraPLANTILLA_CONCEPTOS()
        Dim dt As New DataTable("CONCEPTOS")
        Dim oNomina As New Nomina
        'Dim gvrQna As GridViewRow
        'Dim lblIdQuincena As Label

        'gvrQna = gvQuincenas.SelectedRow
        'lblIdQuincena = gvrQna.FindControl("lblIdQuincena")

        dt = oNomina.GeneraPlantillaConceptosParaTimbrado(CShort(Request.Params("IdQuincena")))

        Using wb As New XLWorkbook()
            wb.Worksheets.Add(dt)
            wb.Worksheet(1).Name = "CONCEPTOS"
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
            wb.Worksheet(1).Range("N2", "N" + (dt.Rows.Count + 1).ToString).SetDataType(XLCellValues.Text)
            wb.Worksheets.First().Tables.First().ShowAutoFilter = False
            wb.Worksheets.First().Tables.First().Theme = XLTableTheme.None
            'wb.SaveAs("PLANTILLA_CONCEPTOS.xlsx")
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=PLANTILLA_CONCEPTOS.xlsx")
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
                Case "0" 'PLANTILLA_CONCEPTOS
                    GeneraPLANTILLA_CONCEPTOS()
                Case "1" 'PLANTILLA_EMPLEADOS
                    GeneraPLANTILLA_EMPLEADOS()
                Case "2" 'PLANTILLA_PLAZA
                    GeneraPLANTILLA_PLAZA()
                Case "3" 'plantillaDatosGenerales (V2.0)
                    GeneraPlantillaDatosGeneralesV2Punto0()
                Case "4" 'plantillaConceptos (V2.0)
                    GeneraPLANTILLA_CONCEPTOSV2Punto0()
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