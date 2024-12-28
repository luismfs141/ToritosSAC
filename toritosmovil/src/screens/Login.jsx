import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, Alert } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import styles from '../assets/css/Login.js';
import { useCliente } from '../hooks/useCliente';

export default function Login({ navigation }) {
    const [usuario, setUsuario] = useState('');
    const [password, setPassword] = useState('');
    const { loginCliente, loading, error } = useCliente();

    const handleLogin = async () => {
        if (usuario && password) {
            try {
                await loginCliente(usuario, btoa(password));
                navigation.replace('Tabs');
            } catch (err) {
                console.error('Error de inicio de sesión:', err);
                Alert.alert('Error', 'Usuario o contraseña incorrectos');
            }
        } else {
            Alert.alert('Error', 'Por favor, ingrese su usuario y contraseña');
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
            <Text style={styles.subHeader}>Inicia Sesion</Text>

            <TextInput
                style={styles.input}
                placeholder="usuario"
                placeholderTextColor="#aaa"
                value={usuario}
                onChangeText={setUsuario}
            />
            <TextInput
                style={styles.input}
                placeholder="••••••"
                placeholderTextColor="#aaa"
                secureTextEntry={true}
                value={password}
                onChangeText={setPassword}
            />

            <TouchableOpacity
                style={styles.signInButton}
                onPress={handleLogin}
            >
                <LinearGradient
                    colors={['#50007b', '#50007b']}
                    style={styles.signInGradient}
                >
                    <Text style={styles.signInText}>
                        INICIAR SESIÓN
                    </Text>
                </LinearGradient>
            </TouchableOpacity>
        </View>
    );
}
