<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGroupGGC
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
        Me.GGC = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.btnExit = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbGroup = New System.Windows.Forms.ComboBox()
        Me.cmbTheme = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.GGC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GGC
        '
        Me.GGC.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GGC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GGC.BackColor = System.Drawing.SystemColors.Window
        Me.GGC.Location = New System.Drawing.Point(0, 44)
        Me.GGC.Name = "GGC"
        Me.GGC.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GGC.Size = New System.Drawing.Size(1019, 530)
        Me.GGC.TabIndex = 3
        Me.GGC.Text = "GridGroupingControl1"
        Me.GGC.UseRightToLeftCompatibleTextBox = True
        Me.GGC.VersionInfo = "15.2400.0.43"
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.btnExit.BeforeTouchSize = New System.Drawing.Size(86, 33)
        Me.btnExit.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Dashed
        Me.btnExit.ComboEditBackColor = System.Drawing.Color.Silver
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.KeepFocusRectangle = False
        Me.btnExit.Location = New System.Drawing.Point(921, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed
        Me.btnExit.Size = New System.Drawing.Size(86, 33)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit Program"
        Me.btnExit.ThemeName = "Metro"
        Me.btnExit.UseVisualStyle = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Select :"
        '
        'cmbGroup
        '
        Me.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroup.FormattingEnabled = True
        Me.cmbGroup.Location = New System.Drawing.Point(58, 11)
        Me.cmbGroup.Name = "cmbGroup"
        Me.cmbGroup.Size = New System.Drawing.Size(122, 22)
        Me.cmbGroup.TabIndex = 61
        '
        'cmbTheme
        '
        Me.cmbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTheme.FormattingEnabled = True
        Me.cmbTheme.Location = New System.Drawing.Point(279, 11)
        Me.cmbTheme.Name = "cmbTheme"
        Me.cmbTheme.Size = New System.Drawing.Size(167, 22)
        Me.cmbTheme.TabIndex = 63
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(219, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Theme :"
        '
        'frmGroupGGC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 575)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbTheme)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbGroup)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GGC)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Name = "frmGroupGGC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grouping with GridGroupingControl - Code bY Thongkorn Tubtimkrob"
        CType(Me.GGC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GGC As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Private WithEvents btnExit As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTheme As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
