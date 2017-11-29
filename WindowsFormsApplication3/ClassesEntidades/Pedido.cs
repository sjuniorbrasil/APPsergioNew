using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aplicativo.ClassesEntidades
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ped_codigo")]
        public int ID { get; set; }

        [Column("ped_dtemissao")]
        public string DataEmissao { get; set; }

        [Column("ped_totalbruto")]
        public decimal TotalBruto { get; set; }

        [Column("ped_percdesc")]
        public decimal PercentualDesconto { get; set; }

        [Column("Ped_desconto")]
        public decimal ValorDesconto { get; set; }

        [Column("ped_totalLiq")]
        public decimal TotalLiquido { get; set; }

        [Column("ped_obs")]
        public string Observacao { get; set; }

        [Column("cod_funcionario")]
        public int FuncionarioID { get; set; }

        [Column("cod_cliente")]
        public int ClienteID { get; set; }
        

        public Pedido()
        {
                
        }
    }
}
