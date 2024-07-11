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

            If arguments.Length = 4 Then
                Publics.Folder = Path.GetDirectoryName(New System.Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath)
                Publics.Source1 = arguments(1)
                Publics.Source2 = arguments(2)
                Publics.Destination = arguments(3)

                Console.WriteLine()
                Console.WriteLine()
                Console.WriteLine()
                Console.WriteLine("Getting the content...")
                Console.WriteLine()

                ' Récupérer le contenu des fichiers sources
                Dim content1 = My.Computer.FileSystem.ReadAllText(Publics.Source1)
                Dim content2 = My.Computer.FileSystem.ReadAllText(Publics.Source2)

                Console.WriteLine()
                Console.WriteLine("Getting the CHANNEL section...")

                ' Récupérer les sections « Channel » des guides EPG
                Dim channelSection1 = "  <channel id=" & Tools.Between(content1, "<channel id=", "<programme")
                Dim channelSection2 = "<channel id=" & Tools.Between(content2, "<channel id=", "<programme")

                Console.WriteLine("Getting the PROGRAMME section...")
                Console.WriteLine()

                ' Récupérer les sections « Programme » des guides EPG
                Dim programmeSection1 = "<programme" & Tools.Between(content1, "<programme", "</tv>")
                Dim programmeSection2 = "<programme" & Tools.Between(content2, "<programme", "</tv>")

                Console.WriteLine("Building the new EPG Guide...")
                Console.WriteLine()

                Dim beginSection = "<?xml version=""1.0"" encoding=""UTF-8""?><!DOCTYPE tv SYSTEM ""xmltv.dtd""><tv generator-info-name="""">"
                Dim endSection = "</tv>" & Convert.ToChar(13)

                ' Joindre les fichiers sources
                Dim content = String.Format("{0}{1}{2}{3}{4}{5}{6}", beginSection, Convert.ToChar(13), channelSection1, channelSection2, programmeSection1, programmeSection2, endSection)

                content = content.Replace(Convert.ToChar(9), "  ")

                Console.WriteLine("Saving the EPG Guide...")
                Console.WriteLine()

                ' Générer le fichier EPG
                My.Computer.FileSystem.WriteAllText(Publics.Destination, content, False)

                Console.WriteLine()
                Console.WriteLine("EPG Guides merged successfully!")
                Console.WriteLine()
            Else
                Console.WriteLine("Error: Missing argument!")
            End If

        Catch ex As Exception
            Call Tools.WriteToLog("Main Error: " & ex.Message)
        End Try
    End Sub

End Class
