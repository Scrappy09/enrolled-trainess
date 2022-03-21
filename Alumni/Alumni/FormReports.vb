Public Class FormReports



    Private Sub BtnMagpet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMagpet.Click
        FormPrint.Mcity = "Magpet"
        FormPrint.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FormPrint.Mcity = "Kidapawan"
        FormPrint.ShowDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FormPrint.Mcity = "Matalam"
        FormPrint.ShowDialog()

    End Sub

    Private Sub FormReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class