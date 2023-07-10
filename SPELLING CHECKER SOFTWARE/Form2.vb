Imports System.IO

Public Class Form2
    Dim fs As FileStream
    Dim read As StreamReader
    Dim write As StreamWriter
    Dim a, b, c, d, f As String
    Dim counter As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        write = New StreamWriter(fs)
        write.Write(TextBox1.Text)
        write.Close()
        MessageBox.Show("file written")

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fs = New FileStream("D:\Textfile5.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)

    End Sub





    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Show()

    End Sub


End Class