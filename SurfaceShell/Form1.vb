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
        Dim wpf As New shellwpf
        wpf.Show()
        Me.hide()

    End Sub

End Class
