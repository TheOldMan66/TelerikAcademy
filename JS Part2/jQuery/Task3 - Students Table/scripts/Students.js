$(document).ready(function() {
    'use strict';
    var studentsData = [{
        firstName: 'Peter',
        lastName: 'Ivanov',
        grade: 8
    }, {
        firstName: 'Ivan',
        lastName: 'Stoyanov',
        grade: 4
    }, {
        firstName: 'Nikolai',
        lastName: 'Kostov',
        grade: 4
    }, {
        firstName: 'Ivaylo',
        lastName: 'kenov',
        grade: 5
    }, {
        firstName: 'Stoyan',
        lastName: 'Kirilov',
        grade: 11
    }, {
        firstName: 'Asen',
        lastName: 'Petrov',
        grade: 15
    }, ]

    var tableHeader = {
        firstName: 'Fiers Name',
        lastName: 'Last Name',
        grade: 'Grade'
    }


    var $table = $('<table></table>');
    var $tableHeader = $('<tr></tr>');
    $.each(tableHeader, function(index, value) {
        $('<th>' + value + '</th>').appendTo($tableHeader);
    });
    $table.append($tableHeader);

    $.each(studentsData, function(index, value) {
        var $tableRow = $('<tr></tr>');
        $.each(value, function(index, value) {
            $tableRow.append('<td>' + value + '</td>');
        })
        $table.append($tableRow);
    })
    $('#wrapper').append($table);
})