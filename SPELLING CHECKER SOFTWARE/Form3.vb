Imports System.Data.SqlClient

Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim f As String = TextBox1.Text


        Dim qury As String = "Insert Into DATATABLE Values(@DataNaME)"
        Dim col As SqlConnection = New SqlConnection("Data Source=DESKTOP-CPL34M1\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand(qury, col)
        cmd.Parameters.AddWithValue("@DataNaME", f)



        col.Open()
        cmd.ExecuteNonQuery()
        col.Close()
        MessageBox.Show("DATA ADDED")
        BindDATA()
    End Sub

    Private Sub BindDATA()
        Dim query As String = "SELECT * FROM DATATABLE"

        Dim col As SqlConnection = New SqlConnection("Data Source=DESKTOP-CPL34M1\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand(query, col)
        Dim da As New SqlDataAdapter()
        da.SelectCommand = cmd
        Dim dt As New DataTable()
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim f As String = TextBox1.Text
        Dim q As String = "SELECT * FROM DATATABLE WHERE DATANAME= '" + TextBox1.Text + "' "
        Dim col As SqlConnection = New SqlConnection("Data Source=DESKTOP-CPL34M1\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand(q, col)
        Dim da As New SqlDataAdapter()
        da.SelectCommand = cmd
        Dim dt As New DataTable()

        da.Fill(dt)

        BindDATA()
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim f As String = TextBox1.Text


        Dim qury As String = "delete  datatable  Where DataName=@f"
        Dim col As SqlConnection = New SqlConnection("Data Source=DESKTOP-CPL34M1\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand(qury, col)
        cmd.Parameters.AddWithValue("@f", f)


        col.Open()
        cmd.ExecuteNonQuery()
        col.Close()
        MessageBox.Show("DATA DELETED")
        BindDATA()
    End Sub
End Class