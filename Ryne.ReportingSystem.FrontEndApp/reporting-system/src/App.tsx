
import { useEffect, useState } from 'react';
import './App.css';
import { IDefectoscope } from './types/defectoscopeType';
import { Container } from 'react-bootstrap';
import defectoscopeService from './service/defectoscopeService';
import DefectoscopeRaw from './components/DefectoscopeRaw';


function App() {
  const [def, setDefs] = useState<IDefectoscope[]>([]);

  useEffect(() => {
    fetchDefectoscope()
  })
  async function fetchDefectoscope() {
    try {
      const response = await defectoscopeService.getAll()
      setDefs(response.data);
    } catch (e) {
      alert(e)
    }

  }


  return (
    <Container className="p-3">
      <DefectoscopeRaw def={def} />
    </Container>
  );
}

export default App;
