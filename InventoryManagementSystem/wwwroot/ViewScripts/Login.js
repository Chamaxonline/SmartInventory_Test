function Login() {
    debugger
    var form = new FormData();
    form.append("UserName", $("#tbxUserName").val());
    form.append("Password", $("#tbxPassword").val());

    var settings = {
        "url": "https://localhost:44378/Account/LoginTry",
        "method": "POST",
        "timeout": 0,
        "processData": false,
        "mimeType": "multipart/form-data",
        "contentType": false,
        "data": form
    };

    $.ajax(settings).done(function (response) {        
        console.log(response);
        var res = JSON.parse(response);
        if (res.status == true) {
            window.location.replace("https://localhost:44378/Products");
        }
        else {
            $.notify(res.message, "error");
        }
        
       // $.notify(res.message, "success");
       // alert(response);
    });
}