import { FormEvent, useState } from 'react'
import axios from 'axios';
import './App.css'
import logo from '../src/assets/logo.svg';

function App() {

  const [user, setUser] = useState('');
  const [password, setPassword] = useState('');

  async function handleAuth(e : FormEvent) {
    e.preventDefault();

    const api = axios.create({
      baseURL: "https://localhost:44315",
      withCredentials: true
    });

    await api
              .post(`/api/rest/login?userName=${user}&password=${password}`)
              .then((resp) => {
                console.log(resp);
              });

    window.location.href = 'https://localhost:44315/Authenticated';
  }

  return (
    <div className="App">
      <img src={logo} alt="" />
      <form autoComplete="nope" onSubmit={handleAuth}>
        <input type="text" id="user" placeholder="User" autoComplete="username" onChange={e => setUser(e.target.value)} />
        <input type="password" id="password" placeholder="Password" autoComplete="current-password" onChange={e => setPassword(e.target.value)} />

        <button type="submit">
          Logar
        </button>
      </form>

      {/* <a href="https://localhost:44315/Authenticated">TO MVC</a> */}
    </div>
  )
}

export default App
