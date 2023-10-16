using System.ComponentModel.DataAnnotations;

namespace ProjetoDrogas.Models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

    }
}
