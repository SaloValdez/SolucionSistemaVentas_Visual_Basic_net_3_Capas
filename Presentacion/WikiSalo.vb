Public Class WikiSalo

    Private Sub WikiSalo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.F1 Then
            MsgBox("Se presiono la tecla F1")
        ElseIf e.KeyData = Keys.C Then

        End If
        If e.KeyData = Keys.Control + Keys.N Then
            MessageBox.Show("Se ha pulsado la combinación de teclas Control+N")
        End If

    End Sub

End Class