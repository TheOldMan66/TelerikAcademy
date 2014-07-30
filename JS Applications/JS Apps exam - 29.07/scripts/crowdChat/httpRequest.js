define(['Q'], function(Q) {
    var httpRequest = (function() {


        var getJSON = function(url, contentType, acceptType) {
            var deferred = Q.defer();

            $.ajax({
                url: url,
                type: 'GET',
                contentType: contentType || '',
                acceptType: acceptType || '',
                success: function(data) {
                    deferred.resolve(data);
                },
                error: function(err) {
                    deferred.reject(err);
                }
            });

            return deferred.promise;
        };

        var postJSON = function(url, contentType, acceptType, data) {
            var deferred = Q.defer();

            if (data) {
                data = JSON.stringify(data);
            } else {
                data = {
                    _method: 'delete'
                };
            }

            $.ajax({
                url: url,
                type: "POST",
                contentType: contentType,
                acceptType: acceptType,
                data: data,
                success: function(data) {
                    deferred.resolve(data);
                },
                error: function(err) {
                    deferred.reject(err);
                }
            });

            return deferred.promise;
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON
        };
    }());
    return httpRequest;
});