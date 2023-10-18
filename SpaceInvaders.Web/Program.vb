Imports System.Runtime.Versioning
Imports Avalonia
Imports Avalonia.Browser
Imports SpaceInvaders.Avalonia

<Assembly: SupportedOSPlatform("browser")>

Friend Module Program
    Public Sub Main(args As String())
        BuildAvaloniaApp().StartBrowserAppAsync("out")
    End Sub

    Public Function BuildAvaloniaApp() As AppBuilder
        Return AppBuilder.Configure(Of App)()
    End Function
End Module
