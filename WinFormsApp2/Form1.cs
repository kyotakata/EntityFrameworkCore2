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
                dataGridView1.DataSource = context.Product.ToList();
            }

        }
    }
}
