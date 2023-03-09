Public Class ChessPiece
    Enum Chesscolour
        white
        black
    End Enum
    Public X, Y, tx, ty, count, scoremove, upmovecount, rightmovecount, downmovecount, leftmovecount, buttonID, buttonsPastBorder, uprightmovecount, downrightmovecount, downleftmovecount, upleftmovecount, endofloop, startofloop As Integer
    Public colour As Chesscolour
    Public UpMoveButtonsCheck, RightMoveButtonsCheck, DownMoveButtonsCheck, LeftMoveButtonsCheck, UpRightMoveButtonsCheck, DownRightMoveButtonsCheck, DownLeftMoveButtonsCheck, UpLeftMoveButtonsCheck As New List(Of Button)
    Public change, sameColourChange, OppositeColourChange, movebuttonchecker As Boolean
    Public ButtonX_Causing_Check, ButtonY_Causing_Check As List(Of Integer)
    Public checkbuttons(6), upMovebutton(6), rightMoveButton(6), downMoveButton(6), leftMoveButton(6), upRightMoveButton(6), downRightMoveButton(6), downLeftMoveButton(6), upLeftMoveButton(6), wpieces(15), bpieces(15), piece, pieces1(15), pieces2(15) As Button
    Public Sub New(ByVal xCoord As Integer, ByVal yCoord As Integer, ByVal Chess_colour As Chesscolour, ByVal Chess_piece As Button)
        Dim counter As Integer
        X = xCoord
        Y = yCoord
        colour = Chess_colour
        piece = Chess_piece
        ButtonX_Causing_Check = ChessBoard.ButtonX_Causing_Check
        ButtonY_Causing_Check = ChessBoard.ButtonY_Causing_Check
        For X As ButtonMoveIndex = ButtonMoveIndex.upMovebuttonLow To ButtonMoveIndex.upMovebuttonHigh
            upMovebutton(X) = ChessBoard.buttonmoves(X)
        Next
        For X As ButtonMoveIndex = ButtonMoveIndex.rightMovebuttonLow To ButtonMoveIndex.rightMovebuttonHigh
            rightMoveButton(counter) = ChessBoard.buttonmoves(X)
            counter += 1
        Next
        counter = 0
        For X As ButtonMoveIndex = ButtonMoveIndex.downMovebuttonLow To ButtonMoveIndex.downMovebuttonHigh
            downMoveButton(counter) = ChessBoard.buttonmoves(X)
            counter += 1
        Next
        counter = 0
        For X As ButtonMoveIndex = ButtonMoveIndex.leftMovebuttonLow To ButtonMoveIndex.leftMovebuttonHigh
            leftMoveButton(counter) = ChessBoard.buttonmoves(X)
            counter += 1
        Next
        counter = 0
        For X As ButtonMoveIndex = ButtonMoveIndex.upRightMovebuttonLow To ButtonMoveIndex.upRightMovebuttonHigh
            upRightMoveButton(counter) = ChessBoard.buttonmoves(X)
            counter += 1
        Next
        counter = 0
        For X As ButtonMoveIndex = ButtonMoveIndex.downRightMovebuttonLow To ButtonMoveIndex.downRightMovebuttonHigh
            downRightMoveButton(counter) = ChessBoard.buttonmoves(X)
            counter += 1
        Next
        counter = 0
        For X As ButtonMoveIndex = ButtonMoveIndex.downLeftMovebuttonLow To ButtonMoveIndex.downLeftMovebuttonHigh
            downLeftMoveButton(counter) = ChessBoard.buttonmoves(X)
            counter += 1
        Next
        counter = 0
        For X As ButtonMoveIndex = ButtonMoveIndex.upLeftMovebuttonlow To ButtonMoveIndex.upLeftMovebuttonHigh
            upLeftMoveButton(counter) = ChessBoard.buttonmoves(X)
            counter += 1
        Next
        wpieces(0) = ChessBoard.WPawn1
        wpieces(1) = ChessBoard.WPawn2
        wpieces(2) = ChessBoard.WPawn3
        wpieces(3) = ChessBoard.WPawn4
        wpieces(4) = ChessBoard.WPawn5
        wpieces(5) = ChessBoard.WPawn6
        wpieces(6) = ChessBoard.WPawn7
        wpieces(7) = ChessBoard.WPawn8
        wpieces(8) = ChessBoard.WRook1
        wpieces(9) = ChessBoard.WRook2
        wpieces(10) = ChessBoard.WBishop1
        wpieces(11) = ChessBoard.WBishop2
        wpieces(12) = ChessBoard.WKnight1
        wpieces(13) = ChessBoard.Wknight2
        wpieces(14) = ChessBoard.WQueen
        wpieces(15) = ChessBoard.WKing
        bpieces(0) = ChessBoard.BPawn1
        bpieces(1) = ChessBoard.BPawn2
        bpieces(2) = ChessBoard.BPawn3
        bpieces(3) = ChessBoard.BPawn4
        bpieces(4) = ChessBoard.BPawn5
        bpieces(5) = ChessBoard.BPawn6
        bpieces(6) = ChessBoard.BPawn7
        bpieces(7) = ChessBoard.BPawn8
        bpieces(8) = ChessBoard.BRook1
        bpieces(9) = ChessBoard.BRook2
        bpieces(10) = ChessBoard.BBishop1
        bpieces(11) = ChessBoard.BBishop2
        bpieces(12) = ChessBoard.BKnight1
        bpieces(13) = ChessBoard.BKnight2
        bpieces(14) = ChessBoard.BQueen
        bpieces(15) = ChessBoard.BKing

    End Sub
    Public Function getColour()
        Return colour
    End Function
    'This sets colour of the pieces to be checked
    Public Overridable Sub SetColour()
        If colour = Chesscolour.black Then
            pieces1 = bpieces
            pieces2 = wpieces
        ElseIf colour = Chesscolour.white Then
            pieces1 = wpieces
            pieces2 = bpieces
        End If
    End Sub
    'This checks where the piece clicked can move by initailly placing all the move buttons and check to see if there is an obstruction in them and only show 
    ' the amount of it can move, this is used for rooks, bishops and queens by changing the size of the loop and checks each parts of the moves row by row, for example the order of checking buttons go up then right, left and down
    'When checking for check or checkmate it will how for each section of a piece can move then save it an array for checking later on after going through all parts of the piece
    Public Overridable Sub CheckMoves()
        Dim xcoordinate, ycoordinate, piecemove, l, tempscoremove, temppostionscore As Integer
        temppostionscore = count
        For t = startofloop To endofloop
            If ChessBoard.CheckWBishop.Contains(piece) Or ChessBoard.CheckBBishop.Contains(piece) Then
                ChessBoard.PawnBishop = True
            ElseIf ChessBoard.CheckWRook.Contains(piece) Or ChessBoard.CheckBRook.Contains(piece) Then
                ChessBoard.PawnRook = True
            ElseIf ChessBoard.CheckWQueen.Contains(piece) Or ChessBoard.CheckBQueen.Contains(piece) Then
                ChessBoard.PawnQueen = True
            End If
            change = False
            piecemove = 0
            l = 0
            scoremove = 0
            rearrangechecks(temppostionscore)
            xcoordinate = X + tx
            ycoordinate = Y + ty
            checkbuttons(0).Location = New Point(X + tx, Y + ty)
            checkbuttons(1).Location = New Point(X + (2 * tx), Y + (2 * ty))
            checkbuttons(2).Location = New Point(X + (3 * tx), Y + (3 * ty))
            checkbuttons(3).Location = New Point(X + (4 * tx), Y + (4 * ty))
            checkbuttons(4).Location = New Point(X + (5 * tx), Y + (5 * ty))
            checkbuttons(5).Location = New Point(X + (6 * tx), Y + (6 * ty))
            checkbuttons(6).Location = New Point(X + (7 * tx), Y + (7 * ty))
            For m = 0 To 6
                For Each p In pieces2
                    If p Is ChessBoard.WKnight1 Then
                        p = p
                    End If
                    If p.Left = xcoordinate And p.Top = ycoordinate Then
                        If l = 1 Then
                            If piecemove < scoremove Then
                                scoremove = piecemove
                            End If
                        Else
                            change = True
                            scoremove = piecemove + 1
                            l = 1
                        End If
                    End If
                Next
                piecemove += 1
                xcoordinate = xcoordinate + tx
                ycoordinate = ycoordinate + ty
            Next
            l = 0
            piecemove = 0
            tempscoremove = 0
            xcoordinate = X + tx
            ycoordinate = Y + ty
            change = False
            For m = 0 To 6
                For Each p In pieces1
                    If p.Left = xcoordinate And p.Top = ycoordinate Then
                        If l = 1 Then
                            If piecemove < tempscoremove Then
                                tempscoremove = piecemove
                            End If
                        Else
                            change = True
                            tempscoremove = piecemove + 1
                            l = 1
                        End If
                    End If
                Next
                piecemove += 1
                xcoordinate = xcoordinate + tx
                ycoordinate = ycoordinate + ty
            Next
            temppostionscore += 1
            If tempscoremove = 0 And scoremove = 0 Then
                scoremove = 0
            ElseIf tempscoremove < scoremove And tempscoremove <> 0 Then
                scoremove = tempscoremove - 1
                movebuttonchecker = True
            ElseIf tempscoremove > scoremove And scoremove = 0 Then
                scoremove = tempscoremove - 1
                movebuttonchecker = True
            ElseIf tempscoremove > scoremove And scoremove = 0 And tempscoremove <> 1 Then
                scoremove = tempscoremove - 1
                movebuttonchecker = True
            End If
            For Each Button In checkbuttons
                Button.Hide()
            Next
            If ChessBoard.CheckMode = True Then
                If movebuttonchecker = True Then
                    movebuttonchecker = False
                    scoremove += 1
                End If
                If scoremove = 0 Then
                    For Each Button In checkbuttons
                        If Button.Left > 539 Or Button.Left < 0 Or Button.Top > 539 Or Button.Top < 0 Then
                            buttonsPastBorder += 1
                        End If
                    Next
                End If
                If buttonsPastBorder = 7 Then
                    change = True
                    scoremove = 0
                End If
                buttonsPastBorder = 0
                If piece Is ChessBoard.WRook1 Or piece Is ChessBoard.WRook2 Or piece Is ChessBoard.BRook1 Or piece Is ChessBoard.BRook2 Or piece Is ChessBoard.WQueen Or piece Is ChessBoard.BQueen And count < 4 Or ChessBoard.PawnRook = True Or ChessBoard.PawnQueen = True Then
                    If count = 0 Then
                        If scoremove = 0 And change = True Then
                            upmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            upmovecount = 7
                        Else
                            If (piece.Left = ChessBoard.WKing.Left And piece.Top - (77 * scoremove) = ChessBoard.WKing.Top) Or (piece.Left = ChessBoard.BKing.Left And piece.Top - (77 * scoremove) = ChessBoard.BKing.Top) Then
                                upmovecount = scoremove + 1
                                scoremove += 1
                            Else
                                upmovecount = scoremove
                            End If
                        End If
                        UpMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 1 Then
                        If scoremove = 0 And change = True Then
                            rightmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            rightmovecount = 7
                        Else
                            If (piece.Left + (77 * scoremove) = ChessBoard.WKing.Left And piece.Top = ChessBoard.WKing.Top) Or (piece.Left + (77 * scoremove) = ChessBoard.BKing.Left And piece.Top = ChessBoard.BKing.Top) Then
                                rightmovecount = scoremove + 1
                                scoremove += 1
                            Else
                                rightmovecount = scoremove
                            End If
                        End If
                        RightMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 2 Then
                        If scoremove = 0 And change = True Then
                            downmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            downmovecount = 7
                        Else
                            If (piece.Left = ChessBoard.WKing.Left And piece.Top + (77 * scoremove) = ChessBoard.WKing.Top) Or (piece.Left = ChessBoard.BKing.Left And piece.Top + (77 * scoremove) = ChessBoard.BKing.Top) Then
                                downmovecount = scoremove + 1
                                scoremove += 1
                            Else
                                downmovecount = scoremove
                            End If
                        End If
                        DownMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 3 Then
                        If scoremove = 0 And change = True Then
                            leftmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            leftmovecount = 7
                        Else
                            If (piece.Left - (77 * scoremove) = ChessBoard.WKing.Left And piece.Top = ChessBoard.WKing.Top) Or (piece.Left - (77 * scoremove) = ChessBoard.BKing.Left And piece.Top = ChessBoard.BKing.Top) Then
                                leftmovecount = scoremove + 1
                                scoremove += 1
                            Else
                                leftmovecount = scoremove
                            End If
                        End If
                        LeftMoveButtonsCheck = StoreButtons(scoremove)
                    End If
                End If
                If piece Is ChessBoard.WBishop1 Or piece Is ChessBoard.WBishop2 Or piece Is ChessBoard.BBishop1 Or piece Is ChessBoard.BBishop2 Or piece Is ChessBoard.WQueen Or piece Is ChessBoard.BQueen And count >= 4 Or ChessBoard.PawnBishop = True Or ChessBoard.PawnQueen = True Then
                    If count = 4 Then
                        If scoremove = 0 And change = True Then
                            uprightmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            uprightmovecount = 7
                        Else
                            If (piece.Left + (77 * scoremove) = ChessBoard.WKing.Left And piece.Top - (77 * scoremove) = ChessBoard.WKing.Top) Or (piece.Left + (77 * scoremove) = ChessBoard.BKing.Left And piece.Top - (77 * scoremove) = ChessBoard.BKing.Top) Then
                                uprightmovecount = scoremove + 1
                                scoremove += 1
                            Else
                                uprightmovecount = scoremove
                            End If
                        End If
                        UpRightMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 5 Then
                        If scoremove = 0 And change = True Then
                            downrightmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            downrightmovecount = 7
                        Else
                            If (piece.Left + (77 * scoremove) = ChessBoard.WKing.Left And piece.Top + (77 * scoremove) = ChessBoard.WKing.Top) Or (piece.Left + (77 * scoremove) = ChessBoard.BKing.Left And piece.Top + (77 * scoremove) = ChessBoard.BKing.Top) Then
                                downrightmovecount = scoremove + 1
                                scoremove += 1
                            Else
                                downrightmovecount = scoremove
                            End If
                        End If
                        DownRightMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 6 Then
                        If scoremove = 0 And change = True Then
                            downleftmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            downleftmovecount = 7
                        Else
                            If (piece.Left - (77 * scoremove) = ChessBoard.WKing.Left And piece.Top + (77 * scoremove) = ChessBoard.WKing.Top) Or (piece.Left - (77 * scoremove) = ChessBoard.BKing.Left And piece.Top + (77 * scoremove) = ChessBoard.BKing.Top) Then
                                downleftmovecount = scoremove + 1
                                scoremove += 1
                            Else
                                downleftmovecount = scoremove
                            End If
                        End If
                        DownLeftMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 7 Then
                        If scoremove = 0 And change = True Then
                            upleftmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            upleftmovecount = 7
                        Else
                            If (piece.Left - (77 * scoremove) = ChessBoard.WKing.Left And piece.Top - (77 * scoremove) = ChessBoard.WKing.Top) Or (piece.Left - (77 * scoremove) = ChessBoard.BKing.Left And piece.Top - (77 * scoremove) = ChessBoard.BKing.Top) Then
                                upleftmovecount = scoremove + 1
                                scoremove += 1
                            Else
                                upleftmovecount = scoremove
                            End If

                        End If
                        UpLeftMoveButtonsCheck = StoreButtons(scoremove)
                    End If
                End If
                count += 1
                change = False
            Else
                If ChessBoard.WKinginCheck = True Or ChessBoard.BKinginCheck = True Then
                    rearrangechecks(temppostionscore - 1)
                    PieceMoveWhenChecked()
                Else
                    movebuttons(scoremove)
                End If
            End If
        Next
        count = 0
    End Sub
    'Stores the possible moves in lists to be used later
    Public Function StoreButtons(scoremove)
        Dim value As Integer
        If scoremove = 0 Then
            value = 0
        Else         
            value = -1
        End If
        Dim buttonholder As New List(Of Button)
        For Button = 0 To scoremove + value
            If Button < 6 Then
                buttonholder.Add(checkbuttons(Button))
            Else
                Exit For
            End If
        Next
        Return buttonholder
    End Function
    'This is where it goes checking each section in the loop, the loop id being the temppositionscore where each number represents a certain section
    Public Overridable Sub rearrangechecks(ByRef temppostionscore As Integer)
        If piece Is ChessBoard.WRook1 Or piece Is ChessBoard.WRook2 Or piece Is ChessBoard.WQueen Or piece Is ChessBoard.BRook1 Or piece Is ChessBoard.BRook2 Or piece Is ChessBoard.BQueen Or ChessBoard.PawnRook = True Or ChessBoard.PawnQueen = True Then
            If temppostionscore = 0 Then
                checkbuttons = upMovebutton
                tx = 0
                ty = -77
            ElseIf temppostionscore = 1 Then
                checkbuttons = rightMoveButton
                tx = 77
                ty = 0
            ElseIf temppostionscore = 2 Then
                checkbuttons = downMoveButton
                tx = 0
                ty = 77
            ElseIf temppostionscore = 3 Then
                checkbuttons = leftMoveButton
                tx = -77
                ty = 0
            End If
        End If
        If piece Is ChessBoard.WBishop1 Or piece Is ChessBoard.WBishop2 Or piece Is ChessBoard.WQueen Or piece Is ChessBoard.BBishop1 Or piece Is ChessBoard.BBishop2 Or piece Is ChessBoard.BQueen Or ChessBoard.PawnBishop = True Or ChessBoard.PawnQueen = True Then
            If temppostionscore = 4 Then
                checkbuttons = upRightMoveButton
                tx = 77
                ty = -77
            ElseIf temppostionscore = 5 Then
                checkbuttons = downRightMoveButton
                tx = 77
                ty = 77
            ElseIf temppostionscore = 6 Then
                checkbuttons = downLeftMoveButton
                tx = -77
                ty = 77
            ElseIf temppostionscore = 7 Then
                checkbuttons = upLeftMoveButton
                tx = -77
                ty = -77
            End If
        End If
    End Sub
    'This displays all the buttons the piece can make for each section
    Private Sub movebuttons(ByRef scoremove As Integer)
        If scoremove = 0 Then
            If change = True Then
            Else
                checkbuttons(0).Show()
                checkbuttons(1).Show()
                checkbuttons(2).Show()
                checkbuttons(3).Show()
                checkbuttons(4).Show()
                checkbuttons(5).Show()
                checkbuttons(6).Show()
            End If
        ElseIf scoremove = 1 Then
            checkbuttons(0).Show()
        ElseIf scoremove = 2 Then
            checkbuttons(0).Show()
            checkbuttons(1).Show()
        ElseIf scoremove = 3 Then
            checkbuttons(0).Show()
            checkbuttons(1).Show()
            checkbuttons(2).Show()
        ElseIf scoremove = 4 Then
            checkbuttons(0).Show()
            checkbuttons(1).Show()
            checkbuttons(2).Show()
            checkbuttons(3).Show()
        ElseIf scoremove = 5 Then
            checkbuttons(0).Show()
            checkbuttons(1).Show()
            checkbuttons(2).Show()
            checkbuttons(3).Show()
            checkbuttons(4).Show()
        ElseIf scoremove = 6 Then
            checkbuttons(0).Show()
            checkbuttons(1).Show()
            checkbuttons(2).Show()
            checkbuttons(3).Show()
            checkbuttons(4).Show()
            checkbuttons(5).Show()
        ElseIf scoremove = 7 Then
            checkbuttons(0).Show()
            checkbuttons(1).Show()
            checkbuttons(2).Show()
            checkbuttons(3).Show()
            checkbuttons(4).Show()
            checkbuttons(5).Show()
            checkbuttons(6).Show()
        End If
        For Each Button In ChessBoard.buttonmoves
            If Button.Left > 539 Or Button.Left < 0 Or Button.Top > 539 Or Button.Top < 0 Then
                Button.Hide()
            End If
        Next
        scoremove = 0
    End Sub
    Protected Overridable Sub PieceMoveWhenChecked()
        Dim totalbuttonchecks As Integer
        If ButtonX_Causing_Check.Count > 8 Then
            totalbuttonchecks = 8
        Else
            totalbuttonchecks = ButtonX_Causing_Check.Count - 1
        End If
        For i = 0 To totalbuttonchecks
            If scoremove = 0 And change = False Then
                For j = 0 To 7 - 1
                    If checkbuttons(j).Left = ButtonX_Causing_Check(i) And checkbuttons(j).Top = ButtonY_Causing_Check(i) Then
                        checkbuttons(j).Show()
                    End If
                Next
            Else
                For j = 0 To scoremove - 1
                    If checkbuttons(j).Left = ButtonX_Causing_Check(i) And checkbuttons(j).Top = ButtonY_Causing_Check(i) Then
                        checkbuttons(j).Show()
                    End If
                Next
            End If        
        Next
    End Sub
End Class