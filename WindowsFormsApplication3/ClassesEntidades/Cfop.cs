using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicativo.ClassesEntidades
{
    [Table("Cfop")]
    public class Cfop
    {
        [Column("cfo_codigo")]
        public int ID { get; set; }

        [Column("cfo_descricao")]
        public string Descricao { get; set; }

        public Cfop()
        {
            
        }

    }
}
