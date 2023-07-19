﻿Imports MySql.Data.MySqlClient

Public Class frmCategory
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MsgBox("Save this category", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cm = New MySqlCommand("insert into tblcategory (category)values(@category)", cn)
                cm.Parameters.AddWithValue("@category", txtCategory.Text)
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Category has successfully saved!", vbInformation)
                txtCategory.Clear()
                txtCategory.Focus()
                With frmProduct
                    .LoadCategory()
                End With
            End If
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class