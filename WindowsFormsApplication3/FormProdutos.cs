using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication3.ClassesEntidades;
//using Produsys;



namespace WindowsFormsApplication3
{
    public partial class FormProdutos : Form
    {
        bool novo;
        public FormProdutos()
        {
            InitializeComponent();
        }

        utils u = new utils();
        Produto produtos = new Produto();
        Cfop cfop = new Cfop();
        DataContext db = new DataContext();
        
        private void Unovo()
        {
            panel1.Visible = false;
            u.limparMTextBoxes(this);
            u.limparTextBoxes(this);
            u.limparCombo(this);
            u.DisableTxt(this);
            u.DisableCombo(this);
            textBoxCodPoduto.Enabled = false;
            btnNovo.Enabled = true;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            textBoxVlVenda.Text = "0,00";
            textBoxMarge.Text = "0,00";
            textBoxEstoque.Text = "0,00";
            textBox1CustoPro.Text = "0,00";
            txtAliqCofins.Text = "0,00";
            txtAliqIcms.Text = "0,00";
            txtAliqIpi.Text = "0,00";
            txtAliqPis.Text = "0,00";
            buttonCancela.Enabled = false;
            


            btnNovo.Focus();
        }
        private void Ualterar()
        {
            
            u.EnableTxt(this);
            u.EnableCombo(this);
            textBoxCodPoduto.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = true;
            buttonCancela.Enabled = true;
        }       

        private Boolean EnableSalvar()
        {

            if (textBoxDescricao.Text == string.Empty)
            {
                return false;
            }
            
            return true;
        }

        private void FormProdutos_Load(object sender, EventArgs e)
        {
            //DllProdusys dll = new DllProdusys();
            //dll.ExcluiIbexpert();
            //string getuser = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "AppData";
            //string completa = getuser + @"\Roaming\HK-Software\IBExpert\ibexpert.dir";
            //File.Delete(completa);           
            this.MaximizeBox = false;            
            Unovo();            
            //u.SelectIndex(this);                       
            btnNovo.Focus();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxVlVenda_Leave(object sender, EventArgs e)
        {
            if (EnableSalvar())
            {
                btnSalvar.Enabled = true;
            }
            btnSalvar.Focus();
        }

        private void textBox1CustoPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void textBoxMarge_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void textBoxVlVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void textBoxVlVenda_Enter(object sender, EventArgs e)
        {
            
            double margem;
            double kusto;            
            if (double.TryParse(textBox1CustoPro.Text, out kusto) && double.TryParse(textBoxMarge.Text, out margem))
            {
                textBoxVlVenda.Text = produtos.calculaVlVenda(Convert.ToDecimal(textBox1CustoPro.Text), Convert.ToDecimal(textBoxMarge.Text)).ToString("N2");                
            }
            else
            {
                textBoxVlVenda.Text = "";
                MessageBox.Show("Algum valor informado é invalido.", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void textBoxDesRed_Enter(object sender, EventArgs e)
        {
            string descrisaun;
            string descrisaunRed;
            descrisaun = textBoxDescricao.Text;
            descrisaunRed = descrisaun;
            textBoxDesRed.Text = descrisaunRed;
        }
        private void FormProdutos_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeusFormularios.FrmProdutos = null;
        }

        private void button1_Click(object sender, EventArgs e)//btn novo
        {
            
            u.EnableCombo(this);
            u.EnableTxt(this);
            textBoxCodPoduto.Enabled = true;
            //u.SelectIndex(this);
            comboOrigem.SelectedIndex = 0;
            comboSituacao.SelectedIndex = 0;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;            
            textBoxVlVenda.Text = "0,00";
            textBoxMarge.Text = "0,00";
            textBoxEstoque.Text = "0,00";
            textBox1CustoPro.Text = "0,00";
            txtAliqCofins.Text = "0,00";
            txtAliqIcms.Text = "0,00";
            txtAliqIpi.Text = "0,00";
            txtAliqPis.Text = "0,00";
            buttonCancela.Enabled = true;
            textBoxDescricao.Focus();
            try
            {
                this.cFOPTableAdapter.Fill(this.dataSet1.CFOP);
            }
            catch (Exception ex)
            {
                u.messageboxErro(ex.ToString());
            }
            //comboCfop.DataSource = dt.Cfops.ToList();
            //comboCfop.ValueMember = Convert.ToString(cfop.ID);
            //comboCfop.DisplayMember = Convert.ToString(cfop.ID);
            novo = true;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (
                textBox1CustoPro.Text == string.Empty ||
                textBoxDescricao.Text == string.Empty ||
                textBoxMarge.Text == string.Empty ||
                textBoxVlVenda.Text == string.Empty ||
                txtCfornecedor.Text == string.Empty)
            {

                txtCfornecedor.BackColor = Color.Gold;
                textBox1CustoPro.BackColor = Color.Gold;
                textBoxDescricao.BackColor = Color.Gold;
                textBoxMarge.BackColor = Color.Gold;
                textBoxVlVenda.BackColor = Color.Gold;
                u.messageboxCamposObrigatorio();
            }
            else
            {
                produtos.CFOP = Convert.ToInt32(comboCfop.Text);
                produtos.CEST = txtCest.Text;
                produtos.NCM = txtNcm.Text;
                //string origem = comboOrigem.SelectedIndex.ToString();
                produtos.OrigemDoProduto = Convert.ToInt32(comboOrigem.SelectedIndex.ToString());
                //int situacao = Convert.ToInt32(comboSituacao.SelectedIndex.ToString());
                produtos.Situacao = Convert.ToInt32(comboSituacao.SelectedIndex.ToString());
                produtos.AliqInter = comboAliqINter.SelectedIndex.ToString();
                produtos.AliqIcms = txtAliqIcms.Text;
                produtos.AliqIpi = txtAliqIpi.Text;
                produtos.AliqPis = txtAliqPis.Text;
                produtos.AliqCofins = txtAliqCofins.Text;
                produtos.CstICMS = comboCstIcms.Text;
                produtos.CstIPI = comboCstIpi.Text;
                produtos.CstPIS = comboCstPis.Text;
                produtos.CstCOFINS = comboCstCofins.Text;

                produtos.ValorVenda = Convert.ToDecimal(textBoxVlVenda.Text);
                produtos.Custo = Convert.ToDecimal(textBox1CustoPro.Text);
                produtos.Margem = Convert.ToDecimal(textBoxMarge.Text);
                produtos.Estoque = Convert.ToDecimal(textBoxEstoque.Text);
                produtos.Descricao = textBoxDescricao.Text;
                produtos.EAN = textBoxBarras.Text;
                produtos.UnidadeMedida = textBoxUnMedida.Text;
                produtos.DescricaoReduzida = textBoxDesRed.Text;
                produtos.FornecedorID = Convert.ToInt32(txtCfornecedor.Text.Trim());


                if (novo)
                {

                    string sql = "insert into produtos(des_produto,ean, cod_fornecedor, est_produto,un_medida,desc_reduzida,vl_produto,custo,margem,cfo_codigo,cest,ncm,origem,situacao,aliqinter,aliqicms,aliqipi,aliqpis,aliqcofins,csticms,cstipi,cstpis,cstcofins) Values(@des_produto,@ean, @cod_fornecedor, @est_produto,@un_medida,@desc_reduzida,@vl_produto,@custo,@margem,@cfo_codigo,@cest,@ncm,@origem,@situacao,@aliqinter,@aliqicms,@aliqipi,@aliqpis,@aliqcofins,@csticms,@cstipi,@cstpis,@cstcofins)";


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = utils.ConexaoDb();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@cfo_codigo",SqlDbType.Int).Value = produtos.CFOP;
                    cmd.Parameters.Add("@cest", SqlDbType.NVarChar).Value = produtos.CEST;
                    cmd.Parameters.Add("@ncm", SqlDbType.NVarChar).Value = produtos.NCM;
                    cmd.Parameters.Add("@origem", SqlDbType.Int).Value = produtos.OrigemDoProduto;
                    cmd.Parameters.Add("@situacao", SqlDbType.Int).Value = produtos.Situacao;
                    cmd.Parameters.Add("@aliqinter", SqlDbType.NVarChar).Value = produtos.AliqInter;
                    cmd.Parameters.Add("@aliqicms", SqlDbType.NVarChar).Value = produtos.AliqIcms;
                    cmd.Parameters.Add("@aliqipi", SqlDbType.NVarChar).Value = produtos.AliqIpi;
                    cmd.Parameters.Add("@aliqpis", SqlDbType.NVarChar).Value = produtos.AliqPis ;
                    cmd.Parameters.Add("@aliqcofins", SqlDbType.NVarChar).Value = produtos.AliqCofins;
                    cmd.Parameters.Add("@csticms", SqlDbType.NVarChar).Value = produtos.CstICMS;
                    cmd.Parameters.Add("@cstipi", SqlDbType.NVarChar).Value = produtos.CstIPI;
                    cmd.Parameters.Add("@cstpis", SqlDbType.NVarChar).Value = produtos.CstPIS;
                    cmd.Parameters.Add("@cstcofins", SqlDbType.NVarChar).Value =produtos.CstCOFINS;
                    cmd.Parameters.Add("@ean", SqlDbType.VarChar).Value = produtos.EAN;
                    cmd.Parameters.Add("@cod_fornecedor", SqlDbType.Int).Value = produtos.FornecedorID;
                    cmd.Parameters.Add("@un_medida", SqlDbType.VarChar).Value = produtos.UnidadeMedida;
                    cmd.Parameters.Add("@desc_reduzida", SqlDbType.VarChar).Value = produtos.UnidadeMedida;
                    cmd.Parameters.Add("@des_produto", SqlDbType.VarChar).Value = produtos.DescricaoReduzida;
                    cmd.Parameters.Add("@est_produto", SqlDbType.Decimal).Value = produtos.Estoque;
                    cmd.Parameters.Add("@vl_produto", SqlDbType.Decimal).Value = produtos.ValorVenda;
                    cmd.Parameters.Add("@custo", SqlDbType.Decimal).Value = produtos.Custo;
                    cmd.Parameters.Add("@margem", SqlDbType.Decimal).Value = produtos.Margem;
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    produtosDataGridView.Refresh();
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
                        u.ApenasNumeros();
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    produtos.ID = Convert.ToInt32(textBoxCodPoduto.Text);
                    string sql = "update produtos set des_produto = @des_produto, cod_fornecedor = @cod_fornecedor, ean = @ean, est_produto = @est_produto, un_medida = @un_medida, vl_produto = @vl_produto, custo = @custo, margem = @margem, cfo_codigo = @cfo_codigo,cest = @cest,ncm = @ncm,origem = @origem,situacao = @situacao,aliqinter = @aliqinter,aliqicms = @aliqicms,aliqipi = @aliqipi,aliqpis = @aliqpis,aliqcofins = @aliqcofins,csticms = @csticms,cstipi = @cstipi,cstpis = @cstpis,cstcofins = @cstcofins where cod_produto = " + produtos.ID;


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = utils.ConexaoDb();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@cfo_codigo", SqlDbType.Int).Value = produtos.CFOP;
                    cmd.Parameters.Add("@cest", SqlDbType.NVarChar).Value = produtos.CEST;
                    cmd.Parameters.Add("@ncm", SqlDbType.NVarChar).Value = produtos.NCM;
                    cmd.Parameters.Add("@origem", SqlDbType.Int).Value = produtos.OrigemDoProduto;
                    cmd.Parameters.Add("@situacao", SqlDbType.Int).Value = produtos.Situacao;
                    cmd.Parameters.Add("@aliqinter", SqlDbType.NVarChar).Value = produtos.AliqInter;
                    cmd.Parameters.Add("@aliqicms", SqlDbType.NVarChar).Value = produtos.AliqIcms;
                    cmd.Parameters.Add("@aliqipi", SqlDbType.NVarChar).Value = produtos.AliqIpi;
                    cmd.Parameters.Add("@aliqpis", SqlDbType.NVarChar).Value = produtos.AliqPis;
                    cmd.Parameters.Add("@aliqcofins", SqlDbType.NVarChar).Value = produtos.AliqCofins;
                    cmd.Parameters.Add("@csticms", SqlDbType.NVarChar).Value = produtos.AliqIcms;
                    cmd.Parameters.Add("@cstipi", SqlDbType.NVarChar).Value = produtos.AliqIpi;
                    cmd.Parameters.Add("@cstpis", SqlDbType.NVarChar).Value = produtos.AliqIcms;
                    cmd.Parameters.Add("@cstcofins", SqlDbType.NVarChar).Value = produtos.CstCOFINS;
                    cmd.Parameters.Add("@ean", SqlDbType.VarChar).Value = produtos.EAN;
                    cmd.Parameters.Add("@cod_fornecedor", SqlDbType.Int).Value = produtos.FornecedorID;
                    cmd.Parameters.Add("@un_medida", SqlDbType.VarChar).Value = produtos.UnidadeMedida;
                    cmd.Parameters.Add("@desc_reduzida", SqlDbType.VarChar).Value = produtos.DescricaoReduzida;
                    cmd.Parameters.Add("@des_produto", SqlDbType.VarChar).Value = produtos.Descricao;
                    cmd.Parameters.Add("@est_produto", SqlDbType.Decimal).Value = produtos.Estoque;
                    cmd.Parameters.Add("@vl_produto", SqlDbType.Decimal).Value = produtos.ValorVenda;
                    cmd.Parameters.Add("@custo", SqlDbType.Decimal).Value = produtos.Custo;
                    cmd.Parameters.Add("@margem", SqlDbType.Decimal).Value = produtos.Margem;
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
                Unovo();
                txtCfornecedor.BackColor = SystemColors.Window;
                textBox1CustoPro.BackColor = SystemColors.Window;
                textBoxDescricao.BackColor = SystemColors.Window;
                textBoxMarge.BackColor = SystemColors.Window;
                textBoxVlVenda.BackColor = SystemColors.Window;
               
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Você realmente deseja excluir esse registro?", "Mensagem do Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (escolha == DialogResult.Cancel)
            {
         
            }
            else
            {
                string excrui = "delete from produtos where cod_produto = " + textBoxCodPoduto.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = utils.ConexaoDb();
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
                    con.Close();
                }
                Unovo();
                btnNovo.Focus();
                
            }
        }

        private void buttonCancela_Click(object sender, EventArgs e)
        {
            Unovo();
            btnNovo.Focus();          
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            panelPesquisa.Visible = true;
            novo = false;
        }

        private void btnSaiPesquisa_Click(object sender, EventArgs e)
        {
            panelPesquisa.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaProdutos());
            if (radioButtonBarras.Checked)
            {
                dv.RowFilter = "ean like '" + textBox1.Text + "%'";
            }
            if (radioButtonCodigo.Checked)
            {
                dv.RowFilter = "cod_produto = " + textBox1.Text;
            }
            if (radioButtonDescricao.Checked)
            {
                dv.RowFilter = "des_produto like '%" + textBox1.Text + "%'";
            }
            produtosDataGridView.DataSource = dv;
            
        }

        private void produtosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panelPesquisa.Visible = false;
            if (e.RowIndex >= 0)
            {
                //cfo_codigo,cest,ncm,origem,situacao,aliqinter,aliqicms,aliqipi,aliqpis,aliqcofins,csticms,cstipi,cstpis,cstcofins
                DataGridViewRow row = this.produtosDataGridView.Rows[e.RowIndex];
                textBoxCodPoduto.Text = row.Cells[0].Value.ToString();
                textBoxDescricao.Text = row.Cells[1].Value.ToString();
                textBoxBarras.Text = row.Cells[2].Value.ToString();
                txtCfornecedor.Text = row.Cells[3].Value.ToString();
                textBoxEstoque.Text = row.Cells[4].Value.ToString();
                textBoxUnMedida.Text = row.Cells[5].Value.ToString();
                textBoxDesRed.Text = row.Cells[6].Value.ToString();
                textBoxVlVenda.Text = row.Cells[7].Value.ToString();
                textBox1CustoPro.Text = row.Cells[8].Value.ToString();
                textBoxMarge.Text = row.Cells[9].Value.ToString();
                comboCfop.Text = row.Cells[10].Value.ToString();
                txtCest.Text = row.Cells[11].Value.ToString();
                txtNcm.Text = row.Cells[12].Value.ToString();
                comboOrigem.SelectedIndex = Convert.ToInt32(row.Cells[22].Value.ToString());
                comboSituacao.SelectedIndex = Convert.ToInt32(row.Cells[23].Value.ToString());
                comboAliqINter.Text = row.Cells[17].Value.ToString();
                txtAliqIcms.Text = row.Cells[18].Value.ToString();
                txtAliqIpi.Text = row.Cells[19].Value.ToString();
                txtAliqPis.Text = row.Cells[20].Value.ToString();
                txtAliqCofins.Text = row.Cells[21].Value.ToString();
                comboCstIcms.Text = row.Cells[13].Value.ToString();
                comboCstIpi.Text = row.Cells[14].Value.ToString();
                comboCstPis.Text = row.Cells[15].Value.ToString();
                comboCstCofins.Text = row.Cells[16].Value.ToString();
                
                Ualterar();
                textBoxDescricao.Focus();
            }
        }

        private void btnBforn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaFornecedores());
            if (radioButtonCodigo.Checked)
            {
                dv.RowFilter = "cod_fornecedor =" + txtCfornecedor.Text;
            }
            if (radioButtonFantasia.Checked)
            {
                dv.RowFilter = "fantasia like'%" + txtCfornecedor.Text + "%'";
            }
            if (radioButtonrRazao.Checked)
            {
                dv.RowFilter = "razão like '%" + txtCfornecedor.Text + "%'";
            }
            fornecedoresDataGridView.DataSource = dv;
            
        }

        private void fornecedoresDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = false;

            DataGridViewRow row = this.fornecedoresDataGridView.Rows[e.RowIndex];
            txtCfornecedor.Text = row.Cells[0].Value.ToString();
            txtNfornecedor.Text = row.Cells[1].Value.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButtonCodigo.Checked)
            {
                u.ApenasNumeros();
            }

        }

        private void txtCfornecedor_TextChanged(object sender, EventArgs e)
        {
            if (txtCfornecedor.Text == null)
            {
                txtNfornecedor.Focus();
            }
            else
            {
                txtNfornecedor.Text = db.GetDescricao("Select fantasia From fornecedores where cod_fornecedor = ", txtCfornecedor.Text, txtNfornecedor.Text);
            }
        }

        private void txtCfornecedor_TextChanged_1(object sender, EventArgs e)
        {
            if (txtCfornecedor.Text == null)
            {
                txtNfornecedor.Focus();

            }
            else
            {
                txtNfornecedor.Text = db.GetDescricao("Select fantasia From fornecedores where cod_fornecedor = ", txtCfornecedor.Text, txtNfornecedor.Text);
            }
        }

        private void txtCfornecedor_Leave(object sender, EventArgs e)
        {
            if (txtCfornecedor.Text == null)
            {
                txtNfornecedor.Focus();

            }
            else
            {
                txtNfornecedor.Text = db.GetDescricao("Select fantasia From fornecedores where cod_fornecedor = ", txtCfornecedor.Text, txtNfornecedor.Text);
            }
            if (EnableSalvar())
            {
                btnSalvar.Enabled = true;
            }
        }

        private void textBox1CustoPro_Leave(object sender, EventArgs e)
        {
            if (EnableSalvar())
            {
                btnSalvar.Enabled = true;
            }
        }

        private void textBoxMarge_Leave(object sender, EventArgs e)
        {
            if (EnableSalvar())
            {
                btnSalvar.Enabled = true;
            }
        }

        private void textBoxDescricao_Leave(object sender, EventArgs e)
        {
            if (EnableSalvar())
            {
                btnSalvar.Enabled = true;
            }

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //this.produtosTableAdapter1.FillBy(this.dataSet1.produtos);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    
    }
}
    



