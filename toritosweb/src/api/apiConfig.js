import axios from 'axios';

const baseURL = 'http://localhost/ToritosHost/api/'; 
//const baseURL = '10.10.20.250:80/ToritosHost/api/'; 
//const baseURL = 'http://localhost:5158/api/'; 

const api = axios.create({
  baseURL: baseURL,  // Ajusta según tu API
  timeout: 5000,  // Establece un tiempo de espera para la solicitud
  headers: {
    'Content-Type': 'application/json',
  }
});

export default api;