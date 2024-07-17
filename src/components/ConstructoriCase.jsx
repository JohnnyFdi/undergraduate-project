import React, { useEffect, useState } from 'react';
import axiosInstance from '../axios/axios'; // Importă instanța axios configurată
import './Constructori.css'; // Importă stilurile CSS

function ConstructoriCase() {
  const [disponibilEchipe, setDisponibilEchipe] = useState([]);
  const [indisponibilEchipe, setIndisponibilEchipe] = useState([]);
  const [caseVandute, setCaseVandute] = useState([]);
  const [history, setHistory] = useState([]);
  const [constructorId, setConstructorId] = useState('');
  const [casaId, setCasaId] = useState('');
  const [estimatedTime, setEstimatedTime] = useState('');

  useEffect(() => {
    // Fetch echipe de constructii de case
    axiosInstance.get('/api/HouseConstruction')
      .then(response => {
        const echipe = response.data;
        setDisponibilEchipe(echipe.filter(e => e.consStatus === 'disponibil'));
        setIndisponibilEchipe(echipe.filter(e => e.consStatus === 'indisponibil'));
      })
      .catch(error => {
        console.error("There was an error fetching the echipe constructor data!", error);
      });

    // Fetch case vandute
    axiosInstance.get('/api/Admins/casavanduta')
      .then(response => {
        setCaseVandute(response.data);
      })
      .catch(error => {
        console.error("There was an error fetching the case vandute data!", error);
      });

    // Fetch history
    axiosInstance.get('/api/HouseConstruction/history')
      .then(response => {
        setHistory(response.data);
      })
      .catch(error => {
        console.error("There was an error fetching the assignment history data!", error);
      });
  }, []);

  const handleDisponibilize = (id) => {
    axiosInstance.put(`/api/HouseConstruction/${id}`, { casaId: null })
      .then(response => {
        setIndisponibilEchipe(indisponibilEchipe.filter(e => e.constructorCaseId !== id));
        const updatedEchipa = indisponibilEchipe.find(e => e.constructorCaseId === id);
        updatedEchipa.consStatus = 'disponibil';
        updatedEchipa.casaId = null;
        updatedEchipa.casaVanduta = null; // Reset casaVanduta
        setDisponibilEchipe([...disponibilEchipe, updatedEchipa]);

        // Actualizează istoricul
        axiosInstance.get('/api/HouseConstruction/history')
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

  const handleAssignCasa = () => {
    axiosInstance.put(`/api/HouseConstruction/${constructorId}`, { casaId: parseInt(casaId), estimatedTime })
      .then(response => {
        const updatedEchipa = disponibilEchipe.find(e => e.constructorCaseId === parseInt(constructorId));
        if (updatedEchipa) {
          axiosInstance.get(`/api/Admins/casavanduta/${casaId}`)
            .then(casaResponse => {
              updatedEchipa.consStatus = 'indisponibil';
              updatedEchipa.casaId = parseInt(casaId);
              updatedEchipa.casaVanduta = casaResponse.data;
              setDisponibilEchipe(disponibilEchipe.filter(e => e.constructorCaseId !== parseInt(constructorId)));
              setIndisponibilEchipe([...indisponibilEchipe, updatedEchipa]);

              // Actualizează istoricul
              axiosInstance.get('/api/HouseConstruction/history')
                .then(response => {
                  setHistory(response.data);
                })
                .catch(error => {
                  console.error("There was an error fetching the assignment history data!", error);
                });
            })
            .catch(casaError => {
              console.error("There was an error fetching the casa vanduta data!", casaError);
            });
        }
      })
      .catch(error => {
        console.error("There was an error assigning the casa!", error);
      });
  };

  return (
    <div className="constructori-wrapper">
      <h2>Lista Case Vandute</h2>
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
            {caseVandute.map(casa => (
              <tr key={casa.casaId}>
                <td>{casa.casaId}</td>
                <td>{casa.numarCamere}</td>
                <td>{casa.suprafata}</td>
                <td>{casa.etaje}</td>
                <td>{casa.adresa}</td>
                <td className="detalii-casa">{casa.detaliiCasa}</td>
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
              <tr key={echipa.constructorCaseId}>
                <td>{echipa.constructorCaseId}</td>
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
          placeholder="Casa ID" 
          value={casaId} 
          onChange={(e) => setCasaId(e.target.value)} 
        />
        <input 
          type="text" 
          placeholder="Timp Estimat" 
          value={estimatedTime} 
          onChange={(e) => setEstimatedTime(e.target.value)} 
        />
        <button onClick={handleAssignCasa}>Asignează</button>
      </div>

      <h2>Echipe Indisponibile</h2>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Nume</th>
              <th>Status</th>
              <th>Casa</th>
              <th>Acțiune</th>
            </tr>
          </thead>
          <tbody>
            {indisponibilEchipe.map(echipa => (
              <tr key={echipa.constructorCaseId}>
                <td>{echipa.constructorCaseId}</td>
                <td>{echipa.consName}</td>
                <td>{echipa.consStatus}</td>
                <td>{echipa.casaVanduta ? echipa.casaVanduta.adresa : 'N/A'}</td>
                <td>
                  <button onClick={() => handleDisponibilize(echipa.constructorCaseId)}>Disponibilizează</button>
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
              <th>ID Casa</th>
              <th>Data Asignării</th>
              <th>Acțiune</th>
              <th>Timp Estimat</th>
            </tr>
          </thead>
          <tbody>
            {history.map(record => (
              <tr key={record.id}>
                <td>{record.constructorCaseId}</td>
                <td>{record.casaId !== null ? record.casaId : 'N/A'}</td>
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

export default ConstructoriCase;
