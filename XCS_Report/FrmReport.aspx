<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmReport.aspx.vb" Inherits="FrmReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <!-- VENDOR CSS -->
    <link rel="stylesheet" href="assets/vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/vendor/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="assets/vendor/linearicons/style.css">
    <link rel="stylesheet" href="assets/vendor/chartist/css/chartist-custom.css">
    <!-- MAIN CSS -->
    <link rel="stylesheet" href="assets/css/main.css">
    <!-- FOR DEMO PURPOSES ONLY. You should remove this in your project -->
    <link rel="stylesheet" href="assets/css/demo.css">
    <!-- GOOGLE FONTS -->
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700"
        rel="stylesheet">
    <!-- ICONS -->
    <link rel="apple-touch-icon" sizes="76x76" href="assets/img/apple-icon.png">
    <link rel="icon" type="image/png" sizes="96x96" href="assets/img/favicon.png">
    <link href="css/jPaginate.css" rel="stylesheet" />

    <script src="js/jquery-1.11.0.min.js"></script>

    <script src="js/jquery-ui.min.js"></script>

    <!-- Javascript -->

    <script src="assets/vendor/jquery/jquery.min.js"></script>

    <script src="assets/vendor/bootstrap/js/bootstrap.min.js"></script>

    <script src="assets/vendor/jquery-slimscroll/jquery.slimscroll.min.js"></script>

    <script src="assets/scripts/klorofil-common.js"></script>

    <link href="datetimepicker/dist/css/bootstrap-datepicker.css" rel="stylesheet" />

    <script src="datetimepicker/dist/js/bootstrap-datepicker-custom.js"></script>

    <script src="datetimepicker/dist/locales/bootstrap-datepicker.th.min.js" charset="UTF-8"></script>

    <script src="js/alex-date-time.js"></script>

    <!-- My -->
    <link href="css/Style1.css" rel="stylesheet" />

    <script src="js/jsDateTime.js"></script>

    <script src="js/dist/pagination.min.js"></script>

    <script src="js/jsCookie.js"></script>

    <script src="js/jsMaster.js"></script>

    <script src="js/jsDepartment.js"></script>

    <script>
        var currentpage = 0;
        var pagesize = 10;

        $(document).ready(function ($) {
            $('#btnDel').hide();
            setDetectionTime();
            showddlLegislation();
            showddlProvince();
            showddlOffCode1('D','');

            $('#ddlLegislation').on('change', function () {
                showddlDutyGroup($("#ddlLegislation").val());
            })

            $('#ddlProvince').on('change', function () {
                showddlDistrict($("#ddlProvince").val());
            })

            $('#ddlDistrict').on('change', function () {
                showddlSubDistrict($("#ddlDistrict").val());
            })

            $('#ddlOffCode1').on('change', function () {
                showddlOffCode2($("#ddlOffCode1").val());
            })

            $('#ddlOffCode2').on('change', function () {
                showddlOffCode3($("#ddlOffCode2").val());
            })

            $('#SearchDept').click(function () {
                SelectPagingDataNormal();
                ShowDepartment(1);
            });

            $('#btnSearchDept').click(function () {
                SelectPagingDataNormal();
                ShowDepartment(1);
            });

            $('#btnDel').click(function () {
                $("#OfficeCode").val("");
                $("#OfficeName").val("");
                $('#btnDel').hide();
            });

            // ----- รายงานผลงานการจับกุม ------
            $('#btn_pdf').click(function () {
                var parts_from = $("#txtAccidentFrom_date").val().split("/");
                var dt_from = parts_from[2] - 543 + "-" + parts_from[1] + "-" + parts_from[0];

                var parts_to = $("#txtAccidentTo_date").val().split("/");
                var dt_to = parts_to[2] - 543 + "-" + parts_to[1] + "-" + parts_to[0];
                var AccuserType = $("input[name='staff']:checked").val();
                var CaseQuality = $("input[name='quality']:checked").val();
                var CaseLast = $("input[name='caselast']:checked").val();
                var HaveCulprit = "Y";

                if (CaseQuality == "0")
                    HaveCulprit = "N";
                else if (CaseQuality == "")
                 HaveCulprit = "";

                window.open("./Report/frmReportsPreview.aspx?AccidentFrom=" + dt_from + "&AccidentTo=" + dt_to
                 + "&OfficeCode1=" + $("#ddlOffCode1").val()
                 + "&OfficeCode2=" + $("#ddlOffCode2").val()
                 + "&OfficeCode3=" + $("#ddlOffCode3").val()
                 + "&groupid=" + $("#ddlDutyGroup").val()
                 + "&accusertype=" + AccuserType
                 + "&haveculprit=" + HaveCulprit
                 + "&casequality=" + CaseQuality
                 + "&caselast=" + CaseLast
                 + "&doctype=pdf"
                 + "&reportID=1"
                 , "_blank");
            });
            
            $('#btn_excel').click(function () {
                var parts_from = $("#txtAccidentFrom_date").val().split("/");
                var dt_from = parts_from[2] - 543 + "-" + parts_from[1] + "-" + parts_from[0];

                var parts_to = $("#txtAccidentTo_date").val().split("/");
                var dt_to = parts_to[2] - 543 + "-" + parts_to[1] + "-" + parts_to[0];
                var AccuserType = $("input[name='staff']:checked").val();
                var CaseQuality = $("input[name='quality']:checked").val();
                var CaseLast = $("input[name='caselast']:checked").val();
                var HaveCulprit = "Y";

                if (CaseQuality == "0")
                    HaveCulprit = "N";
                else if (CaseQuality == "")
                 HaveCulprit = "";

                window.open("./Report/frmReportsPreview.aspx?AccidentFrom=" + dt_from + "&AccidentTo=" + dt_to
                 + "&OfficeCode1=" + $("#ddlOffCode1").val()
                 + "&OfficeCode2=" + $("#ddlOffCode2").val()
                 + "&OfficeCode3=" + $("#ddlOffCode3").val()
                 + "&groupid=" + $("#ddlDutyGroup").val()
                 + "&accusertype=" + AccuserType
                 + "&haveculprit=" + HaveCulprit
                 + "&casequality=" + CaseQuality
                 + "&caselast=" + CaseLast
                 + "&doctype=excel"
                 + "&reportID=1"
                 , "_blank");
            });
            // ----- END รายงานผลงานการจับกุม ------


            // ----- รายงานผลคดี ส.ส. 2/55 ------
            $('#btn2_pdf').click(function () {
                var parts_from = $("#txtAccidentFrom_date").val().split("/");
                var dt_from = parts_from[2] - 543 + "-" + parts_from[1] + "-" + parts_from[0];

                var parts_to = $("#txtAccidentTo_date").val().split("/");
                var dt_to = parts_to[2] - 543 + "-" + parts_to[1] + "-" + parts_to[0];
                var AccuserType = $("input[name='staff']:checked").val();
                var CaseQuality = $("input[name='quality']:checked").val();
                var CaseLast = $("input[name='caselast']:checked").val();
                var HaveCulprit = "Y";

                if (CaseQuality == "0")
                    HaveCulprit = "N";
                else if (CaseQuality == "")
                 HaveCulprit = "";

                window.open("./Report/frmReportsPreview.aspx?AccidentFrom=" + dt_from + "&AccidentTo=" + dt_to
                 + "&OfficeCode1=" + $("#ddlOffCode1").val()
                 + "&OfficeCode2=" + $("#ddlOffCode2").val()
                 + "&OfficeCode3=" + $("#ddlOffCode3").val()
                 + "&groupid=" + $("#ddlDutyGroup").val()
                 + "&accusertype=" + AccuserType
                 + "&haveculprit=" + HaveCulprit
                 + "&casequality=" + CaseQuality
                 + "&caselast=" + CaseLast
                 + "&doctype=pdf"
                 + "&reportID=2"
                 , "_blank");
            });

            $('#btn2_excel').click(function () {
                var parts_from = $("#txtAccidentFrom_date").val().split("/");
                var dt_from = parts_from[2] - 543 + "-" + parts_from[1] + "-" + parts_from[0];

                var parts_to = $("#txtAccidentTo_date").val().split("/");
                var dt_to = parts_to[2] - 543 + "-" + parts_to[1] + "-" + parts_to[0];
                var AccuserType = $("input[name='staff']:checked").val();
                var CaseQuality = $("input[name='quality']:checked").val();
                var CaseLast = $("input[name='caselast']:checked").val();
                var HaveCulprit = "Y";

                if (CaseQuality == "0")
                    HaveCulprit = "N";
                else if (CaseQuality == "")
                 HaveCulprit = "";

                window.open("./Report/frmReportsPreview.aspx?AccidentFrom=" + dt_from + "&AccidentTo=" + dt_to
                 + "&OfficeCode1=" + $("#ddlOffCode1").val()
                 + "&OfficeCode2=" + $("#ddlOffCode2").val()
                 + "&OfficeCode3=" + $("#ddlOffCode3").val()
                 + "&groupid=" + $("#ddlDutyGroup").val()
                 + "&accusertype=" + AccuserType
                 + "&haveculprit=" + HaveCulprit
                 + "&casequality=" + CaseQuality
                 + "&caselast=" + CaseLast
                 + "&doctype=excel"
                 + "&reportID=2"
                 , "_blank");
            });
            // ----- END รายงานผลคดี ส.ส. 2/55 ------


            // ----- รายงานค่าปรับประมาณการ ------
            $('#btn3_pdf').click(function () {
                var parts_from = $("#txtAccidentFrom_date").val().split("/");
                var dt_from = parts_from[2] - 543 + "-" + parts_from[1] + "-" + parts_from[0];

                var parts_to = $("#txtAccidentTo_date").val().split("/");
                var dt_to = parts_to[2] - 543 + "-" + parts_to[1] + "-" + parts_to[0];
                var AccuserType = $("input[name='staff']:checked").val();
                var CaseQuality = $("input[name='quality']:checked").val();
                var CaseLast = $("input[name='caselast']:checked").val();
                var HaveCulprit = "Y";

                if (CaseQuality == "0")
                    HaveCulprit = "N";
                else if (CaseQuality == "")
                 HaveCulprit = "";

                window.open("./Report/frmReportsPreview.aspx?AccidentFrom=" + dt_from + "&AccidentTo=" + dt_to
                 + "&OfficeCode1=" + $("#ddlOffCode1").val()
                 + "&OfficeCode2=" + $("#ddlOffCode2").val()
                 + "&OfficeCode3=" + $("#ddlOffCode3").val()
                 + "&groupid=" + $("#ddlDutyGroup").val()
                 + "&accusertype=" + AccuserType
                 + "&haveculprit=" + HaveCulprit
                 + "&casequality=" + CaseQuality
                 + "&caselast=" + CaseLast
                 + "&doctype=pdf"
                 + "&reportID=3"
                 , "_blank");
            });

            $('#btn3_excel').click(function () {
                var parts_from = $("#txtAccidentFrom_date").val().split("/");
                var dt_from = parts_from[2] - 543 + "-" + parts_from[1] + "-" + parts_from[0];

                var parts_to = $("#txtAccidentTo_date").val().split("/");
                var dt_to = parts_to[2] - 543 + "-" + parts_to[1] + "-" + parts_to[0];
                var AccuserType = $("input[name='staff']:checked").val();
                var CaseQuality = $("input[name='quality']:checked").val();
                var CaseLast = $("input[name='caselast']:checked").val();
                var HaveCulprit = "Y";

                if (CaseQuality == "0")
                    HaveCulprit = "N";
                else if (CaseQuality == "")
                 HaveCulprit = "";

                window.open("./Report/frmReportsPreview.aspx?AccidentFrom=" + dt_from + "&AccidentTo=" + dt_to
                 + "&OfficeCode1=" + $("#ddlOffCode1").val()
                 + "&OfficeCode2=" + $("#ddlOffCode2").val()
                 + "&OfficeCode3=" + $("#ddlOffCode3").val()
                 + "&groupid=" + $("#ddlDutyGroup").val()
                 + "&accusertype=" + AccuserType
                 + "&haveculprit=" + HaveCulprit
                 + "&casequality=" + CaseQuality
                 + "&caselast=" + CaseLast
                 + "&doctype=excel"
                 + "&reportID=3"
                 , "_blank");
            });
            // ----- END รายงานค่าปรับประมาณการ ------
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div class="main-content">
            <div class="container-fluid">
                <h3 class="page-title" style="font-weight: 800">
                    รายงานสถานะคดี</h3>
                <div class="panel panel-profile">
                    <div class="clearfix" style="height: 588px;">
                        <!-- LEFT COLUMN -->
                        <div class="profile-right">
                            <!-- PROFILE DETAIL -->
                            <div class="profile-detail">
                                <div class="profile-info">
                                    <div class="row">
                                        <div class="col-md-5">
                                            <h5 class="heading">
                                                ผู้กล่าวหา</h5>
                                            <label class="fancy-radio rd-padding">
                                                <input name="staff" value="2" type="radio" />
                                                <span><i></i>เจ้าหน้าที่สรรพสามิต (สตป.)</span>
                                            </label>
                                            <label class="fancy-radio rd-padding">
                                                <input name="staff" value="3" type="radio" />
                                                <span><i></i>เจ้าหน้าที่สรรพสามิตภาค</span>
                                            </label>
                                            <label class="fancy-radio rd-padding">
                                                <input name="staff" value="1" type="radio" />
                                                <span><i></i>เจ้าหน้าที่สรรพสามิตพื้นที่</span>
                                            </label>
                                            <label class="fancy-radio rd-padding">
                                                <input name="staff" value="4" type="radio" />
                                                <span><i></i>เจ้าหน้าที่สรรพสามิตพื้นที่สาขา</span>
                                            </label>
                                            <label class="fancy-radio rd-padding">
                                                <input name="staff" value="5" type="radio" />
                                                <span><i></i>เจ้าหน้าที่อื่นๆ</span>
                                            </label>
                                            <label class="fancy-radio">
                                                <input name="staff" value="" type="radio" checked />
                                                <span><i></i>ไม่ระบุ</span>
                                            </label>
                                        </div>
                                        <div class="col-md-3">
                                            <h5 class="heading">
                                                ลักษณะคดี</h5>
                                            <label class="fancy-radio rd-padding">
                                                <input name="quality" value="2" type="radio" />
                                                <span><i></i>ฟ้องศาล</span>
                                            </label>
                                            <label class="fancy-radio rd-padding">
                                                <input name="quality" value="1" type="radio"  />
                                                <span><i></i>เปรียบเทียบปรับ</span>
                                            </label>
                                            <label class="fancy-radio rd-padding">
                                                <input name="quality" value="0" type="radio" />
                                                <span><i></i>ไม่มีตัว</span>
                                            </label>
                                            <label class="fancy-radio rd-padding">
                                                <input name="quality" value="" type="radio" checked/>
                                                <span><i></i>ไม่ระบุ</span>
                                            </label>
                                        </div>
                                        <div class="col-md-4">
                                            <h5 class="heading">
                                                คดีสินสุดชั้น</h5>
                                            <label class="fancy-radio rd-padding">
                                                <input name="caselast" value="1" type="radio"  />
                                                <span><i></i>กรมสรรพสามิต</span>
                                            </label>
                                            <label class="fancy-radio rd-padding">
                                                <input name="caselast" value="2" type="radio" />
                                                <span><i></i>ศาล</span>
                                            </label>
                                            <label class="fancy-radio rd-padding">
                                                <input name="caselast" value="3" type="radio" />
                                                <span><i></i>พนักงานสอบสวน/พนักงานอัยการ</span>
                                            </label>
                                            <label class="fancy-radio rd-padding">
                                                <input name="caselast" value="" type="radio" checked/>
                                                <span><i></i>ไม่ระบุ</span>
                                            </label>
                                            <%-- <h5 class="heading">เพิกถอน</h5>
                                                <label class="fancy-radio rd-padding">
                                                    <input name="quash" value="1" type="radio" />
                                                    <span><i></i>เพิกถอน</span>
                                                </label>
                                                <label class="fancy-radio rd-padding">
                                                    <input name="quash" value="2" type="radio" />
                                                    <span><i></i>อยู่ระหว่างเพิกถอน</span>
                                                </label>
                                                <label class="fancy-radio">
                                                    <input name="quash" value="0" type="radio" />
                                                    <span><i></i>ไม่ระบุ</span>
                                                </label>--%>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 30px; margin-bottom:127px;">
                                        <div class="col-md-12">
                                            <%--<h5 class="heading">ของกลางมิชอบด้วยกฎหมาย</h5>
                                                <label class="fancy-radio rd-padding">
                                                    <input name="quash" value="1" type="radio" />
                                                    <span><i></i>ของกลางมิชอบด้วยกฎหมาย</span>
                                                </label>
                                                <label class="fancy-radio">
                                                    <input name="quash" value="0" type="radio" />
                                                    <span><i></i>ไม่ระบุ</span>
                                                </label>--%>
                                            <h5 class="heading">
                                                สรรพสามิต</h5>
                                            <div class="row panel_row">
                                                <div class="col-md-3 col-right">
                                                    ภาค :
                                                </div>
                                                <div class="col-md-9">
                                                    <select id="ddlOffCode1" class="form-control control_font">
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="row panel_row">
                                                <div class="col-md-3 col-right">
                                                    พื้นที่ :
                                                </div>
                                                <div class="col-md-9">
                                                    <select id="ddlOffCode2" class="form-control control_font">
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="row panel_row">
                                                <div class="col-md-3 col-right">
                                                    พื้นที่/สาขา :
                                                </div>
                                                <div class="col-md-9">
                                                    <select id="ddlOffCode3" class="form-control control_font">
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- END PROFILE DETAIL -->
                        </div>
                        <!-- END LEFT COLUMN -->
                        <!-- RIGHT COLUMN -->
                        <div class="profile-left">
                            <h5 class="heading" style="font-weight: bold">
                                ค้นหา</h5>
                            <div class="row">
                                <div class="panel-body_control panel_row">
                                    <div class="col-md-2 col-right">
                                        ข้อกล่าวหา :
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" id="txtFromReport_date" />
                                    </div>
                                    <div class="col-md-2 col-right">
                                        ความผิด พ.ร.บ. :
                                    </div>
                                    <div class="col-md-4">
                                        <select id="ddlLegislation" class="form-control control_font">
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="panel-body_control panel_row">
                                    <div class="col-md-2 col-right">
                                        ชื่อผู้กระทำผิด :
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" id="Text1" />
                                    </div>
                                    <div class="col-md-2 col-right">
                                        สินค้า :
                                    </div>
                                    <div class="col-md-4">
                                        <select id="ddlDutyGroup" class="form-control control_font">
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="panel-body_control panel_row">
                                    <div class="col-md-2 col-right">
                                        วันที่เกิดเหตุ :
                                    </div>
                                    <div class="col-md-4">
                                        <div style="float: left; width: 40%">
                                            <input class="form-control" type="text" id="txtAccidentFrom_date" />
                                        </div>
                                        <div>
                                            <span style="padding: 0 20px 0 20px; float: left; font-size: 13px">ถึง</span>
                                            <div class="input-group">
                                                <input class="form-control" type="text" id="txtAccidentTo_date" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2 col-right">
                                        จังหวัด :
                                    </div>
                                    <div class="col-md-4">
                                        <select id="ddlProvince" class="form-control control_font">
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="panel-body_control panel_row">
                                    <div class="col-md-2 col-right">
                                        วันที่รับเรื่องส่วนคดี :
                                    </div>
                                    <div class="col-md-4">
                                        <div style="float: left; width: 40%">
                                            <input class="form-control" type="text" id="txtLawsuitFrom_date" />
                                        </div>
                                        <div>
                                            <span style="padding: 0 20px 0 20px; float: left; font-size: 13px">ถึง</span>
                                            <div class="input-group">
                                                <input class="form-control" type="text" id="txtLawsuitTo_date" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2 col-right">
                                        อำเภอ :
                                    </div>
                                    <div class="col-md-4">
                                        <select id="ddlDistrict" class="form-control control_font">
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="panel-body_control panel_row">
                                    <div class="col-md-2 col-right">
                                        วันที่เขียนบันทึกจับกุม :
                                    </div>
                                    <div class="col-md-4">
                                        <div style="float: left; width: 40%">
                                            <input class="form-control" type="text" id="txtArrestFrom_date" />
                                        </div>
                                        <div>
                                            <span style="padding: 0 20px 0 20px; float: left; font-size: 13px">ถึง</span>
                                            <div class="input-group">
                                                <input class="form-control" type="text" id="txtArrestTo_date" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2 col-right">
                                        ตำบล :
                                    </div>
                                    <div class="col-md-4">
                                        <select id="ddlSubDistrict" class="form-control control_font">
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="panel-body_control panel_row">
                                    <div class="col-md-2 col-right">
                                        เลขที่งาน :
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" id="Text5" />
                                    </div>
                                    <div class="col-md-2 col-right">
                                        คดีเปรียบเทียบที่ :
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" id="Text6" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="panel-body_control panel_row">
                                    <div class="col-md-2 col-right">
                                        เลขที่คดี :
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" id="Text7" />
                                    </div>
                                    <div class="col-md-2 col-right">
                                        รายงานพิสูจน์ที่ :
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" id="Text8" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="panel-body_control panel_row">
                                    <div class="col-md-2 col-right">
                                        ชื่อผู้กล่าวหา :
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" id="Text9" />
                                    </div>
                                    <div class="col-md-2 col-right ">
                                        เลขที่บัตร ปชช. :
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" id="Text10" />
                                    </div>
                                </div>
                            </div>
                            <%--<div class="row">
                                <div class="panel-body_control panel_row">
                                    <div class="col-md-2 col-right">
                                        ชื่อสินค้าของกลาง :
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" id="Text11" />
                                    </div>
                                    <div class="col-md-2 col-right">
                                        จำนวนเงินค่าปรับ :
                                    </div>
                                    <div class="col-md-4">
                                        <div style="float: left; width: 40%">
                                            <input class="form-control" type="text" id="Text12" />
                                        </div>
                                        <div>
                                            <span style="padding: 0 20px 0 20px; float: left; font-size: 13px">ถึง</span>
                                            <div class="input-group">
                                                <input class="form-control" type="text" id="Text15" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                            <%--<div class="row">
                                <div class="panel-body_control panel_row">
                                    <div class="col-md-2 col-right">
                                            มาตรา :</div>
                                        <div class="col-md-4">
                                            <input class="form-control" type="text" id="Text13" />
                                        </div>
                                    <div class="col-md-2 col-right">
                                        สรรพสามิต :</div>
                                    <div class="col-md-2">
                                        <input class="form-control control_font" type="text" id="OfficeCode" disabled="disabled" />
                                    </div>
                                    <div class="col-md-7">
                                        <div class="input-group">
                                            <input class="form-control control_font" type="text" id="OfficeName" disabled="disabled">
                                            <span data-toggle="modal" data-target="#myModal" id="SearchDept" class="input-group-addon">
                                                <i class="fa fa-search"></i></span>
                                        </div>
                                        
                                    </div>
                                    <div class="col-md-1" style="padding:10px 15px 9px 0;" id="btnDel"><i class="fa fa-times"></i></div>
                                        
                                </div>
                            </div>--%>
                            <div class="text-center" style="margin: 20px 0 15px 0;">
                                <button type="button" class="btn btn-primary" id="btn_pdf" style="font-size: 13px;
                                    width: 30%">
                                    <i class="fa fa-file-pdf-o"></i>&nbsp; รายงานผลงานการจับกุม (PDF)</button> &nbsp;&nbsp;&nbsp;
                                <button type="button" class="btn btn-primary" id="btn_excel" style="font-size: 13px;
                                    width: 30%">
                                    <i class="fa fa-file-pdf-o"></i>&nbsp; รายงานผลงานการจับกุม (Excel)</button>
                            </div>
                            <div class="text-center">
                                <button type="button" class="btn btn-info" id="btn2_pdf" style="font-size: 13px;
                                    width: 30%">
                                    <i class="fa fa-file-pdf-o"></i>&nbsp;  รายงานผลคดี ส.ส. 2/55 (PDF)</button> &nbsp;&nbsp;&nbsp;
                                <button type="button" class="btn btn-info" id="btn2_excel" style="font-size: 13px;
                                    width: 30%">
                                    <i class="fa fa-file-pdf-o"></i>&nbsp;  รายงานผลคดี ส.ส. 2/55 (Excel)</button>
                            </div>

                            <div class="text-center" style="margin: 15px 0 0 0;">
                                <button type="button" class="btn btn-success" id="btn3_pdf" style="font-size: 13px;
                                    width: 30%">
                                    <i class="fa fa-file-pdf-o"></i>&nbsp;  รายงานค่าปรับประมาณการ (PDF)</button> &nbsp;&nbsp;&nbsp;
                                <button type="button" class="btn btn-success" id="btn3_excel" style="font-size: 13px;
                                    width: 30%">
                                    <i class="fa fa-file-pdf-o"></i>&nbsp;  รายงานค่าปรับประมาณการ (Excel)</button>
                            </div>
                            <!-- END RIGHT COLUMN -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- เนือหาของ Modal ทั้งหมด -->
                <div class="modal-content">
                    <!-- ส่วนหัวของ Modal -->
                    <div class="modal-header">
                        <!-- ปุ่มกดปิด (X) ตรงส่วนหัวของ Modal -->
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <div id="Div2">
                            <h4 class="modal-title">
                                ข้อมูลหน่วยงาน</h4>
                        </div>
                    </div>
                    <!-- ส่วนเนื้อหาของ Modal -->
                    <div class="modal-body">
                        <div class="row" style="margin-bottom: 20px;">
                            <div class="panel-body_control panel_row">
                                <div class="col-md-2 col-right">
                                    รหัสหน่วยงาน :
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" id="txtDeptCode" />
                                </div>
                                <div class="col-md-2 col-right">
                                    ชื่อหน่วยงาน :
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" type="text" id="txtDeptName" />
                                </div>
                                <div class="col-md-2">
                                    <button type="button" class="btn btn-info" id="btnSearchDept" style="font-size: 13px;">
                                        <i class="fa fa-search"></i>&nbsp; Search</button>
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive" style="clear: both;">
                            <table id="tb" class="table table-bordered" style="font-size: 13px">
                                <thead>
                                    <tr class="Trolley-table-tr">
                                        <th class="Trolley-table-th">
                                            ลำดับที่.
                                        </th>
                                        <th class="Trolley-table-th">
                                            รหัสหน่วยงาน
                                        </th>
                                        <th class="Trolley-table-th">
                                            ชื่อหน่วยงาน
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td colspan="3" style="text-align: center">
                                            ไม่พบข้อมูลที่ค้นหา
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <ul id="Pageing" class="pagination">
                        </ul>
                        <div id="divTotal" style="float: right; padding-top: 30px; font-size: 13px">
                            <img style="display: none" alt="" id="loading" src="Images/load.gif" />&nbsp;ทั้งหมด&nbsp;&nbsp;
                            <span id="totalRecord">0</span> &nbsp;&nbsp;รายการ
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
