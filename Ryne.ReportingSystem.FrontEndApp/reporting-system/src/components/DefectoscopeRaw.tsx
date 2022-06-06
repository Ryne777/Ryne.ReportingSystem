import { FC } from 'react'
import { IDefectoscope } from '../types/defectoscopeType'
import Table from 'react-bootstrap/Table'

interface IDefectoscopeProps {
  def: IDefectoscope[]
}

const DefectoscopeRaw: FC<IDefectoscopeProps> = ({ def }) => {
  return (
    <Table striped bordered hover size="sm">
      <thead>
        <tr>
          <th>#</th>
          <th>Заводской номер</th>
          <th>Тип Дефектоскопа</th>
          <th>Год выпуска</th>
          <th>Предприятие</th>
        </tr>
        {def && def.map((d: IDefectoscope, index: number) => (

          <tr key={d.id}>
            <td>
              {index + 1}
            </td>
            <td>
              {d.serialNumber}
            </td>
            <td>
              {d.typeOfDefectoscopeName}
            </td>
            <td>
              {d.productionYear}
            </td>
            <td>
              {d.organizationName}
            </td>
          </tr>
        ))}
      </thead>
    </Table >
  )
}

export default DefectoscopeRaw