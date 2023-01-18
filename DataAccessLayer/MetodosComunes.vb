Imports System.Web.UI
Imports System.Web.UI.WebControls
Namespace COBAEV
    Public Class MetodosComunes
        Public Function GetPostBackControl(page As Page) As Control
            Dim control As Control = Nothing
            Dim c As Control = Nothing

            Dim ctrlname As String = page.Request.Params.Get("__EVENTTARGET")

            If (ctrlname Is Nothing = False And ctrlname <> String.Empty) Then
                control = page.FindControl(ctrlname)
            Else
                For Each ctl As String In page.Request.Form
                    c = page.FindControl(ctl)
                    If (TypeOf c Is Button) Then
                        control = c
                        Exit For
                    End If
                Next
            End If

            Return control
        End Function
        Public Function DeterminaNumQuincenas(ByVal VigIniDeduc As String, ByVal VigFinDeduc As String) As Byte
            Dim Qna, NumQnas As Byte
            NumQnas = 0
            Try
                While CType(VigIniDeduc, Integer) <= CType(VigFinDeduc, Integer)
                    NumQnas += 1
                    Qna = CType(VigIniDeduc.Substring(4, 2), Byte)
                    If Qna < 24 Then
                        VigIniDeduc = (CType(VigIniDeduc, Integer) + 1).ToString
                    Else
                        VigIniDeduc = (CType(VigIniDeduc.Substring(0, 4), Short) + 1).ToString + "01"
                    End If
                End While
            Catch ex As Exception

            End Try
            Return NumQnas
        End Function
    End Class
End Namespace
