Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Public Class Form1

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr,
    ByVal hWndInsertAfter As IntPtr, ByVal X As Integer,
    ByVal Y As Integer, ByVal cx As Integer, ByVal cy As _
    Integer, ByVal uFlags As UInt32) As Boolean
    End Function

    ReadOnly HWND_BOTTOM As New IntPtr(1)

    Private Const SWP_NOSIZE As UInt32 = &H1
    Private Const SWP_NOMOVE As UInt32 = &H2

    Protected Overrides Sub WndProc(ByRef m As _
    System.Windows.Forms.Message)
        Const WM_PAINT = &HF
        Const WM_CAPTURECHANGED = &H215

        If (m.Msg = WM_PAINT) Or (m.Msg = WM_CAPTURECHANGED) _
        Then
            ' We're being activated. Move to bottom.
            Dim flags As UInt32 = SWP_NOMOVE Or SWP_NOSIZE
            SetWindowPos(Me.Handle, HWND_BOTTOM, 0, 0, 0, 0,
            flags)
        End If

        ' Debug.WriteLine(m.ToString)

        MyBase.WndProc(m)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Process.Start("C:\Windows\System32\TASKKILL.exe", "/F /IM explorer.exe")
        PCName.Text = My.Computer.Name
        '20/05/16 - Autoload surfacepicker.
        'Process.Start("\\WIN-NOHLS1H9ER8\Data Storage\Intra\AppPublish\SurfacePicker\SurfacePicker.application") 'Not anymore
        Process.Start("T:\AppData\Utility\ResetSP.bat")
    End Sub

    Private Sub SecondTimer_Tick(sender As Object, e As EventArgs) Handles SecondTimer.Tick
        'Update Time
        ClockTime.Text = Now.ToString("HH:mm")
        ClockDate.Text = Now.ToString("dddd d MMMM")

        'Update Battery
        Dim power As PowerStatus = SystemInformation.PowerStatus
        Dim percent As Single = power.BatteryLifePercent
        BatteryLife.Text = FormatPercent(percent, 0)
        Dim timeleft As Integer = power.BatteryLifeRemaining
        TabletName.Text = Math.Round(New TimeSpan(0, 0, timeleft).Hours).ToString + "hr " + Math.Round(New TimeSpan(0, 0, timeleft).Minutes).ToString + "min"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles PickLauncher.Click
        Process.Start("\\WIN-NOHLS1H9ER8\Data Storage\Intra\AppPublish\SurfacePicker\SurfacePicker.application")
    End Sub

    Private Sub PrepackLauncher_Click(sender As Object, e As EventArgs) Handles PrepackLauncher.Click
        Process.Start("\\WIN-NOHLS1H9ER8\Data Storage\Intra\AppPublish\PPA\PrePackApp.application")
    End Sub

    Private Sub ClockTime_Click(sender As Object, e As EventArgs) Handles ClockTime.DoubleClick
        Process.Start("C:\Windows\Explorer.exe")
        Me.Close()
    End Sub

    Private Sub GPUpdateButton_Click(sender As Object, e As EventArgs) Handles GPUpdateButton.Click
        PickLauncher.Visible = False
        PrepackLauncher.Visible = False
        GPUpdateButton.Visible = False
        ShutDownButton.Visible = False
        Application.DoEvents()
        Process.Start("gpupdate.exe", "/Force /Boot")
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles ShutDownButton.Click
        Dim newOSString As String = My.Computer.Info.OSFullName

        If MsgBox("Are you sure?", MsgBoxStyle.YesNo, "Shutdown?") = MsgBoxResult.Yes Then



            If InStr(newOSString, "10") Then
                Process.Start("Shutdown.exe", "/s /hybrid /t 0")
            ElseIf InStr(newOSString, "7") Then
                System.Diagnostics.Process.Start("shutdown", "-s -t 0")
            Else
                MsgBox("Something went wrong, run the OS Test")
            End If
        End If
    End Sub
End Class
