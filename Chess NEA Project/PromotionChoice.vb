Public Class PromotionChoice

    Private Sub PromotionChoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ChessBoard.colourOfPieces = "white" Then

        Else

        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ChessBoard.colourOfPieces = "black" Then
            ChessBoard.UsersChoice = "WRook"
        Else
            ChessBoard.UsersChoice = "BRook"
        End If
        ChessBoard.PromotePawn(ChessBoard.chess_piece)
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ChessBoard.colourOfPieces = "black" Then
            ChessBoard.UsersChoice = "WBishop"
        Else
            ChessBoard.UsersChoice = "BBishop"
        End If
        ChessBoard.PromotePawn(ChessBoard.chess_piece)
        Me.Close()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ChessBoard.colourOfPieces = "black" Then
            ChessBoard.UsersChoice = "WKnight"
        Else
            ChessBoard.UsersChoice = "BKnight"
        End If
        ChessBoard.PromotePawn(ChessBoard.chess_piece)
        Me.Close()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ChessBoard.colourOfPieces = "black" Then
            ChessBoard.UsersChoice = "WQueen"
        Else
            ChessBoard.UsersChoice = "BQueen"
        End If
        ChessBoard.PromotePawn(ChessBoard.chess_piece)
        Me.Close()
    End Sub
End Class