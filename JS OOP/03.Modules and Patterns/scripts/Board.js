var SnakeGame = SnakeGame || {};
SnakeGame.Board = (function() {
    'use strict';
    var boardWidth = 600,
        boardHeight = 400,
        canvas,
        context;

    //board initialization
    canvas = document.createElement('canvas');
    canvas.width = boardWidth;
    canvas.height = boardHeight;
    canvas.style.border = '1px solid black';
    document.body.appendChild(canvas);
    context = canvas.getContext("2d");
    context.fillStyle = '#000';
    context.strokeStyle = '#000';

    function isInside(x, y) {
        return x < boardWidth && x > 0 && y < boardHeight && y > 0;
    }

    function Size() {
        return {
            x: boardWidth,
            y: boardHeight
        }
    }

    function Clear() {
        context.clearRect(0, 0, boardWidth, boardHeight);
        context.strokeRect(0, 0, boardWidth, boardHeight);
    }

    return {
        context: context,
        isInside: isInside,
        Size: Size,
        Clear: Clear
    }
})();