$(document).ready(function() {
    'use strict';
    $('#wrapper').find('#leftArrow')
        .on('click', function() {
            var $prev = $('#container').find('#selected')
                .toggle(500)
                .removeAttr('id')
                .prev('.albumImage');
            if ($prev.length != 0) {
                $prev
                    .attr('id', 'selected')
                    .toggle(500);
            } else {
                $('#container').find('.albumImage').last()
                    .attr('id', 'selected')
                    .toggle(500);
            }
        })

    $('#wrapper').find('#rightArrow')
        .on('click', function() {
            var $next = $('#container').find('#selected')
                .toggle(500)
                .removeAttr('id')
                .next('.albumImage');
            if ($next.length != 0) {
                $next
                    .attr('id', 'selected')
                    .toggle(500);
            } else {
                $('#container').find('.albumImage').first()
                    .attr('id', 'selected')
                    .toggle(500);
            }
        })

    $('#slideshow')
        .on('click', function() {
            setInterval(function() {
                $('#wrapper').find('#leftArrow').click()
            }, 5000)
        })

    $('#container').find('#selected').toggle();
})