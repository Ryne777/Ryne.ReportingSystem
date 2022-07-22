import { Button, Col, Form, Row, Table } from "react-bootstrap"
import { IRepairAndDefectoscope } from "../types/repairType"
import { IEngineer } from "../types/engineerType"
import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import engineerService from "../service/engineerService"
const EngineerDetail = () => {
  const [engineer, setEngineer] = useState<IEngineer>()
  const [isEdit, setIsEdit] = useState(true)
  const { id } = useParams<{ id: string }>()

  useEffect(() => {
    GetEngineer(id!)
  }, [id])
  async function GetEngineer(id: string) {
    try {
      const response = await engineerService.get(id)
      setEngineer(response.data)
    } catch (err) { alert(err) }
  }



  return (
    <>
      <Row className="pt-1 align-content-center text-center">
        <Col>
          <Form.Label>Серийный номер :</Form.Label>
          <Form.Control value={engineer?.name} type="text" placeholder="Серийный номер" readOnly={isEdit} />
        </Col>
        <Col>

          <Table className="mb-0" size="sm" striped bordered hover>
            <tbody>
              {engineer?.repairs.map((r: IRepairAndDefectoscope, i: number) => (
                <tr key={r.id}>
                  <td>
                    {r.defectoscopeSerialNumber}
                  </td>
                  <td>
                    {r.typeOfDefectoscope}
                  </td>
                  <td>
                    {r.typeOfRepairTostring}
                  </td>
                  <td>
                    {new Date(r.dateOfCalibration).toLocaleDateString("ru-RU")}
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
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

export default EngineerDetail