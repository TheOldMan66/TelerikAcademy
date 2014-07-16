var specialConsole = (function() {

    function messageParser() {
        var messageBody = arguments[0];

        for (var i = 0; i < arguments.length - 1; i += 1) {
            if (messageBody.indexOf('{' + i + '}') !== -1) {
                messageBody = messageBody.replace('{' + i + '}', arguments[i + 1].toString());
            }
        }
        return messageBody;
    }

    function regularMessage() {
        console.log(messageParser.apply(null, arguments));
    }


    function warningMessage() {
        console.warn(messageParser.apply(null, arguments));
    };

    function errorMessage() {
        console.error(messageParser.apply(null, arguments));
    };


    return {
        writeLine: regularMessage,
        writeWarning: warningMessage,
        writeError: errorMessage
    };

})();