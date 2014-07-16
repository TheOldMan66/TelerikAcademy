//var testVar1 = [8, 1, 6, -9, 4, 4, -2, 10, -1];
//var testVar1 = [8, -8, -7, -6, -5, -4, -3, -2, -1];
var testVar1 = [10, 1255569, -851435, 1457629, 858237, 221970, -652780, 1379095, -732864, -606100, 1566514]


    function Solve(input) {
        var maxSoFar = parseInt(input[1]);
        var currentSum = 0;
        for (var i = 1, len = parseInt(input[0]); i <= len; i++) {
            currentSum += Number(input[i]);
            if (Number(maxSoFar) < Number(currentSum)) {
                maxSoFar = currentSum;
            }

            if (Number(currentSum) < 0) {
                currentSum = 0;
            }

        }

        return maxSoFar;
    }

console.log(Solve(testVar1));