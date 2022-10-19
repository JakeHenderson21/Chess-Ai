Public Class Pawn
    Inherits ChessPiece
    Public everyPiece(31) As Button
    Public firstMoveCheck As Boolean
    Public operatorcheck, newScoreMove, OldScoremove As Integer
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal chess_colour As Chesscolour, ByVal piece As Button, ByVal firstMove As Boolean)
        MyBase.New(X, Y, chess_colour, piece)
        firstMoveCheck = firstMove
    End Sub
    Public Overrides Sub SetColour()
        Dim counter As Integer
        If colour = Chesscolour.black Then
            operatorcheck = 1
        ElseIf colour = Chesscolour.white Then
            operatorcheck = -1
        End If
        For Each Button In wpieces
            everyPiece(counter) = Button
            counter += 1
        Next
        For Each Button In bpieces
            everyPiece(counter) = Button
            counter += 1
        Next
    End Sub
    Public Overrides Sub CheckMoves()
        OldScoremove = 2
        ChessBoard.Button1.Location = New Point(piece.Left, piece.Top + (operatorcheck * 77))
        ChessBoard.Button2.Location = New Point(piece.Left, piece.Top + (operatorcheck * 154))
        For Each pieces In everyPiece
            If firstMoveCheck = False Then
                If piece.Left = pieces.Left And piece.Top + (operatorcheck * 77) = pieces.Top Then
                    newScoreMove = 0
                    PawnMoveChecker()
                ElseIf piece.Left = pieces.Left And piece.Top + (operatorcheck * 154) = pieces.Top Then
                    newScoreMove = 1
                    PawnMoveChecker()
                Else
                    newScoreMove = 2
                    PawnMoveChecker()
                End If
            Else
                If piece.Left = pieces.Left And piece.Top + (operatorcheck * 77) = pieces.Top Then
                    newScoreMove = 0
                    PawnMoveChecker()
                Else
                    newScoreMove = 1
                    PawnMoveChecker()
                End If
            End If     
        Next
        For Each pieces In bpieces
            ChessBoard.Button3.Location = New Point(piece.Left + 77, piece.Top - 77)
            ChessBoard.Button4.Location = New Point(piece.Left - 77, piece.Top - 77)
            If pieces.Left = piece.Left + 77 And pieces.Top = piece.Top - 77 And colour = Chesscolour.white Then
                If ChessBoard.CheckMode = False Then
                    ChessBoard.Button3.Show()
                End If
            ElseIf pieces.Left = piece.Left - 77 And pieces.Top = piece.Top - 77 And colour = Chesscolour.white Then
                If ChessBoard.CheckMode = False Then
                    ChessBoard.Button4.Show()
                End If
            End If
        Next
        For Each pieces In wpieces
            ChessBoard.Button3.Location = New Point(piece.Left + 77, piece.Top + 77)
            ChessBoard.Button4.Location = New Point(piece.Left - 77, piece.Top + 77)

            If pieces.Left = piece.Left + 77 And pieces.Top = piece.Top + 77 And colour = Chesscolour.black Then
                If ChessBoard.CheckMode = False Then
                    ChessBoard.Button3.Show()
                End If
            ElseIf pieces.Left = piece.Left - 77 And pieces.Top = piece.Top + 77 And colour = Chesscolour.black Then
                If ChessBoard.CheckMode = False Then
                    ChessBoard.Button4.Show()
                End If
            End If
        Next

        If OldScoremove = 0 Then
        ElseIf OldScoremove = 1 Then
            If ChessBoard.CheckMode = False Then
                ChessBoard.Button1.Show()
            End If
        ElseIf OldScoremove = 2 Then
            If ChessBoard.CheckMode = False Then
                ChessBoard.Button1.Show()
                ChessBoard.Button2.Show()
            End If
        End If
            For Each Button In buttonMoves
                If Button.Left > 539 Or Button.Left < 0 Or Button.Top > 539 Or Button.Top < 0 Then
                    Button.Hide()
                End If
            Next
    End Sub
    Public Sub PawnMoveChecker()
        If newScoreMove < OldScoremove Then
            OldScoremove = newScoreMove
        End If
    End Sub
End Class
