import { combineReducers, configureStore } from "@reduxjs/toolkit"
import organizationReducer from "./slices/OrganizationsSlices"

const rootReducer = combineReducers({
  organizationReducer
})


export function setupStore() {
  return configureStore({
    reducer: rootReducer
  })
}

export type RootState = ReturnType<typeof rootReducer>
export type AppStore = ReturnType<typeof setupStore>
export type AppDispatch = AppStore['dispatch']
