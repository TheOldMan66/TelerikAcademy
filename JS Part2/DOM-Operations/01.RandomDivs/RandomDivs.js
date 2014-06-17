window.onload = (function(){
	function getRandom(min,max) {
		if (min == undefined) {
			min = 0;
			max = 255;
		} else if (max == undefined) {
			max = min
			min = 0;
		}
		return parseInt(Math.random()*(max-min)+min);
	}

	var divStr,
		divHeight;
	for (var i = 0; i < 20; i++) {
		divStr = '<div style="top:'+ getRandom(600) +'px;left:'+getRandom(800)+'px;height:' + getRandom(20,100) + 'px;width:'+getRandom(20,100) + 
				'px;background-color:rgb('+getRandom() + ','+getRandom() + ','+getRandom() + ');color:rgb('+getRandom() + ','+getRandom() + ','+getRandom() + 
					');border-color:rgb('+getRandom() + ','+getRandom() + ','+getRandom() + ');border-width:'+getRandom(1,20)+'px;border-style:solid;border-radius:'+getRandom(100)+'px"><strong>DIV</strong></div>';
		document.body.innerHTML += divStr;
	}
})();