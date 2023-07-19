Public Class frmProductList

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        With frmProduct
            .LoadCategory()
            .ShowDialog()
        End With
    End Sub
End Class