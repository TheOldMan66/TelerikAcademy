var SnakeGame = SnakeGame || {};
SnakeGame.Snake = (function() {
    'use strict';
    var snakeBody = [],
        snakeLength = 100,
        feedCounter = 0;

    // snake initialization
    snakeBody.push({
        x: parseInt(SnakeGame.Board.Size().x / 2),
        y: parseInt(SnakeGame.Board.Size().y / 2),
        dx: 1,
        dy: 0
    });
    snakeBody.push({
        x: parseInt(SnakeGame.Board.Size().x / 2) - snakeLength,
        y: parseInt(SnakeGame.Board.Size().y / 2),
        dx: 1,
        dy: 0
    });

    function BiteYourself() {
        for (var i = 2; i < snakeBody.length; i++) {
            if ((snakeBody[0].x == snakeBody[i].x &&
                    snakeBody[0].y > Math.min(snakeBody[i - 1].y, snakeBody[i].y) &&
                    snakeBody[0].y < Math.max(snakeBody[i - 1].y, snakeBody[i].y)) ||
                (snakeBody[0].y == snakeBody[i].y &&
                    snakeBody[0].x > Math.min(snakeBody[i - 1].x, snakeBody[i].x) &&
                    snakeBody[0].x < Math.max(snakeBody[i - 1].x, snakeBody[i].x))) {
                return true;
            };
        };
        return false;
    }

    function Move() {
        var lastSnakeJoint = snakeBody[snakeBody.length - 2],
            snakeEnd = snakeBody[snakeBody.length - 1];

        snakeBody[0].x += snakeBody[0].dx;
        snakeBody[0].y += snakeBody[0].dy;

        if (feedCounter === 0) {
            snakeBody[snakeBody.length - 1].x += snakeBody[snakeBody.length - 2].dx;
            snakeBody[snakeBody.length - 1].y += snakeBody[snakeBody.length - 2].dy;
        } else {
            feedCounter--;
        }

        if (lastSnakeJoint.x === snakeEnd.x &&
            lastSnakeJoint.y === snakeEnd.y) {
            snakeBody.pop();
        }
    }

    function Turn(dx, dy) {
        snakeBody.unshift({
            x: snakeBody[0].x,
            y: snakeBody[0].y,
            dx: dx,
            dy: dy
        });
    }

    function HeadPos() {
        return {
            x: snakeBody[0].x,
            y: snakeBody[0].y
        };
    }

    function Grow(size) {
        feedCounter = size;
        snakeLength += size;
    }

    function GetLength() {
        return snakeLength;
    }

    function Draw(context) {
        context.beginPath();
        context.moveTo(snakeBody[0].x, snakeBody[0].y);
        for (var i = 0; i < snakeBody.length; i++) {
            context.lineTo(snakeBody[i].x, snakeBody[i].y);
        }

        context.stroke();
    }

    return {
        BiteYourself: BiteYourself,
        HeadPos: HeadPos,
        Move: Move,
        Turn: Turn,
        Grow: Grow,
        Draw: Draw,
        GetLength: GetLength
    }

})();