Public Class Chess_Ai
    Private LegalMoveNames As New List(Of Button)
    Private LegalMoveXCoordinates(LegalMoveNames.Count, 7) As Integer
    Private LegalMoveYCoordinates(LegalMoveNames.Count, 7) As Integer
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

    End Sub
    Public Sub CheckingForLegalMoves()
        CheckPawns()

    End Sub
    Public Sub CheckButtonsEnabled(Piece)
        For i = StartOfLoop To EndofLoop
            If ChessBoard.buttonmoves(i).Enabled = True Then
                LegalMoveNames.Add(Piece)
                LegalMoveXCoordinates(LegalMoveNames.Count, Piece.Left / 77) = Piece.Left
                LegalMoveYCoordinates(LegalMoveNames.Count, Piece.Top / 77) = Piece.Top
                NumberlegalMoves += 1
            End If
        Next
    End Sub
    Public Sub CheckPawns()
        Dim chesscolour As ChessPiece.Chesscolour
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
        Dim chesscolour As ChessPiece.Chesscolour
        For Each piece In Check_Checkmate.Bpawn
            Dim Rooks As New Rook(piece.Left, piece.Top, chesscolour, piece)
            FirstCheckNumber += 1
            Rooks.SetColour()
            Rooks.CheckMoves()
            ChessBoard.chess_piece = piece
            StartOfLoop = 0
            EndofLoop = 31
            CheckButtonsEnabled(Rooks.piece)
        Next
    End Sub
    Public Sub CheckBishops()

    End Sub
    Public Sub CheckKnights()

    End Sub
    Public Sub CheckQueen()

    End Sub
    Public Sub CheckKing()

    End Sub
End Class
