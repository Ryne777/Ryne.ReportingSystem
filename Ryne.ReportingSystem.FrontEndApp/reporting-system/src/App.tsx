
import { FC } from 'react';
import './App.css';
import { Container } from 'react-bootstrap';
import NavBar from './components/NavBar';
import AppRouter from './components/AppRouter';


const App: FC = () => {


  return (
    <Container>
      <NavBar />
      <AppRouter />
    </Container>
  );
}

export default App;
