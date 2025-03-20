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
        'WriteFile()
        'AppendToFile()
        'ReadFromFile()
        DocExample()
        ReadAllRecords()
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

    Sub DocExample()
        ' Open file for output.
        FileOpen(1, "TestFile.txt", OpenMode.Output)
        ' Print text to the file. The quotation marks will be in the display.
        Write(1, "This is a test.")
        ' Go to the next line.
        WriteLine(1)
        ' Skip a line.
        WriteLine(1)
        ' Print in two print zones. You will see commas and quotation marks
        ' in the output file.
        WriteLine(1, "Zone 1", SPC(10), "Zone 2")
        ' Build a longer string before calling WriteLine.
        WriteLine(1, "Hello" & "  " & "World")
        ' Include five leading spaces.
        WriteLine(1, SPC(5), "Leading spaces")
        ' Print a word starting at column 10.
        WriteLine(1, TAB(10), "Hello")

        ' Assign Boolean and Date values.
        Dim aBool As Boolean
        Dim aDate As DateTime
        aBool = False
        aDate = DateTime.Parse("February 12, 1969")

        ' Dates and Booleans are translated using locale settings of 
        ' your system.
        WriteLine(1, aBool & " is a Boolean value.")
        WriteLine(1, aDate & " is a date.")
        ' Close the file.
        FileClose(1)

        ' Contents of TestFile.txt
        '"This is a test.",
        '
        '"Zone 1",          "Zone 2"
        '"Hello  World"
        '     "Leading spaces"
        '         ,"Hello"
        '"False is a Boolean value."
        '"2/12/1969 is a date."
    End Sub

    Sub ReadAllRecords()
        Dim record As String
        Dim count As Integer
        Try
            FileOpen(1, "TestFile.txt", OpenMode.Input)
            Do Until EOF(1)
                count += 1
                Input(1, record)
                Console.WriteLine($"Record {count}: {record}")
            Loop
            FileClose(1)
        Catch ex As Exception
            MsgBox("File Not Found")
        End Try
    End Sub

End Module
