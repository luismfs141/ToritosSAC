import api from '../api/apiConfig';

export const useDocumento = () => {

    const guardarDocumento = async (documentoData, clienteData, grupoData) => {
        try {
            // Verifica si los archivos existen antes de convertirlos
            if (documentoData.documentoIdentidad) {
                const docIdentidad = await convertirArchivoEnBase64(documentoData.documentoIdentidad);
                documentoData.documentoIdentidad = docIdentidad;
            }

            if (documentoData.antecedentesPenales) {
                const docPenales = await convertirArchivoEnBase64(documentoData.antecedentesPenales);
                documentoData.antecedentesPenales = docPenales;
            }

            if (documentoData.reciboAguaLuz) {
                const docAguaLuz = await convertirArchivoEnBase64(documentoData.reciboAguaLuz);
                documentoData.reciboAguaLuz = docAguaLuz;
            }

            // Crear el objeto de solicitud
            const request = { 'Documento': documentoData, 'Cliente': clienteData, 'Grupo': grupoData };

            // Realizar la solicitud POST
            const response = await api.post('/Documento/GuardarDocumento', request);
            console.log(response);
            if (response.data.exito) {
                return response.data;
            } else {
                throw new Error(response.data.Mensaje);
            }
        } catch (error) {
            console.error("Error al guardar el documento:", error);
            throw error; // Vuelve a lanzar el error para que sea manejado en otro nivel si es necesario
        }
    };

    const getDocumentoPorClienteGrupo = async (clienteData,grupoData)=>{
        try {
            const request = {'Cliente':clienteData,'Grupo':grupoData};
            const response = await api.post('/Documento/ObtenerDocumentoPorClienteGrupo',request);
            //console.log(response.data.objeto);
            return response.data.objeto;
        } catch (error) {
            console.error("Error al obtener los grupos:", error);
        }
    };

    const convertirArchivoEnBase64 = (archivo) => {
        return new Promise((resolve, reject) => {
            // Verifica si el archivo es de tipo Blob (File es un tipo de Blob)
            if (!(archivo instanceof Blob)) {
                reject(new Error('El archivo proporcionado no es de tipo Blob.'));
                return;
            }

            const reader = new FileReader();
            reader.onloadend = () => {
                // Aquí tienes el archivo como un string en base64
                resolve(reader.result.split(',')[1]);  // Elimina la parte "data:image/png;base64," o similar
            };
            reader.onerror = reject;
            reader.readAsDataURL(archivo);  // Esto convierte el archivo en base64
        });
    };

    return{
        guardarDocumento,
        getDocumentoPorClienteGrupo
    }
}