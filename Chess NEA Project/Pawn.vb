﻿Public Class Pawn
    Inherits ChessPiece
    Public everyPiece(31), PieceButtonToCheck As Button
    Public firstMoveCheck As Boolean
    Public operatorcheck, newScoreMove, OldScoremove As Integer
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal chess_colour As Chesscolour, ByVal piece As Button, ByVal firstMove As Boolean)
        MyBase.New(X, Y, chess_colour, piece)
        firstMoveCheck = firstMove
    End Sub
    'overwrites chesspiece's setcolour to adjust for the pawn
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
    'overrides chesspiece's checkmoves to adjust for the pawn, it checks whether or not the pawn has already moved, if it has it can only move once, if not then 
    ' it can move twice, it also checks if the pawn can move to its left or right if there is a piece it can take.
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
        Dim piecesToCheck(15) As Button
        If colour = Chesscolour.white Then
            ChessBoard.Button3.Location = New Point(piece.Left + 77, piece.Top - 77)
            ChessBoard.Button4.Location = New Point(piece.Left - 77, piece.Top - 77)
            piecesToCheck = bpieces
        Else
            ChessBoard.Button3.Location = New Point(piece.Left + 77, piece.Top + 77)
            ChessBoard.Button4.Location = New Point(piece.Left - 77, piece.Top + 77)
            piecesToCheck = wpieces
        End If
        For Each pieces In piecesToCheck
            If pieces.Left = ChessBoard.Button3.Left And pieces.Top = ChessBoard.Button3.Top Then
                If ChessBoard.CheckMode = False Then
                    If ChessBoard.WKinginCheck = True Or ChessBoard.BKinginCheck = True Then
                        PieceButtonToCheck = ChessBoard.Button3
                        PieceMoveWhenChecked()
                    Else
                        ChessBoard.Button3.Show()
                    End If
                End If
            ElseIf pieces.Left = ChessBoard.Button4.Left And pieces.Top = ChessBoard.Button4.Top Then
                If ChessBoard.CheckMode = False Then
                    If ChessBoard.WKinginCheck = True Or ChessBoard.BKinginCheck = True Then
                        PieceButtonToCheck = ChessBoard.Button4
                        PieceMoveWhenChecked()
                    Else
                        ChessBoard.Button4.Show()
                    End If
                End If
            End If
        Next
        If OldScoremove = 0 Then
        ElseIf OldScoremove = 1 Then
            If ChessBoard.CheckMode = False Then
                If ChessBoard.WKinginCheck = True Or ChessBoard.BKinginCheck = True Then
                    PieceButtonToCheck = ChessBoard.Button1
                    PieceMoveWhenChecked()
                Else
                    ChessBoard.Button1.Show()
                End If
            End If
        ElseIf OldScoremove = 2 Then
            If ChessBoard.CheckMode = False Then
                If ChessBoard.WKinginCheck = True Or ChessBoard.BKinginCheck = True Then
                    PieceButtonToCheck = ChessBoard.Button1
                    PieceMoveWhenChecked()
                    PieceButtonToCheck = ChessBoard.Button2
                    PieceMoveWhenChecked()
                Else
                    ChessBoard.Button1.Show()
                    ChessBoard.Button2.Show()
                End If
            End If
        End If
        For Each Button In ChessBoard.buttonmoves
            If Button.Left > 539 Or Button.Left < 0 Or Button.Top > 539 Or Button.Top < 0 Then
                Button.Hide()
            End If
        Next
    End Sub
    'sets the scoremove for how far it can move
    Public Sub PawnMoveChecker()
        If newScoreMove < OldScoremove Then
            OldScoremove = newScoreMove
        End If
    End Sub
    'If a piece can protect the king with a certain move, this move will be displayed for the user to play
    Protected Overrides Sub PieceMoveWhenChecked()
        Dim totalbuttonchecks As Integer
        If ButtonX_Causing_Check.Count > 8 Then
            totalbuttonchecks = 8
        Else
            totalbuttonchecks = ButtonX_Causing_Check.Count - 1
        End If
        For i = 1 To totalbuttonchecks - 1
            If ButtonX_Causing_Check(i) = PieceButtonToCheck.Left And ButtonY_Causing_Check(i) = PieceButtonToCheck.Top Then
                PieceButtonToCheck.Show()
            End If
        Next
        If ChessBoard.ButtonX_Causing_Check(0) = PieceButtonToCheck.Left And ChessBoard.ButtonY_Causing_Check(0) = PieceButtonToCheck.Top Then
            PieceButtonToCheck.Show()
        End If
    End Sub
End Class