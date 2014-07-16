define(['tech-store-models/item'], function(Item) {
    var Store = (function() {

        var SMART_PHONES = ['smart-phone'];
        var MOBILES = ['smart-phone', 'tablet'];
        var COMPUTERS = ['pc', 'notebook'];

        // internal
        function compareByName(first, second) {
            if (first.name.toLowerCase() > second.name.toLowerCase()) {
                return 1;
            } else if (first.name.toLowerCase() < second.name.toLowerCase()) {
                return -1;
            } else {
                return 0;
            }
        };

        function compareByPrice(first, second) {
            return Number(first.price) - Number(second.price);
        };

        function filterItemsByType(items, type) {
            var selectedItems = [];
            for (var i = 0; i < items.length; i++) {
                if (type.indexOf(items[i].type) > -1) {
                    selectedItems.push(items[i]);
                }
            };

            return selectedItems;
        };

        function filterItemsByName(items, name) {
            var selectedItems = [];
            for (var i = 0; i < items.length; i++) {
                if (items[i].name.toLowerCase().indexOf(name.toLowerCase()) > -1) {
                    selectedItems.push(items[i]);
                }
            };

            return selectedItems;
        };

        function filterItemsByPrice(items, range) {
            var min = (range && range.min) || 0;
            var max = (range && range.max) || Number.MAX_VALUE;
            var selectedItems = [];
            for (var i = 0; i < items.length; i++) {
                if (items[i].price >= min && items[i].price <= max) {
                    selectedItems.push(items[i]);
                }
            };

            return selectedItems;
        };

        //constructor
        function Store(name) {
            if (name.length < 6 || name.length > 30) {
                throw new TypeError('Invalid Store name lenght:' + name);
            }

            this.name = name;
            this._items = [];
        }

        //public
        Store.prototype.addItem = function(item) {

            if (!(item instanceof Item)) {
                throw new TypeError('Unsupported item type ');
            }

            this._items.push(item);
            return this;
        };

        Store.prototype.getAll = function() {
            return this._items.sort(compareByName).slice(0);
        };

        Store.prototype.getSmartPhones = function() {
            return filterItemsByType(this._items, SMART_PHONES).sort(compareByName);
        }

        Store.prototype.getMobiles = function() {
            return filterItemsByType(this._items, MOBILES).sort(compareByName);
        }

        Store.prototype.getComputers = function() {
            return filterItemsByType(this._items, COMPUTERS).sort(compareByName);
        }

        Store.prototype.filterItemsByPrice = function(range) {
            return filterItemsByPrice(this._items, range).sort(compareByPrice);
        }

        Store.prototype.filterItemsByType = function(type) {
            return filterItemsByType(this._items, type).sort(compareByName);
        }

        Store.prototype.filterItemsByName = function(name) {
            return filterItemsByName(this._items, name).sort(compareByName);
        }

        Store.prototype.countItemsByType = function(name) {
            var itemsArray = [];
            for (var i = 0; i < this._items.length; i++) {
                if (itemsArray[this._items[i].type] === undefined) {
                    itemsArray[this._items[i].type] = 0;
                }

                itemsArray[this._items[i].type]++;
            };
            return itemsArray;
        }
        return Store;
    }());

    return Store;
});