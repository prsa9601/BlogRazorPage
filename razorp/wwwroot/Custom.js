$(document).ready(function () {
    //console.log("1");
    LoadCkEditor4();
});

function LoadCkEditor4() {
    if (!document.getElementById("ckEditor4"))
         return;
    //console.log("2");

    $("body").prepend("<script src='/ckeditor/ckeditor.js'></script>");

    CKEDITOR.replace('ckEditor4',
        {
            customConfig: '/ckeditor/Editor_custom_config.js'
        });

}
//document.addEventListener("DOMContentLoaded", function () {
//    $("body").append('<script src="/ckeditor4/ckeditor/ckeditor.js"></script>');
//    CKEDITOR.replace("ckEditor4", {
//        customConfig: "/ckeditor4/ckeditor/config.js"
//    });
//});