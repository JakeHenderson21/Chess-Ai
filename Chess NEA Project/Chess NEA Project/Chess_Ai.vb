Imports System.IO
Public Class Chess_Ai
    Private LegalMoveNames, LegalButtonNames As New List(Of Button)
    Private LegalMoveXCoordinates, LegalMoveYCoordinates, LegalButtonXCoordinates, LegalButtonYCoordinates As New List(Of Integer)
    Private NumberlegalMoves, BestScoreMove, TotalBestMovesMade As Integer
    Private InputLayer(383) As Integer
    Private HiddenLayer(255, 3) As Double
    Private Outputlayer(203) As Double
    Private InputToHiddenLayerWeights(383, 255) As Double
    Private HiddenLayerWeights(255, 255, 2) As Double
    Private HiddenToOutputLayerWeights(255, 203) As Double
    Private HiddenBias(255, 3) As Double
    Private OutputBias(203) As Double
    Private FirstCheckNumber As Integer
    Private StartOfLoop, EndofLoop As Integer
    Private BestValue As Integer
    Private AlreadyChecked As Boolean
    Private PieceOptions(203), ButtonOptions(203), BestScoreName, BestScoreButton As Button
    Private EndofInitialLoop, EndOfButtonLoop As Integer
    Private NumberOfMoves, NumberOfPieces, StartingNumber As Integer
    Enum PieceValue
        Pawn = 5
        Rook = 15
        Bishop = 15
        Knight = 15
        Queen = 30
        King = 100
    End Enum
    Public Sub New()
        Dim buttoncount As Integer
        For i = 0 To 203
            PieceOptions(i) = PieceDeclarer(i)
        Next
        For k = 0 To 5
            NumberOfPieces_Moves(k)
            For i = 0 To NumberOfPieces
                For j = StartingNumber To NumberOfMoves
                    ButtonOptions(buttoncount) = ChessBoard.buttonmoves(j)
                    If buttoncount = 203 Then
                    Else
                        buttoncount += 1
                    End If
                Next
            Next
        Next
        EndOfButtonLoop = EndOfButtonLoop
    End Sub
    Private Sub NumberOfPieces_Moves(k)
        If k = 0 Then
            StartingNumber = 0
            NumberOfPieces = 7
            NumberOfMoves = 3
        ElseIf k = 1 Then
            StartingNumber = 0
            NumberOfPieces = 1
            NumberOfMoves = 27
        ElseIf k = 2 Then
            StartingNumber = 28
            NumberOfPieces = 1
            NumberOfMoves = 55
        ElseIf k = 3 Then
            StartingNumber = 0
            NumberOfPieces = 1
            NumberOfMoves = 7
        ElseIf k = 4 Then
            StartingNumber = 0
            NumberOfPieces = 0
            NumberOfMoves = 55
        ElseIf k = 5 Then
            StartingNumber = 65
            NumberOfPieces = 0
            NumberOfMoves = 7
        End If
    End Sub
    Private Function PieceDeclarer(piece)
        Dim result As Button
        If piece >= 196 Then
            result = ChessBoard.BKing
        ElseIf piece >= 188 Then
            result = ChessBoard.BQueen
        ElseIf piece >= 132 Then
            result = ChessBoard.BKnight2
        ElseIf piece >= 124 Then
            result = ChessBoard.BKnight1
        ElseIf piece >= 116 Then
            result = ChessBoard.BBishop2
        ElseIf piece >= 88 Then
            result = ChessBoard.BBishop1
        ElseIf piece >= 60 Then
            result = ChessBoard.BRook2
        ElseIf piece >= 32 Then
            result = ChessBoard.BRook1
        ElseIf piece >= 28 Then
            result = ChessBoard.BPawn8
        ElseIf piece >= 24 Then
            result = ChessBoard.BPawn7
        ElseIf piece >= 20 Then
            result = ChessBoard.BPawn6
        ElseIf piece >= 16 Then
            result = ChessBoard.BPawn5
        ElseIf piece >= 12 Then
            result = ChessBoard.BPawn4
        ElseIf piece >= 8 Then
            result = ChessBoard.BPawn3
        ElseIf piece >= 4 Then
            result = ChessBoard.BPawn2
        ElseIf piece >= 0 Then
            result = ChessBoard.BPawn1
        End If
        Return result
    End Function
    Public Sub Initilise_Weights_And_Bias()
        Dim randomNumber As New Random
        For i = 0 To 383
            For j = 0 To 255
                Randomize()
                InputToHiddenLayerWeights(i, j) = randomNumber.NextDouble / 100
            Next
        Next
        For k = 0 To 2
            For i = 0 To 255
                For j = 0 To 255
                    Randomize()
                    HiddenLayerWeights(i, j, k) = randomNumber.NextDouble / 100
                Next
            Next
        Next
        For i = 0 To 255
            For j = 0 To 203
                Randomize()
                HiddenToOutputLayerWeights(i, j) = randomNumber.NextDouble / 100
            Next
        Next
        For k = 0 To 3
            For i = 0 To 255
                Randomize()
                HiddenBias(i, k) = randomNumber.Next(80, 90) / 100
            Next
        Next
        For i = 0 To 203
            OutputBias(i) = randomNumber.Next(80, 90) / 100
        Next
    End Sub
    Public Sub NextMoveDecider()
        If AlreadyChecked = False Then
            AlreadyChecked = True
            CheckingForBestMoves()
            CheckIfBestMovePlayed()
        Else
            AlreadyChecked = True
        End If
        
        Dim PieceChecker As New List(Of Button)
        Dim AICount As Integer
        For xcoord = 0 To 7
            For ycoord = 0 To 7
                For PieceType = 0 To 5
                    PieceChecker = PieceTypeIdentifier(PieceType)
                    PieceChecker.ToArray()
                    For Each piece In PieceChecker
                        If piece.Left / 77 = xcoord And piece.Top / 77 = ycoord And PieceType = 6 Then
                            InputLayer(AICount) = -1
                        ElseIf piece.Left / 77 = xcoord And piece.Top / 77 = ycoord Then
                            InputLayer(AICount) = 1
                        Else
                            InputLayer(AICount) = 0
                        End If
                        If AICount >= 383 Then
                        Else
                            AICount += 1
                        End If
                    Next
                    PieceChecker.Clear()
                Next
            Next
        Next
        For i = 0 To 255
            For j = 0 To 383
                HiddenLayer(i, 0) += InputLayer(j) * InputToHiddenLayerWeights(j, i)
            Next
            HiddenLayer(i, 0) -= HiddenBias(i, 0)
            HiddenLayer(i, 0) = SigmoidCalculation(HiddenLayer(i, 0))
        Next
        For k = 1 To 3
            For i = 0 To 255
                For j = 0 To 255
                    HiddenLayer(i, k) += HiddenLayer(j, k - 1) * HiddenLayerWeights(j, i, k - 1)
                Next
                HiddenLayer(i, k) -= HiddenBias(i, k)
                HiddenLayer(i, k) = SigmoidCalculation(HiddenLayer(i, k))
            Next
        Next
        For i = 0 To 203
            For j = 0 To 255
                Outputlayer(i) += HiddenLayer(j, 3) * HiddenToOutputLayerWeights(j, i)
            Next
            Outputlayer(i) -= OutputBias(i)
            Outputlayer(i) = SigmoidCalculation(Outputlayer(i))
        Next

        Dim TempOutput As List(Of Double)
        TempOutput = Outputlayer.ToList
        BestValue = TempOutput.IndexOf(Outputlayer.Max)
        If PieceOptions(BestValue) Is ChessBoard.BBishop1 Then
            BestValue = BestValue
        End If
        If PieceOptions(BestValue) Is ChessBoard.BPawn1 Or PieceOptions(BestValue) Is ChessBoard.BPawn2 Or PieceOptions(BestValue) Is ChessBoard.BPawn3 Or PieceOptions(BestValue) Is ChessBoard.BPawn4 Or PieceOptions(BestValue) Is ChessBoard.BPawn5 Or PieceOptions(BestValue) Is ChessBoard.BPawn6 Or PieceOptions(BestValue) Is ChessBoard.BPawn7 Or PieceOptions(BestValue) Is ChessBoard.BPawn8 Then
            Dim AiPiece As New Pawn(PieceOptions(BestValue).Left, PieceOptions(BestValue).Top, ChessPiece.Chesscolour.black, PieceOptions(BestValue), ChessBoard.FirstCheck(FirstCheckIdentifier))
            AiPieceMover(AiPiece)
            FirstCheckNumber = FirstCheckIdentifier()
        ElseIf PieceOptions(BestValue) Is ChessBoard.BRook1 Or PieceOptions(BestValue) Is ChessBoard.BRook2 Then
            Dim AiPiece As New Rook(PieceOptions(BestValue).Left, PieceOptions(BestValue).Top, ChessPiece.Chesscolour.black, PieceOptions(BestValue))
            AiPiece.SetLoopBoundaries()
            AiPiece.SetColour()
            AiPiece.CheckMoves()
            ChessBoard.chess_piece = PieceOptions(BestValue)
            ChessBoard.colourOfPieces = "black"
        ElseIf PieceOptions(BestValue) Is ChessBoard.BBishop1 Or PieceOptions(BestValue) Is ChessBoard.BBishop2 Then
            Dim AiPiece As New Bishop(PieceOptions(BestValue).Left, PieceOptions(BestValue).Top, ChessPiece.Chesscolour.black, PieceOptions(BestValue))
            AiPiece.SetLoopBoundaries()
            AiPiece.SetColour()
            AiPiece.CheckMoves()
            ChessBoard.chess_piece = PieceOptions(BestValue)
            ChessBoard.colourOfPieces = "black"
        ElseIf PieceOptions(BestValue) Is ChessBoard.BKnight2 Or PieceOptions(BestValue) Is ChessBoard.BKnight2 Then
            Dim AiPiece As New Knight(PieceOptions(BestValue).Left, PieceOptions(BestValue).Top, ChessPiece.Chesscolour.black, PieceOptions(BestValue))
            AiPieceMover(AiPiece)
        ElseIf PieceOptions(BestValue) Is ChessBoard.BQueen Then
            Dim AiPiece As New Queen(PieceOptions(BestValue).Left, PieceOptions(BestValue).Top, ChessPiece.Chesscolour.black, PieceOptions(BestValue))
            AiPiece.SetLoopBoundaries()
            AiPiece.SetColour()
            AiPiece.CheckMoves()
            ChessBoard.chess_piece = PieceOptions(BestValue)
            ChessBoard.colourOfPieces = "black"
        ElseIf PieceOptions(BestValue) Is ChessBoard.BKing Then
            Dim AiPiece As New King(PieceOptions(BestValue).Left, PieceOptions(BestValue).Top, ChessPiece.Chesscolour.black, PieceOptions(BestValue))
            AiPieceMover(AiPiece)
        End If
        Dim taken As Boolean = False
        For Each piece In ChessBoard.BPiecesTaken
            If piece Is PieceOptions(BestValue) Then
                taken = True
            End If
        Next
        If ButtonOptions(BestValue).Visible = True And taken = False Then
            If PieceOptions(BestValue) Is ChessBoard.BBishop1 Or PieceOptions(BestValue) Is ChessBoard.BBishop2 Then
                BestValue = BestValue
            End If
            PieceOptions(BestValue).Location = New Point(ButtonOptions(BestValue).Left, ButtonOptions(BestValue).Top)
            ChessBoard.xcoords = PieceOptions(BestValue).Left
            ChessBoard.ycoords = PieceOptions(BestValue).Top
            ChessBoard.clearbuttons()
            ChessBoard.pieceTakenCheck()
            ChessBoard.BlackTime.Stop()
            ChessBoard.WhiteTime.Start()
            ChessBoard.blackpiecedisabler()
            AlreadyChecked = False
        Else
            Initilise_Weights_And_Bias()
            NextMoveDecider()
        End If

    End Sub
    Private Sub AiPieceMover(AiPiece)
        AiPiece.SetColour()
        AiPiece.CheckMoves()
        ChessBoard.chess_piece = PieceOptions(BestValue)
        ChessBoard.colourOfPieces = "black"
    End Sub
    Public Function FirstCheckIdentifier()
        Dim result As Integer
        If PieceOptions(BestValue) Is ChessBoard.BPawn1 Then
            result = 8
        ElseIf PieceOptions(BestValue) Is ChessBoard.BPawn2 Then
            result = 9
        ElseIf PieceOptions(BestValue) Is ChessBoard.BPawn3 Then
            result = 10
        ElseIf PieceOptions(BestValue) Is ChessBoard.BPawn4 Then
            result = 11
        ElseIf PieceOptions(BestValue) Is ChessBoard.BPawn5 Then
            result = 12
        ElseIf PieceOptions(BestValue) Is ChessBoard.BPawn6 Then
            result = 13
        ElseIf PieceOptions(BestValue) Is ChessBoard.BPawn7 Then
            result = 14
        ElseIf PieceOptions(BestValue) Is ChessBoard.BPawn8 Then
            result = 15
        End If
        Return result
    End Function
    Public Function SigmoidCalculation(input)
        Dim result As Double
        result = 1 / (1 + Math.E ^ (-1 * input))
        Return result
    End Function
    Public Function PieceTypeIdentifier(PieceType)
        Dim result As New List(Of Button)
        result.ToArray()
        If PieceType = 0 Then
            For Each piece In Check_Checkmate.Bpawn
                result.Add(piece)
            Next
        ElseIf PieceType = 1 Then
            For Each piece In Check_Checkmate.Brook
                result.Add(piece)
            Next
        ElseIf PieceType = 2 Then
            For Each piece In Check_Checkmate.BBishop
                result.Add(piece)
            Next
        ElseIf PieceType = 3 Then
            For Each piece In Check_Checkmate.BKnight
                result.Add(piece)
            Next
        ElseIf PieceType = 4 Then
            result.Add(ChessBoard.BQueen)
        ElseIf PieceType = 5 Then
            result.Add(ChessBoard.BKing)
        ElseIf PieceType = 6 Then
            For Each piece In ChessBoard.Whitepieces
                result.Add(piece)
            Next
        End If
        Return result
    End Function
    Public Sub CheckingForLegalMoves()
        CheckPawns()
        CheckRooks()
        CheckKnights()
        CheckBishops()
        CheckQueen()
        CheckKing()
    End Sub
    Public Sub CheckIfBestMovePlayed()
        If PieceOptions(BestValue) Is BestScoreName And ButtonOptions(BestValue) Is BestScoreButton Then
            TotalBestMovesMade += 1
        End If
    End Sub
    Public Sub CheckingForBestMoves()
        CheckingForLegalMoves()
        Dim randomnumber As New Random
        Dim AICheckerCount As Integer = 0
        Dim CheckXCoordsPiece, CheckYCoordsPiece, CheckXCoordsButton, CheckYCoordsButton As Integer
        Dim Value As PieceValue
        For Each move In LegalMoveNames
            CheckXCoordsButton = LegalButtonXCoordinates(AICheckerCount) * 77
            CheckYCoordsButton = LegalButtonYCoordinates(AICheckerCount) * 77
            FileOpen(1, "tester.txt", OpenMode.Append)
            PrintLine(1, move.Name & " " & LegalButtonNames(AICheckerCount).Name & " " & CheckXCoordsButton & " " & CheckYCoordsButton)
            FileClose(1)
            For Each piece In ChessBoard.Whitepieces
                If move Is ChessBoard.BPawn4 Then
                    Value = Value
                End If
                If piece.Left = CheckXCoordsButton And piece.Top = CheckYCoordsButton And piece IsNot move Then
                    Value = GetPieceValue(piece)
                End If
            Next
            CheckingScoreValue(Value, move)
            AICheckerCount += 1
        Next
        ChessBoard.BlackSideValue += Value
        ChessBoard.WhiteSideValue -= Value
        If BestScoreMove = 0 Then
            BestScoreName = LegalMoveNames(randomnumber.Next(0, LegalMoveNames.Count))
            BestScoreButton = LegalButtonNames(LegalMoveNames.IndexOf(BestScoreName))
        End If
        FileOpen(1, "testfile.txt", OpenMode.Append)
        PrintLine(1, BestScoreName.Name & " " & BestScoreButton.Name)
        FileClose(1)
    End Sub
    Public Sub CheckingScoreValue(value, move)
        If value > BestScoreMove Then
            BestScoreMove = value
            BestScoreName = move
            BestScoreButton = LegalButtonNames(LegalMoveNames.IndexOf(move))
        Else
        End If
    End Sub
    Public Function GetPieceValue(piece)
        Dim result As PieceValue
        If piece Is ChessBoard.WPawn1 Or piece Is ChessBoard.WPawn2 Or piece Is ChessBoard.WPawn3 Or piece Is ChessBoard.WPawn4 Or piece Is ChessBoard.WPawn5 Or piece Is ChessBoard.WPawn6 Or piece Is ChessBoard.WPawn7 Or piece Is ChessBoard.WPawn8 Then
            result = PieceValue.Pawn
        ElseIf piece Is ChessBoard.WRook1 Or piece Is ChessBoard.WRook2 Then
            result = PieceValue.Rook
        ElseIf piece Is ChessBoard.WBishop1 Or piece Is ChessBoard.WBishop2 Then
            result = PieceValue.Bishop
        ElseIf piece Is ChessBoard.WKnight1 Or piece Is ChessBoard.Wknight2 Then
            result = PieceValue.Knight
        ElseIf piece Is ChessBoard.WQueen Then
            result = PieceValue.Queen
        End If
        Return result
    End Function

    Public Sub CheckButtonsEnabled(Piece)
        For i = StartOfLoop To EndofLoop
            If ChessBoard.buttonmoves(i).Visible = True Then
                If Piece Is ChessBoard.BPawn4 Then
                    NumberlegalMoves = NumberlegalMoves
                End If
                LegalMoveNames.Add(Piece)
                LegalButtonNames.Add(ChessBoard.buttonmoves(i))
                NumberlegalMoves += 1
                LegalButtonXCoordinates.Add(ChessBoard.buttonmoves(i).Left / 77)
                LegalButtonYCoordinates.Add(ChessBoard.buttonmoves(i).Top / 77)
            End If
        Next
    End Sub
    Public Sub CheckPawns()
        FirstCheckNumber = 8
        Dim chesscolour As ChessPiece.Chesscolour = ChessPiece.Chesscolour.black
        For Each piece In Check_Checkmate.Bpawn
            Dim Pawns As New Pawn(piece.Left, piece.Top, chesscolour, piece, ChessBoard.FirstCheck(FirstCheckNumber))

            Pawns.SetColour()
            Pawns.CheckMoves()
            FirstCheckNumber += 1
            ChessBoard.chess_piece = piece
            StartOfLoop = 0
            EndofLoop = 3
            CheckButtonsEnabled(Pawns.piece)
        Next
    End Sub
    Public Sub CheckRooks()
        Dim chesscolour As ChessPiece.Chesscolour = ChessPiece.Chesscolour.black
        For Each piece In Check_Checkmate.Brook
            Dim Rooks As New Rook(piece.Left, piece.Top, chesscolour, piece)
            Rooks.SetColour()
            Rooks.SetLoopBoundaries()
            Rooks.CheckMoves()
            ChessBoard.chess_piece = piece
            StartOfLoop = 0
            EndofLoop = 31
            CheckButtonsEnabled(Rooks.piece)
        Next
    End Sub
    Public Sub CheckBishops()
        Dim chesscolour As ChessPiece.Chesscolour = ChessPiece.Chesscolour.black
        For Each piece In Check_Checkmate.BBishop
            Dim Bishops As New Bishop(piece.Left, piece.Top, chesscolour, piece)
            Bishops.SetColour()
            Bishops.SetLoopBoundaries()
            Bishops.CheckMoves()
            ChessBoard.chess_piece = piece
            StartOfLoop = 32
            EndofLoop = 63
            CheckButtonsEnabled(Bishops.piece)
        Next
    End Sub
    Public Sub CheckKnights()
        Dim chesscolour As ChessPiece.Chesscolour = ChessPiece.Chesscolour.black
        For Each piece In Check_Checkmate.BKnight
            Dim Knights As New Knight(piece.Left, piece.Top, chesscolour, piece)
            Knights.SetColour()
            Knights.CheckMoves()
            ChessBoard.chess_piece = piece
            StartOfLoop = 0
            EndofLoop = 7
            CheckButtonsEnabled(Knights.piece)
        Next
    End Sub
    Public Sub CheckQueen()
        Dim piece As Button
        piece = ChessBoard.BQueen
        Dim chesscolour As ChessPiece.Chesscolour = ChessPiece.Chesscolour.black
        Dim Queens As New Queen(piece.Left, piece.Top, chesscolour, piece)
        Queens.SetColour()
        Queens.SetLoopBoundaries()
        Queens.CheckMoves()
        ChessBoard.chess_piece = piece
        StartOfLoop = 0
        EndofLoop = 7
        CheckButtonsEnabled(Queens.piece)
    End Sub
    Public Sub CheckKing()
        Dim chesscolour As ChessPiece.Chesscolour = ChessPiece.Chesscolour.black
        Dim piece As Button
        piece = ChessBoard.BKing
        Dim Kings As New King(piece.Left, piece.Top, chesscolour, piece)
        Kings.SetColour()
        Kings.CheckMoves()
        ChessBoard.chess_piece = piece
        StartOfLoop = 0
        EndofLoop = 7
        CheckButtonsEnabled(Kings.piece)
    End Sub
End Class
