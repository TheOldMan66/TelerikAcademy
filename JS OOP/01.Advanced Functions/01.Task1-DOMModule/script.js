'use strict';
var domModule = (function() {

    var buffer = [];

    function appendChild(elementToAdd, selector) {
        var elements,
            i;
        elements = document.querySelectorAll(selector);
        for (i = 0; i < elements.length; i++) {
            elements[i].appendChild(elementToAdd.cloneNode(true));
        };
    }

    function removeChild(selector, elementToRemove) {
        var elements,
            childElements,
            i,
            j;
        elements = document.querySelectorAll(selector);
        for (i = 0; i < elements.length; i++) {
            childElements = elements[i].querySelectorAll(elementToRemove);
            for (j = 0; j < childElements.length; j++) {
                childElements[j].parentNode.removeChild(childElements[j])
            };
        };
    }

    function addHandler(selector, event, callback) {
        var elements,
            i;
        elements = document.querySelectorAll(selector);
        for (i = 0; i < elements.length; i++) {
            elements[i].addEventListener(event, callback);
        };
    }

    function appendToBuffer(selector, elementToAdd) {
        var elements,
            i;
        elements = document.querySelectorAll(selector);
        for (i = 0; i < elements.length; i++) {
            buffer.push({
                where: elements[i],
                what: elementToAdd.cloneNode(true)
            })
            if (buffer.length == 100) {
                flushBuffer();
            };
        };
    }

    function flushBuffer() {
        var i;
        for (i = 0; i < buffer.length; i++) {
            buffer[i].where.appendChild(buffer[i].what);
        };
        buffer.length = 0;
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        flushBuffer: flushBuffer
    };
})();