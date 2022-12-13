Imports System.Threading
Public Class ChessBoard
    Public Inputweights(383, 255), HiddenWeights(255, 255, 2), OutputWeights(255, 203), HiddenBias(255, 3), OutputBias(203) As Double
    Public firstAITurn As Boolean
    Public colourOfPieces As String
    Public xcoords, ycoords As Integer
    Public seconds, seconds1, minutes, minutes1, FirstCheckNumber, counter, WCountTaken, BCountTaken, WhiteSideValue, BlackSideValue As Integer
    Public FirstCheck(15), CheckMode, complete, checkingForCheck, firstRound, WkingInStationaryPositon, BkingInStationaryPosition, AiTurn, checkKing As Boolean
    Public Whitepieces(15), Blackpieces(15), chess_piece, buttonmoves(71), Allpieces(31), WPiecesTaken(15), BPiecesTaken(15), KingButtons(7), buttonsToUse, KingPiece As Button
    Private Sub ChessBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        WhiteSideValue = 180
        BlackSideValue = 180
        firstRound = True
        WkingInStationaryPositon = True
        BkingInStationaryPosition = True
        colourOfPieces = "white"
        WhiteTextBox.Text = 0
        BlackTextBox.Text = 0
        Whitepieces(0) = WRook1
        Whitepieces(1) = WKnight1
        Whitepieces(2) = WBishop1
        Whitepieces(3) = WQueen
        Whitepieces(4) = WKing
        Whitepieces(5) = WBishop2
        Whitepieces(6) = Wknight2
        Whitepieces(7) = WRook2
        Whitepieces(8) = WPawn1
        Whitepieces(9) = WPawn2
        Whitepieces(10) = WPawn3
        Whitepieces(11) = WPawn4
        Whitepieces(12) = WPawn5
        Whitepieces(13) = WPawn6
        Whitepieces(14) = WPawn7
        Whitepieces(15) = WPawn8
        Blackpieces(0) = BRook1
        Blackpieces(1) = BKnight1
        Blackpieces(2) = BBishop1
        Blackpieces(3) = BQueen
        Blackpieces(4) = BKing
        Blackpieces(5) = BBishop2
        Blackpieces(6) = BKnight2
        Blackpieces(7) = BRook2
        Blackpieces(8) = BPawn1
        Blackpieces(9) = BPawn2
        Blackpieces(10) = BPawn3
        Blackpieces(11) = BPawn4
        Blackpieces(12) = BPawn5
        Blackpieces(13) = BPawn6
        Blackpieces(14) = BPawn7
        Blackpieces(15) = BPawn8
        buttonmoves(0) = Button1
        buttonmoves(1) = Button2
        buttonmoves(2) = Button3
        buttonmoves(3) = Button4
        buttonmoves(4) = Button5
        buttonmoves(5) = Button6
        buttonmoves(6) = Button7
        buttonmoves(7) = Button8
        buttonmoves(8) = Button9
        buttonmoves(9) = Button10
        buttonmoves(10) = Button11
        buttonmoves(11) = Button12
        buttonmoves(12) = Button13
        buttonmoves(13) = Button14
        buttonmoves(14) = Button15
        buttonmoves(15) = Button16
        buttonmoves(16) = Button17
        buttonmoves(17) = Button18
        buttonmoves(18) = Button19
        buttonmoves(19) = Button20
        buttonmoves(20) = Button21
        buttonmoves(21) = Button22
        buttonmoves(22) = Button23
        buttonmoves(23) = Button24
        buttonmoves(24) = Button25
        buttonmoves(25) = Button26
        buttonmoves(26) = Button27
        buttonmoves(27) = Button28
        buttonmoves(28) = Button29
        buttonmoves(29) = Button30
        buttonmoves(30) = Button31
        buttonmoves(31) = Button32
        buttonmoves(32) = Button33
        buttonmoves(33) = Button34
        buttonmoves(34) = Button35
        buttonmoves(35) = Button36
        buttonmoves(36) = Button37
        buttonmoves(37) = Button38
        buttonmoves(38) = Button39
        buttonmoves(39) = Button40
        buttonmoves(40) = Button41
        buttonmoves(41) = Button42
        buttonmoves(42) = Button43
        buttonmoves(43) = Button44
        buttonmoves(44) = Button45
        buttonmoves(45) = Button46
        buttonmoves(46) = Button47
        buttonmoves(47) = Button48
        buttonmoves(48) = Button49
        buttonmoves(49) = Button50
        buttonmoves(50) = Button51
        buttonmoves(51) = Button52
        buttonmoves(52) = Button53
        buttonmoves(53) = Button54
        buttonmoves(54) = Button55
        buttonmoves(55) = Button56
        buttonmoves(56) = Button57
        buttonmoves(57) = Button58
        buttonmoves(58) = Button59
        buttonmoves(59) = Button60
        buttonmoves(60) = Button61
        buttonmoves(61) = Button62
        buttonmoves(62) = Button63
        buttonmoves(63) = Button64
        buttonmoves(64) = Button65
        buttonmoves(65) = Button66
        buttonmoves(66) = Button67
        buttonmoves(67) = Button68
        buttonmoves(68) = Button69
        buttonmoves(69) = Button70
        buttonmoves(70) = Button71
        buttonmoves(71) = Button72
        WhiteTime.Start()
        seconds = 0
        seconds1 = 0
        If minutes = 0 Then
            minutes = 5
        End If
        If minutes1 = 0 Then
            minutes1 = 5
        End If
        WhiteTextBox.Text = minutes & ":" & "00"
        BlackTextBox.Text = minutes1 & ":" & "00"
        setupBoard()
        For i = 0 To 15
            Allpieces(i) = Whitepieces(i)
            Allpieces(i + 16) = Blackpieces(i)
        Next
        clearbuttons()
        blackpiecedisabler()
        For i = 0 To 7
            KingButtons(i) = buttonmoves(i + 64)
        Next
        If MainMenu.AiMode = True Then
            For Each piece In Blackpieces
                piece.Enabled = False
            Next
        End If
    End Sub
    'Removes all buttons from the board
    Public Sub clearbuttons()
        For Each Button In buttonmoves
            Button.Hide()
            Button.Location = New Point(1000, 1000)
        Next
    End Sub
    'The timer for the white pieces
    Public Sub WhiteTime_Tick(sender As Object, e As EventArgs) Handles WhiteTime.Tick
        If seconds > 0 Then
            seconds -= 1
        Else
            seconds = 59
            minutes -= 1
        End If
        WhiteTextBox.Text = Format(minutes, "00") & ":" & Format(seconds, "00")
        WhiteTimeRunOut()
    End Sub
    'The Timer for the black pieces
    Private Sub BlackTime_Tick(sender As Object, e As EventArgs) Handles BlackTime.Tick
        If seconds1 > 0 Then
            seconds1 -= 1
        Else
            seconds1 = 59
            minutes1 -= 1
        End If
        BlackTextBox.Text = Format(minutes1, "00") & ":" & Format(seconds1, "00")
        BlackTimeRunOut()
    End Sub
    'When White's time has run out this message is displayed to say that white has lost
    Private Sub WhiteTimeRunOut()
        If minutes = 0 And seconds = 0 Then
            WhiteTime.Enabled = False
            MsgBox("White ran out of time, black wins!")
        End If
    End Sub
    'When Black's time has run out this message is displayed to say that black has lost
    Private Sub BlackTimeRunOut()
        If minutes1 = 0 And seconds1 = 0 Then
            BlackTime.Enabled = False
            MsgBox("Black ran out of time, White wins!")
        End If
    End Sub
    'Initilises the board by setting up all the pieces as well as setting up the array for the pieces
    Private Sub setupBoard()
        For Each piece In Whitepieces
            piece.FlatStyle = Windows.Forms.FlatStyle.Flat
            piece.FlatAppearance.BorderSize = 0
            piece.FlatAppearance.MouseDownBackColor = Color.Transparent
            piece.FlatAppearance.MouseOverBackColor = Color.Transparent
            piece.BackColor = Color.Transparent
        Next
        For Each piece In Blackpieces
            piece.FlatStyle = Windows.Forms.FlatStyle.Flat
            piece.FlatAppearance.BorderSize = 0
            piece.FlatAppearance.MouseDownBackColor = Color.Transparent
            piece.FlatAppearance.MouseOverBackColor = Color.Transparent
            piece.BackColor = Color.Transparent
        Next
        Dim xsetup, count As Integer
        For Each piece In Whitepieces
            piece.Size = New Size(80, 80)
            If count <= 7 Then
                piece.Location = New Point(xsetup, 539)
            Else
                piece.Location = New Point(xsetup, 462)
            End If
            xsetup += 77
            If count = 7 Then
                xsetup = 0
            End If
            count = count + 1
        Next
        xsetup = 0
        count = 0
        For Each piece In Blackpieces
            piece.Size = New Size(80, 80)
            If count <= 7 Then
                piece.Location = New Point(xsetup, 0)
            Else
                piece.Location = New Point(xsetup, 77)
            End If
            xsetup += 77
            If count = 7 Then
                xsetup = 0
            End If
            count = count + 1
        Next
    End Sub
    'When Wrook1 is clicked it goes through the checking system of where it can move
    Private Sub WRook1_Click(sender As Object, e As EventArgs) Handles WRook1.Click
        Dim rooks As New Rook(WRook1.Left, WRook1.Top, ChessPiece.Chesscolour.white, WRook1)
        clearbuttons()
        rooks.SetColour()
        rooks.SetLoopBoundaries()
        rooks.CheckMoves()
        chess_piece = WRook1
        colourOfPieces = "white"
    End Sub
    'When Wrook2 is clicked it goes through the checking system of where it can move
    Private Sub WRook2_Click(sender As Object, e As EventArgs) Handles WRook2.Click
        Dim rooks As New Rook(WRook2.Left, WRook2.Top, ChessPiece.Chesscolour.white, WRook2)
        clearbuttons()
        rooks.SetColour()
        rooks.SetLoopBoundaries()
        rooks.CheckMoves()
        chess_piece = WRook2
        colourOfPieces = "white"
    End Sub
    'When Brook1 is clicked it goes through the checking system of where it can move
    Private Sub BRook1_Click(sender As Object, e As EventArgs) Handles BRook1.Click
        Dim rooks As New Rook(BRook1.Left, BRook1.Top, ChessPiece.Chesscolour.black, BRook1)
        clearbuttons()
        rooks.SetColour()
        rooks.SetLoopBoundaries()
        rooks.CheckMoves()
        chess_piece = BRook1
        colourOfPieces = "black"
    End Sub
    'When Brook2 is clicked it goes through the checking system of where it can move
    Private Sub BRook2_Click(sender As Object, e As EventArgs) Handles BRook2.Click
        Dim rooks As New Rook(BRook2.Left, BRook2.Top, ChessPiece.Chesscolour.black, BRook2)
        clearbuttons()
        rooks.SetColour()
        rooks.SetLoopBoundaries()
        rooks.CheckMoves()
        chess_piece = BRook2
        colourOfPieces = "black"
    End Sub
    'When WBishop1 is clicked it goes through the checking system of where it can move
    Private Sub WBishop1_Click(sender As Object, e As EventArgs) Handles WBishop1.Click
        Dim Bishops As New Bishop(WBishop1.Left, WBishop1.Top, ChessPiece.Chesscolour.white, WBishop1)
        clearbuttons()
        Bishops.SetColour()
        Bishops.SetLoopBoundaries()
        Bishops.CheckMoves()
        chess_piece = WBishop1
        colourOfPieces = "white"
    End Sub
    'When WBishop2 is clicked it goes through the checking system of where it can move
    Private Sub WBishop2_Click(sender As Object, e As EventArgs) Handles WBishop2.Click
        Dim Bishops As New Bishop(WBishop2.Left, WBishop2.Top, ChessPiece.Chesscolour.white, WBishop2)
        clearbuttons()
        Bishops.SetColour()
        Bishops.SetLoopBoundaries()
        Bishops.CheckMoves()
        chess_piece = WBishop2
        colourOfPieces = "white"
    End Sub
    'When BBishop1 is clicked it goes through the checking system of where it can move
    Private Sub BBishop1_Click(sender As Object, e As EventArgs) Handles BBishop1.Click
        Dim Bishops As New Bishop(BBishop1.Left, BBishop1.Top, ChessPiece.Chesscolour.black, BBishop1)
        clearbuttons()
        Bishops.SetColour()
        Bishops.SetLoopBoundaries()
        Bishops.CheckMoves()
        chess_piece = BBishop1
        colourOfPieces = "black"
    End Sub
    'When BBishop2 is clicked it goes through the checking system of where it can move
    Private Sub BBishop2_Click(sender As Object, e As EventArgs) Handles BBishop2.Click
        Dim Bishops As New Bishop(BBishop2.Left, BBishop2.Top, ChessPiece.Chesscolour.black, BBishop2)
        clearbuttons()
        Bishops.SetColour()
        Bishops.SetLoopBoundaries()
        Bishops.CheckMoves()
        chess_piece = BBishop2
        colourOfPieces = "black"
    End Sub
    'When WQueen is clicked it goes through the checking system of where it can move
    Private Sub WQueen_Click(sender As Object, e As EventArgs) Handles WQueen.Click
        Dim queen As New Queen(WQueen.Left, WQueen.Top, ChessPiece.Chesscolour.white, WQueen)
        clearbuttons()
        queen.SetColour()
        queen.SetLoopBoundaries()
        queen.CheckMoves()
        chess_piece = WQueen
        colourOfPieces = "white"
    End Sub
    'When BQueen is clicked it goes through the checking system of where it can move
    Private Sub BQueen_Click(sender As Object, e As EventArgs) Handles BQueen.Click
        Dim queen As New Queen(BQueen.Left, BQueen.Top, ChessPiece.Chesscolour.black, BQueen)
        clearbuttons()
        queen.SetColour()
        queen.SetLoopBoundaries()
        queen.CheckMoves()
        chess_piece = BQueen
        colourOfPieces = "black"
    End Sub
    'When WKnight1 is clicked it goes through the checking system of where it can move
    Private Sub WKnight1_Click(sender As Object, e As EventArgs) Handles WKnight1.Click
        Dim knights As New Knight(WKnight1.Left, WKnight1.Top, ChessPiece.Chesscolour.white, WKnight1)
        clearbuttons()
        knights.SetColour()
        knights.CheckMoves()
        chess_piece = WKnight1
        colourOfPieces = "white"
    End Sub
    'When WKnight2 is clicked it goes through the checking system of where it can move
    Private Sub WKnight2_Click(sender As Object, e As EventArgs) Handles Wknight2.Click
        Dim knights As New Knight(Wknight2.Left, Wknight2.Top, ChessPiece.Chesscolour.white, Wknight2)
        clearbuttons()
        knights.SetColour()
        knights.CheckMoves()
        chess_piece = Wknight2
        colourOfPieces = "white"
    End Sub
    'When BKnight1 is clicked it goes through the checking system of where it can move
    Private Sub BKnight1_Click(sender As Object, e As EventArgs) Handles BKnight1.Click
        Dim knights As New Knight(BKnight1.Left, BKnight1.Top, ChessPiece.Chesscolour.black, BKnight1)
        clearbuttons()
        knights.SetColour()
        knights.CheckMoves()
        chess_piece = BKnight1
        colourOfPieces = "black"
    End Sub
    'When BKnight2 is clicked it goes through the checking system of where it can move
    Private Sub BKnight2_Click(sender As Object, e As EventArgs) Handles BKnight2.Click
        Dim knights As New Knight(BKnight2.Left, BKnight2.Top, ChessPiece.Chesscolour.black, BKnight2)
        clearbuttons()
        knights.SetColour()
        knights.CheckMoves()
        chess_piece = BKnight2
        colourOfPieces = "black"
    End Sub
    'When WKing is clicked it goes through the checking system of where it can move
    Private Sub Wking_Click(sender As Object, e As EventArgs) Handles WKing.Click
        Dim kings As New King(WKing.Left, WKing.Top, ChessPiece.Chesscolour.white, WKing)
        clearbuttons()
        kings.SetColour()
        kings.CheckMoves()
        chess_piece = WKing
        colourOfPieces = "white"
    End Sub
    'When BKing is clicked it goes through the checking system of where it can move
    Private Sub Bking_Click(sender As Object, e As EventArgs) Handles BKing.Click
        Dim kings As New King(BKing.Left, BKing.Top, ChessPiece.Chesscolour.black, BKing)
        clearbuttons()
        kings.SetColour()
        kings.CheckMoves()
        chess_piece = BKing
        colourOfPieces = "black"
    End Sub
    'When Wpawn1 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn1_Click(sender As Object, e As EventArgs) Handles WPawn1.Click
        Dim Pawns As New Pawn(WPawn1.Left, WPawn1.Top, ChessPiece.Chesscolour.white, WPawn1, FirstCheck(0))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = WPawn1
        FirstCheckNumber = 0
        colourOfPieces = "white"
    End Sub
    'When Wpawn2 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn2_Click(sender As Object, e As EventArgs) Handles WPawn2.Click
        Dim Pawns As New Pawn(WPawn2.Left, WPawn2.Top, ChessPiece.Chesscolour.white, WPawn2, FirstCheck(1))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = WPawn2
        FirstCheckNumber = 1
        colourOfPieces = "white"
    End Sub
    'When Wpawn3 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn3_Click(sender As Object, e As EventArgs) Handles WPawn3.Click
        Dim Pawns As New Pawn(WPawn3.Left, WPawn3.Top, ChessPiece.Chesscolour.white, WPawn3, FirstCheck(2))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = WPawn3
        FirstCheckNumber = 2
        colourOfPieces = "white"
    End Sub
    'When Wpawn4 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn4_Click(sender As Object, e As EventArgs) Handles WPawn4.Click
        Dim Pawns As New Pawn(WPawn4.Left, WPawn4.Top, ChessPiece.Chesscolour.white, WPawn4, FirstCheck(3))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = WPawn4
        FirstCheckNumber = 3
        colourOfPieces = "white"
    End Sub
    'When Wpawn5 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn5_Click(sender As Object, e As EventArgs) Handles WPawn5.Click
        Dim Pawns As New Pawn(WPawn5.Left, WPawn5.Top, ChessPiece.Chesscolour.white, WPawn5, FirstCheck(4))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = WPawn5
        FirstCheckNumber = 4
        colourOfPieces = "white"
    End Sub
    'When Wpawn6 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn6_Click(sender As Object, e As EventArgs) Handles WPawn6.Click
        Dim Pawns As New Pawn(WPawn6.Left, WPawn6.Top, ChessPiece.Chesscolour.white, WPawn6, FirstCheck(5))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = WPawn6
        FirstCheckNumber = 5
        colourOfPieces = "white"
    End Sub
    'When Wpawn7 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn7_Click(sender As Object, e As EventArgs) Handles WPawn7.Click
        Dim Pawns As New Pawn(WPawn7.Left, WPawn7.Top, ChessPiece.Chesscolour.white, WPawn7, FirstCheck(6))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = WPawn7
        FirstCheckNumber = 6
        colourOfPieces = "white"
    End Sub
    'When Wpawn8 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn8_Click(sender As Object, e As EventArgs) Handles WPawn8.Click
        Dim Pawns As New Pawn(WPawn8.Left, WPawn8.Top, ChessPiece.Chesscolour.white, WPawn8, FirstCheck(7))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = WPawn8
        FirstCheckNumber = 7
        colourOfPieces = "white"
    End Sub
    'When Bpawn1 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn1_Click(sender As Object, e As EventArgs) Handles BPawn1.Click
        Dim Pawns As New Pawn(BPawn1.Left, BPawn1.Top, ChessPiece.Chesscolour.black, BPawn1, FirstCheck(8))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = BPawn1
        FirstCheckNumber = 8
        colourOfPieces = "black"
    End Sub
    'When Bpawn2 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn2_Click(sender As Object, e As EventArgs) Handles BPawn2.Click
        Dim Pawns As New Pawn(BPawn2.Left, BPawn2.Top, ChessPiece.Chesscolour.black, BPawn2, FirstCheck(9))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = BPawn2
        FirstCheckNumber = 9
        colourOfPieces = "black"
    End Sub
    'When Bpawn3 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn3_Click(sender As Object, e As EventArgs) Handles BPawn3.Click
        Dim Pawns As New Pawn(BPawn3.Left, BPawn3.Top, ChessPiece.Chesscolour.black, BPawn3, FirstCheck(10))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = BPawn3
        FirstCheckNumber = 10
        colourOfPieces = "black"
    End Sub
    'When Bpawn4 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn4_Click(sender As Object, e As EventArgs) Handles BPawn4.Click
        Dim Pawns As New Pawn(BPawn4.Left, BPawn4.Top, ChessPiece.Chesscolour.black, BPawn4, FirstCheck(11))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = BPawn4
        FirstCheckNumber = 11
        colourOfPieces = "black"
    End Sub
    'When Bpawn5 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn5_Click(sender As Object, e As EventArgs) Handles BPawn5.Click
        Dim Pawns As New Pawn(BPawn5.Left, BPawn5.Top, ChessPiece.Chesscolour.black, BPawn5, FirstCheck(12))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = BPawn5
        FirstCheckNumber = 12
        colourOfPieces = "black"
    End Sub
    'When Bpawn6 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn6_Click(sender As Object, e As EventArgs) Handles BPawn6.Click
        Dim Pawns As New Pawn(BPawn6.Left, BPawn6.Top, ChessPiece.Chesscolour.black, BPawn6, FirstCheck(13))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = BPawn6
        FirstCheckNumber = 13
        colourOfPieces = "black"
    End Sub
    'When Bpawn7 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn7_Click(sender As Object, e As EventArgs) Handles BPawn7.Click
        Dim Pawns As New Pawn(BPawn7.Left, BPawn7.Top, ChessPiece.Chesscolour.black, BPawn7, FirstCheck(14))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = BPawn7
        FirstCheckNumber = 14
        colourOfPieces = "black"
    End Sub
    'When Bpawn8 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn8_Click(sender As Object, e As EventArgs) Handles BPawn8.Click
        Dim Pawns As New Pawn(BPawn8.Left, BPawn8.Top, ChessPiece.Chesscolour.black, BPawn8, FirstCheck(15))
        clearbuttons()
        Pawns.SetColour()
        Pawns.CheckMoves()
        chess_piece = BPawn8
        FirstCheckNumber = 15
        colourOfPieces = "black"
    End Sub
    'This is the action for all of buttons the user can use to move a piece, it gets the coordinates then clears the buttons and then sets a new loction for the required piece
    Public Sub buttons_click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, Button32.Click, Button33.Click, Button34.Click, Button35.Click, Button36.Click, Button37.Click, Button38.Click, Button39.Click, Button40.Click, Button41.Click, Button42.Click, Button43.Click, Button44.Click, Button45.Click, Button46.Click, Button47.Click, Button48.Click, Button49.Click, Button50.Click, Button51.Click, Button52.Click, Button53.Click, Button54.Click, Button55.Click, Button56.Click, Button57.Click, Button58.Click, Button59.Click, Button60.Click, Button61.Click, Button62.Click, Button63.Click, Button64.Click, Button65.Click, Button66.Click, Button67.Click, Button68.Click, Button69.Click, Button70.Click, Button71.Click, Button72.Click
        Dim buttons = DirectCast(sender, Button)
        xcoords = buttons.Left
        ycoords = buttons.Top
        clearbuttons()
        setNewLocation()
    End Sub
    'This runs at the end of each turn, it goes through each move the opposite side can make to check if the user is in check or checkmate
    Public Sub CheckforCheck()
        Dim checkTheKing As New Check_Checkmate
        Dim CheckingCheck(7) As Boolean

        If WhiteTime.Enabled = True Then
            KingPiece = WKing
            colourOfPieces = "white"
        Else
            colourOfPieces = "black"
            KingPiece = BKing
        End If
        Button65.Location = New Point(KingPiece.Left - 77, KingPiece.Top)
        Button66.Location = New Point(KingPiece.Left - 77, KingPiece.Top + 77)
        Button67.Location = New Point(KingPiece.Left, KingPiece.Top + 77)
        Button68.Location = New Point(KingPiece.Left + 77, KingPiece.Top + 77)
        Button69.Location = New Point(KingPiece.Left + 77, KingPiece.Top)
        Button70.Location = New Point(KingPiece.Left + 77, KingPiece.Top - 77)
        Button71.Location = New Point(KingPiece.Left, KingPiece.Top - 77)
        Button72.Location = New Point(KingPiece.Left - 77, KingPiece.Top - 77)
        For i = 0 To 7
            buttonsToUse = KingButtons(i)
            CheckingCheck(i) = checkTheKing.Check_King
        Next
        If checkingForCheck = True And CheckingCheck(0) = True And CheckingCheck(1) = True And CheckingCheck(2) = True And CheckingCheck(3) = True And CheckingCheck(4) = True And CheckingCheck(5) = True And CheckingCheck(6) = True And CheckingCheck(7) = True Then
            If colourOfPieces = "white" Then
                MsgBox("White Checkmate!")
            Else
                MsgBox("Black Checkmate!")
            End If
            If MainMenu.AiMode = True Then
                SaveNNdata()
            End If
        ElseIf checkingForCheck = True Then
            MsgBox("Check!")
            checkingForCheck = False

        End If
    End Sub
    Public Sub SaveNNdata()
        Dim ai As New Chess_Ai

        Dim inputstring As String = ""
        FileOpen(1, "NNInputWeights.csv", OpenMode.Output)
        For j = 0 To 255
            inputstring = ""
            For i = 0 To 383
                If i <> 383 Then
                    inputstring += Inputweights(i, j).ToString & ","
                Else
                    inputstring += Inputweights(i, j).ToString
                End If
            Next
            PrintLine(1, inputstring)
        Next
        FileClose(1)
        FileOpen(2, "NN1stHiddenWeights.csv", OpenMode.Output)
        For i = 0 To 255
            inputstring = ""
            For j = 0 To 255
                If j <> 255 Then
                    inputstring += HiddenWeights(i, j, 0).ToString & ","
                Else
                    inputstring += HiddenWeights(i, j, 0).ToString
                End If
            Next
            PrintLine(2, inputstring)
        Next
        FileClose(2)
        FileOpen(3, "NN2ndHiddenWeights.csv", OpenMode.Output)
        For i = 0 To 255
            inputstring = ""
            For j = 0 To 255
                If j <> 255 Then
                    inputstring += HiddenWeights(i, j, 1).ToString & ","
                Else
                    inputstring += HiddenWeights(i, j, 1).ToString
                End If
            Next
            PrintLine(3, inputstring)
        Next
        FileClose(3)
        FileOpen(4, "NN3rdHiddenWeights.csv", OpenMode.Output)
        For i = 0 To 255
            inputstring = ""
            For j = 0 To 255
                If j <> 255 Then
                    inputstring += HiddenWeights(i, j, 2).ToString & ","
                Else
                    inputstring += HiddenWeights(i, j, 2).ToString
                End If
            Next
            PrintLine(4, inputstring)
        Next
        FileClose(4)
        FileOpen(5, "NNOutputWeights.csv", OpenMode.Output)
        For j = 0 To 203
            inputstring = ""
            For i = 0 To 255
                If i <> 255 Then
                    inputstring += OutputWeights(i, j).ToString & ","
                Else
                    inputstring += OutputWeights(i, j).ToString
                End If
            Next
            PrintLine(5, inputstring)
        Next
        FileClose(5)
        FileOpen(6, "NNHiddenBias.csv", OpenMode.Output)
        For i = 0 To 3
            inputstring = ""
            For k = 0 To 255
                If k <> 255 Then
                    inputstring += HiddenBias(k, i).ToString & ","
                Else
                    inputstring += HiddenBias(k, i).ToString
                End If
            Next
            PrintLine(6, inputstring)
        Next
        FileClose(6)

        FileOpen(7, "NNOutputBias.txt", OpenMode.Output)
        For i = 0 To 203
            PrintLine(7, OutputBias(i))
        Next
        FileClose(7)
    End Sub
    Private Sub Chessboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MainMenu.AiMode = True Then
            SaveNNdata()
        End If
        MainMenu.Close()
    End Sub
    'This sets a new location for the piece clicked, it firsts checks if it was a pawn, if it was a pawn and its first turn then it makes FirstCheck for the pawn
    ' equal to true meaning when that pawn is clicked again it can't move 2 steps forward, it then checks if a piece was taken then ends turn and starts the next
    ' one by checking which turn it currently is then switching it. 
    Public Sub setNewLocation()
        chess_piece.Left = xcoords
        chess_piece.Top = ycoords
        If chess_piece Is WPawn1 Or chess_piece Is WPawn2 Or chess_piece Is WPawn3 Or chess_piece Is WPawn4 Or chess_piece Is WPawn5 Or chess_piece Is WPawn6 Or chess_piece Is WPawn7 Or chess_piece Is WPawn8 Or chess_piece Is BPawn1 Or chess_piece Is BPawn2 Or chess_piece Is BPawn3 Or chess_piece Is BPawn4 Or chess_piece Is BPawn5 Or chess_piece Is BPawn6 Or chess_piece Is BPawn7 Or chess_piece Is BPawn8 Then
            If FirstCheck(FirstCheckNumber) = False Then
                FirstCheck(FirstCheckNumber) = True
            End If
        End If
        pieceTakenCheck()
        If WhiteTime.Enabled = True Then
            WhiteTime.Stop()
            BlackTime.Start()
            whitepiecedisabler()
        Else
            BlackTime.Stop()
            WhiteTime.Start()
            blackpiecedisabler()
        End If
    End Sub
    'It goes through piece checking if the piece's clicked position has moved on to a piece, if it has it moves piece to the right display the message
    Public Sub pieceTakenCheck()
        For Each piece In Allpieces
            If piece.Left = xcoords And piece.Top = ycoords And piece IsNot chess_piece Then
                setRemovedPieces(piece)
                MsgBox("Piece Taken")
                Exit For
            End If
        Next
    End Sub
    'This checks which piece was just removed and then moves it the right and adding it to an array so it can't be used again
    Public Sub setRemovedPieces(ByVal piece As Button)
        piece.Size = New Size(60, 60)
        piece.Enabled = False
        If colourOfPieces = "white" Then
            BPiecesTaken(BCountTaken) = piece
            BCountTaken += 1
        ElseIf colourOfPieces = "black" Then
            WPiecesTaken(WCountTaken) = piece
            WCountTaken += 1
        End If
        If piece Is WPawn1 Then
            WPawn1.Location = New Point(633, 112)
        ElseIf piece Is WPawn2 Then
            WPawn2.Location = New Point(691, 112)
        ElseIf piece Is WPawn3 Then
            WPawn3.Location = New Point(749, 112)
        ElseIf piece Is WPawn4 Then
            WPawn4.Location = New Point(807, 112)
        ElseIf piece Is WPawn5 Then
            WPawn5.Location = New Point(633, 171)
        ElseIf piece Is WPawn6 Then
            WPawn6.Location = New Point(691, 171)
        ElseIf piece Is WPawn7 Then
            WPawn7.Location = New Point(749, 171)
        ElseIf piece Is WPawn8 Then
            WPawn8.Location = New Point(807, 171)
        ElseIf piece Is BPawn1 Then
            BPawn1.Location = New Point(633, 344)
        ElseIf piece Is BPawn2 Then
            BPawn2.Location = New Point(691, 344)
        ElseIf piece Is BPawn3 Then
            BPawn3.Location = New Point(749, 344)
        ElseIf piece Is BPawn4 Then
            BPawn4.Location = New Point(807, 344)
        ElseIf piece Is BPawn5 Then
            BPawn5.Location = New Point(633, 401)
        ElseIf piece Is BPawn6 Then
            BPawn6.Location = New Point(691, 401)
        ElseIf piece Is BPawn7 Then
            BPawn7.Location = New Point(749, 401)
        ElseIf piece Is BPawn8 Then
            BPawn8.Location = New Point(807, 401)
        ElseIf piece Is WRook1 Then
            WRook1.Location = New Point(633, 231)
        ElseIf piece Is WRook2 Then
            WRook2.Location = New Point(691, 231)
        ElseIf piece Is BRook1 Then
            BRook1.Location = New Point(633, 460)
        ElseIf piece Is BRook2 Then
            BRook2.Location = New Point(691, 460)
        ElseIf piece Is WBishop1 Then
            WBishop1.Location = New Point(749, 231)
        ElseIf piece Is WBishop2 Then
            WBishop2.Location = New Point(807, 231)
        ElseIf piece Is BBishop1 Then
            BBishop1.Location = New Point(749, 460)
        ElseIf piece Is BBishop2 Then
            BBishop2.Location = New Point(807, 460)
        ElseIf piece Is WKnight1 Then
            WKnight1.Location = New Point(633, 287)
        ElseIf piece Is Wknight2 Then
            Wknight2.Location = New Point(691, 287)
        ElseIf piece Is BKnight1 Then
            BKnight1.Location = New Point(633, 520)
        ElseIf piece Is BKnight2 Then
            BKnight2.Location = New Point(691, 520)
        ElseIf piece Is WQueen Then
            WQueen.Location = New Point(749, 520)
        ElseIf piece Is BQueen Then
            BQueen.Location = New Point(749, 520)
        ElseIf piece Is WKing Then
            WKing.Location = New Point(807, 520)
        ElseIf piece Is BKing Then
            BKing.Location = New Point(807, 520)
        End If
    End Sub
    'It will disable all the black pieces so the player can click on them whilst it is white's turn and enable all white pieces
    Public Sub blackpiecedisabler()
        AiTurn = False
        colourOfPieces = "white"
        For Each p In Blackpieces
            p.Enabled = False
        Next
        For Each p In Whitepieces
            For Each piece In WPiecesTaken
                If piece IsNot p Then
                    p.Enabled = True
                Else
                    p.Enabled = False
                    Exit For
                End If
            Next
        Next
        If firstRound = True Then
            firstRound = False
        Else
            CheckforCheck()
        End If
    End Sub
    'For player vs player it will disable all the white pieces so the player can click on them whilst it is black's turn and enable all black pieces
    'For Player vs Ai it will disable the whites pieces but rather enabling black pieces it will activate the Ai for it make its turn
    Private Sub whitepiecedisabler()
        AiTurn = True
        colourOfPieces = "black"
        For Each p In Whitepieces
            p.Enabled = False
        Next
        If firstRound = True Then
            firstRound = False
        Else
            CheckforCheck()
        End If
        If MainMenu.AiMode = True Then
            Dim Ai As New Chess_Ai
            Ai.NextMoveDecider()
            HiddenBias = Ai.GetHiddenBias()
            OutputBias = Ai.GetOutputBias()
            Inputweights = Ai.GetInputWeights()
            HiddenWeights = Ai.GetHiddenWeights()
            OutputWeights = Ai.GetOutputWeights()
        Else
            For Each p In Blackpieces
                For Each piece In BPiecesTaken
                    If piece IsNot p Then
                        p.Enabled = True
                    Else
                        p.Enabled = False
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub
End Class
