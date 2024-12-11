import React from 'react';

const ModalClientesPendientes = ({ show, onClose, clientes, onAccept, onReject }) => {
  return (
    <div className={`modal ${show ? 'show' : ''}`} tabIndex="-1" style={{ display: show ? 'block' : 'none' }}>
      <div className="modal-dialog" style={{ maxWidth: '50%' }}>
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Clientes Pendientes</h5>
            <button type="button" className="btn-close" onClick={onClose}></button>
          </div>
          <div className="modal-body">
            {clientes && clientes.length > 0 ? (
              <div>
                {/* Tabla de Clientes Pendientes */}
                <table className="table table-bordered">
                  <thead>
                    <tr>
                      <th>Nombres</th>
                      <th>Apellidos</th>
                      <th>Acciones</th>
                    </tr>
                  </thead>
                  <tbody>
                    {clientes.map((cliente) => (
                      <tr key={cliente.idClienteI}>
                        <td>{cliente.nombreNv}</td>
                        <td>{cliente.apellidoPaternoNv} {cliente.apellidoMaternoNv}</td>
                        <td>
                          <button 
                            className="btn btn-success me-2"
                            onClick={() => onAccept(cliente.idClienteI)}
                          >
                            Aceptar
                          </button>
                          <button 
                            className="btn btn-danger"
                            onClick={() => onReject(cliente.idClienteI)}
                          >
                            Rechazar
                          </button>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            ) : (
              <p>No hay clientes pendientes.</p>
            )}
          </div>
          <div className="modal-footer">
            <button type="button" className="btn btn-secondary" onClick={onClose}>Cerrar</button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ModalClientesPendientes;