Public Class ConfirmShutdown
    Private Sub YesButton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles YesButton.Click
        Me.DialogResult = True
        Me.Close()
    End Sub
End Class
