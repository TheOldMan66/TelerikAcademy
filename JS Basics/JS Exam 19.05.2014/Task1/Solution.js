var testVar1 = 7;
console.log(Solve(testVar1));




function Solve(input) {
    numOfWheels = Number(input);
    var totalResult = [];
    var result = [0, 0, 0];

    while (result[0] * 10 <= numOfWheels) {
        result[1] = 0;
        while (result[0] * 10 + result[1] * 4 <= numOfWheels) {
            result[2] = 0;
            while (result[0] * 10 + result[1] * 4 + result[2] * 3 <= numOfWheels) {
                if (result[0] * 10 + result[1] * 4 + result[2] * 3 == numOfWheels) {
                    totalResult.push(result);
                }
                result[2]++;
            }
            result[1]++;
        }
        result[0]++;
    }
    console.log(totalResult.length);
}