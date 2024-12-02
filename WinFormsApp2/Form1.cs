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
            // 複数のOrderByがある場合は、最後のOrderByのみ有効（この場合ProductName順になる）
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

        private void button6_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                dg.DataSource = context.Products
                    .OrderByDescending(p => p.Price)
                    .ThenByDescending(p => p.ProductName).ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                dg.DataSource = context.Products
                    .OrderBy(p => p.Price)
                    .ThenByDescending(p => p.ProductName).ToList();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var product = context.Products.Find(4);// DBで使用するFindはプライマリキーを指定する。複数プライマリキーがある場合、Find(4,"A")のようにすればよい
                if (product == null)
                {
                    MessageBox.Show("null!!");
                    return;
                }
                MessageBox.Show(product.ToString());
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var product = context.Products
                    .OrderBy(p => p.Price)
                    .FirstOrDefault(p => p.ProductName.Contains("p"));

                if (product == null)
                {
                    MessageBox.Show("null!!");
                    return;
                }

                MessageBox.Show(product.ToString());

            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var product = context.Products
                    .OrderBy(p => p.Price)
                    .Last(p => p.ProductName.Contains("A"));

                //var product = context.Products
                //    .OrderByDescending(p => p.Price)
                //    .LastOrDefault(p => p.ProductName.Contains("bbb"));

                if (product == null)
                {
                    MessageBox.Show("null!!");
                    return;
                }

                MessageBox.Show(product.ToString());

            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var product = context.Products
                    .OrderByDescending(p => p.Price)
                    .Single(p => p.ProductName.Contains("A"));

                if (product == null)
                {
                    MessageBox.Show("null!!");
                    return;
                }

                MessageBox.Show(product.ToString());

            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var query = (from p in context.Products// 全件取得
                             where p.ProductName.Contains("A")// Aが含まれたもの
                             orderby p.Price descending// 降順
                             select new { p.ProductId, p.ProductName }// 取得項目の選択
                            ).First();// 最初の1件のみ取得
                MessageBox.Show(query.ToString());
                //dg.DataSource = query.ToList();

            }

        }
    }
}
