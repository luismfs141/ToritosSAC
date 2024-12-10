import api from '../api/apiConfig';

export const useGrupo = () => {

    const getGruposPorCliente = async (clienteData) =>{
        try {
            const response = await api.get(`/Grupo/ObtenerGruposPorCliente?idCliente=${clienteData.idClienteI}`);
            // Aseguramos que 'response.data.objeto' siempre sea un arreglo
            return Array.isArray(response.data.objeto) ? response.data.objeto : [];
        } catch (error) {
            console.error("Error al obtener los grupos:", error);
            return [];
        }
    };

    const guardarGrupo = async (clienteData,grupoData) =>{
        try {
            const request = {'Cliente':clienteData,'Grupo':grupoData};
            const response = await api.post('/Grupo/GuardarGrupo',request);

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al obtener los grupos:", error);
        }
    };

    const buscarGrupoCodigo = async (codigoGrupo) =>{
        try{
            const response = await api.get(`/Grupo/ObtenerGrupoPorCodigo?codigoGrupo=${codigoGrupo}`);
            if(response.data.exito){
                return response.data.objeto;
            }
            else{
                throw new Error(response.data.Mensaje);
            }
        }
        catch (error){
            console.error("Error al obtener los grupos:", error);
        }
    }

    const agregarListaGrupoCliente = async (grupoData, clienteData) =>{
        try{
            const request = {'Cliente':clienteData,'Grupo':grupoData};
            console.log(request);
            const response = await api.post('/Grupo/AgregarListaGrupoCliente', request);
            if(response.data.exito){
                return response.data;
            }
            else{
                throw new Error(response.data.Mensaje);
            }
        }
        catch (error){
            console.error("Error al obtener los grupos:", error);
        }
    }

    return{
        getGruposPorCliente,
        guardarGrupo,
        buscarGrupoCodigo,
        agregarListaGrupoCliente
    };
};