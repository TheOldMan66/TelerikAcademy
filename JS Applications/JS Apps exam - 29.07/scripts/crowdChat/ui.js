define(['jquery', 'handlebars'], function($) {


    var userDetails = function() {
        clearPage();

        var h2 = $('<h2></h2>').text('Crowd share register'),
            div = $('<div> </div>').attr('id', 'nickname-containter').addClass('nickname-containter'),

            label = $('<label></label>').text('Select nickname:'),
            nickName = $('<input type="text" />').attr('id', 'nickNameBox').addClass('nickNameBox').height('29px').width('25%'),
            label2 = $('<label></label>').text('Select password:'),
            passwd = $('<input type="text" />').attr('id', 'passwdBox').addClass('passwdBox').height('29px').width('25%'),
            confirmButton = $('<button> </button>').attr('id', 'registerButton').addClass('k-primary').height('29px').width('10%').text('Confirm')

        div.append(h2).append(label).append(nickName).append(label2).append(passwd).append(confirmButton);
        $('#main-content').append(div);

        setActive($('#registerLink'));
    };

    var login = function() {
        clearPage();
        var name = JSON.parse(localStorage.getItem("CrowdChatUserName")).username;

        var h2 = $('<h2></h2>').text('Crowd share login'),
            div = $('<div> </div>').attr('id', 'nickname-containter').addClass('nickname-containter'),

            label = $('<label></label>').text('Login with nickname: ' + name),
            confirmButton = $('<button> </button>').attr('id', 'loginButton').addClass('k-primary').height('29px').width('10%').text('Confirm')

        div.append(h2).append(label).append(confirmButton);
        $('#main-content').append(div);

        setActive($('#LoginLink'));
    };

    var logout = function() {
        clearPage();

        var h2 = $('<h2></h2>').text('Crowd share logout'),
            div = $('<div> </div>').attr('id', 'nickname-containter').addClass('nickname-containter'),

            label = $('<label></label>').text('Logout : ' + name),
            confirmButton = $('<button> </button>').attr('id', 'logoutButton').addClass('k-primary').height('29px').width('10%').text('Confirm')

        div.append(h2).append(label).append(confirmButton);
        $('#main-content').append(div);

        setActive($('#LogoutLink'));
    };


    var initChatPage = function(chatItems) {
        clearPage();

        var username = localStorage.getItem('CrowdChatUserName');

        if (username) {
            addChatArea();
            setMessageFeed(chatItems);
            $('#messageBox').focus();
            setActive($('#chatLink'));
        } else {
            $('#main-content').text('Please choose nickname on home page!');
        }
    };

    var initAboutPage = function() {
        clearPage();

        var h2 = $('<h2></h2>').text('Crowd chat SPA develop by ME :)');
        $('#main-content').append(h2);
        setActive($('#aboutLink'));
    };

    var clearPage = function() {
        $('#main-content').text(' ');
    };

    var showError = function(err) {
        $('#main-content').text('Error');
    };

    var setMessageFeed = function(items) {
        $('feed-container').html(' ');
        //        $('#main-content').html(' ');
        var chatItems = [],
            div = $('<div> </div>').attr('id', 'feed-container').addClass('feed-container');

        items.reverse();
        items.forEach(function(item) {
            var newText,
                newBy;

            newText = item.text.replace(/&nbsp;/gi, ' ').replace(/&#39/g, "'");
            newBy = item.by.replace(/&nbsp;/gi, ' ').replace(/&#39/g, "'");

            chatItems.push({
                text: newText,
                by: newBy
            });
        });

        $('#main-content').append(div);

        handleBarConvert($("#chat-template"), $('#feed-container'), chatItems);
    };

    var handleBarConvert = function(template, container, items) {
        var currentTemplate = Handlebars.compile(template.html());

        container.html(currentTemplate({
            message: items
        }));
    };

    var addChatArea = function() {
        var div = $('<div> </div>')
            .attr('id', 'chat-area')
            .addClass('chat-area'),
            sendButton = $('<button> </button>')
            .attr('id', 'sendButton')
            .addClass('k-primary')
            .height('29px')
            .width('10%')
            .text('Send')
        messageBox = $('<input type="text" />')
            .attr('id', 'messageBox')
            .addClass('messageBox')
            .height('29px')
            .width('89%')

        div.append(messageBox);
        div.append(sendButton);
        $('#main-content').append(div);
    };

    var setActive = function(selector) {
        $('.active').removeClass('active');
        selector.addClass('active');
    };

    return {
        logout: logout,
        login: login,
        userDetails: userDetails,
        initChatPage: initChatPage,
        initAboutPage: initAboutPage,
        showError: showError,
        setMessageFeed: setMessageFeed
    };
});