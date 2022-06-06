import { IDefectoscope } from "./defectoscopeType"

export interface ITypeOfDefectoscope {
  id: string,
  name: string
}
export interface ITypeOfDefectoscopeDetail extends ITypeOfDefectoscope {
  defectoscopes: IDefectoscope[]
}
export interface ITypeOfDefectoscopeCreate {
  name: string
}