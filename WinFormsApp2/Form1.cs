using WinFormsApp2.MyEFCore;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                dg.DataSource = context.Products.ToList();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                dg.DataSource = context.Products
                    .Where(x => x.ProductName.Contains("A")).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                dg.DataSource = context.Products.OrderBy(p => p.Price).ToList();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ������OrderBy������ꍇ�́A�Ō��OrderBy�̂ݗL���i���̏ꍇProductName���ɂȂ�j
            using (var context = new AndersonDbContext())
            {
                dg.DataSource = context.Products
                    .OrderBy(p => p.Price)
                    .OrderBy(p => p.ProductName).ToList();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                dg.DataSource = context.Products
                    .OrderBy(p => p.Price)
                    .ThenBy(p => p.ProductName).ToList();
            }
        }
    }
}
