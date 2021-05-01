Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Security", "DisableSecuritySettingsCheck", 00000001)
        Console.WriteLine("1: Success!")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3", "1806", 0)
        Console.WriteLine("2: Success!")
    End Sub
End Class
