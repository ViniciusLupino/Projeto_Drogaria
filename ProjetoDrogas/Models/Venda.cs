using Humanizer;

namespace ProjetoDrogas.Models
{
    public class Venda
    {
        public Guid VendaId { get; set; }
        public string Nota { get; set; }
        public DateTime Horario { get; set; }

        /**********************/

        public Guid ClienteId { get; set; }
        public Cliente? Clientes { get; set; }

        /**********************/
    }
    
}
