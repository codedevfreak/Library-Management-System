import React, { useState, useEffect } from 'react';
import axios from '../services/api';

const BorrowingList = () => {
  const [borrowings, setBorrowings] = useState([]);

  useEffect(() => {
    axios.get('/api/borrowings')
      .then(response => {
        setBorrowings(response.data);
      })
      .catch(error => {
        console.error('There was an error fetching the borrowings!', error);
      });
  }, []);

  return (
    <div className="container">
      <h2>Borrowings</h2>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>User</th>
            <th>Book</th>
            <th>Borrow Date</th>
            <th>Return Date</th>
          </tr>
        </thead>
        <tbody>
          {borrowings.map(borrowing => (
            <tr key={borrowing.id}>
              <td>{borrowing.user.username}</td>
              <td>{borrowing.book.title}</td>
              <td>{borrowing.borrowDate}</td>
              <td>{borrowing.returnDate}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BorrowingList;
