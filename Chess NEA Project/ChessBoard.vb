﻿Imports System.Threading
Public Class ChessBoard
    Public Inputweights(383, 255), HiddenWeights(255, 255, 2), OutputWeights(255, 203), HiddenBias(255, 3), OutputBias(203) As Double
    Public firstAITurn, endGameState, WKinginCheck, BKinginCheck, continueexecuting, PawnRook, PawnBishop, PawnKnight, PawnQueen As Boolean
    Public colourOfPieces, Piece_name, PawnPromotion(15), UsersChoice As String
    Public xcoords, ycoords As Integer
    Public ButtonX_Causing_Check(), ButtonY_Causing_Check() As Integer
    Public seconds, seconds1, minutes, minutes1, FirstCheckNumber, counter, WCountTaken, BCountTaken, WhiteSideValue, BlackSideValue As Integer
    Public FirstCheck(15), CheckMode, complete, checkingForCheck, firstRound, WkingInStationaryPositon, BkingInStationaryPosition, AiTurn, checkKing As Boolean
    Public CheckWPawn, CheckBPawn, CheckWRook, CheckBRook, CheckWBishop, CheckBBishop, CheckWKnight, CheckBKnight, CheckWQueen, CheckBQueen As New List(Of Button)
    Public Whitepieces(15), Blackpieces(15), chess_piece, buttonmoves(71), Allpieces(31), WPiecesTaken(15), BPiecesTaken(15), KingButtons(7), buttonsToUse, KingPiece, Piece_Causing_Check As Button
    Private Sub ChessBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        PawnPromotion(0) = "WPawn"
        PawnPromotion(1) = "WPawn"
        PawnPromotion(2) = "WPawn"
        PawnPromotion(3) = "WPawn"
        PawnPromotion(4) = "WPawn"
        PawnPromotion(5) = "WPawn"
        PawnPromotion(6) = "WPawn"
        PawnPromotion(7) = "WPawn"
        PawnPromotion(8) = "BPawn"
        PawnPromotion(9) = "BPawn"
        PawnPromotion(10) = "BPawn"
        PawnPromotion(11) = "BPawn"
        PawnPromotion(12) = "BPawn"
        PawnPromotion(13) = "BPawn"
        PawnPromotion(14) = "BPawn"
        PawnPromotion(15) = "BPawn"
        Returnbtn.Hide()
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
        For i = 0 To 7
            CheckWPawn.Add(Whitepieces(i + 8))
            CheckBPawn.Add(Blackpieces(i + 8))
        Next
        CheckWRook.Add(WRook1)
        CheckWRook.Add(WRook2)
        CheckBRook.Add(BRook1)
        CheckBRook.Add(BRook2)
        CheckWBishop.Add(WBishop1)
        CheckWBishop.Add(WBishop2)
        CheckBBishop.Add(BBishop1)
        CheckBBishop.Add(BBishop2)
        CheckWKnight.Add(WKnight1)
        CheckWKnight.Add(Wknight2)
        CheckBKnight.Add(BKnight1)
        CheckBKnight.Add(BKnight2)
        CheckWQueen.Add(WQueen)
        CheckBQueen.Add(BQueen)
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
        CheckMode = False
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
        CheckMode = False
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
        CheckMode = False
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
        CheckMode = False
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
        CheckMode = False
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
        CheckMode = False
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
        CheckMode = False
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
        CheckMode = False
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
        CheckMode = False
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
        CheckMode = False
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
        CheckMode = False
        Dim knights As New Knight(WKnight1.Left, WKnight1.Top, ChessPiece.Chesscolour.white, WKnight1)
        clearbuttons()
        knights.SetColour()
        knights.CheckMoves()
        chess_piece = WKnight1
        colourOfPieces = "white"
    End Sub
    'When WKnight2 is clicked it goes through the checking system of where it can move
    Private Sub WKnight2_Click(sender As Object, e As EventArgs) Handles Wknight2.Click
        CheckMode = False
        Dim knights As New Knight(Wknight2.Left, Wknight2.Top, ChessPiece.Chesscolour.white, Wknight2)
        clearbuttons()
        knights.SetColour()
        knights.CheckMoves()
        chess_piece = Wknight2
        colourOfPieces = "white"
    End Sub
    'When BKnight1 is clicked it goes through the checking system of where it can move
    Private Sub BKnight1_Click(sender As Object, e As EventArgs) Handles BKnight1.Click
        CheckMode = False
        Dim knights As New Knight(BKnight1.Left, BKnight1.Top, ChessPiece.Chesscolour.black, BKnight1)
        clearbuttons()
        knights.SetColour()
        knights.CheckMoves()
        chess_piece = BKnight1
        colourOfPieces = "black"
    End Sub
    'When BKnight2 is clicked it goes through the checking system of where it can move
    Private Sub BKnight2_Click(sender As Object, e As EventArgs) Handles BKnight2.Click
        CheckMode = False
        Dim knights As New Knight(BKnight2.Left, BKnight2.Top, ChessPiece.Chesscolour.black, BKnight2)
        clearbuttons()
        knights.SetColour()
        knights.CheckMoves()
        chess_piece = BKnight2
        colourOfPieces = "black"
    End Sub
    'When WKing is clicked it goes through the checking system of where it can move
    Private Sub Wking_Click(sender As Object, e As EventArgs) Handles WKing.Click
        CheckMode = False
        Dim kings As New King(WKing.Left, WKing.Top, ChessPiece.Chesscolour.white, WKing)
        clearbuttons()
        kings.SetColour()
        kings.CheckMoves()
        chess_piece = WKing
        colourOfPieces = "white"
    End Sub
    'When BKing is clicked it goes through the checking system of where it can move
    Private Sub Bking_Click(sender As Object, e As EventArgs) Handles BKing.Click
        CheckMode = False
        Dim kings As New King(BKing.Left, BKing.Top, ChessPiece.Chesscolour.black, BKing)
        clearbuttons()
        kings.SetColour()
        kings.CheckMoves()
        chess_piece = BKing
        colourOfPieces = "black"
    End Sub
    'When Wpawn1 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn1_Click(sender As Object, e As EventArgs) Handles WPawn1.Click
        FirstCheckNumber = 0
        Promotion(0, WPawn1)
        CheckMode = False        
        chess_piece = WPawn1
        colourOfPieces = "white"
    End Sub
    'When Wpawn2 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn2_Click(sender As Object, e As EventArgs) Handles WPawn2.Click
        CheckMode = False
        FirstCheckNumber = 1
        Promotion(1, WPawn2)
        chess_piece = WPawn2
        colourOfPieces = "white"
    End Sub
    'When Wpawn3 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn3_Click(sender As Object, e As EventArgs) Handles WPawn3.Click
        FirstCheckNumber = 2
        Promotion(2, WPawn3)
        CheckMode = False
        chess_piece = WPawn3
        colourOfPieces = "white"
    End Sub
    'When Wpawn4 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn4_Click(sender As Object, e As EventArgs) Handles WPawn4.Click
        CheckMode = False
        FirstCheckNumber = 3
        Promotion(3, WPawn4)
        chess_piece = WPawn4
        colourOfPieces = "white"
    End Sub
    'When Wpawn5 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn5_Click(sender As Object, e As EventArgs) Handles WPawn5.Click
        CheckMode = False
        FirstCheckNumber = 4
        Promotion(4, WPawn5)
        chess_piece = WPawn5
        colourOfPieces = "white"
    End Sub
    'When Wpawn6 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn6_Click(sender As Object, e As EventArgs) Handles WPawn6.Click
        CheckMode = False
        FirstCheckNumber = 5
        Promotion(5, WPawn6)
        chess_piece = WPawn6
        colourOfPieces = "white"
    End Sub
    'When Wpawn7 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn7_Click(sender As Object, e As EventArgs) Handles WPawn7.Click
        CheckMode = False
        FirstCheckNumber = 6
        Promotion(6, WPawn7)
        chess_piece = WPawn7
        colourOfPieces = "white"
    End Sub
    'When Wpawn8 is clicked it goes through the checking system of where it can move
    Private Sub Wpawn8_Click(sender As Object, e As EventArgs) Handles WPawn8.Click
        CheckMode = False
        FirstCheckNumber = 7
        Promotion(7, WPawn8)
        chess_piece = WPawn8
        colourOfPieces = "white"
    End Sub
    'When Bpawn1 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn1_Click(sender As Object, e As EventArgs) Handles BPawn1.Click
        CheckMode = False
        FirstCheckNumber = 8
        Promotion(8, BPawn1)
        chess_piece = BPawn1
        colourOfPieces = "black"
    End Sub
    'When Bpawn2 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn2_Click(sender As Object, e As EventArgs) Handles BPawn2.Click
        CheckMode = False
        FirstCheckNumber = 9
        Promotion(9, BPawn2)
        chess_piece = BPawn2
        colourOfPieces = "black"
    End Sub
    'When Bpawn3 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn3_Click(sender As Object, e As EventArgs) Handles BPawn3.Click
        CheckMode = False
        FirstCheckNumber = 10
        Promotion(11, BPawn3)
        chess_piece = BPawn3
        colourOfPieces = "black"
    End Sub
    'When Bpawn4 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn4_Click(sender As Object, e As EventArgs) Handles BPawn4.Click
        CheckMode = False
        FirstCheckNumber = 11
        Promotion(11, BPawn4)
        chess_piece = BPawn4
        colourOfPieces = "black"
    End Sub
    'When Bpawn5 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn5_Click(sender As Object, e As EventArgs) Handles BPawn5.Click
        CheckMode = False
        FirstCheckNumber = 12
        Promotion(12, BPawn5)
        chess_piece = BPawn5
        colourOfPieces = "black"
    End Sub
    'When Bpawn6 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn6_Click(sender As Object, e As EventArgs) Handles BPawn6.Click
        CheckMode = False
        FirstCheckNumber = 13
        Promotion(13, BPawn6)
        chess_piece = BPawn6
        colourOfPieces = "black"
    End Sub
    'When Bpawn7 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn7_Click(sender As Object, e As EventArgs) Handles BPawn7.Click
        CheckMode = False
        FirstCheckNumber = 14
        Promotion(14, BPawn7)
        chess_piece = BPawn7
        colourOfPieces = "black"
    End Sub
    'When Bpawn8 is clicked it goes through the checking system of where it can move
    Private Sub Bpawn8_Click(sender As Object, e As EventArgs) Handles BPawn8.Click
        CheckMode = False
        FirstCheckNumber = 15
        Promotion(15, BPawn8)
        chess_piece = BPawn8
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
                endgame()
            Else
                MsgBox("Black Checkmate!")
                endgame()
            End If
            If MainMenu.AiMode = True Then
                SaveNNdata()
            End If
        ElseIf checkingForCheck = True Then
            MsgBox("Check!")
            checkingForCheck = False
            If KingPiece Is WKing Then
                WKinginCheck = True
            Else
                BKinginCheck = True
            End If
        Else
            WKinginCheck = False
            BKinginCheck = False
        End If
    End Sub
    Private Sub endgame()
        WhiteTime.Stop()
        BlackTime.Stop()
        endGameState = True
        For Each piece In Allpieces
            piece.Enabled = False
        Next
        If MsgBox("Do you want to go to the main menu?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
            MainMenu.Show()
        Else
            Returnbtn.Show()
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
        If endGameState = True Then
            endGameState = False
        Else
            MainMenu.Close()
        End If
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
            If (chess_piece.Top = 0 And colourOfPieces = "white") And PawnPromotion(FirstCheckNumber) = "WPawn" Then
                PromotionChoice.Show()
            End If
            If chess_piece.Top = 539 And colourOfPieces = "black" And PawnPromotion(FirstCheckNumber) = "BPawn" Then
                PromotionChoice.Show()
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
    Public Sub PromotePawn(Piece)
        Select Case Piece.name
            Case WPawn1.Name
                PawnPromotion(0) = UsersChoice
            Case WPawn2.Name
                PawnPromotion(1) = UsersChoice
            Case WPawn3.Name
                PawnPromotion(2) = UsersChoice
            Case WPawn4.Name
                PawnPromotion(3) = UsersChoice
            Case WPawn5.Name
                PawnPromotion(4) = UsersChoice
            Case WPawn6.Name
                PawnPromotion(5) = UsersChoice
            Case WPawn7.Name
                PawnPromotion(6) = UsersChoice
            Case WPawn8.Name
                PawnPromotion(7) = UsersChoice
            Case BPawn1.Name
                PawnPromotion(8) = UsersChoice
            Case BPawn2.Name
                PawnPromotion(9) = UsersChoice
            Case BPawn3.Name
                PawnPromotion(10) = UsersChoice
            Case BPawn4.Name
                PawnPromotion(11) = UsersChoice
            Case BPawn5.Name
                PawnPromotion(12) = UsersChoice
            Case BPawn6.Name
                PawnPromotion(13) = UsersChoice
            Case BPawn7.Name
                PawnPromotion(14) = UsersChoice
            Case BPawn8.Name
                PawnPromotion(15) = UsersChoice
        End Select
        If UsersChoice = "WRook" Then
            Piece.backgroundimage = System.Drawing.Image.FromFile("WhiteRook.png")
            CheckWPawn.Remove(Piece)
            CheckWRook.Add(Piece)
        ElseIf UsersChoice = "BRook" Then
            Piece.backgroundimage = System.Drawing.Image.FromFile("BlackRook.png")
            CheckBPawn.Remove(Piece)
            CheckBRook.Add(Piece)
        ElseIf UsersChoice = "WBishop" Then
            Piece.backgroundimage = System.Drawing.Image.FromFile("WhiteBishop.png")
            CheckWPawn.Remove(Piece)
            CheckWBishop.Add(Piece)
        ElseIf UsersChoice = "BBishop" Then
            Piece.backgroundimage = System.Drawing.Image.FromFile("BlackBishop.png")
            CheckBPawn.Remove(Piece)
            CheckBBishop.Add(Piece)
        ElseIf UsersChoice = "WKnight" Then
            Piece.backgroundimage = System.Drawing.Image.FromFile("WhiteKnight.png")
            CheckWPawn.Remove(Piece)
            CheckWKnight.Add(Piece)
        ElseIf UsersChoice = "BKnight" Then
            Piece.backgroundimage = System.Drawing.Image.FromFile("BlackKnight.png")
            CheckBPawn.Remove(Piece)
            CheckBKnight.Add(Piece)
        ElseIf UsersChoice = "WQueen" Then
            Piece.backgroundimage = System.Drawing.Image.FromFile("WhiteQueen.png")
            CheckWPawn.Remove(Piece)
            CheckWQueen.Add(Piece)
        ElseIf UsersChoice = "BQueen" Then
            Piece.backgroundimage = System.Drawing.Image.FromFile("BlackQueen.png")
            CheckBPawn.Remove(Piece)
            CheckBQueen.Add(Piece)
        End If
        continueexecuting = False
    End Sub
    'It goes through piece checking if the piece's clicked position has moved on to a piece, if it has it moves piece to the right display the message
    Public Sub pieceTakenCheck()
        For Each piece In Allpieces
            If piece.Left = xcoords And piece.Top = ycoords And piece IsNot chess_piece Then
                setRemovedPieces(piece)
                MsgBox(Piece_name & " Taken")
                Exit For
            End If
        Next
    End Sub
    Private Function SetPawnName(ByVal piece As Button)
        Dim name As String = ""
        If piece Is WPawn1 Then
            name = selectmovetype(0)
        ElseIf piece Is WPawn2 Then
            name = selectmovetype(1)
        ElseIf piece Is WPawn3 Then
            name = selectmovetype(2)
        ElseIf piece Is WPawn4 Then
            name = selectmovetype(3)
        ElseIf piece Is WPawn5 Then
            name = selectmovetype(4)
        ElseIf piece Is WPawn6 Then
            name = selectmovetype(5)
        ElseIf piece Is WPawn7 Then
            name = selectmovetype(6)
        ElseIf piece Is WPawn8 Then
            name = selectmovetype(7)
        ElseIf piece Is BPawn1 Then
            name = selectmovetype(8)
        ElseIf piece Is BPawn2 Then
            name = selectmovetype(9)
        ElseIf piece Is BPawn3 Then
            name = selectmovetype(10)
        ElseIf piece Is BPawn4 Then
            name = selectmovetype(11)
        ElseIf piece Is BPawn5 Then
            name = selectmovetype(12)
        ElseIf piece Is BPawn6 Then
            name = selectmovetype(13)
        ElseIf piece Is BPawn7 Then
            name = selectmovetype(14)
        ElseIf piece Is BPawn8 Then
            name = selectmovetype(15)
        End If
        Return name
    End Function
    Private Function selectmovetype(ByVal numberToUse As Integer)
        Dim name As String = ""
        If PawnPromotion(numberToUse) = "WRook" Then
            name = "White Rook (White Pawn)"
        ElseIf PawnPromotion(numberToUse) = "BRook" Then
            name = "Black Rook (Black Pawn)"
        ElseIf PawnPromotion(numberToUse) = "WBishop" Then
            name = "White Bishop (White Pawn)"
        ElseIf PawnPromotion(numberToUse) = "BBishop" Then
            name = "Black Bishop (Black Pawn)"
        ElseIf PawnPromotion(numberToUse) = "WKnight" Then
            name = "White Knight (White Pawn)"
        ElseIf PawnPromotion(numberToUse) = "BKnight" Then
            name = "Black Knight (Black Pawn)"
        ElseIf PawnPromotion(numberToUse) = "WQueen" Then
            name = "White Queen (White Pawn)"
        ElseIf PawnPromotion(numberToUse) = "BQueen" Then
            name = "Black Queen (Black Pawn)"
        ElseIf PawnPromotion(numberToUse) = "WPawn" Then
            name = "White Pawn"
        ElseIf PawnPromotion(numberToUse) = "BPawn" Then
            name = "Black Pawn"
        End If
        Return name
    End Function
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
            Piece_name = SetPawnName(piece)
        ElseIf piece Is WPawn2 Then
            WPawn2.Location = New Point(691, 112)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is WPawn3 Then
            WPawn3.Location = New Point(749, 112)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is WPawn4 Then
            WPawn4.Location = New Point(807, 112)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is WPawn5 Then
            WPawn5.Location = New Point(633, 171)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is WPawn6 Then
            WPawn6.Location = New Point(691, 171)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is WPawn7 Then
            WPawn7.Location = New Point(749, 171)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is WPawn8 Then
            WPawn8.Location = New Point(807, 171)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is BPawn1 Then
            BPawn1.Location = New Point(633, 344)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is BPawn2 Then
            BPawn2.Location = New Point(691, 344)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is BPawn3 Then
            BPawn3.Location = New Point(749, 344)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is BPawn4 Then
            BPawn4.Location = New Point(807, 344)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is BPawn5 Then
            BPawn5.Location = New Point(633, 401)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is BPawn6 Then
            BPawn6.Location = New Point(691, 401)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is BPawn7 Then
            BPawn7.Location = New Point(749, 401)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is BPawn8 Then
            BPawn8.Location = New Point(807, 401)
            Piece_name = SetPawnName(piece)
        ElseIf piece Is WRook1 Then
            WRook1.Location = New Point(633, 231)
            Piece_name = "White Rook"
        ElseIf piece Is WRook2 Then
            WRook2.Location = New Point(691, 231)
            Piece_name = "White Rook"
        ElseIf piece Is BRook1 Then
            BRook1.Location = New Point(633, 460)
            Piece_name = "Black Rook"
        ElseIf piece Is BRook2 Then
            BRook2.Location = New Point(691, 460)
            Piece_name = "Black Rook"
        ElseIf piece Is WBishop1 Then
            WBishop1.Location = New Point(749, 231)
            Piece_name = "White Bishop"
        ElseIf piece Is WBishop2 Then
            WBishop2.Location = New Point(807, 231)
            Piece_name = "White Bishop"
        ElseIf piece Is BBishop1 Then
            BBishop1.Location = New Point(749, 460)
            Piece_name = "Black Bishop"
        ElseIf piece Is BBishop2 Then
            BBishop2.Location = New Point(807, 460)
            Piece_name = "Black Bishop"
        ElseIf piece Is WKnight1 Then
            WKnight1.Location = New Point(633, 287)
            Piece_name = "White Knight"
        ElseIf piece Is Wknight2 Then
            Wknight2.Location = New Point(691, 287)
            Piece_name = "White Knight"
        ElseIf piece Is BKnight1 Then
            BKnight1.Location = New Point(633, 520)
            Piece_name = "Black Knight"
        ElseIf piece Is BKnight2 Then
            BKnight2.Location = New Point(691, 520)
            Piece_name = "Black Knight"
        ElseIf piece Is WQueen Then
            WQueen.Location = New Point(749, 520)
            Piece_name = "White Queen"
        ElseIf piece Is BQueen Then
            BQueen.Location = New Point(749, 520)
            Piece_name = "Black Queen"
        ElseIf piece Is WKing Then
            WKing.Location = New Point(807, 520)
            Piece_name = "White King"
        ElseIf piece Is BKing Then
            BKing.Location = New Point(807, 520)
            Piece_name = "Black King"
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
        PawnRook = False
        PawnBishop = False
        PawnKnight = False
        PawnQueen = False
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
        PawnRook = False
        PawnBishop = False
        PawnKnight = False
        PawnQueen = False
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
    Private Sub Returnbtn_Click(sender As Object, e As EventArgs) Handles Returnbtn.Click
        endGameState = True
        Me.Close()
        MainMenu.Show()
    End Sub
    Public Sub Promotion(ByVal idenitifer As Integer, ByVal PawnPiece As Button)
        If PawnPromotion(idenitifer) = "BRook" Then
            Dim rooks As New Rook(PawnPiece.Left, PawnPiece.Top, ChessPiece.Chesscolour.black, PawnPiece)
            PawnRook = True
            clearbuttons()
            rooks.SetColour()
            rooks.SetLoopBoundaries()
            rooks.CheckMoves()
        ElseIf PawnPromotion(idenitifer) = "WRook" Then
            Dim rooks As New Rook(PawnPiece.Left, PawnPiece.Top, ChessPiece.Chesscolour.white, PawnPiece)
            PawnRook = True
            clearbuttons()
            rooks.SetColour()
            rooks.SetLoopBoundaries()
            rooks.CheckMoves()
        ElseIf PawnPromotion(idenitifer) = "BKnight" Then
            Dim knights As New Knight(PawnPiece.Left, PawnPiece.Top, ChessPiece.Chesscolour.black, PawnPiece)
            PawnKnight = True
            clearbuttons()
            knights.SetColour()
            knights.CheckMoves()
        ElseIf PawnPromotion(idenitifer) = "WKnight" Then
            Dim knights As New Knight(PawnPiece.Left, PawnPiece.Top, ChessPiece.Chesscolour.white, PawnPiece)
            PawnKnight = True
            clearbuttons()
            knights.SetColour()
            knights.CheckMoves()
        ElseIf PawnPromotion(idenitifer) = "BBishop" Then
            Dim Bishops As New Bishop(PawnPiece.Left, PawnPiece.Top, ChessPiece.Chesscolour.black, PawnPiece)
            PawnBishop = True
            clearbuttons()
            Bishops.SetColour()
            Bishops.SetLoopBoundaries()
            Bishops.CheckMoves()
        ElseIf PawnPromotion(idenitifer) = "WBishop" Then
            Dim Bishops As New Bishop(PawnPiece.Left, PawnPiece.Top, ChessPiece.Chesscolour.white, PawnPiece)
            PawnBishop = True
            clearbuttons()
            Bishops.SetColour()
            Bishops.SetLoopBoundaries()
            Bishops.CheckMoves()
        ElseIf PawnPromotion(idenitifer) = "BQueen" Then
            Dim queen As New Queen(PawnPiece.Left, PawnPiece.Top, ChessPiece.Chesscolour.black, PawnPiece)
            PawnQueen = True
            clearbuttons()
            queen.SetColour()
            queen.SetLoopBoundaries()
            queen.CheckMoves()
        ElseIf PawnPromotion(idenitifer) = "WQueen" Then
            Dim queen As New Queen(PawnPiece.Left, PawnPiece.Top, ChessPiece.Chesscolour.white, PawnPiece)
            PawnQueen = True
            clearbuttons()
            queen.SetColour()
            queen.SetLoopBoundaries()
            queen.CheckMoves()
        ElseIf PawnPromotion(idenitifer) = "WPawn" Then
            Dim Pawns As New Pawn(PawnPiece.Left, PawnPiece.Top, ChessPiece.Chesscolour.white, PawnPiece, FirstCheck(FirstCheckNumber))
            clearbuttons()
            Pawns.SetColour()
            Pawns.CheckMoves()
        ElseIf PawnPromotion(idenitifer) = "BPawn" Then
            Dim Pawns As New Pawn(PawnPiece.Left, PawnPiece.Top, ChessPiece.Chesscolour.black, PawnPiece, FirstCheck(FirstCheckNumber))
            clearbuttons()
            Pawns.SetColour()
            Pawns.CheckMoves()
        End If
    End Sub
End Class
