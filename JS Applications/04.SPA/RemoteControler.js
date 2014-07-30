var RemoteControler = (function () {
	function getJSON (url, headers) {
		var deferred = $.Deferred();
		$.ajax({
            type: "GET",
            url: url,
            headers: headers || {},
	        success: deferred.resolve,
	        error: deferred.reject
        });
        return deferred.promise();
	};
	function postJSON (url, postItem, headers) {
		var deferred = $.Deferred();
        return $.ajax({
            type: "POST",
            url: url,
            data: postItem,
            headers: headers || {},
	        success: deferred.resolve,
	        error: deferred.reject
        });
        return deferred.promise();
	}
	function deleteJSON (url, headers) {
		var deferred = $.Deferred();
        return $.ajax({
            type: "POST",
            url: url,
            data: { _method: 'delete' },
            headers: headers || {},
	        success: deferred.resolve,
	        error: deferred.reject
        });
        return deferred.promise();
	}
    return {
        get: getJSON,
        post: postJSON,
        delete: deleteJSON
    };
} ());




