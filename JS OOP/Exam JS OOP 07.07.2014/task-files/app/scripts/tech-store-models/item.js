define([], function() {
    var Item = (function() {

        var ALLOWED_ITEM_TYPES = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'];
        //type, name, price
        function Item(type, name, price) {
            if (ALLOWED_ITEM_TYPES.indexOf(type) == -1) {
                throw new TypeError('Invalid item type:' + type);
            }
            if (name.length < 6 || name.length > 40) {
                throw new TypeError('Invalid item name lenght:' + name);
            }
            this.type = type
            this.name = name;
            this.price = price;
        }

        return Item;
    }());

    return Item;
});