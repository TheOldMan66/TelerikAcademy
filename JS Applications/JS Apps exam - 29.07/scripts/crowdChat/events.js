define(['jquery', 'logic', 'httpRequest'], function($, logic, httpRequest) {

    $("a").on("click", function() {
        $('.active').removeClass('active');
        $(this).parent().addClass('active');
    });

    $(document).on("click", "#sendButton", function() {
        postMessage();
    });

    $(document).on("click", "#registerButton", function() {
        var sha1 = CryptoJS.SHA1($('#passwdBox').val() + $('#nickNameBox').val()).toString();
        var userData = {
                username: $('#nickNameBox').val(),
                authCode: sha1
            },
            url = 'http://localhost:3000/user',
            contentType = 'application/json',
            acceptType = 'application/json';

        localStorage.setItem("CrowdChatUserName", JSON.stringify(userData));

    });

    $(document).on("click", "#loginButton", function() {
        var sha1 = CryptoJS.SHA1($('#passwdBox').val() + $('#nickNameBox').val()).toString();
        var userData = {
                username: $('#nickNameBox').val(),
                authCode: sha1
            },
            url = 'http://localhost:3000/auth',
            contentType = 'application/json',
            acceptType = 'application/json';

        httpRequest.postJSON(url, contentType, acceptType, JSON.parse(localStorage.getItem("CrowdChatUserName")))
            .then(function(value) {
                console.log(value);
                localStorage.setItem("CrowdChatSessionKey", JSON.stringify(value));
            });
    });

    $(document).on("click", "#logoutButton", function() {
        var key = localStorage.getItem("CrowdChatSessionKey");
        $.ajax({
            url: 'http://localhost:3000/user',
            contentType = 'application/json',
            acceptType = 'application/json';
            beforeSend: function(request) {
                request.setRequestHeader("X-SessionKey", key.sessionKey);
            },
            type: "POST",
            contentType: contentType,
            acceptType: acceptType,
            data: "true",
            success: function(data) {
                deferred.resolve(data);
            },
            error: function(err) {
                deferred.reject(err);
            }
        });

    });


    $(document).on("keyup", "#messageBox", function() {
        if (event.keyCode == 13) {
            postMessage();
        }
    });

    var postMessage = function() {
        var username = JSON.parse(localStorage.getItem("CrowdChatUserName"));

        var message = {
            user: username.username,
            text: $('#messageBox').val()
        };

        logic.postMessage(message);
        $('messageBox').val(' ');
    };
});