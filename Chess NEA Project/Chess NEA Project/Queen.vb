Public Class Queen
    Inherits ChessPiece
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal chess_colour As Chesscolour, ByVal piece As Button)
        MyBase.New(X, Y, chess_colour, piece)
    End Sub
    Public Sub SetLoopBoundaries()
        startofloop = 0
        endofloop = 7
        count = 0
    End Sub
End Class
