import api from '../api/apiConfig';

export const useSorteo = () => {

    const obtenerSorteosGrupo = async(idGrupo) =>{
        try {
            const response = await api.get(`/Sorteo/ObtenerSorteosPorGrupo?idGrupo=${idGrupo}`);
            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.mensaje);
              }
        } catch (error) {
            console.error("Error al obtener los sorteos", error);
        }
    };

    const guardarSorteo = async(x_sorteo) =>{
        try {
            const response = await api.post(`/sorteo/GuardarSorteo?x_sorteo=${x_sorteo}`);

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al guardar el sorteo", error);
        }
    };

    const ObtenerProximoFechaSorteo = async(idGrupo) =>{
        try {
            const response = await api.get(`/Sorteo/ObtenerProximoFechaSorteo?idGrupo=${idGrupo}`);
            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.mensaje);
              }
        } catch (error) {
            console.error("Error al obtener los sorteos", error);
        }
    };

    const ObtenerMartillazoPeriodo = async(idGrupo) =>{
        try {
            const response = await api.get(`/Sorteo/ObtenerMartillazoPeriodo?idGrupo=${idGrupo}`);
            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.mensaje);
              }
        } catch (error) {
            console.error("Error al obtener los sorteos", error);
        }
    };

    return{
        obtenerSorteosGrupo,
        guardarSorteo,
        ObtenerProximoFechaSorteo,
        ObtenerMartillazoPeriodo
    };
}