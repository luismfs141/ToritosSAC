import api from '../api/apiConfig';

export const useCronograma = () => {
    const crearCronogramaGrupo = async (idGrupo, fechaInicio)=>{
        try {
            const response = await api.post(`/CronogramaGrupo/GenerarCronogramaGrupo?idGrupo=${idGrupo}&fechaInicio=${fechaInicio}`);

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al crear el cronograma", error);
        }
    };

    const obtenerCronogramaGrupo = async (idGrupo)=>{
        try {
            const response = await api.get(`/CronogramaGrupo/ObtenerCronogramaGrupo?idGrupo=${idGrupo}`);

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al obtener el cronograma", error);
        }
    };

    return{
        crearCronogramaGrupo,
        obtenerCronogramaGrupo
    }
}