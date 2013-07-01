Imports System.Data.Common
Imports System.Text

Public Class ContenidoDAO
    Inherits BaseDAO

    Public Function ListContenido() As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenido, tipoContenido, Nombre, Descripcion, Imagen, Orden, Visible, Estatus FROM Contenido WHERE Estatus=@Estatus AND Visible=@Visible")
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        AddInParameter(cmd, "@Visible", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function ListContenidoByCategoria(ByVal idCategoria As Integer) As DataSet
        Dim query As StringBuilder = New StringBuilder
        With query
            .Append("SELECT A.IdContenido, A.tipoContenido, A.Nombre, A.Descripcion, A.Imagen, A.Orden, A.Visible, B.IdCategoria ")
            .Append("FROM Contenido AS A INNER JOIN ContenidoCategoria AS B ON (A.IdContenido=B.IdContenido) ")
            .Append("WHERE B.IdCategoria=@IdCategoria AND A.Estatus=@Estatus AND B.Estatus=@Estatus ")
        End With
        Dim cmd As DbCommand = GetSqlStringCommand(query.ToString)
        AddInParameter(cmd, "@IdCategoria", DbType.Int32, idCategoria)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function GetContenido(ByVal idContenido As Integer) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenido, tipoContenido, Nombre, Descripcion, Imagen, Orden, Visible, Estatus FROM Contenido WHERE IdContenido=@IdContenido")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function GetCategoria(ByVal idCategoria As Integer) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdCategoria, Nombre, Descripcion, IdCategoriaPadre, Orden, Estatus FROM Categoria WHERE IdCategoria = @IdCategoria")
        AddInParameter(cmd, "@IdCategoria", DbType.Int32, idCategoria)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function ListCategoriasByPadre(ByVal idCategoriaPadre As Integer) As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdCategoria, Nombre, Descripcion, IdCategoriaPadre, Orden, Estatus FROM Categoria WHERE IdCategoriaPadre = @IdCategoriaPadre")
        AddInParameter(cmd, "@IdCategoriaPadre", DbType.Int32, idCategoriaPadre)
        Return ExecuteDataSet(cmd)
    End Function

    'Public Function GetTipoContenido(ByVal idTipoContenido As Integer) As DataRow
    '    Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdTipoContenido,Nombre,Creditos,SRSRatingId,Estatus FROM TipoContenido WHERE IdTipoContenido=@IdTipoContenido")
    '    AddInParameter(cmd, "@IdTipoContenido", DbType.Int32, idTipoContenido)
    '    Return ExecuteDataRow(cmd)
    'End Function

    Public Function ListCategorias() As DataSet
        Dim query As StringBuilder = New StringBuilder
        With query
            .Append("SELECT A.IdCategoria, A.Nombre, A.Descripcion, A.IdCategoriaPadre, A.Orden, B.Nombre AS CategoriaPadre ")
            .Append("FROM Categoria AS A LEFT JOIN Categoria AS B ON (A.IdCategoriaPadre=B.IdCategoria) ")
        End With
        Dim cmd As DbCommand = GetSqlStringCommand(query.ToString())
        Return ExecuteDataSet(cmd)
    End Function

    Public Function DelCategoria(ByVal idCategoria As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE Categoria SET Estatus=@Estatus WHERE IdCategoria=@IdCategoria")
        AddInParameter(cmd, "@IdCategoria", DbType.Int32, idCategoria)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function UpdCategoria(ByVal nombre As String, ByVal descripcion As String, ByVal idCategoriaPadre As Integer, ByVal idCategoria As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE Categoria SET Nombre=@Nombre, Descripcion=@Descripcion, IdCategoriaPadre=@IdCategoriaPadre WHERE IdCategoria=@IdCategoria")
        AddInParameter(cmd, "@IdCategoria", DbType.Int32, idCategoria)
        AddInParameter(cmd, "@Nombre", DbType.String, nombre)
        AddInParameter(cmd, "@Descripcion", DbType.String, descripcion)
        AddInParameter(cmd, "@IdCategoriaPadre", DbType.Int32, idCategoriaPadre)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function AddCategoria(ByVal nombre As String, ByVal descripcion As String, ByVal idCategoriaPadre As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT INTO Categoria (Nombre,Descripcion,IdCategoriaPadre,Estatus) VALUES (@Nombre,@Descripcion,@IdCategoriaPadre,@Estatus)")
        AddInParameter(cmd, "@Nombre", DbType.String, nombre)
        AddInParameter(cmd, "@Descripcion", DbType.String, descripcion)
        AddInParameter(cmd, "@IdCategoriaPadre", DbType.Int32, idCategoriaPadre)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function AddContenido(ByVal tipoCont As TipoContenido, ByVal nombre As String, ByVal descripcion As String, ByVal imagen As String, ByVal orden As Integer, ByVal visible As Boolean) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT INTO Contenido (TipoContenido,Nombre,Descripcion,Imagen,Orden,Visible,Estatus) VALUES (@TipoContenido,@Nombre,@Descripcion,@Imagen,@Orden,@Visible,@Estatus)")
        AddInParameter(cmd, "@TipoContenido", DbType.Int32, CInt(tipoCont))
        AddInParameter(cmd, "@Nombre", DbType.String, nombre)
        AddInParameter(cmd, "@Descripcion", DbType.String, descripcion)
        AddInParameter(cmd, "@Imagen", DbType.String, imagen)
        AddInParameter(cmd, "@Orden", DbType.Int32, orden)
        AddInParameter(cmd, "@Visible", DbType.Boolean, visible)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function UpdContenido(ByVal tipoCont As TipoContenido, ByVal nombre As String, ByVal descripcion As String, ByVal imagen As String, ByVal orden As Integer, ByVal visible As Boolean, ByVal idContenido As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE Contenido TipoContenido=@TipoContenido,Nombre=@Nombre,Descripcion=@Descripcion,Orden=@Orden,Visible=@Visible WHERE IdContenido=@IdContenido")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@TipoContenido", DbType.Int32, CInt(tipoCont))
        AddInParameter(cmd, "@Nombre", DbType.String, nombre)
        AddInParameter(cmd, "@Descripcion", DbType.String, descripcion)
        AddInParameter(cmd, "@Imagen", DbType.String, imagen)
        AddInParameter(cmd, "@Orden", DbType.Int32, orden)
        AddInParameter(cmd, "@Visible", DbType.Boolean, visible)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function DelContenido(ByVal idContenido As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UDPATE Contenido SET Estatus@Estatus WHERE IdContenido=@IdContenido")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    'Public Function ListTipoContenido() As DataSet
    '    Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdTipoContenido,Nombre,Descripcion,Imagen,Orden,Visible FROM TipoContenido WHERE Estatus=@Estatus")
    '    AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
    '    Return ExecuteDataSet(cmd)
    'End Function

    Public Function ListContenidoClaves(ByVal idContenido As Integer) As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenidoClave,IdContenido,Clave FROM ContenidoClave WHERE IdContenido=@IdContenido AND Estatus=@Estatus")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function AddContenidoClave(ByVal idContenido As Integer, ByVal clave As String) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT INTO ContenidoClave (IdContenido,Clave,Estatus) VALUES (@IdContenido,@Clave,@Estatus)")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Clave", DbType.String, clave)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function DelContenidoClave(ByVal idContenidoClave As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE ContenidoClave SET Estatus=@Estatus WHERE IdContenidoClave=@IdContenidoClave")
        AddInParameter(cmd, "@IdContenidoClave", DbType.Int32, idContenidoClave)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, False)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function ListContenidoImagenes(ByVal idContenido As Integer) As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenidoImagen,IdContenido,FileName FROM ContenidoImagen WHERE IdContenido=@IdContenido AND Estatus=@Estatus")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function AddContenidoImagen(ByVal idContenido As Integer, ByVal fileName As String) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT INTO ContenidoImagen (IdContenido,FileName,Estatus) VALUES (@IdContenido,@FileName,@Estatus)")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@FileName", DbType.String, fileName)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function DelContenidoImagen(ByVal idContenidoImagen As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE ContenidoImagen SET Estatus=@Estatus WHERE IdContenidoImagen=@IdContenidoImagen")
        AddInParameter(cmd, "@IdContenidoImagen", DbType.Int32, idContenidoImagen)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, False)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function ListContenidoInfo(ByVal idContenido As Integer) As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenidoInfo, IdContenido, Etiqueta, Valor, Visible, Estatus FROM ContenidoInfo WHERE IdContenido=@IdContenido AND Estatus=@Estatus")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function AddContenidoInfo(ByVal idContenido As Integer, ByVal etiqueta As String, ByVal valor As String) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT INTO ContenidoInfo (IdContenido,Etiqueta,Valor,Estatus) VALUES (@IdContenido,@Etiqueta,@Valor,@Estatus)")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Etiqueta", DbType.String, etiqueta)
        AddInParameter(cmd, "@Valor", DbType.String, valor)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function DelContenidoInfo(ByVal idContenidoImagen As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE ContenidoInfo SET Estatus=@Estatus WHERE IdContenidoInfo=@IdContenidoInfo")
        AddInParameter(cmd, "@IdContenidoInfo", DbType.Int32, idContenidoImagen)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, False)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function GetContenidoArchivo(ByVal idContenido As Integer, ByVal grupo As String) As DataRow
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenidoArchivo, IdContenido, Grupo, Archivo, Estatus FROM ContenidoArchivo WHERE IdContenido=@IdContenido AND Grupo=@Grupo AND Estatus=@Estatus")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Grupo", DbType.String, grupo)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataRow(cmd)
    End Function

    Public Function ListContenidoArchivos(ByVal idContenido As Integer) As DataSet
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT IdContenidoArchivo, IdContenido, Grupo, Archivo, Estatus FROM ContenidoArchivo WHERE IdContenido=@IdContenido AND Estatus=@Estatus")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function AddContenidoArchivo(ByVal idContenido As Integer, ByVal grupo As String, ByVal archivo As String) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT INTO ContenidoArchivo (IdContenido, Grupo, Archivo, Estatus) VALUES (@IdContenido,@Grupo,@Archivo,@Estatus)")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Grupo", DbType.String, grupo)
        AddInParameter(cmd, "@Archivo", DbType.String, archivo)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function DelContenidoArchivo(ByVal idContenidoArchivo As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE ContenidoArchivo SET Estatus=@Estatus WHERE IdContenidoArchivo=@IdContenidoArchivo")
        AddInParameter(cmd, "@IdContenidoArchivo", DbType.Int32, idContenidoArchivo)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, False)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function ListContenidoCategorias(ByVal idContenido As Integer) As DataSet
        Dim query As StringBuilder = New StringBuilder
        With query
            .Append("SELECT A.IdContenidoCategoria, A.IdContenido, A.IdCategoria, B.Nombre AS NombreCategoria ")
            .Append("FROM ContenidoCategoria AS A INNER JOIN Categoria AS B ON (A.IdCategoria=B.IdCategoria AND B.Estatus=@Estatus) ")
            .Append("WHERE A.IdContenido=@IdContenido AND A.Estatus=@Estatus")
        End With
        Dim cmd As DbCommand = GetSqlStringCommand(query.ToString())
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteDataSet(cmd)
    End Function

    Public Function AddContenidoCategoria(ByVal idContenido As Integer, ByVal idCategoria As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("INSERT INTO ContenidoCategoria (IdContenido,IdCategoria,Estatus) VALUES (@IdContenido,@IdCategoria,@Estatus)")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@IdCategoria", DbType.Int32, idCategoria)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Return ExecuteNonQueryIdentity(cmd)
    End Function

    Public Function DelContenidoCategoria(ByVal idContenidoCategoria As Integer) As Integer
        Dim cmd As DbCommand = GetSqlStringCommand("UPDATE ContenidoCategoria SET Estatus=@Estatus WHERE IdContenidoCategoria=@IdContenidoCategoria")
        AddInParameter(cmd, "@IdContenidoCategoria", DbType.Int32, idContenidoCategoria)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, False)
        Return CInt(ExecuteNonQuery(cmd))
    End Function

    Public Function ExistContenidoCategoria(ByVal idContenido As Integer, ByVal idCategoria As Integer) As Boolean
        Dim cmd As DbCommand = GetSqlStringCommand("SELECT COUNT(IdContenidoCategoria) AS Count FROM ContenidoCategoria WHERE IdContenido=@IdContenido AND IdCategoria=@IdCategoria AND Estatus=@Estatus")
        AddInParameter(cmd, "@IdContenido", DbType.Int32, idContenido)
        AddInParameter(cmd, "@IdCategoria", DbType.Int32, idCategoria)
        AddInParameter(cmd, "@Estatus", DbType.Boolean, True)
        Dim count As Integer = CInt(ExecuteDataRow(cmd)(0))
        If count = 0 Then
            Return False
        End If
        Return True
    End Function

    Public Enum TipoContenido
        Imagenes = 0
        Tonos = 1
        Videos = 2
    End Enum


End Class
