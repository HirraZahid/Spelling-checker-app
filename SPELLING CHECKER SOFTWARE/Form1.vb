Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports System.IO
Public Class Form1
    Dim fs As FileStream
    Dim fread As StreamReader
    Dim counter As Integer = 0
    Dim wrong As Integer = 0
    'Dim t1, t2, t3 As TimeSpan
    Dim correct As Integer = 0
    Dim i As Integer = 0
    Dim a, b, c, d, f As String

    Dim pic As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SAPI As Object
        SAPI = CreateObject("SAPI.spvoice")
        Dim rn As New Random
        Dim d As Integer = rn.Next(0, 3)



        If d = 0 Then
            SAPI.Speak(TextBox1.Text)
        ElseIf d = 1 Then
            SAPI.Speak(TextBox2.Text)
        ElseIf d = 2 Then
            SAPI.Speak(TextBox3.Text)

        Else
            SAPI.Speak(TextBox4.Text)
            'counter = -1

        End If

        'counter += 1

        Timer1.Start()


    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim SAPI As Object
            SAPI = CreateObject("SAPI.spvoice")
            If TextBox6.Text = TextBox1.Text Or TextBox6.Text = "mango" Or TextBox6.Text = "Mango" Then

                SAPI.Speak("Right")
                correct += 1

            ElseIf TextBox6.Text = TextBox2.Text Or TextBox6.Text = "apple" Or TextBox6.Text = "Apple" Then

                SAPI.Speak("Right")
                correct += 1

            ElseIf TextBox6.Text = TextBox3.Text Or TextBox6.Text = "Banana" Or TextBox6.Text = "banana" Then

                SAPI.Speak("Right")
                correct += 1

            ElseIf TextBox6.Text = TextBox4.Text Or TextBox6.Text = "Orange" Or TextBox6.Text = "orange" Then

                SAPI.Speak("Right")
                correct += 1
            Else
                SAPI.Speak("Wrong")
                wrong += 1
            End If
            'MessageBox.Show("correct : " + correct.ToString + "Wrong :" + wrong.ToString)
            Timer1.Stop()
            Me.DataGridView1.Rows.Add(i, correct, wrong)

        End If

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox6.Clear()
        i = 0

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim i As Integer
        i = e.RowIndex
        Dim SelectedRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
        If e.RowIndex >= 0 Then
            TextBox1.Text = SelectedRow.Cells("DataName").Value.ToString
            'TextBox1.Text += SelectedRow.Cells(0).Value.ToString
            'TextBox1.Text += SelectedRow.Cells(0).Value.ToString
            'TextBox1.Text += SelectedRow.Cells(0).Value.ToString
        End If


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i += 1

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Dim fileReader As String
        'fileReader = My.Computer.FileSystem.ReadAllText("D:\TextFile5.txt")

        'If fileReader.Contains(a) Then
        '    MsgBox(fileReader)
        'End If

        'fread = New StreamReader(fs)
        'a = fread.ReadLine()
        'b = fread.ReadLine()
        'c = fread.ReadLine()
        'd = fread.ReadLine()
        ''f = fread.ReadLine()
        'fread.Close()

        'TextBox1.Text = a
        'TextBox2.Text = b
        'TextBox3.Text = c
        'TextBox4.Text = d



        Dim col As SqlConnection = New SqlConnection("Data Source=DESKTOP-CPL34M1\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand("select * from datatable", col)
        Dim a As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        a.Fill(dt)

        'TextBox1.Text = dt
        DataGridView2.DataSource = dt
        If dt.Rows.Count > 0 Then
            TextBox1.Text = dt.Rows(0)(0).ToString
            TextBox2.Text = dt.Rows(1)(0).ToString
            TextBox3.Text = dt.Rows(2)(0).ToString
            TextBox4.Text = dt.Rows(3)(0).ToString
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'TextBox6.Clear()
        Me.Hide()
        Form2.Show()


    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fs = New FileStream("D:\Textfile6.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
    End Sub
End Class
