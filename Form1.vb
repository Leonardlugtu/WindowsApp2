Imports System.Data
Imports Npgsql


Public Class Form1

    Dim lv As ListViewItem
    Dim selected As String

    Private Sub Poplistview()
        ListView1.Clear()

        With ListView1
            .View = View.Details
            .GridLines = True
            .Columns.Add("ID", 40)
            .Columns.Add("Last name", 110)
            .Columns.Add("First name", 110)
            .Columns.Add("Course", 110)

        End With

        openCon()
        sql = "Select * from tbstudinfo"
        cmd = New NpgsqlCommand(sql, cn)
        dr = cmd.ExecuteReader()

        Do While dr.Read()
            lv = New ListViewItem(dr("studno").ToString)
            lv.SubItems.Add(dr("studlastname"))
            lv.SubItems.Add(dr("studfirstname"))
            lv.SubItems.Add(dr("studcourse"))
            ListView1.Items.Add(lv)

        Loop
        cn.Close()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Poplistview()


    End Sub
End Class
