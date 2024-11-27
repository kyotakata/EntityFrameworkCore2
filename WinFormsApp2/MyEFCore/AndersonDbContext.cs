using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// プロパティ名はテーブルの名前を指定する
        /// </summary>
        public DbSet<ProductEntity> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 接続先情報定義
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"DESKTOP-O4DS0L0";
            builder.InitialCatalog = "AndersonA";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            //UseSqlServerで接続先を指定
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }

        /// <summary>
        /// 主キーの指定(ProductEntity.ProductIdが主キーであることを定義)
        /// 主キーがModelクラス名+Id出ない場合に指定が必要。
        /// 復号キーの場合にも指定が必要。
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasKey(p => p.ProductId);
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

    }
}
