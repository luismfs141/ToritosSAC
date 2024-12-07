import React, { useState,useEffect } from 'react';
import '../assetss/css/Modal.css';
import { useCliente } from '../hooks/useCliente';
import { useGrupo } from '../hooks/useGrupo';

const Grupos = () => {
  const [data, setData] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [newEntry, setNewEntry] = useState({ code: '', status: '', startDate: '', fee: '', period: '' });
  const [editId, setEditId] = useState(null);
  const [filterOption, setFilterOption] = useState('');
  const [modalContent, setModalContent] = useState(null);
  const [showCreateJoinModal, setShowCreateJoinModal] = useState(false);
  const [showCreateUModal, setShowCreateUModal] = useState(false);
  const [selectedOption, setSelectedOption] = useState('');
  const [gruposCliente, setGruposCliente] = useState([]);
  const { getClienteFromLocalStorage } = useCliente();
  const { getGruposPorCliente } = useGrupo();
  const [isInitialized, setIsInitialized] = useState(false); // Nuevo estado para evitar el ciclo infinito

  useEffect(() => {
    if (!isInitialized) {
      const clienteData = getClienteFromLocalStorage();
      if (clienteData) {
        const listaGrupo = getGruposPorCliente(clienteData);
        listaGrupo.then(grupos => {
          setGruposCliente(grupos); 
        });
      }
      setIsInitialized(true); // Cambiar el estado de isInitialized para que no se actualice nuevamente
    }
  }, [isInitialized, getClienteFromLocalStorage]); 

  const handleDelete = (id) => {
    setData(data.filter((item) => item.id !== id));
  };

  const handleEdit = (item) => {
    setNewEntry({
      code: item.code,
      status: item.status,
      startDate: item.startDate,
      fee: item.fee,
      period: item.period,
    });
    setEditId(item.id);
  };

  const handleSearch = () => {
    setSearchTerm(searchTerm.trim());
  };

  const filteredData = data
    .filter((item) => item.code.toLowerCase().includes(searchTerm.toLowerCase()))
    .filter((item) => (filterOption ? item.status === filterOption : true));

  const handleShowDetails = (content) => {
    setModalContent(content);
  };

  const handleCloseModal = () => {
    setModalContent(null);
    setShowCreateJoinModal(false);
    setShowCreateUModal(false);
  };

  const toggleCreateJoinModal = () => {
    setShowCreateJoinModal(!showCreateJoinModal);
  };

  const toggleCreateUModal = () => {
    setShowCreateUModal(!showCreateUModal);
  };

  const handleOptionChange = (e) => {
    setSelectedOption(e.target.value);
  };

  return (
    <div className="container mt-4 mb-4">
      <h3 className="mb-4">Grupos</h3>

      {/* Sección de búsqueda */}
      <div className="d-flex flex-column flex-sm-row align-items-center mb-3">
        <label htmlFor="searchDropdown" className="form-label me-2">
          Buscar Grupo:
        </label>
        <select
          id="searchDropdown"
          className="form-select me-2 mb-2 mb-sm-0"
          style={{ width: '250px' }}
          value={selectedOption}
          onChange={handleOptionChange}
        >
          <option value="">Seleccione un Grupo</option>
          <option value="nombre1">Nombre 1</option>
          <option value="nombre2">Nombre 2</option>
          <option value="nombre3">Nombre 3</option>
        </select>
        <button className="btn btn-primary me-2">
          Buscar
        </button>
      </div>

      {/* Botones Crear y Unirse a Grupo */}
      <div className="mb-3 d-flex flex-column flex-sm-row">
        <button className="btn btn-primary me-2 mb-2 mb-sm-0" onClick={() => toggleCreateJoinModal(false)}>
          Crear Grupo
        </button>
        <button className="btn btn-secondary" onClick={() => toggleCreateUModal(true)}>
          Unirse a Grupo
        </button>
      </div>

      {showCreateJoinModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h5>Configuración</h5>
            <form className="mb-4" onSubmit={(e) => e.preventDefault()}>
              <div className="mb-3 d-flex flex-column flex-sm-row align-items-center">
                <label className="me-2 w-25">Modelo de Vehículo</label>
                <select className="form-control w-75">
                  <option value="">Seleccione un modelo</option>
                  <option value="modelo1">Modelo 1</option>
                  <option value="modelo2">Modelo 2</option>
                  <option value="modelo3">Modelo 3</option>
                </select>
              </div>

              <div className="mb-3 d-flex flex-column flex-sm-row align-items-center">
                <label className="me-2 w-25">Precio</label>
                <input
                  type="number"
                  className="form-control w-75"
                  placeholder="Precio"
                  readOnly
                />
              </div>

              <div className="mb-3 d-flex flex-column flex-sm-row align-items-center">
                <label className="me-2 w-25">Cantidad de Integrantes</label>
                <select className="form-control w-75">
                  <option value="">Seleccione cantidad</option>
                  <option value="1">1</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </div>

              <div className="mb-3 d-flex flex-column flex-sm-row align-items-center">
                <label className="me-2 w-25">Número de Cuotas</label>
                <select className="form-control w-75">
                  <option value="">Seleccione cuotas</option>
                  <option value="3">3</option>
                  <option value="6">6</option>
                  <option value="12">12</option>
                </select>
              </div>

              <div className="mb-3 d-flex flex-column flex-sm-row align-items-center">
                <label className="me-2 w-25">Periodo</label>
                <select className="form-control w-75">
                  <option value="">Seleccione periodo</option>
                  <option value="mensual">Mensual</option>
                  <option value="semestral">Semestral</option>
                  <option value="anual">Anual</option>
                </select>
              </div>

              <div className="mb-3">
                <button className="btn btn-primary me-2">
                  Crear Grupo
                </button>
                <button className="btn btn-secondary" onClick={handleCloseModal}>
                  Cancelar
                </button>
              </div>
            </form>
          </div>
        </div>
      )}

      {showCreateUModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h5>Ingrese Código de Invitación</h5>
            <form className="mb-4" onSubmit={(e) => e.preventDefault()}>
              <div className="mb-3 d-flex justify-content-center">
                <input
                  type="text"
                  className="form-control w-75 text-center"
                  placeholder="Código"
                />
              </div>
              <div className="mb-3">
                <button className="btn btn-primary me-2">
                  Unirse
                </button>
                <button className="btn btn-secondary" onClick={handleCloseModal}>
                  Cancelar
                </button>
              </div>
            </form>
          </div>
        </div>
      )}

      {/* Tabla de grupos */}
      <div className="table-responsive">
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Código</th>
            <th>Estado</th>
            <th>Fecha de Inicio</th>
            <th>Cuota</th>
            <th>Periodo</th>
            <th>Detalles</th>
            <th>Integrantes</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {gruposCliente.map((item) => (
            <tr key={item.idGrupoI}>
              <td>{item.codigoC}</td>
              <td>
                {({
                  'A': 'Abierto',
                  'C': 'Cerrado',
                  'F': 'Funcionando',
                  'T': 'Terminado'
                })[item.estadoC] || 'En Espera'}
              </td>
              <td>{new Date(item.fechaInicioPanderoD).toLocaleDateString()}</td>
              <td>{item.precioUnidadVehiculoM}</td>
              <td>{item.tipoPeriodoPagoC}</td>
              <td>
                <button
                  className="btn btn-info"
                  onClick={() => handleShowDetails('Detalles del grupo')}
                >
                  Ver
                </button>
              </td>
              <td>
                <button
                  className="btn btn-info"
                  onClick={() => handleShowDetails('Integrantes del grupo')}
                >
                  Ver
                </button>
              </td>
              <td>
                <button
                  className="btn btn-warning"
                  onClick={() => handleEdit(item)}
                >
                  Editar
                </button>
                <button
                  className="btn btn-danger"
                  onClick={() => handleDelete(item.idGrupoI)}
                >
                  Eliminar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>

      {/* Modal de detalles */}
      {modalContent && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h5>{modalContent}</h5>
            <button className="btn btn-secondary" onClick={handleCloseModal}>
              Cerrar
            </button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Grupos;
