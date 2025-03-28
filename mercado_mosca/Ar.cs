using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mercado_mosca
{
    public partial class Ar : FormBase
    {
        private Form5 form5;

        public Ar()
        {
            InitializeComponent();
            ExibirImagemAleatoriaSeNecessario();
            form5 = Application.OpenForms["Form5"] as Form5;

            if (form5 == null)
            {
                form5 = new Form5();
                form5.Show();
                form5.Hide();
            }
        }


        private void tbq_TextChanged(object sender, EventArgs e)
        {
            int quantidade;

            if (int.TryParse(tbq.Text, out quantidade))
            {
                int valor = 2403 * quantidade;
                tbp.Text = valor.ToString("C");
            }
        }
      
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 homeForm = new Form1();
            homeForm.Show();
            this.Hide();
        }

        private void bt_Click_1(object sender, EventArgs e)
        {
            string nomeProduto = "Ar condicionado de plastico CIAC";
            int quantidade = int.Parse(tbq.Text);
            decimal precoUnitario = 2403.00m;
            decimal precoTotal = quantidade * precoUnitario;


            Form5 form5 = Application.OpenForms["Form5"] as Form5;

            if (form5 != null)
            {

                form5.AdicionarProdutoNaListBox(nomeProduto, quantidade, precoUnitario);
            }
            else
            {
                MessageBox.Show("Form5 não está aberto.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (form5 != null && !form5.Visible)
            {
                form5.Show();
            }

            this.Hide();
        }
    }
}
