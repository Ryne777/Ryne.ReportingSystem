import { Navigate, Route, Routes } from "react-router-dom"
import DefectoscopeDetail from "../pages/DefectoscopeDetail"
import Defectoscopes from "../pages/Defectoscopes"
import Engineers from "../pages/Engineers"
import Organizations from "../pages/Organizations"
import Repairs from "../pages/Repairs"
import TypeOfDefectoscopes from "../pages/TypeOfDefectoscopes"


const AppRouter = () => {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/defectoscope" replace />} />
      <Route path="repairs" element={<Repairs />} />
      <Route path="engineers" element={<Engineers />} />
      <Route path="organizations" element={<Organizations />} />
      <Route path="type-of-defectoscopes" element={<TypeOfDefectoscopes />} />
      <Route path="defectoscope" element={<Defectoscopes />} />
      <Route path="defectoscope/:id" element={<DefectoscopeDetail />} />

      <Route
        path="*"
        element={
          <main style={{ padding: "1rem" }}>
            <p>There's nothing here!</p>
          </main>
        }
      />
    </Routes>
  )
}

export default AppRouter