using mercado_mosca.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace mercado_mosca
{
    public partial class FormBase : Form
    {
        private Random random = new Random();
        private PictureBox imagemMaior;
        private Image[] imagens;
        private int imagemIndex;
        private Timer timer;
        private bool imagemExibida;

        public FormBase()
        {
            InitializeComponent();
            CarregarImagensDosResources();  
            InicializarTimer();
        }
        public void CarregarImagensDosResources()
        {
            imagens = new Image[]
            {
                Properties.Resources.anuncio1,
                Properties.Resources.anuncio2,
                Properties.Resources.anuncio3,
                Properties.Resources.anuncio4,
                Properties.Resources.anuncio5
            };
        }
        private void InicializarTimer()
        {
            timer = new Timer();
            timer.Interval = 20000; 
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MostrarImagemAleatoria(); 
        }

        private void MostrarImagemAleatoria()
        {
 
            if (imagemMaior == null)
            {
                imagemMaior = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage, 
                    Width = 300,  
                    Height = 300
                };
                this.Controls.Add(imagemMaior);

                imagemMaior.Click += ImagemMaior_Click;
            }

            imagemIndex = random.Next(imagens.Length);
            imagemMaior.Image = imagens[imagemIndex];
            imagemMaior.Visible = true;

            int x = random.Next(0, this.ClientSize.Width - imagemMaior.Width);
            int y = random.Next(0, this.ClientSize.Height - imagemMaior.Height);
            imagemMaior.Location = new Point(x, y);

            imagemMaior.BringToFront(); 
        }
        private void ImagemMaior_Click(object sender, EventArgs e)
        {
            if (imagemMaior != null)
            {
                imagemMaior.Visible = false;
                if (imagemMaior.Image == Properties.Resources.anuncio1)
                {
                    FoneGato homeForm = new FoneGato();
                    homeForm.Show();
                    this.Hide();
                }
                if(imagemMaior.Image == Properties.Resources.anuncio2)
                {
                    Oculos homeForm = new Oculos();
                    homeForm.Show();
                    this.Hide();
                }
                if (imagemMaior.Image == Properties.Resources.anuncio3)
                {
                    Form4 homeForm = new Form4();
                    homeForm.Show();
                    this.Hide();
                }
                if (imagemMaior.Image == Properties.Resources.anuncio4)
                {
                    Form5 homeForm = new Form5();
                    homeForm.Show();
                    this.Hide();
                }
               
            }
            ReiniciarTimer(); 
        }
        private void ReiniciarTimer()
        {
            imagemExibida = false;
            timer.Stop();  
            timer.Start(); 
        }

        protected void ExibirImagemAleatoriaSeNecessario()
        {
            imagemExibida = true; 
            timer.Start();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (imagemMaior != null)
            {
                imagemMaior.Dispose();
            }
        }
    }
}
