Public Class MainMenu
    Public AiMode As Boolean
    'closes the program
    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click
        End
    End Sub
    'Opens the player vs player
    Private Sub Player_Vs_Player_Click(sender As Object, e As EventArgs) Handles Player_Vs_Player.Click
        Me.Hide()
        AiMode = False
        ChessBoard.Show()
    End Sub
    'Opens Player vs Ai
    Private Sub Player_Vs_Ai_Click(sender As Object, e As EventArgs) Handles Player_Vs_Ai.Click
        Me.Hide()
        AiMode = True
        ChessBoard.Show()
    End Sub
    'Opens Settings
    Private Sub SettingsBtn_Click(sender As Object, e As EventArgs) Handles SettingsBtn.Click
        Me.Hide()
        Settings.Show()
    End Sub
End Class