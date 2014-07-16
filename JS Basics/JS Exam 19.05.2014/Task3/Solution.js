var testVar1 = [
    '6',
    'title:Telerik Academy',
    'showSubtitle:true',
    'subTitle:Free training',
    'showMarks:false',
    'marks:3,4,5,6',
    'students:Pesho,Gosho,Ivan',
    '42',
    '@section menu {',
    '<ul id="menu">',
    '<li>Home</li>',
    '<li>About us</li>',
    '</ul>',
    '}',
    '@section footer {',
    '<footer>',
    'Copyright Telerik Academy 2014',
    '</footer>',
    '}',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '<title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '@renderSection("menu")',
    '<h1>@title</h1>',
    '@if (showSubtitle) {',
    '<h2>@subTitle</h2>',
    '<div>@@JustNormalTextWithDoubleKliomba ;)</div>',
    '}',
    '<ul>',
    '@foreach (var student in students) {',
    '<li>',
    '@student',
    '</li>',
    '<li>Multiline @title</li>',
    '}',
    '</ul>',
    '@if (showMarks) {',
    '<div>',
    '@marks',
    '</div>',
    'bul.“Alexander Malinov“ №33., Sofia, 1729, Bulgaria',
    'academy.telerik.com',
    'Telerik Software Academy 2014 6 of 6 facebook.com/TelerikAcademy',
    '}',
    '@renderSection("footer")',
    '</body>',
    '</html>',
];


var testVar2 = [
    '6',
    'title:Telerik Academy',
    'showSubtitle:true',
    'subTitle:Free training',
    'showMarks:false',
    'marks:3,4,5,6',
    'students:Pesho,Gosho,Ivan',
    '42',
    '@section menu {',
    '<ul id="menu">',
    '    <li>Home</li>',
    '    <li>About us</li>',
    '</ul>',
    '}',
    '@section footer {',
    '<footer>',
    '    Copyright Telerik Academy 2014',
    '</footer>',
    '}',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '    <title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '    @renderSection("menu")',
    '',
    '    <h1>@title</h1>',
    '    @if (showSubtitle) {',
    '        <h2>@subTitle</h2>',
    '        <div>@@JustNormalTextWithDoubleKliomba ;)</div>',
    '    }',
    '',
    '    <ul>',
    '        @foreach (var student in students) {',
    '            <li>',
    '                @student ',
    '            </li>',
    '            <li>Multiline @title</li>',
    '        }',
    '    </ul>',
    '    @if (showMarks) {',
    '        <div>',
    '            @marks ',
    '        </div>',
    '    }',
    '',
    '    @renderSection("footer")',
    '</body>',
    '</html>'
];
console.log(Solve(testVar2));




function Solve(input) {
    var numOfKVPairs = Number(input[0]);
    input.shift();
    var KVPairs = [];
    var sections = [];
    var pair = [];
    var inIf = false;
    var ifIsTrue = false;

    for (var i = 0; i < numOfKVPairs; i++) {
        pair = input[i].split(':')
        pair[0] = '@' + pair[0];
        KVPairs[pair[0]] = pair[1];
    }
    input = input.slice(numOfKVPairs);


    var numOfLines = Number(input[0]);
    input.shift();
    var result = [];
    var line = ''
    var currentLine = 0;
    while (input[currentLine].indexOf('@section') === 0) {
        line = input[currentLine];
        line = line.substring(9, line.length - 2);
        currentLine++;
        sections[line] = [];
        while (input[currentLine].indexOf('}') === -1) {
            sections[line].push(input[currentLine]);
            currentLine++;
        }
        currentLine++;
    }

    while (currentLine < numOfLines) {
        if (inIf) {
            continue;
        }
        if (input[currentLine].indexOf('@') === -1) {
            result.push(input[currentLine]);
            currentLine++;
            continue;
        };

        if (input[currentLine].indexOf('@if') > -1) {

        };

        if (input[currentLine].indexOf('@renderSection(') > -1) {
            var tab = input[currentLine].indexOf('@');
            tab = input[currentLine].substring(0, tab);
            var tabName = input[currentLine].indexOf('(') + 1;
            tabName = input[currentLine].substring(input[currentLine].indexOf('(') + 2, input[currentLine].indexOf(')') - 1);

            for (var i = 0; i < sections[tabName].length; i++) {
                result.push(tab + sections[tabName][i]);
            }
            currentLine++;
            continue;
        };

        for (var key in KVPairs) {
            if (input[currentLine].indexOf(key) > -1) {
                input[currentLine] = input[currentLine].replace(key, KVPairs[key]);
            }
        }
        result.push(input[currentLine]);
        currentLine++;
    }

    return result.join('\n');
}