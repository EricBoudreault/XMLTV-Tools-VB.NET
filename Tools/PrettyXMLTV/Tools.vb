Imports System.IO

Public NotInheritable Class Tools

    ''' <summary>
    ''' Formatter, indenter et enregistrer un fichier XML
    ''' </summary>
    ''' <param name="XMLString"></param>
    ''' <param name="fileName"></param>
    Public Shared Sub SavePrettyXML(ByRef XMLString As String, ByVal fileName As String)
        Try
            Dim sw As New StringWriter()
            Dim xw As New XmlTextWriter(sw)

            xw.Formatting = Formatting.Indented
            xw.Indentation = 4

            Dim doc As New XmlDocument

            doc.LoadXml(XMLString)
            doc.Save(fileName)

        Catch ex As Exception
            Call Tools.WriteToLog("SavePrettyXML Error: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Écrire au journal
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="writeDate"></param>
    ''' <remarks></remarks>
    Public Shared Sub WriteToLog(ByVal message As String, Optional writeDate As Boolean = False)
        Try
            Dim path = My.Computer.FileSystem.CombinePath(Publics.Folder, Publics.LogFileName)

            Using file = My.Computer.FileSystem.OpenTextFileWriter(path, True)
                If writeDate Then
                    file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & message)
                Else
                    file.WriteLine(message)
                End If
            End Using

        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

End Class
