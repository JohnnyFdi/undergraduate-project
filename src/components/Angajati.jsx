import React, { useState, useEffect } from 'react';
import axios from '../axios/axios';
import './Angajati.css';

function Angajati() {
  const [adminUsers, setAdminUsers] = useState([]);
  const [newAdminUser, setNewAdminUser] = useState({
    role: '',
    email: '',
    password: '',
  });
  const [successMessage, setSuccessMessage] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  useEffect(() => {
    fetchAdminUsers();
  }, []);

  const fetchAdminUsers = async () => {
    try {
      const response = await axios.get('/api/admins');
      setAdminUsers(response.data);
    } catch (error) {
      console.error('Error fetching admin users:', error);
    }
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('/api/admins/register', newAdminUser);
      setAdminUsers([...adminUsers, response.data]);
      setNewAdminUser({
        role: '',
        email: '',
        password: '',
      });
      setSuccessMessage('Adminul a fost adăugat cu succes');
      setTimeout(() => setSuccessMessage(''), 3000); // Mesajul dispare după 3 secunde
    } catch (error) {
      console.error('Error registering admin user:', error);
      setErrorMessage('Eroare la înregistrarea utilizatorului');
      setTimeout(() => setErrorMessage(''), 3000);
    }
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`/api/admins/${id}`);
      setAdminUsers(adminUsers.filter(user => user.adminId !== id));
      setSuccessMessage(`Adminul cu ID-ul ${id} a fost șters cu succes`);
      setTimeout(() => setSuccessMessage(''), 3000); // Mesajul dispare după 3 secunde
    } catch (error) {
      console.error('Error deleting admin user:', error);
      setErrorMessage(`Eroare la ștergerea utilizatorului cu ID-ul ${id}`);
      setTimeout(() => setErrorMessage(''), 3000);
    }
  };

  return (
    <div className="angajati-wrapper">
      <h1>Angajati</h1> <br />
      <div className="table-container">
        <table className="admin-users-table">
          <thead>
            <tr>
              <th>ID</th>
              <th>Role</th>
              <th>Email</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {adminUsers.map(adminUser => (
              <tr key={adminUser.adminId}>
                <td>{adminUser.adminId}</td>
                <td>{adminUser.role}</td>
                <td>{adminUser.email}</td>
                <td>
                  <button onClick={() => handleDelete(adminUser.adminId)}>Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <form className="register-form" onSubmit={handleRegister}>
        <input 
          type="text" 
          placeholder="Role" 
          value={newAdminUser.role} 
          onChange={(e) => setNewAdminUser({ ...newAdminUser, role: e.target.value })} 
          required 
        />
        <input 
          type="email" 
          placeholder="Email" 
          value={newAdminUser.email} 
          onChange={(e) => setNewAdminUser({ ...newAdminUser, email: e.target.value })} 
          required 
        />
        <input 
          type="password" 
          placeholder="Password" 
          value={newAdminUser.password} 
          onChange={(e) => setNewAdminUser({ ...newAdminUser, password: e.target.value })} 
          required 
        />
        <button type="submit">Adauga Admin</button>
        {successMessage && <p className="success-message">{successMessage}</p>}
        {errorMessage && <p className="error-message">{errorMessage}</p>}
      </form>
    </div>
  );
}

export default Angajati;
