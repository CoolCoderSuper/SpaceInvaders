Public Class frmMain
    Public playerSpeed As Integer = 6
    Public bombSpeed As Integer = 10
    Public invaderSpeed As Integer = 5
    Public reloads As Integer = 3
    Private bullets As Integer = 30
    Private goleft As Boolean
    Private goright As Boolean
    Private score As Integer = 0
    Private isPressed As Boolean
    Private totalEnemies As Integer = 19
    Private isFriendHere As Boolean = False
    Private allowBomb As Boolean = False

    Private Sub KeyDown_CMD(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Left Then
            goleft = True
        End If
        If e.KeyCode = Keys.Right Then
            goright = True
        End If
        If e.KeyCode = Keys.Space AndAlso Not isPressed Then
            If Not (lblScore.Text.Contains("Game Over") Or lblScore.Text.Contains("You Win")) Then
                isPressed = True
                makeBullet()
                bullets -= 1
            End If
        End If
        If e.KeyCode = Keys.R Then
            If Not reloads <= 0 Then
                reloads -= 1
                bullets = 30
            Else
                gameOver(OverMethod.AMMO)
            End If
        End If
    End Sub

    Private Sub KeyUp_CMD(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Left Then
            goleft = False
        End If
        If e.KeyCode = Keys.Right Then
            goright = False
        End If
        If isPressed Then
            isPressed = False
        End If
    End Sub

    Private Sub tmrGame_Tick(sender As Object, e As EventArgs) Handles tmrGame.Tick
        If goleft Then
            pbMe.Left -= playerSpeed
        ElseIf goright Then
            pbMe.Left += playerSpeed
        End If

        If score > 10 Then
            Dim r As New Random
            Dim num As Integer = r.Next(100)
            If num = 7 Then
                If Not isFriendHere Then
                    makeFriend()
                    isFriendHere = True
                End If
            End If
        End If
        If isFriendHere Then
            For Each i As Control In Controls
                If TypeOf i Is PictureBox AndAlso i.Tag Is "friend" Then
                    CType(i, PictureBox).Left += invaderSpeed
                    If CType(i, PictureBox).Left > Width + 20 Then
                        CType(i, PictureBox).Left = 20
                    End If
                End If
            Next
        End If

        lblScore.Text = "Score : " & score
        If score > totalEnemies - 1 Then
            gameOver(OverMethod.WIN)
        End If
        If bullets < 0 Then
            lblBullets.Text = "0"
        Else
            lblBullets.Text = bullets
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrGame.Start()
        tmrBombMaker.Start()
        tmrGuns.Start()
        tmrCollision.Start()
        tmrShields.Start()
    End Sub

    Private Sub makeBullet()
        If Not bullets <= 0 Then
            Dim bullet As PictureBox = New PictureBox
            bullet.BackColor = Color.Black
            bullet.Size = New Size(5, 20)
            bullet.Tag = "bullet"
            bullet.Left = pbMe.Left + pbMe.Width / 2
            bullet.Top = pbMe.Top - 20
            Controls.Add(bullet)
            bullet.BringToFront()
        End If
    End Sub

    Private Sub makeBomb()
        Dim r As New Random
        Dim bomb As PictureBox = New PictureBox
        bomb.BackColor = Color.Orange
        bomb.Size = New Size(5, 20)
        bomb.Tag = "bomb"
        bomb.Left = r.Next(0, Width)
        bomb.Top = Top + 10
        Controls.Add(bomb)
        bomb.BringToFront()
    End Sub

    Private Sub makeFriend()
        Dim pb As PictureBox = New PictureBox
        pb.Size = New Size(50, 50)
        pb.Tag = "friend"
        pb.BackColor = Color.Aqua
        pb.Location = New Point(535, 12)
        Controls.Add(pb)
        pb.BringToFront()
    End Sub

    Private Sub gameOver(method As OverMethod)
        If method = OverMethod.LOSE Then
            lblScore.Text &= " Game Over. You been killed by the aliens!!!"
        ElseIf method = OverMethod.WIN Then
            lblScore.Text &= " You Win!!!"
        ElseIf method = OverMethod.AMMO Then
            lblScore.Text &= " Game Over. You're out of ammo!!!"
        ElseIf method = OverMethod.MURDERER Then
            lblScore.Text &= " Game Over. You killed the friend!!!"
        End If
        removeBullets()
        tmrGame.Stop()
        tmrBombMaker.Stop()
        tmrGuns.Stop()
        tmrCollision.Stop()
    End Sub

    Private Sub removeBullets()
        For Each j As Control In Controls
            If TypeOf j Is PictureBox AndAlso j.Tag Is "bullet" Then
                Controls.Remove(j)
            End If
        Next
    End Sub

    Private Sub tmrBombMaker_Tick(sender As Object, e As EventArgs) Handles tmrBombMaker.Tick
        makeBomb()
    End Sub

    Private Sub tmrGuns_Tick(sender As Object, e As EventArgs) Handles tmrGuns.Tick
        For Each y As Control In Controls
            If TypeOf y Is PictureBox AndAlso y.Tag Is "bullet" Then
                y.Top -= 20
                If CType(y, PictureBox).Top < Height - (Height - 10) Then
                    Controls.Remove(y)
                End If
            End If
        Next
        For Each y As Control In Controls
            If TypeOf y Is PictureBox AndAlso y.Tag Is "bomb" Then
                y.Top += bombSpeed
                If Not DesktopBounds.IntersectsWith(y.Bounds) Then
                    Controls.Remove(y)
                End If
            End If
        Next
        For Each i As Control In Controls
            If TypeOf i Is PictureBox AndAlso i.Tag Is "bomb" Then
                If i.Bounds.IntersectsWith(pbMe.Bounds) Then
                    Controls.Remove(i)
                    gameOver(OverMethod.LOSE)
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Private Sub tmrCollision_Tick(sender As Object, e As EventArgs) Handles tmrCollision.Tick
        For Each x As Control In Controls

            If TypeOf x Is PictureBox AndAlso x.Tag Is "invader" Then

                If CType(x, PictureBox).Bounds.IntersectsWith(pbMe.Bounds) Then
                    gameOver(OverMethod.LOSE)
                    removeBullets()
                    Exit Sub
                End If

                CType(x, PictureBox).Left += invaderSpeed

                If CType(x, PictureBox).Left > Width + 20 Then
                    CType(x, PictureBox).Top += CType(x, PictureBox).Height + 10
                    CType(x, PictureBox).Left = -50
                End If
            End If
        Next

        For Each i As Control In Controls

            For Each j As Control In Controls

                If TypeOf i Is PictureBox AndAlso i.Tag Is "invader" Then

                    If TypeOf j Is PictureBox AndAlso j.Tag Is "bullet" Then

                        If i.Bounds.IntersectsWith(j.Bounds) Then
                            score += 1
                            Controls.Remove(i)
                            Controls.Remove(j)
                        End If
                    End If
                End If
            Next
        Next
        For Each i As Control In Controls
            For Each j As Control In Controls

                If TypeOf i Is PictureBox AndAlso i.Tag Is "friend" Then

                    If TypeOf j Is PictureBox AndAlso j.Tag Is "bullet" Then

                        If i.Bounds.IntersectsWith(j.Bounds) Then
                            Controls.Remove(i)
                            Controls.Remove(j)
                            gameOver(OverMethod.MURDERER)
                            Exit Sub
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub tmrShields_Tick(sender As Object, e As EventArgs) Handles tmrShields.Tick
        For Each i As Control In Controls

            For Each j As Control In Controls

                If TypeOf i Is PictureBox AndAlso (i.Tag Is "bomb" Or i.Tag Is "bullet") Then

                    If TypeOf j Is PictureBox AndAlso j.Tag Is "shield" Then

                        If i.Bounds.IntersectsWith(j.Bounds) Then
                            Controls.Remove(i)
                            Controls.Remove(j)
                        End If
                    End If
                End If
            Next
        Next
    End Sub
End Class

Public Enum OverMethod
    WIN
    LOSE
    AMMO
    MURDERER
End Enum