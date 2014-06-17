window.onload = function() {
    'use strict';
    var paper = Raphael(10, 10, 1000, 500);
    var numOfTurns = 10;
    var precision = 25;
    var startX = 200;
    var startY = 200;
    var gap = 10;
    var endRadius = 0;
    var coords = [];

    for (var j = precision; j <= 360 * numOfTurns; j = j + precision) {
        endRadius = endRadius + gap / 360 * precision;
        coords.push(startX + endRadius * Math.cos(j * Math.PI / 180));
        coords.push(startY + endRadius * Math.sin(j * Math.PI / 180));
    };

    var sequence = 'M ' + startX + ' ' + startY + ' T ' + coords.join(' ');
    var spiral = paper.path(sequence);

    var startX = 500;
    var endRadius = 0;
    for (var j = precision; j <= 360 * numOfTurns; j = j + 1) {
        endRadius = endRadius + gap / 360;
        var circle = paper.circle(
            startX + endRadius * Math.cos(j * Math.PI / 180),
            startY + endRadius * Math.sin(j * Math.PI / 180),
            1);
    };
    paper.text(200, 320, 'Spiral made by series of arcs').attr({
        "font-size": "20"
    });
    paper.text(500, 320, 'Spiral made by series of cicles').attr({
        "font-size": "20"
    });
}