define(['handlebars'], function(Handlebars) {
    'use strict';

    var id = 0,
        selected = [];

    var ComboBox = function(data) {
        id += 1;
        this.data = data;
        this.id = id;
        selected[this.id] = null;
    };

    ComboBox.prototype.render = function(templateId, itemClass) {
        var templateString,
            template,
            resultHTML,
            container;

        templateString = document.getElementById(templateId).innerHTML;
        template = Handlebars.compile(templateString);

        resultHTML = template(this.data);

        container = document.createElement('div');
        container.innerHTML = resultHTML;

        eventhandlingSetup(container, itemClass, this.id);

        return container;
    };

    var eventhandlingSetup = function(container, itemClass, generatedId) {
        var items = container.getElementsByClassName(itemClass);

        for (var i = 0, len = items.length; i < len; i += 1) {
            if (i === 0) {
                items[i].style.display = 'block';
                selected[generatedId] = items[i];
            } else {
                items[i].style.display = 'none';
            }

            items[i].addEventListener('click', function() {
                if (selected[generatedId] === this) {
                    selected[generatedId] = null;
                    revealAll();
                } else if (selected[generatedId] === null) {
                    selected[generatedId] = this;
                    hideOthers(selected[generatedId]);
                }
            });
        }

        function revealAll() {
            for (var i = 0, len = items.length; i < len; i += 1) {
                items[i].style.display = 'block';
            }
        }

        function hideOthers(selectedItem) {
            for (var i = 0, len = items.length; i < len; i += 1) {
                if (items[i] === selectedItem) {
                    continue;
                }

                items[i].style.display = 'none';
            }
        }
    };

    return ComboBox;
});