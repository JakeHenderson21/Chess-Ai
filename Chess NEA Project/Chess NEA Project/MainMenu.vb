Public Class MainMenu
    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click
        End
    End Sub
    Private Sub Player_Vs_Player_Click(sender As Object, e As EventArgs) Handles Player_Vs_Player.Click
        Me.Hide()
        ChessBoard.Show()
    End Sub

    Private Sub SettingsBtn_Click(sender As Object, e As EventArgs) Handles SettingsBtn.Click
        Me.Hide()
        Settings.Show()
    End Sub
End Class