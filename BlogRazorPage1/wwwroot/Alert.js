function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return decodeURIComponent(c.substring(name.length, c.length));
        }
    }
    return "";
}
//var result = getCookie("SystemAlert");
//if (result) {
//    result = JSON.parse(result);
//    if (result.IsSuccess === true) {
//        Success("", result.MetaData.Message, result.isReloadPage);
//    } else {
//        ErrorAlert("", result.MetaData.Message, result.isReloadPage);
//    }
//    deleteCookie("SystemAlert");
//    alert("lll");
//}
//if ($(".select2")) {
//    $(".select2").select2();
//}
//        });

function Success(title, description, isReload = false) {
    if (title == null || title == "undefined") {
        title = "عملیات با موفقیت انجام شد";
    }
    if (description == null || description == "undefined") {
        description = "";
    }
    Swal.fire({
        title: title,
        text: description,
        icon: "success",
        confirmButtonText: "باشه",
    }).then((result) => {
        if (isReload === true) {
            location.reload();
        }
    });
}
function ErrorAlert(Title, description, isReload = false) {
    if (Title == null || Title == "undefined") {
        Title = "مشکلی در عملیات رخ داده است";
    }
    if (description == null || description == "undefined") {
        description = "";
    }
    console.log(description);

    Swal.fire({
        title: Title,
        html: description,
        icon: "error",
        confirmButtonText: "باشه"
    }).then((result) => {
        if (isReload === true) {
            location.reload();
        }
    });
}
$(document).ready(function () {
    result = document.cookie("SystemAlert");
    if (result.IsSuccess === true) {
        Success("", result.MetaData.Message, result.isReloadPage);
    } else {
        ErrorAlert("", result.MetaData.Message, result.isReloadPage);
    }
    deleteCookie("SystemAlert");
    alert("lll");
});