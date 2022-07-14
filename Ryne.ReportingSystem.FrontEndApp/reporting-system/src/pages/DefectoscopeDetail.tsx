import { FC, useEffect, useState } from 'react'
import { Row, Col } from 'react-bootstrap'
import { useParams } from 'react-router-dom'
import defectoscopeService from '../service/defectoscopeService'
import { IDefectoscopeDetail } from '../types/defectoscopeType'


const DefectoscopeDetail: FC = () => {
  const [def, setDef] = useState<IDefectoscopeDetail>()
  const { id } = useParams<{ id: string }>()
  useEffect(() => {
    GetDefectoscope(id!)
  })
  async function GetDefectoscope(id: string) {
    try {
      const data = await defectoscopeService.get(id)
      setDef(data.data)
    } catch (err) { alert(err) }
  }



  return (
    <>
      <Row className="pt-1">
        <Col>
          {def?.serialNumber}
        </Col>
      </Row>
    </>

  )
}

export default DefectoscopeDetail