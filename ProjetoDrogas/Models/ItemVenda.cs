namespace ProjetoDrogas.Models
{
    public class ItemVenda
    {
        public Guid ItemVendaId { get; set; }

        /**********************/
        public Guid VendaId { get; set; }
        public Venda? Vendas { get; set; }

        /**********************/
        public Guid ProdutoId { get; set; }
        public Produto? Produtos { get; set; }

        /**********************/

        public int Quantidade { get; set; }
        public string Preco { get; set; }

        /**********************/

        public decimal PrecoTotal
        {
            get
            { 
                //return Quantidade * int.Parse(Preco);
                return Quantidade * decimal.Parse(Preco);
            }
            set { 
            }
        }




    }
}
