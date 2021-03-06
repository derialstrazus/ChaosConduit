﻿const redirectHere = "/lobby.html";
const announcementsArr = [
    "Across the lands, I am known as:",
    "They see me rollin', they screamin':",
    "When I'm in the club the hotties call me:",
    "...:",
    "Please mail the check to:"
];

function initializeLogin() {
    if (Cookie.Get("ID") !== null && Cookie.Get("ID") !== undefined && Cookie.Get("ID") !== "") {
        window.location.href = redirectHere;
    }

    var announcement = announcementsArr[Math.floor(Math.random() * announcementsArr.length)];
    $("#divLoginInput label").empty();
    $("#divLoginInput label").append(announcement);

    $("#submitUsername").click(function (e) {
        var username = $("#usernameInput").val();
        var passThis = { '': username }
        APIPost("api/authentication", passThis, loginSuccess, loginFailure);
    });
}

function loginSuccess(data) {
    if (data.ID !== null && data.ID !== undefined) {
        Cookie.Set("ID", data.ID);
        Cookie.Set("Name", data.Name);

        window.location.href = redirectHere;
    } else {
        alert("No GUID returned");
    }
}

function loginFailure(xhr, status, error) {
    var message = "Login failed.  Server says: " + xhr.responseJSON.ExceptionMessage;
    alert(message);
}