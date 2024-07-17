import React, { useEffect, useState } from 'react';
import './Profil.css';
import { useNavigate } from 'react-router-dom';
import axios from '../axios/axios';

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

        const response = await axios.get('/api/Admins/profile', {
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
    localStorage.removeItem('email');
    //setIsLoggedIn(false);
    navigate('/');
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
      await axios.put('/api/Admins/profile', userData, {
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
              <strong>Parola:</strong>
              <input
                type="password"
                name="password"
                value={userData.phoneNumber}
                onChange={handleInputChange}
              />
            </p>
            <button onClick={handleSave}>Salvează</button>
          </>
        ) : (
          <>
            
            <p><strong>Email:</strong> {userData.email}</p>
            <p><strong>Rol:</strong> {userData.role}</p>
          </>
        )}
      </div>
      <button onClick={handleEditToggle}>
        {isEditing ? 'Renunță' : 'Modifică parola'}
      </button>
      <button className="logout-button" onClick={handleLogout}>Logout</button>
      
    </div>
    </div>
  );
};

export default Profil;
