using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApplication3.ClassesEntidades
{
    [Table("ItemPedido")]
    public class PedidoProduto
    {
        [Column("Ped_codigo")]
        public int PedidoID { get; set; }

        [Column("cod_produto")]
        public int ProdutoID { get; set; }

        [Column("itp_valor")]
        public decimal ValorUnitario { get; set; }

        [Column("itp_qtde")]
        public decimal Quantidade { get; set; }

        [Column("itp_total")]
        public decimal ValorTotal { get; set; }

        [Column("itp_vloriginal")]
        public decimal ValorOriginal { get; set; }

        public PedidoProduto()
        {

        }
    }
}
