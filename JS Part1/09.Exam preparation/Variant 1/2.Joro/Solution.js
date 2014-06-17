var testVar1 = ['6 7 3', '0 0', '2 2', '-2 2', '3 -1'];

function Solve(input) {
    var command = input[0].split(' ');
    var rows = Number(command[0]);
    var cols = Number(command[1]);
    var numOfCommands = Number(command[2]);

    command = input[1].split(' ');
    var currentRow = Number(command[0]);
    var currentCol = Number(command[1]);
    var sumOfValues = 0;
    var numOfJumps = 0;
    var currentCommandRow = 2;

    var isInGrid = true;
    var visited = [];
    while (isInGrid) {
        numOfJumps++;
        sumOfValues += Number(currentRow * cols + currentCol + 1);
        visited[currentRow * cols + currentCol + 1] = true;
        command = input[currentCommandRow].split(' ');
        currentRow += Number(command[0]);
        currentCol += Number(command[1]);
        isInGrid = (currentRow > -1 && currentRow < rows && currentCol > -1 && currentCol < cols);
        if (!isInGrid || visited[currentRow * cols + currentCol + 1]) {
            break;
        };
        currentCommandRow++;
        if (currentCommandRow > numOfCommands + 1) {
            currentCommandRow = 2;
        };
    }
    if (!isInGrid) {
        return 'escaped ' + sumOfValues;
    } else {
        return 'caught  ' + numOfJumps;

    }
    return (isInGrid + ' ' + numOfJumps + ' ' + sumOfValues);
}

console.log(Solve(testVar1));