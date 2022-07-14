import { FC, useEffect, useState } from 'react'
import { Row, Col, Spinner, Button } from 'react-bootstrap';
import EngineerList from '../components/EngineerList';
import engineerService from '../service/engineerService';
import { IEngineer } from '../types/engineerType';

const Engineers: FC = () => {
  const [engineer, setEngineer] = useState<IEngineer[]>([])

  useEffect(() => {
    fetchEngineers()

  }, [])
  async function fetchEngineers() {
    try {
      const response = await engineerService.getAll()
      setTimeout(() => setEngineer(response.data), 500)
    } catch (e) {
      alert(e)
    }
  }
  return (
    <><Row className="pt-1">
      <Col>
        {engineer.length > 0
          ? <EngineerList engineers={engineer}></EngineerList>
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
export default Engineers