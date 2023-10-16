namespace ProjetoDrogas.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        /**********************/
        public Guid CategoriaId { get; set; }
        public Categoria? Categorias { get; set; }

        /**********************/



    }
}
