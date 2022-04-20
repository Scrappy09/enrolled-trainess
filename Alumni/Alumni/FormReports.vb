Public Class FormReports



    Private Sub BtnMagpet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMagpet.Click
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Magpet"
        frmPrint.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Kidapawan"
        frmPrint.ShowDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Matalam"
        frmPrint.ShowDialog()

    End Sub

    Private Sub FormReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Mlang"
        frmPrint.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Roxas"
        frmPrint.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Makilala"
        frmPrint.ShowDialog()
    End Sub
End Class