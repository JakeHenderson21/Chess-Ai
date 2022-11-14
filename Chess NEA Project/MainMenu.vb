Imports System.IO
Public Class MainMenu
    Public AiMode As Boolean
    'closes the program
    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click
        End
    End Sub
    'Opens the player vs player
    Private Sub Player_Vs_Player_Click(sender As Object, e As EventArgs) Handles Player_Vs_Player.Click
        Me.Hide()
        AiMode = False
        ChessBoard.Show()
    End Sub
    'Opens Player vs Ai
    Private Sub Player_Vs_Ai_Click(sender As Object, e As EventArgs) Handles Player_Vs_Ai.Click
        Dim ai As New Chess_Ai
        Dim inputstring As String = ""
        If My.Computer.FileSystem.FileExists("NNInputWeights.csv") Then
        Else

            FileOpen(1, "NNInputWeights.csv", OpenMode.Output)
            ai.Inititlise_InputWeights()
            For i = 0 To 383
                inputstring = ""
                For j = 0 To 255
                    If i <> 383 Then
                        inputstring += ai.InputToHiddenLayerWeights(i, j).ToString & ","
                    Else
                        inputstring += ai.InputToHiddenLayerWeights(i, j).ToString
                    End If
                Next
                PrintLine(1, inputstring)
            Next
        End If
        FileClose(1)
        If My.Computer.FileSystem.FileExists("NN1stHiddenWeights.csv") Then
        Else
            FileOpen(2, "NN1stHiddenWeights.csv", OpenMode.Output)
            ai.StartofHiddenWeightsLoop = 0
            ai.EndofHiddenWeightsLoop = 0
            ai.Initilise_HiddenWeights()
            For i = 0 To 255
                inputstring = ""
                For j = 0 To 255
                    If j <> 255 Then

                        inputstring += ai.HiddenLayerWeights(i, j, 0).ToString & ","
                    Else
                        inputstring += ai.HiddenLayerWeights(i, j, 0).ToString
                    End If
                Next
                PrintLine(2, inputstring)
            Next
            FileClose(2)
        End If
        If My.Computer.FileSystem.FileExists("NN2ndHiddenWeights.csv") Then
        Else
            FileOpen(3, "NN2ndHiddenWeights.csv", OpenMode.Output)
            ai.StartofHiddenWeightsLoop = 1
            ai.EndofHiddenWeightsLoop = 1
            ai.Initilise_HiddenWeights()
            For i = 0 To 255
                inputstring = ""
                For j = 0 To 255
                    If j <> 255 Then
                        inputstring += ai.HiddenLayerWeights(i, j, 1).ToString & ","
                    Else
                        inputstring += ai.HiddenLayerWeights(i, j, 1).ToString
                    End If
                Next
                PrintLine(3, inputstring)
            Next
            FileClose(3)
        End If
        If My.Computer.FileSystem.FileExists("NN3rdHiddenWeights.csv") Then
        Else
            FileOpen(4, "NN3rdHiddenWeights.csv", OpenMode.Output)
            ai.StartofHiddenWeightsLoop = 2
            ai.EndofHiddenWeightsLoop = 2
            ai.Initilise_HiddenWeights()
            For i = 0 To 255
                inputstring = ""
                For j = 0 To 255
                    If j <> 255 Then
                        inputstring += ai.HiddenLayerWeights(i, j, 2).ToString & ","
                    Else
                        inputstring += ai.HiddenLayerWeights(i, j, 2).ToString
                    End If
                Next
                PrintLine(4, inputstring)
            Next
            FileClose(4)
        End If
        If My.Computer.FileSystem.FileExists("NNOutputWeights.csv") Then
        Else
            FileOpen(5, "NNOutputWeights.csv", OpenMode.Output)
            ai.Initilise_OutputWeights()
            For i = 0 To 255
                inputstring = ""
                For j = 0 To 203
                    If j <> 203 Then
                        inputstring += ai.HiddenToOutputLayerWeights(i, j).ToString & ","
                    Else
                        inputstring += ai.HiddenToOutputLayerWeights(i, j).ToString
                    End If
                Next
                PrintLine(5, inputstring)
            Next
            FileClose(5)
        End If
        If My.Computer.FileSystem.FileExists("NNBias.csv") Then
        Else
            File.Create("NNBias.csv")
            ai.Initilise_HiddenBias()
            For k = 0 To 3
                For i = 0 To 255
                    If i <> 203 Then
                        inputstring += ai.HiddenToOutputLayerWeights(k, i).ToString & ","
                    Else
                        inputstring += ai.HiddenToOutputLayerWeights(k, i).ToString
                    End If
                    inputstring += ai.HiddenBias(k, i)
                Next
            Next
        End If

        Me.Hide()
        AiMode = True
        ChessBoard.Show()
    End Sub
    'Opens Settings
    Private Sub SettingsBtn_Click(sender As Object, e As EventArgs) Handles SettingsBtn.Click
        Me.Hide()
        Settings.Show()
    End Sub
End Class