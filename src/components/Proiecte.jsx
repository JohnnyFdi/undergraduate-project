import React, { useState } from 'react';
import axios from '../axios/axios'; // Importă instanța axios configurată
import './Proiecte.css';

const Proiecte = () => {
  const [projectName, setProjectName] = useState('');
  const [apartmentNumber, setApartmentNumber] = useState(0);
  const [description, setDescription] = useState('');
  const [description2, setDescription2] = useState('');
  const [imageFile, setImageFile] = useState(null);
  const [apartments, setApartments] = useState([]);
  const [imageFiles, setImageFiles] = useState(Array(9).fill(null));

  const handleSubmit = async (e) => {
    e.preventDefault();

    const formData = new FormData();
    formData.append('Nume', projectName);
    formData.append('NumarApartamente', apartmentNumber);
    formData.append('Descriere1', description);
    formData.append('Descriere2', description2);

    if (imageFile) {
      formData.append('UrlImgProiect', imageFile);
    }

    apartments.forEach((apartment, index) => {
      formData.append(`Apartamente[${index}].NumarApartament`, apartment.NumarApartament);
      formData.append(`Apartamente[${index}].NumarCamere`, apartment.NumarCamere);
      formData.append(`Apartamente[${index}].Suprafata`, apartment.Suprafata);
      formData.append(`Apartamente[${index}].Compartimentare`, apartment.Compartimentare);
      formData.append(`Apartamente[${index}].Etaj`, apartment.Etaj);
      formData.append(`Apartamente[${index}].Status`, 'disponibil'); // Setează automat statusul ca "disponibil"
    });

    imageFiles.forEach((file, index) => {
      if (file) {
        formData.append(`Imagini`, file);
      }
    });

    try {
      const response = await axios.post('/api/Admins/adaugare_proiect', formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });
      console.log('Proiect creat cu succes:', response.data);
      // Redirecționează sau afișează un mesaj de succes
    } catch (error) {
      console.error('Eroare la crearea proiectului:', error);
      // Afișează un mesaj de eroare
    }
  };

  const handleImageChange = (e) => {
    const file = e.target.files[0];
    if (file) {
      setImageFile(file);
    }
  };

  const handleMultiImageChange = (index, e) => {
    const file = e.target.files[0];
    if (file) {
      const newImageFiles = [...imageFiles];
      newImageFiles[index] = file;
      setImageFiles(newImageFiles);
    }
  };

  const generateTable = () => {
    const apartmentRows = Array.from({ length: apartmentNumber }, (_, index) => ({
      NumarApartament: '',
      NumarCamere: '',
      Suprafata: '',
      Compartimentare: '',
      Etaj: '',
      Status: 'disponibil'
    }));
    setApartments(apartmentRows);
  };

  const handleInputChange = (index, field, value) => {
    const newApartments = [...apartments];
    newApartments[index][field] = value;
    setApartments(newApartments);
  };

  return (
    <div className="proiecte-wrapper">
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="projectName">Nume Proiect</label>
          <input
            type="text"
            id="projectName"
            value={projectName}
            onChange={(e) => setProjectName(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="apartmentNumber">Număr Apartamente</label>
          <input
            type="number"
            id="apartmentNumber"
            value={apartmentNumber}
            onChange={(e) => setApartmentNumber(e.target.value)}
            required
          />
          <button type="button" onClick={generateTable}>Generează Tabel</button>
        </div>
        <div className="form-group">
          <label htmlFor="description">Descriere (sumara)</label>
          <textarea
            id="description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            required
          ></textarea>
        </div>
        <div className="form-group">
          <label htmlFor="description2">Descriere (amanuntita)</label>
          <textarea
            id="description2"
            value={description2}
            onChange={(e) => setDescription2(e.target.value)}
            required
          ></textarea>
        </div>
        <div className="form-group">
          <label htmlFor="imageFile">Încărcați o Imagine</label>
          <input
            type="file"
            id="imageFile"
            accept="image/*"
            onChange={handleImageChange}
          />
        </div>
        <button type="submit">Creeaza proiect.</button>
      </form>

      {apartments.length > 0 && (
        <div className="table-container">
          <table className="apartments-table">
            <thead>
              <tr>
                <th>Număr Apartament</th>
                <th>Număr Camere</th>
                <th>Suprafață</th>
                <th>Compartimentare</th>
                <th>Etaj</th>
                <th>Status</th>
              </tr>
            </thead>
            <tbody>
              {apartments.map((apartment, index) => (
                <tr key={index}>
                  <td>
                    <input
                      type="number"
                      value={apartment.NumarApartament}
                      onChange={(e) => handleInputChange(index, 'NumarApartament', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      type="number"
                      value={apartment.NumarCamere}
                      onChange={(e) => handleInputChange(index, 'NumarCamere', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      type="number"
                      value={apartment.Suprafata}
                      onChange={(e) => handleInputChange(index, 'Suprafata', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      type="text"
                      value={apartment.Compartimentare}
                      onChange={(e) => handleInputChange(index, 'Compartimentare', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      type="text"
                      value={apartment.Etaj}
                      onChange={(e) => handleInputChange(index, 'Etaj', e.target.value)}
                    />
                  </td>
                  <td>{apartment.Status}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}

      <form className="image-upload-form">
        <h3>Încărcați 9 Imagini</h3>
        <div className="image-upload-grid">
          {imageFiles.map((file, index) => (
            <div key={index} className="image-upload-item">
              <input
                type="file"
                accept="image/*"
                onChange={(e) => handleMultiImageChange(index, e)}
              />
            </div>
          ))}
        </div>
      </form>
    </div>
  );
};

export default Proiecte;