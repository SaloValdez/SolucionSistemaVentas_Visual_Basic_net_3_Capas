Imports System.Data.SqlClient

Public Class ClsArea
    '--------------------------------------------LISTAR-------------------------------------------
    Function Fun_Listar_Area() As DataSet
        Dim ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = objcadenaconexion.conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.StoredProcedure
                    ocmd.CommandText = "sp_lista_area"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
    '---------------------------------------------INSERTAR-----------------------------------------------
    Public Function fun_insertar_Area(ByVal NombreArea As String) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Dim objcadenaconexion As New BCventas.ClsConexion
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = objcadenaconexion.conexion
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_insertar_area"
                    oCmd.Parameters.Add("@NombreArea", SqlDbType.VarChar).Value = NombreArea
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '------------------------------------------------ACTUALIZAR-----------------------------------------
    Public Function fun_actualizar_Area(ByVal NombreArea As String, ByVal IdArea As Integer) As String
        Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = lobjExecute.conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.CommandText = "sp_actualizar_area"
                        oCmd.Parameters.Add("@NombreArea", SqlDbType.VarChar).Value = NombreArea
                        oCmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = idArea
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        fun_actualizar_Area = 1
                    End Using
                End Using
            End Using
        Catch
            fun_actualizar_Area = 0
        Finally
            lobjExecute = Nothing
        End Try
    End Function
    '---------------------------------------ELIMINAR----------------------------------------------------
    Public Function fun_eliminar_area(ByVal IdArea As String) As Integer
        Dim iRet As Integer
        Dim lobjExecute As New BCventas.ClsConexion
        Dim Ds As New DataSet
        Dim objcadenaconexion As New ClsConexion
        Using oCn As New SqlClient.SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = lobjExecute.conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.CommandText = "sp_eliminar_area"
                    oCmd.Parameters.Add("@idarea", SqlDbType.Int).Value = IdArea
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  COMBO AREA ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Function Fun_Combo_Area() As DataSet
        Dim ds As New DataSet
        Dim objconexion As New ClsConexion
        Using cn As New SqlConnection
            Using da As New SqlDataAdapter
                Using cmd As New SqlCommand
                    cn.ConnectionString = objconexion.conexion
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "sp_combo_area"
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


