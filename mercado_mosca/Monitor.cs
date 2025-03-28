using System;
using System.Windows.Forms;

namespace mercado_mosca
{
    public partial class Monitor : FormBase
    {
        private Form5 form5;

        public Monitor()
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (form5 != null && !form5.Visible)
            {
                form5.Show();
            }

            this.Hide();
        }

        private void tbq_TextChanged(object sender, EventArgs e)
        {
            int quantidade;

            if (int.TryParse(tbq.Text, out quantidade))
            {
                int valor = 350 * quantidade;
                tbp.Text = valor.ToString("C");
            }
        }

        private void bt_Click(object sender, EventArgs e)
        {
            string nomeProduto = "Monitor quebrado";
            int quantidade = int.Parse(tbq.Text);
            decimal precoUnitario = 350.00m;
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
            Form1 homeForm = new Form1();
            homeForm.Show();
            this.Hide();
        }

        private void Monitor_Load(object sender, EventArgs e)
        {

        }
    }
}
