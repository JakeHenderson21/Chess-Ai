Public Class Check_Checkmate
    Inherits ChessBoard
    Public chesscolour As ChessPiece.Chesscolour
    Public resultID As Integer
    Public WBishop(1), BBishop(1), WKnight(1), BKnight(1), KingSelectedPieces, CheckingKing, check_Buttons(resultID), UpMoveButton(), RightMoveButton(), LeftMoveButton(), DownMoveButton(), UpRightMoveButton(), DownRightMoveButton(), UpLeftMoveButton(), DownLeftMoveButton() As Button
    Public PawnSelectedPieces, KnightSelectedPieces, RookSelectedPieces, QueensSelectedPieces, BishopSelectedPieces As New List(Of Button)
    Public checking As Boolean
    Public TempButtonX_Causing_Check, TempButtonY_Causing_Check As New List(Of Integer)

    'Initisles arrays for the buttons
    Public Sub New()
        'Rework the arrays into lists, will need to to actually save the lists in the main chessboard class so they don't get deleted
    
    End Sub
    'Finds out which turn has ended and checks the respective king by going through each piece to see if the it is in check or checkmate or where the king can legally move
    Public Function Check_King()
        Dim check1, check2, check3, check4, check5, check6, check7, check8 As Boolean
        Dim result As Boolean
        ChessBoard.checkingForCheck = False
        ChessBoard.CheckMode = True
        If ChessBoard.colourOfPieces = "white" Then
            ChessBoard.KingPiece = ChessBoard.WKing
            PawnSelectedPieces = ChessBoard.CheckBPawn
            RookSelectedPieces = ChessBoard.CheckBRook
            BishopSelectedPieces = ChessBoard.CheckBBishop
            QueensSelectedPieces = ChessBoard.CheckBQueen
            KnightSelectedPieces = ChessBoard.CheckBKnight
            KingSelectedPieces = ChessBoard.BKing
            FirstCheckNumber = 0
            chesscolour = ChessPiece.Chesscolour.black
        Else
            ChessBoard.KingPiece = ChessBoard.BKing
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
        Return result
    End Function
    'This checks if their is a piece blocking the king infront of it when checking for check and checkmate
    Public Function CheckKingAgainstOtherPieces()
        Dim result As Integer
        For Each piece In ChessBoard.Allpieces
            If piece.Left = ChessBoard.buttonsToUse.Left And piece.Top = ChessBoard.buttonsToUse.Top Then
                result = True
            End If
        Next
        Return result
    End Function
    'This checks for if any of the move buttons for king are past the border
    Public Function CheckBorderAgainstKing()
        Dim result As Boolean
        If ChessBoard.buttonsToUse.Left > 539 Or ChessBoard.buttonsToUse.Left < 0 Or ChessBoard.buttonsToUse.Top > 539 Or ChessBoard.buttonsToUse.Top < 0 Then
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
            If (ChessBoard.buttonsToUse.Left = ChessBoard.Button3.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button3.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button4.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button4.Top) Then
                result = True
            End If
            If (ChessBoard.Button3.Left = ChessBoard.KingPiece.Left And ChessBoard.Button3.Top = ChessBoard.KingPiece.Top) Or (ChessBoard.Button4.Left = ChessBoard.KingPiece.Left And ChessBoard.Button4.Top = ChessBoard.KingPiece.Top) Then
                ChessBoard.checkingForCheck = True
                ChessBoard.Piece_Causing_Check = piece
                Dim counter As Integer = 0
                TempButtonX_Causing_Check.Add(CheckPawnsForCollisionWithKing(counter))
                counter = 1
                TempButtonY_Causing_Check.Add(CheckPawnsForCollisionWithKing(counter))
                ChessBoard.ButtonX_Causing_Check = TempButtonX_Causing_Check.ToArray
                ChessBoard.ButtonY_Causing_Check = TempButtonY_Causing_Check.ToArray
            End If
        Next
        Return result
    End Function
    Private Function CheckPawnsForCollisionWithKing(counter)
        Dim ButtonCoordtouse As Integer
        If counter = 0 Then
            If (ChessBoard.Button3.Left = ChessBoard.KingPiece.Left And ChessBoard.Button3.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordtouse = ChessBoard.Button3.Left
            ElseIf (ChessBoard.Button4.Left = ChessBoard.KingPiece.Left And ChessBoard.Button4.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordtouse = ChessBoard.Button4.Left
            End If
        ElseIf counter = 1 Then
            If (ChessBoard.Button3.Left = ChessBoard.KingPiece.Left And ChessBoard.Button3.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordtouse = ChessBoard.Button3.Top
            ElseIf (ChessBoard.Button4.Left = ChessBoard.KingPiece.Left And ChessBoard.Button4.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordtouse = ChessBoard.Button4.Top
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
                        If PieceMove.Left = ChessBoard.buttonsToUse.Left And PieceMove.Top = ChessBoard.buttonsToUse.Top Then
                            result = True
                        End If
                        If PieceMove.Left = ChessBoard.KingPiece.Left And PieceMove.Top = ChessBoard.KingPiece.Top Then
                            TempButtonX_Causing_Check.Add(piece.Left)
                            TempButtonY_Causing_Check.Add(piece.Top)
                            For Each member In check_Buttons
                                TempButtonX_Causing_Check.Add(member.Left)
                                TempButtonY_Causing_Check.Add(member.Top)
                            Next
                            ChessBoard.ButtonX_Causing_Check = TempButtonX_Causing_Check.ToArray
                            ChessBoard.ButtonY_Causing_Check = TempButtonY_Causing_Check.ToArray
                        End If
                    Next
                End If
            Next
        Next
        PawnRook = True
        Return result
    End Function
    'This checks the king against each move that a bishop can possibly make
    Public Function CheckBishopsAgainstKing()
        PawnBishop = True
        Dim result As Boolean = False
        For Each piece In BishopSelectedPieces

            Dim Bishops As New Bishop(piece.Left, piece.Top, chesscolour, piece)
            Bishops.SetColour()
            Bishops.SetLoopBoundaries()
            Bishops.CheckMoves()
            chess_piece = piece
            For buttoncheck = 4 To 7
                check_Buttons = MoveSelector(buttoncheck, Bishops)
                If check_Buttons.Length - 1 <> 0 Then
                    For Each PieceMove In check_Buttons
                        If PieceMove.Left = ChessBoard.buttonsToUse.Left And PieceMove.Top = ChessBoard.buttonsToUse.Top Then
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
                            ChessBoard.ButtonX_Causing_Check = TempButtonX_Causing_Check.ToArray
                            ChessBoard.ButtonY_Causing_Check = TempButtonY_Causing_Check.ToArray
                        End If
                    Next
                End If
            Next
        Next
        PawnBishop = False
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
                        If PieceMove.Left = ChessBoard.buttonsToUse.Left And PieceMove.Top = ChessBoard.buttonsToUse.Top Then
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
                            ChessBoard.ButtonX_Causing_Check = TempButtonX_Causing_Check.ToArray
                            ChessBoard.ButtonY_Causing_Check = TempButtonY_Causing_Check.ToArray
                        End If
                    Next
                End If
            Next
        Next
        PawnQueen = False
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
            If (ChessBoard.buttonsToUse.Left = ChessBoard.Button1.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button1.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button2.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button2.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button3.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button3.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button4.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button4.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button5.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button5.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button6.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button6.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button7.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button7.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button8.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button8.Top) Then
                result = True
            End If
            If (ChessBoard.Button1.Left = ChessBoard.KingPiece.Left And ChessBoard.Button1.Top = ChessBoard.KingPiece.Top) Or (ChessBoard.Button2.Left = ChessBoard.KingPiece.Left And ChessBoard.Button2.Top = ChessBoard.KingPiece.Top) Or (ChessBoard.Button3.Left = ChessBoard.KingPiece.Left And ChessBoard.Button3.Top = ChessBoard.KingPiece.Top) Or (ChessBoard.Button4.Left = ChessBoard.KingPiece.Left And ChessBoard.Button4.Top = ChessBoard.KingPiece.Top) Or (ChessBoard.Button5.Left = ChessBoard.KingPiece.Left And ChessBoard.Button5.Top = ChessBoard.KingPiece.Top) Or (ChessBoard.Button6.Left = ChessBoard.KingPiece.Left And ChessBoard.Button6.Top = ChessBoard.KingPiece.Top) Or (ChessBoard.Button7.Left = ChessBoard.KingPiece.Left And ChessBoard.Button7.Top = ChessBoard.KingPiece.Top) Or (ChessBoard.Button8.Left = ChessBoard.KingPiece.Left And ChessBoard.Button8.Top = ChessBoard.KingPiece.Top) Then
                ChessBoard.checkingForCheck = True
                ChessBoard.Piece_Causing_Check = piece
                Dim counter As Integer
                TempButtonX_Causing_Check.Add(CheckKnightsForCollisionWithKing(counter))
                counter = 1
                TempButtonY_Causing_Check.Add(CheckKnightsForCollisionWithKing(counter))
                ChessBoard.ButtonX_Causing_Check = TempButtonX_Causing_Check.ToArray
                ChessBoard.ButtonY_Causing_Check = TempButtonY_Causing_Check.ToArray
            End If
        Next
        Return result
    End Function
    Private Function CheckKnightsForCollisionWithKing(counter)
        Dim ButtonCoordToUse As Integer = Nothing
        If counter = 0 Then
            If (ChessBoard.Button1.Left = ChessBoard.KingPiece.Left And ChessBoard.Button1.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button1.Left
            ElseIf (ChessBoard.Button2.Left = ChessBoard.KingPiece.Left And ChessBoard.Button2.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button2.Left
            ElseIf (ChessBoard.Button3.Left = ChessBoard.KingPiece.Left And ChessBoard.Button3.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button3.Left
            ElseIf (ChessBoard.Button4.Left = ChessBoard.KingPiece.Left And ChessBoard.Button4.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button4.Left
            ElseIf (ChessBoard.Button5.Left = ChessBoard.KingPiece.Left And ChessBoard.Button5.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button5.Left
            ElseIf (ChessBoard.Button6.Left = ChessBoard.KingPiece.Left And ChessBoard.Button6.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button6.Left
            ElseIf (ChessBoard.Button7.Left = ChessBoard.KingPiece.Left And ChessBoard.Button7.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button7.Left
            ElseIf (ChessBoard.Button8.Left = ChessBoard.KingPiece.Left And ChessBoard.Button8.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button8.Left
            End If
        ElseIf counter = 1 Then
            If (ChessBoard.Button1.Left = ChessBoard.KingPiece.Left And ChessBoard.Button1.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button1.Top
            ElseIf (ChessBoard.Button2.Left = ChessBoard.KingPiece.Left And ChessBoard.Button2.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button2.Top
            ElseIf (ChessBoard.Button3.Left = ChessBoard.KingPiece.Left And ChessBoard.Button3.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button3.Top
            ElseIf (ChessBoard.Button4.Left = ChessBoard.KingPiece.Left And ChessBoard.Button4.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button4.Top
            ElseIf (ChessBoard.Button5.Left = ChessBoard.KingPiece.Left And ChessBoard.Button5.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button5.Top
            ElseIf (ChessBoard.Button6.Left = ChessBoard.KingPiece.Left And ChessBoard.Button6.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button6.Top
            ElseIf (ChessBoard.Button7.Left = ChessBoard.KingPiece.Left And ChessBoard.Button7.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button7.Top
            ElseIf (ChessBoard.Button8.Left = ChessBoard.KingPiece.Left And ChessBoard.Button8.Top = ChessBoard.KingPiece.Top) Then
                ButtonCoordToUse = ChessBoard.Button8.Top
            End If
        End If
        Return ButtonCoordToUse
    End Function
    'This checks the king against each move that the other king can possibly make
    Public Function CheckKingsAgainstKing()
        Dim chesscolour As ChessPiece.Chesscolour
        Dim result As Boolean = False
        Dim Kings As New King(KingSelectedPieces.Left, KingSelectedPieces.Top, chesscolour, KingSelectedPieces)
        Kings.SetColour()
        Kings.CheckMoves()
        chess_piece = KingSelectedPieces
        If (ChessBoard.buttonsToUse.Left = ChessBoard.Button1.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button1.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button2.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button2.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button3.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button3.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button4.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button4.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button5.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button5.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button6.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button6.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button7.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button7.Top) Or (ChessBoard.buttonsToUse.Left = ChessBoard.Button8.Left And ChessBoard.buttonsToUse.Top = ChessBoard.Button8.Top) Then
            result = True
        End If
        Return result
    End Function
    'This is for the rook, bishop and queen and sets the lists that were find out in checkmove from chesspiece and puts them into an array to use for checking
    Public Function MoveSelector(buttoncheck, rooks)
        Dim result(resultID) As Button
        If rooks.piece Is ChessBoard.WRook1 Or rooks.piece Is ChessBoard.WRook2 Or rooks.piece Is ChessBoard.BRook1 Or rooks.piece Is ChessBoard.BRook2 Or rooks.piece Is ChessBoard.WQueen Or rooks.piece Is ChessBoard.BQueen And buttoncheck < 4 Then
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
        If rooks.piece Is ChessBoard.WBishop1 Or rooks.piece Is ChessBoard.WBishop2 Or rooks.piece Is ChessBoard.BBishop1 Or rooks.piece Is ChessBoard.BBishop2 Or rooks.piece Is ChessBoard.WQueen Or rooks.piece Is ChessBoard.BQueen And buttoncheck >= 4 Then
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