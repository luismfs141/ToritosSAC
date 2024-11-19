import React, { useState } from 'react';

const Grupos = () => {
  const [data, setData] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [newEntry, setNewEntry] = useState({ code: '', status: '', startDate: '', fee: '', period: '' });
  const [editId, setEditId] = useState(null);
  const [filterOption, setFilterOption] = useState('');
  const [modalContent, setModalContent] = useState(null);

  const handleAddOrUpdate = () => {
    if (editId) {
      setData(
        data.map((item) =>
          item.id === editId ? { ...item, ...newEntry } : item
        )
      );
      setEditId(null);
    } else {
      setData([...data, { ...newEntry, id: Date.now() }]);
    }
    setNewEntry({ code: '', status: '', startDate: '', fee: '', period: '' });
  };

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

  const handleFilter = () => {
    setFilterOption(filterOption.trim());
  };

  const filteredData = data
    .filter((item) => item.code.toLowerCase().includes(searchTerm.toLowerCase()))
    .filter((item) => (filterOption ? item.status === filterOption : true));

  const handleShowDetails = (content) => {
    setModalContent(content);
  };

  const handleCloseModal = () => {
    setModalContent(null);
  };

  return (
    <div className="container mt-4 mb-4">
      <h3 className="mb-4">Grupos</h3>

      {/* Sección de búsqueda */}
      <div className="input-group mb-3">
        <input
          type="text"
          className="form-control me-2"
          placeholder="Buscar por código"
          onChange={(e) => setSearchTerm(e.target.value)}
          value={searchTerm}
        />
        <button className="btn btn-secondary" onClick={handleSearch}>
          Buscar
        </button>
      </div>

      {/* Formulario para agregar o actualizar registro */}
      <form className="mb-4" onSubmit={(e) => e.preventDefault()}>
        <div className="row mb-3">
          <div className="col-md-3">
            <div className="form-group">
              <label>Código</label>
              <input
                type="text"
                className="form-control"
                placeholder="Código"
                value={newEntry.code}
                onChange={(e) =>
                  setNewEntry({ ...newEntry, code: e.target.value })
                }
              />
            </div>
          </div>
          <div className="col-md-3">
            <div className="form-group">
              <label>Estado</label>
              <input
                type="text"
                className="form-control"
                placeholder="Estado"
                value={newEntry.status}
                onChange={(e) =>
                  setNewEntry({ ...newEntry, status: e.target.value })
                }
              />
            </div>
          </div>
          <div className="col-md-3">
            <div className="form-group">
              <label>Fecha de Inicio</label>
              <input
                type="date"
                className="form-control"
                value={newEntry.startDate}
                onChange={(e) =>
                  setNewEntry({ ...newEntry, startDate: e.target.value })
                }
              />
            </div>
          </div>
          <div className="col-md-3">
            <div className="form-group">
              <label>Cuota</label>
              <input
                type="number"
                className="form-control"
                placeholder="Cuota"
                value={newEntry.fee}
                onChange={(e) =>
                  setNewEntry({ ...newEntry, fee: e.target.value })
                }
              />
            </div>
          </div>
          <div className="col-md-3">
            <div className="form-group">
              <label>Periodo</label>
              <input
                type="text"
                className="form-control"
                placeholder="Periodo"
                value={newEntry.period}
                onChange={(e) =>
                  setNewEntry({ ...newEntry, period: e.target.value })
                }
              />
            </div>
          </div>
        </div>

        {/* Botón para agregar o actualizar */}
        <button
          type="button"
          className="btn btn-primary"
          onClick={handleAddOrUpdate}
        >
          {editId ? 'Actualizar' : 'Agregar'}
        </button>
      </form>

      {/* Tabla de registros */}
      <div className="table-responsive">
        <table className="table table-striped table-bordered">
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
            {filteredData.map((item) => (
              <tr key={item.id}>
                <td>{item.code}</td>
                <td>{item.status}</td>
                <td>{item.startDate}</td>
                <td>{item.fee}</td>
                <td>{item.period}</td>
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
                    className="btn btn-warning me-2"
                    onClick={() => handleEdit(item)}
                  >
                    Editar
                  </button>
                  <button
                    className="btn btn-danger"
                    onClick={() => handleDelete(item.id)}
                  >
                    Eliminar
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* Modal para mostrar detalles o integrantes */}
      {modalContent && (
        <div className="modal-overlay" onClick={handleCloseModal}>
          <div className="modal-content">
            <h5>{modalContent}</h5>
            <button className="btn btn-secondary" onClick={handleCloseModal}>
              Cerrar
            </button>
          </div>
        </div>
      )}

      {/* Estilos para el modal */}
      <style jsx>{`
        .modal-overlay {
          position: fixed;
          top: 0;
          left: 0;
          right: 0;
          bottom: 0;
          background: rgba(0, 0, 0, 0.7);
          display: flex;
          justify-content: center;
          align-items: center;
          z-index: 999;
        }
        .modal-content {
          background: white;
          padding: 20px;
          border-radius: 8px;
          text-align: center;
          max-width: 500px;
          width: 90%;
        }
      `}</style>
    </div>
  );
};

export default Grupos;
