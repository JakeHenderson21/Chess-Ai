Public Class Settings
    'Shows user their input
    Private Sub MinutesChanger_ValueChanged(sender As Object, e As EventArgs) Handles MinutesChanger.ValueChanged
        Label2.Text = MinutesChanger.Value.ToString
    End Sub
    'Cancels the users input, either sets it back to 5 or their last input
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.Close()
        MainMenu.Show()
    End Sub
    'Confirms the users input
    Private Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        ChessBoard.minutes = MinutesChanger.Value
        ChessBoard.minutes1 = MinutesChanger.Value
        Me.Close()
        MainMenu.Show()
    End Sub
End Class