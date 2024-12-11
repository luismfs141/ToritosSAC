import React from 'react';

const ModalDetallesGrupo = ({ show, onClose, detallesGrupo }) => {
  return (
    <div className={`modal ${show ? 'show' : ''}`} tabIndex="-1" style={{ display: show ? 'block' : 'none' }}>
      <div className="modal-dialog" style={{ maxWidth: '50%' }}>{/*Se puede modificar el ancho del modal */}
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Detalles del Grupo</h5>
            <button type="button" className="btn-close" onClick={onClose}></button>
          </div>
          <div className="modal-body">
            {detallesGrupo ? (
              <div>
                {/* Cabecera de detalles del grupo */}
                <div className="row mb-3">
                  <div className="col-6">
                    <p><strong>Código del Grupo:</strong> {detallesGrupo.codigoGrupo}</p>
                    <p><strong>Estado del Grupo:</strong> {detallesGrupo.estadoGrupo}</p>
                    <p><strong>Modelo del Vehículo:</strong> {detallesGrupo.modeloVehiculo ? detallesGrupo.modeloVehiculo.nombreNv : 'N/A'}</p>
                    <p><strong>Administrador del Grupo:</strong> {detallesGrupo.adminGrupo ? `${detallesGrupo.adminGrupo.nombreNv} ${detallesGrupo.adminGrupo.apellidoPaternoNv}` : 'N/A'}</p>
                  </div>
                  <div className="col-6">
                    <p><strong>Tipo de Periodo:</strong> {detallesGrupo.tipoPeriodo}</p>
                    <p><strong>Cuota:</strong> {detallesGrupo.montoCuota}</p>
                    <p><strong>Número de Cuotas:</strong> {detallesGrupo.numeroCuotas}</p>
                    <p><strong>Fecha de Creación:</strong> {detallesGrupo.fechaCreacion ? new Date(detallesGrupo.fechaCreacion).toLocaleDateString() : 'N/A'}</p>
                    <p><strong>Fecha de Inicio:</strong> {detallesGrupo.fechaInicio ? new Date(detallesGrupo.fechaInicio).toLocaleDateString() : 'N/A'}</p>
                  </div>
                </div>

                {/* Tabla de integrantes del grupo */}
                <h6><strong>Integrantes del Grupo</strong></h6>
                <table className="table table-bordered">
                  <thead>
                    <tr>
                      <th>Nombre</th>
                      <th>Apellido</th>
                      <th>Email</th>
                    </tr>
                  </thead>
                  <tbody>
                    {detallesGrupo.integrantesGrupo?.length > 0 ? (
                      detallesGrupo.integrantesGrupo.map((integrante, index) => (
                        <tr key={index}>
                          <td>{integrante.nombreNv}</td>
                          <td>{integrante.apellidoPaternoNv}</td>
                          <td>{integrante.correoNv}</td>
                        </tr>
                      ))
                    ) : (
                      <tr>
                        <td colSpan="3" className="text-center">No hay integrantes</td>
                      </tr>
                    )}
                  </tbody>
                </table>
              </div>
            ) : (
              <p>No se encontró información para este grupo.</p>
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

export default ModalDetallesGrupo;