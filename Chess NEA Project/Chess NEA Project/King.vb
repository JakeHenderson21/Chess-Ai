Public Class King
    Inherits ChessPiece
    Public kingmoves(7) As Boolean

    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal chess_colour As Chesscolour, ByVal piece As Button)
        MyBase.New(X, Y, chess_colour, piece)
    End Sub
    Public Overrides Sub CheckMoves()   
        Dim temppostionscore As Integer
        Dim checktheking As New Check_Checkmate
        Dim checkplaceholder(7) As Boolean
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
                ChessBoard.buttonsToUse = ChessBoard.KingButtons(i)
                checkplaceholder(i) = checktheking.Check_King()
                resetkingbuttonlocations()
            Next

            If kingmoves(0) = True And checkplaceholder(0) = False Then

                ChessBoard.Button65.Show()
            End If
            If kingmoves(1) = True And checkplaceholder(1) = False Then

                ChessBoard.Button66.Show()
            End If
            If kingmoves(2) = True And checkplaceholder(2) = False Then
                ChessBoard.Button67.Show()
            End If
            If kingmoves(3) = True And checkplaceholder(3) = False Then
                ChessBoard.Button68.Show()
            End If
            If kingmoves(4) = True And checkplaceholder(4) = False Then
                ChessBoard.Button69.Show()
            End If
            If kingmoves(5) = True And checkplaceholder(5) = False Then
                ChessBoard.Button70.Show()
            End If
            If kingmoves(6) = True And checkplaceholder(6) = False Then
                ChessBoard.Button71.Show()
            End If
            If kingmoves(7) = True And checkplaceholder(7) = False Then
                ChessBoard.Button72.Show()
            End If
            For Each Button In buttonMoves
                If Button.Left > 539 Or Button.Left < 0 Or Button.Top > 539 Or Button.Top < 0 Then
                    Button.Hide()
                End If
            Next
        End If

        For Each p In kingmoves
            p = False
        Next


    End Sub
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

    Sub resetkingbuttonlocations()
         ChessBoard.Button65.Location = New Point(X - 77, Y)
        ChessBoard.Button66.Location = New Point(X - 77, Y + 77)
        ChessBoard.Button67.Location = New Point(X, Y + 77)
        ChessBoard.Button68.Location = New Point(X + 77, Y + 77)
        ChessBoard.Button69.Location = New Point(X + 77, Y)
        ChessBoard.Button70.Location = New Point(X + 77, Y - 77)
        ChessBoard.Button71.Location = New Point(X, Y - 77)
        ChessBoard.Button72.Location = New Point(X - 77, Y - 77)
    End Sub
End Class
