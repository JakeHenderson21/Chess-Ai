Public Class Check_Checkmate
    Inherits ChessBoard
    Public chesscolour As ChessPiece.Chesscolour
    Public resultID As Integer
    Public WBishop(1), BBishop(1), WKnight(1), BKnight(1), KingSelectedPieces, CheckingKing, check_Buttons(resultID), UpMoveButton(), RightMoveButton(), LeftMoveButton(), DownMoveButton(), UpRightMoveButton(), DownRightMoveButton(), UpLeftMoveButton(), DownLeftMoveButton(), buttontoUse, everyPiece(31) As Button
    Public PawnSelectedPieces, KnightSelectedPieces, RookSelectedPieces, QueensSelectedPieces, BishopSelectedPieces As New List(Of Button)
    Public checking As Boolean
    Public TempButtonX_Causing_Check, TempButtonY_Causing_Check As New List(Of Integer)
    'Initisles arrays for the buttons
    Public Sub New(ByVal buttons)
        If ChessBoard.colourOfPieces = "white" Then
            ChessBoard.KingPiece = ChessBoard.WKing
            FirstCheckNumber = 0
            chesscolour = ChessPiece.Chesscolour.black
        Else
            ChessBoard.KingPiece = ChessBoard.BKing
            FirstCheckNumber = 8
            chesscolour = ChessPiece.Chesscolour.white
        End If
        PawnSelectedPieces = GetPawns()
        RookSelectedPieces = GetRooks()
        BishopSelectedPieces = GetBishops()
        QueensSelectedPieces = GetQueen()
        KnightSelectedPieces = GetKnights()
        KingSelectedPieces = GetKing()
    End Sub
    Public Sub SetButtontoUse(input)
        buttontoUse = input
    End Sub
    Public Sub SetAllPieces(input)
        everyPiece = input
    End Sub

    'Finds out which turn has ended and checks the respective king by going through each piece to see if the it is in check or checkmate or where the king can legally move
    Public Function Check_King()
        Dim check1, check2, check3, check4, check5, check6, check7, check8 As Boolean
        Dim result As Boolean
        ChessBoard.checkingForCheck = False
        ChessBoard.CheckMode = True

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
        Return result
    End Function
    'This checks if their is a piece blocking the king infront of it when checking for check and checkmate
    Public Function CheckKingAgainstOtherPieces()
        Dim result As Integer
        For Each piece In everyPiece
            If piece.Left = buttontoUse.Left And piece.Top = buttontoUse.Top Then
                result = True
            End If
        Next
        Return result
    End Function
    'This checks for if any of the move buttons for king are past the border
    Public Function CheckBorderAgainstKing()
        Dim result As Boolean
        If buttontoUse.Left > 539 Or buttontoUse.Left < 0 Or buttontoUse.Top > 539 Or buttontoUse.Top < 0 Then
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
            If (buttontoUse.Left = ChessBoard.buttonmoves(2).Left And buttontoUse.Top = ChessBoard.buttonmoves(2).Top) Or (buttontoUse.Left = ChessBoard.buttonmoves(3).Left And buttontoUse.Top = ChessBoard.buttonmoves(3).Top) Then
                result = True
            End If
            If (ChessBoard.buttonmoves(2).Left = ChessBoard.KingPiece.Left And ChessBoard.buttonmoves(2).Top = ChessBoard.KingPiece.Top) Or (ChessBoard.buttonmoves(3).Left = ChessBoard.KingPiece.Left And ChessBoard.buttonmoves(3).Top = ChessBoard.KingPiece.Top) Then
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
    Private Function CheckPawnsForCollisionWithKing(counter)
        Dim ButtonCoordtouse As Integer
        If counter = 0 Then
            If (ChessBoard.buttonmoves(2).Left = ChessBoard.KingPiece.Left And ChessBoard.buttonmoves(2).Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordtouse = ChessBoard.buttonmoves(2).Left
            ElseIf (ChessBoard.buttonmoves(3).Left = ChessBoard.KingPiece.Left And ChessBoard.buttonmoves(3).Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordtouse = ChessBoard.buttonmoves(3).Left
            End If
        ElseIf counter = 1 Then
            If (ChessBoard.buttonmoves(2).Left = ChessBoard.KingPiece.Left And ChessBoard.buttonmoves(2).Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordtouse = ChessBoard.buttonmoves(2).Top
            ElseIf (ChessBoard.buttonmoves(3).Left = ChessBoard.KingPiece.Left And ChessBoard.buttonmoves(3).Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordtouse = ChessBoard.buttonmoves(3).Top
            End If
        End If
        Return ButtonCoordtouse
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
                If check_Buttons.Length - 1 <> 0 Then
                    For Each PieceMove In check_Buttons
                        If PieceMove.Left = buttontoUse.Left And PieceMove.Top = buttontoUse.Top Then
                            result = True
                        End If
                        If PieceMove.Left = ChessBoard.KingPiece.Left And PieceMove.Top = ChessBoard.KingPiece.Top Then
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
                If check_Buttons.Length - 1 <> 0 Then
                    For Each PieceMove In check_Buttons
                        If PieceMove.Left = buttontoUse.Left And PieceMove.Top = buttontoUse.Top Then
                            result = True
                        End If
                        If PieceMove.Left = ChessBoard.KingPiece.Left And PieceMove.Top = ChessBoard.KingPiece.Top Then
                            ChessBoard.checkingForCheck = True
                            ChessBoard.Piece_Causing_Check = piece
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
                If check_Buttons.Length - 1 <> 0 Then
                    For Each PieceMove In check_Buttons
                        If PieceMove.Left = buttontoUse.Left And PieceMove.Top = buttontoUse.Top Then
                            result = True
                        End If
                        If PieceMove.Left = ChessBoard.KingPiece.Left And PieceMove.Top = ChessBoard.KingPiece.Top Then
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
            Next
        Next
        Return result
    End Function
    'This checks the king against each move that a knight can possibly make
    Public Function CheckKnightsAgainstKing()
        Dim result, foundCheck As Boolean
        For Each piece In KnightSelectedPieces
            Dim Knights As New Knight(piece.Left, piece.Top, chesscolour, piece)
            Knights.SetColour()
            Knights.CheckMoves()
            chess_piece = piece
            For buttonID = 0 To 7
                If (buttontoUse.Left = ChessBoard.buttonmoves(buttonID).Left And buttontoUse.Top = ChessBoard.buttonmoves(buttonID).Top) And foundCheck = False Then
                    result = True
                    foundCheck = True
                End If
                If (ChessBoard.buttonmoves(buttonID).Left = ChessBoard.KingPiece.Left And ChessBoard.buttonmoves(buttonID).Top = ChessBoard.KingPiece.Top) Then
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
        Next
        Return result
    End Function
    Private Function CheckKnightsForCollisionWithKing(counter)
        Dim ButtonCoordToUse As Integer = Nothing
        For buttonID = 0 To 7
            If (ChessBoard.buttonmoves(buttonID).Left = ChessBoard.KingPiece.Left And ChessBoard.buttonmoves(buttonID).Top = ChessBoard.KingPiece.Top) Then
                If counter = 0 Then
                    ButtonCoordToUse = ChessBoard.buttonmoves(buttonID).Left
                    Exit For
                ElseIf counter = 1 Then
                    ButtonCoordToUse = ChessBoard.buttonmoves(buttonID).Top
                    Exit For
                End If

            End If
        Next
        Return ButtonCoordToUse
    End Function
    'This checks the king against each move that the other king can possibly make
    Public Function CheckKingsAgainstKing()
        ChessBoard.buttonmoves(0).Location = New Point(KingSelectedPieces.Left - 77, KingSelectedPieces.Top)
        ChessBoard.buttonmoves(1).Location = New Point(KingSelectedPieces.Left - 77, KingSelectedPieces.Top + 77)
        ChessBoard.buttonmoves(2).Location = New Point(KingSelectedPieces.Left, KingSelectedPieces.Top + 77)
        ChessBoard.buttonmoves(3).Location = New Point(KingSelectedPieces.Left + 77, KingSelectedPieces.Top + 77)
        ChessBoard.buttonmoves(4).Location = New Point(KingSelectedPieces.Left + 77, KingSelectedPieces.Top)
        ChessBoard.buttonmoves(5).Location = New Point(KingSelectedPieces.Left + 77, KingSelectedPieces.Top - 77)
        ChessBoard.buttonmoves(6).Location = New Point(KingSelectedPieces.Left, KingSelectedPieces.Top - 77)
        ChessBoard.buttonmoves(7).Location = New Point(KingSelectedPieces.Left - 77, KingSelectedPieces.Top - 77)
        Dim result As Boolean = False
        For buttonID = 0 To 7
            If (buttontoUse.Left = ChessBoard.buttonmoves(buttonID).Left And buttontoUse.Top = ChessBoard.buttonmoves(buttonID).Top) Then
                result = True
                Exit For
            End If
        Next
        Return result
    End Function
    'This is for the rook, bishop and queen and sets the lists that were find out in checkmove from chesspiece and puts them into an array to use for checking
    Public Function MoveSelector(buttoncheck, rooks)
        Dim result(resultID) As Button
        If rooks.piece Is ChessBoard.WRook1 Or rooks.piece Is ChessBoard.WRook2 Or rooks.piece Is ChessBoard.BRook1 Or rooks.piece Is ChessBoard.BRook2 Or rooks.piece Is ChessBoard.WQueen Or rooks.piece Is ChessBoard.BQueen And buttoncheck Or ChessBoard.PawnRook = True Or ChessBoard.PawnQueen = True < 4 Then
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
            End If
        End If
        If rooks.piece Is ChessBoard.WBishop1 Or rooks.piece Is ChessBoard.WBishop2 Or rooks.piece Is ChessBoard.BBishop1 Or rooks.piece Is ChessBoard.BBishop2 Or rooks.piece Is ChessBoard.WQueen Or rooks.piece Is ChessBoard.BQueen And buttoncheck >= 4 Or ChessBoard.PawnBishop = True Or ChessBoard.PawnQueen = True Then
            If buttoncheck = 4 Then
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
        End If
        Return result
    End Function
End Class