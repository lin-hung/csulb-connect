// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('#createEvent').click(function (e) {
        e.preventDefault();
        $("#replace").load("/createevent",
            function () {
                $("#createEventModal").modal('show');
            });
    });
    $('#createGroup').click(function (e) {
        e.preventDefault();
        $("#replace").load("/creategroup",
            function () {
                $("#createGroupModal").modal('show');
            });
    });
    $('.groupcard').click(function (e) {
        var groupId = $(this).attr("id").split("_")[1];
        $("#replace").load("/viewgroup/" + groupId,
            function () {
                $("#groupsmodal").modal('show');
            });
    });
    $('#eventsButton').click(function (e) {
        $("#itemList").load("/listevents");
    });
    $('#groupsButton').click(function (e) {
        $("#itemList").load("/listgroups");
    });
})