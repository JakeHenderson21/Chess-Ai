<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Player_Vs_Player = New System.Windows.Forms.Button()
        Me.Player_Vs_Ai = New System.Windows.Forms.Button()
        Me.ExitBtn = New System.Windows.Forms.Button()
        Me.SettingsBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(259, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 55)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Chess"
        '
        'Player_Vs_Player
        '
        Me.Player_Vs_Player.Location = New System.Drawing.Point(254, 226)
        Me.Player_Vs_Player.Name = "Player_Vs_Player"
        Me.Player_Vs_Player.Size = New System.Drawing.Size(178, 69)
        Me.Player_Vs_Player.TabIndex = 1
        Me.Player_Vs_Player.Text = "Player vs Player"
        Me.Player_Vs_Player.UseVisualStyleBackColor = True
        '
        'Player_Vs_Ai
        '
        Me.Player_Vs_Ai.Location = New System.Drawing.Point(254, 322)
        Me.Player_Vs_Ai.Name = "Player_Vs_Ai"
        Me.Player_Vs_Ai.Size = New System.Drawing.Size(178, 69)
        Me.Player_Vs_Ai.TabIndex = 2
        Me.Player_Vs_Ai.Text = "Player vs Ai"
        Me.Player_Vs_Ai.UseVisualStyleBackColor = True
        '
        'ExitBtn
        '
        Me.ExitBtn.Location = New System.Drawing.Point(254, 513)
        Me.ExitBtn.Name = "ExitBtn"
        Me.ExitBtn.Size = New System.Drawing.Size(178, 69)
        Me.ExitBtn.TabIndex = 3
        Me.ExitBtn.Text = "Exit"
        Me.ExitBtn.UseVisualStyleBackColor = True
        '
        'SettingsBtn
        '
        Me.SettingsBtn.Location = New System.Drawing.Point(254, 420)
        Me.SettingsBtn.Name = "SettingsBtn"
        Me.SettingsBtn.Size = New System.Drawing.Size(178, 69)
        Me.SettingsBtn.TabIndex = 4
        Me.SettingsBtn.Text = "Settings"
        Me.SettingsBtn.UseVisualStyleBackColor = True
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(700, 617)
        Me.Controls.Add(Me.SettingsBtn)
        Me.Controls.Add(Me.ExitBtn)
        Me.Controls.Add(Me.Player_Vs_Ai)
        Me.Controls.Add(Me.Player_Vs_Player)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MainMenu"
        Me.Text = "MainMenu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Player_Vs_Player As Button
    Friend WithEvents Player_Vs_Ai As Button
    Friend WithEvents ExitBtn As Button
    Friend WithEvents SettingsBtn As Button
End Class
