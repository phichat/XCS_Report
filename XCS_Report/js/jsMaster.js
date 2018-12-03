function showddlLegislation() {
    $.ajax({
        type: "POST",
        url: "FrmReport.aspx/getDLLLegislation",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            //alert("OK");
            var Ddl1 = $("[id*=ddlLegislation]");
            //Ddl1.empty().append('<option selected="selected" value="0">-- เลือก --</option>');
            $.each(r.d, function () {
                Ddl1.append($("<option></option>").val(this['Value']).html(this['Text']));
            });
            
            showddlDutyGroup($("#ddlLegislation").val());
        },
        error: function () {
            alert('ไม่สามารถเชื่อมต่อฐานข้อมูลได้ค่ะ !!!');
        }
    });
}


function showddlDutyGroup(groupID) {
    $.ajax({
        type: "POST",
        url: "FrmReport.aspx/getDLLDutyGroup",
        data: "{'groupID':'" + groupID + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            //alert("OK");
            var Ddl1 = $("[id*=ddlDutyGroup]");
            Ddl1.empty().append('<option selected="selected" value="">-- เลือก --</option>');
            $.each(r.d, function () {
                Ddl1.append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            alert('ไม่สามารถเชื่อมต่อฐานข้อมูลได้ค่ะ !!!');
        }
    });
}

function showddlProvince() {
    $.ajax({
        type: "POST",
        url: "FrmReport.aspx/getDLLProvince",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            //alert("OK");
            var Ddl1 = $("[id*=ddlProvince]");
            Ddl1.empty().append('<option selected="selected" value="0">-- เลือก --</option>');
            $.each(r.d, function () {
                Ddl1.append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            alert('ไม่สามารถเชื่อมต่อฐานข้อมูลได้ค่ะ !!!');
        }
    });
}

function showddlDistrict(province_code) {
    $.ajax({
        type: "POST",
        url: "FrmReport.aspx/getDLLDistrict",
        data: "{'province_code':'" + province_code + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            //alert("OK");
            var Ddl1 = $("[id*=ddlDistrict]");
            Ddl1.empty().append('<option selected="selected" value="0">-- เลือก --</option>');
            $.each(r.d, function () {
                Ddl1.append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            alert('ไม่สามารถเชื่อมต่อฐานข้อมูลได้ค่ะ !!!');
        }
    });
}

function showddlSubDistrict(district_code) {
    $.ajax({
        type: "POST",
        url: "FrmReport.aspx/getDLLSubDistrict",
        data: "{'district_code':'" + district_code + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            //alert("OK");
            var Ddl1 = $("[id*=ddlSubDistrict]");
            Ddl1.empty().append('<option selected="selected" value="0">-- เลือก --</option>');
            $.each(r.d, function () {
                Ddl1.append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            alert('ไม่สามารถเชื่อมต่อฐานข้อมูลได้ค่ะ !!!');
        }
    });
}

function showddlOffCode1() {
    $.ajax({
        type: "POST",
        url: "FrmReport.aspx/getDLLOffCode1",
        data: "{'indc_off':'D','suboffcode':''}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            //alert("OK");
            var Ddl1 = $("[id*=ddlOffCode1]");
            Ddl1.empty().append('<option selected="selected" value="">-- เลือก --</option>');
            $.each(r.d, function () {
                Ddl1.append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            alert('ไม่สามารถเชื่อมต่อฐานข้อมูลได้ค่ะ !!!');
        }
    });
}

function showddlOffCode2(suboffcode) {
    $.ajax({
        type: "POST",
        url: "FrmReport.aspx/getDLLOffCode1",
        data: "{'indc_off':'E','suboffcode':'" + suboffcode + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            //alert("OK");
            var Ddl1 = $("[id*=ddlOffCode2]");
            Ddl1.empty().append('<option selected="selected" value="">-- เลือก --</option>');
            $.each(r.d, function () {
                Ddl1.append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            alert('ไม่สามารถเชื่อมต่อฐานข้อมูลได้ค่ะ !!!');
        }
    });
}

function showddlOffCode3(suboffcode) {
    $.ajax({
        type: "POST",
        url: "FrmReport.aspx/getDLLOffCode1",
        data: "{'indc_off':'F','suboffcode':'" + suboffcode + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            //alert("OK");
            var Ddl1 = $("[id*=ddlOffCode3]");
            Ddl1.empty().append('<option selected="selected" value="">-- เลือก --</option>');
            $.each(r.d, function () {
                Ddl1.append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            alert('ไม่สามารถเชื่อมต่อฐานข้อมูลได้ค่ะ !!!');
        }
    });
}