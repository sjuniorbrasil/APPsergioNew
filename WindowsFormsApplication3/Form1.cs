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
using System.Data.Entity;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataContext db = new DataContext();

        
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 2;

            }
            else
            {
                timer1.Enabled = false;
                FormPrincipal Inicianiza = new FormPrincipal();
                Inicianiza.Show();
                this.Visible = false;
                //try
                //{
                //    SqlConnection con = new SqlConnection();
                //    con.ConnectionString = Properties.Settings.Default.Ducaun;
                //    con.Open();
                //    Inicianiza.Show();
                //    this.Visible = false;
                //}
                //catch (Exception a)
                //{

                //    MessageBox.Show(a.Message, "Erro ao Conectar ao Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
            }
                  
           
        }

       
    }
}
