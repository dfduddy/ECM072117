Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Public Class FrmMAmaintAC
    Private a_id As String
    Private eflag As Boolean

    Public Sub New(id As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        a_id = id
        Select Case a_id
            Case Is = " " 'add
                Me.UltraLabel1.Text = "Add Mode"
                init_panel()
            Case Is <> " "  'update
                Me.UltraLabel1.Text = "Change Mode"
                update_panel()
                Me.UltraTextEditor1.ReadOnly = True
        End Select
        setup_combo()
        Me.UltraLabel5.Visible = False
    End Sub

    Private Sub UltraBtnOK_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnOK.Click
        edit_data()
        If eflag = False Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
    Private Sub setup_combo()
        Me.UltraComboEditor2.DataSource = db.get_maid
        Me.UltraComboEditor2.ValueMember = "User"
        Me.UltraComboEditor2.DisplayMember = "User"
    End Sub

    Private Sub edit_data()
        Me.UltraTextEditor1.Text = Me.UltraTextEditor1.Text.ToUpper
        eflag = False
        If String.IsNullOrEmpty(Me.UltraTextEditor1.Text) Then
            MessageBox.Show(Me.UltraLabel2.Text & " is required, please input", Me.UltraLabel2.Text, MessageBoxButtons.OK)
            eflag = True
            Me.UltraTextEditor1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.UltraTextEditor2.Text) Then
            MessageBox.Show(Me.UltraLabel3.Text & " is required, please input", Me.UltraLabel3.Text, MessageBoxButtons.OK)
            eflag = True
            Me.UltraTextEditor2.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.UltraComboEditor1.Text) Then
            MessageBox.Show(Me.UltraLabel4.Text & " is required, please select", Me.UltraLabel4.Text, MessageBoxButtons.OK)
            eflag = True
            Me.UltraComboEditor1.Focus()
            Exit Sub
        End If
        If Me.UltraLabel1.Text = "Add Mode" Then
            If db.check_maid(Me.UltraTextEditor1.Text) = True Then 'duplicate record
                MessageBox.Show("Record already on file, please confirm", "Invalid add/update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                eflag = True
                Exit Sub
            End If
        End If
        If db.check_iseries_id(Me.UltraTextEditor1.Text) = False Then
            MessageBox.Show("MA ID missing from iSeries database, please confirm", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Exit Sub
        End If
    End Sub

    Private Sub UltraBtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub UltraLabel3_Click(sender As System.Object, e As System.EventArgs) Handles UltraLabel3.Click

    End Sub
    Private Sub init_panel()
        Dim tt1 As New UltraWinToolTip.UltraToolTipInfo
        tt1.ToolTipText = "Right Click outside field to view iSeries users."
        Me.UltraTextEditor1.Text = ""
        Me.UltraTextEditor2.Text = ""
        Me.UltraCheckEditor1.CheckState = CheckState.Checked
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraTextEditor1, tt1)
    End Sub
    Public Sub update_panel()
        Dim R As tblECMmaid = db.get_tblECMMaid(a_id)
        Me.UltraTextEditor1.Text = R.ID
        Me.UltraTextEditor2.Text = R.name
        Dim s As tblECMmamast = db.get_tblECMMamast(a_id)
        If IsNothing(s) Then
            Me.UltraComboEditor1.SelectedText = 0
            Me.UltraCheckEditor1.CheckState = CheckState.Unchecked
        Else
            Me.UltraComboEditor1.SelectedText = s.Pcopy
            Me.UltraCheckEditor1.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub UltraGroupBox1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UltraGroupBox1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If a_id = " " Then
                Me.UltraComboEditor2.Visible = True
                Me.UltraLabel5.Visible = True
            End If
        End If
    End Sub

    Private Sub FrmMAmaintAC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UltraComboEditor2_SelectionChanged(sender As Object, e As System.EventArgs) Handles UltraComboEditor2.SelectionChanged
        Me.UltraTextEditor1.Text = Me.UltraComboEditor2.SelectedText
    End Sub
End Class