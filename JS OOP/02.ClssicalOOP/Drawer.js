var Drawer = (function() {
    var ctx;

    function Drawer() {
        var canvas;
        canvas = document.createElement('canvas');
        canvas.width = 800;
        canvas.height = 600;
        canvas.style.position = "absolute";
        canvas.style.border = "1px solid black";
        canvas.style.top = '20px';
        canvas.style.left = '20px';
        document.body.appendChild(canvas);
        ctx = canvas.getContext('2d');
        ctx.lineWidth = 2;
        ctx.strokeStyle = 'black';
        ctx.fillStyle = 'red';

    }

    Drawer.prototype = {
        drawLine: function(x1, y1, x2, y2) {
            ctx.beginPath();
            ctx.moveTo(x1, y1);
            ctx.lineTo(x2, y2);
            ctx.stroke();
        },

        drawRect: function(x, y, w, h) {
            ctx.beginPath();
            ctx.rect(x, y, w, h);
            ctx.fill();
            ctx.stroke();
        },

        drawCircle: function(x, y, r) {
            ctx.beginPath();
            ctx.arc(x, y, r, 0, 2 * Math.PI);
            ctx.fill();
            ctx.stroke();
        }
    };

    return Drawer;
}());