using System;

namespace MeuProjetoMinimalAPI.Models
{
    public class Produto 
    {
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now; //pode ser usado assim direto ou incializado no construtor

    }
}