using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApplication3.ClassesEntidades
{
    [Table("Cidades")]
    public class Cidade
    {
        [Column("cid_codigo")]
        public int ID { get; set; }
        [Column("cid_ibge")]
        public int Ibge { get; set; }
        [Column("cid_nome")]
        public string Descricao { get; set; }
        [Column("cid_uf")]
        public string UF { get; set; }        

    }
    
}
