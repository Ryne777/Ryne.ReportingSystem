import http from "../http-common";
import { ITypeOfDefectoscope, ITypeOfDefectoscopeCreate, ITypeOfDefectoscopeDetail } from "../types/typeOfDefectoscope";


class TypeOfDefectoscopeService {

  async getAll() {
    return await http.get<Array<ITypeOfDefectoscope>>("/typeOfDefectoscopes");
  }

  async get(id: string) {
    return await http.get<ITypeOfDefectoscopeDetail>(`/typeOfDefectoscopes/${id}`);
  }

  async create(data: ITypeOfDefectoscopeCreate) {
    return await http.post<ITypeOfDefectoscopeCreate>("/typeOfDefectoscopes", data);
  }

  async update(data: ITypeOfDefectoscopeCreate, id: any) {
    return await http.put<ITypeOfDefectoscopeCreate>(`/typeOfDefectoscopes/${id}`, data);
  }

  async delete(id: any) {
    return await http.delete<any>(`/typeOfDefectoscopes/${id}`);
  }

  async deleteAll() {
    return await http.delete<any>(`/typeOfDefectoscopes`);
  }
}

export default new TypeOfDefectoscopeService()