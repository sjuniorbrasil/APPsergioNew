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

namespace WindowsFormsApplication3
{
    public partial class FormFuncionarios : Form
    {
        bool novo;
        public FormFuncionarios()
        {
            InitializeComponent();
        }
        utils u = new utils();
        DataContext db = new DataContext();

        private void Unovo()
        {
            u.limparMTextBoxes(this);
            u.limparTextBoxes(this);
            u.DisableTxt(this);
            u.DisableMasked(this); ;
            u.DisableDataGrid(this);
            u.DisableCombo(this);
            btnNovo.Enabled = true;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            buttonCancelareg.Enabled = false;
            btnNovo.Focus();
        }

        private void Ualterar()
        {
            u.EnableTxt(this);
            u.EnableMasked(this); ;
            u.EnableDataGrid(this);
            u.EnableCombo(this);
            btnNovo.Enabled = false;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = true;
            buttonCancelareg.Enabled = true;
            textBoxCodFuncionario.Enabled = false;
        }

        private void FormFuncionarios_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            panelCid.Visible = false;
            rbNomeC.Checked = true;
            panel1.Visible = false;
            Unovo();           
        }

        private void buttonSaiAtendimento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLocalizaCadCliente_Click(object sender, EventArgs e)
        {
            Unovo();
        }
        private void FormFuncionarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeusFormularios.FrmFuncionarios = null;
        }

        private void btnLocaliza_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            u.limparMTextBoxes(this);
            u.limparTextBoxes(this);
            u.EnableCombo(this);
            u.EnableDataGrid(this);
            u.EnableMasked(this);
            u.EnableTxt(this);
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            buttonCancelareg.Enabled = true;
            btnPcidade.Enabled = true;            
            novo = true;
            textBoxNomeFuncionario.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Deseja realmente excluir esse registro? ", "Mensagem do sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (escolha == DialogResult.Cancel)
            {                               

            }
            else
            {

                string excrui = "delete from funcionarios where cod_funcionario =  " + textBoxCodFuncionario.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.Ducaun;
                SqlCommand cmd = new SqlCommand(excrui, con);
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
                    funcionariosDataGridView.Refresh();
                    con.Close();
                }
                Unovo();               
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (textBoxNomeFuncionario.Text == string.Empty)
            {
                textBoxNomeFuncionario.BackColor = Color.Gold;
                u.messageboxCamposObrigatorio();
            }
            else
            {
                if (novo)
                {
                    string insere = "insert into funcionarios(n_funcionario, endereco, bairro, cidade, telefone, celular, cep, data_contratacao, obs, ctps, cpf, email) " +
                        "values ('" + textBoxNomeFuncionario.Text + "','"
                            + textBoxEndereco.Text + "','"
                            + textBoxBairroFuncionario.Text + "','"
                            + textBoxCidadeFuncionario.Text + "','"
                            + maskedTextBoxTelefoneFuncionario.Text + "','"
                            + maskedTextBoxCelular.Text + "','"
                            + maskedTextBoxCepFuncionario.Text + "','"
                            + maskedTextBoxDatacon.Text + "','"
                            + textBoxObs.Text + "','"
                            + maskedTextBoxCtps.Text + "','"
                            + maskedTextBoxCpf.Text + "','"
                            + textBoxNumero.Text + "')";
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Properties.Settings.Default.Ducaun;
                    SqlCommand cmd = new SqlCommand(insere, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            u.messageboxSucesso();
                        funcionariosDataGridView.Refresh();
                    }
                    catch (Exception ex)
                    {
                        u.messageboxErro(ex.ToString());
                    }
                    finally
                    {
                        funcionariosDataGridView.Refresh();
                        con.Close();
                    }
                }
                else
                {
                    string altera = "update funcionarios set n_funcionario = '" + textBoxNomeFuncionario.Text +
                        "', endereco = '" + textBoxEndereco.Text +
                        "',bairro = '" + textBoxBairroFuncionario.Text +
                        "',cidade = '" + textBoxCidadeFuncionario.Text +
                        "',telefone = '" + maskedTextBoxTelefoneFuncionario.Text +
                        "', celular = '" + maskedTextBoxCelular.Text +
                        "',cep = '" + maskedTextBoxCepFuncionario.Text +
                        "', data_contratacao = '" + maskedTextBoxDatacon.Text +
                        "', obs = '" + textBoxObs.Text +
                        "', ctps = '" + maskedTextBoxCtps.Text +
                        "', cpf =  '" + maskedTextBoxCpf.Text +
                        "', email = '" + textBoxNumero.Text + "' where cod_funcionario = '" + textBoxCodFuncionario.Text + "'";
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Properties.Settings.Default.Ducaun;
                    SqlCommand cmd = new SqlCommand(altera, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            u.messageboxSucesso();
                        funcionariosDataGridView.Refresh();
                    }
                    catch (Exception ex)
                    {
                        u.messageboxErro(ex.ToString());
                    }
                    finally
                    {
                        funcionariosDataGridView.Refresh();
                        con.Close();
                    }

                }
                Unovo();
                textBoxNomeFuncionario.BackColor = SystemColors.Window;
                btnNovo.Focus();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataView dv = new DataView(DataContext.CarregaFuncionarios());
            if (radioButtonCodigo.Checked)
            {
                dv.RowFilter = "cod_funcionario = " + textBox2.Text;
            }
            if (radioButtonDescricao.Checked)
            {
                dv.RowFilter = "n_funcionario like '%" + textBox2.Text + "%'";
            }
            funcionariosDataGridView.DataSource = dv;
        }
            

        private void radioButtonDescricao_Enter(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void radioButtonCodigo_Enter(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void funcionariosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                panel1.Visible = false;
                DataGridViewRow row = this.funcionariosDataGridView.Rows[e.RowIndex];
                textBoxCodFuncionario.Text = row.Cells[0].Value.ToString();
                textBoxNomeFuncionario.Text = row.Cells[1].Value.ToString();
                textBoxEndereco.Text = row.Cells[2].Value.ToString();
                textBoxBairroFuncionario.Text = row.Cells[3].Value.ToString();
                textBoxCidadeFuncionario.Text = row.Cells[4].Value.ToString();
                maskedTextBoxTelefoneFuncionario.Text = row.Cells[5].Value.ToString();
                maskedTextBoxCelular.Text = row.Cells[6].Value.ToString();
                maskedTextBoxCepFuncionario.Text = row.Cells[7].Value.ToString();
                maskedTextBoxDatacon.Text = row.Cells[8].Value.ToString();
                textBoxObs.Text = row.Cells[9].Value.ToString();
                maskedTextBoxCtps.Text = row.Cells[10].Value.ToString();
                maskedTextBoxCpf.Text = row.Cells[12].Value.ToString();
                textBoxNumero.Text = row.Cells[13].Value.ToString();
                u.EnableCombo(this);
                u.EnableDataGrid(this);
                u.EnableMasked(this);
                u.EnableTxt(this);
                btnNovo.Enabled = false;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = true;
                buttonCancelareg.Enabled = true;
                textBoxNomeFuncionario.Focus();
                btnPcidade.Enabled = true;
                txtNcid.Enabled = true;                
            }
        }

        private void maskedTextBoxCpf_Leave(object sender, EventArgs e)
        {
            try
            {
                string valor = maskedTextBoxCpf.Text;
                if (ValidaCPF.ValidaCPF.Valida(valor))
                {
                    textBoxBairroFuncionario.Focus();
                }
            }
            catch
            {
                MessageBox.Show("O CPF digitado é inválido", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                textBoxBairroFuncionario.Focus();
            }
        }

        private void btnPcidade_Click(object sender, EventArgs e)
        {
            panelCid.Visible = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            panelCid.Visible = false;
        }

        private void btnPesq_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaCidades());
            if (rbCcid.Checked)
            {
                dv.RowFilter = "cid_codigo = " + txtcid.Text;
            }
            if (rbNomeC.Checked)
            {
                dv.RowFilter = "cid_nome like '%" + txtcid.Text + "%'";
            }
            dataGridView1.DataSource = dv;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                panelCid.Visible = false;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBoxCidadeFuncionario.Text = row.Cells[0].Value.ToString();
                txtNcid.Text = row.Cells[1].Value.ToString();
            }
        }

        private void textBoxCidadeFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCidadeFuncionario.Text == null)
            {
                txtNcid.Focus();
            }
            else
            {
                txtNcid.Text = db.GetDescricao("Select cid_nome From cidades where cid_codigo = ", txtcid.Text, txtNcid.Text);
            }
        }

        private void textBoxCidadeFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros(); ;
        }

        private void maskedTextBoxDatacon_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                u.messageboxDataInv();
            }
        }
    }
}
