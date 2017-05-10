using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication3.ClassesEntidades;

namespace WindowsFormsApplication3
{
    public partial class FormClientes : Form
    {
        bool novo;
        public FormClientes()
        {
            InitializeComponent();
        }
        utils u = new utils();
        Cliente cliente = new Cliente();
        Cidade cidad = new Cidade();
        DataContext db = new DataContext();                         

        private void FormClientes_Load(object sender, EventArgs e)
        {
            u.limparTextBoxes(this);
            u.limparMTextBoxes(this);
            textBoxCodCliente.Enabled = false;
            btnPcidade.Enabled = false;
            txtCodCid.Enabled = false;
            textBoxNumero.Enabled = false;
            textBoxBairroCliente.Enabled = false;
            textBoxCidadeCliente.Enabled = false;
            textBoxEmailCliente.Enabled = false;
            textBoxEndereco.Enabled = false;
            textBoxNomeCliente.Enabled = false;
            textBoxObs.Enabled = false;
            maskedTextBoxCel.Enabled = false;
            maskedTextBoxCepCliente.Enabled = false;
            maskedTextBoxCpf.Enabled = false;
            maskedTextBoxDatanas.Enabled = false;
            maskedTextBoxTelefoneCliente.Enabled = false;
            btnNovo.Enabled = true;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            buttonCancelaCadcliente.Enabled = false;
            btnNovo.Focus();
            this.MaximizeBox = false;            
            panelCid.Visible = false;
            rbNomeC.Checked = true;

        }

        private void buttonSaiAtendimento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxObs_Leave(object sender, EventArgs e)
        {
            btnSalvar.Focus();
        }

        private void FormClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeusFormularios.FrmClientes = null;
        }

        private void btnSaiPesquisa_Click(object sender, EventArgs e)
        {
            panelPesquisaClientes.Visible = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            u.limparTextBoxes(this);
            u.limparMTextBoxes(this);
            textBoxNumero.Enabled = true;
            btnPcidade.Enabled = true;
            txtCodCid.Enabled = true;
            textBoxBairroCliente.Enabled = true;
            textBoxCidadeCliente.Enabled = true;
            textBoxEmailCliente.Enabled = true;
            textBoxEndereco.Enabled = true;
            textBoxNomeCliente.Enabled = true;
            textBoxObs.Enabled = true;
            maskedTextBoxCel.Enabled = true;
            maskedTextBoxCepCliente.Enabled = true;
            maskedTextBoxCpf.Enabled = true;
            maskedTextBoxDatanas.Enabled = true;
            maskedTextBoxTelefoneCliente.Enabled = true;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            buttonCancelaCadcliente.Enabled = true;
            textBoxNomeCliente.Focus();
            novo = true;

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            cliente.ID = Convert.ToInt32(textBoxCodCliente.Text);

            DialogResult escolha = MessageBox.Show("Deseja realmente excluir esse registro ?", "Mensagem do Sitema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (escolha == DialogResult.Cancel)
            {
                u.limparTextBoxes(this);
                u.limparMTextBoxes(this);
                u.DisableTxt(this);
                u.DisableMasked(this);             
                btnPcidade.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = false;
                buttonCancelaCadcliente.Enabled = false;
                btnNovo.Enabled = true;
                btnNovo.Enabled = true;
                btnNovo.Focus();
             
            }
            else
            {
                string sql = "DELETE FROM CLIENTES WHERE cod_cliente =" + cliente.ID;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.Ducaun;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                clientesDataGridView.Refresh();

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
            u.limparMTextBoxes(this);
            u.limparTextBoxes(this);
            btnNovo.Enabled = true;
            textBoxCodCliente.Enabled = false;
            btnPcidade.Enabled = false;
            txtCodCid.Enabled = false;
            textBoxNumero.Enabled = false;
            textBoxBairroCliente.Enabled = false;
            textBoxCidadeCliente.Enabled = false;
            textBoxEmailCliente.Enabled = false;
            textBoxEndereco.Enabled = false;
            textBoxNomeCliente.Enabled = false;
            textBoxObs.Enabled = false;
            maskedTextBoxCel.Enabled = false;
            maskedTextBoxCepCliente.Enabled = false;
            maskedTextBoxCpf.Enabled = false;
            maskedTextBoxDatanas.Enabled = false;
            maskedTextBoxTelefoneCliente.Enabled = false;
            btnNovo.Enabled = true;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            buttonCancelaCadcliente.Enabled = false;
            btnNovo.Focus();
        }
        private void btnChamaPesquisa_Click(object sender, EventArgs e)
        {
            novo = false;
            panelPesquisaClientes.Visible = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCodCid.Text == string.Empty || textBoxNomeCliente.Text == string.Empty)
            {
                txtCodCid.BackColor = Color.Gold;
                textBoxNomeCliente.BackColor = Color.Gold;
                u.messageboxCamposObrigatorio();
            }
            else
            {                
                cliente.Razao = textBoxNomeCliente.Text;
                cliente.Endereco = textBoxEndereco.Text;
                cliente.Bairro = textBoxBairroCliente.Text;
                cliente.CidadeCodigo = Convert.ToInt32(txtCodCid.Text);
                cliente.Telefone = maskedTextBoxTelefoneCliente.Text;
                cliente.Celular = maskedTextBoxCel.Text;
                cliente.Cep = maskedTextBoxCepCliente.Text;
                cliente.Observacoes = textBoxObs.Text;
                cliente.Cpf = maskedTextBoxCpf.Text;
                cliente.Email = textBoxEmailCliente.Text;
                cliente.DataNascimento = maskedTextBoxDatanas.Text;
                cliente.Numero = textBoxNumero.Text;
                if (novo) //novo 
                {
                    string sql = "INSERT INTO CLIENTEs(n_cliente,endereco,bairro,cidade,telefone,celular,cep,obs,cpf,email,data_nas,numero) " +
                        "VALUES('" + cliente.Razao + "', '"
                        + cliente.Endereco + "', '"
                        + cliente.Bairro + "', '"
                        + cliente.CidadeCodigo + "', '"
                        + cliente.Telefone + "', '"
                        + cliente.Celular + "', '"
                        + cliente.Cep + "' , '"
                        + cliente.Observacoes + "' , '"
                        + cliente.Cpf + "' , '"
                        + cliente.Email + "' , '"
                        + cliente.DataNascimento + "' , '"
                        + cliente.Numero + "')";

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Properties.Settings.Default.Ducaun;
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    clientesDataGridView.Refresh();
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
                else //altera saporra
                {
                    cliente.ID = Convert.ToInt32(textBoxCodCliente.Text);
                    string sql = "UPDATE CLIENTEs SET n_cliente ='" + cliente.Razao +
                        "', ENDERECO = '" + cliente.Endereco +
                        "', bairro = '" + cliente.Bairro +
                        "', cidade = '" + cliente.CidadeCodigo +
                        "', telefone = '" + cliente.Telefone +
                        "', celular = '" + cliente.Celular +
                        "', cep = '" + cliente.Cep +
                        "', obs = '" + cliente.Observacoes +
                        "', cpf = '" + cliente.Cpf +
                        "', email = '" + cliente.Email +
                        "', data_nas = '" + cliente.DataNascimento +
                        "', numero = '" + cliente.Numero + "' where cod_cliente = '" + cliente.ID + "'";

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Properties.Settings.Default.Ducaun;
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    clientesDataGridView.Refresh();
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
                u.limparMTextBoxes(this);
                u.limparTextBoxes(this);
                clientesDataGridView.Refresh();
                txtCodCid.Clear();
                textBoxCodCliente.Enabled = false;
                btnPcidade.Enabled = false;
                txtCodCid.Enabled = false;
                textBoxNumero.Enabled = false;
                textBoxBairroCliente.Enabled = false;
                textBoxCidadeCliente.Enabled = false;
                textBoxEmailCliente.Enabled = false;
                textBoxEndereco.Enabled = false;
                textBoxNomeCliente.Enabled = false;
                textBoxObs.Enabled = false;
                maskedTextBoxCel.Enabled = false;
                maskedTextBoxCepCliente.Enabled = false;
                maskedTextBoxCpf.Enabled = false;
                maskedTextBoxDatanas.Enabled = false;
                maskedTextBoxTelefoneCliente.Enabled = false;
                btnNovo.Enabled = true;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = false;
                buttonCancelaCadcliente.Enabled = false;
                btnNovo.Focus();
                txtCodCid.BackColor = SystemColors.Window;
                textBoxNomeCliente.BackColor = SystemColors.Window;
            }
        }

        private void btnSaiPesquisa_Click_1(object sender, EventArgs e)
        {
            panelPesquisaClientes.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            DataView dv = new DataView(DataContext.CarregaClientes());
            if (radioButtonCodigo.Checked)
            {
                dv.RowFilter = "cod_cliente =" + textBox1.Text;
            }
            if (radioButtonDescricao.Checked)
            {
                dv.RowFilter = "n_cliente like'%" + textBox1.Text + "%'";
            }
            clientesDataGridView.DataSource = dv;         
        }

        private void clientesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            panelPesquisaClientes.Visible = false;
        }

        private void clientesDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panelPesquisaClientes.Visible = false;
                DataGridViewRow row = this.clientesDataGridView.Rows[e.RowIndex];
                textBoxCodCliente.Text = row.Cells[0].Value.ToString();
                textBoxNomeCliente.Text = row.Cells[1].Value.ToString();
                textBoxEndereco.Text = row.Cells[2].Value.ToString();
                textBoxBairroCliente.Text = row.Cells[3].Value.ToString();
                txtCodCid.Text = row.Cells[4].Value.ToString();
                maskedTextBoxTelefoneCliente.Text = row.Cells[5].Value.ToString();
                maskedTextBoxCel.Text = row.Cells[6].Value.ToString();
                maskedTextBoxCepCliente.Text = row.Cells[7].Value.ToString();
                textBoxObs.Text = row.Cells[8].Value.ToString();
                maskedTextBoxCpf.Text = row.Cells[9].Value.ToString();
                textBoxEmailCliente.Text = row.Cells[10].Value.ToString();
                maskedTextBoxDatanas.Text = row.Cells[11].Value.ToString();
                textBoxNumero.Text = row.Cells[12].Value.ToString();
                textBoxNumero.Enabled = true;
                txtCodCid.Enabled = true;
                textBoxBairroCliente.Enabled = true;
                textBoxCidadeCliente.Enabled = true;
                textBoxEmailCliente.Enabled = true;
                textBoxEndereco.Enabled = true;
                textBoxNomeCliente.Enabled = true;
                textBoxObs.Enabled = true;
                maskedTextBoxCel.Enabled = true;
                maskedTextBoxCepCliente.Enabled = true;
                maskedTextBoxCpf.Enabled = true;
                maskedTextBoxDatanas.Enabled = true;
                maskedTextBoxTelefoneCliente.Enabled = true;
                btnNovo.Enabled = false;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = true;
                buttonCancelaCadcliente.Enabled = true;
                btnPcidade.Enabled = true;
                textBoxNomeCliente.Focus();
            }
        }

        private void buttonCancelaCadcliente_Click(object sender, EventArgs e)
        {
            u.limparMTextBoxes(this);
            u.limparTextBoxes(this);
            txtCodCid.Enabled = false;
            textBoxCodCliente.Enabled = false;
            textBoxNumero.Enabled = false;
            textBoxBairroCliente.Enabled = false;
            textBoxCidadeCliente.Enabled = false;
            textBoxEmailCliente.Enabled = false;
            textBoxEndereco.Enabled = false;
            textBoxNomeCliente.Enabled = false;
            textBoxObs.Enabled = false;
            maskedTextBoxCel.Enabled = false;
            maskedTextBoxCepCliente.Enabled = false;
            maskedTextBoxCpf.Enabled = false;
            maskedTextBoxDatanas.Enabled = false;
            maskedTextBoxTelefoneCliente.Enabled = false;
            btnNovo.Enabled = true;
            btnExcluir.Enabled = false;
            btnPcidade.Enabled = false; 
            btnSalvar.Enabled = false;
            buttonCancelaCadcliente.Enabled = false;
            u.limparTextBoxes(this);
            u.limparMTextBoxes(this);
            btnNovo.Focus();
            this.MaximizeBox = false;    
            clientesDataGridView.Refresh();
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
            u.ApenasNumeros();
        }

        private void maskedTextBoxCpf_Leave(object sender, EventArgs e)
        {
            try
            {
                string valor = maskedTextBoxCpf.Text;
                if (ValidaCPF.ValidaCPF.Valida(valor))
                {
                    textBoxBairroCliente.Focus();
                }
            }
            catch(Exception ex)
            {
                u.messageboxErro(ex.ToString());
            }
            finally
            {
                textBoxBairroCliente.Focus();
            }
        }

        private void maskedTextBoxCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void FormClientes_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            MeusFormularios.FrmClientes = null;
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtCodCid.Text == null)
            {
                textBoxCidadeCliente.Focus();
            }
            else
            {
                txtcid.Text = db.GetDescricao("Select cid_nome From cidades where cid_codigo = ", txtCodCid.Text, txtcid.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panelCid.Visible = false;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtCodCid.Text = row.Cells[0].Value.ToString();
                textBoxCidadeCliente.Text = row.Cells[1].Value.ToString();
            }
        }

        private void maskedTextBoxDatanas_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                u.messageboxDataInv();
            }
        }
    
    }
}


