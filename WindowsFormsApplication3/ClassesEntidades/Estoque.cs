using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Aplicativo.ClassesEntidades
{
    [Table("Estoque")]
    public class Estoque
    {
        [Column("Est_codigo")]
        public int EstoqueID { get; set; }

        [Column("fil_codigo")]
        public int FilialID { get; set; }

        [Column("est_data")]
        public DateTime DataMovimentacao { get; set; }

        [Column("com_codigo")]
        public int EntradaID { get; set; }

        [Column("pro_codigo")]
        public int ProdutoID { get; set; }

        [Column("inv_codigo")]
        public int InventarioID { get; set; }

        [Column("est_motivo")]
        public string Descricao { get; set; }

        [Column("est_codsaida")]
        public int SaidaProdutoID { get; set; }

        [Column("Tra_codigo")]
        public int TranfereciaID { get; set; }

        [Column("est_qtde")]
        public decimal Quantidade { get; set; }

        [Column("est_codconversao")]
        public int ConversaoProdutoID { get; set; }

        [Column("cpp_codigo")]
        public int EntradaProdutoID { get; set; }

        [Column("vep_codigo")]
        public int VendaProdutoID { get; set; }

        [Column("not_codigo")]
        public int NotaID { get; set; }

        [Column("nop_codigo")]
        public int NotaProdutoID { get; set; }

        public Estoque()
        {
                
        }
        
    }
}
