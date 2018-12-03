function ShowDepartment(page) {
    currentpage = page;

    $.ajax({
        type: "POST",
        url: "FrmReport.aspx/getDepartment",
        data: "{'offCode':'" + $("#txtDeptCode").val() + "','offName':'" + $("#txtDeptName").val() + "'"
                + ",'curepage':" + currentpage + ",'pagesize':" + pagesize + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnComplete,
        error: on_error
    });
}

function OnComplete(data, status) {
    var resultSet = $.parseJSON(data.d);

    if (resultSet.Table.length == 0) {
        resetField();

        SelectPagingDataNormal();
    }

    else
        BindingData(resultSet);
}

function on_error(request, status, error) {
    resetField();
}

function BindingData(data) {
    var rownum = 1;
    if (currentpage > 1) {
        rownum = (currentpage - 1) * pagesize;
        rownum = rownum + 1;
    }

    $("#tb tbody").empty();
    $.each(data, function (index, table) {
        $.each(table, function (key, obj) {
            var tr = "<tr id=\"" + obj.OFFCODE + "\">";
            tr += "     <td style=\"text-align:center;\">" + rownum + "</td>";
            tr += "     <td style=\"text-align:center;\"><a style='cursor:pointer' onclick=\"javascript:setOffice('" + obj.OFFCODE + "','" + obj.OFFNAME + "')\">" + obj.OFFCODE + "</a></td>";
            tr += "     <td style=\"text-align:left;\">" + obj.OFFNAME + "</td>";
            tr += "</tr>";

            rownum = rownum + 1;

            $("#tb tbody").append(tr);
        });
    });
}

function SelectPagingDataNormal() {

    $.ajax({
        type: "POST",
        async: false,
        beforeSend: function () { $("#loading").show(); },
        url: "FrmReport.aspx/CountDepartment",
        data: "{'offCode':'" + $("#txtDeptCode").val() + "','offName':'" + $("#txtDeptName").val() + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnError
    });
    function OnSuccess(data, status) {
        BindPageingTable(Math.ceil(data.d / pagesize), currentpage);
        $("#totalRecord").text(data.d);
        $("#loading").hide();
    }
    function OnError(request, status, error) {
        $("#loading").hide();
        alert(request.responseText);
    }
}

function BindPageingTable(TotalPage, start) {

    if (TotalPage > 1) {
        DisPlayPageing(true);
        $("#Pageing").pagination({
            total: TotalPage,
            current: start,
            length: 1,
            size: 2,
            click: function (options, $target) {
                ShowDepartment(options.current);
            }
        });
    }
    else {
        DisPlayPageing(false);
    }
}

function DisPlayPageing(show) {
    if (show) {
        $("#Pageing").show();
        $("#divTotal").show();
    }
    else {

        $("#Pageing").hide();
        $("#divTotal").hide();
    }
}

function resetField() {
    $("#tb tbody").empty();

    var tr = "<tr><td colspan='3' style='text-align:center'>ไม่พบข้อมูลที่ค้นหา</td></tr>";

    $("#tb tbody").append(tr);
}

function setOffice(officeCode, officeName)
{
    $("#OfficeCode").val(officeCode);
    $("#OfficeName").val(officeName);
    $('#myModal').modal('hide');
    $('#btnDel').show();
}