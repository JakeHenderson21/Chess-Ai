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
    'Opens Player vs Ai and generates the weights and biases for the neural network if they haven't already been generated
    Private Sub Player_Vs_Ai_Click(sender As Object, e As EventArgs) Handles Player_Vs_Ai.Click
        ChessBoard.Show()
        ChessBoard.Hide()
        Dim ai As New Chess_Ai
        Dim inputstring As String = ""
        If My.Computer.FileSystem.FileExists("NNInputWeights.csv") Then
        Else
            FileOpen(1, "NNInputWeights.csv", OpenMode.Output)
            ai.Inititlise_InputWeights()
            For j = 0 To 255
                inputstring = ""
                For i = 0 To 383
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
            System.Threading.Thread.Sleep(1000)
            FileOpen(2, "NN1stHiddenWeights.csv", OpenMode.Output)
            ai.hiddenLoopID = 0
            ai.Initilise_HiddenWeights()
            GenerateWeights(inputstring, ai)
            FileClose(2)
        End If
        If My.Computer.FileSystem.FileExists("NN2ndHiddenWeights.csv") Then
        Else
            System.Threading.Thread.Sleep(1000)
            FileOpen(3, "NN2ndHiddenWeights.csv", OpenMode.Output)
            ai.hiddenLoopID = 1
            ai.Initilise_HiddenWeights()
            GenerateWeights(inputstring, ai)
            FileClose(3)
        End If
        If My.Computer.FileSystem.FileExists("NN3rdHiddenWeights.csv") Then
        Else
            System.Threading.Thread.Sleep(1000)
            FileOpen(4, "NN3rdHiddenWeights.csv", OpenMode.Output)
            ai.hiddenLoopID = 2
            ai.Initilise_HiddenWeights()
            GenerateWeights(inputstring, ai)
            FileClose(4)
        End If
        If My.Computer.FileSystem.FileExists("NNOutputWeights.csv") Then
        Else
            System.Threading.Thread.Sleep(1000)
            FileOpen(5, "NNOutputWeights.csv", OpenMode.Output)
            ai.Initilise_OutputWeights()
            For j = 0 To 203
                inputstring = ""
                For i = 0 To 255
                    If i <> 255 Then
                        inputstring += ai.HiddenToOutputLayerWeights(i, j).ToString & ","
                    Else
                        inputstring += ai.HiddenToOutputLayerWeights(i, j).ToString
                    End If
                Next
                PrintLine(5, inputstring)
            Next
            FileClose(5)
        End If
        If My.Computer.FileSystem.FileExists("NNHiddenBias.csv") Then
        Else
            System.Threading.Thread.Sleep(1000)
            FileOpen(6, "NNHiddenBias.csv", OpenMode.Output)
            ai.Initilise_HiddenBias()
            For i = 0 To 3
                inputstring = ""
                For k = 0 To 255
                    If k <> 255 Then
                        inputstring += ai.HiddenBias(k, i).ToString & ","
                    Else
                        inputstring += ai.HiddenBias(k, i).ToString
                    End If
                Next
                PrintLine(6, inputstring)
            Next
            FileClose(6)
        End If
        If My.Computer.FileSystem.FileExists("NNOutputBias.txt") Then
        Else
            System.Threading.Thread.Sleep(1000)
            FileOpen(7, "NNOutputBias.txt", OpenMode.Output)
            ai.Inititlise_OutputBias()
            For i = 0 To 203
                PrintLine(7, ai.OutputBias(i))
            Next
            FileClose(7)
        End If
        Me.Hide()
        AiMode = True
        ChessBoard.Show()
    End Sub
    'Generates the weights then inputs them into an excel file for later use
    Private Sub GenerateWeights(inputstring, ai)
        For i = 0 To 255
            inputstring = ""
            For j = 0 To 255
                If j <> 255 Then
                    inputstring += ai.HiddenLayerWeights(i, j, ai.hiddenLoopID).ToString & ","
                Else
                    inputstring += ai.HiddenLayerWeights(i, j, ai.hiddenLoopID).ToString
                End If
            Next
            PrintLine(ai.hiddenLoopID + 2, inputstring)
        Next
    End Sub
    'Opens Settings
    Private Sub SettingsBtn_Click(sender As Object, e As EventArgs) Handles SettingsBtn.Click
        Me.Hide()
        Settings.Show()
    End Sub
End Class