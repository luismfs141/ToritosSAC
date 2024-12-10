import api from '../api/apiConfig';

export const useDocumento = () => {

    const guardarDocumento = async (documentoData) => {
        try {
            const response = await api.post('/Documento/GuardarDocumento', documentoData); 

            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al guardar el documento:", error);
        }
    }

    const getDocumentoPorClienteGrupo = async (clienteData,grupoData)=>{
        try {
            const request = {'Cliente':clienteData,'Grupo':grupoData};
            const response = await api.post('/Documento/ObtenerDocumentoPorClienteGrupo',request);
            if (response.data.exito) {
                return true;
              } 
            else {
                return false;
              }
        } catch (error) {
            console.error("Error al obtener los grupos:", error);
        }
    };

    return{
        guardarDocumento,
        getDocumentoPorClienteGrupo
    }
}