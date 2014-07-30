define(['httpRequest', "ui"], function(httpRequest, ui) {
    var dataLength,
        currentPage;
    url = 'http://localhost:3000/user',
    contentType = 'application/json',
    acceptType = 'application/json';

    var registerUser = function() {
        ui.userDetails();
        var username = localStorage.getItem("CrowdChatUserName");
        var message = {
            user: username,
            text: $('#messageBox').val()
        };
        currentPage = "main";
    };

    var userLogin = function() {
        ui.login();
        currentPage = "login";
    }

    var userLogout = function() {
        ui.logout();
        currentPage = "logout";
    }
    var initMainPage = function() {
        ui.initMainPage();
        currentPage = "chat";
    };

    var initChatPage = function() {
        getChatFeed();
        currentPage = "chat";
    };

    var initAboutPage = function() {
        ui.initAboutPage();
        currentPage = "about";
    };

    var postMessage = function(message) {
        httpRequest.postJSON(url, contentType, acceptType, message)
            .then(getChatFeed())
            .then(getChatFeed());
    };

    var getChatFeed = function() {
        httpRequest.getJSON(url, contentType, acceptType)
            .then(function(data) {
                dataLength = data.length;
                ui.initChatPage(data);
            }, function(err) {
                ui.showError(err);
            });
    };


    var refresh = setInterval(function() {
            var url = 'http://localhost:3000/post',
                contentType = 'application/json',
                acceptType = 'application/json';

            httpRequest.getJSON(url, contentType, acceptType)
                .then(function(data) {
                        if (dataLength !== data.length && currentPage === 'chat') {
                            ui.setMessageFeed(data);
                        }
                        dataLength = data.length;
                    },
                    function(err) {
                        ui.showError(err);
                    });
        },
        1000);

    return {
        userLogin: userLogin,
        registerUser: registerUser,
        initChatPage: initChatPage,
        initAboutPage: initAboutPage,
        postMessage: postMessage
    };
});