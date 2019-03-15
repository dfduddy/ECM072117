Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Net.Mail

Public Class FrmMRmasterAC
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

    End Sub

    Private Sub UltraBtnOK_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnOK.Click
        edit_data()
        If eflag = False Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
    Private Sub setup_combo()

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
        If String.IsNullOrEmpty(Me.UltraTextEditor3.Text) Then
            MessageBox.Show(Me.UltraLabel6.Text & " is required, please input", Me.UltraLabel3.Text, MessageBoxButtons.OK)
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
            If db.check_meid(Me.UltraTextEditor1.Text) = True Then 'duplicate record
                MessageBox.Show("Record already on file, please confirm", "Invalid add/update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                eflag = True
                Exit Sub
            End If
        End If
        'edit zip code
        'separate strings with comma delimiters
        Dim e As String = Trim(Me.UltraTextEditor3.Value)
        Dim ea As String() = e.Split(New Char() {","})
        Dim eadr As String
        'edit email addresses in array
        For Each eadr In ea
            If check_email(eadr) = False Then
                MessageBox.Show(eadr & " = Invalid email address, please correct", "Invalid email address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                eflag = True
                Exit Sub
            End If
        Next

        'If db.check_iseries_id(Me.UltraTextEditor1.Text) = False Then
        '    MessageBox.Show("MA ID missing from iSeries database, please confirm", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    eflag = True
        '    Exit Sub
        'End If
    End Sub

    Private Sub UltraBtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub UltraLabel3_Click(sender As System.Object, e As System.EventArgs) Handles UltraLabel3.Click

    End Sub
    Private Sub init_panel()
        'Dim tt1 As New UltraWinToolTip.UltraToolTipInfo
        'tt1.ToolTipText = "Right Click outside field to view iSeries users."
        Me.UltraTextEditor1.Text = ""
        Me.UltraTextEditor2.Text = ""
        Me.UltraTextEditor3.Text = ""
        Me.UltraComboEditor1.Text = "N"

        'Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraTextEditor1, tt1)
    End Sub
    Public Sub update_panel()
        Dim R As tblMerchMast = db.get_tblMerchMastr(a_id)
        Me.UltraTextEditor1.Text = R.fldMerchID
        Me.UltraTextEditor2.Text = R.fldMerchName
        Me.UltraTextEditor3.Text = R.fldMerchEmail
        If IsNothing(R.fldFlag1) Then
            R.fldFlag1 = "N"
        End If

        Me.UltraComboEditor1.Text = R.fldFlag1
        'Dim s As tblECMmamast = db.get_tblECMMamast(a_id)
        'If IsNothing(s) Then
        '    Me.UltraComboEditor1.SelectedText = 0

        'Else
        '    Me.UltraComboEditor1.SelectedText = s.Pcopy

        'End If
    End Sub

    Private Sub UltraGroupBox1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UltraGroupBox1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If a_id = " " Then
                'Me.UltraComboEditor2.Visible = True
                'Me.UltraLabel5.Visible = True
            End If
        End If
    End Sub

    Private Sub FrmMAmaintAC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UltraComboEditor2_SelectionChanged(sender As Object, e As System.EventArgs)
        ' Me.UltraTextEditor1.Text = Me.UltraComboEditor2.SelectedText
    End Sub

    Private Sub UltraLabel6_Click(sender As Object, e As EventArgs) Handles UltraLabel6.Click

    End Sub
    Public Function check_email(ea As String) As Boolean
        'dfd01 changed edit for email format
        Try
            Dim tea As String = New MailAddress(ea).Address
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
End Class