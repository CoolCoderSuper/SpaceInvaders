Imports Avalonia.Controls
Imports Avalonia.Controls.Shapes
Imports Avalonia.Input
Imports Avalonia.Interactivity
Imports Avalonia.Markup.Xaml
Imports Avalonia.Media
Imports Avalonia.Threading
'TODO: Improve performance
Partial Public Class GameView
    Inherits UserControl

    Private _playerPosition As Integer
    Private ReadOnly _bulletRects As New List(Of Rectangle)
    Private ReadOnly _gameTimer As New DispatcherTimer
    Private ReadOnly _gameMovementTimer As New DispatcherTimer
    Private ReadOnly _bombTimer As New DispatcherTimer
    Private ReadOnly _bombMovementTimer As New DispatcherTimer
    Private _left As Boolean
    Private _right As Boolean
    Private _isShooting As Boolean
    Private ReadOnly _enemies As New List(Of Rectangle)
    Private ReadOnly _bombs As New List(Of Rectangle)
    Private ReadOnly _gameBoard As Canvas
    Private ReadOnly _playerRect As Rectangle
    Private ReadOnly _scoreLabel As TextBlock
    Private ReadOnly _bulletsLabel As TextBlock
    Private _score As Integer
    Private _bullets As Integer = 30
    Private _reloads As Integer = 3
    Private ReadOnly _bombSpeed As Integer = 20
    Private ReadOnly _playerSpeed As Integer = 5
    Private ReadOnly _enemyCount As Integer = 20
    Private ReadOnly _invaderSpeed As Integer = 5
    Private ReadOnly _bombRate As Integer = 30
    Private ReadOnly _displayManager As IDisplayManager

#Region "Components"

    Public Sub New(bombSpeed As Integer, playerSpeed As Integer, reloads As Integer, enemyCount As Integer, invaderSpeed As Integer, bombRate As Integer, displayManager As IDisplayManager)
        _bombSpeed = bombSpeed
        _playerSpeed = playerSpeed
        _reloads = reloads
        _enemyCount = enemyCount
        _invaderSpeed = invaderSpeed
        _bombRate = bombRate
        _displayManager = displayManager
        AvaloniaXamlLoader.Load(Me)
        _gameBoard = FindControl(Of Canvas)("GameBoard")
        _playerRect = New Rectangle With {
            .Fill = Brushes.GreenYellow,
            .Width = 50,
            .Height = 50
            }
        _gameBoard.Children.Add(_playerRect)
        _gameTimer.Interval = TimeSpan.FromMilliseconds(1)
        _gameTimer.Start()
        AddHandler _gameTimer.Tick, AddressOf game_Tick
        _gameMovementTimer.Interval = TimeSpan.FromMilliseconds(20)
        _gameMovementTimer.Start()
        AddHandler _gameMovementTimer.Tick, AddressOf gameMover_Tick
        _bombTimer.Interval = TimeSpan.FromMilliseconds(40)
        _bombTimer.Start()
        AddHandler _bombTimer.Tick, Sub() MakeBomb()
        _bombMovementTimer.Interval = TimeSpan.FromMilliseconds(_bombRate)
        _bombMovementTimer.Start()
        AddHandler _bombMovementTimer.Tick, AddressOf bombMover_Tick
        _scoreLabel = FindControl(Of TextBlock)("Score")
        SetScore()
        _bulletsLabel = FindControl(Of TextBlock)("Bullets")
        SetBullets()
    End Sub

#End Region

    Private Sub game_Tick(sender As Object, e As EventArgs)
        For Each enemy As Rectangle In _enemies
            If DoRectanglesIntersect(_playerRect, enemy) Then
                GameOver()
            End If
        Next
        For Each bombs As Rectangle In _bombs
            If DoRectanglesIntersect(_playerRect, bombs) Then
                GameOver()
            End If
        Next
        For Each bullet As Rectangle In _bulletRects.ToList
            For Each enemy As Rectangle In _enemies.ToList
                If DoRectanglesIntersect(bullet, enemy) Then
                    _gameBoard.Children.Remove(bullet)
                    _bulletRects.Remove(bullet)
                    _gameBoard.Children.Remove(enemy)
                    _enemies.Remove(enemy)
                    _score += 1
                    SetScore()
                    Exit For
                End If
            Next
        Next
    End Sub
    
    Private Sub gameMover_Tick(sender As Object, e As EventArgs)
        If _left Then
            _playerPosition -= _playerSpeed
            SetPlayerPosition()
        End If
        If _right Then
            _playerPosition += _playerSpeed
            SetPlayerPosition()
        End If
        For Each bullet As Rectangle In _bulletRects
            Canvas.SetTop(bullet, Canvas.GetTop(bullet) - 20)
        Next
        For Each enemy As Rectangle In _enemies
            Canvas.SetLeft(enemy, Canvas.GetLeft(enemy) + _invaderSpeed)
            If Canvas.GetLeft(enemy) > _gameBoard.Bounds.Width + 20 Then
                Canvas.SetTop(enemy, Canvas.GetTop(enemy) + enemy.Height + 10)
                Canvas.SetLeft(enemy, -50)
            End If
        Next
    End Sub
    
    Private Sub bombMover_Tick(sender As Object, e As EventArgs)
        For Each bomb As Rectangle In _bombs
            Canvas.SetTop(bomb, Canvas.GetTop(bomb) + _bombSpeed)
        Next
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs)
        Focus()
        SetupPlayer()
        SetPlayerPosition()
        CreateEnemies()
    End Sub

    Private Sub GameOver()
        _gameTimer.Stop()
        _gameMovementTimer.Stop()
        _bombTimer.Stop()
        _bombMovementTimer.Stop()
        _scoreLabel.Text &= " Game Over!"
    End Sub
    
    Private Sub SetupPlayer()
        Canvas.SetTop(_playerRect, _gameBoard.Bounds.Height - 50)
        _playerPosition = _gameBoard.Bounds.Width / 2 - 50
    End Sub
    
    Private Sub SetScore()
        _scoreLabel.Text = $"Score: {_score}"
        If _score = _enemyCount Then
            _scoreLabel.Text &= " You Win!"
            GameOver()
        End If
    End Sub
    
    Private Sub SetBullets()
        _bulletsLabel.Text = $"Bullets: {_bullets}"
    End Sub

    Private Sub MainWindow_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Left Then
            _left = True
            _right = False
        End If
        If e.Key = Key.Right Then
            _left = False
            _right = True
        End If
        If e.Key = Key.Space AndAlso Not _isShooting Then
            _isShooting = True
            MakeBullet()
        End If
    End Sub

    Private Sub MainWindow_KeyUp(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Left Then
            _left = False
        End If
        If e.Key = Key.Right Then
            _right = False
        End If
        If e.Key = Key.R Then
            If _reloads > 0 Then
                _reloads -= 1
                _bullets = 30
                SetBullets()
            End If
        End If
        If _isShooting Then
            _isShooting = False
        End If
    End Sub

    Private Function DoRectanglesIntersect(rect1 As Rectangle, rect2 As Rectangle) As Boolean
        Return rect1.Bounds.Intersects(rect2.Bounds)
    End Function

    Private Sub CreateEnemies()
        Dim enemiesOnScreen As Integer = _gameBoard.Bounds.Width / (55 + (10 / _enemyCount))
        Dim enemyBuffer As Integer = Math.Abs(enemiesOnScreen - _enemyCount) / 2
        Dim enemyPosition As Integer = 5 + enemyBuffer * 50
        For i As Integer = 0 To _enemyCount - 1
            Dim enemy As New Rectangle With {
                    .Height = 50,
                    .Width = 50,
                    .Fill = Brushes.Red,
                    .Tag = 0
                    }
            Canvas.SetTop(enemy, 1)
            Canvas.SetLeft(enemy, enemyPosition)
            enemyPosition += 55
            _enemies.Add(enemy)
            _gameBoard.Children.Add(enemy)
        Next
    End Sub

    Private Sub MakeBullet()
        If _bullets = 0 Then
            _bulletsLabel.Text = "Out of ammo, reload!"
            Return
        End If
        If _bullets = 0 AndAlso _reloads = 0 Then
            _bulletsLabel.Text = "Out of ammo!"
            Return
        End If
        Dim bulletRect As New Rectangle With {
            .Height = 20,
            .Width = 5,
            .Fill = Brushes.Wheat
        }
        Canvas.SetTop(bulletRect, _gameBoard.Bounds.Height - 70)
        Canvas.SetLeft(bulletRect, _playerPosition + 20)
        _bulletRects.Add(bulletRect)
        _gameBoard.Children.Add(bulletRect)
        _bullets -= 1
        SetBullets()
    End Sub

    Private Sub MakeBomb()
        Dim bombRect As New Rectangle With {
                .Height = 20,
                .Width = 5,
                .Fill = Brushes.DarkGoldenrod
                }
        Canvas.SetTop(bombRect, 1)
        Canvas.SetLeft(bombRect, Random.Shared.Next(0, _gameBoard.Bounds.Width))
        _bombs.Add(bombRect)
        _gameBoard.Children.Add(bombRect)
    End Sub

    Private Sub SetPlayerPosition()
        Canvas.SetLeft(_playerRect, _playerPosition)
    End Sub

    Private Sub MainWindow_SizeChanged(sender As Object, e As SizeChangedEventArgs)
        SetupPlayer()
    End Sub

    Private Sub Window_Closing(sender As Object, e As RoutedEventArgs)
        Dim mainView As MainView = New MainView(_displayManager)
        mainView.LoadValues(_bombRate, _bombSpeed, _enemyCount, _invaderSpeed, _playerSpeed, _reloads)
        _displayManager.Show(mainView)
        _displayManager.Close(Me)
    End Sub
End Class