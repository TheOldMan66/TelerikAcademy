define(function() {
    'use strict';
    var Section;
    Section = (function() {
        function Section(title) {
            this.title = title;
            this.items = [];
        }

        Section.prototype.add = function(item) {
            this.items.push(item);
        }

        Section.prototype.getData = function() {
            return {
                title: this.title,
                items: this.items
            }
        }
        return Section;
    }());
    return Section;
})