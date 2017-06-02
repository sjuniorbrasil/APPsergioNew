namespace Aplicativo
{
    partial class frmCadUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelPesquisa = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.UserDataGridView = new System.Windows.Forms.DataGridView();
            this.usuariosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Aplicativo.DataSet1();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkFiscal = new System.Windows.Forms.CheckBox();
            this.checkCompra = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.checkProduto = new System.Windows.Forms.CheckBox();
            this.checkRelatório = new System.Windows.Forms.CheckBox();
            this.checkVenda = new System.Windows.Forms.CheckBox();
            this.checkUsuario = new System.Windows.Forms.CheckBox();
            this.checkPessoa = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnChamaPesquisa = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.buttonSaiCadClientes = new System.Windows.Forms.Button();
            this.buttonCancelaCadcliente = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuariosTableAdapter = new Aplicativo.DataSet1TableAdapters.usuariosTableAdapter();
            this.usucodigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usunomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ususenhaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usucadClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usucadFornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usucadProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usucadFiscalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usucompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuvendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usurelatoriosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panelPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelPesquisa);
            this.groupBox1.Controls.Add(this.checkFiscal);
            this.groupBox1.Controls.Add(this.checkCompra);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.checkProduto);
            this.groupBox1.Controls.Add(this.checkRelatório);
            this.groupBox1.Controls.Add(this.checkVenda);
            this.groupBox1.Controls.Add(this.checkUsuario);
            this.groupBox1.Controls.Add(this.checkPessoa);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 293);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panelPesquisa
            // 
            this.panelPesquisa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPesquisa.Controls.Add(this.label4);
            this.panelPesquisa.Controls.Add(this.button2);
            this.panelPesquisa.Controls.Add(this.button1);
            this.panelPesquisa.Controls.Add(this.UserDataGridView);
            this.panelPesquisa.Controls.Add(this.textBox3);
            this.panelPesquisa.Location = new System.Drawing.Point(76, 61);
            this.panelPesquisa.Name = "panelPesquisa";
            this.panelPesquisa.Size = new System.Drawing.Size(476, 212);
            this.panelPesquisa.TabIndex = 21;
            this.panelPesquisa.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 31);
            this.label4.TabIndex = 28;
            this.label4.Text = "USUÁRIO";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(405, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 31);
            this.button2.TabIndex = 27;
            this.button2.Text = "Sair";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 31);
            this.button1.TabIndex = 24;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserDataGridView
            // 
            this.UserDataGridView.AllowUserToAddRows = false;
            this.UserDataGridView.AllowUserToDeleteRows = false;
            this.UserDataGridView.AutoGenerateColumns = false;
            this.UserDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usucodigoDataGridViewTextBoxColumn,
            this.usunomeDataGridViewTextBoxColumn,
            this.ususenhaDataGridViewTextBoxColumn,
            this.usucadClienteDataGridViewTextBoxColumn,
            this.usucadFornecedorDataGridViewTextBoxColumn,
            this.usucadProdutoDataGridViewTextBoxColumn,
            this.usucadFiscalDataGridViewTextBoxColumn,
            this.usucompraDataGridViewTextBoxColumn,
            this.usuvendaDataGridViewTextBoxColumn,
            this.usurelatoriosDataGridViewTextBoxColumn});
            this.UserDataGridView.DataSource = this.usuariosBindingSource1;
            this.UserDataGridView.Location = new System.Drawing.Point(3, 34);
            this.UserDataGridView.Name = "UserDataGridView";
            this.UserDataGridView.ReadOnly = true;
            this.UserDataGridView.Size = new System.Drawing.Size(470, 129);
            this.UserDataGridView.TabIndex = 22;
            this.UserDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cfopDataGridView_CellClick);
            // 
            // usuariosBindingSource1
            // 
            this.usuariosBindingSource1.DataMember = "usuarios";
            this.usuariosBindingSource1.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(9, 182);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(314, 20);
            this.textBox3.TabIndex = 23;
            // 
            // checkFiscal
            // 
            this.checkFiscal.AutoSize = true;
            this.checkFiscal.Location = new System.Drawing.Point(6, 190);
            this.checkFiscal.Name = "checkFiscal";
            this.checkFiscal.Size = new System.Drawing.Size(91, 17);
            this.checkFiscal.TabIndex = 20;
            this.checkFiscal.Text = "Módulo Fiscal";
            this.checkFiscal.UseVisualStyleBackColor = true;
            // 
            // checkCompra
            // 
            this.checkCompra.AutoSize = true;
            this.checkCompra.Location = new System.Drawing.Point(8, 121);
            this.checkCompra.Name = "checkCompra";
            this.checkCompra.Size = new System.Drawing.Size(67, 17);
            this.checkCompra.TabIndex = 19;
            this.checkCompra.Text = "Compras";
            this.checkCompra.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Controle";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(61, 13);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(44, 20);
            this.txtCodigo.TabIndex = 17;
            // 
            // checkProduto
            // 
            this.checkProduto.AutoSize = true;
            this.checkProduto.Location = new System.Drawing.Point(8, 75);
            this.checkProduto.Name = "checkProduto";
            this.checkProduto.Size = new System.Drawing.Size(128, 17);
            this.checkProduto.TabIndex = 15;
            this.checkProduto.Text = "Cadastro de Produtos";
            this.checkProduto.UseVisualStyleBackColor = true;
            // 
            // checkRelatório
            // 
            this.checkRelatório.AutoSize = true;
            this.checkRelatório.Location = new System.Drawing.Point(8, 144);
            this.checkRelatório.Name = "checkRelatório";
            this.checkRelatório.Size = new System.Drawing.Size(73, 17);
            this.checkRelatório.TabIndex = 13;
            this.checkRelatório.Text = "Relatórios";
            this.checkRelatório.UseVisualStyleBackColor = true;
            // 
            // checkVenda
            // 
            this.checkVenda.AutoSize = true;
            this.checkVenda.Location = new System.Drawing.Point(8, 98);
            this.checkVenda.Name = "checkVenda";
            this.checkVenda.Size = new System.Drawing.Size(62, 17);
            this.checkVenda.TabIndex = 11;
            this.checkVenda.Text = "Vendas";
            this.checkVenda.UseVisualStyleBackColor = true;
            // 
            // checkUsuario
            // 
            this.checkUsuario.AutoSize = true;
            this.checkUsuario.Location = new System.Drawing.Point(7, 167);
            this.checkUsuario.Name = "checkUsuario";
            this.checkUsuario.Size = new System.Drawing.Size(127, 17);
            this.checkUsuario.TabIndex = 5;
            this.checkUsuario.Text = "Cadastro de Usuários";
            this.checkUsuario.UseVisualStyleBackColor = true;
            // 
            // checkPessoa
            // 
            this.checkPessoa.AutoSize = true;
            this.checkPessoa.Location = new System.Drawing.Point(8, 52);
            this.checkPessoa.Name = "checkPessoa";
            this.checkPessoa.Size = new System.Drawing.Size(126, 17);
            this.checkPessoa.TabIndex = 4;
            this.checkPessoa.Text = "Cadastro de Pessoas";
            this.checkPessoa.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(404, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '#';
            this.textBox2.Size = new System.Drawing.Size(173, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btnChamaPesquisa
            // 
            this.btnChamaPesquisa.Location = new System.Drawing.Point(171, 18);
            this.btnChamaPesquisa.Name = "btnChamaPesquisa";
            this.btnChamaPesquisa.Size = new System.Drawing.Size(77, 37);
            this.btnChamaPesquisa.TabIndex = 58;
            this.btnChamaPesquisa.Text = "Localizar";
            this.btnChamaPesquisa.UseVisualStyleBackColor = true;
            this.btnChamaPesquisa.Click += new System.EventHandler(this.btnChamaPesquisa_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(254, 18);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 37);
            this.btnExcluir.TabIndex = 57;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(335, 18);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 37);
            this.btnSalvar.TabIndex = 56;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(90, 18);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 37);
            this.btnNovo.TabIndex = 55;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // buttonSaiCadClientes
            // 
            this.buttonSaiCadClientes.Location = new System.Drawing.Point(497, 18);
            this.buttonSaiCadClientes.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.buttonSaiCadClientes.Name = "buttonSaiCadClientes";
            this.buttonSaiCadClientes.Size = new System.Drawing.Size(73, 37);
            this.buttonSaiCadClientes.TabIndex = 53;
            this.buttonSaiCadClientes.Text = "Sair";
            this.buttonSaiCadClientes.UseVisualStyleBackColor = true;
            this.buttonSaiCadClientes.Click += new System.EventHandler(this.buttonSaiCadClientes_Click);
            // 
            // buttonCancelaCadcliente
            // 
            this.buttonCancelaCadcliente.Location = new System.Drawing.Point(415, 18);
            this.buttonCancelaCadcliente.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.buttonCancelaCadcliente.Name = "buttonCancelaCadcliente";
            this.buttonCancelaCadcliente.Size = new System.Drawing.Size(73, 37);
            this.buttonCancelaCadcliente.TabIndex = 54;
            this.buttonCancelaCadcliente.Text = "Cancelar";
            this.buttonCancelaCadcliente.UseVisualStyleBackColor = true;
            this.buttonCancelaCadcliente.Click += new System.EventHandler(this.buttonCancelaCadcliente_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChamaPesquisa);
            this.groupBox2.Controls.Add(this.buttonCancelaCadcliente);
            this.groupBox2.Controls.Add(this.btnExcluir);
            this.groupBox2.Controls.Add(this.buttonSaiCadClientes);
            this.groupBox2.Controls.Add(this.btnSalvar);
            this.groupBox2.Controls.Add(this.btnNovo);
            this.groupBox2.Location = new System.Drawing.Point(3, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 65);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "usuarios";
            this.usuariosBindingSource.DataSource = this.dataSet1;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // usucodigoDataGridViewTextBoxColumn
            // 
            this.usucodigoDataGridViewTextBoxColumn.DataPropertyName = "usu_codigo";
            this.usucodigoDataGridViewTextBoxColumn.HeaderText = "usu_codigo";
            this.usucodigoDataGridViewTextBoxColumn.Name = "usucodigoDataGridViewTextBoxColumn";
            this.usucodigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.usucodigoDataGridViewTextBoxColumn.Visible = false;
            // 
            // usunomeDataGridViewTextBoxColumn
            // 
            this.usunomeDataGridViewTextBoxColumn.DataPropertyName = "usu_nome";
            this.usunomeDataGridViewTextBoxColumn.HeaderText = "NOME";
            this.usunomeDataGridViewTextBoxColumn.Name = "usunomeDataGridViewTextBoxColumn";
            this.usunomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.usunomeDataGridViewTextBoxColumn.Width = 420;
            // 
            // ususenhaDataGridViewTextBoxColumn
            // 
            this.ususenhaDataGridViewTextBoxColumn.DataPropertyName = "usu_senha";
            this.ususenhaDataGridViewTextBoxColumn.HeaderText = "usu_senha";
            this.ususenhaDataGridViewTextBoxColumn.Name = "ususenhaDataGridViewTextBoxColumn";
            this.ususenhaDataGridViewTextBoxColumn.ReadOnly = true;
            this.ususenhaDataGridViewTextBoxColumn.Visible = false;
            // 
            // usucadClienteDataGridViewTextBoxColumn
            // 
            this.usucadClienteDataGridViewTextBoxColumn.DataPropertyName = "usu_cadCliente";
            this.usucadClienteDataGridViewTextBoxColumn.HeaderText = "usu_cadCliente";
            this.usucadClienteDataGridViewTextBoxColumn.Name = "usucadClienteDataGridViewTextBoxColumn";
            this.usucadClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.usucadClienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // usucadFornecedorDataGridViewTextBoxColumn
            // 
            this.usucadFornecedorDataGridViewTextBoxColumn.DataPropertyName = "usu_cadFornecedor";
            this.usucadFornecedorDataGridViewTextBoxColumn.HeaderText = "usu_cadFornecedor";
            this.usucadFornecedorDataGridViewTextBoxColumn.Name = "usucadFornecedorDataGridViewTextBoxColumn";
            this.usucadFornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.usucadFornecedorDataGridViewTextBoxColumn.Visible = false;
            // 
            // usucadProdutoDataGridViewTextBoxColumn
            // 
            this.usucadProdutoDataGridViewTextBoxColumn.DataPropertyName = "usu_cadProduto";
            this.usucadProdutoDataGridViewTextBoxColumn.HeaderText = "usu_cadProduto";
            this.usucadProdutoDataGridViewTextBoxColumn.Name = "usucadProdutoDataGridViewTextBoxColumn";
            this.usucadProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.usucadProdutoDataGridViewTextBoxColumn.Visible = false;
            // 
            // usucadFiscalDataGridViewTextBoxColumn
            // 
            this.usucadFiscalDataGridViewTextBoxColumn.DataPropertyName = "usu_cadFiscal";
            this.usucadFiscalDataGridViewTextBoxColumn.HeaderText = "usu_cadFiscal";
            this.usucadFiscalDataGridViewTextBoxColumn.Name = "usucadFiscalDataGridViewTextBoxColumn";
            this.usucadFiscalDataGridViewTextBoxColumn.ReadOnly = true;
            this.usucadFiscalDataGridViewTextBoxColumn.Visible = false;
            // 
            // usucompraDataGridViewTextBoxColumn
            // 
            this.usucompraDataGridViewTextBoxColumn.DataPropertyName = "usu_compra";
            this.usucompraDataGridViewTextBoxColumn.HeaderText = "usu_compra";
            this.usucompraDataGridViewTextBoxColumn.Name = "usucompraDataGridViewTextBoxColumn";
            this.usucompraDataGridViewTextBoxColumn.ReadOnly = true;
            this.usucompraDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuvendaDataGridViewTextBoxColumn
            // 
            this.usuvendaDataGridViewTextBoxColumn.DataPropertyName = "usu_venda";
            this.usuvendaDataGridViewTextBoxColumn.HeaderText = "usu_venda";
            this.usuvendaDataGridViewTextBoxColumn.Name = "usuvendaDataGridViewTextBoxColumn";
            this.usuvendaDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuvendaDataGridViewTextBoxColumn.Visible = false;
            // 
            // usurelatoriosDataGridViewTextBoxColumn
            // 
            this.usurelatoriosDataGridViewTextBoxColumn.DataPropertyName = "usu_relatorios";
            this.usurelatoriosDataGridViewTextBoxColumn.HeaderText = "usu_relatorios";
            this.usurelatoriosDataGridViewTextBoxColumn.Name = "usurelatoriosDataGridViewTextBoxColumn";
            this.usurelatoriosDataGridViewTextBoxColumn.ReadOnly = true;
            this.usurelatoriosDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmCadUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 363);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCadUsuario";
            this.Text = "Cadastro de Usuários";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCadUsuario_FormClosed);
            this.Load += new System.EventHandler(this.frmCadUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelPesquisa.ResumeLayout(false);
            this.panelPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkRelatório;
        private System.Windows.Forms.CheckBox checkVenda;
        private System.Windows.Forms.CheckBox checkUsuario;
        private System.Windows.Forms.CheckBox checkPessoa;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnChamaPesquisa;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button buttonSaiCadClientes;
        private System.Windows.Forms.Button buttonCancelaCadcliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.CheckBox checkCompra;
        private System.Windows.Forms.CheckBox checkProduto;
        private System.Windows.Forms.CheckBox checkFiscal;
        private System.Windows.Forms.Panel panelPesquisa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private DataSet1TableAdapters.usuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.DataGridView UserDataGridView;
        private System.Windows.Forms.BindingSource usuariosBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usucodigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usunomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ususenhaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usucadClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usucadFornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usucadProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usucadFiscalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usucompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuvendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usurelatoriosDataGridViewTextBoxColumn;
    }
}