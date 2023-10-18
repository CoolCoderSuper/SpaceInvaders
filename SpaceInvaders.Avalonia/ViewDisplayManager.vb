Imports Avalonia.Controls
Imports Avalonia.Controls.ApplicationLifetimes

Public Class ViewDisplayManager
    Implements IDisplayManager

    Private ReadOnly _lifetime As ISingleViewApplicationLifetime

    Public Sub New(lifetime As ISingleViewApplicationLifetime)
        _lifetime = lifetime
    End Sub
    
    Public Sub Show(view As UserControl) Implements IDisplayManager.Show
        _lifetime.MainView = view
    End Sub

    Public Sub Close(view As UserControl) Implements IDisplayManager.Close
        
    End Sub
End Class