import { FC } from 'react'
import { Table } from 'react-bootstrap'
import { IEngineer } from '../types/engineerType'
import { IRepairAndDefectoscope } from '../types/repairType'

interface IEngineerProps {
  engineers: IEngineer[]
}

const EngineerList: FC<IEngineerProps> = ({ engineers }) => {
  return (
    <>
      <Table striped bordered hover size="sm" className="text-center align-middle" >
        <thead>
          <tr>
            <th>#</th>
            <th>Имя</th>
            <th>Ремонты</th>
          </tr>
        </thead>
        <tbody>
          {engineers && engineers.map((e: IEngineer, i: number) => (
            <tr key={e.id} >
              <td>
                {i + 1}
              </td>
              <td>
                {e.name}
              </td>
              <td className="p-0">
                <Table className="mb-0" size="sm" striped bordered hover>
                  <tbody>
                    {e.repairs.map((r: IRepairAndDefectoscope, i: number) => (
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
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  )
}

export default EngineerList