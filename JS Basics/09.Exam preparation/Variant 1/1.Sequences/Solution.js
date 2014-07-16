var testVar1 = [7, 1, 2, -3, 4, 4, 0, 1];
var testVar2 = [6, 1, 3, -5, 8, 7, -6];
var testVar3 = [9, 1, 8, 8, 7, 6, 5, 7, 7, 6];

function Solve(input) {
    var numOfSequences = 1;
    for (var i = 2, len = parseInt(input[0]); i <= len; i++) {
        if (Number(input[i]) < Number(input[i - 1])) {
            numOfSequences++;
        }
    }
    return numOfSequences;
}

console.log(Solve(testVar3));