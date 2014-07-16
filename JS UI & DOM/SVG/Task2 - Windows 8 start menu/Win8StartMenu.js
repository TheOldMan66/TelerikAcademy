window.onload = function() {
    'use strict';
    var svgNameSpace = 'http://www.w3.org/2000/svg';
    var svg = document.createElementNS(svgNameSpace, 'svg');
    svg.setAttribute('width', 800);
    svg.setAttribute('height', 600);

    drawImage(0, 0, 800, 600, 'imgs/background.png')
    drawText(70, 70, 36, '#FFF', 'Start');
    drawSimpleButton(70, 100, 90, '#2C84ED', 'imgs/Store.png', 'Store');
    drawSimpleButton(170, 100, 90, '#5CA717', 'imgs/XBOX.png', 'Xbox LIVE Games');
    drawSimpleButton(270, 100, 190, '#B11B41', 'imgs/Photos.png', 'Photos');

    drawSimpleButton(70, 200, 90, '#5434AD', 'imgs/Maps.png', 'Maps');
    drawSimpleButton(170, 200, 90, '#2778EB', 'imgs/IE.png', 'Internet Explorer');
    drawSimpleButton(270, 200, 190, '#5836B1', 'imgs/Messages.png', 'Messaging');


    drawText(100,350,12,'yellow','First and second task are realized using pure SVG DOM API in JS - according to Task 3 requirement.')
    drawText(100,370,12,'yellow','Sory, but I have no time to slice and dice more icons... I have teamwork to do :) ')

    document.body.appendChild(svg);



    function drawImage(x, y, w, h, name) {
        var image = document.createElementNS(svgNameSpace, 'image');
        image.setAttribute('x', x);
        image.setAttribute('y', y);
        image.setAttribute('width', w);
        image.setAttribute('height', h);
        image.setAttribute('preserveAspectRatio', 'none');
        image.setAttributeNS("http://www.w3.org/1999/xlink", 'xlink:href', name);
        svg.appendChild(image);
    }

    function drawText(x, y, size, color, txt) {
        var text = document.createElementNS(svgNameSpace, 'text');
        text.setAttribute('x', x);
        text.setAttribute('y', y);
        text.setAttribute('font-size', size);
        text.setAttribute('fill', color);
        text.setAttribute('font-weight', 'lighter');
        text.setAttribute('font-family', 'Segoe WP SemiLight');
        text.textContent = txt;
        svg.appendChild(text);
    }

    function drawSimpleButton(x, y, width, color, image, name) {
        var button = document.createElementNS(svgNameSpace, 'rect');
        button.setAttribute('x', x);
        button.setAttribute('y', y);
        button.setAttribute('width', width);
        button.setAttribute('height', 90);
        button.setAttribute('fill', color);
        svg.appendChild(button);
        drawImage(x - 25 + (width - 20) / 2, y + 10, 70, 60, image)
        drawText(x + 10, y + 80, 10, '#FFF', name)
    }

}