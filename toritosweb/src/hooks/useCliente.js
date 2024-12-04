import { useState } from 'react';
import api from '../api/apiConfig';

export const useCliente = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const loginCliente = async (usuario, password) => {
    setLoading(true);
    setError(''); // Limpiar el error antes de hacer la llamada
  
    try {
      console.log(usuario);
      console.log(password);
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

  const registrarCliente = async (ClienteData) => {
    setLoading(true);
    setError(''); // Limpiar el error antes de hacer la llamada
  
    try {
      // Asegúrate de usar POST en lugar de GET
      console.log(ClienteData);
      const response = await api.post('/Cliente/GuardarCliente', ClienteData); 
      
      if (response.data.estado === 'Exito') {
        return response.data;
      } else {
        setError(response.data.Mensaje);
        throw new Error(response.data.Mensaje);
      }
    } catch (error) {
      console.error('Error de registro:', error);
      setError(error.response?.data?.Mensaje || 'Hubo un error al intentar registrar el cliente');
      throw error;
    } finally {
      setLoading(false);
    }
  };

  return { loginCliente, registrarCliente,loading, error };
};