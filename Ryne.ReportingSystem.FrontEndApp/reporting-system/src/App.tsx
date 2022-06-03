import axios from 'axios';
import { useEffect, useState } from 'react';
import './App.css';
import Component1 from './Component/Component1';

function App() {
  const [num, setNum] = useState(0)
  const [text, setText] = useState("")


  function increment():void {
    setNum(num+1)
  }
  useEffect(() => {
        fetchUsers()
    }, [])

    async function fetchUsers() {
        try {
            const response = await axios.get('http://localhost:5000/api/defectoscops/')
            console.log(response.data)
        } catch (e) {
            alert(e)
        }
    }

  return (
    <div className="App">
      <h1>{num}</h1>
      <button onClick={increment}>Increment</button>
      <h1>{text}</h1>
      <input type="text"
        value = {text}
        onChange={event => setText(event.target.value)}>
      </input>
      <Component1 name={text} ></Component1>
    </div>
  );
}

export default App;
