import api from '../api/apiConfig';

export const useCuota = () => {
    const generarCuotasClienteGrupo = async(idGrupo) =>{
        try {
            const response = await api.post(`/Cuota/GenerarCuotasClienteGrupo?idGrupo=${idGrupo}`);

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al crear el cronograma", error);
        }
    };

    const listarCuotasClienteGrupo = async(idCliente, idGrupo) =>{
        try {
            const response = await api.get(`/Cuota/ListarCuotasClienteGrupo?idCliente=${idCliente}&idGrupo=${idGrupo}`);

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al crear el cronograma", error);
        }
    };

    const recalcularCuotasClienteGrupo = async(idCliente, idGrupo, montoPagado) =>{
        try {
            const response = await api.post(`/Cuota/RecalcularCuotasClienteGrupo?idCliente=${idCliente}&idGrupo=${idGrupo}&montoPagado=${montoPagado}`);

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
        generarCuotasClienteGrupo,
        listarCuotasClienteGrupo,
        recalcularCuotasClienteGrupo
    }
}