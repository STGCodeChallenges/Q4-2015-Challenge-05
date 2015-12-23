var express = require('express')
var app = express();
var http = require('http').Server(app);
var io = require('socket.io')(http);

app.use(express.static('app'));

app.get('/', function(req, res) {
  res.sendFile(__dirname + '/app/index.html');
});

app.get('/easy', function(req, res) {
  res.sendFile(__dirname + '/app/easy.html');
});

app.get('/hard', function(req, res) {
  res.sendFile(__dirname + '/app/hard.html');
});

var players = {
  easy: {},
  hard: {}
};
io.on('connection', function(socket) {

  socket.on('playerJoined', function(difficulty, name) {
    players[difficulty][name] = {score: 0, playing: true};
    socket.difficulty = difficulty;
    socket.userName = name;
    socket.join(difficulty);
    io.to(difficulty).emit('updatePlayerList', players[difficulty]);
  });

  socket.on('startGame', function(difficulty) {
    socket.broadcast.to(difficulty).emit('gameStarted', difficulty);
  });

  socket.on('updateScore', function(difficulty, name, score) {
    players[difficulty][name].score += score;
    io.to(difficulty).emit('updatePlayerList', players[difficulty]);
  });

  socket.on('playerFinished', function(difficulty, name) {
    var total = 0;
    var finished = 0;
    players[difficulty][name].playing = false;
    for (var player in players[difficulty]) {
      total++;
      if (players[difficulty][player].playing == false) {
        finished++;
      }
    }
    if (total == finished) {
      io.to(difficulty).emit('gameFinished', players[difficulty]);
    }
  });

  socket.on('disconnect', function() {
    var difficulty = socket.difficulty;
    delete players[difficulty][socket.userName];
    io.to(difficulty).emit('updatePlayerList', players[difficulty]);
    console.log('a user disconnected ', difficulty, players);
  });
});


http.listen(3000, function() {
  console.log('listening on '+ getIPAddress() +':3000');
  console.log('connect any device on your local network to this address to play');
  console.log('May the force be with you, always');
});

function getIPAddress() {
  var interfaces = require('os').networkInterfaces();
  for (var devName in interfaces) {
    var iface = interfaces[devName];

    for (var i = 0; i < iface.length; i++) {
      var alias = iface[i];
      if (alias.family === 'IPv4' && alias.address !== '127.0.0.1' && !alias.internal)
        return alias.address;
    }
  }

  return '0.0.0.0';
}
