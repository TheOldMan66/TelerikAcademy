var testVar1 = [
    'def func sum[5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6, 3]',
    'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]'
];



var testVar2 = [
    'def func sum[1, 2, 3, -6]',
    'def newList [func, 10, 1]',
    'def newFunc sum[func, 100, newList]',
    '[newFunc]'
];

var testVar3 = [
    'def definition[-100, -100, -100]',
    'def definitionResult sum[definition]',
    'def defTest sum[definitionResult, 6457457, 2345234, -234546]',
    'avg[defTest, 1, 2, 3]'
];

function Solve(input) {
    var defs = {};
    var currentLine;
    var result;

    for (var i = 0; i < input.length; i++) {
        result = parseLine(input[i]);
    }

    return result;

    function parseLine(commandLine) {
        var result;
        commandLine = commandLine.replace('[', ' [ ');
        commandLine = commandLine.replace(']', ' ] ');
        commandLine = cleanExtraSpaces(commandLine);
        commandLine = commandLine.trim();
        if (commandLine.substr(0, 4) === 'def ') {
            result = makeDef(commandLine);
            return result;
        }

        var command = commandLine.substr(0, 3);
        switch (command) {
            case 'sum':
                result = calcSum(commandLine);
                break;
            case 'avg':
                result = calcAvg(commandLine);
                break;
            case 'max':
                result = calcMax(commandLine);
                break;
            case 'min':
                result = calcMin(commandLine);
                break;
            default:
                result = calc(commandLine);
                break;
        }

        return result;
    }

    function calc(line) {
        line = cleanAllSpaces(line)
        line = line.substring(1, line.length - 1);
        var elements = line.split(',');
        for (var i = 0, len = elements.length; i < len; i++) {
            if (defs[elements[i]] !== undefined) {
                Array.prototype.push.apply(elements, defs[elements[i]]);
                elements.splice(i, 1);
            }
        }
        var result = elements.join(',')
        result = '[' + result + ']';
        return result;
    }


    function makeDef(line) {
        line = line.substr(4).trim();
        var defName = line.substring(0, line.indexOf(' '));
        line = line.substr(defName.length).trim();
        var value = parseLine(line);
        defs[defName] = value;
        return value;
    }


    function cleanExtraSpaces(str) {
        while (str.indexOf('  ') !== -1) {
            str = str.replace('  ', ' ');
        }
        return str.trim();
    }

    function cleanAllSpaces(str) {
        while (str.indexOf(' ') !== -1) {
            str = str.replace(' ', '');
        }
        return str.trim();
    }

    function calcSum(line) {
        line = line.substring(line.indexOf('[') + 1, line.length - 1);
        var elements = line.split(',');
        var sum = 0;
        for (var i = 0; i < elements.length; i++) {
            elements[i] = elements[i].trim();
            if (defs[elements[i].trim()] !== undefined) {
                elements = elements.slice(0, i).concat(String(defs[elements[i]]).split(",")).concat(elements.slice(i + 1));
            }
            sum += Number(elements[i]);
        }
        return sum;
    }

    function calcAvg(line) {
        //debugger;
        line = line.substring(line.indexOf('[') + 1, line.length - 1);
        var elements = line.split(',');
        var sum = 0;
        for (var i = 0; i < elements.length; i++) {
            elements[i] = elements[i].trim();
            if (defs[elements[i].trim()] !== undefined) {
                elements = elements.slice(0, i).concat(String(defs[elements[i]]).split(",")).concat(elements.slice(i + 1));
            }
            sum += Number(elements[i]);
        }
        return parseInt(sum / elements.length);
    }

    function calcMin(line) {
        //debugger;
        line = line.substring(line.indexOf('[') + 1, line.length - 1);
        var elements = line.split(',');
        var min = Number.MAX_VALUE;
        for (var i = 0; i < elements.length; i++) {
            elements[i] = elements[i].trim();
            if (defs[elements[i].trim()] !== undefined) {
                elements = elements.slice(0, i).concat(String(defs[elements[i]]).split(",")).concat(elements.slice(i + 1));
            }
        }
        for (var i = 0; i < elements.length; i++) {
            if (Number(min) > Number(elements[i])) {
                min = elements[i];
            }
        }
        return min;
    }

    function calcMax(line) {
        //debugger;
        line = line.substring(line.indexOf('[') + 1, line.length - 1);
        var elements = line.split(',');
        var max = -Number.MAX_VALUE;
        for (var i = 0; i < elements.length; i++) {
            elements[i] = elements[i].trim();
            if (defs[elements[i].trim()] !== undefined) {
                elements = elements.slice(0, i).concat(String(defs[elements[i]]).split(",")).concat(elements.slice(i + 1));
            }
            if (Number(max) < Number(elements[i])) {
                max = elements[i];
            }
        }
        return max;
    }

    function calc(line) {
        //debugger;
        line = line.substring(1, line.length - 1);
        var elements = line.split(',');
        for (var i = 0; i < elements.length; i++) {
            elements[i] = elements[i].trim();
            if (defs[elements[i].trim()] !== undefined) {
                elements = elements.slice(0, i).concat(String(defs[elements[i]]).split(",")).concat(elements.slice(i + 1));
            }
        }
        return elements.join(',');
    }
}


console.log(Solve(testVar3));