using Microsoft.EntityFrameworkCore;
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
                var product = context.Products.Find(4);// DB�Ŏg�p����Find�̓v���C�}���L�[���w�肷��B�����v���C�}���L�[������ꍇ�AFind(4,"A")�̂悤�ɂ���΂悢
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
                var query = (from p in context.Products// �S���擾
                             where p.ProductName.Contains("A")// A���܂܂ꂽ����
                             orderby p.Price descending// �~��
                             select new { p.ProductId, p.ProductName }// �擾���ڂ̑I��
                            ).First();// �ŏ���1���̂ݎ擾
                MessageBox.Show(query.ToString());
                //dg.DataSource = query.ToList();

            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var products = context.Products
                    .Where(x => EF.Functions.Like(x.ProductName, "%A%"));
                dg.DataSource = products.ToList();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var products = context.Products
                    .Where(x => EF.Functions.Like(x.ProductName, "_A%"));
                dg.DataSource = products.ToList();
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var q = from o in context.Orders
                        select o;
                dg.DataSource = q.ToList();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var q = from o in context.OrderItems
                        select o;
                dg.DataSource = q.ToList();

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var q = from a in context.Orders
                        join b in context.OrderItems
                        on a.OrderId equals b.OrderId
                        select new
                        {
                            a.OrderId,
                            a.CostomerId,
                            a.OrderDate,
                            b.ProductId,
                            b.Quantity,
                            b.Price,
                        };
                dg.DataSource = q.ToList();

            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var q = from a in context.Orders
                        join b in context.OrderItems
                        on a.OrderId equals b.OrderId into bb
                        from b in bb.DefaultIfEmpty()
                        select new
                        {
                            a.OrderId,
                            a.CostomerId,
                            a.OrderDate,
                            ProductId = b != null ? b.ProductId : (int?)null,//int��null���e�^�ɕϊ�
                            Quantity = b != null ? b.Quantity : (int?)null,
                            Price = b != null ? b.Price : (int?)null,
                        };

                dg.DataSource = q.ToList();

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var orders = context.Orders
                    .Include(o => o.OrderItems).ToList();
                dg.DataSource = orders;

            }
        }

        private void dg_SelectionChanged(object sender, EventArgs e)
        {
            var order = dg.CurrentRow.DataBoundItem as Order;
            if (order == null)
            {
                return;
            }
            dg2.DataSource = order.OrderItems;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var orders = context.Orders
                    .Include(o => o.OrderItems)// Orders�ɕR�Â�OrderItems���Ƃ�Ƃ���Include�BInclude�̓��C���ɑ΂��čs���B
                    .ThenInclude(oi => oi.Product);//�R�Â��Ă������(OrderItems)�ɑ΂��ĕR�Â���Ƃ���������Ƃ���ThenInclude
                dg.DataSource = orders.ToList();

            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                dg.DataSource = context.Customers.ToList();
            }
        }
    }

}
