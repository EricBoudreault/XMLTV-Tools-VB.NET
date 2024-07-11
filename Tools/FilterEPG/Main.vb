Imports System.IO
Imports System.Reflection
Imports Microsoft.VisualBasic

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
            Publics.Filter = arguments(2)
            Publics.Destination = arguments(3)

            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("Getting the content...")
            Console.WriteLine()

            ' Récupérer le contenu des fichiers sources
            Dim contentSource = My.Computer.FileSystem.ReadAllText(Publics.Source)

            Console.WriteLine()
            Console.WriteLine("Filtering...")

            Dim headerSection = Tools.Between(contentSource, "", "<channel", StringComparison.CurrentCultureIgnoreCase)
            Dim mainSection = FilterEPG(contentSource, Publics.Filter)

            If mainSection.EndsWith("</tv>") Then
                contentSource = headerSection & mainSection
            Else
                contentSource = headerSection & mainSection & vbCrLf & "</tv>"
            End If

            ' Écrire un XML formatté
            Tools.SavePrettyXML(contentSource, Publics.Destination)

            Console.WriteLine()
            Console.WriteLine("EPG Guide filtered successfully!")
            Console.WriteLine()

        Catch ex As Exception
            Console.WriteLine()
            Console.WriteLine("Main Error: " & ex.Message)
            Console.WriteLine()

            Call Tools.WriteToLog("Main Error: " & ex.Message)
        End Try
    End Sub

    Private Shared Function GetChannel(ByVal line As String) As String
        Dim templine = line.Replace(" ", String.Empty)
        Dim first = "channel id=" & Convert.ToChar(34)

        first = first.Replace(" ", "")

        Dim channel = Tools.Between(templine, first, Convert.ToChar(34), StringComparison.CurrentCultureIgnoreCase)

        If channel.Length = 0 Then
            first = "channel=" & Convert.ToChar(34)
            first = first.Replace(" ", "")
            channel = Tools.Between(templine, first, Convert.ToChar(34), StringComparison.CurrentCultureIgnoreCase)
        End If

        Return channel
    End Function

    Private Shared Function FilterEPG(ByRef content As String, ByVal filter As String) As String
        Dim newContent As New StringBuilder()
        Dim isChannelInLine = False
        Dim currentChannel As String
        Dim str As String() = content.Split(New [Char]() {Convert.ToChar(13)})

        If str.Length < 3 Then
            str = content.Split(New [Char]() {Convert.ToChar(10)})
        End If

        For Each line In str
            If Not isChannelInLine Then
                currentChannel = GetChannel(line)
                isChannelInLine = (currentChannel.Length > 0 And filter.IndexOf(currentChannel) <> -1)
            End If

            If isChannelInLine Then
                newContent.Append(line)

                If line.IndexOf("</channel>") <> -1 OrElse line.IndexOf("</programme>") <> -1 Then
                    isChannelInLine = False
                End If
            End If
        Next

        Return newContent.ToString.Replace(vbLf, vbCrLf)
    End Function

End Class
