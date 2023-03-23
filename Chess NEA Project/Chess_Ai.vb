Imports System.Threading
Imports System.IO
Public Class Chess_Ai
    Private LegalMoveNames, LegalButtonNames As New List(Of Button)
    Private LegalButtonXCoordinates, LegalButtonYCoordinates As New List(Of Integer)
    Private NumberlegalMoves, BestScoreMove, TotalBestMovesMade, PreAiCount As Integer
    Private InputLayer(383), SigMoidInputLayer(383) As Integer
    Private HiddenLayer(255, 3) As Double
    Private Outputlayer(203), totalOutputLayer As Double
    Public InputToHiddenLayerWeights(383, 255) As Double
    Public HiddenLayerWeights(255, 255, 2) As Double
    Public HiddenToOutputLayerWeights(255, 203) As Double
    Public HiddenBias(255, 3) As Double
    Public OutputBias(203) As Double
    Private FirstCheckNumber As Integer
    Private StartOfLoop, EndofLoop As Integer
    Private CFInputtoHiddenlayerWeightChanges(383, 255), CFHiddenLayerWeightChanges(255, 255, 2), CFHiddenToOutputLayerWeightChanges(255, 203), CFHiddenBiasChanges(255, 3), CFOutputBiasChanges(203) As Double
    Private InputtoHiddenLayerCalculations(383, 255), HiddenLayerCalculations(255, 255, 2), HiddentoOutputLayerCalculations(203), HiddenBiasCalculations(255, 3), OutputCalculation(203) As Double
    Private BestValue As Integer
    Private AlreadyChecked, Initialised, found As Boolean
    Private PieceOptions(203), ButtonOptions(203), BestScoreName, BestScoreButton As Button
    Private EndofInitialLoop, EndOfButtonLoop As Integer
    Public NumberOfMoves, NumberOfPieces, StartingNumber, hiddenLoopID As Integer
    Private Desired_Output As Double
    Private TotalError, OutputError(203) As Double
    Private T1Finished, T2Finished, T3Finished, T4Finished, T5Finished, T6Finished, T7Finished, T8Finished As Boolean
    Const LearningRate As Double = 0.1
    Private threadingInProgress As Boolean
    Private TECWRO(203) As Double      'Total Error Change With Respect to Output
    Private OCWRTN(203) As Double      'Output Change With Respect to Total Net Input
    Private OHLWRTSHL23(255) As Double 'Output of Hidden Layer With Respect to Sum of Hidden Layer (H^2 to H^3)
    Private OHLWRTSHL12(255) As Double 'Output of Hidden Layer With Respect to Sum of Hidden Layer (H^1 to H^2)
    Private OHLWRTSHL01(255) As Double 'Output of Hidden Layer With Respect to Sum of Hidden Layer (H^0 to H^1)
    Private OHLWRTSHLI0(255) As Double 'Output of Input Layer With Respect to Sum of Hidden Layer (Input to H^0)
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
    Public Sub CostFunctionCalculation()
        Dim counter As Integer
        Dim sw As New Stopwatch
        sw.Start()
        For i = 0 To 203
            If PieceOptions(i) Is BestScoreName Then
                Desired_Output = 1
            Else
                Desired_Output = 0
            End If
            OutputError(i) = ((1 / 2) * (Desired_Output - Outputlayer(i))) ^ 2
            TotalError += OutputError(i)
            TECWRO(i) = Total_Error_Change_With_Respect_to_Output(i)
            OCWRTN(i) = Output_Change_With_Respect_to_Total_Net(Outputlayer(i))
        Next
        For i = 0 To 255
            OHLWRTSHL23(i) = Output_Change_With_Respect_to_Total_Net(HiddenLayer(i, 3))
            OHLWRTSHL12(i) = Output_Change_With_Respect_to_Total_Net(HiddenLayer(i, 2))
            OHLWRTSHL01(i) = Output_Change_With_Respect_to_Total_Net(HiddenLayer(i, 1))
            OHLWRTSHLI0(i) = Output_Change_With_Respect_to_Total_Net(HiddenLayer(i, 0))
        Next
        For k = 0 To 203
            HiddentoOutputLayerCalculations(k) = TECWRO(k) * OCWRTN(k)
        Next
        For i = 0 To 255
            For k = 0 To 203
                HiddenLayerCalculations(i, counter, 2) += HiddentoOutputLayerCalculations(k) * HiddenToOutputLayerWeights(i, k) * OHLWRTSHL23(i)
                HiddenLayerCalculations(i, counter, 1) += HiddenLayerCalculations(i, counter, 2) * HiddenLayerWeights(i, counter, 2) * OHLWRTSHL12(i)
                HiddenLayerCalculations(i, counter, 0) += HiddenLayerCalculations(i, counter, 1) * HiddenLayerWeights(i, counter, 1) * OHLWRTSHL01(i)
                counter += 1
            Next
            counter = 0
        Next
        For k = 0 To 203
            For i = 0 To 255
                CFHiddenToOutputLayerWeightChanges(i, k) += HiddentoOutputLayerCalculations(k) * HiddenLayer(i, 3)
            Next
        Next
        For i = 0 To 255
            For k = 0 To 255
                CFHiddenLayerWeightChanges(i, counter, 2) += HiddenLayerCalculations(i, k, 2) * HiddenLayer(i, 2)
                CFHiddenLayerWeightChanges(i, counter, 1) += HiddenLayerCalculations(i, k, 1) * HiddenLayer(i, 1)
                CFHiddenLayerWeightChanges(i, counter, 0) += HiddenLayerCalculations(i, k, 0) * HiddenLayer(i, 0)
                counter += 1
            Next
            counter = 0
        Next
        For j = 0 To 383
            For i = 0 To 255
                CFInputtoHiddenlayerWeightChanges(j, i) += HiddenLayerCalculations(i, counter, 0) * HiddenLayerWeights(i, counter, 0) * OHLWRTSHLI0(i) * InputLayer(j)
                counter += 1
            Next
            counter = 0
        Next
        sw.Stop()
        threadingInProgress = False
        'MsgBox(sw.ElapsedMilliseconds)
    End Sub
    Public Function Total_Error_Change_With_Respect_to_Output(i)
        Dim result As Double
        If PieceOptions(i) Is BestScoreName Then
            Desired_Output = 1
        Else
            Desired_Output = 0
        End If
        result = (Outputlayer(i) - Desired_Output)
        Return result
    End Function
    Public Function Output_Change_With_Respect_to_Total_Net(i)
        Dim result As Double
        result = (i * (1 - i))
        Return result
    End Function
    Public Function GetInputWeights()
        Return InputToHiddenLayerWeights
    End Function
    Public Function GetHiddenWeights()
        Return HiddenLayerWeights
    End Function
    Public Function GetOutputWeights()
        Return HiddenToOutputLayerWeights
    End Function
    Public Function GetHiddenBias()
        Return HiddenBias
    End Function
    Public Function GetOutputBias()
        Return OutputBias
    End Function
    Public Sub Initilise_HiddenBias()
        Dim randomNumber As New Random
        Dim checkCount As Integer
        For k = 0 To 3
            For i = 0 To 255
                If k = 0 Or k = 1 Then
                    checkCount = 0
                Else
                    checkCount = k
                End If
                Randomize()
                HiddenBias(i, k) = randomNumber.Next(50, 100) / 10
            Next
        Next
    End Sub
    Public Sub Inititlise_OutputBias()
        Dim randomNumber As New Random
        For i = 0 To 203
            OutputBias(i) = randomNumber.Next(200, 250) / 10
        Next
    End Sub
    Public Sub Inititlise_InputWeights()
        Dim randomNumber As New Random
        For i = 0 To 383
            For j = 0 To 255
                Randomize()
                InputToHiddenLayerWeights(i, j) = randomNumber.NextDouble / 2
            Next
        Next
    End Sub
    Public Sub Initilise_HiddenWeights()
        Dim randomNumber As New Random
        Dim countID As Integer
        If hiddenLoopID = 0 Then
            countID = 1
        Else
            countID = hiddenLoopID * 2
        End If
        For i = 0 To 255
            For j = 0 To 255
                Randomize()
                HiddenLayerWeights(i, j, hiddenLoopID) = randomNumber.NextDouble / (2 * countID)
            Next
        Next
    End Sub
    Public Sub Initilise_OutputWeights()
        Dim randomNumber As New Random
        For i = 0 To 255
            For j = 0 To 203
                Randomize()
                HiddenToOutputLayerWeights(i, j) = randomNumber.NextDouble / 2
            Next
        Next
    End Sub
    Public Function SigMoidDerativeCalculation(input)
        Dim result As Double
        result = SigmoidCalculation(input) * (1 - SigmoidCalculation(input))
        Return result
    End Function
    Public Sub ReadNNData()
        'creates variables
        Dim currentLine As String
        Dim currentRecord() As String
        'inputweights
        FileOpen(1, "NNInputWeights.csv", OpenMode.Input)
        While Not EOF(1)
            For y = 0 To 255
                currentLine = LineInput(1)
                currentRecord = Split(currentLine, ",")
                For x = 0 To 383
                    InputToHiddenLayerWeights(x, y) = currentRecord(x)
                Next
            Next
        End While
        FileClose(1)
        '1stHiddenLayerWeights
        FileOpen(2, "NN1stHiddenWeights.csv", OpenMode.Input)
        While Not EOF(2)
            For y = 0 To 255
                currentLine = LineInput(2)
                currentRecord = Split(currentLine, ",")
                For x = 0 To 255
                    HiddenLayerWeights(x, y, 0) = currentRecord(x)
                Next
            Next
        End While
        FileClose(2)
        '2ndHiddenLayerWeights
        FileOpen(3, "NN2ndHiddenWeights.csv", OpenMode.Input)
        While Not EOF(3)
            For y = 0 To 255
                currentLine = LineInput(3)
                currentRecord = Split(currentLine, ",")
                For x = 0 To 255
                    HiddenLayerWeights(x, y, 1) = currentRecord(x)
                Next
            Next
        End While
        FileClose(3)
        '3rdHiddenLayerWeights
        FileOpen(4, "NN3rdHiddenWeights.csv", OpenMode.Input)
        While Not EOF(4)
            For y = 0 To 255
                currentLine = LineInput(4)
                currentRecord = Split(currentLine, ",")
                For x = 0 To 255
                    HiddenLayerWeights(x, y, 2) = currentRecord(x)
                Next
            Next
        End While
        FileClose(4)
        'OutputWeights
        FileOpen(5, "NNOutputWeights.csv", OpenMode.Input)
        While Not EOF(5)
            For y = 0 To 203
                currentLine = LineInput(5)
                currentRecord = Split(currentLine, ",")
                For x = 0 To 255
                    HiddenToOutputLayerWeights(x, y) = currentRecord(x)
                Next
            Next
        End While
        FileClose(5)
        'HiddenBias
        FileOpen(6, "NNHiddenBias.csv", OpenMode.Input)
        While Not EOF(6)
            For y = 0 To 3
                currentLine = LineInput(6)
                currentRecord = Split(currentLine, ",")
                For x = 0 To 255
                    HiddenBias(x, y) = currentRecord(x)
                Next
            Next
        End While
        FileClose(6)
        'OutputBias
        FileOpen(7, "NNOutputBias.txt", OpenMode.Input)
        Dim countfileline As Integer
        While Not EOF(7)
            OutputBias(countfileline) = LineInput(7)
            countfileline += 1
        End While
        FileClose(7)
    End Sub
    Public Sub NextMoveDecider()
        Dim fgh As Integer
        found = False
        AlreadyChecked = False
        While found = False
            totalOutputLayer = 0
            If Initialised = False Then
                If ChessBoard.firstAITurn = False Then
                    ReadNNData()
                    ChessBoard.firstAITurn = True
                Else
                    InputToHiddenLayerWeights = ChessBoard.Inputweights
                    HiddenLayerWeights = ChessBoard.HiddenWeights
                    HiddenToOutputLayerWeights = ChessBoard.OutputWeights
                    HiddenBias = ChessBoard.HiddenBias
                    OutputBias = ChessBoard.OutputBias
                End If
                Initialised = True
            Else
            End If
            If AlreadyChecked = False Then
                AlreadyChecked = True
                CheckingForBestMoves()
                CheckIfBestMovePlayed()
            Else
                AlreadyChecked = True
            End If
            Dim PieceChecker As New List(Of Button)
            Dim AICount As Integer = 0
            For PieceType = 0 To 5
                PieceChecker = PieceTypeIdentifier(PieceType)
                For Each piece In PieceChecker
                    For xcoord = 0 To 7
                        For ycoord = 0 To 7
                            If piece.Left / 77 = xcoord And piece.Top / 77 = ycoord Then
                                InputLayer(AICount) = 1
                            Else
                                If InputLayer(AICount) = 1 Then
                                Else
                                    InputLayer(AICount) = 0
                                End If
                            End If             
                                AICount += 1
                        Next                       
                    Next
                    AICount -= 64
                Next
                AICount += 64
                PieceChecker.Clear()
            Next
            AICount = AICount
            If fgh = 120 Then
                fgh = fgh
            End If
            If CFHiddenBiasChanges(0, 0) < -100 Then
                fgh = fgh
            End If
            fgh = fgh
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
                totalOutputLayer += (Math.E ^ Outputlayer(i))
            Next
            For i = 0 To 203
                Outputlayer(i) = (Math.E ^ Outputlayer(i)) / totalOutputLayer
            Next
            fgh += 1
            BestValue = BestValue
            Dim TempOutput As List(Of Double)
            TempOutput = Outputlayer.ToList
            BestValue = TempOutput.IndexOf(Outputlayer.Max)
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
                ElseIf piece Is Nothing Then
                    Exit For
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
                found = True
            End If
            CostFunctionCalculation()
            AdjustingWeightsAndBias()
        End While
    End Sub
    Public Sub AdjustingWeightsAndBias()
        Dim randomnumber, randomnum As New Random
        Dim multiplier As Integer
        Dim num As Integer = Nothing
        For i = 0 To 255
            For j = 0 To 383
                num = randomnumber.Next(1, 10)
                If num = 1 Or num = 5 Or num = 7 Or num = 4 Then
                    multiplier = randomnum.Next(10, 20)
                Else : multiplier = 1
                End If
                InputToHiddenLayerWeights(j, i) -= LearningRate * CFInputtoHiddenlayerWeightChanges(j, i) * multiplier
            Next
        Next
        For i = 0 To 2
            For k = 0 To 255
                For j = 0 To 255
                    num = randomnumber.Next(1, 10)
                    If num = 1 Or num = 5 Or num = 7 Or num = 4 Then
                        multiplier = randomnum.Next(10, 20)
                    Else : multiplier = 1
                    End If
                    HiddenLayerWeights(j, k, i) -= LearningRate * CFHiddenLayerWeightChanges(j, k, i) * multiplier
                Next
            Next
        Next
        For i = 0 To 203
            For j = 0 To 255
                num = randomnumber.Next(1, 10)
                If num = 1 Or num = 5 Or num = 7 Or num = 4 Then
                    multiplier = randomnum.Next(10, 20)
                Else : multiplier = 1
                End If
                HiddenToOutputLayerWeights(j, i) -= LearningRate * CFHiddenToOutputLayerWeightChanges(j, i) * multiplier
            Next
        Next
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
            For Each piece In ChessBoard.CheckBPawn
                result.Add(piece)
            Next
        ElseIf PieceType = 1 Then
            For Each piece In ChessBoard.CheckBRook
                result.Add(piece)
            Next
        ElseIf PieceType = 2 Then
            For Each piece In ChessBoard.CheckBBishop
                result.Add(piece)
            Next
        ElseIf PieceType = 3 Then
            For Each piece In ChessBoard.CheckBKnight
                result.Add(piece)
            Next
        ElseIf PieceType = 4 Then
            result.Add(ChessBoard.BQueen)
        ElseIf PieceType = 5 Then
            result.Add(ChessBoard.BKing)
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
        Dim CheckXCoordsButton, CheckYCoordsButton As Integer
        Dim Value As PieceValue
        For Each move In LegalMoveNames
            CheckXCoordsButton = LegalButtonXCoordinates(AICheckerCount) * 77
            CheckYCoordsButton = LegalButtonYCoordinates(AICheckerCount) * 77
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
    End Sub
    Public Sub CheckingScoreValue(value, move)
        If value > BestScoreMove Then
            BestScoreMove = value
            BestScoreName = move
            BestScoreButton = LegalButtonNames(LegalMoveNames.IndexOf(move))
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
        For Each piece In ChessBoard.CheckBPawn
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
        For Each piece In ChessBoard.CheckBRook
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
        For Each piece In ChessBoard.CheckBBishop
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
        For Each piece In ChessBoard.CheckBKnight
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
        For Each piece In ChessBoard.CheckBQueen
            Dim chesscolour As ChessPiece.Chesscolour = ChessPiece.Chesscolour.black
            Dim Queens As New Queen(piece.Left, piece.Top, chesscolour, piece)
            Queens.SetColour()
            Queens.SetLoopBoundaries()
            Queens.CheckMoves()
            ChessBoard.chess_piece = piece
            StartOfLoop = 0
            EndofLoop = 7
            CheckButtonsEnabled(Queens.piece)
        Next
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