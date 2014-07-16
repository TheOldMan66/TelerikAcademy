window.onload = (function() {
    'use strict';

    var body = document.body;
    var todos = [];
    var todoText = document.createElement('input');
    todoText.type = 'text';

    var btnAdd = document.createElement('button');
    btnAdd.innerHTML = 'Add TODO';
    btnAdd.onclick = function() {
        if (todoText.value) {
            body.appendChild(addTodo(body, todoText.value));
        };
    }

    var btnShowAll = document.createElement('button');
    btnShowAll.innerHTML = 'Show all';
    btnShowAll.onclick = function() {
        btnHideNotImportant.disabled = false;
        btnShowAll.disabled = true;
        var containers = document.getElementsByTagName('div');
        for (var i = 0, len = containers.length; i < len; i++) {
            containers[i].style.display = '';
        }
    };

    var btnHideNotImportant = document.createElement('button');
    btnHideNotImportant.innerHTML = 'Hide not important';
    btnHideNotImportant.onclick = function() {
        btnShowAll.disabled = false;
        btnHideNotImportant.disabled = true;
        var containers = document.getElementsByTagName('div');
        for (var i = 0, len = containers.length; i < len; i++) {
            var checkbox = containers[i].getElementsByTagName("input")[0];
            if (checkbox.checked) {
                containers[i].style.display = 'none';
            };
        }
    };

    body.appendChild(todoText);
    body.appendChild(btnAdd);
    body.appendChild(btnShowAll);
    body.appendChild(btnHideNotImportant);

    function addTodo(parent, todo) {
        var container = document.createElement('div');
        container.id = 'CONTAINER' + todos.length;
        container.style.width = '400px';
        container.style.border = '1px solid black';

        var label = document.createElement('label')
        label.htmlFor = 'HIDE' + todos.length;
        label.innerHTML = 'Not important';

        var hidden = document.createElement('input');
        hidden.type = "checkbox";
        hidden.id = 'HIDE' + todos.length;
        hidden.class = 'check' + todos.length;
        //        hidden.onchange = toggleDiv;


        var todoText = document.createElement('strong')
        todoText.innerHTML = todo;
        todoText.style.fontSize = "25px";

        var btnRemove = document.createElement('button');
        btnRemove.innerHTML = 'Remove';
        btnRemove.onclick = removeDiv;
        btnRemove.style.float = 'right';

        container.appendChild(label);
        container.appendChild(hidden);
        container.appendChild(todoText);
        container.appendChild(btnRemove);
        return container;
    }

    function removeDiv(evt) {
        evt.target.parentElement.parentElement.removeChild(evt.target.parentElement);
    }
})();