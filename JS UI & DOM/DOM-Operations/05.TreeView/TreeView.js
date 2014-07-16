window.onload = (function() {
    'use strict';

    var style = document.createElement('style');
    style.innerHTML = 'li{list-style-type:none;background:url(imgs/arrow.png) no-repeat 0px 5px;padding-left:12px}\n' +
        'li ul {display:none}\n' +
        '.clicked {background:url(imgs/arrow1.png) no-repeat 0px 5px}\n' +
        '.clicked > ul {display:block}';
    document.head.appendChild(style);

    var treeView = document.createElement('ul');
    treeView.innerHTML = 'Unordered list';
    document.body.appendChild(treeView);

    document.body.addEventListener('click', function(event) {
        if (event.target instanceof HTMLLIElement) {
            toggleState(event.target);
        }
    }, true);
    addLi(0, treeView, 'List Item ');

    function toggleState(element) {
        if (element.classList.contains('clicked')) {
            element.classList.remove('clicked');
            var nestedClicked = element.getElementsByClassName('clicked');
            for (var i = 0; i < nestedClicked.length; i++) {
                nestedClicked[i].classList.remove('clicked');
            }
        } else {
            element.classList.add('clicked');
        }
    }

    function addLi(depth, parent, text) {
        for (var i = 0; i < 3; i++) {
            var li = document.createElement('li');
            var liTxt = text + (i + 1);
            li.innerHTML = liTxt;
            var ul = document.createElement('ul');
            if (depth < 4) {
                addLi(depth + 1, ul, liTxt + '.');
                li.appendChild(ul);
            } else {
                li.style['background'] = 'none';
            }
            parent.appendChild(li);
        }
    }
})();