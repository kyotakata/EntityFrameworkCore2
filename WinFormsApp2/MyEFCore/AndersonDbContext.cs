using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WinFormsApp2.MyEFCore
{
    /// <summary>
    /// 接続したいデータベースの名前+DbContext
    /// AmazonならAmazonDbContext,TSUTAYAならTSUTAYADbContext
    /// システムの名前が入る
    /// </summary>
    public class AndersonDbContext : DbContext
    {
        /// <summary>
        /// DbSet<TEntity>を介してデータベースにアクセスし、Productデータを全件取得する
        /// プロパティ名はテーブルの名前を指定するが、ModelBuilder.EntityのToTableでテーブル名を指定すれば実際のテーブル名と紐づけることができる。
        /// </summary>
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 接続先情報定義
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"DESKTOP-O4DS0L0";
            builder.InitialCatalog = "AndersonA";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            //UseSqlServerで接続先を指定
            optionsBuilder.UseSqlServer(builder.ConnectionString).LogTo(message =>
            System.Diagnostics.Debug.WriteLine(message),
            new[] { DbLoggerCategory.Database.Command.Name},
            LogLevel.Information);
        }

        private void AAA(string message)
        {

        }

        /// <summary>
        /// テーブル名と主キーの指定
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .ToTable("Product")//実際のテーブル名の指定。実際のテーブル名とDbSet<TEntity>のプロパティ名と必ずしも一緒にしなくてよい
                .HasKey(p => p.ProductId);//主キーの指定(ProductEntity.ProductIdが主キーであることを定義)
                                          // 主キーがModelクラス名+Id出ない場合に指定が必要。
                                          // 復号キーの場合にも指定が必要。
            modelBuilder.Entity<Order>()
                .ToTable("Order");

            modelBuilder.Entity<OrderItem>()
                .ToTable("OrderItem")
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

        }
    }

    /// <summary>
    /// Modelクラス
    /// </summary>
    public class ProductEntity
    {
        // モデル名+IdまたはIdの場合は勝手に主キーと判断してくれるが、
        // そうでない場合はOnModelCreatingをoverrideし、主キーを定義する必要あり。
        public int ProductId { get; set; }
        public string ProductName { get; set; }// varchar(255)はC#でいうところのstring
        public int Price { get; set; }

        public override string ToString()
        {
            return $"Id={ProductId} Name={ProductName} Price={Price}";
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int CostomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();// C#9.0からnew 型名()の「型名」を省略できるようになった
    }

    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public ProductEntity? Product { get; set; }

        public string ProductName => Product?.ProductName;
    }

}
