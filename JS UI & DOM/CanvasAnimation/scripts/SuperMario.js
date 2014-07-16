window.onload = function() {
    "use strict";


    var stage = new Kinetic.Stage({
        container: 'container',
        width: 840,
        height: 525
    });

    var layer = new Kinetic.Layer();
    var sprite = new Image();
    sprite.src = "img/sprite2.png";

    sprite.onload = function() {
        var mario = new Kinetic.Sprite({
            x: 120,
            y: 350,
            image: sprite,
            animation: 'idle',
            animations: {
                idle: [],
                move: []
            },
            frameRate: 10,
            frameIndex: 0
        });
        for (var i = 0; i < 17; i++) {
            mario.attrs.animations.move.push(i * 80);
            mario.attrs.animations.move.push(285);
            mario.attrs.animations.move.push(75);
            mario.attrs.animations.move.push(130);
        };
        for (var i = 11; i < 15; i++) {
            mario.attrs.animations.idle.push(i * 81 - 15);
            mario.attrs.animations.idle.push(700);
            mario.attrs.animations.idle.push(75);
            mario.attrs.animations.idle.push(130);
        };

        layer.add(mario);

        stage.add(layer);

        mario.start();

        var frameCount = 0;

        mario.on('frameIndexChange', function(evt) {
            if (mario.animation() === 'move' && ++frameCount > 5) {
                mario.animation('idle');
                frameCount = 0;
            }
        });

        function getKey(evt) {
            switch (evt.keyCode) {
                case 37: // left arrow
                    mario.scaleX(-1); // this scale reverses the mario
                    mario.setX(mario.attrs.x -= 10);
                    mario.attrs.animation = "move";
                    break;
                case 39: // right arrow
                    mario.scaleX(1);
                    mario.setX(mario.attrs.x += 10);
                    mario.attrs.animation = "move";
                    break;
            }
        }

        window.addEventListener('keydown', getKey);
    };
}

// P.S. I promise to cut precisely mario sprite in next version :)