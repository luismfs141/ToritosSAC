import React, { useState, useEffect } from 'react';

const ModalPagoCuota = ({cliente, grupo, cuota, show, onClose, onSave }) => {

    const [datosPago, setDatosPago] = useState({
        idPagoI: 0,
        idClienteI : 0,
        idGrupoI : 0,
        codigoPagoV :'',
        montoPagoN : 0,
        penalidadN : 0,
        fechaPagoD : new Date().toISOString(),
        opcionPagoC: 'D',
        conceptoC: 'C'
    });

    useEffect(() => {
        if(cliente && grupo && cuota) {
            setDatosPago(prevState => ({
                ...prevState,
                idClienteI : cliente.idClienteI,
                idGrupoI : grupo.idGrupoI,
                montoPagoN : cuota.montoCuotaN + cuota.penalidadN,
                penalidadN : cuota.penalidadN
            }));
        }
    }, [cliente, grupo, cuota]);

    const handleSubmit = (e) => {
        e.preventDefault();
        onSave(datosPago, cuota); // Enviar los datos al controlador
      };

    return (
    <div className={`modal ${show ? 'show' : ''}`} tabIndex="-1" style={{ display: show ? 'block' : 'none' }}>
        <div className="modal-dialog" style={{ maxWidth: '25%' }}>
            <div className="modal-content">
                <div className="modal-header">
                <h5 className="modal-title">Pago de cuotas</h5>
                <button type="button" className="btn-close" onClick={onClose}></button>
                </div>
                <div className="modal-body">
                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <label htmlFor="montoCuota" className="form-label">Monto Cuota</label>
                        <input
                            type="number"
                            className="form-control"
                            id="montoCuota"
                            value={datosPago?datosPago.montoPagoN:0}
                            readOnly
                        />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="penalidadCuota" className="form-label">Penalidad</label>
                        <input
                            type="number"
                            className="form-control"
                            id="penalidadCuota"
                            value={datosPago?datosPago.penalidadN:0}
                            readOnly
                        />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="totalCuota" className="form-label">Total: S/. {datosPago?datosPago.montoPagoN + datosPago.penalidadN : 0}</label>
                    </div>
                    <div className="modal-footer">
                        <button type="submit" className="btn btn-success">Pagar Cuota</button>
                    </div>
                </form>
                </div>
            </div>
        </div>
    </div>
    );
};
export default ModalPagoCuota;