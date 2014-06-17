window.onload = (function() {
    var colorPicker1 = document.createElement('input');
    colorPicker1.type = 'color';
    colorPicker1.style.margin = '20px';
    colorPicker1.addEventListener("change", function() {
        textInput.style['background-color'] = this.value;
    }, true);
    document.body.appendChild(colorPicker1);

    var colorPicker2 = document.createElement('input');
    colorPicker2.type = 'color';
    colorPicker2.style.margin = '20px';
    colorPicker2.addEventListener("change", function() {
        textInput.style['color'] = this.value;
    }, true);
    document.body.appendChild(colorPicker2);

    var textInput = document.createElement('input');
    textInput.type = 'text';
    textInput.value = 'TEST TEXT';
    textInput.style.width = '200px';
    //    textInput.style.height = '100px';
    textInput.style.margin = '20px';
    document.body.appendChild(textInput);
})();