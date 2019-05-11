Imports System.IO

Public Class BatchCode

    Public Folder As String

    Private Random1 As Integer
    Private Random2 As Integer

    Public Sub New(ByVal Folder As String, ByVal Random1 As Integer, ByVal Random2 As Integer)
        Me.Folder = Folder

        Me.Random1 = Random1
        Me.Random2 = Random2
    End Sub

    Public Sub Execute(ByVal Code As String)
        Dim Path As String = Folder & "\" & New Random().Next(Random1, Random2) & ".bat"
        Dim Str As New StreamWriter(Path, False)

        Str.Write(Code)
        Str.Close()

        Dim Proc As New ProcessStartInfo
        Proc.UseShellExecute = True
        Proc.FileName = Path
        Proc.Verb = "runas"

        Process.Start(Proc)
    End Sub

End Class
