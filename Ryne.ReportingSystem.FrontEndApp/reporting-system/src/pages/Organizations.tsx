import { Row, Col, Spinner, Button } from 'react-bootstrap';
import CreateSimleModal from '../components/CreateSimleModal';
import Tables from '../components/Tables';
import { useAppSelector } from '../hooks/redux';
import { createOrganization } from '../store/slices/OrganizationsSlices';



const Organizations = () => {
  const { organizations } = useAppSelector(state => state.organizationReducer)

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
          <CreateSimleModal
            reducer={createOrganization}
            title={"Создать новую  организацию владельца дефектоскопов"}
          />
          <Button variant="danger">Delete</Button>{' '}
        </Col>
      </Row>
    </>

  )
}

export default Organizations