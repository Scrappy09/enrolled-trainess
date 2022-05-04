Imports MySql.Data.MySqlClient
Public Class FormPrint
    Dim fname
    Public Mcity As String

    Dim sql As String


    Private Sub loadRecords()
        Dim myCmd As New MySqlCommand

        Dim phasecondition As String

        If chkPhase1.Checked = True And chkPhase2.Checked = True Then
            phasecondition = "AND (phase=1 OR phase=2)"
        ElseIf chkPhase1.Checked = True And chkPhase2.Checked = False Then
            phasecondition = "AND phase=1"
        ElseIf chkPhase1.Checked = False And chkPhase2.Checked = True Then
            phasecondition = "AND phase=2"
        Else
            phasecondition = ""
        End If

        myCmd.CommandText = "SELECT Fname, Sex, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, Stat, HomeA, City, Num, Email, Tribe, Religion, EA, TA, Phase, Yearg FROM vsbt WHERE City LIKE '%" & Mcity & "%' " & phasecondition & " ORDER by fname ;"
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

    Private Sub FormPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblStudentName.Text = Mcity
        Me.loadRecords()

    End Sub

    Private Sub searchStudent()
        Dim myCmd As New MySqlCommand

        If txtSearch.Text = "" And txtYear.Text = "" Then
            myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt ORDER BY Fname;"
        End If

        If txtSearch.Text <> "" And txtYear.Text = "" Then
            If chkPhase1.Checked = True And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' Or Stat LIKE '" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR City LIKE '" & txtSearch.Text & "%' Or Eage LIKE '" & txtSearch.Text & "%' OR Age LIKE '%" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%') AND City LIKE '" & Mcity & "' ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = True And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' Or Stat LIKE '" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR City LIKE '" & txtSearch.Text & "%' Or Eage LIKE '" & txtSearch.Text & "%' OR Age LIKE '" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%') AND City LIKE '" & Mcity & "' AND phase =1 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' Or Stat LIKE '" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR City LIKE '" & txtSearch.Text & "%' Or Eage LIKE '" & txtSearch.Text & "%' OR Age LIKE '" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%') AND City LIKE '" & Mcity & "' AND phase =2 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' Or Stat LIKE '" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR City LIKE '" & txtSearch.Text & "%' Or Eage LIKE '" & txtSearch.Text & "%' OR Age LIKE '" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%') AND City LIKE '" & Mcity & "' ORDER BY Fname ;"
            End If
        End If

        If txtSearch.Text = "" And txtYear.Text <> "" Then
            If chkPhase1.Checked = True And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase, yearg FROM vsbt WHERE yearg LIKE '" & txtYear.Text & "%' AND City LIKE '%" & Mcity & "%' ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = True And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase, yearg FROM vsbt WHERE yearg LIKE '" & txtYear.Text & "%' AND City LIKE '%" & Mcity & "%' AND phase =1 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase, yearg FROM vsbt WHERE yearg LIKE '" & txtYear.Text & "%' AND City LIKE '%" & Mcity & "%' AND phase =2 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase, yearg FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' Or Stat LIKE '" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR City LIKE '" & txtSearch.Text & "%' Or Eage LIKE '" & txtSearch.Text & "%' OR Age LIKE '" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%')AND City LIKE '" & Mcity & "' ORDER BY Fname ;"
            End If
        End If

        If txtSearch.Text <> "" And txtYear.Text <> "" Then
            If chkPhase1.Checked = True And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' Or Stat LIKE '" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR City LIKE '" & txtSearch.Text & "%' Or Eage LIKE '" & txtSearch.Text & "%' OR Age LIKE '" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%')AND yearg LIKE '" & txtYear.Text & "%' AND City LIKE '" & Mcity & "' ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = True And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' Or Stat LIKE '" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR City LIKE '" & txtSearch.Text & "%' Or Eage LIKE '" & txtSearch.Text & "%' OR Age LIKE '" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%')AND yearg LIKE '" & txtYear.Text & "%' AND City LIKE '" & Mcity & "' AND phase =1 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = True Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' Or Stat LIKE '" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR City LIKE '" & txtSearch.Text & "%' Or Eage LIKE '" & txtSearch.Text & "%' OR Age LIKE '" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%')AND yearg LIKE '" & txtYear.Text & "%' AND City LIKE '" & Mcity & "' AND phase =2 ORDER BY Fname ;"
            ElseIf chkPhase1.Checked = False And chkPhase2.Checked = False Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & txtSearch.Text & "%' Or Stat LIKE '" & txtSearch.Text & "%' OR Tribe LIKE '" & txtSearch.Text & "%' OR Religion LIKE '" & txtSearch.Text & "%' OR TA LIKE '" & txtSearch.Text & "%' OR EA LIKE '" & txtSearch.Text & "%' OR HomeA LIKE '" & txtSearch.Text & "%' OR City LIKE '" & txtSearch.Text & "%' Or Eage LIKE '" & txtSearch.Text & "%' OR Age LIKE '" & txtSearch.Text & "%' OR Sex LIKE '" & txtSearch.Text & "%')AND City LIKE '" & Mcity & "' ORDER BY Fname ;"
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
                    fname = mItem


                    mItem.SubItems.Add(myRead.GetString("Sex"))
                    mItem.SubItems.Add(myRead.GetString("Eage"))
                    mItem.SubItems.Add(myRead.GetString("Age"))
                    mItem.SubItems.Add(myRead.GetString("Bday"))
                    mItem.SubItems.Add(myRead.GetString("Stat"))
                    mItem.SubItems.Add(myRead.GetString("HomeA"))
                    mItem.SubItems.Add(myRead.GetString("City"))
                    mItem.SubItems.Add(myRead.GetString("Num"))
                    mItem.SubItems.Add(myRead.GetString("Email"))
                    mItem.SubItems.Add(myRead.GetString("Tribe"))
                    mItem.SubItems.Add(myRead.GetString("Religion"))
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
    Private Sub BtnPhase1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.loadRecords(1)

        Call searchStudent()
    End Sub

    Private Sub BtnPhase2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'loadRecords(2)
        Call searchStudent()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged, txtYear.TextChanged, chkPhase1.CheckedChanged, chkPhase2.CheckedChanged
        If Not txtSearch.Text = "" Or Not txtYear.Text = "" Then
            Me.searchStudent()

        Else
            Me.loadRecords()

        End If

    End Sub

    Private Sub chkPhase1_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPhase1.CheckedChanged, chkPhase2.CheckedChanged
        'If chkPhase1.Checked = True And chkPhase2.Checked = True Then
        'Call loadRecords()
        'Else
        'Call searchStudent()
        'End If
    End Sub

    Private Sub btnPrintOrderForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintOrderForm.Click
        Dim report As New frmPrintForm
        report.vReportType = "vsbt"
        report.vsbtSQL = sql
        report.ShowDialog()

    End Sub
End Class