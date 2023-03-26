Public Class Check_Checkmate
    Inherits ChessBoard
    Public chesscolour As ChessPiece.Chesscolour
    Public resultID As Integer
    Public WBishop(1), BBishop(1), WKnight(1), BKnight(1), KingSelectedPieces, CheckingKing, check_Buttons(resultID), UpMoveButton(), RightMoveButton(), LeftMoveButton(), DownMoveButton(), UpRightMoveButton(), DownRightMoveButton(), UpLeftMoveButton(), DownLeftMoveButton() As Button
    Public PawnSelectedPieces, KnightSelectedPieces, RookSelectedPieces, QueensSelectedPieces, BishopSelectedPieces As New List(Of Button)
    Public checking As Boolean
    Public king, buttonToCheck As Button
    Public TempButtonX_Causing_Check, TempButtonY_Causing_Check As New List(Of Integer)
    Public Sub New(ByRef kingpiece As Button, ByVal button As Button)
        king = kingpiece
        buttonToCheck = button
    End Sub
    'Finds out which turn has ended and checks the respective king by going through each piece to see if the it is in check or checkmate or where the king can legally move
    Public Function Check_King()
        Dim check1, check2, check3, check4, check5, check6, check7, check8 As Boolean
        Dim result As Boolean
        ChessBoard.checkingForCheck = False
        ChessBoard.CheckMode = True
        If ChessBoard.colourOfPieces = "white" Then
            king = ChessBoard.WKing
            PawnSelectedPieces = ChessBoard.CheckBPawn
            RookSelectedPieces = ChessBoard.CheckBRook
            BishopSelectedPieces = ChessBoard.CheckBBishop
            QueensSelectedPieces = ChessBoard.CheckBQueen
            KnightSelectedPieces = ChessBoard.CheckBKnight
            KingSelectedPieces = ChessBoard.BKing
            FirstCheckNumber = 0
            chesscolour = ChessPiece.Chesscolour.black
        Else
            king = ChessBoard.BKing
            PawnSelectedPieces = ChessBoard.CheckWPawn
            RookSelectedPieces = ChessBoard.CheckWRook
            BishopSelectedPieces = ChessBoard.CheckWBishop
            QueensSelectedPieces = ChessBoard.CheckWQueen
            KnightSelectedPieces = ChessBoard.CheckWKnight
            KingSelectedPieces = ChessBoard.WKing
            FirstCheckNumber = 8
            chesscolour = ChessPiece.Chesscolour.white
        End If
        check1 = CheckPawnsAgainstKing()
        check2 = CheckRooksAgainstKing()
        check3 = CheckBishopsAgainstKing()
        check4 = CheckQueenAgainstKing()
        check5 = CheckKnightsAgainstKing()
        check6 = CheckKingsAgainstKing()
        check7 = CheckBorderAgainstKing()
        If ChessBoard.checkKing = True Then
            ChessBoard.checkKing = False
        Else
            check8 = CheckKingAgainstOtherPieces()
        End If
        If check1 = True Or check2 = True Or check3 = True Or check4 = True Or check5 = True Or check6 = True Or check7 = True Or check8 = True Then
            result = True
        Else
            result = False
        End If
        ChessBoard.CheckMode = False
        PawnBishop = False
        PawnQueen = False
        PawnRook = False
        clearbuttons()
        Return result
    End Function
    'This checks if their is a piece blocking the king infront of it when checking for check and checkmate
    Public Function CheckKingAgainstOtherPieces()
        Dim result As Integer
        For Each piece In ChessBoard.Allpieces
            If piece.Left = buttonToCheck.Left And piece.Top = buttonToCheck.Top Then
                result = True
            End If
        Next
        Return result
    End Function
    'This checks for if any of the move buttons for king are past the border
    Public Function CheckBorderAgainstKing()
        Dim result As Boolean
        If buttonToCheck.Left > 539 Or buttonToCheck.Left < 0 Or buttonToCheck.Top > 539 Or buttonToCheck.Top < 0 Then
            result = True
        Else
            result = False
        End If
        Return result
    End Function
    'This checks the king against each move that a pawn can possibly make
    Public Function CheckPawnsAgainstKing()
        Dim result As Boolean = False
        For Each piece In PawnSelectedPieces
            Dim Pawns As New Pawn(piece.Left, piece.Top, chesscolour, piece, FirstCheck(FirstCheckNumber))
            FirstCheckNumber += 1
            Pawns.SetColour()
            Pawns.CheckMoves()
            chess_piece = piece
            If (buttonToCheck.Left = ChessBoard.Button3.Left And buttonToCheck.Top = ChessBoard.Button3.Top) Or (buttonToCheck.Left = ChessBoard.Button4.Left And buttonToCheck.Top = ChessBoard.Button4.Top) Then
                result = True
            End If
            If (ChessBoard.Button3.Left = king.Left And ChessBoard.Button3.Top = king.Top) Or (ChessBoard.Button4.Left = king.Left And ChessBoard.Button4.Top = king.Top) Then
                ChessBoard.checkingForCheck = True
                ChessBoard.Piece_Causing_Check = piece
                Dim counter As Integer = 0
                TempButtonX_Causing_Check.Add(CheckPawnsForCollisionWithKing(counter))
                counter = 1
                TempButtonY_Causing_Check.Add(CheckPawnsForCollisionWithKing(counter))
                ChessBoard.Buttonxvalue(TempButtonX_Causing_Check)
                ChessBoard.Buttonyvalue(TempButtonY_Causing_Check)
            End If
        Next
        Return result
    End Function
    'This checks if a pawn's move will move to the king or not, if it does it will save the coordinates of the button and add them to a list
    Private Function CheckPawnsForCollisionWithKing(counter)
        Dim ButtonCoordtouse As Integer
        If counter = 0 Then
            If (ChessBoard.Button3.Left = king.Left And ChessBoard.Button3.Top = king.Top) Then
                ButtonCoordtouse = ChessBoard.Button3.Left
            ElseIf (ChessBoard.Button4.Left = king.Left And ChessBoard.Button4.Top = king.Top) Then
                ButtonCoordtouse = ChessBoard.Button4.Left
            End If
        ElseIf counter = 1 Then
            If (ChessBoard.Button3.Left = king.Left And ChessBoard.Button3.Top = king.Top) Then
                ButtonCoordtouse = ChessBoard.Button3.Top
            ElseIf (ChessBoard.Button4.Left = king.Left And ChessBoard.Button4.Top = king.Top) Then
                ButtonCoordtouse = ChessBoard.Button4.Top
            End If
        End If
        Return ButtonCoordtouse
    End Function
    'This is used by the checks for the rook, bishops and queen, it is used to check if one of the pieces will cause check or if one of the moves collides with the king
    Private Function CheckPieceMoves(piece, result)
        If check_Buttons.Length - 1 <> 0 Then
            For Each PieceMove In check_Buttons
                If PieceMove.Left = buttonToCheck.Left And PieceMove.Top = buttonToCheck.Top Then
                    result = True
                End If
                If PieceMove.Left = king.Left And PieceMove.Top = king.Top Then
                    ChessBoard.checkingForCheck = True
                    TempButtonX_Causing_Check.Add(piece.Left)
                    TempButtonY_Causing_Check.Add(piece.Top)
                    For Each member In check_Buttons
                        TempButtonX_Causing_Check.Add(member.Left)
                        TempButtonY_Causing_Check.Add(member.Top)
                    Next
                    ChessBoard.ButtonX_Causing_Check = TempButtonX_Causing_Check
                    ChessBoard.ButtonY_Causing_Check = TempButtonY_Causing_Check
                End If
            Next
        End If
        Return result
    End Function
    'This checks the king against each move that a rook can possibly make
    Public Function CheckRooksAgainstKing()
        Dim result As Boolean = False
        PawnRook = True
        For Each piece In RookSelectedPieces
            Dim Rooks As New Rook(piece.Left, piece.Top, chesscolour, piece)
            Rooks.SetColour()
            Rooks.SetLoopBoundaries()
            Rooks.CheckMoves()
            chess_piece = piece
            For buttoncheck = 0 To 3
                check_Buttons = MoveSelector(buttoncheck, Rooks)
                CheckPieceMoves(piece, result)
            Next
        Next
        Return result
    End Function
    'This checks the king against each move that a bishop can possibly make
    Public Function CheckBishopsAgainstKing()
        Dim result As Boolean = False
        For Each piece In BishopSelectedPieces
            Dim Bishops As New Bishop(piece.Left, piece.Top, chesscolour, piece)
            PawnBishop = True
            Bishops.SetColour()
            Bishops.SetLoopBoundaries()
            Bishops.CheckMoves()
            chess_piece = piece
            For buttoncheck = 4 To 7
                check_Buttons = MoveSelector(buttoncheck, Bishops)
                result = CheckPieceMoves(piece, result)
            Next
        Next
        Return result
    End Function
    'This checks the king against each move that a queen can possibly make
    Public Function CheckQueenAgainstKing()
        Dim result As Boolean = False
        PawnQueen = True
        For Each piece In QueensSelectedPieces
            Dim Queens As New Queen(piece.Left, piece.Top, chesscolour, piece)
            Queens.SetColour()
            Queens.SetLoopBoundaries()
            Queens.CheckMoves()
            chess_piece = piece
            For buttoncheck = 0 To 7
                check_Buttons = MoveSelector(buttoncheck, Queens)
                result = CheckPieceMoves(piece, result)
            Next
        Next
        Return result
    End Function
    'This checks the king against each move that a knight can possibly make
    Public Function CheckKnightsAgainstKing()
        Dim result As Boolean = False
        For Each piece In KnightSelectedPieces
            Dim Knights As New Knight(piece.Left, piece.Top, chesscolour, piece)
            Knights.SetColour()
            Knights.CheckMoves()
            chess_piece = piece
            If (buttonToCheck.Left = ChessBoard.Button1.Left And buttonToCheck.Top = ChessBoard.Button1.Top) Or (buttonToCheck.Left = ChessBoard.Button2.Left And buttonToCheck.Top = ChessBoard.Button2.Top) Or (buttonToCheck.Left = ChessBoard.Button3.Left And buttonToCheck.Top = ChessBoard.Button3.Top) Or (buttonToCheck.Left = ChessBoard.Button4.Left And buttonToCheck.Top = ChessBoard.Button4.Top) Or (buttonToCheck.Left = ChessBoard.Button5.Left And buttonToCheck.Top = ChessBoard.Button5.Top) Or (buttonToCheck.Left = ChessBoard.Button6.Left And buttonToCheck.Top = ChessBoard.Button6.Top) Or (buttonToCheck.Left = ChessBoard.Button7.Left And buttonToCheck.Top = ChessBoard.Button7.Top) Or (buttonToCheck.Left = ChessBoard.Button8.Left And buttonToCheck.Top = ChessBoard.Button8.Top) Then
                result = True
            End If
            If (ChessBoard.Button1.Left = king.Left And ChessBoard.Button1.Top = king.Top) Or (ChessBoard.Button2.Left = king.Left And ChessBoard.Button2.Top = king.Top) Or (ChessBoard.Button3.Left = king.Left And ChessBoard.Button3.Top = king.Top) Or (ChessBoard.Button4.Left = king.Left And ChessBoard.Button4.Top = king.Top) Or (ChessBoard.Button5.Left = king.Left And ChessBoard.Button5.Top = king.Top) Or (ChessBoard.Button6.Left = king.Left And ChessBoard.Button6.Top = king.Top) Or (ChessBoard.Button7.Left = king.Left And ChessBoard.Button7.Top = king.Top) Or (ChessBoard.Button8.Left = king.Left And ChessBoard.Button8.Top = king.Top) Then
                ChessBoard.checkingForCheck = True
                ChessBoard.Piece_Causing_Check = piece
                Dim counter As Integer
                TempButtonX_Causing_Check.Add(piece.Left)
                TempButtonY_Causing_Check.Add(piece.Top)
                TempButtonX_Causing_Check.Add(CheckKnightsForCollisionWithKing(counter))
                counter = 1
                TempButtonY_Causing_Check.Add(CheckKnightsForCollisionWithKing(counter))
                ChessBoard.ButtonX_Causing_Check = TempButtonX_Causing_Check
                ChessBoard.ButtonY_Causing_Check = TempButtonY_Causing_Check
            End If
        Next
        Return result
    End Function
    'This checks if a knights's move will move to the king or not, if it does it will save the coordinates of the button and add them to a list
    Private Function CheckKnightsForCollisionWithKing(counter)
        Dim ButtonCoordToUse As Integer = Nothing
        If counter = 0 Then
            For i = 0 To 7
                If (ChessBoard.buttonmoves(i).Left = king.Left And ChessBoard.buttonmoves(i).Top = king.Top) Then
                    ButtonCoordToUse = ChessBoard.buttonmoves(i).Left
                End If
            Next
        ElseIf counter = 1 Then
            For i = 0 To 7
                If (ChessBoard.buttonmoves(i).Left = king.Left And ChessBoard.buttonmoves(i).Top = king.Top) Then
                    ButtonCoordToUse = ChessBoard.buttonmoves(i).Top
                End If
            Next
        End If
        Return ButtonCoordToUse
    End Function
    'This checks the king against each move that the other king can possibly make
    Public Function CheckKingsAgainstKing()
        ChessBoard.Button1.Location = New Point(KingSelectedPieces.Left - 77, KingSelectedPieces.Top)
        ChessBoard.Button2.Location = New Point(KingSelectedPieces.Left - 77, KingSelectedPieces.Top + 77)
        ChessBoard.Button3.Location = New Point(KingSelectedPieces.Left, KingSelectedPieces.Top + 77)
        ChessBoard.Button4.Location = New Point(KingSelectedPieces.Left + 77, KingSelectedPieces.Top + 77)
        ChessBoard.Button5.Location = New Point(KingSelectedPieces.Left + 77, KingSelectedPieces.Top)
        ChessBoard.Button6.Location = New Point(KingSelectedPieces.Left + 77, KingSelectedPieces.Top - 77)
        ChessBoard.Button7.Location = New Point(KingSelectedPieces.Left, KingSelectedPieces.Top - 77)
        ChessBoard.Button8.Location = New Point(KingSelectedPieces.Left - 77, KingSelectedPieces.Top - 77)
        Dim result As Boolean = False
        If (buttonToCheck.Left = ChessBoard.Button1.Left And buttonToCheck.Top = ChessBoard.Button1.Top) Or (buttonToCheck.Left = ChessBoard.Button2.Left And buttonToCheck.Top = ChessBoard.Button2.Top) Or (buttonToCheck.Left = ChessBoard.Button3.Left And buttonToCheck.Top = ChessBoard.Button3.Top) Or (buttonToCheck.Left = ChessBoard.Button4.Left And buttonToCheck.Top = ChessBoard.Button4.Top) Or (buttonToCheck.Left = ChessBoard.Button5.Left And buttonToCheck.Top = ChessBoard.Button5.Top) Or (buttonToCheck.Left = ChessBoard.Button6.Left And buttonToCheck.Top = ChessBoard.Button6.Top) Or (buttonToCheck.Left = ChessBoard.Button7.Left And buttonToCheck.Top = ChessBoard.Button7.Top) Or (buttonToCheck.Left = ChessBoard.Button8.Left And buttonToCheck.Top = ChessBoard.Button8.Top) Then
            result = True
        End If
        Return result
    End Function
    'This is for the rook, bishop and queen and sets the lists that were find out in checkmove from chesspiece and puts them into an array to use for checking
    Public Function MoveSelector(buttoncheck, rooks)
        Dim result(resultID) As Button
        If buttoncheck = 0 Then
            UpMoveButton = rooks.UpMoveButtonsCheck.ToArray()
            resultID = UpMoveButton.Length
            result = UpMoveButton
            rooks.UpMoveButtonsCheck.Clear()
        ElseIf buttoncheck = 1 Then
            RightMoveButton = rooks.RightMoveButtonsCheck.ToArray()
            resultID = RightMoveButton.Length
            result = RightMoveButton
            rooks.RightMoveButtonsCheck.Clear()
        ElseIf buttoncheck = 2 Then
            LeftMoveButton = rooks.LeftMoveButtonsCheck.ToArray()
            resultID = LeftMoveButton.Length
            result = LeftMoveButton
            rooks.LeftMoveButtonsCheck.Clear()
        ElseIf buttoncheck = 3 Then
            DownMoveButton = rooks.DownMoveButtonsCheck.ToArray()
            resultID = DownMoveButton.Length
            result = DownMoveButton
            rooks.DownMoveButtonsCheck.Clear()
        ElseIf buttoncheck = 4 Then
            UpRightMoveButton = rooks.UpRightMoveButtonsCheck.ToArray()
            resultID = UpRightMoveButton.Length
            result = UpRightMoveButton
            rooks.UpRightMoveButtonsCheck.Clear()
        ElseIf buttoncheck = 5 Then
            DownRightMoveButton = rooks.DownRightMoveButtonsCheck.ToArray()
            resultID = DownRightMoveButton.Length
            result = DownRightMoveButton
            rooks.DownRightMoveButtonsCheck.Clear()
        ElseIf buttoncheck = 6 Then
            DownLeftMoveButton = rooks.downLeftMoveButtonsCheck.ToArray()
            resultID = DownLeftMoveButton.Length
            result = DownLeftMoveButton
            rooks.DownLeftMoveButtonsCheck.Clear()
        ElseIf buttoncheck = 7 Then
            UpLeftMoveButton = rooks.upleftMoveButtonsCheck.ToArray()
            resultID = UpLeftMoveButton.Length
            result = UpLeftMoveButton
            rooks.UpLeftMoveButtonsCheck.Clear()
        End If
        Return result
    End Function
End Class