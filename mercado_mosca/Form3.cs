using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mercado_mosca
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 homeForm = new Form2();
            homeForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0 && textBox4.TextLength != 0 && textBox5.TextLength != 0 && textBox6.TextLength != 0 && textBox7.TextLength != 0)
            {
                if (textBox3.Text == textBox4.Text)
                {
                    string dadoscriarconta = $"{textBox1.Text};{textBox2.Text};{textBox3.Text};{textBox4.Text};{textBox5.Text};{textBox6.Text};{textBox7.Text}\n";
                    File.AppendAllText("clienteInfo.txt", dadoscriarconta);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    label9.Text = "Usuario criado com sucesso";
                }
                else label9.Text = "Suas senhas sao discrepantes. Por favor, verifique-as e tente Novamente";
            }
            else label9.Text = "Algum campo esta vazio. Por favor, insira suas credencias e tente novamente";
        }
    }
}
