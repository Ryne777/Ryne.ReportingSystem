import { useEffect, useState } from 'react'
import { Row, Col, Spinner, Form, Button } from 'react-bootstrap'
import { useParams } from 'react-router-dom'
import Tables from '../components/Tables'
import { useAppSelector } from '../hooks/redux'
import defectoscopeService from '../service/defectoscopeService'
import typeOfDefectoscopeService from '../service/typeOfDefectoscopeService'
import { IDefectoscopeDetail } from '../types/defectoscopeType'
import { ITypeOfDefectoscope } from '../types/typeOfDefectoscope'


const DefectoscopeDetail = () => {
  const [def, setDef] = useState<IDefectoscopeDetail>()
  const [isEdit, setIsEdit] = useState(true)
  const [typeOfDefectoscopes, setTypeOfDefectoscopes] = useState<ITypeOfDefectoscope[]>()
  const { organizations } = useAppSelector(state => state.organizationReducer)
  const { id } = useParams<{ id: string }>()
  useEffect(() => {
    GetDefectoscope(id!)
    fetchOfDefectoscopes()
  }, [id])
  async function GetDefectoscope(id: string) {
    try {
      const response = await defectoscopeService.get(id)
      setDef(response.data)
    } catch (err) { alert(err) }
  }
  async function fetchOfDefectoscopes() {
    try {
      const response = await typeOfDefectoscopeService.getAll()
      setTypeOfDefectoscopes(response.data)
    } catch (e) {
      alert(e)
    }
  }
  return (
    <>
      <Row className="pt-1 align-content-center text-center">
        <Col>
          <Form.Label>Серийный номер :</Form.Label>
          <Form.Control value={def?.serialNumber} type="text" placeholder="Серийный номер" readOnly={isEdit} />
        </Col>
        <Col>
          <Form.Label>Тип дефектоскопа:</Form.Label>
          <Form.Select aria-label="Тип дефектоскопа" disabled={isEdit}>
            <option>{def?.typeOfDefectoscopeName}</option>
            {typeOfDefectoscopes
              ?.filter(type => type.id !== def?.typeOfDefectoscopeId)
              .map(type => (
                <option key={type.id} value={type.id}>
                  {type.name}
                </option>
              ))}
          </Form.Select>
        </Col>
        <Col>
          <Form.Label>Организация:</Form.Label>
          <Form.Select aria-label="Организация" disabled={isEdit}>
            <option>{def?.organizationName}</option>
            {organizations
              ?.filter(org => org.id !== def?.organizationId)
              .map(org => (
                <option key={org.id} value={org.id}>
                  {org.name}
                </option>
              ))}
          </Form.Select>
        </Col>
        <Col>
          <Form.Label>Год выпуска:</Form.Label>
          <Form.Control value={def?.productionYear} type="text" placeholder="Год выпуска" readOnly={isEdit} />
        </Col>
        <Col className="col-3">
          {def?.repairs
            ? <Tables
              objects={def.repairs}
              properties={[
                {
                  key: "dateOfCalibration",
                  title: "Дата калибровки"
                }
              ]}
              path="/repairs"
            />
            : <Spinner animation="border" role="status">
              <span className="visually-hidden">Loading...</span>
            </Spinner>}
        </Col>
      </Row>
      <Row>
        <Col className="d-flex justify-content-end">
          <Button
            variant="success"
            className="me-1"
            onClick={() => setIsEdit(!isEdit)}
          >
            <i className="bi bi-pencil-square"></i>
          </Button>{' '}
          <Button variant="danger"><i className="bi bi-trash-fill"></i></Button>{' '}
        </Col>
      </Row>
    </>

  )
}

export default DefectoscopeDetail