<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMobCustomerEmailAC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("tblMobile_Statis_Codes", -1)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Code")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraCombo1 = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.TblMobileStatisCodesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PpressDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PpressDataSet = New Ppress.PpressDataSet()
        Me.UltraButtonCancel = New Infragistics.Win.Misc.UltraButton()
        Me.UltraButtonOK = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTextEditor4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTextEditor2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTextEditor1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.TblMobile_Statis_CodesTableAdapter = New Ppress.PpressDataSetTableAdapters.tblMobile_Statis_CodesTableAdapter()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraCombo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblMobileStatisCodesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PpressDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PpressDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraCombo1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraButtonCancel)
        Me.UltraGroupBox1.Controls.Add(Me.UltraButtonOK)
        Me.UltraGroupBox1.Controls.Add(Me.UltraTextEditor4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraTextEditor2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraTextEditor1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(23, 46)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(736, 357)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "Customer Email Info"
        '
        'UltraCombo1
        '
        Me.UltraCombo1.CheckedListSettings.CheckStateMember = ""
        Me.UltraCombo1.DataSource = Me.TblMobileStatisCodesBindingSource
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraCombo1.DisplayLayout.Appearance = Appearance26
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn2})
        Me.UltraCombo1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.UltraCombo1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraCombo1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance27.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance27.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraCombo1.DisplayLayout.GroupByBox.Appearance = Appearance27
        Appearance29.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraCombo1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance29
        Me.UltraCombo1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraCombo1.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.UltraCombo1.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraCombo1.DisplayLayout.MaxRowScrollRegions = 1
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UltraCombo1.DisplayLayout.Override.ActiveCellAppearance = Appearance32
        Appearance35.BackColor = System.Drawing.SystemColors.Highlight
        Appearance35.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UltraCombo1.DisplayLayout.Override.ActiveRowAppearance = Appearance35
        Me.UltraCombo1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraCombo1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance37.BackColor = System.Drawing.SystemColors.Window
        Me.UltraCombo1.DisplayLayout.Override.CardAreaAppearance = Appearance37
        Appearance33.BorderColor = System.Drawing.Color.Silver
        Appearance33.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraCombo1.DisplayLayout.Override.CellAppearance = Appearance33
        Me.UltraCombo1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraCombo1.DisplayLayout.Override.CellPadding = 0
        Appearance31.BackColor = System.Drawing.SystemColors.Control
        Appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance31.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraCombo1.DisplayLayout.Override.GroupByRowAppearance = Appearance31
        Appearance30.TextHAlignAsString = "Left"
        Me.UltraCombo1.DisplayLayout.Override.HeaderAppearance = Appearance30
        Me.UltraCombo1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UltraCombo1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance36.BackColor = System.Drawing.SystemColors.Window
        Appearance36.BorderColor = System.Drawing.Color.Silver
        Me.UltraCombo1.DisplayLayout.Override.RowAppearance = Appearance36
        Me.UltraCombo1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance34.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraCombo1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance34
        Me.UltraCombo1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraCombo1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraCombo1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.UltraCombo1.DisplayMember = "Code"
        Me.UltraCombo1.LimitToList = True
        Me.UltraCombo1.Location = New System.Drawing.Point(133, 133)
        Me.UltraCombo1.Name = "UltraCombo1"
        Me.UltraCombo1.PreferredDropDownSize = New System.Drawing.Size(0, 0)
        Me.UltraCombo1.Size = New System.Drawing.Size(74, 22)
        Me.UltraCombo1.TabIndex = 4
        Me.UltraCombo1.ValueMember = "Code"
        '
        'TblMobileStatisCodesBindingSource
        '
        Me.TblMobileStatisCodesBindingSource.DataMember = "tblMobile_Statis_Codes"
        Me.TblMobileStatisCodesBindingSource.DataSource = Me.PpressDataSetBindingSource
        '
        'PpressDataSetBindingSource
        '
        Me.PpressDataSetBindingSource.DataSource = Me.PpressDataSet
        Me.PpressDataSetBindingSource.Position = 0
        '
        'PpressDataSet
        '
        Me.PpressDataSet.DataSetName = "PpressDataSet"
        Me.PpressDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltraButtonCancel
        '
        Me.UltraButtonCancel.Location = New System.Drawing.Point(257, 318)
        Me.UltraButtonCancel.Name = "UltraButtonCancel"
        Me.UltraButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.UltraButtonCancel.TabIndex = 11
        Me.UltraButtonCancel.Text = "&Cancel"
        '
        'UltraButtonOK
        '
        Me.UltraButtonOK.Location = New System.Drawing.Point(132, 318)
        Me.UltraButtonOK.Name = "UltraButtonOK"
        Me.UltraButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.UltraButtonOK.TabIndex = 10
        Me.UltraButtonOK.Text = "&OK"
        '
        'UltraTextEditor4
        '
        Me.UltraTextEditor4.Location = New System.Drawing.Point(131, 178)
        Me.UltraTextEditor4.MaxLength = 100
        Me.UltraTextEditor4.Name = "UltraTextEditor4"
        Me.UltraTextEditor4.Size = New System.Drawing.Size(441, 21)
        Me.UltraTextEditor4.TabIndex = 7
        Me.UltraTextEditor4.Text = "UltraTextEditor4"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(15, 182)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel4.TabIndex = 6
        Me.UltraLabel4.Text = "Comment"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(15, 138)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel3.TabIndex = 5
        Me.UltraLabel3.Text = "Email Status"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(15, 49)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel2.TabIndex = 3
        Me.UltraLabel2.Text = "Mobile Number"
        '
        'UltraTextEditor2
        '
        Me.UltraTextEditor2.Location = New System.Drawing.Point(131, 49)
        Me.UltraTextEditor2.MaxLength = 12
        Me.UltraTextEditor2.Name = "UltraTextEditor2"
        Me.UltraTextEditor2.Size = New System.Drawing.Size(130, 21)
        Me.UltraTextEditor2.TabIndex = 1
        Me.UltraTextEditor2.Text = "UltraTextEditor2"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(15, 90)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 1
        Me.UltraLabel1.Text = "Email Address"
        '
        'UltraTextEditor1
        '
        Me.UltraTextEditor1.Location = New System.Drawing.Point(131, 92)
        Me.UltraTextEditor1.MaxLength = 50
        Me.UltraTextEditor1.Name = "UltraTextEditor1"
        Me.UltraTextEditor1.Size = New System.Drawing.Size(234, 21)
        Me.UltraTextEditor1.TabIndex = 2
        Me.UltraTextEditor1.Text = "UltraTextEditor1"
        '
        'UltraLabel5
        '
        Appearance1.ForeColor = System.Drawing.Color.Red
        Me.UltraLabel5.Appearance = Appearance1
        Me.UltraLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(644, 12)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(115, 23)
        Me.UltraLabel5.TabIndex = 1
        Me.UltraLabel5.Text = "Mode"
        '
        'UltraLabel7
        '
        Me.UltraLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel7.Location = New System.Drawing.Point(155, 12)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(349, 23)
        Me.UltraLabel7.TabIndex = 2
        Me.UltraLabel7.Text = "Mobile Customer Email Information"
        '
        'TblMobile_Statis_CodesTableAdapter
        '
        Me.TblMobile_Statis_CodesTableAdapter.ClearBeforeFill = True
        '
        'FrmMobCustomerEmailAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.UltraLabel7)
        Me.Controls.Add(Me.UltraLabel5)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmMobCustomerEmailAC"
        Me.Text = "FrmMobCustomerEmail"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraCombo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblMobileStatisCodesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PpressDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PpressDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraTextEditor4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTextEditor2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTextEditor1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraButtonOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraButtonCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents PpressDataSet As PpressDataSet
    Friend WithEvents PpressDataSetBindingSource As BindingSource
    Friend WithEvents UltraCombo1 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents TblMobileStatisCodesBindingSource As BindingSource
    Friend WithEvents TblMobile_Statis_CodesTableAdapter As PpressDataSetTableAdapters.tblMobile_Statis_CodesTableAdapter
End Class
