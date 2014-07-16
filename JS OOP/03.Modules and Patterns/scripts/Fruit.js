var SnakeGame = SnakeGame || {};
SnakeGame.Fruits = (function() {
    'use strict';

    var Fruit = function() {
        this.x = parseInt(Math.random() * SnakeGame.Board.Size().x);
        this.y = parseInt(Math.random() * SnakeGame.Board.Size().y);
        if (parseInt(Math.random() * 5) === 0) {
            this.foodSize = 20;
        } else {
            this.foodSize = 10;
        }
    };

    Fruit.prototype.Draw = function(context) {
        context.beginPath();
        context.arc(this.x, this.y, this.foodSize / 3, 0, 2 * Math.PI);
        context.fill();
    };

    Fruit.prototype.CanBeEaten = function(snakeHead) {
        return Math.abs(this.x - snakeHead.x) + Math.abs(this.y - snakeHead.y) < this.foodSize / 3;
    };

    return {
        Fruit: Fruit
    }
})();