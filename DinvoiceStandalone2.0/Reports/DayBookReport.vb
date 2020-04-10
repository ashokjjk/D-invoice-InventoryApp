Public Class DayBookReport

    Private Sub DayBookReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
        'cmbCmpNm.Focus()
    End Sub

  
    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfromdate.ValueChanged
        Me.txtfromdate.Text = Me.dtpfromdate.Value.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub dtptodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtptodate.ValueChanged
        Me.txttodate.Text = Me.dtptodate.Value.Date.ToString("dd/MM/yyyy")
    End Sub
    Dim s As New SharedData
    Dim obj As New ObjClass
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try


        Dim from_date, to_date As String
        from_date = obj.ConvDtFrmt(Me.txtfromdate.Text, "MM/dd/yyyy")
        to_date = obj.ConvDtFrmt(Me.txttodate.Text, "MM/dd/yyyy")
        s.SetDayBookData(from_date, to_date)
        ReportScreen.Show()
        ReportScreen.BringToFront()
        'ReportScreen.TopMost = True
        Catch ex As Exception

        End Try

    End Sub
End Class