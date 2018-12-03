function setDetectionTime()
{
    /* set date*/
    $('#txtAccidentFrom_date').datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: true,
        language: 'th',             //เปลี่ยน label ต่างของ ปฏิทิน ให้เป็น ภาษาไทย   (ต้องใช้ไฟล์ bootstrap-datepicker.th.min.js นี้ด้วย)
        thaiyear: true,             //Set เป็นปี พ.ศ.
        autoclose: true
    }).datepicker("setDate", "0");  //กำหนดเป็นวันปัจุบัน

    $('#txtAccidentFrom_date').keydown(function (event) { return false; }); // ห้าม key ข้อมูลในช่อง textbox
    /* END set date*/
    
    /* set date*/
    $('#txtAccidentTo_date').datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: true,
        language: 'th',             //เปลี่ยน label ต่างของ ปฏิทิน ให้เป็น ภาษาไทย   (ต้องใช้ไฟล์ bootstrap-datepicker.th.min.js นี้ด้วย)
        thaiyear: true,             //Set เป็นปี พ.ศ.
        autoclose: true
    }).datepicker("setDate", "0");  //กำหนดเป็นวันปัจุบัน

    $('#txtAccidentTo_date').keydown(function (event) { return false; }); // ห้าม key ข้อมูลในช่อง textbox
    /* END set date*/
    
    /* set date*/
    $('#txtLawsuitFrom_date').datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: true,
        language: 'th',             //เปลี่ยน label ต่างของ ปฏิทิน ให้เป็น ภาษาไทย   (ต้องใช้ไฟล์ bootstrap-datepicker.th.min.js นี้ด้วย)
        thaiyear: true,             //Set เป็นปี พ.ศ.
        autoclose: true
    });  //กำหนดเป็นวันปัจุบัน

    $('#txtLawsuitFrom_date').keydown(function (event) { return false; }); // ห้าม key ข้อมูลในช่อง textbox
    /* END set date*/
    
    /* set date*/
    $('#txtLawsuitTo_date').datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: true,
        language: 'th',             //เปลี่ยน label ต่างของ ปฏิทิน ให้เป็น ภาษาไทย   (ต้องใช้ไฟล์ bootstrap-datepicker.th.min.js นี้ด้วย)
        thaiyear: true,             //Set เป็นปี พ.ศ.
        autoclose: true
    });  //กำหนดเป็นวันปัจุบัน

    $('#txtLawsuitTo_date').keydown(function (event) { return false; }); // ห้าม key ข้อมูลในช่อง textbox
    /* END set date*/
    
    /* set date*/
    $('#txtArrestFrom_date').datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: true,
        language: 'th',             //เปลี่ยน label ต่างของ ปฏิทิน ให้เป็น ภาษาไทย   (ต้องใช้ไฟล์ bootstrap-datepicker.th.min.js นี้ด้วย)
        thaiyear: true,             //Set เป็นปี พ.ศ.
        autoclose: true
    });  //กำหนดเป็นวันปัจุบัน

    $('#txtArrestFrom_date').keydown(function (event) { return false; }); // ห้าม key ข้อมูลในช่อง textbox
    /* END set date*/
    
    /* set date*/
    $('#txtArrestTo_date').datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: true,
        language: 'th',             //เปลี่ยน label ต่างของ ปฏิทิน ให้เป็น ภาษาไทย   (ต้องใช้ไฟล์ bootstrap-datepicker.th.min.js นี้ด้วย)
        thaiyear: true,             //Set เป็นปี พ.ศ.
        autoclose: true
    });  //กำหนดเป็นวันปัจุบัน

    $('#txtArrestTo_date').keydown(function (event) { return false; }); // ห้าม key ข้อมูลในช่อง textbox
    /* END set date*/
}