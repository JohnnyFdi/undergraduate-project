import React, { useState, useEffect } from 'react';
import axios from '../axios/axios'; // Importă instanța Axios configurată
import './ProiecteView.css';

function ProiecteView() {
  const [proiecte, setProiecte] = useState([]);
  const [apartamente, setApartamente] = useState({});
  const [selectedProjectId, setSelectedProjectId] = useState(null);

  useEffect(() => {
    const fetchProiecte = async () => {
      try {
        const response = await axios.get('/api/Admins/proiecte');
        setProiecte(response.data);
      } catch (error) {
        console.error('Error fetching projects:', error);
      }
    };

    fetchProiecte();
  }, []);

  const handleRowClick = async (projectId) => {
    if (!projectId) return; // Verifică dacă projectId este definit
    if (apartamente[projectId]) {
      setSelectedProjectId(projectId === selectedProjectId ? null : projectId);
    } else {
      try {
        const response = await axios.get(`/api/Admins/proiect/${projectId}`);
        setApartamente((prevState) => ({
          ...prevState,
          [projectId]: response.data.apartamente,
        }));
        setSelectedProjectId(projectId);
      } catch (error) {
        console.error('Error fetching apartments:', error);
      }
    }
  };

  return (
    <div className="proiecte-view-wrapper">
        <h1>Proiecte</h1> <br />
      <table className="proiecte-table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Nume</th>
            <th>Numar Apartamente</th>
            <th>Descriere</th>
          </tr>
        </thead>
        <tbody>
          {proiecte.map((proiect) => (
            <React.Fragment key={proiect.proiectId}>
              <tr key={`project-${proiect.proiectId}`} onClick={() => handleRowClick(proiect.proiectId)}>
                <td>{proiect.proiectId}</td>
                <td>{proiect.nume}</td>
                <td>{proiect.numarApartamente}</td>
                <td>{proiect.descriere1}</td>
              </tr>
              {selectedProjectId === proiect.proiectId && apartamente[proiect.proiectId] && (
                <tr key={`apartments-container-${proiect.proiectId}`}>
                  <td colSpan="4">
                    <table className="apartamente-table">
                      <thead>
                        <tr>
                          <th>ID Apartament</th>
                          <th>Numar Apartament</th>
                          <th>Numar Camere</th>
                          <th>Suprafata</th>
                          <th>Compartimentare</th>
                          <th>Etaj</th>
                          <th>Status</th>
                        </tr>
                      </thead>
                      <tbody>
                        {apartamente[proiect.proiectId].map((apartament) => (
                          <tr key={apartament.apartamentId}>
                            <td>{apartament.apartamentId}</td>
                            <td>{apartament.numarApartament}</td>
                            <td>{apartament.numarCamere}</td>
                            <td>{apartament.suprafata}</td>
                            <td>{apartament.compartimentare}</td>
                            <td>{apartament.etaj}</td>
                            <td>{apartament.status}</td>
                          </tr>
                        ))}
                      </tbody>
                    </table>
                  </td>
                </tr>
              )}
            </React.Fragment>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ProiecteView;
