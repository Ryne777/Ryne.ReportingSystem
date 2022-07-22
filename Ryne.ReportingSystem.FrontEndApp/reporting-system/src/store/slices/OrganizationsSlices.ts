
import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import { AxiosError } from "axios";
import organizationService from "../../service/organizationService";
import { IOrganization, IOrganizationCreate } from "../../types/organizationType";

interface IOrganizationsState {
  organizations: IOrganization[]
  error: string | null | undefined
}
interface IValidationErrors {
  errorMessage: string
  field_errors: Record<string, string>
}

const InitialState: IOrganizationsState = {
  organizations: [],
  error: ""
}
export const getAllOrganizations = createAsyncThunk<IOrganization[], undefined, { rejectValue: IValidationErrors }>(
  "organizations/getAll",
  async (_, { rejectWithValue, }) => {
    try {
      const response = await organizationService.getAll()
      return response.data

    } catch (err: any) {
      const error: AxiosError<IValidationErrors> = err // cast the error for access
      if (!error.response) {
        throw err
      }
      // Use `err.response.data` as `action.payload` for a `rejected` action,
      // by explicitly returning it using the `rejectWithValue()` utility
      return rejectWithValue(error.response.data)
    }
  })
export const createOrganization = createAsyncThunk<void, IOrganizationCreate, { rejectValue: IValidationErrors, state: IOrganizationsState }>(
  "organizations/create",
  async (payload, { rejectWithValue, dispatch }) => {
    try {
      await organizationService.create(payload)
      dispatch(getAllOrganizations())
    }
    catch (err: any) {
      const error: AxiosError<IValidationErrors> = err // cast the error for access
      if (!error.response) {
        throw err
      }
      // Use `err.response.data` as `action.payload` for a `rejected` action,
      // by explicitly returning it using the `rejectWithValue()` utility
      return rejectWithValue(error.response.data)
    }
  }
)

export const organizationsSlices = createSlice({
  name: "organizations",
  initialState: InitialState,
  reducers: {
    setState(state, action: PayloadAction<IOrganization[]>) {
      state.organizations = action.payload
    }
  },
  extraReducers: (builder) => {
    builder
      .addCase(getAllOrganizations.fulfilled, (state, action) => {
        state.organizations = action.payload
      })

  }

})
export default organizationsSlices.reducer