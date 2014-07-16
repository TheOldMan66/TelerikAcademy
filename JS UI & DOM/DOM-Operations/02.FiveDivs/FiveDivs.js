window.onload = (function(){
	var divs = [];

	var oneFifthOfCircle = 2*Math.PI/5,
		centerX = 300;
		centerY = 300;
		radius = 100;

	for (var i = 0; i < 5; i++) {
		divs[i]=document.createElement('div');
		document.body.appendChild(divs[i]);
		divs[i].innerHTML = 'DIV #' + i;
		divs[i].style.left = 50 * i + 'px';
		divs[i].style.top = 50 * i + 'px';
		divs[i].angle = oneFifthOfCircle * i;
	}

	var loop = setInterval(moveCircles, 100);

	function moveCircles(){
		for (var i = 0; i < 5; i++) {
		divs[i].style.left = centerX + Math.cos(divs[i].angle)* radius +'px';
		divs[i].style.top = centerY + Math.sin(divs[i].angle)* radius +'px';
		divs[i].angle += 0.05;
		}
	}
})();