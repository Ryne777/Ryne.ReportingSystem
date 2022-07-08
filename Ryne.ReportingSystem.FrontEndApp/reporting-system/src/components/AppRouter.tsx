import { Route, Routes } from "react-router-dom"
import Defectoscopes from "../pages/Defectoscopes"





const AppRouter = () => {
  return (
    <Routes>
      <Route path="/" element={<Defectoscopes />} />


    </Routes>
  )
}

export default AppRouter