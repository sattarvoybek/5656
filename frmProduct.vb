Imports MySql.Data.MySqlClient
Imports System.IO
Public Class frmProduct
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Dispose()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With frmCategory
            .ShowDialog()
        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Using ofd As New OpenFileDialog With {.Filter = "(Image Files)|*.jpg;*.png;*.bmp*.gif*.ico|Jpg,|*.jpg|Png,|*.png|Bmp,|*.bmp|Gif,|*.gif|Ico,|*.ico",
                 .Multiselect = False, .Title = "Select Image"}

            If ofd.ShowDialog = 1 Then
                PictureBox1.BackgroundImage = Image.FromFile(ofd.FileName)
            End If
        End Using
    End Sub

    Sub LoadCategory()
        cboCategory.Items.Clear()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MsgBox("Save this record?", vbYesNo + vbQuestion) = vbYes Then
                Dim mstream As New MemoryStream
                PictureBox1.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim arrImage() As Byte = mstream.GetBuffer

                cn.Open()
                cm = New MySqlCommand("Insert into tblproduct(description, price, category, weight, image)(@description, @price, @category, @weight, @image)", cn)
                With cm.Parameters
                    .AddWithValue("@description", txtDescription.Text)
                    .AddWithValue("@price", CDbl(txtPrice.Text))
                    .AddWithValue("@category", cboCategory.Text)
                    .AddWithValue("@weight", CheckBox1.Checked.ToString)
                    .AddWithValue("@image", arrImage)
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Record has been successfully saved!", vbInformation)
            End If
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class