import React, { useState } from 'react';
import './ConfigurareCasa.css'; // Fișierul de stil pentru a gestiona responsive-ul
import axios from '../axios/axios'; // Importăm instanța de axios configurată

function ConfigurareCasa() {
  const [userId, setUserId] = useState('');
  const [houseConfigs, setHouseConfigs] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const fetchHouseConfigs = async () => {
    try {
      setLoading(true);
      setError('');
      const response = await axios.get(`/api/HouseConfig/getHouseConfigsByUserId/${userId}`);
      setHouseConfigs(response.data);
    } catch (err) {
      setError('Error fetching house configurations. Please try again.');
    } finally {
      setLoading(false);
    }
  };

  const handleInputChange = (e) => {
    setUserId(e.target.value);
  };

  const handleFetch = () => {
    if (userId) {
      fetchHouseConfigs();
    } else {
      setError('Please enter a user ID.');
    }
  };

  return (
    <div className="configurare-wrapper">
      <div className="input-section">
        <input
          type="text"
          placeholder="Enter User ID"
          value={userId}
          onChange={handleInputChange}
        />
        <button onClick={handleFetch}>Vezi Configurari</button>
      </div>

      {loading && <p>Loading...</p>}
      {error && <p className="error">{error}</p>}

      {houseConfigs.length > 0 && (
        <div className="tables-section">
          <h2>House Configurations</h2>
          <table className="house-config-table">
            <thead>
              <tr>
                <th>ConfigCasaId</th>
                <th>Material</th>
                <th>Finisaj</th>
                <th>TipIncalzire</th>
                <th>Ventilatie</th>
                <th>ColectareReziduri</th>
              </tr>
            </thead>
            <tbody>
              {houseConfigs.map((config) => (
                <tr key={config.configCasaId}>
                  <td>{config.configCasaId}</td>
                  <td>{config.material}</td>
                  <td>{config.finisaj}</td>
                  <td>{config.tipIncalzire}</td>
                  <td>{config.ventilatie}</td>
                  <td>{config.colectareReziduri}</td>
                </tr>
              ))}
            </tbody>
          </table>

          <h2>Configured Rooms</h2>
          <table className="room-config-table">
            <thead>
              <tr>
                <th>ConfigCasaId</th>
                <th>NumeCamera</th>
                <th>Suprafata</th>
                <th>IncalzirePardoseala</th>
              </tr>
            </thead>
            <tbody>
              {houseConfigs.flatMap((config) =>
                (config.camere || []).map((camera, index) => (
                  <tr key={`${config.configCasaId}-${index}`}>
                    <td>{config.configCasaId}</td>
                    <td>{camera.numeCamera}</td>
                    <td>{camera.suprafata}</td>
                    <td>{camera.incalzirePardoseala ? 'Yes' : 'No'}</td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}

export default ConfigurareCasa;
