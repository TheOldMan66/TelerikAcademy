$(document).ready(function() {
    'use strict';

    function GridView() {
        this.$table = $('<table></table>')
    }

    GridView.prototype.AddHeader = function() {
        if (this.$table.find('th').length == 0) {
            var $header = $('<tr></tr>');
            for (var i = 0; i < arguments.length; i++) {
                $header.append($('<th>' + arguments[i] + '</th>'));
            }
            $header.appendTo(this.$table);
        }
    }

    GridView.prototype.AddRow = function() {
        var $row = $('<tr></tr>');
        for (var i = 0; i < arguments.length; i++) {
            if (arguments[i].constructor.name == 'GridView') {
                arguments[i].PlaceIn($row);
            } else {
                $row.append($('<td>' + arguments[i] + '</td>'));
            }
        }
        $row.appendTo(this.$table);
    }

    GridView.prototype.PlaceIn = function(container) {
        if (container == undefined) {
            container = $('body');
        };
        container.append(this.$table);
    };

    var mostInnerGrid = new GridView();
    mostInnerGrid.AddHeader(1, 2, 3, 4, 5);
    mostInnerGrid.AddRow(6, 7, 8, 9, 10);
    mostInnerGrid.AddRow(11, 12, 13, 14, 15);

    var innerGrid = new GridView();
    innerGrid.AddHeader('Inner Head 1', 'Inner Head 2', 'Inner Head 3');
    innerGrid.AddRow('Inner cell 1 1', 'Inner cell 2 1', 'Inner cell 3 1');
    innerGrid.AddRow('Inner cell 1 2', 'Inner cell 2 2', 'Inner cell 3 2');
    innerGrid.AddRow('Inner cell 1 3', 'Inner cell 2 3', mostInnerGrid);

    var middleGrid = new GridView();
    middleGrid.AddHeader('Middle Head 1', 'Middle Head 2', 'Middle Head 3');
    middleGrid.AddRow('Middle cell 1 1', 'Middle cell 2 1', 'Middle cell 3 1');
    middleGrid.AddRow('Middle cell 1 2', innerGrid, 'Middle cell 3 2');
    middleGrid.AddRow('Middle cell 1 3', 'Middle cell 2 3', 'Middle cell 3 3');


    var outherGrid = new GridView();
    outherGrid.AddHeader('Outher Head 1', 'Outher Head 2', 'Outher Head 3');
    outherGrid.AddRow('Outher cell 1 1', 'Outher cell 2 1', 'Outher cell 3 1');
    outherGrid.AddRow('Outher cell 1 2', middleGrid, 'Outher cell 3 2');
    outherGrid.AddRow('Outher cell 1 3', 'Outher cell 2 3', 'Outher cell 3 3');

    outherGrid.PlaceIn($('#wrapper'));
});