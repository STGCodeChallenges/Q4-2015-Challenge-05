Star Wars Trivia
----------------

This trivia app uses web sockets to allow multiple devices/browser windows to participate in the trivia action.
First thing after pulling the code down is return
`npm install`
to install all dependencies.

To start the application run
`node server.js`
It will do it's best to determine what your local IP address and output the URL to use for any devices on your local network to connect.
It doesn't handle edge cases well, so once you connect, try to stay connected until all questions have been answered.
