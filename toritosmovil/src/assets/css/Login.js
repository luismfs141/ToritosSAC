import { StyleSheet } from 'react-native';

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
  subHeader: {
    fontSize: 16,
    color: '#888',
    marginBottom: 20,
  },
  input: {
    width: '100%',
    padding: 15,
    backgroundColor: '#eee',
    borderRadius: 10,
    marginBottom: 15,
  },
  forgotText: {
    alignSelf: 'flex-end',
    color: '#999',
    marginBottom: 20,
  },
  signInButton: {
    width: '100%',
    borderRadius: 10,
  },
  signInGradient: {
    padding: 15,
    borderRadius: 10,
    alignItems: 'center',
  },
  signInText: {
    color: '#fff',
    fontSize: 16,
    fontWeight: 'bold',
  },
  footer: {
    flexDirection: 'row',
    marginTop: 20,
  },
  footerText: {
    color: '#888',
  },
  createText: {
    color: '#333',
    fontWeight: 'bold',
  },
});

export default styles;
