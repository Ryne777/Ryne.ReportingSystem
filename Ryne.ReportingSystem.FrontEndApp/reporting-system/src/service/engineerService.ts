import http from "../http-common";
import { IEngineer, IEngineerCreate } from "../types/engineerType";


class EngineerService {

  async getAll() {
    return await http.get<Array<IEngineer>>("/engineers");
  }

  async get(id: string) {
    return await http.get<IEngineer>(`/engineers/${id}`);
  }

  async create(data: IEngineerCreate) {
    return await http.post<IEngineerCreate>("/engineers", data);
  }

  async update(data: IEngineerCreate, id: any) {
    return await http.put<IEngineerCreate>(`/engineers/${id}`, data);
  }

  async delete(id: any) {
    return await http.delete<any>(`/engineers/${id}`);
  }

  async deleteAll() {
    return await http.delete<any>(`/engineers`);
  }
}

export default new EngineerService()