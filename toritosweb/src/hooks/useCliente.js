import { useState } from 'react';
import api from '../api/apiConfig';

export const useCliente = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  // Función para obtener el cliente de localStorage
  const getClienteFromLocalStorage = () => {
    const loginCliente = JSON.parse(localStorage.getItem('usuario'));
    
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
  };

  // Función de login del cliente
  const loginCliente = async (usuario, password) => {
    setLoading(true);
    setError(''); // Limpiar el error antes de hacer la llamada
    console.log(password);
  
    try {
      const response = await api.get(`/Cliente/LoginCliente?x_usuario=${usuario}&x_password=${password}`);

  
      if (response.data.estado === 'Exito') {
        localStorage.setItem('usuario',JSON.stringify(response.data.data));
  
        return response.data; // Retorna la respuesta completa o los datos necesarios
      } else {
        setError(response.data.mensaje); // Asegúrate de que 'mensaje' es el nombre correcto
        throw new Error(response.data.mensaje); // Usa el nombre correcto de la propiedad del mensaje
      }
    } catch (err) {
      console.error('Error de login:', err);
      setError(err.response?.data?.mensaje || 'Hubo un error al intentar hacer login');
      throw err;
    } finally {
      setLoading(false);
    }
  };


  // Función para registrar un nuevo cliente
  const registrarCliente = async (ClienteData) => {
    setLoading(true);
    setError(''); // Limpiar el error antes de hacer la llamada
  
    try {
      const response = await api.post('/Cliente/GuardarCliente', ClienteData); 
      
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

  // Función para eliminar el cliente de localStorage (Cerrar sesión)
  const logoutCliente = () => {
    localStorage.removeItem('cliente');
  };

  return {
    loginCliente,
    registrarCliente,
    logoutCliente,
    getClienteFromLocalStorage,
    loading,
    error
  };
};