import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Login from './src/screens/Login';
import Cronograma from './src/screens/Cronograma';
import Detalles from "./src/screens/Detalles";
import Soporte from "./src/screens/Soporte";
import Config from "./src/screens/Config";

const Stack = createStackNavigator();
const Tab = createBottomTabNavigator();

function MyTabs() {
    return (
        <Tab.Navigator>
            <Tab.Screen name="Cronograma" component={Cronograma} />
            <Tab.Screen name="Detalles" component={Detalles} />
            <Tab.Screen name="Soporte" component={Soporte} />
            <Tab.Screen name="Config" component={Config} />
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
