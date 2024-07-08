import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Header from './components/Header';
import BookList from './components/BookList';
import UserList from './components/UserList';
import BorrowingList from './components/BorrowingList';
import Login from './components/Login';
import Register from './components/Register';

function App() {
  return (
    <Router>
      <Header />
      <Switch>
        <Route path="/books" component={BookList} />
        <Route path="/users" component={UserList} />
        <Route path="/borrowings" component={BorrowingList} />
        <Route path="/login" component={Login} />
        <Route path="/register" component={Register} />
        <Route path="/" component={BookList} exact />
      </Switch>
    </Router>
  );
}

export default App;
