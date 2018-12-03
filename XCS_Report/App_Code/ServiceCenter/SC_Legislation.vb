Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data
Imports System.Text

Public Class SC_Legislation
    Function getDDL_Legislation() As DataSet
        Dim ds = New DataSet()
        Dim sb As New StringBuilder()

        sb.AppendLine("SELECT ID,LEGISLATION_NAME FROM LEGISLATION WHERE ID = '4'")

        Dim objdb = New UtillDB()
        objdb.setConnection()

        Return objdb.QueryDataSet(sb.ToString())
    End Function

    Function getDDL_DutyGroup(ByVal groupID As String) As DataSet
        Dim ds = New DataSet
        Dim sb As New StringBuilder()

        sb.AppendLine("SELECT DUTY_GROUP.GROUP_ID, DUTY_GROUP.GROUP_NAME")
        sb.AppendLine("FROM PRODUCT_LEGISLATION")
        sb.AppendLine("INNER JOIN DUTY_GROUP ON PRODUCT_LEGISLATION.GROUP_ID = DUTY_GROUP.GROUP_ID")
        sb.AppendLine("WHERE PRODUCT_LEGISLATION.LEGISLATION_ID = '" & groupID & "'")
        sb.AppendLine("AND DUTY_GROUP.GROUP_STATUS = 'N'")

        Dim objdb = New UtillDB()
        objdb.setConnection()

        Return objdb.QueryDataSet(sb.ToString())
    End Function

    Function getDLL_Province() As DataSet
        Dim ds = New DataSet
        Dim sb As New StringBuilder()

        sb.AppendLine("SELECT PROVINCE_CODE,PROVINCE_NAME FROM PROVINCE")

        Dim objdb = New UtillDB()
        objdb.setConnection()

        Return objdb.QueryDataSet(sb.ToString())
    End Function

    Function getDDL_District(ByVal province_code As String) As DataSet
        Dim ds = New DataSet
        Dim sb As New StringBuilder()

        sb.AppendLine("SELECT DISTRICT.DISTRICT_CODE, DISTRICT.DISTRICT_NAME")
        sb.AppendLine("FROM DISTRICT")
        sb.AppendLine("INNER JOIN PROVINCE ON DISTRICT.PROVINCE_CODE = PROVINCE.PROVINCE_CODE")
        sb.AppendLine("WHERE PROVINCE.PROVINCE_CODE = '" & province_code & "'")

        Dim objdb = New UtillDB()
        objdb.setConnection()

        Return objdb.QueryDataSet(sb.ToString())
    End Function

    Function getDDL_SubDistrict(ByVal district_code As String) As DataSet
        Dim ds = New DataSet
        Dim sb As New StringBuilder()

        sb.AppendLine("SELECT SUBDISTRICT.SUBDISTRICT_CODE, SUBDISTRICT.SUBDISTRICT_NAME")
        sb.AppendLine("FROM SUBDISTRICT")
        sb.AppendLine("INNER JOIN DISTRICT ON SUBDISTRICT.DISTRICT_CODE = DISTRICT.DISTRICT_CODE")
        sb.AppendLine("WHERE DISTRICT.DISTRICT_CODE = '" & district_code & "'")

        Dim objdb = New UtillDB()
        objdb.setConnection()

        Return objdb.QueryDataSet(sb.ToString())
    End Function

    Function getDepartment(ByVal offCode As String, ByVal offName As String, ByVal curepage As Integer, ByVal pagesize As Integer) As DataSet
        Dim ds = New DataSet
        Dim sb As New StringBuilder()

        sb.AppendLine("SELECT OFFCODE, OFFNAME ")
        sb.AppendLine("FROM (")
        sb.AppendLine("     SELECT OFFCODE, OFFNAME ,")
        sb.AppendLine("     row_number() over (ORDER BY OFFCODE ASC) line_number")
        sb.AppendLine("     FROM ED_OFFICE")
        sb.AppendLine("     WHERE OFFCODE LIKE '%" & offCode & "%' AND OFFNAME LIKE '%" & offName & "%'")
        sb.AppendLine("     ) WHERE line_number BETWEEN " & (((curepage - 1) * pagesize) + 1) & " AND " & (curepage * pagesize) & "  ORDER BY line_number")

        Dim objdb = New UtillDB()
        objdb.setConnection()

        Return objdb.QueryDataSet(sb.ToString())
    End Function

    Function CountDepartment(ByVal offCode As String, ByVal offName As String) As Integer
        Dim ds = New DataSet
        Dim sb As New StringBuilder()

        sb.AppendLine("SELECT COUNT(*) ")
        sb.AppendLine("FROM ED_OFFICE")
        sb.AppendLine("WHERE OFFCODE LIKE '%" & offCode & "%' AND OFFNAME LIKE '%" & offName & "%'")

        Dim objdb = New UtillDB()
        objdb.setConnection()

        Try
            Return Integer.Parse(objdb.QueryDataOneValue(sb.ToString()))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Function getDLL_OffCode1(ByVal indc_off As String, ByVal suboffcode As String) As DataSet
        Dim ds = New DataSet
        Dim sb As New StringBuilder()

        sb.AppendLine("SELECT OFFCODE, OFFNAME, SUPOFFCODE")
        sb.AppendLine("FROM ED_OFFICE")
        sb.AppendLine("WHERE INDC_OFF = '" & indc_off & "'")

        If suboffcode = "" Then
            sb.AppendLine("AND SUPOFFCODE IS NULL")
        Else
            sb.AppendLine("AND SUPOFFCODE = '" & suboffcode & "'")
        End If

        sb.AppendLine("ORDER BY OFFCODE")


        Dim objdb = New UtillDB()
        objdb.setConnection()

        Return objdb.QueryDataSet(sb.ToString())
    End Function
End Class
