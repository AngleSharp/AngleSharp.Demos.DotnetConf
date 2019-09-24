const cookieSession = require('cookie-session');
const express = require('express');
const { urlencoded } = require('body-parser');

const app = express();

app.use(urlencoded({
  extended: false,
}));

app.use(cookieSession({
  name: 'session',
  keys: ['key1'],
  maxAge: 24 * 60 * 60 * 1000,
}));

app.get('/', (req, res) => {
  if (req.session.loggedIn) {
    res.send(`<!DOCTYPE html>
<a href="/logout" class="logout">Logout</a>
<div id=secret>I'm Batman</div>`);
  } else {
    res.send(`<!DOCTYPE html>
<a href="/login" class="login">Login</a>
<div id=secret>Log in for my secret ...</div>`);
  }
});

app.get('/login', (_, res) => {
  res.send(loginView());
});

app.post('/login', (req, res) => {
  const { user = '', pass = '' } = req.body;

  if (user.toLowerCase() === 'bruce' && pass === 'wayne') {
    req.session.loggedIn = true;
    res.redirect('/');
  } else {
    res.send(loginView(user, 'Invalid credentials.'));
  }
});

app.get('/logout', (_, res) => {
  res.send(`<!DOCTYPE html>
<form method=POST>
<button>Logout</button>
</form>`);
});

app.post('/logout', (req, res) => {
  req.session.loggedIn = false;
  res.redirect('/');
});

function loginView(user = '', error = '') {
  return `<!DOCTYPE html>
<style>
label { display: block; }
</style>
<form method=POST>
<div>
<label>User</label>
<input name=user value="${user}">
</div>
<div>
<label>Pass</label>
<input name=pass type=password>
</div>
<div>
<button>Login</button>
</div>
</form>
<div class=error>${error}</div>`;
}

app.listen(8000);
