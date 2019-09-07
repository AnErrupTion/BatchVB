Imports System.IO

Public Class BatchCode

    Public Sub Execute(FileName As String, Code As String, Optional ShowMsgBox As Boolean = False, Optional Message As String = Nothing)
        File.WriteAllText(FileName, Code)

        Dim Proc As New Process
        Proc.StartInfo.UseShellExecute = True
        Proc.StartInfo.FileName = FileName
        Proc.StartInfo.Verb = "runas"
        Proc.Start()
        Proc.WaitForExit()

        If Proc.HasExited Then
            File.Delete(FileName)
            If ShowMsgBox Then MsgBox(Message)
        End If
    End Sub

End Class
