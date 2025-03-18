import axios from "axios";
import React, { use, useEffect } from "react";
import ListarProdutos from "./components/ListarProdutos";
//1 - Um componente SEMPRE deve começar com a primeira letra
//maiúscula
//2 - Todo componente DEVE ser uma função do JS
//3 - Todo deve retornar apenas UM elemento HTML
function App() {

  
  useEffect(() => { //gerar uma requisição e uma url 
    axios.get("http://localhost:5220/api/produto/listar")  //a requisição pode ser feita pela bibloteca axios e também pelo método fecht do javascript. - com caminho e o que faz (url e método http). 
    .then((response) => {  //"estou tentando fazer tal coisa(requisição), se funcionar mostre algo na tela (vai receber uma resposta"
      console.log(response.data);
    })
  }, []);

  return (
    <div className="App">
      <ListarProdutos></ListarProdutos>
    </div>
  );
}
//4 - OBRIGATORIAMENTE o componente DEVE ser exportado
export default App;
