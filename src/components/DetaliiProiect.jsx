import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import axios from '../api/axios'; // Importă instanța axios configurată
import './DetaliiProiect.css'; 
import FormattedText from './FormattedText'; // Importă componenta

import { Swiper, SwiperSlide } from 'swiper/react';
import { EffectFade, Navigation, Pagination, Autoplay } from 'swiper/modules';

import 'swiper/css';
import 'swiper/css/effect-fade';
import 'swiper/css/navigation';
import 'swiper/css/pagination';

const DetaliiProiect = () => {
  const { nume } = useParams(); // Obține parametrul nume din URL
  const [project, setProject] = useState(null);
  const [images, setImages] = useState([]);

  useEffect(() => {
    const fetchProjectDetails = async () => {
      try {
        const response = await axios.get('/api/Admins/proiecte');
        console.log(response.data); // Verifică datele primite
        const project = response.data.find(p => p.nume === nume);
        if (project) {
          setProject(project);
          setImages(project.imagini || []); // Setează imaginile sau un array gol
        } else {
          console.error('Proiectul nu a fost găsit');
        }
      } catch (error) {
        console.error('Eroare la obținerea detaliilor proiectului:', error);
      }
    };

    fetchProjectDetails();
  }, [nume]);

  if (!project) {
    return <div>Loading...</div>;
  }

  return (
    <div className="detalii-proiect-wrapper">
      <div className="slider-wrapper">
        <Swiper
          spaceBetween={30}
          effect={'fade'}
          navigation={true}
          pagination={{
            clickable: true,
          }}
          autoplay={{
            delay: 7000,
            disableOnInteraction: false,
          }}
          modules={[EffectFade, Navigation, Pagination, Autoplay]}
          className="mySwiper"
        >
          {images.map((image, index) => (
            <SwiperSlide key={index}>
              <img src={image.url} alt={`Imagine ${index + 1}`} />
            </SwiperSlide>
          ))}
        </Swiper>
      </div>
      <div className="project-description-wrapper">
        <h2>Descriere detaliată</h2>
        <FormattedText text={project.descriere2} /> {/* Folosește componenta personalizată */}
        <h2>Apartamente</h2>
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
              {project.apartamente.map((apartment, index) => (
                <tr key={index} className={apartment.status === 'disponibil' ? 'row-available' : 'row-unavailable'}>
                  <td>{apartment.numarApartament}</td>
                  <td>{apartment.numarCamere}</td>
                  <td>{apartment.suprafata}</td>
                  <td>{apartment.compartimentare}</td>
                  <td>{apartment.etaj}</td>
                  <td>{apartment.status}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default DetaliiProiect;
