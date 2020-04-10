Public Class Splash
    Dim obj As New ObjClass
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Dim i As Integer = 0
        If ProgressBar1.Value = 100 Then
            Select obj.FindDuplicate("select count(*) from company_tbl")
                Case Is = 0
                    Settings.Show()
                    Me.Hide()

                Case Else
                    Signin.Show()
                    Me.Hide()

            End Select
                    Timer1.Stop()
        End If

    End Sub

    Private Sub Splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class