import React from 'react';

const Header = () => (
  <nav className="navbar navbar-expand-lg navbar-light bg-light">
    <a className="navbar-brand" href="/">Library Management System</a>
    <div className="collapse navbar-collapse" id="navbarNav">
      <ul className="navbar-nav">
        <li className="nav-item">
          <a className="nav-link" href="/books">Books</a>
        </li>
        <li className="nav-item">
          <a className="nav-link" href="/users">Users</a>
        </li>
        <li className="nav-item">
          <a className="nav-link" href="/borrowings">Borrowings</a>
        </li>
      </ul>
    </div>
  </nav>
);

export default Header;
