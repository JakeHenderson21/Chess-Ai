Public Class Chess_Ai
    Private NumberlegalMoves As Integer
    Private inputLayers(NumberlegalMoves) As Double
    Private hiddenLayer(3, NumberlegalMoves) As Double
    Private outputLayer(NumberlegalMoves + 1) As Double
    Private hiddenLayerWeights(3, NumberlegalMoves + 1) As Double
    Private hiddenBias(3, NumberlegalMoves) As Double
    Private outputBias(NumberlegalMoves) As Double
    Private FirstCheckNumber As Integer
    Public Sub New()

    End Sub
    Public Sub CheckPawns()
        Dim chesscolour As ChessPiece.Chesscolour
        For Each piece In Check_Checkmate.Bpawn
            Dim Pawns As New Pawn(piece.Left, piece.Top, chesscolour, piece, ChessBoard.FirstCheck(FirstCheckNumber))
            FirstCheckNumber += 1
            Pawns.SetColour()
            Pawns.CheckMoves()
            ChessBoard.chess_piece = piece
        Next
    End Sub
    Public Sub CheckRooks()

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
