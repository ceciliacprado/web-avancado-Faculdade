//Esse arquivo é um componente e pode ser chamado onde precisar na aplicação
//O nome tem que sempre ter a primeira letra e maiusculo. 
//componente funcional - função 
//tem que retornar aenas 1 elemento pai (nesse caso a div)

import axios from "axios";
import { useEffect, useState } from "react";

function ListarProdutos() {
    const [produtos, setProdutos] = useState([]); 

    useEffect(() => { //gerar uma requisição e uma url 
        axios.get("http://localhost:5220/api/produto/listar")  //a requisição pode ser feita pela bibloteca axios e também pelo método fecht do javascript. - com caminho e o que faz (url e método http). 
        .then((response) => {  //"estou tentando fazer tal coisa(requisição), se funcionar mostre algo na tela (vai receber uma resposta"
          setProdutos(response.data);
        })
      }, []);
    

    return ( //transformando os produtos em tabela
        <div>
            <h1>Lista dos Produtos</h1>
           <table>
            <tr>
                <td>Nome</td>
                <td>Quantidade</td>
            </tr>
            {produtos.map((produto : any) => (
                <tr>
                    <td>{produto.nome}</td>
                    <td>{produto.quantidade}</td>
                </tr>
           ))} 
           </table>
        </div>
    );
}

export default ListarProdutos;  //é preciso exportar para poder utilizar em outros lugares da aplicaçãos