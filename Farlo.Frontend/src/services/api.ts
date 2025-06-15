import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5000', // Ana URL değil, her servisin URL'si özel belirtilecek
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 10000, // 10 saniye
});

export default api;
