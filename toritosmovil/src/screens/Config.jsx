import React, { useState, useEffect } from 'react';
import { View, Text, StyleSheet, TouchableOpacity, Modal, TextInput, Button } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import { useCliente } from '../hooks/useCliente';
import styles from '../assets/css/Config';
import { useNavigation } from '@react-navigation/native';

const Configuracion = () => {
  const [userName, setUserName] = useState('');
  const [clienteData, setClienteData] = useState(null); 
  const { getClienteFromAsyncStorage } = useCliente(); 

  const navigation = useNavigation();  // Hook de navegación

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

  const handleLogout = () => {
    // Aquí puedes eliminar los datos de sesión (por ejemplo, eliminar el cliente de AsyncStorage)
    // Luego rediriges al Login
    navigation.navigate('Login');  // Suponiendo que tu pantalla de Login tiene este nombre
  };

  return (
    <View style={styles.container}>
      <LinearGradient colors={['#50007b', '#1b0030']} style={styles.logoContainer}>
        <View style={styles.logo}>
          <Text style={styles.logoText}>🙂</Text>
        </View>
      </LinearGradient>

      <Text style={styles.header}>ToritosSAC</Text>
      <Text style={styles.header1}> {userName || 'Cargando...'}</Text>
      <Text style={styles.header}></Text>
      <View style={styles.buttonContainer}>
        <TouchableOpacity style={styles.button} onPress={() => openModal('Cuenta')}>
          <Text style={styles.buttonText}>Cuenta</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.button} onPress={() => openModal('Cambiar Contraseña')}>
          <Text style={styles.buttonText}>Cambiar Contraseña</Text>
        </TouchableOpacity>
        {/* Botón Cerrar Sesión */}
        <TouchableOpacity style={styles.button} onPress={handleLogout}>
          <Text style={styles.buttonText}>Cerrar Sesión</Text>
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
                {/* Otros campos del cliente */}
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

export default Configuracion;
