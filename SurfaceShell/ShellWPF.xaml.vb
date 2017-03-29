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
        if Power.BatteryChargeStatus = BatteryChargeStatus.NoSystemBattery then
            BatteryPercentage.Visibility = Visibility.Collapsed
            BatteryRemainingTime.Visibility = Visibility.Collapsed
        else
            BatteryPercentage.Visibility = Visibility.Visible
            BatteryRemainingTime.Visibility = Visibility.Visible
            BatteryPercentage.Text = formatpercent(Power.BatteryLifePercent,0)
            BatteryRemainingTime.Text = new TimeSpan(0,0,0,power.BatteryLifeRemaining).ToString()
        End If

        'Clock Info
        CurrentTime.Text = now.tostring("HH:mm")
        CurrentDate.Text = now.tostring("dd/MM/yyyy")

        'Remote Info
        If not Check() = CurrentIsRemoteSessionValue then
            CurrentIsRemoteSessionValue = not CurrentIsRemoteSessionValue
            IsRemoteSessionChanged(CurrentIsRemoteSessionValue)
        End If


        ''Debug thing
        'dim debugtext as String= ""
        'debugtext += "CurrentIsRemoteSessionValue: " + currentisremotesessionvalue.ToString + vbnewline
        'debugtext += "SystemInformation.TerminalServerSession: " + SystemInformation.TerminalServerSession.ToString + vbnewline
        'debugtext += "SystemParameters.IsRemoteSession: " + SystemParameters.IsRemoteSession.ToString + vbnewline
        'debugtext += "SystemParameters.IsRemotelyControlled: " + SystemParameters.IsRemotelyControlled.ToString + vbnewline
        'debugtext += "Check() function: " + Check().ToString + vbnewline
        'debugtext += "Current Time: " + now.ToString + vbnewline

        'debug.Text = debugtext



    End Sub

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
        Process.Start("T:\AppData\Utility\ResetSP.bat")
    End Sub

    Private Sub PrepackButton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles PrepackButton.Click
        Process.Start("\\WIN-NOHLS1H9ER8\Data Storage\Intra\AppPublish\PPA\PrePackApp.application")
    End Sub

    Private Sub ItemVerifierButton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles ItemVerifierButton.Click
        Process.Start("\\WIN-NOHLS1H9ER8\Data Storage\Intra\AppPublish\DV\DeliveryVerifier.application")
    End Sub

    Private Sub LocationsModifierButton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles LocationsModifierButton.Click
        Process.Start("\\WIN-NOHLS1H9ER8\Data Storage\Intra\AppPublish\LocationsModifier\LocationsModifier.application")
    End Sub

    Private Sub UpdatePolicyButton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles UpdatePolicyButton.Click
        WarehouseApplicationButton.Visibility = Visibility.Hidden
        PrepackButton.Visibility = Visibility.Hidden
        UpdatePolicyButton.Visibility = Visibility.Hidden
        ShutDownButton.Visibility = Visibility.Hidden
        LocationsModifierButton.Visibility = Visibility.Hidden
        ItemVerifierButton.Visibility = Visibility.Hidden

        Forms.Application.DoEvents()
        Process.Start("gpupdate.exe", "/Force /Boot")
    End Sub

    Private Sub CurrentTime_MouseUp() Handles CurrentTime.MouseUp, CurrentTime.touchup
         Process.Start("C:\Windows\Explorer.exe")
        End
    End Sub

    Private Sub Window_Initialized(sender As Object, e As EventArgs)
        'Dim src As HwndSource = HwndSource.FromHwnd(new WindowInteropHelper(me).Handle)
        'src.AddHook(AddressOf Wndproc)
        'MyBase.OnInitialized(e)
        Addhandler SystemParameters.StaticPropertyChanged, addressof SystemParameterChanged
    End Sub

    Dim CloseSafeShutdownOnDisconnect as Boolean = false
    Dim StartSurfacePickerOnConnect as Boolean = false
    Dim SafeShutdown as new SafeShutdownWindow

    Dim CurrentIsRemoteSessionValue as Boolean = SystemParameters.IsRemoteSession

    Private Sub SystemParameterChanged()
        If not SystemParameters.IsRemoteSession = CurrentIsRemoteSessionValue then
            CurrentIsRemoteSessionValue = SystemParameters.IsRemoteSession
            IsRemoteSessionChanged(SystemParameters.IsRemoteSession)
        End If
    End Sub

    Private Sub IsRemoteSessionChanged(IsRemoteSession As boolean)
        If IsRemoteSession then
            try
                SafeShutdown.Hide()
            Catch ex As Exception

            End Try
            if StartSurfacePickerOnConnect then
                StartSurfacePickerOnConnect = False
                Process.Start("T:\AppData\Utility\ResetSP.bat")
            End If

        End If
    End Sub

    Private Sub ShutDownButton_Click(sender As Object, e As RoutedEventArgs) Handles ShutDownButton.Click

        If MsgBox("Are you sure?", MsgBoxStyle.YesNo, "Shutdown?") = MsgBoxResult.Yes Then
            if CurrentIsRemoteSessionValue then
                CloseSafeShutdownOnDisconnect = true
                SafeShutdown.Cool()
                Process.Start("Taskkill.exe","/F /IM SurfacePicker.exe")
                CloseSafeShutdownOnDisconnect = True
                StartSurfacePickerOnConnect = true
            else
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
        End If
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        me.Show()
        Process.Start("C:\Windows\System32\TASKKILL.exe", "/F /IM explorer.exe")
        DeviceName.Text = My.Computer.Name
        '20/05/16 - Autoload surfacepicker.
        'Process.Start("\\WIN-NOHLS1H9ER8\Data Storage\Intra\AppPublish\SurfacePicker\SurfacePicker.application") 'Not anymore
        Process.Start("T:\AppData\Utility\ResetSP.bat")
    End Sub

    Public Shared Function Check() As Boolean
		Return SystemInformation.TerminalServerSession
	End Function

	<DllImport("user32.dll", EntryPoint := ("GetSystemMetrics"))> _
	Private Shared Function GetSystemMetrics(nIndex As Integer) As Integer
	End Function
End Class
