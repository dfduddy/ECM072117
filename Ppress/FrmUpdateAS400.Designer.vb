<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUpdateAS400
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraMessageBoxManager1 = New Infragistics.Win.UltraMessageBox.UltraMessageBoxManager(Me.components)
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraBtnYes = New Infragistics.Win.Misc.UltraButton()
        Me.UltraBTnNo = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraMessageBoxManager1
        '
        Me.UltraMessageBoxManager1.ContainingControl = Me
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraBTnNo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraBtnYes)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(162, 50)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(442, 227)
        Me.UltraGroupBox1.TabIndex = 1
        '
        'UltraLabel1
        '
        Appearance1.TextHAlignAsString = "Center"
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel1.Location = New System.Drawing.Point(57, 15)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(334, 23)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "Rebuild AS400 Customers ?"
        '
        'UltraBtnYes
        '
        Me.UltraBtnYes.Location = New System.Drawing.Point(114, 157)
        Me.UltraBtnYes.Name = "UltraBtnYes"
        Me.UltraBtnYes.Size = New System.Drawing.Size(75, 23)
        Me.UltraBtnYes.TabIndex = 1
        Me.UltraBtnYes.Text = "&Yes"
        '
        'UltraBTnNo
        '
        Me.UltraBTnNo.Location = New System.Drawing.Point(256, 157)
        Me.UltraBTnNo.Name = "UltraBTnNo"
        Me.UltraBTnNo.Size = New System.Drawing.Size(75, 23)
        Me.UltraBTnNo.TabIndex = 2
        Me.UltraBTnNo.Text = "&No"
        '
        'UltraLabel2
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.ForeColor = System.Drawing.Color.Red
        Appearance2.TextHAlignAsString = "Center"
        Me.UltraLabel2.Appearance = Appearance2
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(114, 198)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(217, 23)
        Me.UltraLabel2.TabIndex = 3
        Me.UltraLabel2.Text = "Building AS400 Customers"
        Me.UltraLabel2.Visible = False
        '
        'UltraLabel3
        '
        Appearance3.TextHAlignAsString = "Center"
        Me.UltraLabel3.Appearance = Appearance3
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel3.Location = New System.Drawing.Point(162, 21)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(442, 23)
        Me.UltraLabel3.TabIndex = 2
        Me.UltraLabel3.Text = "Planet Press ECM"
        '
        'FrmUpdateAS400
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 371)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmUpdateAS400"
        Me.Text = "FrmUpdateAS400"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraMessageBoxManager1 As Infragistics.Win.UltraMessageBox.UltraMessageBoxManager
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraBTnNo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraBtnYes As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
End Class
