using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaClienteTeste.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o CPF do cliente")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Digite o nome do cliente")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a data de nascimento")]
        public DateTime DataNascimento { get; set; }        
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Digite o Cep")]
        public string Cep { get; set; }       
        public string Logradouro { get; set; }       
        public string Cidade { get; set; }       
        public string UF { get; set; }        
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
