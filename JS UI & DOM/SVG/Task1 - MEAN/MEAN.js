window.onload = function() {
    'use strict';
    var svgNameSpace = 'http://www.w3.org/2000/svg';
    var svg = document.createElementNS(svgNameSpace, 'svg');
    svg.setAttribute('width', 200);
    svg.setAttribute('height', 400);
    document.body.appendChild(svg);
    drawCircle(130, 50, '#333');
    drawImage(130, 50, 70, 70, 'imgs/mongodb.png');
    drawText(20, 55, 48, '#333', 'M');

    drawCircle(130, 105, 'black');
    drawText(85, 105, 24, '#FFF', 'express');
    drawText(20, 110, 48, '#000', 'E');

    drawCircle(130, 160, '#E52A3A');
    drawAngular(95, 125, 0.4);
    drawText(20, 165, 48, '#E52A3A', 'A');

    drawCircle(130, 215, '#8EC74E');
    drawNode(94, 195, .18);
    drawText(20, 220, 48, '#8EC74E', 'N');

    function drawNode(x, y, scale) {
        var group = document.createElementNS("http://www.w3.org/2000/svg", "g");
        x = x / scale;
        y = y / scale;
        var path = document.createElementNS(svgNameSpace, 'path');
        var points = 'M' + x + ' ' + y + ' m299 0c0 0 -1 0 -1 0 -1 0 -1 1 -1 2l0 61c0 1 0 1 -1 1 -1 0 -1 0 -2 0l-10 -6c-1 -1 -3 -1 -5 0l-40 23c-1 1 -2 3 -2 4l0 46c0 2 1 3 2 4l40 23c1 1 3 1 5 0l40 -23c1 -1 2 -2 2 -4l0 -114c0 -2 -1 -3 -2 -4l-26 -11c0 0 -1 0 -1 0zm-17 92c0 0 0 0 1 0l14 8c0 0 1 1 1 1l0 16c0 0 0 1 -1 1l-14 8c0 0 -1 0 -1 0l-14 -8c0 0 -1 -1 -1 -1l0 -16c0 0 0 -1 1 -1l14 -8c0 0 0 0 1 0z';
        path.setAttribute('fill', '#404137');
        path.setAttribute('d', points);
        group.appendChild(path);

        path = document.createElementNS(svgNameSpace, 'path');
        points = 'M' + x + ' ' + y + ' m44 57c-1 0 -1 0 -2 1l-40 23c-1 1 -2 2 -2 4l0 61c0 1 0 2 1 2 1 0 2 0 2 0l23 -13c1 -1 2 -2 2 -4l0 -29c0 -2 1 -3 2 -4l10 -6c1 0 2 -1 2 -1 1 0 2 0 2 1l10 6c1 1 2 2 2 4l0 29c0 2 1 3 2 4l23 13c1 0 2 0 2 0 1 0 1 -1 1 -2l0 -61c0 -2 -1 -3 -2 -4l-40 -23c-1 0 -1 -1 -2 -1l0 0z';
        path.setAttribute('fill', '#404137');
        path.setAttribute('d', points);
        group.appendChild(path);

        path = document.createElementNS(svgNameSpace, 'path');
        points = 'M' + x + ' ' + y + ' m400 58c-1 0 -2 0 -2 1l-40 23c-1 1 -2 2 -2 4l0 46c0 2 1 3 2 4l39 22c1 1 3 1 5 0l24 -13c1 0 1 -1 1 -2 0 -1 0 -2 -1 -2l-40 -23c-1 0 -1 -1 -1 -2l0 -14c0 -1 1 -2 1 -2l12 -7c1 0 2 0 2 0l12 7c1 0 1 1 1 2l0 11c0 1 0 2 1 2 1 0 2 0 2 0l24 -14c1 -1 2 -2 2 -4l0 -11c0 -2 -1 -3 -2 -4l-39 -23c-1 0 -2 -1 -2 -1z';
        path.setAttribute('fill', '#404137');
        path.setAttribute('d', points);
        group.appendChild(path);

        path = document.createElementNS(svgNameSpace, 'path');
        points = 'M' + x + ' ' + y + ' m163 58c-1 0 -2 0 -2 1l-40 23c-1 1 -2 2 -2 4l0 46c0 2 1 3 2 4l40 23c1 1 3 1 5 0l40 -23c1 -1 2 -2 2 -4l0 -46c0 -2 -1 -3 -2 -4l-40 -23c-1 0 -2 -1 -2 -1z';
        path.setAttribute('fill', '#ffffff');
        path.setAttribute('d', points);
        group.appendChild(path);

        path = document.createElementNS(svgNameSpace, 'path');
        points = 'M' + x + ' ' + y + ' m399 98c0 0 0 0 0 0l-8 4c0 0 0 0 0 1l0 9c0 0 0 1 0 1l8 4c0 0 1 0 1 0l8 -4c0 0 0 0 0 -1l0 -9c0 0 0 -1 0 -1l-8 -4c0 0 0 0 0 0z';
        path.setAttribute('fill', '#ffffff');
        path.setAttribute('d', points);
        group.appendChild(path);
        group.setAttribute('transform', 'scale(' + scale + ',' + scale + ')');

        svg.appendChild(group);


    }

    function drawAngular(x, y, scale) {
        var group = document.createElementNS("http://www.w3.org/2000/svg", "g");
        x = x / scale;
        y = y / scale;
        var path = document.createElementNS(svgNameSpace, 'path');
        var points = 'M' + x + ' ' + y + ' m83 1 l-82 29 13 108 69 39 70 -39 13 -109z';
        path.setAttribute('fill', '#B3B3B3');
        path.setAttribute('d', points);
        group.appendChild(path);

        path = document.createElementNS(svgNameSpace, 'path');
        points = 'M' + x + ' ' + y + ' m158 36 l-75 -26 0 157 63 -34z';
        path.setAttribute('fill', '#A6120D');
        path.setAttribute('d', points);
        group.appendChild(path);

        path = document.createElementNS(svgNameSpace, 'path');
        points = 'M' + x + ' ' + y + ' m10 36 l11 97 62 34 0 -157z';
        path.setAttribute('fill', '#DD1B16');
        path.setAttribute('d', points);
        group.appendChild(path);

        path = document.createElementNS(svgNameSpace, 'path');
        points = 'M' + x + ' ' + y + ' m104 94 l-21 10h-22l-10 26l-19 0l51 -114l21 78zm-2 -5l-19 -37l-15 36h15l19 1z';
        path.setAttribute('fill', '#F2F2F2');
        path.setAttribute('d', points);
        group.appendChild(path);

        path = document.createElementNS(svgNameSpace, 'path');
        points = 'M' + x + ' ' + y + ' m83 16 l0 36 17 36 -17 0 0 16 24 0 11 26 19 0z';
        path.setAttribute('fill', '#B3B3B3');
        path.setAttribute('d', points);
        group.appendChild(path);
        group.setAttribute('transform', 'scale(' + scale + ',' + scale + ')');
        svg.appendChild(group);
    }

    function drawCircle(x, y, color) {
        var circle = document.createElementNS(svgNameSpace, 'circle');
        circle.setAttribute('cx', x);
        circle.setAttribute('cy', y);
        circle.setAttribute('r', 50);
        circle.setAttribute('fill', color)
        svg.appendChild(circle);
    }

    function drawImage(x, y, w, h, name) {
        var image = document.createElementNS(svgNameSpace, 'image');
        image.setAttribute('x', x - w / 2);
        image.setAttribute('y', y - h / 2);
        image.setAttribute('width', w);
        image.setAttribute('height', h);
        image.setAttributeNS("http://www.w3.org/1999/xlink", 'xlink:href', name);
        svg.appendChild(image);
    }

    function drawText(x, y, size, color, txt) {
        var text = document.createElementNS(svgNameSpace, 'text');
        text.setAttribute('x', x);
        text.setAttribute('y', y + 5);
        text.setAttribute('font-size', size);
        text.setAttribute('fill', color);
        text.setAttribute('font-family', 'Consolas');
        text.textContent = txt;
        svg.appendChild(text);
    }
};