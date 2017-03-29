Imports System.Windows.Threading

Public Class SafeShutdownWindow

    Dim NewTiemr as new DispatcherTimer(new TimeSpan(0,1,0),DispatcherPriority.Normal, Addressof Timertick, me.Dispatcher )

    Private Sub TimerTick()
        me.hide
        NewTiemr.Stop()
    End Sub
    dim counts as Integer = 1
    Public Sub Cool()
        counts += 1
        If counts > 1 then
            me.Show()
        NewTiemr.Start()
        End If
        
    End Sub

End Class
