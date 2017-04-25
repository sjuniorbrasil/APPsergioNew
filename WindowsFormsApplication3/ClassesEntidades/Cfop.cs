using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApplication3.ClassesEntidades
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
