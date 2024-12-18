import React, { useState, useEffect } from 'react';
import { View, Text, StyleSheet, TouchableOpacity, Modal, TextInput, Button } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useCliente } from '../hooks/useCliente';

const Configuracion = () => {
  const [userName, setUserName] = useState('');
  const [clienteData, setClienteData] = useState(null); 
  const { getClienteFromAsyncStorage } = useCliente(); 

  useEffect(() => {
    const loadClienteData = async () => {
      const cliente = await getClienteFromAsyncStorage(); 
      if (cliente) {
        const fullName = `${cliente.nombreNv} ${cliente.apellidoPaternoNv} ${cliente.apellidoMaternoNv}`;
        setUserName(fullName);
        setClienteData(cliente);
      }
    };

    loadClienteData();
  }, [getClienteFromAsyncStorage]);

  const [isModalVisible, setIsModalVisible] = useState(false);
  const [modalContent, setModalContent] = useState('');
  const [newPassword, setNewPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');

  const openModal = (type) => {
    setModalContent(type);
    setIsModalVisible(true);
  };

  const closeModal = () => {
    setIsModalVisible(false);
    setNewPassword('');
    setConfirmPassword('');
  };

  const handlePasswordChange = () => {
    if (newPassword === confirmPassword) {

      console.log('Contraseña cambiada');

      closeModal();
    } else {
      alert('Las contraseñas no coinciden');
    }
  };

  return (
    <View style={styles.container}>
      <LinearGradient colors={['#50007b', '#1b0030']} style={styles.logoContainer}>
        <View style={styles.logo}>
          <Text style={styles.logoText}>🙂</Text>
        </View>
      </LinearGradient>

      <Text style={styles.header}>ToritosSAC</Text>
      <Text style={styles.header1}>Bienvenido, {userName || 'Cargando...'}</Text>
      <Text style={styles.header}></Text>
      <View style={styles.buttonContainer}>
        <TouchableOpacity style={styles.button} onPress={() => openModal('Cuenta')}>
          <Text style={styles.buttonText}>Cuenta</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.button} onPress={() => openModal('Cambiar Contraseña')}>
          <Text style={styles.buttonText}>Cambiar Contraseña</Text>
        </TouchableOpacity>
      </View>

      {/* Modal */}
      <Modal
        visible={isModalVisible}
        animationType="fade"
        transparent={true}
        onRequestClose={closeModal}
      >
        <View style={styles.modalOverlay}>
          <View style={styles.modalContainer}>
            <Text style={styles.modalTitle}>{modalContent}</Text>

            {modalContent === 'Cuenta' && clienteData ? (
              <View style={styles.formContainer}>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Nombre:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.nombreNv}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Apellido Paterno:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.apellidoPaternoNv}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Apellido Materno:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.apellidoMaternoNv}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Número de Documento:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.nroDocumentoV}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Sexo:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.sexoC}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Fecha de Nacimiento:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.fechaNacimientoD}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Número de Contacto:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.nroContactoC}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Correo:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.correoNv}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Dirección:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.direccionNv}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Distrito:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.idDistritoC}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Estado:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.estadoC}
                    editable={false}
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Fecha de Inscripción:</Text>
                  <TextInput
                    style={styles.input}
                    value={clienteData.fechaInscripcionD}
                    editable={false}
                  />
                </View>

              </View>
            ) : modalContent === 'Cambiar Contraseña' ? (
              <View style={styles.formContainer}>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Nueva Contraseña:</Text>
                  <TextInput
                    style={styles.input}
                    value={newPassword}
                    onChangeText={setNewPassword}
                    secureTextEntry
                    placeholder="Ingresa nueva contraseña"
                  />
                </View>
                <View style={styles.formRow}>
                  <Text style={styles.label}>Confirmar Contraseña:</Text>
                  <TextInput
                    style={styles.input}
                    value={confirmPassword}
                    onChangeText={setConfirmPassword}
                    secureTextEntry
                    placeholder="Confirma la nueva contraseña"
                  />
                </View>
              </View>
            ) : null}

            <Button title={modalContent === 'Cambiar Contraseña' ? 'Guardar Cambios' : 'Cerrar'} onPress={modalContent === 'Cambiar Contraseña' ? handlePasswordChange : closeModal} />
          </View>
        </View>
      </Modal>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#f4f4f4',
    alignItems: 'center',
    justifyContent: 'center',
    padding: 20,
  },
  logoContainer: {
    width: 100,
    height: 100,
    borderRadius: 50,
    justifyContent: 'center',
    alignItems: 'center',
    marginBottom: 30,
  },
  logo: {
    backgroundColor: '#fff',
    padding: 20,
    borderRadius: 50,
  },
  logoText: {
    fontSize: 40,
  },
  header: {
    fontSize: 36,
    fontWeight: 'bold',
    color: '#333',
  },
  header1: {
    fontSize: 20,
    fontWeight: 'bold',
    color: '#333',
  },
  buttonContainer: {
    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'center',
    gap: 15,
  },
  button: {
    backgroundColor: '#50007b',
    padding: 15,
    borderRadius: 8,
    width: '80%',
    alignItems: 'center',
  },
  buttonText: {
    color: '#fff',
    fontSize: 18,
    fontWeight: 'bold',
  },
  modalOverlay: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'rgba(0, 0, 0, 0.5)', 
  },
  modalContainer: {
    width: '80%',
    padding: 20,
    backgroundColor: '#fff',
    borderRadius: 10,
    alignItems: 'center',
  },
  modalTitle: {
    fontSize: 20,
    fontWeight: 'bold',
    marginBottom: 15,
  },
  formContainer: {
    width: '100%',
  },
  formRow: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 10,
  },
  label: {
    fontSize: 14, 
    fontWeight: 'bold',
    width: '40%',
    color: '#333',
  },
  input: {
    flex: 1,
    height: 40,
    borderColor: '#ddd',
    borderWidth: 1,
    borderRadius: 5,
    paddingLeft: 10,
  },
});

export default Configuracion;
