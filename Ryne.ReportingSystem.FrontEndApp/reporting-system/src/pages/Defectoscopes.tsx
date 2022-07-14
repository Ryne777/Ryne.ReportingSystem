import { FC, useEffect, useState } from 'react'
import { Row, Col, Spinner, Button } from 'react-bootstrap'
import Tables from '../components/Tables';
import defectoscopeService from '../service/defectoscopeService';
import { IDefectoscope } from '../types/defectoscopeType';



const Defectoscopes: FC = () => {
  const [def, setDefs] = useState<IDefectoscope[]>([]);

  useEffect(() => {
    fetchDefectoscope()

  }, [])
  async function fetchDefectoscope() {
    try {
      const response = await defectoscopeService.getAll()
      setTimeout(() => setDefs(response.data), 500)
    } catch (e) {
      alert(e)
    }
  }
  return (
    <><Row className="pt-1">
      <Col>
        {def.length > 0
          ? <Tables
            objects={def}
            properties={[
              {
                key: "serialNumber",
                title: "Заводской номер"
              },
              {
                key: "typeOfDefectoscopeName",
                title: "Тип Дефектоскопа"
              },
              {
                key: "productionYear",
                title: "Год выпуска"
              },
              {
                key: "organizationName",
                title: "Предприятие"
              }
            ]}
          />
          : <Spinner animation="border" role="status">
            <span className="visually-hidden">Loading...</span>
          </Spinner>}
      </Col>
    </Row><Row>
        <Col className="d-flex justify-content-end">
          <Button variant="success" className="me-1">Add</Button>{' '}
          <Button variant="danger">Delete</Button>{' '}
        </Col>
      </Row>
    </>
  )
}
export default Defectoscopes