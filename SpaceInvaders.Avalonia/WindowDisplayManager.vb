Imports Avalonia.Controls

Public Class WindowDisplayManager
    Implements IDisplayManager
    Public ReadOnly Property Windows As New Dictionary(Of UserControl, Window)

    Public Sub Show(view As UserControl) Implements IDisplayManager.Show
        Dim window As New Window With {
                .Content = view,
                .Title = "Space Invaders",
                .WindowState = WindowState.Maximized
                }
        Windows.Add(view, window)
        window.Show()
    End Sub

    Public Sub Close(view As UserControl) Implements IDisplayManager.Close
        Windows(view).Close()
    End Sub
End Class