Public Class frmSettings
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Dim frm As New frmMain
        frm.tmrBombMaker.Interval = txtBombRate.Value
        frm.bombSpeed = txtBombSpeed.Value
        frm.invaderSpeed = txtInvaderSpeed.Value
        frm.playerSpeed = txtPlayerSpeed.Value
        frm.reloads = txtReloads.Value
        frm.ShowDialog()
    End Sub
End Class