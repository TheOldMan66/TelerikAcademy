(function($) {
    'use strict';
    $.fn.dropdown = function() {
        var originalSelect = this;
        var container = $('<div></div>');
        container.addClass('dropdown-list-container');
        var generatedUL = $('<ul></ul>');
        generatedUL.addClass('dropdown-list-options');
        $.each(originalSelect.find('option'), function(index, currentOption) {
            var li = $('<li></li>');
            li.append(currentOption.text);
            li.addClass('dropdown-list-option');
            li.attr('data-value', currentOption.value);
            if (currentOption.selected) {
                li.attr('id', 'selected');
                li.css('background-color', 'yellow');
            };
            li.appendTo(generatedUL);
        });
        container.append(generatedUL);
        $('body').append(container);

        $('.dropdown-list-options li').on('click', function() {
            var $this = $(this);
            $this.parent().find('#selected').removeAttr('id').removeAttr('style');
            $this.attr('id', 'selected').css('background-color', 'yellow');

            originalSelect.find('option:selected').removeAttr('selected')
            originalSelect.find('option[value=' + $this.data('value') + ']').attr('selected', 'selected');
        })
    }
})(jQuery)

$('#dropdown').dropdown();