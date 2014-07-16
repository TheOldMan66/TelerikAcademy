window.onload = function() {
    'use strict';
    var paper = Raphael(10, 10, 400, 400);
    var logo = paper.path("M30 30 L50 10 L90 50 L70 70 L50 50 L90 10 L110 30");
    logo.attr({
        'stroke-width': '10',
        stroke: '#5CE600'
        //        fill: 'green'
    })

    var telerik = paper.text(120, 40, "Telerik").attr({
        "font-family": "Segoe UI",
        "font-weight": "bold",
        'text-anchor': 'start',
        "font-size": "60"
    })

    var reserved = paper.text(315, 35, String.fromCharCode(174)).attr({
        "font-family": "Segoe UI",
        "font-weight": "bold",
        'text-anchor': 'start',
        "font-size": "20"
    })

    var develop = paper.text(130, 80, 'Develop experiences').attr({
        "font-family": "Segoe UI",
        "font-size": "24",
        'text-anchor': 'start'
    })

    var youTubeRect = paper.rect(200, 160, 135, 85, 20);
    youTubeRect.attr({
        fill: '#EC2727',
        stroke: '#EC2727'
    })

    var youTubeText1 = paper.text(100, 200, 'You').attr({
        "font-family": "Arial",
        "font-size": "48",
        "widht": "100",
        "font-weight": "bold",
        fill: '#666',
        stroke: '#666',
        'text-anchor': 'start'
    }).transform('s1,1.75')

    var youTubeText2 = paper.text(210, 200, 'Tube').attr({
        "font-family": "Arial",
        "font-size": "48",
        "widht": "100",
        "fill": 'white',
        "font-weight": "bold",
        'text-anchor': 'start'
    }).transform('s1,1.75')
}