
Imports System.Data.SqlClient


Public Class ClsLogin
    Public Function login(ByVal usuario As String, ByVal contrasena As String) As DataSet
        Dim ds As New DataSet
        Dim obj As New ClsConexion
        Using cn As New SqlConnection
            Using cmd As New SqlCommand
                Using da As New SqlDataAdapter
                    cn.ConnectionString = obj.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_login_usuario"
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario
                    cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = contrasena
                    da.SelectCommand = cmd
                    cn.Open()
                    da.Fill(ds)
                    cn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function

End Class
