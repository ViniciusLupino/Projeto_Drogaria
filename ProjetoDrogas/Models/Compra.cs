namespace ProjetoDrogas.Models
{
    public class Compra
    {
        public Guid CompraId { get; set; }
        public string Nota { get; set; }
        public DateTime Horario { get; set; }

        /**********************/

        public Guid FornecedorId { get; set; }
        public Fornecedor? Fornecedores { get; set; }

        /**********************/
    }
}
