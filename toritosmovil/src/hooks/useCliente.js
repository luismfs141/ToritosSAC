import { useState } from 'react';
import api from '../api/apiConfig';

export const useCliente = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  /* Función para obtener el cliente de localStorage
  const getClienteFromLocalStorage = () => {
    const loginCliente = JSON.parse(localStorage.getItem('usuario'));

    if (!loginCliente) {
      console.warn('No se encontró ningún usuario en localStorage');
      return null;
    }

    const clienteData = {
      idClienteI: loginCliente.idClienteI,
      codigoC: loginCliente.codigoC,
      nombreNv: loginCliente.nombreNv,
      apellidoPaternoNv: loginCliente.apellidoPaternoNv,
      apellidoMaternoNv: loginCliente.apellidoMaternoNv,
      tipoDocumentoC: loginCliente.tipoDocumentoC,
      nroDocumentoV: loginCliente.nroDocumentoV,
      sexoC: loginCliente.sexoC,
      fechaNacimientoD: loginCliente.fechaNacimientoD,
      estadoCivilC: loginCliente.estadoCivilC,
      nroContactoC: loginCliente.nroContactoC,
      correoNv: loginCliente.correoNv,
      correoAutenticadoBo: loginCliente.correoAutenticadoBo,
      direccionNv: loginCliente.direccionNv,
      direccionRefNv: loginCliente.direccionRefNv,
      idDistritoC: loginCliente.idDistritoC,
      passwordBi: loginCliente.passwordBi,
      estadoC: loginCliente.estadoC,
      fechaInscripcionD: loginCliente.fechaInscripcionD
    };
    return clienteData;
  };*/

  const loginCliente = async (usuario, password) => {
    setLoading(true);
    setError('');

    try {

      console.log('Datos recibidos para login:', { usuario, password });


      const url = `http://192.168.0.107/ToritosHost/api/Cliente/LoginCliente?x_usuario=${usuario}&x_password=${password}`;
      console.log('URL de solicitud:', url);

      const response = await api.get(url);

      console.log('Respuesta del servidor:', response);

      if (response.data.estado === 'Exito') {
        //localStorage.setItem('usuario', JSON.stringify(response.data.data));
        //console.log('Datos guardados en localStorage:', localStorage.getItem('usuario'));
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

  const logoutCliente = () => {
    localStorage.removeItem('usuario');
    console.log('Cliente eliminado de localStorage');
  };

  return {
    loginCliente,
    registrarCliente,
    logoutCliente,
    //getClienteFromLocalStorage,
    loading,
    error
  };
};
