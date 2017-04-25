using System;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApplication3
{
    public class utils
    {
        public void LimparTxt(Control controles)
        {

            foreach (Control ctl in controles.Controls)
            {
                if (ctl is TextBox) ctl.Text = "";
                if (ctl is MaskedTextBox) ctl.Text = "";
            }

        }
        public void FormataCampos(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsLetter(e.KeyChar))

                e.Handled = true;
            if (e.KeyChar == ','
            && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }
        //ControlesTextBox
        public void limparTextBoxes(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = String.Empty;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    limparTextBoxes(ctrl);
                }
            }
        }
        public void limparCombo(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).Text = String.Empty;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    limparCombo(ctrl);
                }
            }
        }
        public void EnableTxt(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Enabled = true;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    EnableTxt(ctrl);
                }
            }
        }
        public void DisableTxt(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Enabled = false;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    DisableTxt(ctrl);
                }
            }
        }
        //ControlesTextBox

        //ControlesComboBox
        public void DisableCombo(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).Enabled = false;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    DisableCombo(ctrl);
                }
            }
        }
        public void EnableCombo(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).Enabled = true;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    EnableCombo(ctrl);
                }
            }
        }
        //ControlesComboBox

        //ControlesMaskedTextBox
        public void limparMTextBoxes(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is MaskedTextBox)
                {
                    ((MaskedTextBox)ctrl).Text = String.Empty;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    limparMTextBoxes(ctrl);
                }
            }
        }

        public void EnableMasked(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is MaskedTextBox)
                {
                    ((MaskedTextBox)ctrl).Enabled = true;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    EnableMasked(ctrl);
                }
            }
        }

        public void DisableMasked(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is MaskedTextBox)
                {
                    ((MaskedTextBox)ctrl).Enabled = false;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    DisableMasked(ctrl);
                }
            }
        }
        //ControlesMaskedTextBox

        //ControlesDataGridView
        public void EnableDataGrid(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is DataGrid)
                {
                    ((DataGrid)ctrl).Enabled = true;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    EnableDataGrid(ctrl);
                }
            }
        }

        public void DisableDataGrid(Control controles)
        {

            foreach (Control ctrl in controles.Controls)
            {

                if (ctrl is DataGrid)
                {
                    ((DataGrid)ctrl).Enabled = false;

                }
                else if (ctrl.Controls.Count > 0)
                {
                    DisableDataGrid(ctrl);
                }
            }
        }
        //ControlesDataGridView



        //ControlesMessageBoxPadrão
        public void messageboxCamposObrigatorio()
        {
            MessageBox.Show("Os campos marcado em amarelo são obrigatórios !", "Mensagem o Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void messageboxSucesso()
        {
            MessageBox.Show("Operação efetuada com sucesso !", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void messageboxErro(string erro)
        {
            MessageBox.Show("Erro: Erro Ao Gravar no banco de dados ");
        }
        public void messageboxDataInv()
        {
            MessageBox.Show("Data inválida", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void PeguntaExcluir()
        {
            MessageBox.Show("Deseja realmente excluir esse registro", "Mensagem do Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public string RCE(string text)
        {
            string retorno;

             retorno = System.Text.RegularExpressions.Regex.Replace(text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);

            return retorno;
        }
        public string RLCE(string text)
        {
            string retorno;

            retorno = System.Text.RegularExpressions.Regex.Replace(text, @"[^a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);

            return retorno;
        }



    }
}


