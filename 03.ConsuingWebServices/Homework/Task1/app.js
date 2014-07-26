    'use strict';
    var url = "http://localhost:3000/students"

    var header = {
        contentType: 'application/json',
        accept: 'application/json',
    };
    var firstStudent = {
        name: "Gosho",
        grade: 1
    };
    var secondStudent = {
        name: "Pesho",
        grade: 2
    };
    var thirdStudent = {
        name: "Stamat",
        grade: 3
    };

    httpRequest.postJSON(url, header, firstStudent)
        .then(httpRequest.postJSON(url, header, secondStudent))
        .then(httpRequest.postJSON(url, header, thirdStudent));

    httpRequest.getJSON(url, header)
        .then(function (data) {
            var list,
                i,
                len,
                student,
                jsonData,
                item;
            list = document.createElement('ul');
            jsonData = JSON.parse(data);
            len = jsonData.count;
            for (i = 0; i < len; i += 1) {
                student = jsonData.students[i];
                item = document.createElement('li');
                item.innerHTML = student.name + ' is in ' + student.grade + ' grade';
                list.appendChild(item);
            }
            document.getElementById('wrapper').appendChild(list);
        }, function (err) {
            document.getElementById("wrapper").innerHTML = "<div style='color:red;font-weight:bold'>Error</div>";
        });