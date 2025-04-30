import { Route, Routes } from "react-router-dom"
import { Stock } from "./pages/stock"
import { Dashboard } from "./pages/dashboard"
import { Home } from "./pages/home"


function App() {

  return (
    <Routes>
      <Route path="/estoque" element={<Stock />} />
      <Route path="/" element={<Home />} />
      <Route path="/dash" element={<Dashboard />} />
    </Routes>
  )
}

export default App
