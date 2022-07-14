import { FC, useEffect, useState } from 'react'
import { Row, Col, Spinner, Button } from 'react-bootstrap';
import Tables from '../components/Tables';
import typeOfDefectoscopeService from '../service/typeOfDefectoscopeService';
import { ITypeOfDefectoscope } from '../types/typeOfDefectoscope';

const TypeOfDefectoscopes: FC = () => {
  const [typeOfDefectoscopes, setTypeOfDefectoscopes] = useState<ITypeOfDefectoscope[]>([]);
  useEffect(() => {
    fetchOrganizations()

  }, [])
  async function fetchOrganizations() {
    try {
      const response = await typeOfDefectoscopeService.getAll()
      setTimeout(() => setTypeOfDefectoscopes(response.data), 500)
    } catch (e) {
      alert(e)
    }
  }
  return (
    <><Row className="pt-1">
      <Col>
        {typeOfDefectoscopes.length > 0
          ? <Tables
            objects={typeOfDefectoscopes}
            properties={[
              {
                key: "name",
                title: 'Название'
              },
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

export default TypeOfDefectoscopes