using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication3.ClassesEntidades;


namespace WindowsFormsApplication3
{
    public partial class FormCidades : Form
    {
        
        bool novo;
        public FormCidades()
        {
            InitializeComponent();

        }
        utils limpartxt = new utils();
        utils u = new utils();
        Cidade cidade = new Cidade();
        DataContext db = new DataContext();       

        private void FormCidades_Load(object sender, EventArgs e)
        {            
            this.MaximizeBox = false;
            buttonExclui.Enabled = false;
            btnCancela.Enabled = false;
            buttonNovo.Enabled = true;
            buttonSair.Enabled = true;
            buttonSalva.Enabled = false;
            txtCodCidade.Enabled = false;
            txtCidade.Enabled = false;
            txtIbge.Enabled = false;
            comboBoxUf.Enabled = false;
            radioButtonDescricao.Checked = true;           
        }
             
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NovoRegistro(object sender, EventArgs e)
        {
            buttonExclui.Enabled = false;
            btnCancela.Enabled = true;
            buttonNovo.Enabled = false;
            buttonSair.Enabled = true;
            buttonSalva.Enabled = true;
            txtCidade.Enabled = true;
            comboBoxUf.Enabled = true;  
            txtIbge.Enabled = true;
            limpartxt.limparTextBoxes(this);
            comboBoxUf.Text = "PR";
            txtCidade.Focus();
            novo = true;
        }

        private void FormCidades_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeusFormularios.FrmCidades = null;
        }
        private bool valida()
        {
            if (txtCidade.Text.Trim() == string.Empty)
            {
                 return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            DataView dv = new DataView(DataContext.CarregaCidades());            
            if (radioButtonCodigo.Checked)
            {

                dv.RowFilter = "cid_codigo =" + Convert.ToUInt32(textBox1.Text);

            }
            if (radioButtonDescricao.Checked)
            {
                dv.RowFilter = "cid_nome like'%" + textBox1.Text + "%'";
            }
            cIDADESDataGridView.DataSource = dv;
        }

        private void buttonExclui_Click(object sender, EventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Você deseja realmente excluir o registro selecionado?", "Mensagem do Sitema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (escolha == DialogResult.Cancel)
            {
                buttonExclui.Enabled = false;
                btnCancela.Enabled = true;
                buttonNovo.Enabled = true;
                buttonSair.Enabled = true;
                buttonSalva.Enabled = false;
                txtCodCidade.Enabled = false;
                txtCidade.Enabled = false;
                comboBoxUf.Enabled = false;    
                txtIbge.Enabled = false;
                limpartxt.limparTextBoxes(this);
                comboBoxUf.Text = "PR";
            }
            else
            {
                string sql = "delete from cidades where cid_codigo = " + txtCodCidade.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = utils.ConexaoDb();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if
                        (i > 0)
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
            }
            cIDADESDataGridView.Refresh();
            buttonExclui.Enabled = false;
            btnCancela.Enabled = true;
            buttonNovo.Enabled = true;
            buttonSair.Enabled = true;
            buttonSalva.Enabled = false;
            txtCodCidade.Enabled = false;
            txtIbge.Enabled = false;
            txtCidade.Enabled = false;
            comboBoxUf.Enabled = false;            
            limpartxt.limparTextBoxes(this);
            comboBoxUf.Text = "PR";
        }
        
        private void btnCancela_Click(object sender, EventArgs e)
        {
            buttonExclui.Enabled = false;
            btnCancela.Enabled = true;
            buttonNovo.Enabled = true;
            buttonSair.Enabled = true;
            buttonSalva.Enabled = false;
            txtCodCidade.Enabled = false;
            txtCidade.Enabled = false;
            txtIbge.Enabled = false;
            comboBoxUf.Enabled = false;            
            limpartxt.limparTextBoxes(this);
            comboBoxUf.Text = "PR";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelPesquisa.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            novo = false;
            panelPesquisa.Visible = true;
            textBox1.Focus();
            cIDADESDataGridView.Refresh();
        }

        private void cIDADESDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panelPesquisa.Visible = false;
                DataGridViewRow row = this.cIDADESDataGridView.Rows[e.RowIndex];
                txtCodCidade.Text = row.Cells[0].Value.ToString();
                txtCidade.Text = row.Cells[1].Value.ToString();
                comboBoxUf.Text = row.Cells[2].Value.ToString();
                txtIbge.Text = row.Cells[3].Value.ToString();
                buttonExclui.Enabled = true;
                btnCancela.Enabled = true;
                buttonNovo.Enabled = false;
                buttonSair.Enabled = true;
                buttonSalva.Enabled = true;
                txtCodCidade.Enabled = true;
                txtCidade.Enabled = true;
                txtIbge.Enabled = true;
                comboBoxUf.Enabled = true;
                txtCidade.Focus();
            }
        }

        private void buttonSalva_Click(object sender, EventArgs e)
        {
            cidade.Descricao = txtCidade.Text;
            cidade.UF = comboBoxUf.Text;
            cidade.Ibge = txtIbge.Text;
            if (txtCidade.Text == string.Empty || comboBoxUf.Text == string.Empty)
            {
                txtCidade.BackColor = Color.Gold;
                comboBoxUf.BackColor = Color.Gold;
                u.messageboxCamposObrigatorio();
            }
            else
            {
                if (novo)
                {
                    string sql = "insert into cidades(cid_nome,cid_uf,cid_ibge) " + "values('" + cidade.Descricao + "','" 
                        + cidade.UF + "','" + cidade.Ibge +  "')";
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = utils.ConexaoDb();
                    SqlCommand cmd = new SqlCommand(sql, con);
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
                }
                else
                {
                    cidade.ID = Convert.ToInt32(txtCodCidade.Text);
                    string sql = "update cidades set cid_nome = '" + cidade.Descricao +
                        "', cid_uf = '" + cidade.UF + "', cid_ibge = '" + cidade.Ibge + "'" + "where cid_codigo = '" + cidade.ID + "'" ;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = utils.ConexaoDb();
                    SqlCommand cmd = new SqlCommand(sql, con);
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
                        cIDADESDataGridView.Refresh();
                        con.Close();
                    }
                }
                limpartxt.limparTextBoxes(this);
                buttonExclui.Enabled = false;
                btnCancela.Enabled = false;
                buttonNovo.Enabled = true;
                buttonSair.Enabled = true;
                buttonSalva.Enabled = false;
                txtCodCidade.Enabled = false;
                txtIbge.Enabled = false;
                txtCidade.Enabled = false;
                comboBoxUf.Enabled = false;
                txtCidade.BackColor = SystemColors.Window;
                comboBoxUf.BackColor = SystemColors.Window;
            }
        }

        private void radioButtonCodigo_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void radioButtonDescricao_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButtonCodigo.Checked)
            {
                u.ApenasNumeros();
            }
        }
    }
}




