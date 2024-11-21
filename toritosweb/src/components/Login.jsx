import React, { useState } from 'react';
import { useCliente } from '../hooks/useCliente';

const LoginForm = () => {
  const [usuario, setUsuario] = useState('');
  const [password, setPassword] = useState('');
  const { loginCliente, loading, error } = useCliente();

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const data = await loginCliente(usuario, password);
      console.log('Login Exitoso:', data);
      // Aqu� puedes redirigir al usuario a otra p�gina si es necesario
    } catch (err) {
      console.error('Error de login:', err);
    }
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Usuario</label>
          <input 
            type="text" 
            value={usuario} 
            onChange={(e) => setUsuario(e.target.value)} 
            required 
          />
        </div>
        <div>
          <label>Contrase�a</label>
          <input 
            type="password" 
            value={password} 
            onChange={(e) => setPassword(e.target.value)} 
            required 
          />
        </div>
        <button type="submit" disabled={loading}>
          {loading ? 'Cargando...' : 'Iniciar Sesi�n'}
        </button>
        {error && <div style={{ color: 'red' }}>{error}</div>}
      </form>
    </div>
  );
};

export default LoginForm;