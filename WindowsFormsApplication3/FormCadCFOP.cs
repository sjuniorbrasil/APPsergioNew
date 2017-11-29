using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Aplicativo.ClassesEntidades;
using System.Data.Entity;

namespace Aplicativo
{
    public partial class FormCadCFOP : Form
    {
        bool novo;
        public FormCadCFOP()
        {
            InitializeComponent();
        }
        utils u = new utils();
        DataContext db = new DataContext();
        //Cfop cfop = new Cfop();
        
        private void limpa()
        {
            u.limparMTextBoxes(this);
            u.limparTextBoxes(this);
            btnCancela.Enabled = false;
            buttonExclui.Enabled = false;
            buttonNovo.Enabled = true;
            buttonSair.Enabled = true;
            buttonSalva.Enabled = false;
            txtCodCopf.Focus();
        }
        private void alterar()
        {
            btnCancela.Enabled = true;
            buttonExclui.Enabled = true;
            buttonNovo.Enabled = false;
            buttonSair.Enabled = true;
            buttonSalva.Enabled = true;
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }

        private void FormCadCFOP_Load(object sender, EventArgs e)
        {           
            u.DisableTxt(this);
            limpa();
        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            limpa();
            buttonSalva.Enabled = true;
            u.EnableTxt(this);
            txtCodCopf.Enabled = true;
            novo = true;
            txtCodCopf.Focus();            
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCadCFOP_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeusFormularios.FrmCadCfop = null;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            buttonSalva.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelPesquisa.Visible = true;
            textBox1.Focus();
            novo = false;
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            limpa();
        }

        private void buttonExclui_Click(object sender, EventArgs e)
        {
            if (DataContext.TipoConexao == 2)
            {
                Cfop cfop = new Cfop();
                cfop.ID = Convert.ToInt32(txtCodCopf.Text);

                DialogResult escolha = MessageBox.Show("Deseja realmente excluir esse registro ?", "Mensagem do Sitema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (escolha == DialogResult.Cancel)
                {

                }
                else
                {
                    string excluir = "delete from CFOP where cfo_codigo = " + cfop.ID;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = utils.ConexaoDb();
                    SqlCommand cmd = new SqlCommand(excluir, con);
                    cmd.CommandType = CommandType.Text;
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
            else
            {
                DialogResult escolha = MessageBox.Show("Deseja realmente excluir esse registro ?", "Mensagem do Sitema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (escolha == DialogResult.Cancel)
                {

                }
                else
                {
                    try
                    {                        
                        var cfup = db.Cfops.Find(Convert.ToInt32(txtCodCopf.Text.Trim()));
                        db.Cfops.Remove(cfup);
                        u.messageboxSucesso();
                    }
                    catch (Exception ex)
                    {
                        u.messageboxErro(ex.ToString());
                        throw;
                    }
                }
            }
            limpa();
        }

        private void buttonSalva_Click(object sender, EventArgs e)
        {
            if (DataContext.TipoConexao == 1)
            {
                Cfop cfop = new Cfop(/*int.Parse(txtCodCopf.Text), txtDescricao.Text*/);
                cfop.Descricao = txtDescricao.Text;
                cfop.ID = Convert.ToInt32(txtCodCopf.Text);
                if (txtCodCopf.Text == string.Empty || txtDescricao.Text == string.Empty)
                {
                    txtCodCopf.BackColor = Color.Gold;
                    txtDescricao.BackColor = Color.Gold;
                    u.messageboxCamposObrigatorio();
                }
                else
                {
                    if (novo)
                    {
                        string inserir = "insert into cfop(cfo_codigo, cfo_descricao) values(@cfo_codigo, @cfo_descricao)";
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = utils.ConexaoDb();
                        SqlCommand cmd = new SqlCommand(inserir, con);
                        cmd.Parameters.Add("@cfo_codigo", SqlDbType.Int).Value = cfop.ID;
                        cmd.Parameters.Add("@cfo_descricao", SqlDbType.NVarChar).Value = cfop.Descricao;
                        cmd.CommandType = CommandType.Text;
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
                            //throw new ArgumentException("TESTE"); pode ser configurada para mostrar uma mensagem configurara no debug para o programador
                            throw;// apenas throw mostra a mensagem padrão sem tratamento
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                    else
                    {
                        string altera = "update cfop set cfo_descricao = @cfo_descricao where cfo_codigo =" + cfop.ID;
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = utils.ConexaoDb();
                        SqlCommand cmd = new SqlCommand(altera, con);
                        cmd.Parameters.Add("@cfo_descricao", SqlDbType.NVarChar).Value = cfop.Descricao;
                        cmd.CommandType = CommandType.Text;
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
                    txtCodCopf.BackColor = SystemColors.Window;
                    txtDescricao.BackColor = SystemColors.Window;
                    limpa();
                    u.DisableTxt(this);
                }
            }
            else
            {
                if (novo)
                {
                    try
                    {
                        Cfop cfop = new Cfop();
                        cfop.ID = Convert.ToInt32(txtCodCopf.Text.Trim());
                        cfop.Descricao = txtDescricao.Text.Trim();
                        db.Cfops.Add(cfop);
                        db.SaveChanges();
                        u.messageboxSucesso();                        
                    }
                    catch (Exception ex)
                    {
                        u.messageboxErro(ex.ToString());
                        throw;
                    }                    
                }
                else
                {
                    try
                    {
                        var cfup = db.Cfops.Find(Convert.ToInt32(txtCodCopf.Text));
                        cfup.ID = Convert.ToInt32(txtCodCopf.Text.Trim());
                        cfup.Descricao = txtDescricao.Text.Trim();
                        db.Entry(cfup).State = EntityState.Modified;
                        db.SaveChanges();
                        u.messageboxSucesso();
                    }
                    catch (Exception ex)
                    {
                        u.messageboxErro(ex.ToString());
                        throw;
                    }
                }
            }
        }

        private void cIDADESDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panelPesquisa.Visible = false;
            alterar();
            DataGridViewRow row = this.cfopDataGridView.Rows[e.RowIndex];
            txtCodCopf.Text = row.Cells[0].Value.ToString();
            txtDescricao.Text = row.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaCfop());
            if (radioButtonCodigo.Checked)
            {
                dv.RowFilter = "cfo_codigo =" + textBox1.Text;
            }
            if (radioButtonDescricao.Checked)
            {
                dv.RowFilter = "cfo_descricao like'%" + textBox1.Text + "%'";
            }

            cfopDataGridView.DataSource = dv;
        }

        private void txtCodCopf_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelPesquisa.Visible = false;
        }


        private void GetDescricaoCfop()
        {            
            string buscaCfop = "Select cfo_descricao From cfop where cfo_codigo = '" + utils.RCE(txtCodCopf.Text.Trim()) + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand sqlCommand = new SqlCommand(buscaCfop, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {
                novo = false;
                txtDescricao.Text = dR[0].ToString();
            }
            else
            {
                txtDescricao.Clear();
            }
            con.Close();
        }

        private void txtCodCopf_TextChanged(object sender, EventArgs e)
        {            
            if (txtCodCopf.Text == null || txtCodCopf.Text == string.Empty)
            {
                txtDescricao.Focus();
            }
            else
            {                
                GetDescricaoCfop();
            }
        }
    }
}
