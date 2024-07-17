import React, { useEffect, useState } from 'react';
import './Profil.css';
import { useNavigate } from 'react-router-dom';
import axios from '../api/axios';

const Profil = ({ setIsLoggedIn }) => {
  const navigate = useNavigate();
  const [userData, setUserData] = useState({});
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [isEditing, setIsEditing] = useState(false);

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const token = localStorage.getItem('token');
        if (!token) {
          throw new Error('Token is missing');
        }

        const response = await axios.get('/api/Users/profile', {
          headers: {
            Authorization: `Bearer ${token}`
          }
        });

        setUserData(response.data);
        setLoading(false);
      } catch (error) {
        console.error('Eroare la preluarea datelor utilizatorului:', error);
        setError('Nu s-au putut prelua datele utilizatorului. Te rugăm să încerci din nou.');
        setLoading(false);
      }
    };

    fetchUserData();
  }, []);

 
  const handleLogout = () => {
    localStorage.removeItem('token');
    setIsLoggedIn(false);
    navigate('/register-login');
  };

  const handleEditToggle = () => {
    setIsEditing(!isEditing);
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setUserData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSave = async () => {
    try {
      const token = localStorage.getItem('token');
      await axios.put('/api/Users/profile', userData, {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });
      setIsEditing(false);
    } catch (error) {
      console.error('Eroare la actualizarea datelor utilizatorului:', error);
      setError('Nu s-au putut salva datele utilizatorului. Te rugăm să încerci din nou.');
    }
  };

  if (loading) {
    return <div>Se încarcă...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <div className="profil-wrapper">
      <div className="form-container">
        <div className="date-container">
          <h2>Profilul Meu</h2>
          {isEditing ? (
            <>
              <p>
                <strong>Prenume:</strong>
                <input
                  type="text"
                  name="firstName"
                  value={userData.firstName}
                  onChange={handleInputChange}
                />
              </p>
              <p>
                <strong>Nume:</strong>
                <input
                  type="text"
                  name="lastName"
                  value={userData.lastName}
                  onChange={handleInputChange}
                />
              </p>
              <p>
                <strong>Email:</strong>
                <input
                  type="email"
                  name="email"
                  value={userData.email}
                  onChange={handleInputChange}
                />
              </p>
              <p>
                <strong>Număr de telefon:</strong>
                <input
                  type="text"
                  name="phoneNumber"
                  value={userData.phoneNumber}
                  onChange={handleInputChange}
                />
              </p>
              <button onClick={handleSave}>Salvează</button>
            </>
          ) : (
            <>
              <p><strong>Prenume:</strong> {userData.firstName}</p>
              <p><strong>Nume:</strong> {userData.lastName}</p>
              <p><strong>Email:</strong> {userData.email}</p>
              <p><strong>Număr de telefon:</strong> {userData.phoneNumber}</p>
            </>
          )}
        </div>
        <button onClick={handleEditToggle}>
          {isEditing ? 'Renunță' : 'Modifică datele curente'}
        </button>
        <button className="logout-button" onClick={handleLogout}>Logout</button>
      </div>
    </div>
  );
};

export default Profil;
