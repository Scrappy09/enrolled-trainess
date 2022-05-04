Imports MySql.Data.MySqlClient
Public Class FrmAllPrint

    Dim sql As String
    Private Sub loadRecords()
        Dim myCmd As New MySqlCommand

        Dim phasecondition As String

        If chkPhase1.Checked = True And chkPhase2.Checked = True Then
            phasecondition = " phase = 1 OR phase = 2 "
        ElseIf chkPhase1.Checked = True And chkPhase2.Checked = False Then
            phasecondition = " phase = 1"
        ElseIf chkPhase1.Checked = False And chkPhase2.Checked = True Then
            phasecondition = " phase =2 "
        ElseIf chkPhase1.Checked = False And chkPhase2.Checked = False Then
            phasecondition = " phase = 1 OR phase = 2 "
        Else
            phasecondition = ""
        End If

        myCmd.CommandText = "SELECT Fname, Sex, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, Stat, HomeA, City, Num, Email, Tribe, Religion, EA, TA, Phase, Yearg FROM vsbt Where " & phasecondition & " ORDER BY Fname;"
        sql = myCmd.CommandText

        myCmd.Connection = myConn


        Dim myRead As MySqlDataReader = Nothing
        Dim mItem As ListViewItem

        lvPrint.Items.Clear()

        If myConn.State = ConnectionState.Closed Then
            Call ConnectDB()
        End If

        Try
            myRead = myCmd.ExecuteReader()
            If myRead.HasRows = True Then
                Do While myRead.Read()
                    mItem = New ListViewItem()
                    mItem = lvPrint.Items.Add(myRead.GetString("Fname"))
                    mItem.SubItems.Add(myRead.GetString("Sex"))
                    mItem.SubItems.Add(myRead.GetString("Eage"))
                    mItem.SubItems.Add(myRead.GetString("Age"))
                    mItem.SubItems.Add(myRead.GetString("Bday"))
                    mItem.SubItems.Add(myRead.GetString("Stat"))
                    mItem.SubItems.Add(myRead.GetString("HomeA"))
                    mItem.SubItems.Add(myRead.GetString("City"))
                    mItem.SubItems.Add(myRead.GetString("Num"))
                    mItem.SubItems.Add(myRead.GetString("Email"))
                    mItem.SubItems.Add(myRead.GetString("Religion"))
                    mItem.SubItems.Add(myRead.GetString("Tribe"))
                    mItem.SubItems.Add(myRead.GetString("EA"))
                    mItem.SubItems.Add(myRead.GetString("TA"))
                    mItem.SubItems.Add(myRead.GetString("Phase"))
                    mItem.SubItems.Add(myRead.GetString("Yearg"))
                Loop
            End If

            myRead.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error: Load Records")
        End Try
        myCmd = Nothing
        myRead = Nothing

    End Sub
    Private Sub searchStudent()
        Dim myCmd As New MySqlCommand

        If txtSearchAll.Text = "" And txtYearAll.Text = "" Then
            myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt ORDER BY Fname;"
        End If

        If txtSearchAll.Text <> "" And txtYearAll.Text = "" Then
            If chkPhase1.Checked = True And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearchAll.Text & "%' Or Stat LIKE '" & txtSearchAll.Text & "%' OR Tribe LIKE '" & txtSearchAll.Text & "%' OR Religion LIKE '" & txtSearchAll.Text & "%' OR TA LIKE '" & txtSearchAll.Text & "%' OR EA LIKE '" & txtSearchAll.Text & "%' OR HomeA LIKE '" & txtSearchAll.Text & "%' OR City LIKE '" & txtSearchAll.Text & "%' Or Eage LIKE '" & txtSearchAll.Text & "' OR Age LIKE '" & txtSearchAll.Text & "' OR Sex LIKE '" & txtSearchAll.Text & "%') ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = True And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearchAll.Text & "%' Or Stat LIKE '" & txtSearchAll.Text & "%' OR Tribe LIKE '" & txtSearchAll.Text & "%' OR Religion LIKE '" & txtSearchAll.Text & "%' OR TA LIKE '" & txtSearchAll.Text & "%' OR EA LIKE '" & txtSearchAll.Text & "%' OR HomeA LIKE '" & txtSearchAll.Text & "%' OR City LIKE '" & txtSearchAll.Text & "%' Or Eage LIKE '" & txtSearchAll.Text & "' OR Age LIKE '" & txtSearchAll.Text & "' OR Sex LIKE '" & txtSearchAll.Text & "%') AND phase =1 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearchAll.Text & "%' Or Stat LIKE '" & txtSearchAll.Text & "%' OR Tribe LIKE '" & txtSearchAll.Text & "%' OR Religion LIKE '" & txtSearchAll.Text & "%' OR TA LIKE '" & txtSearchAll.Text & "%' OR EA LIKE '" & txtSearchAll.Text & "%' OR HomeA LIKE '" & txtSearchAll.Text & "%' OR City LIKE '" & txtSearchAll.Text & "%' Or Eage LIKE '" & txtSearchAll.Text & "' OR Age LIKE '" & txtSearchAll.Text & "' OR Sex LIKE '" & txtSearchAll.Text & "%') AND phase =2 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearchAll.Text & "%' Or Stat LIKE '" & txtSearchAll.Text & "%' OR Tribe LIKE '" & txtSearchAll.Text & "%' OR Religion LIKE '" & txtSearchAll.Text & "%' OR TA LIKE '" & txtSearchAll.Text & "%' OR EA LIKE '" & txtSearchAll.Text & "%' OR HomeA LIKE '" & txtSearchAll.Text & "%' OR City LIKE '" & txtSearchAll.Text & "%' Or Eage LIKE '" & txtSearchAll.Text & "' OR Age LIKE '" & txtSearchAll.Text & "' OR Sex LIKE '" & txtSearchAll.Text & "%') ORDER BY Fname ;"
            End If
        End If

        If txtSearchAll.Text = "" And txtYearAll.Text <> "" Then
            If chkPhase1.Checked = True And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE yearg LIKE '" & txtYearAll.Text & "%'  ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = True And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE yearg LIKE '" & txtYearAll.Text & "%' AND phase =1 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE yearg LIKE '" & txtYearAll.Text & "%' AND phase =2 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearchAll.Text & "%' Or Stat LIKE '" & txtSearchAll.Text & "%' OR Tribe LIKE '" & txtSearchAll.Text & "%' OR Religion LIKE '" & txtSearchAll.Text & "%' OR TA LIKE '" & txtSearchAll.Text & "%' OR EA LIKE '" & txtSearchAll.Text & "%' OR HomeA LIKE '" & txtSearchAll.Text & "%' OR City LIKE '" & txtSearchAll.Text & "%' Or Eage LIKE '" & txtSearchAll.Text & "' OR Age LIKE '" & txtSearchAll.Text & "' OR Sex LIKE '" & txtSearchAll.Text & "%') ORDER BY Fname ;"
            End If
        End If

        If txtSearchAll.Text <> "" And txtYearAll.Text <> "" Then
            If chkPhase1.Checked = True And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearchAll.Text & "%' Or Stat LIKE '" & txtSearchAll.Text & "%' OR Tribe LIKE '" & txtSearchAll.Text & "%' OR Religion LIKE '" & txtSearchAll.Text & "%' OR TA LIKE '" & txtSearchAll.Text & "%' OR EA LIKE '" & txtSearchAll.Text & "%' OR HomeA LIKE '" & txtSearchAll.Text & "%' OR City LIKE '" & txtSearchAll.Text & "%' Or Eage LIKE '" & txtSearchAll.Text & "' OR Age LIKE '" & txtSearchAll.Text & "' OR Sex LIKE '" & txtSearchAll.Text & "%')AND yearg LIKE '" & txtYearAll.Text & "%' ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = True And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearchAll.Text & "%' Or Stat LIKE '" & txtSearchAll.Text & "%' OR Tribe LIKE '" & txtSearchAll.Text & "%' OR Religion LIKE '" & txtSearchAll.Text & "%' OR TA LIKE '" & txtSearchAll.Text & "%' OR EA LIKE '" & txtSearchAll.Text & "%' OR HomeA LIKE '" & txtSearchAll.Text & "%' OR City LIKE '" & txtSearchAll.Text & "%' Or Eage LIKE '" & txtSearchAll.Text & "' OR Age LIKE '" & txtSearchAll.Text & "' OR Sex LIKE '" & txtSearchAll.Text & "%')AND yearg LIKE '" & txtYearAll.Text & "%' AND phase =1 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearchAll.Text & "%' Or Stat LIKE '" & txtSearchAll.Text & "%' OR Tribe LIKE '" & txtSearchAll.Text & "%' OR Religion LIKE '" & txtSearchAll.Text & "%' OR TA LIKE '" & txtSearchAll.Text & "%' OR EA LIKE '" & txtSearchAll.Text & "%' OR HomeA LIKE '" & txtSearchAll.Text & "%' OR City LIKE '" & txtSearchAll.Text & "%' Or Eage LIKE '" & txtSearchAll.Text & "' OR Age LIKE '" & txtSearchAll.Text & "' OR Sex LIKE '" & txtSearchAll.Text & "%')AND yearg LIKE '" & txtYearAll.Text & "%' AND phase =2 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearchAll.Text & "%' Or Stat LIKE '" & txtSearchAll.Text & "%' OR Tribe LIKE '" & txtSearchAll.Text & "%' OR Religion LIKE '" & txtSearchAll.Text & "%' OR TA LIKE '" & txtSearchAll.Text & "%' OR EA LIKE '" & txtSearchAll.Text & "%' OR HomeA LIKE '" & txtSearchAll.Text & "%' OR City LIKE '" & txtSearchAll.Text & "%' Or Eage LIKE '" & txtSearchAll.Text & "' OR Age LIKE '" & txtSearchAll.Text & "' OR Sex LIKE '" & txtSearchAll.Text & "%')ORDER BY Fname ;"
            End If
        End If

        myCmd.Connection = myConn

        sql = myCmd.CommandText

        Dim myRead As MySqlDataReader = Nothing
        Dim mItem As ListViewItem

        lvPrint.Items.Clear()

        If myConn.State = ConnectionState.Closed Then
            Call ConnectDB()
        End If

        Try
            myRead = myCmd.ExecuteReader()
            If myRead.HasRows = True Then
                Do While myRead.Read()
                    mItem = New ListViewItem()
                    mItem = lvPrint.Items.Add(myRead.GetString("Fname"))
                    mItem.SubItems.Add(myRead.GetString("Sex"))
                    mItem.SubItems.Add(myRead.GetString("Eage"))
                    mItem.SubItems.Add(myRead.GetString("Age"))
                    mItem.SubItems.Add(myRead.GetString("Bday"))
                    mItem.SubItems.Add(myRead.GetString("Stat"))
                    mItem.SubItems.Add(myRead.GetString("HomeA"))
                    mItem.SubItems.Add(myRead.GetString("City"))
                    mItem.SubItems.Add(myRead.GetString("Num"))
                    mItem.SubItems.Add(myRead.GetString("Email"))
                    mItem.SubItems.Add(myRead.GetString("Religion"))
                    mItem.SubItems.Add(myRead.GetString("Tribe"))
                    mItem.SubItems.Add(myRead.GetString("EA"))
                    mItem.SubItems.Add(myRead.GetString("TA"))
                    mItem.SubItems.Add(myRead.GetString("Phase"))
                    mItem.SubItems.Add(myRead.GetString("Yearg"))
                Loop
            End If

            myRead.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error: Load Student")
        End Try
        myCmd = Nothing
        myRead = Nothing

    End Sub

    Private Sub btnPrintOrderForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintOrderForm.Click
        Dim report As New frmPrintForm
        report.vReportType = "vsbt"
        report.vsbtSQL = sql
        report.ShowDialog()

    End Sub

    Private Sub FrmAllPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.loadRecords()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtSearchAll_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchAll.TextChanged, txtYearAll.TextChanged, chkPhase1.CheckedChanged, chkPhase2.CheckedChanged
        If Not txtSearchAll.Text = "" Or Not txtYearAll.Text = "" Then
            Me.searchStudent()

        Else
            Me.loadRecords()

        End If

    End Sub

    Private Sub chkPhase1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPhase1.CheckedChanged
        If Not txtSearchAll.Text = "" Or Not txtYearAll.Text = "" Then
            Me.searchStudent()

        Else
            Me.loadRecords()

        End If

    End Sub
End Class