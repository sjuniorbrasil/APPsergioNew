using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicativo.ClassesEntidades
{
    [Table("Nota")]
    public class MinhaNota
    {
        [Column("not_codigo")]
        public int ID { get; set; }

        [Column("not_dtemissao")]
        public DateTime DataEmissao { get; set; }

        [Column("not_numero")]
        public int NumeroNota { get; set; }

        [Column("not_modelo")]
        public string ModeloNF { get; set; }

        [Column("not_serie")]
        public string SerieNF { get; set; }

        [Column("not_finalidade")]
        public int Finalidade { get; set; }

        [Column("cadastro")]
        public int CadastroID { get; set; }

        [Column("cfo_codigo")]
        public int Cfop { get; set; }

        [Column("not_referenciada")]
        public string NotaReferencia { get; set; }

        [Column("not_subtotal")]
        public decimal SubTotal { get; set; }

        [Column("not_desconto")]
        public decimal Desconto { get; set; }

        [Column("not_nfetotal")]
        public decimal TotalNF { get; set; }

        [Column("not_obs")]
        public string ObservacaoNF { get; set; }

        [Column("cod_forncedor")]
        public int FornecedorID { get; set; }

        [Column("not_vencimento")]
        public DateTime? Vencimento { get; set; }

        [Column("not_chave")]
        public string ChaveNF { get; set; }

        [Column("not_protocolo")]
        public string ProtocoloNF { get; set; }

        [Column("not_recibo")]
        public string ReciboNF { get; set; }

        [Column("not_statusnota")]
        public string StatusNota { get; set; }

        [Column("not_dthoraprotocolo")]
        public DateTime DtHoraProtocolo { get; set; }

        [Column("not_cancelada")]
        public int Cancelada { get; set; }

        [Column("not_inutilizada")]
        public int Inutilizada { get; set; }

        [Column("not_motivocancel")]
        public string MotivoCancelamento { get; set; }

        [Column("not_peso")]
        public decimal PesoNF { get; set; }

        [Column("not_volume")]
        public int VolumesNF { get; set; }

        [Column("not_marca")]
        public string Marca { get; set; }

        [Column("not_icmsbase")]
        public decimal IcmsBase { get; set; }

        [Column("not_icmsvalor")]
        public decimal IcmsValor { get; set; }

        [Column("not_icmspercentual")]
        public decimal PercentualIcms { get; set; }

        [Column("not_icmsstvalor")]
        public decimal IcmsStValor { get; set; }

        [Column("not_xml")]
        public string XML { get; set; }
       
        [Column("not_ipi")]       
        public decimal IpiValor { get; set; }
    } 
}
