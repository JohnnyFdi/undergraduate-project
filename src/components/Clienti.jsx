import React, { useState, useEffect } from 'react';
import axios from '../axios/axios';
import './Clienti.css'; 

function Clienti() {
  const [users, setUsers] = useState([]);
  const [searchName, setSearchName] = useState('');
  const [searchEmail, setSearchEmail] = useState('');
  const [newUser, setNewUser] = useState({
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    password: '',
  });
  const [successMessage, setSuccessMessage] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  useEffect(() => {
    fetchUsers();
  }, []);

  const fetchUsers = async () => {
    try {
      const response = await axios.get('/api/users');
      setUsers(response.data);
    } catch (error) {
      console.error('Error fetching users:', error);
    }
  };

  const handleSearch = async () => {
    try {
      const response = await axios.get(`/api/users/search?name=${searchName}&email=${searchEmail}`);
      setUsers(response.data);
    } catch (error) {
      console.error('Error searching users:', error);
    }
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('/api/users/register', newUser);
      setUsers([...users, response.data]);
      setNewUser({
        firstName: '',
        lastName: '',
        email: '',
        phoneNumber: '',
        password: '',
      });
      setSuccessMessage('Clientul a fost adăugat cu succes');
      setTimeout(() => setSuccessMessage(''), 3000); // Mesajul dispare după 3 secunde
    } catch (error) {
      console.error('Error registering user:', error);
      setErrorMessage('Eroare la înregistrarea utilizatorului');
      setTimeout(() => setErrorMessage(''), 3000);
    }
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`/api/users/${id}`);
      setUsers(users.filter(user => user.userId !== id));
      setSuccessMessage(`Clientul cu ID-ul ${id} a fost șters cu succes`);
      setTimeout(() => setSuccessMessage(''), 3000); // Mesajul dispare după 3 secunde
    } catch (error) {
      console.error('Error deleting user:', error);
      setErrorMessage(`Eroare la ștergerea utilizatorului cu ID-ul ${id}`);
      setTimeout(() => setErrorMessage(''), 3000);
    }
  };

  return (
    <div className="clienti-wrapper">
      <h1>Clienti</h1> <br />
      <div className="search-bar">
        <input 
          type="text" 
          placeholder="Search by name" 
          value={searchName} 
          onChange={(e) => setSearchName(e.target.value)} 
        />
        <input 
          type="text" 
          placeholder="Search by email" 
          value={searchEmail} 
          onChange={(e) => setSearchEmail(e.target.value)} 
        />
        <button onClick={handleSearch}>Search</button>
      </div>

      <div className="table-container" id="tabel-clienti">
        <table className="users-table">
          <thead>
            <tr>
              <th>ID</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Email</th>
              <th>Phone Number</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {users.map(user => (
              <tr key={user.userId}>
                <td>{user.userId}</td>
                <td>{user.firstName}</td>
                <td>{user.lastName}</td>
                <td>{user.email}</td>
                <td>{user.phoneNumber}</td>
                <td>
                  <button onClick={() => handleDelete(user.userId)}>Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <form className="register-form" onSubmit={handleRegister}>
        <input 
          type="text" 
          placeholder="First Name" 
          value={newUser.firstName} 
          onChange={(e) => setNewUser({ ...newUser, firstName: e.target.value })} 
          required 
        />
        <input 
          type="text" 
          placeholder="Last Name" 
          value={newUser.lastName} 
          onChange={(e) => setNewUser({ ...newUser, lastName: e.target.value })} 
          required 
        />
        <input 
          type="email" 
          placeholder="Email" 
          value={newUser.email} 
          onChange={(e) => setNewUser({ ...newUser, email: e.target.value })} 
          required 
        />
        <input 
          type="text" 
          placeholder="Phone Number" 
          value={newUser.phoneNumber} 
          onChange={(e) => setNewUser({ ...newUser, phoneNumber: e.target.value })} 
          required 
        />
        
        <button type="submit">Adauga client</button>
        {successMessage && <p className="success-message">{successMessage}</p>}
        {errorMessage && <p className="error-message">{errorMessage}</p>}
      </form>
    </div>
  );
}

export default Clienti;
