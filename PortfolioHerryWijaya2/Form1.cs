using PortfolioHerryWijaya2.Model;

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
            var meong = new Gacha();
           var gogo= meong.SeedData();
        }
    }
}
