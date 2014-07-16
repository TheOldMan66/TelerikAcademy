var movingShapes = (function() {
    var divs = [],
        step = 1,
        minX = 100,
        maxX = 500,
        minY = 100,
        maxY = 300,
        centerX = minX + (maxX - minX) / 2,
        centerY = minY + (maxY - minY) / 2,
        radiusX = centerX - minX,
        radiusY = centerY - minY,
        angularStep = (2 * Math.PI) / ((maxX - minX) * 2 + (maxY - minY) * 2);

    function getRandom(min, max) {
        if (min == undefined) {
            min = 0;
            max = 255;
        } else if (max == undefined) {
            max = min;
            min = 0;
        }
        return parseInt(Math.random() * (max - min) + min);
    }

    function getRandomColor() {
        return 'rgb(' + getRandom() + ',' + getRandom() + ',' + getRandom() + ')';
    }

    function generateDiv(typeOfMoving) {
        var div = document.createElement('div'),
            element = {};
        div.innerHTML = 'DIV';
        div.style.width = '60px';
        div.style.height = '20px';
        div.style.backgroundColor = getRandomColor();
        div.style.borderColor = getRandomColor();
        div.style.border = '2px solid ' + getRandomColor();
        document.body.appendChild(div);
        element.div = div;
        element.posX = minX + (maxX - minX) / 2;
        element.posY = minY;
        if (typeOfMoving == 'rect') {
            element.dX = 1;
            element.dY = 0;
            element.calculateStep = calculateRectangularStep;
        } else {
            element.dX = 0;
            element.calculateStep = calculateElipticalStep;
        }
        divs.push(element);
    }


    function calculateRectangularStep() {
        this.posX = this.posX + this.dX * step;
        this.posY = this.posY + this.dY * step;
        if (this.posX > maxX) {
            this.posX = maxX;
            this.dX = 0;
            this.dY = 1;
        };
        if (this.posY > maxY) {
            this.posY = maxY;
            this.dX = -1;
            this.dY = 0;
        };
        if (this.posX < minX) {
            this.posX = minX;
            this.dX = 0;
            this.dY = -1;
        };
        if (this.posY < minY) {
            this.posY = minY;
            this.dX = 1;
            this.dY = 0;
        };
    }

    function calculateElipticalStep() {
        this.dX = this.dX + angularStep;
        if (this.dX > 2 * Math.PI) {
            this.dX = 0;
        };
        this.posX = centerX + Math.sin(this.dX) * radiusX;
        this.posY = centerY - Math.cos(this.dX) * radiusY;
    }

    function move() {
        for (var i = 0; i < divs.length; i++) {
            divs[i].calculateStep()
            divs[i].div.style.left = divs[i].posX + 'px';
            divs[i].div.style.top = divs[i].posY + 'px';
        };
    }

    setInterval(move, 10);

    function add(typeOfMoving) {
        var aDiv = generateDiv(typeOfMoving);
    }

    return {
        add: add
    }
})();