
import { Container } from 'react-bootstrap';
import NavBar from './components/NavBar';
import AppRouter from './components/AppRouter';
import { useAppDispatch, useAppSelector } from './hooks/redux';
import { useEffect } from 'react';
import { getAllOrganizations } from './store/slices/OrganizationsSlices';


const App = () => {

  const { } = useAppSelector(state => state.organizationReducer)
  const dispatch = useAppDispatch()

  useEffect(() => {
    dispatch(getAllOrganizations())
  }, [dispatch])

  return (
    <Container>
      <NavBar />
      <AppRouter />
    </Container>
  );
}

export default App;
