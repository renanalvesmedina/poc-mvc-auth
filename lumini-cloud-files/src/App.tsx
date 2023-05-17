import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Login } from "./Pages/Login";
import { UploadAnonymous } from "./Pages/UploadAnonymous/index";
import './global.css'

export function App() {
return (
    <BrowserRouter>
      <Routes>
        <Route path='/login' element={<Login />} />
        <Route path='/upload-anon' element={<UploadAnonymous />} />
      </Routes>
    </BrowserRouter>
  )
}
