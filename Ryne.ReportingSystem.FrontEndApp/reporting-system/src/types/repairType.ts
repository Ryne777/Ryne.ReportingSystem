import { TypeOfRepair } from "./typeOfRepair"

export interface IRepair {
  id: string,
  dateOfCalibration: string
}

export interface IRepairDetail extends IRepair {
  dateOfReceipt: string,
  dateOfRelease: string,
  dateOfLastRepair: string,
  typeOfRepair: TypeOfRepair,
  defectoscopeId: string,
  engineerID: string,
  defectoscopeSerialNumber: string,
  typeOfRepairTostring: string,
  engineerName: string
}
export interface IRepairCreate {
  dateOfCalibration: string,
  dateOfReceipt: string,
  dateOfRelease: string,
  dateOfLastRepair: string,
  typeOfRepair: TypeOfRepair,
  defectoscopeId: string,
  engineerID: string
}
export interface IRepairAndDefectoscope extends IRepair {
  defectoscopeSerialNumber: string,
  typeOfDefectoscope: string,
  typeOfRepairTostring: string
}