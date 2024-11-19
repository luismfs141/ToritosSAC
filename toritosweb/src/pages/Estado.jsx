import React, { useState } from 'react';

const Estado = () => {
  const [data, setData] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [newEntry, setNewEntry] = useState({ name: '', email: '' });
  const [editId, setEditId] = useState(null);
  const [filterOption, setFilterOption] = useState('');

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
    setNewEntry({ name: '', email: '' });
  };

  const handleDelete = (id) => {
    setData(data.filter((item) => item.id !== id));
  };

  const handleEdit = (item) => {
    setNewEntry({ name: item.name, email: item.email });
    setEditId(item.id);
  };

  const handleSearch = () => {
    setSearchTerm(searchTerm.trim());
  };

  const handleFilter = () => {
    setFilterOption(filterOption.trim());
  };

  const filteredData = data
    .filter((item) => item.name.toLowerCase().includes(searchTerm.toLowerCase()))
    .filter((item) => (filterOption ? item.email === filterOption : true));

  return (
    <div className="container mt-4 mb-4">
      <h3 className="mb-4">Tabla de Registros</h3>

      {/* Sección de búsqueda */}
      <div className="input-group mb-3">
        <input
          type="text"
          className="form-control me-2"
          placeholder="Buscar por nombre"
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
          <div className="col-md-4">
            <div className="form-group">
              <label>Nombre</label>
              <input
                type="text"
                className="form-control"
                placeholder="Ingresa el nombre"
                value={newEntry.name}
                onChange={(e) =>
                  setNewEntry({ ...newEntry, name: e.target.value })
                }
              />
            </div>
          </div>
          <div className="col-md-4">
            <div className="form-group">
              <label>Email</label>
              <input
                type="email"
                className="form-control"
                placeholder="Ingresa el email"
                value={newEntry.email}
                onChange={(e) =>
                  setNewEntry({ ...newEntry, email: e.target.value })
                }
              />
            </div>
          </div>
        </div>

        {/* Botones */}
        <div className="row mb-3">
          <div className="col-md-4">
            <button
              type="button"
              className="btn btn-primary w-100"
              onClick={handleAddOrUpdate}
            >
              {editId ? 'Actualizar' : 'Agregar'}
            </button>
          </div>

          <div className="col-md-4">
            {/* Filtro de email */}
            <select
              className="form-select w-100"
              value={filterOption}
              onChange={(e) => setFilterOption(e.target.value)}
            >
              <option value="">Filtrar por email</option>
              {data
                .map((item) => item.email)
                .filter((value, index, self) => self.indexOf(value) === index)
                .map((email) => (
                  <option key={email} value={email}>
                    {email}
                  </option>
                ))}
            </select>
          </div>

          <div className="col-md-4">
            <button
              className="btn btn-info w-100"
              onClick={handleFilter}
            >
              Filtrar
            </button>
          </div>
        </div>
      </form>

      {/* Tabla de registros - Añadimos 'table-responsive' para que sea responsive */}
      <div className="table-responsive">
        <table className="table table-striped table-bordered">
          <thead>
            <tr>
              <th>ID</th>
              <th>Nombre</th>
              <th>Email</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
            {filteredData.map((item) => (
              <tr key={item.id}>
                <td>{item.id}</td>
                <td>{item.name}</td>
                <td>{item.email}</td>
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
    </div>
  );
};

export default Estado;
