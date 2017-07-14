using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using NFeEletronica.Contexto;
using NFeEletronica.NotaFiscal;
using NFeEletronica.Certificado;
using Aplicativo.ClassesEntidades;
using System.Linq;

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
                {
                    mskDtVenda.Focus();
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            decimal totalIpi = 0;
            decimal totalICms = 0;
            decimal totalpis = 0;
            decimal totalCofins = 0;

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
                
                string ultimoReg = "Select not_codigo From nota where not_codigo = (Select MAX(not_numero) From nota)";               
                
                SqlConnection con1 = new SqlConnection();
                con.ConnectionString = utils.ConexaoDb();
                SqlCommand cmd2 = new SqlCommand(ultimoReg, con1);
                
                con.Open();
                SqlDataReader dR = cmd2.ExecuteReader();
                
                if (dR.Read())
                {
                    txtNunNota.Text = 1 + dR[0].ToString();
                }
                con.Close();
                DataContext db = new DataContext();
                var pessoa = db.Clientes.Find(Convert.ToInt32(txtcodFornecedor.Text.Trim()));
                var CidadeEstado = db.Cidades.Find(pessoa.CidadeCodigo);
                
                nota.ide.nNF = txtNunNota.Text;
                nota.ide.dEmi = mskDtVenda.Text;
                nota.ide.tpNF = "1"; //normal contingencia
                nota.ide.cMunFG = CidadeEstado.Ibge;
                nota.ide.tpImp = "1";
                nota.ide.tpEmis = "1";
                nota.ide.cDV = "0";                
                nota.ide.idDest = "1";
                nota.ide.indFinal = "0";
                nota.ide.indPres = "0";
                nota.ide.tpAmb = "2";
                nota.ide.finNFe = finalidadeNota;
                nota.ide.procEmi = "3";// soft utilizado
                //
                
                var filial = db.Filiais.Find(DataContext.fil_codigo);
                nota.emit.CNPJ = filial.CpfCnpj;
                nota.emit.xNome = filial.Razao;
                nota.emit.xLgr = filial.Endereco;
                nota.emit.nro = filial.Numero;
                nota.emit.xBairro = filial.Bairro;

                var cidade = db.Cidades.Find(filial.CidadeCodigo);
                nota.emit.cMun = cidade.Ibge;
                nota.emit.xMun = cidade.Descricao;
                nota.emit.UF = cidade.UF;
                nota.emit.CEP = filial.Cep;
                nota.emit.cPais = "1058";
                nota.emit.xPais = "Brasil";
                nota.emit.fone = filial.Telefone;
                nota.emit.IE = filial.IE;
                nota.emit.CRT = "1";

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
                        var produtoIncluir = db.Produtos.Find(notaProduto.cProd);

                        notaProduto.cEAN = produtoIncluir.EAN; 
                        notaProduto.xProd = produtoIncluir.Descricao; 
                        notaProduto.NCM = produtoIncluir.NCM; 
                        notaProduto.CFOP = Convert.ToString(produtoIncluir.CFOP); 
                        notaProduto.uCom = produtoIncluir.UnidadeMedida; 
                        notaProduto.qCom = row.Cells["QUANTIDADE"].Value.ToString(); 
                        notaProduto.vUnCom = row.Cells["VALOR UN"].Value.ToString(); 
                        notaProduto.vProd = row.Cells["TOTAL"].Value.ToString(); 
                        notaProduto.cEANTrib = produtoIncluir.EAN;
                        notaProduto.uTrib = produtoIncluir.UnidadeMedida;
                        notaProduto.qTrib = notaProduto.qCom;
                        notaProduto.vUnTrib = notaProduto.vUnCom;
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
                if (nota.emit.CRT == "1")
                {
                    nota.total.vBC = "0.00";
                }
                else
                {
                    nota.total.vBC = Convert.ToString(totaldaNotacomdesconto);
                }
                    
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
                u.messageboxErro(ex.ToString());
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
                DataContext db = new DataContext();
                var pessoa = db.Clientes.Find(Convert.ToInt32(txtcodFornecedor.Text.Trim()));
                var CidadeEstado = db.Cidades.Find(pessoa.CidadeCodigo);
                txtCIDESt.Text = CidadeEstado.Descricao;
                txtUf.Text = CidadeEstado.UF;
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
                DataGridViewRow row = this.produtosDataGridView.Rows[e.RowIndex];
                txtCodProduto.Text = row.Cells["cod_produto"].Value.ToString();
                txtNomeProduto.Text = row.Cells["des_produto"].Value.ToString();
                txtQuantidade.Text = "1";
                txtValor.Text = row.Cells["vl_produto"].Value.ToString();                
            }
        }
        
        private void btnInsProduto_Click(object sender, EventArgs e)
        {
            MinhaNotaProduto notaProduto = new MinhaNotaProduto();
            notaProduto.Quantidade = Convert.ToDecimal(txtQuantidade.Text.Trim());
            notaProduto.TotalProduto = Convert.ToDecimal(txtVTotal.Text.Trim());
            notaProduto.ValorUn = Convert.ToDecimal(txtValor.Text.Trim());
            notaProduto.ProdutoID = Convert.ToInt32(txtCodProduto.Text.Trim());
            notaProduto.NotaID = Convert.ToInt32(txtControle.Text.Trim());

            DataContext db = new DataContext();
            var produto = db.Produtos.Find(notaProduto.ProdutoID);
            string insProduto = "INSERT INTO NOTAPRODUTO(NOT_CODIGO, NOP_CODIGO, NOP_TIPO, PRO_CODIGO, NOP_DESCRICAO, NOP_QTDE, NOP_VALOR, NOP_TOTAL,"
            + "NOP_ICMSBASE, NOP_ICMSALIQ, NOP_ICMSVALOR, NOP_PERCDESC , NOP_CANCELADO, CFO_CODIGO, NOP_IIBASE, NOP_IIVALOR, NOP_IIIOF, NOP_IIDESPADUAN,"
            + "NOP_ICMSCST, NOP_SUBTOTAL, NOP_ICMSSTBASE, NOP_ICMSSTALIQ, NOP_ICMSSTMVA, NOP_ICMSSTVALOR, NOP_PISCST, NOP_PISBASE, NOP_PISALIQ, NOP_PISVALOR,"
            + "NOP_COFINSCST, NOP_COFINSBASE, NOP_COFINSALIQ, NOP_COFINSVALOR, NOP_CSOSN, NOP_IPIBASE , NOP_IPIALIQ, NOP_IPIVALOR, NOP_AVULSO, FIL_CODIGO,"
            + "NOP_DATA, NOP_IPICST, NOP_TOTIMPOSTO, NOP_DIFAL_VBCUFDEST, NOP_DIFAL_PFCPUFDEST, NOP_DIFAL_PICMSUFDEST, NOP_DIFAL_PICMSINTER, "
            + "NOP_DIFAL_PICMSINTERPART, NOP_DIFAL_VFCPUFDEST, NOP_DIFAL_VICMSUFDEST, NOP_DIFAL_VICMSUFREMET)"
            + "VALUES(@NOT_CODIGO, @NOP_CODIGO, @NOP_TIPO, @PRO_CODIGO, @NOP_DESCRICAO, @NOP_QTDE, @NOP_VALOR, @NOP_TOTAL,"
            + "@NOP_ICMSBASE, @NOP_ICMSALIQ, @NOP_ICMSVALOR, @NOP_PERCDESC , @NOP_CANCELADO, @CFO_CODIGO, @NOP_IIBASE, @NOP_IIVALOR, @NOP_IIIOF, @NOP_IIDESPADUAN,"
            + "@NOP_ICMSCST, @NOP_SUBTOTAL, @NOP_ICMSSTBASE, @NOP_ICMSSTALIQ, @NOP_ICMSSTMVA, @NOP_ICMSSTVALOR, @NOP_PISCST, @NOP_PISBASE, @NOP_PISALIQ, @NOP_PISVALOR,"
            + "@NOP_COFINSCST, @NOP_COFINSBASE, @NOP_COFINSALIQ, @NOP_COFINSVALOR, @NOP_CSOSN, @NOP_IPIBASE , @NOP_IPIALIQ, @NOP_IPIVALOR, @NOP_AVULSO, @FIL_CODIGO,"
            + "@NOP_DATA, @NOP_IPICST, @NOP_TOTIMPOSTO, @NOP_DIFAL_VBCUFDEST, @NOP_DIFAL_PFCPUFDEST, @NOP_DIFAL_PICMSUFDEST, @NOP_DIFAL_PICMSINTER, "
            + "@NOP_DIFAL_PICMSINTERPART, @NOP_DIFAL_VFCPUFDEST, @NOP_DIFAL_VICMSUFDEST, @NOP_DIFAL_VICMSUFREMET);";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = utils.ConexaoDb();
            SqlCommand cmd = new SqlCommand(insProduto, con);
            cmd.Parameters.Add("@NOT_CODIGO", SqlDbType.Int).Value = notaProduto.NotaID;
            cmd.Parameters.Add("@PRO_CODIGO", SqlDbType.Int).Value = notaProduto.ProdutoID;
            cmd.Parameters.Add("@NOP_VALOR", SqlDbType.Decimal).Value = notaProduto.ValorUn;
            cmd.Parameters.Add("@NOP_QTDE", SqlDbType.Decimal).Value = notaProduto.Quantidade;
            cmd.Parameters.Add("@NOP_TOTAL", SqlDbType.Decimal).Value = notaProduto.TotalProduto;
            cmd.Parameters.Add("@NOP_CODIGO", SqlDbType.Int).Value = notaProduto.ID;
            cmd.Parameters.Add("@nop_tipo", SqlDbType.Int).Value = notaProduto.Tipo;
            cmd.Parameters.Add("@nop_descricao", SqlDbType.NVarChar).Value = produto.Descricao;
            var filial = db.Filiais.Find(Convert.ToInt32(textBox3.Text.Trim()));
            if(filial.Crt == "1")
            {
                cmd.Parameters.Add("@nop_icmsbase", SqlDbType.Decimal).Value = notaProduto.ValorUn;
            }
            else
            {
                cmd.Parameters.Add("@nop_icmsbase", SqlDbType.Decimal).Value = 0;
            }
            if(filial.Crt == "1")
            {
                cmd.Parameters.Add("@nop_icmsaliq", SqlDbType.Decimal).Value = produto.AliqIcms;
            }
            else
            {
                cmd.Parameters.Add("@nop_icmsaliq", SqlDbType.Decimal).Value = produto.AliqIcms;
            }

            decimal? totIcms = (((produto.AliqIcms) / 100) * (notaProduto.ValorUn));
            if (filial.Crt == "1")
            {
                cmd.Parameters.Add("@NOP_ICMSVALOR", SqlDbType.Decimal).Value = 0;
            }
            else
            {
                cmd.Parameters.Add("@NOP_ICMSVALOR", SqlDbType.Decimal).Value = totIcms;
            }
            
            cmd.Parameters.Add("@nop_percdesc", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@nop_cancelado", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@cfo_codigo", SqlDbType.Int).Value = produto.CFOP;
            cmd.Parameters.Add("@NOP_IIBASE", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_IIVALOR", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_IIIOF", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_IIDESPADUAN", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_ICMSCST", SqlDbType.Decimal).Value = produto.CstICMS;                      
            cmd.Parameters.Add("@NOP_ICMSSTBASE", SqlDbType.Decimal).Value = notaProduto.ValorUn;
            cmd.Parameters.Add("@NOP_ICMSSTALIQ", SqlDbType.Decimal).Value = produto.IcmsStAliqInter;
            cmd.Parameters.Add("@NOP_ICMSSTMVA", SqlDbType.Decimal).Value = produto.MVA;
            cmd.Parameters.Add("@NOP_ICMSSTVALOR", SqlDbType.Decimal).Value = notaProduto.ValorUn * produto.IcmsStAliqInter;
            cmd.Parameters.Add("@NOP_PISCST", SqlDbType.NVarChar).Value = produto.CstPIS;
            cmd.Parameters.Add("@NOP_PISBASE", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_PISALIQ", SqlDbType.Decimal).Value = produto.AliqPis;
            cmd.Parameters.Add("@NOP_PISVALOR", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_COFINSCST", SqlDbType.NVarChar).Value = produto.CstCOFINS;
            cmd.Parameters.Add("@NOP_COFINSBASE", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_COFINSALIQ", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_COFINSVALOR", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_CSOSN", SqlDbType.NVarChar).Value = produto.CstICMS;
            if(filial.Crt == "1")
            {
                cmd.Parameters.Add("@NOP_IPIBASE", SqlDbType.Decimal).Value = 0;
            }
            else
            {
                cmd.Parameters.Add("@NOP_IPIBASE", SqlDbType.Decimal).Value = notaProduto.ValorUn;
            }
            cmd.Parameters.Add("@NOP_IPIALIQ", SqlDbType.Decimal).Value = produto.AliqIpi;

            decimal? totIpi = ((notaProduto.ValorUn) * ((produto.AliqIpi) / 100));
            if (filial.Crt == "1")
            {
                cmd.Parameters.Add("@NOP_IPIVALOR", SqlDbType.Decimal).Value = 0;
            }
            else
            {
                cmd.Parameters.Add("@NOP_IPIVALOR", SqlDbType.Decimal).Value = totIpi;
            }
            cmd.Parameters.Add("@NOP_AVULSO", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@FIL_CODIGO", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text.Trim());
            cmd.Parameters.Add("@NOP_DATA", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
            cmd.Parameters.Add("@NOP_IPICST", SqlDbType.NVarChar).Value = produto.CstIPI;
            cmd.Parameters.Add("@NOP_DIFAL_VBCUFDEST", SqlDbType.Decimal).Value = 0;
            var cadastro = db.Clientes.Find(Convert.ToInt32(txtcodFornecedor.Text.Trim()));
            var cidade = db.Cidades.Find(cadastro.CidadeCodigo);

            if (cidade.UF.Contains("{SP} {PR} {RJ} {MG} {SC} {RS}"))
            {
                cmd.Parameters.Add("@NOP_DIFAL_PICMSINTER", SqlDbType.Decimal).Value = 12;
            }
            else if (cidade.UF.Contains("{MT} {MS} {GO} {DF} {AC} {AM} {PA} {AL} {PE} {PB} {BA} {ES} {AC} {SE} {RR} {RO} {PI} {AP} {MA} {TO} {RN} {CE}"))
            {
                cmd.Parameters.Add("@NOP_DIFAL_PICMSINTER", SqlDbType.Decimal).Value = 7;
            }
            else if(produto.OrigemDoProduto == 1 || produto.OrigemDoProduto == 2 || produto.OrigemDoProduto == 6 || produto.OrigemDoProduto == 7)
            {
                cmd.Parameters.Add("@NOP_DIFAL_PICMSINTER", SqlDbType.Decimal).Value = 4;
            }
            cmd.Parameters.Add("@NOP_DIFAL_PFCPUFDEST", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_DIFAL_PICMSUFDEST", SqlDbType.Decimal).Value = 0;
            DateTime data = DateTime.Now.Date;
            DateTime Data2018 = Convert.ToDateTime("01/01/2018");
            DateTime Data2019 = Convert.ToDateTime("01/01/2019");
            if (data > Data2018 && data < Data2019)
            {
                cmd.Parameters.Add("@NOP_DIFAL_PICMSINTERPART", SqlDbType.Decimal).Value = 60;                
            }
            else if(data < Data2018)
            {
                cmd.Parameters.Add("@NOP_DIFAL_PICMSINTERPART", SqlDbType.Decimal).Value = 80;
            }
            else if (data > Data2019)
            {
                cmd.Parameters.Add("@NOP_DIFAL_PICMSINTERPART", SqlDbType.Decimal).Value = 100;
            }
            cmd.Parameters.Add("@NOP_DIFAL_VFCPUFDEST", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_DIFAL_VICMSUFDEST", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@NOP_DIFAL_VICMSUFREMET", SqlDbType.Decimal).Value = 0;

            if (filial.Crt == "1")
            {
                cmd.Parameters.Add("@NOP_TOTIMPOSTO", SqlDbType.Decimal).Value = 0;
            }
            else
            {
                cmd.Parameters.Add("@NOP_TOTIMPOSTO", SqlDbType.Decimal).Value = totIpi + totIcms;
            }            

            if (filial.Crt == "1")
            {
                cmd.Parameters.Add("@NOP_SUBTOTAL", SqlDbType.Decimal).Value = (notaProduto.ValorUn * notaProduto.Quantidade);
            }
            else
            {
                cmd.Parameters.Add("@NOP_SUBTOTAL", SqlDbType.Decimal).Value = (notaProduto.ValorUn * notaProduto.Quantidade) + totIpi + totIcms;
            }                    
            
            cmd.CommandType = CommandType.Text;            
            con.Open();
            try
            {
                if (produtosDataGridView.Rows.Cast<DataGridViewRow>().Any(row => row.Cells[0].Value.Equals(txtCodProduto.Text.Trim())))
                {
                    MessageBox.Show("Erro: Produto já inserido ", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        dataGridView1.Rows.Add(txtCodProduto.Text, txtNomeProduto.Text, txtQuantidade.Text, txtValor.Text,  txtVTotal.Text);
                        
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
    }
}
