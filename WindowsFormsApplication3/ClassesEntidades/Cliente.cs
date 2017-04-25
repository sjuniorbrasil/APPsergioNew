using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WindowsFormsApplication3.ClassesEntidades
{
    [Table("Clientes")]
    public class Cliente
    {
        [Column("Cod_cliente")]
        public int ID { get; set; }

        [Column("n_cliente")]
        public string Razao { get; set; }

        public string Fantasia { get; set; }

        [Column("Endereco")]
        public string Endereco { get; set; }

        [Column("Bairro")]
        public string Bairro { get; set; }

        [Column("Cidade")]
        public int CidadeCodigo { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }

        [Column("Celular")]
        public string Celular { get; set; }

        [Column("Cep")]
        public string Cep { get; set; }

        [Column("Obs")]
        public string Observacoes { get; set; }

        [Column("Cpf")]
        public string Cpf { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Data_Nas")]
        public string DataNascimento { get; set; }

        [Column("Numero")]
        public string Numero { get; set; }



    }
}
