/// <reference path="../../../typescript definitions/jquery.d.ts" />
/// <reference path="../../../typescript definitions/bootstrap.d.ts" />
// Search box toggle
// =================
$("#search-btn").on("click", function () {
    $("#search-icon").toggleClass("fa-search fa-times margin-2");
    $("#search-box").toggleClass("show hidden animated fadeInUp");
    return false;
});

// 404 error page smile
// ====================
$("#search-404").focus(function () {
    $("#smile").removeClass("fa-meh-o flipInX");
    $("#smile").addClass("fa-smile-o flipInY");
});

$("#search-404").blur(function () {
    $("#smile").removeClass("fa-smile-o flipInY");
    $("#smile").addClass("fa-meh-o flipInX");
});
//# sourceMappingURL=file1.js.map
