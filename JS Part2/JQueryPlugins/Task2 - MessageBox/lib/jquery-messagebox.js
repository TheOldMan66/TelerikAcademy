(function($) {
    'use strict';
    $.fn.messagebox = function(container) {

        //        var container = $('<div>asd</div>');
        var container = this;
        this.backgroundColor = 'red';
        container.success = success;
        container.error = error;


        //        container.fade();

        return container;

        function success(message) {
            container.html(message);
            container.hide();
            container.css('background-color', 'green')
            container.fadeIn(1000).fadeOut(1000).
            fadeIn(1000).fadeOut(1000).
            fadeIn(1000).fadeOut(1000, function() {
                container.html('');
            })
        }

        function error(message) {
            container.html(message);
            container.hide();
            container.css('background-color', 'red')
            container.fadeIn(1000).fadeOut(1000).
            fadeIn(1000).fadeOut(1000).
            fadeIn(1000).fadeOut(1000, function() {
                container.html('');

            });
        }
    }

})(jQuery)

var msgBox = $('#message-box').messagebox();
msgBox.success('success');
var msgBox2 = $('#message-box2').messagebox();
msgBox2.error('error');