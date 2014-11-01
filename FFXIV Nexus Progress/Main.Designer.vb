<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DonateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LightInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BonusLightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblLastLightEarned = New System.Windows.Forms.Label()
        Me.lblBrightsRemaining = New System.Windows.Forms.Label()
        Me.lblGentlesRemaining = New System.Windows.Forms.Label()
        Me.lblTotalLightToday = New System.Windows.Forms.Label()
        Me.lblLightPerHour = New System.Windows.Forms.Label()
        Me.timerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.comboProcesses = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpLight = New System.Windows.Forms.GroupBox()
        Me.pictureJob = New System.Windows.Forms.PictureBox()
        Me.checkShield = New System.Windows.Forms.CheckBox()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.progressLight = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpLight.SuspendLayout()
        CType(Me.pictureJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.DonateToolStripMenuItem, Me.CheckForUpdateToolStripMenuItem, Me.LightInfoToolStripMenuItem, Me.BonusLightToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(438, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'DonateToolStripMenuItem
        '
        Me.DonateToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DonateToolStripMenuItem.Name = "DonateToolStripMenuItem"
        Me.DonateToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.DonateToolStripMenuItem.Text = "Donate"
        '
        'CheckForUpdateToolStripMenuItem
        '
        Me.CheckForUpdateToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckForUpdateToolStripMenuItem.Name = "CheckForUpdateToolStripMenuItem"
        Me.CheckForUpdateToolStripMenuItem.Size = New System.Drawing.Size(159, 20)
        Me.CheckForUpdateToolStripMenuItem.Text = "Update Memory Addresses"
        '
        'LightInfoToolStripMenuItem
        '
        Me.LightInfoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LightInfoToolStripMenuItem.Name = "LightInfoToolStripMenuItem"
        Me.LightInfoToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.LightInfoToolStripMenuItem.Text = "Light Info"
        '
        'BonusLightToolStripMenuItem
        '
        Me.BonusLightToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.BonusLightToolStripMenuItem.Name = "BonusLightToolStripMenuItem"
        Me.BonusLightToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.BonusLightToolStripMenuItem.Text = "Bonus Light"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 0
        Me.ToolTip1.InitialDelay = 1000
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Nexus Light"
        '
        'lblLastLightEarned
        '
        Me.lblLastLightEarned.BackColor = System.Drawing.Color.Transparent
        Me.lblLastLightEarned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastLightEarned.Font = New System.Drawing.Font("Neo Sans", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastLightEarned.ForeColor = System.Drawing.Color.Green
        Me.lblLastLightEarned.Location = New System.Drawing.Point(266, 37)
        Me.lblLastLightEarned.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLastLightEarned.Name = "lblLastLightEarned"
        Me.lblLastLightEarned.Size = New System.Drawing.Size(41, 32)
        Me.lblLastLightEarned.TabIndex = 32
        Me.lblLastLightEarned.Text = "-"
        Me.lblLastLightEarned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblLastLightEarned, "Last amount of light you earned." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "**Double-click here to reset the total light " & _
        "& timer for all Novuses.**")
        '
        'lblBrightsRemaining
        '
        Me.lblBrightsRemaining.BackColor = System.Drawing.Color.Transparent
        Me.lblBrightsRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBrightsRemaining.Font = New System.Drawing.Font("Neo Sans", 9.749999!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblBrightsRemaining.ForeColor = System.Drawing.Color.Gold
        Me.lblBrightsRemaining.Location = New System.Drawing.Point(26, 75)
        Me.lblBrightsRemaining.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBrightsRemaining.Name = "lblBrightsRemaining"
        Me.lblBrightsRemaining.Size = New System.Drawing.Size(68, 36)
        Me.lblBrightsRemaining.TabIndex = 33
        Me.lblBrightsRemaining.Text = "-"
        Me.lblBrightsRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblBrightsRemaining, "How many Bright Lights are remaining in order to finish your Nexus")
        '
        'lblGentlesRemaining
        '
        Me.lblGentlesRemaining.BackColor = System.Drawing.Color.Transparent
        Me.lblGentlesRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGentlesRemaining.Font = New System.Drawing.Font("Neo Sans", 9.749999!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblGentlesRemaining.ForeColor = System.Drawing.Color.Olive
        Me.lblGentlesRemaining.Location = New System.Drawing.Point(102, 75)
        Me.lblGentlesRemaining.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGentlesRemaining.Name = "lblGentlesRemaining"
        Me.lblGentlesRemaining.Size = New System.Drawing.Size(68, 36)
        Me.lblGentlesRemaining.TabIndex = 34
        Me.lblGentlesRemaining.Text = "-"
        Me.lblGentlesRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblGentlesRemaining, "How many Gentle Lights are remaining in order to finish your Nexus")
        '
        'lblTotalLightToday
        '
        Me.lblTotalLightToday.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalLightToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalLightToday.Font = New System.Drawing.Font("Neo Sans", 9.749999!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLightToday.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblTotalLightToday.Location = New System.Drawing.Point(245, 75)
        Me.lblTotalLightToday.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalLightToday.Name = "lblTotalLightToday"
        Me.lblTotalLightToday.Size = New System.Drawing.Size(62, 36)
        Me.lblTotalLightToday.TabIndex = 35
        Me.lblTotalLightToday.Text = "-"
        Me.lblTotalLightToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblTotalLightToday, "Total Light you've accumulated for this Novus since the start of this program." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "**Double-click here to reset the total light & timer for all Novuses.**")
        '
        'lblLightPerHour
        '
        Me.lblLightPerHour.BackColor = System.Drawing.Color.Transparent
        Me.lblLightPerHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLightPerHour.Font = New System.Drawing.Font("Neo Sans", 9.749999!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLightPerHour.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblLightPerHour.Location = New System.Drawing.Point(178, 75)
        Me.lblLightPerHour.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLightPerHour.Name = "lblLightPerHour"
        Me.lblLightPerHour.Size = New System.Drawing.Size(62, 36)
        Me.lblLightPerHour.TabIndex = 37
        Me.lblLightPerHour.Text = "-"
        Me.lblLightPerHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblLightPerHour, "The amount of Lights Per Hour you are accumulating for this Novus since the timer" & _
        " reset (or the program started)." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "**Double-click here to reset the total light" & _
        " & timer for all Novuses.**")
        '
        'timerRefresh
        '
        Me.timerRefresh.Interval = 1000
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.comboProcesses)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("Monotype Corsiva", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(39, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 280)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Process"
        '
        'comboProcesses
        '
        Me.comboProcesses.DisplayMember = "0"
        Me.comboProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboProcesses.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.comboProcesses.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboProcesses.ForeColor = System.Drawing.Color.Black
        Me.comboProcesses.FormattingEnabled = True
        Me.comboProcesses.Items.AddRange(New Object() {"0"})
        Me.comboProcesses.Location = New System.Drawing.Point(204, 25)
        Me.comboProcesses.Name = "comboProcesses"
        Me.comboProcesses.Size = New System.Drawing.Size(121, 37)
        Me.comboProcesses.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "FFXIV Process ID :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpLight
        '
        Me.grpLight.Controls.Add(Me.lblLightPerHour)
        Me.grpLight.Controls.Add(Me.pictureJob)
        Me.grpLight.Controls.Add(Me.lblTotalLightToday)
        Me.grpLight.Controls.Add(Me.lblGentlesRemaining)
        Me.grpLight.Controls.Add(Me.lblBrightsRemaining)
        Me.grpLight.Controls.Add(Me.lblLastLightEarned)
        Me.grpLight.Controls.Add(Me.checkShield)
        Me.grpLight.Controls.Add(Me.lblProgress)
        Me.grpLight.Controls.Add(Me.progressLight)
        Me.grpLight.Font = New System.Drawing.Font("Monotype Corsiva", 18.0!, System.Drawing.FontStyle.Italic)
        Me.grpLight.Location = New System.Drawing.Point(57, 89)
        Me.grpLight.Name = "grpLight"
        Me.grpLight.Size = New System.Drawing.Size(324, 204)
        Me.grpLight.TabIndex = 32
        Me.grpLight.TabStop = False
        Me.grpLight.Text = "Light"
        '
        'pictureJob
        '
        Me.pictureJob.Location = New System.Drawing.Point(26, 119)
        Me.pictureJob.Name = "pictureJob"
        Me.pictureJob.Padding = New System.Windows.Forms.Padding(10)
        Me.pictureJob.Size = New System.Drawing.Size(68, 60)
        Me.pictureJob.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureJob.TabIndex = 36
        Me.pictureJob.TabStop = False
        '
        'checkShield
        '
        Me.checkShield.AutoSize = True
        Me.checkShield.BackColor = System.Drawing.Color.Transparent
        Me.checkShield.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic)
        Me.checkShield.Location = New System.Drawing.Point(258, 182)
        Me.checkShield.Name = "checkShield"
        Me.checkShield.Size = New System.Drawing.Size(63, 22)
        Me.checkShield.TabIndex = 31
        Me.checkShield.Text = "Shield"
        Me.checkShield.UseVisualStyleBackColor = False
        '
        'lblProgress
        '
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblProgress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblProgress.Location = New System.Drawing.Point(102, 119)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(205, 60)
        Me.lblProgress.TabIndex = 30
        Me.lblProgress.Text = "..."
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'progressLight
        '
        Me.progressLight.Location = New System.Drawing.Point(26, 37)
        Me.progressLight.Maximum = 2000
        Me.progressLight.Name = "progressLight"
        Me.progressLight.Size = New System.Drawing.Size(233, 32)
        Me.progressLight.TabIndex = 27
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(438, 309)
        Me.Controls.Add(Me.grpLight)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FFXIV Nexus Progress"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpLight.ResumeLayout(False)
        Me.grpLight.PerformLayout()
        CType(Me.pictureJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DonateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CheckForUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LightInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timerRefresh As System.Windows.Forms.Timer
    Friend WithEvents BonusLightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents comboProcesses As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpLight As System.Windows.Forms.GroupBox
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents progressLight As System.Windows.Forms.ProgressBar
    Friend WithEvents checkShield As System.Windows.Forms.CheckBox
    Friend WithEvents lblTotalLightToday As System.Windows.Forms.Label
    Friend WithEvents lblGentlesRemaining As System.Windows.Forms.Label
    Friend WithEvents lblBrightsRemaining As System.Windows.Forms.Label
    Friend WithEvents lblLastLightEarned As System.Windows.Forms.Label
    Friend WithEvents pictureJob As System.Windows.Forms.PictureBox
    Friend WithEvents lblLightPerHour As System.Windows.Forms.Label

End Class
