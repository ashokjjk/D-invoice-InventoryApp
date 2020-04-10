Public Class ProfitLossReport

    Private Sub ProfitLossReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MinimizeBox = False
        MaximizeBox = False


    End Sub
   

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfromdate.ValueChanged
        Me.txtfromdate.Text = Me.dtpfromdate.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtptodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptodate.ValueChanged
        Me.txttodate.Text = Me.dtptodate.Value.Date.ToString("dd/MM/yyyy")
    End Sub
    Dim s As New SharedData
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim from_date, to_date As String
        from_date = Me.txtfromdate.Text
        to_date = Me.txttodate.Text
        s.SetPlData(from_date, to_date)
        ReportScreen.Show()
        ReportScreen.BringToFront()
        'ReportScreen.TopMost = True


    End Sub
  
End Class