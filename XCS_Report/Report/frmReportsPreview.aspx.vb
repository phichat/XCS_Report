Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Partial Class Report_frmReportsPreview
    Inherits System.Web.UI.Page
    Dim AccidentFrom_date As String
    Dim AccidentTo_date As String
    'Dim OfficeCode As String
    Dim OfficeCode1 As String
    Dim OfficeCode2 As String
    Dim OfficeCode3 As String
    Dim AccuserType As String
    Dim CaseQuality As String
    Dim CaseLast As String
    Dim HaveCulprit As String
    Dim GroupID As String
    Dim DocType As String
    Dim ReportID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            AccidentFrom_date = Request.QueryString("AccidentFrom")
            AccidentTo_date = Request.QueryString("AccidentTo")
            'OfficeCode = Request.QueryString("OfficeCode")
            OfficeCode1 = Request.QueryString("OfficeCode1")

            If Request.QueryString("OfficeCode2") = "null" Then
                OfficeCode2 = ""
            Else
                OfficeCode2 = Request.QueryString("OfficeCode2")
            End If

            If Request.QueryString("OfficeCode3") = "null" Then
                OfficeCode3 = ""
            Else
                OfficeCode3 = Request.QueryString("OfficeCode3")
            End If

            AccuserType = Request.QueryString("accusertype")
            CaseQuality = Request.QueryString("casequality")
            CaseLast = Request.QueryString("caselast")
            HaveCulprit = Request.QueryString("haveculprit")
            GroupID = Request.QueryString("groupid")
            DocType = Request.QueryString("doctype")
            ReportID = Request.QueryString("reportID")

            PrintReport()
        End If
    End Sub

    Sub PrintReport()
        Try
            Dim rpt As New ReportDocument
            Dim tbLogOn As New TableLogOnInfo
            tbLogOn.ConnectionInfo.ServerName = ConfigurationManager.AppSettings("tnsReport").ToString()
            'tbLogOn.ConnectionInfo.DatabaseName = "orcl2"
            tbLogOn.ConnectionInfo.UserID = ConfigurationManager.AppSettings("db_user").ToString()
            tbLogOn.ConnectionInfo.Password = ConfigurationManager.AppSettings("db_pass").ToString()

            If ReportID = "1" Then
                rpt.Load(Server.MapPath("../Report/ILLR8314.rpt"))
            ElseIf ReportID = "2" Then
                rpt.Load(Server.MapPath("../Report/ILLR8301.rpt"))
            ElseIf ReportID = "3" Then
                rpt.Load(Server.MapPath("../Report/ILLR8315.rpt"))
            End If


            rpt.Database.Tables(0).ApplyLogOnInfo(tbLogOn)

            rpt.SetParameterValue("getOffcode1", OfficeCode1)
            rpt.SetParameterValue("getOffcode2", OfficeCode2)
            rpt.SetParameterValue("getOffcode3", OfficeCode3)
            rpt.SetParameterValue("getUserID", ConfigurationManager.AppSettings("UserID").ToString())
            rpt.SetParameterValue("getDatefrom", AccidentFrom_date)
            rpt.SetParameterValue("getDateto", AccidentTo_date)
            rpt.SetParameterValue("getProductGroup", GroupID)
            rpt.SetParameterValue("getAccuserType", AccuserType)
            rpt.SetParameterValue("getHaveCulprit", HaveCulprit)
            rpt.SetParameterValue("getCaseQuality", CaseQuality)
            rpt.SetParameterValue("getCaseLast", CaseLast)

            If DocType = "pdf" Then
                GenReportPDF(rpt)
            Else
                GenReportExcel(rpt)
            End If

        Catch ex As Exception
            HttpContext.Current.Response.Write("<Script>alert('" + ex.Message + "');</Script>")
        End Try
    End Sub

    Sub GenReportPDF(ByVal report As ReportDocument)
        Try
            Dim s As System.IO.Stream = report.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim b(s.Length) As Byte
            s.Read(b, 0, Integer.Parse(s.Length.ToString()))

            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.ClearHeaders()
            HttpContext.Current.Response.ClearContent()
            HttpContext.Current.Response.Buffer = True
            HttpContext.Current.Response.Charset = "UTF-8"
            HttpContext.Current.Response.ContentType = "application/pdf"

            If ReportID = "1" Then
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=ILLR8314.pdf")
            ElseIf ReportID = "2" Then
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=ILLR8301.pdf")
            ElseIf ReportID = "3" Then
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=ILLR8315.pdf")
            End If


            HttpContext.Current.Response.BinaryWrite(b)
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.SuppressContent = True
            HttpContext.Current.ApplicationInstance.CompleteRequest()

            report.Close()
            report.Dispose()
        Catch ex As Exception
            HttpContext.Current.Response.Write("<Script>alert('" + ex.Message + "');</Script>")

            report.Close()
            report.Dispose()
        End Try
    End Sub

    Sub GenReportExcel(ByVal report As ReportDocument)
        Try
            Dim s As System.IO.Stream = report.ExportToStream(ExportFormatType.Excel)
            Dim b(s.Length) As Byte
            s.Read(b, 0, Integer.Parse(s.Length.ToString()))

            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.ClearHeaders()
            HttpContext.Current.Response.ClearContent()
            HttpContext.Current.Response.Buffer = True
            HttpContext.Current.Response.Charset = "UTF-8"
            HttpContext.Current.Response.ContentType = "application/xls"

            If ReportID = "1" Then
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=ILLR8314.xls")
            ElseIf ReportID = "2" Then
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=ILLR8301.xls")
            ElseIf ReportID = "3" Then
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=ILLR8315.xls")
            End If

            HttpContext.Current.Response.BinaryWrite(b)
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.SuppressContent = True
            HttpContext.Current.ApplicationInstance.CompleteRequest()

            report.Close()
            report.Dispose()
        Catch ex As Exception
            HttpContext.Current.Response.Write("<Script>alert('" + ex.Message + "');</Script>")

            report.Close()
            report.Dispose()
        End Try
    End Sub
End Class
