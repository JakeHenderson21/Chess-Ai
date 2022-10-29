﻿Imports System.IO
Public Class Chess_Ai
    Private LegalMoveNames As New List(Of Button)
    Private LegalMoveXCoordinates, LegalMoveYCoordinates, LegalButtonXCoordinates, LegalButtonYCoordinates As New List(Of Integer)
    Private NumberlegalMoves As Integer
    Private InputLayer(383) As Double
    Private HiddenLayer(255, 3) As Double
    Private Outputlayer(1882) As Double
    Private InputToHiddenLayerWeights(383, 255) As Double
    Private HiddenLayerWeights(255, 255, 2) As Double
    Private HiddenToOutputLayerWeights(255, 1882) As Double
    Private HiddenBias(255, 3) As Double
    Private OutputBias(1882) As Double
    Private FirstCheckNumber As Integer
    Private StartOfLoop, EndofLoop As Integer
    Public Sub New()

        'If My.Computer.FileSystem.FileExists("testfile.txt") Then
        '    File.Delete("testfile.txt")
        '    File.Create("testfile.txt")
        'Else
        '    File.Create("testfile.txt")
        'End If
    End Sub
    Public Sub Initilise_Weights_And_Bias()
        Dim randomNumber As New Random
        For i = 0 To 383
            For j = 0 To 255
                InputToHiddenLayerWeights(i, j) = randomNumber.NextDouble
            Next
        Next
        For k = 0 To 2
            For i = 0 To 255
                For j = 0 To 255
                    HiddenLayerWeights(i, j, k) = randomNumber.NextDouble
                Next
            Next
        Next
        For i = 0 To 255
            For j = 0 To 1882
                HiddenToOutputLayerWeights(i, j) = randomNumber.NextDouble
            Next
        Next
        For k = 0 To 3
            For i = 0 To 255
                HiddenBias(i, k) = randomNumber.Next(80, 90)

            Next
        Next
        For i = 0 To 1882
            OutputBias(i) = randomNumber.Next(80, 90)

        Next
    End Sub
    Public Sub NextMoveDecider()
        Dim PieceChecker As New List(Of Button)
        'For xcoord = 0 To 7
        '    For ycoord = 0 To 7
        '        For PieceType = 0 To 5
        '            PieceChecker = PieceTypeIdentifier(PieceType)
        '            PieceChecker.ToArray()
        '            For Each piece In PieceChecker
        '                If piece.Left / 77 = xcoord And piece.Top / 77 = ycoord Then
        '                    InputLayer(xcoord, ycoord, PieceType) = 1
        '                Else
        '                    InputLayer(xcoord, ycoord, PieceType) = 0
        '                End If
        '            Next
        '            PieceChecker.Clear()
        '        Next
        '    Next
        'Next
        Dim Arraysorter(1882) As Double
        Dim randomnumber As New Random
        For i = 0 To 383
            InputLayer(i) = randomnumber.NextDouble()
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
        For i = 0 To 1882
            For j = 0 To 255
                Outputlayer(i) += HiddenLayer(j, 3) * HiddenToOutputLayerWeights(j, i)
            Next
            Outputlayer(i) -= OutputBias(i)
            Outputlayer(i) = SigmoidCalculation(Outputlayer(i))
        Next
        Arraysorter = Outputlayer
        Dim TempArraySorter As Double
        Dim message As String = ""
        For i = 0 To 1881
            For j = 0 To 1881
                If Arraysorter(j) > Arraysorter(j + 1) Then
                    TempArraySorter = Arraysorter(j)
                    Arraysorter(j) = Arraysorter(j + 1)
                    Arraysorter(j + 1) = TempArraySorter
                End If
            Next
        Next

    End Sub
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
        LegalMoveNames.ToArray()
        LegalMoveXCoordinates.ToArray()
        LegalMoveYCoordinates.ToArray()
        Dim increaser As Integer
        'For Each button In LegalMoveNames
        '    FileOpen(1, "testfile.txt", OpenMode.Append)
        '    PrintLine(1, button.Name & " (" & LegalMoveXCoordinates(LegalMoveNames.IndexOf(button)) & "," & LegalMoveYCoordinates(LegalMoveNames.IndexOf(button)) & ")" & " (" & LegalButtonXCoordinates(LegalMoveNames.IndexOf(button) + increaser) & "," & LegalButtonYCoordinates(LegalMoveNames.IndexOf(button) + increaser) & ")")
        '    If increaser = 0 Then
        '        increaser = 1
        '    Else
        '        increaser = 0
        '    End If
        '    FileClose(1)
        'Next
    End Sub
    Public Sub CheckButtonsEnabled(Piece)
        For i = StartOfLoop To EndofLoop
            If ChessBoard.buttonmoves(i).Visible = True Then
                ChessBoard.buttonmoves(i).Name = ChessBoard.buttonmoves(i).Name
                LegalMoveNames.Add(Piece)
                NumberlegalMoves += 1
                LegalButtonXCoordinates.Add(ChessBoard.buttonmoves(i).Left / 77)
                LegalButtonYCoordinates.Add(ChessBoard.buttonmoves(i).Top / 77)
                LegalMoveXCoordinates.Add(Piece.Left / 77)
                LegalMoveYCoordinates.Add(Piece.Top / 77)
            End If
        Next
    End Sub
    Public Sub CheckPawns()
        Dim chesscolour As ChessPiece.Chesscolour = ChessPiece.Chesscolour.black
        For Each piece In Check_Checkmate.Bpawn
            Dim Pawns As New Pawn(piece.Left, piece.Top, chesscolour, piece, ChessBoard.FirstCheck(FirstCheckNumber))
            FirstCheckNumber += 1
            Pawns.SetColour()
            Pawns.CheckMoves()
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
            FirstCheckNumber += 1
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
            FirstCheckNumber += 1
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
            FirstCheckNumber += 1
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
            FirstCheckNumber += 1
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
            FirstCheckNumber += 1
            Kings.SetColour()
            Kings.CheckMoves()
            ChessBoard.chess_piece = piece
            StartOfLoop = 0
        EndofLoop = 7
        CheckButtonsEnabled(Kings.piece)
    End Sub
End Class
