function createCalendar(containerTag, events) {
    'use strict';
    var dayOfWeek = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

    var container = document.createDocumentFragment();
    var divSize = 150;
    var selectedDiv = null;

    for (var day = 0; day < 30; day++) {
        var div = makeDiv();
        div.appendChild(makeHeader());
        for (var evt = 0; evt < events.length; evt++) {
            if (events[evt].date == (day + 1)) {
                var newEvent = document.createElement('p');
                newEvent.style.margin = '0';
                newEvent.style.display = 'inline-block';
                newEvent.innerHTML = events[evt].hour + ' ' + events[evt].title;
                div.appendChild(newEvent);
            }
        }
        div.addEventListener('mouseenter', onMouseIn);
        div.addEventListener('mouseleave', onMouseOut);
        div.addEventListener('click', onMouseClick);
        container.appendChild(div);
    }

    var wrapper = document.querySelector(containerTag);
    wrapper.style.width = (divSize * 7 + 20) + 'px';
    wrapper.appendChild(container);

    function makeDiv() {
        var div = document.createElement('div');
        div.style.verticalAlign = 'top';
        div.style.width = divSize + 'px';
        div.style.height = divSize + 'px';
        div.style.border = '1px solid black';
        div.style.display = 'inline-block';
        return div;
    }

    function makeHeader() {
        var header = document.createElement('p');
        header.style.borderBottom = '1px solid black';
        header.style.backgroundColor = 'gray';
        header.innerHTML = dayOfWeek[day % 7] + ' ' + (day + 1) + ' June 2014';
        header.style.textAlign = 'center';
        header.style.margin = '0';
        header.classList.add('dayHeader');
        return header;
    }

    function onMouseIn(evt) {
        this.getElementsByClassName('dayHeader')[0].style.backgroundColor = 'lightgray';
    }

    function onMouseOut(evt) {
        this.getElementsByClassName('dayHeader')[0].style.backgroundColor = 'gray';
    }

    function onMouseClick(evt) {
        if (selectedDiv == null) {
            makeSelected(this);
            return;
        };

        selectedDiv.style.removeProperty('background-color');
        var header = selectedDiv.getElementsByClassName('dayHeader')[0];
        header.style.backgroundColor = 'gray';
        header.style.color = 'black';

        if (selectedDiv != this) {
            makeSelected(this);
        } else {
            selectedDiv = null;
        }

        console.log('mouseclick');
    }

    function makeSelected(element) {
        element.style.backgroundColor = 'gray';
        var header = element.getElementsByClassName('dayHeader')[0];
        header.style.backgroundColor = 'black';
        header.style.color = 'white';
        selectedDiv = element;

    }
}