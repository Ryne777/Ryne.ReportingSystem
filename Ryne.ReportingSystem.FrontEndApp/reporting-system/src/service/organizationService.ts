import http from "../http-common";
import { IOrganization, IOrganizationCreate, IOrganizationDetail } from "../types/organizationType";


class OrganizationService {

  async getAll() {
    return await http.get<Array<IOrganization>>("/organizations");
  }

  async get(id: string) {
    return await http.get<IOrganizationDetail>(`/organizations/${id}`);
  }

  async create(data: IOrganizationCreate) {
    return await http.post<IOrganizationCreate>("/organizations", data);
  }

  async update(data: IOrganizationCreate, id: any) {
    return await http.put<IOrganizationCreate>(`/organizations/${id}`, data);
  }

  async delete(id: any) {
    return await http.delete<any>(`/organizations/${id}`);
  }

  async deleteAll() {
    return await http.delete<any>(`/organizations`);
  }
}

export default new OrganizationService()