// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('.groupcard').click(function (e) {
        var groupId = $(this).attr("id").split("_")[1];
        $("#replace").load("/viewgroup/" + groupId,
            function () {
                $("#groupsmodal").modal('show');

            });
    });
})