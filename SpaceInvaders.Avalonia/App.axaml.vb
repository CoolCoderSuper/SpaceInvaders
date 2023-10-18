Imports Avalonia
Imports Avalonia.Controls.ApplicationLifetimes
Imports Avalonia.Markup.Xaml

Public Partial Class App
    Inherits Application
    Public Overrides Sub Initialize()
        AvaloniaXamlLoader.Load(Me)
    End Sub

    Public Overrides Sub OnFrameworkInitializationCompleted()
        Dim desktop As IClassicDesktopStyleApplicationLifetime = TryCast(ApplicationLifetime, IClassicDesktopStyleApplicationLifetime)
        If desktop IsNot Nothing Then
            Dim displayManager As New WindowDisplayManager()
            displayManager.Show(New MainView(displayManager))
            desktop.MainWindow = displayManager.Windows.Values(0)
        End If
        Dim view As ISingleViewApplicationLifetime = TryCast(ApplicationLifetime, ISingleViewApplicationLifetime)
        If view IsNot Nothing Then
            Dim displayManager As New ViewDisplayManager(view)
            view.MainView = New MainView(displayManager)
        End If
        MyBase.OnFrameworkInitializationCompleted()
    End Sub
    
End Class
