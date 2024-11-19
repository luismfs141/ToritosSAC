import { useState } from 'react';
import api from '../api/apiConfig';

export const useCliente = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const loginCliente = async (usuario, password) => {
    setLoading(true);
    setError(''); // Limpiar el error antes de hacer la llamada
  
    try {
      const response = await api.get(`/Cliente/LoginCliente?x_usuario=${usuario}&x_password=${password}`);
      //console.log(response.data.estado); // verificacion del response

      if (response.data.estado === 'Exito') {
        return response.data;
      } else {
        setError(response.data.Mensaje);
        throw new Error(response.data.Mensaje);
      }
    } catch (error) {
      console.error('Error de login:', error);
      setError(error.response?.data?.Mensaje || 'Hubo un error al intentar hacer login');
      throw error;
    } finally {
      setLoading(false);
    }
  };

  return { loginCliente, loading, error };
};