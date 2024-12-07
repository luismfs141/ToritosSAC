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
    return{
        getGruposPorCliente
    };
};