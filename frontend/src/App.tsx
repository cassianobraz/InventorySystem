import { Route, Routes } from "react-router-dom"
import { Stock } from "./pages/stock"
import { Dashboard } from "./pages/dashboard"


function App() {

  return (
    <Routes>
      <Route path="/estoque" element={<Stock />} />
      <Route path="/dash" element={<Dashboard />} />
    </Routes>
  )
}

export default App
