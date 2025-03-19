'Jason Permann
'Spring 2025
'RCET2265
'ConsoleFileIO
'

Option Compare Text
Option Strict On
Option Explicit On
Module ConsoleFileIO

    Sub Main()
        WriteFile()
        AppendToFile()
        ReadFromFile()
    End Sub

    Sub WriteFile()

        FileOpen(1, "MyCoolFile.text", OpenMode.Output)
        Write(1, "Wake up Neo...")
        FileClose(1)

    End Sub

    Sub AppendToFile()
        FileOpen(1, "MyCoolFile.text", OpenMode.Append)
        For i = 1 To 10
            Write(1, "Follow The White Rabbit...")
        Next
        FileClose(1)
    End Sub

    Sub ReadFromFile()
        Dim currentRecord As String
        Try
            FileOpen(1, "MyCoolFile.text", OpenMode.Input)
            Do Until EOF(1) 'EOF() returns true when there are no more records to read
                Input(1, currentRecord)
                Console.WriteLine(currentRecord)
            Loop
            FileClose(1)
        Catch ex As Exception
            MsgBox("No file of that name")
        End Try
    End Sub

End Module
