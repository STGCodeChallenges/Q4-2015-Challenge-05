$(function() {

  socket.emit('playerJoined', difficulty, name);

  var CORRECT_ANSWER_POINTS = 1;
  var gamePlaying = false;
  var question;
  window.submitAnswer = submitAnswer;

  socket.on('updatePlayerList', function(players) {
    var count = 0;
    var playerList = '';
    for (var name in players) {
      if (players.hasOwnProperty(name)) {
        count++;
      }
      playerList += '<li>' + name + ': ' + players[name].score + '</li>';
    }
    if (! gamePlaying) {
      updatePreGameMessages(count);
    } else {
      $('#numPlayers').text('');
    }
    $('#playerList').html(playerList)
  });

  socket.on('gameStarted', function() {
    alert('starting the game');
    $('.gamebuttons').hide();
    playGame();
  });

  socket.on('gameFinished', function(players) {
    var winner;
    var highest = 0;
    var message;
    for (var user in players) {
      if (players[user].score > highest) {
        winner = user;
        highest = winner.score
      }
    }
    if (name == user) {
      message = 'Congratulations you won!';
    } else {
      message = user + ' won';
    }
    $('#gameMessage').text(message);
  });

  $('#startGame').on('click', function() {
    socket.emit('startGame', difficulty);
    gamePlaying = true;
    $('.gamebuttons').hide();
    playGame();
    $('#numPlayers').empty();
  });


  function updatePreGameMessages(count) {
    if (count > 1) {
      $('#numPlayers').text(count + ' players are currently waiting...');
    } else if (count <= 1) {
      $('#numPlayers').text('Waiting on players to join...');
    }
  }

  function playGame() {
    question = questions.pop();
    if (questions.length) {
      displayQuestion(question);
    } else {
      $('.question-container').empty();
      $('#gameMessage').text('Waiting for other players to finish...');
      socket.emit('playerFinished', difficulty, name);
    }
  }

  function displayQuestion(question) {
    var choices = question.choices.reduce(function (string, choice, index) {
      return string += '<li class="choice" onclick="submitAnswer('+index+')">' + choice + '</li>';
    }, '');
    $('#question').text(question.question);
    $('#choices').html(choices);
  }

  function submitAnswer(index) {
    var choice = question.choices[index];
    if (choice == question.answer) {
      socket.emit('updateScore', difficulty, name, CORRECT_ANSWER_POINTS);
    }
    playGame();
  }

});
