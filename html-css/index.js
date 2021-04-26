
const express = require('express');
const app = express();
app.use("/", express.static('public'));
app.listen(3000);

const livereload = require('livereload');
const server = livereload.createServer();
server.watch(__dirname + "/public");

// <script src="http://localhost:35729/livereload.js"></script>
