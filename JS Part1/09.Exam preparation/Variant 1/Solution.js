var testVar1 = ['(  def func    10)', '(def newFunc (+    func  2))', '(def sumFunc (+ func func newFunc 0 0 0))', '(* sumFunc 2)'];
var testVar2 = ['(def func (+ 5 2))', '(def func2 (/  func 5 2 1 0))', '(def func3 (/ func 2))', '(+ func3 func)'];

function Solve(input) {
    var defs = [];
    var defName;
    var result;
    for (var i = 0; i < input.length; i++) {
        result = calculate(input[i]);
        //        console.log(input[i] + '->' + result);
        if (Number.isNaN(result)) {
            return "Division by zero! At Line:" + Number(i + 1);
        }
    }
    return result;

    function calculate(expression) {
        var result;
        expression = removeDuplicateSpaces(expression);
        expression = removeBrackets(expression);
        expression = expression.split(' ');
        switch (expression[0]) {
            case 'def':
                var defName = expression[1];
                expression = expression.slice(2);
                expression = expression.join(' ');
                result = calculate(expression);
                if (result == Number.isNaN) {
                    return result;
                }
                defs[defName] = result;
                break;
            case '+':
                result = 0;
                for (var i = 1; i < expression.length; i++) {
                    result += evaluate(expression[i]);
                }
                break;
            case '-':
                result = 0;
                for (var i = 1; i < expression.length; i++) {
                    result -= evaluate(expression[i]);
                }
                break;
            case '*':
                result = 1;
                for (var i = 1; i < expression.length; i++) {
                    result *= evaluate(expression[i]);
                }
                break;
            case '/':
                result = evaluate(defs[expression[1]]);
                for (var i = 2; i < expression.length; i++) {
                    result = result / evaluate(expression[i]);
                }
                if (Number.isNaN(result)) {
                    return result;
                }
                break;
            default:
                result = evaluate(expression[0]);
        }

        return result;
    }

    function evaluate(expression) {
        var result = NaN;
        if (defs[expression]) {
            result = Number(defs[expression]);
        } else {
            result = Number(expression);
        }
        return result;
    }

    function removeDuplicateSpaces(line) {
        while (line.indexOf('  ') > -1) {
            line = line.replace('  ', ' ');
        }
        return line;
    }

    function removeBrackets(line) {
        if (line.indexOf('(') > -1) {
            line = line.substring(line.indexOf('(') + 1, line.lastIndexOf(')')).trim();
        }
        return line;
    }
}





console.log(Solve(testVar2));