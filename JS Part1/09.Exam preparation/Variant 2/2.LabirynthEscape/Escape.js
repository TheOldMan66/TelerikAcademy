//testVar = ["3 4", "1 3", "lrrd", "dlll", "rddd"];
testVar = ["5 8", "0 0", "rrrrrrrd", "rludulrd", "durlddud", "urrrldud", "ulllllll"]

function Solve(input) {
    var rows = Number(input[0].split(' ')[0]);
    var cols = Number(input[0].split(' ')[1]);
    var startPos = [Number(input[1].split(' ')[0]), Number(input[1].split(' ')[1])];
    var arr = [];
    for (var i = 0; i < rows; i++) {
        //        arr[i] = [];
        arr.push(input[i + 2].split(''));
    }
    var lastCellValue;
    var steps = 0;
    var collectedPoints = Number(0);
    var stepOver = false;
    while (startPos[0] >= 0 && startPos[0] < rows && startPos[1] >= 0 && startPos[1] < cols) {
        if (!arr[startPos[0]][startPos[1]]) {
            stepOver = true;
            break;
        }
        collectedPoints += startPos[0] * cols + Number([startPos[1]]) + 1;
        steps++;
        lastCellValue = arr[startPos[0]][startPos[1]]
        arr[startPos[0]][startPos[1]] = false;
        switch (lastCellValue) {
            case 'd':
                startPos[0]++;
                break;
            case 'u':
                startPos[0]--;
                break;
            case 'r':
                startPos[1]++;
                break;
            case 'l':
                startPos[1]--;
                break;
        }
    }
    if (stepOver) {
        return 'lost ' + steps;
    } else {
        return 'out ' + collectedPoints;
    }
}

console.log(Solve(testVar));