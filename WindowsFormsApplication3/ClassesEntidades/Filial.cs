using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicativo.ClassesEntidades
{
    [Table("Filial")]
    public class Filial
    {
        [Column("Fil_codigo")]
        public int ID { get; set; }

        [Column("fil_razao")]
        public string Razao { get; set; }

        [Column("fil_fantasia")]
        public string Fantasia { get; set; }

        [Column("fil_Endereco")]
        public string Endereco { get; set; }

        [Column("fil_Bairro")]
        public string Bairro { get; set; }

        [Column("fil_Cidade")]
        public int CidadeCodigo { get; set; }

        [Column("fil_Telefone")]
        public string Telefone { get; set; }

        [Column("fil_Celular")]
        public string Celular { get; set; }

        [Column("fil_Cep")]
        public string Cep { get; set; }

        [Column("fil_Obs")]
        public string Observacoes { get; set; }

        [Column("fil_cnpj")]
        public string CpfCnpj { get; set; }

        [Column("fil_IE")]
        public string IE { get; set; }

        [Column("fil_Email")]
        public string Email { get; set; }        

        [Column("fil_Numero")]
        public string Numero { get; set; }

        [Column("fil_contador")]
        public string Contador { get; set; }

        [Column("fil_cnpjContador")]
        public string CnpjContador { get; set; }

        [Column("fil_certificado")]
        public string CertificadoDigital { get; set; }

        [Column("fil_crt")]
        public string Crt { get; set; }


    }
}
