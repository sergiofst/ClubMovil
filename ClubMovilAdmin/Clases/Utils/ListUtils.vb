Public Class ListUtils

    Public Shared Sub Swap(Of T)(ByVal values As List(Of T), ByVal firstIndex As Integer, ByVal secondIndex As Integer)
        If values Is Nothing Then
            Throw New ArgumentNullException("values")
        End If
        If firstIndex < 0 And firstIndex >= values.Count Then
            Throw New ArgumentOutOfRangeException("firstIndex")
        End If
        If secondIndex < 0 And secondIndex >= values.Count Then
            Throw New ArgumentOutOfRangeException("secondIndex")
        End If

        Dim tmp As T = values(firstIndex)
        values(firstIndex) = values(secondIndex)
        values(secondIndex) = tmp
    End Sub
    Public Shared Sub MoveUp(Of T)(ByVal values As List(Of T), ByVal index As Integer)
        If values Is Nothing Then
            Throw New ArgumentNullException("values")
        End If
        If index < 1 And index >= values.Count Then
            Throw New ArgumentOutOfRangeException("index")
        End If
        Dim tmp As T = values(index)
        values(index) = values(index - 1)
        values(index - 1) = tmp
    End Sub
    Public Shared Sub MoveDown(Of T)(ByVal values As List(Of T), ByVal index As Integer)
        If values Is Nothing Then
            Throw New ArgumentNullException("values")
        End If
        If index < 0 And index >= values.Count Then
            Throw New ArgumentOutOfRangeException("index")
        End If
        Dim tmp As T = values(index)
        values(index) = values(index + 1)
        values(index + 1) = tmp
    End Sub

End Class
