using System;
using System.Windows.Forms;
using Aplicativo.ClassesEntidades;

namespace Aplicativo
{
    public partial class FormPrincipal : Form
    {
        Usuario user = new Usuario();
        public FormPrincipal()
        {
            InitializeComponent();

        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmClientes == null)
            {
                MeusFormularios.FrmClientes = new FormClientes();
            }
            MeusFormularios.FrmClientes.Show();
            MeusFormularios.FrmClientes.Focus();
        }

        private void fORNECEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmFornecedores == null)
                MeusFormularios.FrmFornecedores = new FormFornecedores();

            MeusFormularios.FrmFornecedores.Show();
            MeusFormularios.FrmFornecedores.Focus();
        }

        private void pRODUTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmProdutos == null)
                MeusFormularios.FrmProdutos = new FormProdutos();

            MeusFormularios.FrmProdutos.Show();
            MeusFormularios.FrmProdutos.Focus();
        }

        private void cIDADESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmCidades == null)
                MeusFormularios.FrmCidades = new FormCidades();

            MeusFormularios.FrmCidades.Show();
            MeusFormularios.FrmCidades.Focus();                
        }

        private void vENDASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmPedido == null)
                MeusFormularios.FrmPedido = new FormPedido();

           MeusFormularios.FrmPedido.Show();
           MeusFormularios.FrmPedido.Focus();
        }
        
        private void eNTRADADEPRODUTOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmEntProdutos == null)
                MeusFormularios.FrmEntProdutos = new FormEntProdutos();

            MeusFormularios.FrmEntProdutos.Show();
            MeusFormularios.FrmEntProdutos.Focus();
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();             
        }
               
        private void fechaForm(object sender, FormClosingEventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Tem certeza que deseja sair?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (escolha == DialogResult.No)
                e.Cancel = true;
        }
        
        private void cOLABORADORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmFuncionarios == null)
                MeusFormularios.FrmFuncionarios = new FormFuncionarios();

            MeusFormularios.FrmFuncionarios.Show();
            MeusFormularios.FrmFuncionarios.Focus();
        }

        private void pROCEDIMENTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmCadProcedimento == null)
                MeusFormularios.FrmCadProcedimento = new FormCadProcedimento();

            MeusFormularios.FrmCadProcedimento.Show();
            MeusFormularios.FrmCadProcedimento.Focus();
        }
        
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if (FormLogin.usuarioLogado != "admin")
            {
                if (user.AcessoVenda())
                {
                    vENDASToolStripMenuItem.Enabled = true;
                }
                else
                {
                    vENDASToolStripMenuItem.Enabled = false;
                }

                if (user.AcessoCompra())
                {
                    eNTRADADEPRODUTOSToolStripMenuItem .Enabled = true;
                }
                else
                {
                    eNTRADADEPRODUTOSToolStripMenuItem.Enabled = false;
                }

                if (user.AcessoPessoa())
                {
                    fORNECEDORESToolStripMenuItem.Enabled = true;
                    cLIENTESToolStripMenuItem.Enabled = true;
                    fUNCIONÁRIOSToolStripMenuItem.Enabled = true;
                }
                else
                {
                    fUNCIONÁRIOSToolStripMenuItem.Enabled = false;
                    fORNECEDORESToolStripMenuItem.Enabled = false;
                    cLIENTESToolStripMenuItem.Enabled = false;
                }

                if (user.AcessoFiscal())
                {
                    nOTAFISCALELETRÔNICAToolStripMenuItem.Enabled = true;
                    cFOPToolStripMenuItem.Enabled = true;
                }
                else
                {
                    nOTAFISCALELETRÔNICAToolStripMenuItem.Enabled = false;
                    cFOPToolStripMenuItem.Enabled = false;
                }

                if (user.AcessoProduto())
                {
                    pRODUTOSToolStripMenuItem.Enabled = true;
                }
                else
                {
                    pRODUTOSToolStripMenuItem.Enabled = false;
                }

                if (user.AcessoUsuario())
                {
                    uSUÁRIOSToolStripMenuItem.Enabled = true;
                }
                else
                {
                    uSUÁRIOSToolStripMenuItem.Enabled = false;
                }

                if (user.AcessoRelatorio())
                {
                    rELATÓRIOSToolStripMenuItem.Enabled = true;
                }
                else
                {
                    rELATÓRIOSToolStripMenuItem.Enabled = false;
                }
            }
        }
        
        private void aGENDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmAgenda == null)
                MeusFormularios.FrmAgenda = new FormAgenda();

            MeusFormularios.FrmAgenda.Show();
            MeusFormularios.FrmAgenda.Focus();
        }

        private void fUNCIONÁRIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmFuncionarios == null)
                MeusFormularios.FrmFuncionarios = new FormFuncionarios();

            MeusFormularios.FrmFuncionarios.Show();
            MeusFormularios.FrmFuncionarios.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel2.Text = DateTime.Now.ToShortTimeString();
        }        
     
        private void cLIENTESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form ChamarelCli = new FrmRelCadCli();
            ChamarelCli.ShowDialog();
        }

        private void lUCRATIVIDADEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form chamaRel = new relCadForn();
            chamaRel.ShowDialog();
        }

        private void uSUÁRIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.formCadUsuarios == null)
                MeusFormularios.formCadUsuarios = new frmCadUsuario();

            MeusFormularios.formCadUsuarios.Show();
            MeusFormularios.formCadUsuarios.Focus();
        }

        private void cONTASÀPAGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmCpagar == null)
                MeusFormularios.FrmCpagar = new formCpagar();

            MeusFormularios.FrmCpagar.Show();
            MeusFormularios.FrmCpagar.Focus();
        }

        private void cONTASÀPAGARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmCpagar == null)
                MeusFormularios.FrmCpagar = new formCpagar();

            MeusFormularios.FrmCpagar.Show();
            MeusFormularios.FrmCpagar.Focus();
        }

        private void cONTASÀRECEBERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmCreceber == null)
                MeusFormularios.FrmCreceber = new FormCreceber();

            MeusFormularios.FrmCreceber.Show();
            MeusFormularios.FrmCreceber.Focus();
        }

        private void cONTASÀRECEBERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.formRlcreceber == null)
                MeusFormularios.formRlcreceber = new FrmRelCreceber();

            MeusFormularios.formRlcreceber.Show();
            MeusFormularios.formRlcreceber.Focus();
        }

        private void cONTASÀPAGARToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.formRelCpagar == null)
                MeusFormularios.formRelCpagar = new FrmRelCpagar();

            MeusFormularios.formRelCpagar.Show();
            MeusFormularios.formRelCpagar.Focus();
        }     

        private void eSTOQUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.formRelEstproduto == null)
                MeusFormularios.formRelEstproduto = new FrmRelEstoque();

            MeusFormularios.formRelEstproduto.Show();
            MeusFormularios.formRelEstproduto.Focus();
        }

        private void vENDASToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.formRelVendas == null)
                MeusFormularios.formRelVendas = new FrmRelVendas();

            MeusFormularios.formRelVendas.Show();
            MeusFormularios.formRelVendas.Focus();
        }

        private void cFOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmCadCfop == null)
                MeusFormularios.FrmCadCfop = new FormCadCFOP();

            MeusFormularios.FrmCadCfop.Show();
            MeusFormularios.FrmCadCfop.Focus();
        }

        private void nOTAFISCALELETRÔNICAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.FrmNotaFiscal == null)
                MeusFormularios.FrmNotaFiscal = new FormNotaFiscal();

            MeusFormularios.FrmNotaFiscal.Show();
            MeusFormularios.FrmNotaFiscal.Focus();
        }

        private void uSUÁRIOSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MeusFormularios.formCadUsuarios == null)
                MeusFormularios.formCadUsuarios = new frmCadUsuario();

            MeusFormularios.formCadUsuarios.Show();
            MeusFormularios.formCadUsuarios.Focus();
        }

        private void oRDEMDESERVIÇOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MeusFormularios.Formvenda == null)
                MeusFormularios.Formvenda = new FrmVenda();

            MeusFormularios.Formvenda.Show();
            MeusFormularios.Formvenda.Focus();
        }
    }
}
