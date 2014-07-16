(function() {
    'use strict';

    require.config({
        paths: {
            "handlebars": "libs/handlebars.min",
            "comboBox": "comboBox",
            "data": "data"
        },
        shim: {
            'handlebars': {
                exports: 'Handlebars'
            }
        }
    });

    require(["data", "combobox"], function(data, ComboBox) {
        var container, comboBox;

        comboBox = new ComboBox({
            people: data
        });
        container = comboBox.render('cbTemplate', 'person-item');

        document.body.appendChild(container);
    });

}());