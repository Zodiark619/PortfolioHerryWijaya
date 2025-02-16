using PortfolioHerryWijaya2.Model;
using System.Diagnostics;

namespace PortfolioHerryWijaya2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // var meong = new Gacha();
            // var gogo = meong.SeedData();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Process.Start(new ProcessStartInfo("https://www.github.com/Zodiark619") { UseShellExecute = true });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.linkedin.com/in/herry-wijaya-78b7a5216/") { UseShellExecute = true });

        }
    }
}
