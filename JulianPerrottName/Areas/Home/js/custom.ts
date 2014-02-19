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
$("#search-404").focus( () => {
    $("#smile").removeClass("fa-meh-o flipInX");
    $("#smile").addClass("fa-smile-o flipInY");
});

$("#search-404").blur(() => {
    $("#smile").removeClass("fa-smile-o flipInY");
    $("#smile").addClass("fa-meh-o flipInX");
});

var site = site || {};
site.baseUrl = site.baseUrl || "";

$(document).ready(function (e) {

    // locate each partial section.
    // if it has a URL set, load the contents into the area.

    var cnt: number = 0;

    $(".partialContents").each(function (index, item) {
        if (cnt == 10) { return; }
        var url = site.baseUrl + $(item).data("url");
        if (url && url.length > 0) {
            cnt++;
            $(item).load(url);
        }
    });
});
