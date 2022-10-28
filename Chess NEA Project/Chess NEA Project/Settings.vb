Public Class Settings
    Private Sub MinutesChanger_ValueChanged(sender As Object, e As EventArgs) Handles MinutesChanger.ValueChanged
        Label2.Text = MinutesChanger.Value.ToString
    End Sub
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.Close()
        MainMenu.Show()
    End Sub
    Private Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        ChessBoard.minutes = MinutesChanger.Value
        ChessBoard.minutes1 = MinutesChanger.Value
        Me.Close()
        MainMenu.Show()
    End Sub
End Class