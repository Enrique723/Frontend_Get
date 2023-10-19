import react, {Suspense} from "react";
import { fetchData } from "./src/fetchData";
import  "./src/App.css";

const apiData = fetchData("https://localhost:44335/api/Usuarios");

 function App(){
   const data = apiData.read();
  console.log(data)
   return (
    <div className="App">
     <h1>
      Datos del Usuario
     </h1>
     <Suspense fallback={<div> Cargando...</div>}>
     <ul className="Tarjeta">
        {data?.map((item)=> (
          <li key={
            item.idUsuario
            }>
            {
            item.nombre
            } 
            {
            item.correoElectronico
            } 
            {
            item.contraseña
            } 
          </li>
        ))}
     </ul>

     </Suspense>
    </div>
  );
}

export default App;
