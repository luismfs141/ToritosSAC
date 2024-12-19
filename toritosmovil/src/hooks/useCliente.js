import { useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';
import api from '../api/apiConfig';

export const useCliente = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  // Función para obtener el cliente desde AsyncStorage
  const getClienteFromAsyncStorage = async () => {
    try {
      const loginCliente = await AsyncStorage.getItem('usuario');
      if (!loginCliente) {
        console.warn('No se encontró ningún usuario en AsyncStorage');
        return null;
      }

      const parsedCliente = JSON.parse(loginCliente);
      const clienteData = {
        idClienteI: parsedCliente.idClienteI,
        codigoC: parsedCliente.codigoC,
        nombreNv: parsedCliente.nombreNv,
        apellidoPaternoNv: parsedCliente.apellidoPaternoNv,
        apellidoMaternoNv: parsedCliente.apellidoMaternoNv,
        tipoDocumentoC: parsedCliente.tipoDocumentoC,
        nroDocumentoV: parsedCliente.nroDocumentoV,
        sexoC: parsedCliente.sexoC,
        fechaNacimientoD: parsedCliente.fechaNacimientoD,
        estadoCivilC: parsedCliente.estadoCivilC,
        nroContactoC: parsedCliente.nroContactoC,
        correoNv: parsedCliente.correoNv,
        correoAutenticadoBo: parsedCliente.correoAutenticadoBo,
        direccionNv: parsedCliente.direccionNv,
        direccionRefNv: parsedCliente.direccionRefNv,
        idDistritoC: parsedCliente.idDistritoC,
        passwordBi: parsedCliente.passwordBi,
        estadoC: parsedCliente.estadoC,
        fechaInscripcionD: parsedCliente.fechaInscripcionD
      };
      return clienteData;
    } catch (error) {
      console.error('Error al obtener el cliente desde AsyncStorage:', error);
      return null;
    }
  };

  const loginCliente = async (usuario, password) => {
    setLoading(true);
    setError('');

    try {
      console.log('Datos recibidos para login:', { usuario, password });

      const url = `http://10.10.20.251/ToritosHost/api/Cliente/LoginCliente?x_usuario=${usuario}&x_password=${password}`;
      console.log('URL de solicitud:', url);

      const response = await api.get(url);
      console.log('Respuesta del servidor:', response);

      if (response.data.estado === 'Exito') {
        // Guardar datos en AsyncStorage
        await AsyncStorage.setItem('usuario', JSON.stringify(response.data.data));
        console.log('Datos guardados en AsyncStorage:', await AsyncStorage.getItem('usuario'));
        return response.data;
      } else {
        setError(response.data.mensaje);
        throw new Error(response.data.mensaje);
      }
    } catch (err) {
      console.error('Error de login:', err);
      setError(err.response?.data?.mensaje || 'Hubo un error al intentar hacer login');
      throw err;
    } finally {
      setLoading(false);
    }
  };

  const registrarCliente = async (ClienteData) => {
    setLoading(true);
    setError('');

    try {
      console.log('Datos enviados para registro:', ClienteData);

      const response = await api.post('/Cliente/GuardarCliente', ClienteData);

      console.log('Respuesta del servidor al registrar:', response);

      if (response.data.estado === 'Exito') {
        return response.data;
      } else {
        setError(response.data.Mensaje);
        throw new Error(response.data.Mensaje);
      }
    } catch (err) {
      console.error('Error de registro:', err);
      setError(err.response?.data?.Mensaje || 'Hubo un error al intentar registrar el cliente');
      throw err;
    } finally {
      setLoading(false);
    }
  };

  const logoutCliente = async () => {
    await AsyncStorage.removeItem('usuario');
    console.log('Cliente eliminado de AsyncStorage');
  };

  return {
    loginCliente,
    registrarCliente,
    logoutCliente,
    getClienteFromAsyncStorage,
    loading,
    error
  };
};
