var SnakeGame = SnakeGame || {};
SnakeGame.Engine = (function() {
    'use strict';
    var FRUITS_APPEARING_TIME = 300,
        snake = SnakeGame.Snake,
        context = SnakeGame.Board.context,
        fruits = [],
        result,
        fruitsTimer = 1,
        snakeDirection = 39;

    result = document.createElement('div'),
    document.body.appendChild(result);
    window.addEventListener("keydown", doKeyDown, true);


    function doKeyDown(e) {
        var newDirection = e.keyCode;
        switch (newDirection) {
            case 37:
                if (snakeDirection != 39) {
                    SnakeGame.Snake.Turn(-1, 0);
                    snakeDirection = newDirection;
                }
                break;
            case 39:
                if (snakeDirection != 37) {
                    SnakeGame.Snake.Turn(1, 0);
                    snakeDirection = newDirection;
                }
                break;
            case 38:
                if (snakeDirection != 40) {
                    SnakeGame.Snake.Turn(0, -1)
                    snakeDirection = newDirection;
                }
                break;
            case 40:
                if (snakeDirection != 38) {
                    SnakeGame.Snake.Turn(0, 1)
                    snakeDirection = newDirection;
                }
                break;
            default:
                console.log(e.keyIdentifier);
                break;
        }
    }

    //engine main loop

    requestAnimationFrame(gameLoop);

    function gameLoop() {
        SnakeGame.Snake.Move();
        SnakeGame.Board.Clear();
        SnakeGame.Snake.Draw(context);
        fruitsTimer--;
        if (fruitsTimer === 0) {
            fruits.push(new SnakeGame.Fruits.Fruit());
            fruitsTimer = FRUITS_APPEARING_TIME;
        };

        for (var i = 0; i < fruits.length; i++) {
            //            if (fruits[i].x === SnakeGame.Snake.HeadPos().x && fruits[i].y === SnakeGame.Snake.HeadPos().y) {
            if (fruits[i].CanBeEaten(SnakeGame.Snake.HeadPos())) {
                SnakeGame.Snake.Grow(fruits[i].foodSize * 5);
                fruits[i] = fruits[fruits.length - 1];
                fruits.pop();
                result.innerHTML = 'Snake lenght:' + SnakeGame.Snake.GetLength();
            } else {
                fruits[i].Draw(context);
            }
        };

        if (!SnakeGame.Snake.BiteYourself() && SnakeGame.Board.isInside(SnakeGame.Snake.HeadPos().x, SnakeGame.Snake.HeadPos().y)) {
            requestAnimationFrame(gameLoop);
        } else {
            //            console.log('End of game. Snake lenght:' + SnakeGame.Snake.GetLength());
            result.innerHTML = 'End of game. Snake lenght:' + SnakeGame.Snake.GetLength();
        }
    }
})();