using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Aplicativo.ClassesEntidades;

namespace Aplicativo
{
    public partial class frmCadUsuario : Form

    {
        bool novo;
        utils u = new utils();
        public frmCadUsuario()
        {
            InitializeComponent();
        }
        private void Unovo()
        {
            u.EnableTxt(this);
            u.EnableCheck(this);
            u.limparTextBoxes(this);
            u.CheckBoxUnchecked(this);
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            buttonSaiCadClientes.Enabled = true;
            buttonCancelaCadcliente.Enabled = true;
            txtCodigo.Enabled = false;
        }

        private void Ulimpa()
        {            
            u.limparTextBoxes(this);
            u.CheckBoxUnchecked(this);
            u.DisableCheck(this);
            u.DisableTxt(this);
            u.CheckBoxUnchecked(this);            
            btnChamaPesquisa.Enabled = true;
            btnExcluir.Enabled = false;
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            buttonSaiCadClientes.Enabled = true;
            buttonCancelaCadcliente.Enabled = false;
            txtCodigo.Enabled = false;
        }

        private void Ualterar()
        {
            u.EnableTxt(this);
            u.EnableCheck(this);
            textBox1.Enabled = false;
            btnChamaPesquisa.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            buttonSaiCadClientes.Enabled = true;
            buttonCancelaCadcliente.Enabled = true;
            txtCodigo.Enabled = false;
        }

        private void frmCadUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeusFormularios.formCadUsuarios = null;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo = true;
            Unovo();
        }

        private void buttonSaiCadClientes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancelaCadcliente_Click(object sender, EventArgs e)
        {
            Ulimpa();
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
                      
            Ulimpa();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string deletar = "delete from usuarios where usu_codigo = " + txtCodigo.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand cmd = new SqlCommand(deletar, con);
            cmd.CommandType = CommandType.Text;
            con.Open();            
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    u.messageboxSucesso();
            }
            catch (Exception ex)
            {
                u.messageboxErro(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            Ulimpa();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            string busca = "select usu_nome from usuarios where usu_nome = '" + textBox1.Text.Trim() + "'";

            if (textBox1.Text != "admin")
            {
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = utils.ConexaoDb();
                SqlCommand sqlCommand = new SqlCommand(busca, con1);
                con1.Open();
                SqlDataReader dR = sqlCommand.ExecuteReader();
                if (dR.Read())
                {
                    user.Nome = dR[0].ToString().Trim();
                }
                else
                {
                    user.Nome = "";
                }
                con1.Close();
                if (user.Nome != textBox1.Text)
                {
                    if (novo)
                    {
                        string insert = "insert into usuarios(usu_nome, usu_senha, usu_cadpessoa, usu_cadproduto, usu_venda, usu_compra, usu_cadfiscal, usu_cadusuario, usu_relatorios) values(@usu_nome, @usu_senha, @usu_cadpessoa, @usu_cadproduto, @usu_venda, @usu_compra, @usu_cadfiscal, @usu_cadusuario, @usu_relatorios)";

                        user.Nome = textBox1.Text;
                        user.Senha = textBox2.Text;
                        if (checkPessoa.Checked)
                        {
                            user.PPessoa = 1;
                        }
                        else
                        {
                            user.PPessoa = 0;
                        }
                        if (checkProduto.Checked)
                        {
                            user.PProduto = 1;
                        }
                        else
                        {
                            user.PProduto = 0;
                        }
                        if (checkRelatório.Checked)
                        {
                            user.PRelatorio = 1;
                        }
                        else
                        {
                            user.PRelatorio = 0;
                        }
                        if (checkUsuario.Checked)
                        {
                            user.PUsuario = 1;
                        }
                        else
                        {
                            user.PUsuario = 0;
                        }
                        if (checkVenda.Checked)
                        {
                            user.PVenda = 1;
                        }
                        else
                        {
                            user.PVenda = 0;
                        }
                        if (checkCompra.Checked)
                        {
                            user.PCompra = 1;
                        }
                        else
                        {
                            user.PCompra = 0;
                        }
                        if (checkFiscal.Checked)
                        {
                            user.PFiscal = 1;
                        }
                        else
                        {
                            user.PFiscal = 0;
                        }

                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = utils.ConexaoDb();
                        SqlCommand cmd = new SqlCommand(insert, con);
                        cmd.Parameters.Add("@usu_nome", SqlDbType.NVarChar).Value = user.Nome;
                        cmd.Parameters.Add("@usu_senha", SqlDbType.VarChar).Value = user.Senha;
                        cmd.Parameters.Add("@usu_cadpessoa", SqlDbType.Int).Value = user.PPessoa;
                        cmd.Parameters.Add("@usu_cadproduto", SqlDbType.Int).Value = user.PProduto;
                        cmd.Parameters.Add("@usu_venda", SqlDbType.Int).Value = user.PVenda;
                        cmd.Parameters.Add("@usu_compra", SqlDbType.Int).Value = user.PCompra;
                        cmd.Parameters.Add("@usu_cadfiscal", SqlDbType.Int).Value = user.PFiscal;
                        cmd.Parameters.Add("@usu_cadusuario", SqlDbType.Int).Value = user.PUsuario;
                        cmd.Parameters.Add("@usu_relatorios", SqlDbType.Int).Value = user.PRelatorio;
                        con.Open();
                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                u.messageboxSucesso();
                            }
                        }
                        catch (Exception ex)
                        {
                            u.messageboxErro(ex.ToString());
                            throw;
                        }
                        finally
                        {
                            con.Close();
                        }

                    }
                    else
                    {
                        if (textBox2.Text != string.Empty)
                        {
                            string alterar = "update usuarios set usu_senha = @usu_senha, usu_cadpessoa= @usu_cadpessoa, usu_cadproduto = @usu_cadproduto, usu_venda = @usu_venda, usu_compra = @usu_compra, usu_cadfiscal = @usu_cadfiscal, usu_cadusuario = @usu_cadusuario, usu_relatorios = @usu_relatorios";
                            user.Senha = textBox2.Text;
                            if (checkPessoa.Checked)
                            {
                                user.PPessoa = 1;
                            }
                            else
                            {
                                user.PPessoa = 0;
                            }
                            if (checkProduto.Checked)
                            {
                                user.PProduto = 1;
                            }
                            else
                            {
                                user.PProduto = 0;
                            }
                            if (checkRelatório.Checked)
                            {
                                user.PRelatorio = 1;
                            }
                            else
                            {
                                user.PRelatorio = 0;
                            }
                            if (checkUsuario.Checked)
                            {
                                user.PUsuario = 1;
                            }
                            else
                            {
                                user.PUsuario = 0;
                            }
                            if (checkVenda.Checked)
                            {
                                user.PVenda = 1;
                            }
                            else
                            {
                                user.PVenda = 0;
                            }
                            if (checkCompra.Checked)
                            {
                                user.PCompra = 1;
                            }
                            else
                            {
                                user.PCompra = 0;
                            }
                            if (checkFiscal.Checked)
                            {
                                user.PFiscal = 1;
                            }
                            else
                            {
                                user.PFiscal = 0;
                            }

                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = utils.ConexaoDb();
                            SqlCommand cmd = new SqlCommand(alterar, con);
                            cmd.Parameters.Add("@usu_nome", SqlDbType.NVarChar).Value = user.Nome;
                            cmd.Parameters.Add("@usu_senha", SqlDbType.VarChar).Value = user.Senha;
                            cmd.Parameters.Add("@usu_cadpessoa", SqlDbType.Int).Value = user.PPessoa;
                            cmd.Parameters.Add("@usu_cadproduto", SqlDbType.Int).Value = user.PProduto;
                            cmd.Parameters.Add("@usu_venda", SqlDbType.Int).Value = user.PVenda;
                            cmd.Parameters.Add("@usu_compra", SqlDbType.Int).Value = user.PCompra;
                            cmd.Parameters.Add("@usu_cadfiscal", SqlDbType.Int).Value = user.PFiscal;
                            cmd.Parameters.Add("@usu_cadusuario", SqlDbType.Int).Value = user.PUsuario;
                            cmd.Parameters.Add("@usu_relatorios", SqlDbType.Int).Value = user.PRelatorio;
                            con.Open();
                            try
                            {
                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    u.messageboxSucesso();
                                }
                            }
                            catch (Exception ex)
                            {
                                u.messageboxErro(ex.ToString());
                                throw;
                            }
                            finally
                            {
                                con.Close();
                            }

                        }
                        else
                        {
                            string alterar = "update usuarios set  usu_cadpessoa= @usu_cadpessoa, usu_cadproduto = @usu_cadproduto, usu_venda = @usu_venda, usu_compra = @usu_compra, usu_cadfiscal = @usu_cadfiscal, usu_cadusuario = @usu_cadusuario, usu_relatorios = @usu_relatorios";

                            if (checkPessoa.Checked)
                            {
                                user.PPessoa = 1;
                            }
                            else
                            {
                                user.PPessoa = 0;
                            }
                            if (checkProduto.Checked)
                            {
                                user.PProduto = 1;
                            }
                            else
                            {
                                user.PProduto = 0;
                            }
                            if (checkRelatório.Checked)
                            {
                                user.PRelatorio = 1;
                            }
                            else
                            {
                                user.PRelatorio = 0;
                            }
                            if (checkUsuario.Checked)
                            {
                                user.PUsuario = 1;
                            }
                            else
                            {
                                user.PUsuario = 0;
                            }
                            if (checkVenda.Checked)
                            {
                                user.PVenda = 1;
                            }
                            else
                            {
                                user.PVenda = 0;
                            }
                            if (checkCompra.Checked)
                            {
                                user.PCompra = 1;
                            }
                            else
                            {
                                user.PCompra = 0;
                            }
                            if (checkFiscal.Checked)
                            {
                                user.PFiscal = 1;
                            }
                            else
                            {
                                user.PFiscal = 0;
                            }

                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = utils.ConexaoDb();
                            SqlCommand cmd = new SqlCommand(alterar, con);
                            cmd.Parameters.Add("@usu_nome", SqlDbType.NVarChar).Value = user.Nome;

                            cmd.Parameters.Add("@usu_cadpessoa", SqlDbType.Int).Value = user.PPessoa;
                            cmd.Parameters.Add("@usu_cadproduto", SqlDbType.Int).Value = user.PProduto;
                            cmd.Parameters.Add("@usu_venda", SqlDbType.Int).Value = user.PVenda;
                            cmd.Parameters.Add("@usu_compra", SqlDbType.Int).Value = user.PCompra;
                            cmd.Parameters.Add("@usu_cadfiscal", SqlDbType.Int).Value = user.PFiscal;
                            cmd.Parameters.Add("@usu_cadusuario", SqlDbType.Int).Value = user.PUsuario;
                            cmd.Parameters.Add("@usu_relatorios", SqlDbType.Int).Value = user.PRelatorio;
                            con.Open();
                            try
                            {
                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    u.messageboxSucesso();
                                }
                            }
                            catch (Exception ex)
                            {
                                u.messageboxErro(ex.ToString());
                                throw;
                            }
                            finally
                            {
                                con.Close();
                            }

                        }
                        

                    }
                    Ulimpa();
                }
                else
                {
                    MessageBox.Show("Nome de Usuário ja existente! ", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nome de Usuário ja existente! ", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnChamaPesquisa_Click(object sender, EventArgs e)
        {
            panelPesquisa.Visible = true;            
            novo = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaUsuarios());
            UserDataGridView.DataSource = dv;
        }

        private void cfopDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Ualterar();
            Usuario user = new Usuario();
            panelPesquisa.Visible = false;
            Ualterar();
            DataGridViewRow row = this.UserDataGridView.Rows[e.RowIndex];
            txtCodigo.Text = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            string ponteiroUsuario = FormLogin.usuarioLogado;
            //a1 = Convert.ToInt32(row.Cells[3].Value.ToString());
            //a2 = Convert.ToInt32(row.Cells[6].Value.ToString());
            //a3 = Convert.ToInt32(row.Cells[5].Value.ToString());
            //a4 = Convert.ToInt32(row.Cells[4].Value.ToString());
            //a5 = Convert.ToInt32(row.Cells[8].Value.ToString());
            //a6 = Convert.ToInt32(row.Cells[9].Value.ToString());
            // a7 = Convert.ToInt32(row.Cells[7].Value.ToString());
            FormLogin.usuarioLogado = textBox1.Text;
            if (user.AcessoCompra())
            {
                checkCompra.Checked = true;
            }
            if (user.AcessoFiscal())
            {
                checkFiscal.Checked = true;
            }
            if (user.AcessoPessoa())
            {
                checkPessoa.Checked = true;
            }
            if (user.AcessoProduto())
            {
                checkProduto.Checked = true;
            }
            if (user.AcessoRelatorio())
            {
                checkRelatório.Checked = true;
            }
            if (user.AcessoUsuario())
            {
                checkUsuario.Checked = true;
            }
            if (user.AcessoVenda())
            {
                checkVenda.Checked = true;
            }
            textBox2.Enabled = true;
            FormLogin.usuarioLogado = ponteiroUsuario;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelPesquisa.Visible = false;
        }
    }
}
