import { IRepairAndDefectoscope } from "./repairType";

export interface IEngineer {
  id: string,
  name: string,
  repairs: IRepairAndDefectoscope[]
}
export interface IEngineerCreate {
  name: string
}