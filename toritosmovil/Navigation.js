import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { Ionicons } from '@expo/vector-icons';

import Login from './src/screens/Login';
import Cronograma from './src/screens/Cronograma';
import Detalles from "./src/screens/Detalles";
import Soporte from "./src/screens/Soporte";
import Config from "./src/screens/Config";

const Stack = createStackNavigator();
const Tab = createBottomTabNavigator();

function MyTabs() {
    return (
        <Tab.Navigator
            screenOptions={{
                tabBarActiveTintColor: '#50007b', 
                tabBarInactiveTintColor: '#9E9E9E',
                tabBarStyle: {
                    backgroundColor: '#ffffff',
                    borderTopWidth: 0, 
                    paddingBottom: 0, 
                    height: 70,
                },
            }}
        >
            <Tab.Screen
                name="Cronograma"
                component={Cronograma}
                options={{
                    tabBarIcon: ({ color, size }) => (
                        <Ionicons name="calendar" size={size} color={color} />
                    ),
                }}
            />
            <Tab.Screen
                name="Detalles"
                component={Detalles}
                options={{
                    tabBarIcon: ({ color, size }) => (
                        <Ionicons name="information-circle" size={size} color={color} />
                    ),
                }}
            />
            <Tab.Screen
                name="Soporte"
                component={Soporte}
                
                options={{
                    tabBarIcon: ({ color, size }) => (
                        <Ionicons name="help-circle" size={size} color={color} />
                    ),
                }}
            />
            <Tab.Screen
                name="Config"
                component={Config}
                options={{
                    tabBarIcon: ({ color, size }) => (
                        <Ionicons name="settings" size={size} color={color} />
                    ),
                }}
            />
        </Tab.Navigator>
    );
}

export default function Navigation() {
    return (
        <NavigationContainer>
            <Stack.Navigator initialRouteName="Login">
                <Stack.Screen name="Login" component={Login} options={{ headerShown: false }} />
                <Stack.Screen name="Tabs" component={MyTabs} options={{ headerShown: false }} />
            </Stack.Navigator>
        </NavigationContainer>
    );
}
