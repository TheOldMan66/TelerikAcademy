$.fn.gallery = function(columns) {
    'use strict';
    var currentImage = null;
    columns = columns || 4;
    columns = parseFloat(columns);
    var $this = this;
    this.addClass('gallery');
    $('div:nth-child(' + (columns) + 'n+1)').addClass('clearfix');
    $('.selected').hide();

    $('.image-container')
        .on('click', function() {
            var $this = $(this);
            if ($this.parent().hasClass('blurred')) {
                return;
            };
            $('.gallery-list').addClass('blurred');
            $('.selected .previous-image img')[0].src = getPrev($this).find('img')[0].src;
            $('.selected .current-image img')[0].src = $this.find('img')[0].src;
            $('.selected .next-image img')[0].src = getNext($this).find('img')[0].src;
            currentImage = this;
            $('.selected').show();
        })


    $('.current-image')
        .on('click', function() {
            var $this = $(this);
            $('.selected').hide();
            currentImage = null;
            $('.gallery-list').removeClass('blurred');
        })

    $('.previous-image')
        .on('click', function() {
            var $this = $(this);
            $('.selected .next-image img')[0].src = $(currentImage).find('img')[0].src;
            $('.selected .current-image img')[0].src = getPrev($(currentImage)).find('img')[0].src;
            $('.selected .previous-image img')[0].src = getPrev(getPrev($(currentImage))).find('img')[0].src;
            currentImage = getPrev($(currentImage));

        })

    $('.next-image')
        .on('click', function() {
            var $this = $(this);
            $('.selected .previous-image img')[0].src = $(currentImage).find('img')[0].src;
            $('.selected .current-image img')[0].src = getNext($(currentImage)).find('img')[0].src;
            $('.selected .next-image img')[0].src = getNext(getNext($(currentImage))).find('img')[0].src;
            currentImage = getNext($(currentImage));

        })


    function getPrev(current) {
        var prev;
        if (current.prev().length > 0) {
            prev = current.prev();
        } else {
            prev = $('.image-container').last();
        }
        return prev;
    }

    function getNext(current) {
        var next;
        if (current.next().length > 0) {
            next = current.next();
        } else {
            next = $('.image-container').first();
        }
        return next;
    }

}