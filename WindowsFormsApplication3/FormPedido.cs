using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication3.ClassesEntidades;



namespace WindowsFormsApplication3
{
    public partial class FormPedido : Form

    {
        bool novo;
        decimal kuantidade;
        decimal valProduto;
        decimal valUnitario;
        decimal desconto;        
        public FormPedido()
        {
            InitializeComponent();
        }
        Estoque estoque = new Estoque();
        utils u = new utils();
        Pedido pedido = new Pedido();
        PedidoProduto pedidoProduto = new PedidoProduto();
        DataContext db = new DataContext(); 

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
        }
        
        private void FormPedido_Load(object sender, EventArgs e)
        {            
            reportViewer1.Visible = false;
            button8.Visible = false;
            novo = true;
            Unovo();
            panelPfunc.Visible = false;
            mskDtVenda.Enabled = true;
            mskDtVenda.Text = DateTime.Now.ToString();
            txtSomaDesconto.Text = "0,00";
            txtDesconto.Text = "0,00";           
        }

        private void btnSaiPesquisa_Click(object sender, EventArgs e)
        {
            panelPesquisaClientes.Visible = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo = true;
            pedido.DataEmissao = Convert.ToString(mskDtVenda.Text);
            string nova = "insert into pedido(ped_dtemissao) values(@ped_dtemissao)";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;
            SqlCommand cmd = new SqlCommand(nova, con);
            cmd.Parameters.Add("@ped_dtemissao", SqlDbType.VarChar).Value = pedido.DataEmissao;
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
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
            
            txtControle.Enabled = false;
            txtcodCliente.Enabled = true;
            txtNomeCliente.Enabled = true;
            txtcodVendedor.Enabled = true;
            txtNomeVendedor.Enabled = true;
            txtCodProduto.Enabled = true;
            txtNomeProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            txtValor.Enabled = true;
            txtVTotal.Enabled = true;
            txtDesconto.Enabled = true;
            btnExcluir.Enabled = false;
            btnInsProduto.Enabled = false;
            btnNovo.Enabled = false;
            btnPesquisar.Enabled = true;
            btnPCliente.Enabled = true;
            btnPProduto.Enabled = true;            
            btnPvendedor.Enabled = true;
            txtsomaTudo.Enabled = true;
            maskedTextBox1.Enabled = true;
            txtCdesconto.Enabled = true;
            txtObs.Enabled = true;
            txtSomaDesconto.Enabled = true;
            txtsomaTudo.Text = "0,00";
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (validaCalculo())
            {
                btnInsProduto.Enabled = true;
            }
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

        private void FormPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeusFormularios.FrmPedido = null;
        }

        private void btnPCliente_Click(object sender, EventArgs e)
        {
            panelPesquisaClientes.Visible = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaFuncionarios());
            if (radioButtonCodigo.Checked)
            {
                dv.RowFilter = "cod_funcionario = " + txtpfunc.Text;
            }
            if (radioButtonDescricao.Checked)
            {
                dv.RowFilter = "n_funcionario like '%" + txtpfunc.Text + "%'";
            }
            funcionariosDataGridView.DataSource = dv;            
        }

        private void clientesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panelPesquisaClientes.Visible = false;

                DataGridViewRow row = this.clientesDataGridView.Rows[e.RowIndex];

                txtcodCliente.Text = row.Cells[0].Value.ToString();
                txtNomeCliente.Text = row.Cells[1].Value.ToString();
            }
        }

        private void funcionariosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panelPfunc.Visible = false;
                DataGridViewRow row = this.funcionariosDataGridView.Rows[e.RowIndex];
                txtcodVendedor.Text = row.Cells[0].Value.ToString();
                txtNomeVendedor.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaProdutos());
            if (radioButtonBarras.Checked)
            {
                dv.RowFilter = "ean like '%" + textBox1.Text + "%'";
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
            panelPClie.Visible = false;
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

        private void btnPProduto_Click(object sender, EventArgs e)
        {
            panelPClie.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelPClie.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelPfunc.BringToFront();
            panelPfunc.Visible = false;
            panelPfunc.BringToFront();
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
            con.ConnectionString = Properties.Settings.Default.Ducaun;
            SqlCommand cmd = new SqlCommand(insProduto, con);
            cmd.Parameters.Add("@ped_codigo", SqlDbType.Int).Value = pedidoProduto.PedidoID;
            cmd.Parameters.Add("@cod_produto", SqlDbType.Int).Value = pedidoProduto.ProdutoID;
            cmd.Parameters.Add("@itp_valor", SqlDbType.Decimal).Value = pedidoProduto.ValorUnitario;
            cmd.Parameters.Add("@itp_qtde", SqlDbType.Decimal).Value = pedidoProduto.Quantidade;
            cmd.Parameters.Add("@ipt_total", SqlDbType.Decimal).Value = pedidoProduto.ValorTotal;
            cmd.CommandType = CommandType.Text;
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
                    if (i > 0)
                    {
                        dataGridView1.Rows.Add(txtCodProduto.Text, txtNomeProduto.Text, txtQuantidade.Text, txtValor.Text, txtDesconto.Text, txtVTotal.Text);
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
            //grava estoque
            
            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = Properties.Settings.Default.Ducaun;            
            estoque.ProdutoID = Convert.ToInt32(produtosDataGridView.CurrentRow.Cells["cod_produto"].Value.ToString());
            string estoques = "insert into estoque(est_qtde,ven_codigo, est_data, pro_codigo) values(@est_qtde, @ven_codigo, @est_data, @pro_codigo)";
            SqlCommand cmd2 = new SqlCommand(estoques, con2);
            cmd2.Parameters.Add("@est_qtde", SqlDbType.Decimal).Value = pedidoProduto.Quantidade * -1;
            cmd2.Parameters.Add("@ven_codigo", SqlDbType.Int).Value = pedidoProduto.PedidoID;
            cmd2.Parameters.Add("@est_data", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
            cmd2.Parameters.Add("@pro_codigo", SqlDbType.Int).Value = estoque.ProdutoID;
            con2.Open();
            try
            {
                int j = cmd2.ExecuteNonQuery();
                if (j > 0)
                {
                    btnInsProduto.Enabled = false;
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

        private void mskDtVenda_Leave(object sender, EventArgs e)
        {
            string query = "Select ped_codigo From pedido where ped_codigo = (Select MAX(ped_codigo) From pedido)";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;
            SqlCommand sqlCommand = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dR = sqlCommand.ExecuteReader();
            if (dR.Read())
            {
                txtControle.Text = dR[0].ToString();
            }
            con.Close();
        }

        private void btnPvendedor_Click(object sender, EventArgs e)
        {
            panelPfunc.Visible = true;
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
                con.ConnectionString = Properties.Settings.Default.Ducaun;
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

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            decimal valorTotal = 0;

            foreach (DataGridViewRow col in dataGridView1.Rows)
            {
                valorTotal = valorTotal + Convert.ToDecimal(col.Cells[5].Value);
            }

            txtsomaTudo.Text = Convert.ToString(valorTotal);
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
                con.ConnectionString = Properties.Settings.Default.Ducaun;
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
                            this.dataTable1TableAdapter1.FillByimprimeobagui(this.jarbasDataSet.DataTable1, Convert.ToInt32(txtControle.Text)/*((int)(System.Convert.ChangeType(pedidoCodigoToolStripTextBox.Text, typeof(int))))*/);
                        }
                        catch (Exception ex)
                        {
                            u.messageboxErro(ex.ToString());
                        }

                        reportViewer1.Visible = true;
                        reportViewer1.Show();
                        this.reportViewer1.RefreshReport();
                        reportViewer1.Visible = true;
                        button8.Visible = true;
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
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                Unovo(); 
                txtCdesconto.BackColor = SystemColors.Window;
                txtcodCliente.BackColor = SystemColors.Window;
                txtCodProduto.BackColor = SystemColors.Window;
                txtDesconto.BackColor = SystemColors.Window;
                txtSomaDesconto.BackColor = SystemColors.Window;
                txtsomaTudo.BackColor = SystemColors.Window;
                mskDtVenda.BackColor = SystemColors.Window;
                maskedTextBox1.BackColor = SystemColors.Window;
                dataGridView1.Refresh();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancela_Click(object sender, EventArgs e)
        {
            Unovo();       
        }

        private void txtCdesconto_Enter(object sender, EventArgs e)
        {
            decimal totSemDesconto = Convert.ToDecimal(txtsomaTudo.Text.Trim());
            desconto = Convert.ToDecimal(txtSomaDesconto.Text.Trim());
            decimal totalComDesconto = totSemDesconto - desconto;
            txtCdesconto.Text = Convert.ToString(totalComDesconto);
        }

        private void txtSomaDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            if (txtValor.Text == string.Empty)
            {
                txtValor.Text = "0,00";
                txtQuantidade.Text = "0,00";
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            kuantidade = Convert.ToDecimal(txtQuantidade.Text.Trim());
            valUnitario = Convert.ToDecimal(txtValor.Text.Trim());
            valProduto = kuantidade * valUnitario;
            txtVTotal.Text = Convert.ToString(valProduto.ToString("N2"));
        }

        private void txtSomaDesconto_Enter(object sender, EventArgs e)
        {
            if (txtSomaDesconto.Text == string.Empty)
            {
                txtValor.Text = "0,00";
            }
        }        

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;
            SqlCommand cmd = new SqlCommand("select * from pedido", con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DataView dv = new DataView(dt);
            if(rbCliente.Checked)
            {
               

            }
            if(rbCodPed.Checked)
            {
              

            }
            if(rbData.Checked)
            {
                
                dv.RowFilter = "ped_dtemissao like '%" + txtPesquiPedido.Text + "%'"; 
            }
            if (rbProduto.Checked)
            {
               
            }
            pedidoDataGrid.DataSource = dv;
            con.Close();
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            panelPed.Visible = true;
            novo = false;            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelPed.Visible = false;
        }

        private void pedidoDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panelPed.Visible = false;
                DataGridViewRow row = this.pedidoDataGrid.Rows[e.RowIndex];
                txtControle.Text = row.Cells[0].Value.ToString();
                mskDtVenda.Text = row.Cells[1].Value.ToString();
                txtCdesconto.Text = row.Cells[5].Value.ToString();
                txtObs.Text = row.Cells[6].Value.ToString();
                txtcodVendedor.Text = row.Cells[7].Value.ToString();
                txtcodCliente.Text = row.Cells[8].Value.ToString();
                txtSomaDesconto.Text = row.Cells[4].Value.ToString();
                
            }
            string getItem = "select a.cod_produto, b.des_produto, a.ITP_QTDE, a.ITP_VALOR, a.ITP_TOTAL from ITEMPEDIDO a join produtos b on a.cod_produto = b.cod_produto where ped_codigo = " + txtControle.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;
            SqlCommand cmd = new SqlCommand(getItem, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DataView dv = new DataView(dt);
            pedidoDataGrid.DataSource = dv;
            con.Close();
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
            if (txtcodVendedor.Text == null)
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
            if (txtcodCliente.Text == null)
            {
                txtNomeCliente.Focus();
            }
            else
            {
                txtNomeCliente.Text = db.GetDescricao("Select n_cliente From clientes where cod_cliente = ", txtcodCliente.Text, txtNomeCliente.Text);
            }
        }

        private void txtcodVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();       
        }
        
        private void txtcodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void txtcodCliente_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void txtCodProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            u.ApenasNumeros();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = new SqlCommand("select a.cod_produto, b.des_produto, a.ITP_QTDE, a.ITP_VALOR, a.ITP_TOTAL from ITEMPEDIDO a join produtos b on a.cod_produto = b.cod_produto where ped_codigo = "
            +txtControle.Text, new SqlConnection(Properties.Settings.Default.Ducaun));
            DA.GetFillParameters();
            dataGridView1.DataSource = DA.SelectCommand;
            //DA.SelectCommand = new SqlCommand("select a.cod_produto, b.des_produto, a.ITP_QTDE, a.ITP_VALOR, a.ITP_TOTAL from ITEMPEDIDO a join produtos bon a.cod_produto = b.cod_produto where ped_codigo = " 
            // +txtControle.Text, new SqlConnection(Properties.Settings.Default.Ducaun));
        }

        private void txtcodVendedor_Leave(object sender, EventArgs e)
        {
            if (enableSalvar())
            {
                btnSalvar.Enabled = true;
            }
        }

        private void txtcodCliente_Leave(object sender, EventArgs e)
        {
            if (enableSalvar())
            {
                btnSalvar.Enabled = true;
            }
            //verifica se cliente inadimplente           
            if (txtcodCliente.Text == string.Empty)
            {
                txtNomeCliente.Focus();
            }
            else
            {
                if( db.ClienteInadimplente(Convert.ToInt32(txtcodCliente.Text)) == true)
                {
                    u.ClienteInadimplente();
                }                
            }            
        }

        private void txtSomaDesconto_Leave(object sender, EventArgs e)
        {
            if (enableSalvar())
            {
                btnSalvar.Enabled = true;
            }
        }

        private void txtCdesconto_Leave(object sender, EventArgs e)
        {
            if (enableSalvar())
            {
                btnSalvar.Enabled = true;
            }
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            if (enableSalvar())
            {
                btnSalvar.Enabled = true;
            }
        }

        private void fillByimprimeobaguiToolStripButton_Click(object sender, EventArgs e)
        {
            /*try
            {
                this.dataTable1TableAdapter1.FillByimprimeobagui(this.jarbasDataSet.DataTable1, ((int)(System.Convert.ChangeType(pedidoCodigoToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }*/
        }

        private void reportViewer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (reportViewer1.Visible == true)
            {
                if (char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsNumber(e.KeyChar) || (char) 27 != (e.KeyChar) )
                {
                    e.Handled = true;              
                }
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            reportViewer1.Visible = false;
            button8.Visible = false;
        }

        private void mskDtVenda_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            /*if (!e.IsValidInput)
            {
                MessageBox.Show("Data inválida", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
        }

        private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                u.messageboxDataInv();
            }
        }    
           
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {            
            estoque.VendaProdutoID = Convert.ToInt32(txtControle.Text.Trim());
            estoque.ProdutoID = Convert.ToInt32(produtosDataGridView.CurrentRow.Cells["cod_produto"].Value.ToString());
            string deleteEstoque = "delete from estoque where pro_codigo = " + estoque.ProdutoID + "and ven_codigo = " + estoque.VendaProdutoID;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Ducaun;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //codproduto = Convert.ToInt32(produtosDataGridView.CurrentRow.Cells["cod_produto"].Value.ToString());
            //MessageBox.Show(codproduto.ToString());
        }
    }
}



