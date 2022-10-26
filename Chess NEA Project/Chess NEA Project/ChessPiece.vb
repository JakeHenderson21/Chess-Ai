Public Class ChessPiece
    Enum Chesscolour
        white
        black
    End Enum
    Public X, Y, tx, ty, count, scoremove, upmovecount, rightmovecount, downmovecount, leftmovecount, buttonID, buttonsPastBorder, uprightmovecount, downrightmovecount, downleftmovecount, upleftmovecount, endofloop, startofloop As Integer
    Public colour As Chesscolour
    Public UpMoveButtonsCheck, RightMoveButtonsCheck, DownMoveButtonsCheck, LeftMoveButtonsCheck, UpRightMoveButtonsCheck, DownRightMoveButtonsCheck, DownLeftMoveButtonsCheck, UpLeftMoveButtonsCheck As New List(Of Button)
    Public change, sameColourChange, OppositeColourChange, movebuttonchecker As Boolean
    Public checkbuttons(6), upMovebutton(6), rightMoveButton(6), downMoveButton(6), leftMoveButton(6), upRightMoveButton(6), downRightMoveButton(6), downLeftMoveButton(6), upLeftMoveButton(6), wpieces(15), bpieces(15), piece, buttonMoves(71), pieces1(15), pieces2(15) As Button
    Public Sub New(ByVal xCoord As Integer, ByVal yCoord As Integer, ByVal Chess_colour As Chesscolour, ByVal Chess_piece As Button)
        X = xCoord
        Y = yCoord
        colour = Chess_colour
        piece = Chess_piece
        upMovebutton(0) = ChessBoard.Button1
        upMovebutton(1) = ChessBoard.Button2
        upMovebutton(2) = ChessBoard.Button3
        upMovebutton(3) = ChessBoard.Button4
        upMovebutton(4) = ChessBoard.Button5
        upMovebutton(5) = ChessBoard.Button6
        upMovebutton(6) = ChessBoard.Button7
        rightMoveButton(0) = ChessBoard.Button8
        rightMoveButton(1) = ChessBoard.Button9
        rightMoveButton(2) = ChessBoard.Button10
        rightMoveButton(3) = ChessBoard.Button11
        rightMoveButton(4) = ChessBoard.Button12
        rightMoveButton(5) = ChessBoard.Button13
        rightMoveButton(6) = ChessBoard.Button14
        downMoveButton(0) = ChessBoard.Button15
        downMoveButton(1) = ChessBoard.Button16
        downMoveButton(2) = ChessBoard.Button17
        downMoveButton(3) = ChessBoard.Button18
        downMoveButton(4) = ChessBoard.Button19
        downMoveButton(5) = ChessBoard.Button20
        downMoveButton(6) = ChessBoard.Button21
        leftMoveButton(0) = ChessBoard.Button22
        leftMoveButton(1) = ChessBoard.Button23
        leftMoveButton(2) = ChessBoard.Button24
        leftMoveButton(3) = ChessBoard.Button25
        leftMoveButton(4) = ChessBoard.Button26
        leftMoveButton(5) = ChessBoard.Button27
        leftMoveButton(6) = ChessBoard.Button28
        upRightMoveButton(0) = ChessBoard.Button29
        upRightMoveButton(1) = ChessBoard.Button30
        upRightMoveButton(2) = ChessBoard.Button31
        upRightMoveButton(3) = ChessBoard.Button32
        upRightMoveButton(4) = ChessBoard.Button33
        upRightMoveButton(5) = ChessBoard.Button34
        upRightMoveButton(6) = ChessBoard.Button35
        downRightMoveButton(0) = ChessBoard.Button36
        downRightMoveButton(1) = ChessBoard.Button37
        downRightMoveButton(2) = ChessBoard.Button38
        downRightMoveButton(3) = ChessBoard.Button39
        downRightMoveButton(4) = ChessBoard.Button40
        downRightMoveButton(5) = ChessBoard.Button41
        downRightMoveButton(6) = ChessBoard.Button42
        downLeftMoveButton(0) = ChessBoard.Button43
        downLeftMoveButton(1) = ChessBoard.Button44
        downLeftMoveButton(2) = ChessBoard.Button45
        downLeftMoveButton(3) = ChessBoard.Button46
        downLeftMoveButton(4) = ChessBoard.Button47
        downLeftMoveButton(5) = ChessBoard.Button48
        downLeftMoveButton(6) = ChessBoard.Button49
        upLeftMoveButton(0) = ChessBoard.Button50
        upLeftMoveButton(1) = ChessBoard.Button51
        upLeftMoveButton(2) = ChessBoard.Button52
        upLeftMoveButton(3) = ChessBoard.Button53
        upLeftMoveButton(4) = ChessBoard.Button54
        upLeftMoveButton(5) = ChessBoard.Button55
        upLeftMoveButton(6) = ChessBoard.Button56
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
        buttonMoves(0) = ChessBoard.Button1
        buttonMoves(1) = ChessBoard.Button2
        buttonMoves(2) = ChessBoard.Button3
        buttonMoves(3) = ChessBoard.Button4
        buttonMoves(4) = ChessBoard.Button5
        buttonMoves(5) = ChessBoard.Button6
        buttonMoves(6) = ChessBoard.Button7
        buttonMoves(7) = ChessBoard.Button8
        buttonMoves(8) = ChessBoard.Button9
        buttonMoves(9) = ChessBoard.Button10
        buttonMoves(10) = ChessBoard.Button11
        buttonMoves(11) = ChessBoard.Button12
        buttonMoves(12) = ChessBoard.Button13
        buttonMoves(13) = ChessBoard.Button14
        buttonMoves(14) = ChessBoard.Button15
        buttonMoves(15) = ChessBoard.Button16
        buttonMoves(16) = ChessBoard.Button17
        buttonMoves(17) = ChessBoard.Button18
        buttonMoves(18) = ChessBoard.Button19
        buttonMoves(19) = ChessBoard.Button20
        buttonMoves(20) = ChessBoard.Button21
        buttonMoves(21) = ChessBoard.Button22
        buttonMoves(22) = ChessBoard.Button23
        buttonMoves(23) = ChessBoard.Button24
        buttonMoves(24) = ChessBoard.Button25
        buttonMoves(25) = ChessBoard.Button26
        buttonMoves(26) = ChessBoard.Button27
        buttonMoves(27) = ChessBoard.Button28
        buttonMoves(28) = ChessBoard.Button29
        buttonMoves(29) = ChessBoard.Button30
        buttonMoves(30) = ChessBoard.Button31
        buttonMoves(31) = ChessBoard.Button32
        buttonMoves(32) = ChessBoard.Button33
        buttonMoves(33) = ChessBoard.Button34
        buttonMoves(34) = ChessBoard.Button35
        buttonMoves(35) = ChessBoard.Button36
        buttonMoves(36) = ChessBoard.Button37
        buttonMoves(37) = ChessBoard.Button38
        buttonMoves(38) = ChessBoard.Button39
        buttonMoves(39) = ChessBoard.Button40
        buttonMoves(40) = ChessBoard.Button41
        buttonMoves(41) = ChessBoard.Button42
        buttonMoves(42) = ChessBoard.Button43
        buttonMoves(43) = ChessBoard.Button44
        buttonMoves(44) = ChessBoard.Button45
        buttonMoves(45) = ChessBoard.Button46
        buttonMoves(46) = ChessBoard.Button47
        buttonMoves(47) = ChessBoard.Button48
        buttonMoves(48) = ChessBoard.Button49
        buttonMoves(49) = ChessBoard.Button50
        buttonMoves(50) = ChessBoard.Button51
        buttonMoves(51) = ChessBoard.Button52
        buttonMoves(52) = ChessBoard.Button53
        buttonMoves(53) = ChessBoard.Button54
        buttonMoves(54) = ChessBoard.Button55
        buttonMoves(55) = ChessBoard.Button56
        buttonMoves(56) = ChessBoard.Button57
        buttonMoves(57) = ChessBoard.Button58
        buttonMoves(58) = ChessBoard.Button59
        buttonMoves(59) = ChessBoard.Button60
        buttonMoves(60) = ChessBoard.Button61
        buttonMoves(61) = ChessBoard.Button62
        buttonMoves(62) = ChessBoard.Button63
        buttonMoves(63) = ChessBoard.Button64
        buttonMoves(64) = ChessBoard.Button65
        buttonMoves(65) = ChessBoard.Button66
        buttonMoves(66) = ChessBoard.Button67
        buttonMoves(67) = ChessBoard.Button68
        buttonMoves(68) = ChessBoard.Button69
        buttonMoves(69) = ChessBoard.Button70
        buttonMoves(70) = ChessBoard.Button71
        buttonMoves(71) = ChessBoard.Button72
    End Sub
    Public Function getColour()
        Return colour
    End Function
    Public Overridable Sub SetColour()
        If colour = Chesscolour.black Then
            pieces1 = bpieces
            pieces2 = wpieces
        ElseIf colour = Chesscolour.white Then
            pieces1 = wpieces
            pieces2 = bpieces
        End If
    End Sub
    Public Overridable Sub CheckMoves()
        Dim xcoordinate, ycoordinate, piecemove, l, tempscoremove, temppostionscore As Integer
        temppostionscore = count
        For t = startofloop To endofloop
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
                If piece Is ChessBoard.WRook1 Or piece Is ChessBoard.WRook2 Or piece Is ChessBoard.BRook1 Or piece Is ChessBoard.BRook2 Or piece Is ChessBoard.WQueen Or piece Is ChessBoard.BQueen Then
                    If count = 0 Then
                        If scoremove = 0 And change = True Then
                            upmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            upmovecount = 7
                        Else
                            upmovecount = scoremove + 1
                            scoremove += 1
                        End If
                        UpMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 1 Then
                        If scoremove = 0 And change = True Then
                            rightmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            rightmovecount = 7
                        Else
                            rightmovecount = scoremove + 1
                            scoremove += 1
                        End If
                        RightMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 2 Then
                        If scoremove = 0 And change = True Then
                            downmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            downmovecount = 7
                        Else
                            downmovecount = scoremove + 1
                            scoremove += 1
                        End If
                        DownMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 3 Then
                        If scoremove = 0 And change = True Then
                            leftmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            leftmovecount = 7
                        Else
                            leftmovecount = scoremove + 1
                            If (checkbuttons(scoremove).Left = ChessBoard.KingPiece.Left And checkbuttons(scoremove).Top = ChessBoard.KingPiece.Top) Then
                            Else
                                scoremove += 1
                            End If
                        End If
                        LeftMoveButtonsCheck = StoreButtons(scoremove)
                    End If
                End If
                If piece Is ChessBoard.WBishop1 Or piece Is ChessBoard.WBishop2 Or piece Is ChessBoard.BBishop1 Or piece Is ChessBoard.BBishop2 Or piece Is ChessBoard.WQueen Or piece Is ChessBoard.BQueen And count >= 4 Then
                    If count = 4 Then
                        If scoremove = 0 And change = True Then
                            uprightmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            uprightmovecount = 7
                        Else
                            uprightmovecount = scoremove + 1
                            scoremove += 1
                        End If
                        UpRightMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 5 Then
                        If scoremove = 0 And change = True Then
                            downrightmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            downrightmovecount = 7
                        Else
                            downrightmovecount = scoremove + 1
                            scoremove += 1
                        End If
                        DownRightMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 6 Then
                        If scoremove = 0 And change = True Then
                            downleftmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            downleftmovecount = 7
                        Else
                            downleftmovecount = scoremove + 1
                            scoremove += 1
                        End If
                        DownLeftMoveButtonsCheck = StoreButtons(scoremove)
                    ElseIf count = 7 Then
                        If scoremove = 0 And change = True Then
                            upleftmovecount = scoremove
                        ElseIf scoremove = 0 And change = False Then
                            scoremove = 7
                            upleftmovecount = 7
                        Else
                            upleftmovecount = scoremove + 1
                            scoremove += 1
                        End If
                        UpLeftMoveButtonsCheck = StoreButtons(scoremove)
                    End If
                End If
                count += 1
                change = False
            Else
                movebuttons(scoremove)
            End If
        Next
        count = 0
    End Sub
    Public Function StoreButtons(scoremove)
        Dim value As Integer
        If scoremove = 0 Then
            value = 0
        Else         
            value = -1
        End If
        Dim buttonholder As New List(Of Button)
        For Button = 0 To scoremove + value
            checkbuttons(Button).Name = checkbuttons(Button).Name
            buttonholder.Add(checkbuttons(Button))
        Next
        Return buttonholder
    End Function
    Public Sub clearbuttons()
        For Each Button In buttonMoves
            Button.Hide()
            Button.Location = New Point(1000, 1000)
        Next
    End Sub
    Public Overridable Sub rearrangechecks(ByRef temppostionscore As Integer)
        If piece Is ChessBoard.WRook1 Or piece Is ChessBoard.WRook2 Or piece Is ChessBoard.WQueen Or piece Is ChessBoard.BRook1 Or piece Is ChessBoard.BRook2 Or piece Is ChessBoard.BQueen Then
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
        If piece Is ChessBoard.WBishop1 Or piece Is ChessBoard.WBishop2 Or piece Is ChessBoard.WQueen Or piece Is ChessBoard.BBishop1 Or piece Is ChessBoard.BBishop2 Or piece Is ChessBoard.BQueen Then
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
        For Each Button In buttonMoves
            If Button.Left > 539 Or Button.Left < 0 Or Button.Top > 539 Or Button.Top < 0 Then
                Button.Hide()
            End If
        Next
        scoremove = 0
    End Sub
End Class
