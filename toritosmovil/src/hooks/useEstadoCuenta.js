import api from '../api/apiConfig';

export const useEstadoCuenta = () => {
    const crearEstadoCuentaGrupo = async (idGrupo)=>{
        try {
            const response = await api.post(`/EstadoCuenta/GenerarEstadosCuentaClienteGrupo?idGrupo=${idGrupo}`);

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al crear el cronograma", error);
        }
    };

    const obtenerEstadoCuentaCliente = async (idCliente, idGrupo)=>{
        try {
            const response = await api.get(`/EstadoCuenta/ObtenerEstadoCuentaCliente?idCliente=${idCliente}&idGrupo=${idGrupo}`);

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al crear el cronograma", error);
        }
    };

    const obtenerDetallesEstadoCuentaCliente = async (idEstadoCuenta)=>{
        try {
            const response = await api.get(`/EstadoCuenta/ObtenerDetallesEstadoCuentaCliente?idEstadoCuenta=${idEstadoCuenta}`);

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al crear el cronograma", error);
        }
    };

    const registrarPagoEstadoCuenta = async (idEstadoCuenta, idPago)=>{
        try {
            const response = await api.post(`/EstadoCuenta/RegistrarPagoDetallesEstadoCuenta?idEstadoCuenta=${idEstadoCuenta}&idPago=${idPago}`);

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al crear el cronograma", error);
        }
    };

    return{
        crearEstadoCuentaGrupo,
        obtenerEstadoCuentaCliente,
        obtenerDetallesEstadoCuentaCliente,
        registrarPagoEstadoCuenta
    };
}