Public Class King
    Inherits ChessPiece
    Public kingmoves(7) As Boolean
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal chess_colour As Chesscolour, ByVal piece As Button)
        MyBase.New(X, Y, chess_colour, piece)
    End Sub
    'overrides chesspiece's checkmoves for the king, it first goes to check_checkmate to check for possible moves, when coming back to check against the other it
    ' uses different buttons inorder to not mess up the algorithm, then it checks whether or not to display the buttons based on the results of the algorithm
    Public Overrides Sub CheckMoves()   
        Dim temppostionscore As Integer
        Dim checktheking As New Check_Checkmate(ChessBoard.buttonsToUse)
        Dim checkplaceholder(7) As Boolean
        ChessBoard.KingPiece = piece
        If ChessBoard.CheckMode = True Then
            ChessBoard.buttonmoves(0).Location = New Point(X - 77, Y)
            ChessBoard.buttonmoves(1).Location = New Point(X - 77, Y + 77)
            ChessBoard.buttonmoves(2).Location = New Point(X, Y + 77)
            ChessBoard.buttonmoves(3).Location = New Point(X + 77, Y + 77)
            ChessBoard.buttonmoves(4).Location = New Point(X + 77, Y)
            ChessBoard.buttonmoves(5).Location = New Point(X + 77, Y - 77)
            ChessBoard.buttonmoves(6).Location = New Point(X, Y - 77)
            ChessBoard.buttonmoves(7).Location = New Point(X - 77, Y - 77)
        Else
            ChessBoard.buttonmoves(64).Location = New Point(X - 77, Y)
            ChessBoard.buttonmoves(65).Location = New Point(X - 77, Y + 77)
            ChessBoard.buttonmoves(66).Location = New Point(X, Y + 77)
            ChessBoard.buttonmoves(67).Location = New Point(X + 77, Y + 77)
            ChessBoard.buttonmoves(68).Location = New Point(X + 77, Y)
            ChessBoard.buttonmoves(69).Location = New Point(X + 77, Y - 77)
            ChessBoard.buttonmoves(70).Location = New Point(X, Y - 77)
            ChessBoard.buttonmoves(71).Location = New Point(X - 77, Y - 77)
        End If
        If colour = ChessPiece.Chesscolour.white Then
            pieces1 = wpieces
        Else
            pieces1 = bpieces
        End If
        For counter = 0 To 7
            For Each pieces In pieces1
                tx = 0
                ty = 0
                temppostionscore = counter
                rearrangechecks(temppostionscore)
                If pieces.Left = piece.Left + tx And pieces.Top = piece.Top + ty Then
                    kingmoves(counter) = False
                    Exit For
                Else
                    kingmoves(counter) = True
                End If
            Next
        Next
        If ChessBoard.CheckMode = False Then
            For i = 0 To 7
                ChessBoard.buttonsToUse = ChessBoard.KingButtons(i)
                checkplaceholder(i) = checktheking.Check_King()

            Next
            If kingmoves(0) = True And checkplaceholder(0) = False Then
                ChessBoard.buttonmoves(64).Show()
            End If
            If kingmoves(1) = True And checkplaceholder(1) = False Then
                ChessBoard.buttonmoves(65).Show()
            End If
            If kingmoves(2) = True And checkplaceholder(2) = False Then
                ChessBoard.buttonmoves(66).Show()
            End If
            If kingmoves(3) = True And checkplaceholder(3) = False Then
                ChessBoard.buttonmoves(67).Show()
            End If
            If kingmoves(4) = True And checkplaceholder(4) = False Then
                ChessBoard.buttonmoves(68).Show()
            End If
            If kingmoves(5) = True And checkplaceholder(5) = False Then
                ChessBoard.buttonmoves(69).Show()
            End If
            If kingmoves(6) = True And checkplaceholder(6) = False Then
                ChessBoard.buttonmoves(70).Show()
            End If
            If kingmoves(7) = True And checkplaceholder(7) = False Then
                ChessBoard.buttonmoves(71).Show()
            End If
            For Each Button In ChessBoard.buttonmoves
                If Button.Left > 539 Or Button.Left < 0 Or Button.Top > 539 Or Button.Top < 0 Then
                    Button.Hide()
                End If
            Next
        End If

        For Each p In kingmoves
            p = False
        Next
    End Sub
    'Sets the next button to check based on the loop
    Public Overrides Sub rearrangechecks(ByRef temppostionscore As Integer)
        If temppostionscore = 0 Then
            tx = -77
        ElseIf temppostionscore = 1 Then
            tx = -77
            ty = +77
        ElseIf temppostionscore = 2 Then
            ty = +77
        ElseIf temppostionscore = 3 Then
            tx = +77
            ty = +77
        ElseIf temppostionscore = 4 Then
            tx = +77
        ElseIf temppostionscore = 5 Then
            tx = +77
            ty = -77
        ElseIf temppostionscore = 6 Then
            ty = -77
        ElseIf temppostionscore = 7 Then
            tx = -77
            ty = -77
        End If
    End Sub
End Class