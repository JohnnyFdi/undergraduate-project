import React, { useEffect, useState } from 'react';
import axios from '../axios/axios';
import './ContracteCase.css'; // Fișierul de stil pentru a gestiona responsive-ul

function ContracteApartamente() {
  const [contracte, setContracte] = useState([]);
  const [newContract, setNewContract] = useState({
    userId: '',
    apartamentId: '',
    dataSemnarii: '',
    costuri: '',
    pretVanzare: ''
  });

  useEffect(() => {
    fetchContracte();
  }, []);

  const fetchContracte = async () => {
    try {
      const response = await axios.get('/api/Admins/contracte-apartamente');
      const email = localStorage.getItem('email'); // Extrage email-ul din local storage
      const filteredContracte = response.data.filter(contract => contract.adminEmail === email);
      setContracte(filteredContracte);
    } catch (error) {
      console.error('Error fetching contracts', error);
    }
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`/api/Admins/contracte-apartamente/${id}`);
      fetchContracte(); // Refresh the contract list after deletion
    } catch (error) {
      console.error('Error deleting contract', error);
    }
  };

  const handleCreate = async (e) => {
    e.preventDefault();
    try {
      await axios.post('/api/Admins/contracte-apartamente', newContract);
      fetchContracte(); // Refresh the contract list after creation
      setNewContract({
        userId: '',
        apartamentId: '',
        dataSemnarii: '',
        costuri: '',
        pretVanzare: ''
      }); // Reset the form
    } catch (error) {
      console.error('Error creating contract', error);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setNewContract((prevState) => ({
      ...prevState,
      [name]: value
    }));
  };

  return (
    <div className="contracte-case-wrapper">
      <h2>Contractele mele</h2>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Email Admin</th>
            <th>Nume User</th>
            <th>Numar Apartament</th>
            <th>Nume Proiect</th>
            <th>Data Semnarii</th>
            <th>Costuri</th>
            <th>Pret Vanzare</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {contracte.map((contract) => (
            <tr key={contract.contractApId}>
              <td>{contract.contractApId}</td>
              <td>{contract.adminEmail}</td>
              <td>{contract.userFullName}</td>
              <td>{contract.numarApartament}</td>
              <td>{contract.numeProiect}</td>
              <td>{new Date(contract.dataSemnarii).toLocaleDateString()}</td>
              <td>{contract.costuri}</td>
              <td>{contract.pretVanzare}</td>
              <td>
                <button onClick={() => handleDelete(contract.contractApId)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <h2>Creare Contract Nou</h2>
      <form onSubmit={handleCreate}>
        <input
          type="text"
          name="userId"
          value={newContract.userId}
          onChange={handleChange}
          placeholder="User ID"
          required
        />
        <input
          type="text"
          name="apartamentId"
          value={newContract.apartamentId}
          onChange={handleChange}
          placeholder="Apartament ID"
          required
        />
        <input
          type="date"
          name="dataSemnarii"
          value={newContract.dataSemnarii}
          onChange={handleChange}
          placeholder="Data Semnarii"
          required
        />
        <input
          type="number"
          name="costuri"
          value={newContract.costuri}
          onChange={handleChange}
          placeholder="Costuri"
          required
        />
        <input
          type="number"
          name="pretVanzare"
          value={newContract.pretVanzare}
          onChange={handleChange}
          placeholder="Pret Vanzare"
          required
        />
        <button type="submit">Creare Contract</button>
      </form>
    </div>
  );
}

export default ContracteApartamente;
