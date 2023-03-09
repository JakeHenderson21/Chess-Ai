<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChessBoard
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChessBoard))
        Me.chess_Board = New System.Windows.Forms.PictureBox()
        Me.WhiteTime = New System.Windows.Forms.Timer(Me.components)
        Me.BlackTime = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.WPawn5 = New System.Windows.Forms.Button()
        Me.BQueen = New System.Windows.Forms.Button()
        Me.WPawn2 = New System.Windows.Forms.Button()
        Me.BPawn5 = New System.Windows.Forms.Button()
        Me.BBishop2 = New System.Windows.Forms.Button()
        Me.WPawn4 = New System.Windows.Forms.Button()
        Me.WPawn1 = New System.Windows.Forms.Button()
        Me.BKing = New System.Windows.Forms.Button()
        Me.WPawn3 = New System.Windows.Forms.Button()
        Me.BKnight2 = New System.Windows.Forms.Button()
        Me.BBishop1 = New System.Windows.Forms.Button()
        Me.BKnight1 = New System.Windows.Forms.Button()
        Me.BPawn8 = New System.Windows.Forms.Button()
        Me.WKing = New System.Windows.Forms.Button()
        Me.BRook1 = New System.Windows.Forms.Button()
        Me.BRook2 = New System.Windows.Forms.Button()
        Me.BPawn7 = New System.Windows.Forms.Button()
        Me.BPawn6 = New System.Windows.Forms.Button()
        Me.BPawn1 = New System.Windows.Forms.Button()
        Me.BPawn2 = New System.Windows.Forms.Button()
        Me.BPawn3 = New System.Windows.Forms.Button()
        Me.WKnight1 = New System.Windows.Forms.Button()
        Me.Wknight2 = New System.Windows.Forms.Button()
        Me.WQueen = New System.Windows.Forms.Button()
        Me.BPawn4 = New System.Windows.Forms.Button()
        Me.WBishop1 = New System.Windows.Forms.Button()
        Me.WRook2 = New System.Windows.Forms.Button()
        Me.WRook1 = New System.Windows.Forms.Button()
        Me.WBishop2 = New System.Windows.Forms.Button()
        Me.WPawn8 = New System.Windows.Forms.Button()
        Me.WPawn7 = New System.Windows.Forms.Button()
        Me.WPawn6 = New System.Windows.Forms.Button()
        Me.Button64 = New System.Windows.Forms.Button()
        Me.WhiteTextBox = New System.Windows.Forms.Label()
        Me.BlackTextBox = New System.Windows.Forms.Label()
        Me.Returnbtn = New System.Windows.Forms.Button()
        CType(Me.chess_Board,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'chess_Board
        '
        Me.chess_Board.BackColor = System.Drawing.Color.White
        Me.chess_Board.BackgroundImage = CType(resources.GetObject("chess_Board.BackgroundImage"),System.Drawing.Image)
        Me.chess_Board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.chess_Board.Location = New System.Drawing.Point(-4, -20)
        Me.chess_Board.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chess_Board.Name = "chess_Board"
        Me.chess_Board.Size = New System.Drawing.Size(832, 800)
        Me.chess_Board.TabIndex = 0
        Me.chess_Board.TabStop = False
        '
        'WhiteTime
        '
        Me.WhiteTime.Interval = 1000
        '
        'BlackTime
        '
        Me.BlackTime.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(840, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "White's time:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(968, 36)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Black's time:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(845, 139)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(311, 646)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'WPawn5
        '
        Me.WPawn5.BackColor = System.Drawing.Color.Transparent
        Me.WPawn5.BackgroundImage = CType(resources.GetObject("WPawn5.BackgroundImage"), System.Drawing.Image)
        Me.WPawn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WPawn5.FlatAppearance.BorderSize = 0
        Me.WPawn5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WPawn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WPawn5.ForeColor = System.Drawing.Color.Transparent
        Me.WPawn5.Location = New System.Drawing.Point(844, 210)
        Me.WPawn5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WPawn5.Name = "WPawn5"
        Me.WPawn5.Size = New System.Drawing.Size(80, 74)
        Me.WPawn5.TabIndex = 6
        Me.WPawn5.UseVisualStyleBackColor = False
        '
        'BQueen
        '
        Me.BQueen.BackColor = System.Drawing.Color.Transparent
        Me.BQueen.BackgroundImage = CType(resources.GetObject("BQueen.BackgroundImage"), System.Drawing.Image)
        Me.BQueen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BQueen.FlatAppearance.BorderSize = 0
        Me.BQueen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BQueen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BQueen.ForeColor = System.Drawing.Color.Transparent
        Me.BQueen.Location = New System.Drawing.Point(999, 640)
        Me.BQueen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BQueen.Name = "BQueen"
        Me.BQueen.Size = New System.Drawing.Size(80, 74)
        Me.BQueen.TabIndex = 7
        Me.BQueen.UseVisualStyleBackColor = False
        '
        'WPawn2
        '
        Me.WPawn2.BackColor = System.Drawing.Color.Transparent
        Me.WPawn2.BackgroundImage = CType(resources.GetObject("WPawn2.BackgroundImage"), System.Drawing.Image)
        Me.WPawn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WPawn2.FlatAppearance.BorderSize = 0
        Me.WPawn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WPawn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WPawn2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WPawn2.Location = New System.Drawing.Point(921, 138)
        Me.WPawn2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WPawn2.Name = "WPawn2"
        Me.WPawn2.Size = New System.Drawing.Size(80, 74)
        Me.WPawn2.TabIndex = 8
        Me.WPawn2.UseVisualStyleBackColor = True
        '
        'BPawn5
        '
        Me.BPawn5.BackColor = System.Drawing.Color.Transparent
        Me.BPawn5.BackgroundImage = CType(resources.GetObject("BPawn5.BackgroundImage"), System.Drawing.Image)
        Me.BPawn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BPawn5.FlatAppearance.BorderSize = 0
        Me.BPawn5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BPawn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BPawn5.ForeColor = System.Drawing.Color.Transparent
        Me.BPawn5.Location = New System.Drawing.Point(844, 494)
        Me.BPawn5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BPawn5.Name = "BPawn5"
        Me.BPawn5.Size = New System.Drawing.Size(80, 74)
        Me.BPawn5.TabIndex = 9
        Me.BPawn5.UseVisualStyleBackColor = False
        '
        'BBishop2
        '
        Me.BBishop2.BackColor = System.Drawing.Color.Transparent
        Me.BBishop2.BackgroundImage = CType(resources.GetObject("BBishop2.BackgroundImage"), System.Drawing.Image)
        Me.BBishop2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BBishop2.FlatAppearance.BorderSize = 0
        Me.BBishop2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BBishop2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BBishop2.ForeColor = System.Drawing.Color.Transparent
        Me.BBishop2.Location = New System.Drawing.Point(1076, 567)
        Me.BBishop2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BBishop2.Name = "BBishop2"
        Me.BBishop2.Size = New System.Drawing.Size(80, 74)
        Me.BBishop2.TabIndex = 10
        Me.BBishop2.UseVisualStyleBackColor = False
        '
        'WPawn4
        '
        Me.WPawn4.BackColor = System.Drawing.Color.Transparent
        Me.WPawn4.BackgroundImage = CType(resources.GetObject("WPawn4.BackgroundImage"), System.Drawing.Image)
        Me.WPawn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WPawn4.FlatAppearance.BorderSize = 0
        Me.WPawn4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WPawn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WPawn4.ForeColor = System.Drawing.Color.Transparent
        Me.WPawn4.Location = New System.Drawing.Point(1076, 138)
        Me.WPawn4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WPawn4.Name = "WPawn4"
        Me.WPawn4.Size = New System.Drawing.Size(80, 74)
        Me.WPawn4.TabIndex = 11
        Me.WPawn4.UseVisualStyleBackColor = False
        '
        'WPawn1
        '
        Me.WPawn1.BackColor = System.Drawing.Color.Transparent
        Me.WPawn1.BackgroundImage = CType(resources.GetObject("WPawn1.BackgroundImage"), System.Drawing.Image)
        Me.WPawn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WPawn1.FlatAppearance.BorderSize = 0
        Me.WPawn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WPawn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.WPawn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WPawn1.ForeColor = System.Drawing.Color.Transparent
        Me.WPawn1.Location = New System.Drawing.Point(843, 138)
        Me.WPawn1.Margin = New System.Windows.Forms.Padding(0)
        Me.WPawn1.Name = "WPawn1"
        Me.WPawn1.Size = New System.Drawing.Size(80, 74)
        Me.WPawn1.TabIndex = 12
        Me.WPawn1.UseVisualStyleBackColor = True
        '
        'BKing
        '
        Me.BKing.BackColor = System.Drawing.Color.Transparent
        Me.BKing.BackgroundImage = CType(resources.GetObject("BKing.BackgroundImage"), System.Drawing.Image)
        Me.BKing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BKing.FlatAppearance.BorderSize = 0
        Me.BKing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BKing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BKing.ForeColor = System.Drawing.Color.Transparent
        Me.BKing.Location = New System.Drawing.Point(1076, 640)
        Me.BKing.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BKing.Name = "BKing"
        Me.BKing.Size = New System.Drawing.Size(80, 74)
        Me.BKing.TabIndex = 13
        Me.BKing.UseVisualStyleBackColor = False
        '
        'WPawn3
        '
        Me.WPawn3.BackColor = System.Drawing.Color.Transparent
        Me.WPawn3.BackgroundImage = CType(resources.GetObject("WPawn3.BackgroundImage"), System.Drawing.Image)
        Me.WPawn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WPawn3.FlatAppearance.BorderSize = 0
        Me.WPawn3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WPawn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WPawn3.ForeColor = System.Drawing.Color.Transparent
        Me.WPawn3.Location = New System.Drawing.Point(999, 138)
        Me.WPawn3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WPawn3.Name = "WPawn3"
        Me.WPawn3.Size = New System.Drawing.Size(80, 74)
        Me.WPawn3.TabIndex = 14
        Me.WPawn3.UseVisualStyleBackColor = False
        '
        'BKnight2
        '
        Me.BKnight2.BackColor = System.Drawing.Color.Transparent
        Me.BKnight2.BackgroundImage = CType(resources.GetObject("BKnight2.BackgroundImage"), System.Drawing.Image)
        Me.BKnight2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BKnight2.FlatAppearance.BorderSize = 0
        Me.BKnight2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BKnight2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BKnight2.ForeColor = System.Drawing.Color.Transparent
        Me.BKnight2.Location = New System.Drawing.Point(921, 640)
        Me.BKnight2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BKnight2.Name = "BKnight2"
        Me.BKnight2.Size = New System.Drawing.Size(80, 74)
        Me.BKnight2.TabIndex = 15
        Me.BKnight2.UseVisualStyleBackColor = False
        '
        'BBishop1
        '
        Me.BBishop1.BackColor = System.Drawing.Color.Transparent
        Me.BBishop1.BackgroundImage = CType(resources.GetObject("BBishop1.BackgroundImage"), System.Drawing.Image)
        Me.BBishop1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BBishop1.FlatAppearance.BorderSize = 0
        Me.BBishop1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BBishop1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BBishop1.ForeColor = System.Drawing.Color.Transparent
        Me.BBishop1.Location = New System.Drawing.Point(999, 567)
        Me.BBishop1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BBishop1.Name = "BBishop1"
        Me.BBishop1.Size = New System.Drawing.Size(80, 74)
        Me.BBishop1.TabIndex = 16
        Me.BBishop1.UseVisualStyleBackColor = False
        '
        'BKnight1
        '
        Me.BKnight1.BackColor = System.Drawing.Color.Transparent
        Me.BKnight1.BackgroundImage = CType(resources.GetObject("BKnight1.BackgroundImage"), System.Drawing.Image)
        Me.BKnight1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BKnight1.FlatAppearance.BorderSize = 0
        Me.BKnight1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BKnight1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BKnight1.ForeColor = System.Drawing.Color.Transparent
        Me.BKnight1.Location = New System.Drawing.Point(844, 640)
        Me.BKnight1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BKnight1.Name = "BKnight1"
        Me.BKnight1.Size = New System.Drawing.Size(80, 74)
        Me.BKnight1.TabIndex = 17
        Me.BKnight1.UseVisualStyleBackColor = False
        '
        'BPawn8
        '
        Me.BPawn8.BackColor = System.Drawing.Color.Transparent
        Me.BPawn8.BackgroundImage = CType(resources.GetObject("BPawn8.BackgroundImage"), System.Drawing.Image)
        Me.BPawn8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BPawn8.FlatAppearance.BorderSize = 0
        Me.BPawn8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BPawn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BPawn8.ForeColor = System.Drawing.Color.Transparent
        Me.BPawn8.Location = New System.Drawing.Point(1076, 494)
        Me.BPawn8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BPawn8.Name = "BPawn8"
        Me.BPawn8.Size = New System.Drawing.Size(80, 74)
        Me.BPawn8.TabIndex = 18
        Me.BPawn8.UseVisualStyleBackColor = False
        '
        'WKing
        '
        Me.WKing.BackColor = System.Drawing.Color.Transparent
        Me.WKing.BackgroundImage = CType(resources.GetObject("WKing.BackgroundImage"), System.Drawing.Image)
        Me.WKing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WKing.FlatAppearance.BorderSize = 0
        Me.WKing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WKing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WKing.ForeColor = System.Drawing.Color.Transparent
        Me.WKing.Location = New System.Drawing.Point(1076, 352)
        Me.WKing.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WKing.Name = "WKing"
        Me.WKing.Size = New System.Drawing.Size(80, 74)
        Me.WKing.TabIndex = 19
        Me.WKing.UseVisualStyleBackColor = False
        '
        'BRook1
        '
        Me.BRook1.BackColor = System.Drawing.Color.Transparent
        Me.BRook1.BackgroundImage = CType(resources.GetObject("BRook1.BackgroundImage"), System.Drawing.Image)
        Me.BRook1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BRook1.FlatAppearance.BorderSize = 0
        Me.BRook1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BRook1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BRook1.ForeColor = System.Drawing.Color.Transparent
        Me.BRook1.Location = New System.Drawing.Point(845, 566)
        Me.BRook1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BRook1.Name = "BRook1"
        Me.BRook1.Size = New System.Drawing.Size(80, 74)
        Me.BRook1.TabIndex = 20
        Me.BRook1.UseVisualStyleBackColor = False
        '
        'BRook2
        '
        Me.BRook2.BackColor = System.Drawing.Color.Transparent
        Me.BRook2.BackgroundImage = CType(resources.GetObject("BRook2.BackgroundImage"), System.Drawing.Image)
        Me.BRook2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BRook2.FlatAppearance.BorderSize = 0
        Me.BRook2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BRook2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BRook2.ForeColor = System.Drawing.Color.Transparent
        Me.BRook2.Location = New System.Drawing.Point(921, 567)
        Me.BRook2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BRook2.Name = "BRook2"
        Me.BRook2.Size = New System.Drawing.Size(80, 74)
        Me.BRook2.TabIndex = 21
        Me.BRook2.UseVisualStyleBackColor = False
        '
        'BPawn7
        '
        Me.BPawn7.BackColor = System.Drawing.Color.Transparent
        Me.BPawn7.BackgroundImage = CType(resources.GetObject("BPawn7.BackgroundImage"), System.Drawing.Image)
        Me.BPawn7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BPawn7.FlatAppearance.BorderSize = 0
        Me.BPawn7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BPawn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BPawn7.ForeColor = System.Drawing.Color.Transparent
        Me.BPawn7.Location = New System.Drawing.Point(999, 494)
        Me.BPawn7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BPawn7.Name = "BPawn7"
        Me.BPawn7.Size = New System.Drawing.Size(80, 74)
        Me.BPawn7.TabIndex = 22
        Me.BPawn7.UseVisualStyleBackColor = False
        '
        'BPawn6
        '
        Me.BPawn6.BackColor = System.Drawing.Color.Transparent
        Me.BPawn6.BackgroundImage = CType(resources.GetObject("BPawn6.BackgroundImage"), System.Drawing.Image)
        Me.BPawn6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BPawn6.FlatAppearance.BorderSize = 0
        Me.BPawn6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BPawn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BPawn6.ForeColor = System.Drawing.Color.Transparent
        Me.BPawn6.Location = New System.Drawing.Point(921, 494)
        Me.BPawn6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BPawn6.Name = "BPawn6"
        Me.BPawn6.Size = New System.Drawing.Size(80, 74)
        Me.BPawn6.TabIndex = 23
        Me.BPawn6.UseVisualStyleBackColor = False
        '
        'BPawn1
        '
        Me.BPawn1.BackColor = System.Drawing.Color.Transparent
        Me.BPawn1.BackgroundImage = CType(resources.GetObject("BPawn1.BackgroundImage"), System.Drawing.Image)
        Me.BPawn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BPawn1.FlatAppearance.BorderSize = 0
        Me.BPawn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BPawn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BPawn1.ForeColor = System.Drawing.Color.Transparent
        Me.BPawn1.Location = New System.Drawing.Point(844, 423)
        Me.BPawn1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BPawn1.Name = "BPawn1"
        Me.BPawn1.Size = New System.Drawing.Size(80, 74)
        Me.BPawn1.TabIndex = 24
        Me.BPawn1.UseVisualStyleBackColor = False
        '
        'BPawn2
        '
        Me.BPawn2.BackColor = System.Drawing.Color.Transparent
        Me.BPawn2.BackgroundImage = CType(resources.GetObject("BPawn2.BackgroundImage"), System.Drawing.Image)
        Me.BPawn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BPawn2.FlatAppearance.BorderSize = 0
        Me.BPawn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BPawn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BPawn2.ForeColor = System.Drawing.Color.Transparent
        Me.BPawn2.Location = New System.Drawing.Point(921, 423)
        Me.BPawn2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BPawn2.Name = "BPawn2"
        Me.BPawn2.Size = New System.Drawing.Size(80, 74)
        Me.BPawn2.TabIndex = 25
        Me.BPawn2.UseVisualStyleBackColor = False
        '
        'BPawn3
        '
        Me.BPawn3.BackColor = System.Drawing.Color.Transparent
        Me.BPawn3.BackgroundImage = CType(resources.GetObject("BPawn3.BackgroundImage"), System.Drawing.Image)
        Me.BPawn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BPawn3.FlatAppearance.BorderSize = 0
        Me.BPawn3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BPawn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BPawn3.ForeColor = System.Drawing.Color.Transparent
        Me.BPawn3.Location = New System.Drawing.Point(999, 423)
        Me.BPawn3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BPawn3.Name = "BPawn3"
        Me.BPawn3.Size = New System.Drawing.Size(80, 74)
        Me.BPawn3.TabIndex = 26
        Me.BPawn3.UseVisualStyleBackColor = False
        '
        'WKnight1
        '
        Me.WKnight1.BackColor = System.Drawing.Color.Transparent
        Me.WKnight1.BackgroundImage = CType(resources.GetObject("WKnight1.BackgroundImage"), System.Drawing.Image)
        Me.WKnight1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WKnight1.FlatAppearance.BorderSize = 0
        Me.WKnight1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WKnight1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WKnight1.ForeColor = System.Drawing.Color.Transparent
        Me.WKnight1.Location = New System.Drawing.Point(844, 353)
        Me.WKnight1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WKnight1.Name = "WKnight1"
        Me.WKnight1.Size = New System.Drawing.Size(80, 74)
        Me.WKnight1.TabIndex = 27
        Me.WKnight1.UseVisualStyleBackColor = False
        '
        'Wknight2
        '
        Me.Wknight2.BackColor = System.Drawing.Color.Transparent
        Me.Wknight2.BackgroundImage = CType(resources.GetObject("Wknight2.BackgroundImage"), System.Drawing.Image)
        Me.Wknight2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Wknight2.FlatAppearance.BorderSize = 0
        Me.Wknight2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Wknight2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Wknight2.ForeColor = System.Drawing.Color.Transparent
        Me.Wknight2.Location = New System.Drawing.Point(921, 353)
        Me.Wknight2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Wknight2.Name = "Wknight2"
        Me.Wknight2.Size = New System.Drawing.Size(80, 74)
        Me.Wknight2.TabIndex = 28
        Me.Wknight2.UseVisualStyleBackColor = False
        '
        'WQueen
        '
        Me.WQueen.BackColor = System.Drawing.Color.Transparent
        Me.WQueen.BackgroundImage = CType(resources.GetObject("WQueen.BackgroundImage"), System.Drawing.Image)
        Me.WQueen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WQueen.FlatAppearance.BorderSize = 0
        Me.WQueen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WQueen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WQueen.ForeColor = System.Drawing.Color.Transparent
        Me.WQueen.Location = New System.Drawing.Point(999, 353)
        Me.WQueen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WQueen.Name = "WQueen"
        Me.WQueen.Size = New System.Drawing.Size(80, 74)
        Me.WQueen.TabIndex = 29
        Me.WQueen.UseVisualStyleBackColor = False
        '
        'BPawn4
        '
        Me.BPawn4.BackColor = System.Drawing.Color.Transparent
        Me.BPawn4.BackgroundImage = CType(resources.GetObject("BPawn4.BackgroundImage"), System.Drawing.Image)
        Me.BPawn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BPawn4.FlatAppearance.BorderSize = 0
        Me.BPawn4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BPawn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BPawn4.ForeColor = System.Drawing.Color.Transparent
        Me.BPawn4.Location = New System.Drawing.Point(1076, 423)
        Me.BPawn4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BPawn4.Name = "BPawn4"
        Me.BPawn4.Size = New System.Drawing.Size(80, 74)
        Me.BPawn4.TabIndex = 30
        Me.BPawn4.UseVisualStyleBackColor = False
        '
        'WBishop1
        '
        Me.WBishop1.BackColor = System.Drawing.Color.Transparent
        Me.WBishop1.BackgroundImage = CType(resources.GetObject("WBishop1.BackgroundImage"), System.Drawing.Image)
        Me.WBishop1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WBishop1.FlatAppearance.BorderSize = 0
        Me.WBishop1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WBishop1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WBishop1.ForeColor = System.Drawing.Color.Transparent
        Me.WBishop1.Location = New System.Drawing.Point(999, 284)
        Me.WBishop1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WBishop1.Name = "WBishop1"
        Me.WBishop1.Size = New System.Drawing.Size(80, 74)
        Me.WBishop1.TabIndex = 31
        Me.WBishop1.UseVisualStyleBackColor = False
        '
        'WRook2
        '
        Me.WRook2.BackColor = System.Drawing.Color.Transparent
        Me.WRook2.BackgroundImage = CType(resources.GetObject("WRook2.BackgroundImage"), System.Drawing.Image)
        Me.WRook2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WRook2.FlatAppearance.BorderSize = 0
        Me.WRook2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WRook2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WRook2.ForeColor = System.Drawing.Color.Transparent
        Me.WRook2.Location = New System.Drawing.Point(921, 284)
        Me.WRook2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WRook2.Name = "WRook2"
        Me.WRook2.Size = New System.Drawing.Size(80, 74)
        Me.WRook2.TabIndex = 32
        Me.WRook2.UseVisualStyleBackColor = False
        '
        'WRook1
        '
        Me.WRook1.BackColor = System.Drawing.Color.Transparent
        Me.WRook1.BackgroundImage = CType(resources.GetObject("WRook1.BackgroundImage"), System.Drawing.Image)
        Me.WRook1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WRook1.FlatAppearance.BorderSize = 0
        Me.WRook1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WRook1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WRook1.ForeColor = System.Drawing.Color.Transparent
        Me.WRook1.Location = New System.Drawing.Point(844, 284)
        Me.WRook1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WRook1.Name = "WRook1"
        Me.WRook1.Size = New System.Drawing.Size(80, 74)
        Me.WRook1.TabIndex = 33
        Me.WRook1.UseVisualStyleBackColor = False
        '
        'WBishop2
        '
        Me.WBishop2.BackColor = System.Drawing.Color.Transparent
        Me.WBishop2.BackgroundImage = CType(resources.GetObject("WBishop2.BackgroundImage"), System.Drawing.Image)
        Me.WBishop2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WBishop2.FlatAppearance.BorderSize = 0
        Me.WBishop2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WBishop2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WBishop2.ForeColor = System.Drawing.Color.Transparent
        Me.WBishop2.Location = New System.Drawing.Point(1076, 284)
        Me.WBishop2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WBishop2.Name = "WBishop2"
        Me.WBishop2.Size = New System.Drawing.Size(80, 74)
        Me.WBishop2.TabIndex = 34
        Me.WBishop2.UseVisualStyleBackColor = False
        '
        'WPawn8
        '
        Me.WPawn8.BackColor = System.Drawing.Color.Transparent
        Me.WPawn8.BackgroundImage = CType(resources.GetObject("WPawn8.BackgroundImage"), System.Drawing.Image)
        Me.WPawn8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WPawn8.FlatAppearance.BorderSize = 0
        Me.WPawn8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WPawn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WPawn8.ForeColor = System.Drawing.Color.Transparent
        Me.WPawn8.Location = New System.Drawing.Point(1076, 210)
        Me.WPawn8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WPawn8.Name = "WPawn8"
        Me.WPawn8.Size = New System.Drawing.Size(80, 74)
        Me.WPawn8.TabIndex = 35
        Me.WPawn8.UseVisualStyleBackColor = False
        '
        'WPawn7
        '
        Me.WPawn7.BackColor = System.Drawing.Color.Transparent
        Me.WPawn7.BackgroundImage = CType(resources.GetObject("WPawn7.BackgroundImage"), System.Drawing.Image)
        Me.WPawn7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WPawn7.FlatAppearance.BorderSize = 0
        Me.WPawn7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WPawn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WPawn7.ForeColor = System.Drawing.Color.Transparent
        Me.WPawn7.Location = New System.Drawing.Point(999, 210)
        Me.WPawn7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WPawn7.Name = "WPawn7"
        Me.WPawn7.Size = New System.Drawing.Size(80, 74)
        Me.WPawn7.TabIndex = 36
        Me.WPawn7.UseVisualStyleBackColor = False
        '
        'WPawn6
        '
        Me.WPawn6.BackColor = System.Drawing.Color.Transparent
        Me.WPawn6.BackgroundImage = CType(resources.GetObject("WPawn6.BackgroundImage"), System.Drawing.Image)
        Me.WPawn6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.WPawn6.FlatAppearance.BorderSize = 0
        Me.WPawn6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.WPawn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WPawn6.ForeColor = System.Drawing.Color.Transparent
        Me.WPawn6.Location = New System.Drawing.Point(921, 210)
        Me.WPawn6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WPawn6.Name = "WPawn6"
        Me.WPawn6.Size = New System.Drawing.Size(80, 74)
        Me.WPawn6.TabIndex = 37
        Me.WPawn6.UseVisualStyleBackColor = False
        '
        'Button64
        '
        Me.Button64.AutoEllipsis = True
        Me.Button64.BackColor = System.Drawing.Color.Transparent
        Me.Button64.BackgroundImage = CType(resources.GetObject("Button64.BackgroundImage"), System.Drawing.Image)
        Me.Button64.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button64.FlatAppearance.BorderSize = 0
        Me.Button64.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button64.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button64.Location = New System.Drawing.Point(411, 758)
        Me.Button64.Margin = New System.Windows.Forms.Padding(0)
        Me.Button64.Name = "Button64"
        Me.Button64.Size = New System.Drawing.Size(104, 96)
        Me.Button64.TabIndex = 148
        Me.Button64.UseVisualStyleBackColor = False
        '
        'WhiteTextBox
        '
        Me.WhiteTextBox.AutoSize = True
        Me.WhiteTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WhiteTextBox.Location = New System.Drawing.Point(840, 53)
        Me.WhiteTextBox.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.WhiteTextBox.Name = "WhiteTextBox"
        Me.WhiteTextBox.Size = New System.Drawing.Size(0, 29)
        Me.WhiteTextBox.TabIndex = 149
        '
        'BlackTextBox
        '
        Me.BlackTextBox.AutoSize = True
        Me.BlackTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlackTextBox.Location = New System.Drawing.Point(967, 53)
        Me.BlackTextBox.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BlackTextBox.Name = "BlackTextBox"
        Me.BlackTextBox.Size = New System.Drawing.Size(0, 29)
        Me.BlackTextBox.TabIndex = 150
        '
        'Returnbtn
        '
        Me.Returnbtn.Location = New System.Drawing.Point(1031, 102)
        Me.Returnbtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Returnbtn.Name = "Returnbtn"
        Me.Returnbtn.Size = New System.Drawing.Size(123, 28)
        Me.Returnbtn.TabIndex = 159
        Me.Returnbtn.Text = "Return to menu"
        Me.Returnbtn.UseVisualStyleBackColor = True
        '
        'ChessBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1156, 759)
        Me.Controls.Add(Me.Returnbtn)
        Me.Controls.Add(Me.BlackTextBox)
        Me.Controls.Add(Me.WhiteTextBox)
        Me.Controls.Add(Me.Button64)
        Me.Controls.Add(Me.WPawn2)
        Me.Controls.Add(Me.WPawn1)
        Me.Controls.Add(Me.WPawn6)
        Me.Controls.Add(Me.WPawn7)
        Me.Controls.Add(Me.WPawn8)
        Me.Controls.Add(Me.WBishop2)
        Me.Controls.Add(Me.WRook1)
        Me.Controls.Add(Me.WRook2)
        Me.Controls.Add(Me.WBishop1)
        Me.Controls.Add(Me.BPawn4)
        Me.Controls.Add(Me.WQueen)
        Me.Controls.Add(Me.Wknight2)
        Me.Controls.Add(Me.WKnight1)
        Me.Controls.Add(Me.BPawn3)
        Me.Controls.Add(Me.BPawn2)
        Me.Controls.Add(Me.BPawn1)
        Me.Controls.Add(Me.BPawn6)
        Me.Controls.Add(Me.BPawn7)
        Me.Controls.Add(Me.BRook2)
        Me.Controls.Add(Me.BRook1)
        Me.Controls.Add(Me.WKing)
        Me.Controls.Add(Me.BPawn8)
        Me.Controls.Add(Me.BKnight1)
        Me.Controls.Add(Me.BBishop1)
        Me.Controls.Add(Me.BKnight2)
        Me.Controls.Add(Me.WPawn3)
        Me.Controls.Add(Me.BKing)
        Me.Controls.Add(Me.WPawn4)
        Me.Controls.Add(Me.BBishop2)
        Me.Controls.Add(Me.BPawn5)
        Me.Controls.Add(Me.BQueen)
        Me.Controls.Add(Me.WPawn5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chess_Board)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ChessBoard"
        Me.Text = "Form1"
        CType(Me.chess_Board,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents chess_Board As System.Windows.Forms.PictureBox
    Friend WithEvents WhiteTime As System.Windows.Forms.Timer
    Friend WithEvents BlackTime As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents WPawn5 As System.Windows.Forms.Button
    Friend WithEvents BQueen As System.Windows.Forms.Button
    Friend WithEvents WPawn2 As System.Windows.Forms.Button
    Friend WithEvents BPawn5 As System.Windows.Forms.Button
    Friend WithEvents BBishop2 As System.Windows.Forms.Button
    Friend WithEvents WPawn4 As System.Windows.Forms.Button
    Friend WithEvents WPawn1 As System.Windows.Forms.Button
    Friend WithEvents BKing As System.Windows.Forms.Button
    Friend WithEvents WPawn3 As System.Windows.Forms.Button
    Friend WithEvents BKnight2 As System.Windows.Forms.Button
    Friend WithEvents BBishop1 As System.Windows.Forms.Button
    Friend WithEvents BKnight1 As System.Windows.Forms.Button
    Friend WithEvents BPawn8 As System.Windows.Forms.Button
    Friend WithEvents WKing As System.Windows.Forms.Button
    Friend WithEvents BRook1 As System.Windows.Forms.Button
    Friend WithEvents BRook2 As System.Windows.Forms.Button
    Friend WithEvents BPawn7 As System.Windows.Forms.Button
    Friend WithEvents BPawn6 As System.Windows.Forms.Button
    Friend WithEvents BPawn1 As System.Windows.Forms.Button
    Friend WithEvents BPawn2 As System.Windows.Forms.Button
    Friend WithEvents BPawn3 As System.Windows.Forms.Button
    Friend WithEvents WKnight1 As System.Windows.Forms.Button
    Friend WithEvents Wknight2 As System.Windows.Forms.Button
    Friend WithEvents WQueen As System.Windows.Forms.Button
    Friend WithEvents BPawn4 As System.Windows.Forms.Button
    Friend WithEvents WBishop1 As System.Windows.Forms.Button
    Friend WithEvents WRook2 As System.Windows.Forms.Button
    Friend WithEvents WRook1 As System.Windows.Forms.Button
    Friend WithEvents WBishop2 As System.Windows.Forms.Button
    Friend WithEvents WPawn8 As System.Windows.Forms.Button
    Friend WithEvents WPawn7 As System.Windows.Forms.Button
    Friend WithEvents WPawn6 As System.Windows.Forms.Button
    Friend WithEvents Button64 As System.Windows.Forms.Button
    Friend WithEvents WhiteTextBox As System.Windows.Forms.Label
    Friend WithEvents BlackTextBox As System.Windows.Forms.Label
    Friend WithEvents Returnbtn As System.Windows.Forms.Button

End Class
