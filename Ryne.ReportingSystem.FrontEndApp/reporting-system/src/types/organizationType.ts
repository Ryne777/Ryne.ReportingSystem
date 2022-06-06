import { IDefectoscope } from "./defectoscopeType"

export interface IOrganization {
  id: string,
  name: string
}
export interface IOrganizationDetail extends IOrganization {
  defectoscopes: IDefectoscope[]
}

export interface IOrganizationCreate {
  name: string
}