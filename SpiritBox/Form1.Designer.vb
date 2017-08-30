<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.pControlTop = New System.Windows.Forms.Panel()
        Me.btnMinBox = New System.Windows.Forms.Button()
        Me.btnStyle = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pControlBottom = New System.Windows.Forms.Panel()
        Me.tbRate = New System.Windows.Forms.TextBox()
        Me.tbChance = New System.Windows.Forms.TextBox()
        Me.btnTimeRight = New System.Windows.Forms.Button()
        Me.btnTimeLeft = New System.Windows.Forms.Button()
        Me.btnProbRight = New System.Windows.Forms.Button()
        Me.btnProbLeft = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.pControlRight = New System.Windows.Forms.Panel()
        Me.pbBR = New System.Windows.Forms.PictureBox()
        Me.pbTR = New System.Windows.Forms.PictureBox()
        Me.pControlLeft = New System.Windows.Forms.Panel()
        Me.pbBL = New System.Windows.Forms.PictureBox()
        Me.pbTL = New System.Windows.Forms.PictureBox()
        Me.pControlCenter = New System.Windows.Forms.Panel()
        Me.tbMainDisplay = New System.Windows.Forms.RichTextBox()
        Me.eRunTime = New System.Windows.Forms.Timer(Me.components)
        Me.pControlTop.SuspendLayout()
        Me.pControlBottom.SuspendLayout()
        Me.pControlRight.SuspendLayout()
        CType(Me.pbBR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pControlLeft.SuspendLayout()
        CType(Me.pbBL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pControlCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'pControlTop
        '
        Me.pControlTop.Controls.Add(Me.btnMinBox)
        Me.pControlTop.Controls.Add(Me.btnStyle)
        Me.pControlTop.Controls.Add(Me.btnClose)
        Me.pControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pControlTop.Location = New System.Drawing.Point(0, 0)
        Me.pControlTop.Name = "pControlTop"
        Me.pControlTop.Size = New System.Drawing.Size(498, 30)
        Me.pControlTop.TabIndex = 0
        '
        'btnMinBox
        '
        Me.btnMinBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinBox.BackColor = System.Drawing.Color.Black
        Me.btnMinBox.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnMinBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnMinBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.btnMinBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinBox.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnMinBox.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnMinBox.Location = New System.Drawing.Point(449, 6)
        Me.btnMinBox.Name = "btnMinBox"
        Me.btnMinBox.Size = New System.Drawing.Size(18, 18)
        Me.btnMinBox.TabIndex = 3
        Me.btnMinBox.TabStop = False
        Me.btnMinBox.UseVisualStyleBackColor = False
        '
        'btnStyle
        '
        Me.btnStyle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStyle.BackColor = System.Drawing.Color.Black
        Me.btnStyle.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnStyle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnStyle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime
        Me.btnStyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStyle.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnStyle.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnStyle.Location = New System.Drawing.Point(425, 6)
        Me.btnStyle.Name = "btnStyle"
        Me.btnStyle.Size = New System.Drawing.Size(18, 18)
        Me.btnStyle.TabIndex = 1
        Me.btnStyle.TabStop = False
        Me.btnStyle.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Black
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Webdings", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnClose.Location = New System.Drawing.Point(473, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(18, 18)
        Me.btnClose.TabIndex = 0
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'pControlBottom
        '
        Me.pControlBottom.Controls.Add(Me.tbRate)
        Me.pControlBottom.Controls.Add(Me.tbChance)
        Me.pControlBottom.Controls.Add(Me.btnTimeRight)
        Me.pControlBottom.Controls.Add(Me.btnTimeLeft)
        Me.pControlBottom.Controls.Add(Me.btnProbRight)
        Me.pControlBottom.Controls.Add(Me.btnProbLeft)
        Me.pControlBottom.Controls.Add(Me.btnStart)
        Me.pControlBottom.Controls.Add(Me.btnStop)
        Me.pControlBottom.Controls.Add(Me.btnSave)
        Me.pControlBottom.Controls.Add(Me.btnClear)
        Me.pControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pControlBottom.Location = New System.Drawing.Point(0, 299)
        Me.pControlBottom.Name = "pControlBottom"
        Me.pControlBottom.Size = New System.Drawing.Size(498, 40)
        Me.pControlBottom.TabIndex = 1
        '
        'tbRate
        '
        Me.tbRate.BackColor = System.Drawing.Color.Black
        Me.tbRate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRate.ForeColor = System.Drawing.Color.Blue
        Me.tbRate.Location = New System.Drawing.Point(40, 11)
        Me.tbRate.Name = "tbRate"
        Me.tbRate.ReadOnly = True
        Me.tbRate.Size = New System.Drawing.Size(29, 15)
        Me.tbRate.TabIndex = 14
        Me.tbRate.TabStop = False
        Me.tbRate.Text = "0"
        Me.tbRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbChance
        '
        Me.tbChance.BackColor = System.Drawing.Color.Black
        Me.tbChance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbChance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbChance.ForeColor = System.Drawing.Color.Blue
        Me.tbChance.Location = New System.Drawing.Point(429, 11)
        Me.tbChance.Name = "tbChance"
        Me.tbChance.ReadOnly = True
        Me.tbChance.Size = New System.Drawing.Size(29, 15)
        Me.tbChance.TabIndex = 13
        Me.tbChance.TabStop = False
        Me.tbChance.Text = "0"
        Me.tbChance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnTimeRight
        '
        Me.btnTimeRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTimeRight.BackColor = System.Drawing.Color.Black
        Me.btnTimeRight.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnTimeRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnTimeRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.btnTimeRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTimeRight.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnTimeRight.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnTimeRight.Location = New System.Drawing.Point(76, 6)
        Me.btnTimeRight.Name = "btnTimeRight"
        Me.btnTimeRight.Size = New System.Drawing.Size(28, 28)
        Me.btnTimeRight.TabIndex = 12
        Me.btnTimeRight.TabStop = False
        Me.btnTimeRight.Text = "4"
        Me.btnTimeRight.UseVisualStyleBackColor = False
        '
        'btnTimeLeft
        '
        Me.btnTimeLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTimeLeft.BackColor = System.Drawing.Color.Black
        Me.btnTimeLeft.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnTimeLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnTimeLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.btnTimeLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTimeLeft.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnTimeLeft.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnTimeLeft.Location = New System.Drawing.Point(6, 6)
        Me.btnTimeLeft.Name = "btnTimeLeft"
        Me.btnTimeLeft.Size = New System.Drawing.Size(28, 28)
        Me.btnTimeLeft.TabIndex = 11
        Me.btnTimeLeft.TabStop = False
        Me.btnTimeLeft.Text = "3"
        Me.btnTimeLeft.UseVisualStyleBackColor = False
        '
        'btnProbRight
        '
        Me.btnProbRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProbRight.BackColor = System.Drawing.Color.Black
        Me.btnProbRight.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnProbRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnProbRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.btnProbRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProbRight.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnProbRight.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnProbRight.Location = New System.Drawing.Point(464, 6)
        Me.btnProbRight.Name = "btnProbRight"
        Me.btnProbRight.Size = New System.Drawing.Size(28, 28)
        Me.btnProbRight.TabIndex = 10
        Me.btnProbRight.TabStop = False
        Me.btnProbRight.Text = "4"
        Me.btnProbRight.UseVisualStyleBackColor = False
        '
        'btnProbLeft
        '
        Me.btnProbLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProbLeft.BackColor = System.Drawing.Color.Black
        Me.btnProbLeft.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnProbLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnProbLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.btnProbLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProbLeft.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnProbLeft.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnProbLeft.Location = New System.Drawing.Point(394, 6)
        Me.btnProbLeft.Name = "btnProbLeft"
        Me.btnProbLeft.Size = New System.Drawing.Size(28, 28)
        Me.btnProbLeft.TabIndex = 9
        Me.btnProbLeft.TabStop = False
        Me.btnProbLeft.Text = "3"
        Me.btnProbLeft.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.BackColor = System.Drawing.Color.Black
        Me.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnStart.Location = New System.Drawing.Point(110, 6)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(65, 28)
        Me.btnStart.TabIndex = 8
        Me.btnStart.TabStop = False
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.BackColor = System.Drawing.Color.Black
        Me.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnStop.Location = New System.Drawing.Point(181, 6)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(65, 28)
        Me.btnStop.TabIndex = 7
        Me.btnStop.TabStop = False
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.Black
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnSave.Location = New System.Drawing.Point(252, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(65, 28)
        Me.btnSave.TabIndex = 6
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.Black
        Me.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnClear.Location = New System.Drawing.Point(323, 6)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(65, 28)
        Me.btnClear.TabIndex = 4
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'pControlRight
        '
        Me.pControlRight.Controls.Add(Me.pbBR)
        Me.pControlRight.Controls.Add(Me.pbTR)
        Me.pControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pControlRight.Location = New System.Drawing.Point(358, 30)
        Me.pControlRight.Name = "pControlRight"
        Me.pControlRight.Size = New System.Drawing.Size(140, 269)
        Me.pControlRight.TabIndex = 2
        '
        'pbBR
        '
        Me.pbBR.BackColor = System.Drawing.Color.Black
        Me.pbBR.Location = New System.Drawing.Point(6, 135)
        Me.pbBR.Name = "pbBR"
        Me.pbBR.Size = New System.Drawing.Size(128, 128)
        Me.pbBR.TabIndex = 1
        Me.pbBR.TabStop = False
        '
        'pbTR
        '
        Me.pbTR.BackColor = System.Drawing.Color.Black
        Me.pbTR.Location = New System.Drawing.Point(6, 6)
        Me.pbTR.Name = "pbTR"
        Me.pbTR.Size = New System.Drawing.Size(128, 128)
        Me.pbTR.TabIndex = 0
        Me.pbTR.TabStop = False
        '
        'pControlLeft
        '
        Me.pControlLeft.Controls.Add(Me.pbBL)
        Me.pControlLeft.Controls.Add(Me.pbTL)
        Me.pControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pControlLeft.Location = New System.Drawing.Point(0, 30)
        Me.pControlLeft.Name = "pControlLeft"
        Me.pControlLeft.Size = New System.Drawing.Size(140, 269)
        Me.pControlLeft.TabIndex = 3
        '
        'pbBL
        '
        Me.pbBL.BackColor = System.Drawing.Color.Black
        Me.pbBL.Location = New System.Drawing.Point(6, 135)
        Me.pbBL.Name = "pbBL"
        Me.pbBL.Size = New System.Drawing.Size(128, 128)
        Me.pbBL.TabIndex = 2
        Me.pbBL.TabStop = False
        '
        'pbTL
        '
        Me.pbTL.BackColor = System.Drawing.Color.Black
        Me.pbTL.Location = New System.Drawing.Point(6, 6)
        Me.pbTL.Name = "pbTL"
        Me.pbTL.Size = New System.Drawing.Size(128, 128)
        Me.pbTL.TabIndex = 1
        Me.pbTL.TabStop = False
        '
        'pControlCenter
        '
        Me.pControlCenter.Controls.Add(Me.tbMainDisplay)
        Me.pControlCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pControlCenter.Location = New System.Drawing.Point(140, 30)
        Me.pControlCenter.Name = "pControlCenter"
        Me.pControlCenter.Size = New System.Drawing.Size(218, 269)
        Me.pControlCenter.TabIndex = 4
        '
        'tbMainDisplay
        '
        Me.tbMainDisplay.BackColor = System.Drawing.Color.Black
        Me.tbMainDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbMainDisplay.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMainDisplay.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.tbMainDisplay.Location = New System.Drawing.Point(6, 6)
        Me.tbMainDisplay.Name = "tbMainDisplay"
        Me.tbMainDisplay.ReadOnly = True
        Me.tbMainDisplay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.tbMainDisplay.Size = New System.Drawing.Size(206, 257)
        Me.tbMainDisplay.TabIndex = 0
        Me.tbMainDisplay.Text = ""
        '
        'eRunTime
        '
        Me.eRunTime.Enabled = True
        Me.eRunTime.Interval = 1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(498, 339)
        Me.Controls.Add(Me.pControlCenter)
        Me.Controls.Add(Me.pControlLeft)
        Me.Controls.Add(Me.pControlRight)
        Me.Controls.Add(Me.pControlBottom)
        Me.Controls.Add(Me.pControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.pControlTop.ResumeLayout(False)
        Me.pControlBottom.ResumeLayout(False)
        Me.pControlBottom.PerformLayout()
        Me.pControlRight.ResumeLayout(False)
        CType(Me.pbBR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pControlLeft.ResumeLayout(False)
        CType(Me.pbBL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pControlCenter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pControlTop As System.Windows.Forms.Panel
    Friend WithEvents pControlBottom As System.Windows.Forms.Panel
    Friend WithEvents pControlRight As System.Windows.Forms.Panel
    Friend WithEvents pControlLeft As System.Windows.Forms.Panel
    Friend WithEvents pControlCenter As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnStyle As System.Windows.Forms.Button
    Friend WithEvents pbTR As System.Windows.Forms.PictureBox
    Friend WithEvents pbBR As System.Windows.Forms.PictureBox
    Friend WithEvents pbBL As System.Windows.Forms.PictureBox
    Friend WithEvents pbTL As System.Windows.Forms.PictureBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents eRunTime As System.Windows.Forms.Timer
    Friend WithEvents btnMinBox As System.Windows.Forms.Button
    Friend WithEvents tbRate As System.Windows.Forms.TextBox
    Friend WithEvents tbChance As System.Windows.Forms.TextBox
    Friend WithEvents btnTimeRight As System.Windows.Forms.Button
    Friend WithEvents btnTimeLeft As System.Windows.Forms.Button
    Friend WithEvents btnProbRight As System.Windows.Forms.Button
    Friend WithEvents btnProbLeft As System.Windows.Forms.Button
    Friend WithEvents tbMainDisplay As System.Windows.Forms.RichTextBox

End Class
