import React, { useState } from 'react';
import { useCliente } from '../hooks/useCliente';
import { Link } from 'react-router-dom';

const LoginForm = ({ onLogin }) => {
  const [usuario, setUsuario] = useState('');
  const [password, setPassword] = useState('');
  const { loginCliente, loading, error } = useCliente();

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const data = await loginCliente(usuario, password);
      console.log('Login Exitoso:', data);
      onLogin(); // Cambia el estado de autenticación
    } catch (err) {
      console.error('Error de login:', err);
    }
  };

  return (
    <div className="container d-flex justify-content-center align-items-center min-vh-100">
      <div className="card shadow-lg p-4" style={{ maxWidth: '400px', width: '100%' }}>
        {/* Imagen del logo */}
        <img
          src={require('../assetss/img/LogoToritos.png')}
          alt="Toritos Login"
          className="login-image img-fluid d-block mx-auto mb-4"
          style={{ maxWidth: '150px' }}
        />
        <h2 className="text-center mb-4">Iniciar Sesión</h2>
        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label htmlFor="usuario" className="form-label">Usuario</label>
            <input
              id="usuario"
              type="text"
              value={usuario}
              onChange={(e) => setUsuario(e.target.value)}
              required
              className="form-control"
            />
          </div>
          <div className="mb-3">
            <label htmlFor="password" className="form-label">Contraseña</label>
            <input
              id="password"
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
              className="form-control"
            />
          </div>
          <button type="submit" disabled={loading} className="btn btn-success w-100 mb-3">
            {loading ? 'Cargando...' : 'Iniciar Sesión'}
          </button>
          {error && <div className="alert alert-danger text-center">{error}</div>}
        </form>
        <div className="text-center">
          <p>¿No tienes cuenta? <Link to="/RegistroCliente">Crea una cuenta aquí</Link></p>
        </div>
      </div>
    </div>
  );
};

export default LoginForm;