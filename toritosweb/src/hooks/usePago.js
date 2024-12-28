import api from '../api/apiConfig';

export const usePago = () => {
    const realizarPago = async (pago, idEstadoCuenta, idCuota)=>{
        try {
            console.log(pago);
            console.log(idEstadoCuenta);
            console.log(idCuota);
            
            const response = await api.post('/Pago/RealizarPago', {
                pago: pago,
                idEstadoCuenta: idEstadoCuenta,
                idCuota: idCuota
            });


            if (response.data.exito) {
                return response.data;
              } else {
                throw new Error(response.data.Mensaje);
              }
        } catch (error) {
            console.error("Error al realizar el pago.", error);
        }
    };

    return{
        realizarPago
    };
}