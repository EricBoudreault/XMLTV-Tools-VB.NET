Imports System.IO
Imports System.Reflection

''' <summary>
''' Programme principal
''' </summary>
''' <remarks>
''' </remarks>
Public NotInheritable Class Main

    Public Shared Sub Main()
        Try
            Dim arguments = Environment.GetCommandLineArgs

            Publics.Folder = Path.GetDirectoryName(New System.Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath)
            Publics.Source = arguments(1)
            Publics.Destination = arguments(2)

            ' Récupérer le contenu des fichiers sources
            Dim contentSource = My.Computer.FileSystem.ReadAllText(Publics.Source)

            ' Écrire un XML formatté
            Tools.SavePrettyXML(contentSource, Publics.Destination)

            Console.WriteLine()
            Console.WriteLine("File formatted successfully!")
            Console.WriteLine()

        Catch ex As Exception
            Console.WriteLine()
            Console.WriteLine("Main Error: " & ex.Message)
            Console.WriteLine()

            Call Tools.WriteToLog("Main Error: " & ex.Message)
        End Try
    End Sub

End Class
