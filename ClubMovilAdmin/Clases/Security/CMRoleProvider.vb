Imports System.Data.Common
Imports ClubMovil.Data

Public Class CMRoleProvider
    Inherits RoleProvider

    Private m_ApplicationName As String

    Public Overrides Sub AddUsersToRoles(ByVal usernames() As String, ByVal roleNames() As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Property ApplicationName() As String
        Get
            Return m_ApplicationName
        End Get
        Set(ByVal value As String)
            m_ApplicationName = value
        End Set
    End Property

    Public Overrides Function GetRolesForUser(ByVal idUsuario As String) As String()
        Dim dsRoles As DataSet = New UsuarioDAO().ListRolesUsuario(Integer.Parse(idUsuario))
        Dim result As IList(Of String) = New List(Of String)
        For Each drRol As DataRow In dsRoles.Tables(0).Rows
            result.Add(CStr(drRol("Rol")))
        Next
        Return result.ToArray
    End Function

    Public Overrides Function IsUserInRole(ByVal idIssuing As String, ByVal roleName As String) As Boolean
        Return New UsuarioDAO().IsUsuarioEnRol(Integer.Parse(idIssuing), roleName)
    End Function

#Region "NotImplemented"
    Public Overrides Sub CreateRole(ByVal roleName As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function DeleteRole(ByVal roleName As String, ByVal throwOnPopulatedRole As Boolean) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function FindUsersInRole(ByVal roleName As String, ByVal usernameToMatch As String) As String()
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetAllRoles() As String()
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetUsersInRole(ByVal roleName As String) As String()
        Throw New NotImplementedException()
    End Function

    Public Overrides Sub RemoveUsersFromRoles(ByVal usernames() As String, ByVal roleNames() As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function RoleExists(ByVal roleName As String) As Boolean
        Throw New NotImplementedException()
    End Function
#End Region

End Class
