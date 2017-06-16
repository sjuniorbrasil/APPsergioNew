using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Aplicativo.ClassesEntidades;

namespace Aplicativo
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        Usuario user = new Usuario();
        public static string usuarioLogado { get; set; }
        utils u = new utils();
        

        private void button1_Click(object sender, EventArgs e)
        {
            string senha;

            if (textBox1.Text == "admin" && textBox2.Text == "1")
            {
                usuarioLogado = "admin";
                FormPrincipal Inicianiza = new FormPrincipal();
                Inicianiza.Show();
                this.Visible = false;
            }
            else {
                string busca = "select usu_nome, usu_senha from usuarios where usu_nome = '" + textBox1.Text.Trim() + "'";
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = utils.ConexaoDb();
                SqlCommand sqlCommand = new SqlCommand(busca, con);
                con.Open();
                SqlDataReader dR = sqlCommand.ExecuteReader();
                if (dR.Read())
                {
                    senha = dR[1].ToString().Trim();
                    usuarioLogado = dR[0].ToString().Trim();
                    if (senha == textBox2.Text)
                    {
                        FormPrincipal Inicianiza = new FormPrincipal();
                        Inicianiza.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        u.UserSenhaInvalida();
                    }
                }
                else
                {
                    u.UserSenhaInvalida();
                }
                con.Close();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                string senha;

                if (textBox1.Text == "admin" && textBox2.Text == "1")
                {
                    usuarioLogado = "admin";
                    FormPrincipal Inicianiza = new FormPrincipal();
                    Inicianiza.Show();
                    this.Visible = false;
                }
                else
                {
                    string busca = "select usu_nome, usu_senha from usuarios where usu_nome = '" + textBox1.Text.Trim() + "'";

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = utils.ConexaoDb();
                    SqlCommand sqlCommand = new SqlCommand(busca, con);
                    con.Open();
                    SqlDataReader dR = sqlCommand.ExecuteReader();
                    if (dR.Read())
                    {
                        senha = dR[1].ToString().Trim();
                        usuarioLogado = dR[0].ToString().Trim();
                        if (senha == textBox2.Text)
                        {
                            FormPrincipal Inicianiza = new FormPrincipal();
                            Inicianiza.Show();
                            this.Visible = false;
                        }
                        else
                        {
                            u.UserSenhaInvalida();
                        }
                    }
                    else
                    {
                        u.UserSenhaInvalida();
                    }
                    con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
