$(document).ready(function() {
    'use strict';
    $('#wrapper').find('.movable')
        .on('click', function() {
            var $this = $(this);
            $('#wrapper').find('#selected').removeAttr('id');
            $this.attr('id', 'selected');
        })
    $('body').find('#addBtn')
        .on('click', function() {
            if ($('input[name=position]:checked').val() == 'Before') {
                $('#wrapper').find('#selected')
                    .before('<div>' + $('#text').val() + '</div>');
            } else {
                $('#wrapper').find('#selected')
                    .after('<div>' + $('#text').val() + '</div>');

            }
        })
})