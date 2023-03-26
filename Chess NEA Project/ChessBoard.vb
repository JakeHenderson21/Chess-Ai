Imports System.Threading
Public Class ChessBoard
    Public Inputweights(383, 255), HiddenWeights(255, 255, 2), OutputWeights(255, 203), HiddenBias(255, 3), OutputBias(203) As Double
    Public firstAITurn, endGameState, WKinginCheck, BKinginCheck, continueexecuting, PawnRook, PawnBishop, PawnKnight, PawnQueen, checkKing As Boolean
    Public colourOfPieces, Piece_name, PawnPromotion(15), UsersChoice As String
    Public xcoords, ycoords As Integer
    Private Colour As ChessPiece.Chesscolour
    Public ButtonX_Causing_Check, ButtonY_Causing_Check As List(Of Integer)
    Public seconds, seconds1, minutes, minutes1, FirstCheckNumber, counter, WCountTaken, BCountTaken As Integer
    Public FirstCheck(15), CheckMode, checkingForCheck, firstRound, AiTurn As Boolean
    Public CheckWPawn, CheckBPawn, CheckWRook, CheckBRook, CheckWBishop, CheckBBishop, CheckWKnight, CheckBKnight, CheckWQueen, CheckBQueen As New List(Of Button)
    Public Whitepieces(15), Blackpieces(15), chess_piece, buttonmoves(71), Allpieces(31), WPiecesTaken(15), BPiecesTaken(15), KingButtons(7), buttonsToUse, KingPiece, Piece_Causing_Check As Button
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        For i = 0 To 71
            buttonmoves(i) = DirectCast(Controls.Find("button" & i + 1, True)(0), Button) 'Initalises buttons into an array
        Next
    End Sub
    'This setsup arrays that will called later on for calculations of what pieces can move, this also calls the sub "setupboard", this place the pieces into the correct location,
    'It also starts the white timer to start the game.
    Private Sub ChessBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        For i = 0 To 7
            PawnPromotion(i) = "WPawn"
            PawnPromotion(i + 8) = "BPawn"
        Next
        Returnbtn.Hide()
        firstRound = True
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
        For Each b In buttonmoves
            AddHandler b.Click, AddressOf buttons_click
        Next
        WhiteTime.Start()
        seconds = 0
        seconds1 = 0
        If minutes = 0 And Settings.changed = True Then
            minutes = 1
            minutes1 = 1
        ElseIf minutes = 0 And Settings.changed = False Then
            minutes = 5
            minutes1 = 5
        End If
        WhiteTextBox.Text = minutes & ":" & "00"
        BlackTextBox.Text = minutes1 & ":" & "00"
        For i = 0 To 15
            Allpieces(i) = Whitepieces(i)
            Allpieces(i + 16) = Blackpieces(i)
        Next
        setupBoard()
        For Each piece In Allpieces
            AddHandler piece.Click, AddressOf pieces_click
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
    'Removes all buttons from the board so that they don't interfere with any calculations of where pieces can legally move
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
        For Each piece In Allpieces
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
    'This handles every click for when user clicks on a piece to use, it will then call a sub that will decipher which piece has been clicked and what calculations need to be done
    Private Sub pieces_click(sender As Object, e As EventArgs)
        CheckMode = False
        Dim piece = DirectCast(sender, Button)
        If Blackpieces.Contains(piece) Then
            colourOfPieces = "black"
            Colour = ChessPiece.Chesscolour.black
        Else
            colourOfPieces = "white"
            Colour = ChessPiece.Chesscolour.white
        End If
        Piece_Selector(piece)
        chess_piece = piece
    End Sub
    'This decides what piece has been clicked, once done it will follow algorithms to show the user what moves they can use
    Private Sub Piece_Selector(piece)
        clearbuttons()
        If CheckWPawn.Contains(piece) Or CheckBPawn.Contains(piece) Then
            Pawn_CheckFirstNumber_Selector(piece)
            Promotion(FirstCheckNumber, piece)
        ElseIf CheckWRook.Contains(piece) Or CheckBRook.Contains(piece) Then
            Dim Chess_Piece As New Rook(piece.Left, piece.Top, Colour, piece)
            Chess_Piece.SetLoopBoundaries()
            PieceMover(Chess_Piece)
        ElseIf CheckWBishop.Contains(piece) Or CheckBBishop.Contains(piece) Then
            Dim Chess_Piece As New Bishop(piece.Left, piece.Top, Colour, piece)
            Chess_Piece.SetLoopBoundaries()
            PieceMover(Chess_Piece)
        ElseIf CheckWKnight.Contains(piece) Or CheckBKnight.Contains(piece) Then
            Dim Chess_Piece As New Knight(piece.Left, piece.Top, Colour, piece)
            PieceMover(Chess_Piece)
        ElseIf piece Is BKing Or piece Is WKing Then
            Dim Chess_Piece As New King(piece.Left, piece.Top, Colour, piece, KingButtons)
            PieceMover(Chess_Piece)
        ElseIf piece Is BQueen Or piece Is WQueen Then
            Dim Chess_Piece As New Queen(piece.Left, piece.Top, Colour, piece)
            Chess_Piece.SetLoopBoundaries()
            PieceMover(Chess_Piece)
        End If
    End Sub
    'Generates Pieces moves for the user
    Private Sub PieceMover(Chess_piece)
        Chess_piece.SetColour()
        Chess_piece.CheckMoves()
    End Sub
    'This figures which ID shoudl be used with certain pawn to find out if it has already been moved or not
    Public Sub Pawn_CheckFirstNumber_Selector(piece)
        For check = 0 To CheckWPawn.Count - 1
            If piece.name = CheckWPawn(check).Name Then
                FirstCheckNumber = check
            End If
        Next
        For check = 0 To CheckBPawn.Count - 1
            If piece.name = CheckBPawn(check).Name Then
                FirstCheckNumber = check + 8
            End If
        Next
    End Sub
    'This is the action for all of buttons the user can use to move a piece, it gets the coordinates then clears the buttons and then sets a new loction for the required piece
    Public Sub buttons_click(sender As Object, e As EventArgs)
        Dim buttons = DirectCast(sender, Button)
        xcoords = buttons.Left
        ycoords = buttons.Top
        clearbuttons()
        setNewLocation()
    End Sub
    'This runs at the end of each turn, it goes through each move the opposite side can make to check if the user is in check or checkmate
    Public Sub CheckforCheck()
        If WhiteTime.Enabled = True Then
            KingPiece = WKing
            colourOfPieces = "white"
        Else
            colourOfPieces = "black"
            KingPiece = BKing
        End If

        Dim CheckingCheck(7) As Boolean
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
            Dim checkTheKing As New Check_Checkmate(KingPiece, buttonsToUse)
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
        If CheckWPawn.Contains(chess_piece) Or CheckBPawn.Contains(chess_piece) Then
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
        For check = 0 To CheckWPawn.Count - 1
            If Piece.name = CheckWPawn(check).Name Then
                PawnPromotion(check) = UsersChoice
            End If
        Next
        For check = 0 To CheckBPawn.Count - 1
            If Piece.name = CheckBPawn(check).Name Then
                PawnPromotion(check + 8) = UsersChoice
            End If
        Next
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
    'This sets the pawns name, so if they pawn has been promoted, if it gets taken will display the name of the promotion
    Private Function SetPawnName(ByVal piece As Button)
        Dim name As String = ""
        For check = 0 To CheckWPawn.Count - 1
            If piece.Name = CheckWPawn(check).Name Then
                name = selectmovetype(check)
            End If
        Next
        For check = 0 To CheckBPawn.Count - 1
            If piece.Name = CheckBPawn(check).Name Then
                name = selectmovetype(check + 8)
            End If
        Next
        Return Name
    End Function
    'This sets the name for a promoted pawn for when it gets taken, this will display the name of what it promoted to as well as it being a pawn previously 
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
        If CheckWPawn.Contains(piece) Or CheckBPawn.Contains(piece) Then
            Piece_name = SetPawnName(piece)
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
            WQueen.Location = New Point(749, 287)
            Piece_name = "White Queen"
        ElseIf piece Is BQueen Then
            BQueen.Location = New Point(749, 520)
            Piece_name = "Black Queen"
        ElseIf piece Is WKing Then
            WKing.Location = New Point(807, 520)
            Piece_name = "White King"
        ElseIf piece Is BKing Then
            BKing.Location = New Point(807, 287)
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
        clearbuttons()
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
        clearbuttons()
    End Sub
    Private Sub Returnbtn_Click(sender As Object, e As EventArgs) Handles Returnbtn.Click
        endGameState = True
        Me.Close()
        MainMenu.Show()
    End Sub
    Public Sub Promotion(ByVal idenitifer As Integer, ByVal PawnPiece As Button)
        If PawnPromotion(idenitifer) = "BRook" Or PawnPromotion(idenitifer) = "WRook" Then
            Dim rooks As New Rook(PawnPiece.Left, PawnPiece.Top, Colour, PawnPiece)
            PawnRook = True
            clearbuttons()
            rooks.SetLoopBoundaries()
            PieceMover(rooks)
        ElseIf PawnPromotion(idenitifer) = "BKnight" Or PawnPromotion(idenitifer) = "WKnight" Then
            Dim knights As New Knight(PawnPiece.Left, PawnPiece.Top, Colour, PawnPiece)
            PawnKnight = True
            clearbuttons()
            PieceMover(knights)
        ElseIf PawnPromotion(idenitifer) = "BBishop" Or PawnPromotion(idenitifer) = "WBishop" Then
            Dim Bishops As New Bishop(PawnPiece.Left, PawnPiece.Top, Colour, PawnPiece)
            PawnBishop = True
            Bishops.SetLoopBoundaries()
            clearbuttons()
            PieceMover(Bishops)
        ElseIf PawnPromotion(idenitifer) = "BQueen" Or PawnPromotion(idenitifer) = "WQueen" Then
            Dim queen As New Queen(PawnPiece.Left, PawnPiece.Top, Colour, PawnPiece)
            PawnQueen = True
            clearbuttons()
            queen.SetLoopBoundaries()
            PieceMover(queen)
        ElseIf PawnPromotion(idenitifer) = "BPawn" Or PawnPromotion(idenitifer) = "WPawn" Then
            Dim Pawns As New Pawn(PawnPiece.Left, PawnPiece.Top, Colour, PawnPiece, FirstCheck(FirstCheckNumber))
            clearbuttons()
            PieceMover(Pawns)
        End If
    End Sub
    Public Sub Buttonxvalue(value)
        ButtonX_Causing_Check = value
    End Sub
    Public Sub Buttonyvalue(value)
        ButtonX_Causing_Check = value
    End Sub
End Class