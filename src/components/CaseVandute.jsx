import React, { useState, useEffect } from 'react';
import axios from '../axios/axios'; // Importă instanța de axios configurată
import './CaseVandute.css'; // Fișierul de stil pentru a gestiona responsive-ul

function CaseVandute() {
  const [caseVandute, setCaseVandute] = useState([]);
  const [newCasa, setNewCasa] = useState({
    numarCamere: '',
    suprafata: '',
    etaje: '',
    adresa: '',
    detaliiCasa: '',
  });

  useEffect(() => {
    // Fetch case vandute on component mount
    const fetchCaseVandute = async () => {
      try {
        const response = await axios.get('/api/admins/casavanduta');
        setCaseVandute(response.data);
      } catch (error) {
        console.error('Error fetching case vandute:', error);
      }
    };

    fetchCaseVandute();
  }, []);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNewCasa((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('/api/admins/casavanduta', newCasa);
      setCaseVandute((prevState) => [...prevState, response.data]);
      setNewCasa({
        numarCamere: '',
        suprafata: '',
        etaje: '',
        adresa: '',
        detaliiCasa: '',
      });
    } catch (error) {
      console.error('Error adding casa vanduta:', error);
    }
  };

  return (
    <div className="case-vandute-wrapper">
      <h1>Case Destinate Vanzarii</h1>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Numar Camere</th>
              <th>Suprafata</th>
              <th>Etaje</th>
              <th>Adresa</th>
              <th>Detalii Casa</th>
            </tr>
          </thead>
          <tbody>
            {caseVandute.map((casa) => (
              <tr key={casa.casaId}>
                <td>{casa.casaId}</td>
                <td>{casa.numarCamere}</td>
                <td>{casa.suprafata}</td>
                <td>{casa.etaje}</td>
                <td>{casa.adresa}</td>
                <td>{casa.detaliiCasa}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <h2>Adauga Casa Noua</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="number"
          name="numarCamere"
          placeholder="Numar Camere"
          value={newCasa.numarCamere}
          onChange={handleInputChange}
          required
        />
        <input
          type="number"
          name="suprafata"
          placeholder="Suprafata"
          value={newCasa.suprafata}
          onChange={handleInputChange}
          required
        />
        <input
          type="number"
          name="etaje"
          placeholder="Etaje"
          value={newCasa.etaje}
          onChange={handleInputChange}
          required
        />
        <input
          type="text"
          name="adresa"
          placeholder="Adresa"
          value={newCasa.adresa}
          onChange={handleInputChange}
          required
        />
        <textarea
          name="detaliiCasa"
          placeholder="Detalii Casa"
          value={newCasa.detaliiCasa}
          onChange={handleInputChange}
          required
        />
        <button type="submit">Adauga Casa</button>
      </form>
    </div>
  );
}

export default CaseVandute;
