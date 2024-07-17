import axios from 'axios';

const instance = axios.create({
  baseURL: 'https://localhost:44327',
});

// Adaugă un interceptor pentru a adăuga token-ul JWT în antetul cererilor
instance.interceptors.request.use(
  config => {
    const token = localStorage.getItem('token'); // Obține token-ul JWT din localStorage
    if (token) {
      config.headers.Authorization = `Bearer ${token}`; // Adaugă token-ul JWT în antetul Authorization
    }
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

instance.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response && error.response.status === 401) {
      // Token-ul a expirat sau este invalid
      localStorage.removeItem('token');
      window.location.href = '/'; // Redirecționare către pagina de login
    }
    return Promise.reject(error);
  }
);

export default instance;
