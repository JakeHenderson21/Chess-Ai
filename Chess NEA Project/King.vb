﻿Public Class King
    Inherits ChessPiece
    Public kingmoves(7) As Boolean
    Private kingPiece, buttonToCheck, kingButtonMoves(7) As Button
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal chess_colour As Chesscolour, ByVal piece As Button, ByVal kingButtons() As Button)
        MyBase.New(X, Y, chess_colour, piece)
        kingButtonMoves = kingButtons
    End Sub
    'overrides chesspiece's checkmoves for the king, it first goes to check_checkmate to check for possible moves, when coming back to check against the other it
    ' uses different buttons inorder to not mess up the algorithm, then it checks whether or not to display the buttons based on the results of the algorithm
    Public Overrides Sub CheckMoves()
        Dim temppostionscore As Integer
        Dim checkplaceholder(7) As Boolean
        ChessBoard.KingPiece = piece
        If ChessBoard.CheckMode = True Then
            ChessBoard.Button1.Location = New Point(X - 77, Y)
            ChessBoard.Button2.Location = New Point(X - 77, Y + 77)
            ChessBoard.Button3.Location = New Point(X, Y + 77)
            ChessBoard.Button4.Location = New Point(X + 77, Y + 77)
            ChessBoard.Button5.Location = New Point(X + 77, Y)
            ChessBoard.Button6.Location = New Point(X + 77, Y - 77)
            ChessBoard.Button7.Location = New Point(X, Y - 77)
            ChessBoard.Button8.Location = New Point(X - 77, Y - 77)
        Else
            ChessBoard.Button65.Location = New Point(X - 77, Y)
            ChessBoard.Button66.Location = New Point(X - 77, Y + 77)
            ChessBoard.Button67.Location = New Point(X, Y + 77)
            ChessBoard.Button68.Location = New Point(X + 77, Y + 77)
            ChessBoard.Button69.Location = New Point(X + 77, Y)
            ChessBoard.Button70.Location = New Point(X + 77, Y - 77)
            ChessBoard.Button71.Location = New Point(X, Y - 77)
            ChessBoard.Button72.Location = New Point(X - 77, Y - 77)
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
                buttonToCheck = kingButtonMoves(i)
                Dim checktheking As New Check_Checkmate(piece, buttonToCheck)
                checkplaceholder(i) = checktheking.Check_King()
                resetkingbuttonlocations()
            Next
            For i = 0 To 7
                If kingmoves(i) = True And checkplaceholder(i) = False Then
                    kingButtonMoves(i).Show()
                End If
            Next
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
    'resets the king button location incase they have moved
    Public Sub resetkingbuttonlocations()
        ChessBoard.clearbuttons()
        ChessBoard.Button65.Location = New Point(piece.Left - 77, piece.Top)
        ChessBoard.Button66.Location = New Point(piece.Left - 77, piece.Top + 77)
        ChessBoard.Button67.Location = New Point(piece.Left, piece.Top + 77)
        ChessBoard.Button68.Location = New Point(piece.Left + 77, piece.Top + 77)
        ChessBoard.Button69.Location = New Point(piece.Left + 77, piece.Top)
        ChessBoard.Button70.Location = New Point(piece.Left + 77, piece.Top - 77)
        ChessBoard.Button71.Location = New Point(piece.Left, piece.Top - 77)
        ChessBoard.Button72.Location = New Point(piece.Left - 77, piece.Top - 77)
    End Sub
End Class