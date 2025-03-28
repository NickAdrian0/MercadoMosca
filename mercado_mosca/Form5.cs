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
    public partial class Form5 : Form
    {
        private Dictionary<string, (int quantidade, decimal precoUnitario)> carrinho = new Dictionary<string, (int, decimal)>();

        public Form5()
        {
            InitializeComponent();
            btnRemover.Visible = false; 
        }

        public void AdicionarProdutoNaListBox(string nomeProduto, int quantidade, decimal precoUnitario)
        {
            try
            {
                if (carrinho.ContainsKey(nomeProduto))
                {
                    carrinho[nomeProduto] = (carrinho[nomeProduto].quantidade + quantidade, precoUnitario);
                }
                else
                {
                    carrinho[nomeProduto] = (quantidade, precoUnitario);
                }

                AtualizarListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void AtualizarListBox()
        {
            listBoxProdutos.Items.Clear();
            decimal precoTotal = 0;  

            foreach (var item in carrinho)
            {
                string nomeProduto = item.Key;
                int quantidade = item.Value.quantidade;
                decimal precoUnitario = item.Value.precoUnitario;
                decimal precoProduto = quantidade * precoUnitario;

                listBoxProdutos.Items.Add($"{nomeProduto} - {quantidade}x - Total: R$ {precoProduto:F2}");
                precoTotal += precoProduto;  
            }
            txtPrecoTotal.Text = $"Preço Total: R$ {precoTotal:F2}";

            btnRemover.Visible = listBoxProdutos.Items.Count > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 homeForm = new Form1();
            homeForm.Show();
            this.Hide();
        }

        private void listBoxProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemover.Enabled = listBoxProdutos.SelectedIndex != -1;
        }

        private void btnRemover_Click_1(object sender, EventArgs e)
        {
            if (listBoxProdutos.SelectedIndex != -1)
            {
                string itemSelecionado = listBoxProdutos.SelectedItem.ToString();
                string[] partes = itemSelecionado.Split('-');

                string nomeProduto = partes[0].Trim();
                int quantidadeAtual = int.Parse(partes[1].Trim().Split('x')[0]);
                decimal precoUnitario = carrinho[nomeProduto].precoUnitario;

                if (quantidadeAtual > 1)
                {
                    carrinho[nomeProduto] = (quantidadeAtual - 1, precoUnitario);
                }
                else
                {
                    carrinho.Remove(nomeProduto);
                }

                AtualizarListBox();
            }
            else
            {
                MessageBox.Show("Selecione um produto para remover.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBoxProdutos.Items.Count == 0)
            {
                MessageBox.Show("O carrinho está vazio!");
                return;
            }

            string precoTotal = txtPrecoTotal.Text; 
            Recibo reciboForm = new Recibo(listBoxProdutos.Items, precoTotal);
            reciboForm.Show();
            this.Hide();
        }
    }
}