window.onload = (function() {
    'use strict';
    var tags = ["cms", "javascript", "HTTP", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net",
        "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"
    ]

    var result = generateTagCloud(tags, 17, 42);
    for (var i = 0; i < result.length; i++) {
        document.body.appendChild(result[i]);
    };

    function generateTagCloud(tags, minSize, maxSize) {
        var tag,
            tagToLower,
            occurences = [],
            frequency = [],
            fontStep,
            result = [];

        for (tag in tags) {
            tagToLower = tags[tag].toLowerCase();
            if (!occurences[tagToLower]) {
                occurences[tagToLower] = 1;
            } else {
                occurences[tagToLower]++;
            }
        }

        for (tag in occurences) {
            frequency.push({
                name: tag,
                value: occurences[tag]
            });
        };

        frequency.sort(function(a, b) {
            return b.value - a.value;
        })

        fontStep = (maxSize - minSize) / (frequency[0].value - frequency[frequency.length - 1].value);
        var elementHeight;
        for (var i = 0; i < frequency.length; i++) {
            elementHeight = minSize + ((frequency[i].value - 1) * fontStep);
            result[i] = document.createElement('div');
            result[i].style.height = elementHeight + 'px';
            result[i].style['font-size'] = elementHeight + 'px';
            result[i].style.display = 'inline-block';
            result[i].style.margin = '10px';
            result[i].innerHTML = frequency[i].name;
        };

        return result;
    }
})();