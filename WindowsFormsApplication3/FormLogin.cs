using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication3.ClassesEntidades;

namespace WindowsFormsApplication3
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        Usuario user = new Usuario();
        public static string usuarioLogado { get; set; }
        

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
                        MessageBox.Show("Usuário ou Senha Inválidos", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha Inválidos", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
        }
    }
}
