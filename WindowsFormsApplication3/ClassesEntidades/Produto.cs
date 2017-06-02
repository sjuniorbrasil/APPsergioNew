using System.ComponentModel.DataAnnotations.Schema;
namespace Aplicativo.ClassesEntidades
{
    [Table("Produtos")]
    public class Produto
    {
        utils u = new utils();
        public decimal calculaVlVenda( decimal Custo, decimal Margem)
        {
            return  ((Custo) * (Margem / 100) + (Custo)); 
        }
        public Produto()
        {

        }
        [Column("cod_produto")]
        public int ID { get; set; }

        [Column("des-produto")]
        public string Descricao { get; set; }

        [Column("EAN")]
        public string EAN { get; set; }

        [Column("Cod_fornecedor")]
        public int FornecedorID { get; set; }

        [Column("vl_produto")]
        public decimal ValorVenda { get; set; }

        [Column("est_produto")]
        public decimal Estoque { get; set; }

        [Column("des_reduzida")]
        public string DescricaoReduzida { get; set; }

        [Column("Margem")]
        public decimal Margem { get; set; }

        [Column("Custo")]
        public decimal  Custo { get; set; }

        [Column("cfo_codigo")]
        public int CFOP { get; set; }

        [Column("Cest")]
        public string CEST { get; set; }

        [Column("NCM")]
        public string NCM { get; set; }

        [Column("CstIcms")]
        public string CstICMS { get; set; }

        [Column("CstIpi")]
        public string CstIPI { get; set; }

        [Column("CstPis")]
        public string CstPIS { get; set; }

        [Column("CstCofins")]
        public string CstCOFINS { get; set; }

        [Column("AliqInter")]
        public string AliqInter { get; set; }

        [Column("AliqIcms")]
        public string AliqIcms { get; set; }

        [Column("AliqIpi")]
        public string AliqIpi { get; set; }

        [Column("AliqPis")]
        public string AliqPis { get; set; }

        [Column("AliqCofins")]
        public string AliqCofins { get; set; }

        [Column("Origem")]
        public int OrigemDoProduto { get; set; }

        [Column("Situacao")]
        public int Situacao { get; set; }

        [Column("UNMedida")]
        public string UnidadeMedida { get; set; }
    }
}
