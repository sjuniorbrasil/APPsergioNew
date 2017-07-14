using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Aplicativo.ClassesEntidades
{
    [Table("NotaProduto")]
    public class MinhaNotaProduto
    {

        [Column("NOT_CODIGO")]
        public int NotaID { get; set; }

        [Column("NOP_CODIGO")]
        public int ID { get; set; }

        [Column("nop_tipo")]
        public int Tipo { get; set; }

        [Column("PRO_CODIGO")]
        public int ProdutoID { get; set; }

        [Column("NOP_DESCRICAO")]
        public string Descricao { get; set; }

        [Column("NOP_QTDE")]
        public decimal Quantidade { get; set; }

        [Column("NOP_VALOR")]
        public decimal ValorUn { get; set; }

        [Column("NOP_TOTAL")]
        public decimal TotalProduto { get; set; }

        [Column("NOP_ICMSBASE")]
        public decimal IcmsBase { get; set; }

        [Column("NOP_ICMSALIQ")]
        public decimal IcmsAliq { get; set; }

        [Column("NOP_ICMSVALOR")]
        public decimal IcmsValor { get; set; }

        [Column("NOP_PERCDESC")]
        public decimal PercentualDesconto { get; set; }

        [Column("NOP_CANCELADO")]
        public int ProdutoCancelado { get; set; }

        [Column("cfo_codigo")]
        public int Cfop { get; set; }

        [Column("NOP_IIBASE")]
        public decimal IIBASE { get; set; }

        [Column("IIVALOR")]
        public decimal IIVALOR { get; set; }

        [Column("NOP_IIIOF")]
        public decimal IIIOF { get; set; }

        [Column("NOP_IIDESPADUAN")]
        public decimal IIDESPADUAN { get; set; }

        [Column("NOP_ICMSCST")]
        public decimal ICMSCST { get; set; }

        [Column("NOP_SUBTOTAL")]
        public decimal SUBTOTAL { get; set; }

        [Column("NOP_ICMSSTBASE")]
        public decimal ICMSSTBASE { get; set; }

        [Column("NOP_ICMSSTALIQ")]
        public decimal ICMSSTALIQ { get; set; }

        [Column("NOP_ICMSSTMVA")]
        public decimal ICMSSTMVA { get; set; }

        [Column("NOP_ICMSSTVALOR")]
        public decimal ICMSSTVALOR { get; set; }

        [Column("NOP_PISCST")]
        public decimal PISCST { get; set; }

        [Column("NOP_PISBASE")]
        public decimal PISBASE { get; set; }

        [Column("NOP_PISALIQ")]
        public decimal PISALIQ { get; set; }

        [Column("NOP_PISVALOR")]
        public int PISVALOR { get; set; }


        [Column("NOP_COFINSCST")]
        public string COFINSCST { get; set; }

        [Column("NOP_COFINSBASE")]
        public decimal COFINSBASE { get; set; }

        [Column("NOP_COFINSALIQ")]
        public decimal COFINSALIQ { get; set; }

        [Column("NOP_COFINSVALOR")]
        public decimal COFINSVALOR { get; set; }

        [Column("NOP_CSOSN")]
        public string CSOSN { get; set; }

        [Column("NOP_IPIBASE")]
        public decimal IPIBASE { get; set; }

        [Column("NOP_IPIALIQ")]
        public decimal IPIALIQ { get; set; }

        [Column("NOP_IPIVALOR")]
        public decimal IPIVALOR { get; set; }

        [Column("fil_codigo")]
        public int FilialID { get; set; }


        [Column("NOP_DATA")]
        public DateTime Data { get; set; }

        [Column("NOP_IPICST")]
        public string IPICST { get; set; }

        [Column("NOP_TOTIMPOSTO")]
        public decimal TotalImposto { get; set; }

        [Column("NOP_DIFAL_VBCUFDEST")]
        public decimal DIFAL_VBCUFDEST { get; set; }

        [Column("NOP_DIFAL_PFCPUFDEST")]
        public decimal DIFAL_PFCPUFDEST { get; set; }

        [Column("NOP_DIFAL_PICMSUFDEST")]
        public decimal DIFAL_PICMSUFDEST { get; set; }

        [Column("NOP_DIFAL_PICMSINTER")]
        public decimal DIFAL_PICMSINTER { get; set; }

        [Column("NOP_DIFAL_PICMSINTERPART")]
        public decimal DIFAL_PICMSINTERPART { get; set; }

        [Column("NOP_DIFAL_VFCPUFDEST")]
        public decimal DIFAL_VFCPUFDEST { get; set; }

        [Column("NOP_DIFAL_VICMSUFDEST")]
        public decimal DIFAL_VICMSUFDEST { get; set; }

        [Column("NOP_DIFAL_VICMSUFREMET")]
        public decimal DIFAL_VICMSUFREMET { get; set; }
        
    }
}
