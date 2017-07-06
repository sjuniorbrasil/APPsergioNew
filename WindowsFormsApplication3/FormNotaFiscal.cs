﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using NFeEletronica.Contexto;
using NFeEletronica.NotaFiscal;
using NFeEletronica.Certificado;
using Aplicativo.ClassesEntidades;

namespace Aplicativo
{
    public partial class FormNotaFiscal : Form
    {
        utils u = new utils();
        public FormNotaFiscal()
        {
            InitializeComponent();
        }
        private void Unovo()
        {
            u.limparCombo(this);
            u.limparMTextBoxes(this);
            u.limparTextBoxes(this);
            u.DisableCombo(this);
            u.DisableTxt(this);
            btnNovo.Enabled = true;
            btnSair.Enabled = true;
            btnSalvar.Enabled = false;
            btnTransmitir.Enabled = false;
            btnInsProduto.Enabled = false;
            btnPProduto.Enabled = false;
            comboBox1.SelectedValue = 1;
        }

        private void alterar()
        {
            buttonCancela.Enabled = true;
            
            btnNovo.Enabled = false;
            btnSair.Enabled = true;
            btnSalvar.Enabled = true;
            u.EnableCombo(this);
            u.EnableDataGrid(this);
            u.EnableMasked(this);
            u.EnableTxt(this);
        }



        private void btnPCliente_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelPProdutos.Visible = false;
        }

        private void buttonCancela_Click(object sender, EventArgs e)
        {
            Unovo();           
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            u.EnableTxt(this);
            u.EnableCombo(this);
            btnNovo.Enabled = false;
            btnSair.Enabled = false;
            btnSalvar.Enabled = true;
            btnTransmitir.Enabled = false;
            btnInsProduto.Enabled = true;
            btnPProduto.Enabled = true;
            txtSerie.Text = "1";
            comboBox1.SelectedIndex = 0;

            string ultimoReg = "Select not_codigo From nota where not_codigo = (Select MAX(not_codigo) From nota)";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand cmd = new SqlCommand(ultimoReg, con);
            
            
            con.Open();
            SqlDataReader dR = cmd.ExecuteReader();

            if (dR.Read())
            {
                txtControle.Text = 1 + dR[0].ToString();
            }
            con.Close();
            int codigoNota = Convert.ToInt32(txtControle.Text.Trim());

            string inserirCod = "insert into nota(not_codigo) values(@not_codigo)";
            SqlCommand cmd1 = new SqlCommand(inserirCod, con);
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("@not_codigo", SqlDbType.Int).Value = codigoNota;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    mskDtVenda.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: Erro Ao Gravar no banco de dados " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
            string dataEmissao = mskDtVenda.Text.Trim();
            int numeroNota = Convert.ToInt32(txtNunNota.Text.Trim());
            string modeloNota = "55";
            string serie = txtSerie.Text;
            string finalidadeNota = comboBox1.SelectedIndex.ToString();
            int cadastro = Convert.ToInt32(txtcodFornecedor.Text.Trim());
            string cfop = txtCodCfod.Text.Trim();
            string nfeReferenciada = txtNFEreferenciada.Text.Trim();
            decimal subtotal = Convert.ToDecimal(txtsomaTudo.Text.Trim());
            decimal desconto = Convert.ToDecimal(txtSomaDesconto.Text.Trim());
            decimal totaldaNotacomdesconto = Convert.ToDecimal(txtCdesconto.Text.Trim());
            string obsNota = txtObs.Text.Trim();
            string transportador;
            if(txtCodTransp.Text == string.Empty)
            {
                transportador = "0";
            }
            else
            {
                transportador = txtCodTransp.Text.Trim();
            }
            string vencimento = txtVenc.Text;
            string chaveNfe;
            string protocolo;
            string recibo;
            string statusNota;
            string dataHoraProtocolo;
            int notcancelada;
            int notInutilizada;
            string motivoCancel;
            string peso;
            string volumes;
            string marca;            
            decimal icmsBase;
            decimal icmsValor;
            decimal icmsPercentual;
            decimal icmsStValor;
            string nfeXml;
            decimal ipiValor;

            string updateNota = "update nota set not_dtemissao = @not_dtemissao, not_numero = @not_numero, not_modelo = @not_modelo, not_serie = not_serie, not_finalidade = @not_finalidade, cadastro = @cadastro, cfo_codigo = @cfo_codigo, not_referenciada = @not_referenciada, not_subtotal = @not_subtotal, not_desconto = @not_desconto, not_nfetotal = @not_nfetotal, not_obs = @not_obs, cod_forncedor = @cad_fornecedor, not_vencimento = @not_vencimento, not_cancelada = @not_cancelada, not_inutilizada = @not_inutilizada, not_peso = @not_peso, not_volume = @not_volume, not_marca = @not_marca, not_icmsbase = @not_icmsbase, not_icmsvalor = @not_icmsvalor, not_icmspercentual = @not_icmspercentual, not_icmsstvalor = @not_icmsstvalor   where not_codigo = " + txtControle.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand cmd = new SqlCommand(updateNota, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@not_dtemissao", SqlDbType.NVarChar).Value = dataEmissao;
            cmd.Parameters.Add("@not_numero", SqlDbType.Int).Value = numeroNota;
            cmd.Parameters.Add("@not_modelo", SqlDbType.NVarChar).Value = modeloNota;
            cmd.Parameters.Add("@not_serie", SqlDbType.NVarChar).Value = serie;
            cmd.Parameters.Add("@not_finalidade", SqlDbType.NVarChar).Value = finalidadeNota;
            cmd.Parameters.Add("@cadastro", SqlDbType.Int).Value = cadastro;
            cmd.Parameters.Add("@cfo_codigo", SqlDbType.Int).Value = cfop;
            cmd.Parameters.Add("@not_referenciada", SqlDbType.NVarChar).Value = nfeReferenciada;
            cmd.Parameters.Add("@not_subtotal", SqlDbType.Decimal).Value = subtotal;
            cmd.Parameters.Add("@not_desconto", SqlDbType.Decimal).Value = desconto;
            cmd.Parameters.Add("@not_nfetotal", SqlDbType.Decimal).Value = totaldaNotacomdesconto;
            cmd.Parameters.Add("@not_obs", SqlDbType.NVarChar).Value = obsNota;
            cmd.Parameters.Add("@cad_fornecedor", SqlDbType.Int).Value = transportador;
            cmd.Parameters.Add("@not_vencimento", SqlDbType.NVarChar).Value = vencimento;
            cmd.Parameters.Add("@not_cancelada", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@not_inutilizada", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@not_peso", SqlDbType.NVarChar).Value = 1;
            cmd.Parameters.Add("@not_volume", SqlDbType.NVarChar).Value = 1;
            cmd.Parameters.Add("@not_marca", SqlDbType.NVarChar).Value = "marca";
            cmd.Parameters.Add("@not_icmsbase", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@not_icmsvalor", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@not_icmspercentual", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@not_icmsstvalor", SqlDbType.Decimal).Value = 0;


            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    u.messageboxSucesso();
                }
                var nfeContexto = new NFeContexto(false, NFeEletronica.Versao.NFeVersao.VERSAO_3_1_0, new GerenciadorDeCertificado());
                var nota = new Nota(nfeContexto);
                nota.ide.cUF = "41";
                nota.ide.natOp = txtDescCfop.Text;
                nota.ide.indPag = "0";
                nota.ide.mod = "55";
                nota.ide.serie = txtSerie.Text;
                //"select a.cod_produto, b.des_produto, a.ITP_QTDE, a.ITP_VALOR, a.ITP_TOTAL from ITEMPEDIDO a join produtos b on a.cod_produto = b.cod_produto where ped_codigo
                string ultimoReg = "Select not_codigo From nota where not_codigo = (Select MAX(not_numero) From nota)";
                string filial = "select * from filial where fil_codigo = ";
                
                SqlConnection con1 = new SqlConnection();
                con.ConnectionString = utils.ConexaoDb();
                SqlCommand cmd2 = new SqlCommand(ultimoReg, con1);
                SqlCommand cmd3 = new SqlCommand(filial, con1);
                con.Open();
                SqlDataReader dR = cmd2.ExecuteReader();
                SqlDataReader dr1 = cmd3.ExecuteReader();
                if (dR.Read())
                {
                    txtNunNota.Text = 1 + dR[0].ToString();
                }
                con.Close();
                nota.ide.nNF = txtNunNota.Text;
                nota.ide.dEmi = mskDtVenda.Text;
                nota.ide.tpNF = "1"; //normal contingencia
                nota.ide.cMunFG = txtIbge.Text;
                nota.ide.tpImp = "1";
                nota.ide.tpEmis = "1";
                nota.ide.cDV = "0";                
                nota.ide.idDest = "1";
                nota.ide.indFinal = "0";
                nota.ide.indPres = "0";
                nota.ide.tpAmb = "2";
                nota.ide.finNFe = finalidadeNota;
                nota.ide.procEmi = "3";// soft utilizado
                
                if (dr1.Read())
                {
                    nota.emit.CNPJ = dr1[9].ToString();
                    nota.emit.xNome = dr1[1].ToString();
                    nota.emit.xLgr = dr1[3].ToString();
                    nota.emit.nro = dr1[10].ToString();
                    nota.emit.xBairro = dr1[4].ToString();
                    nota.emit.cMun = dr1[13].ToString();
                    nota.emit.xMun = "Maringá";
                    nota.emit.UF = "PR";
                    nota.emit.CEP = "87070300";
                    nota.emit.cPais = "1058";
                    nota.emit.xPais = "Brasil";
                    nota.emit.fone = "449988316578";
                    nota.emit.IE = dr1[12].ToString();
                    nota.emit.CRT = "1";
                                        
                }
                //financeiro
                var dup = new NFeEletronica.NotaFiscal.DUP();
                dup.nDup = "123";
                dup.dVenc = "2014-03-21";
                dup.vDup = "23.33";
                nota.cobr.dup.Add(dup);
                //transportadora
                nota.transp.modFrete = "1";
                nota.transp.xNome = "O Mesmo";
                nota.transp.IE = "637322284114";
                nota.transp.xEnder = "Rua ficticia, 123";
                nota.transp.xMun = "São Lucas";
                nota.transp.UF = "RO";
                //produstos
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {

                    var notaProduto = new DET();
                        notaProduto.cProd = row.Cells["Código"].Value.ToString();
                        DataView dv = new DataView(DataContext.CarregaProdutos());
                        Produto produto = new Produto();
                        DataContext db = new DataContext();
                        var produtoIncluir = db.Produtos.Find(notaProduto.cProd);

                        notaProduto.cEAN = row.Cells["EAN"].Value.ToString(); 
                        notaProduto.xProd = row.Cells["DESCRIÇÃO"].Value.ToString(); 
                        notaProduto.NCM = row.Cells["NCM"].Value.ToString(); 
                        notaProduto.CFOP = row.Cells["CFOP"].Value.ToString(); 
                        notaProduto.uCom = row.Cells["UNIDADE"].Value.ToString(); 
                        notaProduto.qCom = row.Cells["QUANTIDADE"].Value.ToString(); 
                        notaProduto.vUnCom = row.Cells["VALOR UN"].Value.ToString(); 
                        notaProduto.vProd = row.Cells["TOTAL"].Value.ToString(); 
                        notaProduto.cEANTrib = row.Cells["Código"].Value.ToString();
                        notaProduto.uTrib = row.Cells["UNIDADE"].Value.ToString();
                        notaProduto.qTrib = row.Cells["QUANTIDADE"].Value.ToString();
                        notaProduto.vUnTrib = row.Cells["VALOR UN"].Value.ToString();
                        notaProduto.indTot = "1";
                        
                        switch (produtoIncluir.CstICMS)
                        {
                            case "00":
                                notaProduto.icms = ICMS.ICMS00;
                                break;
                            case "10":
                                notaProduto.icms = ICMS.ICMS10;
                                break;
                            case "20":
                                notaProduto.icms = ICMS.ICMS20;
                                break;
                            case "30":
                                notaProduto.icms = ICMS.ICMS30;
                                break;
                            case "40":
                                notaProduto.icms = ICMS.ICMS40_50;
                                break;
                            case "41":
                                notaProduto.icms = ICMS.ICMS40_50;
                                break;
                            case "50":
                                notaProduto.icms = ICMS.ICMS40_50;
                                break;
                            case "51":
                                notaProduto.icms = ICMS.ICMS51;
                                break;
                            case "60":
                                notaProduto.icms = ICMS.ICMS60;
                                break;
                            case "70":
                                notaProduto.icms = ICMS.ICMS70;
                                break;
                            case "90":
                                notaProduto.icms = ICMS.ICMS90;
                                break;
                            case "101":
                                notaProduto.icms = ICMS.ICMS101;
                                break;
                            case "102":
                                notaProduto.icms = ICMS.ICMS102_400;
                                break;                                
                            case "103":
                                notaProduto.icms = ICMS.ICMS102_400;
                                break;
                            case "201":
                                notaProduto.icms = ICMS.ICMS201;
                                break;
                            case "202":
                                notaProduto.icms = ICMS.ICMS202;
                                break; 
                            case "500":
                                notaProduto.icms = ICMS.ICMS500;
                                break;
                            case "900":
                                notaProduto.icms = ICMS.ICMS900;
                                break;
                            default:
                                notaProduto.icms = ICMS.ICMS00;
                                break;
                        }


                        
                        notaProduto.icms_orig = Convert.ToString(produtoIncluir.OrigemDoProduto);
                        if (nota.emit.CRT == "1")
                        {
                            notaProduto.icms_CSOSN = produtoIncluir.CstICMS;
                        }
                        else
                        {
                            notaProduto.icms_CST = produtoIncluir.CstICMS;
                        }                       

                        notaProduto.ipi = IPI.IPI00_49_50_99;
                        notaProduto.ipi_CST = "99";
                        notaProduto.ipi_vIPI = "0";

                        notaProduto.pis = PIS.PIS01_02;
                        notaProduto.pis_CST = "01";
                        notaProduto.pis_vBC = "0";
                        notaProduto.pis_pPIS = "0";
                        notaProduto.pis_vPIS = "0";

                        notaProduto.cofins = COFINS.CST01_02;
                        notaProduto.cofins_CST = "01";
                        notaProduto.cofins_vBC = "0";
                        notaProduto.cofins_pCOFINS = "0";
                        notaProduto.cofins_vCOFINS = "0";

                        nota.AddDet(notaProduto);
                    }
                }
                
                //fim de um produto

                nota.total.vBC = "0.00";
                nota.total.vICMS = "0.00";
                nota.total.vICMSDeson = "0.00";
                nota.total.vBCST = "0.00";
                nota.total.vST = "0.00";
                nota.total.vProd = "1.00";
                nota.total.vFrete = "0.00";
                nota.total.vSeg = "0.00";
                nota.total.vDesc = "0.00";
                nota.total.vII = "0.00";
                nota.total.vIPI = "0.00";
                nota.total.vPIS = "0.00";
                nota.total.vCOFINS = "0.00";
                nota.total.vOutro = "0.00";
                nota.total.vNF = "1.00";
                nota.total.vTotTrib = "0.00";

                nota.SalvarNota(@"C:\temp\teste-nota.xml");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: Erro Ao Gravar no banco de dados " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            Unovo();

        }

        private void btnTransmitir_Click(object sender, EventArgs e)
        {

            //rotina transmitir, se receber resposta positiva faz update, senão mensagem na tela
            string chaveNfe;
            string protocolo;
            string recibo;
            string statusNota;
            string dataHoraProtocolo;
            string updateNota = "update nota set  not_chave = @not_chave, not_protocolo = @not_protocolo, not_recibo = @not_recibo, not_statusnota = @statusnota, not_dthoraprotocolo = @not_dthoraprotocolo   where not_codigo = " + txtControle.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand cmd = new SqlCommand(updateNota, con);
            cmd.CommandType = CommandType.Text;
            //cmd.Parameters.Add("@not_chave", SqlDbType.NVarChar).Value = chaveNfe;
            //cmd.Parameters.Add("@not_protocolo", SqlDbType.NVarChar).Value = protocolo;
            //cmd.Parameters.Add("@not_recibo", SqlDbType.NVarChar).Value = recibo;
            //cmd.Parameters.Add("@not_statusnota", SqlDbType.NVarChar).Value = statusNota;
            //cmd.Parameters.Add("@not_dthoraprotocolo", SqlDbType.NVarChar).Value = dataHoraProtocolo;            
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    u.messageboxSucesso();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: Erro Ao Gravar no banco de dados " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            Unovo();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormNotaFiscal_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeusFormularios.FrmNotaFiscal = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaClientes());
            if (radioButton1.Checked)
            {
                dv.RowFilter = "cod_cliente =" + textBox1.Text;                
            }
            if (radioButtonFantasia.Checked)
            {
                dv.RowFilter = "n_cliente like'%" + textBox4.Text + "%'";
            }
            fornecedoresDataGridView.DataSource = dv;
            
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void FormNotaFiscal_Load(object sender, EventArgs e)
        {
            mskDtVenda.Text = DateTime.Now.ToShortDateString();
        }

        private void btnPProduto_Click(object sender, EventArgs e)
        {
            panelPProdutos.Visible = true;
        }

        private void fornecedoresDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panel1.Visible = false;
                DataGridViewRow row = this.fornecedoresDataGridView.Rows[e.RowIndex];
                txtNomeFornecedor.Text = row.Cells["n_cliente"].Value.ToString();
                txtcodFornecedor.Text = row.Cells["cod_cliente"].Value.ToString();

            }
        }

        private void txtcodFornecedor_TextChanged(object sender, EventArgs e)
        {
            if (txtcodFornecedor.Text == null)
            {
                btnPCliente.Focus();

            }
            else
            {
                string buscaCliente = "Select n_cliente From clientes where cod_cliente = '" + txtcodFornecedor.Text.Trim() + "'";

                SqlConnection con = new SqlConnection();
                con.ConnectionString = utils.ConexaoDb();
                SqlCommand sqlCommand = new SqlCommand(buscaCliente, con);

                con.Open();
                SqlDataReader dR = sqlCommand.ExecuteReader();

                if (dR.Read())
                {
                    txtNomeFornecedor.Text = dR[0].ToString();
                }

                con.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(DataContext.CarregaCfop());
            if (radioButton5.Checked)
            {
                dv.RowFilter = "cfo_codigo" + textBox2.Text ;
            }
            if (radioButton2.Checked)
            {
                dv.RowFilter = "cfo_descricao like '%" + textBox1.Text + "%'";
            }            
            dataGridView2.DataSource = dv;
          
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panel2.Visible = false;
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                txtCodCfod.Text = row.Cells["cfo_codigo"].Value.ToString();
                txtDescCfop.Text = row.Cells["cfo_descricao"].Value.ToString();

            }
        }

        private void produtosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panelPProdutos.Visible = false;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtCodProduto.Text = row.Cells["cod_produto"].Value.ToString();
                txtNomeProduto.Text = row.Cells["des_produto"].Value.ToString();
                txtQuantidade.Text = "1";
                txtValor.Text = row.Cells["vl_produto"].Value.ToString();                
            }
        }
    }
}
