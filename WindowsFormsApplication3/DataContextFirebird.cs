
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Aplicativo.ClassesEntidades;

namespace Aplicativo
{
    public class DataContextFirebird: DbContext
    {
        public DataContextFirebird(): base(Properties.Settings.Default.BancoFirebird)
        {

        }

        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<NotaFreeNFE> Faturas { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }




        [Table("PAIS")]
        public class Pais
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Column("ID")]
            public int ID { get; set; }
            [Column("NOME")]
            public string Nome { get; set; }

            public Pais()
            {

            }
        }

        [Table("MUNICIPIO")]
        public class Municipio
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Column("ID")]

            public int ID { get; set; }
            [Column("NOME")]
            public string Nome { get; set; }

            [Column("COD_IBGE")]
            public string Ibge { get; set; }

            [Column("ID_ESTADO")]
            public int EstadoID { get; set; }


        }
        [Table("ESTADO")]
        public class Estado
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Column("ID")]

            public int ID { get; set; }
            [Column("NOME")]
            public string Nome { get; set; }

            [Column("COD_IBGE")]
            public string Ibge { get; set; }

            [Column("SIGLA")]
            public string Sigla { get; set; }


        }



    }
    
}
