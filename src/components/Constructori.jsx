import React, { useEffect, useState } from 'react';
import axios from '../axios/axios'; // importă instanța axios configurată
import './Constructori.css'; // importă stilurile CSS

function Constructori() {
  const [disponibilEchipe, setDisponibilEchipe] = useState([]);
  const [indisponibilEchipe, setIndisponibilEchipe] = useState([]);
  const [proiecte, setProiecte] = useState([]);
  const [history, setHistory] = useState([]);
  const [constructorId, setConstructorId] = useState('');
  const [proiectId, setProiectId] = useState('');
  const [estimatedTime, setEstimatedTime] = useState(''); // Adăugăm starea pentru timpul estimat

  useEffect(() => {
    // Fetch echipe de constructii
    axios.get('/api/Construction')
      .then(response => {
        const echipe = response.data;
        setDisponibilEchipe(echipe.filter(e => e.consStatus === 'disponibil'));
        setIndisponibilEchipe(echipe.filter(e => e.consStatus === 'indisponibil'));
      })
      .catch(error => {
        console.error("There was an error fetching the echipe constructor data!", error);
      });

    // Fetch proiecte
    axios.get('/api/Admins/proiecte')
      .then(response => {
        setProiecte(response.data);
      })
      .catch(error => {
        console.error("There was an error fetching the project data!", error);
      });

    // Fetch history
    axios.get('/api/Construction/history')
      .then(response => {
        setHistory(response.data);
      })
      .catch(error => {
        console.error("There was an error fetching the assignment history data!", error);
      });
  }, []);

  const handleDisponibilize = (id) => {
    axios.put(`/api/Construction/${id}`, { proiectId: null })
      .then(response => {
        setIndisponibilEchipe(indisponibilEchipe.filter(e => e.constructorId !== id));
        const updatedEchipa = indisponibilEchipe.find(e => e.constructorId === id);
        updatedEchipa.consStatus = 'disponibil';
        updatedEchipa.proiectId = null;
        updatedEchipa.proiect = null; // reset proiect
        setDisponibilEchipe([...disponibilEchipe, updatedEchipa]);

        // Actualizează istoricul
        axios.get('/api/Construction/history')
          .then(response => {
            setHistory(response.data);
          })
          .catch(error => {
            console.error("There was an error fetching the assignment history data!", error);
          });
      })
      .catch(error => {
        console.error("There was an error updating the echipe constructor data!", error);
      });
  };

  const handleAssignProject = () => {
    axios.put(`/api/Construction/${constructorId}`, { proiectId: parseInt(proiectId), estimatedTime })
      .then(response => {
        const updatedEchipa = disponibilEchipe.find(e => e.constructorId === parseInt(constructorId));
        if (updatedEchipa) {
          axios.get(`/api/Admins/proiect/${proiectId}`)
            .then(proiectResponse => {
              updatedEchipa.consStatus = 'indisponibil';
              updatedEchipa.proiectId = parseInt(proiectId);
              updatedEchipa.proiect = proiectResponse.data;
              setDisponibilEchipe(disponibilEchipe.filter(e => e.constructorId !== parseInt(constructorId)));
              setIndisponibilEchipe([...indisponibilEchipe, updatedEchipa]);

              // Actualizează istoricul
              axios.get('/api/Construction/history')
                .then(response => {
                  setHistory(response.data);
                })
                .catch(error => {
                  console.error("There was an error fetching the assignment history data!", error);
                });
            })
            .catch(proiectError => {
              console.error("There was an error fetching the project data!", proiectError);
            });
        }
      })
      .catch(error => {
        console.error("There was an error assigning the project!", error);
      });
  };

  return (
    <div className="constructori-wrapper">
      <h2>Lista Proiecte</h2>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Nume</th>
              <th>Număr Apartamente</th>
            </tr>
          </thead>
          <tbody>
            {proiecte.map(proiect => (
              <tr key={proiect.proiectId}>
                <td>{proiect.proiectId}</td>
                <td>{proiect.nume}</td>
                <td>{proiect.numarApartamente}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <h2>Echipe Disponibile</h2>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Nume</th>
              <th>Status</th>
            </tr>
          </thead>
          <tbody>
            {disponibilEchipe.map(echipa => (
              <tr key={echipa.constructorId}>
                <td>{echipa.constructorId}</td>
                <td>{echipa.consName}</td>
                <td>{echipa.consStatus}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className="assign-container">
        <input 
          type="text" 
          placeholder="Constructor ID" 
          value={constructorId} 
          onChange={(e) => setConstructorId(e.target.value)} 
        />
        <input 
          type="text" 
          placeholder="Proiect ID" 
          value={proiectId} 
          onChange={(e) => setProiectId(e.target.value)} 
        />
        <input 
          type="text" 
          placeholder="Timp Estimat" 
          value={estimatedTime} 
          onChange={(e) => setEstimatedTime(e.target.value)} 
        />
        <button onClick={handleAssignProject}>Asignează</button>
      </div>

      <h2>Echipe Indisponibile</h2>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Nume</th>
              <th>Status</th>
              <th>Proiect</th>
              <th>Acțiune</th>
            </tr>
          </thead>
          <tbody>
            {indisponibilEchipe.map(echipa => (
              <tr key={echipa.constructorId}>
                <td>{echipa.constructorId}</td>
                <td>{echipa.consName}</td>
                <td>{echipa.consStatus}</td>
                <td>{echipa.proiect ? echipa.proiect.nume : 'N/A'}</td>
                <td>
                  <button onClick={() => handleDisponibilize(echipa.constructorId)}>Disponibilizează</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <h2>Istoric Asignări</h2>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>ID Constructor</th>
              <th>ID Proiect</th>
              <th>Data Asignării</th>
              <th>Acțiune</th>
              <th>Timp Estimat</th>
            </tr>
          </thead>
          <tbody>
            {history.map(record => (
              <tr key={record.id}>
                <td>{record.constructorId}</td>
                <td>{record.proiectId !== null ? record.proiectId : 'N/A'}</td>
                <td>{new Date(record.assignedDate).toLocaleString()}</td>
                <td>{record.action}</td>
                <td>{record.estimatedTime}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default Constructori;
