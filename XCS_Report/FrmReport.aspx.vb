Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Newtonsoft.Json

Public Class FrmReport
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethod()> _
    Public Shared Function getDLLLegislation() As List(Of ListItem)
        Dim lsList = New List(Of ListItem)
        Dim dt As DataTable

        dt = New SC_Legislation().getDDL_Legislation().Tables(0)

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim ls As New ListItem
                ls.Value = row("ID")
                ls.Text = row("LEGISLATION_NAME")

                lsList.Add(ls)
            Next
        End If

        Return lsList
    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function getDLLDutyGroup(ByVal groupID As String) As List(Of ListItem)
        Dim lsList = New List(Of ListItem)
        Dim dt As DataTable

        dt = New SC_Legislation().getDDL_DutyGroup(groupID).Tables(0)

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim ls As New ListItem
                ls.Value = row("GROUP_ID")
                ls.Text = row("GROUP_NAME")

                lsList.Add(ls)
            Next
        End If

        Return lsList
    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function getDLLProvince() As List(Of ListItem)
        Dim lsList = New List(Of ListItem)
        Dim dt As DataTable

        dt = New SC_Legislation().getDLL_Province().Tables(0)

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim ls As New ListItem
                ls.Value = row("PROVINCE_CODE")
                ls.Text = row("PROVINCE_NAME")

                lsList.Add(ls)
            Next
        End If

        Return lsList
    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function getDLLDistrict(ByVal province_code As String) As List(Of ListItem)
        Dim lsList = New List(Of ListItem)
        Dim dt As DataTable

        dt = New SC_Legislation().getDDL_District(province_code).Tables(0)

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim ls As New ListItem
                ls.Value = row("DISTRICT_CODE")
                ls.Text = row("DISTRICT_NAME")

                lsList.Add(ls)
            Next
        End If

        Return lsList
    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function getDLLSubDistrict(ByVal district_code As String) As List(Of ListItem)
        Dim lsList = New List(Of ListItem)
        Dim dt As DataTable

        dt = New SC_Legislation().getDDL_SubDistrict(district_code).Tables(0)

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim ls As New ListItem
                ls.Value = row("SUBDISTRICT_CODE")
                ls.Text = row("SUBDISTRICT_NAME")

                lsList.Add(ls)
            Next
        End If

        Return lsList
    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function getDLLOffCode1(ByVal indc_off As String, ByVal suboffcode As String) As List(Of ListItem)
        Dim lsList = New List(Of ListItem)
        Dim dt As DataTable

        dt = New SC_Legislation().getDLL_OffCode1(indc_off, suboffcode).Tables(0)

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim ls As New ListItem
                ls.Value = row("OFFCODE")
                ls.Text = row("OFFNAME")

                lsList.Add(ls)
            Next
        End If

        Return lsList
    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function getDepartment(ByVal offCode As String, ByVal offName As String, ByVal curepage As Integer, ByVal pagesize As Integer) As String
        Dim strResult As String
        Dim ds As New DataSet

        ds = New SC_Legislation().getDepartment(offCode, offName, curepage, pagesize)

        strResult = JsonConvert.SerializeObject(ds, Formatting.Indented)

        Return strResult
    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function CountDepartment(ByVal offCode As String, ByVal offName As String) As Integer
        Dim rowcount As Integer = 0
        rowcount = New SC_Legislation().CountDepartment(offCode, offName)

        Return rowcount
    End Function
End Class
