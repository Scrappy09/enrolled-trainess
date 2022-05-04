Imports MySql.Data.MySqlClient

Public Class Formaddedit
    Dim selStud As Integer
    Dim selFirstName As String
    Dim selSex As String
    Dim selCivilStatus As String
    Dim selBirthDate As String
    Dim selHomeAddress As String
    Dim selCityMunicipality As String
    Dim selTribe As String
    Dim selTradeArea As String
    Dim selReligion As String
    Dim selContactNumber As String
    Dim selYearGraduated As String
    Dim selAge As String
    Dim selEAge As String
    Dim selEA As String
    Dim selEmail As String
    Dim selPhase As String

    Private Sub lvRecords_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvRecords.ItemSelectionChanged

        selFirstName = lvRecords.FocusedItem.Text
        selSex = lvRecords.FocusedItem.SubItems(1).Text
        selEAge = lvRecords.FocusedItem.SubItems(2).Text
        selAge = lvRecords.FocusedItem.SubItems(3).Text
        selBirthDate = lvRecords.FocusedItem.SubItems(4).Text
        selCivilStatus = lvRecords.FocusedItem.SubItems(5).Text
        selHomeAddress = lvRecords.FocusedItem.SubItems(6).Text
        selCityMunicipality = lvRecords.FocusedItem.SubItems(7).Text
        selContactNumber = lvRecords.FocusedItem.SubItems(8).Text
        selEmail = lvRecords.FocusedItem.SubItems(9).Text
        selReligion = lvRecords.FocusedItem.SubItems(10).Text
        selTribe = lvRecords.FocusedItem.SubItems(11).Text
        selEA = lvRecords.FocusedItem.SubItems(12).Text
        selTradeArea = lvRecords.FocusedItem.SubItems(13).Text
        selPhase = lvRecords.FocusedItem.SubItems(14).Text
        selYearGraduated = lvRecords.FocusedItem.SubItems(15).Text


    End Sub

    Private Sub loadRecords()
        Dim myCmd As New MySqlCommand
        myCmd.CommandText = "SELECT Fname, Sex, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, Stat, HomeA, City, Num, Email, Tribe, Religion, EA, TA, Phase, Yearg FROM vsbt ORDER by Fname ;"
        myCmd.Connection = myConn


        Dim myRead As MySqlDataReader = Nothing
        Dim mItem As ListViewItem

        lvRecords.Items.Clear()

        If myConn.State = ConnectionState.Closed Then
            Call ConnectDB()
        End If

        Try
            myRead = myCmd.ExecuteReader()
            If myRead.HasRows = True Then
                Do While myRead.Read()
                    mItem = New ListViewItem()
                    mItem = lvRecords.Items.Add(myRead.GetString("Fname"))

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
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error Load Records")
        End Try
        myCmd = Nothing
        myRead = Nothing

    End Sub

    Private Sub Formaddedit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.loadRecords()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Not selFirstName = "" Then
            grp_Student.Text = "Update Data"
            grp_Student.Enabled = True
            TxtFname.Focus()
            btnOk.Text = "Update"
            btnCLOSE.Text = "Cancel"


            TxtFname.Text = selFirstName
            CBSex.Text = selSex
            CBStatus.Text = selCivilStatus
            TxtEage.Text = selEAge
            TxtAge.Text = selAge
            DTPBirth.Text = selBirthDate
            TxtHomeA.Text = selHomeAddress
            TxtCity.Text = selCityMunicipality
            TxtTribe.Text = selTribe
            TxtTradeArea.Text = selTradeArea
            TxtReligion.Text = selReligion
            TxtNumber.Text = selContactNumber
            TxtYearg.Text = selYearGraduated
            TxtEA.Text = selEA
            TxtPhase.Text = selPhase


        Else
            MsgBox("Please Select a Data", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        grp_Student.Enabled = True
        grp_Student.Text = "Add New Student"
        btnOk.Text = "Add"
        btnCLOSE.Text = "Cancel"


        TxtFname.Text = ""
        CBSex.Text = ""
        CBStatus.Text = ""
        TxtEage.Text = ""
        TxtAge.Text = ""
        DTPBirth.Text = ""
        TxtHomeA.Text = ""
        TxtCity.Text = ""
        TxtTribe.Text = ""
        TxtTradeArea.Text = ""
        TxtReligion.Text = ""
        TxtNumber.Text = ""
        TxtYearg.Text = ""
        TxtEA.Text = ""
        TxtEmail.Text = ""
        TxtPhase.Text = ""

    End Sub

    Private Function addStudent(ByVal vFname As String, ByVal vSex As String, ByVal vStat As String, ByVal vAge As String, ByVal vEage As String, ByVal vBday As String, ByVal vHomeA As String, ByVal vCity As String, ByVal vTribe As String, ByVal vTA As String, ByVal vReligion As String, ByVal vNum As String, ByVal vYearg As String, ByVal vEA As String, ByVal vEmail As String, ByVal vPhase As String) As Boolean
        On Error GoTo ErrTrap

        Dim myAdapter As New MySqlDataAdapter
        Dim myCommand As New MySqlCommand()

        Call ConnectDB()

        If myConn.State = ConnectionState.Open Then
            myCommand.Connection = myConn
            myCommand.CommandText = "INSERT INTO vsbt(Fname, Sex, Stat, Eage, Age, Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase) VALUES('" & vFname & "','" & vSex & "','" & vStat & "','" & vAge & "','" & vEage & "','" & vBday & "','" & vHomeA & "','" & vCity & "','" & vTribe & "','" & vTA & "','" & vReligion & "','" & vNum & "','" & vYearg & "','" & vEA & "','" & vEmail & "','" & vPhase & "')"
            myAdapter.SelectCommand = myCommand
            myCommand.ExecuteReader()
        End If

        myConn.Close()

        Return True
        Exit Function
ErrTrap:
        MsgBox(Err.Description, MsgBoxStyle.Exclamation)
        myConn.Close()
    End Function

    Private Function updateStudent(ByVal vFname As String, ByVal vSex As String, ByVal vStatus As String, ByVal vEage As String, ByVal vBday As String, ByVal vHomeA As String, ByVal vCity As String, ByVal vTribe As String, ByVal vTA As String, ByVal vReligion As String, ByVal vNumber As String, ByVal vYearg As String, ByVal vEA As String, ByVal vEmail As String, ByVal vPhase As String) As Boolean
        On Error GoTo Errtrap

        Dim myAdapter As New MySqlDataAdapter
        Dim myCommand As New MySqlCommand()

        Call ConnectDB()

        If myConn.State = ConnectionState.Open Then
            myCommand.Connection = myConn
            myCommand.CommandText = "UPDATE vsbt SET Fname = '" & vFname & "', Sex = '" & vSex & "', Stat = '" & vStatus & "', Eage = '" & vEage & "', Bday = '" & vBday & "', HomeA = '" & vHomeA & "', City = '" & vCity & "', Tribe = '" & vTribe & "', TA = '" & vTA & "', Religion = '" & vReligion & "', Num = '" & vNumber & "', Yearg = '" & vYearg & "', EA = '" & vEA & "', Email = '" & vEmail & "', Phase = '" & vPhase & "'WHERE Fname = '" & selFirstName & "'; "
            myAdapter.SelectCommand = myCommand
            myCommand.ExecuteReader()
        End If
        myConn.Close()

        Return True
        Exit Function
Errtrap:
        MsgBox(Err.Description, MsgBoxStyle.Exclamation)
        myConn.Close()
    End Function


    Private Sub btnOk_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If btnOk.Text = "Add" Then
            'ADD CUSTOMER

            If addStudent(TxtFname.Text, CBSex.Text, CBStatus.Text, TxtEage.Text, TxtAge.Text, DTPBirth.Text, TxtHomeA.Text, TxtCity.Text, TxtTribe.Text, TxtTradeArea.Text, TxtReligion.Text, TxtNumber.Text, TxtYearg.Text, TxtEA.Text, TxtEmail.Text, TxtPhase.Text) = True Then
                MsgBox("New Data Successfully Added!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Me.loadRecords()

                grp_Student.Enabled = False
                lvRecords.Focus()


                TxtFname.Text = ""
                CBSex.Text = ""
                CBStatus.Text = ""
                TxtEage.Text = ""
                TxtAge.Text = ""
                DTPBirth.Text = ""
                TxtHomeA.Text = ""
                TxtCity.Text = ""
                TxtTribe.Text = ""
                TxtTradeArea.Text = ""
                TxtReligion.Text = ""
                TxtNumber.Text = ""
                TxtYearg.Text = ""
                TxtEA.Text = ""
                TxtEmail.Text = ""
                TxtPhase.Text = ""


            Else
                MsgBox("Please fill out all the entries!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            End If

        Else

            ' UPDATE CUSTOMER
            If updateStudent(TxtFname.Text, CBSex.Text, CBStatus.Text, TxtEage.Text, DTPBirth.Text, TxtHomeA.Text, TxtCity.Text, TxtTribe.Text, TxtTradeArea.Text, TxtReligion.Text, TxtNumber.Text, TxtYearg.Text, TxtEA.Text, TxtEmail.Text, TxtPhase.Text) = True Then
                MsgBox("Information Updated!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Me.loadRecords()

                grp_Student.Enabled = False
                lvRecords.Focus()


                TxtFname.Text = ""
                CBSex.Text = ""
                CBStatus.Text = ""
                TxtEage.Text = ""
                TxtAge.Text = ""
                DTPBirth.Text = ""
                TxtHomeA.Text = ""
                TxtCity.Text = ""
                TxtTribe.Text = ""
                TxtTradeArea.Text = ""
                TxtReligion.Text = ""
                TxtNumber.Text = ""
                TxtYearg.Text = ""
                TxtEA.Text = ""
                TxtEmail.Text = ""
                TxtPhase.Text = ""

            Else
                MsgBox("Please fill out all the entries!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)

            End If
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Not selFirstName = "" Then
            If MsgBox("Are you sure you want to delete" & selFirstName, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If DeleteStudID(selFirstName) = True Then
                    Me.loadRecords()
                End If
            End If
        Else
            MsgBox("Please select a Student", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
        End If
    End Sub
    Private Function DeleteStudID(ByVal vFname As String) As Boolean
        On Error GoTo Errtrap

        Dim myAdapter As New MySqlDataAdapter
        Dim myCommand As New MySqlCommand()

        Call ConnectDB()

        If myConn.State = ConnectionState.Open Then
            myCommand.Connection = myConn
            myCommand.CommandText = "DELETE from vsbt WHERE Fname ='" & vFname & "';"
            myAdapter.SelectCommand = myCommand
            myCommand.ExecuteReader()
        End If

        myConn.Close()

        Return True
        Exit Function
Errtrap:
        MsgBox(Err.Description, MsgBoxStyle.Exclamation)
        myConn.Close()
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLOSE.Click
        If btnCLOSE.Text = "Cancel" Then
            grp_Student.Enabled = False
            lvRecords.Focus()
            btnCLOSE.Text = "CLOSE"

        Else
            Me.Close()
        End If

    End Sub

    Private Sub searchStudent()
        Dim myCmd As New MySqlCommand
        If txtFilter.Text <> "" Then
            myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage,round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & TxtSearch.Text & "%' OR Tribe LIKE '" & TxtSearch.Text & "%' OR Eage LIKE '" & TxtSearch.Text & "%' OR Religion LIKE '" & TxtSearch.Text & "%' OR EA LIKE '" & TxtSearch.Text & "%' OR TA LIKE '" & TxtSearch.Text & "%' OR HomeA LIKE '" & TxtSearch.Text & "%' OR City LIKE '" & TxtSearch.Text & "%' OR Age LIKE '" & TxtSearch.Text & "%' OR Stat LIKE '" & TxtSearch.Text & "%' OR Sex LIKE '" & TxtSearch.Text & "%' OR Yearg LIKE '" & TxtSearch.Text & "%') AND Phase ='" & txtFilter.Text & "' ORDER BY Fname ;"
            If txtFilter.Text  <> "" And TxtSearch.Text  <> "" Then
                myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage,round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE (Fname LIKE '%" & TxtSearch.Text & "%' OR Stat LIKE '" & TxtSearch.Text & "%' OR Eage LIKE '" & TxtSearch.Text & "%' OR Tribe LIKE '" & TxtSearch.Text & "%' OR Religion LIKE '" & TxtSearch.Text & "%' OR TA LIKE '" & TxtSearch.Text & "%' OR EA LIKE '" & TxtSearch.Text & "%' OR HomeA LIKE '" & TxtSearch.Text & "%' OR City LIKE '" & TxtSearch.Text & "%' OR Age LIKE '" & TxtSearch.Text & "%' OR Sex LIKE '" & TxtSearch.Text & "%') and (Fname LIKE '%" & txtFilter.Text & "%' Or Stat LIKE '" & txtFilter.Text & "%' OR Tribe LIKE '" & txtFilter.Text & "%' OR Religion LIKE '" & txtFilter.Text & "%' OR TA LIKE '" & txtFilter.Text & "%' OR EA LIKE '" & txtFilter.Text & "%' OR HomeA LIKE '" & txtFilter.Text & "%' OR City LIKE '" & txtFilter.Text & "%' OR Age LIKE '" & txtFilter.Text & "%' OR Sex LIKE '" & txtFilter.Text & "%') ORDER BY Fname ;"
            End If
        Else
            myCmd.CommandText = "SELECT Fname, Sex, Stat, Eage, round((floor(datediff(now(),bday))/360)) AS 'age', Bday, HomeA, City, Tribe, TA, Religion, Num, Yearg, EA, Email, Phase FROM vsbt WHERE Fname LIKE '%" & TxtSearch.Text & "%' OR Eage LIKE '" & TxtSearch.Text & "%' OR Tribe LIKE '" & TxtSearch.Text & "%' OR Religion LIKE '" & TxtSearch.Text & "%' OR TA LIKE '" & TxtSearch.Text & "%' OR EA LIKE '" & TxtSearch.Text & "%' OR HomeA LIKE '" & TxtSearch.Text & "%' OR City LIKE '" & TxtSearch.Text & "%' OR Age LIKE '" & TxtSearch.Text & "%' OR Sex LIKE '" & TxtSearch.Text & "%' OR Yearg LIKE '" & TxtSearch.Text & "%' OR Stat LIKE '" & TxtSearch.Text & "%'ORDER BY Fname ;"
        End If

        myCmd.Connection = myConn

        Dim myRead As MySqlDataReader = Nothing
        Dim mItem As ListViewItem

        lvRecords.Items.Clear()

        If myConn.State = ConnectionState.Closed Then
            Call ConnectDB()
        End If

        Try
            myRead = myCmd.ExecuteReader()
            If myRead.HasRows = True Then
                Do While myRead.Read()
                    mItem = New ListViewItem()
                    mItem = lvRecords.Items.Add(myRead.GetString("Fname"))

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
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error: Load Records")
        End Try
        myCmd = Nothing
        myRead = Nothing

    End Sub

    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged, txtFilter.TextChanged
        If Not TxtSearch.Text = "" Then
            Me.searchStudent()
        Else
            Me.loadRecords()
        End If

    End Sub


    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub
End Class