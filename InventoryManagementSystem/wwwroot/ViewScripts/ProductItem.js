$(document).ready(function () {
    var productsDataset = [];

    $('#mytable').DataTable();
    var totalProductCount = 0;
    LoadProducts();
    $("#inputActive").prop("checked", true);
    setTimeout(function () {
        generateProductCode();
    },2000 );


});

function LoadProducts() {
    $.ajax({
        type: "GET",
        url: "Products/GetAllProducts",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        success: function (bind) {
            var json = bind;
            if (bind.length > 0) {
                window.totalProductCount = bind.length;
            }
            if ($.fn.DataTable.isDataTable('#producttable')) {
                $('#producttable').DataTable().destroy();
                $('#producttable tbody').empty();
            }
            $('#producttable').DataTable({
                "aaData": json,
                "aoColumns": [
                   
                    { "mDataProp": "name" },
                    { "mDataProp": "description" },
                    { "mDataProp": "code" },
                    { "mDataProp": "qty" },
                    { "mDataProp": "active" },

                    {
                        "mDataProp": null, "bSearchable": false, "bSortable": false,
                        "sDefaultContent": '<button class="btn" onclick="productEdit()"><i class="fa fa-edit" ></i></button>'
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

function productEdit() {
    alert("Hi");
}

function generateProductCode() {
    debugger
    var code = 'STM-' + window.totalProductCount 
    $("#inputCode").val(code);
}

function SaveProduct() {
    var form = new FormData();
    form.append("ProductId", "0");
    form.append("Code", $("#inputCode").val());
    form.append("Description", $("#inputDescription").val());
    form.append("Active", $("#inputActive").prop("checked"));
    form.append("Name", $("#inputProductName").val());
    form.append("Qty", $("#inputQty").val())

    var settings = {
        "url": "Products/create",
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
        LoadProducts();
        Clearform();
    });
   
}
function Clearform() {
    $("#inputProductName").val('');
    generateProductCode();
    $("#inputDescription").val('');
    $("#inputQty").val('');

}

