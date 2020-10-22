Imports System.Runtime.InteropServices
Imports System.Windows
Imports System.Windows.Interop
Imports System.Windows.Threading

Public Class ShellWPF

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr,
    ByVal hWndInsertAfter As IntPtr, ByVal X As Integer,
    ByVal Y As Integer, ByVal cx As Integer, ByVal cy As _
    Integer, ByVal uFlags As UInt32) As Boolean
    End Function


    Dim RefreshTSCtimer As New DispatcherTimer(New TimeSpan(0,0,0,1), DispatcherPriority.Normal, Addressof RefreshTSC,me.Dispatcher)

    Private Sub RefreshTSC()

        'Battery Info
        dim Power as PowerStatus = SystemInformation.PowerStatus

        'Clock Info
        CurrentTime.Text = now.tostring("HH:mm")
        CurrentDate.Text = now.tostring("dd/MM/yyyy")


        if Not started
            started = true
            WarehouseApplicationButton_Click(Nothing,nothing)
        End If

    End Sub

    Dim started = false


    ReadOnly HWND_BOTTOM As New IntPtr(1)

    Private Const SWP_NOSIZE As UInt32 = &H1
    Private Const SWP_NOMOVE As UInt32 = &H2

    Function WndProc(hwnd As IntPtr, msg As integer, wparam As IntPtr, IParam As IntPtr, ByRef handled As boolean) As intptr
        Const WM_PAINT = &HF
        Const WM_CAPTURECHANGED = &H215

        If (Msg = WM_PAINT) Or (Msg = WM_CAPTURECHANGED) _
        Then
            ' We're being activated. Move to bottom.
            Dim flags As UInt32 = SWP_NOMOVE Or SWP_NOSIZE
            SetWindowPos(new WindowInteropHelper(me).Handle, HWND_BOTTOM, 0, 0, 0, 0,
            flags)
        End If

        return IntPtr.Zero
    End Function
    Private Sub WarehouseApplicationButton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles WarehouseApplicationButton.Click
        Process.Start("C:\Program Files\Internet Explorer\iexplore.exe" , "http://apps.ad.whitehinge.com/AppPublish/SurfacePicker/SurfacePicker.application")
    End Sub



    Private Sub UpdatePolicyButton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles UpdatePolicyButton.Click
        WarehouseApplicationButton.Visibility = Visibility.Hidden
        UpdatePolicyButton.Visibility = Visibility.Hidden
        ShutDownButton.Visibility = Visibility.Hidden

        Forms.Application.DoEvents()
        Process.Start("gpupdate.exe", "/Force /Boot")
    End Sub

    Private Sub CurrentTime_MouseUp() Handles CurrentTime.MouseUp, CurrentTime.touchup
         Process.Start("C:\Windows\Explorer.exe")
        End
    End Sub


    Private Sub ShutDownButton_Click(sender As Object, e As RoutedEventArgs) Handles ShutDownButton.Click
        Dim sdDialog = new ConfirmShutdown()
        
        If sdDialog.ShowDialog() Then
            'msgbox("It would shut down now")
            Dim newOSString As String = My.Computer.Info.OSFullName

            If InStr(newOSString, "10") Then
                Process.Start("Shutdown.exe", "/s /hybrid /t 0")
            ElseIf InStr(newOSString, "7") Then
                System.Diagnostics.Process.Start("shutdown", "-s -t 0")
            Else
                MsgBox("Something went wrong, run the OS Test")
            End If
        End If
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        me.Show()
        Process.Start("C:\Windows\System32\TASKKILL.exe", "/F /IM explorer.exe")
        DeviceName.Text = My.Computer.Name
        '20/05/16 - Autoload surfacepicker.
        'Process.Start("\\WIN-NOHLS1H9ER8\Data Storage\Intra\AppPublish\SurfacePicker\SurfacePicker.application") 'Not anymore
        
    End Sub

    Public Shared Function Check() As Boolean
		Return SystemInformation.TerminalServerSession
	End Function

	<DllImport("user32.dll", EntryPoint := ("GetSystemMetrics"))> _
	Private Shared Function GetSystemMetrics(nIndex As Integer) As Integer
	End Function
End Class
