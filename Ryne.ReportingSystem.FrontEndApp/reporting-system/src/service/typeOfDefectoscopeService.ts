import http from "../http-common";
import { ITypeOfDefectoscope, ITypeOfDefectoscopeCreate, ITypeOfDefectoscopeDetail } from "../types/typeOfDefectoscope";


class TypeOfDefectoscopeService {

  async getAll() {
    return await http.get<Array<ITypeOfDefectoscope>>("/typeOfDefectoscope");
  }

  async get(id: string) {
    return await http.get<ITypeOfDefectoscopeDetail>(`/typeOfDefectoscope/${id}`);
  }

  async create(data: ITypeOfDefectoscopeCreate) {
    return await http.post<ITypeOfDefectoscopeCreate>("/typeOfDefectoscope", data);
  }

  async update(data: ITypeOfDefectoscopeCreate, id: any) {
    return await http.put<ITypeOfDefectoscopeCreate>(`/typeOfDefectoscope/${id}`, data);
  }

  async delete(id: any) {
    return await http.delete<any>(`/typeOfDefectoscopes/${id}`);
  }

  async deleteAll() {
    return await http.delete<any>(`/typeOfDefectoscopes`);
  }
}

export default new TypeOfDefectoscopeService()