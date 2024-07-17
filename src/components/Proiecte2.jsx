import React, { useState, useEffect } from 'react';
import axios from '../api/axios'; // Importă instanța axios configurată
import './Proiecte2.css';
import { Link } from 'react-router-dom';

const Proiecte2 = () => {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    const fetchProjects = async () => {
      try {
        const response = await axios.get('/api/Admins/proiecte');
        console.log(response.data); // Verifică datele primite
        setProjects(response.data);
      } catch (error) {
        console.error('Eroare la obținerea proiectelor:', error);
      }
    };

    fetchProjects();
  }, []);

  return (
    <div className="proiecte2-wrapper">
      {projects.map((project) => (
        <div key={project.proiectId} className="proiect-item">
          <div className="imagine-proiect">
            <img src={project.imgUrl} alt={project.nume} />
          </div>
          <div className="descriere-proiect">
            <h1>{project.nume}</h1>
            <h3>{project.descriere1}</h3> <br />
            <Link to={`/projects/${project.nume}`} className="buton-case"><span>Afla mai multe!</span></Link>
          </div>
        </div>
      ))}
    </div>
  );
}

export default Proiecte2;
