var httpRequest = (function () {
    'use strict';

    var getHttpRequest, makeRequest, getJSON, postJSON;

    // copy/paste from lecture demo ...

    getHttpRequest = (function () {
        var xmlHttpFactories;
        xmlHttpFactories = [

          function () {
              return new XMLHttpRequest();
          },
          function () {
              return new ActiveXObject("Msxml3.XMLHTTP");
          },
          function () {
              return new ActiveXObject("Msxml2.XMLHTTP.6.0");
          },
          function () {
              return new ActiveXObject("Msxml2.XMLHTTP.3.0");
          },
          function () {
              return new ActiveXObject("Msxml2.XMLHTTP");
          },
          function () {
              return new ActiveXObject("Microsoft.XMLHTTP");
          }
        ];
        return function () {
            var xmlFactory, _i, _len;
            for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                xmlFactory = xmlHttpFactories[_i];
                try {
                    return xmlFactory();
                } catch (_error) {

                }
            }
            return null;
        };
    })();



    makeRequest = function (url, options) {
        var promise = new Promise(
            function (resolve, reject) {
                var httpRequest = getHttpRequest();

                httpRequest.open(options.type, url, true);
                httpRequest.onreadystatechange = stateChangeHandler;
                httpRequest.setRequestHeader('Content-Type', options.contentType);
                httpRequest.setRequestHeader("Accept", options.accept);
                httpRequest.send(options.data);

                function stateChangeHandler() {
                    if (this.readyState === this.DONE) {
                        if (this.status === 200) {
                            resolve(this.response);
                        } else {
                            reject(this);
                        }
                    }
                };
            });

        return promise;
    };

    getJSON = function (url, options) {
        options = options || {};
        options.type = 'GET';
        options.contentType = options.contentType || 'application/json';
        options.accept = options.accept || 'application/json';
        options.data = null;
        return makeRequest(url, options);
    }

    postJSON = function (url, options, data) {
        options = options || {};
        options.type = 'POST';
        options.contentType = options.contentType || 'application/json';
        options.accept = options.accept || 'application/json';
        options.data = JSON.stringify(data);
        return makeRequest(url, options);
    }
    return {
        getJSON: getJSON,
        postJSON: postJSON
    };
    return httpRequest;
})();
