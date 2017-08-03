<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMAmaintAC
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraComboEditor2 = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraCheckEditor1 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraComboEditor1 = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTextEditor2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTextEditor1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraBtnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.UltraBtnOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraComboEditor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraCheckEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraComboEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Controls.Add(Me.UltraComboEditor2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraCheckEditor1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraComboEditor1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraTextEditor2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraTextEditor1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(25, 28)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(809, 255)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "MA Master Maintenance"
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(527, 67)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel5.TabIndex = 10
        Me.UltraLabel5.Text = "User ID"
        '
        'UltraComboEditor2
        '
        Me.UltraComboEditor2.Location = New System.Drawing.Point(516, 96)
        Me.UltraComboEditor2.Name = "UltraComboEditor2"
        Me.UltraComboEditor2.Size = New System.Drawing.Size(187, 21)
        Me.UltraComboEditor2.TabIndex = 9
        '
        'UltraCheckEditor1
        '
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.SizeInPoints = 10.0!
        Me.UltraCheckEditor1.Appearance = Appearance3
        Me.UltraCheckEditor1.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.UltraCheckEditor1.Location = New System.Drawing.Point(126, 183)
        Me.UltraCheckEditor1.Name = "UltraCheckEditor1"
        Me.UltraCheckEditor1.Size = New System.Drawing.Size(142, 20)
        Me.UltraCheckEditor1.TabIndex = 8
        Me.UltraCheckEditor1.Text = "Active"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(126, 154)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(90, 23)
        Me.UltraLabel4.TabIndex = 7
        Me.UltraLabel4.Text = "Print Copies"
        '
        'UltraComboEditor1
        '
        Me.UltraComboEditor1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem12.DataValue = "ValueListItem9"
        ValueListItem12.DisplayText = "0"
        ValueListItem3.DataValue = "ValueListItem0"
        ValueListItem3.DisplayText = "1"
        ValueListItem4.DataValue = "ValueListItem1"
        ValueListItem4.DisplayText = "2"
        ValueListItem5.DataValue = "ValueListItem2"
        ValueListItem5.DisplayText = "3"
        ValueListItem6.DataValue = "ValueListItem3"
        ValueListItem6.DisplayText = "4"
        ValueListItem7.DataValue = "ValueListItem4"
        ValueListItem7.DisplayText = "5"
        ValueListItem8.DataValue = "ValueListItem5"
        ValueListItem8.DisplayText = "6"
        ValueListItem9.DataValue = "ValueListItem6"
        ValueListItem9.DisplayText = "7"
        ValueListItem10.DataValue = "ValueListItem7"
        ValueListItem10.DisplayText = "8"
        ValueListItem11.DataValue = "ValueListItem8"
        ValueListItem11.DisplayText = "9"
        Me.UltraComboEditor1.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem12, ValueListItem3, ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7, ValueListItem8, ValueListItem9, ValueListItem10, ValueListItem11})
        Me.UltraComboEditor1.Location = New System.Drawing.Point(252, 151)
        Me.UltraComboEditor1.Name = "UltraComboEditor1"
        Me.UltraComboEditor1.Size = New System.Drawing.Size(47, 21)
        Me.UltraComboEditor1.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.UltraComboEditor1.TabIndex = 6
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(126, 125)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(67, 23)
        Me.UltraLabel3.TabIndex = 5
        Me.UltraLabel3.Text = "MA Name"
        '
        'UltraTextEditor2
        '
        Me.UltraTextEditor2.Location = New System.Drawing.Point(252, 123)
        Me.UltraTextEditor2.MaxLength = 30
        Me.UltraTextEditor2.Name = "UltraTextEditor2"
        Me.UltraTextEditor2.Size = New System.Drawing.Size(216, 21)
        Me.UltraTextEditor2.TabIndex = 4
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(126, 94)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(67, 23)
        Me.UltraLabel2.TabIndex = 3
        Me.UltraLabel2.Text = "MA ID"
        '
        'UltraTextEditor1
        '
        Me.UltraTextEditor1.Location = New System.Drawing.Point(252, 96)
        Me.UltraTextEditor1.MaxLength = 10
        Me.UltraTextEditor1.Name = "UltraTextEditor1"
        Me.UltraTextEditor1.Size = New System.Drawing.Size(100, 21)
        Me.UltraTextEditor1.TabIndex = 2
        '
        'UltraLabel1
        '
        Appearance1.ForeColor = System.Drawing.Color.Red
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(703, 19)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 1
        Me.UltraLabel1.Text = "Mode"
        '
        'UltraBtnCancel
        '
        Me.UltraBtnCancel.Location = New System.Drawing.Point(418, 316)
        Me.UltraBtnCancel.Name = "UltraBtnCancel"
        Me.UltraBtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.UltraBtnCancel.TabIndex = 23
        Me.UltraBtnCancel.Text = "&Cancel"
        '
        'UltraBtnOK
        '
        Me.UltraBtnOK.Location = New System.Drawing.Point(277, 316)
        Me.UltraBtnOK.Name = "UltraBtnOK"
        Me.UltraBtnOK.Size = New System.Drawing.Size(75, 23)
        Me.UltraBtnOK.TabIndex = 22
        Me.UltraBtnOK.Text = "&OK"
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'FrmMAmaintAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 494)
        Me.Controls.Add(Me.UltraBtnCancel)
        Me.Controls.Add(Me.UltraBtnOK)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmMAmaintAC"
        Me.Text = "FrmMAmaintAC"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraComboEditor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraCheckEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraComboEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraBtnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraBtnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTextEditor2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTextEditor1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraComboEditor1 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraCheckEditor1 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraComboEditor2 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
End Class
