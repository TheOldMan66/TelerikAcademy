(function() {
    var messagesToShow = 20;

    reloadMessages();
    setInterval(reloadMessages, 1000);
    $("#send-btn").on("click", sendMessage);


    function reloadMessages() {
        RemoteControler.get("http://crowd-chat.herokuapp.com/posts")
            .then(function(messages) {
                var len = Math.min(messages.length, messagesToShow);
                var init = Math.max(0, messages.length - messagesToShow - 1);
                var messageFragment = document.createDocumentFragment();
                for (var i = init + len; i > init; i--) {
                    var $message = $("<li>")
                        .attr("id", messages[i].id)
                        .append($("<span>").addClass("by").append(messages[i].by))
                        .append(" say: ")
                        .append($("<span>").addClass("msg").append(messages[i].text))
                        .appendTo(messageFragment);
                }

                $("#messages-list").empty().append(messageFragment);
            })
            .fail(function(err) {
                $("#messages-list").empty().prepend(' error. Retrying... ');
            });
    }

    function sendMessage() {
        var text = $("#chat-input").val();
        var user = $("#username-input").val();
        RemoteControler.post("http://crowd-chat.herokuapp.com/posts", {
            user: user,
            text: text
        });
        reloadMessages();
    }
}())