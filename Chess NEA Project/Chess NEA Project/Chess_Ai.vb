﻿Imports System.IO
Public Class Chess_Ai
    Private LegalMoveNames As New List(Of Button)
    Private LegalMoveXCoordinates, LegalMoveYCoordinates, LegalButtonXCoordinates, LegalButtonYCoordinates As New List(Of Integer)
    Private NumberlegalMoves As Integer
    Private inputLayers(NumberlegalMoves) As Double
    Private hiddenLayer(3, NumberlegalMoves) As Double
    Private outputLayer(NumberlegalMoves + 1) As Double
    Private hiddenLayerWeights(3, NumberlegalMoves + 1) As Double
    Private hiddenBias(3, NumberlegalMoves) As Double
    Private outputBias(NumberlegalMoves) As Double
    Private FirstCheckNumber As Integer
    Private StartOfLoop, EndofLoop As Integer
    Public Sub New()
        If My.Computer.FileSystem.FileExists("testfile.txt") Then
            File.Delete("testfile.txt")
            File.Create("testfile.txt")
        Else
            File.Create("testfile.txt")
        End If
    End Sub
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
        For Each button In LegalMoveNames
            FileOpen(1, "testfile.txt", OpenMode.Append)
            PrintLine(1, button.Name & " (" & LegalMoveXCoordinates(LegalMoveNames.IndexOf(button)) & "," & LegalMoveYCoordinates(LegalMoveNames.IndexOf(button)) & ")" & " (" & LegalButtonXCoordinates(LegalMoveNames.IndexOf(button) + increaser) & "," & LegalButtonYCoordinates(LegalMoveNames.IndexOf(button) + increaser) & ")")
            If increaser = 0 Then
                increaser = 1
            Else
                increaser = 0
            End If
            FileClose(1)
        Next
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
