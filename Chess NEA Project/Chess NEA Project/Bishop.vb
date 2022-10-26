Public Class Bishop
    Inherits ChessPiece
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal chess_colour As Chesscolour, ByVal piece As Button)
        MyBase.New(X, Y, chess_colour, piece)
    End Sub
    Public Sub SetLoopBoundaries()
        startofloop = 4
        endofloop = 7
        count = 4
    End Sub
End Class
