import http from "../http-common";
import { IDefectoscope, IDefectoscopeCreate, IDefectoscopeDetail } from "../types/defectoscopeType";


class DefectoscopeService {

  async getAll() {
    return await http.get<Array<IDefectoscope>>("/defectoscopes");
  }

  async get(id: string) {
    return await http.get<IDefectoscopeDetail>(`/defectoscopes/${id}`);
  }

  async create(data: IDefectoscopeCreate) {
    return await http.post<IDefectoscopeCreate>("/defectoscopes", data);
  }

  async update(data: IDefectoscopeCreate, id: any) {
    return await http.put<IDefectoscopeCreate>(`/defectoscopes/${id}`, data);
  }

  async delete(id: any) {
    return await http.delete<any>(`/defectoscopes/${id}`);
  }

  async deleteAll() {
    return await http.delete<any>(`/defectoscopes`);
  }
}

export default new DefectoscopeService()