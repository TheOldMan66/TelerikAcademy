var testVar1 = [
    '3 5',
    'dr dl dr ur ul',
    'dr dr ul ur ur',
    'dl dr ur dl ur'
];
console.log(Solve(testVar1));

function Solve(input) {
    var command = input[0].split(' ');
    var rows = Number(command[0]);
    var cols = Number(command[1]);
    var matrix = [];
    for (var i = 0; i < rows; i++) {
        matrix[i] = input[i + 1].split(' ');
    };

    var currentRow = 0;
    var currentCol = 0;
    var lastRow = 0;
    var lastCol = 0;
    var sum = 0;
    var result = '';

    while (true) {
        /*        if (currentRow === 0) {
            sum = sum + currentCol + 1;
        } else { */
        sum = sum + (1 << currentRow) + (currentCol);
        //        }
        lastRow = currentRow;
        lastCol = currentCol;
        switch (matrix[currentRow][currentCol]) {
            case 'dr':
                currentRow++;
                currentCol++;
                break;
            case 'dl':
                currentRow++;
                currentCol--;
                break;
            case 'ur':
                currentRow--;
                currentCol++;
                break;
            case 'ul':
                currentRow--;
                currentCol--;
                break;
            default:
                break;
        }
        matrix[lastRow][lastCol] = null;
        if (currentRow < 0 || currentRow === rows ||
            currentCol < 0 || currentCol === cols) {
            return 'successed with ' + sum;
        }
        if (matrix[currentRow][currentCol] === null) {
            return 'failed at (' + currentRow + ', ' + currentCol + ')';
        }
    }
}