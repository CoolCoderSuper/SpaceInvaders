Imports Avalonia.Controls
Imports Avalonia.Interactivity
Imports Avalonia.Markup.Xaml

Public Class MainView
    Inherits UserControl

    Private ReadOnly _displayManager As IDisplayManager
    Private ReadOnly _bombRate As TextBox
    Private ReadOnly _bombSpeed As TextBox
    Private ReadOnly _invaderCount As TextBox
    Private ReadOnly _invaderSpeed As TextBox
    Private ReadOnly _playerSpeed As TextBox
    Private ReadOnly _reloads As TextBox
    
    Public Sub New(displayManager As IDisplayManager)
        AvaloniaXamlLoader.Load(Me)
        _displayManager = displayManager
        _bombRate = FindControl(Of TextBox)("BombRate")
        _bombSpeed = FindControl(Of TextBox)("BombSpeed")
        _invaderCount = FindControl(Of TextBox)("InvaderCount")
        _invaderSpeed = FindControl(Of TextBox)("InvaderSpeed")
        _playerSpeed = FindControl(Of TextBox)("PlayerSpeed")
        _reloads = FindControl(Of TextBox)("Reloads")
    End Sub
    
    Public Sub LoadValues(intBombRate As Integer, intBombSpeed As Integer, intInvaderCount As Integer, intInvaderSpeed As Integer, intPlayerSpeed As Integer, intReloads As Integer)
        _bombRate.Text = intBombRate
        _bombSpeed.Text = intBombSpeed
        _invaderCount.Text = intInvaderCount
        _invaderSpeed.Text = intInvaderSpeed
        _playerSpeed.Text = intPlayerSpeed
        _reloads.Text = intReloads
    End Sub

    Private Sub Go_Click(sender As Object, e As RoutedEventArgs)
        Dim view As New GameView(_bombSpeed.Text, _playerSpeed.Text, _reloads.Text, _invaderCount.Text, _invaderSpeed.Text, _bombRate.Text, _displayManager)
        _displayManager.Show(view)
        _displayManager.Close(Me)
    End Sub
End Class