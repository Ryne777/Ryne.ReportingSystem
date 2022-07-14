import { FC, useEffect, useState } from 'react'
import { Row, Col, Spinner, Button } from 'react-bootstrap';
import Tables from '../components/Tables';
import organizationService from '../service/organizationService';
import { IOrganization } from '../types/organizationType'



const Organizations: FC = () => {
  const [organizations, setOrganizations] = useState<IOrganization[]>([]);
  useEffect(() => {
    fetchOrganizations()

  }, [])
  async function fetchOrganizations() {
    try {
      const response = await organizationService.getAll()
      setTimeout(() => setOrganizations(response.data), 500)
    } catch (e) {
      alert(e)
    }
  }
  return (
    <><Row className="pt-1">
      <Col>
        {organizations.length > 0
          ? <Tables
            objects={organizations}
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

export default Organizations