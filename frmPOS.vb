Public Class frmPOS
    Private Sub btnProduct_Click(sender As Object, e As EventArgs) Handles btnProduct.Click
        With frmProductList
            .ShowDialog()
        End With

    End Sub
End Class
