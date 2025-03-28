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
    public partial class Oculos : FormBase
    {
        private Form5 form5;
        public Oculos()
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
                int valor = 180 * quantidade;
                tbp.Text = valor.ToString("C");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nomeProduto = "Óculos de aviador";
            int quantidade = int.Parse(tbq.Text);
            decimal precoUnitario = 180.00m;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 homeForm = new Form4();
            homeForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (form5 != null && !form5.Visible)
            {
                form5.Show();
            }

            this.Hide();
        }
    }
}
