import { FC, useEffect, useState } from 'react'
import { Row, Col, Spinner, Button } from 'react-bootstrap';
import Tables from '../components/Tables';
import repairService from '../service/repairService';
import { IRepairDetail } from '../types/repairType';

const Repairs: FC = () => {
  const [repairs, setRepairs] = useState<IRepairDetail[]>([]);

  useEffect(() => {
    fetchRepairs()

  }, [])
  async function fetchRepairs() {
    try {
      const response = await repairService.getAll()
      setTimeout(() => setRepairs(response.data), 500)
    } catch (e) {
      alert(e)
    }
  }
  return (
    <><Row className="pt-1">
      <Col>
        {repairs.length > 0
          ? <Tables
            objects={repairs}
            properties={[
              {
                key: "defectoscopeSerialNumber",
                title: "Заводской номер"
              },
              {
                key: "typeOfRepairTostring",
                title: "Тип Ремонта"
              },
              {
                key: "dateOfReceipt",
                title: "Дата поступления на ремонт"
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

export default Repairs


