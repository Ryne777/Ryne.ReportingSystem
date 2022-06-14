
import { FC, useEffect, useState } from 'react';
import './App.css';
import { IDefectoscope } from './types/defectoscopeType';
import { Container, Form } from 'react-bootstrap';
import defectoscopeService from './service/defectoscopeService';
import DefectoscopeRaw from './components/DefectoscopeRaw';


const App: FC = () => {
  const [def, setDefs] = useState<IDefectoscope[]>([]);

  useEffect(() => {
    fetchDefectoscope()

  }, [])
  async function fetchDefectoscope() {
    try {
      const response = await defectoscopeService.getAll()
      setDefs(response.data);
      console.log(new Date("2022-06-06T05:55:01.052Z"))
    } catch (e) {
      alert(e)
    }
  }


  return (
    <Container className="p-3">
      <DefectoscopeRaw def={def} />
      <Form.Label htmlFor="exampleColorInput">Color picker</Form.Label>
      {/* <Form.Control
        type="date"
        id="exampleColorInput"
        title="Choose your color"

        onChange={e => setDate(new Date(e.target.value))}
      /> */}
      {/* <p>{date && date.toJSON()}</p> */}

    </Container>
  );
}

export default App;
