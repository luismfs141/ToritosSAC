import api from '../api/apiConfig';

export const usePago = () => {
    const realizarPago = async (pago, idEstadoCuenta, idCuota)=>{
        try {
            const response = await api.post(`/Pago/RealizarPago?x_pago=${pago}&idEstadoCuenta=${idEstadoCuenta}&idCuota=${idCuota}`);

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