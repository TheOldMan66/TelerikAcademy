$(document).ready(function() {
    'use strict';
    $('#colorPicker').on('change', function() {
        $('body').css('background-color', $(this).val());
    })
})