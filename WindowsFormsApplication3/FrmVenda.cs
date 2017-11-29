using Aplicativo.ClassesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using static Aplicativo.DataContextFirebird;

namespace Aplicativo
{
    public partial class FrmVenda : Form
    {
        public FrmVenda()
        {
            InitializeComponent();
        }
        bool novo;
        decimal kuantidade;
        decimal valProduto;
        decimal valUnitario;
        decimal desconto;
        int cfopNumero;
        Estoque estoque = new Estoque();
        utils u = new utils();
        Pedido pedido = new Pedido();
        PedidoProduto pedidoProduto = new PedidoProduto();
        DataContext db = new DataContext();

        private void button1_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaFuncionarios());
            if (radioButton2.Checked)
            {
                dv.RowFilter = "cod_funcionario = " + txtpfunc.Text;
            }
            if (radioButton1.Checked)
            {
                dv.RowFilter = "n_funcionario like '%" + txtpfunc.Text + "%'";
            }
            funcionariosDataGridView.DataSource = dv;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaClientes());
            if (radioButtonCodigo.Checked)
            {
                dv.RowFilter = "cod_cliente =" + txtpcli.Text;
            }
            if (radioButtonDescricao.Checked)
            {
                dv.RowFilter = "n_cliente like'%" + txtpcli.Text + "%'";
            }
            clientesDataGridView.DataSource = dv;
        }

        private void btnSaiPesquisa_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void btnPCliente_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count < 6)
            {
                this.tabControl1.TabPages.Add(tabPage2);
                tabControl1.SelectedTab = tabPage2;
            }
        }

        private void btnPvendedor_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count < 6)
            {
                this.tabControl1.TabPages.Add(tabPage5);
                tabControl1.SelectedTab = tabPage5;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaProdutos());
            if (radioButtonBarras.Checked)
            {
                dv.RowFilter = "ean like '%" + textBox1.Text + "%'";
            }
            if (radioButton4.Checked)
            {
                dv.RowFilter = "cod_produto = " + textBox1.Text;
            }
            if (radioButton3.Checked)
            {
                dv.RowFilter = "des_produto like '%" + textBox1.Text + "%'";
            }
            produtosDataGridView.DataSource = dv;
        }

        private void btnPProduto_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count < 6)
            {
                this.tabControl1.TabPages.Add(tabPage3);
                tabControl1.SelectedTab = tabPage3;
            }
        }

        private void clientesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                tabControl1.TabPages.Remove(tabPage2);
                DataGridViewRow row = this.clientesDataGridView.Rows[e.RowIndex];
                txtcodCliente.Text = row.Cells[0].Value.ToString();
                txtNomeCliente.Text = row.Cells[1].Value.ToString();
            }
        }

        private void funcionariosDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tabControl1.TabPages.Remove(tabPage5);
                DataGridViewRow row = this.funcionariosDataGridView.Rows[e.RowIndex];
                txtcodVendedor.Text = row.Cells[0].Value.ToString();
                txtNomeVendedor.Text = row.Cells[1].Value.ToString();
            }
        }

        private void produtosDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.produtosDataGridView.Rows[e.RowIndex];
                txtCodProduto.Text = row.Cells[0].Value.ToString();
                txtNomeProduto.Text = row.Cells[1].Value.ToString();
                txtValor.Text = row.Cells[4].Value.ToString();
            }
            txtQuantidade.Focus();
            txtQuantidade.Text = "1,00";
        }

        private void btnInsProduto_Click(object sender, EventArgs e)
        {
            pedidoProduto.Quantidade = Convert.ToDecimal(txtQuantidade.Text.Trim());
            pedidoProduto.ValorTotal = Convert.ToDecimal(txtVTotal.Text.Trim());
            pedidoProduto.ValorUnitario = Convert.ToDecimal(txtValor.Text.Trim());
            pedidoProduto.ProdutoID = Convert.ToInt32(txtCodProduto.Text.Trim());
            pedidoProduto.PedidoID = Convert.ToInt32(txtControle.Text.Trim());

            string insProduto = " insert into itempedido(ped_codigo, cod_produto, itp_valor, itp_qtde, itp_total)" +
                "values(@ped_codigo, @cod_produto, @itp_valor, @itp_qtde, @ipt_total)";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand cmd = new SqlCommand(insProduto, con);
            cmd.Parameters.Add("@ped_codigo", SqlDbType.Int).Value = pedidoProduto.PedidoID;
            cmd.Parameters.Add("@cod_produto", SqlDbType.Int).Value = pedidoProduto.ProdutoID;
            cmd.Parameters.Add("@itp_valor", SqlDbType.Decimal).Value = pedidoProduto.ValorUnitario;
            cmd.Parameters.Add("@itp_qtde", SqlDbType.Decimal).Value = pedidoProduto.Quantidade;
            cmd.Parameters.Add("@ipt_total", SqlDbType.Decimal).Value = pedidoProduto.ValorTotal;
            cmd.CommandType = CommandType.Text;
            estoque.ProdutoID = Convert.ToInt32(produtosDataGridView.CurrentRow.Cells["cod_produto"].Value.ToString());
            string estoques = "insert into estoque(est_qtde,ven_codigo, est_data, pro_codigo) values(@est_qtde, @ven_codigo, @est_data, @pro_codigo)";
            SqlCommand cmd2 = new SqlCommand(estoques, con);
            cmd2.Parameters.Add("@est_qtde", SqlDbType.Decimal).Value = pedidoProduto.Quantidade * -1;
            cmd2.Parameters.Add("@ven_codigo", SqlDbType.Int).Value = pedidoProduto.PedidoID;
            cmd2.Parameters.Add("@est_data", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
            cmd2.Parameters.Add("@pro_codigo", SqlDbType.Int).Value = estoque.ProdutoID;
            con.Open();
            try
            {
                if (dataGridView1.Rows.Cast<DataGridViewRow>().Any(row => row.Cells[0].Value.Equals(txtCodProduto.Text.Trim())))
                {
                    MessageBox.Show("Erro: Produto já inserido ", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int i = cmd.ExecuteNonQuery();
                    int j = cmd2.ExecuteNonQuery();

                    if ((i > 0) && (j > 0))
                    {
                        //dataGridView1.Rows.Add(txtCodProduto.Text, txtNomeProduto.Text, txtQuantidade.Text, txtValor.Text, txtDesconto.Text, txtVTotal.Text);
                        //dar refresh no grid
                        CarregaProdutos();
                        txtVTotal.Text = "";
                        txtValor.Text = "";
                        txtQuantidade.Text = "";
                        txtNomeProduto.Text = "";
                        txtCodProduto.Text = "";
                        btnInsProduto.Enabled = false;
                    }
                }
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo = true;
            pedido.DataEmissao = Convert.ToString(mskDtVenda.Text);
            string nova = "insert into pedido(ped_dtemissao) values(@ped_dtemissao)";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand cmd = new SqlCommand(nova, con);
            cmd.Parameters.Add("@ped_dtemissao", SqlDbType.VarChar).Value = pedido.DataEmissao;
            cmd.CommandType = CommandType.Text;            
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    mskDtVenda.Focus();

            }
            catch (Exception ex)
            {
                u.messageboxErro(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            Uenable();          
            
        }

        private Boolean enableSalvar()
        {
            if (txtcodCliente.Text == string.Empty)
            {
                return false;
            }
            else if (txtcodVendedor.Text == string.Empty)
            {
                return false;
            }

            else if (txtSomaDesconto.Text == string.Empty)
            {
                return false;

            }
            else if (txtsomaTudo.Text == string.Empty)
            {
                return false;
            }
            else if (maskedTextBox1.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            //reportViewer1.Visible = false;
            //button8.Visible = false;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            novo = true;
            Unovo();
            
            mskDtVenda.Enabled = true;
            mskDtVenda.Text = DateTime.Now.ToString();
            txtSomaDesconto.Text = "0,00";
            txtDesconto.Text = "0,00";
        }
        private void Unovo()
        {
            u.limparCombo(this);
            u.limparMTextBoxes(this);
            u.limparTextBoxes(this);
            u.DisableCombo(this);
            u.DisableTxt(this);
            u.DisableMasked(this);
            u.DisableDataGrid(this);
            btnNovo.Enabled = true;
            btnSair.Enabled = true;
            btnSalvar.Enabled = false;
            btnInsProduto.Enabled = false;
            btnPProduto.Enabled = false;
            dataGridView1.Rows.Clear();
        }
        private void Uenable()
        {
            u.EnableCombo(this);
            u.EnableTxt(this);
            u.EnableMasked(this);            
            btnNovo.Enabled = false;
            btnSair.Enabled = true;
            btnSalvar.Enabled = false;
            btnInsProduto.Enabled = true;
            btnPProduto.Enabled = true;            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Voce deseja realmente excluir esse registro ?", "Mensagem do Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (escolha == DialogResult.Cancel)
            {
                //blabla bla
            }
            else
            {
                string delete = "delete from pedido where ped_codigo = " + txtControle.Text;
                string deleteItem = "delete from ITEMPEDIDO where ped_codigo = " + txtControle.Text;
                string deleteEstoque = "delete from estoque where ven_codigo = " + txtControle.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = utils.ConexaoDb();
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.CommandType = CommandType.Text;
                SqlCommand cmd1 = new SqlCommand(deleteItem, con);
                cmd1.CommandType = CommandType.Text;
                SqlCommand cmd2 = new SqlCommand(deleteEstoque, con);
                cmd2.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    int j = cmd1.ExecuteNonQuery();
                    int k = cmd2.ExecuteNonQuery();
                    if ((i > 0) || (j > 0) || (k > 0))
                    {
                        u.messageboxSucesso();
                    }
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
        }

        private void buttonCancela_Click(object sender, EventArgs e)
        {
            Unovo();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVenda_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeusFormularios.Formvenda = null;
        }

        private Boolean validaCalculo()
        {

            if (txtVTotal.Text == string.Empty)
            {
                return false;
            }
            else if (txtCodProduto.Text == string.Empty)
            {
                return false;
            }
            else if (txtDesconto.Text == string.Empty)
            {
                return false;
            }
            else if (txtValor.Text == string.Empty)
            {
                return false;
            }
            else if (txtQuantidade.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        private void mskDtVenda_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            //decimal valorTotal = 0;

            //foreach (DataGridViewRow col in dataGridView1.Rows)
            //{
            //    valorTotal = valorTotal + Convert.ToDecimal(col.Cells[5].Value);
            //}

            //txtsomaTudo.Text = Convert.ToString(valorTotal);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCdesconto.Text == string.Empty ||
               txtcodCliente.Text == string.Empty ||
               //txtCodProduto.Text == string.Empty ||
               //txtDesconto.Text == string.Empty ||
               txtSomaDesconto.Text == string.Empty ||
               txtsomaTudo.Text == string.Empty ||
               mskDtVenda.Text == string.Empty ||
               maskedTextBox1.Text == string.Empty)
            {
                txtCdesconto.BackColor = Color.Gold;
                txtcodCliente.BackColor = Color.Gold;
                //txtCodProduto.BackColor = Color.Gold;
                //txtDesconto.BackColor = Color.Gold;
                txtSomaDesconto.BackColor = Color.Gold;
                txtsomaTudo.BackColor = Color.Gold;
                mskDtVenda.BackColor = Color.Gold;
                maskedTextBox1.BackColor = Color.Gold;
                u.messageboxCamposObrigatorio();
            }
            else
            {
                if (txtSomaDesconto.Text == string.Empty)
                {
                    txtSomaDesconto.Text = "0,00";
                }
                int codvenda = Convert.ToInt32(txtControle.Text.Trim());
                decimal pedtotalliq = Convert.ToDecimal(txtCdesconto.Text.Trim());
                int codfuncionatio = Convert.ToInt32(txtcodVendedor.Text.Trim());
                int codcliente = Convert.ToInt32(txtcodCliente.Text.Trim());
                desconto = Convert.ToDecimal(txtSomaDesconto.Text.Trim());
                string peddtEmissao = mskDtVenda.Text.Trim();
                string dtVenc = maskedTextBox1.Text.Trim();

                string pedobs = txtObs.Text;

                string atualiza = "update pedido set ped_totalliq = @ped_totalliq, cod_funcionario = @cod_funcionario, cod_cliente = @cod_cliente, ped_obs = @ped_obs, ped_desconto = @ped_desconto where ped_codigo = " + txtControle.Text;
                string financeiro = "insert into creceber(rec_valor, rec_dtvenc, cod_cliente, rec_situacao ) values(@ped_totalliq, @rec_dtvenc, @cod_cliente, 'PENDENTE')";

                SqlConnection con = new SqlConnection();
                con.ConnectionString = utils.ConexaoDb();
                SqlCommand cmd = new SqlCommand(atualiza, con);
                cmd.Parameters.Add("@ped_totalliq", SqlDbType.Decimal).Value = pedtotalliq;
                cmd.Parameters.Add("@cod_funcionario", SqlDbType.Int).Value = codfuncionatio;
                cmd.Parameters.Add("@cod_cliente", SqlDbType.Int).Value = codcliente;
                cmd.Parameters.Add("@ped_obs", SqlDbType.VarChar).Value = pedobs;
                cmd.Parameters.Add("@ped_desconto", SqlDbType.Decimal).Value = desconto;
                cmd.Parameters.Add("@ped_dtemissao", SqlDbType.NVarChar).Value = peddtEmissao;

                SqlCommand cmd1 = new SqlCommand(financeiro, con);
                cmd1.Parameters.Add("@ped_totalliq", SqlDbType.Decimal).Value = pedtotalliq;
                cmd1.Parameters.Add("@cod_cliente", SqlDbType.Int).Value = codcliente;
                cmd1.Parameters.Add("@rec_dtvenc", SqlDbType.NVarChar).Value = dtVenc;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    int j = cmd1.ExecuteNonQuery();

                    if ((i > 0) || (j > 0))
                    {
                        u.messageboxSucesso();
                        try
                        {
                            //this.dataTable1TableAdapter1.FillByimprimeobagui(this.jarbasDataSet.DataTable1, Convert.ToInt32(txtControle.Text)/*((int)(System.Convert.ChangeType(pedidoCodigoToolStripTextBox.Text, typeof(int))))*/);
                        }
                        catch (Exception ex)
                        {
                            u.messageboxErro(ex.ToString());
                        }

                        //reportViewer1.Visible = true;
                        //reportViewer1.Show();
                        //this.reportViewer1.RefreshReport();
                        //reportViewer1.Visible = true;
                        //button8.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    u.messageboxErro(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
                txtCdesconto.BackColor = SystemColors.Window;
                txtcodCliente.BackColor = SystemColors.Window;
                txtCodProduto.BackColor = SystemColors.Window;
                txtDesconto.BackColor = SystemColors.Window;
                txtSomaDesconto.BackColor = SystemColors.Window;
                txtsomaTudo.BackColor = SystemColors.Window;
                mskDtVenda.BackColor = SystemColors.Window;
                maskedTextBox1.BackColor = SystemColors.Window;
                dataGridView1.Refresh();
                Unovo();
            }
        }

        private void txtCdesconto_Enter(object sender, EventArgs e)
        {
            decimal totSemDesconto = Convert.ToDecimal(txtsomaTudo.Text.Trim());
            desconto = Convert.ToDecimal(txtSomaDesconto.Text.Trim());
            decimal totalComDesconto = totSemDesconto - desconto;
            txtCdesconto.Text = Convert.ToString(totalComDesconto);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (txtControle.Text != string.Empty || txtControle.Text == null)
            {

                estoque.VendaProdutoID = Convert.ToInt32(txtControle.Text.Trim());

                estoque.ProdutoID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["cod_produto"].Value.ToString());
                string deleteEstoque = "delete from estoque where pro_codigo = " + estoque.ProdutoID + "and ven_codigo = " + estoque.VendaProdutoID;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = utils.ConexaoDb();
                SqlCommand cmd = new SqlCommand(deleteEstoque, con);
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
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void mskDtVenda_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                u.messageboxDataInv();
            }
        }

        private void txtcodCliente_Leave(object sender, EventArgs e)
        {

        }

        private void txtControle_Leave(object sender, EventArgs e)
        {
            if (enableSalvar())
            {
                btnSalvar.Enabled = true;
            }
        }

        private void txtcodVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }
        private void CarregaProdutos()
        {
            string select = "select a.cod_produto, b.des_produto, a.ITP_QTDE, a.ITP_VALOR, a.ITP_TOTAL from ITEMPEDIDO "
                           + " a join produtos b on a.cod_produto = b.cod_produto where ped_codigo = " + txtControle.Text;



            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            con.Open();
            SqlCommand Cmm = new SqlCommand();
            Cmm.CommandText = select;
            Cmm.CommandType = CommandType.Text;
            Cmm.Connection = con;
            SqlDataReader DR;
            DR = Cmm.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR);
            con.Close();
            DataView dv = new DataView(DT);
            dataGridView1.DataSource = dv;
            dataGridView1.Columns[0].HeaderText = "CONTROLE";
            dataGridView1.Columns[0].Width = 95;
            dataGridView1.Columns[1].HeaderText = "DESCRIÇÃO";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "QUANTIDADE";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].HeaderText = "VALOR UNITÁRIO";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].HeaderText = "DESCONTO";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[2].HeaderText = "TOTAL";
            dataGridView1.Columns[2].Width = 100;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if(tabControl1.TabPages.Count < 6)
            {
                tabControl1.TabPages.Add(tabPage4);
                tabControl1.SelectedTab = tabPage4;
                novo = false;
            }            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand cmd = new SqlCommand("select * from pedido", con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DataView dv = new DataView(dt);
            if (rbCliente.Checked)
            {


            }
            if (rbCodPed.Checked)
            {


            }
            if (rbData.Checked)
            {

                dv.RowFilter = "ped_dtemissao like '%" + txtPesquiPedido.Text + "%'";
            }
            if (rbProduto.Checked)
            {

            }
            pedidoDataGrid.DataSource = dv;
            con.Close();
        }

        private void pedidoDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = this.pedidoDataGrid.Rows[e.RowIndex];
                txtControle.Text = row.Cells[0].Value.ToString();
                mskDtVenda.Text = row.Cells[1].Value.ToString();
                txtCdesconto.Text = row.Cells[5].Value.ToString();
                txtObs.Text = row.Cells[6].Value.ToString();
                txtcodVendedor.Text = row.Cells[7].Value.ToString();
                txtcodCliente.Text = row.Cells[8].Value.ToString();
                txtSomaDesconto.Text = row.Cells[4].Value.ToString();

            }
            CarregaProdutos();
            txtControle.Enabled = false;
            u.EnableCombo(this);
            u.EnableDataGrid(this);
            u.EnableMasked(this);
            u.EnableTxt(this);
            btnExcluir.Enabled = false;
            btnInsProduto.Enabled = false;
            btnNovo.Enabled = false;
            btnPesquisar.Enabled = true;
            btnPCliente.Enabled = true;
            btnPProduto.Enabled = true;
            btnPvendedor.Enabled = true;
            txtsomaTudo.Enabled = false;
            maskedTextBox1.Enabled = true;
        }

        private void txtcodVendedor_TextChanged(object sender, EventArgs e)
        {
            if (txtcodVendedor.Text == null || txtcodVendedor.Text == string.Empty)
            {
                txtNomeVendedor.Focus();
            }
            else
            {
                txtNomeVendedor.Text = db.GetDescricao("Select n_funcionario From funcionarios where cod_funcionario = ", txtcodVendedor.Text, txtNomeVendedor.Text);
            }
        }

        private void txtcodCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtcodCliente.Text == null || txtcodCliente.Text == string.Empty)
            {
                txtNomeCliente.Focus();
            }
            else
            {
                txtNomeCliente.Text = db.GetDescricao("Select n_cliente From clientes where cod_cliente = ", txtcodCliente.Text, txtNomeCliente.Text);
            }
        }

        private void txtCodProduto_TextChanged(object sender, EventArgs e)
        {
            if (txtCodProduto.Text == null || txtCodProduto.Text == string.Empty)
            {
                txtNomeProduto.Focus();
            }
            else
            {
                txtNomeProduto.Text = db.GetDescricao("Select des_produto From produtos where cod_produto = ", txtCodProduto.Text, txtNomeProduto.Text);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int estadoID = 0;
            FbConnection con = new FbConnection();
            con.ConnectionString = Properties.Settings.Default.BancoFirebird;
            FbCommand cmd = new FbCommand("select * from nfe", con);
            con.Open();
            FbDataReader DR;
            DR = cmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR);
            con.Close();
            DataView dv = new DataView(DT);
            dataGridView2.DataSource = dv;

            DataContextFirebird dbFb = new DataContextFirebird();
            NotaFreeNFE nf = new NotaFreeNFE();

            // cadastro de cliente
            var cliente = db.Clientes.Find(Convert.ToInt32(txtcodCliente.Text.Trim()));
            FbConnection conCl = new FbConnection();
            conCl.ConnectionString = Properties.Settings.Default.BancoFirebird;
            string selectC = "select ID from PESSOA WHERE ID = " + cliente.ID;
            FbCommand cmd2 = new FbCommand(selectC, conCl);
            try
            {
                var cidMs = db.Cidades.Find(cliente.CidadeCodigo);
                var cidFb = dbFb.Municipios.Where(x => x.Ibge == cidMs.Ibge).FirstOrDefault();
                con.Open();
                FbDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {

                }
                else
                {
                    string insertC = "INSERT INTO PESSOA(ID, ID_MUNICIPIO, ID_ESTADO, ID_PAIS, ID_FILIAL, TIPO, PESSOA, RAZAO, FANTASIA, )"
                                   + "CNPJCPF, IE, ISENTO_ICMS, CEP, ENDERECO, NUMERO, COMPLEMENTO, BAIRRO, EMAIL, FONE, CELULAR,  CONTATO, "
                                   + "OBS, CADASTRO, CNAE, INDFINAL, EXIBIROBS) VALUES @(ID, @ID_MUNICIPIO, @ID_ESTADO, @ID_PAIS, @ID_FILIAL, @TIPO, @PESSOA, @RAZAO, @FANTASIA, "
                                   + "@CNPJCPF, @IE, @ISENTO_ICMS, @CEP, @ENDERECO, @NUMERO, @COMPLEMENTO, @BAIRRO, @EMAIL, @FONE, @CELULAR, @CONTATO, "
                                   + "@OBS, @CADASTRO, @CNAE, @INDFINAL, @EXIBIROBS)";
                    cmd2.Parameters.Add("@ID", FbDbType.Integer).Value = cliente.ID;
                    cmd2.Parameters.Add("@ID_MUNICIPIO", FbDbType.Integer).Value = cidFb.ID;
                    cmd2.Parameters.Add("@ID_ESTADO", FbDbType.Integer).Value = cidFb.EstadoID;
                    estadoID = cidFb.EstadoID;
                    cmd2.Parameters.Add("@ID_PAIS", FbDbType.Integer).Value = 1058;
                    cmd2.Parameters.Add("@ID_FILIAL", FbDbType.Integer).Value = 1;
                    cmd2.Parameters.Add("@TIPO", FbDbType.Integer).Value = 0;
                    cmd2.Parameters.Add("@PESSOA", FbDbType.VarChar).Value = "J";
                    cmd2.Parameters.Add("@RAZAO", FbDbType.VarChar).Value = cliente.Razao;
                    cmd2.Parameters.Add("@FANTASIA", FbDbType.VarChar).Value = cliente.Razao;
                    cmd2.Parameters.Add("@CNPJCPF", FbDbType.VarChar).Value = cliente.Cpf;
                    cmd2.Parameters.Add("@IE", FbDbType.VarChar).Value = cliente.IE;
                    cmd2.Parameters.Add("@ISENTO_ICMS", FbDbType.Integer).Value = 0;
                    cmd2.Parameters.Add("@CEP", FbDbType.VarChar).Value = cliente.Cep;
                    cmd2.Parameters.Add("@ENDERECO", FbDbType.VarChar).Value = cliente.Endereco;
                    cmd2.Parameters.Add("@NUMERO", FbDbType.VarChar).Value = cliente.Numero;
                    cmd2.Parameters.Add("@COMPLEMENTO", FbDbType.VarChar).Value = "";
                    cmd2.Parameters.Add("@BAIRRO", FbDbType.VarChar).Value = cliente.Bairro;
                    cmd2.Parameters.Add("@EMAIL", FbDbType.VarChar).Value = cliente.Email;
                    cmd2.Parameters.Add("@FONE", FbDbType.VarChar).Value = cliente.Telefone;
                    cmd2.Parameters.Add("@CELULAR", FbDbType.VarChar).Value = cliente.Celular;
                    cmd2.Parameters.Add("@CONTATO", FbDbType.VarChar).Value = "";
                    cmd2.Parameters.Add("@OBS", FbDbType.VarChar).Value = cliente.Observacoes;
                    cmd2.Parameters.Add("@CADASTRO", FbDbType.Date).Value = DateTime.Now.Date;
                    cmd2.Parameters.Add("@CNAE", FbDbType.VarChar).Value = "";
                    cmd2.Parameters.Add("@INDFINAL", FbDbType.Integer).Value = 0;
                    cmd2.Parameters.Add("@EXIBIROBS", FbDbType.Integer).Value = 1;
                    try
                    {
                        cmd2.CommandType = CommandType.Text;
                        conCl.Open();
                        int iii = cmd.ExecuteNonQuery();
                        if (iii > 0)
                        {

                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            //cadastro de produto
            var i = 0;
            foreach (var row in this.dataGridView1.Rows)
            {
                i = i + 1;
                var dataGridViewRow = row as DataGridViewRow;
                var celula = dataGridViewRow.Cells["cod_produto"];
                var valVenda = dataGridViewRow.Cells[3];
                var valor = celula.Value;
                if (valor != DBNull.Value)
                {
                    var produto = db.Produtos.Find(valor);
                    string select = "select ID from PRODUTO WHERE ID = " + valor;
                    FbCommand cmd1 = new FbCommand(select, con);
                    try
                    {
                        string comando = "";
                        FbConnection conFb = new FbConnection();
                        conFb.ConnectionString = Properties.Settings.Default.BancoFirebird;
                        FbCommand cmdFb = new FbCommand(comando, conFb);
                        con.Open();
                        FbDataReader dr = cmd1.ExecuteReader();
                        if (dr.Read())
                        {
                            comando = "update produto set PRECO = " + produto.ValorVenda + "where ID = " + valor;
                        }
                        else
                        {
                            comando = "insert into PRODUTO(ID, ID_GRUPO, ID_SUBGRUPO, ID_TRIBUTACAO, NCM, CODIGO , DESCRICAO, UNIDADE, TIPO, "
                                          + " SITUACAO, PRECO, ORIGEM, CEST) VALUES (@ID, @ID_GRUPO, @ID_SUBGRUPO, @ID_TRIBUTACAO, @NCM, @CODIGO , "
                                          + "@DESCRICAO, @UNIDADE, @TIPO, @SITUACAO, @PRECO, @ORIGEM, @CEST)";
                            cmdFb.Parameters.Add("@ID", FbDbType.Integer).Value = produto.ID;
                            cmdFb.Parameters.Add("@ID_GRUPO", FbDbType.Integer).Value = 1;
                            cmdFb.Parameters.Add("@ID_SUBGRUPO", FbDbType.Integer).Value = 1;
                            cmdFb.Parameters.Add("@ID_TRIBUTACAO", FbDbType.Integer).Value = 1;
                            cmdFb.Parameters.Add("@NCM, @CODIGO", FbDbType.VarChar).Value = produto.NCM;
                            cmdFb.Parameters.Add("@CODIGO", FbDbType.VarChar).Value = produto.Referencia;
                            cmdFb.Parameters.Add("@DESCRICAO", FbDbType.VarChar).Value = produto.DescricaoReduzida;
                            cmdFb.Parameters.Add("@UNIDADE", FbDbType.VarChar).Value = produto.UnidadeMedida;
                            cmdFb.Parameters.Add("@TIPO", FbDbType.SmallInt).Value = 0;
                            cmdFb.Parameters.Add("@SITUACAO", FbDbType.SmallInt).Value = 0;
                            cmdFb.Parameters.Add("@PRECO", FbDbType.Decimal).Value = valVenda;
                            cmdFb.Parameters.Add("@ORIGEM", FbDbType.Integer).Value = produto.OrigemDoProduto;
                            cmdFb.Parameters.Add("@CEST", FbDbType.VarChar).Value = produto.CEST;
                        }
                        try
                        {
                            cmdFb.CommandType = CommandType.Text;
                            conFb.Open();
                            int ii = cmd.ExecuteNonQuery();
                            if (ii > 0)
                            {
                                
                            }                           
                        }
                        catch (Exception ex)
                        {
                            u.messageboxErro(ex.ToString());
                            throw;
                        }
                        finally
                        {
                            conFb.Close();
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



            //dados da nota
            var filial = db.Filiais.Find(1);
           
            var cidad = db.Cidades.Find(filial.CidadeCodigo);
            var ultimaNf = dbFb.Faturas.Max(x => x.ID);
            var cfop = db.Cfops.Find(cfopNumero);
            var ultimaNota = dbFb.Faturas.Find(ultimaNf);
            var dest = db.Clientes.Find(Convert.ToInt32(txtcodCliente.Text));
            var cidDest = db.Cidades.Find(dest.CidadeCodigo);
            


            // dados do emitente
            nf.Ambiente = 1;
            nf.Bairro = filial.Bairro;
            nf.CepEmitente = filial.Cep;
            //nf.CnaeEmitente = "4520-0/01";
            nf.CnpjEmitente = filial.CpfCnpj;
            nf.CodigoIbge = cidad.Ibge;
            nf.CodPais = "1058";
            nf.CRT = 1;
            nf.DataEmissao = DateTime.Now;
            nf.DataSaida = DateTime.Now;
            nf.DataSaida = DateTime.Now;
            nf.DescMunicipioEmitente = cidad.Descricao;
            nf.FantasiaEmitente = filial.Fantasia;
            nf.FilialID = filial.ID;
            nf.FinalidadeNF = 1;
            nf.FoneEmitente = filial.Telefone;
            //nf.HoraSaida = DateTime.Now;
            nf.IbgeEmitente = cidad.Ibge;
            nf.ID = ultimaNf + 1;
            
            nf.IDE_CMUNFG = Convert.ToInt32(cidad.Ibge);
            nf.IEEmitente = filial.IE;
            //nf.IestEmitente = filial.
            nf.InfComplEmitente = "LOTES 107 A B E 108";
            nf.LogradouroEmitente = filial.Endereco;
            nf.Modelo = 55;
            nf.NaturezaOperacao = cfop.Descricao;
            nf.NomeEmitente = filial.Razao;
            nf.NomePaisEmitente = "Brasil";
            nf.NumeroEmitente = filial.Numero;
            nf.NumeroNF = ultimaNota.NumeroNF;
            nf.Serie = ultimaNota.Serie;
            nf.SituacaoNf = 0;
            nf.TipoEmissao = 0;
            nf.TipoNF = 1;
            nf.TipoNf = 0;
            nf.UFEmitente = cidad.UF;
            nf.VersaoApp = ultimaNota.VersaoApp;

            //dados do destinatario

            nf.BairroDestinatario = dest.Bairro;
            nf.CepDestinatario = dest.Cep;
            nf.CodPaisDestinatario = "1058";
            nf.EstadoDestinatario = cidDest.UF;
            nf.FoneDestinatario = dest.Telefone;
            nf.IbgeDestinario = cidDest.Ibge;
            nf.IEDestinatario = dest.IE;
            //nf.InfComplDestinatario = 
            nf.LogradouroDestinatario = dest.Endereco;
            nf.NomeDestinatario = dest.Razao;
            nf.NomeMunDestinario = cidDest.Descricao;
            nf.NomePaisDestinatario = "Brasil";
            nf.NumeroDestinatario = dest.Numero;
            nf.UFDestinatario = cidDest.UF;
            ultimaNf += 1;
            dbFb.Faturas.Add(nf);
            dbFb.SaveChanges();

            //itens da nota 
            i = 0;
            foreach (var row in this.dataGridView1.Rows)
            {
                i = i + 1;
                var dataGridViewRow = row as DataGridViewRow;
                var celula = dataGridViewRow.Cells["cod_produto"];
                var valVenda = dataGridViewRow.Cells["itp_valor"];
                var quantidade = dataGridViewRow.Cells["itp_qtde"];
                var valor = celula.Value;
                if (valor != DBNull.Value)
                {
                    var produto = db.Produtos.Find(valor);
                    try
                    {
                        string getNitem = "select max(NITEM) from NFE_ITENS where ID = " + ultimaNf;
                        FbConnection Ncon = new FbConnection();
                        Ncon.ConnectionString = Properties.Settings.Default.Ducaun;
                        FbCommand Ncmd = new FbCommand(getNitem, Ncon);
                        Ncmd.CommandType = CommandType.Text;
                        Ncon.Open();
                        FbDataReader fbDr = Ncmd.ExecuteReader();
                        if (fbDr.Read())
                        {
                            getNitem = fbDr[0].ToString();
                            getNitem = Convert.ToString(Convert.ToInt32(getNitem) + 1);
                        }
                        else
                        {
                            getNitem = "1";
                        }


                        string comando = "";
                        FbConnection conI = new FbConnection();
                        conI.ConnectionString = Properties.Settings.Default.BancoFirebird;
                        FbCommand cmdI = new FbCommand(comando, conI);
                        comando = "insert into NFE_ITENS(ID, ID_NFE, ID_FILIAL, ID_PRODUTO, NITEM, CPROD , XPROD, NCM, CFOP, UCOM, QCOM, VUNCOM"
                                      + " VPROD, UTRIB, QTRIB, VUNTRIB, VDESC, VEICPROD_TPOP, VEICPROD_CONDVEIC,  COMB_CPRODANP, COMB_CODIF, "
                                      + " COMB_CIDE_QBCPROD, COMB_CIDE_VALIQPROD, COMB_ICMS_VBCICMS, COMB_ICMS_VBCICMSST, COMB_ICMSCONS_UFCONS "
                                      + " ICMS_ORIGEM, ICMS_MODBC, ICMS_MODBCST) "
                                      + " VALUES (@ID, @ID_NFE, @ID_FILIAL, @ID_PRODUTO, @NITEM, @CPROD , @XPROD, @NCM, @CFOP, @UCOM, @QCOM, @VUNCOM"
                                      + " @VPROD, @UTRIB, @QTRIB, @VUNTRIB, @VDESC, @VEICPROD_TPOP, @VEICPROD_CONDVEIC, @COMB_CPRODANP, @COMB_CODIF, "
                                      + " @COMB_CIDE_QBCPROD, @COMB_CIDE_VALIQPROD, @COMB_ICMS_VBCICMS, @COMB_ICMS_VBCICMSST, @COMB_ICMSCONS_UFCONS"
                                      + " @ICMS_ORIGEM, @ICMS_MODBC, @ICMS_MODBCST)";
                        cmdI.Parameters.Add("@ID", FbDbType.Integer).Value = produto.ID;
                        cmdI.Parameters.Add("@ID_NFE", FbDbType.Integer).Value = ultimaNf;
                        cmdI.Parameters.Add("@ID_FILIAL", FbDbType.Integer).Value = 1;
                        cmdI.Parameters.Add("@ID_PRODUTO", FbDbType.Integer).Value = valor;
                        cmdI.Parameters.Add("@NITEM", FbDbType.Integer).Value = Convert.ToInt32(getNitem);
                        cmdI.Parameters.Add("@CPROD", FbDbType.VarChar).Value = produto.Referencia;
                        cmdI.Parameters.Add("@XPROD", FbDbType.VarChar).Value = produto.DescricaoReduzida;
                        cmdI.Parameters.Add("@NCM", FbDbType.VarChar).Value = produto.NCM;
                        cmdI.Parameters.Add("@CFOP", FbDbType.Integer).Value = produto.CFOP;
                        cmdI.Parameters.Add("@UCOM", FbDbType.VarChar).Value = produto.UnidadeMedida;
                        cmdI.Parameters.Add("@QCOM", FbDbType.Decimal).Value = quantidade;
                        cmdI.Parameters.Add("@VUNCOM", FbDbType.Decimal).Value = valVenda;
                        cmdI.Parameters.Add("@VPROD", FbDbType.Decimal).Value = (Convert.ToDecimal(quantidade) * Convert.ToDecimal(valVenda));
                        cmdI.Parameters.Add("@UTRIB", FbDbType.VarChar).Value = produto.UnidadeMedida;
                        cmdI.Parameters.Add("@QTRIB", FbDbType.Decimal).Value = quantidade;
                        cmdI.Parameters.Add("@VUNTRIB", FbDbType.Decimal).Value = 0;
                        cmdI.Parameters.Add("@VDESC", FbDbType.Decimal).Value = 0;
                        cmdI.Parameters.Add("@VEICPROD_TPOP", FbDbType.SmallInt).Value = 0;
                        cmdI.Parameters.Add("@VEICPROD_CONDVEIC", FbDbType.SmallInt).Value = 0;
                        cmdI.Parameters.Add("@COMB_CPRODANP", FbDbType.SmallInt).Value = 0;
                        cmdI.Parameters.Add("@COMB_CODIF", FbDbType.SmallInt).Value = 0;
                        cmdI.Parameters.Add("@COMB_CIDE_QBCPROD", FbDbType.Decimal).Value = (Convert.ToDecimal(quantidade) * Convert.ToDecimal(valVenda));
                        cmdI.Parameters.Add("@COMB_CIDE_VALIQPROD", FbDbType.Decimal).Value = 0;
                        cmdI.Parameters.Add("@COMB_ICMS_VBCICMS", FbDbType.Decimal).Value = (Convert.ToDecimal(quantidade) * Convert.ToDecimal(valVenda));
                        cmdI.Parameters.Add("@COMB_ICMS_VBCICMSST", FbDbType.Decimal).Value = (Convert.ToDecimal(quantidade) * Convert.ToDecimal(valVenda));
                        var estado = dbFb.Estados.Find(estadoID);
                        cmdI.Parameters.Add("@COMB_ICMSCONS_UFCONS", FbDbType.VarChar).Value = estado.Sigla;
                        cmdI.Parameters.Add("@ICMS_ORIGEM", FbDbType.SmallInt).Value = 0;
                        cmdI.Parameters.Add("@ICMS_MODBC", FbDbType.SmallInt).Value = 0;
                        cmdI.Parameters.Add("@ICMS_MODBCST", FbDbType.SmallInt).Value = 4; 
                        cmdI.CommandType = CommandType.Text;
                        conI.Open();
                        int ii = cmd.ExecuteNonQuery();
                        conI.Close();
                    }
                    catch (Exception ex)
                    {
                        u.messageboxErro(ex.ToString());
                        throw;
                    }
                    
                }
            }
            u.messageboxSucesso();
        }

        private void mskDtVenda_Leave_1(object sender, EventArgs e)
        {
            string query = "Select ped_codigo From pedido where ped_codigo = (Select MAX(ped_codigo) From pedido)";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand sqlCommand = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {
                txtControle.Text = dR[0].ToString();
            }
            con.Close();
        }
    }
}
