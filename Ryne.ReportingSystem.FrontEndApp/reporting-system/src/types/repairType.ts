import { TypeOfRepair } from "./typeOfRepair"

export interface IRepair {
  id: string,
  dateOfCalibration: Date
}

export interface IRepairDetail extends IRepair {
  dateOfReceipt: Date,
  dateOfRelease: Date,
  dateOfLastRepair: Date,
  typeOfRepair: TypeOfRepair,
  defectoscopeId: string,
  engineerID: string,
  defectoscopeSerialNumber: string,
  typeOfRepairTostring: string,
  engineerName: string
}
export interface IRepairCreate {
  dateOfCalibration: Date,
  dateOfReceipt: Date,
  dateOfRelease: Date,
  dateOfLastRepair: Date,
  typeOfRepair: TypeOfRepair,
  defectoscopeId: Date,
  engineerID: Date
}
export interface IRepairAndDefectoscope extends IRepair {
  defectoscopeSerialNumber: string,
  typeOfDefectoscope: string,
  typeOfRepairTostring: string
}