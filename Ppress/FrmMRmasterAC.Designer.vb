<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMRmasterAC
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
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraTextEditor3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
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
        CType(Me.UltraTextEditor3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraComboEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraTextEditor3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraComboEditor1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraTextEditor2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraTextEditor1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(25, 28)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(809, 282)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "Merch  Master Maintenance"
        '
        'UltraTextEditor3
        '
        Me.UltraTextEditor3.Location = New System.Drawing.Point(252, 152)
        Me.UltraTextEditor3.MaxLength = 30
        Me.UltraTextEditor3.Name = "UltraTextEditor3"
        Me.UltraTextEditor3.Size = New System.Drawing.Size(464, 21)
        Me.UltraTextEditor3.TabIndex = 4
        '
        'UltraLabel6
        '
        Me.UltraLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel6.Location = New System.Drawing.Point(126, 154)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(99, 23)
        Me.UltraLabel6.TabIndex = 11
        Me.UltraLabel6.Text = "Email Address"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(126, 189)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(90, 23)
        Me.UltraLabel4.TabIndex = 7
        Me.UltraLabel4.Text = "Flag 1"
        '
        'UltraComboEditor1
        '
        Me.UltraComboEditor1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem2.DataValue = "ValueListItem1"
        ValueListItem2.DisplayText = "N"
        ValueListItem1.DataValue = "ValueListItem0"
        ValueListItem1.DisplayText = "Y"
        Me.UltraComboEditor1.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem2, ValueListItem1})
        Me.UltraComboEditor1.Location = New System.Drawing.Point(252, 187)
        Me.UltraComboEditor1.Name = "UltraComboEditor1"
        Me.UltraComboEditor1.Size = New System.Drawing.Size(47, 21)
        Me.UltraComboEditor1.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.UltraComboEditor1.TabIndex = 5
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(126, 125)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(99, 23)
        Me.UltraLabel3.TabIndex = 5
        Me.UltraLabel3.Text = "Merch Name"
        '
        'UltraTextEditor2
        '
        Me.UltraTextEditor2.Location = New System.Drawing.Point(252, 123)
        Me.UltraTextEditor2.MaxLength = 30
        Me.UltraTextEditor2.Name = "UltraTextEditor2"
        Me.UltraTextEditor2.Size = New System.Drawing.Size(216, 21)
        Me.UltraTextEditor2.TabIndex = 3
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(126, 94)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(67, 23)
        Me.UltraLabel2.TabIndex = 3
        Me.UltraLabel2.Text = "Merch ID"
        '
        'UltraTextEditor1
        '
        Me.UltraTextEditor1.Location = New System.Drawing.Point(252, 96)
        Me.UltraTextEditor1.MaxLength = 10
        Me.UltraTextEditor1.Name = "UltraTextEditor1"
        Me.UltraTextEditor1.Size = New System.Drawing.Size(47, 21)
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
        Me.UltraBtnCancel.Location = New System.Drawing.Point(418, 353)
        Me.UltraBtnCancel.Name = "UltraBtnCancel"
        Me.UltraBtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.UltraBtnCancel.TabIndex = 23
        Me.UltraBtnCancel.Text = "&Cancel"
        '
        'UltraBtnOK
        '
        Me.UltraBtnOK.Location = New System.Drawing.Point(277, 353)
        Me.UltraBtnOK.Name = "UltraBtnOK"
        Me.UltraBtnOK.Size = New System.Drawing.Size(75, 23)
        Me.UltraBtnOK.TabIndex = 22
        Me.UltraBtnOK.Text = "&OK"
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'FrmMRmasterAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 494)
        Me.Controls.Add(Me.UltraBtnCancel)
        Me.Controls.Add(Me.UltraBtnOK)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmMRmasterAC"
        Me.Text = "FrmMAmaintAC"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraTextEditor3, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTextEditor3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
