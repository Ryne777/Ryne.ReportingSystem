import { IRepair } from "./repairType"

export interface IDefectoscope {
  id: string,
  serialNumber: string,
  productionYear: number,
  typeOfDefectoscopeName: string,
  organizationName: string
}

export interface IDefectoscopeDetail extends IDefectoscope {
  typeOfDefectoscopeId: string,
  organizationId: string,
  repairs: IRepair
}
export interface IDefectoscopeCreate {
  serialNumber: string,
  productionYear: number,
  typeOfDefectoscopeId: string,
  organizationId: string,
}