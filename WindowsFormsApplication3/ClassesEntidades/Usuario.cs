using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace Aplicativo.ClassesEntidades
{
    [Table("usuarios")]
    public class Usuario
    {
        DataContext db = new DataContext();


        [Column("usu_codigo")]
        public int UsuarioID { get; set; }

        [Column("usu_nome")]
        public string Nome { get; set; }

        [Column("usu_senha")]
        public string Senha { get; set; }

        [Column("usu_cadPessoa")]
        public int PPessoa { get; set; }

        [Column("usu_cadProduto")]
        public int PProduto { get; set; }

        [Column("usu_fiscal")]
        public int PFiscal { get; set; }

        [Column("usu_compra")]
        public int PCompra { get; set; }

        [Column("usu_venda")]
        public int PVenda { get; set; }

        [Column("usu_relatorio")]
        public int PRelatorio { get; set; }

        [Column("usu_cadUsuario")]
        public int PUsuario { get; set; }

        public Boolean AcessoPessoa()
        {
            string busca = "select usu_cadPessoa from usuarios where usu_nome = '" + FormLogin.usuarioLogado.Trim() + "'";
            string acesso1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand sqlCommand = new SqlCommand(busca, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {
                acesso1 = dR[0].ToString();
            }          
            else
            {
                acesso1 = "0";
            }
            con.Close();
            Convert.ToInt32(acesso1);

            if (Convert.ToInt32(acesso1) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean AcessoFiscal()
        {
            string busca = "select usu_cadfiscal from usuarios where usu_nome = '" + FormLogin.usuarioLogado.Trim() + "'";
            string acesso1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand sqlCommand = new SqlCommand(busca, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {
                acesso1 = dR[0].ToString();
            }
            else
            {
                acesso1 = "0";
            }
            con.Close();
            Convert.ToInt32(acesso1);

            if (Convert.ToInt32(acesso1) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean AcessoProduto()
        {
            string busca = "select usu_cadProduto from usuarios where usu_nome = '" + FormLogin.usuarioLogado.Trim() + "'";
            string acesso1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand sqlCommand = new SqlCommand(busca, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {
                acesso1 = dR[0].ToString();
            }
            else
            {
                acesso1 = "0";
            }
            con.Close();
            Convert.ToInt32(acesso1);

            if (Convert.ToInt32(acesso1) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean AcessoVenda()
        {
            string busca = "select usu_venda from usuarios where usu_nome = '" + FormLogin.usuarioLogado.Trim() + "'";
            string acesso1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand sqlCommand = new SqlCommand(busca, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {
                acesso1 = dR[0].ToString();
            }
            else
            {
                acesso1 = "0";
            }
            con.Close();
            Convert.ToInt32(acesso1);

            if (Convert.ToInt32(acesso1) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean AcessoCompra()
        {
            string busca = "select usu_compra from usuarios where usu_nome = '" + FormLogin.usuarioLogado.Trim() + "'";
            string acesso1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand sqlCommand = new SqlCommand(busca, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {
                acesso1 = dR[0].ToString();
            }
            else
            {
                acesso1 = "0";
            }
            con.Close();
            Convert.ToInt32(acesso1);

            if (Convert.ToInt32(acesso1) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean AcessoRelatorio()
        {
            string busca = "select usu_relatorios from usuarios where usu_nome = '" + FormLogin.usuarioLogado.Trim() + "'";
            string acesso1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand sqlCommand = new SqlCommand(busca, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {
                acesso1 = dR[0].ToString();
            }
            else
            {
                acesso1 = "0";
            }
            con.Close();
            Convert.ToInt32(acesso1);

            if (Convert.ToInt32(acesso1) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean AcessoUsuario()
        {
            string busca = "select usu_cadusuario from usuarios where usu_nome = '" + FormLogin.usuarioLogado.Trim() + "'";
            string acesso1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand sqlCommand = new SqlCommand(busca, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {
                acesso1 = dR[0].ToString();
            }
            else
            {
                acesso1 = "0";
            }
            con.Close();
            Convert.ToInt32(acesso1);

            if (Convert.ToInt32(acesso1) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
