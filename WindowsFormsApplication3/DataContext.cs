using System;
using System.Data.SqlClient;
using System.Data;
using WindowsFormsApplication3.ClassesEntidades;
using System.Data.Entity;



namespace WindowsFormsApplication3
{   
    public class DataContext: DbContext
    {        
        public DataContext(): base(utils.ConexaoDb())
        {

        }
       

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Cfop> Cfops { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Estoque> Estoques { get; set; }
        public virtual DbSet<PedidoProduto> PedidoProdutos { get; set; }

        //pesquisas padrão
        public static DataTable CarregaCidades()
        {
            SqlConnection con = new SqlConnection();           
            con.ConnectionString = utils.ConexaoDb();
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
            con.ConnectionString = utils.ConexaoDb();
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
            con.ConnectionString = utils.ConexaoDb();
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
            con.ConnectionString = utils.ConexaoDb();
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
            con.ConnectionString = utils.ConexaoDb();
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
            con.ConnectionString = utils.ConexaoDb();
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

        public Boolean ClienteInadimplente(int IDcliente)
        {            
            string verInadimplencia = "select * from creceber where cod_cliente =" + IDcliente + " and rec_situacao = 'pendente' and rec_vencido = 1";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand cmd = new SqlCommand(verInadimplencia, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            try
            {
                int contador = Convert.ToInt32(dr[0].ToString());
                if (contador > 0)
                {
                    return true;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }          
        }
        public string GetDescricao(string select, string txt1, string txt2)
        {
            string busca = select + Convert.ToInt32(txt1);
            string descricao;

            SqlConnection con = new SqlConnection();            
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand sqlCommand = new SqlCommand(busca, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {                
                txt2 = dR[0].ToString();                
            }
            else
            {
                txt2 = "";                
            }
            descricao = txt2;
            con.Close();
            return descricao;            
        }
        //public partial class ComandoIncluir()
        //{

        //}
      
                   
    }
}
