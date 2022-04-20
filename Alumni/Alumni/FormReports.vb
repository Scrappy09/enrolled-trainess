Imports MySql.Data.MySqlClient
Public Class FormReports
    Dim vcity As String
    Private Sub BtnMagpet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Magpet"
        frmPrint.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Kidapawan"
        frmPrint.ShowDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Matalam"
        frmPrint.ShowDialog()

    End Sub

    Private Sub FormReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadCity()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Mlang"
        frmPrint.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Roxas"
        frmPrint.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = "Makilala"
        frmPrint.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBcity.SelectedIndexChanged

    End Sub
    Private Sub LoadCity()
        Dim myCmd As New MySqlCommand

        myCmd.CommandText = "SELECT DISTINCT city FROM vsbt "
        myCmd.Connection = myConn

        Dim myRead As MySqlDataReader = Nothing

        CBcity.Items.Clear()

        If myConn.State = ConnectionState.Closed Then
            Call ConnectDB()
        End If

        Try
            myRead = myCmd.ExecuteReader()
            If myRead.HasRows = True Then
                Do While myRead.Read()
                    CBcity.Items.Add(myRead.GetString("city"))
                Loop
            End If
            myRead.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error: load City")
        End Try

        myCmd = Nothing
        myRead = Nothing
    End Sub

    Private Sub BtnOpenRecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpenRecords.Click
        Dim frmPrint As New FormPrint
        frmPrint.Mcity = CBcity.Text
        frmPrint.Show()

    End Sub
End Class