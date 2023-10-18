Imports Avalonia.Controls
Imports Avalonia.Interactivity
Imports Avalonia.Markup.Xaml

Public Class MainWindow
    Inherits Window

    Private ReadOnly _bombRate As TextBox
    Private ReadOnly _bombSpeed As TextBox
    Private ReadOnly _invaderCount As TextBox
    Private ReadOnly _invaderSpeed As TextBox
    Private ReadOnly _playerSpeed As TextBox
    Private ReadOnly _reloads As TextBox
    
    Public Sub New()
        AvaloniaXamlLoader.Load(Me)
        _bombRate = FindControl(Of TextBox)("BombRate")
        _bombSpeed = FindControl(Of TextBox)("BombSpeed")
        _invaderCount = FindControl(Of TextBox)("InvaderCount")
        _invaderSpeed = FindControl(Of TextBox)("InvaderSpeed")
        _playerSpeed = FindControl(Of TextBox)("PlayerSpeed")
        _reloads = FindControl(Of TextBox)("Reloads")
    End Sub

    Private Sub Go_Click(sender As Object, e As RoutedEventArgs)
        Dim frm As New GameWindow(_bombSpeed.Text, _playerSpeed.Text, _reloads.Text, _invaderCount.Text, _invaderSpeed.Text, _bombRate.Text)
        frm.Show()
        Close()
    End Sub
End Class