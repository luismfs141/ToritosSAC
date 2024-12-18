import { StyleSheet } from 'react-native';

const styles = StyleSheet.create({
  container: {
      padding: 20,
      backgroundColor: '#f5f5f5',
  },
  headerContainer: {
      padding: 20,
      borderRadius: 5,
      marginBottom: 20,
      alignItems: 'center',
      justifyContent: 'center',
  },
  header: {
      fontSize: 20,
      fontWeight: 'bold',
      color: '#fff',
  },
  subHeader: {
      fontSize: 18,
      fontWeight: '600',
      marginVertical: 10,
  },
  text: {
      fontSize: 16,
      marginBottom: 15,
      textAlign: 'center',
  },
  contactContainer: {
      marginBottom: 20,
  },
  contactText: {
      fontSize: 16,
      marginVertical: 5,
  },
  contactDetail: {
      color: '#50007b', 
  },
  faqContainer: {
      marginBottom: 15,
  },
  faqQuestion: {
      fontSize: 16,
      fontWeight: '500',
      marginBottom: 5,
      color: '#50007b', 
  },
  faqAnswer: {
      fontSize: 14,
      marginBottom: 10,
  },
});

export default styles;
