Imports Microsoft.VisualBasic
Imports System.Data.OracleClient
Imports System.Web
Imports System.Data

Public Class UtillDB
    Dim strConnString As String = ""
    Dim objConn As OracleConnection
    Dim objCmd As OracleCommand
    Dim Trans As OracleTransaction

    Sub setConnection()
        'strConnString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & ConfigurationManager.AppSettings("db_HOST").ToString()
        'strConnString &= ")(PORT=" & ConfigurationManager.AppSettings("db_port").ToString()
        'strConnString &= ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & ConfigurationManager.AppSettings("db_ServiceName").ToString()
        'strConnString &= ")));User Id=" & ConfigurationManager.AppSettings("db_user").ToString()
        'strConnString &= ";Password=" & ConfigurationManager.AppSettings("db_pass").ToString() & ";"

        strConnString = "Data Source=" & ConfigurationManager.AppSettings("tnsReport").ToString()
        strConnString &= ";User ID=" & ConfigurationManager.AppSettings("db_user").ToString()
        strConnString &= ";Password=" & ConfigurationManager.AppSettings("db_pass").ToString()
        strConnString &= ";"
    End Sub

    Function QueryDataSet(ByVal strSQL As String) As DataSet
        Dim ds = New DataSet
        Dim dtAdapter As New OracleDataAdapter

        objConn = New OracleConnection

        Try
            objConn.ConnectionString = strConnString
            objConn.Open()

            objCmd = New OracleCommand

            objCmd.Connection = objConn
            objCmd.CommandText = strSQL
            objCmd.CommandType = CommandType.Text

            dtAdapter.SelectCommand = objCmd
            dtAdapter.Fill(ds)
            objConn.Close()
            objConn.Dispose()
        Catch ex As Exception
            objConn.Close()
            objConn.Dispose()
        End Try

        Return ds
    End Function

    Function QueryDataOneValue(ByVal strSQL As String) As String
        Dim Reader As String = ""

        objConn = New OracleConnection

        Try
            objConn.ConnectionString = strConnString
            objConn.Open()

            objCmd = New OracleCommand(strSQL, objConn)
            Reader = objCmd.ExecuteScalar().ToString()

            objConn.Close()
            objConn.Dispose()
        Catch ex As Exception
            objConn.Close()
            objConn.Dispose()
        End Try

        Return Reader
    End Function

    Function QueryExecuteNonQuery(ByVal strSQL As String) As Boolean
        objConn = New OracleConnection

        Try
            objConn.ConnectionString = strConnString
            objConn.Open()

            objCmd = New OracleCommand

            objCmd.Connection = objConn
            objCmd.CommandText = strSQL
            objCmd.CommandType = CommandType.Text

            objCmd.ExecuteNonQuery()
            objConn.Close()
            objConn.Dispose()

            Return True
        Catch ex As Exception
            objConn.Close()
            objConn.Dispose()

            Return False
        End Try
    End Function

    Sub TransStart()
        objConn = New OracleConnection

        Try
            objConn.ConnectionString = strConnString
            objConn.Open()
        Catch ex As Exception

        End Try

        Trans = objConn.BeginTransaction(IsolationLevel.ReadCommitted)
    End Sub

    Sub TranExecute(ByVal strSQL)
        objCmd = New OracleCommand

        objCmd.Connection = objConn
        objCmd.Transaction = Trans
        objCmd.CommandType = CommandType.Text
        objCmd.CommandText = strSQL

        objCmd.ExecuteNonQuery()
    End Sub

    Sub TransRollBack()
        Trans.Rollback()
    End Sub

    Sub TransCommit()
        Trans.Commit()
    End Sub

    Sub Close()
        objConn.Close()
        objConn.Dispose()
    End Sub
End Class
