using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using WindowsFormsApplication3.ClassesEntidades;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Data.Entity;





namespace WindowsFormsApplication3
{
   
    public class DataContext: DbContext
    {        
        public DataContext(): base(Properties.Settings.Default.Ducaun)
        {

        }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Cfop> Cfops { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        
        

        public static DataTable CarregaCidades()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;

            con.Open();
            SqlCommand Cmm = new SqlCommand();
            Cmm.CommandText = "Select * from cidades";
            Cmm.CommandType = CommandType.Text;
            Cmm.Connection = con;
            SqlDataReader DR;
            DR = Cmm.ExecuteReader();                    

            DataTable DT = new DataTable();
            DT.Load(DR);

            con.Close();
            return DT;
        }

        public static DataTable CarregaClientes()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;
            con.Open();
            SqlCommand Cmm = new SqlCommand();
            Cmm.CommandText = "Select * from clientes";
            Cmm.CommandType = CommandType.Text;
            Cmm.Connection = con;
            SqlDataReader DR;
            DR = Cmm.ExecuteReader();           

            DataTable DT = new DataTable();
            DT.Load(DR);

            con.Close();
            return DT;

        }

        public static DataTable CarregaFornecedores()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;
            con.Open();
            SqlCommand Cmm = new SqlCommand();
            Cmm.CommandText = "Select * from fornecedores";
            Cmm.CommandType = CommandType.Text;
            Cmm.Connection = con;
            SqlDataReader DR;
            DR = Cmm.ExecuteReader();

            DataTable DT = new DataTable();
            DT.Load(DR);

            con.Close();
            return DT;
        }

        public static DataTable CarregaProdutos()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;
            con.Open();
            SqlCommand Cmm = new SqlCommand();
            Cmm.CommandText = "Select * from produtos";
            Cmm.CommandType = CommandType.Text;
            Cmm.Connection = con;
            SqlDataReader DR;
            DR = Cmm.ExecuteReader();

            DataTable DT = new DataTable();
            DT.Load(DR);

            con.Close();
            return DT;
        }

        public static DataTable CarregaCfop()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;
            con.Open();
            SqlCommand Cmm = new SqlCommand();
            Cmm.CommandText = "Select * from cfop";
            Cmm.CommandType = CommandType.Text;
            Cmm.Connection = con;
            SqlDataReader DR;
            DR = Cmm.ExecuteReader();

            DataTable DT = new DataTable();
            DT.Load(DR);

            con.Close();
            return DT;
        }

        public static DataTable CarregaFuncionarios()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;
            con.Open();
            SqlCommand Cmm = new SqlCommand();
            Cmm.CommandText = "Select * from funcionarios";
            Cmm.CommandType = CommandType.Text;
            Cmm.Connection = con;
            SqlDataReader DR;
            DR = Cmm.ExecuteReader();

            DataTable DT = new DataTable();
            DT.Load(DR);

            con.Close();
            return DT;
        }
    }
}
