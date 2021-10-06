$(document).ready(function () {
    CUSTOMERS.InitalizeComponent();
});
var CUSTOMERS;
(function (CUSTOMERS) {
    // Arrays
    var AccountType = 2;
    var MSG_ID;
    //var Details: Array<CUSTOMER> = new Array<CUSTOMER>();
    var Det_Single_Cust = new CUSTOMER();
    var Details_Updata_Cust = new Array();
    var CustomerDetails = new Array();
    var SearchDetails = new Array();
    var BilldIData = new Array();
    var Model = new CUSTOMER();
    var ReportGrid = new JsGrid();
    var CashDetailsAr = new Array();
    var CashDetailsEn = new Array();
    var sys = new SystemTools();
    var SysSession = GetSystemSession();
    var ID_CUSTOMER;
    var txt_NAME;
    var txt_phone;
    var txt_Notes;
    var txt_Type_CUSTOMER;
    var btnback;
    var btnShow;
    var btnAdd;
    var btnEdit;
    var btnsave;
    var searchbutmemreport;
    var txt_Debit;
    var txt_DebitFC;
    var txt_Openbalance;
    var compcode; //SharedSession.CurrentEnvironment.CompCode;
    var IsNew = false;
    var index;
    var Selecteditem = new Array();
    var CustomerIdUpdate = 0;
    var CustomerId;
    var sum_balance;
    var Debit;
    var Credit;
    var Valid = 0;
    var Update_claenData = 0;
    var txt_ID_APP_Category;
    var txt_Cust_Type;
    var CUSTOMER_ID = 0;
    var status;
    function InitalizeComponent() {
        //debugger;
        if (SysSession.CurrentEnvironment.ScreenLanguage = "ar") {
            document.getElementById('Screen_name').innerHTML = "العملاء";
        }
        else {
            document.getElementById('Screen_name').innerHTML = "CUSTOMER";
        }
        compcode = Number(SysSession.CurrentEnvironment.CompCode);
        InitalizeControls();
        InitalizeEvents();
    }
    CUSTOMERS.InitalizeComponent = InitalizeComponent;
    function InitalizeControls() {
        txt_ID_APP_Category = document.getElementById("txt_ID_APP_Category");
        txt_Cust_Type = document.getElementById("txt_Cust_Type");
        status = document.getElementById('id_chkcustom6');
        btnShow = document.getElementById("btnShow");
        btnAdd = document.getElementById("btnAdd");
        btnEdit = document.getElementById("btnedite");
        btnsave = document.getElementById("btnsave");
        btnback = document.getElementById("btnback");
        ID_CUSTOMER = document.getElementById("txt_NAME");
        txt_NAME = document.getElementById("txt_NAME");
        txt_phone = document.getElementById("txt_NAME");
        txt_Notes = document.getElementById("txt_NAME");
        txt_Type_CUSTOMER = document.getElementById("txt_NAME");
        searchbutmemreport = document.getElementById("searchbutmemreport");
        txt_Debit = document.getElementById("txt_Debit");
        txt_DebitFC = document.getElementById("txt_DebitFC");
        txt_Openbalance = document.getElementById("txt_Openbalance");
    }
    function InitalizeEvents() {
        btnShow.onclick = btnShow_onclick;
        btnAdd.onclick = btnAdd_onclick;
        btnsave.onclick = btnsave_onClick;
        btnback.onclick = btnback_onclick;
        btnEdit.onclick = btnEdit_onclick;
        txt_Cust_Type.onchange = txt_Cust_Type_onchange;
        searchbutmemreport.onkeyup = _SearchBox_Change;
        txt_Openbalance.onkeyup = txt_Openbalance_onchange;
    }
    function Display_All() {
        var CreditType = $("#txt_ID_APP_Type").val();
        var BalType = $("#txt_indebtedness").val();
        CustomerDetails = new Array();
        Ajax.Callsync({
            type: "Get",
            url: sys.apiUrl("Customer", "GetFiltered"),
            data: { CreditType: CreditType, BalType: BalType },
            success: function (d) {
                debugger;
                var result = d;
                if (result.IsSuccess) {
                    CustomerDetails = result.Response;
                    for (var i = 0; i < CustomerDetails.length; i++) {
                        CustomerDetails[i].Name_STATUS = CustomerDetails[i].STATUS == false ? 'غير فعال' : 'فعال';
                        CustomerDetails[i].NameIsCreditCustomer = CustomerDetails[i].IsCreditCustomer == false ? 'أجل' : 'نقدي';
                    }
                    InitializeGrid();
                    ReportGrid.DataSource = CustomerDetails;
                    ReportGrid.Bind();
                }
            }
        });
    }
    function InitializeGrid() {
        var res = GetResourceList("");
        $("#id_ReportGrid").attr("style", "");
        ReportGrid.OnRowDoubleClicked = DriverDoubleClick;
        ReportGrid.ElementName = "ReportGrid";
        ReportGrid.PrimaryKey = "CUSTOMER_ID";
        ReportGrid.Paging = true;
        ReportGrid.PageSize = 10;
        ReportGrid.Sorting = true;
        ReportGrid.InsertionMode = JsGridInsertionMode.Binding;
        ReportGrid.Editing = false;
        ReportGrid.Inserting = false;
        ReportGrid.SelectedIndex = 1;
        ReportGrid.OnItemEditing = function () { };
        ReportGrid.Columns = [
            { title: "الرقم", name: "CUSTOMER_ID", type: "text", width: "100px", visible: false },
            { title: "الرقم", name: "CustomerCODE", type: "text", width: "100px" },
            { title: "الاسم", name: "CUSTOMER_NAME", type: "text", width: "100px" },
            { title: "رقم الجوال", name: "PHONE", type: "text", width: "100px" },
            { title: "النوع", name: "NameIsCreditCustomer", type: "text", width: "100px" },
            { title: "الرصيد الافتتاحي", name: "Openbalance", type: "text", width: "100px" },
            { title: "مدين", name: "Debit", type: "text", width: "100px" },
            { title: "دائن", name: "Credit", type: "text", width: "100px" },
            { title: "الرصيد", name: "CreditLimit", type: "text", width: "100px" },
            { title: "مفعل", name: "Name_STATUS", type: "textdd", width: "100px" },
        ];
        ReportGrid.Bind();
    }
    function DriverDoubleClick() {
        debugger;
        Selecteditem = CustomerDetails.filter(function (s) { return s.CUSTOMER_ID == Number(ReportGrid.SelectedKey); });
        DocumentActions.RenderFromModel(Selecteditem[0]);
        $('#txt_Cust_Type').val(Selecteditem[0].IsCreditCustomer == false ? '0' : '1');
        if (Selecteditem[0].STATUS) {
            status.checked = true;
        }
        else
            status.checked = false;
        $('#btnedite').removeClass("display_none");
        $('#btnsave').addClass("display_none");
        $('#btnback').addClass("display_none");
        $('#btnedite').removeAttr("disabled");
        $('#Div_control').removeClass("display_none");
        if (Selecteditem[0].IsCreditCustomer == false) {
            $('#div_Balance').removeClass("display_none");
        }
        else {
            $('#div_Balance').addClass("display_none");
            txt_Debit.value = "0";
            txt_DebitFC.value = "0";
        }
        //Debit = Selecteditem[0].CreditLimit;
        //Credit = Number(Selecteditem[0].Openbalance - Selecteditem[0].CreditLimit);
        //if (Credit < 0) {
        //    $('#txt_Debit').val((Credit * -1));
        //    $('#txt_DebitFC').val(('0'));
        //}
        //else {
        //    $('#txt_DebitFC').val((Credit));
        //    $('#txt_Debit').val(('0'));
        //}
        CUSTOMER_ID = Selecteditem[0].CUSTOMER_ID;
        $('#Div_control').removeClass("display_none");
    }
    function txt_Openbalance_onchange() {
        if (IsNew != true) {
            //$('#txt_DebitFC').val((Number(txt_Openbalance.value) - Debit).toString());
            var credit = Selecteditem[0].Debit - Number(txt_Openbalance.value);
            if (credit > 0) {
                $('#txt_Debit').val(credit);
                $('#txt_DebitFC').val("0");
            }
            else {
                $('#txt_DebitFC').val(credit * -1);
                $('#txt_Debit').val("0");
            }
        }
        else {
            $('#txt_DebitFC').val(txt_Openbalance.value);
        }
    }
    function btnEdit_onclick() {
        IsNew = false;
        $('#btnsave').removeClass("display_none");
        $('#btnback').removeClass("display_none");
        $("#Div_control :input").removeAttr("disabled");
        $('#btnedite').addClass("display_none");
        $("#id_div_Add").addClass("disabledDiv");
        $('#txt_balance').attr("disabled", "disabled");
        $('#txt_DebitFC').attr("disabled", "disabled");
        $('#txt_Debit').attr("disabled", "disabled");
        $('#txt_Openbalance').attr("disabled", "disabled");
        $('#txt_CustomerCODE').attr("disabled", "disabled");
    }
    function btnAdd_onclick() {
        debugger;
        IsNew = true;
        EnableControls();
        $('#btnsave').removeClass("display_none");
        $('#btnback').removeClass("display_none");
        $("#Div_control :input").removeAttr("disabled");
        $('#btnedite').addClass("display_none");
        $("#id_div_Add").addClass("disabledDiv");
        $("#Div_control :input").val("");
        $('#txt_balance').attr("disabled", "disabled");
        $('#txt_DebitFC').attr("disabled", "disabled");
        $('#txt_Debit').attr("disabled", "disabled");
        $('#txt_CustomerCODE').attr("disabled", "disabled");
        $('#Div_control').removeClass("display_none");
        status.checked = true;
        txt_Cust_Type.value = 'Null';
    }
    function btnsave_onClick() {
        if (!Validation())
            return;
        Insert();
    }
    function btnback_onclick() {
        Selecteditem = CustomerDetails.filter(function (x) { return x.CUSTOMER_ID == Number(ReportGrid.SelectedKey); });
        if (Selecteditem.length == 0) {
            IsNew = true;
        }
        if (IsNew == true) {
            $('#btnAddDetails').toggleClass("display_none");
            $('#btnsave').toggleClass("display_none");
            $('#btnback').toggleClass("display_none");
            $(".fa-minus-circle").addClass("display_none");
            $("#btnedite").removeClass("display_none");
            $("#btnedite").removeAttr("disabled");
            $("#Div_control").addClass("display_none");
            $("#id_div_Add").attr("disabled", "");
            $("#id_div_Add").removeClass("disabledDiv");
        }
        else {
            $('#btnAddDetails').toggleClass("display_none");
            $('#btnsave').toggleClass("display_none");
            $('#btnback').toggleClass("display_none");
            $(".fa-minus-circle").addClass("display_none");
            $("#btnedite").removeClass("display_none");
            $("#btnedite").removeAttr("disabled");
            Update_claenData = 0;
            $("#id_div_Add").attr("disabled", "");
            $("#id_div_Add").removeClass("disabledDiv");
        }
        $("#Div_control :input").attr("disabled", "disabled");
        DriverDoubleClick();
    }
    function btnShow_onclick() {
        Display_All();
    }
    function Validation() {
        if ($('#txt_Cust_Type').val() == "Null") {
            MessageBox.Show("يجب اختيار النوع ", " ");
            Errorinput($('#txt_Cust_Type'));
            return false;
        }
        if ($('#txt_NAME').val() == "") {
            MessageBox.Show("يجب ادخال اسم العميل ", " ");
            Errorinput($('#txt_NAME'));
            return false;
        }
        if ($('#txt_MOBILE').val() == 0) {
            MessageBox.Show("يجب ادخال الهاتف ", " ");
            Errorinput($('#txt_MOBILE'));
            return false;
        }
        if ($('#txt_Email').val().trim() != '') {
            if (validate_email() == false) {
                DisplayMassage("يجب ادخال البريد الالكتروني صحيح ", "You must enter a valid email", MessageType.Worning);
                Errorinput($('#txt_Email'));
                return false;
            }
        }
        return true;
    }
    function EnableControls() {
        debugger;
        $("#Div_control").attr("style", "height: 389px;margin-bottom: 19px;margin-top: 20px;");
        $('#btnsave').removeClass("display_none");
        $('#btnback').removeClass("display_none");
        $('#btnedite').attr('class', 'btn btn-primary display_none');
        $('#txt_IS_Active').prop("selectedIndex", 0);
        ID_CUSTOMER.value = "";
        txt_NAME.value = "";
        txt_phone.value = "";
        txt_Notes.value = "";
        txt_Type_CUSTOMER.value = "";
    }
    function _SearchBox_Change() {
        debugger;
        if (searchbutmemreport.value != "") {
            var search_1 = searchbutmemreport.value.toLowerCase();
            SearchDetails = CustomerDetails.filter(function (x) { return x.CUSTOMER_NAME.toLowerCase().search(search_1) >= 0 || x.PHONE.toString().search(search_1) >= 0; });
            ReportGrid.DataSource = SearchDetails;
            ReportGrid.Bind();
        }
        else {
            ReportGrid.DataSource = CustomerDetails;
            ReportGrid.Bind();
        }
    }
    function Assign() {
        if (IsNew == true) {
            Details_Updata_Cust = new Array();
            Det_Single_Cust = new CUSTOMER();
            DocumentActions.AssignToModel(Det_Single_Cust);
            Det_Single_Cust.CustomerCODE = (Math.floor(Math.random() * 1000) + Math.floor(Math.random() * 1000)).toString();
            Det_Single_Cust.CUSTOMER_ID = 0;
            Det_Single_Cust.STATUS = status.checked;
            Det_Single_Cust.IsCreditCustomer = $('#txt_Cust_Type').val() == '0' ? false : true;
            Det_Single_Cust.StatusFlag = "i";
            Details_Updata_Cust.push(Det_Single_Cust);
        }
        else {
            Details_Updata_Cust = new Array();
            Det_Single_Cust = new CUSTOMER();
            DocumentActions.AssignToModel(Det_Single_Cust);
            Det_Single_Cust.CustomerCODE = (Math.floor(Math.random() * 1000) + Math.floor(Math.random() * 1000)).toString();
            Det_Single_Cust.CUSTOMER_ID = Number(CUSTOMER_ID);
            Det_Single_Cust.STATUS = status.checked;
            Det_Single_Cust.IsCreditCustomer = $('#txt_Cust_Type').val() == '0' ? false : true;
            Det_Single_Cust.StatusFlag = "u";
            Details_Updata_Cust.push(Det_Single_Cust);
        }
    }
    function Insert() {
        Assign();
        Ajax.Callsync({
            type: "POST",
            url: sys.apiUrl("Customer", "UpdateCustlist"),
            data: JSON.stringify(Details_Updata_Cust),
            success: function (d) {
                debugger;
                var result = d;
                if (result.IsSuccess == true) {
                    CUSTOMER_ID = result.Response;
                    success();
                }
                else {
                    MessageBox.Show(result.ErrorMessage, "خطأ");
                }
            }
        });
    }
    function success() {
        $('#btnAddDetails').toggleClass("display_none");
        $('#btnsave').toggleClass("display_none");
        $('#btnback').toggleClass("display_none");
        $(".fa-minus-circle").addClass("display_none");
        $("#btnedite").removeClass("display_none");
        $("#btnedite").removeAttr("disabled");
        $("#Div_control").addClass("display_none");
        $("#id_div_Add").attr("disabled", "");
        $("#id_div_Add").removeClass("disabledDiv");
        $("#Div_control :input").attr("disabled", "disabled");
        $("#txt_ID_APP_Type").val('Null');
        $("#txt_indebtedness").val('All');
        Display_All();
        Selecteditem = CustomerDetails.filter(function (s) { return s.CUSTOMER_ID == Number(CUSTOMER_ID); });
        DocumentActions.RenderFromModel(Selecteditem[0]);
        $('#txt_Cust_Type').val(Selecteditem[0].IsCreditCustomer == false ? '0' : '1');
        var status = document.getElementById('id_chkcustom6');
        if (Selecteditem[0].STATUS) {
            status.checked = true;
        }
        else
            status.checked = false;
        $('#btnedite').removeClass("display_none");
        $('#btnsave').addClass("display_none");
        $('#btnback').addClass("display_none");
        $('#btnedite').removeAttr("disabled");
        $('#Div_control').removeClass("display_none");
        if (Selecteditem[0].IsCreditCustomer == false) {
            $('#div_Balance').removeClass("display_none");
        }
        else {
            $('#div_Balance').addClass("display_none");
            txt_Debit.value = "0";
            txt_DebitFC.value = "0";
        }
        //Debit = Selecteditem[0].CreditLimit;
        //Credit = Number(Selecteditem[0].Openbalance - Selecteditem[0].CreditLimit);
        //if (Credit < 0) {
        //    $('#txt_Debit').val((Credit * -1));
        //    $('#txt_DebitFC').val(('0'));
        //}
        //else {
        //    $('#txt_DebitFC').val((Credit));
        //    $('#txt_Debit').val(('0'));
        //}
        CUSTOMER_ID = Selecteditem[0].CUSTOMER_ID;
        $('#Div_control').removeClass("display_none");
    }
    function txt_Cust_Type_onchange() {
        if (txt_Cust_Type.value == "0" || txt_Cust_Type.value == "Null") {
            $('#div_Balance').removeClass("display_none");
        }
        else {
            $('#div_Balance').addClass("display_none");
            txt_Debit.value = "0";
            txt_DebitFC.value = "0";
            txt_Openbalance.value = "0";
            $('#txt_balance').val('0');
        }
    }
    function validateEmail(email) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }
    function validate_email() {
        var email = $("#txt_Email").val();
        validateEmail(email);
        return validateEmail(email);
    }
})(CUSTOMERS || (CUSTOMERS = {}));
//# sourceMappingURL=CUSTOMERS.js.map