Public Class Knight
    Inherits ChessPiece
    Public knightmoves(7) As Boolean
    Public PieceButtonToCheck As Button
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal chess_colour As Chesscolour, ByVal piece As Button)
        MyBase.New(X, Y, chess_colour, piece)
    End Sub
    'overrides chesspiece's checkmove for knight's movements, it checks whether not each button can be visible and then shows which are available
    Public Overrides Sub CheckMoves()
        Dim temppostionscore As Integer
        ChessBoard.Button1.Location = New Point(X - 77, Y - 154)
        ChessBoard.Button2.Location = New Point(X + 77, Y - 154)
        ChessBoard.Button3.Location = New Point(X + 154, Y - 77)
        ChessBoard.Button4.Location = New Point(X + 154, Y + 77)
        ChessBoard.Button5.Location = New Point(X - 77, Y + 154)
        ChessBoard.Button6.Location = New Point(X - 154, Y + 77)
        ChessBoard.Button7.Location = New Point(X + 77, Y + 154)
        ChessBoard.Button8.Location = New Point(X - 154, Y - 77)
        If colour = Chesscolour.black Then
            pieces1 = bpieces
        ElseIf colour = Chesscolour.white Then
            pieces1 = wpieces
        End If
        For counter = 0 To 7
            For Each pieces In pieces1
                temppostionscore = counter
                rearrangechecks(temppostionscore)
                If pieces.Left = piece.Left + tx And pieces.Top = piece.Top + ty Then
                    knightmoves(counter) = False
                    Exit For
                Else
                    knightmoves(counter) = True
                End If
            Next
        Next
        If ChessBoard.CheckMode = False Then
            If ChessBoard.WKinginCheck = True Or ChessBoard.BKinginCheck = True Then
                For i = 0 To 7
                    If knightmoves(i) = True Then
                        PieceButtonToCheck = ChessBoard.buttonmoves(i)
                        PieceMoveWhenChecked()
                    End If
                Next
            Else
                For i = 0 To 7
                    If knightmoves(i) = True Then
                        ChessBoard.buttonmoves(i).Show()
                    End If
                Next
            End If
            For Each Button In ChessBoard.buttonmoves
                If Button.Left > 539 Or Button.Left < 0 Or Button.Top > 539 Or Button.Top < 0 Then
                    Button.Hide()
                End If
            Next
        End If
        For Each p In knightmoves
            p = False
        Next
    End Sub
    'Sets the next button to check based on the loop
    Public Overrides Sub rearrangechecks(ByRef temppostionscore As Integer)
        If temppostionscore = 0 Then
            tx = -77
            ty = -154
        ElseIf temppostionscore = 1 Then
            tx = +77
            ty = -154
        ElseIf temppostionscore = 2 Then
            tx = +154
            ty = -77
        ElseIf temppostionscore = 3 Then
            tx = +154
            ty = +77
        ElseIf temppostionscore = 4 Then
            tx = -77
            ty = +154
        ElseIf temppostionscore = 5 Then
            tx = -154
            ty = +77
        ElseIf temppostionscore = 6 Then
            tx = +77
            ty = +154
        ElseIf temppostionscore = 7 Then
            tx = -154
            ty = -77
        End If
    End Sub
    Protected Overrides Sub PieceMoveWhenChecked()
        Dim totalbuttonchecks As Integer
        If ButtonX_Causing_Check.Count > 8 Then
            totalbuttonchecks = 8
        Else
            totalbuttonchecks = ButtonX_Causing_Check.Count - 1
        End If
        For i = 0 To totalbuttonchecks
            If ButtonX_Causing_Check(i) = PieceButtonToCheck.Left And ButtonY_Causing_Check(i) = PieceButtonToCheck.Top Then
                PieceButtonToCheck.Show()
            End If
        Next
        If ButtonX_Causing_Check(0) = PieceButtonToCheck.Left And ButtonY_Causing_Check(0) = PieceButtonToCheck.Top Then
            PieceButtonToCheck.Show()
        End If
    End Sub
End Class