using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicativo.ClassesEntidades
{
    [Table("NFE")]
    public class NotaFreeNFE
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int ID { get; set; }

        [Column("ID_FILIAL")]
        public int FilialID { get; set; }

        [Column("ID_CFOP")]
        public int Cfop { get; set; }

        [Column("IDE_NATOP")]
        public string NaturezaOperacao { get; set; }

        [Column("IDE_MODELO")]
        public int Modelo { get; set; }

        [Column("IDE_SERIE")]
        public int Serie { get; set; }

        [Column("IDE_NNF")]
        public int NumeroNF { get; set; }

        [Column("IDE_DEMI")]
        public DateTime DataEmissao { get; set; }

        [Column("IDE_DSAIENT")]
        public DateTime DataSaida { get; set; }

        [Column("IDE_HSAIENT")]
        public DateTime HoraSaida { get; set; }

        [Column("IDE_TPNF")]
        public int TipoNF { get; set; }

        [Column("IDE_TPEMIS")]
        public int TipoEmissao { get; set; }

        [Column("IDE_TPAMB")]
        public int Ambiente { get; set; }

        [Column("IDE_VERPROC")]
        public string VersaoApp { get; set; }

        [Column("IDE_CUF")]
        public string CodigoIbge { get; set; }

        [Column("IDE_CMUNFG")]
        public int IDE_CMUNFG { get; set; }

        [Column("IDE_FINNFE")]
        public int FinalidadeNF { get; set; }

        [Column("EMIT_CNPJCPF")]
        public string CnpjEmitente { get; set; }

        [Column("EMIT_IE")]
        public string IEEmitente { get; set; }

        [Column("EMIT_XNOME")]
        public string NomeEmitente { get; set; }

        [Column("EMIT_XFANT")]
        public string FantasiaEmitente { get; set; }

        [Column("EMIT_ENDEREMIT_FONE")]
        public string FoneEmitente { get; set; }

        [Column("EMIT_ENDEREMIT_CEP")]
        public string CepEmitente { get; set; }

        [Column("EMIT_ENDEREMIT_XLGR")]
        public string LogradouroEmitente { get; set; }

        [Column("EMIT_ENDEREMIT_NRO")]
        public string NumeroEmitente { get; set; }

        [Column("EMIT_ENDEREMIT_XCPL")]
        public string InfComplEmitente { get; set; }

        [Column("EMIT_ENDEREMIT_XBAIRRO")]
        public string Bairro { get; set; }

        [Column("EMIT_ENDEREMIT_CMUN")]
        public string IbgeEmitente { get; set; }

        [Column("EMIT_ENDEREMIT_XMUN")]
        public string DescMunicipioEmitente { get; set; }

        [Column("EMIT_ENDEREMIT_UF")]
        public string UFEmitente { get; set; }

        [Column("EMIT_ENDEREMIT_CPAIS")]
        public string CodPais { get; set; }

        [Column("EMIT_ENDEREMIT_XPAIS")]
        public string NomePaisEmitente { get; set; }

        [Column("EMIT_IEST")]
        public string IestEmitente { get; set; }

        [Column("EMIT_CNAE")]
        public string CnaeEmitente { get; set; }

        [Column("EMIT_CRT")]
        public int CRT { get; set; }

        [Column("DEST_IE")]
        public string IEDestinatario { get; set; }

        [Column("DEST_ISUF")]
        public string EstadoDestinatario { get; set; }

        [Column("DEST_XNOME")]
        public string NomeDestinatario { get; set; }

        [Column("DEST_ENDERDEST_FONE")]
        public string FoneDestinatario { get; set; }

        [Column("DEST_ENDERDEST_CEP")]
        public string CepDestinatario { get; set; }

        [Column("DEST_ENDERDEST_XLGR")]
        public string LogradouroDestinatario { get; set; }

        [Column("DEST_ENDERDEST_NRO")]
        public string NumeroDestinatario { get; set; }

        [Column("DEST_ENDERDEST_XCPL")]
        public string InfComplDestinatario { get; set; }

        [Column("DEST_ENDERDEST_XBAIRRO")]
        public string BairroDestinatario { get; set; }

        [Column("DEST_ENDERDEST_CMUN")]
        public string IbgeDestinario { get; set; }

        [Column("DEST_ENDERDEST_XMUN")]
        public string NomeMunDestinario { get; set; }

        [Column("DEST_ENDERDEST_UF")]
        public string UFDestinatario { get; set; }

        [Column("DEST_ENDERDEST_CPAIS")]
        public string CodPaisDestinatario { get; set; }

        [Column("DEST_ENDERDEST_XPAIS")]
        public string NomePaisDestinatario { get; set; }

        [Column("NFE_SITUACAO")]
        public int SituacaoNf { get; set; }

        [Column("NFE_TIPO")]
        public int TipoNf { get; set; }

        public NotaFreeNFE()
        {

        }


    }
}
