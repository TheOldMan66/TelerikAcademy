var testVar1 = ['U'];
var testVar2 = ['bM'];
var testVar3 = ['BaG'];
var testVar4 = ['CfI'];
var testVar5 = ['aAAAAAAAAAAAA'];


function Solve(input) {
    input = input[0].split('');
    var result = 0;
    var currentDigit = 0;
    var currentCharPos = 0;

    while (currentCharPos < input.length) {
        result = result * 168;
        currentDigit = 0;
        if (input[currentCharPos] === input[currentCharPos].toLocaleLowerCase()) {
            currentDigit = (input[currentCharPos].charCodeAt(0) - 96) * 26;
            currentCharPos++;
            currentDigit = currentDigit + (input[currentCharPos].charCodeAt(0) - 65);
            currentCharPos++;
        } else {
            currentDigit = input[currentCharPos].charCodeAt(0) - 65;
            currentCharPos++
        }
        result = currentDigit + result;
    }
    return result;
}

console.log(Solve(['aDLdYcGeXaEfIcY']))