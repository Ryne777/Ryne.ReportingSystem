import http from "../http-common";
import { IRepairCreate, IRepairDetail } from "../types/repairType";


class RepairService {

  async getAll() {
    return await http.get<Array<IRepairDetail>>("/repairs");
  }

  async get(id: string) {
    return await http.get<IRepairDetail>(`/repairs/${id}`);
  }

  async create(data: IRepairCreate) {
    return await http.post<IRepairCreate>("/repairs", data);
  }

  async update(data: IRepairCreate, id: any) {
    return await http.put<IRepairCreate>(`/repairs/${id}`, data);
  }

  async delete(id: any) {
    return await http.delete<any>(`/repairs/${id}`);
  }

  async deleteAll() {
    return await http.delete<any>(`/repairs`);
  }
}

export default new RepairService()