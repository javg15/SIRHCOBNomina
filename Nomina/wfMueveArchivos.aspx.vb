Imports System.IO
Imports DataAccessLayer.COBAEV.Empleados
Partial Class wfMueveArchivos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim arrayFiles(), arrayDirs() As String
        Dim RutaOrigen As String = "D:\Expedientes07112012"
        Dim RutaDestino As String = "C:\IFE"
        Dim File, Dir As String
        Dim DirInfo As DirectoryInfo
        Dim FileInfo As FileInfo
        Dim StrDocs As String
        Dim oEmpExp As New Expediente

        arrayDirs = Directory.GetDirectories(RutaOrigen)

        For Each Dir In arrayDirs
            StrDocs = String.Empty
            DirInfo = New DirectoryInfo(Dir)
            StrDocs = StrDocs + DirInfo.Name
            If DirInfo.Name <> "Fotos" Then
                arrayFiles = Directory.GetFiles(RutaOrigen + "\" + DirInfo.Name)
                For Each File In arrayFiles
                    FileInfo = New FileInfo(File)
                    oEmpExp.InsertaNombresDeArchivos(FileInfo.Name)
                    'If FileInfo.Name = DirInfo.Name + "0600.jpg" Or FileInfo.Name = DirInfo.Name + "0601.jpg" Then
                    '    System.IO.File.Copy(RutaOrigen + "\" + DirInfo.Name + "\" + FileInfo.Name, RutaDestino + "\" + FileInfo.Name)
                    'End If
                Next
                'oEmpExp.InsertaEmpsDocs(StrDocs)
            End If
        Next
        Response.Write("Terminado.")

        'Dim arrayFiles(), arrayDirs() As String
        'Dim File, Dir As String
        'Dim FileInfo As FileInfo
        'Dim DirInfo As DirectoryInfo
        'Dim strFileName As String

        'Dim RutaOrigen As String = "D:\ExpedientesParaEscanear"
        'Dim RutaDestino As String = "D:\ExpedientesParaEscanear"

        ''*************Para mover archivos
        'arrayDirs = Directory.GetDirectories(RutaOrigen + "\")
        'For Each Dir In arrayDirs
        '    DirInfo = New DirectoryInfo(Dir)
        '    arrayFiles = Directory.GetFiles(RutaOrigen + "\" + DirInfo.Name)
        '    For Each File In arrayFiles
        '        FileInfo = New FileInfo(File)
        '        'Tratamos de trabajar solo los archvios que tiene una longitud de 13 caracteres en el nombre + extensión
        '        If FileInfo.Name.Replace(" ", "").Trim.Length = 13 Then
        '            'Si no existe el directorio lo creamos
        '            If Not Directory.Exists(RutaDestino + "\" + FileInfo.Name.Substring(0, 5)) Then
        '                Directory.CreateDirectory(RutaDestino + "\" + FileInfo.Name.Substring(0, 5))
        '            End If
        '            'Trabajamos solo los archivos que tengan como nombre un valor numérico
        '            strFileName = String.Empty
        '            strFileName = Left(FileInfo.Name.Replace(" ", "").Trim, 9)

        '            If IsNumeric(strFileName) Then
        '                'Si no existe el archivo en RutaDestino
        '                If Not System.IO.File.Exists(RutaDestino + "\" + FileInfo.Name.Substring(0, 5) + "\" + FileInfo.Name.Replace(" ", "").Trim) Then
        '                    'Movemos el archivo de RutaOrigen a RutaDestino
        '                    System.IO.File.Move(RutaOrigen + "\" + DirInfo.Name + "\" + FileInfo.Name, _
        '                                    RutaDestino + "\" + FileInfo.Name.Substring(0, 5) + "\" + FileInfo.Name.Replace(" ", "").Trim)
        '                Else 'If ya existe el archivo en RutaDestino
        '                    'Eliminamos el archivo en RutaDestino
        '                    System.IO.File.Delete(RutaDestino + "\" + FileInfo.Name.Substring(0, 5) + "\" + FileInfo.Name.Replace(" ", "").Trim)
        '                    'Movemos el archivo de RutaOrigen a RutaDestino
        '                    System.IO.File.Move(RutaOrigen + "\" + DirInfo.Name + "\" + FileInfo.Name, _
        '                                    RutaDestino + "\" + FileInfo.Name.Substring(0, 5) + "\" + FileInfo.Name.Replace(" ", "").Trim)

        '                End If
        '            Else
        '                System.IO.File.Move(RutaOrigen + "\" + DirInfo.Name + "\" + FileInfo.Name, _
        '                                RutaOrigen + "\" + DirInfo.Name + "\" + FileInfo.Name.Replace("N", "").Trim)

        '            End If
        '        Else
        '            'Trabajamos solo los archivos que tengan como nombre un valor numérico
        '            strFileName = String.Empty
        '            strFileName = FileInfo.Name

        '            If IsNumeric(strFileName) = False Then
        '                System.IO.File.Move(RutaOrigen + "\" + DirInfo.Name + "\" + FileInfo.Name, _
        '                            RutaOrigen + "\" + DirInfo.Name + "\" + FileInfo.Name.Replace("N", "").Trim)
        '            End If
        '        End If
        '    Next
        'Next
        'Response.Write("Terminado.")
        '*************Para mover archivos

    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim IndiceDiaMes, IndiceMes As Byte
    '    Dim CuentaSabados As Byte = 0
    '    Dim CuentaDomingos As Byte = 0
    '    Dim Fecha As Date

    '    Me.Label1.Text = String.Empty

    '    For IndiceMes = 1 To 12
    '        Fecha = CDate("01/" + IndiceMes.ToString.PadLeft(2, "0") + "/" + CShort(Me.TextBox1.Text).ToString)
    '        CuentaSabados = 0
    '        CuentaDomingos = 0
    '        For IndiceDiaMes = 1 To Date.DaysInMonth(CShort(Me.TextBox1.Text), IndiceMes) - 1
    '            Select Case Fecha.DayOfWeek
    '                Case DayOfWeek.Sunday
    '                    CuentaDomingos = CuentaDomingos + 1
    '                Case DayOfWeek.Saturday
    '                    CuentaSabados = CuentaSabados + 1
    '            End Select
    '            Fecha = Fecha.AddDays(1)
    '        Next
    '        Me.Label1.Text = Me.Label1.Text + MonthName(IndiceMes).ToUpper + " de " + CShort(Me.TextBox1.Text).ToString + " tiene " + CuentaSabados.ToString + " Sábados y " + CuentaDomingos.ToString + " Domingos<br />"
    '    Next
    'End Sub
End Class
