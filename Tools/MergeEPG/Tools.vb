Public NotInheritable Class Tools

    ''' <summary>
    ''' Obtenir la chaîne située entre deux chaînes de caractères
    ''' </summary>
    ''' <param name="expression"></param>
    ''' <param name="firstString"></param>
    ''' <param name="lastString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Between(ByVal expression As String, ByVal firstString As String, ByVal lastString As String) As String
        Dim finalString As String

        Try
            Dim pos1 = expression.IndexOf(firstString) + firstString.Length
            Dim pos2 = expression.IndexOf(lastString, pos1)

            finalString = expression.Substring(pos1, pos2 - pos1)

            If finalString.Length <= 0 Then
                finalString = String.Empty
            End If

            Return finalString

        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="expression"></param>
    ''' <param name="firstString"></param>
    ''' <param name="lastString"></param>
    ''' <param name="occurence"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Between(ByVal expression As String, ByVal firstString As String, ByVal lastString As String, ByVal occurence As Integer) As String
        Dim finalString = String.Empty

        Try
            If occurence > 0 Then
                Dim pos1 = 0
                Dim pos2 = 0

                For x = 1 To occurence
                    pos1 = expression.IndexOf(firstString, pos1) + firstString.Length

                    If pos1 < firstString.Length Then
                        Exit For
                    End If
                Next

                If pos1 < firstString.Length Then
                    finalString = String.Empty
                Else
                    pos2 = expression.IndexOf(lastString, pos1)

                    finalString = expression.Substring(pos1, pos2 - pos1)

                    If finalString.Length <= 0 Then
                        finalString = String.Empty
                    End If
                End If
            End If

            Return finalString

        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Obtenir la chaîne située entre deux chaînes de caractères (insensible à la case)
    ''' </summary>
    ''' <param name="expression"></param>
    ''' <param name="firstString"></param>
    ''' <param name="lastString"></param>
    ''' <param name="comparison"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Between(ByVal expression As String, ByVal firstString As String, ByVal lastString As String, ByVal comparison As StringComparison) As String
        Dim finalString As String

        Try
            Dim pos1 = expression.IndexOf(firstString, comparison) + firstString.Length
            Dim pos2 = expression.IndexOf(lastString, pos1, comparison)

            finalString = expression.Substring(pos1, pos2 - pos1)

            If finalString.Length <= 0 Then
                finalString = String.Empty
            End If

            Return finalString

        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Obtenir la chaîne située entre deux chaînes de caractères (insensible à la case)
    ''' </summary>
    ''' <param name="expression"></param>
    ''' <param name="firstString"></param>
    ''' <param name="lastString"></param>
    ''' <param name="comparison"></param>
    ''' <param name="occurence"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Between(ByVal expression As String, ByVal firstString As String, ByVal lastString As String, ByVal comparison As StringComparison, ByVal occurence As Integer) As String
        Dim finalString = String.Empty

        Try
            If occurence > 0 Then
                Dim pos1 = 0
                Dim pos2 = 0

                For x = 1 To occurence
                    pos1 = expression.IndexOf(firstString, pos1, comparison) + firstString.Length

                    If pos1 < firstString.Length Then
                        Exit For
                    End If
                Next

                If pos1 < firstString.Length Then
                    finalString = String.Empty
                Else
                    pos2 = expression.IndexOf(lastString, pos1, comparison)

                    finalString = expression.Substring(pos1, pos2 - pos1)

                    If finalString.Length <= 0 Then
                        finalString = String.Empty
                    End If
                End If
            End If

            Return finalString

        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

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

