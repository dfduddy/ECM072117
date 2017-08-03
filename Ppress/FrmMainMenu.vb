Imports Infragistics.Win.UltraWinGrid
Public Class FrmMainMenu

    
    Private Sub UltraToolbarsManager1_ToolClick(sender As System.Object, e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
        Select Case e.Tool.Key
            Case "Document Routing"    ' ButtonTool
                ' Place code here
                Dim f As New FrmDocRouting
                f.Show()

            Case "Customer Confirmation"    ' ButtonTool
                ' Place code here
                Dim f As New FrmCustConf
                f.Show()
            Case "Printer Control 3"    ' ButtonTool
                Dim f As New FrmPrcntl3
                f.Show()
            Case "MA maintenance"    ' ButtonTool
                Dim f As New FrmMAmaint
                f.Show()
            Case "Printer Control 2"    ' ButtonTool
                Dim f As New FrmPrcntl2
                f.Show()
            Case "EcoSign Maintenance"    ' ButtonTool
                Dim f As New FrmEcoSign
                f.Show()
            Case "About"    ' ButtonTool
                Dim f As New FrmAbout
                f.Show()
            Case "Rebuild AS400 Customers"    ' ButtonTool
                Dim f As New FrmUpdateAS400
                f.Show()
            Case "Printer Settings"    ' ButtonTool
                Dim f As New FrmPrinter_Settings
                f.Show()
        End Select
    End Sub

    Private Sub FrmMainMenu_Fill_Panel_PaintClient(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles FrmMainMenu_Fill_Panel.PaintClient

    End Sub
End Class