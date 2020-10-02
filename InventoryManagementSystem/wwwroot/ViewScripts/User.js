$(document).ready(function () {
    //Initialize Select2 Elements
    $('.select2bs4').select2({
        theme: 'bootstrap4'
    });
    //$("#userRoles").select2({ placeholder: "Select a Role" });
    LoadAllRoles();
    $("#cbxActive").prop("checked", true);
    LoadUsers();
});

function SaveUser() {
    var form = new FormData();
    form.append("UserId", "0");
    form.append("FirstName", $("#tbxFirstName").val());
    form.append("LastName", $("#tbxLastName").val());
    form.append("UserName", $("#tbxUserName").val());
    form.append("Active", $("#cbxActive").prop("checked"));
    form.append("Password", $("#tbxPassword").val());
    form.append("RoleId", $("#userRoles").val())

    var settings = {
        "url": "User/create",
        "method": "POST",
        "timeout": 0,
        "processData": false,
        "mimeType": "multipart/form-data",
        "contentType": false,
        "data": form
    };

    $.ajax(settings).done(function (response) {
        debugger
        console.log(response);
        $.notify("Save Successfully", "success");
        LoadUsers();
        Clearform();
    });
}
function LoadAllRoles() {
    $.ajax({
        type: "GET",
        url: "Role/GetAllRoles",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        success: function (result) {

            for (var i = 0; i < result.length; i++) {
                $("#userRoles").append(
                    $('<option/>', {
                        value: result[i].roleId,
                        html: result[i].roleName
                    })
                );
            }
        }
    })
}
function LoadUsers() {
    $.ajax({
        type: "GET",
        url: "User/GetAllUsers",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        success: function (result) {
            var json = result;

            if ($.fn.DataTable.isDataTable('#usertable')) {
                $('#usertable').DataTable().destroy();
                $('#usertable tbody').empty();
            }
            $('#usertable').DataTable({
                "aaData": json,
                "aoColumns": [
                    { "mDataProp": "userId" },
                    { "mDataProp": "firstName" },
                    { "mDataProp": "lastName" },
                    { "mDataProp": "userName" },
                    { "mDataProp": "roleName" },
                    { "mDataProp": "active" },

                    {
                        "mDataProp": null, "bSearchable": false, "bSortable": false,
                        "sDefaultContent":  '< button class= "btn" onclick="EditUser()" > <i class="fa fa-edit" ></i></button>'
                    },
                ],
                "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                    $('td:eq(0)', nRow).addClass("avo-lime-h avo-heading-white");
                    $('td:eq(1),td:eq(2),td:eq(3)', nRow).addClass("avo-light");
                }
            });


        }
    })
    return false;

}
function Clearform() {
    $("#tbxFirstName").val('');
    $("#tbxLastName").val('');
    $("#tbxUserName").val('');
    $("#cbxActive").prop("checked", true);
    $("#tbxPassword").val('');
    // $("#userRoles").val(0)

}
function EditUser() {
    $.notify("in Progress", "error");
}

