<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrinter_SettingsAC
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraCheckEditor1 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraComboEditor1 = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraBtnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.UltaBtnOK = New Infragistics.Win.Misc.UltraButton()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraCheckEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraComboEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraCheckEditor1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraComboEditor1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(33, 36)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(819, 293)
        Me.UltraGroupBox1.TabIndex = 1
        Me.UltraGroupBox1.Text = "Printer Settings Maintenance"
        '
        'UltraCheckEditor1
        '
        Me.UltraCheckEditor1.Location = New System.Drawing.Point(160, 88)
        Me.UltraCheckEditor1.Name = "UltraCheckEditor1"
        Me.UltraCheckEditor1.Size = New System.Drawing.Size(120, 20)
        Me.UltraCheckEditor1.TabIndex = 15
        '
        'UltraLabel8
        '
        Appearance1.ForeColor = System.Drawing.Color.Red
        Me.UltraLabel8.Appearance = Appearance1
        Me.UltraLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(713, 19)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel8.TabIndex = 14
        Me.UltraLabel8.Text = "Mode"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(38, 88)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel3.TabIndex = 5
        Me.UltraLabel3.Text = "Postscript"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(38, 63)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 1
        Me.UltraLabel1.Text = "Printer Name"
        '
        'UltraComboEditor1
        '
        Me.UltraComboEditor1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Me.UltraComboEditor1.Location = New System.Drawing.Point(160, 59)
        Me.UltraComboEditor1.MaxLength = 50
        Me.UltraComboEditor1.Name = "UltraComboEditor1"
        Me.UltraComboEditor1.ShowOverflowIndicator = True
        Me.UltraComboEditor1.Size = New System.Drawing.Size(217, 21)
        Me.UltraComboEditor1.TabIndex = 0
        '
        'UltraBtnCancel
        '
        Me.UltraBtnCancel.Location = New System.Drawing.Point(497, 359)
        Me.UltraBtnCancel.Name = "UltraBtnCancel"
        Me.UltraBtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.UltraBtnCancel.TabIndex = 4
        Me.UltraBtnCancel.Text = "&Cancel"
        '
        'UltaBtnOK
        '
        Me.UltaBtnOK.Location = New System.Drawing.Point(258, 360)
        Me.UltaBtnOK.Name = "UltaBtnOK"
        Me.UltaBtnOK.ShowOutline = False
        Me.UltaBtnOK.Size = New System.Drawing.Size(75, 23)
        Me.UltaBtnOK.TabIndex = 3
        Me.UltaBtnOK.Text = "&OK"
        '
        'FrmPrinter_SettingsAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 471)
        Me.Controls.Add(Me.UltraBtnCancel)
        Me.Controls.Add(Me.UltaBtnOK)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmPrinter_SettingsAC"
        Me.Text = "FrmPrinter_SettingsAC"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraCheckEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraComboEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraComboEditor1 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraBtnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltaBtnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraCheckEditor1 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
