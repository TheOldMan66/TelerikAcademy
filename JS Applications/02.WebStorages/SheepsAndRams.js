$(document).ready(function() {
    var ram = $(document.createElement('img'))
    var sheep = $(document.createElement('img'))
    var noLuck = $(document.createElement('img'))
    var userName;
    var numberToGuess = generateRandomNumber();
    var attemptsCount = 0;
    var allTimesHighScoreForThisUser;

    console.log(numberToGuess);

    sheep.attr('src', 'imgs/cow.png');
    ram.attr('src', 'imgs/bull.png');
    noLuck.attr('src', 'imgs/no.gif');

    $('#userInputBtn').click(function() {
        $('#congrats').hide();
        attemptsCount++;
        var isRam = [false, false, false, false];
        var userInput = $('#userGuessNumber').val();
        var gameOver = true;

        $('#sheepContainer').empty();

        //check for rams
        for (var i = 0; i < 4; i++) {
            if (numberToGuess[i] === $('#userGuessNumber').val()[i]) {
                isRam[i] = true;
                ram.clone().appendTo($('#sheepContainer'));
            } else {
                gameOver = false;
            }
        };
        if (!gameOver) {
            //check for sheeps
            for (var i = 0; i < 4; i++) {
                if (!isRam[i]) {
                    for (var j = 0; j < 4; j++) {
                        if (!isRam[j]) {
                            if (numberToGuess[i] === $('#userGuessNumber').val()[j]) {
                                sheep.clone().appendTo($('#sheepContainer'));
                                break;
                            };
                        }
                    }

                };
            };
            if (!$('#sheepContainer').html()) {
                noLuck.clone().appendTo($('#sheepContainer'));
            }
        } else {
            $('#userBestScore').html(attemptsCount);
            $('#congrats').show();
            console.log('You won the game in ' + attemptsCount + ' attempts!');
            if (Number.isNaN(bestForNow) || attemptsCount < bestForNow) {
                bestForNow = attemptsCount;
                localStorage.setItem(userName, bestForNow);
            }
            numberToGuess = generateRandomNumber();
            console.log(numberToGuess);
            gameOver = true;
        }
    })

    $('#userLoginBtn').click(function() {
        userName = $('#userNameInput')[0].value;
        if (!$.trim(userName).length) {
            userName = ' visitor';
        } else {
            userName = ' ' + userName;
        };
        $('#userLogin').hide();
        $('#userData').show();
        $('#gameBoard').show();
        $('#userNameSpan').html(userName);
        bestForNow = parseInt(localStorage.getItem(userName));
        $('#userBestScore').html(bestForNow);
    })

    $('#highScoreBtn').click(function() {
        var highScoreItem;
        var storageKey;

        if ($('#highScoreDiv').html()) {
            $('#highScoreDiv').empty()
        } else {
            for (var i = 0; i < localStorage.length; i++) {
                highScoreItem = $(document.createElement('div'))
                storageKey = localStorage.key(i);
                highScoreItem.html(storageKey + ' - ' + localStorage.getItem(storageKey) + ' points');
                highScoreItem.appendTo($('#highScoreDiv'));
            };
        }

        // sorry, I now that High score must be sorted, but ... I have no time for that. In next release may be ... :)
    })

    function generateRandomNumber() {
        var result = parseInt(Math.random() * 9 + 1);
        for (var i = 0; i < 3; i++) {
            result = result + '' + parseInt((Math.random() * 10));
        };
        return result;
    }
})